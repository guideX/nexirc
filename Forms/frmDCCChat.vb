'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmDCCChat
    Private WithEvents lListen As nexIRC.Sockets.AsyncServer
    Private WithEvents lSocket As nexIRC.Sockets.AsyncSocket
    Private lServer As Boolean
    Private lRemoteIp As String
    Private lRemotePort As String
    Private lAutoConnect As Boolean
    Private lClientConnected As Boolean
    Private lStatusIndex As Integer
    Private Delegate Sub EmptyDelegate()
    Private Delegate Sub StringDelegate(ByVal lData As String)
    Private Delegate Sub ConnectDelegate(ByVal l_RemoteIp As String, ByVal l_RemotePort As Long)

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Private Sub AddText(ByVal lData As String)
        On Error Resume Next
        If Len(lData) <> 0 Then
            If DoRight(lData, 1) <> vbCrLf Then
                txtIncoming.Text = lData & vbCrLf & txtIncoming.Text
            Else
                txtIncoming.Text = lData & txtIncoming.Text
            End If
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub AddText(ByVal lData As String)")
    End Sub

    Private Sub SendData(ByVal lTempSocket As nexIRC.Sockets.AsyncSocket, ByVal lData As String)
        On Error Resume Next
        If Len(lData) <> 0 Then
            lTempSocket.Send(lData & vbCrLf)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SendData(ByVal lSocket As nexIRC.Sockets.AsyncSocket, ByVal lData As String)")
    End Sub

    Private Sub InitDCCListenSocket(Optional ByVal lPort As Long = 0)
        On Error Resume Next
        lListen = New nexIRC.Sockets.AsyncServer(CInt(lPort))
        lListen.Start()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub InitDCCListenSocket(ByVal lPort As Integer)")
    End Sub

    Public Sub ConnectToDCCChat(ByVal lIp As String, ByVal lPort As Long)
        On Error Resume Next
        lSocket.Connect(lIp, lPort)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub ConnectToDCCChat(ByVal lIp As String, ByVal lPort As Long)")
    End Sub

    Public Sub SetInfo(ByVal lIp As String, ByVal lPort As String)
        On Error Resume Next
        lRemoteIp = lIp
        lRemotePort = lPort
        lAutoConnect = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SetInfo(ByVal lIp As String, ByVal lPort As String)")
    End Sub

    Private Sub frmDCCChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim lPort As Long, lConnect As New ConnectDelegate(AddressOf ConnectToDCCChat), i As Integer
        Me.Icon = mdiMain.Icon
        Me.MdiParent = mdiMain
        For i = 1 To lNotify.nCount
            With lNotify.nNotify(i)
                cboUsers.Items.Add(.nNickName)
            End With
        Next i
        If lAutoConnect = True Then
            lSocket = New nexIRC.Sockets.AsyncSocket
            lRemoteIp = DecodeLongIPAddr(lRemoteIp)
            lPort = CLng(Replace(Trim(lRemotePort), "", ""))
            cboUsers.Enabled = False
            cmdConnect.Enabled = False
            cmdDisconnect.Enabled = True
            Me.Invoke(lConnect, lRemoteIp, lPort)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As nexIRC.Sockets.AsyncSocket) Handles lListen.ConnectionAccept
        On Error Resume Next
        Dim lAddText As New StringDelegate(AddressOf AddText)
        Me.Invoke(lAddText, "Connection Accepted")
        lSocket = tmp_Socket
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As nexIRC.Sockets.AsyncSocket) Handles lListen.ConnectionAccept")
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
        On Error Resume Next
        Dim lAddText As New StringDelegate(AddressOf AddText)
        Me.Invoke(lAddText, "Socket Connected")
        lClientConnected = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected")
    End Sub

    Private Sub ProcessInData(ByVal lData As String)
        On Error Resume Next
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String
        If Len(lData) <> 0 Then
            lData = Replace(lData, Chr(10), "")
            lData = Replace(lData, Chr(13), "")
            lData = Replace(lData, vbCrLf, "")
            msg = "<" & cboUsers.Text & "> " & Trim(lData)
            Me.Invoke(lAddText, msg)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub ProcessInData(ByVal lData As String)")
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        On Error Resume Next
        Dim lInData As New StringDelegate(AddressOf ProcessInData)
        Me.Invoke(lInData, SocketData)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles lSocket.socketDataArrival")
    End Sub

    Private Sub SocketDisconnectedProc()
        On Error Resume Next
        lClientConnected = False
        If lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            AddText("Socket Disconnected")
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SocketDisconnectedProc()")
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
        On Error Resume Next
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        Me.Invoke(lSocketDisconnectProc)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected")
    End Sub

    Private Sub cmdSetNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        cboUsers.Enabled = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdSetNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetNickName.Click")
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        On Error Resume Next
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String, p As Long
        If Len(cboUsers.Text) <> 0 Then
            p = lStatus.lIRCMisc.ReturnDCCPort()
            If p <> 0 Then
                lSocket = New nexIRC.Sockets.AsyncSocket
                InitDCCListenSocket(p)
                If lDCC.dUseIpAddress = True Then
                    msg = lDCC.dCustomIpAddress
                Else
                    msg = lStatus.lIRCMisc.ReturnMyIp()
                End If
                lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & cboUsers.Text & " :DCC CHAT (" & msg & ")")
                lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & cboUsers.Text & " :DCC CHAT chat " & EncodeIPAddr(msg) & " " & Trim(p.ToString) & "")
                Me.Invoke(lAddText, "Attempting Connection")
                cboUsers.Enabled = False
                cmdConnect.Enabled = False
                cmdDisconnect.Enabled = True
            End If
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click")
    End Sub

    Private Sub frmDCCChat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        txtIncomingNoColor.Width = Me.ClientSize.Width
        txtIncomingNoColor.Height = Me.ClientSize.Height - (txtOutgoing.Height + tlsDCCChat.Height)
        txtIncoming.Width = txtIncomingNoColor.Width
        txtIncoming.Height = txtIncomingNoColor.Height
        txtOutgoing.Width = txtIncomingNoColor.Width
        txtOutgoing.Top = txtIncoming.Height + tlsDCCChat.Height
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCChat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
    End Sub

    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        On Error Resume Next
        lSocket.Close()
        AddText("Disconnected")
        cmdDisconnect.Enabled = False
        cmdConnect.Enabled = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click")
    End Sub

    Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown")
    End Sub

    Private Sub txtIncoming_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        On Error Resume Next
        txtIncomingNoColor.ScrollToCaret()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncoming_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged")
    End Sub

    Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus
        On Error Resume Next
        If lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        On Error Resume Next
        Dim msg As String
        If e.KeyCode = 13 Then
            e.Handled = True
            msg = txtOutgoing.Text
            If Len(msg) <> 0 Then
                txtOutgoing.Text = ""
                lSocket.Send(msg & vbCrLf)
                AddText("<" & lStatus.NickName(lStatusIndex) & "> " & msg)
            End If
            Exit Sub
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
    End Sub

    Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then e.Handled = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress")
    End Sub

    Private Sub SocketErrorProc(ByVal lData As String)
        On Error Resume Next
        If lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            AddText("Socket Error: " & lData)
            lClientConnected = False
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SocketErrorProc()")
    End Sub

    Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError
        On Error Resume Next
        Dim lSocketErrorProc As New StringDelegate(AddressOf SocketErrorProc)
        Me.Invoke(lSocketErrorProc, lData)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected")
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
    End Sub
End Class