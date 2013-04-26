'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmCompatibility
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCancel.Click")
        'End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
        SaveCompatibility()
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub

    Private Sub SetListViewToCompatibility(ByVal lListView As ListView)
        Dim lItem As ListViewItem
        lvwCompatibility.Items.Clear()
        lvwCompatibility.Columns.Clear()
        lListView.Columns.Add("Description", 150)
        lListView.Columns.Add("Supported", 50)
        For i As Integer = 1 To lCompatibility.cCount
            With lCompatibility.cCompatibility(i)
                lItem = New ListViewItem
                lItem = lListView.Items.Add(.cDescription)
                lItem.SubItems.Add(.cEnabled.ToString)
            End With
        Next i
    End Sub

    Private Sub frmCompatibility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        Me.Icon = mdiMain.Icon
        SetListViewToCompatibility(lvwCompatibility)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmCompatibility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub

    Private Sub lvwCompatibility_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwCompatibility.DoubleClick
        'Try
        Dim mbox As MsgBoxResult, i As Integer
        lCompatibility.cModified = True
        Select Case lvwCompatibility.SelectedItems.Count
            Case 1
                mbox = MsgBox("Would you like the item '" & lvwCompatibility.SelectedItems(0).Text & "' to enabled?", MsgBoxStyle.YesNo)
                i = FindCompatibilityIndex(lvwCompatibility.SelectedItems(0).Text)
                If i <> 0 Then
                    With lCompatibility.cCompatibility(i)
                        Select Case mbox
                            Case MsgBoxResult.Yes
                                .cEnabled = True
                            Case MsgBoxResult.No
                                .cEnabled = False
                        End Select
                    End With
                End If
        End Select
        SetListViewToCompatibility(lvwCompatibility)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwCompatibility_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwCompatibility.DoubleClick")
        'End Try
    End Sub

    Private Sub lblAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAdd.LinkClicked
        'Try
        Dim mbox As MsgBoxResult, msg As String, b As Boolean
        msg = InputBox("Description: ")
        mbox = MsgBox("Would you like the item '" & lvwCompatibility.SelectedItems(0).Text & "' to enabled?", MsgBoxStyle.YesNo)
        Select Case mbox
            Case MsgBoxResult.Yes
                b = True
            Case MsgBoxResult.No
                b = False
        End Select
        AddToCompatibility(msg, b)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lblAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAdd.LinkClicked")
        'End Try
    End Sub

    Private Sub lblRemove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRemove.LinkClicked
        'Try
        RemoveFromCompatibility(FindCompatibilityIndex(lvwCompatibility.SelectedItems(0).Text))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lblRemove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRemove.LinkClicked")
        'End Try
    End Sub
End Class