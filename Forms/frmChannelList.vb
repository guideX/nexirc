'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Imports nexIRC.Modules

Public Class frmChannelList
    Private WithEvents lChannelListUI As New clsChannelListUI

    Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            lChannelListUI.FormClosed(lvwChannels, Me.Left, Me.Top, Me.Width, Me.Height)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lChannelListUI.Load(Me, lvwChannels)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub frmChannelList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            lChannelListUI.Resize(lvwChannels, Me, ToolStrip1.Height)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub ListView_ColumnClick(sender As Object, e As Windows.Forms.ColumnClickEventArgs)
        Try
            If (lChannelListUI.lSortOrder = SortOrder.Ascending) Then
                lChannelListUI.lSortOrder = SortOrder.Descending
            Else
                lChannelListUI.lSortOrder = SortOrder.Ascending
            End If
            lvwChannels.ListViewItemSorter = New ListViewSorter(e.Column, lChannelListUI.lSortOrder)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub lvwChannels_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwChannels.ColumnClick
        Try
            AddHandler lvwChannels.ColumnClick, AddressOf ListView_ColumnClick
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick
        Try
            lChannelListUI.DoubleClick(lvwChannels)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub lvwChannels_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChannels.ItemSelectionChanged
        Try
            lChannelListUI.ItemSelectionChanged(lvwChannels, e.ItemIndex)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub lvwChannels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown
        Try
            Me.Focus()
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Public WriteOnly Property MeIndex() As Integer
        Set(_Index As Integer)
            Try
                lChannelListUI.MeIndex = _Index
            Catch ex As Exception
                'Throw ex
            End Try
        End Set
    End Property

    Private Sub lChannelListUI_SaveColumnWidths() Handles lChannelListUI.SaveColumnWidths
        Try
            For i As Integer = 1 To 3
                Files.WriteINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", i.ToString, lvwChannels.Columns(i - 1).Width.ToString)
            Next i
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub
End Class