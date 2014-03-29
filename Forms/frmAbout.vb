'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows

Public Class frmAbout
    Private WithEvents lAbout As New clsAbout

    Private Sub frmAbout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lAbout.Form_Load(Me, Me.PictureBox1, Me.RadPageView1)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub
End Class