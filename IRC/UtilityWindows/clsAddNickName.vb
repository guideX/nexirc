'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Namespace IRC.UtilityWindows
    Public Class clsAddNickName
        Public Sub Form_Load(_RadTextBox As RadTextBox)
            'Try
            _RadTextBox.Focus()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub Form_Load(_RadTextBox As RadTextBox)")
            'End Try
        End Sub
        Public Sub cmdOK_Click(_Form As Form, _NickName As String)
            'Try
            If (_NickName.Length) <> 0 Then
                AddNickName(_NickName)
                _Form.Close()
            End If
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub cmdOK_Click()")
            'End Try
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            'Try
            _Form.Close()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub cmdCancel_Click()")
            'End Try
        End Sub
        Public Sub txtNickname_KeyPress(_Form As Form, _Char As Char, _NickName As String)
            'Try
            If _Char = Convert.ToChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                AddNickName(_NickName)
                _Form.Close()
            End If
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub txtNickname_KeyPress(_Char As Char)")
            'End Try
        End Sub
    End Class
End Namespace