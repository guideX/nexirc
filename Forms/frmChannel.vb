'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.RichTextBox
Public Class frmChannel
    Public WithEvents lMdiChildWindow As New clsMdiChildWindow
#Region "Form Events"
    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        Try
            lMdiChildWindow.txtOutgoing_GotFocus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus")
        End Try
    End Sub
    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            lMdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        End Try
    End Sub
    Private Sub txtIncoming_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Try
            lMdiChildWindow.txtIncomingColor_MouseDown()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        End Try
    End Sub
    Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            lMdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Document.Selection.GetSelectedText(), txtIncoming, txtOutgoing)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp")
        End Try
    End Sub
    Private Sub txtIncoming_TextChanged(sender As Object, e As System.EventArgs) Handles txtIncoming.TextChanged
        Try
            lMdiChildWindow.txtIncomingColor_TextChanged(txtIncoming.VerticalScroll.Maximum)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
        End Try
    End Sub
    Private Sub lvwNicklist_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwNicklist.DoubleClick
        Try
            lMdiChildWindow.lvwNickList_DoubleClick()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick")
        End Try
    End Sub
    Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            lMdiChildWindow.Form_FormClosing()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        End Try
    End Sub
    Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            lMdiChildWindow.Form_Resize(Me.ClientSize.Width, Me.ClientSize.Height, txtOutgoing.Height, txtIncoming.Top)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub
    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        Try
            lMdiChildWindow.tmrGetNames_Tick(lvwNicklist.Items.Count)
            tmrGetNames.Enabled = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick")
        End Try
    End Sub
    Private Sub frmChannel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lMdiChildWindow.Form_Load(clsMdiChildWindow.eFormTypes.fChannel)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click
        Try
            lMdiChildWindow.cmdPart_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click")
        End Try
    End Sub
    Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click
        Try
            lMdiChildWindow.cmdHide_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click")
        End Try
    End Sub
    Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click
        Try
            lMdiChildWindow.cmdNotice_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click")
        End Try
    End Sub
    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        Try
            lMdiChildWindow.cmdAddToChannelFolder_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click")
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
    Private Sub lMdiChildWindow_ClearNickList() Handles lMdiChildWindow.ClearNickList
        Try
            lvwNicklist.Items.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearNickList() Handles lMdiChildWindow.ClearNickList")
        End Try
    End Sub
    Private Sub lMdiChildWindow_CloseForm() Handles lMdiChildWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_CloseForm() Handles lMdiChildWindow.CloseForm")
        End Try
    End Sub
    Private Sub lMdiChildWindow_DisableGetNamesTimer() Handles lMdiChildWindow.DisableGetNamesTimer
        Try
            tmrGetNames.Enabled = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_DisableGetNamesTimer() Handles lMdiChildWindow.DisableGetNamesTimer")
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
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetIncomingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetNicklistColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetNicklistColors
        Try
            lvwNicklist.ListViewElement.BackColor = backgroundColor
            lvwNicklist.ListViewElement.ForeColor = foregroundColor
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetNicklistColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetNicklistColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles lMdiChildWindow.SetOutgoingColors
        Try
            txtOutgoing.TextBoxElement.BackColor = backgroundColor
            txtOutgoing.TextBoxElement.ForeColor = foregroundColor
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