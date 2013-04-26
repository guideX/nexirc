<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChannel))
        Me.txtOutgoing = New System.Windows.Forms.TextBox()
        Me.txtIncomingColor = New System.Windows.Forms.RichTextBox()
        Me.tspChannel = New System.Windows.Forms.ToolStrip()
        Me.cmd_Add = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_AutoJoin = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_ChannelFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Notice = New System.Windows.Forms.ToolStripButton()
        Me.cmd_Names = New System.Windows.Forms.ToolStripButton()
        Me.cmd_Modes = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_ChannelOperator = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_GiveVoice = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_Moderated = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_InviteOnly = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Hide = New System.Windows.Forms.ToolStripButton()
        Me.cmd_Part = New System.Windows.Forms.ToolStripButton()
        Me.cmd_Close = New System.Windows.Forms.ToolStripButton()
        Me.cmd_URL = New System.Windows.Forms.ToolStripButton()
        Me.cmd_NickList = New System.Windows.Forms.MenuStrip()
        Me.cmd_NickListPopup = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_NickQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_NickNotice = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrGetNames = New System.Windows.Forms.Timer(Me.components)
        Me.lvwNicklist = New System.Windows.Forms.ListView()
        Me.tspChannel.SuspendLayout()
        Me.cmd_NickList.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOutgoing
        '
        Me.txtOutgoing.BackColor = System.Drawing.Color.MistyRose
        Me.txtOutgoing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutgoing.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 137)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(430, 16)
        Me.txtOutgoing.TabIndex = 0
        '
        'txtIncomingColor
        '
        Me.txtIncomingColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIncomingColor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIncomingColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomingColor.Location = New System.Drawing.Point(0, 25)
        Me.txtIncomingColor.Name = "txtIncomingColor"
        Me.txtIncomingColor.Size = New System.Drawing.Size(328, 109)
        Me.txtIncomingColor.TabIndex = 3
        Me.txtIncomingColor.Text = ""
        '
        'tspChannel
        '
        Me.tspChannel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tspChannel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspChannel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspChannel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_Add, Me.cmd_Notice, Me.cmd_Names, Me.cmd_Modes, Me.cmd_Hide, Me.cmd_Part, Me.cmd_Close, Me.cmd_URL})
        Me.tspChannel.Location = New System.Drawing.Point(0, 0)
        Me.tspChannel.Name = "tspChannel"
        Me.tspChannel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspChannel.ShowItemToolTips = False
        Me.tspChannel.Size = New System.Drawing.Size(469, 25)
        Me.tspChannel.TabIndex = 4
        Me.tspChannel.Text = "ToolStrip1"
        '
        'cmd_Add
        '
        Me.cmd_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Add.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_AutoJoin, Me.cmd_ChannelFolder})
        Me.cmd_Add.Image = CType(resources.GetObject("cmd_Add.Image"), System.Drawing.Image)
        Me.cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(42, 22)
        Me.cmd_Add.Text = "Add"
        '
        'cmd_AutoJoin
        '
        Me.cmd_AutoJoin.Name = "cmd_AutoJoin"
        Me.cmd_AutoJoin.Size = New System.Drawing.Size(181, 22)
        Me.cmd_AutoJoin.Text = "Add to Auto Join"
        '
        'cmd_ChannelFolder
        '
        Me.cmd_ChannelFolder.Name = "cmd_ChannelFolder"
        Me.cmd_ChannelFolder.Size = New System.Drawing.Size(181, 22)
        Me.cmd_ChannelFolder.Text = "Add to Channel Folder"
        '
        'cmd_Notice
        '
        Me.cmd_Notice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Notice.Image = CType(resources.GetObject("cmd_Notice.Image"), System.Drawing.Image)
        Me.cmd_Notice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Notice.Name = "cmd_Notice"
        Me.cmd_Notice.Size = New System.Drawing.Size(41, 22)
        Me.cmd_Notice.Text = "Notice"
        '
        'cmd_Names
        '
        Me.cmd_Names.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Names.Image = CType(resources.GetObject("cmd_Names.Image"), System.Drawing.Image)
        Me.cmd_Names.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Names.Name = "cmd_Names"
        Me.cmd_Names.Size = New System.Drawing.Size(84, 22)
        Me.cmd_Names.Text = "Refresh Nicklist"
        '
        'cmd_Modes
        '
        Me.cmd_Modes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Modes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_ChannelOperator, Me.cmd_GiveVoice, Me.ToolStripSeparator1, Me.cmd_Moderated, Me.cmd_InviteOnly})
        Me.cmd_Modes.Image = CType(resources.GetObject("cmd_Modes.Image"), System.Drawing.Image)
        Me.cmd_Modes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Modes.Name = "cmd_Modes"
        Me.cmd_Modes.Size = New System.Drawing.Size(54, 22)
        Me.cmd_Modes.Text = "&Modes"
        '
        'cmd_ChannelOperator
        '
        Me.cmd_ChannelOperator.CheckOnClick = True
        Me.cmd_ChannelOperator.Name = "cmd_ChannelOperator"
        Me.cmd_ChannelOperator.Size = New System.Drawing.Size(160, 22)
        Me.cmd_ChannelOperator.Text = "Channel Operator"
        '
        'cmd_GiveVoice
        '
        Me.cmd_GiveVoice.CheckOnClick = True
        Me.cmd_GiveVoice.Name = "cmd_GiveVoice"
        Me.cmd_GiveVoice.Size = New System.Drawing.Size(160, 22)
        Me.cmd_GiveVoice.Text = "Voice"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'cmd_Moderated
        '
        Me.cmd_Moderated.CheckOnClick = True
        Me.cmd_Moderated.Name = "cmd_Moderated"
        Me.cmd_Moderated.Size = New System.Drawing.Size(160, 22)
        Me.cmd_Moderated.Text = "Moderated"
        '
        'cmd_InviteOnly
        '
        Me.cmd_InviteOnly.CheckOnClick = True
        Me.cmd_InviteOnly.Name = "cmd_InviteOnly"
        Me.cmd_InviteOnly.Size = New System.Drawing.Size(160, 22)
        Me.cmd_InviteOnly.Text = "Invite Only"
        '
        'cmd_Hide
        '
        Me.cmd_Hide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Hide.Image = CType(resources.GetObject("cmd_Hide.Image"), System.Drawing.Image)
        Me.cmd_Hide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Hide.Name = "cmd_Hide"
        Me.cmd_Hide.Size = New System.Drawing.Size(50, 22)
        Me.cmd_Hide.Text = "Minimize"
        '
        'cmd_Part
        '
        Me.cmd_Part.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Part.Image = CType(resources.GetObject("cmd_Part.Image"), System.Drawing.Image)
        Me.cmd_Part.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Part.Name = "cmd_Part"
        Me.cmd_Part.Size = New System.Drawing.Size(31, 22)
        Me.cmd_Part.Text = "Part"
        '
        'cmd_Close
        '
        Me.cmd_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_Close.Image = CType(resources.GetObject("cmd_Close.Image"), System.Drawing.Image)
        Me.cmd_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_Close.Name = "cmd_Close"
        Me.cmd_Close.Size = New System.Drawing.Size(37, 22)
        Me.cmd_Close.Text = "Close"
        '
        'cmd_URL
        '
        Me.cmd_URL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmd_URL.Image = CType(resources.GetObject("cmd_URL.Image"), System.Drawing.Image)
        Me.cmd_URL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_URL.Name = "cmd_URL"
        Me.cmd_URL.Size = New System.Drawing.Size(30, 22)
        Me.cmd_URL.Text = "URL"
        '
        'cmd_NickList
        '
        Me.cmd_NickList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_NickList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_NickListPopup})
        Me.cmd_NickList.Location = New System.Drawing.Point(0, 0)
        Me.cmd_NickList.Name = "cmd_NickList"
        Me.cmd_NickList.Size = New System.Drawing.Size(387, 24)
        Me.cmd_NickList.TabIndex = 5
        Me.cmd_NickList.Text = "MenuStrip1"
        Me.cmd_NickList.Visible = False
        '
        'cmd_NickListPopup
        '
        Me.cmd_NickListPopup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_NickQuery, Me.cmd_NickNotice})
        Me.cmd_NickListPopup.Name = "cmd_NickListPopup"
        Me.cmd_NickListPopup.Size = New System.Drawing.Size(70, 20)
        Me.cmd_NickListPopup.Text = "<NickList>"
        '
        'cmd_NickQuery
        '
        Me.cmd_NickQuery.Name = "cmd_NickQuery"
        Me.cmd_NickQuery.Size = New System.Drawing.Size(104, 22)
        Me.cmd_NickQuery.Text = "Query"
        '
        'cmd_NickNotice
        '
        Me.cmd_NickNotice.Name = "cmd_NickNotice"
        Me.cmd_NickNotice.Size = New System.Drawing.Size(104, 22)
        Me.cmd_NickNotice.Text = "Notice"
        '
        'tmrGetNames
        '
        Me.tmrGetNames.Interval = 1000
        '
        'lvwNicklist
        '
        Me.lvwNicklist.BackColor = System.Drawing.Color.MistyRose
        Me.lvwNicklist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwNicklist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwNicklist.Location = New System.Drawing.Point(334, 25)
        Me.lvwNicklist.Name = "lvwNicklist"
        Me.lvwNicklist.Size = New System.Drawing.Size(96, 109)
        Me.lvwNicklist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwNicklist.TabIndex = 6
        Me.lvwNicklist.UseCompatibleStateImageBehavior = False
        Me.lvwNicklist.View = System.Windows.Forms.View.Details
        '
        'frmChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(469, 156)
        Me.Controls.Add(Me.lvwNicklist)
        Me.Controls.Add(Me.tspChannel)
        Me.Controls.Add(Me.cmd_NickList)
        Me.Controls.Add(Me.txtIncomingColor)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.cmd_NickList
        Me.Name = "frmChannel"
        Me.Text = "frmChannel"
        Me.tspChannel.ResumeLayout(False)
        Me.tspChannel.PerformLayout()
        Me.cmd_NickList.ResumeLayout(False)
        Me.cmd_NickList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutgoing As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomingColor As System.Windows.Forms.RichTextBox
    Friend WithEvents tspChannel As System.Windows.Forms.ToolStrip
    Friend WithEvents cmd_Hide As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_Part As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_Notice As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_Add As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_AutoJoin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_ChannelFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_NickList As System.Windows.Forms.MenuStrip
    Friend WithEvents cmd_NickListPopup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_NickQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_NickNotice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_Names As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrGetNames As System.Windows.Forms.Timer
    Friend WithEvents lvwNicklist As System.Windows.Forms.ListView
    Friend WithEvents cmd_Modes As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_Moderated As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_InviteOnly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_ChannelOperator As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_GiveVoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_URL As System.Windows.Forms.ToolStripButton
End Class
