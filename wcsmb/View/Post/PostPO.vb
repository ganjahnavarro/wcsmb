﻿Public Class PostPO

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        itemsGrid.BackgroundColor = Color.WhiteSmoke
        loadGrid()
        loadUnpostedPurchaseOrders()
    End Sub

    Private Sub loadGrid()
        itemsGrid.Dock = DockStyle.Fill
        itemsGrid.Columns.Clear()

        itemsGrid.Columns.Add("Id", "Id")
        itemsGrid.Columns.Add("poNumber", "PO No.")
        itemsGrid.Columns.Add("Supplier", "Supplier")
        itemsGrid.Columns.Add("Date", "Date")
        itemsGrid.Columns.Add("Amount", "Amount")

        itemsGrid.Columns.Item("Id").Visible = False
        itemsGrid.Columns.Item("Supplier").MinimumWidth = 220

        itemsGrid.Columns.Item("Amount").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight
        itemsGrid.Columns.Item("Amount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub loadUnpostedPurchaseOrders()
        Using context As New DatabaseContext(Constants.CONNECTION_STRING_NAME)
            Dim unposteds = context.purchaseorders _
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
        If Util.askForConfirmation("Post selected Purchase Orders?", "Post") Then
            postSelectedOrders()
        End If
    End Sub

    Private Sub postSelectedOrders()
        Dim ids As New List(Of Integer)
        For Each row As DataGridViewRow In itemsGrid.SelectedRows
            ids.Add(itemsGrid("Id", row.Index).Value)
        Next

        Using context As New DatabaseContext(Constants.CONNECTION_STRING_NAME)
            Dim pos = context.purchaseorders _
                      .Where(Function(c) ids.Contains(c.Id)).ToList()

            For Each order In pos
                order.PostedDate = docDate.Value
                order.ModifyDate = DateTime.Now

                'Posting
                For Each item In order.purchaseorderitems
                    item.stock.QtyOnHand = item.stock.QtyOnHand + item.Quantity
                    item.stock.Cost = item.Price
                Next

                Dim action As String = Controller.currentUser.Username & " posted a purchase order (" &
                    order.DocumentNo & ")"
                context.activities.Add(New activity(action))
            Next
            context.SaveChanges()
        End Using

        Util.notifyInfo(ids.Count & " Purchase Order/s was posted.")
        loadUnpostedPurchaseOrders()
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