Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Business.Repositories

Namespace nexIRC.Client.IRC.Channels
    Public Class clsChannelListUI
        Public Event SaveColumnWidths()
        Public lSortOrder As SortOrder
        Private lCurrentChannel As String
        Private lMeIndex As Integer
        Public Sub cmdAddToChannelFolder_Click(ByVal channel As String)
            Modules.IrcSettings.ChannelFoldersRepo.Add(channel, Modules.IrcSettings.IrcNetworks.GetDefault().Description)
        End Sub
        Public Sub cmdRefresh_Click(ByVal form As Form)
            Try
                Dim n As Integer = Modules.lStatus.ActiveIndex
                Modules.lStrings.ProcessReplaceCommand(n, IrcCommandTypes.cLIST, Modules.lStatus.ServerDescription(n))
                form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public WriteOnly Property MeIndex() As Integer
            Set(ByVal _MeIndex As Integer)
                Try
                    lMeIndex = _MeIndex
                    Modules.lChannelLists.SetOpen(lMeIndex)
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property
        Public Sub FormClosed(ByVal _ChannelsListView As ListView, ByVal _FormLeft As Integer, ByVal _FormTop As Integer, ByVal _FormWidth As Integer, ByVal _FormHeight As Integer)
            Try
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Left", _FormLeft.ToString)
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Top", _FormTop.ToString)
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Width", _FormWidth.ToString)
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Height", _FormHeight.ToString)
                Modules.lChannelLists.SetClosed(lMeIndex)
                RaiseEvent SaveColumnWidths()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub ResetList(ByVal _ListView As ListView)
            Try
                _ListView.Items.Clear()
                _ListView.View = View.Details
                _ListView.HeaderStyle = ColumnHeaderStyle.Clickable
                _ListView.Columns.Add("Channel", Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "1", "150"))), HorizontalAlignment.Left)
                _ListView.Columns.Add("Topic", Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "2", "350"))), HorizontalAlignment.Left)
                _ListView.Columns.Add("Users", Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "3", "100"))), HorizontalAlignment.Left)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Load(ByVal _Form As Form, ByVal _ListView As ListView)
            Try
                _Form.Left = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Left", "300")))
                _Form.Top = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Top", "300")))
                _Form.Width = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Width", "300")))
                _Form.Height = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "ChannelList", "Height", "300")))
                _Form.MdiParent() = mdiMain
                _Form.Icon = mdiMain.Icon
                ResetList(_ListView)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Resize(ByVal _ListView As ListView, ByVal _Form As Form, ByVal _ToolStripHeight As Integer)
            Try
                _ListView.Width = _Form.ClientSize.Width
                _ListView.Height = _Form.ClientSize.Height - _ToolStripHeight
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub DoubleClick(ByVal _ListView As ListView)
            Try
                Dim i As Integer
                For i = 0 To _ListView.SelectedItems.Count
                    Modules.lChannels.Join(Modules.lChannelLists.ReturnStatusIndex(lMeIndex), lCurrentChannel)
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub ItemSelectionChanged(ByVal _ListView As ListView, ByVal _ItemIndex As Integer)
            Try
                lCurrentChannel = _ListView.Items(_ItemIndex).Text
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
    Public Class clsChannelList
        Public Structure gChannelListItem
            Public cChannel As String
            Public cTopic As String
            Public cUserCount As Integer
        End Structure
        Public Structure gChannelListItems
            Public cCount As Integer
            Public cChannelListItem() As gChannelListItem
        End Structure
        Public Structure gChannelList
            Public cWindow As frmChannelList
            Public cVisible As Boolean
            Public cTreeNode As TreeNode
            Public cTreeNodeVisible As Boolean
            Public cItem As gChannelListItems
            Public cStatusIndex As Integer
            Public cStatusDescription As String
        End Structure
        Public Structure gChannelLists
            Public cChannelList() As gChannelList
            Public cCount As Integer
        End Structure
        Private lChannelLists As gChannelLists
        Public Function ReturnChannelListIndex(ByVal _StatusIndex As Integer) As Integer
            Try
                Dim n As Integer = 0
                For i As Integer = 1 To lChannelLists.cCount
                    If lChannelLists.cChannelList(i).cStatusIndex = _StatusIndex Then
                        n = i
                    End If
                Next i
                Return n
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Function ReturnStatusIndex(ByVal _ChannelListIndex As Integer) As Integer
            Try
                If (lChannelLists.cChannelList IsNot Nothing) Then
                    Return lChannelLists.cChannelList(_ChannelListIndex).cStatusIndex
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Sub NewChannelList(ByVal _StatusIndex As Integer)
            Try
                Dim b As Boolean = False, _ChannelListIndex As Integer
                For i As Integer = 1 To lChannelLists.cCount
                    If _StatusIndex = lChannelLists.cChannelList(i).cStatusIndex Then
                        _ChannelListIndex = i
                        b = True
                    End If
                Next i
                If b = False Then
                    lChannelLists.cCount = lChannelLists.cCount + 1
                    ReDim lChannelLists.cChannelList(lChannelLists.cCount)
                    With lChannelLists.cChannelList(lChannelLists.cCount)
                        .cStatusIndex = _StatusIndex
                        .cTreeNodeVisible = True
                        .cTreeNode = Modules.lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add("Channel List", "Channel List", 1)
                        .cWindow = New frmChannelList
                    End With
                Else
                    With lChannelLists.cChannelList(_ChannelListIndex)
                        .cStatusIndex = _StatusIndex
                        .cWindow = New frmChannelList
                        .cItem = New gChannelListItems()
                        .cWindow.MeIndex = _ChannelListIndex
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Clear(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    .cWindow.lvwChannels.Clear()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Unload(ByVal _ChannelListIndex As Integer)
            Try
                If lChannelLists.cCount <> 0 Then
                    With lChannelLists.cChannelList(_ChannelListIndex)
                        If .cVisible = True Then .cWindow.Close()
                        If .cTreeNodeVisible = True Then .cTreeNode = Nothing
                        .cTreeNodeVisible = False
                        .cVisible = False
                        .cWindow = Nothing
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public WriteOnly Property StatusDescription(ByVal _ChannelListIndex As Integer) As String
            Set(ByVal _StatusDescription As String)
                Try
                    lChannelLists.cChannelList(_ChannelListIndex).cStatusDescription = _StatusDescription
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property
        Public Sub Display(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    '.cWindow.Text = "Channel List [" & lStatusObjects.sStatusObject(lStatusIndex).sDescription & "]"
                    .cWindow = New frmChannelList()
                    .cWindow.Text = "Channel List [" & Modules.lStatus.Window(.cStatusIndex).Text & "]"
                    .cWindow.lvwChannels.Items.Clear()
                    .cWindow.Show()
                    SetItems(_ChannelListIndex)
                    .cWindow.MeIndex = _ChannelListIndex
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub SetItems(ByVal _ChannelListIndex As Integer)
            Try
                Dim _Item As ListViewItem
                With lChannelLists.cChannelList(_ChannelListIndex)
                    For i As Integer = 1 To .cItem.cCount
                        _Item = .cWindow.lvwChannels.Items.Add(.cItem.cChannelListItem(i).cChannel)
                        _Item.SubItems.Add(.cItem.cChannelListItem(i).cTopic)
                        _Item.SubItems.Add(.cItem.cChannelListItem(i).cUserCount.ToString)
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Close(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    If .cVisible = True Then .cWindow.Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub HideTreeNode(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    If .cTreeNodeVisible = True Then
                        .cTreeNodeVisible = False
                        .cTreeNode.Remove()
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub DoubleClick(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    If .cVisible = False Then
                        Display(_ChannelListIndex)
                    Else
                        .cWindow.Focus()
                        Exit Sub
                    End If
                End With
                With lChannelLists.cChannelList(_ChannelListIndex)
                    'With lStatusObjects.sStatusObject(n)
                    If .cVisible = False Then
                        'Display(_ChannelListIndex)
                        SetItems(_ChannelListIndex)
                        '.cWindow = New frmChannelList
                        '.cWindow.Show()
                        '.cVisible = True
                        '.cWindow.SetStatusIndex(n)
                        'SetChannelListItems(n, .sChannelList.cWindow.lvwChannels)
                    Else
                        'mdiMain.SetWindowFocus(.sChannelList.cWindow)
                        mdiMain.SetWindowFocus(.cWindow)
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Function DoesChannelExist(ByVal _ChannelListIndex As Integer, ByVal _Channel As String) As Boolean
            Try
                Dim _Result As Boolean = False
                With lChannelLists.cChannelList(_ChannelListIndex)
                    For i As Integer = 1 To .cItem.cCount
                        If .cItem.cChannelListItem(i).cChannel.ToLower() = _Channel.ToLower() = True Then
                            _Result = True
                        End If
                    Next i
                End With
                Return _Result
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Sub Add(ByVal _ChannelListIndex As Integer, ByVal _Data As String)
            Try
                Dim splt() As String, splt2() As String, i As Integer, msg As String
                If Left(_Data, 1) <> ":" Then _Data = ":" & _Data
                If Len(_Data) <> 0 Then
                    _Data = Trim(_Data)
                    splt = Split(_Data, ":")
                    splt2 = Split(splt(1), " ")
                    i = Len(splt2(0)) + Len(splt2(1)) + Len(splt2(2)) + Len(splt2(3)) + Len(splt2(4)) + 7
                    msg = Right(_Data, Len(_Data) - i)
                    msg = TextHelper.StripColorCodes(msg)
                    If msg = Nothing Then msg = ""
                    If DoesChannelExist(_ChannelListIndex, splt2(3)) = False Then
                        With lChannelLists.cChannelList(_ChannelListIndex)
                            .cItem.cCount = .cItem.cCount + 1
                            ReDim Preserve .cItem.cChannelListItem(.cItem.cCount)
                            With .cItem.cChannelListItem(.cItem.cCount)
                                .cChannel = splt2(3)
                                .cTopic = msg
                                If IsNumeric(splt2(4)) = True Then
                                    .cUserCount = CType(splt2(4).Trim, Integer)
                                End If
                            End With
                            If .cTreeNodeVisible = False Then
                                .cTreeNodeVisible = True
                            End If
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub SetOpen(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    .cVisible = True
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub SetClosed(ByVal _ChannelListIndex As Integer)
            Try
                With lChannelLists.cChannelList(_ChannelListIndex)
                    .cVisible = False
                    .cWindow = Nothing
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
