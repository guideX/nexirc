'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Classes.Communications
Imports Telerik.WinControls.UI
Public Class clsDccChat
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
    Private Delegate Sub StringDelegateWithTextBox(_Data As String, _TextBox As TextBox)
    Private Delegate Sub ConnectDelegate(ByVal l_RemoteIp As String, ByVal l_RemotePort As Long)
    Private lInvokeForm As Form
    Private lIncomingTextBox As TextBox
    Private lOutgoingTextBox As TextBox
    Private lUsersDropDownList As ToolStripComboBox
    Private lConnectButton As ToolStripButton
    Private lDisconnectButton As ToolStripButton
    Private lToolStrip As ToolStrip
    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub AddText(_Text As String)
        Try
            If Len(_Text) <> 0 Then
                If lStrings.DoRight(_Text, 1) <> vbCrLf Then
                    lIncomingTextBox.Text = _Text & vbCrLf & lIncomingTextBox.Text
                Else
                    lIncomingTextBox.Text = _Text & lIncomingTextBox.Text
                End If
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub AddText(_Text As String)")
        End Try
    End Sub
    Private Sub SendData(ByVal lTempSocket As AsyncSocket, ByVal lData As String)
        Try
            If Len(lData) <> 0 Then
                lTempSocket.Send(lData & vbCrLf)
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub SendData(ByVal lTempSocket As AsyncSocket, ByVal lData As String)")
        End Try
    End Sub
    Private Sub InitDCCListenSocket(Optional ByVal _Port As Long = 0)
        Try
            lListen = New AsyncServer(Convert.ToInt32(_Port))
            lListen.Start()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub InitDCCListenSocket(Optional ByVal _Port As Long = 0)")
        End Try
    End Sub
    Public Sub ConnectToDCCChat(ByVal _Ip As String, ByVal _Port As Long)
        Try
            lSocket.Connect(_Ip, _Port)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub ConnectToDCCChat(ByVal _Ip As String, ByVal _Port As Long)")
        End Try
    End Sub
    Public Sub SetInfo(ByVal _Ip As String, ByVal _Port As String)
        Try
            lRemoteIp = _Ip
            lRemotePort = _Port
            lAutoConnect = True
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetInfo(ByVal _Ip As String, ByVal _Port As String)")
        End Try
    End Sub
    Public Sub Form_Load(_Form As Form, _UsersDropDownList As ToolStripComboBox, _ConnectButton As ToolStripButton, _DisconnectButton As ToolStripButton, _IncomingTextBox As RichTextBox, _ToolStrip As ToolStrip, _OutgoingTextBox As TextBox)
        Try
            Dim lPort As Long, lConnect As New ConnectDelegate(AddressOf ConnectToDCCChat), i As Integer
            lInvokeForm = _Form
            lUsersDropDownList = _UsersDropDownList
            lConnectButton = _ConnectButton
            lDisconnectButton = _DisconnectButton
            lToolStrip = _ToolStrip
            lOutgoingTextBox = _OutgoingTextBox
            _Form.Icon = mdiMain.Icon
            _Form.MdiParent = mdiMain
            For i = 1 To lSettings.lNotify.nCount
                With lSettings.lNotify.nNotify(i)
                    _UsersDropDownList.Items.Add(.nNickName)
                End With
            Next i
            If lAutoConnect = True Then
                lSocket = New AsyncSocket
                lRemoteIp = lStrings.DecodeLongIPAddr(lRemoteIp)
                lPort = CLng(Replace(Trim(lRemotePort), "", ""))
                _UsersDropDownList.Enabled = False
                _ConnectButton.Enabled = False
                _DisconnectButton.Enabled = True
                _Form.Invoke(lConnect, lRemoteIp, lPort)
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub Form_Load(_Form As Form, _UsersListBox As ToolStripComboBox, _ConnectButton As ToolStripButton, _DisconnectButton As ToolStripButton)")
        End Try
    End Sub
    Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lListen.ConnectionAccept
        Try
            Dim lAddText As New StringDelegate(AddressOf AddText)
            lInvokeForm.Invoke(lAddText, "Connection Accepted")
            lSocket = tmp_Socket
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lListen.ConnectionAccept")
        End Try
    End Sub
    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
        Dim lAddText As New StringDelegate(AddressOf AddText)
        lInvokeForm.Invoke(lAddText, "Socket Connected")
        lClientConnected = True
    End Sub
    Private Sub ProcessInData(ByVal lData As String)
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String
        If Len(lData) <> 0 Then
            lData = Replace(lData, Chr(10), "")
            lData = Replace(lData, Chr(13), "")
            lData = Replace(lData, vbCrLf, "")
            msg = "<" & lUsersDropDownList.Text & "> " & Trim(lData)
            lInvokeForm.Invoke(lAddText, msg)
        End If
    End Sub
    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        Dim lInData As New StringDelegate(AddressOf ProcessInData)
        lInvokeForm.Invoke(lInData, SocketData)
    End Sub
    Private Sub SocketDisconnectedProc()
        lClientConnected = False
        If lSettings_DCC.lDCC.dAutoCloseDialogs = True Then
            lInvokeForm.Close()
        Else
            AddText("Socket Disconnected")
        End If
    End Sub
    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        lInvokeForm.Invoke(lSocketDisconnectProc)
    End Sub
    Private Sub cmdSetNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lUsersDropDownList.Enabled = False
    End Sub
    Public Sub cmdConnect_Click()
        Dim lAddText As New StringDelegate(AddressOf AddText), msg As String, p As Long
        If Len(lUsersDropDownList.Text) <> 0 Then
            p = lProcessNumeric.lIrcNumericHelper.ReturnDCCPort()
            If p <> 0 Then
                lSocket = New AsyncSocket
                InitDCCListenSocket(p)
                If lSettings_DCC.lDCC.dUseIpAddress = True Then
                    msg = lSettings_DCC.lDCC.dCustomIpAddress
                Else
                    msg = lProcessNumeric.lIrcNumericHelper.ReturnMyIp()
                End If
                msg = msg.Replace(Chr(10), "").Replace(Chr(13), "").Replace(vbCrLf, "").Trim
                lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & lUsersDropDownList.Text & " :DCC CHAT (" & msg & ")")
                lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & lUsersDropDownList.Text & " :DCC CHAT chat " & lStrings.EncodeIPAddr(msg) & " " & Trim(p.ToString) & "")
                lInvokeForm.Invoke(lAddText, "Attempting Connection")
                lUsersDropDownList.Enabled = False
                lConnectButton.Enabled = False
                lDisconnectButton.Enabled = True
            End If
        End If
    End Sub
    Public Sub frmDCCChat_Resize()
        Try
            'lIncomingTextBox.Width = lInvokeForm.ClientSize.Width
            'lOutgoingTextBox.Width = lIncomingTextBox.Width
            'lOutgoingTextBox.Top = lOutgoingTextBox.Height + lToolStrip.Height
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub frmDCCChat_Resize()")
        End Try
    End Sub
    Public Sub cmdDisconnect_Click()
        Try
            lSocket.Close()
            AddText("Disconnected")
            lDisconnectButton.Enabled = False
            lConnectButton.Enabled = False
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub cmdDisconnect_Click()")
        End Try
    End Sub
    Public Sub txtIncoming_MouseDown()
        lInvokeForm.Focus()
    End Sub
    Public Sub txtIncoming_TextChanged()
        lIncomingTextBox.ScrollToCaret()
    End Sub
    Public Sub txtOutgoing_GotFocus()
        If lSettings.lIRC.iSettings.sAutoMaximize = True Then lInvokeForm.WindowState = FormWindowState.Maximized
    End Sub
    Public Sub txtOutgoing_KeyDown(e As System.Windows.Forms.KeyEventArgs)
        Dim msg As String
        If e.KeyCode = 13 Then
            e.Handled = True
            msg = lOutgoingTextBox.Text
            If Len(msg) <> 0 Then
                lOutgoingTextBox.Text = ""
                lSocket.Send(msg & vbCrLf)
                AddText("<" & lStatus.NickName(lStatusIndex) & "> " & msg)
            End If
            Exit Sub
        End If
    End Sub
    Public Sub txtOutgoing_KeyPress(e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If e.KeyChar = Chr(13) Then e.Handled = True
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub txtOutgoing_KeyPress(e As System.Windows.Forms.KeyPressEventArgs)")
        End Try
    End Sub
    Private Sub SocketErrorProc(ByVal _Data As String)
        Try
            If lSettings_DCC.lDCC.dAutoCloseDialogs = True Then
                lInvokeForm.Close()
            Else
                AddText("Socket Error: " & _Data)
                lClientConnected = False
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub SocketErrorProc(ByVal lData As String)")
        End Try
    End Sub
    Public Sub txtOutgoing_MouseDown()
        Try
            lInvokeForm.Focus()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub txtOutgoing_MouseDown()")
        End Try
    End Sub
End Class