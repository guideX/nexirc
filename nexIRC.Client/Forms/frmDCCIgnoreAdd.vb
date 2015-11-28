'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Public Class frmDccIgnoreAdd
    Private Sub frmDccIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Icon = mdiMain.Icon
            txtValue.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim dccSettings = Business.Repositories.DccSettings.Read(Application.StartupPath)
            With dccSettings.dIgnorelist
                If optNickName.IsChecked = True Then
                    frmCustomize.lstDCCIgnoreItems.Items.Add(txtValue.Text)
                ElseIf optFileType.IsChecked = True Then
                    frmCustomize.lstIgnoreExtensions.Items.Add(txtValue.Text)
                End If
            End With
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class