'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class ServerInfo
    Private _prefix As String, _chanTypes As String

    Public Property ChanTypes() As String
        Get
            'Try
            Return _chanTypes
            'Catch ex As Exception
            'Return Nothing
            'End Try
        End Get
        Set(value As String)
            'Try
            _chanTypes = value
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Set
    End Property

    Public Property Prefix() As String
        Get
            'Try
            Return _prefix
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Get
        Set(value As String)
            'Try
            _prefix = value
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Set
    End Property
End Class