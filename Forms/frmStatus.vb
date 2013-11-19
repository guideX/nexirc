'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmStatus
#Region "Public Variables"
    Public WithEvents lMdiChildWindow As New clsMdiChildWindow
    Public WithEvents lAutoConnectDelayTimer As New Timer
#End Region
#Region "Window Events"
    Private Sub cmdSendNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendNotice.Click
        Try
            lMdiChildWindow.cmdSendNewNotice_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click")
        End Try
    End Sub
    Private Sub cmdNewPrivateMessage_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewPrivateMessage.Click
        Try
            lMdiChildWindow.cmdNewPrivateMessage_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click")
        End Try
    End Sub
    Private Sub cmdListChannels_Click(sender As System.Object, e As System.EventArgs) Handles cmdListChannels.Click
        Try
            lMdiChildWindow.cmdListChannels_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click")
        End Try
    End Sub
    Private Sub cmdChangeNickname_Click(sender As System.Object, e As System.EventArgs) Handles cmdChangeNickname.Click
        Try
            lMdiChildWindow.cmdChangeNickName_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click")
        End Try
    End Sub
    Private Sub cmdDisconnect_Click(sender As Object, e As System.EventArgs) Handles cmdDisconnect.Click
        Try
            lMdiChildWindow.cmdDisconnect_Click()
            lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click")
        End Try
    End Sub
    Private Sub cmdConnect_Click(sender As Object, e As System.EventArgs) Handles cmdConnect.Click
        Try
            lMdiChildWindow.cmdConnect_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click")
        End Try
    End Sub
    Private Sub cmdConnection_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnection.Click
        Try
            lMdiChildWindow.cmdToggleConnection_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick")
        End Try

    End Sub
    'Private Sub tmrWaitForLUsers_Tick(sender As Object, e As System.EventArgs) Handles tmrWaitForLUsers.Tick
    'lMdiChildWindow.tmrWaitForLUsers_Tick()
    'End Sub
    Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick
        Try
            lMdiChildWindow.tmrConnectDelay_Tick()
            lAutoConnectDelayTimer.Enabled = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick")
        End Try
    End Sub
    Private Sub txtIncoming_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Try
            lMdiChildWindow.txtIncomingColor_MouseDown()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown")
        End Try
    End Sub
    Private Sub txtIncoming_TextChanged(sender As Object, e As System.EventArgs) Handles txtIncoming.TextChanged
        Try
            lMdiChildWindow.txtIncomingColor_TextChanged(txtIncoming.VerticalScroll.Maximum)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
        End Try
    End Sub
    Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            lMdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Text, txtIncoming, txtOutgoing)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncoming_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp")
        End Try
    End Sub
    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            lMdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        End Try
    End Sub
    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        Try
            lMdiChildWindow.txtOutgoing_GotFocus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus")
        End Try
    End Sub
    Private Sub txtOutgoing_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        Try
            lMdiChildWindow.Form_GotFocus(Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        End Try
    End Sub
    Private Sub frmStatus_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            lMdiChildWindow.Form_Load(clsMdiChildWindow.eFormTypes.fStatus)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Private Sub frmStatus_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            lMdiChildWindow.Form_Resize(Me.ClientSize.Width, Me.ClientSize.Height, txtOutgoing.Height, txtIncoming.Top)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmStatus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub
    Private Sub frmStatus_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            lMdiChildWindow.Form_FormClosing(Me, e)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)")
        End Try
    End Sub
    Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate
        Try
            lMdiChildWindow.Form_GotFocus(Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate")
        End Try
    End Sub
    Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        Try
            lMdiChildWindow.Form_GotFocus(Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus")
        End Try
    End Sub
#End Region
#Region "Class Events"
    Private Sub lMdiChildWindow_BringToFront() Handles lMdiChildWindow.BringToFront
        Try
            Me.BringToFront()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_BringToFront() Handles lMdiChildWindow.BringToFront")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles lMdiChildWindow.ClearIncomingTextBoxSelection
        Try
            txtIncoming.Document.Selection.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles lMdiChildWindow.ClearIncomingTextBoxSelection")
        End Try
    End Sub
    Private Sub lMdiChildWindow_CloseForm() Handles lMdiChildWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_CloseForm() Handles lMdiChildWindow.CloseForm")
        End Try
    End Sub
    Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles lMdiChildWindow.EmptyOutgoingTextBox
        Try
            txtOutgoing.Text = ""
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles lMdiChildWindow.EmptyOutgoingTextBox")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles lMdiChildWindow.FormDimensions
        Try
            Me.Width = width
            Me.Height = height
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles lMdiChildWindow.FormDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormFocus() Handles lMdiChildWindow.FormFocus
        Try
            Me.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormFocus() Handles lMdiChildWindow.FormFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles lMdiChildWindow.FormIcon
        Try
            Me.Icon = icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles lMdiChildWindow.FormIcon")
        End Try
    End Sub
    Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles lMdiChildWindow.IncomingTextBoxDimensions
        Try
            txtIncoming.Width = width
            txtIncoming.Height = height
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles lMdiChildWindow.IncomingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingSetFocus() Handles lMdiChildWindow.OutgoingSetFocus
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingSetFocus() Handles lMdiChildWindow.OutgoingSetFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles lMdiChildWindow.OutgoingTextBoxDimensions
        Try
            txtOutgoing.Width = width
            txtOutgoing.Top = top
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles lMdiChildWindow.OutgoingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ScrollToCaret() Handles lMdiChildWindow.ScrollToCaret
        Try
            If (txtIncoming IsNot Nothing) Then
                If (txtIncoming.Document IsNot Nothing) Then
                    If (txtIncoming.Document.CaretPosition IsNot Nothing) Then
                        txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    End If
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ScrollToCaret() Handles lMdiChildWindow.ScrollToCaret")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetIncomingColors
        Try
            txtIncoming.RichTextBoxElement.PageBackground = backgroundColor
            txtIncoming.RichTextBoxElement.ForeColor = foregroundColor
            txtIncoming.RichTextBoxElement.BorderWidth = 0
            txtIncoming.RichTextBoxElement.BackColor = backgroundColor
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetIncomingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetOutgoingColors

        Try
            txtOutgoing.TextBoxElement.BackColor = backgroundColor
            txtOutgoing.TextBoxElement.ForeColor = foregroundColor
            txtOutgoing.TextBoxElement.ShowBorder = False
            txtOutgoing.TextBoxElement.Border.Width = 0
            txtOutgoing.TextBoxElement.Border.BackColor = Color.Black
            txtOutgoing.TextBoxElement.Border.ForeColor = Color.Black
            txtOutgoing.TextBoxElement.Border.Visibility = Telerik.WinControls.ElementVisibility.Hidden
            'txtOutgoing.BackColor = Color.Black
            txtOutgoing.TextBoxElement.BorderThickness = New System.Windows.Forms.Padding(0)

        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetOutgoingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles lMdiChildWindow.SetParent
        Try
            Me.MdiParent = parentForm
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles lMdiChildWindow.SetParent")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles lMdiChildWindow.SetWindowState
        Try
            Me.WindowState = windowState
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles lMdiChildWindow.SetWindowState")
        End Try
    End Sub
#End Region
End Class