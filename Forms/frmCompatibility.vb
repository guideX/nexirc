Imports nexIRC.IRC.UtilityWindows
Public Class frmCompatibility
    Private WithEvents lCompatibility As New clsCompatibility
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lCompatibility.cmdOK_Click(Me)
    End Sub
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lCompatibility.cmdCancel_Click(Me)
    End Sub
    Private Sub lnkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked
        lCompatibility.lblAdd_LinkClicked(lvwCompatibility.SelectedItem.Text)
    End Sub
    Private Sub lnkRemove_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRemove.LinkClicked
        lCompatibility.lblRemove_LinkClicked(lvwCompatibility.SelectedItem.Text)
    End Sub
    Private Sub frmCompatibility_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lCompatibility.Form_Load(lvwCompatibility)
    End Sub
End Class