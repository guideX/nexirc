Option Explicit On
Option Strict On
Imports System
Imports System.Net
Imports nexIRC.IRC.Channels.clsChannel
Imports nexIRC.Classes.UI
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules
Public Class clsIrcNumericHelper
    Public l001 As String, l002 As String, l003 As String, l004 As String, l311 As String, l312 As String, l313 As String, l316 As String, l317 As String, l319 As String, l378 As String, l379 As String, l401 As String, l250 As String, l251 As String, l252 As String, l253 As String, l254 As String, l255 As String, l265 As String, l266 As String, l616 As String, l615 As String, lWhoisUser As String
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
            If lSettings_DCC.lDCC.dRandomizePort = True Then
                If InStr(lSettings_DCC.lDCC.dSendPort, "-") <> 0 Then
                    splt = Split(lSettings_DCC.lDCC.dSendPort, "-")
                    p = GetRnd(CInt(Trim(splt(0))), CInt(Trim(splt(1))))
                Else
                    p = GetRnd(128, 9999)
                End If
            Else
                If InStr(lSettings_DCC.lDCC.dSendPort, "-") <> 0 Then
                    splt = Split(lSettings_DCC.lDCC.dSendPort, "-")
                    p = GetRnd(CInt(Trim(splt(0))), CInt(Trim(splt(1))))
                Else
                    p = CLng(Trim(lSettings_DCC.lDCC.dSendPort))
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
            f.lDccChatUI.SetStatusIndex(lStatus.ActiveIndex)
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
            If lSettings_DCC.lDCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then Exit Sub
            If IsNickNameInDCCIgnoreList(Trim(msg)) = False Then
                If lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.ePrompt Then
                    Dim lDCCChatPrompt As New frmDCCChatPrompt
                    lDCCChatPrompt.SetInfo(Trim(msg), splt(6), splt(7))
                    lDCCChatPrompt.SetStatusIndex(lStatusIndex)
                    clsAnimate.Animate(lDCCChatPrompt, clsAnimate.Effect.Center, 200, 1)
                ElseIf lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll Then
                    Dim lDCCChat As New frmDCCChat
                    lDCCChat.cboUsers.Text = Trim(msg)
                    lDCCChat.lDccChatUI.SetInfo(splt(6), Trim(splt(7)))
                    clsAnimate.Animate(lDCCChat, clsAnimate.Effect.Center, 200, 1)
                ElseIf lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eIgnore Then
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
            With lSettings_DCC.lDCC.dIgnorelist
                For i = 1 To .dCount
                    If .dItem(i).dType = nexIRC.IRC.Settings.clsDCC.gDCCIgnoreType.dFileTypes Then
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
            If lSettings_DCC.lDCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then
                lProcessNumeric.ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Auto Ignore is enabled, and user is unknown '" & msg & "'.")
                Exit Sub
            End If
            If IsNickNameInDCCIgnoreList(msg) = False Then
                If ReturnIsFileTypeIgnored(Trim(splt(5))) = False Then
                    If lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.ePrompt Then
                        mdiMain.tspDCCToolBar.Items(0).Text = "Accept the file '" & Trim(splt(5)) & "' from the user '" & msg & "'?"
                        mdiMain.tspDCCToolBar.Visible = True
                        mdiMain.lblUser.Tag = msg & vbCrLf & Trim(splt(6)) & vbCrLf & Trim(splt(7)) & vbCrLf & Trim(splt(5)) & vbCrLf & Trim(splt(8))
                    ElseIf lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll Then
                        lForm.InitDCCGet(Trim(msg), Trim(splt(6)), Trim(splt(7)), Trim(splt(5)), Trim(splt(8)))
                        clsAnimate.Animate(lForm, clsAnimate.Effect.Center, 200, 1)
                    ElseIf lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eIgnore Then
                        lProcessNumeric.ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring all DCC connections")
                    End If
                Else
                    splt2 = Split(msg, ".")
                    lProcessNumeric.ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring file type of '" & splt2(1) & "'.")
                End If
            Else
                lProcessNumeric.ProcessReplaceStringHelper(lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "User is in ignore list '" & msg & "'.")
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DCCSendProc(ByVal lData As String)")
        End Try
    End Sub

    Public Function IsNickNameInDCCIgnoreList(ByVal lNickName As String) As Boolean
        Try
            Dim i As Integer
            If Len(lNickName) <> 0 Then
                For i = 1 To lSettings_DCC.lDCC.dIgnorelist.dCount
                    With lSettings_DCC.lDCC.dIgnorelist.dItem(i)
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
                    lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, splt(i))
                Next i
            Else
                lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, lData)
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