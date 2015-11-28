'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsAddNickName
        Public Sub Form_Load(_RadTextBox As RadTextBox)
            Try
                _RadTextBox.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdOK_Click(_Form As Form, _NickName As String)
            Try
                If (_NickName.Length) <> 0 Then
                    frmCustomize.cboMyNickNames.Items.Add(_NickName)
                    _Form.Close()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub txtNickname_KeyPress(_Form As Form, _Char As Char, _NickName As String)
            Try
                If _Char = Convert.ToChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                    Modules.lSettings.AddNickName(_NickName)
                    _Form.Close()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace