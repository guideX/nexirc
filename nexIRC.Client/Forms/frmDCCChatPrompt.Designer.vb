<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDccChatPrompt
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
        Me.lblNickName = New Telerik.WinControls.UI.RadLabel()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        Me.lblAddress = New Telerik.WinControls.UI.RadLabel()
        CType(Me.lblNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNickName
        '
        Me.lblNickName.Location = New System.Drawing.Point(163, 12)
        Me.lblNickName.Name = "lblNickName"
        Me.lblNickName.Size = New System.Drawing.Size(49, 18)
        Me.lblNickName.TabIndex = 22
        Me.lblNickName.Text = "<None>"
        Me.lblNickName.ThemeName = "Office2010Black"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(163, 60)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(85, 60)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 24)
        Me.cmdOK.TabIndex = 20
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
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
        Me.RadLabel3.Location = New System.Drawing.Point(12, 36)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(49, 18)
        Me.RadLabel3.TabIndex = 23
        Me.RadLabel3.Text = "Address:"
        Me.RadLabel3.ThemeName = "Office2010Black"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(163, 36)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(49, 18)
        Me.lblAddress.TabIndex = 24
        Me.lblAddress.Text = "<None>"
        Me.lblAddress.ThemeName = "Office2010Black"
        '
        'frmDccChatPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 93)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.RadLabel3)
        Me.Controls.Add(Me.lblNickName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.RadLabel1)
        Me.MaximizeBox = False
        Me.Name = "frmDccChatPrompt"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Accept?"
        Me.ThemeName = "Office2010Black"
        CType(Me.lblNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNickName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
    Friend WithEvents lblAddress As Telerik.WinControls.UI.RadLabel
End Class

