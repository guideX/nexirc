﻿'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannel
    Public lMdiChildWindow As New clsMdiChildWindow

    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        'Try
        lMdiChildWindow.txtOutgoing_GotFocus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        'Try
        lMdiChildWindow.txtOutgoing_KeyDown(e)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_Click(sender As Object, e As System.EventArgs) Handles txtIncomingColor.Click
        'Try
        lMdiChildWindow.txtIncomingColor_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click")
        'End Try
    End Sub

    Private Sub txtIncomingColor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        'Try
        lMdiChildWindow.txtIncomingColor_LinkClicked(e)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Private Sub txtOutgoing_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        'Try
        lMdiChildWindow.txtOutgoing_MouseDown(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown
        'Try
        lMdiChildWindow.txtIncomingColor_MouseDown(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp
        'Try
        lMdiChildWindow.txtIncomingColor_MouseUp(txtIncomingColor.SelectedText, txtOutgoing)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
        'End Try
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged
        'Try
        txtIncomingColor.ScrollToCaret()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
        'End Try
    End Sub

    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        'Try
        If lvwNicklist.Items.Count = 0 Then
            ProcessReplaceCommand(lChannels.StatusIndex(lMdiChildWindow.MeIndex), eCommandTypes.cNAMES, lChannels.Name(lMdiChildWindow.MeIndex))
        End If
        tmrGetNames.Enabled = False
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick")
        'End Try
    End Sub

    Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick
        'Try
        lChannels.NickList_DoubleClick(lMdiChildWindow.MeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick")
        'End Try
    End Sub

    Private Sub cmdURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdURL.Click
        'Try
        mdiMain.BrowseURL(lChannels.URL(lMdiChildWindow.MeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_URL.Click")
        'End Try
    End Sub

    Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click
        'Try
        Me.Close()
        lChannels.RemoveTree(lMdiChildWindow.MeIndex)
        ProcessReplaceCommand(lChannels.StatusIndex(lMdiChildWindow.MeIndex), eCommandTypes.cPART, lChannels.Name(lMdiChildWindow.MeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click")
        'End Try
    End Sub

    Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click
        'Try
        lChannels.Minimize(lMdiChildWindow.MeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click")
        'End Try
    End Sub

    Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click
        'Try
        Dim msg As String
        msg = InputBox("Enter notice message:")
        If Len(msg) <> 0 Then ProcessReplaceCommand(lMdiChildWindow.MeIndex, eCommandTypes.cNOTICE, lChannels.Name(lMdiChildWindow.MeIndex), msg)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notice.Click")
        'End Try
    End Sub

    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        'Try
        lMdiChildWindow.cmdAddToChannelFolder_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click
        'Try
        lMdiChildWindow.cmdNames_Click(lvwNicklist)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        'End Try
    End Sub

    Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        lMdiChildWindow.Form_FormClosing()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        'End Try
    End Sub

    Private Sub frmChannel_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Try
        lMdiChildWindow.Form_Load(Me.Name)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_Load(sender As Object, e As System.EventArgs) Handles Me.Load")
        'End Try
    End Sub

    Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        'Try
        lMdiChildWindow.Form_Resize()
        'Catch ex As Exception
        'ProcessError(ex.Message,"Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub
End Class