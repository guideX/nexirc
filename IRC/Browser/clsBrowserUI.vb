'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class clsBrowserUI
    Public Sub TriggerResize(_Form As Form)
        'Try
        _Form.Width = _Form.Width + 1
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub TriggerResize()")
        'End Try
    End Sub
    Public Sub DocumentTitleChanged(_DocumentTitle As String)
        'Try
        If _DocumentTitle.Length <> 0 Then
            mdiMain.Text = "nexIRC v" & Application.ProductVersion & " (" & _DocumentTitle & ")"
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DocumentTitleChanged(_DocumentTitle As String)")
        'End Try
    End Sub
    Public Sub Browser_GotFocus(_Form As Form)
        'Try
        _Form.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus")
        'End Try
    End Sub
    Public Sub Form_Resize(_Form As Form, _Browser As WebBrowser, _ToolStrip As ToolStrip)
        'Try
        _Browser.Width = _Form.ClientSize.Width
        _Browser.Height = _Form.ClientSize.Height - _ToolStrip.Height
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub
    Public Sub cmdBack_Click(_Browser As WebBrowser)
        'Try
        _Browser.GoBack()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click")
        'End Try
    End Sub
    Public Sub cmdForward_Click(_Browser As WebBrowser)
        'Try
        _Browser.GoForward()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click")
        'End Try
    End Sub
    Public Sub cmdHome_Click(_Browser As WebBrowser)
        'Try
        _Browser.Navigate(lIRC.iSettings.sURL)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click")
        'End Try
    End Sub
    Public Sub cmdRefresh_Click(_Browser As WebBrowser)
        'Try
        _Browser.Refresh()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click")
        'End Try
    End Sub
    Public Sub cmdStop_Click(_Browser As WebBrowser)
        'Try
        _Browser.Stop()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click")
        'End Try
    End Sub
    Public Sub cmdGo_Click(_Browser As WebBrowser, _Url As String)
        'Try
        _Browser.Navigate(_Url)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click")
        'End Try
    End Sub
    Public Sub ToolStrip_MouseDown(_Form As Form)
        'Try
        _Form.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown")
        'End Try
    End Sub
End Class