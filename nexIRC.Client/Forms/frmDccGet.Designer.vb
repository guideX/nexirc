<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDccGet
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDccGet))
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.Office2007BlackTheme1 = New Telerik.WinControls.Themes.Office2007BlackTheme()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.lblPort = New Telerik.WinControls.UI.RadLabel()
        Me.lblIp = New Telerik.WinControls.UI.RadLabel()
        Me.lblNickname = New Telerik.WinControls.UI.RadLabel()
        Me.lblSize = New Telerik.WinControls.UI.RadLabel()
        Me.lblFilename = New Telerik.WinControls.UI.RadLabel()
        Me.txtDownloadTo = New Telerik.WinControls.UI.RadTextBox()
        Me.ProgressBar1 = New Telerik.WinControls.UI.RadProgressBar()
        Me.cmdRun = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.cmdDownloadTo = New Telerik.WinControls.UI.RadButton()
        Me.tmrSendCurrentSize = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tmrDelayEndTransfer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNickname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFilename, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDownloadTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdDownloadTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.White
        Me.RadLabel1.Location = New System.Drawing.Point(12, 12)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel1.Size = New System.Drawing.Size(133, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "A file is being sent to you"
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(66, 36)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Size = New System.Drawing.Size(26, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "File:"
        '
        'RadLabel3
        '
        Me.RadLabel3.ForeColor = System.Drawing.Color.White
        Me.RadLabel3.Location = New System.Drawing.Point(66, 60)
        Me.RadLabel3.Name = "RadLabel3"
        '
        '
        '
        Me.RadLabel3.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel3.Size = New System.Drawing.Size(28, 18)
        Me.RadLabel3.TabIndex = 2
        Me.RadLabel3.Text = "Size:"
        '
        'RadLabel4
        '
        Me.RadLabel4.ForeColor = System.Drawing.Color.White
        Me.RadLabel4.Location = New System.Drawing.Point(66, 84)
        Me.RadLabel4.Name = "RadLabel4"
        '
        '
        '
        Me.RadLabel4.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel4.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel4.TabIndex = 3
        Me.RadLabel4.Text = "Nickname:"
        '
        'RadLabel5
        '
        Me.RadLabel5.ForeColor = System.Drawing.Color.White
        Me.RadLabel5.Location = New System.Drawing.Point(66, 108)
        Me.RadLabel5.Name = "RadLabel5"
        '
        '
        '
        Me.RadLabel5.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel5.Size = New System.Drawing.Size(18, 18)
        Me.RadLabel5.TabIndex = 4
        Me.RadLabel5.Text = "Ip:"
        '
        'RadLabel6
        '
        Me.RadLabel6.ForeColor = System.Drawing.Color.White
        Me.RadLabel6.Location = New System.Drawing.Point(66, 132)
        Me.RadLabel6.Name = "RadLabel6"
        '
        '
        '
        Me.RadLabel6.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel6.Size = New System.Drawing.Size(29, 18)
        Me.RadLabel6.TabIndex = 5
        Me.RadLabel6.Text = "Port:"
        '
        'RadLabel7
        '
        Me.RadLabel7.ForeColor = System.Drawing.Color.White
        Me.RadLabel7.Location = New System.Drawing.Point(66, 156)
        Me.RadLabel7.Name = "RadLabel7"
        '
        '
        '
        Me.RadLabel7.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel7.Size = New System.Drawing.Size(88, 18)
        Me.RadLabel7.TabIndex = 6
        Me.RadLabel7.Text = "Downloaded To:"
        '
        'RadLabel8
        '
        Me.RadLabel8.ForeColor = System.Drawing.Color.White
        Me.RadLabel8.Location = New System.Drawing.Point(66, 180)
        Me.RadLabel8.Name = "RadLabel8"
        '
        '
        '
        Me.RadLabel8.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel8.Size = New System.Drawing.Size(52, 18)
        Me.RadLabel8.TabIndex = 7
        Me.RadLabel8.Text = "Progress:"
        '
        'lblPort
        '
        Me.lblPort.ForeColor = System.Drawing.Color.White
        Me.lblPort.Location = New System.Drawing.Point(168, 132)
        Me.lblPort.Name = "lblPort"
        '
        '
        '
        Me.lblPort.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblPort.Size = New System.Drawing.Size(14, 18)
        Me.lblPort.TabIndex = 12
        Me.lblPort.Text = "..."
        '
        'lblIp
        '
        Me.lblIp.ForeColor = System.Drawing.Color.White
        Me.lblIp.Location = New System.Drawing.Point(168, 108)
        Me.lblIp.Name = "lblIp"
        '
        '
        '
        Me.lblIp.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblIp.Size = New System.Drawing.Size(14, 18)
        Me.lblIp.TabIndex = 11
        Me.lblIp.Text = "..."
        '
        'lblNickname
        '
        Me.lblNickname.ForeColor = System.Drawing.Color.White
        Me.lblNickname.Location = New System.Drawing.Point(168, 84)
        Me.lblNickname.Name = "lblNickname"
        '
        '
        '
        Me.lblNickname.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblNickname.Size = New System.Drawing.Size(14, 18)
        Me.lblNickname.TabIndex = 10
        Me.lblNickname.Text = "..."
        '
        'lblSize
        '
        Me.lblSize.ForeColor = System.Drawing.Color.White
        Me.lblSize.Location = New System.Drawing.Point(168, 60)
        Me.lblSize.Name = "lblSize"
        '
        '
        '
        Me.lblSize.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblSize.Size = New System.Drawing.Size(14, 18)
        Me.lblSize.TabIndex = 9
        Me.lblSize.Text = "..."
        '
        'lblFilename
        '
        Me.lblFilename.ForeColor = System.Drawing.Color.White
        Me.lblFilename.Location = New System.Drawing.Point(168, 36)
        Me.lblFilename.Name = "lblFilename"
        '
        '
        '
        Me.lblFilename.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblFilename.Size = New System.Drawing.Size(14, 18)
        Me.lblFilename.TabIndex = 8
        Me.lblFilename.Text = "..."
        '
        'txtDownloadTo
        '
        Me.txtDownloadTo.Location = New System.Drawing.Point(168, 156)
        Me.txtDownloadTo.Name = "txtDownloadTo"
        Me.txtDownloadTo.Size = New System.Drawing.Size(135, 20)
        Me.txtDownloadTo.TabIndex = 0
        Me.txtDownloadTo.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ProgressBar1.ImageIndex = -1
        Me.ProgressBar1.ImageKey = ""
        Me.ProgressBar1.ImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ProgressBar1.Location = New System.Drawing.Point(168, 182)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.SeparatorColor1 = System.Drawing.Color.White
        Me.ProgressBar1.SeparatorColor2 = System.Drawing.Color.White
        Me.ProgressBar1.SeparatorColor3 = System.Drawing.Color.White
        Me.ProgressBar1.SeparatorColor4 = System.Drawing.Color.White
        Me.ProgressBar1.Size = New System.Drawing.Size(183, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'cmdRun
        '
        Me.cmdRun.Location = New System.Drawing.Point(168, 211)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(57, 24)
        Me.cmdRun.TabIndex = 13
        Me.cmdRun.Text = "Run"
        Me.cmdRun.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(231, 211)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(57, 24)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(294, 211)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(57, 24)
        Me.cmdCancel.TabIndex = 14
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'cmdDownloadTo
        '
        Me.cmdDownloadTo.Location = New System.Drawing.Point(309, 156)
        Me.cmdDownloadTo.Name = "cmdDownloadTo"
        Me.cmdDownloadTo.Size = New System.Drawing.Size(42, 20)
        Me.cmdDownloadTo.TabIndex = 15
        Me.cmdDownloadTo.Text = "..."
        Me.cmdDownloadTo.ThemeName = "Office2010Black"
        '
        'tmrSendCurrentSize
        '
        '
        'tmrDelayEndTransfer
        '
        Me.tmrDelayEndTransfer.Interval = 2000
        '
        'frmDccGet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 251)
        Me.Controls.Add(Me.cmdDownloadTo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdRun)
        Me.Controls.Add(Me.txtDownloadTo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.lblIp)
        Me.Controls.Add(Me.lblNickname)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.RadLabel8)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDccGet"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Dcc Get"
        Me.ThemeName = "Office2010Black"
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNickname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFilename, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDownloadTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdDownloadTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
    Friend WithEvents Office2007BlackTheme1 As Telerik.WinControls.Themes.Office2007BlackTheme
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPort As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblIp As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNickname As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblSize As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblFilename As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDownloadTo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents ProgressBar1 As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents cmdRun As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdDownloadTo As Telerik.WinControls.UI.RadButton
    Friend WithEvents tmrSendCurrentSize As Timer
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents tmrDelayEndTransfer As Timer
End Class

