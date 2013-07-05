Option Explicit On
Option Strict On
Public Class frmAddServer
    Public WithEvents lAddServer As New clsAddServer

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lAddServer.cmdCancel_Click(Me)
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lAddServer.cmdOK_Click(txtIP, txtPort, cboNetwork.Text, Me)
    End Sub

    Private Sub frmAddServer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lAddServer.Form_Load(cboNetwork)
    End Sub

    Private Sub cmdNewNetwork_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewNetwork.Click
        lAddServer.cmdNewNetwork_Click(cboNetwork)
    End Sub
End Class