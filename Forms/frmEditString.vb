'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmEditString
    Private Sub frmEditString_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Dim i As Integer
        Me.Icon = mdiMain.Icon
        For i = -999 To 999
            cboNumeric.Items.Add(Trim(CStr(i)))
        Next i
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'On Error Resume Next
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'On Error Resume Next
        Dim n As Integer, i As Integer
        n = FindStringIndexByDescription(txtDescription.Text)
        If n <> 0 Then
            SetStringData(n, txtData.Text)
            SetStringSupport(n, txtSupport.Text)
            SetStringSyntax(n, txtSyntax.Text)
            If lWinVisible.wCustomize = True Then
                i = FindRadListViewIndex(frmCustomize.lvwStrings, txtDescription.Text)
                If i <> 0 Then
                    With frmCustomize.lvwStrings.Items(i)
                        .Text = txtDescription.Text
                        .Item(1) = txtSupport.Text
                        .Item(2) = txtSyntax.Text
                        .Item(3) = cboNumeric.Text
                        .Item(4) = txtData.Text
                    End With
                End If
            End If
        End If
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Try
        Dim msg As String
        msg = InputBox("Add Text String Parameter")
        If Len(msg) <> 0 Then
            AddTextStringParameter(CType(cboNumeric.Text, Integer), msg)
            lstParameters.Items.Add(msg)
        Else
            If lIRC.iSettings.sPrompts = True Then
                MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click")
        'End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Try
        RemoveTextStringParameter(CType(cboNumeric.Text, Integer), lstParameters.Text)
        lstParameters.Items.RemoveAt(lstParameters.SelectedIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click")
        'End Try
    End Sub
End Class