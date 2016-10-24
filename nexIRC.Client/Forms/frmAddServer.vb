'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Imports nexIRC.Models.Server

Public Class frmAddServer
    Public WithEvents addServer As New clsAddServer

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs)
        Try
            addServer.cmdCancel_Click(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs)
        If (txtIP.Text.Length = 0) Then
            Beep()
            txtIP.Focus()
            Exit Sub
        End If
        If (txtPort.Text.Length = 0) Then
            Beep()
            txtPort.Focus()
            Exit Sub
        End If
        If (txtDescription.Text.Length = 0) Then
            Beep()
            txtDescription.Focus()
            Exit Sub
        End If
        addServer.cmdOK_Click(txtDescription.Text, txtIP.Text, Convert.ToInt32(txtPort.Text), cboNetwork.Text)
    End Sub

    Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            addServer.Form_Load(cboNetwork)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs)
        Try
            addServer.cmdNewNetwork_Click(cboNetwork)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdOK_Click_1(sender As Object, e As EventArgs) Handles cmdOK.Click

    End Sub
End Class