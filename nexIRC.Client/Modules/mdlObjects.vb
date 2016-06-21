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
        Public lCommandController As CommandController
        Public lCompatibilityController As CompatibilityController
        Public lStringsController As FixedStringController
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
    End Module
End Namespace