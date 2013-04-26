<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRaw
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
        Me.txtInData = New System.Windows.Forms.TextBox
        Me.txtOutData = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtInData
        '
        Me.txtInData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInData.Location = New System.Drawing.Point(0, 0)
        Me.txtInData.Multiline = True
        Me.txtInData.Name = "txtInData"
        Me.txtInData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInData.Size = New System.Drawing.Size(318, 85)
        Me.txtInData.TabIndex = 0
        '
        'txtOutData
        '
        Me.txtOutData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutData.Location = New System.Drawing.Point(0, 91)
        Me.txtOutData.Multiline = True
        Me.txtOutData.Name = "txtOutData"
        Me.txtOutData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutData.Size = New System.Drawing.Size(318, 85)
        Me.txtOutData.TabIndex = 1
        '
        'frmRaw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(326, 184)
        Me.Controls.Add(Me.txtOutData)
        Me.Controls.Add(Me.txtInData)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmRaw"
        Me.Text = "frmRaw"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInData As System.Windows.Forms.TextBox
    Friend WithEvents txtOutData As System.Windows.Forms.TextBox
End Class
