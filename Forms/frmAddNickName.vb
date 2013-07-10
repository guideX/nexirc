Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmAddNickname
    Private WithEvents lAddNickName As New clsAddNickName
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lAddNickName.cmdCancel_Click(Me)
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lAddNickName.cmdOK_Click(Me, txtNickName.Text)
    End Sub
    Private Sub frmAddNickname_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lAddNickName.Form_Load(txtNickName)
    End Sub
    Private Sub txtNickName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickName.KeyPress
        lAddNickName.txtNickname_KeyPress(Me, e.KeyChar, txtNickName.Text)
    End Sub
End Class
