'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class clsIdent
    Private WithEvents lIdentListen As nexIRC.Sockets.AsyncServer
    Private WithEvents lClientSocket As nexIRC.Sockets.AsyncSocket
    Private Delegate Sub StringDelegate(ByVal lData As String)
    'Public Event ProcessError(ByVal _Error As String, ByVal _Sub As String)

    Public Sub InitListenSocket(Optional ByVal lPort As Long = 0)
        ''Try
        lIdentListen = New nexIRC.Sockets.AsyncServer(CInt(lPort))
        lIdentListen.Start()
        ''Catch ex As Exception
        'RaiseEvent ProcessError(Err.Description, "Private Sub InitListenSocket(ByVal lPort As Integer)")
        ''End Try
    End Sub

    Private Sub lIdentListen_ConnectionAccept(ByVal tmp_Socket As nexIRC.Sockets.AsyncSocket) Handles lIdentListen.ConnectionAccept
        ''Try
        lClientSocket = tmp_Socket
        ''Catch ex As Exception
        ''RaiseEvent ProcessError(ex.Message, "Private Sub lIdentListen_ConnectionAccept(ByVal tmp_Socket As nIRC.Sockets.clsAsyncSocket) Handles lIdentListen.ConnectionAccept")
        ''End Try
    End Sub

    Private Sub SendIdentInfo(ByVal lData As String)
        ''Try
        Dim msg As String, msg2 As String, lForm As frmStatus
        lForm = lStatus.GetObject(lStatus.ActiveIndex).sWindow
        msg = Trim(lStatus.StatusSocketLocalPort(lForm.MeIndex).ToString) & ", " & Trim(lStatus.ReturnRemotePort(lForm.MeIndex).ToString) & " : USERID : " & lIRC.iIdent.iUserID
        msg2 = Trim(lStatus.StatusSocketLocalPort(lForm.MeIndex).ToString) & ", " & Trim(lStatus.ReturnRemotePort(lForm.MeIndex).ToString) & " : SYSTEM : " & lIRC.iIdent.iSystem
        lClientSocket.Send(msg & vbCrLf)
        lClientSocket.Send(msg2 & vbCrLf)
        lClientSocket.Close()
        ''Catch ex As Exception
        ''RaiseEvent ProcessError(ex.Message, "Private Sub SendIdentInfo(ByVal lData As String)")
        ''End Try
    End Sub

    Private Sub lClientSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lClientSocket.socketDataArrival
        ''Try
        Dim lSendIdentInfo As New StringDelegate(AddressOf SendIdentInfo)
        mdiMain.Invoke(lSendIdentInfo, SocketData)
        ''Catch ex As Exception
        ''RaiseEvent ProcessError(ex.Message, "Private Sub lClientSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles lClientSocket.socketDataArrival")
        ''End Try
    End Sub
End Class