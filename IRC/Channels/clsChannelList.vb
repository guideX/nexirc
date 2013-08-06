Option Explicit On
Option Strict On
Imports nexIRC.Classes.UI
Imports nexIRC.Modules
Imports nexIRC.Classes.IO
Public Class clsChannelListUI
    Public Event SaveColumnWidths()
    Public lSortOrder As SortOrder
    Private lCurrentChannel As String
    Private lMeIndex As Integer
    Public WriteOnly Property MeIndex() As Integer
        Set(_MeIndex As Integer)
            'Try
            lMeIndex = _MeIndex
            lChannelLists.SetOpen(lMeIndex)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As Integer")
            'End Try
        End Set
    End Property
    Public Sub FormClosed(_ChannelsListView As ListView, _FormLeft As Integer, _FormTop As Integer, _FormWidth As Integer, _FormHeight As Integer)
        'Try
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Left", _FormLeft.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Top", _FormTop.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Width", _FormWidth.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Height", _FormHeight.ToString)
        lChannelLists.SetClosed(lMeIndex)
        RaiseEvent SaveColumnWidths()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        'End Try
    End Sub
    Public Sub ResetList(_ListView As ListView)
        'Try
        _ListView.Items.Clear()
        _ListView.View = View.Details
        _ListView.HeaderStyle = ColumnHeaderStyle.Clickable
        _ListView.Columns.Add("Channel", CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "1", "150"))), HorizontalAlignment.Left)
        _ListView.Columns.Add("Topic", CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "2", "350"))), HorizontalAlignment.Left)
        _ListView.Columns.Add("Users", CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "3", "100"))), HorizontalAlignment.Left)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ResetList()")
        'End Try
    End Sub
    Public Sub Load(_Form As Form, _ListView As ListView)
        'Try
        _Form.Left = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "ChannelList", "Left", "300")))
        _Form.Top = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "ChannelList", "Top", "300")))
        _Form.Width = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "ChannelList", "Width", "300")))
        _Form.Height = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "ChannelList", "Height", "300")))
        _Form.MdiParent() = mdiMain
        _Form.Icon = mdiMain.Icon
        ResetList(_ListView)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Public Sub Resize(_ListView As ListView, _Form As Form, _ToolStripHeight As Integer)
        'Try
        _ListView.Width = _Form.ClientSize.Width
        _ListView.Height = _Form.ClientSize.Height - _ToolStripHeight
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Resize()")
        'End Try
    End Sub
    Public Sub DoubleClick(_ListView As ListView)
        'Try
        Dim i As Integer
        For i = 0 To _ListView.SelectedItems.Count
            lChannels.Join(lChannelLists.ReturnStatusIndex(lMeIndex), lCurrentChannel)
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoubleClick()")
        'End Try
    End Sub
    Public Sub ItemSelectionChanged(_ListView As ListView, _ItemIndex As Integer)
        'Try
        lCurrentChannel = _ListView.Items(_ItemIndex).Text
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwChannels_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChannels.ItemSelectionChanged")
        'End Try
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
    Public Function ReturnChannelListIndex(_StatusIndex As Integer) As Integer
        'Try
        Dim n As Integer = 0
        For i As Integer = 1 To lChannelLists.cCount
            If lChannelLists.cChannelList(i).cStatusIndex = _StatusIndex Then
                n = i
            End If
        Next i
        Return n
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function ReturnChannelListIndex(_StatusIndex As Integer) As Integer")
        'Return Nothing
        'End Try
    End Function
    Public Function ReturnStatusIndex(_ChannelListIndex As Integer) As Integer
        Try
            Return lChannelLists.cChannelList(_ChannelListIndex).cStatusIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReturnStatusIndex(_ChannelListIndex As Integer) As Integer")
            Return Nothing
        End Try
    End Function
    Public Sub NewChannelList(_StatusIndex As Integer)
        'Try
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
                .cTreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add("Channel List", "Channel List", 1)
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub NewChannelList(_StatusIndex As Integer)")
        'End Try
    End Sub
    Public Sub Clear(_ChannelListIndex As Integer)
        'Try
        With lChannelLists.cChannelList(_ChannelListIndex)
            .cWindow.lvwChannels.Clear()
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ClearChannelListItems(lStatusIndex As Integer)")
        'End Try
    End Sub
    Public Sub Unload(_ChannelListIndex As Integer)
        'Try
        If lChannelLists.cCount <> 0 Then
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .cVisible = True Then .cWindow.Close()
                If .cTreeNodeVisible = True Then .cTreeNode = Nothing
                .cTreeNodeVisible = False
                .cVisible = False
                .cWindow = Nothing
            End With
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Shared Sub Unload(_ChannelList As gChannelList)")
        'End Try
    End Sub
    Public WriteOnly Property StatusDescription(_ChannelListIndex As Integer) As String
        Set(_StatusDescription As String)
            'Try
            lChannelLists.cChannelList(_ChannelListIndex).cStatusDescription = _StatusDescription
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public WriteOnly Property StatusDescription() As String")
            'End Try
        End Set
    End Property
    Public Sub Display(_ChannelListIndex As Integer)
        'Try
        With lChannelLists.cChannelList(_ChannelListIndex)
            '.cWindow.Text = "Channel List [" & lStatusObjects.sStatusObject(lStatusIndex).sDescription & "]"
            .cWindow = New frmChannelList()
            .cWindow.Text = "Channel List [" & lStatus.Window(.cStatusIndex).Text & "]"
            .cWindow.lvwChannels.Items.Clear()
            clsAnimate.Animate(.cWindow, clsAnimate.Effect.Center, 200, 1)
            SetItems(_ChannelListIndex)
            .cWindow.MeIndex = _ChannelListIndex
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Shared Sub Display(_ChannelList As gChannelList, _StatusDescription As String)")
        'End Try
    End Sub
    Private Sub SetItems(_ChannelListIndex As Integer)
        'Try
        Dim _Item As ListViewItem
        clsLockWindowUpdate.LockWindowUpdate(lChannelLists.cChannelList(_ChannelListIndex).cWindow.lvwChannels.Handle)
        With lChannelLists.cChannelList(_ChannelListIndex)
            For i As Integer = 1 To .cItem.cCount
                _Item = .cWindow.lvwChannels.Items.Add(.cItem.cChannelListItem(i).cChannel)
                _Item.SubItems.Add(.cItem.cChannelListItem(i).cTopic)
                _Item.SubItems.Add(.cItem.cChannelListItem(i).cUserCount.ToString)
            Next i
        End With
        clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub SetItems(_ChannelListIndex As Integer)")
        'End Try
    End Sub
    Public Sub Close(_ChannelListIndex As Integer)
        Try
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .cVisible = True Then .cWindow.Close()
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Close()")
        End Try
    End Sub
    Public Sub HideTreeNode(_ChannelListIndex As Integer)
        Try
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .cTreeNodeVisible = True Then
                    .cTreeNodeVisible = False
                    .cTreeNode.Remove()
                End If
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub HideTreeNode(_ChannelListIndex As Integer)")
        End Try
    End Sub
    Public Sub DoubleClick(_ChannelListIndex As Integer)
        'Try
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoubleClick()")
        'End Try
    End Sub
    Public Function DoesChannelExist(_ChannelListIndex As Integer, _Channel As String) As Boolean
        'Try
        Dim _Result As Boolean = False
        With lChannelLists.cChannelList(_ChannelListIndex)
            For i As Integer = 1 To .cItem.cCount
                If .cItem.cChannelListItem(i).cChannel.ToLower() = _Channel.ToLower() = True Then
                    _Result = True
                End If
            Next i
        End With
        Return _Result
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function DoesChannelExist(_ChannelListIndex As Integer, _Channel As String) As Boolean")
        'End Try
    End Function
    Public Sub Add(_ChannelListIndex As Integer, ByVal _Data As String)
        'Try
        Dim splt() As String, splt2() As String, i As Integer, msg As String
        If Left(_Data, 1) <> ":" Then _Data = ":" & _Data
        If Len(_Data) <> 0 Then
            _Data = Trim(_Data)
            splt = Split(_Data, ":")
            splt2 = Split(splt(1), " ")
            i = Len(splt2(0)) + Len(splt2(1)) + Len(splt2(2)) + Len(splt2(3)) + Len(splt2(4)) + 7
            msg = Right(_Data, Len(_Data) - i)
            msg = StripColorCodes(msg)
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ProcessChannelListItem(ByVal lStatusIndex As Integer, ByVal lData As String)")
        'End Try
    End Sub
    Public Sub SetOpen(_ChannelListIndex As Integer)
        'Try
        With lChannelLists.cChannelList(_ChannelListIndex)
            .cVisible = True
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetChannelListClosed(ByVal lIndex As Integer)")
        'End Try
    End Sub
    Public Sub SetClosed(_ChannelListIndex As Integer)
        'Try
        With lChannelLists.cChannelList(_ChannelListIndex)
            .cVisible = False
            .cWindow = Nothing
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetChannelListClosed(ByVal lIndex As Integer)")
        'End Try
    End Sub
End Class