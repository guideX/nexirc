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
            Throw ex
        End Try
    End Sub
    Public Function ReturnDCCPort() As Long
        Try
            Dim splt() As String, p As Long
            If lSettings_DCC.lDCC.dRandomizePort = True Then
                If (lSettings_DCC.lDCC.dSendPort.Contains("-")) Then
                    splt = Split(lSettings_DCC.lDCC.dSendPort, "-")
                    p = lStrings.GetRnd(Convert.ToInt32(splt(0).Trim()), Convert.ToInt32(splt(1).Trim()))
                Else
                    p = lStrings.GetRnd(128, 9999)
                End If
            Else
                If (lSettings_DCC.lDCC.dSendPort.Contains("-")) Then
                    splt = Split(lSettings_DCC.lDCC.dSendPort, "-")
                    p = lStrings.GetRnd(Convert.ToInt32(splt(0).Trim()), Convert.ToInt32(splt(1).Trim()))
                Else
                    p = Convert.ToInt64(lSettings_DCC.lDCC.dSendPort.Trim())
                End If
            End If
            ReturnDCCPort = p
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function ReturnRandomNetworkIndex(ByVal excludeIndex As Integer) As Integer
        Dim result As Integer
        Try
            Dim n As Integer, b As Boolean
            If (excludeIndex <> 0) Then
                Do Until b = True
                    n = Convert.ToInt32(lStrings.GetRnd(1, lSettings.lNetworks.nCount))
                    If (n <> excludeIndex) Then b = True
                Loop
                result = n
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Sub NewDCCChat()
        Try
            Dim f As frmDCCChat
            f = New frmDCCChat
            f.lDccChatUI.SetStatusIndex(lStatus.ActiveIndex)
            f.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub NewDCCSend()
        Try
            Dim f As frmDCCSend
            f = New frmDCCSend
            f.SetStatusIndex(lStatus.ActiveIndex)
            f.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ReturnMyIp() As String
        Try
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
            ReturnMyIp = (CType(h.AddressList.GetValue(0), IPAddress).ToString)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub ProcessWhoisCommand(ByVal _StatusIndex As Integer)
        Try
            Dim msg As String = "", _Start As String, _End As String
            _Start = lStrings.ReturnReplacedString(eStringTypes.sWHOIS_START).Trim & Environment.Newline
            _End = lStrings.ReturnReplacedString(eStringTypes.sWHOIS_END).Trim
            If Len(l311) <> 0 Then msg = msg & l311 & Environment.Newline
            If Len(l312) <> 0 Then msg = msg & l312 & Environment.Newline
            If Len(l313) <> 0 Then msg = msg & l313 & Environment.Newline
            If Len(l316) <> 0 Then msg = msg & l316 & Environment.Newline
            If Len(l317) <> 0 Then msg = msg & l317 & Environment.Newline
            If Len(l319) <> 0 Then msg = msg & l319 & Environment.Newline
            If Len(l378) <> 0 Then msg = msg & l378 & Environment.Newline
            If Len(l379) <> 0 Then msg = msg & l379 & Environment.Newline
            If Len(l401) <> 0 Then msg = msg & l401 & Environment.Newline
            If Len(l615) <> 0 Then msg = msg & l615 & Environment.Newline
            If Len(l616) <> 0 Then msg = msg & l616 & Environment.Newline
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
            Throw ex
        End Try
    End Sub
    Public Sub ProcessLUsersCommand(ByVal lStatusIndex As Integer)
        Try
            Dim msg As String, msg2 As String, msg3 As String
            msg2 = lStrings.ReturnReplacedString(eStringTypes.sLUSERS_BEGIN)
            msg3 = lStrings.ReturnReplacedString(eStringTypes.sLUSERS_END)
            msg = "-" & Environment.Newline & msg2 & Chr(13)
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
            Throw ex
        End Try
    End Sub
    Public Sub DoWhois(ByVal lStatusIndex As Integer, ByVal lNick As String)
        Try
            lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sWHOIS_WAIT)
            lStatus.SendSocket(lStatusIndex, "WHOIS :" & lNick)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ReturnTimeStamp(ByVal lData As String) As String
        Try
            Dim d As DateTime
            d = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            d.AddSeconds(CDbl(Trim(lData)))
            Return d.ToString
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Sub ProcessNickNameChange(_StatusIndex As Integer, _Data As String)
        Dim splt() As String, _OldNick As String, _NewNick As String ', _HostName As String
        Try
            splt = Split(_Data, ":")
            _OldNick = lStrings.ParseData(_Data, ":", "!")
            _NewNick = lStrings.ParseData(_Data, "=", " NICK :")
            '_HostName = Right(_Data, Len(_Data) - (Len(splt(1)) + 2))
            'ProcessReplaceString(_StatusIndex, eStringTypes.sNICK_CHANGE, _OldNick, _NewNick, _HostName)
            If _OldNick = lStatus.NickName(_StatusIndex) Then
                lStatus.NickName(_StatusIndex, False) = _NewNick
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ProcessISUPPORT(lData As String)
        Try
            'TODO
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActionProc(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim msg As String, splt() As String
            splt = Split(lData, " ")
            msg = lStrings.ReturnReplacedString(eStringTypes.sCHANNEL_ACTION, lStrings.ParseData(lData, ":", "!"), Right(lData, Len(lData) - Len(splt(0) & " " & splt(1) & " " & splt(2) & " " & splt(3))))
            lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt(2)), msg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DCCChatProc(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, msg As String
            msg = lStrings.ParseData(lData, ":", "!")
            splt = Split(lData, " ")
            If lSettings_DCC.lDCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then Exit Sub
            If IsNickNameInDCCIgnoreList(Trim(msg)) = False Then
                If lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.ePrompt Then
                    Dim lDCCChatPrompt As New frmDCCChatPrompt
                    lDCCChatPrompt.SetInfo(Trim(msg), splt(6), splt(7))
                    lDCCChatPrompt.SetStatusIndex(lStatusIndex)
                    lDCCChatPrompt.Show()
                ElseIf lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll Then
                    Dim lDCCChat As New frmDCCChat
                    lDCCChat.cboUsers.Text = Trim(msg)
                    lDCCChat.lDccChatUI.SetInfo(splt(6), Trim(splt(7)))
                    lDCCChat.Show()
                ElseIf lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eIgnore Then
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ReturnIsFileTypeIgnored(ByVal fileName As String) As Boolean
        Dim result As Boolean
        Try
            Dim i As Integer, splt() As String, msg As String
            splt = Split(fileName, ".")
            msg = splt(UBound(splt)).Trim().ToLower()
            With lSettings_DCC.lDCC.dIgnorelist
                For i = 1 To .dCount
                    If (.dItem(i).dType = nexIRC.IRC.Settings.clsDCC.gDCCIgnoreType.dFileTypes) Then
                        If (.dItem(i).dData.Trim().ToLower() = msg.Trim().ToLower()) Then
                            result = True
                            Exit For
                        End If
                    End If
                Next i
            End With
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function IsUserInNotifyList(ByVal lData As String) As Boolean
        Dim result As Boolean
        Try
            Dim i As Integer
            For i = 0 To lSettings.lNotify.nCount
                If (lData.ToLower() = lSettings.lNotify.nNotify(i).nNickName.ToLower()) Then
                    result = True
                    Exit For
                End If
            Next i
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub DCCSendProc(ByVal lData As String)
        Try
            Dim lForm As New frmDCCGet, splt() As String, splt2() As String, msg As String
            msg = lStrings.ParseData(lData, ":", "!")
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
                        mdiMain.lblUser.Tag = msg & Environment.Newline & Trim(splt(6)) & Environment.Newline & Trim(splt(7)) & Environment.Newline & Trim(splt(5)) & Environment.Newline & Trim(splt(8))
                    ElseIf lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll Then
                        lForm.InitDCCGet(Trim(msg), Trim(splt(6)), Trim(splt(7)), Trim(splt(5)), Trim(splt(8)))
                        'animate.Animate(lForm, animate.Effect.Center, 200, 1)
                        lForm.Show()
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
            Throw ex
        End Try
    End Sub

    Public Function IsNickNameInDCCIgnoreList(ByVal lNickName As String) As Boolean
        Dim result As Boolean
        Try
            Dim i As Integer
            If lNickName.Length() <> 0 Then
                For i = 1 To lSettings_DCC.lDCC.dIgnorelist.dCount
                    With lSettings_DCC.lDCC.dIgnorelist.dItem(i)
                        If (.dData.ToLower() = lNickName.ToLower()) Then
                            result = True
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub DoNotify(ByVal lStatusIndex As Integer)
        Try
            Dim i As Integer, msg As String
            msg = ""
            If lSettings.lNotify.nCount <> 0 Then
                For i = 1 To lSettings.lNotify.nCount
                    With lSettings.lNotify.nNotify(i)
                        If Len(.nNickName) <> 0 Then
                            If LCase(Trim(.nNetwork)) = LCase(Trim(lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription)) Or .nNetwork = "" Then
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
            Throw ex
        End Try
    End Sub

    Public Sub ProcessDataArrival(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, i As Integer
            If InStr(lData, Environment.Newline) <> 0 Then
                splt = Split(lData, Environment.Newline)
                For i = 0 To UBound(splt)
                    lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, splt(i))
                Next i
            Else
                lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, lData)
            End If
        Catch ex As Exception
            Throw ex
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