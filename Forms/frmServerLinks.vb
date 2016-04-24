'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmServerLinks
    Public lServerLinksUI As New clsServerLinks
    Private Sub frmServerLinks_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lServerLinksUI.frmServerLinks_FormClosing(lvwLinks)
    End Sub
    Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lServerLinksUI.Form_Load(Me, cboNetworks, lvwLinks)
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        lServerLinksUI.cmdOK_Click(Me, lvwLinks, cboNetworks)
    End Sub
End Class