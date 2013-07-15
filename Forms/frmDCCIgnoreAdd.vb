'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmDCCIgnoreAdd
    Private Sub frmDCCIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = mdiMain.Icon
        txtValue.Focus()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        With lDCC.dIgnorelist
            If optNickName.Checked = True Then
                frmCustomize.lstDCCIgnoreItems.Items.Add(txtValue.Text)
            ElseIf optFileType.Checked = True Then
                frmCustomize.lstIgnoreExtensions.Items.Add(txtValue.Text)
            End If
        End With
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class