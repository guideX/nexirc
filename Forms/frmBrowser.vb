'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmBrowser
    Public Sub TriggerResize()
        'Try
        Me.Width = Me.Width + 1
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub TriggerResize()")
        'End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'Try
        'mdiMain.ToolStripStatusLabel.Text = "Document Done"
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted")
        'End Try
    End Sub

    Private Sub WebBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.DocumentTitleChanged
        'Try
        If Len(WebBrowser1.DocumentTitle()) <> 0 Then
            mdiMain.Text = "nexIRC v" & Application.ProductVersion & " (" & WebBrowser1.DocumentTitle() & ")"
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.DocumentTitleChanged")
        'End Try
    End Sub

    Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.GotFocus")
        'End Try
    End Sub

    Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        'Try
        'mdiMain.ToolStripStatusLabel.Text = "Downloading Webpage ..."
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.DocumentTitleChanged")
        'End Try
    End Sub

    Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.StatusTextChanged
        'Try
        'mdiMain.ToolStripStatusLabel.Text = WebBrowser1.StatusText
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.StatusTextChanged")
        'End Try
    End Sub

    Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        WebBrowser1.Width = Me.ClientSize.Width
        WebBrowser1.Height = Me.ClientSize.Height - ToolStrip1.Height
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmBrowser_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        'Try
        WebBrowser1.GoBack()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click")
        'End Try
    End Sub

    Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click
        'Try
        WebBrowser1.GoForward()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click")
        'End Try
    End Sub

    Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click
        'Try
        WebBrowser1.Navigate(lIRC.iSettings.sURL)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click")
        'End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'Try
        WebBrowser1.Refresh()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click")
        'End Try
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        'Try
        WebBrowser1.Stop()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click")
        'End Try
    End Sub

    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        'Try
        WebBrowser1.Navigate(txtUrl.Text)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click")
        'End Try
    End Sub

    Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStrip1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseDown")
        'End Try
    End Sub
End Class