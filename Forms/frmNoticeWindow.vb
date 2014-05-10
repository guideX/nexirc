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
    Private WithEvents lMdiWindow As New MdiChildWindow

    Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean, ByVal lNick As String)
        'On Error Resume Next
        lPrivateMessage = lValue
        lPMNick = lNick
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetPrivateMessageWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnsupportedWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lUnsupported = lValue
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetUnknownsWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lUnknowns = lValue
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetMotdWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lMotdWindow = lValue
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetMotdWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetNoticeWindow(ByVal lValue As Boolean)
        'On Error Resume Next
        lNoticeWindow = lValue
        txtOutgoing.Visible = True
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetNoticeWindow(ByVal lValue As Boolean)")
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        'On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub DoNoticeColor(ByVal lData As String)
        'On Error Resume Next
        lStrings.Print(lData, txtIncoming)
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub DoNoticeColor(ByVal lData As String, ByVal lTextBox As TextBox, ByVal lTextBoxColor As System.Windows.Forms.RichTextBox)")
    End Sub

    Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'On Error Resume Next
        lMdiWindow.Form_FormClosing()
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
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
    End Sub

    Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'On Error Resume Next
        lStatus.ActiveIndex = lStatusIndex
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub frmNoticeWindow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus")
    End Sub

    Public Sub TriggerResize()
        'On Error Resume Next
        Me.Width = Me.Width + 1
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Public Sub TriggerResize()")
    End Sub

    Private Sub frmNoticeWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
            Me.MdiParent = mdiMain
            Me.Width = lSettings.lIRC.iSettings.sWindowSizes.iNotice.wWidth
            Me.Height = lSettings.lIRC.iSettings.sWindowSizes.iNotice.wHeight
            lMdiWindow.Form_Load(MdiChildWindow.FormTypes.NoticeWindow)
            lMdiWindow.Form_Resize(txtIncoming, txtOutgoing, Me)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub frmNoticeWindow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            lMdiWindow.Form_Resize(txtIncoming, txtOutgoing, Me)
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            Dim msg As String
            If e.KeyCode = 13 Then
                If lStrings.LeftRight(txtOutgoing.Text, 0, 1) = "/" Then
                    msg = txtOutgoing.Text
                    txtOutgoing.Text = ""
                    lStatus.ProcessUserInput(lStatusIndex, msg)
                    e.Handled = True
                Else
                    If (Not String.IsNullOrEmpty(txtOutgoing.Text)) Then
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
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncoming.GotFocus
        'On Error Resume Next
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.GotFocus")
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        'On Error Resume Next
        'txtIncoming.ScrollToCaret()
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtIncomingNoColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        'On Error Resume Next
        Me.Focus()
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIncoming.KeyPress
        'On Error Resume Next
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
        'If Err.Number <> 0 Then 'Throw ex 'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress")
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        Try
            lMdiWindow.txtOutgoing_GotFocus(Me)
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        End Try
    End Sub

    Private Sub lMdiChildWindow_BringToFront() Handles lMdiWindow.BringToFront
        Try
            Me.BringToFront()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_BringToFront() Handles lMdiWindow.BringToFront")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles lMdiWindow.ClearIncomingTextBoxSelection
        Try
            txtIncoming.Document.Selection.Clear()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles lMdiWindow.ClearIncomingTextBoxSelection")
        End Try
    End Sub
    Private Sub lMdiChildWindow_CloseForm() Handles lMdiWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_CloseForm() Handles lMdiWindow.CloseForm")
        End Try
    End Sub
    Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles lMdiWindow.EmptyOutgoingTextBox
        Try
            txtOutgoing.Text = ""
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles lMdiWindow.EmptyOutgoingTextBox")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles lMdiWindow.FormDimensions
        Try
            Me.Width = width
            Me.Height = height
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles lMdiWindow.FormDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormFocus() Handles lMdiWindow.FormFocus
        Try
            Me.Focus()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormFocus() Handles lMdiWindow.FormFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles lMdiWindow.FormIcon
        Try
            Me.Icon = icon
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles lMdiWindow.FormIcon")
        End Try
    End Sub
    Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles lMdiWindow.IncomingTextBoxDimensions
        Try
            txtIncoming.Width = width
            txtIncoming.Height = height
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles lMdiWindow.IncomingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingSetFocus() Handles lMdiWindow.OutgoingSetFocus
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingSetFocus() Handles lMdiWindow.OutgoingSetFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles lMdiWindow.OutgoingTextBoxDimensions
        Try
            txtOutgoing.Width = width
            txtOutgoing.Top = top
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles lMdiWindow.OutgoingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ScrollToCaret() Handles lMdiWindow.ScrollToCaret
        Try
            If (txtIncoming IsNot Nothing) Then
                If (txtIncoming.Document IsNot Nothing) Then
                    If (txtIncoming.Document.CaretPosition IsNot Nothing) Then
                        txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    End If
                End If
            End If
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_ScrollToCaret() Handles lMdiWindow.ScrollToCaret")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiWindow.SetIncomingColors
        Try
            txtIncoming.RichTextBoxElement.PageBackground = backgroundColor
            txtIncoming.RichTextBoxElement.ForeColor = foregroundColor
            txtIncoming.RichTextBoxElement.BorderWidth = 0
            txtIncoming.RichTextBoxElement.BackColor = backgroundColor
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiWindow.SetIncomingColors")
        End Try
    End Sub

    Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiWindow.SetOutgoingColors
        Try
            txtOutgoing.TextBoxElement.BackColor = backgroundColor
            txtOutgoing.TextBoxElement.ForeColor = foregroundColor
            txtOutgoing.TextBoxElement.ShowBorder = False
            txtOutgoing.TextBoxElement.Border.Width = 0
            txtOutgoing.TextBoxElement.Border.BackColor = Color.Black
            txtOutgoing.TextBoxElement.Border.ForeColor = Color.Black
            txtOutgoing.TextBoxElement.Border.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
            txtOutgoing.TextBoxElement.BorderThickness = New System.Windows.Forms.Padding(0)
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiWindow.SetOutgoingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles lMdiWindow.SetParent
        Try
            Me.MdiParent = parentForm
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles lMdiWindow.SetParent")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles lMdiWindow.SetWindowState
        Try
            Me.WindowState = windowState
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles lMdiWindow.SetWindowState")
        End Try
    End Sub
End Class