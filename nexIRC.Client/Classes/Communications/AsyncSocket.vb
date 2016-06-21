'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Business.Sockets

Namespace Classes.Communications
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