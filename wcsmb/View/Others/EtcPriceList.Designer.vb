<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EtcPriceList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtcPriceList))
        Me.tbCustomer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbStock = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.enterGrid = New wcsmb.EnterDataGridView()
        Me.lblCustomerType = New System.Windows.Forms.Label()
        Me.notificationPanel = New System.Windows.Forms.Panel()
        Me.notificationClose = New System.Windows.Forms.Label()
        Me.notificationLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.enterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notificationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCustomer
        '
        Me.tbCustomer.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbCustomer.Location = New System.Drawing.Point(167, 34)
        Me.tbCustomer.Name = "tbCustomer"
        Me.tbCustomer.Size = New System.Drawing.Size(350, 32)
        Me.tbCustomer.TabIndex = 112
        Me.tbCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 23)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Stock"
        '
        'tbStock
        '
        Me.tbStock.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbStock.Location = New System.Drawing.Point(167, 82)
        Me.tbStock.Name = "tbStock"
        Me.tbStock.Size = New System.Drawing.Size(350, 32)
        Me.tbStock.TabIndex = 115
        Me.tbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel1.Controls.Add(Me.enterGrid)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 13.0!)
        Me.Panel1.Location = New System.Drawing.Point(37, 146)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(606, 386)
        Me.Panel1.TabIndex = 127
        '
        'enterGrid
        '
        Me.enterGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.enterGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.enterGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.enterGrid.BackgroundColor = System.Drawing.SystemColors.Window
        Me.enterGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.enterGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumSeaGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 13.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSeaGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.enterGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.enterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 13.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.enterGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.enterGrid.EnableHeadersVisualStyles = False
        Me.enterGrid.GridColor = System.Drawing.Color.Gainsboro
        Me.enterGrid.Location = New System.Drawing.Point(4, 4)
        Me.enterGrid.MultiSelect = False
        Me.enterGrid.Name = "enterGrid"
        Me.enterGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.MediumSeaGreen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 13.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumSeaGreen
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.enterGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.enterGrid.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        Me.enterGrid.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.enterGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.enterGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.enterGrid.Size = New System.Drawing.Size(598, 378)
        Me.enterGrid.TabIndex = 132
        '
        'lblCustomerType
        '
        Me.lblCustomerType.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerType.ForeColor = System.Drawing.Color.DimGray
        Me.lblCustomerType.Location = New System.Drawing.Point(532, 38)
        Me.lblCustomerType.Name = "lblCustomerType"
        Me.lblCustomerType.Size = New System.Drawing.Size(153, 23)
        Me.lblCustomerType.TabIndex = 129
        Me.lblCustomerType.Text = "RETAILER"
        Me.lblCustomerType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'notificationPanel
        '
        Me.notificationPanel.BackColor = System.Drawing.Color.LightSlateGray
        Me.notificationPanel.Controls.Add(Me.notificationClose)
        Me.notificationPanel.Controls.Add(Me.notificationLabel)
        Me.notificationPanel.Location = New System.Drawing.Point(71, 8)
        Me.notificationPanel.Name = "notificationPanel"
        Me.notificationPanel.Size = New System.Drawing.Size(558, 38)
        Me.notificationPanel.TabIndex = 133
        Me.notificationPanel.Visible = False
        '
        'notificationClose
        '
        Me.notificationClose.AutoSize = True
        Me.notificationClose.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notificationClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.notificationClose.Location = New System.Drawing.Point(536, 9)
        Me.notificationClose.Name = "notificationClose"
        Me.notificationClose.Size = New System.Drawing.Size(16, 16)
        Me.notificationClose.TabIndex = 18
        Me.notificationClose.Text = "X"
        '
        'notificationLabel
        '
        Me.notificationLabel.BackColor = System.Drawing.Color.Transparent
        Me.notificationLabel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.notificationLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.notificationLabel.Location = New System.Drawing.Point(3, 4)
        Me.notificationLabel.Name = "notificationLabel"
        Me.notificationLabel.Size = New System.Drawing.Size(540, 28)
        Me.notificationLabel.TabIndex = 0
        Me.notificationLabel.Text = "Notification"
        Me.notificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EtcPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(686, 556)
        Me.Controls.Add(Me.notificationPanel)
        Me.Controls.Add(Me.lblCustomerType)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbStock)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbCustomer)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EtcPriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Price List"
        Me.Panel1.ResumeLayout(False)
        CType(Me.enterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notificationPanel.ResumeLayout(False)
        Me.notificationPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbCustomer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbStock As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents enterGrid As EnterDataGridView
    Friend WithEvents lblCustomerType As Label
    Friend WithEvents notificationPanel As Panel
    Friend WithEvents notificationClose As Label
    Friend WithEvents notificationLabel As Label
End Class
