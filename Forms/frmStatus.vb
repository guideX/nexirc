'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmStatus
    Public WithEvents lMdiChildWindow As New clsMdiChildWindow
    Public WithEvents lAutoConnectDelayTimer As New Timer

    Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        'Try
        lMdiChildWindow.TextBox_LinkClicked(e.LinkText)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown
        'Try
        lMdiChildWindow.txtIncomingColor_MouseDown(Me, txtOutgoing)
        lStatus.ActiveIndex = lMdiChildWindow.MeIndex
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        'End Try
    End Sub

    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        'Try
        lMdiChildWindow.txtOutgoing_GotFocus(Me)
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
        lMdiChildWindow.txtIncomingColor_MouseUp(txtIncomingColor.SelectedText, txtOutgoing)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
        'End Try
    End Sub

    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        'Try
        lMdiChildWindow.cmdDisconnect_Click()
        'lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click")
        'End Try
    End Sub

    'Private Sub cmdChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeConnection.Click
    ''Try
    'lMdiChildWindow.cmdChangeConnection_Click()
    ''Catch ex As Exception
    'ProcessError(ex.Message, "Private Sub cmd_ChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeConnection.Click")
    ''End Try
    'End Sub

    Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick
        'Try
        lMdiChildWindow.cmdToggleConnection_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick")
        'End Try
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        'Try
        lMdiChildWindow.cmdConnect_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click")
        'End Try
    End Sub

    Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick
        'Try
        lMdiChildWindow.tmrConnectDelay_Tick()
        lAutoConnectDelayTimer.Enabled = False
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        'Try
        lMdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing)
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
        lMdiChildWindow.cmdSendNewNotice_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click")
        'End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'Try
        lMdiChildWindow.cmdNewPrivateMessage_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click")
        'End Try
    End Sub

    Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click
        'Try
        lMdiChildWindow.cmdListChannels_Click()
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
        lMdiChildWindow.Form_Load(txtIncomingColor, txtOutgoing, Me, clsMdiChildWindow.eFormTypes.fStatus)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
End Class