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
        txtUsername.Text = lSettings_Services.lX.xLoginNickName
        txtPassword.Text = lSettings_Services.lX.xLoginPassword
        chkXEnable.Checked = lSettings_Services.lX.xEnable
        chkLoginOnConnect.Checked = lSettings_Services.lX.xLoginOnConnect
        chkShowOnConnect.Checked = lSettings_Services.lX.xShowOnConnect
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        lSettings_Services.lX.xEnable = CBool(chkXEnable.Checked)
        lSettings_Services.lX.xLoginNickName = txtUsername.Text
        lSettings_Services.lX.xLoginPassword = txtPassword.Text
        lSettings_Services.lX.xShowOnConnect = CBool(chkShowOnConnect.Checked)
        lSettings_Services.lX.xLoginOnConnect = CBool(chkLoginOnConnect.Checked)
        lSettings_Services.SaveServices()
        lStatus.PrivateMessage_User(lStatusIndex, lSettings_Services.lX.xLongName, "LOGIN " & lSettings_Services.lX.xLoginNickName & " " & lSettings_Services.lX.xLoginPassword)
        Me.Close()
    End Sub

    Private Sub lblCreateAnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAnAccount.Click
        mdiMain.BrowseURL(lSettings_Services.lX.xCreateAnAccountURL)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
End Class