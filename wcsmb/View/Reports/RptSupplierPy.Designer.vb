﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptSupplierPy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptSupplierPy))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dateTo = New System.Windows.Forms.DateTimePicker()
        Me.dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.PictureBox()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.tabStock = New System.Windows.Forms.Button()
        Me.tbFilter = New System.Windows.Forms.TextBox()
        Me.notificationPanel = New System.Windows.Forms.Panel()
        Me.notificationClose = New System.Windows.Forms.Label()
        Me.notificationLabel = New System.Windows.Forms.Label()
        Me.cbSummary = New System.Windows.Forms.CheckBox()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notificationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(408, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 23)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "TO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(57, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "DATE FROM"
        '
        'dateTo
        '
        Me.dateTo.CustomFormat = ""
        Me.dateTo.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTo.Location = New System.Drawing.Point(465, 144)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(154, 32)
        Me.dateTo.TabIndex = 86
        '
        'dateFrom
        '
        Me.dateFrom.CustomFormat = ""
        Me.dateFrom.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFrom.Location = New System.Drawing.Point(175, 147)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(151, 32)
        Me.dateFrom.TabIndex = 85
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Image = Global.wcsmb.My.Resources.Resources.print1
        Me.btnPrint.Location = New System.Drawing.Point(574, 227)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(45, 45)
        Me.btnPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnPrint.TabIndex = 83
        Me.btnPrint.TabStop = False
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lblFilter.Location = New System.Drawing.Point(57, 188)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(92, 23)
        Me.lblFilter.TabIndex = 82
        Me.lblFilter.Text = "SUPPLIER"
        '
        'tabStock
        '
        Me.tabStock.BackColor = System.Drawing.Color.Chocolate
        Me.tabStock.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate
        Me.tabStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate
        Me.tabStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate
        Me.tabStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tabStock.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStock.ForeColor = System.Drawing.Color.White
        Me.tabStock.Location = New System.Drawing.Point(133, 104)
        Me.tabStock.Name = "tabStock"
        Me.tabStock.Size = New System.Drawing.Size(431, 30)
        Me.tabStock.TabIndex = 81
        Me.tabStock.Text = "Payment to Supplier"
        Me.tabStock.UseVisualStyleBackColor = False
        '
        'tbFilter
        '
        Me.tbFilter.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.tbFilter.Location = New System.Drawing.Point(175, 185)
        Me.tbFilter.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.tbFilter.Name = "tbFilter"
        Me.tbFilter.Size = New System.Drawing.Size(444, 32)
        Me.tbFilter.TabIndex = 89
        '
        'notificationPanel
        '
        Me.notificationPanel.BackColor = System.Drawing.Color.LightSlateGray
        Me.notificationPanel.Controls.Add(Me.notificationClose)
        Me.notificationPanel.Controls.Add(Me.notificationLabel)
        Me.notificationPanel.Location = New System.Drawing.Point(147, 6)
        Me.notificationPanel.Name = "notificationPanel"
        Me.notificationPanel.Size = New System.Drawing.Size(400, 35)
        Me.notificationPanel.TabIndex = 122
        Me.notificationPanel.Visible = False
        '
        'notificationClose
        '
        Me.notificationClose.AutoSize = True
        Me.notificationClose.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notificationClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.notificationClose.Location = New System.Drawing.Point(378, 9)
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
        Me.notificationLabel.Location = New System.Drawing.Point(7, 3)
        Me.notificationLabel.Name = "notificationLabel"
        Me.notificationLabel.Size = New System.Drawing.Size(390, 28)
        Me.notificationLabel.TabIndex = 0
        Me.notificationLabel.Text = "Notification"
        Me.notificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbSummary
        '
        Me.cbSummary.AutoSize = True
        Me.cbSummary.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.cbSummary.Location = New System.Drawing.Point(175, 225)
        Me.cbSummary.Name = "cbSummary"
        Me.cbSummary.Size = New System.Drawing.Size(97, 22)
        Me.cbSummary.TabIndex = 123
        Me.cbSummary.Text = "SUMMARY"
        Me.cbSummary.UseVisualStyleBackColor = True
        '
        'RptSupplierPy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(681, 341)
        Me.Controls.Add(Me.cbSummary)
        Me.Controls.Add(Me.notificationPanel)
        Me.Controls.Add(Me.tbFilter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dateTo)
        Me.Controls.Add(Me.dateFrom)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.tabStock)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RptSupplierPy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment to Supplier"
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notificationPanel.ResumeLayout(False)
        Me.notificationPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.PictureBox
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents tabStock As System.Windows.Forms.Button
    Friend WithEvents tbFilter As System.Windows.Forms.TextBox
    Friend WithEvents notificationPanel As System.Windows.Forms.Panel
    Friend WithEvents notificationClose As System.Windows.Forms.Label
    Friend WithEvents notificationLabel As System.Windows.Forms.Label
    Friend WithEvents cbSummary As System.Windows.Forms.CheckBox
End Class
