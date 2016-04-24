'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports System.Text
Namespace Classes.IO
    Public Class Files
        Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Auto Function WritePrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean

        Public Shared Function ReadINI(ByVal lFile As String, ByVal Section As String, ByVal Key As String, Optional ByVal lDefault As String = "") As String
            Try
                Dim i As Integer, msg As StringBuilder, msg2 As String
                msg = New StringBuilder(500)
                i = GetPrivateProfileString(Section, Key, "", msg, msg.Capacity, lFile)
                msg2 = msg.ToString()
                If i = 0 Then
                    ReadINI = lDefault
                Else
                    ReadINI = msg2.Trim
                End If
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Shared Sub WriteINI(ByVal file As String, ByVal section As String, ByVal key As String, ByVal value As String)
            Try
                WritePrivateProfileString(section, key, value, file)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace