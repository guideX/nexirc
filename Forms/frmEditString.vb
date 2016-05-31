'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmEditString
    Private Sub frmEditString_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer
            Me.Icon = mdiMain.Icon
            For i = -999 To 999
                cboNumeric.Items.Add(Trim(Convert.ToString(i)))
            Next i
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim n As Integer, i As Integer
            n = lStrings.FindStringIndexByDescription(txtDescription.Text)
            If n <> 0 Then
                lStrings.SetStringData(n, txtData.Text)
                lStrings.SetStringSupport(n, txtSupport.Text)
                lStrings.SetStringSyntax(n, txtSyntax.Text)
                If lSettings.lWinVisible.wCustomize = True Then
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
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            Dim msg As String
            msg = InputBox("Add Text String Parameter")
            If (Not String.IsNullOrEmpty(msg)) Then
                lStrings.AddTextStringParameter(CType(cboNumeric.Text, Integer), msg)
                lstParameters.Items.Add(msg)
            Else
                If lSettings.lIRC.iSettings.sPrompts = True Then
                    MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Try
            lStrings.RemoveTextStringParameter(CType(cboNumeric.Text, Integer), lstParameters.Text)
            lstParameters.Items.RemoveAt(lstParameters.SelectedIndex)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class