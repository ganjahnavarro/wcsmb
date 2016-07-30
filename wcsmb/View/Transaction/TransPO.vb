﻿Public Class TransPO
    Implements IControl

    Dim printDoc As New PrintTransaction

    Public currentObject As purchaseorder
    Dim totalAmount As Double
    Dim selectedStock As stock
    Dim retainIds As New List(Of Integer)

    Dim prevStockName As String

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        Controller.initSuppliers()
        tbSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource
        tbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        tbSupplier.AutoCompleteCustomSource = Controller.supplierList

        loadGrid()
        initialize()
        prevStockName = String.Empty
    End Sub

#Region "Standard"
    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Enter
                Return MyBase.ProcessDialogKey(Keys.Tab)
        End Select
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Public Sub validateItems()
        btnCheck.Visible = True
        btnCheck.Focus()
    End Sub

    Private Sub enterGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGrid.CellBeginEdit
        btnCheck.Visible = False
    End Sub

    Private Sub initialize()
        Me.reset()
        Me.loadObject()
        Me.enableInputs(False)
        Me.showUpdateButtons(False)
        Controller.updateMode = Nothing
    End Sub

    Public Sub addClick() Handles btnAdd.Click
        If btnAdd.Visible Then
            Me.reset()
            Me.enableInputs(True)
            Controller.updateMode = Constants.UPDATE_MODE_CREATE
            showUpdateButtons(True)
        End If
    End Sub

    Public Sub editClick() Handles btnEdit.Click
        If btnEdit.Visible Then
            Me.enableInputs(True)
            Controller.updateMode = Constants.UPDATE_MODE_EDIT
            Me.loadObject()
            showUpdateButtons(True)
        End If
    End Sub

    Public Sub deleteClick() Handles btnDelete.Click
        If btnDelete.Visible Then
            If Util.askForConfirmation("Delete this item?", "Delete") Then
                Me.deleteObject()
                Me.resetListSelection()
                resetMe()
            End If
        End If
    End Sub

    Public Sub cancelClick() Handles btnCancel.Click
        If btnCancel.Visible Then
            Util.clearRows(enterGrid)
            resetMe()
        End If
    End Sub

    Public Sub checkClick() Handles btnCheck.Click
        If btnCheck.Visible Then
            If Not IsNothing(Me.getErrorMessage) Then
                Util.notifyError(Me.getErrorMessage)
            Else
                Try
                    saveChangesOnMe()
                    resetMe()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub nextClick() Handles btnNext.Click
        If btnNext.Visible Then
            Me.nextObject()
        End If
    End Sub

    Private Sub nextDblClick() Handles btnNext.DoubleClick
        If btnNext.Visible Then
            Me.lastObject()
        End If
    End Sub

    Private Sub previousClick() Handles btnPrev.Click
        If btnPrev.Visible Then
            Me.previousObject()
        End If
    End Sub

    Private Sub previousDblClick() Handles btnPrev.DoubleClick
        If btnPrev.Visible Then
            Me.firstObject()
        End If
    End Sub

    Public Sub searchClick() Handles btnSearch.Click
        If btnSearch.Visible Then
            Me.search()
        End If
    End Sub

    Private Sub saveChangesOnMe()
        If Controller.updateMode = Constants.UPDATE_MODE_CREATE Then
            Me.saveObject()
        Else
            Me.updateObject()
        End If
    End Sub

    Private Sub resetMe()
        Me.reset()
        Me.enableInputs(False)
        showUpdateButtons(False)
        Controller.updateMode = Nothing
        Me.loadObject()
    End Sub

    Public Sub showUpdateButtons(ByVal show As Boolean)
        btnCheck.Visible = show
        btnCancel.Visible = show

        stockDescription.Text = String.Empty
        stockDescription.Visible = show

        btnAdd.Visible = Not show

        If getAllowEditDelete() Then
            btnEdit.Visible = Not show
            btnDelete.Visible = Not show
        Else
            btnEdit.Visible = False
            btnDelete.Visible = False
        End If

        btnPrev.Visible = Not show
        btnNext.Visible = Not show
        btnSearch.Visible = Not show
        btnPrint.Visible = Not show
    End Sub

