'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannelList
    Private lCurrentChannel As String
    Private lListViewSorter As clsListViewSorter
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

    Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        WriteINI(lINI.iIRC, "ChannelList", "Left", Me.Left.ToString)
        WriteINI(lINI.iIRC, "ChannelList", "Top", Me.Top.ToString)
        WriteINI(lINI.iIRC, "ChannelList", "Width", Me.Width.ToString)
        WriteINI(lINI.iIRC, "ChannelList", "Height", Me.Height.ToString)
        For i As Integer = 1 To 3
            WriteINI(lINI.iIRC, "lvwChannels_ColumnWidth", i.ToString, Me.lvwChannels.Columns(i - 1).Width.ToString)
        Next i
        lChannelLists.SetClosed(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        'End Try
    End Sub

    Public Sub ResetList()
        'Try
        lvwChannels.Items.Clear()
        lvwChannels.View = View.Details
        lvwChannels.HeaderStyle = ColumnHeaderStyle.Clickable
        lvwChannels.Columns.Add("Channel", CInt(Trim(ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "1", "150"))), HorizontalAlignment.Left)
        lvwChannels.Columns.Add("Topic", CInt(Trim(ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "2", "350"))), HorizontalAlignment.Left)
        lvwChannels.Columns.Add("Users", CInt(Trim(ReadINI(lINI.iIRC, "lvwChannels_ColumnWidth", "3", "100"))), HorizontalAlignment.Left)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ResetList()")
        'End Try
    End Sub

    Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        Me.Left = CInt(Trim(ReadINI(lINI.iIRC, "ChannelList", "Left", "300")))
        Me.Top = CInt(Trim(ReadINI(lINI.iIRC, "ChannelList", "Top", "300")))
        Me.Width = CInt(Trim(ReadINI(lINI.iIRC, "ChannelList", "Width", "300")))
        Me.Height = CInt(Trim(ReadINI(lINI.iIRC, "ChannelList", "Height", "300")))
        Me.MdiParent() = mdiMain
        Me.Icon = mdiMain.Icon
        ResetList()
        lListViewSorter = New clsListViewSorter(lvwChannels)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub

    Private Sub frmChannelList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        lvwChannels.Width = Me.ClientSize.Width
        lvwChannels.Height = Me.ClientSize.Height
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub

    Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick
        'Try
        Dim i As Integer
        For i = 0 To lvwChannels.SelectedItems.Count
            lChannels.Join(lChannelLists.ReturnStatusIndex(lMeIndex), lCurrentChannel)
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick")
        'End Try
    End Sub

    Private Sub lvwChannels_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChannels.ItemSelectionChanged
        'Try
        lCurrentChannel = lvwChannels.Items(e.ItemIndex).Text
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwChannels_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChannels.ItemSelectionChanged")
        'End Try
    End Sub

    Private Sub lvwChannels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwChannels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown")
        'End Try
    End Sub
End Class