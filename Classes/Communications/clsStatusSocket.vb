'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict Off
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules

Namespace Classes.Communications
    Public Class clsStatusSocket
        Public Event ProcessError(_Error As String, _Sub As String)
        Public Event SocketError(_Error As String, _SocketIndex As Integer)
        Private WithEvents lSocket As AsyncSocket
        Private lStatusIndex As Integer
        Private Delegate Sub StringDelegate(ByVal lData As String)
        Private Delegate Sub IntegerDelegate(ByVal lInteger As Integer)
        Private Delegate Sub DataArrivalDelegate(ByVal lIndex As Integer, ByVal lData As String)
        Private Delegate Sub DisconnectDelegate(ByVal lInteger As Integer, ByVal lCloseSocket As Boolean)
        Private lInvoke As Form

        Public Function Connected() As Boolean
            Try
                Return lSocket.Connected
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Function Connected() As Boolean")
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalIp() As String
            Try
                ReturnLocalIp = lSocket.ReturnLocalIp()
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Function ReturnLocalIp() As String")
                Return Nothing
            End Try
        End Function

        Public Function ReturnLocalPort() As Long
            Try
                If Connected() = True Then
                    ReturnLocalPort = lSocket.ReturnLocalPort
                End If
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Function ReturnLocalPort() As Long")
            End Try
        End Function

        Public Sub NewSocket(ByVal lIndex As Integer, ByVal lForm As Form)
            Try
                lSocket = New AsyncSocket
                lStatusIndex = lIndex
                lInvoke = New Form
                lInvoke = lForm
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Sub NewSocket()")
            End Try
        End Sub

        Public Sub SendSocket(ByVal lData As String)
            Try
                If Connected() = True Then lSocket.Send(lData & vbCrLf)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Sub SendSocket()")
            End Try
        End Sub

        Public Sub CloseSocket()
            Try
                If Connected() = True Then lSocket.Close()
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Sub CloseSocket()")
            End Try
        End Sub

        Public Sub ConnectSocket(ByVal lIp As String, ByVal lPort As Long)
            Try
                If Connected() = False Then lSocket.Connect(lIp, lPort)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Sub ConnectSocket(ByVal lIp As String, ByVal lPort As Long)")
            End Try

        End Sub

        Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
            Try
                Dim lConnectEvent As New IntegerDelegate(AddressOf lStatus.ConnectEvent)
                lInvoke.Invoke(lConnectEvent, lStatusIndex)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Private Sub nSocket_socketConnected(ByVal SocketID As String) Handles nSocket.socketConnected")
            End Try
        End Sub

        Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lByteRead As Integer) Handles lSocket.socketDataArrival
            Try
                Dim lProcessDataArrival As New DataArrivalDelegate(AddressOf lProcessNumeric.lIrcNumericHelper.ProcessDataArrival)
                lInvoke.Invoke(lProcessDataArrival, lStatusIndex, SocketData)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Private Sub nSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles nSocket.socketDataArrival")
            End Try
        End Sub

        Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
            Try
                Dim lDisconnectEvent As New DisconnectDelegate(AddressOf lStatus.CloseStatusConnection)
                If Connected() = True Then lInvoke.Invoke(lDisconnectEvent, lStatusIndex, False)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected")
            End Try
        End Sub

        Private Sub SocketErrorProc(ByVal _Data As String)
            Try
                ProcessReplaceString(lStatusIndex, eStringTypes.sSOCKET_ERROR, _Data)
                lStatus.CloseStatusConnection(lStatusIndex, False)
                'RaiseEvent SocketError(_Data, lStatusIndex)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Private Sub SocketErrorProc(ByVal lData As String)")
            End Try
        End Sub

        Private Sub lSocket_socketError(ByVal _Data As String) Handles lSocket.socketError
            Try
                Dim lSocketError As New StringDelegate(AddressOf SocketErrorProc)
                lInvoke.Invoke(lSocketError, _Data)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Private Sub lSocket_socketError(ByVal _Data As String) Handles lSocket.socketError")
            End Try
        End Sub
    End Class
End Namespace