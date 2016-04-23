'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Namespace Classes.UI
    Public Class flashWindow
        <DllImport("user32.dll", EntryPoint:="FlashWindow")> Public Shared Function FlashWindow(ByVal hwnd As Integer, ByVal bInvert As Integer) As Integer
        End Function

        Private WithEvents timer As New Timer
        Private handle As Integer

        Private Sub timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer.Tick
            'Try
            FlashOnce()
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub

        Public Sub FlashOnce()
            'Try
            FlashWindow(handle, 1)
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub

        Public Sub EnableDisableTimer(Optional ByVal _Enabled As Boolean = True, Optional ByVal _Interval As Integer = 300)
            'Try
            If _Enabled = True Then
                timer.Interval = _Interval
                timer.Enabled = True
                timer.Start()
            Else
                timer.Enabled = False
            End If
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub

        Public Sub New(ByVal _handle As Integer)
            'Try
            handle = _handle
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub
    End Class
End Namespace