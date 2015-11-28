'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows
Public Class frmChangeNickName
    Public WithEvents ChangeNickName As New clsChangeNickName

    Private Sub frmChangeNickName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            ChangeNickName.Form_Load(lstNickNames)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            ChangeNickName.cmdCancel_Click(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Try
            ChangeNickName.cmdOK_Click(lstNickNames.SelectedItem.Text, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick
        Try
            ChangeNickName.lstNickNames_DoubleClick(lstNickNames.SelectedItem.Text, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstNickNames_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstNickNames.SelectedIndexChanged
        Try
            ChangeNickName.lstNickNames_SelectedIndexChanged(lstNickNames.SelectedItem.Text, txtNickName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        Try
            lstNickNames.Items.Add(txtNickName.Text)
            Modules.lSettings.AddNickName(txtNickName.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class