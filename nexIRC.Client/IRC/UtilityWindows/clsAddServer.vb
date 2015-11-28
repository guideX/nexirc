Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Repositories

Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsAddServer
        Public lConnectSetting As Boolean
        Public Sub cmdCancel_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub Form_Load(_RadDropDownList As RadDropDownList)
            Try
                Modules.lSettings.FillRadComboWithNetworks(_RadDropDownList, True)
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
                _NetworkIndex = Modules.IrcSettings.IrcNetworks.Find(_Network).Id
                If _NetworkIndex <> 0 Then
                    _NetworkIndex = Modules.lSettings.AddServer(_Network, _IpTextBox.Text, _NetworkIndex, Convert.ToInt64(_PortTextBox.Text.Trim))
                End If
                If lConnectSetting = True Then
                    Modules.lSettings.lServers.sIndex = _NetworkIndex
                    Modules.lStatus.SetRemoteSettings(Modules.lStatus.ActiveIndex(), _IpTextBox.Text, Convert.ToInt64(_PortTextBox.Text.Trim))
                    Modules.lStatus.ActiveStatusConnect()
                End If
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdNewNetwork_Click(_RadDropDownList As RadDropDownList)
            Dim _NetworkDescription As String, _NetworkIndex As Integer
            _NetworkDescription = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
            If Len(_NetworkDescription) <> 0 Then
                Dim network = New NetworkData()
                network.Description = _NetworkDescription
                _NetworkIndex = Modules.IrcSettings.IrcNetworks.Add(network)
                If _NetworkIndex <> 0 Then
                    Modules.lSettings.FillRadComboWithNetworks(_RadDropDownList)
                    _RadDropDownList.SelectedIndex = Modules.FindRadComboIndex(_RadDropDownList, _NetworkDescription)
                End If
            End If
        End Sub
    End Class
End Namespace