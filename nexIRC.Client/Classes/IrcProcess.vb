'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Namespace nexIRC.Client.Classes
    Public Class IrcProcess
        Private Delegate Sub ProcessInDataDelegate(ByVal statusIndex As Integer, ByVal data As String)
        Private _busy As Boolean = False
        Private _processes As New List(Of process)
        Private WithEvents processTimer As Timer

        Private Structure process
            Public pParam1 As String
            Public pStatusIndex As Integer
        End Structure

        Private Sub processTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles processTimer.Tick
            Dim n As Integer, i As Integer, processes As List(Of process) = _processes
            processes = New List(Of process)
            If _busy = True Then Exit Sub
            If (processes.Count <> 0) Then
                For i = 0 To processes.Count - 1
                    If (Not String.IsNullOrEmpty(processes(i).pParam1)) Then
                        n = n + 1
                        Dim lProcessDataArrivalLine As New ProcessInDataDelegate(AddressOf Modules.lProcessNumeric.ProcessDataArrivalLine)
                        Try
                            _busy = True
                            Modules.lStatus.GetObject(processes(i).pStatusIndex).sWindow.Invoke(lProcessDataArrivalLine, processes(i).pStatusIndex, processes(i).pParam1)
                            _busy = False
                        Catch
                            _busy = False
                            Initialize()
                        End Try
                        Exit Sub
                    End If
                Next i
                processTimer.Enabled = False
                Exit Sub
            End If
        End Sub

        Public Property Busy() As Boolean
            Get
                Return _busy
            End Get
            Set(value As Boolean)
                _busy = value
            End Set
        End Property

        Public Sub Add(statusId As Integer, data As String)
            Dim process As New process
            process.pParam1 = data
            process.pStatusIndex = statusId
            _processes.Add(process)
            If processTimer.Enabled = False Then processTimer.Enabled = True
        End Sub

        Public Sub Initialize()
            processTimer = New Timer
            _processes = New List(Of process)
        End Sub
    End Class
End Namespace