'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules

Public Class frmRaw
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        'On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Private Sub frmRaw_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'On Error Resume Next
        lStatus.SetRawWindowClosed(lStatusIndex)
        lStatus.SetRawData(lStatusIndex, txtInData.Text, txtOutData.Text)
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub frmRaw_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
    End Sub

    Private Sub frmRaw_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'On Error Resume Next
        lStatus.ActiveIndex = lStatusIndex
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub frmRaw_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus")
    End Sub

    Private Sub frmRaw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Me.Icon = mdiMain.Icon
        Me.MdiParent = mdiMain
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub frmRaw_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
    End Sub

    Private Sub frmRaw_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'On Error Resume Next
        txtInData.Width = Me.ClientSize.Width
        txtInData.Height = Convert.ToInt32(Me.ClientSize.Height / 2)
        txtOutData.Top = txtInData.Height + 4
        txtOutData.Width = txtInData.Width
        txtOutData.Height = txtInData.Height - 2
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub frmRaw_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
    End Sub

    Private Sub txtOutData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutData.GotFocus
        'On Error Resume Next
        If lSettings.lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub txtOutData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutData.GotFocus")
    End Sub

    Private Sub txtOutData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutData.MouseDown
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub txtOutData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutData.MouseDown")
    End Sub

    Private Sub txtInData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInData.GotFocus
        'On Error Resume Next
        If lSettings.lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub txtInData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInData.GotFocus")
    End Sub

    Private Sub txtInData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInData.MouseDown
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then Throw 'ProcessError(ex.Message, "Private Sub txtInData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInData.MouseDown")
    End Sub
End Class