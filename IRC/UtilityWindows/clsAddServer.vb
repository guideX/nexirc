Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Namespace IRC.UtilityWindows
    Public Class clsAddServer
        Public lConnectSetting As Boolean
        Public Sub cmdCancel_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex 'Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub Form_Load(_RadDropDownList As RadDropDownList)
            Try
                lSettings.FillRadComboWithNetworks(_RadDropDownList, True)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdOK_Click(_IpTextBox As RadTextBox, _PortTextBox As RadTextBox, _Network As String, _Form As Form)
            Try
                Dim _NetworkIndex As Integer
                If _IpTextBox.Text.Length = 0 Then
                    Beep()
                    _IpTextBox.Focus()
                    Exit Sub
                End If
                If _PortTextBox.Text.Length = 0 Then
                    Beep()
                    _PortTextBox.Focus()
                    Exit Sub
                End If
                _NetworkIndex = lSettings.FindNetworkIndex(_Network)
                If _NetworkIndex <> 0 Then
                    _NetworkIndex = lSettings.AddServer(_Network, _IpTextBox.Text, _NetworkIndex, Convert.ToInt64(_PortTextBox.Text.Trim))
                End If
                If lConnectSetting = True Then
                    lSettings.lServers.sIndex = _NetworkIndex
                    lStatus.SetRemoteSettings(lStatus.ActiveIndex(), _IpTextBox.Text, Convert.ToInt64(_PortTextBox.Text.Trim))
                    lStatus.ActiveStatusConnect()
                End If
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdNewNetwork_Click(_RadDropDownList As RadDropDownList)
            Try
                Dim _NetworkDescription As String, _NetworkIndex As Integer
                _NetworkDescription = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
                If Len(_NetworkDescription) <> 0 Then
                    _NetworkIndex = lSettings.AddNetwork(_NetworkDescription)
                    If _NetworkIndex <> 0 Then
                        lSettings.FillRadComboWithNetworks(_RadDropDownList)
                        _RadDropDownList.SelectedIndex = FindRadComboIndex(_RadDropDownList, _NetworkDescription)
                    End If
                End If
                'If Err.Number <> 0 Then Throw ex 'Throw ex 'ProcessError(ex.Message, "Private Sub cmdNewNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewNetwork.Click")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace