Option Explicit On
Option Strict On
Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.Client

Public Class FrmCNotice
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cNOTICE, txtNickname.Text, txtChannel.Text, txtMessage.Text)
        Me.Close()
    End Sub

    Private Sub FrmCNotice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = mdiMain.Icon
    End Sub
End Class