Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client.IRC.MainWindow.clsMainWindowUI
Imports nexIRC.Client.nexIRC.Client.IRC.Numerics.clsIrcNumerics

Namespace nexIRC.Client.IRC.Numerics
    Public Class clsProcessNumeric
        Private Delegate Sub StatusDataDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
        Private Delegate Sub JoinPartDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
        Private Delegate Sub QuitDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
        Private Delegate Sub ProcessReplaceStringDelegate1(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)
        Public WithEvents lIrcNumericHelper As New clsIrcNumericHelper

        Public Sub ProcessDataArrivalLine(ByVal lStatusIndex As Integer, ByVal lData As String)
            Dim splt() As String, splt2() As String, splt3() As String, splt4() As String, i As Integer, n As Integer, msg As String, msg2 As String, msg3 As String, b As Boolean
            lData = Trim(lData)
            If (lData.Length = 0) Then
                Exit Sub
            End If
            If Left(LCase(lData), 21) = "error :closing link: " Then
                Modules.lStatus.CloseStatusConnection(lStatusIndex, False)
                Exit Sub
            End If
            Modules.lStatus.Raw_AddText(lStatusIndex, lData, True)
            If Left(LCase(lData), 7) = "version" Then
                If Modules.lSettings.lIRC.iSettings.sExtendedMessages = True Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sVERSION_REQUEST)
                msg = Modules.lStrings.ReturnReplacedString(eStringTypes.sVERSION_REPLY)
                Modules.lStatus.SendSocket(lStatusIndex, msg)
                Exit Sub
            End If
            If Left(LCase(lData), 13) = "notice auth :" Then
                splt2 = Split(lData, ":")
                Modules.lStatus.ActiveIndex = lStatusIndex
                If InStr(UCase(splt2(1)), "/QUOTE PASS ") <> 0 Then
                    Dim ps() As String
                    ps = Split(splt2(1), "/")
                    msg = Replace(ps(1), "QUOTE PASS", "")
                    Modules.lStatus.DoStatusSocket(lStatusIndex, "PASS " & msg)
                    Exit Sub
                End If
                Modules.lStatus.Notices_Add(lStatusIndex, Replace(splt2(1), "***", ""))
                Exit Sub
            End If
            If InStr(LCase(lData), "notice auth :", CompareMethod.Text) <> 0 Then
                splt2 = Split(lData, ":")
                Select Case UBound(splt2)
                    Case 1
                        Modules.lStatus.Notices_Add(lStatusIndex, splt2(1))
                    Case 2
                        Modules.lStatus.Notices_Add(lStatusIndex, splt2(1), splt2(2))
                End Select
                Exit Sub
            End If
            If Left(LCase(Trim(lData)), 10) = "*** notice" Then
                Modules.lStatus.Notices_Add(lStatusIndex, lData)
                Exit Sub
            End If
            splt = Split(lData, " ")
            If (UBound(splt) > 0) Then
                If (splt(1) = "NOTICE") Then
                    Dim noticeSource As String = splt(0).Remove(0, 1)
                    Dim noticeNickName As String = splt(2)
                    lData = lData.Remove(0, noticeSource.Length + splt(1).Length + noticeNickName.Length + 5).Trim()
                    If (lData.ToLower().Contains("you are now identified for")) Then
                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNICKSERV_LOGIN, noticeNickName)
                        mdiMain.tspQueryPrompt.Visible = False
                    ElseIf lData.ToLower().Contains("nickname is registered") Then
                        mdiMain.ShowQueryBar("This nickname is registered, proceed with NickServ login?", eInfoBar.iNickServ_NickTaken)
                        mdiMain.lblQueryPrompt.Tag = 5
                    Else
                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sINCOMING_NOTICE, noticeSource, lData)
                    End If
                    Exit Sub
                End If
            End If
            If Left(LCase(lData), 6) = "ping :" Then
                Modules.lStatus.SendSocket(lStatusIndex, "PONG :" & Right(lData, Len(lData) - 6))
                If Modules.lSettings.lIRC.iSettings.sExtendedMessages = True Then Modules.lStatus.AddText("Ping? Pong!", lStatusIndex)
                Exit Sub
            End If
            If InStr(LCase(lData), "version") <> 0 Then
                msg = lData
                msg = Trim(Replace(msg, "", ""))
                If LCase(msg) = "version" Then Exit Sub
            End If
            'splt = Split(lData, " ")
            If InStr(lData, " 001 ") <> 0 And Left(lData, 1) = ":" Or InStr(lData, " 433 ") <> 0 And Left(lData, 1) = ":" Then
                Modules.lStatus.StatusServerName(lStatusIndex) = Replace(splt(0), ":", "")
                Modules.lStatus.UpdateCaption(lStatusIndex, Modules.lStatus.NickName(lStatusIndex), Modules.lStatus.StatusServerName(lStatusIndex))
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
                        Select Case Convert.ToInt32(Trim(splt(1)))
                            Case 1
                                Modules.lStatus.DoModes(lStatusIndex)
                                If Modules.lSettings.lIRC.iSettings.sPopupChannelFolders = True Then
                                    Modules.lChannelFolder.Show(lStatusIndex)
                                End If
                                lIrcNumericHelper.l001 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WELCOME, Modules.IrcSettings.IrcNetworks.GetById(Modules.lStatus.NetworkIndex(lStatusIndex)).Description, splt2(2))
                                Exit Sub
                            Case 2
                                msg2 = Replace(TextHelper.ParseData(splt2(2), "host is ", ","), "ost is ", "")
                                msg2 = Replace(msg2, "host is ", "")
                                msg3 = TextHelper.ParseData(splt2(2), "version ", Right(splt2(2), 2)) & Right(splt2(2), 3)
                                msg3 = Replace(msg3, "ersion", "")
                                msg3 = Replace(msg3, "version", "")
                                lIrcNumericHelper.l002 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_YOURHOST, msg2, msg3)
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then Modules.lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                Exit Sub
                            Case 3
                                msg2 = TextHelper.ParseData(splt2(2), "created", Convert.ToString(Right(splt2(2), 1)))
                                msg2 = Replace(splt2(2), "reated", "")
                                lIrcNumericHelper.l003 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_CREATED, msg2)
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then Modules.lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                Exit Sub
                            Case 4
                                splt3 = Split(splt2(2), " ")
                                lIrcNumericHelper.l004 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_MYINFO, splt3(0), splt3(1), splt3(2), splt3(3))
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then Modules.lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                lIrcNumericHelper.DoNotify(lStatusIndex)
                                Exit Sub
                            Case 5
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISUPPORT, splt2(2))
                                End If
                                'lIrcNumericHelper.ProcessISUPPORT(lData)
                                Exit Sub
                            Case 6
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAP, splt2(2))
                                End If
                                Exit Sub
                            Case 7
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPEND, splt2(2))
                                End If
                                Exit Sub
                            Case 8
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SNOMASK, splt2(2))
                                End If
                                Exit Sub
                            Case 9
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATMEMTOT, splt2(2))
                                End If
                                Exit Sub
                            Case 10
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BOUNCE_2, splt2(2))
                                End If
                                Exit Sub
                            Case 20
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_PLEASEWAIT, splt2(2))
                                End If
                                Exit Sub
                            Case 200
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELINK, splt2(2))
                                End If
                                Exit Sub
                            Case 201
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECONNECTING, splt2(2))
                                End If
                                Exit Sub
                            Case 202
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEHANDSHAKE, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 203
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUNKNOWN, splt3(1), splt3(4))
                                End If
                                Exit Sub
                            Case 204
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEOPERATOR, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 205
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUSER, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 206
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVER, splt3(1), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 207
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVICE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 208
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACENEWTYPE, splt3(0), splt3(2))
                                End If
                                Exit Sub
                            Case 209
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECLASS, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 210
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACERECONNECT, splt2(2))
                                End If
                                Exit Sub
                            Case 211
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLINKINFO, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 212
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCOMMANDS, splt3(0), splt3(1), splt3(2), splt3(3))
                                End If
                                Exit Sub
                            Case 213
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 214
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSNLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 215
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSILINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 216
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSKLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 218
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSYLINE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 219
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFSTATS, splt3(0), Replace(splt3(1), ":", ""))
                                End If
                                Exit Sub
                            Case 221
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UMODEIS, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 234
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLIST, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 235
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLISTEND, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 241
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 242
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSUPTIME, splt2(2))
                                End If
                                Exit Sub
                            Case 243
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSOLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 244
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSHLINE, splt3(1), splt3(3))
                                End If
                                Exit Sub
                            Case 250
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If UBound(splt2) > 2 Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCONN, splt2(3))
                                    End If
                                End If
                                Exit Sub
                            Case 251
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l251 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERCLIENT, splt2(2))
                                    If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 252
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l252 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSEROP, splt2(2))
                                    If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 253
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l253 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERUNKNOWN, splt2(2))
                                    If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 254
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lIrcNumericHelper.l254 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERCHANNELS, splt2(2))
                                    If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 255
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l255 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERME, splt2(2))
                                    If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 256
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINME, splt2(2))
                                End If
                                Exit Sub
                            Case 257
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC1, splt2(2))
                                End If
                                Exit Sub
                            Case 258
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC2, splt2(2))
                                End If
                                Exit Sub
                            Case 259
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINEMAIL, splt2(2))
                                End If
                                Exit Sub
                            Case 261
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELOG, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 262
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEEND, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 263
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRYAGAIN, splt2(3))
                                End If
                                Exit Sub
                            Case 265
                                lIrcNumericHelper.l265 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_LOCALUSERS, splt2(2) & ": " & splt2(3))
                                If Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 266
                                Modules.lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False
                                lIrcNumericHelper.l266 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_GLOBALUSERS, splt2(2) & ": " & splt2(3))
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                        lIrcNumericHelper.ProcessLUsersCommand(lStatusIndex)
                                    End If
                                End If
                                Exit Sub
                            Case 292
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HELP, splt2(2))
                                End If
                                Exit Sub
                            Case 300
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NONE, splt2(2))
                                End If
                                Exit Sub
                            Case 301
                                splt3 = Split(splt2(2), ":")
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_AWAY, splt3(0), splt3(1))
                                Exit Sub
                            Case 302
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(Replace(splt2(2), ":", ""), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERHOST, splt2(2))
                                    Exit Sub
                                End If
                            Case 303
                                splt3 = Split(splt2(2), " ")
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_BEGIN)
                                For i = 0 To UBound(splt3)
                                    If Len(splt3(i)) <> 0 Then
                                        msg2 = splt3(i)
                                        n = Modules.lSettings.FindNotifyIndex(Trim(msg2))
                                        If Len(Modules.lSettings.lNotify.nNotify(n).nNetwork) = 0 Then
                                            Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, Modules.lSettings.lNotify.nNotify(n).nMessage)
                                            Modules.lStatus.AddToNotifyList(lStatusIndex, msg2)
                                        Else
                                            'If Modules.lSettings.lNotify.nNotify(n).nNetwork = Modules.lSettings.lNetworks.nNetwork(Modules.lStatus.NetworkIndex(lStatusIndex)).nDescription Or Len(LCase(Trim(Modules.lSettings.lNotify.nNotify(n).nNetwork))) <> 0 Then
                                            If Modules.lSettings.lNotify.nNotify(n).nNetwork = Modules.IrcSettings.IrcNetworks.GetById(Modules.lStatus.NetworkIndex(lStatusIndex)).Description Or Len(LCase(Trim(Modules.lSettings.lNotify.nNotify(n).nNetwork))) <> 0 Then
                                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, Modules.lSettings.lNotify.nNotify(n).nMessage)
                                                Modules.lStatus.AddToNotifyList(lStatusIndex, msg2)
                                            End If
                                        End If
                                    End If
                                Next i
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_END)
                                Exit Sub
                            Case 305
                                Modules.lSettings.SetAwayStatus(False)
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UNAWAY, Replace(splt2(2), ":", ""))
                                Exit Sub
                            Case 306
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lSettings.SetAwayStatus(True)
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWAWAY, Replace(splt2(2), ":", ""))
                                    Exit Sub
                                End If
                            Case 311
                                splt3 = Split(Replace(splt2(2), "* :", ""), " ")
                                If Len(Replace(splt3(4), ":", "")) <> 0 Then
                                    lIrcNumericHelper.l311 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), Replace(splt3(4), ":", ""))
                                Else
                                    lIrcNumericHelper.l311 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), "unknown")
                                End If
                                lIrcNumericHelper.lWhoisUser = splt3(0)
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 312
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    lIrcNumericHelper.l312 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISSERVER, Trim(Replace(splt3(1), ":", "")))
                                    If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 313
                                splt3 = Split(splt2(2), ":")
                                lIrcNumericHelper.l313 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISOPERATOR, splt3(0), splt3(1))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 314
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt3) = 4 Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOWASUSER, splt3(0), splt3(1), splt3(2), Trim(Replace(splt3(4), ":", "")))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 315
                                splt3 = Split(splt2(2), ":")
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHO, splt3(0))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 316
                                lIrcNumericHelper.l316 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISCHANOP, splt2(2))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 317
                                splt3 = Split(splt2(2), " ")
                                lIrcNumericHelper.l317 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISIDLE, Replace(splt3(1), ":", ""))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 318
                                lIrcNumericHelper.ProcessWhoisCommand(lStatusIndex)
                                Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                Exit Sub
                            Case 319
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    lIrcNumericHelper.l319 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISCHANNELS, splt3(1))
                                End If
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 321
                                Modules.lChannelLists.NewChannelList(lStatusIndex)
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTSTART)
                                'lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sCHANNEL_LIST_WAIT)
                                Exit Sub
                            Case 322
                                Modules.lChannelLists.Add(Modules.lChannelLists.ReturnChannelListIndex(lStatusIndex), lData)
                                Application.DoEvents()
                                Exit Sub
                            Case 323
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTEND)
                                Modules.lChannelLists.StatusDescription(Modules.lChannelLists.ReturnChannelListIndex(lStatusIndex)) = Modules.lStatus.GetObject(lStatusIndex).sDescription
                                Modules.lChannelLists.Display(Modules.lChannelLists.ReturnChannelListIndex(lStatusIndex))
                                Exit Sub
                            Case 324
                                splt3 = Split(splt2(2), " ")
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_CHANNELMODEIS, splt3(0), splt3(1), splt3(2))
                                Exit Sub
                            Case 328
                                splt3 = Split(splt2(2), " ")
                                msg2 = splt2(3) & ":" & splt2(4)
                                msg = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_CHANNEL_URL, splt3(0), msg2)
                                i = Modules.lChannels.Find(lStatusIndex, splt3(0))
                                Modules.lChannels.URL(i) = msg2
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If i <> 0 Then
                                        Modules.lChannels.DoChannelColor(Modules.lChannels.Find(lStatusIndex, splt3(0)), msg)
                                    Else
                                        Modules.lStatus.AddText(msg, lStatusIndex)
                                    End If
                                End If
                                'If lIRC.iSettings.sAutoNavigateChannelUrls = True And lIRC.iSettings.sShowBrowser = True Then mdiMain.BrowseURL(msg2)
                                Exit Sub
                            Case 330

                                Exit Sub
                            Case 331
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOTOPIC, splt2(2))
                                Exit Sub
                            Case 332
                                Modules.lChannels.Topic(lStatusIndex, lData)
                                Exit Sub
                            Case 333
                                splt(3) = Trim(Replace(splt(3), ":", ""))
                                msg = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_TOPICWHOTIME, splt(3), Trim(splt(4)), lIrcNumericHelper.ReturnTimeStamp(splt(5)))
                                i = Modules.lChannels.Find(lStatusIndex, splt(3))
                                If i <> 0 Then
                                    Modules.lChannels.DoChannelColor(Modules.lChannels.Find(lStatusIndex, splt2(2)), msg)
                                Else
                                    Modules.lStatus.AddText(msg, lStatusIndex)
                                End If
                                Exit Sub
                            Case 338
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOISACTUALLY, splt2(2))
                                Exit Sub
                            Case 341
                                splt3 = Split(splt2(2))
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITING, splt3(0), splt3(1))
                                Exit Sub
                            Case 342
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SUMMONING, splt2(3))
                                End If
                                Exit Sub
                            Case 346
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 347
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 348
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_EXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 349
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFEXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 351
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = splt2(3)
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_VERSION, splt3(0), splt3(1), msg)
                                End If
                                Exit Sub
                            Case 352
                                splt3 = Split(splt2(2), " ")
                                splt4 = Split(splt2(3), " ")
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOREPLY, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt4(0), Right(splt2(3), Len(splt2(3)) - Len(splt4(0))))
                                Exit Sub
                            Case 353
                                n = Modules.lChannels.Find(lStatusIndex, Trim(splt(4)))
                                If n <> 0 Then
                                    splt = Split(splt2(3), " ")
                                    For i = 0 To UBound(splt)
                                        If splt(i).Length <> 0 Then Modules.lChannels.AddToNickListQue(n, splt(i).Trim())
                                    Next i
                                End If
                                Exit Sub
                            Case 364
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt2) <> 2 Then
                                    splt4 = Split(splt2(3), " ")
                                    If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LINKS, splt3(0), splt3(1), splt4(0), splt4(1))
                                    End If
                                    Modules.lStatus.AddToServerLinks(lStatusIndex, splt3(0), "6667")
                                End If
                                Exit Sub
                            Case 365
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFLINKS)
                                End If
                                Exit Sub
                            Case 366
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFNAMES, splt2(2))
                                    For ii As Integer = 1 To Modules.lChannels.Count
                                        If (Modules.lChannels.Window(ii) IsNot Nothing) Then
                                            Modules.lChannels.EnableDelayNamesTimer(ii)
                                        End If
                                    Next ii
                                End If
                                Exit Sub
                            Case 367
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BANLIST, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 368
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFBANLIST, Trim(splt2(2)))
                                End If
                                Exit Sub
                            Case 369
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHOWAS, splt2(2))
                                End If
                                Exit Sub
                            Case 371
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(splt2(2)) <> 0 Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INFO, splt2(2))
                                        Exit Sub
                                    End If
                                End If
                            Case 372
                                If Modules.lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    Modules.lStatus.Motd_AddText(lStatusIndex, Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_MOTD, splt2(2)))
                                Else
                                    If Modules.lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTD, splt2(2))
                                    End If
                                End If
                                Exit Sub
                            Case 374
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINFO)
                                End If
                                Exit Sub
                            Case 375
                                If Modules.lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    Modules.lStatus.Motd_AddText(lStatusIndex, Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_MOTDSTART, Modules.IrcSettings.IrcNetworks.GetById(Modules.lStatus.NetworkIndex(lStatusIndex)).Description))
                                Else
                                    If Modules.lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTDSTART, Modules.IrcSettings.IrcNetworks.GetById(Modules.lStatus.NetworkIndex(lStatusIndex)).Description)
                                    End If
                                End If
                                Exit Sub
                            Case 376
                                If Modules.lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    Modules.lStatus.Motd_AddText(lStatusIndex, Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_ENDOFMOTD))
                                    Exit Sub
                                Else
                                    If Modules.lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFMOTD)
                                    End If
                                End If
                                Exit Sub
                            Case 378
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l378 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 379
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l379 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISMODES, splt2(2))
                                End If
                                Exit Sub
                            Case 381
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOUREOPER, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 382
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_REHASHING, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 383
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOURESERVICE, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 391
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TIME, splt2(2))
                                End If
                                Exit Sub
                            Case 392
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERSSTART)
                                End If
                                Exit Sub
                            Case 393
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERS, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 394
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFUSERS)
                                End If
                                Exit Sub
                            Case 395
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOUSERS)
                                End If
                                Exit Sub
                            Case 396
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HOSTHIDDEN, splt2(2))
                                End If
                                Exit Sub
                            Case 400
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNERROR, splt2(2))
                                End If
                                Exit Sub
                            Case 401
                                Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHNICK, splt2(2))
                                Exit Sub
                            Case 402
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVER, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 403
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHCHANNEL, splt2(2))
                                End If
                                Exit Sub
                            Case 404
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANNOTSENDTOCHAN, splt2(2))
                                End If
                                Exit Sub
                            Case 405
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYCHANNELS, splt2(2))
                                End If
                                Exit Sub
                            Case 406
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WASNOSUCHNICK, splt2(2))
                                End If
                                Exit Sub
                            Case 407
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYTARGETS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 408
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVICE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 409
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOORIGIN, splt2(2))
                                End If
                                Exit Sub
                            Case 411
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NORECIPIENT, splt2(2))
                                End If
                                Exit Sub
                            Case 412
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTEXTTOSEND, splt2(2))
                                End If
                                Exit Sub
                            Case 413
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 414
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WILDTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 415
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADMASK, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 421
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNCOMMAND, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 422
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOMOTD, splt2(2))
                                End If
                                Exit Sub
                            Case 423
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOADMININFO, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 424
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN, splt2(2))
                                End If
                                Exit Sub
                            Case 431
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN)
                                End If
                            Case 432
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ERRONEUSNICKNAME, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 433
                                Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKNAMEINUSE, Modules.lStatus.NickName(lStatusIndex))
                                If (Modules.lSettings.lIRC.iSettings.sAutoSelectAlternateNickname) Then
                                    Dim nn = New Random(DateTime.Now.Millisecond).Next(1, Modules.lSettings.lIRC.iNicks.nCount + 1)
                                    Dim newNick = Modules.lSettings.lIRC.iNicks.nNick(nn)
                                    If (Modules.lSettings.lIRC.iNicks.nCount <> 1) Then
                                        b = False
                                        If (Modules.lSettings.lIRC.iSettings.sPrompts) Then
                                            Dim msgboxResult = MessageBox.Show("Change nickname to " & newNick.nNick & "?", "Auto Select Nickname?", MessageBoxButtons.OKCancel)
                                            If (msgboxResult = DialogResult.OK) Then
                                                b = True
                                            End If
                                        Else
                                            b = True
                                        End If
                                        If (b) Then
                                            Modules.lSettings.lIRC.iNicks.nIndex = nn
                                            'lStatus.NickName(lStatusIndex, True) = Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick
                                            Modules.lStatus.NickName(lStatusIndex, True) = newNick.nNick
                                        End If
                                    End If
                                Else
                                    If Modules.lSettings.lIRC.iSettings.sChangeNickNameWindow = True Then
                                        Dim f As New frmChangeNickName
                                        f = New frmChangeNickName
                                        f.ChangeNickName.ServerIndex = lStatusIndex
                                        f.Show()
                                    Else
                                        If (Modules.lSettings.lIRC.iSettings.sPrompts) Then
                                            mdiMain.ShowQueryBar("Nickname '" & Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick & "' is taken, select another?", eInfoBar.iNicknameInUse)
                                        End If
                                    End If
                                End If
                                Exit Sub
                            Case 436
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKCOLLISION, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 437
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), "/")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNAVAILRESOURCE, splt3(0), splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 439
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TARGETTOOFAST, splt2(2))
                                End If
                                Exit Sub
                            Case 441
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERNOTINCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 442
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTONCHANNEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 443
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERONCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 445
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_SUMMONDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 446
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 451
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTREGISTERED, splt2(2))
                                End If
                                Exit Sub
                            Case 461
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NEEDMOREPARAMS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 462
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ALREADYREGISTERED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 463
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPERMFORHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 464
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_PASSWDMISMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 465
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_YOUREBANNEDCREEP, splt2(2))
                                End If
                                Exit Sub
                            Case 467
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_KEYSET, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 468
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVALIDUSERNAME, Modules.lSettings.lIRC.iRealName, splt2(2))
                                End If
                            Case 470
                                Modules.lChannels.Redirect(lStatusIndex, lData)
                            Case 471
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANNELISFULL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 472
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNMODE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 473
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVITEONLYCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 474
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANNEDFROMCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 475
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNELKEY, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 477
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = Right(lData, Len(lData) - (Len(splt2(1)) + Len(splt2(2)) + 2))
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOCHANMODES, msg)
                                End If
                                Exit Sub
                            Case 478
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANLISTFULL, splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 479
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt = Split(splt2(2), " ")
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNAME, splt2(3), splt2(4))
                                End If
                                Exit Sub
                            Case 481
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPRIVILEGES, splt2(2))
                                End If
                                Exit Sub
                            Case 482
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANOPRIVSNEEDED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 483
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANTKILLSERVER, splt2(2))
                                End If
                                Exit Sub
                            Case 484
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_RESTRICTED, splt2(2))
                                End If
                                Exit Sub
                            Case 485
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNIQOPRIVSNEEDED, splt2(2))
                                End If
                                Exit Sub
                            Case 491
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOOPERHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 501
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UMODEUNKNOWNFLAG, splt2(2))
                                End If
                                Exit Sub
                            Case 502
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDONTMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 605
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWOFF, splt2(1))
                                End If
                                Exit Sub
                            Case 606
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WATCHLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 607
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWATCHLIST)
                                End If
                                Exit Sub
                            Case 610
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPMORE, splt2(3))
                                End If
                                Exit Sub
                            Case 615
                                lIrcNumericHelper.l615 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISMODES2, splt2(3))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 616
                                lIrcNumericHelper.l616 = Modules.lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISHOST2, splt2(3))
                                If Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then Modules.lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 999
                                If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    Modules.lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NUMERIC_ERR)
                                End If
                        End Select
                    End If
                End If
            End If
            If (UBound(splt) > 0) Then
                If Trim(LCase(splt(1))) = "nick" Then
                    splt2 = Split(lData, " ")
                    splt2(2) = splt2(2).Replace(":", "")
                    splt2(0) = TextHelper.ParseData(splt2(0), ":", "!").Replace(":", "").Replace("!", "")
                    splt2(1) = lData
                    splt2(1) = Left(lData, Len(lData) - (Len(splt2(2)) + 7))
                    splt2(1) = Right(splt2(1), Len(splt2(1)) - (Len(splt2(0)) + 2))
                    Modules.lChannels.SomeoneChangedNickName(splt2(0), splt2(1), splt2(2), lStatusIndex)
                End If
                If Trim(LCase(splt(1))) = "quit" Then
                    Dim lQuitProc As New QuitDelegate(AddressOf Modules.lChannels.SomeoneQuit)
                    Modules.lStatus.GetObject(lStatusIndex).sWindow.Invoke(lQuitProc, lStatusIndex, lData)
                End If
                If Trim(LCase(splt(1))) = "nick" Then
                    lIrcNumericHelper.ProcessNickNameChange(lStatusIndex, lData)
                    Exit Sub
                End If
                Select Case LCase(Trim(splt(1)))
                    Case "join"
                        Dim lJoinProc As New JoinPartDelegate(AddressOf Modules.lChannels.SomeoneJoined)
                        Modules.lStatus.GetObject(lStatusIndex).sWindow.Invoke(lJoinProc, lStatusIndex, lData)
                        Exit Sub
                    Case "part"
                        Dim lPartProc As New JoinPartDelegate(AddressOf Modules.lChannels.SomeoneParted)
                        Modules.lStatus.GetObject(lStatusIndex).sWindow.Invoke(lPartProc, lStatusIndex, lData)
                        Exit Sub
                    Case "mode"
                        Dim lChannelModeProc As New StatusDataDelegate(AddressOf Modules.lChannels.Mode)
                        Modules.lStatus.GetObject(lStatusIndex).sWindow.Invoke(lChannelModeProc, lStatusIndex, lData)
                        Exit Sub
                End Select
                If InStr(UCase(Trim(splt(1))), "PRIVMSG") <> 0 Then
                    If InStr(lData, ":ACTION ") <> 0 Then
                        lIrcNumericHelper.ActionProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If InStr(UCase(lData), "DCC SEND ") <> 0 Then
                        lIrcNumericHelper.DCCSendProc(lData)
                        Exit Sub
                    End If
                    If InStr(lData, "DCC CHAT chat") <> 0 Then
                        lIrcNumericHelper.DCCChatProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If Left(lData, 1) = ":" Then lData = Right(lData, Len(lData) - 1)
                    msg3 = Right(lData, Len(lData) - (Len(splt(0)) + Len(splt(1)) + Len(splt(2)) + 3))
                    msg2 = TextHelper.ParseData(splt(0), ":", "!")
                    msg2 = Modules.lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, msg2, msg3)
                    i = Modules.lChannels.Find(lStatusIndex, splt(2))
                    If i <> 0 Then
                        Modules.lChannels.PrivMsg(i, msg2)
                        Exit Sub
                    Else
                        If Trim(msg3) <> "VERSION" Then
                            msg2 = TextHelper.ParseData(splt(0), ":", "!")
                            Modules.lStatus.PrivateMessage_Add(lStatusIndex, msg2, Right(splt(0), Len(splt(0)) - (Len(msg2) + 2)), msg3)
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
                    msg3 = Modules.lStrings.ReturnReplacedString(eStringTypes.sNOTICE, Replace(splt(0), ":", ""), msg2)
                    'If lIRC.iSettings.sStringSettings.sServerInNotices = False Then
                    'msg3 = msg3 & "»"
                    'msg3 = ParseData(msg3, ":", "»")
                    'msg3 = Replace(msg3, ":", "")
                    'msg3 = Replace(msg3, "»", "")
                    'msg3 = Trim(msg3)
                    'End If
                    If Modules.lSettings.lIRC.iSettings.sNoticesInOwnWindow = True Then
                        Modules.lStatus.Notices_Add(lStatusIndex, msg3)
                    Else
                        Modules.lStatus.AddText(msg3, lStatusIndex)
                    End If
                    Exit Sub
                End If
            End If
            Modules.lStatus.AddToUnknowns(lStatusIndex, lData)
        End Sub

        Public Sub ProcessReplaceStringHelper(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)
            Dim ProcessReplaceString As New ProcessReplaceStringDelegate1(AddressOf Modules.lStrings.ProcessReplaceString)
            Modules.lStatus.GetObject(lStatusIndex).sWindow.Invoke(ProcessReplaceString, lStatusIndex, lType, r1)
        End Sub
    End Class
End Namespace