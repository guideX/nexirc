Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmChangeNickName
    Public WithEvents lChangeNickName As New clsChangeNickName
    Private Sub frmChangeNickName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lChangeNickName.Form_Load(lstNickNames)
    End Sub
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lChangeNickName.cmdCancel_Click(Me)
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lChangeNickName.cmdOK_Click(txtNickName.Text, Me)
    End Sub
    Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick
        lChangeNickName.lstNickNames_DoubleClick(lstNickNames.Text, Me)
    End Sub
    Private Sub lstNickNames_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstNickNames.SelectedIndexChanged
        lChangeNickName.lstNickNames_SelectedIndexChanged(lstNickNames.SelectedItem.Text, txtNickName)
    End Sub
End Class