'INCOMPLETE
'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Business.Helpers

Public Class frmDownloadManager
    Private Sub frmDownloadManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
            lSettings.SetListViewToDownloadManager(lvwDownloadManager)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmDownloadManager_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Try
            lvwDownloadManager.Items.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Try
            Dim msg As String = lvwDownloadManager.SelectedItems(0).Text, v As Boolean, p As Boolean
            Select Case TextHelper.DoRight(msg, 4)
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
            If p = True Then
                'If lIRC.iSettings.sShowBrowser = True Then
                'mdiMain.BrowseURL(ReturnDownloadManagerFullPath(msg))
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lvwDownloadManager_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDownloadManager.DoubleClick
        Try
            Dim msg As String = lvwDownloadManager.SelectedItems(0).Text
            Select Case TextHelper.DoRight(LCase(Trim(msg)), 4)
                Case ".txt"
            End Select
            MsgBox(msg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class