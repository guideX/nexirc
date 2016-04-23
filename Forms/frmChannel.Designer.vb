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
        Me.tspChannel = New System.Windows.Forms.ToolStrip()
        Me.cmdClear = New System.Windows.Forms.ToolStripButton()
        Me.cmdPart = New System.Windows.Forms.ToolStripButton()
        Me.cmdHide = New System.Windows.Forms.ToolStripButton()
        Me.cmdNotice = New System.Windows.Forms.ToolStripButton()
        Me.cmdAddToChannelFolder = New System.Windows.Forms.ToolStripButton()
        Me.cmdNames = New System.Windows.Forms.ToolStripButton()
        Me.cmdURL = New System.Windows.Forms.ToolStripButton()
        Me.tmrGetNames = New System.Windows.Forms.Timer(Me.components)
        Me.txtIncoming = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        Me.txtOutgoing = New Telerik.WinControls.UI.RadTextBox()
        Me.lvwNickList = New Telerik.WinControls.UI.RadListView()
        Me.tmrAddNameDelay = New System.Windows.Forms.Timer(Me.components)
        Me.tspChannel.SuspendLayout()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvwNickList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tspChannel
        '
        Me.tspChannel.BackColor = System.Drawing.Color.White
        Me.tspChannel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspChannel.GripMargin = New System.Windows.Forms.Padding(0)
        Me.tspChannel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspChannel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdClear, Me.cmdPart, Me.cmdHide, Me.cmdNotice, Me.cmdAddToChannelFolder, Me.cmdNames, Me.cmdURL})
        Me.tspChannel.Location = New System.Drawing.Point(0, 0)
        Me.tspChannel.Name = "tspChannel"
        Me.tspChannel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspChannel.ShowItemToolTips = False
        Me.tspChannel.Size = New System.Drawing.Size(434, 25)
        Me.tspChannel.TabIndex = 11
        '
        'cmdClear
        '
        Me.cmdClear.Image = Global.nexIRC.My.Resources.Resources.delete
        Me.cmdClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(60, 22)
        Me.cmdClear.Text = "&Clear"
        '
        'cmdPart
        '
        Me.cmdPart.Image = CType(resources.GetObject("cmdPart.Image"), System.Drawing.Image)
        Me.cmdPart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPart.Name = "cmdPart"
        Me.cmdPart.Size = New System.Drawing.Size(53, 22)
        Me.cmdPart.Text = "Part"
        '
        'cmdHide
        '
        Me.cmdHide.Image = CType(resources.GetObject("cmdHide.Image"), System.Drawing.Image)
        Me.cmdHide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Size = New System.Drawing.Size(57, 22)
        Me.cmdHide.Text = "Hide"
        '
        'cmdNotice
        '
        Me.cmdNotice.Image = CType(resources.GetObject("cmdNotice.Image"), System.Drawing.Image)
        Me.cmdNotice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNotice.Name = "cmdNotice"
        Me.cmdNotice.Size = New System.Drawing.Size(68, 22)
        Me.cmdNotice.Text = "Notice"
        '
        'cmdAddToChannelFolder
        '
        Me.cmdAddToChannelFolder.Image = CType(resources.GetObject("cmdAddToChannelFolder.Image"), System.Drawing.Image)
        Me.cmdAddToChannelFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddToChannelFolder.Name = "cmdAddToChannelFolder"
        Me.cmdAddToChannelFolder.Size = New System.Drawing.Size(166, 22)
        Me.cmdAddToChannelFolder.Text = "Add to Channel Folder"
        '
        'cmdNames
        '
        Me.cmdNames.Image = CType(resources.GetObject("cmdNames.Image"), System.Drawing.Image)
        Me.cmdNames.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNames.Name = "cmdNames"
        Me.cmdNames.Size = New System.Drawing.Size(127, 22)
        Me.cmdNames.Text = "Refresh NickList"
        '
        'cmdURL
        '
        Me.cmdURL.Image = CType(resources.GetObject("cmdURL.Image"), System.Drawing.Image)
        Me.cmdURL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdURL.Name = "cmdURL"
        Me.cmdURL.Size = New System.Drawing.Size(51, 22)
        Me.cmdURL.Text = "URL"
        Me.cmdURL.Visible = False
        '
        'tmrGetNames
        '
        '
        'txtIncoming
        '
        Me.txtIncoming.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncoming.Location = New System.Drawing.Point(0, 25)
        Me.txtIncoming.Name = "txtIncoming"
        Me.txtIncoming.Size = New System.Drawing.Size(316, 103)
        Me.txtIncoming.TabIndex = 13
        Me.txtIncoming.Text = "RadRichTextBox1"
        '
        'txtOutgoing
        '
        Me.txtOutgoing.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 134)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(429, 25)
        Me.txtOutgoing.TabIndex = 17
        Me.txtOutgoing.TabStop = False
        '
        'lvwNickList
        '
        Me.lvwNickList.EnableSorting = True
        Me.lvwNickList.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwNickList.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNickList.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNickList.Location = New System.Drawing.Point(322, 25)
        Me.lvwNickList.Name = "lvwNickList"
        Me.lvwNickList.Size = New System.Drawing.Size(107, 103)
        Me.lvwNickList.TabIndex = 18
        Me.lvwNickList.Text = "RadListView1"
        '
        'tmrAddNameDelay
        '
        Me.tmrAddNameDelay.Interval = 200
        '
        'frmChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(434, 165)
        Me.Controls.Add(Me.lvwNickList)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.txtIncoming)
        Me.Controls.Add(Me.tspChannel)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChannel"
        Me.Text = "frmChannel"
        Me.tspChannel.ResumeLayout(False)
        Me.tspChannel.PerformLayout()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvwNickList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspChannel As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdURL As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrGetNames As System.Windows.Forms.Timer
    Friend WithEvents cmdNotice As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAddToChannelFolder As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNames As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPart As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdHide As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtIncoming As Telerik.WinControls.RichTextBox.RadRichTextBox
    Friend WithEvents txtOutgoing As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lvwNickList As Telerik.WinControls.UI.RadListView
    Friend WithEvents cmdClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrAddNameDelay As System.Windows.Forms.Timer
End Class
