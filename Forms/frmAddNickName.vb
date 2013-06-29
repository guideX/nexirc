'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmAddNickName
    Private Sub OK_Button()
        On Error Resume Next
        If Len(txtNickname.Text) <> 0 Then AddNickName(txtNickname.Text)
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub OK_Button()")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        OK_Button()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub txtNickname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickname.KeyPress
        On Error Resume Next
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            OK_Button()
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub txtNickname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNickname.KeyPress")
    End Sub

    Private Sub frmAddNickName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmAddNickName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub
End Class