<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInOwnWindow
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
        Me.chkShowRawWindow = New System.Windows.Forms.CheckBox
        Me.chkNoticesInOwnWindow = New System.Windows.Forms.CheckBox
        Me.chkMOTDInOwnWindow = New System.Windows.Forms.CheckBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkShowRawWindow
        '
        Me.chkShowRawWindow.AutoSize = True
        Me.chkShowRawWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkShowRawWindow.Location = New System.Drawing.Point(12, 12)
        Me.chkShowRawWindow.Name = "chkShowRawWindow"
        Me.chkShowRawWindow.Size = New System.Drawing.Size(117, 17)
        Me.chkShowRawWindow.TabIndex = 33
        Me.chkShowRawWindow.Text = "Raw in own window"
        Me.chkShowRawWindow.UseVisualStyleBackColor = True
        '
        'chkNoticesInOwnWindow
        '
        Me.chkNoticesInOwnWindow.AutoSize = True
        Me.chkNoticesInOwnWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNoticesInOwnWindow.Location = New System.Drawing.Point(12, 58)
        Me.chkNoticesInOwnWindow.Name = "chkNoticesInOwnWindow"
        Me.chkNoticesInOwnWindow.Size = New System.Drawing.Size(131, 17)
        Me.chkNoticesInOwnWindow.TabIndex = 32
        Me.chkNoticesInOwnWindow.Text = "Notices in own window"
        Me.chkNoticesInOwnWindow.UseVisualStyleBackColor = True
        '
        'chkMOTDInOwnWindow
        '
        Me.chkMOTDInOwnWindow.AutoSize = True
        Me.chkMOTDInOwnWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMOTDInOwnWindow.Location = New System.Drawing.Point(12, 35)
        Me.chkMOTDInOwnWindow.Name = "chkMOTDInOwnWindow"
        Me.chkMOTDInOwnWindow.Size = New System.Drawing.Size(125, 17)
        Me.chkMOTDInOwnWindow.TabIndex = 31
        Me.chkMOTDInOwnWindow.Text = "MOTD in own window"
        Me.chkMOTDInOwnWindow.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(49, 92)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(130, 92)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 36
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmInOwnWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(211, 120)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.chkShowRawWindow)
        Me.Controls.Add(Me.chkNoticesInOwnWindow)
        Me.Controls.Add(Me.chkMOTDInOwnWindow)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInOwnWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Show in own Window"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkShowRawWindow As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoticesInOwnWindow As System.Windows.Forms.CheckBox
    Friend WithEvents chkMOTDInOwnWindow As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
