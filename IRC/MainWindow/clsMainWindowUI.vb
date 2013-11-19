Imports nexIRC.Classes.IO
Imports nexIRC.Classes.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Namespace nexIRC.MainWindow
    Public Class clsMainWindowUI
        Public WithEvents lProcesses As New clsProcess
        Public lVideo As New gVideo
        Private lLoadingForm As New frmLoading
        Private lFlashesLeft As Integer
        Public Structure gVideo
            Public vWindow As frmVideoPlayer
            Public vFile As String
            Public vVisible As Boolean
        End Structure
        Public Structure gBrowser
            'Public bWindow As frmBrowser
            Public bURL As String
            Public bVisible As Boolean
        End Structure
        Public Enum gWindowBarImageTypes
            wStatus = 1
            wChannel = 2
            wServer = 3
            wNotice = 4
        End Enum
        Public Enum eInfoBar
            iWelcome = 1
            iSocketError = 2
            iNetworkAvailable = 3
            iNetworkUnavailable = 4
            iNickServ_NickTaken = 5
            iNicknameInUse = 6
        End Enum
        Public Event QueryBarPromptLabelVisible(text As String, tag As String)

        Public Sub ShowQueryBar(ByVal _Text As String, ByVal _Function As eInfoBar, _QueryPromptLabel As ToolStripLabel, _ToolStrip As ToolStrip)
            Try
                If Len(_Text) <> 0 Then
                    RaiseEvent QueryBarPromptLabelVisible(_Text, Trim(CType(_Function, Integer).ToString))
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub ShowQueryBar(ByVal lText As String)")
            End Try
        End Sub
        Public Sub SetFlashesLeft(ByVal _Value As Integer, _FlashDCCToolBarTimer As Timer)
            Try
                lFlashesLeft = _Value
                _FlashDCCToolBarTimer.Enabled = True
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub SetFlashesLeft(ByVal lValue As Integer)")
            End Try
        End Sub
        'Public Function AddWindowBar(ByVal _Text As String, ByVal _ImageType As gWindowBarImageTypes, _ImageList As ImageList, _ToolStrip As RadStatusStrip) As Telerik.WinControls.RadItem
        Public Function AddWindowBar(ByVal _Text As String, ByVal _ImageType As gWindowBarImageTypes, _ToolStrip As RadStatusStrip) As RadItem
            Try
                'LEON
                'IMAGE IS FUCKED, FIX IT!
                Dim i As Integer ', lImage As Image
                Select Case _ImageType
                    Case gWindowBarImageTypes.wStatus
                        i = 0
                    Case gWindowBarImageTypes.wChannel
                        i = 1
                    Case gWindowBarImageTypes.wServer
                        i = 2
                    Case gWindowBarImageTypes.wNotice
                        i = 3
                End Select
                'lImage = _ImageList.Images(i)
                Dim radItem As New Telerik.WinControls.RadItem()
                radItem.Text = _Text
                _ToolStrip.Items.Add(radItem)
                Return radItem
            Catch ex As Exception
                ProcessError(ex.Message, "Public Function AddWindowBar(ByVal lText As String, ByVal lImageType As gWindowBarImageTypes, ByVal lSender As Object, ByVal lEventArgs As System.EventArgs) As ToolStripItem")
                Return Nothing
            End Try
        End Function
        Public Sub RemoveWindowBar(ByVal _Text As String, _ToolStrip As ToolStrip)
            Try
                Dim i As Integer
                For i = 0 To _ToolStrip.Items.Count - 1
                    If LCase(Trim(_ToolStrip.Items(i).Text)) = LCase(Trim(_Text)) Then
                        _ToolStrip.Items.Remove(_ToolStrip.Items(i))
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub RemoveWindowBar(ByVal lText As String)")
            End Try
        End Sub
        Public Sub ClearWindowBar(_ToolStrip As RadStatusStrip)
            Try
                _ToolStrip.Items.Clear()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub ClearWindowBar()")
            End Try
        End Sub
        Public Sub PlayVideo(ByVal lFile As String)
            Try
                If Len(lFile) <> 0 And clsFiles.DoesFileExist(lFile) = True Then
                    If lVideo.vVisible = False Then
                        lVideo.vVisible = True
                        lVideo.vWindow = Nothing
                        lVideo.vWindow = New frmVideoPlayer
                        lVideo.vWindow.Show()
                        lVideo.vWindow.OpenAndPlay(lFile)
                    Else
                        lVideo.vWindow.OpenAndPlay(lFile)
                    End If
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub PlayVideo(ByVal lFile As String)")
            End Try
        End Sub
        Private Function IsPageExempt(ByVal lURL As String) As Boolean
            Try
                Dim splt() As String = Split(lURL, "/")
                'If InStr(splt(2), "'06-13-2013 - guideX") <> 0 Or InStr(splt(0), "tnexgen.com") <> 0 Then
                Return True
                'End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Function IsPageExempt(ByVal lURL As String) As Boolean")
            End Try
        End Function
        Public Sub FormClosed(_Form As Form, _NotifyIcon As NotifyIcon, _SideBarShown As Boolean)
            Try
                If _Form.WindowState = FormWindowState.Minimized Then _NotifyIcon.Visible = True
                clsFiles.WriteINI(lINI.iIRC, "mdiMain", "Left", _Form.Left.ToString().Trim())
                clsFiles.WriteINI(lINI.iIRC, "mdiMain", "Top", _Form.Top.ToString().Trim())
                clsFiles.WriteINI(lINI.iIRC, "mdiMain", "Width", _Form.Width.ToString().Trim())
                clsFiles.WriteINI(lINI.iIRC, "mdiMain", "Height", _Form.Height.ToString().Trim())
                clsFiles.WriteINI(lINI.iIRC, "mdiMain", "SideBarShown", _SideBarShown.ToString())
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub mdiMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
            End Try
        End Sub
        Public Sub FormClosing(e As System.Windows.Forms.FormClosingEventArgs, _Form As Form, _WaitForQuitTimer As Timer)
            Try
                lStatus.Closing = True
                If lStatus.QuitAll() = False Then
                    e.Cancel = True
                    _Form.Visible = False
                    _WaitForQuitTimer.Enabled = True
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub mdiMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
            End Try
        End Sub
        Public Sub SetLoadingFormProgress(ByVal _Data As String, ByVal _Value As Integer)
            Try
                lLoadingForm.SetProgress(_Data, _Value)
                lLoadingForm.Refresh()
                Application.DoEvents()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub SetLoadingFormProgress(ByVal _Data As String, ByVal _Value As Integer)")
            End Try
        End Sub
        Public Function OpenDialogFileNames(_DialogOpen As OpenFileDialog, ByVal _InitDir As String, ByVal _Title As String, ByVal _Filter As String) As String()
            Try
                With _DialogOpen
                    .Filter = _Filter
                    .InitialDirectory = _InitDir
                    .Title = _Title
                    .ShowDialog()
                    .Multiselect = True
                    Return .FileNames
                End With
            Catch ex As Exception
                ProcessError(ex.Message, "Public Function OpenDialogFileNames(ByVal lInitDir As String, ByVal lTitle As String, ByVal lFilter As String) As String()")
                Return Nothing
            End Try
        End Function
        Public Sub Form_Load(_Form As Form, _NotifyIcon As NotifyIcon, _TimerStartupSettings As Timer, _LeftBarButton As Button, _LeftNav As Panel, _ToolStrip As ToolStrip, _WindowsToolStrip As ToolStrip)
            Try
                _WindowsToolStrip.ForeColor = Color.White
                _NotifyIcon.Visible = True
                _NotifyIcon.Icon = _Form.Icon
                lLoadingForm = New frmLoading
                clsAnimate.Animate(lLoadingForm, clsAnimate.Effect.Center, 200, 1)
                lLoadingForm.Focus()
                Application.DoEvents()
                SetLoadingFormProgress("Initializing Status Windows", 2)
                SetArraySizes()
                lStatus = New Global.nexIRC.IRC.Status.clsStatus(lArraySizes.aStatusWindows)
                SetLoadingFormProgress("Initializing Processes", 5)
                lProcesses.Initialize()
                SetLoadingFormProgress("Loading Settings", 7)
                LoadSettings()
                SetLoadingFormProgress("Browsing URL", 95)
                lLoadingForm.Focus()
                If lServers.sIndex <> 0 Then lStatus.Create(lIRC, lServers)
                _Form.Left = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "mdiMain", "Left", CStr(_Form.Left))))
                _Form.Top = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "mdiMain", "Top", CStr(_Form.Top))))
                _Form.Width = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "mdiMain", "Width", CStr(_Form.Width))))
                _Form.Height = CInt(Trim(clsFiles.ReadINI(lINI.iIRC, "mdiMain", "Height", CStr(_Form.Height))))
                If lIRC.iIdent.iSettings.iEnabled = True Then
                    lIdent.InitListenSocket(113)
                End If
                SetLoadingFormProgress("Loading Complete", 100)
                lLoadingForm.Close()
                _TimerStartupSettings.Interval = 500
                _TimerStartupSettings.Enabled = True
                _Form.Text = "nexIRC v" & Application.ProductVersion
                If (Convert.ToBoolean(clsFiles.ReadINI(lINI.iIRC, "Settings", "SideBarShown", "False")) = False) Then
                    _LeftBarButton.Left = 0
                    _LeftNav.Visible = False
                End If
                Form_Resize(_Form, _LeftBarButton, _LeftNav, _ToolStrip, _WindowsToolStrip)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub Form_Load(_Form As Form, _NotifyIcon As NotifyIcon, _TimerStartupSettings As Timer, _LeftBarButton As Button, _LeftNav As Panel, _ToolStrip As ToolStrip, _WindowsToolStrip As ToolStrip)")
            End Try
        End Sub
        Public Sub Form_Resize(_Form As Form, _LeftButton As Button, _LeftNav As Panel, _ToolStrip As ToolStrip, _WindowsToolStrip As ToolStrip)
            Try
                'clsLockWindowUpdate.LockWindowUpdate(_Form.Handle)
                _LeftButton.Top = CInt(_Form.ClientSize.Height / 2)
                If _LeftNav.Visible = True Then
                    _LeftButton.Left = _LeftNav.ClientSize.Width
                Else
                    _LeftButton.Left = 0
                End If
                If lVideo.vVisible = True Then
                    If lVideo.vWindow.Left <> 0 Then lVideo.vWindow.Left = 0
                    If lVideo.vWindow.Top <> 0 Then lVideo.vWindow.Top = 0
                    If _LeftNav.Visible = True Then
                        lVideo.vWindow.Width = _Form.ClientSize.Width - (_LeftNav.ClientSize.Width + 4)
                    Else
                        lVideo.vWindow.Width = _Form.ClientSize.Width - (4)
                    End If
                    If _WindowsToolStrip.Visible = True Then
                        If _ToolStrip.Visible = True Then
                            lVideo.vWindow.Height = _Form.ClientSize.Height - (_WindowsToolStrip.ClientSize.Height + _ToolStrip.ClientSize.Height + 4)
                        Else
                            lVideo.vWindow.Height = _Form.ClientSize.Height - (_WindowsToolStrip.ClientSize.Height + 4)
                        End If
                    Else
                        If _ToolStrip.Visible = True Then
                            lVideo.vWindow.Height = _Form.ClientSize.Height - (_ToolStrip.ClientSize.Height + 4)
                        Else
                            lVideo.vWindow.Height = _Form.ClientSize.Height - (4)
                        End If
                    End If
                End If
                'ResizeBrowser(_Form, _LeftNav, _ToolStrip, _WindowsToolStrip)
                '_Form.Refresh()
                'clsLockWindowUpdate.LockWindowUpdate(System.IntPtr.Zero)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub Form_Resize(_Form As Form)")
            End Try
        End Sub
        Public Sub SetWindowFocus(ByVal _Form As Form)
            Try
                If _Form.WindowState = FormWindowState.Minimized Then _Form.WindowState = FormWindowState.Normal
                If lIRC.iSettings.sAutoMaximize = True And _Form.WindowState <> FormWindowState.Maximized Then _Form.WindowState = FormWindowState.Maximized
                _Form.BringToFront()
                _Form.Focus()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub SetWindowFocus(ByVal _Form As Form)")
            End Try
        End Sub
        Public Sub HideChildren(_Form As Form, ByVal _Except As Form, _ActiveForm As Form)
            Try
                Dim i As Integer
                If _ActiveForm.Name = _Except.Name Then Exit Sub
                For i = 0 To (_Form.MdiChildren.Length) - 1
                    If _Form.MdiChildren(i).Visible = True Then _Form.MdiChildren(i).Visible = False
                Next i
                _Except.Visible = True
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub HideChildren(_Form As Form, ByVal _Except As Form, _ActiveForm As Form)")
            End Try
        End Sub
        Public Sub StartupSettingsTimer_Tick(_Timer As Timer)
            Try
                _Timer.Enabled = False
                If lIRC.iSettings.sCustomizeOnStartup = True Then
                    frmCustomize.Show()
                    frmCustomize.Focus()
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub tmrStartupSettings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStartupSettings.Tick")
            End Try
        End Sub
        Public Sub FlashDCCToolBarTimer_Tick(_Timer As Timer)
            Try
                If lFlashesLeft = 0 Then
                    _Timer.Enabled = False
                    Exit Sub
                End If
                lFlashesLeft = lFlashesLeft - 1
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub FlashDCCToolBarTimer_Tick(_Timer As Timer)")
            End Try
        End Sub
        Public Sub WindowsToolStrip_ItemClicked(ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
            Dim _ChannelIndex As Integer = 0, _MeIndex As Integer
            Try
                If (IsNumeric(e.ClickedItem.Tag.ToString()) = True) Then
                    _MeIndex = CType(e.ClickedItem.Tag.ToString(), Integer)
                    If DoLeft(e.ClickedItem.Text, 1) = "#" Then
                        _ChannelIndex = lChannels.Find(_MeIndex, e.ClickedItem.Text.ToString)
                        If (lChannels.Visible(_ChannelIndex) = True) Then
                            lChannels.ToggleChannelWindowState(_ChannelIndex, lChannels.Window(_ChannelIndex).lMdiChildWindow.lForeMost)
                        Else
                            lChannels.Form_Load(_ChannelIndex)
                            mdiMain.SetWindowFocus(lChannels.Window(_ChannelIndex))
                        End If
                    ElseIf InStr(e.ClickedItem.Text, "(") <> 0 And InStr(e.ClickedItem.Text, ")") <> 0 Then
                        If (lStatus.Window(_MeIndex) IsNot Nothing) Then
                            If (lStatus.Window(_MeIndex).Visible) = True Then
                                lStatus.ToggleStatusWindowState(_MeIndex, lStatus.Window(_MeIndex).lMdiChildWindow.lForeMost)
                            End If
                        End If
                    Else
                        If (lStatus.PrivateMessage_Visible(_MeIndex, e.ClickedItem.Text) = True) Then
                            lStatus.PrivateMessage_ToggleWindowState(Convert.ToInt32(e.ClickedItem.Tag), lStatus.PrivateMessage_Find(Convert.ToInt32(e.ClickedItem.Tag), e.ClickedItem.Text))
                        Else
                            lStatus.PrivateMessages_Initialize(Convert.ToInt32(e.ClickedItem.Tag), e.ClickedItem.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub tspWindows_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tspWindows.ItemClicked")
            End Try
        End Sub
        Public Sub Connections_DoubleClick(_SelectedNode As TreeNode)
            Try
                lStatus.DblClickConnections(_SelectedNode)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub Connections_DoubleClick(_SelectedNode As TreeNode)")
            End Try
        End Sub
        Public Sub cmdAcceptQuery_Click(_QueryPromptLabel As ToolStripItem, _QueryPromptToolStrip As ToolStrip)
            Try
                Dim splt() As String, _NickName As String, _HostName As String
                If Len(_QueryPromptLabel.Tag.ToString) = 1 Then
                    Select Case CType(CType(_QueryPromptLabel.Tag.ToString, Integer), eInfoBar)
                        Case eInfoBar.iNickServ_NickTaken
                            clsAnimate.Animate(frmNickServLogin, clsAnimate.Effect.Center, 200, 1)
                            frmNickServLogin.SetStatusIndex(lStatus.ActiveIndex)
                    End Select
                ElseIf InStr(_QueryPromptLabel.Tag.ToString, ":") <> 0 Then
                    splt = Split(_QueryPromptLabel.Tag.ToString, ":")
                    If lQuerySettings.qAutoShowWindow = True Then
                        _NickName = ParseData(_QueryPromptLabel.Text, "'", "(")
                        _HostName = ParseData(_QueryPromptLabel.Text, "(", ")")
                        lStatus.PrivateMessages_Add(CInt(Trim(splt(0))), _NickName, _HostName, splt(2))
                    End If
                    _QueryPromptToolStrip.Visible = False
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdAcceptQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcceptQuery.Click")
            End Try
        End Sub
        Public Sub cmdDeclineQuery_Click(_QueryPromptToolStrip As ToolStrip)
            Try
                _QueryPromptToolStrip.Visible = False
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdDeclineQuery_Click(_QueryPromptToolStrip As ToolStrip)")
            End Try
        End Sub
        Public Sub cmd_ClearHistory_Click(_Recent1 As ToolStripMenuItem, _Recent2 As ToolStripMenuItem, _Recent3 As ToolStripMenuItem)
            Try
                Dim i As Integer
                _Recent1.Text = "(Empty)"
                _Recent2.Text = "(Empty)"
                _Recent3.Text = "(Empty)"
                _Recent1.Enabled = False
                _Recent2.Enabled = False
                _Recent3.Enabled = False
                For i = 1 To lRecientServers.sCount
                    lRecientServers.sItem(i) = ""
                Next i
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_ClearHistory_Click(_Recent1 As Button, _Recent2 As Button, _Recent3 As Button)")
            End Try
        End Sub
        Public Sub cmd_Connect_Click()
            Try
                lStatus.ActiveStatusConnect()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Connect_Click()")
            End Try
        End Sub
        Public Sub cmd_Disconnect_Click()
            'On Error Resume Next
            lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
            'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click")
        End Sub
        Public Sub cmd_CloseStatus_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                lStatus.CloseWindow(i)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_CloseStatus_Click()")
            End Try
        End Sub
        Public Sub cmd_Exit_Click()
            Try
                End
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click")
            End Try
        End Sub
        Public Sub cmd_Channels_ButtonClick()
            Try
                lChannelFolder.Show(lStatus.ActiveIndex)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_Channels_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Channels.ButtonClick")
            End Try
        End Sub
        Public Sub cmd_Connection_ButtonClick()
            Try
                lStatus.ToggleConnection(lStatus.ActiveIndex)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_Connection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connection.ButtonClick")
            End Try
        End Sub
        Public Sub cmd_Customize_Click()
            Try
                frmCustomize.Show()
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_Customize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Customize.Click")
            End Try
        End Sub
        Public Sub cmd_ListChannels_Click()
            Try
                Dim n As Integer = lStatus.ActiveIndex
                ProcessReplaceCommand(n, eCommandTypes.cLIST, lStatus.ServerDescription(n))
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ListChannels.Click")
            End Try
        End Sub
        Public Sub cmd_LeftBar_Click(_LeftBarButton As ToolStripMenuItem, _LeftPanel As Panel, _Form As Form)
            Try
                If _LeftBarButton.Checked = True Then
                    _LeftBarButton.Checked = False
                    _LeftPanel.Visible = False
                    _Form.Width = _Form.Width + 1
                Else
                    _LeftBarButton.Checked = True
                    _LeftPanel.Visible = True
                    _Form.Width = _Form.Width + 1
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_LeftBar_Click(_LeftBarButton As Button, _LeftPanel As Panel)")
            End Try
        End Sub
        Public Sub cmd_WindowBar_Click(_WindowBarButton As ToolStripMenuItem, _WindowsToolStrip As ToolStrip, _Form As Form)
            Try
                If _WindowBarButton.Checked = True Then
                    _WindowBarButton.Checked = False
                    _WindowsToolStrip.Visible = False
                Else
                    _WindowBarButton.Checked = True
                    _WindowsToolStrip.Visible = True
                End If
                _Form.Width = _Form.Width + 1
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_WindowBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WindowBar.Click")
            End Try
        End Sub
        Public Sub cmd_Cascade_Click(_Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.Cascade)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Cascade_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_TileHorizontal_Click(_Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.TileHorizontal)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_TileHorizontal_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_TileVertical_Click(_Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.TileVertical)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_TileVertical_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_ArrangeIcons_Click(_Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.ArrangeIcons)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_ArrangeIcons_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_ChannelFolder_Click()
            Try
                lChannelFolder.Show(lStatus.ActiveIndex)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
            End Try
        End Sub
        Public Sub cmd_Window_ButtonClick(_Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.Cascade)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Window_ButtonClick(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_NewStatusWindow_Click()
            Try
                lStatus.Create(lIRC, lServers)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_NewStatusWindow_Click()")
            End Try
        End Sub
        Public Sub cmd_View_ButtonClick()
            Try
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_View_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.ButtonClick")
            End Try
        End Sub
        Public Sub cmd_DCCSend_Click()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCSend()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_DCCSend_Click()")
            End Try
        End Sub
        Public Sub cmd_DCCChat_Click()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCChat()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_DCCChat_Click()")
            End Try
        End Sub
        Public Sub cmd_DownloadManager_Click()
            Try
                clsAnimate.Animate(frmDownloadManager, clsAnimate.Effect.Center, 200, 1)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_DownloadManager_Click()")
            End Try
        End Sub
        Public Sub cmd_DCC_ButtonClick()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCSend()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_DCC_ButtonClick()")
            End Try
        End Sub
        Public Sub cmd_RecientServer1_Click(_Recent1 As String)
            Try
                If Len(_Recent1) <> 0 And _Recent1 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent1, 6667)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_RecientServer1_Click(_Recent1 As String)")
            End Try
        End Sub
        Public Sub cmd_RecientServer2_Click(_Recent2 As String)
            Try
                If Len(_Recent2) <> 0 And _Recent2 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent2, 6667)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_RecientServer2_Click(_Recent2 As String)")
            End Try
        End Sub
        Public Sub cmd_RecientServer3_Click(_Recent3 As String)
            Try
                If Len(_Recent3) <> 0 And _Recent3 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent3, 6667)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_RecientServer3_Click(_Recent3 As String)")
            End Try
        End Sub
        Public Sub cmdLeftBar_Click(_ActiveForm As Form, _cmd_LeftBarButton As ToolStripMenuItem, _LeftPanel As Panel, _Form As Form)
            Try
                If _cmd_LeftBarButton.Checked = True Then
                    clsAnimate.Animate(_LeftPanel, clsAnimate.Effect.Slide, 200, 1)
                    _cmd_LeftBarButton.Checked = False
                    'Panel1.Visible = False
                Else
                    _cmd_LeftBarButton.Checked = True
                    'Panel1.Visible = True
                    clsAnimate.Animate(_LeftPanel, clsAnimate.Effect.Slide, 200, 1)
                End If
                _Form.Width = _Form.Width + 1
                _ActiveForm.Focus()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmdLeftBar_Click(_ActiveForm As Form)")
            End Try
        End Sub
        Public Sub cmd_ServerLinks_Click()
            Try
                lStatus.SendSocket(lStatus.ActiveIndex, "LINKS")
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_ServerLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ServerLinks.Click")
            End Try
        End Sub
        Public Sub cmd_Whois_Click()
            Try
                Dim msg As String, i As Integer
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter whois nickname")
                If Len(msg) <> 0 Then ProcessReplaceCommand(i, eCommandTypes.cWHOIS, msg)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Whois_Click()")
            End Try
        End Sub
        Public Sub cmd_Whowas_Click()
            Try
                Dim msg As String, i As Integer
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter whowas nickname")
                If Len(msg) <> 0 Then ProcessReplaceCommand(i, eCommandTypes.cWHOWAS, msg)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Whowas_Click()")
            End Try
        End Sub
        Public Sub cmd_Time_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                ProcessReplaceCommand(i, eCommandTypes.cTIME)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Time_Click()")
            End Try
        End Sub
        Public Sub cmd_Stats_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                ProcessReplaceCommand(i, eCommandTypes.cSTATS)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Stats_Click()")
            End Try
        End Sub
        Public Sub cmd_Away_Click()
            Try
                Dim i As Integer, msg As String
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter away message:")
                ProcessReplaceCommand(i, eCommandTypes.cAWAY, msg)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Away_Click()")
            End Try
        End Sub
        Public Sub cmd_Back_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                ProcessReplaceCommand(i, eCommandTypes.cBACK)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_Back_Click()")
            End Try
        End Sub
        Public Sub cmd_PlayVideo_Click(_OpenFileDialog As OpenFileDialog)
            Try
                Dim msg() As String, i As Integer
                msg = OpenDialogFileNames(_OpenFileDialog, Application.StartupPath, "Play Video", "Video Files |*.avi,*.mov,*.wmv,*.mpg,*.mpeg")
                i = msg.Length - 1
                If i <> -1 Then PlayVideo(msg(i))
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_PlayVideo_Click()")
            End Try
        End Sub
        Public Sub mnuExit_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub mnuExit_Click(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_CloseConnection_Click()
            Try
                lStatus.Quit(lStatus.ActiveIndex())
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmd_CloseConnection_Click()")
            End Try
        End Sub
        Public Sub cmdAccept_Click(_UserToolStripLabel As ToolStripLabel, _ToolStrip As ToolStrip, _DCCToolBarToolStrip As ToolStrip)
            Try
                Dim splt() As String, lForm As New frmDCCGet
                splt = Split(_UserToolStripLabel.Tag.ToString, vbCrLf)
                _ToolStrip.Visible = False
                _DCCToolBarToolStrip.Visible = False
                _ToolStrip.Visible = True
                lForm.InitDCCGet(splt(0), splt(1), splt(2), splt(3), splt(4))
                clsAnimate.Animate(lForm, clsAnimate.Effect.Center, 200, 1)
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmdAccept_Click()")
            End Try
        End Sub
        Public Sub cmdDeny_Click(_DCCToolBarToolStrip As ToolStrip)
            Try
                _DCCToolBarToolStrip.Visible = False
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmdDeny_Click(_DCCToolBarToolStrip As ToolStrip)")
            End Try
            'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdDeny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeny.Click")
        End Sub
        Public Sub nicSystray_MouseDoubleClick(_Form As Form)
            Try
                _Form.Show()
                _Form.WindowState = FormWindowState.Normal
                _Form.Focus()
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub nicSystray_MouseDoubleClick(_Form As Form)")
            End Try
        End Sub
        Public Sub cmd_SelectAServer_Click()
            Try
                frmCustomize.Show()
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_SelectAServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_SelectAServer.Click")
            End Try
        End Sub
        Public Sub cmd_ShowAbout_Click()
            Try
                clsAnimate.Animate(frmAbout, clsAnimate.Effect.Slide, 200, 1)
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmd_ShowAbout_Click(sender As System.Object, e As System.EventArgs) Handles cmd_ShowAbout.Click")
            End Try
        End Sub
        Public Sub cmdRedirectDeny_Click(_RedirectToolStrip As ToolStrip)
            Try
                _RedirectToolStrip.Visible = False
            Catch ex As Exception
                ProcessError(ex.Message, "Public Sub cmdRedirectDeny_Click(_RedirectToolStrip As ToolStrip)")
            End Try
        End Sub
        Public Sub cmdRedirectAccept_Click(_RedirectToolStrip As ToolStrip, _RedirectMessageLabel As ToolStripLabel)
            Try
                Dim splt() As String
                _RedirectToolStrip.Visible = False
                If (IsNumeric(_RedirectMessageLabel.Tag.ToString().Trim()) = True) Then
                    splt = _RedirectMessageLabel.Text.ToString().Split(Convert.ToChar("'"))
                    lChannels.Join(Convert.ToInt32(_RedirectMessageLabel.Tag.ToString().Trim()), splt(3))
                End If
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub cmdRedirectAccept_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedirectAccept.Click")
            End Try
        End Sub
        Public Sub tmrWaitForQuit_Tick()
            Try
                End
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub tmrWaitForQuit_Tick(sender As System.Object, e As System.EventArgs) Handles tmrWaitForQuit.Tick")
            End Try
        End Sub
        Public Sub tmrHideRedirect_Tick(_RedirectToolStrip As ToolStrip, _HideRedirectTimer As Timer)
            Try
                _RedirectToolStrip.Visible = False
                _HideRedirectTimer.Enabled = False
            Catch ex As Exception
                ProcessError(ex.Message, "Private Sub tmrHideRedirect_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHideRedirect.Tick")
            End Try
        End Sub
    End Class
End Namespace