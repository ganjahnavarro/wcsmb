﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransPR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransPR))
        Me.ButtonsPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrint = New System.Windows.Forms.PictureBox()
        Me.btnSearch = New System.Windows.Forms.PictureBox()
        Me.btnNext = New System.Windows.Forms.PictureBox()
        Me.btnPrev = New System.Windows.Forms.PictureBox()
        Me.btnAdd = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.PictureBox()
        Me.btnDelete = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.PictureBox()
        Me.btnCheck = New System.Windows.Forms.PictureBox()
        Me.lblPostedOn = New System.Windows.Forms.Label()
        Me.lblOn = New System.Windows.Forms.Label()
        Me.lblBy = New System.Windows.Forms.Label()
        Me.lblPostedDate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.enterGrid = New wcsmb.EnterDataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbTotalAmt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbRemarks = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.docDate = New System.Windows.Forms.DateTimePicker()
        Me.tbDocNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUnitName = New System.Windows.Forms.Label()
        Me.tbSupplier = New System.Windows.Forms.TextBox()
        Me.notificationPanel = New System.Windows.Forms.Panel()
        Me.notificationClose = New System.Windows.Forms.Label()
        Me.notificationLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.stockDescription = New System.Windows.Forms.Label()
        Me.ButtonsPanel.SuspendLayout()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.enterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notificationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonsPanel
        '
        Me.ButtonsPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonsPanel.Controls.Add(Me.btnPrint)
        Me.ButtonsPanel.Controls.Add(Me.btnSearch)
        Me.ButtonsPanel.Controls.Add(Me.btnNext)
        Me.ButtonsPanel.Controls.Add(Me.btnPrev)
        Me.ButtonsPanel.Controls.Add(Me.btnAdd)
        Me.ButtonsPanel.Controls.Add(Me.btnEdit)
        Me.ButtonsPanel.Controls.Add(Me.btnDelete)
        Me.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.ButtonsPanel.Location = New System.Drawing.Point(644, 684)
        Me.ButtonsPanel.Name = "ButtonsPanel"
        Me.ButtonsPanel.Size = New System.Drawing.Size(378, 46)
        Me.ButtonsPanel.TabIndex = 127
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Image = Global.wcsmb.My.Resources.Resources.print1
        Me.btnPrint.Location = New System.Drawing.Point(333, 0)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(45, 45)
        Me.btnPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnPrint.TabIndex = 146
        Me.btnPrint.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Image = Global.wcsmb.My.Resources.Resources.search
        Me.btnSearch.Location = New System.Drawing.Point(284, 0)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(45, 45)
        Me.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnSearch.TabIndex = 47
        Me.btnSearch.TabStop = False
        '
        'btnNext
        '
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.Image = Global.wcsmb.My.Resources.Resources.right_arrow
        Me.btnNext.Location = New System.Drawing.Point(235, 0)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(45, 45)
        Me.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnNext.TabIndex = 43
        Me.btnNext.TabStop = False
        '
        'btnPrev
        '
        Me.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrev.Image = Global.wcsmb.My.Resources.Resources.left_arrow
        Me.btnPrev.Location = New System.Drawing.Point(186, 0)
        Me.btnPrev.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(45, 45)
        Me.btnPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnPrev.TabIndex = 44
        Me.btnPrev.TabStop = False
        '
        'btnAdd
        '
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Image = Global.wcsmb.My.Resources.Resources.plusx
        Me.btnAdd.Location = New System.Drawing.Point(127, 0)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 0, 10, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(45, 45)
        Me.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAdd.TabIndex = 41
        Me.btnAdd.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.Image = Global.wcsmb.My.Resources.Resources.edit
        Me.btnEdit.Location = New System.Drawing.Point(78, 0)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(45, 45)
        Me.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnEdit.TabIndex = 40
        Me.btnEdit.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Image = Global.wcsmb.My.Resources.Resources.bin
        Me.btnDelete.Location = New System.Drawing.Point(29, 0)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(45, 45)
        Me.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnDelete.TabIndex = 42
        Me.btnDelete.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Image = Global.wcsmb.My.Resources.Resources.delete
        Me.btnCancel.Location = New System.Drawing.Point(977, 684)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(45, 45)
        Me.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.TabStop = False
        '
        'btnCheck
        '
        Me.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheck.Image = Global.wcsmb.My.Resources.Resources.checkmark
        Me.btnCheck.Location = New System.Drawing.Point(928, 684)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(45, 45)
        Me.btnCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCheck.TabIndex = 46
        Me.btnCheck.TabStop = False
        '
        'lblPostedOn
        '
        Me.lblPostedOn.AutoSize = True
        Me.lblPostedOn.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lblPostedOn.ForeColor = System.Drawing.Color.Green
        Me.lblPostedOn.Location = New System.Drawing.Point(154, 706)
        Me.lblPostedOn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPostedOn.Name = "lblPostedOn"
        Me.lblPostedOn.Size = New System.Drawing.Size(92, 23)
        Me.lblPostedOn.TabIndex = 130
        Me.lblPostedOn.Text = "Posted on"
        '
        'lblOn
        '
        Me.lblOn.AutoSize = True
        Me.lblOn.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblOn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOn.Location = New System.Drawing.Point(16, 711)
        Me.lblOn.Name = "lblOn"
        Me.lblOn.Size = New System.Drawing.Size(107, 19)
        Me.lblOn.TabIndex = 129
        Me.lblOn.Text = "On: 12/03/14"
        '
        'lblBy
        '
        Me.lblBy.AutoSize = True
        Me.lblBy.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBy.Location = New System.Drawing.Point(20, 684)
        Me.lblBy.Name = "lblBy"
        Me.lblBy.Size = New System.Drawing.Size(87, 19)
        Me.lblBy.TabIndex = 128
        Me.lblBy.Text = "By: Ganjah"
        '
        'lblPostedDate
        '
        Me.lblPostedDate.AutoSize = True
        Me.lblPostedDate.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lblPostedDate.ForeColor = System.Drawing.Color.Green
        Me.lblPostedDate.Location = New System.Drawing.Point(242, 706)
        Me.lblPostedDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPostedDate.Name = "lblPostedDate"
        Me.lblPostedDate.Size = New System.Drawing.Size(104, 23)
        Me.lblPostedDate.TabIndex = 131
        Me.lblPostedDate.Text = "12/10/2014"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel1.Controls.Add(Me.enterGrid)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 13.0!)
        Me.Panel1.Location = New System.Drawing.Point(20, 250)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(993, 418)
        Me.Panel1.TabIndex = 132
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
        Me.enterGrid.ReadOnly = True
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
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.enterGrid.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.enterGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.enterGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.enterGrid.Size = New System.Drawing.Size(975, 428)
        Me.enterGrid.TabIndex = 144
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(597, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 23)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Total Amount"
        '
        'tbTotalAmt
        '
        Me.tbTotalAmt.Enabled = False
        Me.tbTotalAmt.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbTotalAmt.Location = New System.Drawing.Point(730, 95)
        Me.tbTotalAmt.Name = "tbTotalAmt"
        Me.tbTotalAmt.Size = New System.Drawing.Size(182, 32)
        Me.tbTotalAmt.TabIndex = 138
        Me.tbTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(106, 140)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 23)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Remarks"
        '
        'tbRemarks
        '
        Me.tbRemarks.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbRemarks.Location = New System.Drawing.Point(216, 140)
        Me.tbRemarks.Multiline = True
        Me.tbRemarks.Name = "tbRemarks"
        Me.tbRemarks.Size = New System.Drawing.Size(696, 71)
        Me.tbRemarks.TabIndex = 139
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(670, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 23)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Date"
        '
        'docDate
        '
        Me.docDate.CustomFormat = ""
        Me.docDate.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.docDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.docDate.Location = New System.Drawing.Point(730, 51)
        Me.docDate.MaxDate = New Date(2999, 12, 31, 0, 0, 0, 0)
        Me.docDate.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.docDate.Name = "docDate"
        Me.docDate.Size = New System.Drawing.Size(182, 32)
        Me.docDate.TabIndex = 137
        '
        'tbDocNo
        '
        Me.tbDocNo.Enabled = False
        Me.tbDocNo.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbDocNo.Location = New System.Drawing.Point(216, 51)
        Me.tbDocNo.Name = "tbDocNo"
        Me.tbDocNo.Size = New System.Drawing.Size(361, 32)
        Me.tbDocNo.TabIndex = 135
        Me.tbDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 99)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 23)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Supplier"
        '
        'lblUnitName
        '
        Me.lblUnitName.AutoSize = True
        Me.lblUnitName.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblUnitName.Location = New System.Drawing.Point(106, 55)
        Me.lblUnitName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnitName.Name = "lblUnitName"
        Me.lblUnitName.Size = New System.Drawing.Size(67, 23)
        Me.lblUnitName.TabIndex = 133
        Me.lblUnitName.Text = "PR No."
        '
        'tbSupplier
        '
        Me.tbSupplier.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbSupplier.Location = New System.Drawing.Point(216, 95)
        Me.tbSupplier.Name = "tbSupplier"
        Me.tbSupplier.Size = New System.Drawing.Size(361, 32)
        Me.tbSupplier.TabIndex = 136
        Me.tbSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'notificationPanel
        '
        Me.notificationPanel.BackColor = System.Drawing.Color.LightSlateGray
        Me.notificationPanel.Controls.Add(Me.notificationClose)
        Me.notificationPanel.Controls.Add(Me.notificationLabel)
        Me.notificationPanel.Location = New System.Drawing.Point(246, 7)
        Me.notificationPanel.Name = "notificationPanel"
        Me.notificationPanel.Size = New System.Drawing.Size(558, 38)
        Me.notificationPanel.TabIndex = 143
        Me.notificationPanel.Visible = False
        '
        'notificationClose
        '
        Me.notificationClose.AutoSize = True
        Me.notificationClose.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notificationClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.notificationClose.Location = New System.Drawing.Point(536, 11)
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
        Me.notificationLabel.Location = New System.Drawing.Point(9, 4)
        Me.notificationLabel.Name = "notificationLabel"
        Me.notificationLabel.Size = New System.Drawing.Size(531, 28)
        Me.notificationLabel.TabIndex = 0
        Me.notificationLabel.Text = "Notification"
        Me.notificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(977, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 23)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "items"
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.lblCount.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblCount.Location = New System.Drawing.Point(977, 26)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(56, 39)
        Me.lblCount.TabIndex = 144
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stockDescription
        '
        Me.stockDescription.AutoSize = True
        Me.stockDescription.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stockDescription.ForeColor = System.Drawing.Color.SeaGreen
        Me.stockDescription.Location = New System.Drawing.Point(19, 222)
        Me.stockDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.stockDescription.Name = "stockDescription"
        Me.stockDescription.Size = New System.Drawing.Size(139, 21)
        Me.stockDescription.TabIndex = 175
        Me.stockDescription.Text = "Stock Description"
        '
        'TransPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1034, 741)
        Me.Controls.Add(Me.stockDescription)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.notificationPanel)
        Me.Controls.Add(Me.tbSupplier)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbTotalAmt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbRemarks)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.docDate)
        Me.Controls.Add(Me.tbDocNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUnitName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblPostedOn)
        Me.Controls.Add(Me.lblOn)
        Me.Controls.Add(Me.lblBy)
        Me.Controls.Add(Me.lblPostedDate)
        Me.Controls.Add(Me.ButtonsPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransPR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Purchase Return"
        Me.ButtonsPanel.ResumeLayout(False)
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.enterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notificationPanel.ResumeLayout(False)
        Me.notificationPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonsPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAdd As System.Windows.Forms.PictureBox
    Friend WithEvents btnEdit As System.Windows.Forms.PictureBox
    Friend WithEvents btnDelete As System.Windows.Forms.PictureBox
    Friend WithEvents btnNext As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrev As System.Windows.Forms.PictureBox
    Friend WithEvents btnSearch As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancel As System.Windows.Forms.PictureBox
    Friend WithEvents btnCheck As System.Windows.Forms.PictureBox
    Friend WithEvents lblPostedOn As System.Windows.Forms.Label
    Friend WithEvents lblOn As System.Windows.Forms.Label
    Friend WithEvents lblBy As System.Windows.Forms.Label
    Friend WithEvents lblPostedDate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbTotalAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents docDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbDocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUnitName As System.Windows.Forms.Label
    Friend WithEvents tbSupplier As System.Windows.Forms.TextBox
    Friend WithEvents notificationPanel As System.Windows.Forms.Panel
    Friend WithEvents notificationClose As System.Windows.Forms.Label
    Friend WithEvents notificationLabel As System.Windows.Forms.Label
    Friend WithEvents enterGrid As wcsmb.EnterDataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents stockDescription As Label
End Class
