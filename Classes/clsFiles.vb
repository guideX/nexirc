'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.Text

Public Class clsFiles
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean

    Public Shared Function GetFilePath(ByVal lFile As String) As String
        Try
            Dim msg() As String
            If Len(lFile) <> 0 Then
                msg = Split(lFile, "\", -1, vbTextCompare)
                GetFilePath = Left(lFile, Len(lFile) - Len(msg(UBound(msg))))
            Else
                GetFilePath = ""
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function GetFilePath(ByVal lFile As String) As String")
            Return Nothing
        End Try
    End Function

    Public Shared Function DoesFileExist(ByVal lFileName As String) As Boolean
        Try
            Dim msg As String
            msg = Dir(lFileName)
            If msg <> "" Then
                DoesFileExist = True
            Else
                DoesFileExist = False
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function DoesFileExist(ByVal lFileName As String) As Boolean")
        End Try
    End Function

    Public Shared Function ReadINI(ByVal lFile As String, ByVal Section As String, ByVal Key As String, Optional ByVal lDefault As String = "") As String
        Try
            Dim i As Integer, msg As StringBuilder, msg2 As String
            msg = New StringBuilder(500)
            i = GetPrivateProfileString(Section, Key, "", msg, msg.Capacity, lFile)
            msg2 = msg.ToString()
            If i = 0 Then
                ReadINI = lDefault
            Else
                ReadINI = Trim(msg2)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function ReadINI(ByVal lFile As String, ByVal Section As String, ByVal Key As String, Optional ByVal lDefault As String = "") As String")
            Return Nothing
        End Try
    End Function

    Public Shared Sub WriteINI(ByVal lFile As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        Try
            WritePrivateProfileString(Section, Key, Value, lFile)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub clsFiles.WriteINI(ByVal lFile As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)")
        End Try
    End Sub
End Class