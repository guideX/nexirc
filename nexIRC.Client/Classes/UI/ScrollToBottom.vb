Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Imports Telerik.WinControls.RichTextBox

Namespace Classes.UI
    Public Class ScrollToBottom
        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
        End Function

        Private Shared ReadOnly WM_VSCROLL As Integer = 277

        Public Shared Sub ScrollToBottom(richTextBox As RichTextBox)
            SendMessage(richTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
        End Sub

        Public Shared Sub ScrollToBottom(richTextBox As RadRichTextBox)
            SendMessage(richTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
        End Sub
    End Class
End Namespace