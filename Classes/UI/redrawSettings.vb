Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices

Public Class redrawSettings
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Const WM_SETREDRAW As Integer = &HB
    Private Const WM_USER As Integer = &H400
    Private Const EM_GETEVENTMASK As Integer = (WM_USER + 59)
    Private Const EM_SETEVENTMASK As Integer = (WM_USER + 69)

    Public Shared Function DisableDraw(textBox As RichTextBox) As IntPtr
        Dim eventMask As IntPtr = IntPtr.Zero
        SendMessage(textBox.Handle, WM_SETREDRAW, CType(0, IntPtr), IntPtr.Zero)
        eventMask = SendMessage(textBox.Handle, EM_GETEVENTMASK, CType(0, IntPtr), IntPtr.Zero)
    End Function

    Public Shared Sub EnableDraw(textBox As RichTextBox, eventMask As IntPtr)
        SendMessage(textBox.Handle, EM_SETEVENTMASK, CType(0, IntPtr), eventMask)
        SendMessage(textBox.Handle, WM_SETREDRAW, CType(1, IntPtr), IntPtr.Zero)
    End Sub
End Class