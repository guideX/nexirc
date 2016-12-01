'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows

Public Class frmAddServer
    Public WithEvents addServer As New clsAddServer

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            addServer.cmdCancel_Click(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Try
            addServer.cmdOK_Click(txtIP, txtPort, cboNetwork.Text, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            addServer.Form_Load(cboNetwork)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewNetwork.Click
        Try
            addServer.cmdNewNetwork_Click(cboNetwork)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class