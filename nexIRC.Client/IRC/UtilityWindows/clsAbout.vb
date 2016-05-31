Imports Telerik.WinControls.UI
Imports nexIRC.Classes.UI
Namespace IRC.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(_Form As Form, _PictureBox As PictureBox, _RadPageView As RadPageView)
            Animate.Animate(_PictureBox, Animate.Effect.Center, 200, 1)
            Animate.Animate(_RadPageView, animate.Effect.Center, 200, 1)
        End Sub
    End Class
End Namespace