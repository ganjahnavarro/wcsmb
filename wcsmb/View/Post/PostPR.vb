﻿Public Class PostPR

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        itemsGrid.BackgroundColor = Color.WhiteSmoke
        loadGrid()
        loadUnposteds()
    End Sub

    Private Sub loadGrid()
        itemsGrid.Dock = DockStyle.Fill
        itemsGrid.Columns.Clear()

        itemsGrid.Columns.Add("Id", "Id")
        itemsGrid.Columns.Add("prNumber", "PR No.")
        itemsGrid.Columns.Add("Supplier", "Supplier")
        itemsGrid.Columns.Add("Date", "Date")
        itemsGrid.Columns.Add("Amount", "Amount")

        itemsGrid.Columns.Item("Id").Visible = False
        itemsGrid.Columns.Item("Supplier").MinimumWidth = 220

        itemsGrid.Columns.Item("Amount").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight
        itemsGrid.Columns.Item("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub loadUnposteds()
        Using context As New DatabaseContext(Constants.CONNECTION_STRING_NAME)
            Dim unposteds = context.purchasereturns _
                .Where(Function(c) c.PostedDate.Equals(Nothing)).ToList()

            itemsGrid.Rows.Clear()

            For Each obj In unposteds
                itemsGrid.Rows.Add(
                    obj.Id,
                    obj.DocumentNo,
                    obj.supplier.Name,
                    Format(obj.Date, Constants.DATE_FORMAT),
                    obj.TotalAmount)
            Next

            lblNoRecords.Visible = If(unposteds.Count = 0, True, False)
            checkSelection()
        End Using
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If Util.askForConfirmation("Post selected Purchase Returns?", "Post") Then
            postSelectedOrders()
        End If
    End Sub

    Private Sub postSelectedOrders()
        Dim ids As New List(Of Integer)
        For Each row As DataGridViewRow In itemsGrid.SelectedRows
            ids.Add(itemsGrid("Id", row.Index).Value)
        Next

        Using context As New DatabaseContext(Constants.CONNECTION_STRING_NAME)
            Dim returns = context.purchasereturns _
                      .Where(Function(c) ids.Contains(c.Id)).ToList()

            For Each rtn In returns
                rtn.PostedDate = docDate.Value
                rtn.ModifyDate = DateTime.Now

                Dim action As String = Controller.currentUser.Username & " posted a purchase return (" &
                    rtn.DocumentNo & ")"
                context.activities.Add(New activity(action))

                'Posting
                Dim poUsed As New List(Of purchaseorder)

                For Each rtnItem In rtn.purchasereturnitems
                    Dim totalReturn = rtnItem.Quantity

                    Dim qry As String = "select i.* from purchaseorderitems i, suppliers sup, stocks s, purchaseorders po " &
                        "where i.purchaseorderid = po.id and i.stockid = s.id and po.supplierid = sup.id " &
                        "and po.posteddate is not null and ucase(sup.name) = '" & rtn.supplier.Name.ToUpper & "' " &
                        "and s.id = '" & rtnItem.stockId & "' and i.discount1 = '" & rtnItem.Discount1 & "' " &
                        "and i.discount2 = '" & rtnItem.Discount2 & "' and i.discount3 = '" & rtnItem.Discount3 &
                        "' and sup.active = true and i.price = '" & rtnItem.Price & "'"

                    Dim poItems = context.purchaseorderitems.SqlQuery(qry) _
                        .OrderByDescending(Function(c) c.Id).ToList

                    poUsed.Clear()

                    'Update total qty returned of po items
                    For Each poItem In poItems
                        If Not poUsed.Contains(poItem.purchaseorder) Then
                            poUsed.Add(poItem.purchaseorder)
                        End If

                        If poItem.getRemainingQuantity < totalReturn Then
                            poItem.QuantityReturned += poItem.getRemainingQuantity
                        Else
                            poItem.QuantityReturned += totalReturn
                        End If

                        totalReturn = totalReturn - poItem.QuantityReturned

                        If totalReturn = 0 Then
                            Exit For
                        End If
                    Next

                    'Update total returned of purchaseorders
                    For Each po In poUsed
                        po.TotalReturned = po.getTotalReturnedFromItems
                        po.ModifyDate = DateTime.Now
                    Next

                    rtnItem.stock.QtyOnHand += rtnItem.Quantity
                Next
            Next
            context.SaveChangesAsync()
        End Using

        Util.notifyInfo(ids.Count & " Purchase Return/s was posted.")
        loadUnposteds()
    End Sub

    Private Sub btnMark_Click(sender As Object, e As EventArgs) Handles btnMark.Click
        itemsGrid.SelectAll()
        checkSelection()
    End Sub

    Private Sub btnUnmark_Click(sender As Object, e As EventArgs) Handles btnUnmark.Click
        itemsGrid.ClearSelection()
        checkSelection()
    End Sub

    Private Sub checkSelection()
        btn3.Visible = If(itemsGrid.SelectedRows.Count = 0, False, True)
    End Sub

    Private Sub itemsGrid_SelectionChanged(sender As Object, e As EventArgs) Handles itemsGrid.SelectionChanged
        checkSelection()
    End Sub

End Class