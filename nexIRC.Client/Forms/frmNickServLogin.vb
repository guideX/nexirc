'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules

Public Class frmNickServLogin
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub frmNickServLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
            txtNickname.Text = lSettings_Services.lNickServ.nLoginNickname
            txtPassword.Text = lSettings_Services.lNickServ.nLoginPassword
            chkLoginOnConnect.Checked = lSettings_Services.lNickServ.nLoginOnConnect
            chkShowOnConnect.Checked = lSettings_Services.lNickServ.nShowOnConnect
            'chkXEnable.Checked = lNickServ.nEnable
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdLogin_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim settings As BotSettings
        Try
            settings = New BotSettings()
            lSettings_Services.lNickServ.nLoginNickname = txtNickname.Text
            lSettings_Services.lNickServ.nLoginPassword = txtPassword.Text
            lSettings_Services.lNickServ.nShowOnConnect = Convert.ToBoolean(chkShowOnConnect.Checked)
            lSettings_Services.lNickServ.nLoginOnConnect = Convert.ToBoolean(chkLoginOnConnect.Checked)
            settings.Email = lSettings_Services.lNickServ.nLoginNickname
            settings.Password = lSettings_Services.lNickServ.nLoginPassword
            lStatus.GetObject(lStatusIndex).sNickBot.Login(settings)
            lSettings_Services.SaveServices()
            Me.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Try
            If (e.KeyChar = Convert.ToChar(13)) Then
                cmdLogin_Click(sender, e)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub txtNickname_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickname.KeyPress
        Try
            If (e.KeyChar = Convert.ToChar(13)) Then
                cmdLogin_Click(sender, e)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class