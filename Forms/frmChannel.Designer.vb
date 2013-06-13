<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChannel))
        Me.lvwNicklist = New System.Windows.Forms.ListView()
        Me.txtIncomingColor = New System.Windows.Forms.RichTextBox()
        Me.txtOutgoing = New System.Windows.Forms.TextBox()
        Me.tspChannel = New System.Windows.Forms.ToolStrip()
        Me.cmdPart = New System.Windows.Forms.ToolStripButton()
        Me.cmdHide = New System.Windows.Forms.ToolStripButton()
        Me.cmdNotice = New System.Windows.Forms.ToolStripButton()
        Me.cmdAddToChannelFolder = New System.Windows.Forms.ToolStripButton()
        Me.cmdNames = New System.Windows.Forms.ToolStripButton()
        Me.cmdURL = New System.Windows.Forms.ToolStripButton()
        Me.tmrGetNames = New System.Windows.Forms.Timer(Me.components)
        Me.tspChannel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwNicklist
        '
        Me.lvwNicklist.BackColor = System.Drawing.Color.Black
        Me.lvwNicklist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwNicklist.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwNicklist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwNicklist.Location = New System.Drawing.Point(334, 25)
        Me.lvwNicklist.Name = "lvwNicklist"
        Me.lvwNicklist.Size = New System.Drawing.Size(96, 109)
        Me.lvwNicklist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwNicklist.TabIndex = 9
        Me.lvwNicklist.UseCompatibleStateImageBehavior = False
        Me.lvwNicklist.View = System.Windows.Forms.View.Details
        '
        'txtIncomingColor
        '
        Me.txtIncomingColor.BackColor = System.Drawing.Color.Black
        Me.txtIncomingColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIncomingColor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIncomingColor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomingColor.Location = New System.Drawing.Point(0, 25)
        Me.txtIncomingColor.Name = "txtIncomingColor"
        Me.txtIncomingColor.Size = New System.Drawing.Size(328, 109)
        Me.txtIncomingColor.TabIndex = 8
        Me.txtIncomingColor.Text = ""
        '
        'txtOutgoing
        '
        Me.txtOutgoing.BackColor = System.Drawing.Color.Navy
        Me.txtOutgoing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutgoing.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.ForeColor = System.Drawing.Color.White
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 134)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(430, 19)
        Me.txtOutgoing.TabIndex = 7
        '
        'tspChannel
        '
        Me.tspChannel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tspChannel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspChannel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspChannel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdPart, Me.cmdHide, Me.cmdNotice, Me.cmdAddToChannelFolder, Me.cmdNames, Me.cmdURL})
        Me.tspChannel.Location = New System.Drawing.Point(0, 0)
        Me.tspChannel.Name = "tspChannel"
        Me.tspChannel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspChannel.ShowItemToolTips = False
        Me.tspChannel.Size = New System.Drawing.Size(439, 25)
        Me.tspChannel.TabIndex = 11
        '
        'cmdPart
        '
        Me.cmdPart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPart.Image = CType(resources.GetObject("cmdPart.Image"), System.Drawing.Image)
        Me.cmdPart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPart.Name = "cmdPart"
        Me.cmdPart.Size = New System.Drawing.Size(23, 22)
        Me.cmdPart.Text = "Part"
        '
        'cmdHide
        '
        Me.cmdHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdHide.Image = CType(resources.GetObject("cmdHide.Image"), System.Drawing.Image)
        Me.cmdHide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Size = New System.Drawing.Size(23, 22)
        Me.cmdHide.Text = "Hide"
        '
        'cmdNotice
        '
        Me.cmdNotice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNotice.Image = CType(resources.GetObject("cmdNotice.Image"), System.Drawing.Image)
        Me.cmdNotice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNotice.Name = "cmdNotice"
        Me.cmdNotice.Size = New System.Drawing.Size(23, 22)
        Me.cmdNotice.Text = "Notice"
        '
        'cmdAddToChannelFolder
        '
        Me.cmdAddToChannelFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddToChannelFolder.Image = CType(resources.GetObject("cmdAddToChannelFolder.Image"), System.Drawing.Image)
        Me.cmdAddToChannelFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddToChannelFolder.Name = "cmdAddToChannelFolder"
        Me.cmdAddToChannelFolder.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddToChannelFolder.Text = "Add to Channel Folder"
        '
        'cmdNames
        '
        Me.cmdNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNames.Image = CType(resources.GetObject("cmdNames.Image"), System.Drawing.Image)
        Me.cmdNames.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNames.Name = "cmdNames"
        Me.cmdNames.Size = New System.Drawing.Size(23, 22)
        Me.cmdNames.Text = "Refresh NickList"
        '
        'cmdURL
        '
        Me.cmdURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdURL.Image = CType(resources.GetObject("cmdURL.Image"), System.Drawing.Image)
        Me.cmdURL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdURL.Name = "cmdURL"
        Me.cmdURL.Size = New System.Drawing.Size(23, 22)
        Me.cmdURL.Text = "URL"
        Me.cmdURL.Visible = False
        '
        'tmrGetNames
        '
        '
        'frmChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(439, 165)
        Me.Controls.Add(Me.tspChannel)
        Me.Controls.Add(Me.lvwNicklist)
        Me.Controls.Add(Me.txtIncomingColor)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChannel"
        Me.Text = "frmChannel"
        Me.tspChannel.ResumeLayout(False)
        Me.tspChannel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwNicklist As System.Windows.Forms.ListView
    Friend WithEvents txtIncomingColor As System.Windows.Forms.RichTextBox
    Friend WithEvents txtOutgoing As System.Windows.Forms.TextBox
    Friend WithEvents tspChannel As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdURL As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrGetNames As System.Windows.Forms.Timer
    Friend WithEvents cmdNotice As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAddToChannelFolder As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNames As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPart As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdHide As System.Windows.Forms.ToolStripButton
End Class
