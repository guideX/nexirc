'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class clsMdiChildWindow
    Private Enum eFormTypes
        fStatus = 1
        fChannel = 2
    End Enum

    Private lMeIndex As Integer
    Private lFormType As eFormTypes

    Public Sub cmdAddToChannelFolder_Click()
        'Try
        AddToChannelFolders(lChannels.Name(lMeIndex), lChannels.StatusIndex(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Public Sub cmdNames_Click(_NickList As ListView)
        'Try
        _NickList.Items.Clear()
        ProcessReplaceCommand(lChannels.StatusIndex(lMeIndex), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        'End Try
    End Sub

    Public Sub txtOutgoing_GotFocus()
        'Try
        lChannels.Outgoing_GotFocus(lMeIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Public Sub txtOutgoing_KeyDown(e As System.Windows.Forms.KeyEventArgs)
        'Try
        lChannels.Outgoing_KeyDown(lMeIndex, e.KeyCode)
        If e.KeyCode = 13 Then
            e.SuppressKeyPress = True
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Public Sub txtIncomingColor_LinkClicked(e As System.Windows.Forms.LinkClickedEventArgs)
        'Try
        lChannels.Incoming_LinkClick(lMeIndex, e.LinkText)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtIncomingColor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtIncomingColor.LinkClicked")
        'End Try
    End Sub

    Public Sub txtIncomingColor_MouseDown(lForm As Form)
        'Try
        lForm.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseDown()")
        'End Try
    End Sub

    Public Sub txtIncomingColor_MouseUp(_SelectedText As String, _txtOutgoing As TextBox)
        'Try
        If Len(_SelectedText) <> 0 Then
            Clipboard.Clear()
            Clipboard.SetText(_SelectedText)
        End If
        _txtOutgoing.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseUp(_SelectedText As String)")
        'End Try
    End Sub

    Public Sub txtOutgoing_MouseDown(lForm As Form)
        'Try
        lForm.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtOutgoing_MouseDown()")
        'End Try
    End Sub

    Public Sub txtIncomingColor_Click(lForm As Form)
        'Try
        lForm.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtIncomingColor_Click(sender As Object, e As System.EventArgs)")
        'End Try
    End Sub

    Public Property MeIndex() As Integer
        Get
            Return lMeIndex
        End Get
        Set(_MeIndex As Integer)
            'Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    lMeIndex = _MeIndex
                    lChannels.SetChannelVisible(_MeIndex, True)
                    lChannels.CurrentIndex = _MeIndex
                    lChannels.Window_Load(lMeIndex)
            End Select
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As String")
            'End Try
        End Set
    End Property

    Public Sub Form_Resize()
        'Handles Me.Resize
        'Try
        Select Case lFormType
            Case eFormTypes.fStatus
            Case eFormTypes.fChannel
                If lMeIndex <> 0 Then
                    lChannels.Window_Resize(lMeIndex)
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_Resize()")
        'End Try
    End Sub

    Public Sub Form_Load(_FormName As String)
        'Try
        Select Case _FormName
            Case "frmStatus"
                lFormType = eFormTypes.fStatus
            Case "frmChannel"
                lFormType = eFormTypes.fChannel
        End Select
        Form_Resize()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_Load(_FormName As String)")
        'End Try
    End Sub

    Public Sub Form_FormClosing()
        'Try
        Select Case lFormType
            Case eFormTypes.fStatus
            Case eFormTypes.fChannel
                lChannels.Window_Closing(lMeIndex)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_FormClosing()")
        'End Try
    End Sub
End Class