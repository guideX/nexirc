<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatus))
        Me.tspChannel = New System.Windows.Forms.ToolStrip()
        Me.cmdConnection = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmdConnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdDisconnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdChangeConnection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdChannels = New System.Windows.Forms.ToolStripSplitButton()
        Me.tspListChannels = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtOutgoing = New System.Windows.Forms.TextBox()
        Me.tmrWaitForChannelList = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckChannelList = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWaitForLUsers = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWaitForWhois = New System.Windows.Forms.Timer(Me.components)
        Me.txtIncomingColor = New System.Windows.Forms.RichTextBox()
        Me.tspChannel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspChannel
        '
        Me.tspChannel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tspChannel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspChannel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspChannel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdConnection, Me.cmdChannels})
        Me.tspChannel.Location = New System.Drawing.Point(0, 0)
        Me.tspChannel.Name = "tspChannel"
        Me.tspChannel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspChannel.ShowItemToolTips = False
        Me.tspChannel.Size = New System.Drawing.Size(260, 25)
        Me.tspChannel.TabIndex = 10
        '
        'cmdConnection
        '
        Me.cmdConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdConnection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdConnect, Me.cmdDisconnect, Me.ToolStripSeparator3, Me.cmdChangeConnection, Me.ToolStripSeparator1, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.cmdConnection.Image = CType(resources.GetObject("cmdConnection.Image"), System.Drawing.Image)
        Me.cmdConnection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdConnection.Name = "cmdConnection"
        Me.cmdConnection.Size = New System.Drawing.Size(32, 22)
        Me.cmdConnection.Text = "Connection"
        '
        'cmdConnect
        '
        Me.cmdConnect.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(195, 22)
        Me.cmdConnect.Text = "Connect"
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(195, 22)
        Me.cmdDisconnect.Text = "Disconnect"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(192, 6)
        '
        'cmdChangeConnection
        '
        Me.cmdChangeConnection.Image = CType(resources.GetObject("cmdChangeConnection.Image"), System.Drawing.Image)
        Me.cmdChangeConnection.Name = "cmdChangeConnection"
        Me.cmdChangeConnection.Size = New System.Drawing.Size(195, 22)
        Me.cmdChangeConnection.Text = "Change Connection"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem1.Text = "Change Nickname"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem2.Text = "Send PrivMsg"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.nexIRC.My.Resources.Resources.chat
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem3.Text = "Send Notice"
        '
        'cmdChannels
        '
        Me.cmdChannels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdChannels.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspListChannels})
        Me.cmdChannels.Image = Global.nexIRC.My.Resources.Resources.applications
        Me.cmdChannels.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdChannels.Name = "cmdChannels"
        Me.cmdChannels.Size = New System.Drawing.Size(32, 22)
        Me.cmdChannels.Text = "Channels"
        Me.cmdChannels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tspListChannels
        '
        Me.tspListChannels.Name = "tspListChannels"
        Me.tspListChannels.Size = New System.Drawing.Size(157, 22)
        Me.tspListChannels.Text = "List Channels"
        '
        'txtOutgoing
        '
        Me.txtOutgoing.BackColor = System.Drawing.Color.Navy
        Me.txtOutgoing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutgoing.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.ForeColor = System.Drawing.Color.White
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 114)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(249, 19)
        Me.txtOutgoing.TabIndex = 8
        '
        'tmrWaitForChannelList
        '
        Me.tmrWaitForChannelList.Interval = 10000
        '
        'tmrCheckChannelList
        '
        Me.tmrCheckChannelList.Interval = 2000
        '
        'tmrWaitForLUsers
        '
        Me.tmrWaitForLUsers.Interval = 2000
        '
        'tmrWaitForWhois
        '
        Me.tmrWaitForWhois.Interval = 2000
        '
        'txtIncomingColor
        '
        Me.txtIncomingColor.BackColor = System.Drawing.Color.Black
        Me.txtIncomingColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIncomingColor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIncomingColor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomingColor.ForeColor = System.Drawing.Color.White
        Me.txtIncomingColor.Location = New System.Drawing.Point(0, 25)
        Me.txtIncomingColor.Name = "txtIncomingColor"
        Me.txtIncomingColor.Size = New System.Drawing.Size(249, 83)
        Me.txtIncomingColor.TabIndex = 9
        Me.txtIncomingColor.Text = ""
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(260, 155)
        Me.Controls.Add(Me.tspChannel)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.txtIncomingColor)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Status"
        Me.tspChannel.ResumeLayout(False)
        Me.tspChannel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspChannel As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdConnection As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmdConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDisconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdChangeConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOutgoing As System.Windows.Forms.TextBox
    Friend WithEvents tmrWaitForChannelList As System.Windows.Forms.Timer
    Friend WithEvents tmrCheckChannelList As System.Windows.Forms.Timer
    Friend WithEvents tmrWaitForLUsers As System.Windows.Forms.Timer
    Friend WithEvents tmrWaitForWhois As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdChannels As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tspListChannels As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtIncomingColor As System.Windows.Forms.RichTextBox
End Class
