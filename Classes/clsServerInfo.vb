'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class clsServerInfo
    Public Event ProcessError(lError As String, lSub As String)
    Private _PREFIX As String, _CHANTYPES As String

    Public Property CHANTYPES() As String
        Get
            Try
                Return _CHANTYPES
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Property CHANTYPES() As String")
                Return Nothing
            End Try
        End Get
        Set(lCHANTYPES As String)
            Try
                _CHANTYPES = lCHANTYPES
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Property CHANTYPES() As String")
            End Try
        End Set
    End Property

    Public Property PREFIX() As String
        Get
            Try
                Return _PREFIX
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Property PREFIX() As String")
                Return Nothing
            End Try
        End Get
        Set(lPREFIX As String)
            Try
                _PREFIX = lPREFIX
            Catch ex As Exception
                RaiseEvent ProcessError(ex.Message, "Public Property PREFIX() As String")
            End Try
        End Set
    End Property
End Class