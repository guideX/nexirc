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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmdAddToChannelFolder = New System.Windows.Forms.ToolStripButton()
        Me.cmdAddToAutoJoin = New System.Windows.Forms.ToolStripButton()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwChannels
        '
        Me.lvwChannels.BackColor = System.Drawing.Color.Black
        Me.lvwChannels.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwChannels.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwChannels.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lvwChannels.FullRowSelect = True
        Me.lvwChannels.Location = New System.Drawing.Point(0, 25)
        Me.lvwChannels.Name = "lvwChannels"
        Me.lvwChannels.Size = New System.Drawing.Size(274, 113)
        Me.lvwChannels.TabIndex = 0
        Me.lvwChannels.UseCompatibleStateImageBehavior = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdRefresh, Me.ToolStripSeparator1, Me.cmdAddToChannelFolder, Me.cmdAddToAutoJoin, Me.ToolStripSeparator2, Me.cmdClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(345, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRefresh.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(23, 22)
        Me.cmdRefresh.Text = "Refresh"
        '
        'cmdAddToChannelFolder
        '
        Me.cmdAddToChannelFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddToChannelFolder.Image = Global.nexIRC.My.Resources.Resources.add
        Me.cmdAddToChannelFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddToChannelFolder.Name = "cmdAddToChannelFolder"
        Me.cmdAddToChannelFolder.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddToChannelFolder.Text = "Add to Channel Folder"
        '
        'cmdAddToAutoJoin
        '
        Me.cmdAddToAutoJoin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddToAutoJoin.Image = Global.nexIRC.My.Resources.Resources.add
        Me.cmdAddToAutoJoin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddToAutoJoin.Name = "cmdAddToAutoJoin"
        Me.cmdAddToAutoJoin.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddToAutoJoin.Text = "Add to Auto Join"
        '
        'cmdClose
        '
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdClose.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(23, 22)
        Me.cmdClose.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frmChannelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(345, 159)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lvwChannels)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChannelList"
        Me.Text = "Channel List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwChannels As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAddToChannelFolder As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAddToAutoJoin As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
