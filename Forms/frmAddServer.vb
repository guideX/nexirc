Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmAddServer
    Public WithEvents lAddServer As New clsAddServer
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        lAddServer.cmdCancel_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        lAddServer.cmdOK_Click(txtIP, txtPort, cboNetwork.Text, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub
    Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        lAddServer.Form_Load(cboNetwork)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewNetwork.Click
        'Try
        lAddServer.cmdNewNetwork_Click(cboNetwork)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewNetwork.Click")
        'End Try
    End Sub
End Class