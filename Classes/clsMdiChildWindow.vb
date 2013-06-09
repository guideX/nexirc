'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class clsMdiChildWindow
    Public Enum eFormTypes
        fStatus = 1
        fChannel = 2
        fNoticeWindow = 3
        fMotdWindow = 4
        fUnknown = 5
        fUnsupported = 6
        fPrivateMessage = 7
    End Enum

    Public lForeMost As Boolean
    Private lMeIndex As Integer
    Private lFormType As eFormTypes

    Public Sub SetFormType(_FormType As eFormTypes)
        'Try
        lFormType = _FormType
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetFormType(_FormType As eFormTypes)")
        'End Try
    End Sub

    Public Sub cmdAddToChannelFolder_Click()
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                AddToChannelFolders(lChannels.Name(lMeIndex), lChannels.StatusIndex(lMeIndex))
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        'End Try
    End Sub

    Public Sub cmdNames_Click(_NickList As ListView)
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                _NickList.Items.Clear()
                ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        'End Try
    End Sub

    Public Sub txtOutgoing_GotFocus(_Form As Form)
        'Try
        lChannels.ResetForeMostWindows()
        lStatus.ResetForeMostWindows()
        lForeMost = True
        _Form.BringToFront()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
        'End Try
    End Sub

    Public Sub txtOutgoing_KeyDown(ByRef e As System.Windows.Forms.KeyEventArgs, ByRef _TextBox As TextBox)
        'Try
        Select Case lFormType
            Case eFormTypes.fStatus
                Dim msg As String
                If e.KeyCode = 13 Then
                    msg = _TextBox.Text
                    _TextBox.Text = ""
                    lStatus.ProcessUserInput(lMeIndex, msg)
                    e.SuppressKeyPress = True
                    'e.Handled = True
                    Exit Sub
                End If
            Case eFormTypes.fChannel
                lChannels.Outgoing_KeyDown(lMeIndex, e.KeyCode)
                If e.KeyCode = 13 Then
                    e.SuppressKeyPress = True
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        'End Try
    End Sub

    Public Sub txtIncomingColor_MouseDown(lForm As Form, _txtOutgoing As TextBox)
        'Try
        lForm.BringToFront()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseDown()")
        'End Try
    End Sub

    Public Sub cmd_JoinChannel_Click()
        'Try
        frmChannelJoin.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmd_JoinChannel_Click()")
        'End Try
    End Sub

    Public Sub txtIncomingColor_MouseUp(_SelectedText As String, ByRef _txtOutgoing As TextBox)
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
                Case eFormTypes.fStatus
                    lMeIndex = _MeIndex
            End Select
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As String")
            'End Try
        End Set
    End Property

    Public Sub Form_Resize(ByRef _IncomingRichTextBox As RichTextBox, ByRef _OutgoingTextBox As TextBox, ByRef _Form As Form)
        'Handles Me.Resize
        'Try
        Select Case lFormType
            Case eFormTypes.fStatus
                _IncomingRichTextBox.Width = _Form.ClientSize.Width
                _IncomingRichTextBox.Height = _Form.ClientSize.Height - (_OutgoingTextBox.Height + _IncomingRichTextBox.Top)
                _OutgoingTextBox.Width = _IncomingRichTextBox.Width
                _OutgoingTextBox.Top = _IncomingRichTextBox.Height + _IncomingRichTextBox.Top
            Case eFormTypes.fChannel
                If lMeIndex <> 0 Then
                    lChannels.Window_Resize(lMeIndex)
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_Resize()")
        'End Try
    End Sub

    Public Sub cmdChangeNickName_Click()
        Dim _StatusIndex As Integer
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                _StatusIndex = lChannels.StatusIndex(lMeIndex)
            Case eFormTypes.fStatus
                _StatusIndex = lMeIndex
        End Select
        If _StatusIndex <> 0 Then
            frmChangeNickname.SetServerWindow(lMeIndex)
            frmChangeNickname.Show()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdChangeNickName_Click()")
        'End Try
    End Sub

    Public Sub Form_Load(ByRef _IncomingTextBox As RichTextBox, ByRef _OutgoingTextBox As TextBox, _Form As Form, _FormType As eFormTypes)
        'Try
        lFormType = _FormType
        _Form.Icon = mdiMain.Icon
        _Form.MdiParent = mdiMain
        Select Case lFormType
            Case eFormTypes.fStatus
                lFormType = eFormTypes.fStatus
                'txtIncomingColor.BackColor = System.Drawing.Color.FromArgb(RGB(233, 240, 249))
                'Form_Resize(_IncomingTextBox, _OutgoingTextBox, _Form)
            Case eFormTypes.fChannel
                lFormType = eFormTypes.fChannel
            Case Else
                _Form.Width = lIRC.iSettings.sWindowSizes.iNotice.wWidth
                _Form.Height = lIRC.iSettings.sWindowSizes.iNotice.wHeight
        End Select
        Form_Resize(_IncomingTextBox, _OutgoingTextBox, _Form)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_Load(_FormName As String)")
        'End Try
    End Sub

    Public Sub Form_GotFocus(_Form As Form)
        'Try
        Dim _StatusIndex As Integer = ReturnMeStatusIndex()
        If _StatusIndex <> 0 Then
            lChannels.CurrentIndex = 0
            If lIRC.iSettings.sAutoMaximize = True Then _Form.WindowState = FormWindowState.Maximized
            lStatus.SetSeenIcon(_StatusIndex, True)
            lStatus.ActiveIndex = _StatusIndex
        End If
        '_Form.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_GotFocus()")
        'End Try
    End Sub

    Public Sub Form_FormClosing(Optional ByRef _Form As frmStatus = Nothing, Optional ByRef e As System.Windows.Forms.FormClosingEventArgs = Nothing)
        'Try
        Select Case lFormType
            Case eFormTypes.fStatus
                lStatus.Form_Closing(_Form, e)
            Case eFormTypes.fChannel
                lChannels.Window_Closing(lMeIndex)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub Form_FormClosing()")
        'End Try
    End Sub

    Public Sub txtIncomingColor_TextChanged(ByRef _RichTextBox As RichTextBox)
        'Try
        _RichTextBox.ScrollToCaret()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub txtIncomingColor_TextChanged()")
        'End Try
    End Sub

    Public Sub tmrGetNames_Tick(ByRef _NickList As ListView)
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                If _NickList.Items.Count = 0 Then
                    ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNAMES, lChannels.Name(MeIndex))
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub tmrGetNames_Tick(_NickList As ListView)")
        'End Try
    End Sub

    Private Function ReturnMeStatusIndex() As Integer
        'Try
        Dim _StatusIndex As Integer
        Select Case lFormType
            Case eFormTypes.fChannel
                _StatusIndex = lChannels.StatusIndex(lMeIndex)
            Case eFormTypes.fStatus
                _StatusIndex = lMeIndex
        End Select
        Return _StatusIndex
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function ReturnMeStatusIndex() As Integer")
        'Return Nothing
        'End Try
    End Function

    Public Sub cmdSendNewNotice_Click()
        'Try
        Dim _Form As New frmSendNotice
        _Form.StatusIndex = ReturnMeStatusIndex()
        _Form.Visible = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdSendNewNotice_Click()")
        'End Try
    End Sub

    Public Sub cmdNewPrivateMessage_Click()
        'Try
        Dim _Form As New frmPrivateMessage
        _Form.StatusIndex = ReturnMeStatusIndex()
        _Form.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdNewPrivateMessage_Click()")
        'End Try
    End Sub

    Public Sub cmdChangeConnection_Click()
        'Try
        Dim _Form As New frmChangeConnection
        _Form.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdChangeConnection_Click()")
        'End Try
    End Sub

    Public Sub cmdToggleConnection_Click()
        'Try
        lStatus.ToggleConnection(ReturnMeStatusIndex())
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdToggleConnection()")
        'End Try
    End Sub

    Public Sub cmdConnect_Click()
        'Try
        lStatus.Connect(ReturnMeStatusIndex())
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdConnect_Click()")
        'End Try
    End Sub

    Public Sub tmrConnectDelay_Tick()
        'Try
        lStatus.Connect(ReturnMeStatusIndex())
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub lAutoConnectDelayTimer_Tick()")
        'End Try
    End Sub

    Public Sub cmdChannelFolder_Click()
        'Try
        lChannelFolder.SetStatusIndex(lMeIndex)
        lChannelFolder.ShowWindow()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdChannelFolder_Click()")
        'End Try
    End Sub

    Public Sub cmdDisconnect_Click()
        'Try
        Dim _StatusIndex As Integer = ReturnMeStatusIndex()
        If lStatus.Connected(_StatusIndex) = True Or lStatus.ReturnStatusConnecting(_StatusIndex) = True Then
            lStatus.CloseStatusConnection(_StatusIndex, True)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdDisconnect_Click()")
        'End Try
    End Sub

    Public Sub lvwNickList_DoubleClick()
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                lChannels.NickList_DoubleClick(lMeIndex)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub lvwNickList_DoubleClick()")
        'End Try
    End Sub

    Public Sub cmdListChannels_Click()
        'Try
        ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cLIST)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdListChannels()")
        'End Try
    End Sub

    Public Sub cmdUrl_Click()
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                mdiMain.BrowseURL(lChannels.URL(lMeIndex))
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdUrl_Click()")
        'End Try
    End Sub

    Public Sub cmdPart_Click(_Form As Form)
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                _Form.Close()
                lChannels.RemoveTree(lMeIndex)
                ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cPART, lChannels.Name(lMeIndex))
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdPart_Click(_Form As Form)")
        'End Try
    End Sub

    Public Sub cmdHide_Click()
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                lChannels.Minimize(lMeIndex)
            Case eFormTypes.fStatus
                lStatus.Minimize(lMeIndex)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdHide_Click()")
        'End Try
    End Sub

    Public Sub cmdNotice_Click()
        'Try
        Select Case lFormType
            Case eFormTypes.fChannel
                Dim msg As String
                msg = InputBox("Enter notice message:")
                If Len(msg) <> 0 Then ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNOTICE, lChannels.Name(MeIndex), msg)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub cmdNotice_Click()")
        'End Try
    End Sub

    Public Sub TextBox_LinkClicked(_Link As String)
        'Try
        mdiMain.BrowseURL(_Link)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub TextBox_LinkClicked(_Link As String)")
        'End Try
    End Sub
End Class