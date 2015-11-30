Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI

Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsCompatibility
        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub

        Public Sub cmdOK_Click(_Form As Form)
            Modules.lSettings.SaveCompatibility()
            _Form.Close()
        End Sub

        Private Sub SetListViewToCompatibility(ByVal _RadListView As RadListView)
            Dim _ListViewItem As ListViewDataItem
            _RadListView.Items.Clear()
            _RadListView.Columns.Clear()
            _RadListView.Columns.Add("Description", "Description")
            _RadListView.Columns.Add("Supported", "Supported")
            For i As Integer = 1 To Modules.lSettings.lCompatibility.cCount
                With Modules.lSettings.lCompatibility.cCompatibility(i)
                    _ListViewItem = New ListViewDataItem
                    _ListViewItem.Item(0) = .cDescription
                    _ListViewItem.Item(1) = .cEnabled.ToString
                    _RadListView.Items.Add(_ListViewItem)
                End With
            Next i
        End Sub

        Public Sub Form_Load(_RadListView As RadListView)
            SetListViewToCompatibility(_RadListView)
        End Sub

        Public Sub lvwCompatibility_DoubleClick(_RadListView As RadListView)
            Dim _MsgBoxResult As MsgBoxResult, i As Integer
            Modules.lSettings.lCompatibility.cModified = True
            Select Case _RadListView.SelectedItems.Count
                Case 1
                    _MsgBoxResult = MsgBox("Would you like the item '" & _RadListView.SelectedItems(0).Text & "' to enabled?", MsgBoxStyle.YesNo)
                    i = Modules.lSettings.FindCompatibilityIndex(_RadListView.SelectedItems(0).Text)
                    If i <> 0 Then
                        With Modules.lSettings.lCompatibility.cCompatibility(i)
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
        End Sub

        Public Sub lblAdd_LinkClicked(_SelectedCompatibilityItem As String)
            Dim mbox As MsgBoxResult, msg As String, b As Boolean
            msg = InputBox("Description: ")
            mbox = MsgBox("Would you like the item '" & _SelectedCompatibilityItem & "' to enabled?", MsgBoxStyle.YesNo)
            Select Case mbox
                Case MsgBoxResult.Yes
                    b = True
                Case MsgBoxResult.No
                    b = False
            End Select
            Modules.lSettings.AddToCompatibility(msg, b)
        End Sub

        Public Sub lblRemove_LinkClicked(_SelectedCompatibilityItem As String)
            Modules.lSettings.RemoveFromCompatibility(Modules.lSettings.FindCompatibilityIndex(_SelectedCompatibilityItem))
        End Sub
    End Class
End Namespace