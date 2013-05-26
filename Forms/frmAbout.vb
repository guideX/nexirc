'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmAbout
    Private lAnimate As clsAnimate

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = True
        clsAnimate.Animate(PictureBox1, clsAnimate.Effect.Center, 200, 1)
        clsAnimate.Animate(TabControl1, clsAnimate.Effect.Center, 200, 1)
        'Try
        'Me.Parent = mdiMain
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
End Class