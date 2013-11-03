'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Imports Telerik.WinControls.UI

Public Class frmEditServer
    Private lServerIndex As Integer
    Private lInfoSet As Boolean

    Public Sub SetServerInfo(ByVal lIndex As Integer)
        Try
            lServerIndex = lIndex
            txtDescription.Text = lServers.sServer(lIndex).sDescription
            txtIp.Text = lServers.sServer(lIndex).sIP
            txtPort.Text = CStr(lServers.sServer(lIndex).sPort)
            FillComboWithNetworks(cboNetwork, True)
            cboNetwork.Text = lNetworks.nNetwork(lServers.sServer(lIndex).sNetworkIndex).nDescription
            lInfoSet = True
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetServerInfo(ByVal lIndex As Integer)")
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Try
            If lInfoSet = False Then
                If lIRC.iSettings.sPrompts = True Then MsgBox("Unable to edit server")
                Exit Sub
            End If
            If Len(txtDescription.Text) <> 0 And Len(txtPort.Text) <> 0 And Len(txtIp.Text) <> 0 And lServerIndex <> 0 Then
                With lServers.sServer(lServerIndex)
                    .sDescription = txtDescription.Text
                    .sIP = txtIp.Text
                    .sPort = CLng(Trim(txtPort.Text))
                    .sNetworkIndex = FindNetworkIndex(cboNetwork.Text)
                    If lWinVisible.wCustomize = True Then
                        frmCustomize.UpdateSelectedServer(txtDescription.Text, txtIp.Text, txtPort.Text)
                    End If
                End With
                Me.Close()
            Else
                If lIRC.iSettings.sPrompts = True Then MsgBox("Not all fields are filled out", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub

    Private Sub frmEditServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmEditServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class
