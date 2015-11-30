Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client
Imports nexIRC.Client.nexIRC.Client.IRC.Channels

Public Class frmChannelFolder
    Private WithEvents channelFolderWindow As New clsChannelFolderUI
#Region "Window Subs"
    Public Sub Init()
    End Sub

    Public Sub SetStatusIndex(statusId As Integer)
        channelFolderWindow.SetStatusIndex(statusId)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        channelFolderWindow.cmdClose_Click()
    End Sub

    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        channelFolderWindow.Form_FormClosed(chkPopupOnConnect.Checked, chkCloseOnJoin.Checked, Me.Left, Me.Top)
    End Sub

    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        channelFolderWindow.Form_Load(cboNetwork)
    End Sub

    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        channelFolderWindow.cmdJoin_Click(txtChannel.Text, chkCloseOnJoin.Checked)
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        channelFolderWindow.cmdAdd_Click(txtChannel.Text, cboNetwork.Text)
    End Sub

    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        channelFolderWindow.lstChannels_DoubleClick(lstChannels.SelectedItem.Text, chkCloseOnJoin.Checked)
    End Sub

    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        channelFolderWindow.lstChannels_SelectedIndexChanged()
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        channelFolderWindow.cmdRemove_Click(txtChannel.Text)
    End Sub

    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        channelFolderWindow.cboNetwork_SelectedIndexChanged(cboNetwork.Text)
    End Sub

    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        channelFolderWindow.lnkJumpToChannelList_LinkClicked()
    End Sub

    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        channelFolderWindow.txtChannel_Enter(MouseButtons, sender)
    End Sub

    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        channelFolderWindow.txtChannel_Enter(MouseButtons, sender)
    End Sub

    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        channelFolderWindow.txtChannel_Leave()
    End Sub

    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        channelFolderWindow.txtChannel_MouseUp(sender)
    End Sub
#End Region
#Region "Events"
    Private Sub channelFolderWindow_AddChannelToListBox(_Channel As String) Handles channelFolderWindow.AddChannelToListBox
        lstChannels.Items.Add(_Channel)
    End Sub

    Private Sub channelFolderWindow_AddNetworkComboBoxItem(_Network As String) Handles channelFolderWindow.AddNetworkComboBoxItem
        cboNetwork.Items.Add(_Network)
    End Sub

    Private Sub channelFolderWindow_AnimateClose() Handles channelFolderWindow.AnimateClose
        Me.Close()
    End Sub

    Private Sub channelFolderWindow_ChannelTextBoxSelectAll() Handles channelFolderWindow.ChannelTextBoxSelectAll
        txtChannel.SelectAll()
    End Sub

    Private Sub channelFolderWindow_ClearChannelsListBox() Handles channelFolderWindow.ClearChannelsListBox
        lstChannels.Items.Clear()
    End Sub

    Private Sub channelFolderWindow_ClearNetworkComboBox() Handles channelFolderWindow.ClearNetworkComboBox
        cboNetwork.Items.Clear()
    End Sub

    Private Sub channelFolderWindow_FormClosed() Handles channelFolderWindow.FormClosed
        Me.Close()
    End Sub

    Private Sub channelFolderWindow_RemoveChannelListBoxItem(channel As String) Handles channelFolderWindow.RemoveChannelListBoxItem
        Modules.IrcSettings.ChannelFoldersRepository.Delete(Modules.IrcSettings.ChannelFoldersRepository.Find(channel, cboNetwork.Text))
    End Sub

    Private Sub channelFolderWindow_SetAutoCloseCheckBoxValue(_Value As Boolean) Handles channelFolderWindow.SetAutoCloseCheckBoxValue
        chkCloseOnJoin.Checked = _Value
    End Sub

    Private Sub channelFolderWindow_SetChannelTextBoxTextToListBoxText() Handles channelFolderWindow.SetChannelTextBoxTextToListBoxText
        If (lstChannels.SelectedItem IsNot Nothing) Then txtChannel.Text = lstChannels.SelectedItem.Text
    End Sub

    Private Sub channelFolderWindow_SetDefaultNetwork(network As String) Handles channelFolderWindow.SetDefaultNetwork
        General.SetSelectedRadComboBoxItem(cboNetwork, network)
    End Sub

    Private Sub channelFolderWindow_SetPopupChannelFoldersCheckBoxValue(_Value As Boolean) Handles channelFolderWindow.SetPopupChannelFoldersCheckBoxValue
        chkPopupOnConnect.Checked = _Value
    End Sub
#End Region
End Class