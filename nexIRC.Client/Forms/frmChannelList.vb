Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client
Imports nexIRC.Client.nexIRC.Client.IRC.Channels

Public Class frmChannelList
    Private WithEvents lChannelListUI As New clsChannelListUI

    Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lChannelListUI.FormClosed(lvwChannels, Me.Left, Me.Top, Me.Width, Me.Height)
    End Sub

    Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lChannelListUI.Load(Me, lvwChannels)
    End Sub

    Private Sub frmChannelList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lChannelListUI.Resize(lvwChannels, Me, ToolStrip1.Height)
    End Sub

    Private Sub ListView_ColumnClick(ByVal sender As Object, ByVal e As Windows.Forms.ColumnClickEventArgs)
        If (lChannelListUI.lSortOrder = SortOrder.Ascending) Then
            lChannelListUI.lSortOrder = SortOrder.Descending
        Else
            lChannelListUI.lSortOrder = SortOrder.Ascending
        End If
        lvwChannels.ListViewItemSorter = New ListViewSorter(e.Column, lChannelListUI.lSortOrder)
    End Sub

    Private Sub lvwChannels_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwChannels.ColumnClick
        AddHandler lvwChannels.ColumnClick, AddressOf ListView_ColumnClick
    End Sub

    Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick
        lChannelListUI.DoubleClick(lvwChannels)
    End Sub

    Private Sub lvwChannels_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChannels.ItemSelectionChanged
        lChannelListUI.ItemSelectionChanged(lvwChannels, e.ItemIndex)
    End Sub

    Private Sub lvwChannels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown
        Me.Focus()
    End Sub

    Public WriteOnly Property MeIndex() As Integer
        Set(ByVal _Index As Integer)
            lChannelListUI.MeIndex = _Index
        End Set
    End Property

    Private Sub lChannelListUI_SaveColumnWidths() Handles lChannelListUI.SaveColumnWidths
        For i As Integer = 1 To 3
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", i.ToString, lvwChannels.Columns(i - 1).Width.ToString)
        Next i
    End Sub
End Class