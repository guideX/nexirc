<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotepad
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
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.BackColor = System.Drawing.Color.Black
        Me.txtData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtData.ForeColor = System.Drawing.Color.White
        Me.txtData.Location = New System.Drawing.Point(0, 0)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtData.Size = New System.Drawing.Size(405, 273)
        Me.txtData.TabIndex = 1
        '
        'frmNotepad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 273)
        Me.Controls.Add(Me.txtData)
        Me.Name = "frmNotepad"
        Me.Text = "Notepad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtData As System.Windows.Forms.TextBox
End Class
