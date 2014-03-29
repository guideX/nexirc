Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports nexIRC.Modules
Namespace IRC.UtilityWindows
    Public Class clsChangeNickName
        Public lServerIndex As Integer
        Public Sub Form_Load(_RadListBox As RadListControl)
            Try
                For i As Integer = 1 To lSettings.lIRC.iNicks.nCount
                    With lSettings.lIRC.iNicks.nNick(i)
                        If Len(.nNick) <> 0 Then
                            _RadListBox.Items.Add(.nNick)
                        End If
                    End With
                Next i
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Private Sub Form_Load()")
            End Try
        End Sub
        Public Sub lstNickNames_DoubleClick(_NickName As String, _Form As Form)
            Try
                cmdOK_Click(_NickName, _Form)
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Private Sub lstNickNames_DoubleClick(sender As Object, e As System.EventArgs) Handles lstNickNames.DoubleClick")
            End Try
        End Sub
        Public Sub lstNickNames_SelectedIndexChanged(_NickName As String, _NickNameTextBox As RadTextBox)
            Try
                _NickNameTextBox.Text = _NickName
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Private Sub lstNickNames_SelectedIndexChanged(_NickName As String, _NickNameTextBox As RadTextBox)")
            End Try
        End Sub
        Public Sub cmdOK_Click(_NickName As String, _Form As Form)
            Try
                If Len(_NickName) <> 0 Then
                    lStatus.NickName(lServerIndex, True) = _NickName
                    _Form.Close()
                Else
                    If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("You must select a nickname")
                End If
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
            End Try
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
            End Try
        End Sub
    End Class
End Namespace