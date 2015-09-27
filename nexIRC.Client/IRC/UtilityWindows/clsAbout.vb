Imports Telerik.WinControls.UI
Imports nexIRC.UI

Namespace IRC.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(ByVal _Form As Form, ByVal _RadPageView As RadPageView)
            Try
                Animate.AnimateNow(_RadPageView, Animate.Effect.Center, 200, 1)
                Dim ee = CType(_RadPageView.ViewElement, RadPageViewStripElement)
                ee.ShowItemCloseButton = False
                ee.StripButtons = StripViewButtons.Scroll
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace