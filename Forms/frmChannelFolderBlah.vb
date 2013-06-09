'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannelFolder1
    Private lChannelFolderWindow As clsChannelFolderWindow
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        'Try
        lChannelFolderWindow.cmdClose_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click")
        'End Try
    End Sub
    Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        lChannelFolderWindow.frmChannelFolder_FormClosed(chkPopupOnConnect.Checked, chkAutoClose.Checked, Me.Left, Me.Top)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannelFolder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        'End Try
    End Sub
    Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try

    End Sub

    Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click
        'Try

        If Len(txtChannel.Text) <> 0 Then
            If chkAutoClose.Checked = True Then Me.Close()
            lChannels.Join(lStatusIndex, txtChannel.Text)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
        'End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Try
        Dim i As Integer
        If Len(txtChannel.Text) <> 0 Then
            lstChannels.Items.Add(txtChannel.Text)
            i = FindNetworkIndex(cboNetwork.Text)
            If i <> 0 Then
                AddToChannelFolders(txtChannel.Text, i)
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click")
        'End Try
    End Sub

    Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick
        'Try
        lChannels.Join(lStatusIndex, txtChannel.Text)
        If chkAutoClose.Checked = True Then Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
        'End Try
    End Sub

    Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged
        'Try
        txtChannel.Text = lstChannels.Text
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
        'End Try
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        'Try
        Dim i As Integer
        If Len(txtChannel.Text) <> 0 Then
            RemoveChannelFolder(FindChannelFolderIndex(txtChannel.Text))
            i = ReturnListBoxIndex(lstChannels, lstChannels.SelectedItem().ToString)
            lstChannels.Items.RemoveAt(i)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
        'End Try
    End Sub

    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        'Try
        Dim i As Integer
        lstChannels.Items.Clear()
        For i = 1 To lChannelFolders.cCount
            If LCase(Trim(lNetworks.nNetwork(FindNetworkIndex(lChannelFolders.cChannelFolder(i).cNetwork)).nDescription)) = LCase(Trim(cboNetwork.Text)) Then
                lstChannels.Items.Add(lChannelFolders.cChannelFolder(i).cChannel)
            End If
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        'End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click")
        'End Try
    End Sub

    Private Sub lnkJumpToChannelList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkJumpToChannelList.LinkClicked
        'Try
        ProcessReplaceCommand(lStatusIndex, eCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex))
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "lnkJumpToChannelList_LinkClicked")
        'End Try
    End Sub

    Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter
        'Try
        If MouseButtons = Windows.Forms.MouseButtons.None Then lLastFocused = CType(sender, Control)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
        'End Try
    End Sub

    Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus
        'Try
        txtChannel.SelectAll()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
        'End Try
    End Sub

    Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave
        'Try
        lLastFocused = Nothing
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
        'End Try
    End Sub

    Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp
        'Try
        With CType(sender, TextBox)
            If lLastFocused IsNot sender AndAlso .SelectionLength = 0 Then .SelectAll()
        End With
        lLastFocused = CType(sender, Control)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
        'End Try
    End Sub

    Private Sub txtChannel_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChannel.TextChanged

    End Sub
End Class