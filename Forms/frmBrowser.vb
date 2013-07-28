'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmBrowser
    Public lBrowserUI As New clsBrowserUI
    Private Sub WebBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.DocumentTitleChanged
        lBrowserUI.DocumentTitleChanged(WebBrowser1.DocumentTitle)
    End Sub
    Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus
        lBrowserUI.Browser_GotFocus(Me)
    End Sub
    Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lBrowserUI.Form_Resize(Me, WebBrowser1, ToolStrip1)
    End Sub
    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        lBrowserUI.cmdBack_Click(WebBrowser1)
    End Sub
    Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click
        lBrowserUI.cmdForward_Click(WebBrowser1)
    End Sub
    Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click
        lBrowserUI.cmdHome_Click(WebBrowser1)
    End Sub
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        lBrowserUI.cmdRefresh_Click(WebBrowser1)
    End Sub
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        lBrowserUI.cmdStop_Click(WebBrowser1)
    End Sub
    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        lBrowserUI.cmdGo_Click(WebBrowser1, txtUrl.Text)
    End Sub
    Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown
        lBrowserUI.ToolStrip_MouseDown(Me)
    End Sub
End Class