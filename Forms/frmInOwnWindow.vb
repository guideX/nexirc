Option Explicit On
Option Strict On
Public Class frmInOwnWindow
    Private Sub frmInOwnWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        chkMOTDInOwnWindow.Checked = lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = lIRC.iSettings.sShowRawWindow
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmInOwnWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
        lIRC.iSettings.sMOTDInOwnWindow = chkMOTDInOwnWindow.Checked
        lIRC.iSettings.sNoticesInOwnWindow = chkNoticesInOwnWindow.Checked
        lIRC.iSettings.sShowRawWindow = chkShowRawWindow.Checked
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub
End Class