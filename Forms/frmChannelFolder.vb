'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.UI
Public Class frmChannelFolder
    Private WithEvents lChannelFolderWindow As New clsChannelFolderUI
    Public Sub Init()
        Try
            lChannelFolderWindow.Init()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Init()")
        End Try
    End Sub
    Public Sub SetStatusIndex(_StatusIndex As Integer)
        Try
            lChannelFolderWindow.SetStatusIndex(_StatusIndex)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(_StatusIndex As Integer)")
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try
            lChannelFolderWindow.cmdClose_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click")
        End Try
    End Sub
    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Try
            lChannelFolderWindow.Form_FormClosed(chkPopupOnConnect.Checked, chkCloseOnJoin.Checked, Me.Left, Me.Top)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)")
        End Try
    End Sub
    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lChannelFolderWindow.Form_Load()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load")
        End Try
    End Sub
    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        Try
            lChannelFolderWindow.cmdJoin_Click(txtChannel.Text, chkCloseOnJoin.Checked)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
        End Try
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            lChannelFolderWindow.cmdAdd_Click(txtChannel.Text, cboNetwork.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click")
        End Try
    End Sub
    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        Try
            lChannelFolderWindow.lstChannels_DoubleClick(lstChannels.SelectedItem.Text, chkCloseOnJoin.Checked)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
        End Try
    End Sub
    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        Try
            lChannelFolderWindow.lstChannels_SelectedIndexChanged()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
        End Try
    End Sub
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Try
            lChannelFolderWindow.cmdRemove_Click(txtChannel.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
        End Try
    End Sub
    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        Try
            lChannelFolderWindow.cboNetwork_SelectedIndexChanged(cboNetwork.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        End Try
    End Sub
    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        Try
            lChannelFolderWindow.lnkJumpToChannelList_LinkClicked()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked")
        End Try
    End Sub
    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        Try
            lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
        End Try
    End Sub
    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        Try
            lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
        End Try
    End Sub
    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        Try
            lChannelFolderWindow.txtChannel_Leave()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
        End Try
    End Sub
    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        Try
            lChannelFolderWindow.txtChannel_MouseUp(sender)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
        End Try
    End Sub
    Private Sub lChannelFolderWindow_AddChannelToListBox(_Channel As String) Handles lChannelFolderWindow.AddChannelToListBox
        lstChannels.Items.Add(_Channel)
    End Sub
    Private Sub lChannelFolderWindow_AddNetworkComboBoxItem(_Network As String) Handles lChannelFolderWindow.AddNetworkComboBoxItem
        cboNetwork.Items.Add(_Network)
    End Sub
    Private Sub lChannelFolderWindow_AnimateClose() Handles lChannelFolderWindow.AnimateClose
        clsAnimate.Animate(Me, clsAnimate.Effect.Center, 200, 1)
        Me.Close()
    End Sub
    Private Sub lChannelFolderWindow_ChannelTextBoxSelectAll() Handles lChannelFolderWindow.ChannelTextBoxSelectAll
        txtChannel.SelectAll()
    End Sub
    Private Sub lChannelFolderWindow_ClearChannelsListBox() Handles lChannelFolderWindow.ClearChannelsListBox
        lstChannels.Items.Clear()
    End Sub
    Private Sub lChannelFolderWindow_ClearNetworkComboBox() Handles lChannelFolderWindow.ClearNetworkComboBox
        cboNetwork.Items.Clear()
    End Sub
    Private Sub lChannelFolderWindow_FormClosed() Handles lChannelFolderWindow.FormClosed
        Me.Close()
    End Sub
    Private Sub lChannelFolderWindow_RemoveChannelListBoxItem(_Channel As String) Handles lChannelFolderWindow.RemoveChannelListBoxItem
        Try
            If Len(_Channel) <> 0 Then
                RemoveChannelFolder(FindChannelFolderIndex(_Channel))
                lstChannels.Items.RemoveAt(Modules.ReturnRadListBoxIndex(lstChannels, lstChannels.SelectedItem().ToString))
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelFolderWindow_RemoveChannelListBoxItem(_Channel As String) Handles lChannelFolderWindow.RemoveChannelListBoxItem")
        End Try
    End Sub
    Private Sub lChannelFolderWindow_SetAutoCloseCheckBoxValue(_Value As Boolean) Handles lChannelFolderWindow.SetAutoCloseCheckBoxValue
        Try
            chkCloseOnJoin.Checked = _Value
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelFolderWindow_SetAutoCloseCheckBoxValue(_Value As Boolean) Handles lChannelFolderWindow.SetAutoCloseCheckBoxValue")
        End Try
    End Sub
    Private Sub lChannelFolderWindow_SetChannelTextBoxTextToListBoxText() Handles lChannelFolderWindow.SetChannelTextBoxTextToListBoxText
        Try
            If (lstChannels.SelectedItem IsNot Nothing) Then
                txtChannel.Text = lstChannels.SelectedItem.Text
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelFolderWindow_SetChannelTextBoxTextToListBoxText() Handles lChannelFolderWindow.SetChannelTextBoxTextToListBoxText")
        End Try
    End Sub
    Private Sub lChannelFolderWindow_SetDefaultNetwork(_Network As String) Handles lChannelFolderWindow.SetDefaultNetwork
        Try
            Modules.SetSelectedRadComboBoxItem(cboNetwork, _Network)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelFolderWindow_SetDefaultNetwork(_Network As String) Handles lChannelFolderWindow.SetDefaultNetwork")
        End Try
    End Sub
    Private Sub lChannelFolderWindow_SetPopupChannelFoldersCheckBoxValue(_Value As Boolean) Handles lChannelFolderWindow.SetPopupChannelFoldersCheckBoxValue
        Try
            chkPopupOnConnect.Checked = _Value
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lChannelFolderWindow_SetPopupChannelFoldersCheckBoxValue(_Value As Boolean) Handles lChannelFolderWindow.SetPopupChannelFoldersCheckBoxValue")
        End Try
    End Sub
End Class