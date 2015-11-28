Option Explicit On
Option Strict On

Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.Client

Public Class FrmInvite
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cINVITE, txtNickname.Text, txtChannel.Text)
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
