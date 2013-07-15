'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Classes.Communications

Public Class frmDCCChat
    Private WithEvents lListen As AsyncServer
    Private WithEvents lSocket As AsyncSocket
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
        lStatusIndex = lIndex
    End Sub

    Private Sub AddText(ByVal lData As String)
        If Len(lData) <> 0 Then
            If DoRight(lData, 1) <> vbCrLf Then
                txtIncoming.Text = lData & vbCrLf & txtIncoming.Text
            Else
                txtIncoming.Text = lData & txtIncoming.Text
            End If
        End If
    End Sub

    Private Sub SendData(ByVal lTempSocket As AsyncSocket, ByVal lData As String)
        If Len(lData) <> 0 Then
            lTempSocket.Send(lData & vbCrLf)
        End If
    End Sub

    Private Sub InitDCCListenSocket(Optional ByVal lPort As Long = 0)
        lListen = New AsyncServer(CInt(lPort))
        lListen.Start()
    End Sub

    Public Sub ConnectToDCCChat(ByVal lIp As String, ByVal lPort As Long)
        lSocket.Connect(lIp, lPort)
    End Sub

    Public Sub SetInfo(ByVal lIp As String, ByVal lPort As String)
        lRemoteIp = lIp
        lRemotePort = lPort
        lAutoConnect = True
    End Sub

    Private Sub frmDCCChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lPort As Long, lConnect As New ConnectDelegate(AddressOf ConnectToDCCChat), i As Integer
        Me.Icon = mdiMain.Icon
        Me.MdiParent = mdiMain
        For i = 1 To lNotify.nCount
            With lNotify.nNotify(i)
                cboUsers.Items.Add(.nNickName)
            End With
        Next i
        If lAutoConnect = True Then
            lSocket = New AsyncSocket
            lRemoteIp = DecodeLongIPAddr(lRemoteIp)
            lPort = CLng(Replace(Trim(lRemotePort), "", ""))
            cboUsers.Enabled = False
            cmdConnect.Enabled = False
            cmdDisconnect.Enabled = True
            Me.Invoke(lConnect, lRemoteIp, lPort)
        End If
    End Sub

    Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lListen.ConnectionAccept
        Dim lAddText As New StringDelegate(AddressOf AddText)
        Me.Invoke(lAddText, "Connection Accepted")
        lSocket = tmp_Socket
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
        Dim lAddText As New StringDelegate(AddressOf AddText)
        Me.Invoke(lAddText, "Socket Connected")
        lClientConnected = True
    End Sub

    Private Sub ProcessInData(ByVal lData As String)
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String
        If Len(lData) <> 0 Then
            lData = Replace(lData, Chr(10), "")
            lData = Replace(lData, Chr(13), "")
            lData = Replace(lData, vbCrLf, "")
            msg = "<" & cboUsers.Text & "> " & Trim(lData)
            Me.Invoke(lAddText, msg)
        End If
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        Dim lInData As New StringDelegate(AddressOf ProcessInData)
        Me.Invoke(lInData, SocketData)
    End Sub

    Private Sub SocketDisconnectedProc()
        lClientConnected = False
        If lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            AddText("Socket Disconnected")
        End If
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        Me.Invoke(lSocketDisconnectProc)
    End Sub

    Private Sub cmdSetNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboUsers.Enabled = False
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String, p As Long
        If Len(cboUsers.Text) <> 0 Then
            p = lProcessNumeric.lIrcNumericHelper.ReturnDCCPort()
            If p <> 0 Then
                lSocket = New AsyncSocket
                InitDCCListenSocket(p)
                If lDCC.dUseIpAddress = True Then
                    msg = lDCC.dCustomIpAddress
                Else
                    msg = lProcessNumeric.lIrcNumericHelper.ReturnMyIp()
                End If
                msg = msg.Replace(Chr(10), "").Replace(Chr(13), "").Replace(vbCrLf, "").Trim
                lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & cboUsers.Text & " :DCC CHAT (" & msg & ")")
                lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & cboUsers.Text & " :DCC CHAT chat " & EncodeIPAddr(msg) & " " & Trim(p.ToString) & "")
                Me.Invoke(lAddText, "Attempting Connection")
                cboUsers.Enabled = False
                cmdConnect.Enabled = False
                cmdDisconnect.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmDCCChat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        txtIncomingNoColor.Width = Me.ClientSize.Width
        txtIncomingNoColor.Height = Me.ClientSize.Height - (txtOutgoing.Height + tlsDCCChat.Height)
        txtIncoming.Width = txtIncomingNoColor.Width
        txtIncoming.Height = txtIncomingNoColor.Height
        txtOutgoing.Width = txtIncomingNoColor.Width
        txtOutgoing.Top = txtIncoming.Height + tlsDCCChat.Height
    End Sub

    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        lSocket.Close()
        AddText("Disconnected")
        cmdDisconnect.Enabled = False
        cmdConnect.Enabled = False
    End Sub

    Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Me.Focus()
    End Sub

    Private Sub txtIncoming_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        txtIncomingNoColor.ScrollToCaret()
    End Sub

    Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus
        If lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
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
    End Sub

    Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress
        If e.KeyChar = Chr(13) Then e.Handled = True
    End Sub

    Private Sub SocketErrorProc(ByVal lData As String)
        If lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            AddText("Socket Error: " & lData)
            lClientConnected = False
        End If
    End Sub

    Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError
        Dim lSocketErrorProc As New StringDelegate(AddressOf SocketErrorProc)
        Me.Invoke(lSocketErrorProc, lData)
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        Me.Focus()
    End Sub
End Class