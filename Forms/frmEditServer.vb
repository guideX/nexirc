'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmEditServer
    Private lServerIndex As Integer
    Private lInfoSet As Boolean

    Public Sub SetServerInfo(ByVal lIndex As Integer)
        On Error Resume Next
        lServerIndex = lIndex
        txtDescription.Text = lServers.sServer(lIndex).sDescription
        txtIp.Text = lServers.sServer(lIndex).sIP
        txtPort.Text = CStr(lServers.sServer(lIndex).sPort)
        FillComboWithNetworks(cboNetwork, True)
        cboNetwork.Text = lNetworks.nNetwork(lServers.sServer(lIndex).sNetworkIndex).nDescription
        lInfoSet = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetServerInfo(ByVal lIndex As Integer)")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
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
                'If lWinVisible.wCustomize = True Then
                'Dim l As ListViewDataItem, i As Integer
                'For i = 0 To frmCustomize.lvwServers.Count - 1
                'l = frmCustomize.lvwServers.SelectedItems(i)
                'l.Text = txtDescription.Text
                'l.Item(1) = txtIp.Text
                'l.Item(2) = txtPort.Text
                'Exit For
                'Next i
                'End If
            End With
            Me.Close()
        Else
            If lIRC.iSettings.sPrompts = True Then MsgBox("Not all fields are filled out", MsgBoxStyle.Exclamation)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub frmEditServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmEditServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub
End Class
