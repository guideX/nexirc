Imports Telerik.WinControls.UI
Imports nexIRC.Business.Helpers
Namespace IRC.UtilityWindows
    Public Class clsAbout
        Public Sub Form_Load(_Form As Form, _PictureBox As PictureBox, _RadPageView As RadPageView)
            NativeMethods.Animate(_RadPageView, [Enum].AnimateWindowFlags.AW_CENTER, 200, 1)
        End Sub
    End Class
End Namespace