'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Public Class frmSendNotice
    Public lSendNoticeUI As New clsSendNoticeUI
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lSendNoticeUI.cmdOK_Click(txtMessage, txtNickName)
    End Sub
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lSendNoticeUI.cmdCancel_Click(Me)
    End Sub
    Private Sub frmPrivateMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lSendNoticeUI.Form_Load(Me)
    End Sub
End Class