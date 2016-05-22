﻿'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows

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
        Try
            addServer.cmdOK_Click(txtIP, txtPort, cboNetwork.Text, Me)
        Catch ex As Exception
            Throw
        End Try
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
End Class