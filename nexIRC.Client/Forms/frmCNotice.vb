Option Explicit On
Option Strict On

Imports nexIRC.Business.Enums

Public Class FrmCNotice
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cNOTICE, txtNickname.Text, txtChannel.Text, txtMessage.Text)
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmCNotice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = mdiMain.Icon
    End Sub
End Class