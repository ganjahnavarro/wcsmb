﻿Public Class PostCC

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGrid()
        loadUnposteds()
    End Sub

    Private Sub loadGrid()
        itemsGrid.Dock = DockStyle.Fill
        itemsGrid.Columns.Clear()

        itemsGrid.Columns.Add("Id", "Id")
        itemsGrid.Columns.Add("Collection", "Coll No.")
        itemsGrid.Columns.Add("Customer", "Customer")
        itemsGrid.Columns.Add("Date", "Date")
        itemsGrid.Columns.Add("PaidAmount", "Paid Amount")

        itemsGrid.Columns.Item("Id").Visible = False
        itemsGrid.Columns.Item("Customer").MinimumWidth = 220

        itemsGrid.Columns.Item("PaidAmount").DefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleRight
        itemsGrid.Columns.Item("PaidAmount").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub loadUnposteds()
        Using context As New DatabaseContext()
            Dim unposteds = context.customercollections _
                .Where(Function(c) c.PostedDate.Equals(Nothing)).ToList()

            itemsGrid.Rows.Clear()

            For Each obj In unposteds
                itemsGrid.Rows.Add(
                    obj.Id,
                    obj.DocumentNo,
                    obj.customer.Name,
                    Format(obj.Date, Constants.DATE_FORMAT),
                    obj.TotalPaid)
            Next

            lblNoRecords.Visible = If(unposteds.Count = 0, True, False)
            checkSelection()
        End Using
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If Util.askForConfirmation("Post selected Customer Collections?", "Post") Then
            postSelectedOrders()
        End If
    End Sub

    Private Sub postSelectedOrders()
        Dim ids As New List(Of Integer)
        For Each row As DataGridViewRow In itemsGrid.SelectedRows
            ids.Add(itemsGrid("Id", row.Index).Value)
        Next

        Using context As New DatabaseContext()
            Dim ccs = context.customercollections _
                      .Where(Function(c) ids.Contains(c.Id)).ToList()

            For Each cc In ccs
                cc.PostedDate = docDate.Value
                cc.ModifyDate = DateTime.Now

                Dim action As String = Controller.currentUser.Username &
                    " posted a customer collection (" & cc.DocumentNo & ")"
                context.activities.Add(New activity(action))

                'Posting
                For Each so In cc.collectionorderitems
                    so.salesorder.TotalPaid += so.Amount
                    so.salesorder.ModifyDate = DateTime.Now
                Next
            Next
            context.SaveChanges()
        End Using

        Util.notifyInfo(ids.Count & " Customer Collection/s was posted.")
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