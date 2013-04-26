'nexIRC 3.0.23
'07-05-2013 - guideX
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

    Private Sub frmChannel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        lChannels.Window_Closing(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        'End Try
    End Sub

    Private Sub frmChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        'lChannels.Window_Load(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub

    Private Sub frmChannel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        If lMeIndex <> 0 Then
            lChannels.Window_Resize(lMeIndex)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmChannel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        'End Try
    End Sub

    Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus
        'Try
        lChannels.Outgoing_GotFocus(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        'Try
        lChannels.Outgoing_KeyDown(lMeIndex, e.KeyCode)
        e.SuppressKeyPress = True
        'e.Handled = True
        'e.Handled = True
        'e.SuppressKeyPress = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.Click")
        'End Try
    End Sub

    Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked
        'Try
        lChannels.Incoming_LinkClick(lMeIndex, e.LinkText)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Private Sub txtOutgoing_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress
        'Try
        'e.Handled = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutgoing.KeyPress")
        'End Try
    End Sub

    Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        'Try
        Me.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown")
        'End Try
    End Sub

    Private Sub lstUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        lChannels.Users_DoubleClick(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub lstUsers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Try
        Me.Focus()
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmd_NickListPopup.DropDown.Show()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstUsers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)")
        'End Try
    End Sub

    Private Sub cmd_Hide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Hide.Click
        On Error Resume Next
        lChannels.Minimize(lMeIndex)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Hide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Hide.Click")
    End Sub

    Private Sub cmd_Part_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Part.Click
        On Error Resume Next
        Me.Close()
        lChannels.RemoveTree(lMeIndex)
        ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cPART, lChannels.Name(lMeIndex))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Part_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Part.Click")
    End Sub

    Private Sub cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Close.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Close.Click")
    End Sub

    Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click
        'Try
        AddToChannelFolders(lChannels.Name(lMeIndex), lChannels.StatusIndex(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Private Sub cmd_Notice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notice.Click
        'Try
        Dim msg As String
        msg = InputBox("Enter notice message:")
        If Len(msg) <> 0 Then ProcessReplaceCommand(lMeIndex, eCommandTypes.cNOTICE, lChannels.Name(lMeIndex), msg)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Notice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notice.Click")
        'End Try
    End Sub

    Private Sub cmd_Names_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Names.Click
        On Error Resume Next
        lvwNicklist.Items.Clear()
        ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Names_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Names.Click")
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
            Clipboard.SetText(txtIncomingColor.SelectedText)
        End If
        txtOutgoing.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncomingColor.MouseUp")
    End Sub

    Private Sub txtIncomingColor_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.SelectionChanged
        On Error Resume Next
        'MsgBox(e.ToString)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncomingColor.SelectionChanged")
    End Sub

    Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged
        On Error Resume Next
        'txtIncomingColor.ScrollToCaret()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub txtIncomingColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingColor.TextChanged")
    End Sub

    Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick
        On Error Resume Next
        If lvwNicklist.Items.Count = 0 Then
            ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        End If
        tmrGetNames.Enabled = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrGetNames_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetNames.Tick")
    End Sub

    Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick
        'Try
        lChannels.NickList_DoubleClick(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwNicklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNicklist.DoubleClick")
        'End Try
    End Sub

    Private Sub cmd_ChannelOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelOperator.Click
        'Try
        Dim _SelectedIndex As Integer, msg As String = ""
        If lvwNicklist.SelectedItems.Count = 1 Then
            msg = lvwNicklist.SelectedItems(0).Text
        Else
            For _SelectedIndex = 0 To lvwNicklist.SelectedItems.Count - 1
                If Len(msg) <> 0 Then
                    msg = msg & " " & lvwNicklist.SelectedItems(_SelectedIndex).Text
                Else
                    msg = lvwNicklist.SelectedItems(_SelectedIndex).Text
                End If
            Next _SelectedIndex
        End If
        If Len(msg) <> 0 Then lStatus.DoStatusSocket(lChannels.StatusIndex(lMeIndex), "MODE " & lChannels.Name(lMeIndex) & " +o " & msg)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelOperator.Click")
        'End Try
    End Sub

    Private Sub cmd_URL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_URL.Click
        'Try
        mdiMain.BrowseURL(lChannels.URL(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_URL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_URL.Click")
        'End Try
    End Sub

    Private Sub txtOutgoing_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOutgoing.TextChanged

    End Sub
End Class
