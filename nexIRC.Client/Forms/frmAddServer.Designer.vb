<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddServer))
        Me.lblDescription = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.lblNetwork = New Telerik.WinControls.UI.RadLabel()
        Me.txtDescription = New Telerik.WinControls.UI.RadTextBox()
        Me.txtPort = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIP = New Telerik.WinControls.UI.RadTextBox()
        Me.cboNetwork = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdNewNetwork = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        CType(Me.lblDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdNewNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(12, 12)
        Me.lblDescription.Name = "lblDescription"
        '
        '
        '
        Me.lblDescription.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Size = New System.Drawing.Size(66, 18)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Description:"
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(12, 36)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Size = New System.Drawing.Size(43, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "IP/Port:"
        '
        'lblNetwork
        '
        Me.lblNetwork.ForeColor = System.Drawing.Color.White
        Me.lblNetwork.Location = New System.Drawing.Point(12, 60)
        Me.lblNetwork.Name = "lblNetwork"
        '
        '
        '
        Me.lblNetwork.RootElement.ForeColor = System.Drawing.Color.White
        Me.lblNetwork.Size = New System.Drawing.Size(51, 18)
        Me.lblNetwork.TabIndex = 2
        Me.lblNetwork.Text = "Network:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(90, 10)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(206, 20)
        Me.txtDescription.TabIndex = 3
        Me.txtDescription.TabStop = False
        Me.txtDescription.ThemeName = "Office2010Black"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(196, 36)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 4
        Me.txtPort.TabStop = False
        Me.txtPort.ThemeName = "Office2010Black"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(90, 36)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(100, 20)
        Me.txtIP.TabIndex = 5
        Me.txtIP.TabStop = False
        Me.txtIP.ThemeName = "Office2010Black"
        '
        'cboNetwork
        '
        Me.cboNetwork.DropDownAnimationEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(90, 62)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.ShowImageInEditorArea = True
        Me.cboNetwork.Size = New System.Drawing.Size(206, 20)
        Me.cboNetwork.TabIndex = 6
        Me.cboNetwork.ThemeName = "Office2010Black"
        '
        'cmdNewNetwork
        '
        Me.cmdNewNetwork.Location = New System.Drawing.Point(90, 88)
        Me.cmdNewNetwork.Name = "cmdNewNetwork"
        Me.cmdNewNetwork.Size = New System.Drawing.Size(206, 24)
        Me.cmdNewNetwork.TabIndex = 7
        Me.cmdNewNetwork.Text = "New Network"
        Me.cmdNewNetwork.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(90, 134)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 24)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(196, 134)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'frmAddServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 170)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdNewNetwork)
        Me.Controls.Add(Me.cboNetwork)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblNetwork)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.lblDescription)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAddServer"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Add Server"
        Me.ThemeName = "Office2010Black"
        CType(Me.lblDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdNewNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNetwork As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDescription As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtPort As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIP As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cboNetwork As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdNewNetwork As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
End Class

