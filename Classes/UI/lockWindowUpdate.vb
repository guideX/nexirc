'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Namespace Classes.UI
    Public Class lockWindowUpdate
        <DllImport("user32.dll")> _
        Public Shared Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
        End Function
    End Class
End Namespace