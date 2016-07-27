﻿Public Class SelectCC

    Public selectedOrders As New List(Of String)
    Public addedOrders As New List(Of String)

    Public customerName As String
    Public initialPaid As Double
    Public totalCheck As Double

    Public Sub openUp(ByVal fromScreen As String)
        Controller.previousForm = fromScreen
        Controller.currentForm = Me.Name
        Me.ShowDialog()
    End Sub

    Private Sub etcFormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Controller.currentForm = Controller.previousForm
    End Sub

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        tbTotalCheck.Text = FormatNumber(totalCheck, 2)

        loadGrid()
        loadObjects()
    End Sub

    Private Sub loadGrid()
        itemsGrid.Dock = DockStyle.Fill
        itemsGrid.Columns.Clear()

        itemsGrid.Columns.Add("Id", "Id")
        itemsGrid.Columns.Add("SO", "SO No.")
        itemsGrid.Columns.Add("Date", "Date")
        itemsGrid.Columns.Add("Balance", "Balance")

        itemsGrid.Columns.Item("Id").Visible = False
        itemsGrid.Columns.Item("Balance").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub loadObjects()
        itemsGrid.Rows.Clear()

        Using context As New DatabaseContext()
            Dim hasRecords As Boolean = False
            Dim withBalances = context.salesorders _
                .Where(Function(c) c.customer.Name.ToUpper.Equals(customerName.ToUpper) _
                    AndAlso Not addedOrders.Contains(c.DocumentNo.ToUpper) AndAlso Not c.PostedDate.Equals(Nothing) _
                    AndAlso c.customer.Active = True) _
                .OrderBy(Function(c) c.DocumentNo).ToList()

            For Each obj In withBalances
                If obj.getBalance > 0 Then
                    itemsGrid.Rows.Add(
                    obj.Id,
                    obj.DocumentNo,
                    Format(obj.Date, Constants.DATE_FORMAT),
                    obj.getBalance)

                    hasRecords = True
                End If
            Next

            lblNoRecords.Visible = Not hasRecords
        End Using
    End Sub

    Private Sub itemsGrid_SelectionChanged(sender As Object, e As EventArgs) Handles itemsGrid.SelectionChanged
        updateSelection()
    End Sub

    Private Sub updateSelection()
        selectedOrders.Clear()
        Dim total As Double = initialPaid

        For Each row As DataGridViewRow In itemsGrid.SelectedRows
            Dim balance As Double
            Double.TryParse(itemsGrid("Balance", row.Index).Value, balance)
            total += balance

            If balance > 0 Then
                selectedOrders.Add(itemsGrid("SO", row.Index).Value)
            End If
        Next

        tbTotalPaid.Text = FormatNumber(total, 2)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        TransCC.addOrders(selectedOrders)
        Me.Close()
    End Sub

End Class