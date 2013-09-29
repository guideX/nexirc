'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmBrowser
    'Public WithEvents lBrowserUI As New clsBrowserUI
    Private Sub WebBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.DocumentTitleChanged
        lBrowserUI.DocumentTitleChanged(WebBrowser1.DocumentTitle)
    End Sub
    Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus
        lBrowserUI.Browser_GotFocus()
    End Sub
    Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lBrowserUI.Form_Resize(Me.ClientSize.Width, Me.ClientSize.Height, ToolStrip1.Height)
    End Sub
    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        lBrowserUI.cmdBack_Click()
    End Sub
    Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click
        lBrowserUI.cmdForward_Click()
    End Sub
    Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click
        lBrowserUI.cmdHome_Click()
    End Sub
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        lBrowserUI.cmdRefresh_Click()
    End Sub
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        lBrowserUI.cmdStop_Click()
    End Sub
    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        lBrowserUI.cmdGo_Click(txtUrl.Text)
    End Sub
    Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown
        lBrowserUI.ToolStrip_MouseDown(Me)
    End Sub
    Private Sub lBrowserUI_BrowserGoBack() Handles lBrowserUI.BrowserGoBack
        WebBrowser1.GoBack()
    End Sub
    Private Sub lBrowserUI_BrowserGoForward() Handles lBrowserUI.BrowserGoForward
        WebBrowser1.GoForward()
    End Sub
    Private Sub lBrowserUI_BrowserHome() Handles lBrowserUI.BrowserHome
        WebBrowser1.Navigate(lIRC.iSettings.sURL)
    End Sub
    Private Sub lBrowserUI_BrowserNavigateURL(_Url As String) Handles lBrowserUI.BrowserNavigateURL
        WebBrowser1.Navigate(_Url)
    End Sub
    Private Sub lBrowserUI_BrowserRefresh() Handles lBrowserUI.BrowserRefresh
        WebBrowser1.Refresh()
    End Sub
    Private Sub lBrowserUI_BrowserStop() Handles lBrowserUI.BrowserStop
        WebBrowser1.Stop()
    End Sub
    Private Sub lBrowserUI_FormFocus() Handles lBrowserUI.FormFocus
        Me.Focus()
    End Sub
    Private Sub lBrowserUI_FormResizeTrigger() Handles lBrowserUI.FormResizeTrigger
        Me.Width = Me.Width + 1
    End Sub
    Private Sub lBrowserUI_Resize(_Width As Integer, _Height As Integer) Handles lBrowserUI.Resize
        WebBrowser1.Width = _Width
        WebBrowser1.Height = _Height
    End Sub
End Class