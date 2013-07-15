'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules

Public Class frmXLogin
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        lStatusIndex = lIndex
    End Sub

    Private Sub frmXLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = mdiMain.Icon
        txtUsername.Text = lX.xLoginNickName
        txtPassword.Text = lX.xLoginPassword
        chkXEnable.Checked = lX.xEnable
        chkLoginOnConnect.Checked = lX.xLoginOnConnect
        chkShowOnConnect.Checked = lX.xShowOnConnect
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        lX.xEnable = CBool(chkXEnable.Checked)
        lX.xLoginNickName = txtUsername.Text
        lX.xLoginPassword = txtPassword.Text
        lX.xShowOnConnect = CBool(chkShowOnConnect.Checked)
        lX.xLoginOnConnect = CBool(chkLoginOnConnect.Checked)
        SaveServices()
        lStatus.PrivateMessage_User(lStatusIndex, lX.xLongName, "LOGIN " & lX.xLoginNickName & " " & lX.xLoginPassword)
        Me.Close()
    End Sub

    Private Sub lblCreateAnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAnAccount.Click
        mdiMain.BrowseURL(lX.xCreateAnAccountURL)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
End Class