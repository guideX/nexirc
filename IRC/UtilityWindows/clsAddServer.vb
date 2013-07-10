Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Namespace IRC.UtilityWindows
    Public Class clsAddServer
        Public lConnectSetting As Boolean
        Private lNetwork As String
        Public Property Network() As String
            Get
                Try
                    Return lNetwork
                Catch ex As Exception
                    ProcessError(ex.Message, "Public Property lNetwork() As String")
                    Return Nothing
                End Try
            End Get
            Set(_Network As String)
                Try
                    lNetwork = _Network
                Catch ex As Exception
                    ProcessError(ex.Message, "Public Property lNetwork() As String")
                End Try
            End Set
        End Property
        Public Sub cmdCancel_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdCancel_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub Form_Load(_RadDropDownList As RadDropDownList)
            Try
                FillRadComboWithNetworks(_RadDropDownList, True)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub Form_Load(_RadDropDownList As RadDropDownList)")
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
                _NetworkIndex = FindNetworkIndex(_Network)
                If _NetworkIndex <> 0 Then
                    _NetworkIndex = AddServer(_Network, _IpTextBox.Text, _NetworkIndex, Convert.ToInt64(_PortTextBox.Text.Trim))
                End If
                If lConnectSetting = True Then
                    lServers.sIndex = _NetworkIndex
                    lStatus.SetRemoteSettings(lStatus.ActiveIndex(), _IpTextBox.Text, Convert.ToInt64(_PortTextBox.Text.Trim))
                    lStatus.ActiveStatusConnect()
                End If
                _Form.Close()
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdOK_Click()")
            End Try
        End Sub
        Public Sub cmdNewNetwork_Click(_RadDropDownList As RadDropDownList)
            Try
                Dim _NetworkDescription As String, _NetworkIndex As Integer
                _NetworkDescription = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
                If Len(_NetworkDescription) <> 0 Then
                    _NetworkIndex = AddNetwork(_NetworkDescription)
                    If _NetworkIndex <> 0 Then
                        FillRadComboWithNetworks(_RadDropDownList)
                        _RadDropDownList.SelectedIndex = FindRadComboIndex(_RadDropDownList, _NetworkDescription)
                    End If
                End If
                'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdNewNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewNetwork.Click")
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdNewNetwork_Click()")
            End Try
        End Sub
        Public Sub mnuServerLists_Click()
            Try
                mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub mnuServerLists_Click()")
            End Try
        End Sub
    End Class
End Namespace