'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
'Imports nexIRC.Classes.IO
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports nexIRC.UI
Imports nexIRC.Business.Helpers
Imports nexIRC.IrcSettings
Imports nexIRC.Business.Enums

Namespace nexIRC.MainWindow
    Public Class clsMainWindowUI
        Public WithEvents lProcesses As New IrcProcess
        Private lLoadingForm As New FrmLoading
        Private lFlashesLeft As Integer

        Public Structure gBrowser
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

        Public Event SetBackgroundColor()
        Public Event QueryBarPromptLabelVisible(ByVal text As String, ByVal tag As String)
        Public Event SetDimensions(ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer)
        Public Event EnableStartupSettingsTimer(ByVal tickInterval As Integer)
        Public Event FormTitle(ByVal title As String)

        Public Sub ShowQueryBar(ByVal _Text As String, ByVal _Function As eInfoBar, ByVal _QueryPromptLabel As ToolStripLabel, ByVal _ToolStrip As ToolStrip)
            Try
                If Len(_Text) <> 0 Then
                    RaiseEvent QueryBarPromptLabelVisible(_Text, Trim(CType(_Function, Integer).ToString))
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SetFlashesLeft(ByVal _Value As Integer, ByVal _FlashDCCToolBarTimer As Timer)
            Try
                lFlashesLeft = _Value
                _FlashDCCToolBarTimer.Enabled = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function AddWindowBar(ByVal _Text As String, ByVal _ImageType As gWindowBarImageTypes, ByVal _ImageList As ImageList, ByVal _ToolStrip As ToolStrip) As ToolStripItem
            Try
                Dim lImage As Image, i As Integer
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
                lImage = _ImageList.Images(i)
                Return _ToolStrip.Items.Add(_Text, lImage)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Sub RemoveWindowBar(ByVal _Text As String, ByVal _ToolStrip As ToolStrip)
            Try
                Dim i As Integer
                For i = 0 To _ToolStrip.Items.Count - 1
                    If LCase(Trim(_ToolStrip.Items(i).Text)) = LCase(Trim(_Text)) Then
                        _ToolStrip.Items.Remove(_ToolStrip.Items(i))
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub ClearWindowBar(ByVal _ToolStrip As ToolStrip)
            Try
                _ToolStrip.Items.Clear()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub FormClosed(ByVal _Form As Form, ByVal _NotifyIcon As NotifyIcon, ByVal _SideBarShown As Boolean)
            Try
                If _Form.WindowState = FormWindowState.Minimized Then _NotifyIcon.Visible = True
                IniFileHelper.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Left", _Form.Left.ToString().Trim())
                IniFileHelper.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Top", _Form.Top.ToString().Trim())
                IniFileHelper.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Width", _Form.Width.ToString().Trim())
                IniFileHelper.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Height", _Form.Height.ToString().Trim())
                IniFileHelper.WriteINI(lSettings.lINI.iIRC, "mdiMain", "SideBarShown", _SideBarShown.ToString())
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub FormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs, ByVal _Form As Form, ByVal _WaitForQuitTimer As Timer)
            Try
                lStatus.Closing = True
                If lStatus.QuitAll() = False Then
                    e.Cancel = True
                    _Form.Visible = False
                    _WaitForQuitTimer.Enabled = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SetLoadingFormProgress(ByVal _Data As String, ByVal _Value As Integer)
            Try
                lLoadingForm.SetProgress(_Data, _Value)
                lLoadingForm.Refresh()
                Application.DoEvents()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function OpenDialogFileNames(ByVal _DialogOpen As OpenFileDialog, ByVal _InitDir As String, ByVal _Title As String, ByVal _Filter As String) As String()
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
                Throw ex
                Return Nothing
            End Try
        End Function

        Public Sub Form_Load(ByVal _Form As Form, ByVal _NotifyIcon As NotifyIcon, ByVal _LeftBarButton As Button, ByVal _LeftNav As Panel, ByVal _ToolStrip As ToolStrip, ByVal _WindowsToolStrip As ToolStrip)
            Dim sideBarShown As Boolean
            'Try
            _WindowsToolStrip.ForeColor = Color.White
            _NotifyIcon.Visible = True
            _NotifyIcon.Icon = _Form.Icon
            lLoadingForm = New FrmLoading
            lLoadingForm.Show()
            lLoadingForm.Focus()
            Application.DoEvents()
            SetLoadingFormProgress("Initializing Status Windows", 2)
            lSettings.SetArraySizes()
            lStatus = New Global.nexIRC.IRC.Status.Status(lSettings.lArraySizes.aStatusWindows)
            SetLoadingFormProgress("Initializing Processes", 5)
            lProcesses.Initialize()
            SetLoadingFormProgress("Loading Settings", 7)
            lSettings.LoadSettings()
            lLoadingForm.Focus()
            If lSettings.lServers.sIndex <> 0 Then lStatus.Create(lSettings.lIRC, lSettings.lServers)
            _Form.Left = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "mdiMain", "Left", Convert.ToString(_Form.Left))))
            _Form.Top = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "mdiMain", "Top", Convert.ToString(_Form.Top))))
            _Form.Width = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "mdiMain", "Width", Convert.ToString(_Form.Width))))
            _Form.Height = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "mdiMain", "Height", Convert.ToString(_Form.Height))))
            If lSettings.lIRC.iIdent.iSettings.iEnabled = True Then
                lIdent.Listen(113)
            End If
            SetLoadingFormProgress("Loading Complete", 100)
            lLoadingForm.Close()
            _Form.Text = "nexIRC v" & Application.ProductVersion
            sideBarShown = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "mdiMain", "SideBarShown", "False"))
            _LeftBarButton.Left = 0
            If (Not sideBarShown) Then
                _LeftNav.Visible = False
            Else
                _LeftNav.Visible = True
            End If
            Form_Resize(_Form, _LeftBarButton, _LeftNav, _ToolStrip, _WindowsToolStrip)
            RaiseEvent SetBackgroundColor()
            _Form.Visible = True
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Sub

        Public Sub Form_Resize(ByVal _Form As Form, ByVal _LeftButton As Button, ByVal _LeftNav As Panel, ByVal _ToolStrip As ToolStrip, ByVal _WindowsToolStrip As ToolStrip)
            Try
                _LeftButton.Top = Convert.ToInt32(_Form.ClientSize.Height / 2)
                If _LeftNav.Visible = True Then
                    _LeftButton.Left = _LeftNav.ClientSize.Width
                Else
                    _LeftButton.Left = 0
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SetWindowFocus(ByVal _Form As Form)
            Try
                If _Form.WindowState = FormWindowState.Minimized Then _Form.WindowState = FormWindowState.Normal
                If lSettings.lIRC.iSettings.sAutoMaximize = True And _Form.WindowState <> FormWindowState.Maximized Then _Form.WindowState = FormWindowState.Maximized
                _Form.BringToFront()
                _Form.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub HideChildren(ByVal _Form As Form, ByVal _Except As Form, ByVal _ActiveForm As Form)
            Try
                Dim i As Integer
                If _ActiveForm.Name = _Except.Name Then Exit Sub
                For i = 0 To (_Form.MdiChildren.Length) - 1
                    If _Form.MdiChildren(i).Visible = True Then _Form.MdiChildren(i).Visible = False
                Next i
                _Except.Visible = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub StartupSettingsTimer_Tick(ByVal _Timer As Timer)
            Try
                _Timer.Enabled = False
                If lSettings.lIRC.iSettings.sCustomizeOnStartup = True Then
                    frmCustomize.Show()
                    frmCustomize.Focus()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub FlashDCCToolBarTimer_Tick(ByVal _Timer As Timer)
            Try
                If lFlashesLeft = 0 Then
                    _Timer.Enabled = False
                    Exit Sub
                End If
                lFlashesLeft = lFlashesLeft - 1
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub WindowsToolStrip_ItemClicked(ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
            Dim channelIndex As Integer = 0, meIndex As Integer
            Try
                If (IsNumeric(e.ClickedItem.Tag.ToString()) = True) Then
                    meIndex = CType(e.ClickedItem.Tag.ToString(), Integer)
                    If TextHelper.DoLeft(e.ClickedItem.Text, 1) = "#" Then
                        channelIndex = lChannels.Find(meIndex, e.ClickedItem.Text.ToString)
                        If (lChannels.Visible(channelIndex)) Then
                            lChannels.Focus(channelIndex)
                        Else
                            lChannels.Visible(channelIndex) = True
                        End If
                    ElseIf InStr(e.ClickedItem.Text, "(") <> 0 And InStr(e.ClickedItem.Text, ")") <> 0 Then
                        If (lStatus.Window(meIndex) IsNot Nothing) Then
                            If (lStatus.Visible(meIndex)) Then
                                lStatus.Focus(meIndex)
                            Else
                                lStatus.Visible(meIndex) = True
                            End If
                        End If
                    Else
                        If (lStatus.PrivateMessage_Visible(meIndex, e.ClickedItem.Text) = True) Then
                            lStatus.PrivateMessage_Focus(meIndex, lStatus.PrivateMessage_Find(meIndex, e.ClickedItem.Text))
                            'lStatus.GetObject(meIndex).sPrivateMessages.pPrivateMessage(lStatus.PrivateMessage_Find(meIndex, e.ClickedItem.Text)).pWindow.txtOutgoing.Focus()
                        Else
                            lStatus.PrivateMessage_Visible(meIndex, e.ClickedItem.Text) = True
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Connections_DoubleClick(ByVal _SelectedNode As TreeNode)
            Try
                lStatus.DblClickConnections(_SelectedNode)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdAcceptQuery_Click(ByVal _QueryPromptLabel As ToolStripItem, ByVal _QueryPromptToolStrip As ToolStrip)
            Try
                Dim splt() As String, _NickName As String, _HostName As String
                If Len(_QueryPromptLabel.Tag.ToString) = 1 Then
                    Select Case CType(CType(_QueryPromptLabel.Tag.ToString, Integer), eInfoBar)
                        Case eInfoBar.iNickServ_NickTaken
                            frmNickServLogin.Show()
                            frmNickServLogin.SetStatusIndex(lStatus.ActiveIndex)
                    End Select
                ElseIf InStr(_QueryPromptLabel.Tag.ToString, ":") <> 0 Then
                    splt = Split(_QueryPromptLabel.Tag.ToString, ":")
                    If (New QuerySettings(Application.StartupPath).Get().AutoShowWindow()) Then
                        _NickName = TextHelper.ParseData(_QueryPromptLabel.Text, "'", "(")
                        _HostName = TextHelper.ParseData(_QueryPromptLabel.Text, "(", ")")
                        lStatus.PrivateMessage_Add(Convert.ToInt32(Trim(splt(0))), _NickName, _HostName, splt(2), True)
                    End If
                    _QueryPromptToolStrip.Visible = False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdDeclineQuery_Click(ByVal _QueryPromptToolStrip As ToolStrip)
            Try
                _QueryPromptToolStrip.Visible = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub clearHistory()
            For i = 1 To lSettings.lRecientServers.sCount
                lSettings.lRecientServers.sItem(i) = ""
            Next i
        End Sub

        Public Sub cmd_ClearHistory_Click(ByVal _Recent1 As RadMenuItem, ByVal _Recent2 As RadMenuItem, ByVal _Recent3 As RadMenuItem)
            Try
                'Dim i As Integer
                _Recent1.Text = "(Empty)"
                _Recent2.Text = "(Empty)"
                _Recent3.Text = "(Empty)"
                _Recent1.Enabled = False
                _Recent2.Enabled = False
                _Recent3.Enabled = False
                clearHistory()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub InitializeSharedAddWindow(ByVal type As clsSharedAdd.eSharedAddType)
            Dim form As frmSharedAdd
            Try
                form = New frmSharedAdd()
                form.lSharedAddUI.SharedAddType = type
                form.lSharedAddUI.StatusIndex = lStatus.ActiveIndex
                form.Show()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_IRCOperatorConnect()

        End Sub

        Public Sub cmd_CNotice()

        End Sub

        Public Sub cmd_Info()
            InitializeSharedAddWindow(clsSharedAdd.eSharedAddType.sInfo)
        End Sub

        Public Sub cmd_Error()
            InitializeSharedAddWindow(clsSharedAdd.eSharedAddType.sCommandError)
        End Sub

        Public Sub cmd_Kick()
            InitializeSharedAddWindow(clsSharedAdd.eSharedAddType.sKick)
        End Sub

        Public Sub cmd_Kill()
            InitializeSharedAddWindow(clsSharedAdd.eSharedAddType.sKill)
        End Sub

        Public Sub cmd_Help()
            lStrings.ProcessReplaceCommand(lStatus.ActiveIndex, IrcCommandTypes.cHELP)
        End Sub

        Public Sub cmd_Die()
            lStrings.ProcessReplaceCommand(lStatus.ActiveIndex, IrcCommandTypes.cDIE)
        End Sub

        Public Sub cmd_Invite()
            Dim f As New FrmInvite
            f.Show()
        End Sub

        Public Sub cmd_ClearHistory_Click(ByVal _Recent1 As ToolStripMenuItem, ByVal _Recent2 As ToolStripMenuItem, ByVal _Recent3 As ToolStripMenuItem)
            Try
                'Dim i As Integer
                _Recent1.Text = "(Empty)"
                _Recent2.Text = "(Empty)"
                _Recent3.Text = "(Empty)"
                _Recent1.Enabled = False
                _Recent2.Enabled = False
                _Recent3.Enabled = False
                clearHistory()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Connect_Click()
            Try
                lStatus.ActiveStatusConnect()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Disconnect_Click()
            lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        End Sub

        Public Sub cmd_CloseStatus_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                lStatus.CloseWindow(i)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Exit_Click()
            Try
                End
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Channels_ButtonClick()
            lChannelFolder.Show(lStatus.ActiveIndex)
        End Sub

        Public Sub cmd_Connection_ButtonClick()
            lStatus.ToggleConnection(lStatus.ActiveIndex)
        End Sub

        Public Sub cmd_Customize_Click()
            frmCustomize.Show()
        End Sub

        Public Sub cmd_ListChannels_Click()
            Dim n As Integer = lStatus.ActiveIndex
            lStrings.ProcessReplaceCommand(n, IrcCommandTypes.cLIST, lStatus.ServerDescription(n))
        End Sub

        Public Sub cmd_LeftBar_Click(ByVal _LeftBarButton As ToolStripMenuItem, ByVal _LeftPanel As Panel, ByVal _Form As Form)
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
                Throw ex
            End Try
        End Sub

        Public Sub cmd_WindowBar_Click(ByVal _WindowBarButton As ToolStripMenuItem, ByVal _WindowsToolStrip As ToolStrip, ByVal _Form As Form)
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
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Cascade_Click(ByVal _Form As Form)
            _Form.LayoutMdi(MdiLayout.Cascade)
        End Sub
        Public Sub cmd_TileHorizontal_Click(ByVal _Form As Form)
            _Form.LayoutMdi(MdiLayout.TileHorizontal)
        End Sub
        Public Sub cmd_TileVertical_Click(ByVal _Form As Form)
            _Form.LayoutMdi(MdiLayout.TileVertical)
        End Sub

        Public Sub cmd_ArrangeIcons_Click(ByVal _Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.ArrangeIcons)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_ChannelFolder_Click()
            Try
                lChannelFolder.Show(lStatus.ActiveIndex)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Window_ButtonClick(ByVal _Form As Form)
            Try
                _Form.LayoutMdi(MdiLayout.Cascade)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_NewStatusWindow_Click()
            Try
                lStatus.Create(lSettings.lIRC, lSettings.lServers)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_View_ButtonClick()
            Try
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_DCCSend_Click()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCSend()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_DCCChat_Click()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCChat()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_DownloadManager_Click()
            Try
                frmDownloadManager.Show()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_DCC_ButtonClick()
            Try
                lProcessNumeric.lIrcNumericHelper.NewDCCSend()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_RecientServer1_Click(ByVal _Recent1 As String)
            Try
                If Len(_Recent1) <> 0 And _Recent1 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent1, 6667)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_RecientServer2_Click(ByVal _Recent2 As String)
            Try
                If Len(_Recent2) <> 0 And _Recent2 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent2, 6667)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_RecientServer3_Click(ByVal _Recent3 As String)
            Try
                If Len(_Recent3) <> 0 And _Recent3 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent3, 6667)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdLeftBar_Click(ByVal _ActiveForm As Form, ByVal _cmd_LeftBarButton As ToolStripMenuItem, ByVal _LeftPanel As Panel, ByVal _Form As Form)
            Try
                If _cmd_LeftBarButton.Checked = True Then
                    Animate.AnimateNow(_LeftPanel, Animate.Effect.Slide, 200, 1)
                    mdiMain.cmdLeftBar.Left = 168
                    _cmd_LeftBarButton.Checked = False
                Else
                    _cmd_LeftBarButton.Checked = True
                    mdiMain.cmdLeftBar.Left = 0
                    Animate.AnimateNow(_LeftPanel, Animate.Effect.Slide, 200, 1)
                End If
                _Form.Width = _Form.Width + 1
                _ActiveForm.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_ServerLinks_Click()
            Try
                lStatus.SendSocket(lStatus.ActiveIndex, "LINKS")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Whois_Click()
            Try
                Dim msg As String, i As Integer
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter whois nickname")
                If Len(msg) <> 0 Then lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cWHOIS, msg)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Whowas_Click()
            Try
                Dim msg As String, i As Integer
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter whowas nickname")
                If Len(msg) <> 0 Then lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cWHOWAS, msg)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Time_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cTIME)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub tmrStartup_Tick(ByVal startupTimer As Timer)
            Try
                startupTimer.Enabled = False
                If (lSettings.lIRC.iSettings.sCustomizeOnStartup = True) Then
                    frmCustomize.Show()
                End If
                If (lSettings.lIRC.iSettings.sAutoConnect = True) Then
                    lStatus.ToggleConnection(lStatus.ActiveIndex)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Admin_Click()
            Try
                lStrings.ProcessReplaceCommand(lStatus.ActiveIndex, IrcCommandTypes.cADMIN)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Stats_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cSTATS)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Away_Click()
            Try
                Dim i As Integer, msg As String
                i = lStatus.ActiveIndex()
                msg = InputBox("Enter away message:")
                lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cAWAY, msg)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_Back_Click()
            Try
                Dim i As Integer
                i = lStatus.ActiveIndex()
                lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cBACK)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub mnuExit_Click(ByVal _Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_CloseConnection_Click()
            Try
                lStatus.Quit(lStatus.ActiveIndex())
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdAccept_Click(ByVal _UserToolStripLabel As ToolStripLabel, ByVal _ToolStrip As ToolStrip, ByVal _DCCToolBarToolStrip As ToolStrip)
            Try
                Dim splt() As String, lForm As New frmDccGet
                splt = Split(_UserToolStripLabel.Tag.ToString, Environment.NewLine)
                _ToolStrip.Visible = False
                _DCCToolBarToolStrip.Visible = False
                _ToolStrip.Visible = True
                lForm.InitDCCGet(splt(0), splt(1), splt(2), splt(3), splt(4))
                lForm.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdAccept_Click()")
            End Try
        End Sub

        Public Sub cmdDeny_Click(ByVal _DCCToolBarToolStrip As ToolStrip)
            Try
                _DCCToolBarToolStrip.Visible = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub nicSystray_MouseDoubleClick(ByVal _Form As Form)
            Try
                _Form.Show()
                _Form.WindowState = FormWindowState.Normal
                _Form.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_SelectAServer_Click()
            Try
                frmCustomize.Show()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmd_ShowAbout_Click()
            Try
                frmAbout.Show()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdRedirectDeny_Click(ByVal _RedirectToolStrip As ToolStrip)
            Try
                _RedirectToolStrip.Visible = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cmdRedirectAccept_Click(ByVal _RedirectToolStrip As ToolStrip, ByVal _RedirectMessageLabel As ToolStripLabel)
            Try
                Dim splt() As String
                _RedirectToolStrip.Visible = False
                If (IsNumeric(_RedirectMessageLabel.Tag.ToString().Trim()) = True) Then
                    splt = _RedirectMessageLabel.Text.ToString().Split(Convert.ToChar("'"))
                    lChannels.Join(Convert.ToInt32(_RedirectMessageLabel.Tag.ToString().Trim()), splt(3))
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub tmrWaitForQuit_Tick()
            Try
                End
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub tmrHideRedirect_Tick(ByVal _RedirectToolStrip As ToolStrip, ByVal _HideRedirectTimer As Timer)
            Try
                _RedirectToolStrip.Visible = False
                _HideRedirectTimer.Enabled = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace