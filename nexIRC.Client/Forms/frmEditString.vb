Option Explicit On
Option Strict On
Imports nexIRC.Business.Helpers
Imports nexIRC.Client.nexIRC.Client

Public Class frmEditString
    Private Sub frmEditString_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Me.Icon = mdiMain.Icon
        For i = -999 To 999
            cboNumeric.Items.Add(Trim(Convert.ToString(i)))
        Next i
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim n As Integer, i As Integer
        n = Modules.lStrings.FindStringIndexByDescription(txtDescription.Text)
        If n <> 0 Then
            Modules.lStrings.SetStringData(n, txtData.Text)
            Modules.lStrings.SetStringSupport(n, txtSupport.Text)
            Modules.lStrings.SetStringSyntax(n, txtSyntax.Text)
            If Modules.lSettings.lWinVisible.wCustomize = True Then
                i = General.FindRadListViewIndex(frmCustomize.lvwStrings, txtDescription.Text)
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
        Dim msg As String
        msg = InputBox("Add Text String Parameter")
        If (Not String.IsNullOrEmpty(msg)) Then
            Modules.lStrings.AddTextStringParameter(CType(cboNumeric.Text, Integer), msg)
            lstParameters.Items.Add(msg)
        Else
            If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Modules.lStrings.RemoveTextStringParameter(CType(cboNumeric.Text, Integer), lstParameters.Text)
        lstParameters.Items.RemoveAt(lstParameters.SelectedIndex)
    End Sub
End Class