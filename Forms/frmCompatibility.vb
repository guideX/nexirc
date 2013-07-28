'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmCompatibility
    Private WithEvents lCompatibility As New clsCompatibility
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        lCompatibility.cmdOK_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message,"Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        lCompatibility.cmdCancel_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Private Sub lnkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked
        'Try
        lCompatibility.lblAdd_LinkClicked(lvwCompatibility.SelectedItem.Text)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked")
        'End Try
    End Sub
    Private Sub lnkRemove_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRemove.LinkClicked
        'Try
        lCompatibility.lblRemove_LinkClicked(lvwCompatibility.SelectedItem.Text)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkRemove_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRemove.LinkClicked")
        'End Try
    End Sub
    Private Sub frmCompatibility_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Try
        lCompatibility.Form_Load(lvwCompatibility)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmCompatibility_Load(sender As Object, e As System.EventArgs) Handles Me.Load")
        'End Try
    End Sub
End Class