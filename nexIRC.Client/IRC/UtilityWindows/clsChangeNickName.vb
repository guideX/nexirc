Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI

Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsChangeNickName
        Public ServerIndex As Integer

        Public Sub Form_Load(_RadListBox As RadListControl)
            For i As Integer = 1 To Modules.lSettings.lIRC.iNicks.nCount
                With Modules.lSettings.lIRC.iNicks.nNick(i)
                    If Len(.nNick) <> 0 Then
                        _RadListBox.Items.Add(.nNick)
                    End If
                End With
            Next i
        End Sub

        Public Sub lstNickNames_DoubleClick(_NickName As String, _Form As Form)
            cmdOK_Click(_NickName, _Form)
        End Sub

        Public Sub cmdAdd_Click(nickName As String, nickNamesListBox As RadListControl)
            nickNamesListBox.Items.Add(nickName)
            Modules.lSettings.AddNickName(nickName)
        End Sub

        Public Sub lstNickNames_SelectedIndexChanged(_NickName As String, _NickNameTextBox As RadTextBox)
            _NickNameTextBox.Text = _NickName
        End Sub

        Public Sub cmdOK_Click(_NickName As String, _Form As Form)
            If Len(_NickName) <> 0 Then
                Modules.lStatus.NickName(ServerIndex, True) = _NickName
                _Form.Close()
            Else
                If Modules.lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("You must select a nickname")
            End If
        End Sub

        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub
    End Class
End Namespace