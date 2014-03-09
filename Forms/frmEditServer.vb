'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports Telerik.WinControls.UI

Public Class frmEditServer
    Private lServerIndex As Integer
    Private lInfoSet As Boolean

    Public Sub SetServerInfo(ByVal lIndex As Integer)
        'Try
        lServerIndex = lIndex
        txtDescription.Text = lSettings.lServers.sServer(lIndex).sDescription
        txtIp.Text = lSettings.lServers.sServer(lIndex).sIP
        txtPort.Text = Convert.ToString(lSettings.lServers.sServer(lIndex).sPort)
        lSettings.FillComboWithNetworks(cboNetwork, True)
        cboNetwork.Text = lSettings.lNetworks.nNetwork(lSettings.lServers.sServer(lIndex).sNetworkIndex).nDescription
        lInfoSet = True
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
        If lInfoSet = False Then
            If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Unable to edit server")
            Exit Sub
        End If
        If (Not String.IsNullOrEmpty(txtDescription.Text) And Not String.IsNullOrEmpty(txtPort.Text) And Not String.IsNullOrEmpty(txtIp.Text) And lServerIndex <> 0) Then
            With lSettings.lServers.sServer(lServerIndex)
                .sDescription = txtDescription.Text
                .sIP = txtIp.Text
                .sPort = Convert.ToInt64(Trim(txtPort.Text))
                .sNetworkIndex = lSettings.FindNetworkIndex(cboNetwork.Text)
                If lSettings.lWinVisible.wCustomize = True Then
                    frmCustomize.UpdateSelectedServer(txtDescription.Text, txtIp.Text, txtPort.Text)
                End If
            End With
            Me.Close()
        Else
            If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Not all fields are filled out", MsgBoxStyle.Exclamation)
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmEditServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        Me.Icon = mdiMain.Icon
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub
End Class