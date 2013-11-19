'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Classes.Communications
Public Class clsIdent
    Private WithEvents lIdentListen As AsyncServer
    Private WithEvents lClientSocket As AsyncSocket
    Private Delegate Sub StringDelegate(ByVal lData As String)
    Public Sub InitListenSocket(Optional ByVal lPort As Long = 0)
        Try
            lIdentListen = New AsyncServer(CInt(lPort))
            lIdentListen.Start()
        Catch ex As Exception
            ProcessError(Err.Description, "Private Sub InitListenSocket(ByVal lPort As Integer)")
        End Try
    End Sub
    Private Sub lIdentListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lIdentListen.ConnectionAccept
        Try
            lClientSocket = tmp_Socket
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lIdentListen_ConnectionAccept(ByVal tmp_Socket As nIRC.Sockets.clsAsyncSocket) Handles lIdentListen.ConnectionAccept")
        End Try
    End Sub
    Private Sub SendIdentInfo(ByVal lData As String)
        Try
            Dim msg As String, msg2 As String, lForm As FrmStatus
            lForm = lStatus.GetObject(lStatus.ActiveIndex).sWindow
            msg = Trim(lStatus.StatusSocketLocalPort(lForm.lMdiChildWindow.MeIndex).ToString) & ", " & Trim(lStatus.ReturnRemotePort(lForm.lMdiChildWindow.MeIndex).ToString) & " : USERID : " & lIRC.iIdent.iUserID
            msg2 = Trim(lStatus.StatusSocketLocalPort(lForm.lMdiChildWindow.MeIndex).ToString) & ", " & Trim(lStatus.ReturnRemotePort(lForm.lMdiChildWindow.MeIndex).ToString) & " : SYSTEM : " & lIRC.iIdent.iSystem
            lClientSocket.Send(msg & vbCrLf)
            lClientSocket.Send(msg2 & vbCrLf)
            lClientSocket.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub SendIdentInfo(ByVal lData As String)")
        End Try
    End Sub
    Private Sub lClientSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lClientSocket.socketDataArrival
        Try
            Dim lSendIdentInfo As New StringDelegate(AddressOf SendIdentInfo)
            MdiMain.Invoke(lSendIdentInfo, SocketData)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lClientSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles lClientSocket.socketDataArrival")
        End Try
    End Sub
End Class