'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannelFolder
    Private lChannelFolderWindow As New clsChannelFolderWindow
    Public Sub Init()
        lChannelFolderWindow.Init(cboNetwork, chkPopupOnConnect, chkCloseOnJoin)
    End Sub
    Public Sub SetStatusIndex(_StatusIndex As Integer)
        lChannelFolderWindow.SetStatusIndex(_StatusIndex)
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        lChannelFolderWindow.cmdClose_Click(Me)
    End Sub
    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        lChannelFolderWindow.Form_FormClosed(chkPopupOnConnect.Checked, chkCloseOnJoin.Checked, Me.Left, Me.Top)
    End Sub
    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        lChannelFolderWindow.Form_Load(Me, cboNetwork, chkPopupOnConnect, chkCloseOnJoin)
    End Sub
    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        lChannelFolderWindow.cmdJoin_Click(txtChannel.Text, chkCloseOnJoin.Checked, Me)
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        lChannelFolderWindow.cmdAdd_Click(txtChannel.Text, lstChannels, cboNetwork.Text)
    End Sub
    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        lChannelFolderWindow.lstChannels_DoubleClick(lstChannels.SelectedItem.Text, chkCloseOnJoin.Checked, Me)
    End Sub
    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        lChannelFolderWindow.lstChannels_SelectedIndexChanged(lstChannels, txtChannel)
    End Sub
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        lChannelFolderWindow.cmdRemove_Click(txtChannel.Text, lstChannels)
    End Sub
    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        lChannelFolderWindow.cboNetwork_SelectedIndexChanged(lstChannels, cboNetwork.Text)
    End Sub
    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        lChannelFolderWindow.lnkJumpToChannelList_LinkClicked(Me)
    End Sub
    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
    End Sub
    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
    End Sub
    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        lChannelFolderWindow.txtChannel_Leave()
    End Sub
    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        lChannelFolderWindow.txtChannel_MouseUp(sender)
    End Sub

    Private Sub lstChannels_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstChannels.SelectedIndexChanged

    End Sub
End Class