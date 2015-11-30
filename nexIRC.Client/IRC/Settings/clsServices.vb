Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client.IRC.Settings.Settings

Namespace nexIRC.Client.IRC.Settings
    Public Class clsServices
        Public Structure gServiceParam
            Public sParam As String
        End Structure

        Public Structure gServiceCommand
            Public sCommand As String
            Public sLevel As Integer
            Public sServiceParam() As gServiceParam
            Public sServiceParamCount As Integer
        End Structure

        Public Structure gServiceCommands
            Public sServiceCommand() As gServiceCommand
            Public sServiceCommandCount As Integer
        End Structure

        Public Structure gService
            Public sName As String
            Public sType As eServiceType
            Public sTypeCustom As Integer
            Public sNetwork As String
            Public sServerCommands As gServiceCommands
        End Structure

        Public Structure gServices
            Public sCount As Integer
            Public sService() As gService
        End Structure

        Public Structure gX
            Public xLoginNickName As String
            Public xLoginPassword As String
            Public xEnable As Boolean
            Public xShowOnConnect As Boolean
            Public xLoginOnConnect As Boolean
            Public xCreateAnAccountURL As String
            Public xLongName As String
        End Structure

        Public Structure gNickServ
            Public nLoginNickname As String
            Public nLoginPassword As String
            Public nShowOnConnect As Boolean
            Public nLoginOnConnect As Boolean
        End Structure

        Public lServices As gServices
        Public lX As gX
        Public lNickServ As gNickServ

        Public Sub AddService(ByVal lName As String, ByVal lType As eServiceType)
            lServices.sCount = lServices.sCount + 1
            If Len(lName) <> 0 And lType <> eServiceType.sNone Then
                With lServices.sService(lServices.sCount)
                    .sName = lName
                    .sType = lType
                End With
            End If
        End Sub

        Public Sub LoadServices()
            Dim i As Integer, n As Integer, t As Integer, e As Integer
            lServices.sCount = Convert.ToInt32(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, "Settings", "Count", "0"))
            ReDim lServices.sService(Modules.lSettings.lArraySizes.aServices)
            If lServices.sCount <> 0 Then
                For i = 1 To lServices.sCount
                    With lServices.sService(i)
                        ReDim .sServerCommands.sServiceCommand(Modules.lSettings.lArraySizes.aServiceCommands)
                        ReDim .sServerCommands.sServiceCommand(i).sServiceParam(Modules.lSettings.lArraySizes.aServiceParams)
                        .sName = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Name", "")
                        e = Convert.ToInt32(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Type", "0"))
                        Select Case e
                            Case 0
                                .sType = eServiceType.sNone
                            Case 1
                                .sType = eServiceType.sChanServ
                            Case 2
                                .sType = eServiceType.sNickServ
                            Case 3
                                .sType = eServiceType.sX
                            Case Else
                                .sTypeCustom = e
                        End Select
                        .sNetwork = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Network", "")
                        .sServerCommands.sServiceCommandCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "CommandCount", "0")))
                        If .sServerCommands.sServiceCommandCount <> 0 Then
                            For n = 1 To .sServerCommands.sServiceCommandCount
                                .sServerCommands.sServiceCommand(n).sCommand = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)), "")
                                .sServerCommands.sServiceCommand(n).sServiceParamCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "ParamCount", "0")))
                                If .sServerCommands.sServiceCommand(n).sServiceParamCount <> 0 Then
                                    For t = 1 To .sServerCommands.sServiceCommand(n).sServiceParamCount
                                        .sServerCommands.sServiceCommand(n).sServiceParam(t).sParam = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "Param" & Trim(Convert.ToString(t)), "")
                                    Next t
                                End If
                            Next n
                        End If
                    End With
                Next i
            End If
            With lNickServ
                .nLoginNickname = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginNickname", "")
                .nLoginPassword = IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginPassword", "")
                .nLoginOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginOnConnect", "False"))
                .nShowOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServices, "NickServ", "ShowOnConnect", "True"))
            End With
        End Sub

        Public Sub SaveServices()
            Dim i As Integer
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, "Settings", "Count", Trim(lServices.sCount.ToString))
            If lServices.sCount <> 0 Then
                For i = 1 To lServices.sCount
                    With lServices.sService(i)
                        IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Name", .sName)
                        IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Type", Convert.ToString(.sType))
                    End With
                Next i
            End If
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginNickname", lNickServ.nLoginNickname)
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginPassword", lNickServ.nLoginPassword)
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, "NickServ", "LoginOnConnect", Convert.ToString(lNickServ.nLoginOnConnect))
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iServices, "NickServ", "ShowOnConnect", Convert.ToString(lNickServ.nShowOnConnect))
        End Sub
    End Class
End Namespace