'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmSharedAdd
    Public lSharedAddUI As New clsSharedAdd
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        lSharedAddUI.cmdCancel_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        lSharedAddUI.Form_Load(Me, txtDescription)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        'Try
        lSharedAddUI.txtNetworkDescription_KeyPress(e, Me, txtDescription)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetworkDescription.KeyPress")
        'End Try
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lSharedAddUI.mnuExit_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        lSharedAddUI.cmdOK_Click(txtDescription, Me)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lSharedAddUI.ExitToolStripMenuItem_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Private Sub ServerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        lSharedAddUI.ServerListToolStripMenuItem_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ServerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
End Class