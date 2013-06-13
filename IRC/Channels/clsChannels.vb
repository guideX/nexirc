'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Namespace IRC.Channels
    Public Class clsChannel
        Public Event ProcessError(_Error As String, _Sub As String)
        'Public Structure gNickList
        Public nCount As Integer
        'Public nItem() As String
        'End Structure
        Public Structure gChannel
            Public cName As String
            Public cURL As String
            Public cWindow As frmChannel
            Public cVisible As Boolean
            Public cTreeNode As TreeNode
            Public cTreeNodeVisible As Boolean
            Public cIncomingText As String
            'Public cNickList As gNickList
            Public cStatusIndex As Integer
            Public cWindowBarItem As ToolStripItem
            Public cWindowBarItemVisible As Boolean
        End Structure
        Public Structure gChannels
            Public cCount As Integer
            Public cIndex As Integer
            Public cChannel() As gChannel
        End Structure
        Public Structure gChannelCollection
            Public cChannel() As Integer
            Public cCount As Integer
        End Structure
        Private lChannels As gChannels
        Public Sub AddToNickList(_ChannelIndex As Integer, ByVal _NickName As String)
            'Try
            Dim _NickListItem As ListViewItem, _Exists As Boolean = False
            With lChannels.cChannel(_ChannelIndex)
                For Each _NickListItem In .cWindow.lvwNicklist.Items
                    If (_NickListItem.Text.ToLower().Trim().Replace("@", "").Replace("@", "") = _NickName.ToLower().Trim().Replace("@", "").Replace("@", "")) Then
                        _Exists = True
                        Exit For
                    End If
                Next _NickListItem
                If _Exists = False Then
                    _NickListItem = .cWindow.lvwNicklist.Items.Add(_NickName)
                    If InStr(_NickListItem.Text, "@") <> 0 Then
                        _NickListItem.ForeColor = Color.Red
                    ElseIf InStr(_NickListItem.Text, "+") <> 0 Then
                        _NickListItem.ForeColor = Color.DarkGreen
                    Else
                        _NickListItem.ForeColor = Color.White
                    End If
                End If
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub AddToChannelNickList(ByVal lIndex As Integer, ByVal lNickName As String)")
            'End Try
        End Sub
        Public Sub Minimize(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cWindow.WindowState = FormWindowState.Minimized
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub HideChannelWindow(ByVal lIndex As Integer)")
            'End Try
        End Sub
        Public Sub PrivMsg(_ChannelIndex As Integer, ByVal _Data As String)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cIncomingText = _Data & vbCrLf & .cIncomingText
                'mdiMain.lFlashWindow.FlashOnce()
                If .cVisible = True Then
                    DoChannelColor(_ChannelIndex, _Data)
                Else
                    If .cTreeNode.ImageIndex <> 9 Then .cTreeNode.ImageIndex = 9
                    If .cTreeNode.SelectedImageIndex <> 9 Then .cTreeNode.SelectedImageIndex = 9
                End If
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub DoChannelPrivMsg(ByVal lChannelIndex As Integer, ByVal lData As String)")
            'End Try
        End Sub
        Public Sub DoChannelColor(_ChannelIndex As Integer, ByVal _Data As String)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                DoColor(_Data, .cWindow.txtIncomingColor)
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub DoChannelColor(ByVal lStatusIndex As Integer, ByVal lChannelName As String, ByVal lData As String)")
            'End Try
        End Sub
        Public Sub Window_Closing(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                lIRC.iSettings.sWindowSizes.iChannel.wWidth = .cWindow.Width
                lIRC.iSettings.sWindowSizes.iChannel.wHeight = .cWindow.Height
                SaveWindowSizes()
                If lStatus.Closing() = False Then
                    SetChannelVisible(_ChannelIndex, False)
                End If
            End With
            'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Window_Closing(_ChannelIndex As Integer)")
            'End Try
        End Sub
        Public Sub Window_Load(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex).cWindow
                .Icon = mdiMain.Icon
                .MdiParent = mdiMain
                .tmrGetNames.Enabled = True
                .lvwNicklist.Columns.Add("Nickname", 80)
                .Width = lIRC.iSettings.sWindowSizes.iChannel.wWidth
                .Height = lIRC.iSettings.sWindowSizes.iChannel.wHeight
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Window_Load(_ChannelIndex As Integer)")
            'End Try
        End Sub
        Public Sub Window_Resize(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex).cWindow
                .txtIncomingColor.Width = .ClientSize.Width - .lvwNicklist.Width
                .txtIncomingColor.Height = .ClientSize.Height - (.txtOutgoing.Height + .tspChannel.ClientSize.Height)
                .txtOutgoing.Width = .ClientSize.Width
                .txtOutgoing.Top = .txtIncomingColor.Height + .tspChannel.ClientSize.Height
                .lvwNicklist.Left = .txtIncomingColor.Width
                .lvwNicklist.Height = .txtIncomingColor.Height
                .lvwNicklist.Top = .txtIncomingColor.Top
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Window_Resize()")
            'End Try
        End Sub
        Public Sub Outgoing_GotFocus(_ChannelIndex As Integer)
            Try
                With lChannels.cChannel(_ChannelIndex)
                    If lIRC.iSettings.sAutoMaximize = True Then .cWindow.WindowState = FormWindowState.Maximized
                    lChannels.cIndex = _ChannelIndex
                    lStatus.ActiveIndex = .cStatusIndex
                End With
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Sub Outgoing_GotFocus(_ChannelIndex As Integer)")
            End Try
        End Sub
        Public Sub Outgoing_KeyDown(_ChannelIndex As Integer, _KeyCode As Integer)
            'Try
            Dim msg As String, msg2 As String
            With lChannels.cChannel(_ChannelIndex)
                If _KeyCode = 13 Then
                    msg = .cWindow.txtOutgoing.Text
                    .cWindow.txtOutgoing.Text = ""
                    If LeftRight(msg, 0, 1) = "/" Then
                        lStatus.ProcessUserInput(lChannels.cChannel(_ChannelIndex).cStatusIndex, msg)
                    Else
                        lStatus.DoStatusSocket(lChannels.cChannel(_ChannelIndex).cStatusIndex, "PRIVMSG " & lChannels.cChannel(_ChannelIndex).cName & " :" & msg)
                        msg2 = ReturnReplacedString(eStringTypes.sPRIVMSG, lStatus.NickName(lChannels.cChannel(_ChannelIndex).cStatusIndex), msg)
                        DoChannelColor(_ChannelIndex, msg2)
                    End If
                End If
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Outgoing_KeyDown(_ChannelIndex As Integer, _TextBox As TextBox, _KeyCode As Integer)")
            'End Try
        End Sub
        Public Function StatusIndex(_ChannelIndex As Integer) As Integer
            'Try
            Return lChannels.cChannel(_ChannelIndex).cStatusIndex
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Function StatusIndex(_ChannelIndex As Integer) As Integer")
            'End Try
        End Function
        Public Sub SetChannelVisible(_ChannelIndex As Integer, ByVal _Visible As Boolean)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cVisible = _Visible
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Shared Sub SetChannelVisible(_Channel As gChannel, ByVal _Visible As Boolean)")
            'End Try
        End Sub
        Public Sub NickList_DoubleClick(_ChannelIndex As Integer)
            'Try
            Dim msg As String
            With lChannels.cChannel(_ChannelIndex)
                msg = Replace(.cWindow.lvwNicklist.SelectedItems(0).Text, "+", "")
                msg = Replace(msg, "@", "")
                lStatus.PrivateMessages_Initialize(.cStatusIndex, msg)
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub NickList_DoubleClick(_ChannelIndex As Integer)")
            'End Try
        End Sub
        Public Sub Users_DoubleClick(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                Dim msg As String
                msg = Replace(.cWindow.lvwNicklist.Text, "+", "")
                msg = Replace(.cWindow.lvwNicklist.Text, "@", "")
                lStatus.PrivateMessages_Initialize(.cStatusIndex, msg)
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Users_DoubleClick(_ChannelIndex As Integer)")
            'End Try
        End Sub
        Public Sub CreateWindow(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cWindow = New frmChannel
                .cWindow.Show()
                LockWindowUpdate(.cWindow.Handle)
                '.cWindow.txtIncomingColor.BackColor = System.Drawing.Color.FromArgb(RGB(233, 240, 249))
                .cWindow.lMdiChildWindow.Form_Load(.cWindow.txtIncomingColor, .cWindow.txtOutgoing, .cWindow, clsMdiChildWindow.eFormTypes.fChannel)
                .cWindow.lMdiChildWindow.SetFormType(clsMdiChildWindow.eFormTypes.fChannel)
                .cWindow.lMdiChildWindow.MeIndex = _ChannelIndex
                .cWindow.Text = .cName
                LockWindowUpdate(IntPtr.Zero)
                'clsAnimate.Animate(.cWindow, clsAnimate.Effect.Center, 200, 1)
                '.cWindow.MdiParent = mdiMain
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub NewChannelWindow(_Channel As gChannel)")
            'End Try
        End Sub
        Public Sub ResetForeMostWindows()
            'Try
            For i As Integer = 1 To lChannels.cCount
                lChannels.cChannel(i).cWindow.lMdiChildWindow.lForeMost = False
            Next i
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub ResetForeMostWindows()")
            'End Try
        End Sub
        Public Sub ToggleChannelWindowState(_ChannelIndex As Integer, _ForeMost As Boolean)
            'Try
            With lChannels.cChannel(_ChannelIndex).cWindow
                If .WindowState = FormWindowState.Normal = True Then
                    If _ForeMost = True Then
                        .WindowState = FormWindowState.Minimized
                    Else
                        .Focus()
                    End If
                ElseIf .WindowState = FormWindowState.Maximized Then
                    If _ForeMost = True Then
                        .WindowState = FormWindowState.Minimized
                    Else
                        .Focus()
                    End If
                ElseIf .WindowState = FormWindowState.Minimized Then
                    .WindowState = FormWindowState.Normal
                End If
            End With
            'End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub ToggleChannelWindowState(_Channel As gChannel)")
            'End Try
        End Sub
        Public Sub AddText_WhereUserExists(_StatusIndex As Integer, _NickName As String, _Text As String)
            'Try
            If (_StatusIndex <> 0 Or _NickName.Trim().Length() = 0) Then
                For _ChannelIndex As Integer = 1 To lChannels.cCount
                    For n As Integer = 0 To lChannels.cChannel(_ChannelIndex).cWindow.lvwNicklist.Items.Count - 1
                        If (lChannels.cChannel(_ChannelIndex).cWindow.lvwNicklist.Items(n).Text.Trim().ToLower.Replace("@", "").Replace("+", "") = _NickName.Trim().ToLower.Replace("@", "").Replace("+", "")) Then
                            DoChannelColor(_ChannelIndex, _Text)
                        End If
                    Next n
                Next _ChannelIndex
            End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub AddText_WhereUserExists(_StatusIndex As Integer, _NickName As String)")
            'End Try
        End Sub
        Public Function HaveChannels(_StatusIndex As Integer) As Boolean
            'Try
            Dim _Result As Boolean = False
            For i As Integer = 1 To lChannels.cCount
                If lChannels.cChannel(i).cStatusIndex = _StatusIndex Then _Result = True
            Next i
            Return _Result
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Function HaveChannels(_StatusIndex As Integer) As Boolean")
            'Return Nothing
            'End Try
        End Function
        Public Sub RemoveTree(_ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cTreeNode.Remove()
                .cTreeNodeVisible = False
                mdiMain.tspWindows.Items.Remove(.cWindowBarItem)
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Shared Sub RemoveChannelTree(_Channel As gChannel)")
            'End Try
        End Sub
        'Public Sub Recall(_ChannelIndex As Integer)
        'Try
        'Dim i As Integer
        'With lChannels.cChannel(_ChannelIndex)
        'For i = 1 To .cNickList.nCount
        'If Len(.cNickList.nItem(i)) <> 0 Then
        '.cWindow.lvwNicklist.Items.Add(.cNickList.nItem(i))
        'End If
        'Next i
        'If Len(.cIncomingText) <> 0 Then
        'DoChannelColor(_ChannelIndex, .cIncomingText)
        'End If
        'End With
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Public Shared Sub RecallChannelData(_Channel As gChannel)")
        'End Try
        'If Err.Number <> 0 Then 'RaiseEvent ProcessError(ex.Message, "Public Sub RecallChannelData(ByVal lChannelIndex As Integer)")
        'End Sub
        Public Sub Redirect(_StatusIndex As Integer, _Data As String)
            'Try
            Dim _ChannelA As String, _ChannelB As String, splt() As String, _NickName As String
            splt = _Data.Split(Convert.ToChar(" "))
            _NickName = splt(2)
            _ChannelA = splt(3)
            _ChannelB = splt(4)
            If (_NickName.ToLower = lStatus.NickName(_StatusIndex).ToLower()) Then
                If (lIRC.iSettings.sPrompts = True) Then
                    mdiMain.lblRedirectMessage.Text = "Notice: You have been redirected from '" & _ChannelA & "' to '" & _ChannelB & "'."
                    mdiMain.lblRedirectMessage.Tag = _StatusIndex.ToString()
                    mdiMain.tmrHideRedirect.Enabled = True
                    mdiMain.tspRedirect.Visible = True
                Else
                    Join(_StatusIndex, _ChannelB)
                End If
                If lIRC.iSettings.sNoIRCMessages = False Then ProcessReplaceString(_StatusIndex, eStringTypes.sERR_LINKCHANNEL, _ChannelA, _ChannelB)
                'Join(_StatusIndex, _ChannelB)
            End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub Redirect(_StatusIndex As Integer, _Data As String)")
            'End Try
        End Sub
        Public Sub SomeoneChangedNickName(_OldNickName As String, _HostName As String, _NickName As String, _StatusIndex As Integer)
            'Try
            For Each lChannel As gChannel In lChannels.cChannel
                If (lChannel.cStatusIndex = _StatusIndex) Then
                    For Each lListViewItem As ListViewItem In lChannel.cWindow.lvwNicklist.Items
                        If (lListViewItem.Text = _OldNickName) Then
                            lListViewItem.Text = _NickName
                            DoColor(ReturnReplacedString(eStringTypes.sNICK_CHANGE, _OldNickName, _HostName, _NickName), lChannel.cWindow.txtIncomingColor)
                        End If
                    Next lListViewItem
                End If
            Next lChannel
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub SomeoneChangedNickName(_OldNickName As String, _HostName As String, _NickName As String, _StatusIndex As Integer)")
            'End Try
        End Sub
        Public Sub SomeoneJoined(ByVal _StatusIndex As Integer, ByVal _Data As String)
            ':guide_X!~guide_X@pool-108-13-216-135.lsanca.fios.verizon.net JOIN #testerama
            'Try
            Dim _NickName As String, _IpAddress As String, _Channel As String, _TextToDisplay As String, _ChannelIndex As Integer
            _NickName = ParseData(_Data, ":", "!")
            _IpAddress = ParseData(_Data, "~", " JOIN ")
            If InStr(UCase(_Data), " JOIN :#") <> 0 Then
                _Channel = Right(_Data, Len(_Data) - (InStr(Right(_Data, Len(_Data) - 1), ":", CompareMethod.Text) + 1))
            ElseIf InStr(UCase(_Data), " JOIN #") <> 0 Then
                _Channel = Right(_Data, Len(_Data) - (InStr(Right(_Data, Len(_Data) - 1), " JOIN ", CompareMethod.Text) + 1))
                If InStr(_Channel, "JOIN") <> 0 Then _Channel = Replace(_Channel, "JOIN", "")
                _Channel = Trim(_Channel)
            Else
                Exit Sub
            End If
            If LCase(Trim(_NickName)) = LCase(Trim(lStatus.NickName(_StatusIndex))) Then
                _ChannelIndex = Add(_Channel, _StatusIndex)
                CreateWindow(_ChannelIndex)
                DoChannelColor(_ChannelIndex, ReturnReplacedString(eStringTypes.sYOUJOIN, _Channel))
                AddToChannelFolders(_Channel, lStatus.NetworkIndex(_StatusIndex))
                lChannelFolder.RefreshChannelFolderChannelList()
            Else
                If lIRC.iSettings.sShowUserAddresses = True Then
                    _TextToDisplay = ReturnReplacedString(eStringTypes.sUSER_JOINED, _NickName & " (" & _IpAddress & ")", _Channel)
                Else
                    _TextToDisplay = ReturnReplacedString(eStringTypes.sUSER_JOINED, _NickName, _Channel)
                End If
                _ChannelIndex = Find(_StatusIndex, _Channel)
                With lChannels.cChannel(_ChannelIndex)
                    DoChannelColor(_ChannelIndex, _TextToDisplay)
                    AddToNickList(_ChannelIndex, _NickName)
                End With
            End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub JoinProc(ByVal lStatusIndex As Integer, ByVal lData As String)")
            'End Try
        End Sub
        Public Sub RemoveFromNickList(_ChannelIndex As Integer, ByVal _NickName As String)
            'Try
            Dim i As Integer, _NickListText As String
            If Len(_NickName) <> 0 Then
                With lChannels.cChannel(_ChannelIndex)
                    For i = 0 To .cWindow.lvwNicklist.Items.Count - 1
                        _NickListText = .cWindow.lvwNicklist.Items(i).Text
                        If LCase(Trim(_NickListText)) = LCase(Trim(_NickName)) Or LCase(Trim(_NickListText)) = LCase(Trim("@" & _NickName)) Or LCase(Trim(_NickListText)) = LCase(Trim("+" & _NickName)) Then
                            .cWindow.lvwNicklist.Items.RemoveAt(i)
                        End If
                    Next i
                End With
            End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub RemoveNickNameFromNicklist(ByVal lIndex As Integer, ByVal lNickName As String)")
            'End Try
        End Sub
        Public Sub SomeoneQuit(ByVal _StatusIndex As Integer, ByVal _Data As String)
            'Try
            ':guide_X!~guide_X@pool-108-13-216-135.lsanca.fios.verizon.net QUIT :Client Quit
            Dim splt3() As String = Split(_Data, "QUIT :")
            Dim splt2() As String, _QuitMessage As String = "", _HostName As String = "", _NickName As String, i As Integer, n As Integer = 0
            _NickName = ParseData(_Data, ":", "!")
            splt2 = _Data.Split(Convert.ToChar(" "))
            _QuitMessage = splt3(1)
            _HostName = splt2(0).Replace(":", "").Trim()
            For i = 1 To lChannels.cCount
                For n = 0 To lChannels.cChannel(i).cWindow.lvwNicklist.Items.Count - 1
                    If lChannels.cChannel(i).cWindow.lvwNicklist.Items(n).Text.Trim.ToLower.Replace("@", "").Replace("+", "") = _NickName.Trim.ToLower.Replace("@", "").Replace("+", "") Then
                        RemoveFromNickList(Find(_StatusIndex, lChannels.cChannel(i).cName), _NickName)
                        DoChannelColor(i, ReturnReplacedString(eStringTypes.sUSER_QUIT, _NickName, _HostName, _QuitMessage))
                    End If
                Next n
            Next i
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub SomeoneQuit(ByVal lStatusIndex As Integer, ByVal lData As String)")
            'End Try
        End Sub
        Public Sub SomeoneParted(ByVal _StatusIndex As Integer, ByVal _Data As String)
            'Try
            Dim splt() As String, splt2(), _NickName As String, _ChannelName As String, _HostName As String, _ChannelIndex As Integer, _TextToDisplay As String
            _NickName = ""
            _ChannelName = ""
            _HostName = ""
            splt = _Data.Split(Convert.ToChar(" "))
            If (UBound(splt)) = 2 Then
                _ChannelName = splt(2)
                splt2 = splt(0).Split(Convert.ToChar("@"))
                If UBound(splt2) = 1 Then
                    _NickName = splt2(0)
                    _NickName = ParseData(_NickName, ":", "!")
                    _HostName = Split(splt2(0), "~")(1) & "@" & splt2(1)
                End If
            End If
            _ChannelIndex = Find(_StatusIndex, _ChannelName)
            If _NickName.Trim() = lStatus.NickName(_StatusIndex).Trim() Then
                With lChannels.cChannel(_ChannelIndex)
                    .cIncomingText = ""
                    .cName = ""
                    '.cNickList.nCount = 0
                    'ReDim .cNickList.nItem(lArraySizes.aNickList)
                    .cStatusIndex = 0
                    If .cVisible = True Then .cWindow.Close()
                    .cTreeNode.Remove()
                    .cTreeNode = Nothing
                    .cTreeNodeVisible = False
                    .cWindowBarItem = Nothing
                    .cWindowBarItemVisible = False
                End With
            Else
                RemoveFromNickList(Find(_StatusIndex, _ChannelName), _NickName)
                If lIRC.iSettings.sShowUserAddresses = True Then
                    _TextToDisplay = ReturnReplacedString(eStringTypes.sUSER_PARTED, _NickName & " (" & _HostName & ")", _ChannelName)
                Else
                    _TextToDisplay = ReturnReplacedString(eStringTypes.sUSER_PARTED, _NickName, _ChannelName)
                End If
                DoChannelColor(Find(_StatusIndex, _ChannelName), _TextToDisplay)
            End If
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub PartProc(ByVal lStatusIndex As Integer, ByVal lData As String)")
            'End Try
        End Sub
        Public Function Find(ByVal _StatusIndex As Integer, ByVal _ChannelName As String) As Integer
            'Try
            Dim i As Integer, _Result As Integer
            If Len(_ChannelName) <> 0 Then
                For i = 1 To lChannels.cCount
                    With lChannels.cChannel(i)
                        If Trim(LCase(_ChannelName)) = Trim(LCase(.cName)) And _StatusIndex = .cStatusIndex Then
                            _Result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return _Result
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Shared Function Find(ByVal lStatusIndex As Integer, ByVal lChannelName As String) As Integer")
            'Return Nothing
            'End Try
        End Function
        Public Sub Delete(ByVal _ChannelIndex As Integer)
            'Try
            With lChannels.cChannel(_ChannelIndex)
                .cName = ""
                If .cTreeNodeVisible = True Then .cTreeNode.Remove()
                .cTreeNode = Nothing
                .cTreeNodeVisible = False
                .cWindow = Nothing
                .cVisible = False
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub KillChannel(ByVal lIndex As Integer)")
            'End Try
        End Sub

        Public Sub Join(ByVal lStatusIndex As Integer, ByVal lChannelName As String)
            'Try
            If lStatusIndex <> 0 And Len(lChannelName) <> 0 Then lStatus.SendSocket(lStatusIndex, "JOIN " & lChannelName)
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub JoinChannel(ByVal lStatusIndex As Integer, ByVal lChannelName As String)")
            'End Try
        End Sub
        Public Sub ClearAll(_StatusIndex As Integer)
            'Try
            For _ChannelIndex As Integer = 1 To lChannels.cCount
                With lChannels.cChannel(_ChannelIndex)
                    If .cStatusIndex = _StatusIndex Then
                        If .cVisible = True Then .cWindow.Close()
                        .cTreeNodeVisible = False
                        .cTreeNode = Nothing
                        .cName = ""
                        'ReDim .cNickList.nItem(lArraySizes.aNickList)
                        '.cNickList.nCount = 0
                        .cVisible = False
                        .cWindow = Nothing
                        .cStatusIndex = 0
                    End If
                End With
            Next _ChannelIndex
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub ClearAllChannels(_StatusIndex As Integer)")
            'End Try
        End Sub
        Public Sub Topic(_StatusIndex As Integer, _Data As String)
            'Try
            Dim splt() As String = Split(_Data.Trim(), ":"), splt2() As String, _Message As String, _Channel As String, _ChannelIndex As Integer = 0
            splt2 = Split(splt(1), " ")
            _Channel = splt2(3)
            _Message = Right(_Data, Len(_Data) - splt(1).Length() - 2)
            _ChannelIndex = Find(_StatusIndex, _Channel)
            With lChannels.cChannel(_ChannelIndex)
                DoColor(ReturnReplacedString(eStringTypes.sRPL_TOPIC, _Channel, _Message), .cWindow.txtIncomingColor)
                .cWindow.Text = _Channel & ": " & StripColorCodes(_Message)
            End With
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub ChannelTopicMessage(_StatusIndex As Integer, _Data As String)")
            'End Try
        End Sub
        Private Function Add(_Name As String, _StatusIndex As Integer) As Integer
            'Try
            lChannels.cCount = lChannels.cCount + 1
            ReDim Preserve lChannels.cChannel(lChannels.cCount)
            With lChannels.cChannel(lChannels.cCount)
                .cName = _Name
                .cStatusIndex = _StatusIndex
                .cTreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add(_Name, _Name, 1, 1)
                .cTreeNodeVisible = True
                .cWindowBarItem = mdiMain.AddWindowBar(.cName, mdiMain.gWindowBarImageTypes.wChannel)
                .cWindowBarItem.Tag = Trim(.cStatusIndex.ToString)
                .cWindowBarItemVisible = True
            End With
            Return lChannels.cCount
            'NewChannelWindow(_StatusIndex, lChannels.cCount)
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub AddChannel(_Channel As gChannel)")
            'End Try
        End Function
        'Public Function ReturnChannelsUserIsIn(_StatusIndex As Integer, ByVal _NickName As String) As List(Of Integer)
        'Try
        'Dim c As New gChannelCollection, _Result As List(Of Integer) = New List(Of Integer)
        'If Len(_NickName) <> 0 Then
        'ReDim c.cChannel(lArraySizes.aChannelWindows)
        'For _ChannelIndex As Integer = 1 To lChannels.cCount
        'With lChannels.cChannel(_ChannelIndex)
        'For _NicklistIndex As Integer = 1 To .cNickList.nCount
        'If (.cNickList.nItem(_NicklistIndex).Trim().ToLower() = _NickName.Trim().ToLower()) Then
        '_Result.Add(_NicklistIndex)
        'End If
        'Next _NicklistIndex
        'End With
        'Next _ChannelIndex
        'Return _Result
        'Else
        'Return New List(Of Integer)
        'End If
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Public Function ReturnChannelUserIsIn(ByVal lNickName As String) As gChannelCollection")
        'Return Nothing
        'End Try
        'End Function
        Public Property CurrentIndex() As Integer
            Get
                'Try
                Return lChannels.cIndex
                'Catch ex As Exception
                'Return Nothing
                'RaiseEvent ProcessError(ex.Message, "Public Property CurrentIndex(ByVal lIndex As Integer) As Integer")
                'End Try
            End Get
            Set(ByVal lValue As Integer)
                'Try
                lChannels.cIndex = lValue
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property CurrentIndex(ByVal lIndex As Integer) As Integer")
                'End Try
            End Set
        End Property
        Public Function Window(_ChannelIndex As Integer) As frmChannel
            'Try
            Return lChannels.cChannel(_ChannelIndex).cWindow
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Function Window(_ChannelIndex As Integer) As frmChannel")
            'Return Nothing
            'End Try
        End Function
        Public Property Visible(_ChannelIndex As Integer) As Boolean
            Get
                'Try
                Return lChannels.cChannel(_ChannelIndex).cVisible
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property Visible(_Channel As gChannel) As Boolean")
                'End Try
            End Get
            Set(ByVal lValue As Boolean)
                'Try
                lChannels.cChannel(_ChannelIndex).cVisible = lValue
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property Visible(_Channel As gChannel) As Boolean")
                'End Try
            End Set
        End Property
        Public Property Count() As Integer
            Get
                'Try
                Return lChannels.cCount
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelCount() As Integer")
                'End Try
            End Get
            Set(ByVal lValue As Integer)
                'Try
                lChannels.cCount = lValue
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelCount() As Integer")
                'End Try
            End Set
        End Property
        Public Property Name(_Index As Integer) As String
            Get
                'Try
                Return lChannels.cChannel(_Index).cName
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelName(ByVal lIndex As Integer) As String")
                'Return Nothing
                'End Try
            End Get
            Set(ByVal _Value As String)
                'Try
                lChannels.cChannel(_Index).cName = _Value
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelName(ByVal lIndex As Integer) As String")
                'End Try
            End Set
        End Property
        Public Sub Mode(ByVal _StatusIndex As Integer, ByVal _Data As String)
            'Try
            Dim splt() As String, splt2() As String, msg As String, _ChannelIndex As Integer = 0
            If Len(_Data) <> 0 And _StatusIndex <> 0 Then
                splt = Split(_Data, " ")
                splt2 = Split(splt(0), "!")
                splt2(0) = Replace(splt2(0), ":", "")
                splt2(1) = Replace(splt2(1), "n=", "")
                _ChannelIndex = Find(_StatusIndex, splt(2))
                Select Case Trim(splt(3))
                    Case "+o"
                        msg = ReturnReplacedString(eStringTypes.sUSER_MODE, splt2(0), splt(3), splt(4))
                        PrivMsg(_ChannelIndex, msg)
                    Case "-o"
                        msg = ReturnReplacedString(eStringTypes.sUSER_MODE, splt2(0), splt(3), splt(4))
                        PrivMsg(_ChannelIndex, msg)
                End Select
            End If
            ''0: nickname!user@host
            ''1: mode
            ''2: channel
            ''3: mode
            ''4: username
            '':NickName!user@host MODE #channel +v username
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub ChannelModeProc(ByVal lStatusIndex As Integer, ByVal lData As String)")
            'End Try
        End Sub
        Public Property URL(ByVal lIndex As Integer) As String
            Get
                'Try
                Return lChannels.cChannel(lIndex).cURL
                'Catch ex As Exception
                'Return Nothing
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelURL(ByVal lIndex As Integer) As String")
                'End Try
            End Get
            Set(ByVal lValue As String)
                'Try
                With lChannels.cChannel(lIndex)
                    .cURL = lValue
                    .cWindow.cmdURL.Visible = True
                End With
                'Catch ex As Exception
                'RaiseEvent ProcessError(ex.Message, "Public Property ChannelURL(ByVal lIndex As Integer) As String")
                'End Try
            End Set
        End Property
        Public Sub New()
            'Try
            ReDim lChannels.cChannel(lArraySizes.aChannelWindows)
            'Catch ex As Exception
            'RaiseEvent ProcessError(ex.Message, "Public Sub New()")
            'End Try
        End Sub
    End Class
End Namespace