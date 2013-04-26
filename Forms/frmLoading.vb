'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmLoading
    Public Sub SetProgress(ByVal lData As String, ByVal lValue As Integer)
        On Error Resume Next
        lblStatus.Text = lData
        prgLoading.Value = lValue
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetProgress(ByVal lData As String, ByVal lValue As Integer)")
    End Sub

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "nexIRC - v" & Application.ProductVersion
    End Sub
End Class