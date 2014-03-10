'nexIRC 3.0.26
'06-13-2013 - guideX
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
                Try
                    _socketType = value
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property

        Public WriteOnly Property PassSocket(invokeForm As Form) As AsyncSocket
            Set(value As AsyncSocket)
                Try
                    _invoke = invokeForm
                    socket = value
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property

        Public Function Connected() As Boolean
            Try
                Return socket.Connected
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalIp() As String
            Try
                ReturnLocalIp = socket.ReturnLocalIp()
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalPort() As Long
            Try
                If (Connected() = True) Then
                    Return socket.ReturnLocalPort
                End If
                Return 0
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Sub NewSocket(ByVal id As Integer, ByVal form As Form)
            Try
                socket = New AsyncSocket
                statusId = id
                _invoke = New Form
                _invoke = form
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SendSocket(ByVal data As String)
            Try
                If (Connected() = True) Then socket.Send(data & Environment.NewLine)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub CloseSocket()
            Try
                If Connected() = True Then socket.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub ConnectSocket(ByVal ip As String, ByVal port As Long)
            Try
                If Connected() = False Then socket.Connect(ip, port)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub CouldNotConnect(data As String)
            Try
                lStrings.ProcessReplaceString(statusId, eStringTypes.sCOULD_NOT_CONNECT, lStatus.ServerDescription(statusId))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub socket_CouldNotConnect(SocketID As String) Handles socket.CouldNotConnect
            Try
                Dim couldNotConnectEvent As New StringDelegate(AddressOf CouldNotConnect)
                _invoke.Invoke(couldNotConnectEvent, SocketID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lSocket_socketConnected(ByVal socketID As String) Handles socket.SocketConnected
            Try
                Dim connectEvent As New IntegerDelegate(AddressOf lStatus.ConnectEvent)
                _invoke.Invoke(connectEvent, statusId)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub DataArrivalProc(id As Integer, data As String)
            Try
                RaiseEvent DataArrival(data)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub lSocket_socketDataArrival(ByVal socketID As String, ByVal socketData As String, ByVal bytes() As Byte, ByVal lByteRead As Integer) Handles socket.SocketDataArrival
            Try
                Select Case _socketType
                    Case SocketType.Status
                        Dim processDataArrival As New DataArrivalDelegate(AddressOf lProcessNumeric.lIrcNumericHelper.ProcessDataArrival)
                        _invoke.Invoke(processDataArrival, statusId, socketData)
                    Case SocketType.Ident
                        Dim processDataArrival As New DataArrivalDelegate(AddressOf DataArrivalProc)
                        _invoke.Invoke(processDataArrival, statusId, socketData)
                End Select
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub socket_socketDisconnected(ByVal socketId As String) Handles socket.SocketDisconnected
            Try
                Dim disconnectEvent As New DisconnectDelegate(AddressOf lStatus.CloseStatusConnection)
                If Connected() = True Then _invoke.Invoke(disconnectEvent, statusId, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace