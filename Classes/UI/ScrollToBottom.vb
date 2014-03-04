Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Imports Telerik.WinControls.RichTextBox

Namespace Classes.UI
    Public Class ScrollToBottom
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
        End Function

        Private Shared ReadOnly WM_VSCROLL As Integer = 277

        Public Shared Sub ScrollToBottom(richTextBox As RichTextBox)
            'Try
            SendMessage(richTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub

        Public Shared Sub ScrollToBottom(richTextBox As RadRichTextBox)
            'Try
            SendMessage(richTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub
    End Class
End Namespace