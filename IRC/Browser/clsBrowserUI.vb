'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class clsBrowserUI
    Public Event FormResizeTrigger()
    Public Event FormFocus()
    Public Event BrowserNavigateURL(_Url As String)
    Public Event BrowserGoBack()
    Public Event BrowserGoForward()
    Public Event BrowserStop()
    Public Event BrowserHome()
    Public Event BrowserRefresh()
    Public Event Resize(_Width As Integer, _Height As Integer)
    Public Sub TriggerResize()
        'Try
        RaiseEvent FormResizeTrigger()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub TriggerResize()")
        'End Try
    End Sub
    Public Sub DocumentTitleChanged(_Title As String)
        'Try
        If _Title.Length <> 0 Then
            mdiMain.Text = "nexIRC v" & Application.ProductVersion & " (" & _Title & ")"
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DocumentTitleChanged(_DocumentTitle As String)")
        'End Try
    End Sub
    Public Sub Browser_GotFocus()
        'Try
        lStatus.Window(lStatus.ActiveIndex).Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus")
        'End Try
    End Sub
    Public Sub Form_Resize(_FormClientSizeWidth As Integer, _FormClientSizeHeight As Integer, _ToolStripHeight As Integer)
        'Try
        RaiseEvent Resize(_FormClientSizeWidth, (_FormClientSizeHeight - _ToolStripHeight))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub
    Public Sub cmdBack_Click()
        'Try
        RaiseEvent BrowserGoBack()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click")
        'End Try
    End Sub
    Public Sub cmdForward_Click()
        'Try
        RaiseEvent BrowserGoForward()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click")
        'End Try
    End Sub
    Public Sub cmdHome_Click()
        'Try
        RaiseEvent BrowserHome()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click")
        'End Try
    End Sub
    Public Sub cmdRefresh_Click()
        'Try
        RaiseEvent BrowserRefresh()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click")
        'End Try
    End Sub
    Public Sub cmdStop_Click()
        'Try
        RaiseEvent BrowserStop()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click")
        'End Try
    End Sub
    Public Sub cmdGo_Click(_Url As String)
        'Try
        '_Browser.Navigate(_Url)
        RaiseEvent BrowserNavigateURL(_Url)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click")
        'End Try
    End Sub
    Public Sub ToolStrip_MouseDown(_Form As Form)
        'Try
        _Form.Focus()
        RaiseEvent FormFocus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown")
        'End Try
    End Sub
End Class