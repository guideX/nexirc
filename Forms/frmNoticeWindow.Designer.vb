<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoticeWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtIncomingColor = New System.Windows.Forms.RichTextBox
        Me.txtOutgoing = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtIncomingColor
        '
        Me.txtIncomingColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIncomingColor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIncomingColor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomingColor.Location = New System.Drawing.Point(0, 0)
        Me.txtIncomingColor.Name = "txtIncomingColor"
        Me.txtIncomingColor.Size = New System.Drawing.Size(172, 76)
        Me.txtIncomingColor.TabIndex = 1
        Me.txtIncomingColor.Text = ""
        '
        'txtOutgoing
        '
        Me.txtOutgoing.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOutgoing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutgoing.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 82)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(172, 16)
        Me.txtOutgoing.TabIndex = 2
        '
        'frmNoticeWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(180, 105)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.txtIncomingColor)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmNoticeWindow"
        Me.Text = "Notice Window"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIncomingColor As System.Windows.Forms.RichTextBox
    Friend WithEvents txtOutgoing As System.Windows.Forms.TextBox
End Class
