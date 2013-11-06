'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Public Class frmChannelList
    Private WithEvents lChannelListUI As New clsChannelListUI
    Private Sub frmChannelsList_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            lChannelListUI.FormClosed(lvwChannels, Me.Left, Me.Top, Me.Width, Me.Height)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        End Try
    End Sub
    Private Sub frmChannelsList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lChannelListUI.Load(Me, lvwChannels)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Public WriteOnly Property MeIndex() As Integer
        Set(_Index As Integer)
            Try
                lChannelListUI.MeIndex = _Index
            Catch ex As Exception
                ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As Integer")
            End Try
        End Set
    End Property
    Private Sub lChannelListUI_SaveColumnWidths() Handles lChannelListUI.SaveColumnWidths
        Try
            For i As Integer = 1 To 3
                clsFiles.WriteINI(lINI.iIRC, "lvwChannels_ColumnWidth", i.ToString, lvwChannels.Columns(i - 1).Width.ToString)
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelListUI_SaveColumnWidths() Handles lChannelListUI.SaveColumnWidths")
        End Try
    End Sub
    Private Sub frmChannelsList_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            lChannelListUI.Resize(lvwChannels, Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub
    Private Sub lvwChannels_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwChannels.DoubleClick
        Try
            lChannelListUI.DoubleClick(lvwChannels)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lvwChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwChannels.DoubleClick")
        End Try
    End Sub
    Private Sub lvwChannels_ItemMouseDoubleClick(sender As Object, e As Telerik.WinControls.UI.ListViewItemEventArgs) Handles lvwChannels.ItemMouseDoubleClick
        Try
            lChannelListUI.DoubleClick(lvwChannels)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lvwChannels_ItemMouseDoubleClick(sender As Object, e As Telerik.WinControls.UI.ListViewItemEventArgs) Handles lvwChannels.ItemMouseDoubleClick")
        End Try
    End Sub
    Private Sub lvwChannels_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown
        Try
            Me.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lvwChannels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwChannels.MouseDown")
        End Try
    End Sub
    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        Try
            lChannelListUI.cmdRefresh_Click(Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click")
        End Try
    End Sub
    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        Try
            lChannelListUI.cmdAddToChannelFolder_Click(Me.lvwChannels.SelectedItem.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click")
        End Try
    End Sub
End Class