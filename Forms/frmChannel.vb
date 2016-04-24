'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.RichTextBox.Model
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.Enumerations
Imports System.ComponentModel

Public Class frmChannel
#Region "Public Variables"
    Public WithEvents MdiChildWindow As New MdiChildWindow
#End Region
#Region "Window Events"
    Private Sub txtOutgoing_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        Me.BringToFront()
    End Sub

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        Try
            txtIncoming.Document = New RadDocument()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            MdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Try
            MdiChildWindow.txtIncomingColor_MouseDown()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtIncoming_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            MdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Document.Selection.GetSelectedText(), txtIncoming, txtOutgoing)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncoming.TextChanged
        Try
            MdiChildWindow.txtIncomingColor_TextChanged(txtIncoming.VerticalScroll.Maximum)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        Try
            MdiChildWindow.tmrGetNames_Tick(lvwNickList.Items.Count)
            tmrGetNames.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            MdiChildWindow.lvwNickList_DoubleClick()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click
        Try
            MdiChildWindow.cmdPart_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click
        Try
            MdiChildWindow.cmdHide_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click
        Try
            MdiChildWindow.cmdNotice_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        Try
            MdiChildWindow.cmdAddToChannelFolder_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click
        Try
            MdiChildWindow.cmdNames_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            MdiChildWindow.Form_FormClosing(Me, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmChannel_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            lvwNickList.SortDescriptors.Add(New SortDescriptor("Text", ListSortDirection.Ascending))
            lvwNickList.EnableSorting = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            MdiChildWindow.Form_Resize(Me.ClientSize.Width, Me.ClientSize.Height, txtOutgoing.Height, txtIncoming.Top)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Class Events"
    Private Sub MdiChildWindow_AddToNickList(nickName As String) Handles MdiChildWindow.AddToNickList
        Try
            Dim m = lvwNickList.Items.Where(Function(n) n.Text.ToLower().Trim().Replace("@", "").Replace("+", "").Replace("-", "") = nickName.ToLower().Trim().Replace("@", "").Replace("+", "").Replace("-", ""))
            If (m.Count = 0) Then lvwNickList.Items.Add(nickName)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub lMdiChildWindow_BringToFront() Handles MdiChildWindow.BringToFront
        Try
            Me.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles MdiChildWindow.ClearIncomingTextBoxSelection
        Try
            txtIncoming.Document.Selection.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_ClearNickList() Handles MdiChildWindow.ClearNickList
        Try
            lvwNickList.Items.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_CloseForm() Handles MdiChildWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_DisableGetNamesTimer() Handles MdiChildWindow.DisableGetNamesTimer
        Try
            tmrGetNames.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MdiChildWindow_DisableNameDelayTimer() Handles MdiChildWindow.DisableNameDelayTimer
        Try
            tmrAddNameDelay.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles MdiChildWindow.EmptyOutgoingTextBox
        Try
            txtOutgoing.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles MdiChildWindow.FormDimensions
        Try
            Me.Width = width
            Me.Height = height
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_FormFocus() Handles MdiChildWindow.FormFocus
        Try
            Me.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles MdiChildWindow.FormIcon
        Try
            Me.Icon = icon
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles MdiChildWindow.IncomingTextBoxDimensions
        Try
            txtIncoming.Width = width
            txtIncoming.Height = height
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MdiChildWindow_NickListBeginUpdate() Handles MdiChildWindow.NickListBeginUpdate
        lvwNickList.Items.BeginUpdate()
    End Sub

    Private Sub MdiChildWindow_NickListEndUpdate() Handles MdiChildWindow.NickListEndUpdate
        lvwNickList.Items.EndUpdate()
    End Sub

    Private Sub lMdiChildWindow_OutgoingSetFocus() Handles MdiChildWindow.OutgoingSetFocus
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles MdiChildWindow.OutgoingTextBoxDimensions
        Try
            txtOutgoing.Width = width
            txtOutgoing.Top = top
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_ScrollToCaret() Handles MdiChildWindow.ScrollToCaret
        Try
            If (txtIncoming IsNot Nothing) Then
                If (txtIncoming.Document IsNot Nothing) Then
                    If (txtIncoming.Document.CaretPosition IsNot Nothing) Then
                        'txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles MdiChildWindow.SetIncomingColors
        Try
            txtIncoming.RichTextBoxElement.PageBackground = backgroundColor
            txtIncoming.RichTextBoxElement.ForeColor = foregroundColor
            txtIncoming.RichTextBoxElement.BorderWidth = 0
            txtIncoming.RichTextBoxElement.BackColor = backgroundColor
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_SetNicklistColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles MdiChildWindow.SetNicklistColors
        Try
            lvwNickList.ListViewElement.BackColor = backgroundColor
            lvwNickList.ListViewElement.ForeColor = foregroundColor
            lvwNickList.ListViewElement.BorderColor = Color.Black
            lvwNickList.ListViewElement.BorderWidth = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MdiChildWindow_SetNickListSortSettings() Handles MdiChildWindow.SetNickListSortSettings
        Try
            lvwNickList.EnableSorting = True
            lvwNickList.EnableColumnSort = True
        Catch ex As Exception
            Throw ex
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
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles MdiChildWindow.SetParent
        Try
            Me.MdiParent = parentForm
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles MdiChildWindow.SetWindowState
        Try
            Me.WindowState = windowState
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lvwNickList_DoubleClick1(sender As Object, e As System.EventArgs) Handles lvwNickList.DoubleClick
        Try
            MdiChildWindow.lvwNickList_DoubleClick()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tmrAddNameDelay_Tick(sender As System.Object, e As System.EventArgs) Handles tmrAddNameDelay.Tick
        Try
            MdiChildWindow.tmrAddNameDelay_Tick()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class