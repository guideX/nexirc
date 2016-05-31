Option Explicit On
Option Strict On
'nexIRC 3.0.31
'05-30-2016 - guideX
Imports nexIRC.Business.Helpers
Imports nexIRC.Enum.Services
Imports nexIRC.Modules
Imports nexIRC.Settings

Namespace nexIRC.IRC.Settings
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
            Public sType As ServiceType
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

        Public Sub AddService(ByVal lName As String, ByVal lType As ServiceType)
            Try
                lServices.sCount = lServices.sCount + 1
                If Len(lName) <> 0 And lType <> ServiceType.None Then
                    With lServices.sService(lServices.sCount)
                        .sName = lName
                        .sType = lType
                    End With
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub LoadServices()
            Try
                Dim i As Integer, n As Integer, t As Integer, e As Integer
                lServices.sCount = Convert.ToInt32(NativeMethods.ReadINI(Modules.lSettings.lINI.iServices, "Settings", "Count", "0"))
                ReDim lServices.sService(Modules.lSettings.lArraySizes.aServices)
                If lServices.sCount <> 0 Then
                    For i = 1 To lServices.sCount
                        With lServices.sService(i)
                            ReDim .sServerCommands.sServiceCommand(Modules.lSettings.lArraySizes.aServiceCommands)
                            ReDim .sServerCommands.sServiceCommand(i).sServiceParam(Modules.lSettings.lArraySizes.aServiceParams)
                            .sName = NativeMethods.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Name", "")
                            e = Convert.ToInt32(NativeMethods.ReadINI(Modules.lSettings.lINI.iServices, Trim(Str(i)), "Type", "0"))
                            Select Case e
                                Case 0
                                    .sType = ServiceType.None
                                Case 1
                                    .sType = ServiceType.ChanServ
                                Case 2
                                    .sType = ServiceType.NickServ
                                Case 3
                                    .sType = ServiceType.X
                                Case Else
                                    .sTypeCustom = e
                            End Select
                            .sNetwork = NativeMethods.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "Network", "")
                            .sServerCommands.sServiceCommandCount = Convert.ToInt32(Trim(NativeMethods.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "CommandCount", "0")))
                            If .sServerCommands.sServiceCommandCount <> 0 Then
                                For n = 1 To .sServerCommands.sServiceCommandCount
                                    .sServerCommands.sServiceCommand(n).sCommand = NativeMethods.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)), "")
                                    .sServerCommands.sServiceCommand(n).sServiceParamCount = Convert.ToInt32(Trim(NativeMethods.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "ParamCount", "0")))
                                    If .sServerCommands.sServiceCommand(n).sServiceParamCount <> 0 Then
                                        For t = 1 To .sServerCommands.sServiceCommand(n).sServiceParamCount
                                            .sServerCommands.sServiceCommand(n).sServiceParam(t).sParam = NativeMethods.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "Param" & Trim(Convert.ToString(t)), "")
                                        Next t
                                    End If
                                Next n
                            End If
                        End With
                    Next i
                End If
                'With lX
                '.xLoginNickName = NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "LoginNickName", "")
                '.xLoginPassword = NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "LoginPassword", "")
                '.xCreateAnAccountURL = NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "CreateAnAccountURL", "http://cservice.undernet.org/live/newuser.php")
                '.xEnable = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "Enable", "True"))
                '.xLoginOnConnect = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "LoginOnConnect", "False"))
                '.xShowOnConnect = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "ShowOnConnect", "True"))
                '.xLongName = NativeMethods.ReadINI(lSettings.lINI.iServices, "X", "LongName", "x@channels.undernet.org")
                'End With
                With lNickServ
                    '.nEnable = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iServices, "NickServ", "Enable", "False"))
                    .nLoginNickname = NativeMethods.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginNickname", "")
                    .nLoginPassword = NativeMethods.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginPassword", "")
                    .nLoginOnConnect = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginOnConnect", "False"))
                    .nShowOnConnect = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iServices, "NickServ", "ShowOnConnect", "True"))
                End With
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub SaveServices()
            Try
                Dim i As Integer
                NativeMethods.WriteINI(lSettings.lINI.iServices, "Settings", "Count", Trim(lServices.sCount.ToString))
                If lServices.sCount <> 0 Then
                    For i = 1 To lServices.sCount
                        With lServices.sService(i)
                            NativeMethods.WriteINI(lSettings.lINI.iServices, Trim(Str(i)), "Name", .sName)
                            NativeMethods.WriteINI(lSettings.lINI.iServices, Trim(Str(i)), "Type", Convert.ToString(.sType))
                        End With
                    Next i
                End If
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "LoginNickName", lX.xLoginNickName)
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "LoginPassword", lX.xLoginPassword)
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "Enable", Convert.ToString(lX.xEnable))
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "LoginOnConnect", Convert.ToString(lX.xLoginOnConnect))
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "ShowOnConnect", Convert.ToString(lX.xShowOnConnect))
                'NativeMethods.WriteINI(lSettings.lINI.iServices, "X", "LongName", lX.xLongName)
                NativeMethods.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginNickname", lNickServ.nLoginNickname)
                NativeMethods.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginPassword", lNickServ.nLoginPassword)
                NativeMethods.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginOnConnect", Convert.ToString(lNickServ.nLoginOnConnect))
                NativeMethods.WriteINI(lSettings.lINI.iServices, "NickServ", "ShowOnConnect", Convert.ToString(lNickServ.nShowOnConnect))
            Catch ex As Exception
                Throw
            End Try
        End Sub
    End Class
End Namespace