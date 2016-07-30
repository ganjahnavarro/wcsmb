﻿Public Class TransSP
    Implements IControl

    Public currentObject As supplierpayment
    Dim checkTotalAmount As Double = 0
    Dim paidTotalAmount As Double = 0
    Dim prevOrderName As String

    Dim orderList As New AutoCompleteStringCollection
    Dim retainIds As New List(Of Integer)
    Dim selectedOrder As purchaseorder

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        Controller.initSuppliers()
        tbSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource
        tbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        tbSupplier.AutoCompleteCustomSource = Controller.supplierList

        loadGrids()
        initialize()
        prevOrderName = String.Empty
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

    Private Sub enterGridChecks_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGridChecks.CellBeginEdit
        btnCheck.Visible = False
    End Sub

    Private Sub enterGridChecks_GotFocus(sender As Object, e As EventArgs) Handles enterGridChecks.GotFocus
        enterGridOrders.ClearSelection()
    End Sub

    Private Sub enterGridOrders_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGridOrders.CellBeginEdit
        btnCheck.Visible = False
    End Sub

    Private Sub enterGridOrders_GotFocus(sender As Object, e As EventArgs) Handles enterGridOrders.GotFocus
        enterGridChecks.ClearSelection()
    End Sub

    Private Sub initialize()
        Me.reset()
        Me.loadObject()
        Me.showUpdateButtons(False)
        Controller.updateMode = Nothing
        Me.enableInputs(False)
    End Sub

    Public Sub addClick() Handles btnAdd.Click
        If Not IsNothing(Me) And btnAdd.Visible Then
            Me.reset()
            Me.enableInputs(True)
            Controller.updateMode = Constants.UPDATE_MODE_CREATE
            showUpdateButtons(True)
        End If
    End Sub

    Public Sub editClick() Handles btnEdit.Click
        If Not IsNothing(Me) And btnEdit.Visible Then
            Controller.updateMode = Constants.UPDATE_MODE_EDIT
            Me.enableInputs(True)
            Me.loadObject()
            showUpdateButtons(True)
            reloadOrders(tbSupplier.Text)
            updateTotalAmount()
        End If
    End Sub

    Public Sub deleteClick() Handles btnDelete.Click
        If Not IsNothing(Me) And btnDelete.Visible Then
            If Util.askForConfirmation("Delete this item?", "Delete") Then
                Me.deleteObject()
                Me.resetListSelection()
                resetMe()
            End If
        End If
    End Sub

    Public Sub cancelClick() Handles btnCancel.Click
        If Not IsNothing(Me) And btnCancel.Visible Then
            Util.clearRows(enterGridOrders)
            Util.clearRows(enterGridChecks)
            resetMe()
        End If
    End Sub

    Public Sub checkClick() Handles btnCheck.Click
        If Not IsNothing(Me) And btnCheck.Visible Then
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
        If Not IsNothing(Me) And btnNext.Visible Then
            Me.nextObject()
        End If
    End Sub

    Private Sub nextDblClick() Handles btnNext.DoubleClick
        If Not IsNothing(Me) And btnNext.Visible Then
            Me.lastObject()
        End If
    End Sub

    Private Sub previousClick() Handles btnPrev.Click
        If Not IsNothing(Me) And btnPrev.Visible Then
            Me.previousObject()
        End If
    End Sub

    Private Sub previousDblClick() Handles btnPrev.DoubleClick
        If Not IsNothing(Me) And btnPrev.Visible Then
            Me.firstObject()
        End If
    End Sub

    Public Sub searchClick() Handles btnSearch.Click
        If Not IsNothing(Me) And btnSearch.Visible Then
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
        showUpdateButtons(False)
        Controller.updateMode = Nothing
        Me.enableInputs(False)
        Me.loadObject()
    End Sub

    Public Sub showUpdateButtons(ByVal show As Boolean)
        btnCheck.Visible = show
        btnCancel.Visible = show

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
    End Sub

