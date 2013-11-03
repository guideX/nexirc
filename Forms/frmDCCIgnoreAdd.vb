'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmDCCIgnoreAdd
    Private Sub frmDCCIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Icon = mdiMain.Icon
            txtValue.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmDCCIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            With lSettings_DCC.lDCC.dIgnorelist
                If optNickName.Checked = True Then
                    frmCustomize.lstDCCIgnoreItems.Items.Add(txtValue.Text)
                ElseIf optFileType.Checked = True Then
                    frmCustomize.lstIgnoreExtensions.Items.Add(txtValue.Text)
                End If
            End With
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
End Class