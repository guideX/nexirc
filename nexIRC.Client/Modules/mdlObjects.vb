'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.Channels
Imports nexIRC.IRC.Status
Imports nexIRC.nexIRC.IRC.Settings
Imports nexIRC.Business.Controllers

Namespace Modules
    Public Module mdlObjects
        Public lSettings As New Settings
        Public lStrings As New IrcStrings
        Public lStatus As Status
        Public lChannels As New clsChannel
        Public lChannelLists As New clsChannelList
        Public lChannelFolder As New clsChannelFolder
        Public lProcessNumeric As New clsProcessNumeric
        Public lSettings_DCC As New clsDCC
        Public lSettings_Services As New clsServices
        Public lIdent As New Ident
        Public lCommandController As CommandController
        Public lStringsController As New FixedStringController(Application.StartupPath + "\data\config\strings.ini")
        Public lCompatibilityController As New CompatibilityController(Application.StartupPath + "\data\config\compatibility.ini")
        Public lBotController As New BotController(Application.StartupPath + "\data\config\bots.ini")
        Public lChannelFolderController As New ChannelFolderController(Application.StartupPath + "\data\config\channelfolder.ini")
        Public lRecentServerController As New RecentServersController(Application.StartupPath + "\data\config\recentservers.ini", False)
        Public Notify As New NotifyListController(Application.StartupPath + "\data\config\notifylist.ini")
    End Module
End Namespace