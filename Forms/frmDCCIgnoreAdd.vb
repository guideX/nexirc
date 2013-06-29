'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmDCCIgnoreAdd
    Private Sub frmDCCIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Icon = mdiMain.Icon
        txtValue.Focus()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmDCCIgnoreAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        With lDCC.dIgnorelist
            If optNickName.Checked = True Then
                frmCustomize.lstDCCIgnoreItems.Items.Add(txtValue.Text)
            ElseIf optFileType.Checked = True Then
                frmCustomize.lstIgnoreExtensions.Items.Add(txtValue.Text)
            End If
        End With
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub
End Class