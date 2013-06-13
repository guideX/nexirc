<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelList
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
        Me.lvwChannels = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lvwChannels
        '
        Me.lvwChannels.BackColor = System.Drawing.Color.Black
        Me.lvwChannels.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwChannels.ForeColor = System.Drawing.Color.White
        Me.lvwChannels.FullRowSelect = True
        Me.lvwChannels.Location = New System.Drawing.Point(1, 1)
        Me.lvwChannels.Name = "lvwChannels"
        Me.lvwChannels.Size = New System.Drawing.Size(274, 113)
        Me.lvwChannels.TabIndex = 0
        Me.lvwChannels.UseCompatibleStateImageBehavior = False
        '
        'frmChannelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 159)
        Me.Controls.Add(Me.lvwChannels)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChannelList"
        Me.Text = "Channel List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwChannels As System.Windows.Forms.ListView
End Class
