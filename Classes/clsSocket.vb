'nexIRC 3.0.23
'06-13-2013 - guideX / DarkMercenary44
Option Explicit On
Option Strict On
Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Namespace nexIRC.Sockets
    Public Class StateObject
        Public WorkSocket As Socket = Nothing
        Public BufferSize As Integer = 32767
        Public Buffer(32767) As Byte
    End Class

    Public Class AsyncServer
        Private m_SocketPort As Integer
        Public Event ConnectionAccept(ByVal tmp_Socket As AsyncSocket)
        Public Event SocketError(ByVal lData As String)
        Private lClosed As Boolean

        Public Sub New(ByVal lPort As Integer)
            Try
                m_SocketPort = lPort
            Catch ex As Exception
                RaiseEvent SocketError(ex.Message)
            End Try
        End Sub

        Public Sub Start()
            Try
                Dim lListenIP As IPAddress = IPAddress.Any, lListenPort As Integer = m_SocketPort, lListenEP As IPEndPoint = New IPEndPoint(lListenIP, lListenPort)
                If lClosed = True Then
                    lClosed = False
                    Exit Sub
                End If
                Dim obj_Socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                obj_Socket.Bind(lListenEP)
                obj_Socket.Listen(100)
                obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
            Catch ex As Exception
                RaiseEvent SocketError(ex.Message)
            End Try
        End Sub

        Public Sub Close()
            Try
                lClosed = True
            Catch ex As Exception
                RaiseEvent SocketError(ex.Message)
            End Try
        End Sub

        Private Sub onIncomingConnection(ByVal lResult As IAsyncResult)
            Try
                Dim obj_Socket As Socket = CType(lResult.AsyncState, Socket), obj_Connected As Socket = obj_Socket.EndAccept(lResult)
                If lClosed = True Then
                    obj_Connected.Shutdown(SocketShutdown.Both)
                    obj_Connected.Close()
                Else
                    Dim tmp_GUID As String = GetGUID()
                    RaiseEvent ConnectionAccept(New AsyncSocket(obj_Connected, tmp_GUID))
                End If
                obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
            Catch ex As Exception
                RaiseEvent SocketError(ex.Message)
            End Try
        End Sub

        Private Function GetGUID() As String
            Try
                Return System.Guid.NewGuid.ToString
            Catch ex As Exception
                Return Nothing
                RaiseEvent SocketError(ex.Message)
            End Try
        End Function
    End Class

    Public Class AsyncSocket
        Private m_SocketID As String
        Private m_tmpSocket As Socket
        Public Event socketDisconnected(ByVal SocketID As String)
        Public Event socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer)
        Public Event socketConnected(ByVal SocketID As String)
        Public Event socketError(ByVal lData As String)

        Public Sub New(ByVal tmp_Socket As Socket, ByVal tmp_SocketID As String)
            Try
                m_SocketID = tmp_SocketID
                m_tmpSocket = tmp_Socket
                Dim obj_Socket As Socket = tmp_Socket
                Dim obj_SocketState As New StateObject
                obj_SocketState.WorkSocket = obj_Socket
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public ReadOnly Property Connected() As Boolean
            Get
                Try
                    Return (m_tmpSocket.Connected)
                Catch ex As Exception
                    ProcessError(ex.Message, "Public ReadOnly Property Connected() As Boolean")
                End Try
            End Get
        End Property

        Public Sub New()
            Try
                m_tmpSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public Sub SendBytes(ByVal Buffer() As Byte)
            Try
                Dim obj_StateObject As New StateObject
                obj_StateObject.WorkSocket = m_tmpSocket
                m_tmpSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public Sub Send(ByVal tmp_Data As String)
            Try
                Dim obj_StateObject As New StateObject
                obj_StateObject.WorkSocket = m_tmpSocket
                Dim Buffer As Byte() = Encoding.UTF8.GetBytes(tmp_Data)
                m_tmpSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public Sub Close()
            Try
                m_tmpSocket.Shutdown(SocketShutdown.Both)
                m_tmpSocket.Close()
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public Sub Connect(ByVal hostIP As String, ByVal hostPort As Long)
            Try
                Dim hostEndPoint As New IPEndPoint(Dns.Resolve(hostIP).AddressList(0), CInt(hostPort))
                Dim obj_Socket As Socket = m_tmpSocket
                obj_Socket.BeginConnect(hostEndPoint, New AsyncCallback(AddressOf onConnectionComplete), obj_Socket)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Private Sub onDataArrival(ByVal ar As IAsyncResult)
            Try
                Dim obj_SocketState As StateObject = CType(ar.AsyncState, StateObject)
                Dim obj_Socket As Socket = obj_SocketState.WorkSocket
                Dim sck_Data As String
                Dim BytesRead As Integer = obj_Socket.EndReceive(ar)
                If BytesRead > 0 Then
                    sck_Data = Encoding.UTF8.GetString(obj_SocketState.Buffer, 0, BytesRead)
                    RaiseEvent socketDataArrival(m_SocketID, sck_Data, obj_SocketState.Buffer, BytesRead)
                End If
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
            Catch ex As Exception
                RaiseEvent socketDisconnected(m_SocketID)
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public Function ReturnLocalIp() As String
            Try
                ReturnLocalIp = New WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp")
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalPort() As Long
            Try
                ReturnLocalPort = CLng(CType(m_tmpSocket.LocalEndPoint, IPEndPoint).Port)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Function

        Private Sub onSendComplete(ByVal ar As IAsyncResult)
            Try
                Dim obj_SocketState As StateObject = CType(ar.AsyncState, StateObject), obj_Socket As Socket = obj_SocketState.WorkSocket
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Private Sub onConnectionComplete(ByVal ar As IAsyncResult)
            'TODO
            'TODO
            'TODO
            'EXAMINE WHY ERRORS HAPPEN HERE
            'TODO
            'TODO
            'TODO
            Try
                m_tmpSocket = CType(ar.AsyncState, Socket)
                m_tmpSocket.EndConnect(ar)
                RaiseEvent socketConnected("null")
                Dim lTempSocket As Socket = m_tmpSocket, lSocketState As New StateObject
                lSocketState.WorkSocket = lTempSocket
                lTempSocket.BeginReceive(lSocketState.Buffer, 0, lSocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), lSocketState)
            Catch ex As Exception
                RaiseEvent socketError(ex.Message)
            End Try
        End Sub

        Public ReadOnly Property SocketID() As String
            Get
                SocketID = m_SocketID
            End Get
        End Property
    End Class

    Public Class AsyncSocketController
        Private m_SocketCol As New SortedList
        Private WithEvents m_ServerSocket As AsyncServer
        Public Event onConnectionAccept(ByVal SocketID As String)
        Public Event onSocketDisconnected(ByVal SocketID As String)
        Public Event onDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
        Public Event onSocketError(ByVal lData As String)

        Public Sub New(ByVal tmp_Port As Integer)
            Try
                m_ServerSocket = New AsyncServer(tmp_Port)
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public Sub Start()
            Try
                m_ServerSocket.Start()
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public Sub StopServer()
            Try
                m_ServerSocket.Close()
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public Sub Send(ByVal tmp_SocketID As String, ByVal tmp_Data As String, Optional ByVal tmp_Return As Boolean = True)
            Try
                If tmp_Return = True Then
                    CType(m_SocketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data & vbCrLf)
                Else
                    CType(m_SocketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data)
                End If
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public Sub Close(ByVal tmp_SocketID As String)
            Try
                CType(m_SocketCol.Item(tmp_SocketID), AsyncSocket).Close()
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public Sub Add(ByVal tmp_Socket As AsyncSocket)
            Try
                m_SocketCol.Add(tmp_Socket.SocketID, tmp_Socket)
                AddHandler tmp_Socket.socketDisconnected, AddressOf SocketDisconnected
                AddHandler tmp_Socket.socketDataArrival, AddressOf SocketDataArrival
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Public ReadOnly Property Item(ByVal Key As String) As AsyncSocket
            Get
                Try
                    Return CType(m_SocketCol(Key), nexIRC.Sockets.AsyncSocket)
                Catch ex As Exception
                    RaiseEvent onSocketError(ex.Message)
                    Return Nothing
                End Try
            End Get
        End Property

        Public ReadOnly Property ItembyIndex(ByVal Key As Integer) As AsyncSocket
            Get
                Try
                    Return CType(m_SocketCol(m_SocketCol.GetKey(Key)), nexIRC.Sockets.AsyncSocket)
                Catch ex As Exception
                    ProcessError(ex.Message, "Public ReadOnly Property ItembyIndex(ByVal Key As Integer) As AsyncSocket")
                    Return Nothing
                End Try
            End Get
        End Property

        Public Function Exists(ByVal SocketID As String) As Boolean
            Try
                Dim lTempSocket As nexIRC.Sockets.AsyncSocket = Item(SocketID)
                If lTempSocket Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return m_SocketCol.Count
            End Get
        End Property

        Private Sub m_ServerSocket_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles m_ServerSocket.ConnectionAccept
            Try
                Add(tmp_Socket)
                RaiseEvent onConnectionAccept(tmp_Socket.SocketID)
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Private Sub SocketDisconnected(ByVal SocketID As String)
            Try
                m_SocketCol.Remove(SocketID)
                RaiseEvent onSocketDisconnected(SocketID)
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub

        Private Sub SocketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
            Try
                RaiseEvent onDataArrival(SocketID, SocketData, lBytes, lBytesRecieved)
            Catch ex As Exception
                RaiseEvent onSocketError(ex.Message)
            End Try
        End Sub
    End Class
End Namespace