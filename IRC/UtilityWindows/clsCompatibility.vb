Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Namespace IRC.UtilityWindows
    Public Class clsCompatibility
        Public Sub cmdCancel_Click(_Form As Form)
            'Try
            _Form.Close()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub cmdCancel_Click(_Form As Form)")
            'End Try
        End Sub
        Public Sub cmdOK_Click(_Form As Form)
            'Try
            SaveCompatibility()
            _Form.Close()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub cmdOK_Click(_Form As Form)")
            'End Try
        End Sub
        Private Sub SetListViewToCompatibility(ByVal _RadListView As RadListView)
            Dim _ListViewItem As ListViewDataItem
            'Try
            _RadListView.Items.Clear()
            _RadListView.Columns.Clear()
            _RadListView.Columns.Add("Description", "Description")
            _RadListView.Columns.Add("Supported", "Supported")
            For i As Integer = 1 To lCompatibility.cCount
                With lCompatibility.cCompatibility(i)
                    _ListViewItem = New ListViewDataItem
                    '_ListViewItem.Text = .cDescription
                    _ListViewItem.Item(0) = .cDescription
                    _ListViewItem.Item(1) = .cEnabled.ToString
                    _RadListView.Items.Add(_ListViewItem)
                End With
            Next i
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub SetListViewToCompatibility(ByVal lListView As RadListView)")
            'End Try
        End Sub
        Public Sub Form_Load(_RadListView As RadListView)
            'Try
            SetListViewToCompatibility(_RadListView)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub frmCompatibility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
            'End Try
        End Sub
        Public Sub lvwCompatibility_DoubleClick(_RadListView As RadListView)
            'Try
            Dim _MsgBoxResult As MsgBoxResult, i As Integer
            lCompatibility.cModified = True
            Select Case _RadListView.SelectedItems.Count
                Case 1
                    _MsgBoxResult = MsgBox("Would you like the item '" & _RadListView.SelectedItems(0).Text & "' to enabled?", MsgBoxStyle.YesNo)
                    i = FindCompatibilityIndex(_RadListView.SelectedItems(0).Text)
                    If i <> 0 Then
                        With lCompatibility.cCompatibility(i)
                            Select Case _MsgBoxResult
                                Case MsgBoxResult.Yes
                                    .cEnabled = True
                                Case MsgBoxResult.No
                                    .cEnabled = False
                            End Select
                        End With
                    End If
            End Select
            SetListViewToCompatibility(_RadListView)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub lvwCompatibility_DoubleClick(_RadListView As RadListView)")
            'End Try
        End Sub
        Public Sub lblAdd_LinkClicked(_SelectedCompatibilityItem As String)
            'Try
            Dim mbox As MsgBoxResult, msg As String, b As Boolean
            msg = InputBox("Description: ")
            mbox = MsgBox("Would you like the item '" & _SelectedCompatibilityItem & "' to enabled?", MsgBoxStyle.YesNo)
            Select Case mbox
                Case MsgBoxResult.Yes
                    b = True
                Case MsgBoxResult.No
                    b = False
            End Select
            AddToCompatibility(msg, b)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub lblAdd_LinkClicked(_SelectedCompatibilityItem As String)")
            'End Try
        End Sub
        Public Sub lblRemove_LinkClicked(_SelectedCompatibilityItem As String)
            'Try
            RemoveFromCompatibility(FindCompatibilityIndex(_SelectedCompatibilityItem))
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub lblRemove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRemove.LinkClicked")
            'End Try
        End Sub
    End Class
End Namespace