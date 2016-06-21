'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Classes.Communications
Imports nexIRC.Business.Sockets
Public Class Ident
    Private WithEvents _listenSocket As AsyncServer
    Private WithEvents _clientSocket As StatusSocket
    Private Delegate Sub StringDelegate(ByVal lData As String)
    Private Delegate Sub IntegerDelegate(ByVal int As Integer)
    Private Delegate Sub DataArrivalDelegate(ByVal id As Integer, ByVal data As String)

    Public Sub Listen(Optional ByVal port As Long = 0)
        _listenSocket = New AsyncServer(Convert.ToInt32(port))
        _listenSocket.Start()
    End Sub

    Private Sub _listenSocket_ConnectionAccept(ByVal tempSocket As AsyncSocket) Handles _listenSocket.ConnectionAccept
        _clientSocket.PassSocket(lStatus.GetObject(lStatus.ActiveIndex).sWindow) = tempSocket
        '_clientSocket = tempSocket
    End Sub

    Public Sub ProcessSocketDataArrival(socketId As Integer)
        Dim msg As String, msg2 As String, form As frmStatus
        form = lStatus.GetObject(lStatus.ActiveIndex).sWindow
        msg = Trim(lStatus.StatusSocketLocalPort(socketId).ToString()) & ", " & Trim(lStatus.ReturnRemotePort(lStatus.ActiveIndex).ToString()) & " : USERID : " & lSettings.lIRC.iIdent.iUserID
        msg2 = Trim(lStatus.StatusSocketLocalPort(lStatus.ActiveIndex).ToString()) & ", " & Trim(lStatus.ReturnRemotePort(lStatus.ActiveIndex).ToString()) & " : SYSTEM : " & lSettings.lIRC.iIdent.iSystem
        _clientSocket.SendSocket(msg & Environment.NewLine)
        _clientSocket.SendSocket(msg2 & Environment.NewLine)
        _clientSocket.CloseSocket()
    End Sub

    Public Sub New()
        _clientSocket = New StatusSocket()
        _clientSocket.SetSocketType = StatusSocket.SocketType.Ident
    End Sub

    Private Sub _clientSocket_DataArrival(data As String) Handles _clientSocket.DataArrival
        Dim statusId As Integer
        statusId = lStatus.ActiveIndex()
        Dim processSocketDataArrivalProc As New IntegerDelegate(AddressOf ProcessSocketDataArrival)
        lStatus.GetObject(statusId).sWindow.Invoke(processSocketDataArrivalProc, statusId)
    End Sub
End Class