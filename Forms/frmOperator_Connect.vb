Option Explicit On
Option Strict On
'CONNECT <target server> [<port> [<remote server>]] (RFC 1459)
Public Class frmOperator_Connect
    Private Sub frmOperator_Connect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmOperator_Connect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click

    End Sub
End Class