<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiMain))
        Me.nicSystray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrFlashDCCToolBar = New System.Windows.Forms.Timer(Me.components)
        Me.cmdLeftBar = New System.Windows.Forms.Button()
        Me.cboAllServers = New System.Windows.Forms.ToolStripComboBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.tspWindows = New System.Windows.Forms.ToolStrip()
        Me.tmrStartupSettings = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tspMain = New System.Windows.Forms.ToolStrip()
        Me.cmd_Connection = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_RecientServers = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_RecientServer1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_RecientServer2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_RecientServer3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep2387682 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_ClearHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_NewStatusWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep398269823 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_Commands = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_AwayMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Away = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Back = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_ServerLinks = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Whois = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Whowas = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Time = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Stats = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep39879803269 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_Connect = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Disconnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_CloseConnection = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_SelectAServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_ChangeConnection = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep3298079802 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_CloseStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep398792 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Customize = New System.Windows.Forms.ToolStripButton()
        Me.cmd_Media = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_PlayVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_DCC = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_DCCSend = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_DCCChat = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep908372 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_DownloadManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_Channels = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_ChannelFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_ListChannels = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_View = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_LeftBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_WindowBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Window = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_TileHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_TileVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Cascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_Sep3869626 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_ArrangeIcons = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmd_ShowAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlLeftNav = New System.Windows.Forms.Panel()
        Me.tvwConnections = New System.Windows.Forms.TreeView()
        Me.lblQueryPrompt = New System.Windows.Forms.ToolStripLabel()
        Me.tspQueryPrompt = New System.Windows.Forms.ToolStrip()
        Me.cmdAcceptQuery = New System.Windows.Forms.ToolStripButton()
        Me.cmdDeclineQuery = New System.Windows.Forms.ToolStripButton()
        Me.lblUser = New System.Windows.Forms.ToolStripLabel()
        Me.tspDCCToolBar = New System.Windows.Forms.ToolStrip()
        Me.cmdAccept = New System.Windows.Forms.ToolStripButton()
        Me.cmdDeny = New System.Windows.Forms.ToolStripButton()
        Me.fdgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tspRedirect = New System.Windows.Forms.ToolStrip()
        Me.lblRedirectMessage = New System.Windows.Forms.ToolStripLabel()
        Me.cmdRedirectAccept = New System.Windows.Forms.ToolStripButton()
        Me.cmdRedirectDeny = New System.Windows.Forms.ToolStripButton()
        Me.tmrWaitForQuit = New System.Windows.Forms.Timer(Me.components)
        Me.tmrHideRedirect = New System.Windows.Forms.Timer(Me.components)
        Me.tspMain.SuspendLayout()
        Me.pnlLeftNav.SuspendLayout()
        Me.tspQueryPrompt.SuspendLayout()
        Me.tspDCCToolBar.SuspendLayout()
        Me.tspRedirect.SuspendLayout()
        Me.SuspendLayout()
        '
        'nicSystray
        '
        Me.nicSystray.Text = "nexIRC"
        Me.nicSystray.Visible = True
        '
        'tmrFlashDCCToolBar
        '
        Me.tmrFlashDCCToolBar.Interval = 700
        '
        'cmdLeftBar
        '
        Me.cmdLeftBar.BackColor = System.Drawing.Color.White
        Me.cmdLeftBar.Location = New System.Drawing.Point(175, 204)
        Me.cmdLeftBar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeftBar.Name = "cmdLeftBar"
        Me.cmdLeftBar.Size = New System.Drawing.Size(15, 39)
        Me.cmdLeftBar.TabIndex = 11
        Me.cmdLeftBar.UseVisualStyleBackColor = False
        '
        'cboAllServers
        '
        Me.cboAllServers.Name = "cboAllServers"
        Me.cboAllServers.Size = New System.Drawing.Size(121, 23)
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.SystemColors.ControlText
        '
        'tspWindows
        '
        Me.tspWindows.BackColor = System.Drawing.Color.Black
        Me.tspWindows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tspWindows.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tspWindows.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspWindows.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspWindows.Location = New System.Drawing.Point(0, 331)
        Me.tspWindows.Name = "tspWindows"
        Me.tspWindows.Padding = New System.Windows.Forms.Padding(0)
        Me.tspWindows.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspWindows.ShowItemToolTips = False
        Me.tspWindows.Size = New System.Drawing.Size(819, 25)
        Me.tspWindows.TabIndex = 23
        Me.tspWindows.Text = "ToolStrip1"
        '
        'tmrStartupSettings
        '
        Me.tmrStartupSettings.Interval = 200
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "black_status.jpg")
        Me.ImageList1.Images.SetKeyName(1, "black_channel.jpg")
        Me.ImageList1.Images.SetKeyName(2, "black_server.jpg")
        Me.ImageList1.Images.SetKeyName(3, "black_notice.jpg")
        Me.ImageList1.Images.SetKeyName(4, "black_raw.jpg")
        Me.ImageList1.Images.SetKeyName(5, "black_rawblue.jpg")
        Me.ImageList1.Images.SetKeyName(6, "black_noticeblue.jpg")
        Me.ImageList1.Images.SetKeyName(7, "black_serverblue.jpg")
        Me.ImageList1.Images.SetKeyName(8, "black_statusblue.jpg")
        Me.ImageList1.Images.SetKeyName(9, "black_channelblue.jpg")
        '
        'tspMain
        '
        Me.tspMain.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tspMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tspMain.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_Connection, Me.cmd_Customize, Me.cmd_Media, Me.cmd_DCC, Me.ToolStripSeparator1, Me.cmd_Channels, Me.ToolStripSeparator2, Me.cmd_View, Me.cmd_Window})
        Me.tspMain.Location = New System.Drawing.Point(0, 0)
        Me.tspMain.Name = "tspMain"
        Me.tspMain.Padding = New System.Windows.Forms.Padding(0)
        Me.tspMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tspMain.Size = New System.Drawing.Size(819, 25)
        Me.tspMain.TabIndex = 22
        '
        'cmd_Connection
        '
        Me.cmd_Connection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_Connection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_RecientServers, Me.cmd_NewStatusWindow, Me.cmd_Sep398269823, Me.mnu_Commands, Me.cmd_Sep39879803269, Me.cmd_Connect, Me.cmd_Disconnect, Me.cmd_CloseConnection, Me.cmd_SelectAServer, Me.cmd_ChangeConnection, Me.cmd_Sep3298079802, Me.cmd_CloseStatus, Me.cmd_Sep398792, Me.cmd_Exit})
        Me.cmd_Connection.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.cmd_Connection.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Connection.Name = "cmd_Connection"
        Me.cmd_Connection.Size = New System.Drawing.Size(32, 22)
        Me.cmd_Connection.Text = "Network"
        '
        'cmd_RecientServers
        '
        Me.cmd_RecientServers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_RecientServer1, Me.cmd_RecientServer2, Me.cmd_RecientServer3, Me.cmd_Sep2387682, Me.cmd_ClearHistory})
        Me.cmd_RecientServers.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmd_RecientServers.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_RecientServers.Name = "cmd_RecientServers"
        Me.cmd_RecientServers.Size = New System.Drawing.Size(222, 22)
        Me.cmd_RecientServers.Text = "Recient Servers"
        '
        'cmd_RecientServer1
        '
        Me.cmd_RecientServer1.Name = "cmd_RecientServer1"
        Me.cmd_RecientServer1.Size = New System.Drawing.Size(155, 22)
        Me.cmd_RecientServer1.Text = "(Empty)"
        '
        'cmd_RecientServer2
        '
        Me.cmd_RecientServer2.Name = "cmd_RecientServer2"
        Me.cmd_RecientServer2.Size = New System.Drawing.Size(155, 22)
        Me.cmd_RecientServer2.Text = "(Empty)"
        '
        'cmd_RecientServer3
        '
        Me.cmd_RecientServer3.Name = "cmd_RecientServer3"
        Me.cmd_RecientServer3.Size = New System.Drawing.Size(155, 22)
        Me.cmd_RecientServer3.Text = "(Empty)"
        '
        'cmd_Sep2387682
        '
        Me.cmd_Sep2387682.Name = "cmd_Sep2387682"
        Me.cmd_Sep2387682.Size = New System.Drawing.Size(152, 6)
        '
        'cmd_ClearHistory
        '
        Me.cmd_ClearHistory.Name = "cmd_ClearHistory"
        Me.cmd_ClearHistory.Size = New System.Drawing.Size(155, 22)
        Me.cmd_ClearHistory.Text = "Clear History"
        '
        'cmd_NewStatusWindow
        '
        Me.cmd_NewStatusWindow.Image = Global.nexIRC.My.Resources.Resources.add1
        Me.cmd_NewStatusWindow.Name = "cmd_NewStatusWindow"
        Me.cmd_NewStatusWindow.Size = New System.Drawing.Size(222, 22)
        Me.cmd_NewStatusWindow.Text = "New Status Window"
        '
        'cmd_Sep398269823
        '
        Me.cmd_Sep398269823.Name = "cmd_Sep398269823"
        Me.cmd_Sep398269823.Size = New System.Drawing.Size(219, 6)
        '
        'mnu_Commands
        '
        Me.mnu_Commands.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_AwayMenu, Me.cmd_ServerLinks, Me.cmd_Whois, Me.cmd_Whowas, Me.cmd_Time, Me.cmd_Stats})
        Me.mnu_Commands.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.mnu_Commands.Name = "mnu_Commands"
        Me.mnu_Commands.Size = New System.Drawing.Size(222, 22)
        Me.mnu_Commands.Text = "Commands"
        '
        'cmd_AwayMenu
        '
        Me.cmd_AwayMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_Away, Me.cmd_Back})
        Me.cmd_AwayMenu.Name = "cmd_AwayMenu"
        Me.cmd_AwayMenu.Size = New System.Drawing.Size(150, 22)
        Me.cmd_AwayMenu.Text = "Away"
        '
        'cmd_Away
        '
        Me.cmd_Away.Name = "cmd_Away"
        Me.cmd_Away.Size = New System.Drawing.Size(110, 22)
        Me.cmd_Away.Text = "Away"
        '
        'cmd_Back
        '
        Me.cmd_Back.Name = "cmd_Back"
        Me.cmd_Back.Size = New System.Drawing.Size(110, 22)
        Me.cmd_Back.Text = "Back"
        '
        'cmd_ServerLinks
        '
        Me.cmd_ServerLinks.Name = "cmd_ServerLinks"
        Me.cmd_ServerLinks.Size = New System.Drawing.Size(150, 22)
        Me.cmd_ServerLinks.Text = "Server Links"
        '
        'cmd_Whois
        '
        Me.cmd_Whois.Name = "cmd_Whois"
        Me.cmd_Whois.Size = New System.Drawing.Size(150, 22)
        Me.cmd_Whois.Text = "Whois"
        '
        'cmd_Whowas
        '
        Me.cmd_Whowas.Name = "cmd_Whowas"
        Me.cmd_Whowas.Size = New System.Drawing.Size(150, 22)
        Me.cmd_Whowas.Text = "Whowas"
        '
        'cmd_Time
        '
        Me.cmd_Time.Name = "cmd_Time"
        Me.cmd_Time.Size = New System.Drawing.Size(150, 22)
        Me.cmd_Time.Text = "Time"
        '
        'cmd_Stats
        '
        Me.cmd_Stats.Name = "cmd_Stats"
        Me.cmd_Stats.Size = New System.Drawing.Size(150, 22)
        Me.cmd_Stats.Text = "Stats"
        '
        'cmd_Sep39879803269
        '
        Me.cmd_Sep39879803269.Name = "cmd_Sep39879803269"
        Me.cmd_Sep39879803269.Size = New System.Drawing.Size(219, 6)
        '
        'cmd_Connect
        '
        Me.cmd_Connect.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmd_Connect.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Connect.Name = "cmd_Connect"
        Me.cmd_Connect.Size = New System.Drawing.Size(222, 22)
        Me.cmd_Connect.Text = "Connect"
        '
        'cmd_Disconnect
        '
        Me.cmd_Disconnect.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmd_Disconnect.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Disconnect.Name = "cmd_Disconnect"
        Me.cmd_Disconnect.Size = New System.Drawing.Size(222, 22)
        Me.cmd_Disconnect.Text = "Disconnect"
        '
        'cmd_CloseConnection
        '
        Me.cmd_CloseConnection.Name = "cmd_CloseConnection"
        Me.cmd_CloseConnection.Size = New System.Drawing.Size(222, 22)
        Me.cmd_CloseConnection.Text = "Quit"
        '
        'cmd_SelectAServer
        '
        Me.cmd_SelectAServer.Name = "cmd_SelectAServer"
        Me.cmd_SelectAServer.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.cmd_SelectAServer.Size = New System.Drawing.Size(222, 22)
        Me.cmd_SelectAServer.Text = "Select a Server ..."
        '
        'cmd_ChangeConnection
        '
        Me.cmd_ChangeConnection.Name = "cmd_ChangeConnection"
        Me.cmd_ChangeConnection.Size = New System.Drawing.Size(222, 22)
        Me.cmd_ChangeConnection.Text = "Change Connection"
        '
        'cmd_Sep3298079802
        '
        Me.cmd_Sep3298079802.Name = "cmd_Sep3298079802"
        Me.cmd_Sep3298079802.Size = New System.Drawing.Size(219, 6)
        '
        'cmd_CloseStatus
        '
        Me.cmd_CloseStatus.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmd_CloseStatus.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_CloseStatus.Name = "cmd_CloseStatus"
        Me.cmd_CloseStatus.Size = New System.Drawing.Size(222, 22)
        Me.cmd_CloseStatus.Text = "Close Status"
        '
        'cmd_Sep398792
        '
        Me.cmd_Sep398792.Name = "cmd_Sep398792"
        Me.cmd_Sep398792.Size = New System.Drawing.Size(219, 6)
        '
        'cmd_Exit
        '
        Me.cmd_Exit.Image = Global.nexIRC.My.Resources.Resources.delete
        Me.cmd_Exit.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(222, 22)
        Me.cmd_Exit.Text = "Exit nexIRC"
        '
        'cmd_Customize
        '
        Me.cmd_Customize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_Customize.Image = Global.nexIRC.My.Resources.Resources.applications
        Me.cmd_Customize.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Customize.Name = "cmd_Customize"
        Me.cmd_Customize.Size = New System.Drawing.Size(23, 22)
        Me.cmd_Customize.Text = "Customize"
        '
        'cmd_Media
        '
        Me.cmd_Media.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_Media.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_PlayVideo})
        Me.cmd_Media.Image = Global.nexIRC.My.Resources.Resources.film
        Me.cmd_Media.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Media.Name = "cmd_Media"
        Me.cmd_Media.Size = New System.Drawing.Size(32, 22)
        Me.cmd_Media.Text = "Media"
        '
        'cmd_PlayVideo
        '
        Me.cmd_PlayVideo.Name = "cmd_PlayVideo"
        Me.cmd_PlayVideo.Size = New System.Drawing.Size(142, 22)
        Me.cmd_PlayVideo.Text = "Play Video"
        '
        'cmd_DCC
        '
        Me.cmd_DCC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_DCC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_DCCSend, Me.cmd_DCCChat, Me.cmd_Sep908372, Me.cmd_DownloadManager})
        Me.cmd_DCC.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.cmd_DCC.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_DCC.Name = "cmd_DCC"
        Me.cmd_DCC.Size = New System.Drawing.Size(32, 22)
        Me.cmd_DCC.Text = "DCC"
        '
        'cmd_DCCSend
        '
        Me.cmd_DCCSend.Name = "cmd_DCCSend"
        Me.cmd_DCCSend.Size = New System.Drawing.Size(196, 22)
        Me.cmd_DCCSend.Text = "DCC Send"
        '
        'cmd_DCCChat
        '
        Me.cmd_DCCChat.Name = "cmd_DCCChat"
        Me.cmd_DCCChat.Size = New System.Drawing.Size(196, 22)
        Me.cmd_DCCChat.Text = "DCC Chat"
        '
        'cmd_Sep908372
        '
        Me.cmd_Sep908372.Name = "cmd_Sep908372"
        Me.cmd_Sep908372.Size = New System.Drawing.Size(193, 6)
        '
        'cmd_DownloadManager
        '
        Me.cmd_DownloadManager.Name = "cmd_DownloadManager"
        Me.cmd_DownloadManager.Size = New System.Drawing.Size(196, 22)
        Me.cmd_DownloadManager.Text = "Download Manager"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmd_Channels
        '
        Me.cmd_Channels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_Channels.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_ChannelFolder, Me.cmd_ListChannels})
        Me.cmd_Channels.Image = Global.nexIRC.My.Resources.Resources.web
        Me.cmd_Channels.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Channels.Name = "cmd_Channels"
        Me.cmd_Channels.Size = New System.Drawing.Size(32, 22)
        Me.cmd_Channels.Text = "Channels"
        '
        'cmd_ChannelFolder
        '
        Me.cmd_ChannelFolder.Name = "cmd_ChannelFolder"
        Me.cmd_ChannelFolder.Size = New System.Drawing.Size(170, 22)
        Me.cmd_ChannelFolder.Text = "Channel Folder"
        '
        'cmd_ListChannels
        '
        Me.cmd_ListChannels.Name = "cmd_ListChannels"
        Me.cmd_ListChannels.Size = New System.Drawing.Size(170, 22)
        Me.cmd_ListChannels.Text = "List Channels"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmd_View
        '
        Me.cmd_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_View.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_LeftBar, Me.cmd_WindowBar})
        Me.cmd_View.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.cmd_View.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(32, 22)
        Me.cmd_View.Text = "Tools"
        '
        'cmd_LeftBar
        '
        Me.cmd_LeftBar.Checked = True
        Me.cmd_LeftBar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmd_LeftBar.Name = "cmd_LeftBar"
        Me.cmd_LeftBar.Size = New System.Drawing.Size(152, 22)
        Me.cmd_LeftBar.Text = "Left Bar"
        '
        'cmd_WindowBar
        '
        Me.cmd_WindowBar.Checked = True
        Me.cmd_WindowBar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmd_WindowBar.Name = "cmd_WindowBar"
        Me.cmd_WindowBar.Size = New System.Drawing.Size(152, 22)
        Me.cmd_WindowBar.Text = "Window Bar"
        '
        'cmd_Window
        '
        Me.cmd_Window.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_Window.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_TileHorizontal, Me.cmd_TileVertical, Me.cmd_Cascade, Me.cmd_Sep3869626, Me.cmd_ArrangeIcons, Me.ToolStripSeparator4, Me.cmd_ShowAbout})
        Me.cmd_Window.Image = CType(resources.GetObject("cmd_Window.Image"), System.Drawing.Image)
        Me.cmd_Window.ImageTransparentColor = System.Drawing.Color.White
        Me.cmd_Window.Name = "cmd_Window"
        Me.cmd_Window.Size = New System.Drawing.Size(32, 22)
        Me.cmd_Window.Text = "Window"
        '
        'cmd_TileHorizontal
        '
        Me.cmd_TileHorizontal.Name = "cmd_TileHorizontal"
        Me.cmd_TileHorizontal.Size = New System.Drawing.Size(166, 22)
        Me.cmd_TileHorizontal.Text = "Tile Horizontal"
        '
        'cmd_TileVertical
        '
        Me.cmd_TileVertical.Name = "cmd_TileVertical"
        Me.cmd_TileVertical.Size = New System.Drawing.Size(166, 22)
        Me.cmd_TileVertical.Text = "Tile Vertical"
        '
        'cmd_Cascade
        '
        Me.cmd_Cascade.Name = "cmd_Cascade"
        Me.cmd_Cascade.Size = New System.Drawing.Size(166, 22)
        Me.cmd_Cascade.Text = "Cascade"
        '
        'cmd_Sep3869626
        '
        Me.cmd_Sep3869626.Name = "cmd_Sep3869626"
        Me.cmd_Sep3869626.Size = New System.Drawing.Size(163, 6)
        '
        'cmd_ArrangeIcons
        '
        Me.cmd_ArrangeIcons.Name = "cmd_ArrangeIcons"
        Me.cmd_ArrangeIcons.Size = New System.Drawing.Size(166, 22)
        Me.cmd_ArrangeIcons.Text = "Arrange Icons"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(163, 6)
        '
        'cmd_ShowAbout
        '
        Me.cmd_ShowAbout.Name = "cmd_ShowAbout"
        Me.cmd_ShowAbout.Size = New System.Drawing.Size(166, 22)
        Me.cmd_ShowAbout.Text = "Show About"
        '
        'pnlLeftNav
        '
        Me.pnlLeftNav.BackColor = System.Drawing.Color.Black
        Me.pnlLeftNav.Controls.Add(Me.tvwConnections)
        Me.pnlLeftNav.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlLeftNav.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftNav.Location = New System.Drawing.Point(0, 25)
        Me.pnlLeftNav.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeftNav.Name = "pnlLeftNav"
        Me.pnlLeftNav.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlLeftNav.Size = New System.Drawing.Size(167, 306)
        Me.pnlLeftNav.TabIndex = 25
        '
        'tvwConnections
        '
        Me.tvwConnections.BackColor = System.Drawing.Color.Black
        Me.tvwConnections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvwConnections.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwConnections.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwConnections.ForeColor = System.Drawing.Color.White
        Me.tvwConnections.FullRowSelect = True
        Me.tvwConnections.ImageIndex = 0
        Me.tvwConnections.ImageList = Me.ImageList1
        Me.tvwConnections.Indent = 15
        Me.tvwConnections.ItemHeight = 18
        Me.tvwConnections.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tvwConnections.Location = New System.Drawing.Point(1, 1)
        Me.tvwConnections.Margin = New System.Windows.Forms.Padding(0)
        Me.tvwConnections.Name = "tvwConnections"
        Me.tvwConnections.SelectedImageIndex = 0
        Me.tvwConnections.Size = New System.Drawing.Size(165, 304)
        Me.tvwConnections.TabIndex = 13
        '
        'lblQueryPrompt
        '
        Me.lblQueryPrompt.ForeColor = System.Drawing.Color.Black
        Me.lblQueryPrompt.Name = "lblQueryPrompt"
        Me.lblQueryPrompt.Size = New System.Drawing.Size(155, 22)
        Me.lblQueryPrompt.Text = "Accept Query from (user)?"
        '
        'tspQueryPrompt
        '
        Me.tspQueryPrompt.BackColor = System.Drawing.Color.Yellow
        Me.tspQueryPrompt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tspQueryPrompt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspQueryPrompt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspQueryPrompt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblQueryPrompt, Me.cmdAcceptQuery, Me.cmdDeclineQuery})
        Me.tspQueryPrompt.Location = New System.Drawing.Point(167, 25)
        Me.tspQueryPrompt.Name = "tspQueryPrompt"
        Me.tspQueryPrompt.Padding = New System.Windows.Forms.Padding(0)
        Me.tspQueryPrompt.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tspQueryPrompt.ShowItemToolTips = False
        Me.tspQueryPrompt.Size = New System.Drawing.Size(652, 25)
        Me.tspQueryPrompt.TabIndex = 27
        Me.tspQueryPrompt.Visible = False
        '
        'cmdAcceptQuery
        '
        Me.cmdAcceptQuery.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdAcceptQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdAcceptQuery.ForeColor = System.Drawing.Color.Blue
        Me.cmdAcceptQuery.Image = CType(resources.GetObject("cmdAcceptQuery.Image"), System.Drawing.Image)
        Me.cmdAcceptQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAcceptQuery.Name = "cmdAcceptQuery"
        Me.cmdAcceptQuery.Size = New System.Drawing.Size(50, 22)
        Me.cmdAcceptQuery.Text = "Accept"
        '
        'cmdDeclineQuery
        '
        Me.cmdDeclineQuery.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdDeclineQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdDeclineQuery.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeclineQuery.Image = CType(resources.GetObject("cmdDeclineQuery.Image"), System.Drawing.Image)
        Me.cmdDeclineQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDeclineQuery.Name = "cmdDeclineQuery"
        Me.cmdDeclineQuery.Size = New System.Drawing.Size(39, 22)
        Me.cmdDeclineQuery.Text = "Deny"
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.Yellow
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(254, 22)
        Me.lblUser.Text = "Download the file (file) from the user (user)?"
        '
        'tspDCCToolBar
        '
        Me.tspDCCToolBar.BackColor = System.Drawing.Color.Yellow
        Me.tspDCCToolBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tspDCCToolBar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspDCCToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspDCCToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUser, Me.cmdAccept, Me.cmdDeny})
        Me.tspDCCToolBar.Location = New System.Drawing.Point(167, 25)
        Me.tspDCCToolBar.Name = "tspDCCToolBar"
        Me.tspDCCToolBar.Padding = New System.Windows.Forms.Padding(0)
        Me.tspDCCToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tspDCCToolBar.ShowItemToolTips = False
        Me.tspDCCToolBar.Size = New System.Drawing.Size(652, 25)
        Me.tspDCCToolBar.TabIndex = 29
        Me.tspDCCToolBar.Visible = False
        '
        'cmdAccept
        '
        Me.cmdAccept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdAccept.ForeColor = System.Drawing.Color.Blue
        Me.cmdAccept.Image = CType(resources.GetObject("cmdAccept.Image"), System.Drawing.Image)
        Me.cmdAccept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(50, 22)
        Me.cmdAccept.Text = "Accept"
        '
        'cmdDeny
        '
        Me.cmdDeny.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdDeny.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdDeny.ForeColor = System.Drawing.Color.Blue
        Me.cmdDeny.Image = CType(resources.GetObject("cmdDeny.Image"), System.Drawing.Image)
        Me.cmdDeny.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDeny.Name = "cmdDeny"
        Me.cmdDeny.Size = New System.Drawing.Size(39, 22)
        Me.cmdDeny.Text = "Deny"
        '
        'fdgOpen
        '
        Me.fdgOpen.Title = "nexIRC - Open"
        '
        'tspRedirect
        '
        Me.tspRedirect.BackColor = System.Drawing.Color.Yellow
        Me.tspRedirect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tspRedirect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tspRedirect.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspRedirect.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblRedirectMessage, Me.cmdRedirectAccept, Me.cmdRedirectDeny})
        Me.tspRedirect.Location = New System.Drawing.Point(167, 25)
        Me.tspRedirect.Name = "tspRedirect"
        Me.tspRedirect.Padding = New System.Windows.Forms.Padding(0)
        Me.tspRedirect.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tspRedirect.ShowItemToolTips = False
        Me.tspRedirect.Size = New System.Drawing.Size(652, 25)
        Me.tspRedirect.TabIndex = 31
        Me.tspRedirect.Visible = False
        '
        'lblRedirectMessage
        '
        Me.lblRedirectMessage.ForeColor = System.Drawing.Color.Black
        Me.lblRedirectMessage.Name = "lblRedirectMessage"
        Me.lblRedirectMessage.Size = New System.Drawing.Size(362, 22)
        Me.lblRedirectMessage.Text = "Notice: You've been redirected from (Channel A) to (Channel B)"
        '
        'cmdRedirectAccept
        '
        Me.cmdRedirectAccept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdRedirectAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdRedirectAccept.ForeColor = System.Drawing.Color.Blue
        Me.cmdRedirectAccept.Image = CType(resources.GetObject("cmdRedirectAccept.Image"), System.Drawing.Image)
        Me.cmdRedirectAccept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRedirectAccept.Name = "cmdRedirectAccept"
        Me.cmdRedirectAccept.Size = New System.Drawing.Size(27, 22)
        Me.cmdRedirectAccept.Text = "OK"
        '
        'cmdRedirectDeny
        '
        Me.cmdRedirectDeny.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdRedirectDeny.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdRedirectDeny.ForeColor = System.Drawing.Color.Blue
        Me.cmdRedirectDeny.Image = CType(resources.GetObject("cmdRedirectDeny.Image"), System.Drawing.Image)
        Me.cmdRedirectDeny.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRedirectDeny.Name = "cmdRedirectDeny"
        Me.cmdRedirectDeny.Size = New System.Drawing.Size(39, 22)
        Me.cmdRedirectDeny.Text = "Deny"
        Me.cmdRedirectDeny.Visible = False
        '
        'tmrWaitForQuit
        '
        Me.tmrWaitForQuit.Interval = 1500
        '
        'tmrHideRedirect
        '
        Me.tmrHideRedirect.Interval = 6000
        '
        'mdiMain
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(819, 356)
        Me.Controls.Add(Me.tspQueryPrompt)
        Me.Controls.Add(Me.tspDCCToolBar)
        Me.Controls.Add(Me.tspRedirect)
        Me.Controls.Add(Me.pnlLeftNav)
        Me.Controls.Add(Me.tspMain)
        Me.Controls.Add(Me.tspWindows)
        Me.Controls.Add(Me.cmdLeftBar)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "mdiMain"
        Me.Text = "nexIRC"
        Me.tspMain.ResumeLayout(False)
        Me.tspMain.PerformLayout()
        Me.pnlLeftNav.ResumeLayout(False)
        Me.tspQueryPrompt.ResumeLayout(False)
        Me.tspQueryPrompt.PerformLayout()
        Me.tspDCCToolBar.ResumeLayout(False)
        Me.tspDCCToolBar.PerformLayout()
        Me.tspRedirect.ResumeLayout(False)
        Me.tspRedirect.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nicSystray As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrFlashDCCToolBar As System.Windows.Forms.Timer
    Friend WithEvents cmdLeftBar As System.Windows.Forms.Button
    Friend WithEvents cboAllServers As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents tspWindows As System.Windows.Forms.ToolStrip
    Friend WithEvents tmrStartupSettings As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tspMain As System.Windows.Forms.ToolStrip
    Friend WithEvents cmd_Connection As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_RecientServers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_RecientServer1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_RecientServer2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_RecientServer3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep2387682 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_ClearHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_NewStatusWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep398269823 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_Commands As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_AwayMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Away As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Back As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_ServerLinks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Whois As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Whowas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Time As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Stats As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep39879803269 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_Connect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Disconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_CloseConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_SelectAServer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_ChangeConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep3298079802 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_CloseStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep398792 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Customize As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_Media As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_PlayVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_DCC As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_DCCSend As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_DCCChat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep908372 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_DownloadManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_Channels As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_ChannelFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_ListChannels As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_View As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_LeftBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_WindowBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Window As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmd_TileHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_TileVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Cascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_Sep3869626 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_ArrangeIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlLeftNav As System.Windows.Forms.Panel
    Friend WithEvents tvwConnections As System.Windows.Forms.TreeView
    Friend WithEvents lblQueryPrompt As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdAcceptQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDeclineQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspQueryPrompt As System.Windows.Forms.ToolStrip
    Friend WithEvents lblUser As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdAccept As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDeny As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspDCCToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents fdgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmd_ShowAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tspRedirect As System.Windows.Forms.ToolStrip
    Friend WithEvents lblRedirectMessage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdRedirectAccept As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRedirectDeny As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrWaitForQuit As System.Windows.Forms.Timer
    Friend WithEvents tmrHideRedirect As System.Windows.Forms.Timer
    'Friend WithEvents cmdConnection As System.Windows.Forms.ToolStripSplitButton
    'Friend WithEvents mnuNewStatusWindow As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuSep76829639 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents mnuConnect As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuDisconnect As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuSep63574325 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents cmdDownloadManager As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuServerLinks As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuSep36587263875 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents mnuUnloadActive As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents cmdChannels As System.Windows.Forms.ToolStripSplitButton
    'Friend WithEvents mnuJoinChannel As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents mnuChannelList As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuChannelFolder As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents cmdCustomize As System.Windows.Forms.ToolStripButton
    'Friend WithEvents cmdDCC As System.Windows.Forms.ToolStripSplitButton
    'Friend WithEvents mnuSendFile As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuDCCChat As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents cmdWindow As System.Windows.Forms.ToolStripSplitButton
    'Friend WithEvents mnuCascade As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuTileHorizontally As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuTileVertically As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuArrangeIcons As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuConnection As System.Windows.Forms.ContextMenuStrip
    'Friend WithEvents mnuConnectionsConnect As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuConnectionsDisconnect As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuStatus As System.Windows.Forms.ContextMenuStrip
    'Friend WithEvents mnuStatusExit As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuStatusListChannels As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuNetworkSettings As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuRecientServers As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuRecientServerList1 As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuRecientServerList2 As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuRecientServerList3 As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents mnuSep3982698372 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents mnuSep234987639 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents mnuClearHistory As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
End Class
