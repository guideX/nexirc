'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Public Class frmChannel
#Region "Public Variables"
    Public WithEvents MdiChildWindow As New clsMdiChildWindow
#End Region
#Region "Window Events"
    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        Try
            MdiChildWindow.txtOutgoing_GotFocus(Me)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus")
        End Try
    End Sub
    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            MdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing.Text)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        End Try
    End Sub
    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Try
            MdiChildWindow.txtIncomingColor_MouseDown()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        End Try
    End Sub
    Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            MdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Document.Selection.GetSelectedText(), txtIncoming, txtOutgoing)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp")
        End Try
    End Sub
    Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        Try
            MdiChildWindow.txtIncomingColor_TextChanged(txtIncoming.VerticalScroll.Maximum)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
        End Try
    End Sub
    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        Try
            MdiChildWindow.tmrGetNames_Tick(lvwNickList.Items.Count)
            tmrGetNames.Enabled = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick")
        End Try
    End Sub
    Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            MdiChildWindow.lvwNickList_DoubleClick()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick")
        End Try
    End Sub
    Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click
        Try
            MdiChildWindow.cmdPart_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click")
        End Try
    End Sub
    Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click
        Try
            MdiChildWindow.cmdHide_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click")
        End Try
    End Sub
    Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click
        Try
            MdiChildWindow.cmdNotice_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notice.Click")
        End Try
    End Sub
    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        Try
            MdiChildWindow.cmdAddToChannelFolder_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        End Try
    End Sub
    Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click
        Try
            MdiChildWindow.cmdNames_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        End Try
    End Sub
    Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            MdiChildWindow.Form_FormClosing()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        End Try
    End Sub
    Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            MdiChildWindow.Form_Resize(Me.ClientSize.Width, Me.ClientSize.Height, txtOutgoing.Height, txtIncoming.Top)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub
#End Region
#Region "Class Events"
    Private Sub lMdiChildWindow_BringToFront() Handles MdiChildWindow.BringToFront
        Try
            Me.BringToFront()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_BringToFront() Handles mdiChildWindow.BringToFront")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles MdiChildWindow.ClearIncomingTextBoxSelection
        Try
            txtIncoming.Document.Selection.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles mdiChildWindow.ClearIncomingTextBoxSelection")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ClearNickList() Handles MdiChildWindow.ClearNickList
        Try
            lvwNickList.Items.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearNickList() Handles mdiChildWindow.ClearNickList")
        End Try
    End Sub
    Private Sub lMdiChildWindow_CloseForm() Handles MdiChildWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_CloseForm() Handles mdiChildWindow.CloseForm")
        End Try
    End Sub
    Private Sub lMdiChildWindow_DisableGetNamesTimer() Handles MdiChildWindow.DisableGetNamesTimer
        Try
            tmrGetNames.Enabled = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_DisableGetNamesTimer() Handles mdiChildWindow.DisableGetNamesTimer")
        End Try
    End Sub
    Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles MdiChildWindow.EmptyOutgoingTextBox
        Try
            txtOutgoing.Text = ""
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles mdiChildWindow.EmptyOutgoingTextBox")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles MdiChildWindow.FormDimensions
        Try
            Me.Width = width
            Me.Height = height
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles mdiChildWindow.FormDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormFocus() Handles MdiChildWindow.FormFocus
        Try
            Me.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormFocus() Handles mdiChildWindow.FormFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles MdiChildWindow.FormIcon
        Try
            Me.Icon = icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles mdiChildWindow.FormIcon")
        End Try
    End Sub
    Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles MdiChildWindow.IncomingTextBoxDimensions
        Try
            txtIncoming.Width = width
            txtIncoming.Height = height
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles mdiChildWindow.IncomingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingSetFocus() Handles MdiChildWindow.OutgoingSetFocus
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingSetFocus() Handles mdiChildWindow.OutgoingSetFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles MdiChildWindow.OutgoingTextBoxDimensions
        Try
            txtOutgoing.Width = width
            txtOutgoing.Top = top
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles mdiChildWindow.OutgoingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ScrollToCaret() Handles MdiChildWindow.ScrollToCaret
        Try
            If (txtIncoming IsNot Nothing) Then
                If (txtIncoming.Document IsNot Nothing) Then
                    If (txtIncoming.Document.CaretPosition IsNot Nothing) Then
                        txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    End If
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_ScrollToCaret() Handles mdiChildWindow.ScrollToCaret")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles MdiChildWindow.SetIncomingColors
        Try
            txtIncoming.RichTextBoxElement.PageBackground = backgroundColor
            txtIncoming.RichTextBoxElement.ForeColor = foregroundColor
            txtIncoming.RichTextBoxElement.BorderWidth = 0
            txtIncoming.RichTextBoxElement.BackColor = backgroundColor
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetIncomingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetNicklistColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles MdiChildWindow.SetNicklistColors
        Try
            lvwNickList.ListViewElement.BackColor = backgroundColor
            lvwNickList.ListViewElement.ForeColor = foregroundColor
            lvwNickList.ListViewElement.BorderColor = Color.Black
            lvwNickList.ListViewElement.BorderWidth = 0
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetNicklistColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetNicklistColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles MdiChildWindow.SetOutgoingColors
        Try
            txtOutgoing.TextBoxElement.BackColor = backgroundColor
            txtOutgoing.TextBoxElement.ForeColor = foregroundColor
            txtOutgoing.TextBoxElement.ShowBorder = False
            txtOutgoing.TextBoxElement.Border.Width = 0
            txtOutgoing.TextBoxElement.Border.BackColor = Color.Black
            txtOutgoing.TextBoxElement.Border.ForeColor = Color.Black
            txtOutgoing.TextBoxElement.Border.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetOutgoingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles MdiChildWindow.SetParent
        Try
            Me.MdiParent = parentForm
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles mdiChildWindow.SetParent")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles MdiChildWindow.SetWindowState
        Try
            Me.WindowState = windowState
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles mdiChildWindow.SetWindowState")
        End Try
    End Sub
#End Region
End Class