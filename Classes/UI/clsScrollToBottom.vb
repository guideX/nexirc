Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Namespace Classes.UI
    Public Class clsScrollToBottom
        Public Event ProcessError(_Message As String, _Sub As String)

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
        End Function

        Private Shared ReadOnly WM_VSCROLL As Integer = 277

        Public Sub ScrollToBottom(_RichTextBox As RichTextBox)
            Try
                SendMessage(_RichTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Shared Sub ScrollToBottom(_RichTextBox As RichTextBox)")
            End Try
        End Sub
    End Class
End Namespace