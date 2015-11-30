Option Explicit On
Option Strict On
Imports nexIRC.Business.Repositories
Imports nexIRC.Client.nexIRC.Client.Classes
Imports nexIRC.Client.nexIRC.Client.IRC.Channels
Imports nexIRC.Client.nexIRC.Client.IRC.Numerics
Imports nexIRC.Client.nexIRC.Client.IRC.Settings
Imports nexIRC.Client.nexIRC.Client.IRC.Status
Namespace nexIRC.Client.Modules
    Public Module mdlObjects
        Public lSettings As New Settings
        Public lStrings As New IrcStrings
        Public lStatus As Status
        Public lChannels As New clsChannel
        Public lChannelLists As New clsChannelList
        Public lChannelFolder As New clsChannelFolder
        Public lProcessNumeric As New clsProcessNumeric
        Public lSettings_DCC As gDCC = DccSettings.Read(Application.StartupPath)
        Public lSettings_Services As New clsServices
        Public lIdent As New Ident
        Public IrcSettings As New IrcSettings(Application.StartupPath & "\")
    End Module
End Namespace