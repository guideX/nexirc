'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmNoticeWindow
    Private lStatusIndex As Integer
    Private lNoticeWindow As Boolean
    Private lMotdWindow As Boolean
    Private lUnknowns As Boolean
    Private lUnsupported As Boolean
    Private lPrivateMessage As Boolean
    Private lPMNick As String
    Private lMdiWindow As New MdiChildWindow

    Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean, ByVal lNick As String)
        'On Error Resume Next
        lPrivateMessage = lValue
        lPMNick = lNick
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnsupportedWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lUnsupported = lValue
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnknownsWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lUnknowns = lValue
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetMotdWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lMotdWindow = lValue
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetMotdWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetNoticeWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lNoticeWindow = lValue
        txtOutgoing.Visible = True
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetNoticeWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        'On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub DoNoticeColor(ByVal lData As String)
        'On Error Resume Next
        lStrings.Print(lData, txtIncoming)
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub DoNoticeColor(ByVal lData As String, ByVal lTextBox As TextBox, ByVal lTextBoxColor As System.Windows.Forms.RichTextBox)")
    End Sub

    Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'On Error Resume Next
        lSettings.lIRC.iSettings.sWindowSizes.iNotice.wWidth = Me.Width
        lSettings.lIRC.iSettings.sWindowSizes.iNotice.wHeight = Me.Height
        lSettings.SaveWindowSizes()
        If lMotdWindow = True Then
            lStatus.Motd_Open(lStatusIndex) = False
        ElseIf lPrivateMessage = True Then
            lStatus.PrivateMessage_Visible(lStatusIndex, lPMNick) = False
        ElseIf lNoticeWindow = True Then
            lStatus.Notice_Visible(lStatusIndex) = False
        ElseIf lUnknowns = True Then
            lStatus.SetUnknownsClosed(lStatusIndex)
        End If
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
    End Sub

    Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'On Error Resume Next
        lStatus.ActiveIndex = lStatusIndex
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus")
    End Sub

    Public Sub TriggerResize()
        'On Error Resume Next
        Me.Width = Me.Width + 1
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub TriggerResize()")
    End Sub

    Private Sub frmNoticeWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        Me.Icon = mdiMain.Icon
        Me.MdiParent = mdiMain
        Me.Width = lSettings.lIRC.iSettings.sWindowSizes.iNotice.wWidth
        Me.Height = lSettings.lIRC.iSettings.sWindowSizes.iNotice.wHeight
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmNoticeWindow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        txtIncoming.Width = Me.ClientSize.Width
        txtIncoming.Height = Me.ClientSize.Height - txtOutgoing.Height
        txtOutgoing.Width = txtIncoming.Width
        txtOutgoing.Top = txtIncoming.Height
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub txtNotice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        If lSettings.lIRC.iSettings.sAutoMaximize = True Then Me.WindowState = FormWindowState.Maximized
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Try
        Dim msg As String
        If e.KeyCode = 13 Then
            If lStrings.LeftRight(txtOutgoing.Text, 0, 1) = "/" Then
                msg = txtOutgoing.Text
                txtOutgoing.Text = ""
                lStatus.ProcessUserInput(lStatusIndex, msg)
                e.Handled = True
            Else
                If Len(txtOutgoing.Text) <> 0 Then
                    If lPrivateMessage = True Then
                        msg = txtOutgoing.Text
                        lStatus.DoStatusSocket(lStatusIndex, "PRIVMSG " & lPMNick & " :" & msg)
                        txtOutgoing.Text = ""
                        e.Handled = True
                        DoNoticeColor(lStrings.ReturnReplacedString(clsIrcNumerics.eStringTypes.sPRIVMSG, lStatus.NickName(lStatusIndex), msg))
                        lStatus.PrivateMessage_AddToConversation(lStatus.NickName(lStatusIndex), msg, lStatusIndex, lStatus.PrivateMessage_Find(lStatusIndex, lPMNick))
                    End If
                End If
            End If
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.GotFocus")
    End Sub

    Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs)
        'On Error Resume Next
        'If lIRC.iSettings.sShowBrowser = True Then
        'mdiMain.BrowseURL(e.LinkText)
        'End If
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'On Error Resume Next
        'If Len(txtIncoming.SelectedText) <> 0 Then
        'Clipboard.Clear()
        'Clipboard.SetText(txtIncoming.Text)
        'End If
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        'txtIncoming.ScrollToCaret()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtIncomingNoColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On Error Resume Next
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
        'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress")
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            lMdiWindow.txtOutgoing_GotFocus(Me)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        End Try
    End Sub
End Class