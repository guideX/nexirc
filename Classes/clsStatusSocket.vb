'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class clsStatusSocket
    Public Event ProcessError(_Error As String, _Sub As String)
    Public Event SocketError(_Error As String, _SocketIndex As Integer)
    Private WithEvents lSocket As nexIRC.Sockets.AsyncSocket
    Private lStatusIndex As Integer
    Private Delegate Sub StringDelegate(ByVal lData As String)
    Private Delegate Sub IntegerDelegate(ByVal lInteger As Integer)
    Private Delegate Sub DataArrivalDelegate(ByVal lIndex As Integer, ByVal lData As String)
    Private Delegate Sub DisconnectDelegate(ByVal lInteger As Integer, ByVal lCloseSocket As Boolean)
    Private lInvoke As Form
    'Private lConnected As Boolean

    Public Function Connected() As Boolean
        'Try
        Return lSocket.Connected
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function Connected() As Boolean")
        'Return Nothing
        'End Try
    End Function

    Public Function ReturnLocalIp() As String
        On Error Resume Next
        ReturnLocalIp = lSocket.ReturnLocalIp()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnLocalIp() As String")
    End Function

    Public Function ReturnLocalPort() As Long
        On Error Resume Next
        If Connected() = True Then
            ReturnLocalPort = lSocket.ReturnLocalPort
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnLocalPort() As Long")
    End Function

    Public Sub NewSocket(ByVal lIndex As Integer, ByVal lForm As Form)
        On Error Resume Next
        lSocket = New nexIRC.Sockets.AsyncSocket
        lStatusIndex = lIndex
        lInvoke = New Form
        lInvoke = lForm
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub NewSocket()")
    End Sub

    Public Sub SendSocket(ByVal lData As String)
        On Error Resume Next
        If Connected() = True Then lSocket.Send(lData & vbCrLf)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SendSocket()")
    End Sub

    Public Sub CloseSocket()
        On Error Resume Next
        If Connected() = True Then lSocket.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub CloseSocket()")
    End Sub

    Public Sub ConnectSocket(ByVal lIp As String, ByVal lPort As Long)
        On Error Resume Next
        If Connected() = False Then lSocket.Connect(lIp, lPort)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub ConnectSocket(ByVal lIp As String, ByVal lPort As Long)")
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
        On Error Resume Next
        Dim lConnectEvent As New IntegerDelegate(AddressOf lStatus.ConnectEvent)
        lInvoke.Invoke(lConnectEvent, lStatusIndex)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub nSocket_socketConnected(ByVal SocketID As String) Handles nSocket.socketConnected")
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lByteRead As Integer) Handles lSocket.socketDataArrival
        On Error Resume Next
        Dim lProcessDataArrival As New DataArrivalDelegate(AddressOf lStatus.lIRCMisc.ProcessDataArrival)
        lInvoke.Invoke(lProcessDataArrival, lStatusIndex, SocketData)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub nSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles nSocket.socketDataArrival")
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
        On Error Resume Next
        Dim lDisconnectEvent As New DisconnectDelegate(AddressOf lStatus.CloseStatusConnection)
        If Connected() = True Then lInvoke.Invoke(lDisconnectEvent, lStatusIndex, False)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected")
    End Sub

    Private Sub SocketErrorProc(ByVal _Data As String)
        'Try
        ProcessReplaceString(lStatusIndex, eStringTypes.sSOCKET_ERROR, _Data)
        lStatus.CloseStatusConnection(lStatusIndex, False)
        RaiseEvent SocketError(_Data, lStatusIndex)
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Private Sub SocketErrorProc(ByVal lData As String)")
        'End Try
    End Sub

    Private Sub lSocket_socketError(ByVal _Data As String) Handles lSocket.socketError
        'Try
        Dim lSocketError As New StringDelegate(AddressOf SocketErrorProc)
        lInvoke.Invoke(lSocketError, _Data)
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Private Sub lSocket_socketError(ByVal _Data As String) Handles lSocket.socketError")
        'End Try
    End Sub
End Class
