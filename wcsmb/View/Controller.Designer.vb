﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Controller
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Controller))
        Me.mainPanel = New System.Windows.Forms.Panel()
        Me.logoutPanel = New System.Windows.Forms.Panel()
        Me.lblLogout = New System.Windows.Forms.Label()
        Me.imgLogout = New System.Windows.Forms.PictureBox()
        Me.usersPanel = New System.Windows.Forms.Panel()
        Me.lblUsers = New System.Windows.Forms.Label()
        Me.imgUsers = New System.Windows.Forms.PictureBox()
        Me.settingsPanel = New System.Windows.Forms.Panel()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.imgSettings = New System.Windows.Forms.PictureBox()
        Me.activitiesPanel = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.activityList = New System.Windows.Forms.ListBox()
        Me.reportsPanel = New System.Windows.Forms.Panel()
        Me.lblRSP = New System.Windows.Forms.Label()
        Me.lblRSOA = New System.Windows.Forms.Label()
        Me.lblRS = New System.Windows.Forms.Label()
        Me.lblRSMV = New System.Windows.Forms.Label()
        Me.lblRPMN = New System.Windows.Forms.Label()
        Me.lblRSMN = New System.Windows.Forms.Label()
        Me.lblRTL = New System.Windows.Forms.Label()
        Me.imgReport = New System.Windows.Forms.PictureBox()
        Me.transactionPanel = New System.Windows.Forms.Panel()
        Me.lblTSR = New System.Windows.Forms.Label()
        Me.lblTSO = New System.Windows.Forms.Label()
        Me.lblTCC = New System.Windows.Forms.Label()
        Me.lblTPR = New System.Windows.Forms.Label()
        Me.lblTPO = New System.Windows.Forms.Label()
        Me.imgTrans = New System.Windows.Forms.PictureBox()
        Me.lblTSP = New System.Windows.Forms.Label()
        Me.filesPanel = New System.Windows.Forms.Panel()
        Me.lblFAgent = New System.Windows.Forms.Label()
        Me.lblFCust = New System.Windows.Forms.Label()
        Me.imgFiles = New System.Windows.Forms.PictureBox()
        Me.lblFUnit = New System.Windows.Forms.Label()
        Me.lblFCtgr = New System.Windows.Forms.Label()
        Me.lblFSupp = New System.Windows.Forms.Label()
        Me.lblFStock = New System.Windows.Forms.Label()
        Me.topPanel = New System.Windows.Forms.Panel()
        Me.minimizeButton = New System.Windows.Forms.Label()
        Me.closeButton = New System.Windows.Forms.Label()
        Me.hotkeyListener = New System.Windows.Forms.Timer(Me.components)
        Me.notificationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.mainPanel.SuspendLayout()
        Me.logoutPanel.SuspendLayout()
        CType(Me.imgLogout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.usersPanel.SuspendLayout()
        CType(Me.imgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.settingsPanel.SuspendLayout()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.activitiesPanel.SuspendLayout()
        Me.reportsPanel.SuspendLayout()
        CType(Me.imgReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.transactionPanel.SuspendLayout()
        CType(Me.imgTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filesPanel.SuspendLayout()
        CType(Me.imgFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainPanel
        '
        Me.mainPanel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.mainPanel.BackColor = System.Drawing.Color.Transparent
        Me.mainPanel.Controls.Add(Me.logoutPanel)
        Me.mainPanel.Controls.Add(Me.usersPanel)
        Me.mainPanel.Controls.Add(Me.settingsPanel)
        Me.mainPanel.Controls.Add(Me.activitiesPanel)
        Me.mainPanel.Controls.Add(Me.reportsPanel)
        Me.mainPanel.Controls.Add(Me.transactionPanel)
        Me.mainPanel.Controls.Add(Me.filesPanel)
        Me.mainPanel.Controls.Add(Me.topPanel)
        Me.mainPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainPanel.Location = New System.Drawing.Point(-1, -1)
        Me.mainPanel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.mainPanel.Name = "mainPanel"
        Me.mainPanel.Size = New System.Drawing.Size(1143, 634)
        Me.mainPanel.TabIndex = 3
        '
        'logoutPanel
        '
        Me.logoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.logoutPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.logoutPanel.Controls.Add(Me.lblLogout)
        Me.logoutPanel.Controls.Add(Me.imgLogout)
        Me.logoutPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.logoutPanel.Location = New System.Drawing.Point(971, 444)
        Me.logoutPanel.Name = "logoutPanel"
        Me.logoutPanel.Size = New System.Drawing.Size(164, 181)
        Me.logoutPanel.TabIndex = 17
        '
        'lblLogout
        '
        Me.lblLogout.AutoSize = True
        Me.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLogout.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblLogout.Location = New System.Drawing.Point(45, 131)
        Me.lblLogout.Name = "lblLogout"
        Me.lblLogout.Size = New System.Drawing.Size(75, 25)
        Me.lblLogout.TabIndex = 18
        Me.lblLogout.Text = "Logout"
        Me.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogout
        '
        Me.imgLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgLogout.Image = Global.wcsmb.My.Resources.Resources._logout
        Me.imgLogout.Location = New System.Drawing.Point(44, 36)
        Me.imgLogout.Name = "imgLogout"
        Me.imgLogout.Size = New System.Drawing.Size(80, 80)
        Me.imgLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogout.TabIndex = 17
        Me.imgLogout.TabStop = False
        '
        'usersPanel
        '
        Me.usersPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.usersPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.usersPanel.Controls.Add(Me.lblUsers)
        Me.usersPanel.Controls.Add(Me.imgUsers)
        Me.usersPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.usersPanel.Location = New System.Drawing.Point(798, 444)
        Me.usersPanel.Name = "usersPanel"
        Me.usersPanel.Size = New System.Drawing.Size(164, 181)
        Me.usersPanel.TabIndex = 16
        '
        'lblUsers
        '
        Me.lblUsers.AutoSize = True
        Me.lblUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUsers.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblUsers.Location = New System.Drawing.Point(51, 131)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.Size = New System.Drawing.Size(63, 25)
        Me.lblUsers.TabIndex = 17
        Me.lblUsers.Text = "Users"
        Me.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgUsers
        '
        Me.imgUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgUsers.Image = Global.wcsmb.My.Resources.Resources._user2
        Me.imgUsers.Location = New System.Drawing.Point(45, 34)
        Me.imgUsers.Name = "imgUsers"
        Me.imgUsers.Size = New System.Drawing.Size(80, 80)
        Me.imgUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgUsers.TabIndex = 16
        Me.imgUsers.TabStop = False
        '
        'settingsPanel
        '
        Me.settingsPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.settingsPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.settingsPanel.Controls.Add(Me.lblSettings)
        Me.settingsPanel.Controls.Add(Me.imgSettings)
        Me.settingsPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settingsPanel.Location = New System.Drawing.Point(627, 444)
        Me.settingsPanel.Name = "settingsPanel"
        Me.settingsPanel.Size = New System.Drawing.Size(163, 181)
        Me.settingsPanel.TabIndex = 15
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSettings.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSettings.Location = New System.Drawing.Point(36, 131)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(87, 25)
        Me.lblSettings.TabIndex = 15
        Me.lblSettings.Text = "Settings"
        Me.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgSettings
        '
        Me.imgSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgSettings.Image = Global.wcsmb.My.Resources.Resources._settings
        Me.imgSettings.Location = New System.Drawing.Point(41, 34)
        Me.imgSettings.Name = "imgSettings"
        Me.imgSettings.Size = New System.Drawing.Size(80, 80)
        Me.imgSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgSettings.TabIndex = 4
        Me.imgSettings.TabStop = False
        '
        'activitiesPanel
        '
        Me.activitiesPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.activitiesPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.activitiesPanel.Controls.Add(Me.Label30)
        Me.activitiesPanel.Controls.Add(Me.activityList)
        Me.activitiesPanel.Location = New System.Drawing.Point(627, 60)
        Me.activitiesPanel.Name = "activitiesPanel"
        Me.activitiesPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.activitiesPanel.Size = New System.Drawing.Size(509, 375)
        Me.activitiesPanel.TabIndex = 15
        '
        'Label30
        '
        Me.Label30.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(5, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(499, 40)
        Me.Label30.TabIndex = 5
        Me.Label30.Text = "Recent Activities"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'activityList
        '
        Me.activityList.BackColor = System.Drawing.Color.Gainsboro
        Me.activityList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.activityList.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.activityList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.activityList.FormattingEnabled = True
        Me.activityList.ItemHeight = 21
        Me.activityList.Location = New System.Drawing.Point(63, 53)
        Me.activityList.Name = "activityList"
        Me.activityList.Size = New System.Drawing.Size(388, 294)
        Me.activityList.TabIndex = 4
        '
        'reportsPanel
        '
        Me.reportsPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.reportsPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.reportsPanel.Controls.Add(Me.lblRSP)
        Me.reportsPanel.Controls.Add(Me.lblRSOA)
        Me.reportsPanel.Controls.Add(Me.lblRS)
        Me.reportsPanel.Controls.Add(Me.lblRSMV)
        Me.reportsPanel.Controls.Add(Me.lblRPMN)
        Me.reportsPanel.Controls.Add(Me.lblRSMN)
        Me.reportsPanel.Controls.Add(Me.lblRTL)
        Me.reportsPanel.Controls.Add(Me.imgReport)
        Me.reportsPanel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.reportsPanel.Location = New System.Drawing.Point(6, 444)
        Me.reportsPanel.Name = "reportsPanel"
        Me.reportsPanel.Size = New System.Drawing.Size(615, 181)
        Me.reportsPanel.TabIndex = 8
        '
        'lblRSP
        '
        Me.lblRSP.AutoSize = True
        Me.lblRSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRSP.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRSP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRSP.Location = New System.Drawing.Point(415, 131)
        Me.lblRSP.Name = "lblRSP"
        Me.lblRSP.Size = New System.Drawing.Size(177, 25)
        Me.lblRSP.TabIndex = 21
        Me.lblRSP.Text = "Supplier Payment"
        Me.lblRSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRSOA
        '
        Me.lblRSOA.AutoSize = True
        Me.lblRSOA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRSOA.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRSOA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRSOA.Location = New System.Drawing.Point(278, 131)
        Me.lblRSOA.Name = "lblRSOA"
        Me.lblRSOA.Size = New System.Drawing.Size(52, 25)
        Me.lblRSOA.TabIndex = 20
        Me.lblRSOA.Text = "SOA"
        Me.lblRSOA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRS
        '
        Me.lblRS.AutoSize = True
        Me.lblRS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRS.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRS.Location = New System.Drawing.Point(180, 131)
        Me.lblRS.Name = "lblRS"
        Me.lblRS.Size = New System.Drawing.Size(60, 25)
        Me.lblRS.TabIndex = 19
        Me.lblRS.Text = "Sales"
        Me.lblRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRSMV
        '
        Me.lblRSMV.AutoSize = True
        Me.lblRSMV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRSMV.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRSMV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRSMV.Location = New System.Drawing.Point(427, 81)
        Me.lblRSMV.Name = "lblRSMV"
        Me.lblRSMV.Size = New System.Drawing.Size(165, 25)
        Me.lblRSMV.TabIndex = 18
        Me.lblRSMV.Text = "Stock Movement"
        Me.lblRSMV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRPMN
        '
        Me.lblRPMN.AutoSize = True
        Me.lblRPMN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRPMN.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRPMN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRPMN.Location = New System.Drawing.Point(180, 81)
        Me.lblRPMN.Name = "lblRPMN"
        Me.lblRPMN.Size = New System.Drawing.Size(203, 25)
        Me.lblRPMN.TabIndex = 17
        Me.lblRPMN.Text = "Purchase Monitoring"
        Me.lblRPMN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRSMN
        '
        Me.lblRSMN.AutoSize = True
        Me.lblRSMN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRSMN.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRSMN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRSMN.Location = New System.Drawing.Point(424, 27)
        Me.lblRSMN.Name = "lblRSMN"
        Me.lblRSMN.Size = New System.Drawing.Size(168, 25)
        Me.lblRSMN.TabIndex = 16
        Me.lblRSMN.Text = "Stock Monitoring"
        Me.lblRSMN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRTL
        '
        Me.lblRTL.AutoSize = True
        Me.lblRTL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRTL.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblRTL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblRTL.Location = New System.Drawing.Point(180, 27)
        Me.lblRTL.Name = "lblRTL"
        Me.lblRTL.Size = New System.Drawing.Size(158, 25)
        Me.lblRTL.TabIndex = 15
        Me.lblRTL.Text = "Transaction List"
        Me.lblRTL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgReport
        '
        Me.imgReport.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.imgReport.Dock = System.Windows.Forms.DockStyle.Left
        Me.imgReport.Image = Global.wcsmb.My.Resources.Resources.reports
        Me.imgReport.Location = New System.Drawing.Point(0, 0)
        Me.imgReport.Name = "imgReport"
        Me.imgReport.Size = New System.Drawing.Size(150, 181)
        Me.imgReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgReport.TabIndex = 5
        Me.imgReport.TabStop = False
        '
        'transactionPanel
        '
        Me.transactionPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.transactionPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.transactionPanel.Controls.Add(Me.lblTSR)
        Me.transactionPanel.Controls.Add(Me.lblTSO)
        Me.transactionPanel.Controls.Add(Me.lblTCC)
        Me.transactionPanel.Controls.Add(Me.lblTPR)
        Me.transactionPanel.Controls.Add(Me.lblTPO)
        Me.transactionPanel.Controls.Add(Me.imgTrans)
        Me.transactionPanel.Controls.Add(Me.lblTSP)
        Me.transactionPanel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.transactionPanel.Location = New System.Drawing.Point(6, 246)
        Me.transactionPanel.Name = "transactionPanel"
        Me.transactionPanel.Size = New System.Drawing.Size(615, 189)
        Me.transactionPanel.TabIndex = 7
        '
        'lblTSR
        '
        Me.lblTSR.AutoSize = True
        Me.lblTSR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTSR.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTSR.Location = New System.Drawing.Point(463, 83)
        Me.lblTSR.Name = "lblTSR"
        Me.lblTSR.Size = New System.Drawing.Size(130, 25)
        Me.lblTSR.TabIndex = 7
        Me.lblTSR.Text = "Sales Return"
        Me.lblTSR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTSO
        '
        Me.lblTSO.AutoSize = True
        Me.lblTSO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTSO.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTSO.Location = New System.Drawing.Point(472, 30)
        Me.lblTSO.Name = "lblTSO"
        Me.lblTSO.Size = New System.Drawing.Size(121, 25)
        Me.lblTSO.TabIndex = 8
        Me.lblTSO.Text = "Sales Order"
        Me.lblTSO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTCC
        '
        Me.lblTCC.AutoSize = True
        Me.lblTCC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTCC.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTCC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTCC.Location = New System.Drawing.Point(437, 135)
        Me.lblTCC.Name = "lblTCC"
        Me.lblTCC.Size = New System.Drawing.Size(156, 25)
        Me.lblTCC.TabIndex = 6
        Me.lblTCC.Text = "Cust. Collection"
        Me.lblTCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTPR
        '
        Me.lblTPR.AutoSize = True
        Me.lblTPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTPR.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTPR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTPR.Location = New System.Drawing.Point(180, 83)
        Me.lblTPR.Name = "lblTPR"
        Me.lblTPR.Size = New System.Drawing.Size(167, 25)
        Me.lblTPR.TabIndex = 4
        Me.lblTPR.Text = "Purchase Return"
        Me.lblTPR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTPO
        '
        Me.lblTPO.AutoSize = True
        Me.lblTPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTPO.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTPO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTPO.Location = New System.Drawing.Point(180, 30)
        Me.lblTPO.Name = "lblTPO"
        Me.lblTPO.Size = New System.Drawing.Size(158, 25)
        Me.lblTPO.TabIndex = 5
        Me.lblTPO.Text = "Purchase Order"
        Me.lblTPO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgTrans
        '
        Me.imgTrans.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.imgTrans.Dock = System.Windows.Forms.DockStyle.Left
        Me.imgTrans.Image = Global.wcsmb.My.Resources.Resources.transaction
        Me.imgTrans.Location = New System.Drawing.Point(0, 0)
        Me.imgTrans.Name = "imgTrans"
        Me.imgTrans.Size = New System.Drawing.Size(150, 189)
        Me.imgTrans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgTrans.TabIndex = 3
        Me.imgTrans.TabStop = False
        '
        'lblTSP
        '
        Me.lblTSP.AutoSize = True
        Me.lblTSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTSP.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTSP.Location = New System.Drawing.Point(180, 135)
        Me.lblTSP.Name = "lblTSP"
        Me.lblTSP.Size = New System.Drawing.Size(177, 25)
        Me.lblTSP.TabIndex = 3
        Me.lblTSP.Text = "Supplier Payment"
        Me.lblTSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'filesPanel
        '
        Me.filesPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.filesPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.filesPanel.Controls.Add(Me.lblFAgent)
        Me.filesPanel.Controls.Add(Me.lblFCust)
        Me.filesPanel.Controls.Add(Me.imgFiles)
        Me.filesPanel.Controls.Add(Me.lblFUnit)
        Me.filesPanel.Controls.Add(Me.lblFCtgr)
        Me.filesPanel.Controls.Add(Me.lblFSupp)
        Me.filesPanel.Controls.Add(Me.lblFStock)
        Me.filesPanel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.filesPanel.Location = New System.Drawing.Point(6, 60)
        Me.filesPanel.Name = "filesPanel"
        Me.filesPanel.Size = New System.Drawing.Size(615, 180)
        Me.filesPanel.TabIndex = 6
        '
        'lblFAgent
        '
        Me.lblFAgent.AutoSize = True
        Me.lblFAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFAgent.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFAgent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFAgent.Location = New System.Drawing.Point(486, 74)
        Me.lblFAgent.Name = "lblFAgent"
        Me.lblFAgent.Size = New System.Drawing.Size(106, 25)
        Me.lblFAgent.TabIndex = 13
        Me.lblFAgent.Text = "Agent File"
        Me.lblFAgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFCust
        '
        Me.lblFCust.AutoSize = True
        Me.lblFCust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFCust.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFCust.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFCust.Location = New System.Drawing.Point(452, 20)
        Me.lblFCust.Name = "lblFCust"
        Me.lblFCust.Size = New System.Drawing.Size(140, 25)
        Me.lblFCust.TabIndex = 14
        Me.lblFCust.Text = "Customer File"
        Me.lblFCust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgFiles
        '
        Me.imgFiles.BackColor = System.Drawing.Color.Transparent
        Me.imgFiles.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.imgFiles.Dock = System.Windows.Forms.DockStyle.Left
        Me.imgFiles.Image = Global.wcsmb.My.Resources.Resources.suitcase
        Me.imgFiles.Location = New System.Drawing.Point(0, 0)
        Me.imgFiles.Name = "imgFiles"
        Me.imgFiles.Size = New System.Drawing.Size(150, 180)
        Me.imgFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgFiles.TabIndex = 2
        Me.imgFiles.TabStop = False
        '
        'lblFUnit
        '
        Me.lblFUnit.AutoSize = True
        Me.lblFUnit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFUnit.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFUnit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFUnit.Location = New System.Drawing.Point(503, 128)
        Me.lblFUnit.Name = "lblFUnit"
        Me.lblFUnit.Size = New System.Drawing.Size(89, 25)
        Me.lblFUnit.TabIndex = 12
        Me.lblFUnit.Text = "Unit File"
        Me.lblFUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFCtgr
        '
        Me.lblFCtgr.AutoSize = True
        Me.lblFCtgr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFCtgr.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFCtgr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFCtgr.Location = New System.Drawing.Point(180, 128)
        Me.lblFCtgr.Name = "lblFCtgr"
        Me.lblFCtgr.Size = New System.Drawing.Size(134, 25)
        Me.lblFCtgr.TabIndex = 9
        Me.lblFCtgr.Text = "Category File"
        Me.lblFCtgr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFSupp
        '
        Me.lblFSupp.AutoSize = True
        Me.lblFSupp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFSupp.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFSupp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFSupp.Location = New System.Drawing.Point(180, 74)
        Me.lblFSupp.Name = "lblFSupp"
        Me.lblFSupp.Size = New System.Drawing.Size(128, 25)
        Me.lblFSupp.TabIndex = 10
        Me.lblFSupp.Text = "Supplier File"
        Me.lblFSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFStock
        '
        Me.lblFStock.AutoSize = True
        Me.lblFStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFStock.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.lblFStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblFStock.Location = New System.Drawing.Point(180, 20)
        Me.lblFStock.Name = "lblFStock"
        Me.lblFStock.Size = New System.Drawing.Size(170, 25)
        Me.lblFStock.TabIndex = 11
        Me.lblFStock.Text = "Stock Master File"
        Me.lblFStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'topPanel
        '
        Me.topPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.topPanel.BackgroundImage = Global.wcsmb.My.Resources.Resources.grdt
        Me.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.topPanel.Controls.Add(Me.minimizeButton)
        Me.topPanel.Controls.Add(Me.closeButton)
        Me.topPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.topPanel.Location = New System.Drawing.Point(0, 0)
        Me.topPanel.Name = "topPanel"
        Me.topPanel.Size = New System.Drawing.Size(1143, 54)
        Me.topPanel.TabIndex = 1
        '
        'minimizeButton
        '
        Me.minimizeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimizeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.minimizeButton.Font = New System.Drawing.Font("Comic Sans MS", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimizeButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.minimizeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.minimizeButton.Location = New System.Drawing.Point(1057, 6)
        Me.minimizeButton.Margin = New System.Windows.Forms.Padding(5, 10, 10, 5)
        Me.minimizeButton.Name = "minimizeButton"
        Me.minimizeButton.Size = New System.Drawing.Size(38, 26)
        Me.minimizeButton.TabIndex = 3
        Me.minimizeButton.Text = "_"
        Me.minimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.closeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.closeButton.Font = New System.Drawing.Font("Comic Sans MS", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.closeButton.Location = New System.Drawing.Point(1100, 6)
        Me.closeButton.Margin = New System.Windows.Forms.Padding(5, 10, 10, 5)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(38, 26)
        Me.closeButton.TabIndex = 2
        Me.closeButton.Text = "X"
        Me.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hotkeyListener
        '
        Me.hotkeyListener.Interval = 50
        '
        'notificationTimer
        '
        Me.notificationTimer.Interval = 250
        '
        'pollTimer
        '
        Me.pollTimer.Interval = 10000
        '
        'Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1142, 629)
        Me.ControlBox = False
        Me.Controls.Add(Me.mainPanel)
        Me.Font = New System.Drawing.Font("Lucida Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Controller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.mainPanel.ResumeLayout(False)
        Me.logoutPanel.ResumeLayout(False)
        Me.logoutPanel.PerformLayout()
        CType(Me.imgLogout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.usersPanel.ResumeLayout(False)
        Me.usersPanel.PerformLayout()
        CType(Me.imgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.settingsPanel.ResumeLayout(False)
        Me.settingsPanel.PerformLayout()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.activitiesPanel.ResumeLayout(False)
        Me.reportsPanel.ResumeLayout(False)
        Me.reportsPanel.PerformLayout()
        CType(Me.imgReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.transactionPanel.ResumeLayout(False)
        Me.transactionPanel.PerformLayout()
        CType(Me.imgTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.filesPanel.ResumeLayout(False)
        Me.filesPanel.PerformLayout()
        CType(Me.imgFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mainPanel As System.Windows.Forms.Panel
    Friend WithEvents topPanel As System.Windows.Forms.Panel
    Friend WithEvents minimizeButton As System.Windows.Forms.Label
    Friend WithEvents closeButton As System.Windows.Forms.Label
    Friend WithEvents imgFiles As System.Windows.Forms.PictureBox
    Friend WithEvents imgReport As System.Windows.Forms.PictureBox
    Friend WithEvents imgTrans As System.Windows.Forms.PictureBox
    Friend WithEvents filesPanel As System.Windows.Forms.Panel
    Friend WithEvents transactionPanel As System.Windows.Forms.Panel
    Friend WithEvents reportsPanel As System.Windows.Forms.Panel
    Friend WithEvents lblTSP As System.Windows.Forms.Label
    Friend WithEvents lblTPR As System.Windows.Forms.Label
    Friend WithEvents lblTPO As System.Windows.Forms.Label
    Friend WithEvents lblTSR As System.Windows.Forms.Label
    Friend WithEvents lblTSO As System.Windows.Forms.Label
    Friend WithEvents lblTCC As System.Windows.Forms.Label
    Friend WithEvents lblRTL As System.Windows.Forms.Label
    Friend WithEvents lblRSMN As System.Windows.Forms.Label
    Friend WithEvents lblRPMN As System.Windows.Forms.Label
    Friend WithEvents lblRSMV As System.Windows.Forms.Label
    Friend WithEvents lblRS As System.Windows.Forms.Label
    Friend WithEvents lblRSOA As System.Windows.Forms.Label
    Friend WithEvents lblRSP As System.Windows.Forms.Label
    Friend WithEvents lblFAgent As System.Windows.Forms.Label
    Friend WithEvents lblFCust As System.Windows.Forms.Label
    Friend WithEvents lblFUnit As System.Windows.Forms.Label
    Friend WithEvents lblFCtgr As System.Windows.Forms.Label
    Friend WithEvents lblFSupp As System.Windows.Forms.Label
    Friend WithEvents lblFStock As System.Windows.Forms.Label
    Friend WithEvents activitiesPanel As System.Windows.Forms.Panel
    Friend WithEvents usersPanel As System.Windows.Forms.Panel
    Friend WithEvents settingsPanel As System.Windows.Forms.Panel
    Friend WithEvents logoutPanel As System.Windows.Forms.Panel
    Friend WithEvents imgSettings As System.Windows.Forms.PictureBox
    Friend WithEvents lblSettings As System.Windows.Forms.Label
    Friend WithEvents imgUsers As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsers As System.Windows.Forms.Label
    Friend WithEvents imgLogout As System.Windows.Forms.PictureBox
    Friend WithEvents lblLogout As System.Windows.Forms.Label
    Friend WithEvents activityList As System.Windows.Forms.ListBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents hotkeyListener As System.Windows.Forms.Timer
    Friend WithEvents notificationTimer As System.Windows.Forms.Timer
    Friend WithEvents pollTimer As System.Windows.Forms.Timer
End Class
