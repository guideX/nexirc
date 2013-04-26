'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmChangeNickname
    Private lServerIndex As Integer

    Public Sub SetServerWindow(ByVal lIndex As Integer)
        On Error Resume Next
        lServerIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetServerWindow(ByVal lIndex As Integer)")
    End Sub

    Private Sub frmChangeNickname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim i As Integer
        For i = 1 To lIRC.iNicks.nCount
            With lIRC.iNicks.nNick(i)
                If Len(.nNick) <> 0 Then
                    lstNickNames.Items.Add(.nNick)
                End If
            End With
        Next i
        Me.Icon = mdiMain.Icon
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmChangeNickname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick
        Try
            cmdOK_Click(sender, e)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick")
        End Try
    End Sub

    Private Sub lstNickNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNickNames.SelectedIndexChanged
        On Error Resume Next
        txtNickName.Text = lstNickNames.Text
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lstNickNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNickNames.SelectedIndexChanged")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click")
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim msg As String
        msg = txtNickName.Text
        If Len(msg) <> 0 Then
            lStatus.NickName(lServerIndex, True) = txtNickName.Text
            Me.Close()
        Else
            If lIRC.iSettings.sPrompts = True Then MsgBox("You must select a nickname")
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click")
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub
End Class