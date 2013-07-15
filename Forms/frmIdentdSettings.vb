'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmIdentdSettings
    Private Sub frmIdentdSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        With lIRC.iIdent
            txtIdentdPort.Text = .iPort.ToString
            txtIdentdSystem.Text = .iSystem
            txtIdentdUserID.Text = .iUserID
            chkIdentdEnabled.Checked = .iSettings.iEnabled
        End With
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmIdentdSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'On Error Resume Next
        With lIRC.iIdent
            .iPort = CType(txtIdentdPort.Text, Integer)
            .iSettings.iEnabled = chkIdentdEnabled.Checked
            .iSystem = txtIdentdSystem.Text
            .iUserID = txtIdentdUserID.Text
        End With
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub
End Class