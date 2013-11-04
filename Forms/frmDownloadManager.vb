'INCOMPLETE
'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmDownloadManager

    Private Sub frmDownloadManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Me.Icon = mdiMain.Icon
        SetListViewToDownloadManager(lvwDownloadManager)
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmDownloadManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub frmDownloadManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'On Error Resume Next
        lvwDownloadManager.Width = Me.Width - (lvwDownloadManager.Left + 28)
        lvwDownloadManager.Height = Me.Height - (lvwDownloadManager.Top + (cmdRun.Height * 2) + (lvwDownloadManager.Top * 2))
        cmdClose.Top = Me.Height - (cmdClose.Height + (lvwDownloadManager.Top * 2)) - 20
        cmdClose.Left = lvwDownloadManager.Width - (cmdClose.Width - 12)
        cmdRun.Left = cmdClose.Left - (cmdRun.Width + 5)
        cmdRun.Top = Me.Height - (cmdClose.Height + (lvwDownloadManager.Top * 2)) - 20
        cmdClear.Left = cmdRun.Left - (cmdClear.Width + 4)
        cmdClear.Top = cmdRun.Top
        cmdOpenLocation.Top = cmdClear.Top
        cmdOpenLocation.Left = lvwDownloadManager.Left
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmDownloadManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        'On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click")
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'On Error Resume Next
        lvwDownloadManager.Items.Clear()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click")
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        'On Error Resume Next
        Dim msg As String = lvwDownloadManager.SelectedItems(0).Text, v As Boolean, p As Boolean
        Select Case DoRight(msg, 4)
            Case ".txt"

            Case ".gif"
                p = True
            Case ".jpg"
                p = True
            Case ".bmp"
                p = True
            Case ".png"
                p = True
            Case ".tif"
                p = True
            Case ".mp4"
                v = True
            Case ".avi "
                v = True
            Case ".wmv"
                v = True
            Case "mpeg"
                v = True
            Case ".wmx"
                v = True
            Case ".mpg"
                v = True
        End Select
        If v = True Then
            If lIRC.iSettings.sVideoBackground = True Then
                mdiMain.PlayVideo(ReturnDownloadManagerFullPath(msg))
                Exit Sub
            End If
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click")
    End Sub

    Private Sub lvwDownloadManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDownloadManager.Click
        'MsgBox(lvwDownloadManager.SelectedItems(0).Text)
    End Sub

    Private Sub lvwDownloadManager_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDownloadManager.DoubleClick
        'On Error Resume Next
        Dim msg As String = lvwDownloadManager.SelectedItems(0).Text
        Select Case DoRight(LCase(Trim(msg)), 4)
            Case ".txt"


        End Select
        MsgBox(msg)
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub lvwDownloadManager_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDownloadManager.SelectedIndexChanged")
    End Sub

    Private Sub lvwDownloadManager_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDownloadManager.SelectedIndexChanged
    End Sub
End Class