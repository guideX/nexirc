'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Enum
Imports nexIRC.Modules
Imports nexIRC.nexIRC.MainWindow.clsMainWindowUI
Imports Telerik.WinControls.UI
Namespace IRC.Channels
    Public Class clsChannel
        Public nCount As Integer
        Public Structure gChannel
            Public cName As String
            Public cURL As String
            Public cWindow As frmChannel
            Public cVisible As Boolean
            Public cTreeNode As TreeNode
            Public cTreeNodeVisible As Boolean
            Public cIncomingText As String
            Public cStatusIndex As Integer
            Public cWindowBarItem As ToolStripItem
            Public cWindowBarItemVisible As Boolean
            Public cNamesToAdd As List(Of String)
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
        Public Sub Focus(channelIndex As Integer)
            With lChannels.cChannel(channelIndex)
                .cWindow.Focus()
            End With
        End Sub
        Public Sub EnableDelayNamesTimer(channelIndex As Integer)
            lChannels.cChannel(channelIndex).cWindow.tmrAddNameDelay.Enabled = True
        End Sub
        Public Sub AddToNickListQue(channelIndex As Integer, nickName As String)
            lChannels.cChannel(channelIndex).cWindow.MdiChildWindow.NicklistQue.Add(nickName)
        End Sub
        Private Sub AddToNickList(_ChannelIndex As Integer, ByVal _NickName As String)
            Dim listViewDataItem As ListViewDataItem, b As Boolean
            With lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList
                listViewDataItem = New ListViewDataItem()
                listViewDataItem.Text = _NickName
                If InStr(listViewDataItem.Text, "@") <> 0 Then
                    listViewDataItem.ForeColor = Color.Red
                ElseIf InStr(listViewDataItem.Text, "+") <> 0 Then
                    listViewDataItem.ForeColor = Color.DarkGreen
                Else
                    listViewDataItem.ForeColor = Color.White
                End If
                _NickName = _NickName.Replace("@", "")
                _NickName = _NickName.Replace("+", "")
                For Each msg As ListViewDataItem In .Items
                    If msg.Text.Replace("@", "").Replace("+", "") = _NickName Then
                        b = True
                    End If
                Next msg
                If (Not b) Then
                    .Items.Add(listViewDataItem)
                End If
            End With
        End Sub
        Public Sub Minimize(_ChannelIndex As Integer)
            With lChannels.cChannel(_ChannelIndex)
                .cWindow.WindowState = FormWindowState.Minimized
            End With
        End Sub
        Public Sub PrivMsg(_ChannelIndex As Integer, ByVal _Data As String)
            With lChannels.cChannel(_ChannelIndex)
                DoChannelColor(_ChannelIndex, _Data)
                If .cVisible = False Then
                    If .cTreeNode.ImageIndex <> 9 Then .cTreeNode.ImageIndex = 9
                    If .cTreeNode.SelectedImageIndex <> 9 Then .cTreeNode.SelectedImageIndex = 9
                    If .cWindowBarItem.ImageIndex <> 9 Then .cWindowBarItem.ImageIndex = 9
                    'If .cWindowBarItem.SelectedImageIndex <> 9 Then .cWindowBarItem.SelectedImageIndex = 9
                End If
            End With
        End Sub
        Public Sub DoChannelColor(channelIndex As Integer, ByVal data As String)
            If (channelIndex <> 0) Then
                lChannels.cChannel(channelIndex).cWindow.txtIncoming.Print(data)
            End If
        End Sub
        Public Sub Window_Closing(form As Form, meIndex As Integer, eventArgs As System.Windows.Forms.FormClosingEventArgs)
            With lChannels.cChannel(meIndex)
                lSettings.lIRC.iSettings.sWindowSizes.iChannel.wWidth = .cWindow.Width
                lSettings.lIRC.iSettings.sWindowSizes.iChannel.wHeight = .cWindow.Height
                lSettings.SaveWindowSizes()
                If lStatus.Closing() = False Then
                    SetChannelVisible(meIndex, False)
                End If
                form.Visible = False
                eventArgs.Cancel = True
            End With
        End Sub
        Public Sub Form_Load(channelIndex As Integer)
            lChannels.cChannel(channelIndex).cWindow = New frmChannel
            lChannels.cChannel(channelIndex).cWindow.Show()
            lChannels.cChannel(channelIndex).cWindow.MdiChildWindow.FormType = FormTypes.Channel
            lChannels.cChannel(channelIndex).cWindow.MdiChildWindow.MeIndex = channelIndex
            lChannels.cChannel(channelIndex).cWindow.MdiChildWindow.Form_Load(FormTypes.Channel)
            lChannels.cChannel(channelIndex).cWindow.txtIncoming.Print(lChannels.cChannel(channelIndex).cIncomingText)
            lChannels.cChannel(channelIndex).cWindow.Text = lChannels.cChannel(channelIndex).cName
            lChannels.cChannel(channelIndex).cWindow.Icon = mdiMain.Icon
            lChannels.cChannel(channelIndex).cWindow.MdiParent = mdiMain
            lChannels.cChannel(channelIndex).cWindow.lvwNickList.Columns.Add("Nickname")
            lChannels.cChannel(channelIndex).cWindow.txtOutgoing.Focus()
        End Sub
        Public Sub Window_Resize(_ChannelIndex As Integer)
            Dim m As Integer
            With lChannels.cChannel(_ChannelIndex).cWindow
                If (.ClientSize.Width <> 0) Then
                    .txtIncoming.Width = .ClientSize.Width - .lvwNickList.Width
                    m = .ClientSize.Height - (.txtOutgoing.Height + .tspChannel.ClientSize.Height)
                    If ((m <= .txtIncoming.MinimumSize.Height) Or m >= .txtIncoming.MaximumSize.Height) Then
                        .txtIncoming.Height = .ClientSize.Height - (.txtOutgoing.Height + .tspChannel.ClientSize.Height)
                    End If
                    .txtOutgoing.Width = .ClientSize.Width
                    .txtOutgoing.Top = .txtIncoming.Height + .tspChannel.ClientSize.Height
                    .lvwNickList.Left = .txtIncoming.Width
                    .lvwNickList.Height = .txtIncoming.Height
                    .lvwNickList.Top = .txtIncoming.Top
                End If
            End With
        End Sub
        Public Sub Outgoing_GotFocus(_ChannelIndex As Integer)
            With lChannels.cChannel(_ChannelIndex)
                If lSettings.lIRC.iSettings.sAutoMaximize = True Then .cWindow.WindowState = FormWindowState.Maximized
                lChannels.cIndex = _ChannelIndex
                lStatus.ActiveIndex = .cStatusIndex
            End With
        End Sub
        Public Sub Outgoing_KeyDown(_ChannelIndex As Integer, _KeyCode As Integer)
            Dim msg As String, msg2 As String
            If (_ChannelIndex <> 0) Then
                With lChannels.cChannel(_ChannelIndex)
                    If _KeyCode = 13 Then
                        msg = .cWindow.txtOutgoing.Text
                        .cWindow.txtOutgoing.Text = ""
                        If lStrings.LeftRight(msg, 0, 1) = "/" Then
                            lStatus.ProcessUserInput(lChannels.cChannel(_ChannelIndex).cStatusIndex, msg)
                        Else
                            lStatus.DoStatusSocket(lChannels.cChannel(_ChannelIndex).cStatusIndex, "PRIVMSG " & lChannels.cChannel(_ChannelIndex).cName & " :" & msg)
                            msg2 = lStringsController.ReadReplacedString(IrcNumeric.sPRIVMSG, lStatus.NickName(lChannels.cChannel(_ChannelIndex).cStatusIndex), msg)
                            DoChannelColor(_ChannelIndex, msg2)
                        End If
                    End If
                End With
            End If
        End Sub
        Public Function StatusIndex(channelIndex As Integer) As Integer
            Return lChannels.cChannel(channelIndex).cStatusIndex
        End Function
        Public Sub SetChannelVisible(_ChannelIndex As Integer, ByVal _Visible As Boolean)
            With lChannels.cChannel(_ChannelIndex)
                .cVisible = _Visible
            End With
        End Sub
        Public Sub NickList_DoubleClick(_ChannelIndex As Integer)
            Dim msg As String
            With lChannels.cChannel(_ChannelIndex)
                msg = Replace(.cWindow.lvwNickList.SelectedItems(0).Text, "+", "")
                msg = Replace(msg, "@", "")
                'lStatus.PrivateMessage_Initialize(.cStatusIndex, msg)
                lStatus.PrivateMessage_Add(StatusIndex(_ChannelIndex), msg, "", "", True)
            End With
        End Sub
        Public Sub Users_DoubleClick(_ChannelIndex As Integer)
            With lChannels.cChannel(_ChannelIndex)
                Dim msg As String
                msg = Replace(.cWindow.lvwNickList.Text, "+", "")
                msg = Replace(.cWindow.lvwNickList.Text, "@", "")
                lStatus.PrivateMessage_Initialize(.cStatusIndex, msg)
            End With
        End Sub
        Public Sub ResetForeMostWindows()
            For i As Integer = 1 To lChannels.cCount
                lChannels.cChannel(i).cWindow.MdiChildWindow.lForeMost = False
            Next i
        End Sub
        Public Sub ToggleChannelWindowState(_ChannelIndex As Integer, _ForeMost As Boolean)
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
        End Sub
        Public Sub AddText_WhereUserExists(_StatusIndex As Integer, _NickName As String, _Text As String)
            If (_StatusIndex <> 0 Or _NickName.Trim().Length() = 0) Then
                For _ChannelIndex As Integer = 1 To lChannels.cCount
                    For n As Integer = 0 To lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList.Items.Count - 1
                        If (lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList.Items(n).Text.Trim().ToLower.Replace("@", "").Replace("+", "") = _NickName.Trim().ToLower.Replace("@", "").Replace("+", "")) Then
                            DoChannelColor(_ChannelIndex, _Text)
                        End If
                    Next n
                Next _ChannelIndex
            End If
        End Sub
        Public Function HaveChannels(_StatusIndex As Integer) As Boolean
            Dim _Result As Boolean = False
            For i As Integer = 1 To lChannels.cCount
                If lChannels.cChannel(i).cStatusIndex = _StatusIndex Then _Result = True
            Next i
            Return _Result
        End Function
        Public Sub RemoveTree(_ChannelIndex As Integer)
            With lChannels.cChannel(_ChannelIndex)
                .cTreeNode.Remove()
                .cTreeNodeVisible = False
                mdiMain.tspWindows.Items.Remove(.cWindowBarItem)
            End With
        End Sub
        Public Sub Redirect(_StatusIndex As Integer, _Data As String)
            Dim _ChannelA As String, _ChannelB As String, splt() As String, _NickName As String
            splt = _Data.Split(Convert.ToChar(" "))
            _NickName = splt(2)
            _ChannelA = splt(3)
            _ChannelB = splt(4)
            If (_NickName.ToLower = lStatus.NickName(_StatusIndex).ToLower()) Then
                If (lSettings.lIRC.iSettings.sPrompts = True) Then
                    mdiMain.lblRedirectMessage.Text = "Notice: You have been redirected from '" & _ChannelA & "' to '" & _ChannelB & "'."
                    mdiMain.lblRedirectMessage.Tag = _StatusIndex.ToString()
                    mdiMain.tmrHideRedirect.Enabled = True
                    mdiMain.tspRedirect.Visible = True
                Else
                    Join(_StatusIndex, _ChannelB)
                End If
                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(_StatusIndex, IrcNumeric.sERR_LINKCHANNEL, _ChannelA, _ChannelB)
            End If
        End Sub
        Public Sub SomeoneChangedNickName(_OldNickName As String, _HostName As String, _NickName As String, _StatusIndex As Integer)
            For Each lChannel As gChannel In lChannels.cChannel
                If (lChannel.cStatusIndex = _StatusIndex) Then
                    For Each lListViewItem As ListViewDataItem In lChannel.cWindow.lvwNickList.Items
                        If (lListViewItem.Text = _OldNickName) Then
                            lListViewItem.Text = _NickName
                            lChannel.cWindow.txtIncoming.Print(lStringsController.ReadReplacedString(IrcNumeric.sNICK_CHANGE, _OldNickName, _HostName, _NickName))
                        End If
                    Next lListViewItem
                End If
            Next lChannel
        End Sub
        Public Sub SomeoneJoined(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Dim _NickName As String, _IpAddress As String, _Channel As String, _TextToDisplay As String, _ChannelIndex As Integer
            _NickName = lStrings.ParseData(_Data, ":", "!")
            _IpAddress = lStrings.ParseData(_Data, "~", " JOIN ")
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
                Form_Load(_ChannelIndex)
                DoChannelColor(_ChannelIndex, lStringsController.ReadReplacedString(IrcNumeric.sYOUJOIN, _Channel))
                lSettings.AddToChannelFolders(_Channel, lStatus.NetworkIndex(_StatusIndex))
                lChannelFolder.RefreshChannelFolderChannelList()
            Else
                If lSettings.lIRC.iSettings.sShowUserAddresses = True Then
                    _TextToDisplay = lStringsController.ReadReplacedString(IrcNumeric.sUSER_JOINED, _NickName & " (" & _IpAddress & ")", _Channel)
                Else
                    _TextToDisplay = lStringsController.ReadReplacedString(IrcNumeric.sUSER_JOINED, _NickName, _Channel)
                End If
                _ChannelIndex = Find(_StatusIndex, _Channel)
                With lChannels.cChannel(_ChannelIndex)
                    DoChannelColor(_ChannelIndex, _TextToDisplay)
                    AddToNickList(_ChannelIndex, _NickName)
                End With
            End If
        End Sub
        Public Sub RemoveFromNickList(_ChannelIndex As Integer, ByVal _NickName As String)
            Dim i As Integer, _NickListText As String
            If Len(_NickName) <> 0 Then
                With lChannels.cChannel(_ChannelIndex)
                    For i = 0 To .cWindow.lvwNickList.Items.Count - 1
                        _NickListText = .cWindow.lvwNickList.Items(i).Text
                        If LCase(Trim(_NickListText)) = LCase(Trim(_NickName)) Or LCase(Trim(_NickListText)) = LCase(Trim("@" & _NickName)) Or LCase(Trim(_NickListText)) = LCase(Trim("+" & _NickName)) Then
                            .cWindow.lvwNickList.Items.RemoveAt(i)
                            Exit For
                        End If
                    Next i
                End With
            End If
        End Sub
        Public Sub SomeoneQuit(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Dim nickListIds As List(Of Integer), nickName As String, hostName As String, quitMessage As String, lastNickName As String
            Try
                lastNickName = ""
                nickListIds = New List(Of Integer)
                If (_Data.Contains(":") And _Data.Contains("!")) Then
                    nickName = lStrings.ParseData(_Data, ":", "!")
                    If (_Data.Contains(" QUIT :")) Then
                        hostName = lStrings.ParseData(_Data, ":" & nickName & "!", " QUIT :").Replace(nickName & "!", "")
                        quitMessage = _Data.Replace(":" & nickName & "!" & hostName & " QUIT :", "")
                        Dim nickListItems As List(Of ListViewDataItem)
                        For i = 1 To lChannels.cCount
                            Dim ii As Integer = i
                            nickListItems = lChannels.cChannel(i).cWindow.lvwNickList.Items.Where(Function(nickListItem) nickListItem.Text = nickName Or nickListItem.Text = "@" & nickName Or nickListItem.Text = "+" & nickName).ToList()
                            nickListItems = nickListItems.Distinct.ToList()
                            nickListItems.ForEach(Function(m) As Boolean
                                                      If (lastNickName <> nickName) Then
                                                          lastNickName = nickName
                                                          lChannels.cChannel(ii).cWindow.lvwNickList.Items.Remove(m)
                                                          DoChannelColor(ii, lStringsController.ReadReplacedString(IrcNumeric.sUSER_QUIT, nickName, hostName, quitMessage))
                                                      End If
                                                      Return True
                                                  End Function)
                        Next i
                    End If
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Sub SomeoneParted(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Dim splt() As String, splt2() As String, splt3() As String, _NickName As String, _ChannelName As String, _HostName As String, _ChannelIndex As Integer, _TextToDisplay As String
            _NickName = ""
            _ChannelName = ""
            _HostName = ""
            splt = _Data.Split(Convert.ToChar(" "))
            If (UBound(splt)) = 2 Then
                _ChannelName = splt(2)
                splt2 = splt(0).Split(Convert.ToChar("@"))
                If UBound(splt2) = 1 Then
                    _NickName = splt2(0)
                    _NickName = lStrings.ParseData(_NickName, ":", "!")
                    '_HostName = Split(splt2(0), "~")(1) & "@" & splt2(1)
                    splt3 = Split(splt2(0), "~")
                    If (UBound(splt3) > 0) Then
                        _HostName = splt3(1) & "@" & splt2(1)
                    Else
                        _HostName = splt3(0)
                    End If
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
                If lSettings.lIRC.iSettings.sShowUserAddresses = True Then
                    _TextToDisplay = lStringsController.ReadReplacedString(IrcNumeric.sUSER_PARTED, _NickName & " (" & _HostName & ")", _ChannelName)
                Else
                    _TextToDisplay = lStringsController.ReadReplacedString(IrcNumeric.sUSER_PARTED, _NickName, _ChannelName)
                End If
                DoChannelColor(Find(_StatusIndex, _ChannelName), _TextToDisplay)
            End If
        End Sub
        Public Function Find(ByVal _StatusIndex As Integer, ByVal _ChannelName As String) As Integer
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
        End Function
        Public Sub Delete(ByVal _ChannelIndex As Integer)
            With lChannels.cChannel(_ChannelIndex)
                .cName = ""
                If .cTreeNodeVisible = True Then .cTreeNode.Remove()
                .cTreeNode = Nothing
                .cTreeNodeVisible = False
                .cWindow = Nothing
                .cVisible = False
            End With
        End Sub
        Public Sub Join(ByVal lStatusIndex As Integer, ByVal lChannelName As String)
            If lStatusIndex <> 0 And Len(lChannelName) <> 0 Then lStatus.SendSocket(lStatusIndex, "JOIN " & lChannelName)
        End Sub
        Public Sub ClearAll(_StatusIndex As Integer)
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
        End Sub
        Public Sub Topic(_StatusIndex As Integer, _Data As String)
            Dim splt() As String = Split(_Data.Trim(), ":"), splt2() As String, _Message As String, _Channel As String, _ChannelIndex As Integer = 0
            splt2 = Split(splt(1), " ")
            _Channel = splt2(3)
            _Message = Right(_Data, Len(_Data) - splt(1).Length() - 2)
            _ChannelIndex = Find(_StatusIndex, _Channel)
            With lChannels.cChannel(_ChannelIndex)
                .cWindow.txtIncoming.Print(lStringsController.ReadReplacedString(IrcNumeric.sRPL_TOPIC, _Channel, _Message))
                .cWindow.Text = _Channel & ": " & _Message.StripColorCodes
            End With
        End Sub
        Private Function Add(_Name As String, _StatusIndex As Integer) As Integer
            lChannels.cCount = lChannels.cCount + 1
            ReDim Preserve lChannels.cChannel(lChannels.cCount)
            With lChannels.cChannel(lChannels.cCount)
                .cName = _Name
                .cStatusIndex = _StatusIndex
                .cTreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add(_Name, _Name, 1, 1)
                .cTreeNodeVisible = True
                .cWindowBarItem = mdiMain.AddWindowBar(.cName, gWindowBarImageTypes.wChannel)
                .cWindowBarItem.Tag = Trim(.cStatusIndex.ToString)
                .cWindowBarItemVisible = True
            End With
            Return lChannels.cCount
        End Function
        Public Property CurrentIndex() As Integer
            Get
                Return lChannels.cIndex
            End Get
            Set(ByVal lValue As Integer)
                lChannels.cIndex = lValue
            End Set
        End Property
        Public Function Window(_ChannelIndex As Integer) As frmChannel
            Return lChannels.cChannel(_ChannelIndex).cWindow
        End Function
        Public Function GetObject(channelIndex As Integer) As gChannel
            Return lChannels.cChannel(channelIndex)
        End Function
        Public Property Visible(channelIndex As Integer) As Boolean
            Get
                Return lChannels.cChannel(channelIndex).cVisible
            End Get
            Set(ByVal value As Boolean)
                With lChannels.cChannel(channelIndex)
                    .cVisible = value
                    .cWindow.Visible = value
                    If (value = True And .cVisible = False) Then
                        If .cTreeNode.ImageIndex <> 1 Then .cTreeNode.ImageIndex = 1
                        If .cTreeNode.SelectedImageIndex <> 1 Then .cTreeNode.SelectedImageIndex = 1
                        If .cWindowBarItem.ImageIndex <> 1 Then .cWindowBarItem.ImageIndex = 1
                    End If
                    .cWindow.txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    If (.cTreeNode IsNot Nothing) Then
                        If (.cTreeNode.ImageIndex <> 1) Then .cTreeNode.ImageIndex = 1
                        If (.cTreeNode.SelectedImageIndex <> 1) Then .cTreeNode.SelectedImageIndex = 1
                    End If
                    If (.cWindowBarItem IsNot Nothing) Then
                        If (.cTreeNode.ImageIndex <> 1) Then .cTreeNode.ImageIndex = 1
                    End If
                End With
            End Set
        End Property
        Public Property Count() As Integer
            Get
                Return lChannels.cCount
            End Get
            Set(ByVal lValue As Integer)
                lChannels.cCount = lValue
            End Set
        End Property
        Public Property Name(_Index As Integer) As String
            Get
                Return lChannels.cChannel(_Index).cName
            End Get
            Set(ByVal _Value As String)
                lChannels.cChannel(_Index).cName = _Value
            End Set
        End Property
        Public Sub Mode(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Dim splt() As String, splt2() As String, msg As String, _ChannelIndex As Integer = 0
            If Len(_Data) <> 0 And _StatusIndex <> 0 Then
                splt = Split(_Data, " ")
                splt2 = Split(splt(0), "!")
                If UBound(splt2) <> 0 Then
                    splt2(0) = Replace(splt2(0), ":", "")
                    splt2(1) = Replace(splt2(1), "n=", "")
                    _ChannelIndex = Find(_StatusIndex, splt(2))
                    Select Case Trim(splt(3))
                        Case "+o"
                            msg = lStringsController.ReadReplacedString(IrcNumeric.sUSER_MODE, splt2(0), splt(3), splt(4))
                            PrivMsg(_ChannelIndex, msg)
                        Case "-o"
                            msg = lStringsController.ReadReplacedString(IrcNumeric.sUSER_MODE, splt2(0), splt(3), splt(4))
                            PrivMsg(_ChannelIndex, msg)
                    End Select
                End If
            End If
            ''0: nickname!user@host
            ''1: mode
            ''2: channel
            ''3: mode
            ''4: username
            '':NickName!user@host MODE #channel +v username
        End Sub
        Public Property URL(ByVal lIndex As Integer) As String
            Get
                Return lChannels.cChannel(lIndex).cURL
            End Get
            Set(ByVal lValue As String)
                With lChannels.cChannel(lIndex)
                    .cURL = lValue
                End With
            End Set
        End Property
        Public Sub New()
            ReDim lChannels.cChannel(2000)
        End Sub
    End Class
End Namespace