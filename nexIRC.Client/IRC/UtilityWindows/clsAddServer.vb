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
                Throw
            End Try
        End Sub
        Public Sub Form_Load(_RadDropDownList As RadDropDownList)
            Try
                lSettings.FillRadComboWithNetworks(_RadDropDownList, True)
            Catch ex As Exception
                Throw
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
                    _NetworkIndex = lSettings.AddServer(_Network, _IpTextBox.Text, _NetworkIndex, _PortTextBox.Text.ToLong)
                End If
                If lConnectSetting = True Then
                    lSettings.lServers.Index = _NetworkIndex
                    lStatus.SetRemoteSettings(lStatus.ActiveIndex(), _IpTextBox.Text, _PortTextBox.Text.ToLong)
                    lStatus.ActiveStatusConnect()
                End If
                _Form.Close()
            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Sub cmdNewNetwork_Click(rddl As RadDropDownList)
            Dim description As String, n As Integer
            description = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
            If Len(description) <> 0 Then
                n = lSettings.AddNetwork(description)
                If (n <> 0) Then
                    lSettings.FillRadComboWithNetworks(rddl)
                    rddl.SelectedIndex = rddl.FindRadComboIndex(description)
                End If
            End If
        End Sub
    End Class
End Namespace