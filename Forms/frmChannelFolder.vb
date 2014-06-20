'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.UI
Imports nexIRC.Modules
Public Class frmChannelFolder
    Private WithEvents channelFolderWindow As New clsChannelFolderUI
#Region "Window Subs"
    Public Sub Init()
        'Try
        channelFolderWindow.Init()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Public Sub SetStatusIndex(statusId As Integer)
        'Try
        channelFolderWindow.SetStatusIndex(statusId)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        'Try
        channelFolderWindow.cmdClose_Click()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        channelFolderWindow.Form_FormClosed(chkPopupOnConnect.Checked, chkCloseOnJoin.Checked, Me.Left, Me.Top)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        If (channelFolderWindow Is Nothing) Then
            channelFolderWindow = New clsChannelFolderUI()
        End If
        channelFolderWindow.Form_Load()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        'Try
        channelFolderWindow.cmdJoin_Click(txtChannel.Text, chkCloseOnJoin.Checked)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Try
        channelFolderWindow.cmdAdd_Click(txtChannel.Text, cboNetwork.Text)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        Try
            channelFolderWindow.lstChannels_DoubleClick(lstChannels.SelectedItem.Text, chkCloseOnJoin.Checked)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        Try
            channelFolderWindow.lstChannels_SelectedIndexChanged()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Try
            channelFolderWindow.cmdRemove_Click(txtChannel.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        'Try
        channelFolderWindow.cboNetwork_SelectedIndexChanged(cboNetwork.Text)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        Try
            channelFolderWindow.lnkJumpToChannelList_LinkClicked()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        Try
            channelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        Try
            channelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        Try
            channelFolderWindow.txtChannel_Leave()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        Try
            channelFolderWindow.txtChannel_MouseUp(sender)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Events"
    Private Sub channelFolderWindow_AddChannelToListBox(_Channel As String) Handles channelFolderWindow.AddChannelToListBox
        Try
            lstChannels.Items.Add(_Channel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub channelFolderWindow_AddNetworkComboBoxItem(_Network As String) Handles channelFolderWindow.AddNetworkComboBoxItem
        'Try
        cboNetwork.Items.Add(_Network)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_AnimateClose() Handles channelFolderWindow.AnimateClose
        'Try
        Me.Close()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_ChannelTextBoxSelectAll() Handles channelFolderWindow.ChannelTextBoxSelectAll
        'Try
        txtChannel.SelectAll()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_ClearChannelsListBox() Handles channelFolderWindow.ClearChannelsListBox
        'Try
        lstChannels.Items.Clear()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_ClearNetworkComboBox() Handles channelFolderWindow.ClearNetworkComboBox
        'Try
        cboNetwork.Items.Clear()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_FormClosed() Handles channelFolderWindow.FormClosed
        'Try
        Me.Close()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_RemoveChannelListBoxItem(channel As String) Handles channelFolderWindow.RemoveChannelListBoxItem
        'Try
        Dim channelFolderIndexes As List(Of Integer)
        If (Not String.IsNullOrEmpty(channel)) Then
            channelFolderIndexes = Modules.lSettings.FindChannelFolderIndexes(channel, cboNetwork.Text)
            lstChannels.Items.RemoveAt(Modules.ReturnRadListBoxIndex(lstChannels, lstChannels.SelectedItem().ToString))
            For Each index As Integer In channelFolderIndexes
                lSettings.RemoveChannelFolder(index)
            Next index
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_SetAutoCloseCheckBoxValue(_Value As Boolean) Handles channelFolderWindow.SetAutoCloseCheckBoxValue
        'Try
        chkCloseOnJoin.Checked = _Value
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_SetChannelTextBoxTextToListBoxText() Handles channelFolderWindow.SetChannelTextBoxTextToListBoxText
        'Try
        If (lstChannels.SelectedItem IsNot Nothing) Then
            txtChannel.Text = lstChannels.SelectedItem.Text
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_SetDefaultNetwork(network As String) Handles channelFolderWindow.SetDefaultNetwork
        'Try
        Modules.SetSelectedRadComboBoxItem(cboNetwork, network)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub channelFolderWindow_SetPopupChannelFoldersCheckBoxValue(_Value As Boolean) Handles channelFolderWindow.SetPopupChannelFoldersCheckBoxValue
        'Try
        chkPopupOnConnect.Checked = _Value
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub
#End Region
End Class