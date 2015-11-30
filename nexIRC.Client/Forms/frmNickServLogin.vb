Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client
'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Imports nexIRC.Client.nexIRC.Client.IRC.Services

Public Class frmNickServLogin
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        'Try
            lStatusIndex = lIndex
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub frmNickServLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = mdiMain.Icon
        txtNickname.Text = Modules.lSettings_Services.lNickServ.nLoginNickname
        txtPassword.Text = Modules.lSettings_Services.lNickServ.nLoginPassword
        chkLoginOnConnect.Checked = Modules.lSettings_Services.lNickServ.nLoginOnConnect
        chkShowOnConnect.Checked = Modules.lSettings_Services.lNickServ.nShowOnConnect
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
            Me.Close()
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdLogin_Click(sender As System.Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim settings As BotSettings
        'Try
            settings = New BotSettings()
            Modules.lSettings_Services.lNickServ.nLoginNickname = txtNickname.Text
            Modules.lSettings_Services.lNickServ.nLoginPassword = txtPassword.Text
            Modules.lSettings_Services.lNickServ.nShowOnConnect = Convert.ToBoolean(chkShowOnConnect.Checked)
            Modules.lSettings_Services.lNickServ.nLoginOnConnect = Convert.ToBoolean(chkLoginOnConnect.Checked)
            settings.Email = Modules.lSettings_Services.lNickServ.nLoginNickname
            settings.Password = Modules.lSettings_Services.lNickServ.nLoginPassword
            Modules.lStatus.GetObject(lStatusIndex).sNickBot.Login(settings)
            Modules.lSettings_Services.SaveServices()
            Me.Close()
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        'Try
            If (e.KeyChar = Convert.ToChar(13)) Then
                cmdLogin_Click(sender, e)
            End If
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub txtNickname_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickname.KeyPress
        'Try
            If (e.KeyChar = Convert.ToChar(13)) Then
                cmdLogin_Click(sender, e)
            End If
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub
End Class