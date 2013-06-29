'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmEditUserProfile
    Private Sub frmEditUserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        With lIRC
            txtEMail.Text = .iEMail
            txtPassword.Text = .iPass
            txtRealName.Text = .iRealName
            txtOperName.Text = .iOperName
            txtOperPass.Text = .iOperPass
        End With
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmEditUserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim splt() As String
        If InStr(txtEMail.Text, "@") <> 0 Then
            splt = Split(txtEMail.Text, "@")
            With lIRC
                .iEMail = txtEMail.Text
                .iPass = txtPassword.Text
                '.iRealName = txtRealName.Text
                .iRealName = splt(0)
                .iOperName = txtOperName.Text
                .iOperPass = txtOperPass.Text
            End With
            Me.Close()
        Else
            MsgBox("Email invalid!")
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub
End Class