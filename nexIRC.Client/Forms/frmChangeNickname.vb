Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows

Public Class frmChangeNickName
    Public WithEvents ChangeNickName As New clsChangeNickName

    Private Sub frmChangeNickName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ChangeNickName.Form_Load(lstNickNames)
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        ChangeNickName.cmdCancel_Click(Me)
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        ChangeNickName.cmdOK_Click(lstNickNames.SelectedItem.Text, Me)
    End Sub

    Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick
        ChangeNickName.lstNickNames_DoubleClick(lstNickNames.SelectedItem.Text, Me)
    End Sub

    Private Sub lstNickNames_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstNickNames.SelectedIndexChanged
        ChangeNickName.lstNickNames_SelectedIndexChanged(lstNickNames.SelectedItem.Text, txtNickName)
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        ChangeNickName.cmdAdd_Click(txtNickName.Text, lstNickNames)
    End Sub
End Class