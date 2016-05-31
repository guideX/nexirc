'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Namespace Classes.Communications
    Public Class StateObject
        Public WorkSocket As Socket = Nothing
        Public BufferSize As Integer = 32767
        Public Buffer(32767) As Byte
    End Class

    Public Class AsyncServer
        Public Event ConnectionAccept(ByVal tmp_Socket As AsyncSocket)
        Private _closed As Boolean
        Private _socketPort As Integer

        Public Sub New(ByVal lPort As Integer)
            _socketPort = lPort
        End Sub

        Public Sub Start()
            Dim listenIP As IPAddress = IPAddress.Any, listenPort As Integer = _socketPort, listenEp As IPEndPoint = New IPEndPoint(listenIP, listenPort)
            If _closed = True Then
                _closed = False
                Exit Sub
            End If
            Dim obj_Socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            obj_Socket.Bind(listenEp)
            obj_Socket.Listen(100)
            obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
        End Sub

        Public Sub Close()
            _closed = True
        End Sub

        Private Sub onIncomingConnection(ByVal result As IAsyncResult)
            Dim obj_Socket As Socket = CType(result.AsyncState, Socket), obj_Connected As Socket = obj_Socket.EndAccept(result)
            If (_closed = True) Then
                obj_Connected.Shutdown(SocketShutdown.Both)
                obj_Connected.Close()
            Else
                RaiseEvent ConnectionAccept(New AsyncSocket(obj_Connected, System.Guid.NewGuid.ToString()))
            End If
            obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
        End Sub
    End Class

    Public Class AsyncSocket
        Public Event SocketDisconnected(ByVal SocketID As String)
        Public Event SocketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer)
        Public Event SocketConnected(ByVal SocketID As String)
        Public Event CouldNotConnect(SocketID As String)
        Private _socketId As String
        Private _tempSocket As Socket

        Public Sub New(ByVal tmp_Socket As Socket, ByVal tmp_SocketID As String)
            _socketId = tmp_SocketID
            _tempSocket = tmp_Socket
            Dim obj_Socket As Socket = tmp_Socket
            Dim obj_SocketState As New StateObject
            obj_SocketState.WorkSocket = obj_Socket
            obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
        End Sub

        Public ReadOnly Property Connected() As Boolean
            Get
                Return (_tempSocket.Connected)
            End Get
        End Property

        Public Sub New()
            _tempSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        End Sub

        Public Sub SendBytes(ByVal Buffer() As Byte)
            Dim obj_StateObject As New StateObject
            obj_StateObject.WorkSocket = _tempSocket
            _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
        End Sub

        Public Sub Send(ByVal tmp_Data As String)
            Dim obj_StateObject As New StateObject
            obj_StateObject.WorkSocket = _tempSocket
            Dim Buffer As Byte() = Encoding.UTF8.GetBytes(tmp_Data)
            _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
        End Sub

        Public Sub Close()
            _tempSocket.Shutdown(SocketShutdown.Both)
            _tempSocket.Close()
        End Sub

        Public Sub Connect(ByVal hostIP As String, ByVal hostPort As Int32)
            Dim hostEndPoint As New IPEndPoint(Dns.Resolve(hostIP).AddressList(0), Convert.ToInt32(hostPort))
            Dim obj_Socket As Socket = _tempSocket
            obj_Socket.BeginConnect(hostEndPoint, New AsyncCallback(AddressOf onConnectionComplete), obj_Socket)
        End Sub

        Private Sub onDataArrival(ByVal ar As IAsyncResult)
            Try
                Dim obj_SocketState As StateObject = CType(ar.AsyncState, StateObject)
                Dim obj_Socket As Socket = obj_SocketState.WorkSocket
                Dim sck_Data As String
                Dim BytesRead As Integer = obj_Socket.EndReceive(ar)
                If BytesRead > 0 Then
                    sck_Data = Encoding.UTF8.GetString(obj_SocketState.Buffer, 0, BytesRead)
                    RaiseEvent SocketDataArrival(_socketId, sck_Data, obj_SocketState.Buffer, BytesRead)
                End If
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
            Catch ex As Exception
                If (ex.Message.Contains("Cannot access a disposed object")) Then
                    RaiseEvent SocketDisconnected(SocketID)
                Else
                    'MessageBox.Show(ex.Message)
                    'Throw
                    'Something keeps going wrong in here
                End If
            End Try
        End Sub

        Public Function ReturnLocalIp() As String
            ReturnLocalIp = New WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp")
        End Function

        Public Function ReturnLocalPort() As Long
            ReturnLocalPort = Convert.ToInt64(CType(_tempSocket.LocalEndPoint, IPEndPoint).Port)
        End Function

        Private Sub onSendComplete(ByVal ar As IAsyncResult)
            Dim obj_SocketState As StateObject = CType(ar.AsyncState, StateObject), obj_Socket As Socket = obj_SocketState.WorkSocket
        End Sub

        Private Sub onConnectionComplete(ByVal ar As IAsyncResult)
            Try
                _tempSocket = CType(ar.AsyncState, Socket)
                _tempSocket.EndConnect(ar)
                RaiseEvent SocketConnected("null")
                Dim lTempSocket As Socket = _tempSocket, lSocketState As New StateObject
                lSocketState.WorkSocket = lTempSocket
                lTempSocket.BeginReceive(lSocketState.Buffer, 0, lSocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), lSocketState)
            Catch ex As Exception
                If (ex.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond")) Then
                    'Print(ProcessReplaceString(0,clsIrcNumerics.eStringTypes.sCONNECTION_CLOSED
                    RaiseEvent CouldNotConnect(SocketID)
                Else
                    Throw
                End If
            End Try
        End Sub

        Public ReadOnly Property SocketID() As String
            Get
                Return _socketId
            End Get
        End Property
    End Class

    Public Class AsyncSocketController
        Private _socketCol As New SortedList
        Private WithEvents _serverSocket As AsyncServer
        Public Event onConnectionAccept(ByVal socketID As String)
        Public Event onSocketDisconnected(ByVal socketID As String)
        Public Event onDataArrival(ByVal socketID As String, ByVal socketData As String, ByVal bytes() As Byte, ByVal bytesRecieved As Integer)

        Public Sub New(ByVal tmp_Port As Integer)
            _serverSocket = New AsyncServer(tmp_Port)
        End Sub

        Public Sub Start()
            _serverSocket.Start()
        End Sub

        Public Sub StopServer()
            _serverSocket.Close()
        End Sub

        Public Sub Send(ByVal tmp_SocketID As String, ByVal tmp_Data As String, Optional ByVal tmp_Return As Boolean = True)
            If tmp_Return = True Then
                CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data & Environment.NewLine)
            Else
                CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data)
            End If
        End Sub

        Public Sub Close(ByVal tmp_SocketID As String)
            CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Close()
        End Sub

        Public Sub Add(ByVal tmp_Socket As AsyncSocket)
            _socketCol.Add(tmp_Socket.SocketID, tmp_Socket)
            AddHandler tmp_Socket.SocketDisconnected, AddressOf SocketDisconnected
            AddHandler tmp_Socket.SocketDataArrival, AddressOf SocketDataArrival
        End Sub

        Public ReadOnly Property Item(ByVal Key As String) As AsyncSocket
            Get
                Return CType(_socketCol(Key), AsyncSocket)
            End Get
        End Property

        Public ReadOnly Property ItembyIndex(ByVal Key As Integer) As AsyncSocket
            Get
                Return CType(_socketCol(_socketCol.GetKey(Key)), AsyncSocket)
            End Get
        End Property

        Public Function Exists(ByVal SocketID As String) As Boolean
            Dim lTempSocket As AsyncSocket = Item(SocketID)
            If lTempSocket Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return _socketCol.Count
            End Get
        End Property

        Private Sub m_ServerSocket_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles _serverSocket.ConnectionAccept
            Add(tmp_Socket)
            RaiseEvent onConnectionAccept(tmp_Socket.SocketID)
        End Sub

        Private Sub SocketDisconnected(ByVal SocketID As String)
            _socketCol.Remove(SocketID)
            RaiseEvent onSocketDisconnected(SocketID)
        End Sub

        Private Sub SocketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
            RaiseEvent onDataArrival(SocketID, SocketData, lBytes, lBytesRecieved)
        End Sub
    End Class
End Namespace