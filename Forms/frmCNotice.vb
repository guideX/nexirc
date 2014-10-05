Option Explicit On
Option Strict On
Public Class FrmCNotice
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Try
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, clsCommandTypes.eCommandTypes.cNOTICE, txtNickname.Text, txtChannel.Text, txtMessage.Text)
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class