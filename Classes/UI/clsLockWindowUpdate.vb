Imports System.Runtime.InteropServices
Namespace Classes.UI
    Public Class clsLockWindowUpdate
        <DllImport("user32.dll")> _
        Public Shared Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
        End Function
    End Class
End Namespace