#End Region

    Public Function getAllowEditDelete() As Boolean Implements IControl.getAllowEditDelete
        Return If(IsNothing(currentObject) OrElse Not IsNothing(currentObject.PostedDate), False, True)
    End Function

    Public Sub deleteObject() Implements IControl.deleteObject
        Using context As New DatabaseContext()
            currentObject = context.purchaseorders.Where(Function(c) _
                c.Id.Equals(currentObject.Id)).FirstOrDefault
            context.purchaseorderitems.RemoveRange(currentObject.purchaseorderitems)
            context.purchaseorders.Remove(currentObject)

            Dim action As String = Controller.currentUser.Username & " deleted a purchase order (" &
                   currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
        End Using

        currentObject = Nothing
    End Sub

    Public Sub deleteRow() Implements IControl.deleteRow
        If Not IsNothing(Controller.updateMode) AndAlso Not IsNothing(enterGrid.CurrentCell) _
            AndAlso enterGrid.CurrentCell.RowIndex >= 0 Then
            Try
                enterGrid.Rows.RemoveAt(enterGrid.CurrentCell.RowIndex)
                updateTotalAmount()
            Catch ex As Exception
                For Each cell As DataGridViewCell In enterGrid _
                        .Rows(enterGrid.CurrentCell.RowIndex).Cells()
                    cell.Value = String.Empty
                Next
            End Try
        End If
    End Sub

    Public Sub enableInputs(enable As Boolean) Implements IControl.enableInputs
        tbDocNo.Enabled = enable
        tbRemarks.Enabled = enable
        docDate.Enabled = enable
        tbSupplier.Enabled = enable

        enterGrid.ReadOnly = Not enable
        setReadOnlyColumns()

        If enable Then
            tbDocNo.Focus()
            enterGrid.ClearSelection()
        End If
    End Sub

    Public Sub loadObject() Implements IControl.loadObject
        Using context As New DatabaseContext()
            If Not IsNothing(currentObject) Then
                currentObject = context.purchaseorders _
                    .Include("PurchaseOrderItems").Include("Supplier") _
                    .Where(Function(f) f.Id.Equals(currentObject.Id)) _
                    .FirstOrDefault
                loadCurrentObject()
            Else
                currentObject = context.purchaseorders _
                    .Include("PurchaseOrderItems").Include("Supplier") _
                    .OrderByDescending(Function(f) f.DocumentNo) _
                    .FirstOrDefault

                If Not IsNothing(currentObject) Then
                    loadCurrentObject()
                Else
                    reset()
                End If
            End If
        End Using
    End Sub

    Public Sub nextObject() Implements IControl.nextObject
        If IsNothing(currentObject) Then
            Exit Sub
        End If

        Using context As New DatabaseContext()
            Dim nextObj As New purchaseorder
            nextObj = context.purchaseorders _
                .Where(Function(c) c.DocumentNo.CompareTo(currentObject.DocumentNo) > 0) _
                .OrderBy(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(nextObj) Then
                currentObject = nextObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub previousObject() Implements IControl.previousObject
        If IsNothing(currentObject) Then
            Exit Sub
        End If

        Using context As New DatabaseContext()
            Dim prevObj As New purchaseorder
            prevObj = context.purchaseorders _
                .Where(Function(c) c.DocumentNo.CompareTo(currentObject.DocumentNo) < 0) _
                .OrderByDescending(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(prevObj) Then
                currentObject = prevObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub firstObject() Implements IControl.firstObject
        Using context As New DatabaseContext()
            Dim firstObj As New purchaseorder
            firstObj = context.purchaseorders _
                .OrderBy(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(firstObj) Then
                currentObject = firstObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub lastObject() Implements IControl.lastObject
        Using context As New DatabaseContext()
            Dim lastObj As New purchaseorder
            lastObj = context.purchaseorders _
                .OrderByDescending(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(lastObj) Then
                currentObject = lastObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub reset() Implements IControl.reset
        lblBy.Visible = False
        lblOn.Visible = False

        tbDocNo.Text = String.Empty
        tbRemarks.Text = String.Empty
        tbTotalAmt.Text = String.Empty
        docDate.Value = DateTime.Today
        tbSupplier.Text = String.Empty

        Util.clearRows(enterGrid)
    End Sub

    Public Sub saveObject() Implements IControl.saveObject
        Using context As New DatabaseContext()
            currentObject = New purchaseorder
            setObjectValues(context)
            context.purchaseorders.Add(currentObject)

            Dim action As String = Controller.currentUser.Username & " create a purchase order (" &
                   currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            Try
                context.SaveChanges()
            Catch ex As Exception
                MsgBox("Error: " + ex.Message)

            End Try

            Util.notifyInfo("Created 1 Purchase Order.")
        End Using
    End Sub

    Public Sub search() Implements IControl.search
        EtcSearch.openUp(Me.Name)
    End Sub

    Public Sub setObjectValues(ByRef context As DatabaseContext)
        updateTotalAmount()
        currentObject.DocumentNo = tbDocNo.Text
        currentObject.Date = docDate.Value
        currentObject.ModifyBy = Controller.currentUser.Username
        currentObject.ModifyDate = DateTime.Now
        currentObject.Remarks = tbRemarks.Text
        currentObject.TotalAmount = totalAmount

        If String.IsNullOrWhiteSpace(tbSupplier.Text) Then
            currentObject.supplier = Nothing
        Else
            currentObject.supplierId = context.suppliers _
                    .Where(Function(c) c.Name.ToUpper.Equals(tbSupplier.Text.ToUpper) And c.Active = True) _
                    .Select(Function(c) c.Id).FirstOrDefault
        End If

        setObjectItemsValues(context)
    End Sub

    Public Function showAllButtons() As Integer Implements IControl.getButtonsShown
        Return Constants.SHOW_ALL
    End Function

    Public Sub updateObject() Implements IControl.updateObject
        Using context As New DatabaseContext()
            currentObject = context.purchaseorders _
                    .Where(Function(c) c.Id.Equals(currentObject.Id)).FirstOrDefault()
            setObjectValues(context)

            Dim action As String = Controller.currentUser.Username & " updated a purchase order (" &
                   currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
            Util.notifyInfo("Updated 1 Purchase Order.")
        End Using
    End Sub

    Public Function getErrorMessage() As String Implements IControl.getErrorMessage
        If String.IsNullOrWhiteSpace(tbDocNo.Text) Then
            Return "Document No. is required."
        End If

        If IsNothing(docDate.Value) Then
            Return "Date is required."
        End If

        If String.IsNullOrEmpty(tbSupplier.Text) Then
            Return "Supplier is required."
        End If

        If Controller.updateMode.Equals(Constants.UPDATE_MODE_CREATE) _
            OrElse Not currentObject.DocumentNo.ToUpper.Equals(tbDocNo.Text.ToUpper) Then
            Dim duplicateDocNo As String
            Using context As New DatabaseContext()
                duplicateDocNo = context.purchaseorders _
                    .Where(Function(c) c.DocumentNo.ToUpper.Equals(tbDocNo.Text.ToUpper)) _
                    .Select(Function(c) c.DocumentNo).FirstOrDefault
            End Using

            If Not String.IsNullOrEmpty(duplicateDocNo) Then
                Return "Document No. already exists."
            End If
        End If

        If Not Controller.supplierList.Contains(tbSupplier.Text.ToUpper) Then
            Return "Invalid Supplier name."
        End If

        If enterGrid.RowCount <= 1 Then
            Return Constants.ERROR_MSG_INPUT_ITEMS
        End If

        Return Nothing
    End Function

    Private Sub loadCurrentObject()
        lblBy.Text = Util.fmtModifyBy(currentObject.ModifyBy)
        lblOn.Text = Util.fmtModifyDate(currentObject.ModifyDate)
        lblBy.Visible = True
        lblOn.Visible = True

        tbDocNo.Text = currentObject.DocumentNo
        tbRemarks.Text = currentObject.Remarks
        docDate.Value = currentObject.Date
        tbTotalAmt.Text = FormatNumber(CDbl(currentObject.TotalAmount), 2)
        tbSupplier.Text = currentObject.supplier.Name

        Dim modifiable = If(IsNothing(Controller.updateMode) And IsNothing(currentObject.PostedDate), True, False)
        btnEdit.Visible = modifiable
        btnDelete.Visible = modifiable

        loadObjectItems(currentObject.purchaseorderitems.ToList())
    End Sub

    Private Sub loadObjectItems(ByVal orderItems As List(Of purchaseorderitem))
        Util.clearRows(enterGrid)

        Dim hasDisc1, hasDisc2, hasDisc3 As Boolean

        For Each orderItem In orderItems
            enterGrid.Rows.Add(
                orderItem.Id,
                orderItem.stock.Name,
                orderItem.stock.Description,
                orderItem.Quantity,
                orderItem.stock.unit.Name,
                orderItem.Price,
                orderItem.Discount1,
                orderItem.Discount2,
                orderItem.Discount3,
                getRowAmount(orderItem.Quantity, orderItem.Price, orderItem.Discount1,
                    orderItem.Discount2, orderItem.Discount3))

            hasDisc1 = If(orderItem.Discount1 > 0, True, hasDisc1)
            hasDisc2 = If(orderItem.Discount2 > 0, True, hasDisc2)
            hasDisc3 = If(orderItem.Discount3 > 0, True, hasDisc3)
        Next

        enterGrid.Columns.Item("Disc1").Visible = hasDisc1
        enterGrid.Columns.Item("Disc2").Visible = hasDisc2
        enterGrid.Columns.Item("Disc3").Visible = hasDisc3
    End Sub

    Private Sub loadGrid()
        enterGrid.Dock = DockStyle.Fill
        Util.clearRows(enterGrid)
        enterGrid.Columns.Clear()

        enterGrid.Columns.Add("Id", "Id")
        enterGrid.Columns.Add("Stock", "Stock")
        enterGrid.Columns.Add("Desc", "Description")
        enterGrid.Columns.Add("Qty", "Qty")
        enterGrid.Columns.Add("Unit", "Unit")
        enterGrid.Columns.Add("Price", "Price")
        enterGrid.Columns.Add("Disc1", "D1")
        enterGrid.Columns.Add("Disc2", "D2")
        enterGrid.Columns.Add("Disc3", "D3")
        enterGrid.Columns.Add("Amount", "Amount")

        enterGrid.Columns.Item("Qty").Width = 40
        enterGrid.Columns.Item("Unit").Width = 40

        enterGrid.Columns.Item("Stock").MinimumWidth = 130
        enterGrid.Columns.Item("Amount").MinimumWidth = 100
        enterGrid.Columns.Item("Desc").MinimumWidth = 140

        enterGrid.Columns.Item("Id").Visible = False
        setReadOnlyColumns()

        enterGrid.Columns.Item("Price").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        enterGrid.Columns.Item("Disc1").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        enterGrid.Columns.Item("Disc2").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        enterGrid.Columns.Item("Disc3").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        enterGrid.Columns.Item("Amount").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight

        enterGrid.Columns.Item("Price").DefaultCellStyle.Format = "N2"
        enterGrid.Columns.Item("Disc1").DefaultCellStyle.Format = "N2"
        enterGrid.Columns.Item("Disc2").DefaultCellStyle.Format = "N2"
        enterGrid.Columns.Item("Disc3").DefaultCellStyle.Format = "N2"
        enterGrid.Columns.Item("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub enterGrid_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.CellValidated
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            Select Case e.ColumnIndex
                Case 1
                    stockChanged(e)
                    Exit Select
                Case 3, 5, 6, 7, 8
                    varsChanged(e)
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub stockChanged(ByVal e As DataGridViewCellEventArgs)
        If Not IsNothing(enterGrid("Stock", e.RowIndex).Value) Then
            Dim stockName As String = enterGrid("Stock", e.RowIndex).Value.ToString

            If Not IsNothing(stockName) Then
                If stockName.ToUpper.Equals(prevStockName.ToUpper) Then
                    Exit Sub
                End If

                prevStockName = stockName

                Using context As New DatabaseContext()
                    selectedStock = context.stocks _
                        .Where(Function(c) c.Name.Equals(stockName) And c.Active = True).FirstOrDefault

                    If Not IsNothing(selectedStock) Then
                        enterGrid("Desc", e.RowIndex).Value = selectedStock.Description
                        enterGrid("Unit", e.RowIndex).Value = selectedStock.unit.Name

                        'If IsNothing(enterGrid("Price", e.RowIndex).Value) Then
                        enterGrid("Price", e.RowIndex).Value =
                            If(selectedStock.Cost = 0, selectedStock.WholesalePrice, selectedStock.Cost)
                        'End If

                        If IsNothing(enterGrid("Qty", e.RowIndex).Value) Then
                            enterGrid("Qty", e.RowIndex).Value = 1
                        End If

                        varsChanged(e)
                    End If
                End Using
            End If
            updateTotalAmount()
        End If
    End Sub

    Private Sub varsChanged(ByVal e As DataGridViewCellEventArgs)
        varsChanged(e.RowIndex)
    End Sub

    Private Sub varsChanged(ByVal idx As Integer)
        enterGrid("Amount", idx).Value = getRowAmount(idx)
        updateTotalAmount()
    End Sub

    Private Function getRowAmount(ByVal rowIndex As Integer) As Double
        Dim qty, price, disc1, disc2, disc3 As Double

        Double.TryParse(enterGrid("Qty", rowIndex).Value, qty)
        Double.TryParse(enterGrid("Price", rowIndex).Value, price)
        Double.TryParse(enterGrid("Disc1", rowIndex).Value, disc1)
        Double.TryParse(enterGrid("Disc2", rowIndex).Value, disc2)
        Double.TryParse(enterGrid("Disc3", rowIndex).Value, disc3)

        Return getRowAmount(qty, price, disc1, disc2, disc3)
    End Function

    Public Function getRowAmount(ByVal qty As Double, ByVal price As Double,
            ByVal disc1 As Double, ByVal disc2 As Double, ByVal disc3 As Double) As Double
        If Not IsNothing(qty) And Not IsNothing(price) Then
            Dim amount = qty * price
            amount = If(IsNothing(disc1), amount,
                        amount - (amount * (disc1 / 100)))
            amount = If(IsNothing(disc2), amount,
                        amount - (amount * (disc2 / 100)))
            amount = If(IsNothing(disc3), amount,
                        amount - (amount * (disc3 / 100)))
            Return amount
        End If

        Return Nothing
    End Function

    Private Sub updateTotalAmount()
        totalAmount = 0

        For rowIndex = 0 To enterGrid.RowCount - 2
            totalAmount += If(IsNothing(getRowAmount(rowIndex)), 0, getRowAmount(rowIndex))
        Next

        tbTotalAmt.Text = FormatNumber(CDbl(totalAmount), 2)
    End Sub

    Private Sub setObjectItemsValues(ByRef context As DatabaseContext)
        retainIds.Clear()

        For rowIndex = 0 To enterGrid.RowCount - 2

            Dim itemId As Integer = If(String.IsNullOrEmpty(enterGrid("Id", rowIndex).Value),
                Nothing, enterGrid("Id", rowIndex).Value)

            If Not IsNothing(itemId) And itemId <> 0 Then
                For Each orderItem In currentObject.purchaseorderitems
                    If itemId = orderItem.Id Then
                        setItemValues(orderItem, rowIndex, context)
                        retainIds.Add(itemId)
                        Exit For
                    End If
                Next
            Else
                Dim orderItem As New purchaseorderitem
                setItemValues(orderItem, rowIndex, context)
                currentObject.purchaseorderitems.Add(orderItem)
            End If
        Next

        For count = currentObject.purchaseorderitems.Count - 1 To 0 Step -1
            If Not IsNothing(currentObject.purchaseorderitems(count).Id) _
                And currentObject.purchaseorderitems(count).Id <> 0 _
                And Not retainIds.Contains(currentObject.purchaseorderitems(count).Id) Then

                context.purchaseorderitems _
                    .Remove(currentObject.purchaseorderitems(count))
            End If
        Next
    End Sub

    Private Sub setItemValues(ByRef orderItem As purchaseorderitem,
                              ByVal rowIndex As Integer, ByRef context As DatabaseContext)
        Dim stockName As String = enterGrid("Stock", rowIndex).Value

        orderItem.Price = enterGrid("Price", rowIndex).Value
        orderItem.Quantity = enterGrid("Qty", rowIndex).Value

        Dim disc1, disc2, disc3 As Double
        Double.TryParse(enterGrid("Disc1", rowIndex).Value, disc1)
        Double.TryParse(enterGrid("Disc2", rowIndex).Value, disc2)
        Double.TryParse(enterGrid("Disc3", rowIndex).Value, disc3)

        orderItem.Discount1 = disc1
        orderItem.Discount2 = disc2
        orderItem.Discount3 = disc3

        orderItem.stockId = context.stocks _
            .Where(Function(c) c.Name.ToUpper.Equals(stockName.Trim.ToUpper) And c.Active = True) _
            .Select(Function(c) c.Id).FirstOrDefault
    End Sub

    Public Sub resetListSelection() Implements IControl.resetListSelection
    End Sub

    Private Sub enterGrid_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles enterGrid.EditingControlShowing
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If enterGrid.Columns.Item(enterGrid.CurrentCell.ColumnIndex).HeaderText = "Stock" Then
                Dim tb As TextBox = e.Control
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                tb.AutoCompleteCustomSource = Controller.stockList

                AddHandler tb.TextChanged, AddressOf stockInputChanged
            Else
                Dim tb As TextBox = e.Control
                tb.AutoCompleteMode = AutoCompleteMode.None
            End If
        End If
    End Sub

    Private Sub stockInputChanged(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            Dim tb As TextBox = sender

            If Controller.stockDictionary.ContainsKey(tb.Text) Then
                Controller.stockDictionary.TryGetValue(tb.Text, stockDescription.Text)
            Else
                stockDescription.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub enterGrid_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGrid.RowValidating
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If Not String.IsNullOrWhiteSpace(enterGrid("Stock", e.RowIndex).Value) Then

                Dim stockName = enterGrid("Stock", e.RowIndex).Value

                If Not IsNothing(stockName) AndAlso Not Controller.stockList.Contains(stockName.ToString.Trim.ToUpper) Then
                    Util.notifyError("Invalid Stock Name.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Stock", e.RowIndex)
                    Exit Sub
                End If

                Dim price, disc1, disc2, disc3 As Double
                Dim qty As Integer

                Double.TryParse(enterGrid("Price", e.RowIndex).Value, price)
                Double.TryParse(enterGrid("Disc1", e.RowIndex).Value, disc1)
                Double.TryParse(enterGrid("Disc2", e.RowIndex).Value, disc2)
                Double.TryParse(enterGrid("Disc3", e.RowIndex).Value, disc3)
                Integer.TryParse(enterGrid("Qty", e.RowIndex).Value, qty)

                If IsNothing(price) OrElse price < 0 Then
                    Util.notifyError("Invalid Price value.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Price", e.RowIndex)
                    Exit Sub
                End If

                If IsNothing(disc1) OrElse disc1 < 0 Then
                    Util.notifyError("Invalid Discount-1 value.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Disc1", e.RowIndex)
                    Exit Sub
                End If

                If IsNothing(disc2) OrElse disc2 < 0 Then
                    Util.notifyError("Invalid Discount-2 value.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Disc2", e.RowIndex)
                    Exit Sub
                End If

                If IsNothing(disc3) OrElse disc3 < 0 Then
                    Util.notifyError("Invalid Discount-3 value.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Disc3", e.RowIndex)
                    Exit Sub
                End If

                If IsNothing(qty) OrElse qty < 0 Then
                    Util.notifyError("Invalid Quantity value.")
                    e.Cancel = True
                    enterGrid.CurrentCell = enterGrid("Qty", e.RowIndex)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Public Sub printObject() Implements IControl.printObject
        If btnPrint.Visible And Not IsNothing(currentObject) Then
            Using context As New DatabaseContext()
                printDoc.name = currentObject.supplier.Name
                printDoc.address = currentObject.supplier.Address
                printDoc.docNo = currentObject.DocumentNo
                printDoc.docDate = currentObject.Date
                printDoc.agent = String.Empty

                printDoc.items = context.Database _
                    .SqlQuery(Of _Transaction)(
                        "select i.quantity, if(i.quantity > 1, u.pluralname, u.name) as unit, s.name as stock, " &
                        "s.description, i.price, i.discount1, i.discount2, i.discount3 " &
                        "from purchaseorderitems i, stocks s, units u " &
                        "where i.stockid = s.id and s.unitid = u.id " &
                        "and i.purchaseorderid = '" & currentObject.Id & "'") _
                    .ToList()
            End Using

            Util.previewDocument(printDoc)
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        printObject()
    End Sub

    Private Sub enterGrid_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.RowEnter
        Dim stockValue = enterGrid("Stock", e.RowIndex).Value
        prevStockName = If(Not IsNothing(stockValue), stockValue, String.Empty)
    End Sub

    Private Sub enterGrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.CellEnter
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If enterGrid.Focused AndAlso enterGrid.CurrentCell.ReadOnly Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub setReadOnlyColumns()
        enterGrid.Columns.Item("Desc").ReadOnly = True
        enterGrid.Columns.Item("Unit").ReadOnly = True
        enterGrid.Columns.Item("Amount").ReadOnly = True
    End Sub

    Public Sub addOrderItem(ByVal values As List(Of String))
        Dim qty As Integer
        Dim price, d1, d2, d3 As Double

        Integer.TryParse(values(3), qty)
        Double.TryParse(values(5), price)
        Double.TryParse(values(9), d1)
        Double.TryParse(values(10), d2)
        Double.TryParse(values(11), d3)

        enterGrid.Rows.Add(values(0), values(1), values(2),
            qty, values(4), price, d1, d2, d3,
            getRowAmount(qty, price, d1, d2, d3))

        enterGrid.CurrentCell = enterGrid("Stock", enterGrid.RowCount - 2)
    End Sub

    Private Sub enterGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub enterGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.CellContentClick

    End Sub

    Private Sub tbTotalAmt_TextChanged(sender As Object, e As EventArgs) Handles tbTotalAmt.TextChanged

    End Sub

    Private Sub lblPostedDate_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub lblPostedOn_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub tbRemarks_TextChanged(sender As Object, e As EventArgs) Handles tbRemarks.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub docDate_ValueChanged(sender As Object, e As EventArgs) Handles docDate.ValueChanged

    End Sub

    Private Sub tbDocNo_TextChanged(sender As Object, e As EventArgs) Handles tbDocNo.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblUnitName_Click(sender As Object, e As EventArgs) Handles lblUnitName.Click

    End Sub

    Private Sub lblOn_Click(sender As Object, e As EventArgs) Handles lblOn.Click

    End Sub

    Private Sub lblBy_Click(sender As Object, e As EventArgs) Handles lblBy.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub tbSupplier_TextChanged(sender As Object, e As EventArgs) Handles tbSupplier.TextChanged

    End Sub

    Private Sub notificationPanel_Paint(sender As Object, e As PaintEventArgs) Handles notificationPanel.Paint

    End Sub

    Private Sub notificationClose_Click(sender As Object, e As EventArgs) Handles notificationClose.Click

    End Sub

    Private Sub notificationLabel_Click(sender As Object, e As EventArgs) Handles notificationLabel.Click

    End Sub

    Private Sub stockDescription_Click(sender As Object, e As EventArgs) Handles stockDescription.Click

    End Sub
End Class