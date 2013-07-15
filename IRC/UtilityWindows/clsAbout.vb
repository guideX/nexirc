Imports Telerik.WinControls.UI
Imports nexIRC.Classes.UI
Namespace IRC.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(_Form As Form, _PictureBox As PictureBox, _RadPageView As RadPageView)
            'Try
            clsAnimate.Animate(_PictureBox, clsAnimate.Effect.Center, 200, 1)
            clsAnimate.Animate(_RadPageView, clsAnimate.Effect.Center, 200, 1)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Sub Form_Load(_Form As Form)")
            'End Try
        End Sub
    End Class
End Namespace