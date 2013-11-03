'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class clsProcess
    Private Delegate Sub ProcessInDataDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private lBusy As Boolean = False
    Private lProcesses As New List(Of gProcess)
    Private WithEvents lProcessTimer As Timer

    Private Structure gProcess
        Public pParam1 As String
        Public pStatusIndex As Integer
    End Structure

    Private Sub lProcessTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lProcessTimer.Tick
        Try
            Dim n As Integer, i As Integer, _Processes As List(Of gProcess) = lProcesses
            lProcesses = New List(Of gProcess)
            If lBusy = True Then Exit Sub
            If _Processes.Count <> 0 Then
                For i = 0 To _Processes.Count - 1
                    If _Processes(i).pParam1.Length <> 0 Then
                        n = n + 1
                        Dim lProcessDataArrivalLine As New ProcessInDataDelegate(AddressOf lProcessNumeric.ProcessDataArrivalLine)
                        Try
                            lBusy = True
                            lStatus.GetObject(_Processes(i).pStatusIndex).sWindow.Invoke(lProcessDataArrivalLine, _Processes(i).pStatusIndex, _Processes(i).pParam1)
                            lBusy = False
                        Catch ex As Exception
                            lBusy = False
                            Initialize()
                        End Try
                        Exit Sub
                    End If
                Next i
                lProcessTimer.Enabled = False
                Exit Sub
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lProcessTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lProcessTimer.Tick")
        End Try
    End Sub

    Public Property Busy() As Boolean
        Get
            Try
                Return lBusy
            Catch ex As Exception
                ProcessError(ex.Message, "Public Property Busy() As Boolean")
                Return Nothing
            End Try
        End Get
        Set(_Busy As Boolean)
            Try
                lBusy = _Busy
            Catch ex As Exception
                ProcessError(ex.Message, "Public Property Busy() As Boolean")
            End Try
        End Set
    End Property

    Public Sub Add(_StatusIndex As Integer, _Data As String)
        Try
            Dim _Process As New gProcess
            _Process.pParam1 = _Data
            _Process.pStatusIndex = _StatusIndex
            lProcesses.Add(_Process)
            If lProcessTimer.Enabled = False Then lProcessTimer.Enabled = True
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Add(_StatusIndex As Integer, _Data As String)")
        End Try
    End Sub

    Public Sub Initialize()
        Try
            lProcessTimer = New Timer
            lProcesses = New List(Of gProcess)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Initialize()")
        End Try
    End Sub
End Class