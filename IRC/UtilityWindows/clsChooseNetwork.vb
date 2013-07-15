Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Namespace IRC.UtilityWindows
    Public Class clsChooseNetwork
        Public lServerToChange As Integer
        Public lNetworkIndex As Integer
        Public Sub Form_Load(_RadDropDownList As RadDropDownList, _Form As Form)
            'Try
            Dim i As Integer
            For i = 0 To lNetworks.nCount
                With lNetworks.nNetwork(i)
                    If Len(.nDescription) <> 0 Then _RadDropDownList.Items.Add(.nDescription)
                End With
            Next i
            _RadDropDownList.Text = lNetworks.nNetwork(lNetworkIndex).nDescription
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub Form_Load()")
            'End Try
        End Sub
        Public Sub cmdCancel_Click(_Form As Form)
            'Try
            _Form.Close()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub cmdCancel_Click(_Form As Form)")
            'End Try
        End Sub
        Public Sub cmdOK_Click(_Form As Form, _Network As String)
            'Try
            Dim i As Integer, msg As String
            If lServerToChange <> 0 Then
                msg = _Network
                i = FindNetworkIndex(msg)
                lServers.sServer(lServerToChange).sNetworkIndex = i
                clsFiles.WriteINI(lINI.iServers, Trim(Str(lServerToChange)), "NetworkIndex", Trim(Str(i)))
                If lWinVisible.wCustomize = True Then
                    frmCustomize.cboNetworks.Text = lNetworks.nNetwork(i).nDescription
                End If
            End If
            _Form.Close()
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub cmdOK_Click()")
            'End Try
        End Sub
    End Class
End Namespace