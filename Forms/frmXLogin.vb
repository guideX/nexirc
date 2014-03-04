'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmXLogin
    Public WithEvents lXLogin As New clsXLoginUI
    Private Sub frmXLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lXLogin.lForm = Me
        lXLogin.lUsernameTextBox = txtUsername
        lXLogin.lPasswordTextBox = txtPassword
        lXLogin.lEnableCheckBox = chkXEnable
        lXLogin.lLoginOnConnect = chkLoginOnConnect
        lXLogin.lShowOnConnect = chkShowOnConnect
        lXLogin.frmXLogin_Load()
    End Sub
    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        lXLogin.cmdLogin_Click()
    End Sub
    Private Sub lblCreateAnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAnAccount.Click
        'lXLogin.lblCreateAnAccount_Click()
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        lXLogin.cmdCancel_Click()
    End Sub
End Class