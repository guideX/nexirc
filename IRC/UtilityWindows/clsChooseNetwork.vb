Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Imports nexIRC.IniFile

Namespace IRC.UtilityWindows
    Public Class clsChooseNetwork
        Public lServerToChange As Integer
        Public lNetworkIndex As Integer
        Public Sub Form_Load(_RadDropDownList As RadDropDownList, _Form As Form)
            Try
                Dim i As Integer
                For i = 0 To lSettings.lNetworks.nCount
                    With lSettings.lNetworks.nNetwork(i)
                        If Len(.nDescription) <> 0 Then _RadDropDownList.Items.Add(.nDescription)
                    End With
                Next i
                _RadDropDownList.Text = lSettings.lNetworks.nNetwork(lNetworkIndex).nDescription
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
        Public Sub cmdOK_Click(_Form As Form, _Network As String)
            Try
                Dim i As Integer, msg As String
                If lServerToChange <> 0 Then
                    msg = _Network
                    i = lSettings.FindNetworkIndex(msg)
                    lSettings.lServers.sServer(lServerToChange).sNetworkIndex = i
                    Files.WriteINI(lSettings.lINI.iServers, lServerToChange.ToString().Trim(), "NetworkIndex", i.ToString().Trim())
                    If lSettings.lWinVisible.wCustomize = True Then
                        frmCustomize.cboNetworks.Text = lSettings.lNetworks.nNetwork(i).nDescription
                    End If
                End If
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace