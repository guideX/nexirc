<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompatibility
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
        Me.lvwCompatibility = New System.Windows.Forms.ListView
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblAdd = New System.Windows.Forms.LinkLabel
        Me.lblRemove = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'lvwCompatibility
        '
        Me.lvwCompatibility.FullRowSelect = True
        Me.lvwCompatibility.Location = New System.Drawing.Point(3, 2)
        Me.lvwCompatibility.Name = "lvwCompatibility"
        Me.lvwCompatibility.Size = New System.Drawing.Size(268, 160)
        Me.lvwCompatibility.TabIndex = 0
        Me.lvwCompatibility.UseCompatibleStateImageBehavior = False
        Me.lvwCompatibility.View = System.Windows.Forms.View.Details
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(115, 168)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(196, 168)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblAdd
        '
        Me.lblAdd.AutoSize = True
        Me.lblAdd.Location = New System.Drawing.Point(0, 165)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(26, 13)
        Me.lblAdd.TabIndex = 3
        Me.lblAdd.TabStop = True
        Me.lblAdd.Text = "Add"
        '
        'lblRemove
        '
        Me.lblRemove.AutoSize = True
        Me.lblRemove.Location = New System.Drawing.Point(32, 165)
        Me.lblRemove.Name = "lblRemove"
        Me.lblRemove.Size = New System.Drawing.Size(46, 13)
        Me.lblRemove.TabIndex = 4
        Me.lblRemove.TabStop = True
        Me.lblRemove.Text = "Remove"
        '
        'frmCompatibility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(276, 195)
        Me.Controls.Add(Me.lblRemove)
        Me.Controls.Add(Me.lblAdd)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lvwCompatibility)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompatibility"
        Me.Text = "nexIRC - IRC Compatibility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwCompatibility As System.Windows.Forms.ListView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRemove As System.Windows.Forms.LinkLabel
End Class
