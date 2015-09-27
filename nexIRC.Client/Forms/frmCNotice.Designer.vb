<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCNotice
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
        Me.txtChannel = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.txtNickname = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.txtMessage = New Telerik.WinControls.UI.RadTextBox()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        CType(Me.txtChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNickname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(84, 39)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(259, 20)
        Me.txtChannel.TabIndex = 23
        Me.txtChannel.TabStop = False
        Me.txtChannel.ThemeName = "Office2010Black"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(12, 38)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(49, 18)
        Me.RadLabel2.TabIndex = 22
        Me.RadLabel2.Text = "Channel:"
        Me.RadLabel2.ThemeName = "Office2010Black"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(271, 141)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(193, 141)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 24)
        Me.cmdOK.TabIndex = 20
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'txtNickname
        '
        Me.txtNickname.Location = New System.Drawing.Point(84, 13)
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(259, 20)
        Me.txtNickname.TabIndex = 19
        Me.txtNickname.TabStop = False
        Me.txtNickname.ThemeName = "Office2010Black"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(12, 12)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel1.TabIndex = 18
        Me.RadLabel1.Text = "Nickname:"
        Me.RadLabel1.ThemeName = "Office2010Black"
        '
        'RadLabel3
        '
        Me.RadLabel3.Location = New System.Drawing.Point(12, 65)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(53, 18)
        Me.RadLabel3.TabIndex = 23
        Me.RadLabel3.Text = "Message:"
        Me.RadLabel3.ThemeName = "Office2010Black"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(84, 65)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        '
        '
        '
        Me.txtMessage.RootElement.StretchVertically = True
        Me.txtMessage.Size = New System.Drawing.Size(259, 70)
        Me.txtMessage.TabIndex = 24
        Me.txtMessage.TabStop = False
        Me.txtMessage.ThemeName = "Office2010Black"
        '
        'FrmCNotice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 172)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.txtChannel)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtNickname)
        Me.Controls.Add(Me.RadLabel1)
        Me.Name = "FrmCNotice"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "CNotice"
        Me.ThemeName = "Office2010Black"
        CType(Me.txtChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNickname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChannel As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtNickname As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtMessage As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
End Class

