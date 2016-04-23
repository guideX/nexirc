Imports Telerik.WinControls.UI
Imports nexIRC.Classes.UI
Namespace IRC.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(_Form As Form, _PictureBox As PictureBox, _RadPageView As RadPageView)
            Try
                animate.Animate(_PictureBox, animate.Effect.Center, 200, 1)
                animate.Animate(_RadPageView, animate.Effect.Center, 200, 1)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace