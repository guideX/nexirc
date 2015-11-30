Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Helpers

Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsChooseNetwork
        Public lServerToChange As Integer
        Public lNetworkIndex As Integer

        Public Sub Form_Load(ByVal _RadDropDownList As RadDropDownList, ByVal _Form As Form)
            Dim networks = Modules.IrcSettings.IrcNetworks.Get()
            For Each network In networks
                If (Not String.IsNullOrEmpty(network.Description)) Then
                    _RadDropDownList.Items.Add(network.Description)
                End If
            Next network
            _RadDropDownList.Text = Modules.IrcSettings.IrcNetworks.GetById(lNetworkIndex).Description
        End Sub

        Public Sub cmdCancel_Click(ByVal _Form As Form)
            _Form.Close()
        End Sub

        Public Sub cmdOK_Click(ByVal _Form As Form, ByVal _Network As String)
            Dim i As Integer, msg As String
            If lServerToChange <> 0 Then
                msg = _Network
                i = Modules.IrcSettings.IrcNetworks.Find(msg).ID
                Modules.lSettings.lServers.sServer(lServerToChange).sNetworkIndex = i
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iServers, lServerToChange.ToString().Trim(), "NetworkIndex", i.ToString().Trim())
                If Modules.lSettings.lWinVisible.wCustomize = True Then
                    frmCustomize.cboNetworks.Text = Modules.IrcSettings.IrcNetworks.GetById(i).Description
                End If
            End If
            _Form.Close()
        End Sub
    End Class
End Namespace