Option Explicit On
Option Strict On

Imports nexIRC.Business.Enums

Public Class FrmKick
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cKICK, txtChannel.Text, txtNickname.Text)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class