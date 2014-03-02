Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Imports Telerik.WinControls.RichTextBox

Namespace Classes.UI
    Public Class clsScrollToBottom
        Public Event ProcessError(_Message As String, _Sub As String)
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
        End Function
        Private Shared ReadOnly WM_VSCROLL As Integer = 277
        Public Shared Sub ScrollToBottom(_RichTextBox As RichTextBox)
            SendMessage(_RichTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
        End Sub
        Public Shared Sub ScrollToBottom(_RichTextBox As RadRichTextBox)
            SendMessage(_RichTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
        End Sub
    End Class
End Namespace