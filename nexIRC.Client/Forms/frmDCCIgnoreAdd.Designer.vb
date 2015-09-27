<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDccIgnoreAdd
    Inherits Telerik.WinControls.UI.RadForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDccIgnoreAdd))
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.Office2007BlackTheme1 = New Telerik.WinControls.Themes.Office2007BlackTheme()
        Me.tmrSendCurrentSize = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tmrDelayEndTransfer = New System.Windows.Forms.Timer(Me.components)
        Me.txtValue = New Telerik.WinControls.UI.RadTextBox()
        Me.optNickName = New Telerik.WinControls.UI.RadRadioButton()
        Me.optFileType = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        CType(Me.txtValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optFileType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrDelayEndTransfer
        '
        Me.tmrDelayEndTransfer.Interval = 2000
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(55, 10)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(242, 20)
        Me.txtValue.TabIndex = 0
        Me.txtValue.TabStop = False
        '
        'optNickName
        '
        Me.optNickName.ForeColor = System.Drawing.Color.White
        Me.optNickName.Location = New System.Drawing.Point(55, 36)
        Me.optNickName.Name = "optNickName"
        '
        '
        '
        Me.optNickName.RootElement.ForeColor = System.Drawing.Color.White
        Me.optNickName.Size = New System.Drawing.Size(110, 18)
        Me.optNickName.TabIndex = 1
        Me.optNickName.Text = "Nickname"
        '
        'optFileType
        '
        Me.optFileType.ForeColor = System.Drawing.Color.White
        Me.optFileType.Location = New System.Drawing.Point(55, 60)
        Me.optFileType.Name = "optFileType"
        '
        '
        '
        Me.optFileType.RootElement.ForeColor = System.Drawing.Color.White
        Me.optFileType.Size = New System.Drawing.Size(110, 18)
        Me.optFileType.TabIndex = 0
        Me.optFileType.Text = "File type"
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
        Me.RadLabel1.Size = New System.Drawing.Size(37, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "Value:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(268, 84)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 24)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(162, 84)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 24)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'frmDccIgnoreAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 122)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.optNickName)
        Me.Controls.Add(Me.optFileType)
        Me.Controls.Add(Me.txtValue)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDccIgnoreAdd"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Dcc Ignore Add"
        Me.ThemeName = "Office2010Black"
        CType(Me.txtValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optFileType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
    Friend WithEvents Office2007BlackTheme1 As Telerik.WinControls.Themes.Office2007BlackTheme
    Friend WithEvents tmrSendCurrentSize As Timer
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents tmrDelayEndTransfer As Timer
    Friend WithEvents txtValue As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents optNickName As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optFileType As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
End Class

