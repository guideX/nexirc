﻿'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.RichTextBox
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
    Public Event ClearIncomingTextBoxSelection()
    Public Event ScrollToCaret()
    Public Event CloseForm()
    Public Event ClearNickList()
    Public Event IncomingTextBoxDimensions(width As Integer, height As Integer)
    Public Event OutgoingTextBoxDimensions(width As Integer, top As Integer)
    Public Event DisableGetNamesTimer()
    Public Event FormDimensions(width As Integer, height As Integer)
    Public Event FormFocus()
    Public Event FormIcon(icon As System.Drawing.Icon)
    Public Event SetParent(parentForm As Form)
    Public Event SetIncomingColors(backgroundColor As Color, foregroundColor As Color)
    Public Event SetOutgoingColors(backgroundColor As Color, foregroundColor As Color)
    Public Event SetNicklistColors(backgroundColor As Color, foregroundColor As Color)
    Public Event BringToFront()
    Public Event EmptyOutgoingTextBox()
    Public Event SetWindowState(windowState As FormWindowState)
    Private lMeIndex As Integer
    Private lFormType As eFormTypes
    Public Sub tmrWaitForLUsers_Tick()

    End Sub
    Public Sub SetFormType(_FormType As eFormTypes)
        Try
            lFormType = _FormType
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetFormType(_FormType As eFormTypes)")
        End Try
    End Sub
    Public Sub cmdAddToChannelFolder_Click()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    AddToChannelFolders(lChannels.Name(lMeIndex), lChannels.StatusIndex(lMeIndex))
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
        End Try
    End Sub
    Public Sub cmdNames_Click()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    RaiseEvent ClearNickList()
                    ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNAMES, lChannels.Name(lMeIndex))
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdNames_Click(sender As System.Object, e As System.EventArgs) Handles cmdNames.Click")
        End Try
    End Sub
    Public Sub txtOutgoing_GotFocus()
        Try
            lChannels.ResetForeMostWindows()
            lStatus.ResetForeMostWindows()
            lForeMost = True
            RaiseEvent BringToFront()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutgoing.GotFocus")
        End Try
    End Sub
    Public Sub txtOutgoing_KeyDown(ByRef e As System.Windows.Forms.KeyEventArgs, text As String)
        Try
            Select Case lFormType
                Case eFormTypes.fStatus
                    If e.KeyCode = 13 Then
                        RaiseEvent EmptyOutgoingTextBox()
                        lStatus.ProcessUserInput(lMeIndex, text)
                        e.SuppressKeyPress = True
                        Exit Sub
                    End If
                Case eFormTypes.fChannel
                    lChannels.Outgoing_KeyDown(lMeIndex, e.KeyCode)
                    If e.KeyCode = 13 Then
                        e.SuppressKeyPress = True
                    End If
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        End Try
    End Sub
    Public Sub txtOutgoing_KeyDown(ByRef e As System.Windows.Forms.KeyEventArgs, ByRef _TextBox As TextBox)
        Try
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
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown")
        End Try
    End Sub
    Public Sub txtIncomingColor_MouseDown()
        Try
            lStatus.ActiveIndex = MeIndex
            RaiseEvent BringToFront()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseDown()")
        End Try
    End Sub
    Public Sub txtIncomingColor_MouseDown(lForm As Form, _txtOutgoing As TextBox)
        Try
            lForm.BringToFront()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseDown()")
        End Try
    End Sub
    Public Sub txtIncomingColor_MouseUp(_SelectedText As String, ByRef _txtOutgoing As TextBox)
        Try
            If Len(_SelectedText) <> 0 Then
                Clipboard.Clear()
                Clipboard.SetText(_SelectedText)
            End If
            _txtOutgoing.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseUp(_SelectedText As String)")
        End Try
    End Sub
    Public Event OutgoingSetFocus()
    Public Sub txtIncomingColor_MouseUp(text As String, txtIncoming As RadRichTextBox, txtOutgoing As RadTextBox)
        Try
            RaiseEvent ClearIncomingTextBoxSelection()
            If Len(text) <> 0 Then
                Clipboard.Clear()
                Clipboard.SetText(text)
            End If
            RaiseEvent OutgoingSetFocus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub txtIncomingColor_MouseUp(_SelectedText As String)")
        End Try
    End Sub
    Public Property MeIndex() As Integer
        Get
            Return lMeIndex
        End Get
        Set(_MeIndex As Integer)
            Try
                Select Case lFormType
                    Case eFormTypes.fChannel
                        lMeIndex = _MeIndex
                        lChannels.SetChannelVisible(_MeIndex, True)
                        lChannels.CurrentIndex = _MeIndex
                        'lChannels.Window_Load(lMeIndex)
                    Case eFormTypes.fStatus
                        lMeIndex = _MeIndex
                End Select
            Catch ex As Exception
                ProcessError(ex.Message, "Public WriteOnly Property MeIndex() As String")
            End Try
        End Set
    End Property
    Public Sub Form_Resize(formClientSizeWidth As Integer, formClientSizeHeight As Integer, outgoingTextboxHeight As Integer, incomingTextBoxTop As Integer)
        Dim incomingWidth As Integer, incomingHeight As Integer
        Try
            Select Case lFormType
                Case eFormTypes.fStatus
                    incomingWidth = formClientSizeWidth
                    incomingHeight = formClientSizeHeight - (outgoingTextboxHeight + incomingTextBoxTop)
                    RaiseEvent IncomingTextBoxDimensions(incomingWidth, incomingHeight)
                    RaiseEvent OutgoingTextBoxDimensions(incomingWidth, (incomingHeight + incomingTextBoxTop))
                Case eFormTypes.fChannel
                    If lMeIndex <> 0 Then
                        lChannels.Window_Resize(lMeIndex)
                    End If
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Resize()")
        End Try
    End Sub
    Public Sub Form_Resize(ByRef _IncomingRichTextBox As RichTextBox, ByRef _OutgoingTextBox As TextBox, ByRef _Form As Form)
        Try
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
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Resize()")
        End Try
    End Sub
    Public Sub cmdChangeNickName_Click()
        Dim _StatusIndex As Integer
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    _StatusIndex = lChannels.StatusIndex(lMeIndex)
                Case eFormTypes.fStatus
                    _StatusIndex = lMeIndex
            End Select
            If _StatusIndex <> 0 Then
                Dim f As New frmChangeNickName
                f = New frmChangeNickName
                f.lChangeNickName.lServerIndex = lMeIndex
                clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdChangeNickName_Click()")
        End Try
    End Sub
    Public Sub Form_Load(_FormType As eFormTypes)
        Try
            lFormType = _FormType
            RaiseEvent FormIcon(MdiMain.Icon)
            RaiseEvent SetParent(MdiMain)
            RaiseEvent SetIncomingColors(Color.Black, Color.White)
            RaiseEvent SetOutgoingColors(Color.Blue, Color.White)
            Select Case _FormType
                Case eFormTypes.fStatus
                    lStatus.Window_Resize(lMeIndex)
                Case eFormTypes.fChannel
                    lChannels.Window_Resize(lMeIndex)
                    RaiseEvent SetNicklistColors(Color.Blue, Color.White)
            End Select
            RaiseEvent FormDimensions(Convert.ToInt32((MdiMain.Width / 10) * 8), Convert.ToInt32(MdiMain.Height / 2))
            RaiseEvent FormFocus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Load(_FormName As String)")
        End Try
    End Sub
    Public Sub Form_Load(ByRef _IncomingTextBox As RichTextBox, ByRef _OutgoingTextBox As TextBox, _Form As Form, _FormType As eFormTypes)
        Try
            lFormType = _FormType
            _Form.Icon = MdiMain.Icon
            _Form.MdiParent = MdiMain
            Select Case _FormType
                Case eFormTypes.fStatus
                    Form_Resize(_IncomingTextBox, _OutgoingTextBox, _Form)
                Case eFormTypes.fChannel
                    lChannels.Window_Resize(lMeIndex)
                Case Else
                    '_Form.Width = lIRC.iSettings.sWindowSizes.iNotice.wWidth
                    '_Form.Height = lIRC.iSettings.sWindowSizes.iNotice.wHeight
            End Select
            _Form.Width = Convert.ToInt32((MdiMain.Width / 10) * 8)
            _Form.Height = Convert.ToInt32(MdiMain.Height / 2)
            _Form.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Load(_FormName As String)")
        End Try
    End Sub
    Public Sub Form_GotFocus()
        Try
            Dim _StatusIndex As Integer = ReturnMeStatusIndex()
            If _StatusIndex <> 0 Then
                lChannels.CurrentIndex = 0
                If lIRC.iSettings.sAutoMaximize = True Then RaiseEvent SetWindowState(FormWindowState.Maximized)
                lStatus.SetSeenIcon(_StatusIndex, True)
                lStatus.ActiveIndex = _StatusIndex
            End If
            '_Form.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_GotFocus()")
        End Try
    End Sub
    Public Sub Form_GotFocus(_Form As Form)
        Try
            Dim _StatusIndex As Integer = ReturnMeStatusIndex()
            If _StatusIndex <> 0 Then
                lChannels.CurrentIndex = 0
                If lIRC.iSettings.sAutoMaximize = True Then _Form.WindowState = FormWindowState.Maximized
                lStatus.SetSeenIcon(_StatusIndex, True)
                lStatus.ActiveIndex = _StatusIndex
            End If
            '_Form.Focus()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_GotFocus()")
        End Try
    End Sub
    Public Sub Form_FormClosing(Optional ByRef _Form As FrmStatus = Nothing, Optional ByRef e As System.Windows.Forms.FormClosingEventArgs = Nothing)
        Try
            Select Case lFormType
                Case eFormTypes.fStatus
                    lStatus.Form_Closing(_Form, lMeIndex, e)
                Case eFormTypes.fChannel
                    lChannels.Window_Closing(lMeIndex)
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_FormClosing()")
        End Try
    End Sub
    Public Sub txtIncomingColor_TextChanged(verticalScrollMaximum As Integer)
        Try
            RaiseEvent ScrollToCaret()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub txtIncomingColor_TextChanged()")
        End Try
    End Sub
    Public Sub tmrGetNames_Tick(nickListItemsCount As Integer)
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    If nickListItemsCount = 0 Then
                        ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNAMES, lChannels.Name(MeIndex))
                    End If
            End Select
            RaiseEvent DisableGetNamesTimer()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub tmrGetNames_Tick(_NickList As ListView)")
        End Try
    End Sub
    Private Function ReturnMeStatusIndex() As Integer
        Try
            Dim _StatusIndex As Integer
            Select Case lFormType
                Case eFormTypes.fChannel
                    _StatusIndex = lChannels.StatusIndex(lMeIndex)
                Case eFormTypes.fStatus
                    _StatusIndex = lMeIndex
            End Select
            Return _StatusIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Private Function ReturnMeStatusIndex() As Integer")
            Return Nothing
        End Try
    End Function
    Public Sub cmdSendNewNotice_Click()
        Try
            Dim _Form As New frmSendNotice
            _Form.lSendNoticeUI.StatusIndex = ReturnMeStatusIndex()
            _Form.Visible = True
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdSendNewNotice_Click()")
        End Try
    End Sub
    Public Sub cmdNewPrivateMessage_Click()
        Try
            Dim _Form As New frmPrivateMessage
            _Form.StatusIndex = ReturnMeStatusIndex()
            _Form.Show()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdNewPrivateMessage_Click()")
        End Try
    End Sub
    Public Sub cmdToggleConnection_Click()
        Try
            lStatus.ToggleConnection(ReturnMeStatusIndex())
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdToggleConnection()")
        End Try
    End Sub
    Public Sub cmdConnect_Click()
        Try
            lStatus.Connect(ReturnMeStatusIndex())
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdConnect_Click()")
        End Try
    End Sub
    Public Sub tmrConnectDelay_Tick()
        Try
            lStatus.Connect(ReturnMeStatusIndex())
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub lAutoConnectDelayTimer_Tick()")
        End Try
    End Sub
    Public Sub cmdChannelFolder_Click()
        Try
            lChannelFolder.Show(lMeIndex)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdChannelFolder_Click()")
        End Try
    End Sub
    Public Sub cmdDisconnect_Click()
        Try
            Dim _StatusIndex As Integer = ReturnMeStatusIndex()
            If lStatus.Connected(_StatusIndex) = True Or lStatus.ReturnStatusConnecting(_StatusIndex) = True Then
                lStatus.CloseStatusConnection(_StatusIndex, True)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdDisconnect_Click()")
        End Try
    End Sub
    Public Sub lvwNickList_DoubleClick()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    lChannels.NickList_DoubleClick(lMeIndex)
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub lvwNickList_DoubleClick()")
        End Try
    End Sub
    Public Sub cmdListChannels_Click()
        Try
            ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cLIST)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdListChannels()")
        End Try
    End Sub
    Public Sub cmdPart_Click()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    RaiseEvent CloseForm()
                    lChannels.RemoveTree(lMeIndex)
                    ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cPART, lChannels.Name(lMeIndex))
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdPart_Click(_Form As Form)")
        End Try
    End Sub
    Public Sub cmdHide_Click()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    lChannels.Minimize(lMeIndex)
                Case eFormTypes.fStatus
                    lStatus.Minimize(lMeIndex)
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdHide_Click()")
        End Try
    End Sub
    Public Sub cmdNotice_Click()
        Try
            Select Case lFormType
                Case eFormTypes.fChannel
                    Dim msg As String
                    msg = InputBox("Enter notice message:")
                    If Len(msg) <> 0 Then ProcessReplaceCommand(ReturnMeStatusIndex(), eCommandTypes.cNOTICE, lChannels.Name(MeIndex), msg)
            End Select
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdNotice_Click()")
        End Try
    End Sub
End Class