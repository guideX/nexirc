'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmIdentdSettings
    Private Sub frmIdentdSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With lSettings.lIRC.iIdent
                txtIdentdPort.Text = .iPort.ToString
                txtIdentdSystem.Text = .iSystem
                txtIdentdUserID.Text = .iUserID
                chkIdentdEnabled.Checked = .iSettings.iEnabled
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            With lSettings.lIRC.iIdent
                .iPort = CType(txtIdentdPort.Text, Integer)
                .iSettings.iEnabled = chkIdentdEnabled.Checked
                .iSystem = txtIdentdSystem.Text
                .iUserID = txtIdentdUserID.Text
            End With
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class