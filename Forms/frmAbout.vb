Public Class frmAbout

    Private Sub frmAbout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Visible = True
        clsAnimate.Animate(PictureBox1, clsAnimate.Effect.Center, 200, 1)
        clsAnimate.Animate(RadPageView1, clsAnimate.Effect.Center, 200, 1)
        Try
            'Me.Parent = mdiMain
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class
