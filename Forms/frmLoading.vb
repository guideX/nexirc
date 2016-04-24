'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On

Public Class frmLoading
    Public Sub SetProgress(ByVal lData As String, ByVal lValue As Integer)
        Try
            lblStatus.Text = lData
            prgLoading.Value = lValue
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "nexIRC - v" & Application.ProductVersion
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class