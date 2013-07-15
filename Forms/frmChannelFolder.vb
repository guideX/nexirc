'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannelFolder
    Private lChannelFolderWindow As New clsChannelFolderWindow
    Public Sub Init()
        'Try
        lChannelFolderWindow.Init(cboNetwork, chkPopupOnConnect, chkCloseOnJoin)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Init()")
        'End Try
    End Sub
    Public Sub SetStatusIndex(_StatusIndex As Integer)
        'Try
        lChannelFolderWindow.SetStatusIndex(_StatusIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetStatusIndex(_StatusIndex As Integer)")
        'End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        'Try
        lChannelFolderWindow.cmdClose_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click")
        'End Try
    End Sub
    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        'Try
        lChannelFolderWindow.Form_FormClosed(chkPopupOnConnect.Checked, chkCloseOnJoin.Checked, Me.Left, Me.Top)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)")
        'End Try
    End Sub
    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        lChannelFolderWindow.Form_Load(Me, cboNetwork, chkPopupOnConnect, chkCloseOnJoin)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load")
        'End Try
    End Sub
    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        'Try
        lChannelFolderWindow.cmdJoin_Click(txtChannel.Text, chkCloseOnJoin.Checked, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
        'End Try
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Try
        lChannelFolderWindow.cmdAdd_Click(txtChannel.Text, lstChannels, cboNetwork.Text)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click")
        'End Try
    End Sub
    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        'Try
        lChannelFolderWindow.lstChannels_DoubleClick(lstChannels.SelectedItem.Text, chkCloseOnJoin.Checked, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
        'End Try
    End Sub
    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        'Try
        lChannelFolderWindow.lstChannels_SelectedIndexChanged(lstChannels, txtChannel)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
        'End Try
    End Sub
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        'Try
        lChannelFolderWindow.cmdRemove_Click(txtChannel.Text, lstChannels)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
        'End Try
    End Sub
    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        'Try
        lChannelFolderWindow.cboNetwork_SelectedIndexChanged(lstChannels, cboNetwork.Text)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        'End Try
    End Sub
    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        'Try
        lChannelFolderWindow.lnkJumpToChannelList_LinkClicked(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked")
        'End Try
    End Sub
    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        'Try
        lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
        'End Try
    End Sub
    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        'Try
        lChannelFolderWindow.txtChannel_Enter(MouseButtons, sender)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
        'End Try
    End Sub
    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        'Try
        lChannelFolderWindow.txtChannel_Leave()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
        'End Try
    End Sub
    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        'Try
        lChannelFolderWindow.txtChannel_MouseUp(sender)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
        'End Try
    End Sub

    Private Sub lstChannels_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstChannels.SelectedIndexChanged

    End Sub
End Class