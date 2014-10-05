<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParent
    Inherits Telerik.WinControls.UI.RadForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParent))
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.CommandBarDropDownButton1 = New Telerik.WinControls.UI.CommandBarDropDownButton()
        Me.mnuRecentServers = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuRecentServerItem1 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuRecentServerItem2 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuRecentServerItem3 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuRecentServerSep = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.mnuClearHistory = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuNewStatusWindow = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuConnectionsSep1 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.mnuCommands = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuAdmin = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuAwayBackMenu = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuAway = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuBack = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuError = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuHelp = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperator = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorConnect = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorDie = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorEncap = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorCPrivMsg2 = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorCNotice = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorOper = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorRehash = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorRestart = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuIRCOperatorServer = New Telerik.WinControls.UI.RadMenuItem()
        Me.SQuit = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuInfo = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuInvite = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuKick = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuKill = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuKnock = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuLinks = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuLUsers = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuMode = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuMotd = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuNames = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuNotice = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuPrivmsg = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuRules = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuServerLinks = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuTime = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuService = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuStats = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuServList = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSQuery = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSetName = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSilence = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuSummon = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuUhnames = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuUserhost = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuUserip = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuVersion = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuWallops = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuWatch = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuWho = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuWhois = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuWhowas = New Telerik.WinControls.UI.RadMenuItem()
        Me.CommandBarDropDownButton2 = New Telerik.WinControls.UI.CommandBarDropDownButton()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.AutoSize = True
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.RadCommandBar1.Size = New System.Drawing.Size(759, 30)
        Me.RadCommandBar1.TabIndex = 1
        Me.RadCommandBar1.Text = "RadCommandBar1"
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.DisplayName = Nothing
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.FloatingForm = Nothing
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.CommandBarDropDownButton1, Me.CommandBarDropDownButton2})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'CommandBarDropDownButton1
        '
        Me.CommandBarDropDownButton1.AccessibleDescription = "Connection"
        Me.CommandBarDropDownButton1.AccessibleName = "Connection"
        Me.CommandBarDropDownButton1.AutoSize = False
        Me.CommandBarDropDownButton1.BorderDrawMode = Telerik.WinControls.BorderDrawModes.HorizontalOverVertical
        Me.CommandBarDropDownButton1.BorderLeftShadowColor = System.Drawing.Color.Empty
        Me.CommandBarDropDownButton1.Bounds = New System.Drawing.Rectangle(0, 0, 102, 26)
        Me.CommandBarDropDownButton1.DisplayName = "Connection"
        Me.CommandBarDropDownButton1.DrawText = True
        Me.CommandBarDropDownButton1.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.CommandBarDropDownButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.CommandBarDropDownButton1.ImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CommandBarDropDownButton1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuRecentServers, Me.mnuNewStatusWindow, Me.mnuConnectionsSep1, Me.mnuCommands})
        Me.CommandBarDropDownButton1.Name = "CommandBarDropDownButton1"
        Me.CommandBarDropDownButton1.Padding = New System.Windows.Forms.Padding(0)
        Me.CommandBarDropDownButton1.Text = "Connection"
        Me.CommandBarDropDownButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.CommandBarDropDownButton1.TextWrap = True
        Me.CommandBarDropDownButton1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarDropDownButton1.VisibleInOverflowMenu = True
        '
        'mnuRecentServers
        '
        Me.mnuRecentServers.AccessibleDescription = "RadMenuItem1"
        Me.mnuRecentServers.AccessibleName = "RadMenuItem1"
        Me.mnuRecentServers.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.mnuRecentServers.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuRecentServerItem1, Me.mnuRecentServerItem2, Me.mnuRecentServerItem3, Me.mnuRecentServerSep, Me.mnuClearHistory})
        Me.mnuRecentServers.Name = "mnuRecentServers"
        Me.mnuRecentServers.Text = "Recent Servers"
        Me.mnuRecentServers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuRecentServerItem1
        '
        Me.mnuRecentServerItem1.AccessibleDescription = "(Empty)"
        Me.mnuRecentServerItem1.AccessibleName = "(Empty)"
        Me.mnuRecentServerItem1.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.mnuRecentServerItem1.Name = "mnuRecentServerItem1"
        Me.mnuRecentServerItem1.Text = "(Empty)"
        Me.mnuRecentServerItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuRecentServerItem2
        '
        Me.mnuRecentServerItem2.AccessibleDescription = "(Empty)"
        Me.mnuRecentServerItem2.AccessibleName = "(Empty)"
        Me.mnuRecentServerItem2.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.mnuRecentServerItem2.Name = "mnuRecentServerItem2"
        Me.mnuRecentServerItem2.Text = "(Empty)"
        Me.mnuRecentServerItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuRecentServerItem3
        '
        Me.mnuRecentServerItem3.AccessibleDescription = "(Empty)"
        Me.mnuRecentServerItem3.AccessibleName = "(Empty)"
        Me.mnuRecentServerItem3.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.mnuRecentServerItem3.Name = "mnuRecentServerItem3"
        Me.mnuRecentServerItem3.Text = "(Empty)"
        Me.mnuRecentServerItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuRecentServerSep
        '
        Me.mnuRecentServerSep.AccessibleDescription = "RadMenuSeparatorItem1"
        Me.mnuRecentServerSep.AccessibleName = "RadMenuSeparatorItem1"
        Me.mnuRecentServerSep.Name = "mnuRecentServerSep"
        Me.mnuRecentServerSep.Text = "RadMenuSeparatorItem1"
        Me.mnuRecentServerSep.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuClearHistory
        '
        Me.mnuClearHistory.AccessibleDescription = "Clear History"
        Me.mnuClearHistory.AccessibleName = "Clear History"
        Me.mnuClearHistory.Name = "mnuClearHistory"
        Me.mnuClearHistory.Text = "Clear History"
        Me.mnuClearHistory.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuNewStatusWindow
        '
        Me.mnuNewStatusWindow.AccessibleDescription = "New Status Window"
        Me.mnuNewStatusWindow.AccessibleName = "New Status Window"
        Me.mnuNewStatusWindow.Image = Global.nexIRC.My.Resources.Resources.add1
        Me.mnuNewStatusWindow.Name = "mnuNewStatusWindow"
        Me.mnuNewStatusWindow.Text = "New Status Window"
        Me.mnuNewStatusWindow.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuConnectionsSep1
        '
        Me.mnuConnectionsSep1.AccessibleDescription = "RadMenuSeparatorItem1"
        Me.mnuConnectionsSep1.AccessibleName = "RadMenuSeparatorItem1"
        Me.mnuConnectionsSep1.Name = "mnuConnectionsSep1"
        Me.mnuConnectionsSep1.Text = "RadMenuSeparatorItem1"
        Me.mnuConnectionsSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuCommands
        '
        Me.mnuCommands.AccessibleDescription = "Commands"
        Me.mnuCommands.AccessibleName = "Commands"
        Me.mnuCommands.Class = ""
        Me.mnuCommands.Image = Global.nexIRC.My.Resources.Resources.applications
        Me.mnuCommands.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuAdmin, Me.mnuAwayBackMenu, Me.mnuError, Me.mnuHelp, Me.mnuIRCOperator, Me.mnuInfo, Me.mnuInvite, Me.mnuKick, Me.mnuKill, Me.mnuKnock, Me.mnuLinks, Me.mnuLUsers, Me.mnuMode, Me.mnuMotd, Me.mnuNames, Me.mnuNotice, Me.mnuPrivmsg, Me.mnuRules, Me.mnuServerLinks, Me.mnuTime, Me.mnuService, Me.mnuStats, Me.mnuServList, Me.mnuSQuery, Me.mnuSetName, Me.mnuSilence, Me.mnuSummon, Me.mnuUhnames, Me.mnuUserhost, Me.mnuUserip, Me.mnuVersion, Me.mnuWallops, Me.mnuWatch, Me.mnuWho, Me.mnuWhois, Me.mnuWhowas})
        Me.mnuCommands.Name = "mnuCommands"
        Me.mnuCommands.Text = "Commands"
        Me.mnuCommands.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuAdmin
        '
        Me.mnuAdmin.AccessibleDescription = "Admin"
        Me.mnuAdmin.AccessibleName = "Admin"
        Me.mnuAdmin.Name = "mnuAdmin"
        Me.mnuAdmin.Text = "Admin"
        Me.mnuAdmin.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuAwayBackMenu
        '
        Me.mnuAwayBackMenu.AccessibleDescription = "Away/Back"
        Me.mnuAwayBackMenu.AccessibleName = "Away/Back"
        Me.mnuAwayBackMenu.Image = Nothing
        Me.mnuAwayBackMenu.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuAway, Me.mnuBack})
        Me.mnuAwayBackMenu.Name = "mnuAwayBackMenu"
        Me.mnuAwayBackMenu.Text = "Away/Back"
        Me.mnuAwayBackMenu.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuAway
        '
        Me.mnuAway.AccessibleDescription = "Away"
        Me.mnuAway.AccessibleName = "Away"
        Me.mnuAway.Name = "mnuAway"
        Me.mnuAway.Text = "Away"
        Me.mnuAway.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuBack
        '
        Me.mnuBack.AccessibleDescription = "Back"
        Me.mnuBack.AccessibleName = "Back"
        Me.mnuBack.Name = "mnuBack"
        Me.mnuBack.Text = "Back"
        Me.mnuBack.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuError
        '
        Me.mnuError.AccessibleDescription = "Error"
        Me.mnuError.AccessibleName = "Error"
        Me.mnuError.Name = "mnuError"
        Me.mnuError.Text = "Error"
        Me.mnuError.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuHelp
        '
        Me.mnuHelp.AccessibleDescription = "Help"
        Me.mnuHelp.AccessibleName = "Help"
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Text = "Help"
        Me.mnuHelp.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperator
        '
        Me.mnuIRCOperator.AccessibleDescription = "IRC Operator"
        Me.mnuIRCOperator.AccessibleName = "IRC Operator"
        Me.mnuIRCOperator.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuIRCOperatorConnect, Me.mnuIRCOperatorDie, Me.mnuIRCOperatorEncap, Me.mnuIRCOperatorCPrivMsg2, Me.mnuIRCOperatorCNotice, Me.mnuIRCOperatorOper, Me.mnuIRCOperatorRehash, Me.mnuIRCOperatorRestart, Me.mnuIRCOperatorServer, Me.SQuit})
        Me.mnuIRCOperator.Name = "mnuIRCOperator"
        Me.mnuIRCOperator.Text = "IRC Operator"
        Me.mnuIRCOperator.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorConnect
        '
        Me.mnuIRCOperatorConnect.AccessibleDescription = "Connect"
        Me.mnuIRCOperatorConnect.AccessibleName = "Connect"
        Me.mnuIRCOperatorConnect.Name = "mnuIRCOperatorConnect"
        Me.mnuIRCOperatorConnect.Text = "Connect"
        Me.mnuIRCOperatorConnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorDie
        '
        Me.mnuIRCOperatorDie.AccessibleDescription = "Die"
        Me.mnuIRCOperatorDie.AccessibleName = "Die"
        Me.mnuIRCOperatorDie.Name = "mnuIRCOperatorDie"
        Me.mnuIRCOperatorDie.Text = "Die"
        Me.mnuIRCOperatorDie.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorEncap
        '
        Me.mnuIRCOperatorEncap.AccessibleDescription = "Encap"
        Me.mnuIRCOperatorEncap.AccessibleName = "Encap"
        Me.mnuIRCOperatorEncap.Name = "mnuIRCOperatorEncap"
        Me.mnuIRCOperatorEncap.Text = "Encap"
        Me.mnuIRCOperatorEncap.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorCPrivMsg2
        '
        Me.mnuIRCOperatorCPrivMsg2.AccessibleDescription = "CPrivMsg"
        Me.mnuIRCOperatorCPrivMsg2.AccessibleName = "CPrivMsg"
        Me.mnuIRCOperatorCPrivMsg2.Name = "mnuIRCOperatorCPrivMsg2"
        Me.mnuIRCOperatorCPrivMsg2.Text = "CPrivMsg"
        Me.mnuIRCOperatorCPrivMsg2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorCNotice
        '
        Me.mnuIRCOperatorCNotice.AccessibleDescription = "CNotice"
        Me.mnuIRCOperatorCNotice.AccessibleName = "CNotice"
        Me.mnuIRCOperatorCNotice.Name = "mnuIRCOperatorCNotice"
        Me.mnuIRCOperatorCNotice.Text = "CNotice"
        Me.mnuIRCOperatorCNotice.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorOper
        '
        Me.mnuIRCOperatorOper.AccessibleDescription = "Oper"
        Me.mnuIRCOperatorOper.AccessibleName = "Oper"
        Me.mnuIRCOperatorOper.Name = "mnuIRCOperatorOper"
        Me.mnuIRCOperatorOper.Text = "Oper"
        Me.mnuIRCOperatorOper.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorRehash
        '
        Me.mnuIRCOperatorRehash.AccessibleDescription = "Rehash"
        Me.mnuIRCOperatorRehash.AccessibleName = "Rehash"
        Me.mnuIRCOperatorRehash.Name = "mnuIRCOperatorRehash"
        Me.mnuIRCOperatorRehash.Text = "Rehash"
        Me.mnuIRCOperatorRehash.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorRestart
        '
        Me.mnuIRCOperatorRestart.AccessibleDescription = "Restart"
        Me.mnuIRCOperatorRestart.AccessibleName = "Restart"
        Me.mnuIRCOperatorRestart.Name = "mnuIRCOperatorRestart"
        Me.mnuIRCOperatorRestart.Text = "Restart"
        Me.mnuIRCOperatorRestart.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuIRCOperatorServer
        '
        Me.mnuIRCOperatorServer.AccessibleDescription = "Server"
        Me.mnuIRCOperatorServer.AccessibleName = "Server"
        Me.mnuIRCOperatorServer.Name = "mnuIRCOperatorServer"
        Me.mnuIRCOperatorServer.Text = "Server"
        Me.mnuIRCOperatorServer.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'SQuit
        '
        Me.SQuit.AccessibleDescription = "SQuit"
        Me.SQuit.AccessibleName = "SQuit"
        Me.SQuit.Name = "SQuit"
        Me.SQuit.Text = "SQuit"
        Me.SQuit.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuInfo
        '
        Me.mnuInfo.AccessibleDescription = "Info"
        Me.mnuInfo.AccessibleName = "Info"
        Me.mnuInfo.Name = "mnuInfo"
        Me.mnuInfo.Text = "Info"
        Me.mnuInfo.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuInvite
        '
        Me.mnuInvite.AccessibleDescription = "Invite"
        Me.mnuInvite.AccessibleName = "Invite"
        Me.mnuInvite.Name = "mnuInvite"
        Me.mnuInvite.Text = "Invite"
        Me.mnuInvite.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuKick
        '
        Me.mnuKick.AccessibleDescription = "Kick"
        Me.mnuKick.AccessibleName = "Kick"
        Me.mnuKick.Name = "mnuKick"
        Me.mnuKick.Text = "Kick"
        Me.mnuKick.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuKill
        '
        Me.mnuKill.AccessibleDescription = "Kill"
        Me.mnuKill.AccessibleName = "Kill"
        Me.mnuKill.Name = "mnuKill"
        Me.mnuKill.Text = "Kill"
        Me.mnuKill.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuKnock
        '
        Me.mnuKnock.AccessibleDescription = "Knock"
        Me.mnuKnock.AccessibleName = "Knock"
        Me.mnuKnock.Name = "mnuKnock"
        Me.mnuKnock.Text = "Knock"
        Me.mnuKnock.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuLinks
        '
        Me.mnuLinks.AccessibleDescription = "Links"
        Me.mnuLinks.AccessibleName = "Links"
        Me.mnuLinks.Name = "mnuLinks"
        Me.mnuLinks.Text = "Links"
        Me.mnuLinks.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuLUsers
        '
        Me.mnuLUsers.AccessibleDescription = "LUsers"
        Me.mnuLUsers.AccessibleName = "LUsers"
        Me.mnuLUsers.Name = "mnuLUsers"
        Me.mnuLUsers.Text = "LUsers"
        Me.mnuLUsers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuMode
        '
        Me.mnuMode.AccessibleDescription = "Mode"
        Me.mnuMode.AccessibleName = "Mode"
        Me.mnuMode.Name = "mnuMode"
        Me.mnuMode.Text = "Mode"
        Me.mnuMode.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuMotd
        '
        Me.mnuMotd.AccessibleDescription = "Motd"
        Me.mnuMotd.AccessibleName = "Motd"
        Me.mnuMotd.Name = "mnuMotd"
        Me.mnuMotd.Text = "Motd"
        Me.mnuMotd.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuNames
        '
        Me.mnuNames.AccessibleDescription = "Names"
        Me.mnuNames.AccessibleName = "Names"
        Me.mnuNames.Name = "mnuNames"
        Me.mnuNames.Text = "Names"
        Me.mnuNames.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuNotice
        '
        Me.mnuNotice.AccessibleDescription = "Notice"
        Me.mnuNotice.AccessibleName = "Notice"
        Me.mnuNotice.Name = "mnuNotice"
        Me.mnuNotice.Text = "Notice"
        Me.mnuNotice.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuPrivmsg
        '
        Me.mnuPrivmsg.AccessibleDescription = "Privmsg"
        Me.mnuPrivmsg.AccessibleName = "Privmsg"
        Me.mnuPrivmsg.Name = "mnuPrivmsg"
        Me.mnuPrivmsg.Text = "Privmsg"
        Me.mnuPrivmsg.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuRules
        '
        Me.mnuRules.AccessibleDescription = "Rules"
        Me.mnuRules.AccessibleName = "Rules"
        Me.mnuRules.Name = "mnuRules"
        Me.mnuRules.Text = "Rules"
        Me.mnuRules.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuServerLinks
        '
        Me.mnuServerLinks.AccessibleDescription = "Server Links"
        Me.mnuServerLinks.AccessibleName = "Server Links"
        Me.mnuServerLinks.Image = Nothing
        Me.mnuServerLinks.Name = "mnuServerLinks"
        Me.mnuServerLinks.Text = "Server Links"
        Me.mnuServerLinks.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuTime
        '
        Me.mnuTime.AccessibleDescription = "Time"
        Me.mnuTime.AccessibleName = "Time"
        Me.mnuTime.Image = Nothing
        Me.mnuTime.Name = "mnuTime"
        Me.mnuTime.Text = "Time"
        Me.mnuTime.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuService
        '
        Me.mnuService.AccessibleDescription = "Service"
        Me.mnuService.AccessibleName = "Service"
        Me.mnuService.Name = "mnuService"
        Me.mnuService.Text = "Service"
        Me.mnuService.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuStats
        '
        Me.mnuStats.AccessibleDescription = "Stats"
        Me.mnuStats.AccessibleName = "Stats"
        Me.mnuStats.Image = Nothing
        Me.mnuStats.Name = "mnuStats"
        Me.mnuStats.Text = "Stats"
        Me.mnuStats.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuServList
        '
        Me.mnuServList.AccessibleDescription = "ServList"
        Me.mnuServList.AccessibleName = "ServList"
        Me.mnuServList.Name = "mnuServList"
        Me.mnuServList.Text = "ServList"
        Me.mnuServList.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSQuery
        '
        Me.mnuSQuery.AccessibleDescription = "SQuery"
        Me.mnuSQuery.AccessibleName = "SQuery"
        Me.mnuSQuery.Name = "mnuSQuery"
        Me.mnuSQuery.Text = "SQuery"
        Me.mnuSQuery.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSetName
        '
        Me.mnuSetName.AccessibleDescription = "SetName"
        Me.mnuSetName.AccessibleName = "SetName"
        Me.mnuSetName.Name = "mnuSetName"
        Me.mnuSetName.Text = "SetName"
        Me.mnuSetName.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSilence
        '
        Me.mnuSilence.AccessibleDescription = "Silence"
        Me.mnuSilence.AccessibleName = "Silence"
        Me.mnuSilence.Name = "mnuSilence"
        Me.mnuSilence.Text = "Silence"
        Me.mnuSilence.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuSummon
        '
        Me.mnuSummon.AccessibleDescription = "Summon"
        Me.mnuSummon.AccessibleName = "Summon"
        Me.mnuSummon.Name = "mnuSummon"
        Me.mnuSummon.Text = "Summon"
        Me.mnuSummon.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuUhnames
        '
        Me.mnuUhnames.AccessibleDescription = "Uhnames"
        Me.mnuUhnames.AccessibleName = "Uhnames"
        Me.mnuUhnames.Name = "mnuUhnames"
        Me.mnuUhnames.Text = "Uhnames"
        Me.mnuUhnames.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuUserhost
        '
        Me.mnuUserhost.AccessibleDescription = "Userhost"
        Me.mnuUserhost.AccessibleName = "Userhost"
        Me.mnuUserhost.Name = "mnuUserhost"
        Me.mnuUserhost.Text = "Userhost"
        Me.mnuUserhost.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuUserip
        '
        Me.mnuUserip.AccessibleDescription = "Userip"
        Me.mnuUserip.AccessibleName = "Userip"
        Me.mnuUserip.Name = "mnuUserip"
        Me.mnuUserip.Text = "Userip"
        Me.mnuUserip.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuVersion
        '
        Me.mnuVersion.AccessibleDescription = "Version"
        Me.mnuVersion.AccessibleName = "Version"
        Me.mnuVersion.Name = "mnuVersion"
        Me.mnuVersion.Text = "Version"
        Me.mnuVersion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuWallops
        '
        Me.mnuWallops.AccessibleDescription = "Wallops"
        Me.mnuWallops.AccessibleName = "Wallops"
        Me.mnuWallops.Name = "mnuWallops"
        Me.mnuWallops.Text = "Wallops"
        Me.mnuWallops.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuWatch
        '
        Me.mnuWatch.AccessibleDescription = "Watch"
        Me.mnuWatch.AccessibleName = "Watch"
        Me.mnuWatch.Name = "mnuWatch"
        Me.mnuWatch.Text = "Watch"
        Me.mnuWatch.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuWho
        '
        Me.mnuWho.AccessibleDescription = "Who"
        Me.mnuWho.AccessibleName = "Who"
        Me.mnuWho.Name = "mnuWho"
        Me.mnuWho.Text = "Who"
        Me.mnuWho.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuWhois
        '
        Me.mnuWhois.AccessibleDescription = "Whois"
        Me.mnuWhois.AccessibleName = "Whois"
        Me.mnuWhois.Image = Nothing
        Me.mnuWhois.Name = "mnuWhois"
        Me.mnuWhois.Text = "Whois"
        Me.mnuWhois.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'mnuWhowas
        '
        Me.mnuWhowas.AccessibleDescription = "Whowas"
        Me.mnuWhowas.AccessibleName = "Whowas"
        Me.mnuWhowas.Image = Nothing
        Me.mnuWhowas.Name = "mnuWhowas"
        Me.mnuWhowas.Text = "Whowas"
        Me.mnuWhowas.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'CommandBarDropDownButton2
        '
        Me.CommandBarDropDownButton2.AccessibleDescription = "CommandBarDropDownButton2"
        Me.CommandBarDropDownButton2.AccessibleName = "CommandBarDropDownButton2"
        Me.CommandBarDropDownButton2.DisplayName = "CommandBarDropDownButton2"
        Me.CommandBarDropDownButton2.Image = CType(resources.GetObject("CommandBarDropDownButton2.Image"), System.Drawing.Image)
        Me.CommandBarDropDownButton2.Name = "CommandBarDropDownButton2"
        Me.CommandBarDropDownButton2.Text = "CommandBarDropDownButton2"
        Me.CommandBarDropDownButton2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarDropDownButton2.VisibleInOverflowMenu = True
        '
        'frmParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 292)
        Me.Controls.Add(Me.RadCommandBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.IsMdiContainer = True
        Me.Name = "frmParent"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.SmallImageScalingSize = New System.Drawing.Size(16, 16)
        Me.Text = "nexIRC"
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents CommandBarDropDownButton1 As Telerik.WinControls.UI.CommandBarDropDownButton
    Friend WithEvents CommandBarDropDownButton2 As Telerik.WinControls.UI.CommandBarDropDownButton
    Friend WithEvents mnuRecentServers As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuRecentServerItem1 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuRecentServerItem2 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuRecentServerItem3 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuRecentServerSep As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents mnuClearHistory As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuNewStatusWindow As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuConnectionsSep1 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents mnuCommands As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuAwayBackMenu As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuAway As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuBack As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuServerLinks As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuWhois As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuWhowas As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuTime As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuStats As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperator As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorConnect As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorDie As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuAdmin As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuHelp As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuInfo As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuInvite As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorEncap As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorCNotice As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorCPrivMsg2 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuError As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorOper As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuKick As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuKill As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuKnock As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuLinks As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuLUsers As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuMode As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuMotd As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuNames As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuNotice As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorRehash As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorRestart As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuIRCOperatorServer As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents SQuit As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuPrivmsg As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuRules As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuService As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuServList As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSQuery As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSetName As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSilence As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuSummon As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuUhnames As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuUserhost As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuUserip As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuVersion As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuWallops As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuWatch As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuWho As Telerik.WinControls.UI.RadMenuItem
End Class

