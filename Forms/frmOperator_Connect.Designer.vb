<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperator_Connect
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
        Me.lblTargetServer = New System.Windows.Forms.Label()
        Me.cboTargetServer = New System.Windows.Forms.ComboBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblRemoteServer = New System.Windows.Forms.Label()
        Me.txtRemoteServer = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTargetServer
        '
        Me.lblTargetServer.AutoSize = True
        Me.lblTargetServer.Location = New System.Drawing.Point(12, 9)
        Me.lblTargetServer.Name = "lblTargetServer"
        Me.lblTargetServer.Size = New System.Drawing.Size(78, 13)
        Me.lblTargetServer.TabIndex = 0
        Me.lblTargetServer.Text = "Target Server:"
        '
        'cboTargetServer
        '
        Me.cboTargetServer.FormattingEnabled = True
        Me.cboTargetServer.Location = New System.Drawing.Point(118, 6)
        Me.cboTargetServer.Name = "cboTargetServer"
        Me.cboTargetServer.Size = New System.Drawing.Size(195, 21)
        Me.cboTargetServer.TabIndex = 1
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(12, 36)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(31, 13)
        Me.lblPort.TabIndex = 2
        Me.lblPort.Text = "Port:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(118, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(195, 21)
        Me.TextBox1.TabIndex = 3
        '
        'lblRemoteServer
        '
        Me.lblRemoteServer.AutoSize = True
        Me.lblRemoteServer.Location = New System.Drawing.Point(12, 63)
        Me.lblRemoteServer.Name = "lblRemoteServer"
        Me.lblRemoteServer.Size = New System.Drawing.Size(83, 13)
        Me.lblRemoteServer.TabIndex = 4
        Me.lblRemoteServer.Text = "Remote Server:"
        '
        'txtRemoteServer
        '
        Me.txtRemoteServer.Location = New System.Drawing.Point(118, 60)
        Me.txtRemoteServer.Name = "txtRemoteServer"
        Me.txtRemoteServer.Size = New System.Drawing.Size(195, 21)
        Me.txtRemoteServer.TabIndex = 5
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(238, 87)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(157, 87)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmOperator_Connect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 122)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtRemoteServer)
        Me.Controls.Add(Me.lblRemoteServer)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.cboTargetServer)
        Me.Controls.Add(Me.lblTargetServer)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmOperator_Connect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "nexIRC - Operator Connect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTargetServer As System.Windows.Forms.Label
    Friend WithEvents cboTargetServer As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRemoteServer As System.Windows.Forms.Label
    Friend WithEvents txtRemoteServer As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
