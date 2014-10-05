'nexIRC 3.0.31
Option Explicit On
Option Strict On
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports nexIRC.Modules

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
            Try
                _socketPort = lPort
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Start()
            Try
                Dim listenIP As IPAddress = IPAddress.Any, listenPort As Integer = _socketPort, listenEp As IPEndPoint = New IPEndPoint(listenIP, listenPort)
                If _closed = True Then
                    _closed = False
                    Exit Sub
                End If
                Dim obj_Socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                obj_Socket.Bind(listenEp)
                obj_Socket.Listen(100)
                obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Close()
            Try
                _closed = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub onIncomingConnection(ByVal result As IAsyncResult)
            Try
                Dim obj_Socket As Socket = CType(result.AsyncState, Socket), obj_Connected As Socket = obj_Socket.EndAccept(result)
                If (_closed = True) Then
                    obj_Connected.Shutdown(SocketShutdown.Both)
                    obj_Connected.Close()
                Else
                    RaiseEvent ConnectionAccept(New AsyncSocket(obj_Connected, System.Guid.NewGuid.ToString()))
                End If
                obj_Socket.BeginAccept(New AsyncCallback(AddressOf onIncomingConnection), obj_Socket)
            Catch ex As Exception
                Throw ex
            End Try
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
            Try
                _socketId = tmp_SocketID
                _tempSocket = tmp_Socket
                Dim obj_Socket As Socket = tmp_Socket
                Dim obj_SocketState As New StateObject
                obj_SocketState.WorkSocket = obj_Socket
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public ReadOnly Property Connected() As Boolean
            Get
                Try
                    Return (_tempSocket.Connected)
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
        End Property

        Public Sub New()
            Try
                _tempSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SendBytes(ByVal Buffer() As Byte)
            Try
                Dim obj_StateObject As New StateObject
                obj_StateObject.WorkSocket = _tempSocket
                _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Send(ByVal tmp_Data As String)
            Try
                Dim obj_StateObject As New StateObject
                obj_StateObject.WorkSocket = _tempSocket
                Dim Buffer As Byte() = Encoding.UTF8.GetBytes(tmp_Data)
                _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, New AsyncCallback(AddressOf onSendComplete), obj_StateObject)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Close()
            Try
                _tempSocket.Shutdown(SocketShutdown.Both)
                _tempSocket.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Connect(ByVal hostIP As String, ByVal hostPort As Long)
            Try
                Dim hostEndPoint As New IPEndPoint(Dns.Resolve(hostIP).AddressList(0), Convert.ToInt32(hostPort))
                Dim obj_Socket As Socket = _tempSocket
                obj_Socket.BeginConnect(hostEndPoint, New AsyncCallback(AddressOf onConnectionComplete), obj_Socket)
            Catch ex As Exception
                Throw ex
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
                    RaiseEvent SocketDataArrival(_socketId, sck_Data, obj_SocketState.Buffer, BytesRead)
                End If
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, New AsyncCallback(AddressOf onDataArrival), obj_SocketState)
            Catch ex As Exception
                If (ex.Message.Contains("Cannot access a disposed object")) Then
                    RaiseEvent SocketDisconnected(SocketID)
                Else
                    MessageBox.Show(ex.Message)
                    'Throw ex
                    'Something keeps going wrong in here
                End If
            End Try
        End Sub

        Public Function ReturnLocalIp() As String
            Try
                ReturnLocalIp = New WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp")
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalPort() As Long
            Try
                ReturnLocalPort = Convert.ToInt64(CType(_tempSocket.LocalEndPoint, IPEndPoint).Port)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Private Sub onSendComplete(ByVal ar As IAsyncResult)
            Try
                Dim obj_SocketState As StateObject = CType(ar.AsyncState, StateObject), obj_Socket As Socket = obj_SocketState.WorkSocket
            Catch ex As Exception
                Throw ex
            End Try
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
                    Throw ex
                End If
            End Try
        End Sub

        Public ReadOnly Property SocketID() As String
            Get
                Try
                    Return _socketId
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
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
            Try
                _serverSocket = New AsyncServer(tmp_Port)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Start()
            Try
                _serverSocket.Start()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub StopServer()
            Try
                _serverSocket.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Send(ByVal tmp_SocketID As String, ByVal tmp_Data As String, Optional ByVal tmp_Return As Boolean = True)
            Try
                If tmp_Return = True Then
                    CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data & Environment.Newline)
                Else
                    CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Send(tmp_Data)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Close(ByVal tmp_SocketID As String)
            Try
                CType(_socketCol.Item(tmp_SocketID), AsyncSocket).Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Add(ByVal tmp_Socket As AsyncSocket)
            Try
                _socketCol.Add(tmp_Socket.SocketID, tmp_Socket)
                AddHandler tmp_Socket.socketDisconnected, AddressOf SocketDisconnected
                AddHandler tmp_Socket.socketDataArrival, AddressOf SocketDataArrival
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public ReadOnly Property Item(ByVal Key As String) As AsyncSocket
            Get
                Try
                    Return CType(_socketCol(Key), AsyncSocket)
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
        End Property

        Public ReadOnly Property ItembyIndex(ByVal Key As Integer) As AsyncSocket
            Get
                Try
                    Return CType(_socketCol(_socketCol.GetKey(Key)), AsyncSocket)
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public ReadOnly Property ItembyIndex(ByVal Key As Integer) As AsyncSocket")
                    Throw ex
                    Return Nothing
                End Try
            End Get
        End Property

        Public Function Exists(ByVal SocketID As String) As Boolean
            Try
                Dim lTempSocket As AsyncSocket = Item(SocketID)
                If lTempSocket Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Try
                    Return _socketCol.Count
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
        End Property

        Private Sub m_ServerSocket_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles _serverSocket.ConnectionAccept
            Try
                Add(tmp_Socket)
                RaiseEvent onConnectionAccept(tmp_Socket.SocketID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub SocketDisconnected(ByVal SocketID As String)
            Try
                _socketCol.Remove(SocketID)
                RaiseEvent onSocketDisconnected(SocketID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub SocketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
            Try
                RaiseEvent onDataArrival(SocketID, SocketData, lBytes, lBytesRecieved)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace