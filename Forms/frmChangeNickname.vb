Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmChangeNickName
    Public WithEvents lChangeNickName As New clsChangeNickName
    Private Sub frmChangeNickName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        lChangeNickName.Form_Load(lstNickNames)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChangeNickName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        lChangeNickName.cmdCancel_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        lChangeNickName.cmdOK_Click(txtNickName.Text, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub
    Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick
        'Try
        lChangeNickName.lstNickNames_DoubleClick(lstNickNames.Text, Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick")
        'End Try
    End Sub
    Private Sub lstNickNames_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstNickNames.SelectedIndexChanged
        'Try
        lChangeNickName.lstNickNames_SelectedIndexChanged(lstNickNames.SelectedItem.Text, txtNickName)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstNickNames_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstNickNames.SelectedIndexChanged")
        'End Try
    End Sub
End Class