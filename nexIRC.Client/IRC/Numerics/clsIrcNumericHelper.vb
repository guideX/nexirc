Option Explicit On
Option Strict On
Imports System.Net
Imports nexIRC.Business.Enums
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client.IRC.Numerics.clsIrcNumerics
Imports nexIRC.Client.nexIRC.Client.Modules

Namespace nexIRC.Client.IRC.Numerics
    Public Class clsIrcNumericHelper
        Public l001 As String, l002 As String, l003 As String, l004 As String, l311 As String, l312 As String, l313 As String, l316 As String, l317 As String, l319 As String, l378 As String, l379 As String, l401 As String, l250 As String, l251 As String, l252 As String, l253 As String, l254 As String, l255 As String, l265 As String, l266 As String, l616 As String, l615 As String, lWhoisUser As String

        Public Sub clsIrcNumericHelper()
        End Sub

        Public Sub ResetMessages()
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
        End Sub
        Public Function ReturnDCCPort() As Long
            Dim splt() As String, p As Long
            If Modules.lSettings_DCC.dRandomizePort = True Then
                If (Modules.lSettings_DCC.dSendPort.Contains("-")) Then
                    splt = Split(Modules.lSettings_DCC.dSendPort, "-")
                    p = TextHelper.GetRnd(Convert.ToInt32(splt(0).Trim()), Convert.ToInt32(splt(1).Trim()))
                Else
                    p = TextHelper.GetRnd(128, 9999)
                End If
            Else
                If (Modules.lSettings_DCC.dSendPort.Contains("-")) Then
                    splt = Split(Modules.lSettings_DCC.dSendPort, "-")
                    p = TextHelper.GetRnd(Convert.ToInt32(splt(0).Trim()), Convert.ToInt32(splt(1).Trim()))
                Else
                    p = Convert.ToInt64(Modules.lSettings_DCC.dSendPort.Trim())
                End If
            End If
            ReturnDCCPort = p
        End Function
        Public Function ReturnRandomNetworkIndex(ByVal excludeIndex As Integer) As Integer
            Dim result As Integer
            Dim n As Integer, b As Boolean
            If (excludeIndex <> 0) Then
                Do Until b = True
                    'n = Convert.ToInt32(TextHelper.GetRnd(1, Modules.lSettings.lNetworks.nCount))
                    n = Convert.ToInt32(TextHelper.GetRnd(1, Modules.IrcSettings.IrcNetworks.Count()))
                    If (n <> excludeIndex) Then b = True
                Loop
                result = n
            End If
            Return result
        End Function
        Public Sub NewDCCChat()
            Dim f As frmDCCChat
            f = New frmDCCChat
            f.lDccChatUI.SetStatusIndex(Modules.lStatus.ActiveIndex)
            f.Show()
        End Sub
        Public Sub NewDCCSend()
            Dim f As frmDCCSend
            f = New frmDCCSend
            f.SetStatusIndex(Modules.lStatus.ActiveIndex)
            f.Show()
        End Sub

        Public Function ReturnMyIp() As String
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
            ReturnMyIp = (CType(h.AddressList.GetValue(0), IPAddress).ToString)
        End Function

        Public Sub ProcessWhoisCommand(ByVal _StatusIndex As Integer)
            Dim msg As String = "", _Start As String, _End As String
            _Start = Modules.lStrings.ReturnReplacedString(eStringTypes.sWHOIS_START).Trim & Environment.NewLine
            _End = Modules.lStrings.ReturnReplacedString(eStringTypes.sWHOIS_END).Trim
            If Len(l311) <> 0 Then msg = msg & l311 & Environment.NewLine
            If Len(l312) <> 0 Then msg = msg & l312 & Environment.NewLine
            If Len(l313) <> 0 Then msg = msg & l313 & Environment.NewLine
            If Len(l316) <> 0 Then msg = msg & l316 & Environment.NewLine
            If Len(l317) <> 0 Then msg = msg & l317 & Environment.NewLine
            If Len(l319) <> 0 Then msg = msg & l319 & Environment.NewLine
            If Len(l378) <> 0 Then msg = msg & l378 & Environment.NewLine
            If Len(l379) <> 0 Then msg = msg & l379 & Environment.NewLine
            If Len(l401) <> 0 Then msg = msg & l401 & Environment.NewLine
            If Len(l615) <> 0 Then msg = msg & l615 & Environment.NewLine
            If Len(l616) <> 0 Then msg = msg & l616 & Environment.NewLine
            If Len(msg) <> 0 Then
                msg = _Start & msg & _End
                If (mdlObjects.lChannels.HaveChannels(_StatusIndex) = True) Then
                    mdlObjects.lChannels.AddText_WhereUserExists(_StatusIndex, lWhoisUser, msg)
                Else
                    Modules.lStatus.AddText(msg, _StatusIndex)
                End If
            End If
            ResetMessages()
        End Sub
        Public Sub ProcessLUsersCommand(ByVal lStatusIndex As Integer)
            Dim msg As String, msg2 As String, msg3 As String
            msg2 = Modules.lStrings.ReturnReplacedString(eStringTypes.sLUSERS_BEGIN)
            msg3 = Modules.lStrings.ReturnReplacedString(eStringTypes.sLUSERS_END)
            msg = "-" & Environment.NewLine & msg2 & Chr(13)
            If Len(Trim(l251)) <> 0 Then msg = msg & l251 & Chr(13)
            If Len(Trim(l252)) <> 0 Then msg = msg & l252 & Chr(13)
            If Len(Trim(l254)) <> 0 Then msg = msg & l254 & Chr(13)
            If Len(Trim(l250)) <> 0 Then msg = msg & l250 & Chr(13)
            If Len(Trim(l253)) <> 0 Then msg = msg & l253 & Chr(13)
            If Len(Trim(l255)) <> 0 Then msg = msg & l255 & Chr(13)
            If Len(Trim(l265)) <> 0 Then msg = msg & l265 & Chr(13)
            If Len(Trim(l266)) <> 0 Then msg = msg & l266 & Chr(13)
            msg = msg & msg3 & Chr(13) & "-"
            Modules.lStatus.AddText(msg, lStatusIndex)
            ResetMessages()
        End Sub
        Public Sub DoWhois(ByVal lStatusIndex As Integer, ByVal lNick As String)
            Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sWHOIS_WAIT)
            Modules.lStatus.SendSocket(lStatusIndex, "WHOIS :" & lNick)
        End Sub
        Public Function ReturnTimeStamp(ByVal lData As String) As String
            Dim d As DateTime
            d = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            d.AddSeconds(CDbl(Trim(lData)))
            Return d.ToString
        End Function
        Public Sub ProcessNickNameChange(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Dim splt() As String, _OldNick As String, _NewNick As String ', _HostName As String
            splt = Split(_Data, ":")
            _OldNick = TextHelper.ParseData(_Data, ":", "!")
            _NewNick = TextHelper.ParseData(_Data, "=", " NICK :")
            '_HostName = Right(_Data, Len(_Data) - (Len(splt(1)) + 2))
            'ProcessReplaceString(_StatusIndex, eStringTypes.sNICK_CHANGE, _OldNick, _NewNick, _HostName)
            If _OldNick = Modules.lStatus.NickName(_StatusIndex) Then
                Modules.lStatus.NickName(_StatusIndex, False) = _NewNick
            End If
        End Sub

        Public Sub ActionProc(ByVal lStatusIndex As Integer, ByVal lData As String)
            Dim msg As String, splt() As String
            splt = Split(lData, " ")
            msg = Modules.lStrings.ReturnReplacedString(eStringTypes.sCHANNEL_ACTION, TextHelper.ParseData(lData, ":", "!"), Right(lData, Len(lData) - Len(splt(0) & " " & splt(1) & " " & splt(2) & " " & splt(3))))
            mdlObjects.lChannels.DoChannelColor(mdlObjects.lChannels.Find(lStatusIndex, splt(2)), msg)
        End Sub

        Public Sub DCCChatProc(ByVal lStatusIndex As Integer, ByVal lData As String)
            Dim splt() As String, msg As String
            msg = TextHelper.ParseData(lData, ":", "!")
            splt = Split(lData, " ")
            If Modules.lSettings_DCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then Exit Sub
            If IsNickNameInDCCIgnoreList(Trim(msg)) = False Then
                If Modules.lSettings_DCC.ChatPrompt = DccPrompt.Prompt Then
                    Dim lDCCChatPrompt As New frmDccChatPrompt
                    lDCCChatPrompt.SetInfo(Trim(msg), splt(6), splt(7))
                    lDCCChatPrompt.SetStatusIndex(lStatusIndex)
                    lDCCChatPrompt.Show()
                ElseIf Modules.lSettings_DCC.ChatPrompt = DccPrompt.AcceptAll Then
                    Dim lDCCChat As New frmDCCChat
                    lDCCChat.cboUsers.Text = Trim(msg)
                    lDCCChat.lDccChatUI.SetInfo(splt(6), Trim(splt(7)))
                    lDCCChat.Show()
                ElseIf Modules.lSettings_DCC.ChatPrompt = DccPrompt.Ignore Then
                End If
            End If
        End Sub

        Public Function ReturnIsFileTypeIgnored(ByVal fileName As String) As Boolean
            Dim result As Boolean
            Dim i As Integer, splt() As String, msg As String
            splt = Split(fileName, ".")
            msg = splt(UBound(splt)).Trim().ToLower()
            With Modules.lSettings_DCC.IgnoreList
                For i = 1 To .Count
                    If (.Items(i).Type = DCCIgnoreType.FileTypes) Then
                        If (.Items(i).Data.Trim().ToLower() = msg.Trim().ToLower()) Then
                            result = True
                            Exit For
                        End If
                    End If
                Next i
            End With
            Return result
        End Function

        Public Function IsUserInNotifyList(ByVal lData As String) As Boolean
            Dim result As Boolean
            Dim i As Integer
            For i = 0 To Modules.lSettings.lNotify.nCount
                If (lData.ToLower() = Modules.lSettings.lNotify.nNotify(i).nNickName.ToLower()) Then
                    result = True
                    Exit For
                End If
            Next i
            Return result
        End Function

        Public Sub DCCSendProc(ByVal lData As String)
            Dim lForm As New frmDccGet, splt() As String, splt2() As String, msg As String
            msg = TextHelper.ParseData(lData, ":", "!")
            splt = Split(lData, " ")
            If Modules.lSettings_DCC.dAutoIgnore = True And IsUserInNotifyList(msg) = False Then
                Modules.lProcessNumeric.ProcessReplaceStringHelper(Modules.lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Auto Ignore is enabled, and user is unknown '" & msg & "'.")
                Exit Sub
            End If
            If IsNickNameInDCCIgnoreList(msg) = False Then
                If ReturnIsFileTypeIgnored(Trim(splt(5))) = False Then
                    If Modules.lSettings_DCC.SendPrompt = DccPrompt.Prompt Then
                        mdiMain.tspDCCToolBar.Items(0).Text = "Accept the file '" & Trim(splt(5)) & "' from the user '" & msg & "'?"
                        mdiMain.tspDCCToolBar.Visible = True
                        mdiMain.lblUser.Tag = msg & Environment.NewLine & Trim(splt(6)) & Environment.NewLine & Trim(splt(7)) & Environment.NewLine & Trim(splt(5)) & Environment.NewLine & Trim(splt(8))
                    ElseIf Modules.lSettings_DCC.SendPrompt = DccPrompt.AcceptAll Then
                        lForm.InitDCCGet(Trim(msg), Trim(splt(6)), Trim(splt(7)), Trim(splt(5)), Trim(splt(8)))
                        'animate.Animate(lForm, animate.Effect.Center, 200, 1)
                        lForm.Show()
                    ElseIf Modules.lSettings_DCC.SendPrompt = DccPrompt.Ignore Then
                        Modules.lProcessNumeric.ProcessReplaceStringHelper(Modules.lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring all DCC connections")
                    End If
                Else
                    splt2 = Split(msg, ".")
                    Modules.lProcessNumeric.ProcessReplaceStringHelper(Modules.lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "Ignoring file type of '" & splt2(1) & "'.")
                End If
            Else
                Modules.lProcessNumeric.ProcessReplaceStringHelper(Modules.lStatus.ActiveIndex, eStringTypes.sDCC_DENIED, "User is in ignore list '" & msg & "'.")
            End If
        End Sub

        Public Function IsNickNameInDCCIgnoreList(ByVal lNickName As String) As Boolean
            Dim result As Boolean
            Dim i As Integer
            If lNickName.Length() <> 0 Then
                For i = 1 To Modules.lSettings_DCC.IgnoreList.Count
                    With Modules.lSettings_DCC.IgnoreList.Items(i)
                        If (.Data.ToLower() = lNickName.ToLower()) Then
                            result = True
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        End Function

        Public Sub DoNotify(ByVal lStatusIndex As Integer)
            Dim i As Integer, msg As String
            msg = ""
            If Modules.lSettings.lNotify.nCount <> 0 Then
                For i = 1 To Modules.lSettings.lNotify.nCount
                    With Modules.lSettings.lNotify.nNotify(i)
                        If Len(.nNickName) <> 0 Then
                            If (.nNetwork.Trim().ToLower() = Modules.IrcSettings.IrcNetworks.GetById(Modules.lStatus.NetworkIndex(lStatusIndex)).Description Or .nNetwork = "") Then
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
                    Modules.lStatus.SendSocket(lStatusIndex, "ISON " & msg)
                End If
            End If
        End Sub

        Public Sub ProcessDataArrival(ByVal lStatusIndex As Integer, ByVal lData As String)
            Dim splt() As String, i As Integer
            If InStr(lData, Environment.NewLine) <> 0 Then
                splt = Split(lData, Environment.NewLine)
                For i = 0 To UBound(splt)
                    Modules.lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, splt(i))
                Next i
            Else
                Modules.lProcessNumeric.ProcessDataArrivalLine(lStatusIndex, lData)
            End If
        End Sub

        Public Function IPToInteger(ByVal Expression As String) As Integer
            Dim IPAddress As System.Net.IPAddress = System.Net.IPAddress.Parse(Expression)
            With IPAddress
                Return (System.Convert.ToInt32(.GetAddressBytes(3)) << 24) Or (System.Convert.ToInt32(.GetAddressBytes(2)) << 16) Or (System.Convert.ToInt32(.GetAddressBytes(1)) << 8) Or System.Convert.ToInt32(.GetAddressBytes(0))
            End With
        End Function

        Public Function IPToString(ByVal Expression As Integer) As String
            Dim IPAddress As System.Net.IPAddress = New System.Net.IPAddress(System.Convert.ToInt64(Expression))
            Return IPAddress.ToString
        End Function
    End Class
End Namespace