'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Namespace IRC.UtilityWindows
    Public Class clsAddNickName
        Public Sub Form_Load(_RadTextBox As RadTextBox)
            _RadTextBox.Focus()
        End Sub
        Public Sub cmdOK_Click(_Form As Form, _NickName As String)
            If (_NickName.Length) <> 0 Then
                frmCustomize.cboMyNickNames.Items.Add(_NickName)
                _Form.Close()
            End If
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub txtNickname_KeyPress(_Form As Form, _Char As Char, _NickName As String)
            If _Char = Convert.ToChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                lSettings.AddNickName(_NickName)
                _Form.Close()
            End If
        End Sub
    End Class
End Namespace