Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Models.Network
Imports nexIRC.Models.Server
Imports nexIRC.Business.Controllers
Namespace IRC.UtilityWindows
    Public Class clsAddServer
        Public lConnectSetting As Boolean
        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub Form_Load(_RadDropDownList As RadDropDownList)
            lSettings.FillRadComboWithNetworks(_RadDropDownList, True)
        End Sub
        Public Sub cmdOK_Click(description As String, ip As String, port As Integer, network As String)
            If (ip.Length = 0) Then
                Beep()
                Exit Sub
            End If
            If (port = 0) Then
                Beep()
                Exit Sub
            End If
            If (description.Length = 0) Then
                Beep()
                Exit Sub
            End If
            Dim server As New ServerModel
            server.Description = description
            server.Ip = ip
            server.Port = port
            Using c = New ConnectionController(lSettings.lINI.iNetworks, lSettings.lINI.iRecientServers)
                Dim networkIndex = c.FindNetworkIndex(network, lSettings.lNetworks.Networks)
                If (networkIndex IsNot Nothing) Then
                    server.NetworkIndex = networkIndex.Value
                    If (c.CreateServer(server)) Then
                        If (lConnectSetting = True) Then
                            Modules.lSettings.lServers.Index = networkIndex.Value
                            Modules.lStatus.SetRemoteSettings(Modules.lStatus.ActiveIndex(), ip, port)
                            Modules.lStatus.ActiveStatusConnect()
                        End If
                    End If
                End If
            End Using
        End Sub
        Public Sub cmdNewNetwork_Click(rddl As RadDropDownList)
            Dim description = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
            If (Not String.IsNullOrEmpty(description)) Then
                Dim n = New NetworkModel
                n.Name = description
                Using c = New ConnectionController(lSettings.lINI.iNetworks, lSettings.lINI.iRecientServers)
                    If (c.CreateNetwork(n, Modules.lSettings.lNetworks.Networks)) Then
                        lSettings.FillRadComboWithNetworks(rddl)
                        rddl.SelectedIndex = rddl.FindRadComboIndex(description)
                    End If
                End Using
            End If
        End Sub
    End Class
End Namespace