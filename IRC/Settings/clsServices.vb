Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
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
        Public Function DoesNetworkHaveAService(ByVal lNetwork As String) As Boolean
            Dim i As Integer
            If Len(lNetwork) <> 0 Then
                For i = 1 To lServices.sCount
                    If Trim(LCase(lServices.sService(i).sNetwork)) = Trim(LCase(lNetwork)) Then
                        DoesNetworkHaveAService = True
                        Exit For
                    End If
                Next i
            End If
        End Function
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
            lServices.sCount = CInt(clsFiles.ReadINI(lINI.iServices, "Settings", "Count", "0"))
            ReDim lServices.sService(lArraySizes.aServices)
            If lServices.sCount <> 0 Then
                For i = 1 To lServices.sCount
                    With lServices.sService(i)
                        ReDim .sServerCommands.sServiceCommand(lArraySizes.aServiceCommands)
                        ReDim .sServerCommands.sServiceCommand(i).sServiceParam(lArraySizes.aServiceParams)
                        .sName = clsFiles.ReadINI(lINI.iServices, Trim(Str(i)), "Name", "")
                        e = CInt(clsFiles.ReadINI(lINI.iServices, Trim(Str(i)), "Type", "0"))
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
                        .sNetwork = clsFiles.ReadINI(lINI.iServices, Trim(Str(i)), "Network", "")
                        .sServerCommands.sServiceCommandCount = CInt(Trim(clsFiles.ReadINI(lINI.iServices, Trim(Str(i)), "CommandCount", "0")))
                        If .sServerCommands.sServiceCommandCount <> 0 Then
                            For n = 1 To .sServerCommands.sServiceCommandCount
                                .sServerCommands.sServiceCommand(n).sCommand = clsFiles.ReadINI(lINI.iServices, Trim(CStr(i)), "Command" & Trim(CStr(n)), "")
                                .sServerCommands.sServiceCommand(n).sServiceParamCount = CInt(Trim(clsFiles.ReadINI(lINI.iServices, Trim(CStr(i)), "Command" & Trim(CStr(n)) & "ParamCount", "0")))
                                If .sServerCommands.sServiceCommand(n).sServiceParamCount <> 0 Then
                                    For t = 1 To .sServerCommands.sServiceCommand(n).sServiceParamCount
                                        .sServerCommands.sServiceCommand(n).sServiceParam(t).sParam = clsFiles.ReadINI(lINI.iServices, Trim(CStr(i)), "Command" & Trim(CStr(n)) & "Param" & Trim(CStr(t)), "")
                                    Next t
                                End If
                            Next n
                        End If
                    End With
                Next i
            End If
            With lX
                .xLoginNickName = clsFiles.ReadINI(lINI.iServices, "X", "LoginNickName", "")
                .xLoginPassword = clsFiles.ReadINI(lINI.iServices, "X", "LoginPassword", "")
                .xCreateAnAccountURL = clsFiles.ReadINI(lINI.iServices, "X", "CreateAnAccountURL", "http://cservice.undernet.org/live/newuser.php")
                .xEnable = CBool(clsFiles.ReadINI(lINI.iServices, "X", "Enable", "True"))
                .xLoginOnConnect = CBool(clsFiles.ReadINI(lINI.iServices, "X", "LoginOnConnect", "False"))
                .xShowOnConnect = CBool(clsFiles.ReadINI(lINI.iServices, "X", "ShowOnConnect", "True"))
                .xLongName = clsFiles.ReadINI(lINI.iServices, "X", "LongName", "x@channels.undernet.org")
            End With
            With lNickServ
                '.nEnable = CBool(clsFiles.ReadINI(lINI.iServices, "NickServ", "Enable", "False"))
                .nLoginNickname = clsFiles.ReadINI(lINI.iServices, "NickServ", "LoginNickname", "")
                .nLoginPassword = clsFiles.ReadINI(lINI.iServices, "NickServ", "LoginPassword", "")
                .nLoginOnConnect = CBool(clsFiles.ReadINI(lINI.iServices, "NickServ", "LoginOnConnect", "False"))
                .nShowOnConnect = CBool(clsFiles.ReadINI(lINI.iServices, "NickServ", "ShowOnConnect", "True"))
            End With
        End Sub
        Public Function FindServicesIndexByType(ByVal lService As eServiceType) As Integer
            Dim i As Integer
            For i = 1 To lServices.sCount
                With lServices.sService(i)
                    If .sType = lService Then
                        FindServicesIndexByType = i
                        Exit For
                    End If
                End With
            Next i
        End Function
        Public Sub SaveServices()
            Dim i As Integer
            clsFiles.WriteINI(lINI.iServices, "Settings", "Count", Trim(lServices.sCount.ToString))
            If lServices.sCount <> 0 Then
                For i = 1 To lServices.sCount
                    With lServices.sService(i)
                        clsFiles.WriteINI(lINI.iServices, Trim(Str(i)), "Name", .sName)
                        clsFiles.WriteINI(lINI.iServices, Trim(Str(i)), "Type", CStr(.sType))
                    End With
                Next i
            End If
            clsFiles.WriteINI(lINI.iServices, "X", "LoginNickName", lX.xLoginNickName)
            clsFiles.WriteINI(lINI.iServices, "X", "LoginPassword", lX.xLoginPassword)
            clsFiles.WriteINI(lINI.iServices, "X", "Enable", CStr(lX.xEnable))
            clsFiles.WriteINI(lINI.iServices, "X", "LoginOnConnect", CStr(lX.xLoginOnConnect))
            clsFiles.WriteINI(lINI.iServices, "X", "ShowOnConnect", CStr(lX.xShowOnConnect))
            clsFiles.WriteINI(lINI.iServices, "X", "LongName", lX.xLongName)
            clsFiles.WriteINI(lINI.iServices, "NickServ", "LoginNickname", lNickServ.nLoginNickname)
            clsFiles.WriteINI(lINI.iServices, "NickServ", "LoginPassword", lNickServ.nLoginPassword)
            clsFiles.WriteINI(lINI.iServices, "NickServ", "LoginOnConnect", CStr(lNickServ.nLoginOnConnect))
            clsFiles.WriteINI(lINI.iServices, "NickServ", "ShowOnConnect", CStr(lNickServ.nShowOnConnect))
        End Sub
    End Class
End Namespace