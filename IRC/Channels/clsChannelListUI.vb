Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Public Class clsChannelListUI
    Private lCurrentChannel As String
    Private lMeIndex As Integer
    Private lChannelListUI As New clsChannelListUI
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
    Public Sub FormClosed(Form As Form, _ChannelsListView As ListView)
        'Try
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Left", Form.Left.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Top", Form.Top.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Width", Form.Width.ToString)
        clsFiles.WriteINI(lINI.iIRC, "ChannelList", "Height", Form.Height.ToString)
        For i As Integer = 1 To 3
            clsFiles.WriteINI(lINI.iIRC, "lvwChannels_ColumnWidth", i.ToString, _ChannelsListView.Columns(i - 1).Width.ToString)
        Next i
        lChannelLists.SetClosed(lMeIndex)
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