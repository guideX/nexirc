'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict Off
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules

Namespace Classes.Communications
    Public Class StatusSocket
        Public Event DataArrival(data As String)
        Private WithEvents socket As AsyncSocket
        Private statusId As Integer
        Private Delegate Sub StringDelegate(ByVal data As String)
        Private Delegate Sub IntegerDelegate(ByVal int As Integer)
        Private Delegate Sub DataArrivalDelegate(ByVal id As Integer, ByVal data As String)
        Private Delegate Sub DisconnectDelegate(ByVal id As Integer, ByVal closeSocket As Boolean)
        Private _invoke As Form
        Private _socketType As SocketType = SocketType.Status

        Public Enum SocketType
            Status = 1
            Ident = 2
        End Enum

        Public WriteOnly Property SetSocketType() As SocketType
            Set(value As SocketType)
                _socketType = value
            End Set
        End Property

        Public WriteOnly Property PassSocket(invokeForm As Form) As AsyncSocket
            Set(value As AsyncSocket)
                _invoke = invokeForm
                socket = value
            End Set
        End Property

        Public Function Connected() As Boolean
                Return socket.Connected
        End Function

        Public Function ReturnLocalIp() As String
                ReturnLocalIp = socket.ReturnLocalIp()
        End Function

        Public Function ReturnLocalPort() As Long
                If (Connected() = True) Then
                    Return socket.ReturnLocalPort
                End If
                Return 0
        End Function

        Public Sub NewSocket(ByVal id As Integer, ByVal form As Form)
                socket = New AsyncSocket
                statusId = id
                _invoke = New Form
                _invoke = form
        End Sub

        Public Sub SendSocket(ByVal data As String)
                If (Connected() = True) Then socket.Send(data & Environment.NewLine)
        End Sub

        Public Sub CloseSocket()
                If Connected() = True Then socket.Close()
        End Sub

        Public Sub ConnectSocket(ByVal ip As String, ByVal port As Long)
                If Connected() = False Then socket.Connect(ip, port)
        End Sub

        Public Sub CouldNotConnect(data As String)
            lStrings.ProcessReplaceString(statusId, eStringTypes.sCOULD_NOT_CONNECT, lStatus.ServerDescription(statusId))
        End Sub

        Private Sub socket_CouldNotConnect(SocketID As String) Handles socket.CouldNotConnect
            Dim couldNotConnectEvent As New StringDelegate(AddressOf CouldNotConnect)
            _invoke.Invoke(couldNotConnectEvent, SocketID)
        End Sub

        Private Sub lSocket_socketConnected(ByVal socketID As String) Handles socket.SocketConnected
            Try
                Dim connectEvent As New IntegerDelegate(AddressOf lStatus.ConnectEvent)
                _invoke.Invoke(connectEvent, statusId)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DataArrivalProc(id As Integer, data As String)
            RaiseEvent DataArrival(data)
        End Sub

        Private Sub lSocket_socketDataArrival(ByVal socketID As String, ByVal socketData As String, ByVal bytes() As Byte, ByVal lByteRead As Integer) Handles socket.SocketDataArrival
            Select Case _socketType
                Case SocketType.Status
                    Dim processDataArrival As New DataArrivalDelegate(AddressOf lProcessNumeric.lIrcNumericHelper.ProcessDataArrival)
                    _invoke.Invoke(processDataArrival, statusId, socketData)
                Case SocketType.Ident
                    Dim processDataArrival As New DataArrivalDelegate(AddressOf DataArrivalProc)
                    _invoke.Invoke(processDataArrival, statusId, socketData)
            End Select
        End Sub

        Private Sub socket_socketDisconnected(ByVal socketId As String) Handles socket.SocketDisconnected
            Try
                Dim disconnectEvent As New DisconnectDelegate(AddressOf lStatus.CloseStatusConnection)
                If Connected() = True Then _invoke.Invoke(disconnectEvent, statusId, False)
            Catch ex As Exception
                'Throw
            End Try
        End Sub
    End Class
End Namespace