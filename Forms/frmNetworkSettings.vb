'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Net
Imports nexIRC.Modules

Public Class frmNetworkSettings
    Private Function ReturnIpAddress() As String
        Try
            Dim h As String
            h = System.Net.Dns.GetHostName()
            Return System.Net.Dns.GetHostByName(h).AddressList(0).ToString()
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Sub frmNetworkSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Me.Icon = mdiMain.Icon
        With lSettings_DCC.lDCC
            If .dUseIpAddress = True Then
                optIpAddressCustom.Checked = True
            Else
                optIpAddressAuto.Checked = True
            End If
            txtBufferSize.Text = Trim(.dBufferSize.ToString)
            txtCustomIpAddress.Text = .dCustomIpAddress
            txtSendPort.Text = .dSendPort.ToString
            If .dRandomizePort = True Then chkRandomize.Checked = True
        End With
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub frmNetworkSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'On Error Resume Next
        With lSettings_DCC.lDCC
            .dRandomizePort = chkRandomize.Checked
            .dSendPort = txtSendPort.Text
            If optIpAddressAuto.Checked = True Then
                .dUseIpAddress = False
            ElseIf optIpAddressCustom.Checked = True Then
                .dUseIpAddress = True
            End If
            .dRandomizePort = Convert.ToBoolean(chkRandomize.Checked)
            .dCustomIpAddress = txtCustomIpAddress.Text
            .dBufferSize = CLng(Trim(txtBufferSize.Text))
        End With
        Me.Close()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub optIpAddressCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        txtCustomIpAddress.Enabled = True
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub optIpAddressCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIpAddressCustom.CheckedChanged")
    End Sub

    Private Sub optIpAddressAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        txtCustomIpAddress.Enabled = False
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub optIpAddressAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIpAddressAuto.CheckedChanged")
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try
            Dim client As New WebClient, baseurl As String = "http://checkip.dyndns.org:8245/", data As System.IO.Stream, reader As System.IO.StreamReader, s As String
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)")
            data = client.OpenRead(baseurl)
            reader = New System.IO.StreamReader(data)
            s = reader.ReadToEnd
            data.Close()
            reader.Close()
            s = s.Replace("<html><head><title>Current IP Check</title></head><body>", "").Replace("</body></html>", "").ToString()
            s = s.Replace("Current IP Address: ", "")
            txtCustomIpAddress.Text = s
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
