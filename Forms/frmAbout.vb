Option Explicit On
Option Strict On
Public Class frmAbout
    Private WithEvents lAbout As New clsAbout
    Private Sub frmAbout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lAbout.Form_Load(Me, Me.PictureBox1, Me.RadPageView1)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class