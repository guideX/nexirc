<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXLogin
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.chkXEnable = New System.Windows.Forms.CheckBox()
        Me.chkLoginOnConnect = New System.Windows.Forms.CheckBox()
        Me.chkShowOnConnect = New System.Windows.Forms.CheckBox()
        Me.lblCreateAnAccount = New System.Windows.Forms.Label()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(15, 25)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(303, 21)
        Me.txtUsername.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(15, 64)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(303, 21)
        Me.txtPassword.TabIndex = 3
        '
        'chkXEnable
        '
        Me.chkXEnable.AutoSize = True
        Me.chkXEnable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkXEnable.Location = New System.Drawing.Point(15, 137)
        Me.chkXEnable.Name = "chkXEnable"
        Me.chkXEnable.Size = New System.Drawing.Size(58, 17)
        Me.chkXEnable.TabIndex = 4
        Me.chkXEnable.Text = "Enable"
        Me.chkXEnable.UseVisualStyleBackColor = True
        '
        'chkLoginOnConnect
        '
        Me.chkLoginOnConnect.AutoSize = True
        Me.chkLoginOnConnect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLoginOnConnect.Location = New System.Drawing.Point(15, 91)
        Me.chkLoginOnConnect.Name = "chkLoginOnConnect"
        Me.chkLoginOnConnect.Size = New System.Drawing.Size(109, 17)
        Me.chkLoginOnConnect.TabIndex = 5
        Me.chkLoginOnConnect.Text = "Login on Connect"
        Me.chkLoginOnConnect.UseVisualStyleBackColor = True
        '
        'chkShowOnConnect
        '
        Me.chkShowOnConnect.AutoSize = True
        Me.chkShowOnConnect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowOnConnect.Location = New System.Drawing.Point(15, 114)
        Me.chkShowOnConnect.Name = "chkShowOnConnect"
        Me.chkShowOnConnect.Size = New System.Drawing.Size(110, 17)
        Me.chkShowOnConnect.TabIndex = 6
        Me.chkShowOnConnect.Text = "Show on Connect"
        Me.chkShowOnConnect.UseVisualStyleBackColor = True
        '
        'lblCreateAnAccount
        '
        Me.lblCreateAnAccount.AutoSize = True
        Me.lblCreateAnAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCreateAnAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateAnAccount.ForeColor = System.Drawing.Color.Blue
        Me.lblCreateAnAccount.Location = New System.Drawing.Point(222, 91)
        Me.lblCreateAnAccount.Name = "lblCreateAnAccount"
        Me.lblCreateAnAccount.Size = New System.Drawing.Size(96, 13)
        Me.lblCreateAnAccount.TabIndex = 8
        Me.lblCreateAnAccount.Text = "Create an account"
        '
        'cmdLogin
        '
        Me.cmdLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLogin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLogin.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(144, 131)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(84, 27)
        Me.cmdLogin.TabIndex = 11
        Me.cmdLogin.Text = "&Login"
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = Global.nexIRC.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(234, 131)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(84, 27)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Tag = "s"
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmXLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 170)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblCreateAnAccount)
        Me.Controls.Add(Me.chkShowOnConnect)
        Me.Controls.Add(Me.chkLoginOnConnect)
        Me.Controls.Add(Me.chkXEnable)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmXLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "nexIRC - X Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkXEnable As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoginOnConnect As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowOnConnect As System.Windows.Forms.CheckBox
    Friend WithEvents lblCreateAnAccount As System.Windows.Forms.Label
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
