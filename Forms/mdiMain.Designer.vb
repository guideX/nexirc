<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiMain))
        Me.rcbTop = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdConnection = New Telerik.WinControls.UI.CommandBarDropDownButton()
        Me.cmdRecentServers = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdRecentServer1 = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdRecentServer2 = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdRecentServer3 = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep4 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdClearHistory = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdNewStatusWindow = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep5 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdCommands = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdAwayMenu = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdAwayMenuAway = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdAwayMenuBack = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep6 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdServerLinks = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdWhois = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdWhowas = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdTime = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdStats = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep1 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdConnect = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdDisconnect = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdQuit = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep2 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdSelectAServer = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdChangeConnection = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSep3 = New Telerik.WinControls.UI.RadMenuSeparatorItem()
        Me.cmdCloseStatus = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.CommandBarRowElement2 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.rssBottom = New Telerik.WinControls.UI.RadStatusStrip()
        Me.tvwLeft = New Telerik.WinControls.UI.RadTreeView()
        CType(Me.rcbTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rssBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvwLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcbTop
        '
        Me.rcbTop.AutoSize = True
        Me.rcbTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.rcbTop.Location = New System.Drawing.Point(0, 0)
        Me.rcbTop.Name = "rcbTop"
        Me.rcbTop.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1, Me.CommandBarRowElement2})
        Me.rcbTop.Size = New System.Drawing.Size(772, 55)
        Me.rcbTop.TabIndex = 1
        Me.rcbTop.Text = "RadCommandBar1"
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
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdConnection})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'cmdConnection
        '
        Me.cmdConnection.AccessibleDescription = "Connection"
        Me.cmdConnection.AccessibleName = "Connection"
        Me.cmdConnection.DisplayName = "CommandBarDropDownButton1"
        Me.cmdConnection.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdConnection.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cmdRecentServers, Me.cmdNewStatusWindow, Me.cmdSep5, Me.cmdCommands, Me.cmdSep1, Me.cmdConnect, Me.cmdDisconnect, Me.cmdQuit, Me.cmdSep2, Me.cmdSelectAServer, Me.cmdChangeConnection, Me.cmdSep3, Me.cmdCloseStatus})
        Me.cmdConnection.Name = "cmdConnection"
        Me.cmdConnection.Text = "Connection"
        Me.cmdConnection.ToolTipText = "Connection"
        Me.cmdConnection.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdConnection.VisibleInOverflowMenu = True
        '
        'cmdRecentServers
        '
        Me.cmdRecentServers.AccessibleDescription = "Recent Servers"
        Me.cmdRecentServers.AccessibleName = "Recent Servers"
        '
        '
        '
        Me.cmdRecentServers.ButtonElement.AccessibleDescription = "Recent Servers"
        Me.cmdRecentServers.ButtonElement.AccessibleName = "Recent Servers"
        Me.cmdRecentServers.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cmdRecentServer1, Me.cmdRecentServer2, Me.cmdRecentServer3, Me.cmdSep4, Me.cmdClearHistory})
        Me.cmdRecentServers.Name = "cmdRecentServers"
        Me.cmdRecentServers.Text = "Recent Servers"
        Me.cmdRecentServers.ToolTipText = "Recent Servers"
        Me.cmdRecentServers.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdRecentServer1
        '
        Me.cmdRecentServer1.AccessibleDescription = "(None)"
        Me.cmdRecentServer1.AccessibleName = "(None)"
        '
        '
        '
        Me.cmdRecentServer1.ButtonElement.AccessibleDescription = "(None)"
        Me.cmdRecentServer1.ButtonElement.AccessibleName = "(None)"
        Me.cmdRecentServer1.Enabled = False
        Me.cmdRecentServer1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecentServer1.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdRecentServer1.Name = "cmdRecentServer1"
        Me.cmdRecentServer1.Text = "(None)"
        Me.cmdRecentServer1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdRecentServer2
        '
        Me.cmdRecentServer2.AccessibleDescription = "(None)"
        Me.cmdRecentServer2.AccessibleName = "(None)"
        '
        '
        '
        Me.cmdRecentServer2.ButtonElement.AccessibleDescription = "(None)"
        Me.cmdRecentServer2.ButtonElement.AccessibleName = "(None)"
        Me.cmdRecentServer2.Enabled = False
        Me.cmdRecentServer2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecentServer2.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdRecentServer2.Name = "cmdRecentServer2"
        Me.cmdRecentServer2.Text = "(None)"
        Me.cmdRecentServer2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdRecentServer3
        '
        Me.cmdRecentServer3.AccessibleDescription = "Recent Server 3"
        Me.cmdRecentServer3.AccessibleName = "Recent Server 3"
        '
        '
        '
        Me.cmdRecentServer3.ButtonElement.AccessibleDescription = "(None)"
        Me.cmdRecentServer3.ButtonElement.AccessibleName = "(None)"
        Me.cmdRecentServer3.Enabled = False
        Me.cmdRecentServer3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecentServer3.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdRecentServer3.Name = "cmdRecentServer3"
        Me.cmdRecentServer3.Text = "(None)"
        Me.cmdRecentServer3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep4
        '
        Me.cmdSep4.AccessibleDescription = "cmdSep4"
        Me.cmdSep4.AccessibleName = "cmdSep4"
        Me.cmdSep4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSep4.Name = "cmdSep4"
        Me.cmdSep4.Text = "cmdSep4"
        Me.cmdSep4.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdClearHistory
        '
        Me.cmdClearHistory.AccessibleDescription = "Clear History"
        Me.cmdClearHistory.AccessibleName = "Clear History"
        '
        '
        '
        Me.cmdClearHistory.ButtonElement.AccessibleDescription = "Clear History"
        Me.cmdClearHistory.ButtonElement.AccessibleName = "Clear History"
        Me.cmdClearHistory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearHistory.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdClearHistory.Name = "cmdClearHistory"
        Me.cmdClearHistory.Text = "Clear History"
        Me.cmdClearHistory.ToolTipText = "Clear History"
        Me.cmdClearHistory.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdNewStatusWindow
        '
        Me.cmdNewStatusWindow.AccessibleDescription = "New Status Window"
        Me.cmdNewStatusWindow.AccessibleName = "New Status Window"
        '
        '
        '
        Me.cmdNewStatusWindow.ButtonElement.AccessibleDescription = "New Status Window"
        Me.cmdNewStatusWindow.ButtonElement.AccessibleName = "New Status Window"
        Me.cmdNewStatusWindow.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdNewStatusWindow.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewStatusWindow.Image = Global.nexIRC.My.Resources.Resources.add
        Me.cmdNewStatusWindow.Name = "cmdNewStatusWindow"
        Me.cmdNewStatusWindow.Text = "New Status Window"
        Me.cmdNewStatusWindow.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep5
        '
        Me.cmdSep5.AccessibleDescription = "cmdSep5"
        Me.cmdSep5.AccessibleName = "cmdSep5"
        Me.cmdSep5.Name = "cmdSep5"
        Me.cmdSep5.Text = "cmdSep5"
        Me.cmdSep5.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdCommands
        '
        Me.cmdCommands.AccessibleDescription = "Commands"
        Me.cmdCommands.AccessibleName = "Commands"
        '
        '
        '
        Me.cmdCommands.ButtonElement.AccessibleDescription = "Commands"
        Me.cmdCommands.ButtonElement.AccessibleName = "Commands"
        Me.cmdCommands.Image = Global.nexIRC.My.Resources.Resources.forward
        Me.cmdCommands.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cmdAwayMenu, Me.cmdSep6, Me.cmdServerLinks, Me.cmdWhois, Me.cmdWhowas, Me.cmdTime, Me.cmdStats})
        Me.cmdCommands.Name = "cmdCommands"
        Me.cmdCommands.Text = "Commands"
        Me.cmdCommands.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdAwayMenu
        '
        Me.cmdAwayMenu.AccessibleDescription = "Away Menu"
        Me.cmdAwayMenu.AccessibleName = "Away Menu"
        '
        '
        '
        Me.cmdAwayMenu.ButtonElement.AccessibleDescription = "Away Menu"
        Me.cmdAwayMenu.ButtonElement.AccessibleName = "Away Menu"
        Me.cmdAwayMenu.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdAwayMenu.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAwayMenu.Image = Global.nexIRC.My.Resources.Resources.forward
        Me.cmdAwayMenu.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cmdAwayMenuAway, Me.cmdAwayMenuBack})
        Me.cmdAwayMenu.Name = "cmdAwayMenu"
        Me.cmdAwayMenu.Text = "Away Menu"
        Me.cmdAwayMenu.ToolTipText = "Away Menu"
        Me.cmdAwayMenu.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdAwayMenuAway
        '
        Me.cmdAwayMenuAway.AccessibleDescription = "Away"
        Me.cmdAwayMenuAway.AccessibleName = "Away"
        '
        '
        '
        Me.cmdAwayMenuAway.ButtonElement.AccessibleDescription = "Away"
        Me.cmdAwayMenuAway.ButtonElement.AccessibleName = "Away"
        Me.cmdAwayMenuAway.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdAwayMenuAway.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAwayMenuAway.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdAwayMenuAway.Name = "cmdAwayMenuAway"
        Me.cmdAwayMenuAway.Text = "Away"
        Me.cmdAwayMenuAway.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdAwayMenuBack
        '
        Me.cmdAwayMenuBack.AccessibleDescription = "Back"
        Me.cmdAwayMenuBack.AccessibleName = "Back"
        '
        '
        '
        Me.cmdAwayMenuBack.ButtonElement.AccessibleDescription = "Back"
        Me.cmdAwayMenuBack.ButtonElement.AccessibleName = "Back"
        Me.cmdAwayMenuBack.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdAwayMenuBack.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAwayMenuBack.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdAwayMenuBack.Name = "cmdAwayMenuBack"
        Me.cmdAwayMenuBack.Text = "Back"
        Me.cmdAwayMenuBack.ToolTipText = "Back"
        Me.cmdAwayMenuBack.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep6
        '
        Me.cmdSep6.AccessibleDescription = "RadMenuSeparatorItem1"
        Me.cmdSep6.AccessibleName = "RadMenuSeparatorItem1"
        Me.cmdSep6.Name = "cmdSep6"
        Me.cmdSep6.Text = "RadMenuSeparatorItem1"
        Me.cmdSep6.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdServerLinks
        '
        Me.cmdServerLinks.AccessibleDescription = "Server Links"
        Me.cmdServerLinks.AccessibleName = "Server Links"
        '
        '
        '
        Me.cmdServerLinks.ButtonElement.AccessibleDescription = "Server Links"
        Me.cmdServerLinks.ButtonElement.AccessibleName = "Server Links"
        Me.cmdServerLinks.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdServerLinks.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdServerLinks.Image = Global.nexIRC.My.Resources.Resources.forward
        Me.cmdServerLinks.Name = "cmdServerLinks"
        Me.cmdServerLinks.Text = "Server Links"
        Me.cmdServerLinks.ToolTipText = "Server Links"
        Me.cmdServerLinks.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdWhois
        '
        Me.cmdWhois.AccessibleDescription = "Whois"
        Me.cmdWhois.AccessibleName = "Whois"
        '
        '
        '
        Me.cmdWhois.ButtonElement.AccessibleDescription = "Whois"
        Me.cmdWhois.ButtonElement.AccessibleName = "Whois"
        Me.cmdWhois.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdWhois.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWhois.Name = "cmdWhois"
        Me.cmdWhois.Text = "Whois"
        Me.cmdWhois.ToolTipText = "Whois"
        Me.cmdWhois.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdWhowas
        '
        Me.cmdWhowas.AccessibleDescription = "RadMenuButtonItem1"
        Me.cmdWhowas.AccessibleName = "RadMenuButtonItem1"
        '
        '
        '
        Me.cmdWhowas.ButtonElement.AccessibleDescription = "RadMenuButtonItem1"
        Me.cmdWhowas.ButtonElement.AccessibleName = "RadMenuButtonItem1"
        Me.cmdWhowas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWhowas.Name = "cmdWhowas"
        Me.cmdWhowas.Text = "RadMenuButtonItem1"
        Me.cmdWhowas.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdTime
        '
        Me.cmdTime.AccessibleDescription = "RadMenuButtonItem2"
        Me.cmdTime.AccessibleName = "RadMenuButtonItem2"
        '
        '
        '
        Me.cmdTime.ButtonElement.AccessibleDescription = "RadMenuButtonItem2"
        Me.cmdTime.ButtonElement.AccessibleName = "RadMenuButtonItem2"
        Me.cmdTime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTime.Name = "cmdTime"
        Me.cmdTime.Text = "RadMenuButtonItem2"
        Me.cmdTime.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdStats
        '
        Me.cmdStats.AccessibleDescription = "RadMenuButtonItem3"
        Me.cmdStats.AccessibleName = "RadMenuButtonItem3"
        '
        '
        '
        Me.cmdStats.ButtonElement.AccessibleDescription = "RadMenuButtonItem3"
        Me.cmdStats.ButtonElement.AccessibleName = "RadMenuButtonItem3"
        Me.cmdStats.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStats.Name = "cmdStats"
        Me.cmdStats.Text = "RadMenuButtonItem3"
        Me.cmdStats.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep1
        '
        Me.cmdSep1.AccessibleDescription = "RadMenuSeparatorItem1"
        Me.cmdSep1.AccessibleName = "RadMenuSeparatorItem1"
        Me.cmdSep1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSep1.Name = "cmdSep1"
        Me.cmdSep1.Text = "RadMenuSeparatorItem1"
        Me.cmdSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdConnect
        '
        Me.cmdConnect.AccessibleDescription = "Connect"
        Me.cmdConnect.AccessibleName = "Connect"
        '
        '
        '
        Me.cmdConnect.ButtonElement.AccessibleDescription = "Connect"
        Me.cmdConnect.ButtonElement.AccessibleName = "Connect"
        Me.cmdConnect.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdConnect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnect.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.ToolTipText = "Connect"
        Me.cmdConnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.AccessibleDescription = "Disconnect"
        Me.cmdDisconnect.AccessibleName = "Disconnect"
        '
        '
        '
        Me.cmdDisconnect.ButtonElement.AccessibleDescription = "Disconnect"
        Me.cmdDisconnect.ButtonElement.AccessibleName = "Disconnect"
        Me.cmdDisconnect.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdDisconnect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisconnect.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.ToolTipText = "Disconnect"
        Me.cmdDisconnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdQuit
        '
        Me.cmdQuit.AccessibleDescription = "Quit"
        Me.cmdQuit.AccessibleName = "Quit"
        '
        '
        '
        Me.cmdQuit.ButtonElement.AccessibleDescription = "Quit"
        Me.cmdQuit.ButtonElement.AccessibleName = "Quit"
        Me.cmdQuit.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdQuit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQuit.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Text = "Quit"
        Me.cmdQuit.ToolTipText = "Quit"
        Me.cmdQuit.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep2
        '
        Me.cmdSep2.AccessibleDescription = "sep2"
        Me.cmdSep2.AccessibleName = "RadMenuSeparatorItem1"
        Me.cmdSep2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSep2.Name = "cmdSep2"
        Me.cmdSep2.Text = "RadMenuSeparatorItem1"
        Me.cmdSep2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSelectAServer
        '
        Me.cmdSelectAServer.AccessibleDescription = "Select a Server"
        Me.cmdSelectAServer.AccessibleName = "Select a Server"
        '
        '
        '
        Me.cmdSelectAServer.ButtonElement.AccessibleDescription = "Select a Server"
        Me.cmdSelectAServer.ButtonElement.AccessibleName = "Select a Server"
        Me.cmdSelectAServer.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdSelectAServer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectAServer.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.cmdSelectAServer.Name = "cmdSelectAServer"
        Me.cmdSelectAServer.Text = "Select a Server"
        Me.cmdSelectAServer.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdChangeConnection
        '
        Me.cmdChangeConnection.AccessibleDescription = "Change Connection"
        Me.cmdChangeConnection.AccessibleName = "Change Connection"
        '
        '
        '
        Me.cmdChangeConnection.ButtonElement.AccessibleDescription = "Change Connection"
        Me.cmdChangeConnection.ButtonElement.AccessibleName = "Change Connection"
        Me.cmdChangeConnection.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdChangeConnection.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeConnection.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.cmdChangeConnection.Name = "cmdChangeConnection"
        Me.cmdChangeConnection.Text = "Change Connection"
        Me.cmdChangeConnection.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSep3
        '
        Me.cmdSep3.AccessibleDescription = "RadMenuSeparatorItem1"
        Me.cmdSep3.AccessibleName = "RadMenuSeparatorItem1"
        Me.cmdSep3.Name = "cmdSep3"
        Me.cmdSep3.Text = "RadMenuSeparatorItem1"
        Me.cmdSep3.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdCloseStatus
        '
        Me.cmdCloseStatus.AccessibleDescription = "Close Status"
        Me.cmdCloseStatus.AccessibleName = "Close Status"
        '
        '
        '
        Me.cmdCloseStatus.ButtonElement.AccessibleDescription = "Close Status"
        Me.cmdCloseStatus.ButtonElement.AccessibleName = "Close Status"
        Me.cmdCloseStatus.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.cmdCloseStatus.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdCloseStatus.Name = "cmdCloseStatus"
        Me.cmdCloseStatus.Text = "Close Status"
        Me.cmdCloseStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'CommandBarRowElement2
        '
        Me.CommandBarRowElement2.DisplayName = Nothing
        Me.CommandBarRowElement2.MinSize = New System.Drawing.Size(25, 25)
        '
        'rssBottom
        '
        Me.rssBottom.AutoSize = True
        Me.rssBottom.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.rssBottom.Location = New System.Drawing.Point(0, 372)
        Me.rssBottom.Name = "rssBottom"
        Me.rssBottom.Size = New System.Drawing.Size(772, 24)
        Me.rssBottom.TabIndex = 2
        Me.rssBottom.Text = "RadStatusStrip1"
        '
        'tvwLeft
        '
        Me.tvwLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwLeft.Location = New System.Drawing.Point(0, 55)
        Me.tvwLeft.Name = "tvwLeft"
        Me.tvwLeft.Size = New System.Drawing.Size(150, 317)
        Me.tvwLeft.SpacingBetweenNodes = -1
        Me.tvwLeft.TabIndex = 3
        Me.tvwLeft.Text = "RadTreeView1"
        '
        'mdiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 396)
        Me.Controls.Add(Me.tvwLeft)
        Me.Controls.Add(Me.rssBottom)
        Me.Controls.Add(Me.rcbTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "mdiMain"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC"
        CType(Me.rcbTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rssBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvwLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcbTop As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents rssBottom As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents tvwLeft As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents cmdConnection As Telerik.WinControls.UI.CommandBarDropDownButton
    Friend WithEvents cmdConnect As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdDisconnect As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdNewStatusWindow As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep1 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdQuit As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep2 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdSelectAServer As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdChangeConnection As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep3 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdCloseStatus As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdRecentServers As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdRecentServer1 As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdRecentServer2 As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdRecentServer3 As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep4 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdClearHistory As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep5 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdCommands As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdAwayMenu As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdServerLinks As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdWhois As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdAwayMenuAway As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdAwayMenuBack As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdSep6 As Telerik.WinControls.UI.RadMenuSeparatorItem
    Friend WithEvents cmdWhowas As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdTime As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdStats As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents CommandBarRowElement2 As Telerik.WinControls.UI.CommandBarRowElement
End Class

