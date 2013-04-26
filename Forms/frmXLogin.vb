'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmXLogin
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        lStatusIndex = lIndex
    End Sub

    Private Sub frmXLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        txtUsername.Text = lX.xLoginNickName
        txtPassword.Text = lX.xLoginPassword
        chkXEnable.Checked = lX.xEnable
        chkLoginOnConnect.Checked = lX.xLoginOnConnect
        chkShowOnConnect.Checked = lX.xShowOnConnect
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        On Error Resume Next
        lX.xEnable = CBool(chkXEnable.Checked)
        lX.xLoginNickName = txtUsername.Text
        lX.xLoginPassword = txtPassword.Text
        lX.xShowOnConnect = CBool(chkShowOnConnect.Checked)
        lX.xLoginOnConnect = CBool(chkLoginOnConnect.Checked)
        SaveServices()
        lStatus.PrivateMessage_User(lStatusIndex, lX.xLongName, "LOGIN " & lX.xLoginNickName & " " & lX.xLoginPassword)
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click")
    End Sub

    Private Sub lblCreateAnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAnAccount.Click
        On Error Resume Next
        mdiMain.BrowseURL(lX.xCreateAnAccountURL)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lblCreateAnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAnAccount.Click")
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
End Class