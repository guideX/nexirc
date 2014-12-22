Option Explicit On
Option Strict On
Public Class FrmKick
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, clsCommandTypes.eCommandTypes.cKICK, txtChannel.Text, txtNickname.Text)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class