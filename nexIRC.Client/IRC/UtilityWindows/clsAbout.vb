Imports Telerik.WinControls.UI

Namespace nexIRC.Client.IRC.Status.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(ByVal _Form As Form, ByVal _RadPageView As RadPageView)
            Dim ee = CType(_RadPageView.ViewElement, RadPageViewStripElement)
            ee.ShowItemCloseButton = False
            ee.StripButtons = StripViewButtons.Scroll
        End Sub
    End Class
End Namespace