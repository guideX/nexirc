'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmNoticeWindow
    Private lStatusIndex As Integer
    Private lNoticeWindow As Boolean
    Private lMotdWindow As Boolean
    Private lUnknowns As Boolean
    Private lUnsupported As Boolean
    Private lPrivateMessage As Boolean
    Private lPMNick As String

    Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean, ByVal lNick As String)
        On Error Resume Next
        lPrivateMessage = lValue
        lPMNick = lNick
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnsupportedWindow(ByVal lValue As Boolean)
        On Error Resume Next
        lUnsupported = lValue
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnknownsWindow(ByVal lValue As Boolean)
        On Error Resume Next
        lUnknowns = lValue
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetMotdWindow(ByVal lValue As Boolean)
        On Error Resume Next
        lMotdWindow = lValue
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetMotdWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetNoticeWindow(ByVal lValue As Boolean)
        On Error Resume Next
        lNoticeWindow = lValue
        txtOutgoing.Visible = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetNoticeWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub DoNoticeColor(ByVal lData As String)
        On Error Resume Next
        DoColor(lData, txtIncomingColor)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub DoNoticeColor(ByVal lData As String, ByVal lTextBox As TextBox, ByVal lTextBoxColor As System.Windows.Forms.RichTextBox)")
    End Sub

    Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        lIRC.iSettings.sWindowSizes.iNotice.wWidth = Me.Width
        lIRC.iSettings.sWindowSizes.iNotice.wHeight = Me.Height
        SaveWindowSizes()
        If lMotdWindow = True Then
            lStatus.Motd_Closed(lStatusIndex) = True
        ElseIf lPrivateMessage = True Then
            lStatus.PrivateMessage_Visible(lStatusIndex, lPMNick) = False
        ElseIf lNoticeWindow = True Then
            lStatus.Notice_Visible(lStatusIndex) = False
        ElseIf lUnknowns = True Then
            lStatus.SetUnknownsClosed(lStatusIndex)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
    End Sub

    Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        On Error Resume Next
        lStatus.ActiveIndex = lStatusIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus")
    End Sub

    Public Sub TriggerResize()
        On Error Resume Next
        Me.Width = Me.Width + 1
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub TriggerResize()")
    End Sub

    Private Sub frmNoticeWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        Me.MdiParent = mdiMain
        Me.Width = lIRC.iSettings.sWindowSizes.iNotice.wWidth
        Me.Height = lIRC.iSettings.sWindowSizes.iNotice.wHeight
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub frmNoticeWindow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        txtIncomingColor.Width = Me.ClientSize.Width
        txtIncomingColor.Height = Me.ClientSize.Height - txtOutgoing.Height
        txtOutgoing.Width = txtIncomingColor.Width
        txtOutgoing.Top = txtIncomingColor.Height
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
    End Sub

    Private Sub txtNotice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error Resume Next
        If lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtNotice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNotice.GotFocus")
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        On Error Resume Next
        Dim msg As String
        If e.KeyCode = 13 Then
            If LeftRight(txtOutgoing.Text, 0, 1) = "/" Then
                msg = txtOutgoing.Text
                txtOutgoing.Text = ""
                lStatus.ProcessUserInput(lStatusIndex, msg)
                e.Handled = True
            Else
                If Len(txtOutgoing.Text) <> 0 Then
                    msg = txtOutgoing.Text
                    lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & lPMNick & " :" & msg)
                    txtOutgoing.Text = ""
                    e.Handled = True
                    DoNoticeColor("12<" & lStatus.NickName(lStatusIndex) & "> " & msg)
                End If
            End If
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
    End Sub

    Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.GotFocus
        On Error Resume Next
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.GotFocus")
    End Sub

    Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        On Error Resume Next
        If lIRC.iSettings.sShowBrowser = True Then
            mdiMain.BrowseURL(e.LinkText)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown
        On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp
        On Error Resume Next
        If Len(txtIncomingColor.SelectedText) <> 0 Then
            Clipboard.Clear()
            Clipboard.SetText(txtIncomingColor.Text)
        End If
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged
        On Error Resume Next
        txtIncomingColor.ScrollToCaret()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtIncomingNoColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress")
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
    End Sub
End Class