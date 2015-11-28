Option Explicit On
'Option Strict On
'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Imports nexIRC.Client.nexIRC.Client.Classes.Communications
Imports nexIRC.Sockets

Namespace nexIRC.Client.Classes
    Public Class Ident
        Private WithEvents _listenSocket As AsyncServer
        Private WithEvents _clientSocket As StatusSocket
        Private ReadOnly lStatus As Object
        Private Delegate Sub StringDelegate(ByVal lData As String)
        Private Delegate Sub IntegerDelegate(ByVal int As Integer)
        Private Delegate Sub DataArrivalDelegate(ByVal id As Integer, ByVal data As String)

        Public Sub Listen(Optional ByVal port As Long = 0)
            Try
                _listenSocket = New AsyncServer(Convert.ToInt32(port))
                _listenSocket.Start()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub _listenSocket_ConnectionAccept(ByVal tempSocket As AsyncSocket) Handles _listenSocket.ConnectionAccept
            Try
                _clientSocket.PassSocket(Modules.lStatus.GetObject(Modules.lStatus.ActiveIndex).sWindow) = tempSocket
                '_clientSocket = tempSocket
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub ProcessSocketDataArrival(socketId As Integer)
            Dim msg As String, msg2 As String, form As frmStatus
            Try
                form = Modules.lStatus.GetObject(Modules.lStatus.ActiveIndex).sWindow
                msg = Trim(Modules.lStatus.StatusSocketLocalPort(socketId).ToString()) & ", " & Trim(Modules.lStatus.ReturnRemotePort(Modules.lStatus.ActiveIndex).ToString()) & " : USERID : " & Modules.lSettings.lIRC.iIdent.iUserID
                msg2 = Trim(Modules.lStatus.StatusSocketLocalPort(Modules.lStatus.ActiveIndex).ToString()) & ", " & Trim(Modules.lStatus.ReturnRemotePort(Modules.lStatus.ActiveIndex).ToString()) & " : SYSTEM : " & Modules.lSettings.lIRC.iIdent.iSystem
                _clientSocket.SendSocket(msg & Environment.NewLine)
                _clientSocket.SendSocket(msg2 & Environment.NewLine)
                _clientSocket.CloseSocket()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub New()
            Try
                _clientSocket = New StatusSocket()
                _clientSocket.SetSocketType = StatusSocket.SocketType.Ident
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub _clientSocket_DataArrival(data As String) Handles _clientSocket.DataArrival
            Dim statusId As Integer
            Try
                statusId = Modules.lStatus.ActiveIndex()
                Dim processSocketDataArrivalProc As New IntegerDelegate(AddressOf ProcessSocketDataArrival)
                Modules.lStatus.GetObject(statusId).sWindow.Invoke(processSocketDataArrivalProc, statusId)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace