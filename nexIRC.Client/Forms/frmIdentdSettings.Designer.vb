<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIdentdSettings
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
        Me.chkIdentdEnabled = New System.Windows.Forms.CheckBox
        Me.txtIdentdPort = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtIdentdSystem = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtIdentdUserID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkIdentdEnabled
        '
        Me.chkIdentdEnabled.AutoSize = True
        Me.chkIdentdEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIdentdEnabled.Location = New System.Drawing.Point(166, 93)
        Me.chkIdentdEnabled.Name = "chkIdentdEnabled"
        Me.chkIdentdEnabled.Size = New System.Drawing.Size(61, 17)
        Me.chkIdentdEnabled.TabIndex = 60
        Me.chkIdentdEnabled.Text = "Enabled"
        Me.chkIdentdEnabled.UseVisualStyleBackColor = True
        '
        'txtIdentdPort
        '
        Me.txtIdentdPort.Location = New System.Drawing.Point(166, 66)
        Me.txtIdentdPort.Name = "txtIdentdPort"
        Me.txtIdentdPort.Size = New System.Drawing.Size(295, 21)
        Me.txtIdentdPort.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(10, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Port:"
        '
        'txtIdentdSystem
        '
        Me.txtIdentdSystem.Location = New System.Drawing.Point(166, 39)
        Me.txtIdentdSystem.Name = "txtIdentdSystem"
        Me.txtIdentdSystem.Size = New System.Drawing.Size(295, 21)
        Me.txtIdentdSystem.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(10, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "System:"
        '
        'txtIdentdUserID
        '
        Me.txtIdentdUserID.Location = New System.Drawing.Point(166, 12)
        Me.txtIdentdUserID.Name = "txtIdentdUserID"
        Me.txtIdentdUserID.Size = New System.Drawing.Size(295, 21)
        Me.txtIdentdUserID.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(10, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "User ID:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(359, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(101, 24)
        Me.cmdCancel.TabIndex = 61
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(252, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(101, 24)
        Me.cmdOK.TabIndex = 62
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmIdentdSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 156)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkIdentdEnabled)
        Me.Controls.Add(Me.txtIdentdPort)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIdentdSystem)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIdentdUserID)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIdentdSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "nexIRC - Identd Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkIdentdEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtIdentdPort As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIdentdSystem As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIdentdUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
