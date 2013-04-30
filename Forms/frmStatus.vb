'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Text

Public Class frmStatus
    Private lMeIndex As Integer
    Public WithEvents lMdiChildWindow As New clsMdiChildWindow
    Public WithEvents lAutoConnectDelayTimer As New Timer

    Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click
        'Try
        lMdiChildWindow.txtIncomingColor_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click")
        'End Try
    End Sub

    Private Sub txtIncomingColor_GotFocus(sender As Object, e As System.EventArgs) Handles txtIncomingColor.GotFocus
        'Try
        lMdiChildWindow.txtIncomingColor_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_GotFocus(sender As Object, e As System.EventArgs) Handles txtIncomingColor.GotFocus")
        'End Try
    End Sub

    Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        'Try
        lMdiChildWindow.TextBox_LinkClicked(e.LinkText)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown
        'Try
        lMdiChildWindow.Form_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        'End Try
    End Sub

    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        'Try
        lMdiChildWindow.Form_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        'Try
        lMdiChildWindow.Form_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        'End Try
    End Sub

    Private Sub frmStatus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        lMdiChildWindow.Form_Resize(txtIncomingColor, txtOutgoing, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmStatus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp
        'Try
        If Len(txtIncomingColor.SelectedText) <> 0 Then
            Clipboard.Clear()
            Clipboard.SetText(txtIncomingColor.SelectedText)
        End If
        txtOutgoing.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
        'End Try
    End Sub

    Private Sub cmd_JoinChannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        frmChannelJoin.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_JoinChannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_ChannelList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        ProcessReplaceCommand(lMeIndex, eCommandTypes.cLIST)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_Disconnect_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        If lStatus.Connected(lMeIndex) = True Or lStatus.ReturnStatusConnecting(lMeIndex) = True Then
            lStatus.CloseStatusConnection(lMeIndex, True)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Disconnect_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lStatus.Quit(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_CloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lStatus.CloseStatusConnection(lMeIndex, True)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_CloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        frmChangeConnection.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Change.Click")
        'End Try
    End Sub

    Private Sub cmd_ChannelJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        frmChannelJoin.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelJoin.Click")
        'End Try
    End Sub

    Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        ProcessReplaceCommand(lMeIndex, eCommandTypes.cLIST)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ListChannels.Click")
        'End Try
    End Sub

    Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        frmChannelFolder.SetStatusIndex(lStatus.ActiveIndex())
        frmChannelFolder.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Private Sub cmd_Disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lStatus.Quit(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        'Try
        lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click")
        'End Try
    End Sub

    Private Sub cmdChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeConnection.Click
        'Try
        frmChangeConnection.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeConnection.Click")
        'End Try
    End Sub

    Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick
        'Try
        lStatus.ToggleConnection(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick")
        'End Try
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        'Try
        'lStatus.StatusConnectProc(lMeIndex)
        lStatus.Connect(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click")
        'End Try
    End Sub

    Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick
        'Try
        lAutoConnectDelayTimer.Enabled = False
        lStatus.Connect(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        'Try
        Dim msg As String
        If e.KeyCode = 13 Then
            msg = txtOutgoing.Text
            txtOutgoing.Text = ""
            lStatus.ProcessUserInput(lMeIndex, msg)
            e.SuppressKeyPress = True
            'e.Handled = True
            Exit Sub
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Private Sub frmStatus_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        lMdiChildWindow.Form_FormClosing(Me, e)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)")
        'End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        'Try
        frmSendNotice.StatusIndex = lMeIndex
        frmSendNotice.Visible = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click")
        'End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'Try
        Dim _Form As New frmPrivateMessage
        _Form.StatusIndex = lMeIndex
        _Form.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click")
        'End Try
    End Sub

    Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click
        'Try
        ProcessReplaceCommand(lMeIndex, eCommandTypes.cLIST)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click")
        'End Try
    End Sub

    Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate
        'Try
        lMdiChildWindow.Form_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate")
        'End Try
    End Sub

    Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        'Try
        lMdiChildWindow.Form_GotFocus(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus")
        'End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'Try
        lMdiChildWindow.cmdChangeNickName_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click")
        'End Try
    End Sub

    Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        lMdiChildWindow.Form_Load(txtIncomingColor, txtOutgoing, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
End Class