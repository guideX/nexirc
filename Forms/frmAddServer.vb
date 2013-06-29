'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmAddServer
    Private lConnectOK As Boolean

    Public Sub SetConnectEvent()
        On Error Resume Next
        lConnectOK = True
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetConnectEvent()")
    End Sub

    Public Sub SetNetwork(ByVal lNetwork As String)
        On Error Resume Next
        cboNetwork.Text = lNetwork
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetNetwork(ByVal lNetwork As String)")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub frmAddServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        FillComboWithNetworks(cboNetwork, True)
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmAddServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim i As Integer, n As Integer
        If Len(txtPort.Text) = 0 Then
            Beep()
            txtPort.Focus()
            Exit Sub
        End If
        i = FindNetworkIndex(cboNetwork.Text)
        If i <> 0 Then
            n = AddServer(txtNetworkDescription.Text, txtIp.Text, i, CLng(Trim(txtPort.Text)))
        End If
        Me.Close()
        If lConnectOK = True Then
            lServers.sIndex = n
            lStatus.SetRemoteSettings(lStatus.ActiveIndex(), txtIp.Text, CLng(Trim(txtPort.Text)))
            lStatus.ActiveStatusConnect()
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmAddServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdNewNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewNetwork.Click
        On Error Resume Next
        Dim msg As String, i As Integer
        msg = InputBox("Enter a description for the new netwrok", "nexIRC - Add Network", "")
        If Len(msg) <> 0 Then
            i = AddNetwork(msg)
            If i <> 0 Then
                FillComboWithNetworks(cboNetwork)
                cboNetwork.SelectedItem = FindComboIndex(cboNetwork, msg)
            End If
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdNewNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewNetwork.Click")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click")
    End Sub

    Private Sub mnuServerLists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub mnuServerLists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServerLists.Click")
    End Sub
End Class