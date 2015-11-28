'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Sockets
Imports nexIRC.Business.Helpers

Namespace nexIRC.Client.IRC.DCC
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
        Private Delegate Sub StringDelegateWithTextBox(ByVal _Data As String, ByVal _TextBox As TextBox)
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

        Public Sub AddText(ByVal _Text As String)
            Try
                If Len(_Text) <> 0 Then
                    If TextHelper.DoRight(_Text, 1) <> Environment.NewLine Then
                        lIncomingTextBox.Text = _Text & Environment.NewLine & lIncomingTextBox.Text
                    Else
                        lIncomingTextBox.Text = _Text & lIncomingTextBox.Text
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub SendData(ByVal lTempSocket As AsyncSocket, ByVal lData As String)
            Try
                If Len(lData) <> 0 Then
                    lTempSocket.Send(lData & Environment.NewLine)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub InitDCCListenSocket(Optional ByVal _Port As Long = 0)
            Try
                lListen = New AsyncServer(Convert.ToInt32(_Port))
                lListen.Start()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub ConnectToDCCChat(ByVal _Ip As String, ByVal _Port As Long)
            Try
                lSocket.Connect(_Ip, _Port)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SetInfo(ByVal _Ip As String, ByVal _Port As String)
            Try
                lRemoteIp = _Ip
                lRemotePort = _Port
                lAutoConnect = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Form_Load(ByVal _Form As Form, ByVal _UsersDropDownList As ToolStripComboBox, ByVal _ConnectButton As ToolStripButton, ByVal _DisconnectButton As ToolStripButton, ByVal _IncomingTextBox As RichTextBox, ByVal _ToolStrip As ToolStrip, ByVal _OutgoingTextBox As TextBox)
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
                For i = 1 To Modules.lSettings.lNotify.nCount
                    With Modules.lSettings.lNotify.nNotify(i)
                        _UsersDropDownList.Items.Add(.nNickName)
                    End With
                Next i
                If lAutoConnect = True Then
                    lSocket = New AsyncSocket
                    lRemoteIp = Modules.lStrings.DecodeLongIPAddr(lRemoteIp)
                    lPort = Convert.ToInt64(Replace(Trim(lRemotePort), "", ""))
                    _UsersDropDownList.Enabled = False
                    _ConnectButton.Enabled = False
                    _DisconnectButton.Enabled = True
                    _Form.Invoke(lConnect, lRemoteIp, lPort)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lListen.ConnectionAccept
            Try
                Dim lAddText As New StringDelegate(AddressOf AddText)
                lInvokeForm.Invoke(lAddText, "Connection Accepted")
                lSocket = tmp_Socket
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.SocketConnected
            Try
                Dim lAddText As New StringDelegate(AddressOf AddText)
                lInvokeForm.Invoke(lAddText, "Socket Connected")
                lClientConnected = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub ProcessInData(ByVal lData As String)
            Try
                Dim lAddText As New StringDelegate(AddressOf AddText), msg As String
                If Len(lData) <> 0 Then
                    lData = Replace(lData, Chr(10), "")
                    lData = Replace(lData, Chr(13), "")
                    lData = Replace(lData, Environment.NewLine, "")
                    msg = "<" & lUsersDropDownList.Text & "> " & Trim(lData)
                    lInvokeForm.Invoke(lAddText, msg)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.SocketDataArrival
            Try
                Dim lInData As New StringDelegate(AddressOf ProcessInData)
                lInvokeForm.Invoke(lInData, SocketData)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub SocketDisconnectedProc()
            Try
                lClientConnected = False
                If Modules.lSettings_DCC.dAutoCloseDialogs = True Then
                    lInvokeForm.Close()
                Else
                    AddText("Socket Disconnected")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.SocketDisconnected
            Try
                Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
                lInvokeForm.Invoke(lSocketDisconnectProc)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub cmdSetNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                lUsersDropDownList.Enabled = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdConnect_Click()
            Try
                Dim lAddText As New StringDelegate(AddressOf AddText), msg As String, p As Long
                If Len(lUsersDropDownList.Text) <> 0 Then
                    p = Modules.lProcessNumeric.lIrcNumericHelper.ReturnDCCPort()
                    If p <> 0 Then
                        lSocket = New AsyncSocket
                        InitDCCListenSocket(p)
                        If Modules.lSettings_DCC.dUseIpAddress = True Then
                            msg = Modules.lSettings_DCC.dCustomIpAddress
                        Else
                            msg = Modules.lProcessNumeric.lIrcNumericHelper.ReturnMyIp()
                        End If
                        msg = msg.Replace(Chr(10), "").Replace(Chr(13), "").Replace(Environment.NewLine, "").Trim
                        Modules.lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & lUsersDropDownList.Text & " :DCC CHAT (" & msg & ")")
                        Modules.lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & lUsersDropDownList.Text & " :DCC CHAT chat " & TextHelper.EncodeIPAddr(msg) & " " & Trim(p.ToString) & "")
                        lInvokeForm.Invoke(lAddText, "Attempting Connection")
                        lUsersDropDownList.Enabled = False
                        lConnectButton.Enabled = False
                        lDisconnectButton.Enabled = True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Public Sub frmDCCChat_Resize()
        'lIncomingTextBox.Width = lInvokeForm.ClientSize.Width
        'lOutgoingTextBox.Width = lIncomingTextBox.Width
        'lOutgoingTextBox.Top = lOutgoingTextBox.Height + lToolStrip.Height
        'End Sub

        Public Sub cmdDisconnect_Click()
            Try
                lSocket.Close()
                AddText("Disconnected")
                lDisconnectButton.Enabled = False
                lConnectButton.Enabled = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtIncoming_MouseDown()
            Try
                lInvokeForm.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtIncoming_TextChanged()
            Try
                lIncomingTextBox.ScrollToCaret()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtOutgoing_GotFocus()
            Try
                If Modules.lSettings.lIRC.iSettings.sAutoMaximize = True Then lInvokeForm.WindowState = FormWindowState.Maximized
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtOutgoing_KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            Try
                Dim msg As String
                If e.KeyCode = 13 Then
                    e.Handled = True
                    msg = lOutgoingTextBox.Text
                    If Len(msg) <> 0 Then
                        lOutgoingTextBox.Text = ""
                        lSocket.Send(msg & Environment.NewLine)
                        AddText("<" & Modules.lStatus.NickName(lStatusIndex) & "> " & msg)
                    End If
                    Exit Sub
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtOutgoing_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Try
                If e.KeyChar = Chr(13) Then e.Handled = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub SocketErrorProc(ByVal _Data As String)
            Try
                If Modules.lSettings_DCC.dAutoCloseDialogs = True Then
                    lInvokeForm.Close()
                Else
                    AddText("Socket Error: " & _Data)
                    lClientConnected = False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub txtOutgoing_MouseDown()
            Try
                lInvokeForm.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace