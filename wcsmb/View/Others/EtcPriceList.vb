Public Class EtcPriceList

    Dim customer As customer
    Dim customerPrice As customerprice
    Dim previousAmount As Double

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        Controller.initCustomers()
        tbCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource
        tbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        tbCustomer.AutoCompleteCustomSource = Controller.customerList

        loadGrid()
    End Sub

    Private Sub loadGrid()
        enterGrid.Dock = DockStyle.Fill
        Util.clearRows(enterGrid)
        enterGrid.Columns.Clear()

        enterGrid.Columns.Add("Id", "Id")
        enterGrid.Columns.Add("Stock", "Stock")
        enterGrid.Columns.Add("Description", "Description")
        enterGrid.Columns.Add("DefaultPrice", "Default Price")
        enterGrid.Columns.Add("Price", "Price")
        enterGrid.Columns.Add("StockId", "StockId")

        enterGrid.Columns.Item("Id").Visible = False
        enterGrid.Columns.Item("StockId").Visible = False
        setReadOnlyColumns()

        enterGrid.Columns.Item("DefaultPrice").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        enterGrid.Columns.Item("Price").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight

        enterGrid.Columns.Item("DefaultPrice").DefaultCellStyle.Format = "N2"
        enterGrid.Columns.Item("Price").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub setReadOnlyColumns()
        enterGrid.Columns.Item("Stock").ReadOnly = True
        enterGrid.Columns.Item("Description").ReadOnly = True
        enterGrid.Columns.Item("DefaultPrice").ReadOnly = True
    End Sub

    Private Sub tbCustomer_TextChanged(sender As Object, e As EventArgs) Handles tbCustomer.TextChanged
        Using context As New DatabaseContext()
            customer = context.customers.Where(Function(c) _
                c.Name.ToUpper.Equals(tbCustomer.Text.ToUpper) And c.Active = True).FirstOrDefault

            lblCustomerType.Text = If(Not IsNothing(customer), customer.Type, String.Empty)
        End Using
    End Sub

    Private Sub findCustomerPrices()
        If IsNothing(customer) Then
            Util.notifyError("Invalid customer.")
            Exit Sub
        End If

        Dim customerStockPrices As List(Of _CustomerStockPrice)
        Dim defaultPrice = If(customer.Type.Equals(Constants.CUSTOMER_TYPE_RETAILER), "s.retailprice", "s.wholesaleprice")

        Dim queryString As String = "select cp.id as id, s.name as stock, s.description, " &
            defaultPrice & " as defaultPrice, " &
            " coalesce(cp.price, " & defaultPrice & ") as price, s.id as stockId from stocks s left join  " &
            " (select c.Id, c.price, c.stockId, c.customerId from customerprice c where c.customerId = " & customer.Id & ") cp" &
            " on cp.stockId = s.id where s.active = true and upper(s.name) like '%" & tbStock.Text.ToUpper & "%'" &
            " limit 100"

        Using context As New DatabaseContext()
            customerStockPrices = context.Database _
                .SqlQuery(Of _CustomerStockPrice)(queryString) _
                .ToList()
        End Using

        If Not IsNothing(customerStockPrices) Then
            loadCustomerStockPrices(customerStockPrices)
        End If
    End Sub

    Private Sub loadCustomerStockPrices(ByVal items As List(Of _CustomerStockPrice))
        Util.clearRows(enterGrid)

        For Each item In items
            enterGrid.Rows.Add(
                item.Id,
                item.Stock,
                item.Description,
                item.DefaultPrice,
                item.Price,
                item.StockId)
        Next
    End Sub

    Private Sub tbStock_KeyDown(sender As Object, e As KeyEventArgs) Handles tbStock.KeyDown
        If e.KeyData.Equals(Keys.Enter) Then
            findCustomerPrices()
        End If
    End Sub

    Private Sub enterGrid_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.CellValueChanged
        Dim customerPriceId As Integer
        Integer.TryParse(enterGrid("Id", e.RowIndex).Value, customerPriceId)

        Dim newPrice As Double
        Double.TryParse(enterGrid("Price", e.RowIndex).Value, newPrice)

        If newPrice <= 0 Then
            enterGrid("Price", e.RowIndex).Value = previousAmount
            Util.notifyError("Invalid amount.")
            Exit Sub
        End If

        Dim stockId As Integer
        Integer.TryParse(enterGrid("StockId", e.RowIndex).Value, stockId)

        Using context As New DatabaseContext
            If customerPriceId <= 0 Then
                'new
                customerPrice = New customerprice
                customerPrice.stockId = stockId
                customerPrice.customerId = customer.Id
                customerPrice.Price = newPrice
                context.customerprices.Add(customerPrice)
            Else
                'update
                customerPrice = context.customerprices _
                    .Where(Function(c) c.Id.Equals(customerPriceId)).FirstOrDefault
                customerPrice.Price = newPrice
            End If

            context.SaveChanges()
        End Using

        enterGrid("Id", e.RowIndex).Value = customerPrice.Id
    End Sub

    Private Sub enterGrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles enterGrid.CellEnter
        If enterGrid.Focused AndAlso enterGrid.CurrentCell.ReadOnly Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub enterGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles enterGrid.CellBeginEdit
        Double.TryParse(enterGrid("Price", e.RowIndex).Value, previousAmount)
    End Sub

End Class