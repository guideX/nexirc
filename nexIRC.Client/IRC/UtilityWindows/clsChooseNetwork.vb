Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Business.Helpers
Imports TeamNexgenCore.Helpers

Namespace IRC.UtilityWindows
    Public Class clsChooseNetwork
        Public lServerToChange As Integer
        Public lNetworkIndex As Integer
        Public Sub Form_Load(_RadDropDownList As RadDropDownList, _Form As Form)
            Dim i As Integer
            For i = 0 To lSettings.lNetworks.Networks.Count
                With lSettings.lNetworks.Networks(i)
                    If Len(.Name) <> 0 Then _RadDropDownList.Items.Add(.Name)
                End With
            Next i
            _RadDropDownList.Text = lSettings.lNetworks.Networks(lNetworkIndex).Name
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub cmdOK_Click(_Form As Form, _Network As String)
            Dim i As Integer, msg As String
            If lServerToChange <> 0 Then
                msg = _Network
                i = lSettings.FindNetworkIndex(msg)
                lSettings.lServers.Servers(lServerToChange).NetworkIndex = i
                NativeMethods.WriteINI(lSettings.lINI.iServers, lServerToChange.ToString().Trim(), "NetworkIndex", i.ToString().Trim())
                If lSettings.lWinVisible.wCustomize = True Then
                    frmCustomize.cboNetworks.Text = lSettings.lNetworks.Networks(i).Name
                End If
            End If
            _Form.Close()
        End Sub
    End Class
End Namespace