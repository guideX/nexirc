<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNickServLogin
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
        Me.lblCreateAnAccount = New System.Windows.Forms.Label()
        Me.chkShowOnConnect = New System.Windows.Forms.CheckBox()
        Me.chkLoginOnConnect = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkXEnable = New System.Windows.Forms.CheckBox()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCreateAnAccount
        '
        Me.lblCreateAnAccount.AutoSize = True
        Me.lblCreateAnAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCreateAnAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateAnAccount.ForeColor = System.Drawing.Color.Blue
        Me.lblCreateAnAccount.Location = New System.Drawing.Point(224, 56)
        Me.lblCreateAnAccount.Name = "lblCreateAnAccount"
        Me.lblCreateAnAccount.Size = New System.Drawing.Size(95, 13)
        Me.lblCreateAnAccount.TabIndex = 15
        Me.lblCreateAnAccount.Text = "Create an account"
        Me.lblCreateAnAccount.Visible = False
        '
        'chkShowOnConnect
        '
        Me.chkShowOnConnect.AutoSize = True
        Me.chkShowOnConnect.Location = New System.Drawing.Point(15, 102)
        Me.chkShowOnConnect.Name = "chkShowOnConnect"
        Me.chkShowOnConnect.Size = New System.Drawing.Size(110, 17)
        Me.chkShowOnConnect.TabIndex = 13
        Me.chkShowOnConnect.Text = "Show on Connect"
        Me.chkShowOnConnect.UseVisualStyleBackColor = True
        '
        'chkLoginOnConnect
        '
        Me.chkLoginOnConnect.AutoSize = True
        Me.chkLoginOnConnect.Location = New System.Drawing.Point(15, 79)
        Me.chkLoginOnConnect.Name = "chkLoginOnConnect"
        Me.chkLoginOnConnect.Size = New System.Drawing.Size(109, 17)
        Me.chkLoginOnConnect.TabIndex = 12
        Me.chkLoginOnConnect.Text = "Login on Connect"
        Me.chkLoginOnConnect.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(15, 25)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(304, 21)
        Me.txtPassword.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Password:"
        '
        'chkXEnable
        '
        Me.chkXEnable.AutoSize = True
        Me.chkXEnable.Location = New System.Drawing.Point(15, 56)
        Me.chkXEnable.Name = "chkXEnable"
        Me.chkXEnable.Size = New System.Drawing.Size(58, 17)
        Me.chkXEnable.TabIndex = 11
        Me.chkXEnable.Text = "Enable"
        Me.chkXEnable.UseVisualStyleBackColor = True
        '
        'cmdLogin
        '
        Me.cmdLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLogin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogin.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(145, 92)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(84, 27)
        Me.cmdLogin.TabIndex = 17
        Me.cmdLogin.Text = "&Login"
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = Global.nexIRC.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(235, 92)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(84, 27)
        Me.cmdCancel.TabIndex = 16
        Me.cmdCancel.Tag = "s"
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmNickServLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 130)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblCreateAnAccount)
        Me.Controls.Add(Me.chkShowOnConnect)
        Me.Controls.Add(Me.chkLoginOnConnect)
        Me.Controls.Add(Me.chkXEnable)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNickServLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "nexIRC - Nickserv"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCreateAnAccount As System.Windows.Forms.Label
    Friend WithEvents chkShowOnConnect As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoginOnConnect As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkXEnable As System.Windows.Forms.CheckBox
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
