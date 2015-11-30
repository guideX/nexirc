Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows

Public Class frmAddServer
    Public WithEvents addServer As New clsAddServer

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        addServer.cmdCancel_Click(Me)
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        addServer.cmdOK_Click(txtIP, txtPort, cboNetwork.Text, Me)
    End Sub

    Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        addServer.Form_Load(cboNetwork)
    End Sub

    Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewNetwork.Click
        addServer.cmdNewNetwork_Click(cboNetwork)
    End Sub
End Class