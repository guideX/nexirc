Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices

Public Class clsScrollToBottom
    Public Event ProcessError(_Message As String, _Sub As String)

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, EntryPoint:="GetScrollBarInfo")> _
    Private Shared Function GetScrollBarInfo(hWnd As IntPtr, idObject As UInteger, ByRef psbi As SCROLLBARINFO) As Integer
    End Function

    Private Shared ReadOnly WM_VSCROLL As Integer = 277

    Private Structure SCROLLBARINFO
        Public cbSize As Integer
        Public rcScrollBar As RECT
        Public dxyLineButton As Integer
        Public xyThumbTop As Integer
        Public xyThumbBottom As Integer
        Public reserved As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> _
        Public rgstate As Integer()
    End Structure

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Public Function IsAtBottom(_RichTextBox As RichTextBox) As Boolean
        'Try
        Dim OBJID_VSCROLL As UInteger = &HFFFFFFFBUI
        Dim info As New SCROLLBARINFO()
        info.cbSize = Marshal.SizeOf(info)
        Dim res As Integer = GetScrollBarInfo(_RichTextBox.Handle, OBJID_VSCROLL, info)
        Return info.xyThumbBottom > (info.rcScrollBar.Bottom - info.rcScrollBar.Top - 20)
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Public Sub ScrollToBottom(_RichTextBox As RichTextBox)")
        'End Try
    End Function

    Public Sub ScrollToBottom(_RichTextBox As RichTextBox)
        'Try
        SendMessage(_RichTextBox.Handle, WM_VSCROLL, CType(7, IntPtr), IntPtr.Zero)
        'Catch ex As Exception
        'RaiseEvent ProcessError(ex.Message, "Public Shared Sub ScrollToBottom(_RichTextBox As RichTextBox)")
        'End Try
    End Sub
End Class