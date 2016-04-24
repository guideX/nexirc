'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Public Class frmDCCChat
    Public WithEvents lDccChatUI As New clsDccChat
    Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        lDccChatUI.txtIncoming_MouseDown()
    End Sub
    Private Sub frmDCCChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lDccChatUI.Form_Load(Me, cboUsers, cmdConnect, cmdDisconnect, txtIncoming, tlsDCCChat, txtOutgoing)
    End Sub
    Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus
        lDccChatUI.txtOutgoing_GotFocus()
    End Sub
    Private Sub txtIncoming_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        lDccChatUI.txtIncoming_TextChanged()
    End Sub
    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        lDccChatUI.cmdDisconnect_Click()
    End Sub
    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        lDccChatUI.txtOutgoing_KeyDown(e)
    End Sub
    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        lDccChatUI.txtOutgoing_MouseDown()
    End Sub
    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        lDccChatUI.cmdConnect_Click()
    End Sub
    'Private Sub frmDCCChat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    'lDccChatUI.frmDCCChat_Resize()
    'End Sub
End Class