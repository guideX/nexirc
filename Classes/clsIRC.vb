'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System
Imports System.Net
Imports nexIRC.IRC.Channels.clsChannel
Imports nexIRC.Classes.UI

Public Class clsIRC
    Private l001 As String, l002 As String, l003 As String, l004 As String, l311 As String, l312 As String, l313 As String, l316 As String, l317 As String, l319 As String, l378 As String, l379 As String, l401 As String, l250 As String, l251 As String, l252 As String, l253 As String, l254 As String, l255 As String, l265 As String, l266 As String, l616 As String, l615 As String, lWhoisUser As String
    Private Delegate Sub StatusDataDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub JoinPartDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub QuitDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub ProcessReplaceStringDelegate1(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)

    Private Sub ProcessReplaceStringHelper(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)
        Try
            Dim lProcessReplaceString As New ProcessReplaceStringDelegate1(AddressOf ProcessReplaceString)
            lStatus.GetObject(lStatusIndex).sWindow.Invoke(lProcessReplaceString, lStatusIndex, lType, r1)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub ProcessReplaceStringHelper(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)")
        End Try
    End Sub

    Public Sub ResetMessages()
        Try
            l001 = ""
            l002 = ""
            l003 = ""
            l004 = ""
            l250 = ""
            l251 = ""
            l252 = ""
            l253 = ""
            l254 = ""
            l255 = ""
            l265 = ""
            l266 = ""
            l311 = ""
            l312 = ""
            l313 = ""
            l316 = ""
            l317 = ""
            l319 = ""
            l378 = ""
            l379 = ""
            l401 = ""
            l615 = ""
            l616 = ""
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ResetMessages()")
        End Try
    End Sub

    Public Function ReturnDCCPort() As Long
        Try
            Dim splt() As String, p As Long
            If lDCC.dRandomizePort = True Then
                If InStr(lDCC.dSendPort, "-") <> 0 Then
                    splt = Split(lDCC.dSendPort, "-")
                    p = GetRnd(CInt(Trim(splt(0))), CInt(Trim(splt(1))))
                Else
                    p = GetRnd(128, 9999)
                End If
            Else
                If InStr(lDCC.dSendPort, "-") <> 0 Then
                    splt = Split(lDCC.dSendPort, "-")
                    p = GetRnd(CInt(Trim(splt(0))), CInt(Trim(splt(1))))
                Else
                    p = CLng(Trim(lDCC.dSendPort))
                End If
            End If
            ReturnDCCPort = p
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnDCCPort() As Long")
        End Try
    End Function

    Public Function ReturnRandomNetworkIndex(ByVal lExcludeIndex As Integer) As Integer
        Try
            Dim n As Integer, b As Boolean
            If lExcludeIndex <> 0 Then
                Do Until b = True
                    n = CInt(GetRnd(1, lNetworks.nCount))
                    If n <> lExcludeIndex Then b = True
                Loop
                ReturnRandomNetworkIndex = n
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnRandomNetworkIndex(ByVal lExcludeIndex As Integer) As Integer")
        End Try
    End Function

    Public Sub NewDCCChat()
        Try
            Dim f As frmDCCChat
            f = New frmDCCChat
            f.SetStatusIndex(lStatus.ActiveIndex)
            clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub NewDCCChat()")
        End Try
    End Sub

    Public Sub NewDCCSend()
        Try
            Dim f As frmDCCSend
            f = New frmDCCSend
            f.SetStatusIndex(lStatus.ActiveIndex)
            clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub NewDCCSend()")
        End Try
    End Sub

    Public Function ReturnMyIp() As String
        Try
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
            ReturnMyIp = (CType(h.AddressList.GetValue(0), IPAddress).ToString)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnMyIp() As String")
            Return Nothing
        End Try
    End Function

    Public Function IsChannelListData(ByVal lServerIP As String, ByVal lData As String) As Boolean
        Try
            If Len(lServerIP) <> 0 And Len(lData) <> 0 Then
                If Left(lData, Len(lServerIP) + 5) = ":" & lServerIP & " 322" Then
                    IsChannelListData = True
                Else
                    If InStr(lData, " 322") <> 0 Then
                        IsChannelListData = True
                    End If
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function IsChannelListData(ByVal lData As String) As Boolean")
        End Try
    End Function

    Public Sub ProcessWhoisCommand(ByVal _StatusIndex As Integer)
        Try
            Dim msg As String = "", _Start As String, _End As String
            _Start = ReturnReplacedString(eStringTypes.sWHOIS_START).Trim & vbCrLf
            _End = ReturnReplacedString(eStringTypes.sWHOIS_END).Trim
            If Len(l311) <> 0 Then msg = msg & l311 & vbCrLf
            If Len(l312) <> 0 Then msg = msg & l312 & vbCrLf
            If Len(l313) <> 0 Then msg = msg & l313 & vbCrLf
            If Len(l316) <> 0 Then msg = msg & l316 & vbCrLf
            If Len(l317) <> 0 Then msg = msg & l317 & vbCrLf
            If Len(l319) <> 0 Then msg = msg & l319 & vbCrLf
            If Len(l378) <> 0 Then msg = msg & l378 & vbCrLf
            If Len(l379) <> 0 Then msg = msg & l379 & vbCrLf
            If Len(l401) <> 0 Then msg = msg & l401 & vbCrLf
            If Len(l615) <> 0 Then msg = msg & l615 & vbCrLf
            If Len(l616) <> 0 Then msg = msg & l616 & vbCrLf
            If Len(msg) <> 0 Then
                msg = _Start & msg & _End
                If (lChannels.HaveChannels(_StatusIndex) = True) Then
                    lChannels.AddText_WhereUserExists(_StatusIndex, lWhoisUser, msg)
                Else
                    lStatus.AddText(msg, _StatusIndex)
                End If
            End If
            ResetMessages()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessWhoisCommand(ByVal lStatus As frmServer)")
        End Try
    End Sub

    Public Sub ProcessLUsersCommand(ByVal lStatusIndex As Integer)
        Try
            Dim msg As String, msg2 As String, msg3 As String
            msg2 = ReturnReplacedString(eStringTypes.sLUSERS_BEGIN)
            msg3 = ReturnReplacedString(eStringTypes.sLUSERS_END)
            msg = "-" & vbCrLf & msg2 & Chr(13)
            If Len(Trim(l251)) <> 0 Then msg = msg & l251 & Chr(13)
            If Len(Trim(l252)) <> 0 Then msg = msg & l252 & Chr(13)
            If Len(Trim(l254)) <> 0 Then msg = msg & l254 & Chr(13)
            If Len(Trim(l250)) <> 0 Then msg = msg & l250 & Chr(13)
            If Len(Trim(l253)) <> 0 Then msg = msg & l253 & Chr(13)
            If Len(Trim(l255)) <> 0 Then msg = msg & l255 & Chr(13)
            If Len(Trim(l265)) <> 0 Then msg = msg & l265 & Chr(13)
            If Len(Trim(l266)) <> 0 Then msg = msg & l266 & Chr(13)
            msg = msg & msg3 & Chr(13) & "-"
            lStatus.AddText(msg, lStatusIndex)
            ResetMessages()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessLUsersCommand(ByVal lStatusIndex As Integer)")
        End Try
    End Sub

    Public Sub DoWhois(ByVal lStatusIndex As Integer, ByVal lNick As String)
        Try
            ProcessReplaceString(lStatusIndex, eStringTypes.sWHOIS_WAIT)
            lStatus.SendSocket(lStatusIndex, "WHOIS :" & lNick)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DoWhois(ByVal lStatus As frmServer)")
        End Try
    End Sub

    Public Function ReturnTimeStamp(ByVal lData As String) As String
        Try
            Dim d As DateTime
            d = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            d.AddSeconds(CDbl(Trim(lData)))
            Return d.ToString
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnTimeStamp(ByVal lData As String) As String")
            Return Nothing
        End Try
    End Function

    Public Sub ProcessDataArrivalLine(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, splt2() As String, splt3() As String, splt4() As String, i As Integer, n As Integer, msg As String, msg2 As String, msg3 As String ', _Input As String
            lData = Trim(lData)
            If Left(LCase(lData), 21) = "error :closing link: " Then
                lStatus.CloseStatusConnection(lStatusIndex, False)
                Exit Sub
            End If
            lStatus.Raw_AddText(lStatusIndex, lData, True)
            If Left(LCase(lData), 7) = "version" Then
                If lIRC.iSettings.sExtendedMessages = True Then ProcessReplaceString(lStatusIndex, eStringTypes.sVERSION_REQUEST)
                msg = ReturnReplacedString(eStringTypes.sVERSION_REPLY)
                lStatus.SendSocket(lStatusIndex, msg)
                Exit Sub
            End If
            If Left(LCase(lData), 13) = "notice auth :" Then
                splt2 = Split(lData, ":")
                lStatus.ActiveIndex = lStatusIndex
                If InStr(UCase(splt2(1)), "/QUOTE PASS ") <> 0 Then
                    Dim ps() As String
                    ps = Split(splt2(1), "/")
                    msg = Replace(ps(1), "QUOTE PASS", "")
                    lStatus.DoStatusSocket(lStatusIndex, "PASS " & msg)
                    Exit Sub
                End If
                lStatus.Notices_Add(lStatusIndex, Replace(splt2(1), "***", ""))
                Exit Sub
            End If
            If InStr(LCase(lData), "notice auth :", CompareMethod.Text) <> 0 Then
                splt2 = Split(lData, ":")
                lStatus.Notices_Add(lStatusIndex, splt2(1))
                Exit Sub
            End If
            If Left(LCase(Trim(lData)), 10) = "*** notice" Then
                lStatus.Notices_Add(lStatusIndex, lData)
                Exit Sub
            End If
            If Split(lData, " ")(1) = "NOTICE" Then
                If Left(lData, 27) = ":NickServ!NickServ@services" Then
                    lData = Right(lData, Len(lData) - 29)
                    If Left(lData, 6) = "NOTICE" Then
                        If InStr(LCase(lData), "you are now identified for") <> 0 Then
                            ProcessReplaceString(lStatusIndex, eStringTypes.sNICKSERV_LOGIN, lIRC.iNicks.nNick(lIRC.iNicks.nIndex).nNick)
                            mdiMain.tspQueryPrompt.Visible = False
                        ElseIf InStr(LCase(lData), "nickname is registered") <> 0 Then
                            mdiMain.ShowQueryBar("This nickname is registered, proceed with NickServ login?", mdiMain.eInfoBar.iNickServ_NickTaken)
                            mdiMain.lblQueryPrompt.Tag = 5
                        End If
                    End If
                    Exit Sub
                End If
                splt2 = Split(lData, ":")
                ProcessReplaceString(lStatusIndex, eStringTypes.sNOTICE, splt2(1), splt2(2))
                Exit Sub
            End If
            If Left(LCase(lData), 6) = "ping :" Then
                lStatus.SendSocket(lStatusIndex, "PONG :" & Right(lData, Len(lData) - 6))
                If lIRC.iSettings.sExtendedMessages = True Then lStatus.AddText("Ping? Pong!", lStatusIndex)
                Exit Sub
            End If
            If InStr(LCase(lData), "version") <> 0 Then
                msg = lData
                msg = Trim(Replace(msg, "", ""))
                If LCase(msg) = "version" Then Exit Sub
            End If
            splt = Split(lData, " ")
            If InStr(lData, " 001 ") <> 0 And Left(lData, 1) = ":" Or InStr(lData, " 433 ") <> 0 And Left(lData, 1) = ":" Then
                lStatus.StatusServerName(lStatusIndex) = Replace(splt(0), ":", "")
                lStatus.Caption(lStatusIndex) = lStatus.NickName(lStatusIndex) & " on " & lStatus.StatusServerName(lStatusIndex)
            End If
            If Left(lData, 1) = ":" Then
                If UBound(splt) > 2 Then
                    If Left(splt(3), 1) <> ":" Then
                        splt(3) = ":" & splt(3)
                        msg = ""
                        For i = 0 To UBound(splt)
                            If Len(msg) <> 0 Then
                                msg = msg & " " & splt(i)
                            Else
                                msg = splt(i)
                            End If
                        Next i
                    Else
                        msg = lData
                    End If
                Else
                    msg = ""
                End If
                splt2 = Split(msg, ":")
                If UBound(splt) <> 0 Then
                    If IsNumeric(splt(1)) = True Then
                        Select Case CInt(Trim(splt(1)))
                            Case 1
                                lStatus.DoModes(lStatusIndex)
                                If lIRC.iSettings.sPopupChannelFolders = True Then
                                    lChannelFolder.Show(lStatusIndex)
                                End If
                                l001 = ReturnReplacedString(eStringTypes.sRPL_WELCOME, lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription, splt2(2))
                                Exit Sub
                            Case 2
                                msg2 = Replace(ParseData(splt2(2), "host is ", ","), "ost is ", "")
                                msg2 = Replace(msg2, "host is ", "")
                                msg3 = ParseData(splt2(2), "version ", Right(splt2(2), 2)) & Right(splt2(2), 3)
                                msg3 = Replace(msg3, "ersion", "")
                                msg3 = Replace(msg3, "version", "")
                                l002 = ReturnReplacedString(eStringTypes.sRPL_YOURHOST, msg2, msg3)
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(l001) <> 0 And Len(l002) <> 0 And Len(l003) <> 0 And Len(l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, l001, l002, l003, l004)
                                End If
                                Exit Sub
                            Case 3
                                msg2 = ParseData(splt2(2), "created", CStr(Right(splt2(2), 1)))
                                msg2 = Replace(splt2(2), "reated", "")
                                l003 = ReturnReplacedString(eStringTypes.sRPL_CREATED, msg2)
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(l001) <> 0 And Len(l002) <> 0 And Len(l003) <> 0 And Len(l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, l001, l002, l003, l004)
                                End If
                                Exit Sub
                            Case 4
                                splt3 = Split(splt2(2), " ")
                                l004 = ReturnReplacedString(eStringTypes.sRPL_MYINFO, splt3(0), splt3(1), splt3(2), splt3(3))
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(l001) <> 0 And Len(l002) <> 0 And Len(l003) <> 0 And Len(l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, l001, l002, l003, l004)
                                End If
                                DoNotify(lStatusIndex)
                                Exit Sub
                            Case 5
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISUPPORT, splt2(2))
                                End If
                                ProcessISUPPORT(lData)
                                Exit Sub
                            Case 6
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAP, splt2(2))
                                End If
                                Exit Sub
                            Case 7
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPEND, splt2(2))
                                End If
                                Exit Sub
                            Case 8
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SNOMASK, splt2(2))
                                End If
                                Exit Sub
                            Case 9
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATMEMTOT, splt2(2))
                                End If
                                Exit Sub
                            Case 10
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BOUNCE_2, splt2(2))
                                End If
                                Exit Sub
                            Case 20
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_PLEASEWAIT, splt2(2))
                                End If
                                Exit Sub
                            Case 200
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELINK, splt2(2))
                                End If
                                Exit Sub
                            Case 201
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECONNECTING, splt2(2))
                                End If
                                Exit Sub
                            Case 202
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEHANDSHAKE, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 203
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUNKNOWN, splt3(1), splt3(4))
                                End If
                                Exit Sub
                            Case 204
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEOPERATOR, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 205
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUSER, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 206
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVER, splt3(1), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 207
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVICE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 208
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACENEWTYPE, splt3(0), splt3(2))
                                End If
                                Exit Sub
                            Case 209
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECLASS, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 210
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACERECONNECT, splt2(2))
                                End If
                                Exit Sub
                            Case 211
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLINKINFO, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 212
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCOMMANDS, splt3(0), splt3(1), splt3(2), splt3(3))
                                End If
                                Exit Sub
                            Case 213
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 214
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSNLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 215
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSILINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 216
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSKLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 218
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSYLINE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 219
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFSTATS, splt3(0), Replace(splt3(1), ":", ""))
                                End If
                                Exit Sub
                            Case 221
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UMODEIS, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 234
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLIST, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 235
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLISTEND, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 241
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 242
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSUPTIME, splt2(2))
                                End If
                                Exit Sub
                            Case 243
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSOLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 244
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSHLINE, splt3(1), splt3(3))
                                End If
                                Exit Sub
                            Case 250
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If UBound(splt2) > 2 Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCONN, splt2(3))
                                    End If
                                End If
                                Exit Sub
                            Case 251
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l251 = ReturnReplacedString(eStringTypes.sRPL_LUSERCLIENT, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 252
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l252 = ReturnReplacedString(eStringTypes.sRPL_LUSEROP, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 253
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l253 = ReturnReplacedString(eStringTypes.sRPL_LUSERUNKNOWN, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 254
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    l254 = ReturnReplacedString(eStringTypes.sRPL_LUSERCHANNELS, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 255
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l255 = ReturnReplacedString(eStringTypes.sRPL_LUSERME, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 256
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINME, splt3(0), Replace(splt3(1), ":", ""))
                                End If
                                Exit Sub
                            Case 257
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC1, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 258
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC2, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 259
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINEMAIL, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 261
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELOG, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 262
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEEND, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 263
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRYAGAIN, splt2(3))
                                End If
                                Exit Sub
                            Case 265
                                l265 = ReturnReplacedString(eStringTypes.sRPL_LOCALUSERS, splt2(2) & ": " & splt2(3))
                                If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 266
                                lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False
                                l266 = ReturnReplacedString(eStringTypes.sRPL_GLOBALUSERS, splt2(2) & ": " & splt2(3))
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If lIRC.iSettings.sNoIRCMessages = False Then
                                        ProcessLUsersCommand(lStatusIndex)
                                    End If
                                End If
                                Exit Sub
                            Case 292
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HELP, splt2(2))
                                End If
                                Exit Sub
                            Case 300
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NONE, splt2(2))
                                End If
                                Exit Sub
                            Case 301
                                splt3 = Split(splt2(2), ":")
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_AWAY, splt3(0), splt3(1))
                                Exit Sub
                            Case 302
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(Replace(splt2(2), ":", ""), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERHOST, splt2(2))
                                    Exit Sub
                                End If
                            Case 303
                                splt3 = Split(splt2(2), " ")
                                ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_BEGIN)
                                For i = 0 To UBound(splt3)
                                    If Len(splt3(i)) <> 0 Then
                                        msg2 = splt3(i)
                                        n = FindNotifyIndex(Trim(msg2))
                                        If Len(lNotify.nNotify(n).nNetwork) = 0 Then
                                            ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, lNotify.nNotify(n).nMessage)
                                            lStatus.AddToNotifyList(lStatusIndex, msg2)
                                        Else
                                            If lNotify.nNotify(n).nNetwork = lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription Or Len(LCase(Trim(lNotify.nNotify(n).nNetwork))) <> 0 Then
                                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, lNotify.nNotify(n).nMessage)
                                                lStatus.AddToNotifyList(lStatusIndex, msg2)
                                            End If
                                        End If
                                    End If
                                Next i
                                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_END)
                                Exit Sub
                            Case 305
                                SetAwayStatus(False)
                                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UNAWAY, Replace(splt2(2), ":", ""))
                                Exit Sub
                            Case 306
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    SetAwayStatus(True)
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWAWAY, Replace(splt2(2), ":", ""))
                                    Exit Sub
                                End If
                            Case 311
                                splt3 = Split(Replace(splt2(2), "* :", ""), " ")
                                If Len(Replace(splt3(4), ":", "")) <> 0 Then
                                    l311 = ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), Replace(splt3(4), ":", ""))
                                Else
                                    l311 = ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), "unknown")
                                End If
                                lWhoisUser = splt3(0)
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 312
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    l312 = ReturnReplacedString(eStringTypes.sRPL_WHOISSERVER, Trim(Replace(splt3(1), ":", "")))
                                    If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 313
                                splt3 = Split(splt2(2), ":")
                                l313 = ReturnReplacedString(eStringTypes.sRPL_WHOISOPERATOR, splt3(0), splt3(1))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 314
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt3) = 4 Then ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOWASUSER, splt3(0), splt3(1), splt3(2), Trim(Replace(splt3(4), ":", "")))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 315
                                splt3 = Split(splt2(2), ":")
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHO, splt3(0))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 316
                                l316 = ReturnReplacedString(eStringTypes.sRPL_WHOISCHANOP, splt2(2))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 317
                                splt3 = Split(splt2(2), " ")
                                l317 = ReturnReplacedString(eStringTypes.sRPL_WHOISIDLE, Replace(splt3(1), ":", ""))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 318
                                ProcessWhoisCommand(lStatusIndex)
                                lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                Exit Sub
                            Case 319
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    l319 = ReturnReplacedString(eStringTypes.sRPL_WHOISCHANNELS, splt3(1))
                                End If
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 321
                                lChannelLists.NewChannelList(lStatusIndex)
                                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTSTART)
                                'ProcessReplaceString(lStatusIndex, eStringTypes.sCHANNEL_LIST_WAIT)
                                Exit Sub
                            Case 322
                                lChannelLists.Add(lChannelLists.ReturnChannelListIndex(lStatusIndex), lData)
                                Application.DoEvents()
                                Exit Sub
                            Case 323
                                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTEND)
                                lChannelLists.StatusDescription(lChannelLists.ReturnChannelListIndex(lStatusIndex)) = lStatus.GetObject(lStatusIndex).sDescription
                                lChannelLists.Display(lChannelLists.ReturnChannelListIndex(lStatusIndex))
                                Exit Sub
                            Case 324
                                splt3 = Split(splt2(2), " ")
                                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_CHANNELMODEIS, splt3(0), splt3(1), splt3(2))
                                Exit Sub
                            Case 328
                                splt3 = Split(splt2(2), " ")
                                msg2 = splt2(3) & ":" & splt2(4)
                                msg = ReturnReplacedString(eStringTypes.sRPL_CHANNEL_URL, splt3(0), msg2)
                                i = lChannels.Find(lStatusIndex, splt3(0))
                                lChannels.URL(i) = msg2
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If i <> 0 Then
                                        lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt3(0)), msg)
                                    Else
                                        lStatus.AddText(msg, lStatusIndex)
                                    End If
                                End If
                                If lIRC.iSettings.sAutoNavigateChannelUrls = True And lIRC.iSettings.sShowBrowser = True Then mdiMain.BrowseURL(msg2)
                                Exit Sub
                            Case 331
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOTOPIC, splt2(2))
                                Exit Sub
                            Case 332
                                lChannels.Topic(lStatusIndex, lData)
                                Exit Sub
                            Case 333
                                splt(3) = Trim(Replace(splt(3), ":", ""))
                                msg = ReturnReplacedString(eStringTypes.sRPL_TOPICWHOTIME, splt(3), Trim(splt(4)), ReturnTimeStamp(splt(5)))
                                i = lChannels.Find(lStatusIndex, splt(3))
                                If i <> 0 Then
                                    lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt2(2)), msg)
                                Else
                                    lStatus.AddText(msg, lStatusIndex)
                                End If
                                Exit Sub
                            Case 338
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOISACTUALLY, splt2(2))
                                Exit Sub
                            Case 341
                                splt3 = Split(splt2(2))
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITING, splt3(0), splt3(1))
                                Exit Sub
                            Case 342
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SUMMONING, splt2(3))
                                End If
                                Exit Sub
                            Case 346
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 347
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 348
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_EXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 349
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFEXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 351
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = splt2(3)
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_VERSION, splt3(0), splt3(1), msg)
                                End If
                                Exit Sub
                            Case 352
                                splt3 = Split(splt2(2), " ")
                                splt4 = Split(splt2(3), " ")
                                ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOREPLY, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt4(0), Right(splt2(3), Len(splt2(3)) - Len(splt4(0))))
                                Exit Sub
                            Case 353
                                n = lChannels.Find(lStatusIndex, Trim(splt(4)))
                                If n <> 0 Then
                                    clsLockWindowUpdate.LockWindowUpdate(lChannels.Window(n).Handle)
                                    splt = Split(splt2(3), " ")
                                    For i = 0 To UBound(splt)
                                        If splt(i).Length <> 0 Then lChannels.AddToNickList(n, Trim(splt(i)))
                                    Next i
                                End If
                                Exit Sub
                            Case 364
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt2) <> 2 Then
                                    splt4 = Split(splt2(3), " ")
                                    If lIRC.iSettings.sNoIRCMessages = False Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LINKS, splt3(0), splt3(1), splt4(0), splt4(1))
                                    End If
                                    lStatus.AddToServerLinks(lStatusIndex, splt3(0), "6667")
                                End If
                                Exit Sub
                            Case 365
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFLINKS)
                                End If
                                Exit Sub
                            Case 366
                                clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFNAMES, splt2(2))
                                End If
                                Exit Sub
                            Case 367
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BANLIST, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 368
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFBANLIST, Trim(splt2(2)))
                                End If
                                Exit Sub
                            Case 369
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHOWAS, splt2(2))
                                End If
                                Exit Sub
                            Case 371
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(splt2(2)) <> 0 Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INFO, splt2(2))
                                        Exit Sub
                                    End If
                                End If
                            Case 372
                                If lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, ReturnReplacedString(eStringTypes.sRPL_MOTD, splt2(2)))
                                Else
                                    If lIRC.iSettings.sHideMOTD = False Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTD, splt2(2))
                                    End If
                                End If
                                Exit Sub
                            Case 374
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINFO)
                                End If
                                Exit Sub
                            Case 375
                                If lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, ReturnReplacedString(eStringTypes.sRPL_MOTDSTART, lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription))
                                Else
                                    If lIRC.iSettings.sHideMOTD = False Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTDSTART, lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription)
                                    End If
                                End If
                                Exit Sub
                            Case 376
                                If lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, ReturnReplacedString(eStringTypes.sRPL_ENDOFMOTD))
                                    Exit Sub
                                Else
                                    If lIRC.iSettings.sHideMOTD = False Then
                                        ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFMOTD)
                                    End If
                                End If
                                Exit Sub
                            Case 378
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l378 = ReturnReplacedString(eStringTypes.sRPL_WHOISHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 379
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    l379 = ReturnReplacedString(eStringTypes.sRPL_WHOISMODES, splt2(2))
                                End If
                                Exit Sub
                            Case 381
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOUREOPER, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 382
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_REHASHING, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 383
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOURESERVICE, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 391
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TIME, splt2(2))
                                End If
                                Exit Sub
                            Case 392
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERSSTART)
                                End If
                                Exit Sub
                            Case 393
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERS, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 394
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFUSERS)
                                End If
                                Exit Sub
                            Case 395
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOUSERS)
                                End If
                                Exit Sub
                            Case 396
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HOSTHIDDEN, splt2(2))
                                End If
                                Exit Sub
                            Case 400
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNERROR, splt2(2))
                                End If
                                Exit Sub
                            Case 401
                                lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHNICK, splt2(2))
                                Exit Sub
                            Case 402
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVER, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 403
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHCHANNEL, splt2(2))
                                End If
                                Exit Sub
                            Case 404
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANNOTSENDTOCHAN, splt2(2))
                                End If
                                Exit Sub
                            Case 405
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYCHANNELS, splt2(2))
                                End If
                                Exit Sub
                            Case 406
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WASNOSUCHNICK, splt2(2))
                                End If
                                Exit Sub
                            Case 407
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYTARGETS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 408
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVICE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 409
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOORIGIN, splt2(2))
                                End If
                                Exit Sub
                            Case 411
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NORECIPIENT, splt2(2))
                                End If
                                Exit Sub
                            Case 412
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTEXTTOSEND, splt2(2))
                                End If
                                Exit Sub
                            Case 413
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 414
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WILDTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 415
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADMASK, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 421
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNCOMMAND, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 422
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOMOTD, splt2(2))
                                End If
                                Exit Sub
                            Case 423
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOADMININFO, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 424
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN, splt2(2))
                                End If
                                Exit Sub
                            Case 431
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN)
                                End If
                            Case 432
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ERRONEUSNICKNAME, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 433
                                ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKNAMEINUSE, lStatus.NickName(lStatusIndex))
                                If lIRC.iSettings.sChangeNickNameWindow = True Then
                                    Dim f As New frmChangeNickName
                                    f = New frmChangeNickName
                                    f.lChangeNickName.lServerIndex = lStatusIndex
                                    clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
                                End If
                                Exit Sub
                            Case 436
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKCOLLISION, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 437
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), "/")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNAVAILRESOURCE, splt3(0), splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 439
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TARGETTOOFAST, splt2(2))
                                End If
                                Exit Sub
                            Case 441
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERNOTINCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 442
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTONCHANNEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 443
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERONCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 445
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_SUMMONDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 446
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 451
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTREGISTERED, splt2(2))
                                End If
                                Exit Sub
                            Case 461
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NEEDMOREPARAMS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 462
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ALREADYREGISTERED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 463
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPERMFORHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 464
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_PASSWDMISMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 465
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_YOUREBANNEDCREEP, splt2(2))
                                End If
                                Exit Sub
                            Case 467
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_KEYSET, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 468
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVALIDUSERNAME, lIRC.iRealName, splt2(2))
                                    'Stop
                                    'fweqfweqf()
                                    '_Input = InputBox(
                                    'lStatus.SendSocket(lStatusIndex, "USER " & msg & " 0 * :" & InputBox(lIRC.iRealName, splt(3)))
                                End If
                            Case 470
                                lChannels.Redirect(lStatusIndex, lData)
                            Case 471
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANNELISFULL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 472
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNMODE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 473
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVITEONLYCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 474
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANNEDFROMCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 475
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNELKEY, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 477
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = Right(lData, Len(lData) - (Len(splt2(1)) + Len(splt2(2)) + 2))
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOCHANMODES, msg)
                                End If
                                Exit Sub
                            Case 478
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANLISTFULL, splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 479
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    splt = Split(splt2(2), " ")
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNAME, splt2(3), splt2(4))
                                End If
                                Exit Sub
                            Case 481
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPRIVILEGES, splt2(2))
                                End If
                                Exit Sub
                            Case 482
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANOPRIVSNEEDED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 483
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANTKILLSERVER, splt2(2))
                                End If
                                Exit Sub
                            Case 484
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_RESTRICTED, splt2(2))
                                End If
                                Exit Sub
                            Case 485
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNIQOPRIVSNEEDED, splt2(2))
                                End If
                                Exit Sub
                            Case 491
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOOPERHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 501
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UMODEUNKNOWNFLAG, splt2(2))
                                End If
                                Exit Sub
                            Case 502
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDONTMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 605
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWOFF, splt2(1))
                                End If
                                Exit Sub
                            Case 606
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WATCHLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 607
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWATCHLIST)
                                End If
                                Exit Sub
                            Case 610
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPMORE, splt2(3))
                                End If
                                Exit Sub
                            Case 615
                                l615 = ReturnReplacedString(eStringTypes.sRPL_WHOISMODES2, splt2(3))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 616
                                l616 = ReturnReplacedString(eStringTypes.sRPL_WHOISHOST2, splt2(3))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 999
                                If lIRC.iSettings.sNoIRCMessages = False Then
                                    ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NUMERIC_ERR)
                                End If
                        End Select
                    End If
                End If
            End If
            If Trim(LCase(splt(1))) = "nick" Then
                ':guide__X!~guide_X@71-94-138-127.static.mtpk.ca.charter.com NICK :guide___X
                splt2 = Split(lData, " ")
                splt2(2) = splt2(2).Replace(":", "")
                splt2(0) = ParseData(splt2(0), ":", "!").Replace(":", "").Replace("!", "")
                splt2(1) = lData
                splt2(1) = Left(lData, Len(lData) - (Len(splt2(2)) + 7))
                splt2(1) = Right(splt2(1), Len(splt2(1)) - (Len(splt2(0)) + 2))
                lChannels.SomeoneChangedNickName(splt2(0), splt2(1), splt2(2), lStatusIndex)
            End If
            If Trim(LCase(splt(1))) = "quit" Then
                Dim lQuitProc As New QuitDelegate(AddressOf lChannels.SomeoneQuit)
                lStatus.GetObject(lStatusIndex).sWindow.Invoke(lQuitProc, lStatusIndex, lData)
            End If
            If Trim(LCase(splt(1))) = "nick" Then
                ProcessNickNameChange(lStatusIndex, lData)
                Exit Sub
            End If
            If UBound(splt) <> 0 Then
                Select Case LCase(Trim(splt(1)))
                    Case "join"
                        Dim lJoinProc As New JoinPartDelegate(AddressOf lChannels.SomeoneJoined)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lJoinProc, lStatusIndex, lData)
                        Exit Sub
                    Case "part"
                        Dim lPartProc As New JoinPartDelegate(AddressOf lChannels.SomeoneParted)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lPartProc, lStatusIndex, lData)
                        Exit Sub
                    Case "mode"
                        Dim lChannelModeProc As New StatusDataDelegate(AddressOf lChannels.Mode)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lChannelModeProc, lStatusIndex, lData)
                        Exit Sub
                End Select
                If InStr(UCase(Trim(splt(1))), "PRIVMSG") <> 0 Then
                    If InStr(lData, ":ACTION ") <> 0 Then
                        ActionProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If InStr(UCase(lData), "DCC SEND ") <> 0 Then
                        DCCSendProc(lData)
                        Exit Sub
                    End If
                    If InStr(lData, "DCC CHAT chat") <> 0 Then
                        DCCChatProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If Left(lData, 1) = ":" Then lData = Right(lData, Len(lData) - 1)
                    msg3 = Right(lData, Len(lData) - (Len(splt(0)) + Len(splt(1)) + Len(splt(2)) + 3))
                    msg2 = ParseData(splt(0), ":", "!")
                    msg2 = ReturnReplacedString(eStringTypes.sPRIVMSG, msg2, msg3)
                    i = lChannels.Find(lStatusIndex, splt(2))
                    If i <> 0 Then
                        lChannels.PrivMsg(i, msg2)
                        Exit Sub
                    Else
                        If Trim(msg3) <> "VERSION" Then
                            msg2 = ParseData(splt(0), ":", "!")
                            lStatus.PrivateMessages_Add(lStatusIndex, msg2, Right(splt(0), Len(splt(0)) - (Len(msg2) + 2)), msg3)
                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                If InStr(UCase(Trim(splt(1))), "NOTICE") <> 0 Then
                    msg2 = Right(lData, Len(lData) - (Len(splt(0)) + Len(splt(1)) + Len(splt(2)) + 3))
                    msg2 = Replace(msg2, "***", "")
                    msg2 = Replace(msg2, ":", "")
                    msg3 = ReturnReplacedString(eStringTypes.sNOTICE, Replace(splt(0), ":", ""), msg2)
                    If lIRC.iSettings.sStringSettings.sServerInNotices = False Then
                        msg3 = msg3 & "»"
                        msg3 = ParseData(msg3, ":", "»")
                        msg3 = Replace(msg3, ":", "")
                        msg3 = Replace(msg3, "»", "")
                        msg3 = Trim(msg3)
                    End If
                    If lIRC.iSettings.sNoticesInOwnWindow = True Then
                        lStatus.Notices_Add(lStatusIndex, msg3)
                    Else
                        lStatus.AddText(msg3, lStatusIndex)
                    End If
                    Exit Sub
                End If
            End If
            lStatus.AddToUnknowns(lStatusIndex, lData)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessDataArrivalLine(ByVal lStatusIndex As Integer, ByVal lData As String)")
        End Try
    End Sub

    Public Sub ProcessNickNameChange(_StatusIndex As Integer, _Data As String)
        Dim splt() As String, _OldNick As String, _NewNick As String ', _HostName As String
        Try
            splt = Split(_Data, ":")
            _OldNick = ParseData(_Data, ":", "!")
            _NewNick = ParseData(_Data, "=", " NICK :")
            '_HostName = Right(_Data, Len(_Data) - (Len(splt(1)) + 2))
            'ProcessReplaceString(_StatusIndex, eStringTypes.sNICK_CHANGE, _OldNick, _NewNick, _HostName)
            If _OldNick = lStatus.NickName(_StatusIndex) Then
                lStatus.NickName(_StatusIndex, False) = _NewNick
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessNickNameChange(_StatusIndex As Integer, _Data As String)")
        End Try
    End Sub

    Public Sub ProcessISUPPORT(lData As String)
        Try
            'TODO
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessISUPPORT(lData As String)")
        End Try
    End Sub

    Public Sub ActionProc(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim msg As String, splt() As String
            splt = Split(lData, " ")
            msg = ReturnReplacedString(eStringTypes.sCHANNEL_ACTION, ParseData(lData, ":", "!"), Right(lData, Len(lData) - Len(splt(0) & " " & splt(1) & " " & splt(2) & " " & splt(3))))
            lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt(2)), msg)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ActionProc(ByVal lData As String)")
        End Try
    End Sub

    Public Sub DCCChatProc(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, msg As String
            msg = ParseData(lData, ":", "!")
            splt = Split(lData, " ")
            If lDCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then Exit Sub
            If IsNickNameInDCCIgnoreList(Trim(msg)) = False Then
                If lDCC.dChatPrompt = eDCCPrompt.ePrompt Then
                    Dim lDCCChatPrompt As New frmDCCChatPrompt
                    lDCCChatPrompt.SetInfo(Trim(msg), splt(6), splt(7))
                    lDCCChatPrompt.SetStatusIndex(lStatusIndex)
                    clsAnimate.Animate(lDCCChatPrompt, clsAnimate.Effect.Center, 200, 1)
                ElseIf lDCC.dChatPrompt = eDCCPrompt.eAcceptAll Then
                    Dim lDCCChat As New frmDCCChat
                    lDCCChat.cboUsers.Text = Trim(msg)
                    lDCCChat.SetInfo(splt(6), Trim(splt(7)))
                    clsAnimate.Animate(lDCCChat, clsAnimate.Effect.Center, 200, 1)
                ElseIf lDCC.dChatPrompt = eDCCPrompt.eIgnore Then
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DCCChatProc(ByVal lData As String)")
        End Try
    End Sub

    Public Function ReturnIsFileTypeIgnored(ByVal lFileName As String) As Boolean
        Try
            Dim i As Integer, splt() As String, msg As String
            splt = Split(lFileName, ".")
            msg = LCase(Trim(splt(UBound(splt))))
            With lDCC.dIgnorelist
                For i = 1 To .dCount
                    If .dItem(i).dType = gDCCIgnoreType.dFileTypes Then
                        If LCase(Trim(.dItem(i).dData)) = LCase(Trim(msg)) Then
                            ReturnIsFileTypeIgnored = True
                            Exit For
                        End If
                    End If
                Next i
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnIsFileTypeIgnored(ByVal lFileName As String) As Boolean")
        End Try
    End Function

    Public Function IsUserInNotifyList(ByVal lData As String) As Boolean
        Try
            Dim i As Integer
            For i = 0 To lNotify.nCount
                If LCase(lData) = LCase(lNotify.nNotify(i).nNickName) Then
                    IsUserInNotifyList = True
                    Exit For
                End If
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function IsUserInNotifyList(ByVal lData As String) As Boolean")
        End Try
    End Function

    Public Sub DCCSendProc(ByVal lData As String)
        Try
            Dim lForm As New frmDCCGet, splt() As String, splt2() As String, msg As String
            msg = ParseData(lData, ":", "!")
            splt = Split(lData, " ")
            If lDCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then
                ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Auto Ignore is enabled, and user is unknown '" & msg & "'.")
                Exit Sub
            End If
            If IsNickNameInDCCIgnoreList(msg) = False Then
                If ReturnIsFileTypeIgnored(Trim(splt(5))) = False Then
                    If lDCC.dSendPrompt = eDCCPrompt.ePrompt Then
                        mdiMain.tspDCCToolBar.Items(0).Text = "Accept the file '" & Trim(splt(5)) & "' from the user '" & msg & "'?"
                        mdiMain.tspDCCToolBar.Visible = True
                        mdiMain.lblUser.Tag = msg & vbCrLf & Trim(splt(6)) & vbCrLf & Trim(splt(7)) & vbCrLf & Trim(splt(5)) & vbCrLf & Trim(splt(8))
                    ElseIf lDCC.dSendPrompt = eDCCPrompt.eAcceptAll Then
                        lForm.InitDCCGet(Trim(msg), Trim(splt(6)), Trim(splt(7)), Trim(splt(5)), Trim(splt(8)))
                        clsAnimate.Animate(lForm, clsAnimate.Effect.Center, 200, 1)
                    ElseIf lDCC.dSendPrompt = eDCCPrompt.eIgnore Then
                        ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring all DCC connections")
                    End If
                Else
                    splt2 = Split(msg, ".")
                    ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring file type of '" & splt2(1) & "'.")
                End If
            Else
                ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "User is in ignore list '" & msg & "'.")
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DCCSendProc(ByVal lData As String)")
        End Try
    End Sub

    Public Function IsNickNameInDCCIgnoreList(ByVal lNickName As String) As Boolean
        Try
            Dim i As Integer
            If Len(lNickName) <> 0 Then
                For i = 1 To lDCC.dIgnorelist.dCount
                    With lDCC.dIgnorelist.dItem(i)
                        If LCase(.dData) = LCase(lNickName) Then
                            IsNickNameInDCCIgnoreList = True
                            Exit For
                        End If
                    End With
                Next i
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function IsNickNameInDCCIgnoreList(ByVal lNickName As String) As Boolean")
        End Try
    End Function

    Public Sub DoNotify(ByVal lStatusIndex As Integer)
        Try
            Dim i As Integer, msg As String
            msg = ""
            If lNotify.nCount <> 0 Then
                For i = 1 To lNotify.nCount
                    With lNotify.nNotify(i)
                        If Len(.nNickName) <> 0 Then
                            If LCase(Trim(.nNetwork)) = LCase(Trim(lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription)) Or .nNetwork = "" Then
                                If Len(msg) <> 0 Then
                                    msg = msg & " " & .nNickName
                                Else
                                    msg = .nNickName
                                End If
                            End If
                        End If
                    End With
                Next i
                If Len(msg) <> 0 Then
                    lStatus.SendSocket(lStatusIndex, "ISON " & msg)
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DoNotify(ByVal lStatusIndex As Integer)")
        End Try
    End Sub

    Public Sub ProcessDataArrival(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, i As Integer
            If InStr(lData, vbCrLf) <> 0 Then
                splt = Split(lData, vbCrLf)
                For i = 0 To UBound(splt)
                    lStatus.lIRCMisc.ProcessDataArrivalLine(lStatusIndex, splt(i))
                Next i
            Else
                lStatus.lIRCMisc.ProcessDataArrivalLine(lStatusIndex, lData)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ProcessDataArrival(ByVal lServerIndex As Integer, ByVal lData As String)")
        End Try
    End Sub

    Public Function IPToInteger(ByVal Expression As String) As Integer
        Try
            Dim IPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(Expression)
            With IPAddress
                Return (System.Convert.ToInt32(.GetAddressBytes(3)) << 24) Or (System.Convert.ToInt32(.GetAddressBytes(2)) << 16) Or (System.Convert.ToInt32(.GetAddressBytes(1)) << 8) Or System.Convert.ToInt32(.GetAddressBytes(0))
            End With
        Catch ex As Exception
            Return 0I
        End Try
    End Function

    Public Function IPToString(ByVal Expression As Integer) As String
        Try
            Dim IPAddress As System.Net.IPAddress = New System.Net.IPAddress(System.Convert.ToInt64(Expression))
            Return IPAddress.ToString
        Catch ex As Exception
            Return "0.0.0.0"
        End Try
    End Function
End Class