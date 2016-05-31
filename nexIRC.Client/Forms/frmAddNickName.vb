Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmAddNickname
    Private WithEvents lAddNickName As New clsAddNickName
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            lAddNickName.cmdCancel_Click(Me)
        Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Try
            lAddNickName.cmdOK_Click(Me, txtNickName.Text)
        Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub
    Private Sub frmAddNickname_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            lAddNickName.Form_Load(txtNickName)
        Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub frmAddNickname_Load(sender As Object, e As System.EventArgs) Handles Me.Load")
        End Try
    End Sub
    Private Sub txtNickName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickName.KeyPress
        Try
            lAddNickName.txtNickname_KeyPress(Me, e.KeyChar, txtNickName.Text)
        Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub txtNickName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickName.KeyPress")
        End Try
    End Sub
End Class
