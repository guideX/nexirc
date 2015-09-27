Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
'Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Imports nexIRC.Business.Helpers

Namespace IRC.UtilityWindows
    Public Class clsChooseNetwork
        Public lServerToChange As Integer
        Public lNetworkIndex As Integer
        Public Sub Form_Load(ByVal _RadDropDownList As RadDropDownList, ByVal _Form As Form)
            Try
                'Dim i As Integer


                Dim networks = Modules.IrcSettings.IrcNetworks.Get()


                For Each network In networks
                    If (Not String.IsNullOrEmpty(network.Description)) Then
                        _RadDropDownList.Items.Add(network.Description)
                    End If
                Next network
                _RadDropDownList.Text = Modules.IrcSettings.IrcNetworks.GetById(lNetworkIndex).Description
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdCancel_Click(ByVal _Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub cmdOK_Click(ByVal _Form As Form, ByVal _Network As String)
            Try
                Dim i As Integer, msg As String
                If lServerToChange <> 0 Then
                    msg = _Network
                    i = Modules.IrcSettings.IrcNetworks.Find(msg).Id
                    lSettings.lServers.sServer(lServerToChange).sNetworkIndex = i
                    IniFileHelper.WriteINI(lSettings.lINI.iServers, lServerToChange.ToString().Trim(), "NetworkIndex", i.ToString().Trim())
                    If lSettings.lWinVisible.wCustomize = True Then
                        frmCustomize.cboNetworks.Text = Modules.IrcSettings.IrcNetworks.GetById(i).Description
                    End If
                End If
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace