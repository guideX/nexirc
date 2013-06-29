'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices

Public Class clsFlashWindow
    'Public Event ProcessError(ByVal _Error As String, ByVal _Sub As String)
    <DllImport("user32.dll", EntryPoint:="FlashWindow")> Public Shared Function FlashWindow(ByVal hwnd As Integer, ByVal bInvert As Integer) As Integer
    End Function

    Private WithEvents lTimer As New Timer
    Private lHandle As Integer

    Private Sub lTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lTimer.Tick
        Try
            FlashOnce()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lTimer.Tick")
        End Try
    End Sub

    Public Sub FlashOnce()
        Try
            FlashWindow(lHandle, 1)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub FlashOnce()")
        End Try
    End Sub

    Public Sub EnableDisableTimer(Optional ByVal _Enabled As Boolean = True, Optional ByVal _Interval As Integer = 300)
        Try
            If _Enabled = True Then
                lTimer.Interval = _Interval
                lTimer.Enabled = True
                lTimer.Start()
            Else
                lTimer.Enabled = False
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Start()")
        End Try
    End Sub

    Public Sub New(ByVal _Handle As Integer)
        Try
            lHandle = _Handle
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub New()")
        End Try
    End Sub
End Class