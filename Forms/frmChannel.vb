'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChannel
    Private lMeIndex As Integer

    Public WriteOnly Property MeIndex() As Integer
        Set(_MeIndex As Integer)
            'Try
            lMeIndex = _MeIndex
            lChannels.SetChannelVisible(_MeIndex, True)
            lChannels.CurrentIndex = _MeIndex
            lChannels.Window_Load(lMeIndex)
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As String")
            'End Try
        End Set
    End Property

    Private Sub frmChannel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        lChannels.Window_Closing(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        'End Try
    End Sub

    Private Sub frmChannel_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        'Try
        If lMeIndex <> 0 Then
            lChannels.Window_Resize(lMeIndex)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub

    Private Sub txtOutgoing_GotFocus(sender As Object, e As System.EventArgs) Handles txtOutgoing.GotFocus
        'Try
        lChannels.Outgoing_GotFocus(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        'Try
        lChannels.Outgoing_KeyDown(lMeIndex, e.KeyCode)
        If e.KeyCode = 13 Then
            e.SuppressKeyPress = True
        End If
        'e.Handled = True
        'e.Handled = True
        'e.SuppressKeyPress = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_Click(sender As Object, e As System.EventArgs) Handles txtIncomingColor.Click
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click")
        'End Try
    End Sub

    Private Sub txtIncomingColor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        'Try
        lChannels.Incoming_LinkClick(lMeIndex, e.LinkText)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Private Sub txtOutgoing_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp
        'Try
        If Len(txtIncomingColor.SelectedText) <> 0 Then
            Clipboard.Clear()
            Clipboard.SetText(txtIncomingColor.SelectedText)
        End If
        txtOutgoing.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
        'End Try
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged
        'Try
        'txtIncomingColor.ScrollToCaret()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
        'End Try
    End Sub

    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        'Try
        If lvwNicklist.Items.Count = 0 Then
            ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        End If
        tmrGetNames.Enabled = False
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick")
        'End Try
    End Sub

    Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick
        'Try
        lChannels.NickList_DoubleClick(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick")
        'End Try
    End Sub

    Private Sub cmdURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdURL.Click
        'Try
        mdiMain.BrowseURL(lChannels.URL(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_URL.Click")
        'End Try
    End Sub

    Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click
        'Try
        Me.Close()
        lChannels.RemoveTree(lMeIndex)
        ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cPART, lChannels.Name(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdPart.Click")
        'End Try
    End Sub

    Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click
        'Try
        lChannels.Minimize(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdHide.Click")
        'End Try
    End Sub

    Private Sub cmdNotice_Click(sender As System.Object, e As System.EventArgs) Handles cmdNotice.Click
        'Try
        Dim msg As String
        msg = InputBox("Enter notice message:")
        If Len(msg) <> 0 Then ProcessReplaceCommand(lMeIndex, eCommandTypes.cNOTICE, lChannels.Name(lMeIndex), msg)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notice.Click")
        'End Try
    End Sub

    Private Sub cmdAddToChannelFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddToChannelFolder.Click
        'Try
        AddToChannelFolders(lChannels.Name(lMeIndex), lChannels.StatusIndex(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click
        'Try
        lvwNicklist.Items.Clear()
        ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        'End Try
    End Sub

    Private Sub txtOutgoing_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOutgoing.TextChanged

    End Sub

    Private Sub frmChannel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            frmChannel_Resize(sender, e)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class