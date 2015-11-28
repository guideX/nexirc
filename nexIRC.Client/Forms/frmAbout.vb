Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows

Public Class frmAbout
    Private WithEvents lAbout As New clsAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lAbout.Form_Load(Me, Me.RadPageView1)
    End Sub

    Private Sub RadPageView1_SelectedPageChanged(sender As Object, e As EventArgs) Handles RadPageView1.SelectedPageChanged

    End Sub
End Class