#End Region

    Private Sub loadGrids()
        loadEnterGridChecks()
        loadEnterGridOrders()
    End Sub

    Private Sub loadEnterGridChecks()
        enterGridChecks.Dock = DockStyle.Fill
        Util.clearRows(enterGridChecks)
        enterGridChecks.Columns.Clear()

        enterGridChecks.Columns.Add("Id", "Id")
        enterGridChecks.Columns.Add("Check", "Check No.")
        enterGridChecks.Columns.Add("Date", "Date")
        enterGridChecks.Columns.Add("Amount", "Amount")

        enterGridChecks.Columns.Item("Id").Visible = False

        enterGridChecks.Columns.Item("Amount").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight
        enterGridChecks.Columns.Item("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub loadEnterGridOrders()
        enterGridOrders.Dock = DockStyle.Fill
        Util.clearRows(enterGridOrders)
        enterGridOrders.Columns.Clear()

        enterGridOrders.Columns.Add("Id", "Id")
        enterGridOrders.Columns.Add("PO", "PO")
        enterGridOrders.Columns.Add("Date", "Date")
        enterGridOrders.Columns.Add("Balance", "Balance")
        enterGridOrders.Columns.Add("Paid", "Paid")

        enterGridOrders.Columns.Item("Id").Visible = False
        setReadOnlyColumns()

        enterGridOrders.Columns.Item("Balance").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight
        enterGridOrders.Columns.Item("Paid").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight

        enterGridOrders.Columns.Item("Balance").DefaultCellStyle.Format = "N2"
        enterGridOrders.Columns.Item("Paid").DefaultCellStyle.Format = "N2"
    End Sub

    Public Sub deleteObject() Implements IControl.deleteObject
        Using context As New DatabaseContext()
            currentObject = context.supplierpayments.Where(Function(c) _
                c.Id.Equals(currentObject.Id)).FirstOrDefault
            context.paymentcheckitems.RemoveRange(currentObject.paymentcheckitems)
            context.paymentorderitems.RemoveRange(currentObject.paymentorderitems)
            context.supplierpayments.Remove(currentObject)

            Dim action As String = Controller.currentUser.Username & " deleted a supplier payment (" &
                currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
        End Using

        currentObject = Nothing
    End Sub

    Public Sub deleteRow() Implements IControl.deleteRow
        If Not IsNothing(Controller.updateMode) AndAlso enterGridChecks.Focused _
            AndAlso Not IsNothing(enterGridChecks.CurrentCell) _
            AndAlso enterGridChecks.CurrentCell.RowIndex >= 0 Then
            Try
                enterGridChecks.Rows.RemoveAt(enterGridChecks.CurrentCell.RowIndex)
                updateTotalAmount()
            Catch ex As Exception
                For Each cell As DataGridViewCell In enterGridChecks _
                        .Rows(enterGridChecks.CurrentCell.RowIndex).Cells()
                    cell.Value = String.Empty
                Next
            End Try
        End If

        If Not IsNothing(Controller.updateMode) AndAlso enterGridOrders.Focused _
            AndAlso Not IsNothing(enterGridOrders.CurrentCell) _
            AndAlso enterGridOrders.CurrentCell.RowIndex >= 0 Then
            Try
                enterGridOrders.Rows.RemoveAt(enterGridOrders.CurrentCell.RowIndex)
                updateTotalAmount()
            Catch ex As Exception
                For Each cell As DataGridViewCell In enterGridOrders _
                        .Rows(enterGridOrders.CurrentCell.RowIndex).Cells()
                    cell.Value = String.Empty
                Next
            End Try
        End If
    End Sub

    Private Sub updateTotalAmount()
        updateCheckTotalAmount()
        updateOrdersTotalAmount()
    End Sub

    Private Sub updateCheckTotalAmount()
        checkTotalAmount = 0
        For rowIndex = 0 To enterGridChecks.RowCount - 2
            Dim amount As Double
            Double.TryParse(enterGridChecks("Amount", rowIndex).Value, amount)
            checkTotalAmount += amount
        Next
        tbTotalCheck.Text = FormatNumber(CDbl(checkTotalAmount), 2)
    End Sub

    Private Sub updateOrdersTotalAmount()
        paidTotalAmount = 0
        For rowIndex = 0 To enterGridOrders.RowCount - 2
            Dim amount As Double
            Double.TryParse(enterGridOrders("Paid", rowIndex).Value, amount)
            paidTotalAmount += amount
        Next
        tbTotalPaid.Text = FormatNumber(CDbl(paidTotalAmount), 2)
    End Sub

    Public Sub enableInputs(enable As Boolean) Implements IControl.enableInputs
        tbRemarks.Enabled = enable
        docDate.Enabled = enable
        tbSupplier.Enabled = enable
        tbBank.Enabled = enable

        enterGridChecks.ReadOnly = Not enable
        enterGridOrders.ReadOnly = Not enable
        setReadOnlyColumns()

        If enable Then
            tbSupplier.Focus()
            enterGridChecks.ClearSelection()
            enterGridOrders.ClearSelection()
        End If

        addItems.Visible = If(enable AndAlso Not IsNothing(Controller.updateMode) _
            AndAlso Controller.updateMode.Equals(Constants.UPDATE_MODE_EDIT), True, False)
    End Sub
    Public Sub nextObject() Implements IControl.nextObject
        If IsNothing(currentObject) Then
            Exit Sub
        End If

        Using context As New DatabaseContext()
            Dim nextObj As New supplierpayment
            nextObj = context.supplierpayments _
                .Where(Function(c) c.DocumentNo.CompareTo(currentObject.DocumentNo) > 0) _
                .OrderBy(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(nextObj) Then
                currentObject = nextObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub previousObject() Implements IControl.previousObject
        Using context As New DatabaseContext()
            Dim prevObj As New supplierpayment
            prevObj = context.supplierpayments _
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
            Dim firstObj As New supplierpayment
            firstObj = context.supplierpayments _
                .OrderBy(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(firstObj) Then
                currentObject = firstObj
                loadObject()
            End If
        End Using
    End Sub

    Public Sub lastObject() Implements IControl.lastObject
        Using context As New DatabaseContext()
            Dim lastObj As New supplierpayment
            lastObj = context.supplierpayments _
                .OrderByDescending(Function(c) c.DocumentNo).FirstOrDefault

            If Not IsNothing(lastObj) Then
                currentObject = lastObj
                loadObject()
            End If
        End Using
    End Sub

    Public Function getAllowEditDelete() As Boolean Implements IControl.getAllowEditDelete
        Return If(IsNothing(currentObject) OrElse Not IsNothing(currentObject.PostedDate), False, True)
    End Function

    Public Function getButtonsShown() As Integer Implements IControl.getButtonsShown
        Return Constants.SHOW_ALL
    End Function

    Public Function getErrorMessage() As String Implements IControl.getErrorMessage
        If String.IsNullOrWhiteSpace(tbSupplier.Text) Then
            Return "Supplier name is required."
        End If

        If IsNothing(docDate.Value) Then
            Return "Date is required."
        End If

        If Not Controller.supplierList.Contains(tbSupplier.Text.ToUpper) Then
            Return "Invalid Supplier."
        End If

        If enterGridChecks.RowCount <= 1 Then
            Return Constants.ERROR_MSG_INPUT_ITEMS
        End If

        If enterGridOrders.RowCount <= 1 Then
            Return Constants.ERROR_MSG_INPUT_ITEMS
        End If

        Return Nothing
    End Function

    Public Sub loadObject() Implements IControl.loadObject
        Using context As New DatabaseContext()

            If Not IsNothing(currentObject) Then
                currentObject = context.supplierpayments _
                    .Include("Supplier").Include("PaymentOrderItems") _
                    .Include("PaymentCheckItems") _
                .Where(Function(f) f.Id.Equals(currentObject.Id)) _
                .FirstOrDefault()
                loadCurrentObject()
            Else
                currentObject = context.supplierpayments _
                    .Include("Supplier").Include("PaymentOrderItems") _
                    .Include("PaymentCheckItems") _
                .OrderByDescending(Function(f) f.DocumentNo) _
                .FirstOrDefault()

                If Not IsNothing(currentObject) Then
                    loadCurrentObject()
                Else
                    reset()
                End If
            End If
        End Using
    End Sub

    Private Sub loadCurrentObject()
        lblBy.Text = Util.fmtModifyBy(currentObject.ModifyBy)
        lblOn.Text = Util.fmtModifyDate(currentObject.ModifyDate)
        lblBy.Visible = True
        lblOn.Visible = True

        tbBank.Text = currentObject.Bank
        tbRemarks.Text = currentObject.Remarks
        docDate.Value = currentObject.Date
        tbTotalCheck.Text = FormatNumber(CDbl(currentObject.TotalCheck), 2)
        tbTotalPaid.Text = FormatNumber(CDbl(currentObject.TotalPaid), 2)
        tbSupplier.Text = currentObject.supplier.Name
        tbDocNo.Text = currentObject.DocumentNo

        Dim modifiable = If(IsNothing(Controller.updateMode) And IsNothing(currentObject.PostedDate), True, False)
        btnEdit.Visible = modifiable
        btnDelete.Visible = modifiable

        loadObjectItems()
    End Sub

    Private Sub loadObjectItems()
        loadCheckItems()
        loadOrderItems()
    End Sub

    Private Sub loadCheckItems()
        Util.clearRows(enterGridChecks)

        For Each orderItem In currentObject.paymentcheckitems
            enterGridChecks.Rows.Add(
                orderItem.Id,
                orderItem.DocumentNo,
                Format(orderItem.Date, Constants.DATE_FORMAT),
                orderItem.Amount)
        Next
    End Sub

    Private Sub loadOrderItems()
        Util.clearRows(enterGridOrders)

        For Each orderItem In currentObject.paymentorderitems
            enterGridOrders.Rows.Add(
                orderItem.Id,
                orderItem.purchaseorder.DocumentNo,
                Format(orderItem.purchaseorder.Date),
                orderItem.BalanceGot,
                orderItem.Amount)
        Next
    End Sub

    Public Sub reset() Implements IControl.reset
        lblBy.Visible = False
        lblOn.Visible = False

        tbDocNo.Text = String.Empty
        tbRemarks.Text = String.Empty
        tbTotalCheck.Text = String.Empty
        tbTotalPaid.Text = String.Empty
        tbBank.Text = String.Empty
        docDate.Value = DateTime.Today
        tbSupplier.Text = String.Empty

        Util.clearRows(enterGridChecks)
        Util.clearRows(enterGridOrders)
    End Sub

    Public Sub resetListSelection() Implements IControl.resetListSelection
    End Sub

    Public Sub saveObject() Implements IControl.saveObject
        Using context As New DatabaseContext()
            currentObject = New supplierpayment
            setObjectValues(context)

            context.supplierpayments.Add(currentObject)

            Dim action As String = Controller.currentUser.Username & " created a supplier payment (" &
                currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
            Util.notifyInfo("Created 1 Supplier Payment.")
        End Using
    End Sub

    Public Sub search() Implements IControl.search
        EtcSearch.openUp(Me.Name)
    End Sub

    Public Sub setObjectValues(ByRef context As DatabaseContext)
        updateTotalAmount()

        currentObject.Date = docDate.Value
        currentObject.Remarks = tbRemarks.Text
        currentObject.TotalPaid = paidTotalAmount
        currentObject.TotalCheck = checkTotalAmount

        currentObject.Bank = If(String.IsNullOrEmpty(tbBank.Text),
            Constants.DEFAULT_BANK, tbBank.Text)

        currentObject.ModifyBy = Controller.currentUser.Username
        currentObject.ModifyDate = DateTime.Now

        If String.IsNullOrEmpty(tbSupplier.Text) Then
            currentObject.supplier = Nothing
        Else
            currentObject.supplierId = context.suppliers _
                .Where(Function(c) c.Name.ToUpper.Equals(tbSupplier.Text.ToUpper) And c.Active = True) _
                .Select(Function(c) c.Id).FirstOrDefault
        End If

        setObjectItemsValues(context)
    End Sub

    Private Sub setObjectItemsValues(ByRef context As DatabaseContext)
        setCheckItemsValues(context)
        setOrderItemsValues(context)
    End Sub

    Private Sub setCheckItemsValues(ByRef context As DatabaseContext)
        retainIds.Clear()

        For rowIndex = 0 To enterGridChecks.RowCount - 2

            Dim itemId As Integer = If(String.IsNullOrEmpty(enterGridChecks("Id", rowIndex).Value),
                Nothing, enterGridChecks("Id", rowIndex).Value)

            If Not IsNothing(itemId) And itemId <> 0 Then
                For Each item In currentObject.paymentcheckitems
                    If itemId = item.Id Then
                        setCheckItem(item, rowIndex)
                        retainIds.Add(itemId)
                        Exit For
                    End If
                Next
            Else
                Dim orderItem As New paymentcheckitem
                setCheckItem(orderItem, rowIndex)
                currentObject.paymentcheckitems.Add(orderItem)
            End If
        Next

        For count = currentObject.paymentcheckitems.Count - 1 To 0 Step -1
            If Not IsNothing(currentObject.paymentcheckitems(count).Id) _
                And currentObject.paymentcheckitems(count).Id <> 0 _
                And Not retainIds.Contains(currentObject.paymentcheckitems(count).Id) Then

                context.paymentcheckitems _
                    .Remove(currentObject.paymentcheckitems(count))
            End If
        Next
    End Sub

    Private Sub setCheckItem(ByRef item As paymentcheckitem, ByVal rowIndex As Integer)
        item.DocumentNo = enterGridChecks("Check", rowIndex).Value
        item.Amount = enterGridChecks("Amount", rowIndex).Value
        Date.TryParse(enterGridChecks("Date", rowIndex).Value, item.Date)
    End Sub

    Private Sub enterGridChecks_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGridChecks.RowValidating
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If Not String.IsNullOrWhiteSpace(enterGridChecks("Check", e.RowIndex).Value) _
                OrElse Not String.IsNullOrWhiteSpace(enterGridChecks("Amount", e.RowIndex).Value) _
                OrElse Not String.IsNullOrWhiteSpace(enterGridChecks("Date", e.RowIndex).Value) Then

                If String.IsNullOrWhiteSpace(enterGridChecks("Check", e.RowIndex).Value) Then
                    Util.notifyError("Check is required.")
                    e.Cancel = True
                    enterGridChecks.CurrentCell = enterGridChecks("Check", e.RowIndex)
                    Exit Sub
                End If

                If String.IsNullOrWhiteSpace(enterGridChecks("Amount", e.RowIndex).Value) Then
                    Util.notifyError("Amount is required.")
                    e.Cancel = True
                    enterGridChecks.CurrentCell = enterGridChecks("Amount", e.RowIndex)
                    Exit Sub
                End If

                If String.IsNullOrWhiteSpace(enterGridChecks("Date", e.RowIndex).Value) Then
                    Util.notifyError("Date is required.")
                    e.Cancel = True
                    enterGridChecks.CurrentCell = enterGridChecks("Date", e.RowIndex)
                    Exit Sub
                End If

                Dim dt As DateTime
                DateTime.TryParse(enterGridChecks("Date", e.RowIndex).Value, dt)

                If dt.CompareTo(Util.getValidDate) < 0 Then
                    Util.notifyError("Invalid Date.")
                    e.Cancel = True
                    enterGridChecks.CurrentCell = enterGridChecks("Date", e.RowIndex)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub setOrderItemsValues(ByRef context As DatabaseContext)
        retainIds.Clear()

        For rowIndex = 0 To enterGridOrders.RowCount - 2

            Dim itemId As Integer = If(String.IsNullOrEmpty(enterGridOrders("Id", rowIndex).Value),
                    Nothing, enterGridOrders("Id", rowIndex).Value)

            If Not IsNothing(itemId) And itemId <> 0 Then
                For Each item In currentObject.paymentorderitems
                    If itemId = item.Id Then
                        setOrderItem(item, rowIndex, context)
                        retainIds.Add(itemId)
                        Exit For
                    End If
                Next
            Else
                Dim orderItem As New paymentorderitem
                setOrderItem(orderItem, rowIndex, context)
                currentObject.paymentorderitems.Add(orderItem)
            End If
        Next

        For count = currentObject.paymentorderitems.Count - 1 To 0 Step -1
            Dim tmpId As Integer = currentObject.paymentorderitems(count).Id

            If Not IsNothing(tmpId) And tmpId <> 0 _
                And Not retainIds.Contains(tmpId) Then

                Dim item = context.paymentorderitems.Single(Function(c) c.Id.Equals(tmpId))
                context.paymentorderitems.Remove(item)
            End If
        Next
    End Sub

    Private Sub setOrderItem(ByRef item As paymentorderitem,
           ByVal rowIndex As Integer, ByRef context As DatabaseContext)
        Dim docNo As String = enterGridOrders("PO", rowIndex).Value
        item.purchaseorderId = context.purchaseorders _
            .Where(Function(c) c.DocumentNo.ToUpper.Equals(docNo.ToUpper)) _
            .Select(Function(c) c.Id).FirstOrDefault
        item.Amount = enterGridOrders("Paid", rowIndex).Value
        item.BalanceGot = enterGridOrders("Balance", rowIndex).Value
    End Sub

    Public Sub updateObject() Implements IControl.updateObject
        Using context As New DatabaseContext()
            currentObject = context.supplierpayments _
                .Where(Function(c) c.Id.Equals(currentObject.Id)).FirstOrDefault()
            setObjectValues(context)

            Dim action As String = Controller.currentUser.Username & " updated a supplier payment (" &
                currentObject.DocumentNo & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
            Util.notifyInfo("Updated 1 Supplier Payment.")
        End Using
    End Sub

    Private Sub reloadOrders(ByVal name As String)
        orderList.Clear()
        Using context As New DatabaseContext()
            Dim qry As String = "select c.* from purchaseorders c, suppliers s " &
                "where c.supplierId = s.Id and ucase(s.Name) = '" _
                & name.ToUpper & "' and s.active = true"

            orderList.AddRange(context.purchaseorders.SqlQuery(qry) _
                .Select(Function(c) c.DocumentNo.ToUpper) _
                .Distinct().ToArray())
        End Using
    End Sub

    Private Sub enterGridOrders_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles enterGridOrders.CellValidated
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            Select Case e.ColumnIndex
                Case 1
                    orderChanged(e)
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub orderChanged(ByVal e As DataGridViewCellEventArgs)
        orderChanged(e.RowIndex)
    End Sub

    Private Sub orderChanged(ByVal rowIndex As Integer)
        If Not IsNothing(enterGridOrders("PO", rowIndex).Value) Then
            Dim orderDocNo As String = enterGridOrders("PO", rowIndex).Value.ToString

            If Not String.IsNullOrEmpty(orderDocNo) Then
                If orderDocNo.ToUpper.Equals(prevOrderName.ToUpper) Then
                    Exit Sub
                End If

                prevOrderName = orderDocNo
                Using context As New DatabaseContext()
                    selectedOrder = context.purchaseorders _
                        .Where(Function(c) c.DocumentNo.ToUpper.Equals(orderDocNo.ToUpper)) _
                        .FirstOrDefault

                    If Not IsNothing(selectedOrder) Then
                        enterGridOrders("Paid", rowIndex).Value = 0
                        updateOrdersTotalAmount()

                        Dim remaining As Double = checkTotalAmount - paidTotalAmount

                        enterGridOrders("Date", rowIndex).Value = Format(selectedOrder.Date, Constants.DATE_FORMAT)
                        enterGridOrders("Balance", rowIndex).Value = selectedOrder.getBalance
                        enterGridOrders("Paid", rowIndex).Value =
                            If(remaining >= selectedOrder.getBalance, selectedOrder.getBalance, remaining)
                    End If
                End Using
            End If
            updateOrdersTotalAmount()
        End If
    End Sub

    Private Sub enterGridChecks_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles enterGridChecks.CellValueChanged
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If e.ColumnIndex = 3 Then
                updateCheckTotalAmount()
                updatePaidFromChecks()
            End If
        End If
    End Sub

    Private Sub enterGridOrders_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles enterGridOrders.EditingControlShowing
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If enterGridOrders.Columns.Item(enterGridOrders.CurrentCell.ColumnIndex).HeaderText = "PO" Then
                Dim tb As TextBox = e.Control
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                tb.AutoCompleteCustomSource = orderList
            Else
                Dim tb As TextBox = e.Control
                tb.AutoCompleteMode = AutoCompleteMode.None
            End If
        End If
    End Sub

    Private Sub enterGridOrders_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGridOrders.RowValidating
        If Not IsNothing(Controller.updateMode) Then
            If Not String.IsNullOrWhiteSpace(enterGridOrders("PO", e.RowIndex).Value) Then
                If Not orderList.Contains(enterGridOrders("PO", e.RowIndex).Value.ToString.ToUpper) Then
                    Util.notifyError("Invalid Purchase Order.")
                    e.Cancel = True
                    enterGridOrders.CurrentCell = enterGridOrders("PO", e.RowIndex)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Public Sub printObject() Implements IControl.printObject
    End Sub

    Dim previousFilter As String

    Private Sub tbSupplier_GotFocus(sender As Object, e As EventArgs) Handles tbSupplier.GotFocus
        previousFilter = tbSupplier.Text
    End Sub

    Private Sub tbSupplierValidated(sender As Object, e As EventArgs) Handles tbSupplier.Validated
        If Not String.IsNullOrEmpty(Controller.updateMode) _
            AndAlso Not previousFilter.ToUpper.Equals(tbSupplier.Text) Then
            Util.clearRows(enterGridOrders)

            If String.IsNullOrEmpty(tbSupplier.Text) Then
                enterGridOrders.ReadOnly = True
                orderList.Clear()
                addItems.Visible = False
            Else
                reloadOrders(tbSupplier.Text)
                enterGridOrders.ReadOnly = False
                addItems.Visible = True
            End If
        End If
    End Sub

    Public Sub showSelection() Handles addItems.Click
        If addItems.Visible Then
            Dim addedOrders As New List(Of String)

            For rowIndex = 0 To enterGridOrders.RowCount - 2
                Dim doc = enterGridOrders("", rowIndex).Value

                If Not IsNothing(doc) Then
                    addedOrders.Add(doc.ToString.ToUpper)
                End If
            Next

            SelectSP.addedOrders = addedOrders
            SelectSP.supplierName = tbSupplier.Text
            SelectSP.initialPaid = paidTotalAmount
            SelectSP.totalCheck = checkTotalAmount
            SelectSP.openUp(Me.Name)
        End If
    End Sub

    Private Sub updatePaidFromChecks()
        Dim remaining As Double = checkTotalAmount

        For rowIndex = 0 To enterGridOrders.RowCount - 2
            Dim balance, paid As Double
            Double.TryParse(enterGridOrders("Balance", rowIndex).Value, balance)

            paid = If(remaining >= balance, balance, remaining)
            enterGridOrders("Paid", rowIndex).Value = FormatNumber(paid, 2)
            remaining = remaining - balance
        Next

        updateOrdersTotalAmount()
    End Sub

    Public Sub addOrders(ByVal orders As List(Of String))
        For Each order In orders
            enterGridOrders.Rows.Add(String.Empty, order)
            enterGridOrders.CurrentCell = enterGridOrders("PO", enterGridOrders.RowCount - 2)

            prevOrderName = String.Empty
            orderChanged(enterGridOrders.CurrentCell.RowIndex)
        Next
    End Sub

    Private Sub enterGridOrders_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles enterGridOrders.RowEnter
        Dim orderValue = enterGridOrders("PO", e.RowIndex).Value
        prevOrderName = If(Not IsNothing(orderValue), orderValue, String.Empty)
    End Sub

    Private Sub enterGrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles enterGridOrders.CellEnter
        If Not String.IsNullOrEmpty(Controller.updateMode) Then
            If enterGridOrders.Focused AndAlso enterGridOrders.CurrentCell.ReadOnly Then
                SendKeys.Send("{TAB}")
            End If

            addItems.Visible = Not enterGridOrders.IsCurrentRowDirty
        End If
    End Sub

    Private Sub setReadOnlyColumns()
        enterGridOrders.Columns.Item("Date").ReadOnly = True
        enterGridOrders.Columns.Item("Balance").ReadOnly = True
        enterGridOrders.Columns.Item("Paid").ReadOnly = True
    End Sub

End Class