'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmNickServLogin
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub

    Private Sub frmNickServLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
            txtPassword.Text = lNickServ.nLoginPassword
            chkLoginOnConnect.Checked = lNickServ.nLoginOnConnect
            chkShowOnConnect.Checked = lNickServ.nShowOnConnect
            'chkXEnable.Checked = lNickServ.nEnable
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmNickServLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub

    Private Sub cmdLogin_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogin.Click
        Try
            'lNickServ.nEnable = CBool(chkXEnable.Checked)
            lNickServ.nLoginPassword = txtPassword.Text
            lNickServ.nShowOnConnect = CBool(chkShowOnConnect.Checked)
            lNickServ.nLoginOnConnect = CBool(chkLoginOnConnect.Checked)
            SaveServices()
            lStatus.PrivateMessage_User(lStatusIndex, "nickserv", "identify " & lNickServ.nLoginPassword)
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click")
        End Try
    End Sub
End Class