Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.UI
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.Client.Classes
Imports nexIRC.Business.Repositories
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows

Namespace nexIRC.Client.IRC.MainWindow
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
            If Len(_Text) <> 0 Then
                RaiseEvent QueryBarPromptLabelVisible(_Text, Trim(CType(_Function, Integer).ToString))
            End If
        End Sub

        Public Sub SetFlashesLeft(ByVal _Value As Integer, ByVal _FlashDCCToolBarTimer As Timer)
            lFlashesLeft = _Value
            _FlashDCCToolBarTimer.Enabled = True
        End Sub

        Public Function AddWindowBar(ByVal _Text As String, ByVal _ImageType As gWindowBarImageTypes, ByVal _ImageList As ImageList, ByVal _ToolStrip As ToolStrip) As ToolStripItem
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
        End Function

        Public Sub RemoveWindowBar(ByVal _Text As String, ByVal _ToolStrip As ToolStrip)
            Dim i As Integer
            For i = 0 To _ToolStrip.Items.Count - 1
                If LCase(Trim(_ToolStrip.Items(i).Text)) = LCase(Trim(_Text)) Then
                    _ToolStrip.Items.Remove(_ToolStrip.Items(i))
                    Exit For
                End If
            Next i
        End Sub

        Public Sub ClearWindowBar(ByVal _ToolStrip As ToolStrip)
            _ToolStrip.Items.Clear()
        End Sub

        Public Sub FormClosed(ByVal _Form As Form, ByVal _NotifyIcon As NotifyIcon, ByVal _SideBarShown As Boolean)
            If _Form.WindowState = FormWindowState.Minimized Then _NotifyIcon.Visible = True
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Left", _Form.Left.ToString().Trim())
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Top", _Form.Top.ToString().Trim())
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Width", _Form.Width.ToString().Trim())
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Height", _Form.Height.ToString().Trim())
            IniFileHelper.WriteINI(Modules.lSettings.lINI.iIRC, "mdiMain", "SideBarShown", _SideBarShown.ToString())
        End Sub

        Public Sub FormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs, ByVal _Form As Form, ByVal _WaitForQuitTimer As Timer)
            Modules.lStatus.Closing = True
            If Modules.lStatus.QuitAll() = False Then
                e.Cancel = True
                _Form.Visible = False
                _WaitForQuitTimer.Enabled = True
            End If
        End Sub

        Public Sub SetLoadingFormProgress(ByVal _Data As String, ByVal _Value As Integer)
            lLoadingForm.SetProgress(_Data, _Value)
            lLoadingForm.Refresh()
            Application.DoEvents()
        End Sub

        Public Function OpenDialogFileNames(ByVal _DialogOpen As OpenFileDialog, ByVal _InitDir As String, ByVal _Title As String, ByVal _Filter As String) As String()
            With _DialogOpen
                .Filter = _Filter
                .InitialDirectory = _InitDir
                .Title = _Title
                .ShowDialog()
                .Multiselect = True
                Return .FileNames
            End With
        End Function

        Public Sub Form_Load(ByVal _Form As Form, ByVal _NotifyIcon As NotifyIcon, ByVal _LeftBarButton As Button, ByVal _LeftNav As Panel, ByVal _ToolStrip As ToolStrip, ByVal _WindowsToolStrip As ToolStrip, startupTimer As Timer, windowsToolstripImageList As ImageList)
            Dim sideBarShown As Boolean
            _WindowsToolStrip.ForeColor = Color.White
            _NotifyIcon.Visible = True
            _NotifyIcon.Icon = _Form.Icon
            lLoadingForm = New FrmLoading
            lLoadingForm.Show()
            lLoadingForm.Focus()
            Application.DoEvents()
            SetLoadingFormProgress("Initializing Status Windows", 2)
            Modules.lSettings.SetArraySizes()
            Modules.lStatus = New Status.Status(Modules.lSettings.lArraySizes.aStatusWindows)
            SetLoadingFormProgress("Initializing Processes", 5)
            lProcesses.Initialize()
            SetLoadingFormProgress("Loading Settings", 7)
            Modules.lSettings.LoadSettings()
            lLoadingForm.Focus()
            If Modules.lSettings.lServers.sIndex <> 0 Then Modules.lStatus.Create(Modules.IrcSettings, Modules.lSettings.lServers)
            _Form.Left = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Left", Convert.ToString(_Form.Left))))
            _Form.Top = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Top", Convert.ToString(_Form.Top))))
            _Form.Width = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Width", Convert.ToString(_Form.Width))))
            _Form.Height = Convert.ToInt32(Trim(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "mdiMain", "Height", Convert.ToString(_Form.Height))))
            If Modules.lSettings.lIRC.iIdent.iSettings.iEnabled = True Then
                Modules.lIdent.Listen(113)
            End If
            SetLoadingFormProgress("Loading Complete", 100)
            lLoadingForm.Close()
            _Form.Text = "nexIRC v" & Application.ProductVersion
            sideBarShown = Convert.ToBoolean(IniFileHelper.ReadINI(Modules.lSettings.lINI.iIRC, "mdiMain", "SideBarShown", "False"))
            _LeftBarButton.Left = 0
            If (Not sideBarShown) Then
                _LeftNav.Visible = False
            Else
                _LeftNav.Visible = True
            End If
            Form_Resize(_Form, _LeftBarButton, _LeftNav, _ToolStrip, _WindowsToolStrip)
            RaiseEvent SetBackgroundColor()
            _Form.Visible = True
            startupTimer.Enabled = True
            _WindowsToolStrip.ImageList = windowsToolstripImageList
        End Sub

        Public Sub Form_Resize(ByVal _Form As Form, ByVal _LeftButton As Button, ByVal _LeftNav As Panel, ByVal _ToolStrip As ToolStrip, ByVal _WindowsToolStrip As ToolStrip)
            _LeftButton.Top = Convert.ToInt32(_Form.ClientSize.Height / 2)
            If _LeftNav.Visible = True Then
                _LeftButton.Left = _LeftNav.ClientSize.Width
            Else
                _LeftButton.Left = 0
            End If
        End Sub

        Public Sub SetWindowFocus(ByVal _Form As Form)
            If _Form.WindowState = FormWindowState.Minimized Then _Form.WindowState = FormWindowState.Normal
            If Modules.lSettings.lIRC.iSettings.sAutoMaximize = True And _Form.WindowState <> FormWindowState.Maximized Then _Form.WindowState = FormWindowState.Maximized
            _Form.BringToFront()
            _Form.Focus()
        End Sub

        Public Sub HideChildren(ByVal _Form As Form, ByVal _Except As Form, ByVal _ActiveForm As Form)
            Dim i As Integer
            If _ActiveForm.Name = _Except.Name Then Exit Sub
            For i = 0 To (_Form.MdiChildren.Length) - 1
                If _Form.MdiChildren(i).Visible = True Then _Form.MdiChildren(i).Visible = False
            Next i
            _Except.Visible = True
        End Sub

        Public Sub StartupSettingsTimer_Tick(ByVal _Timer As Timer)
            _Timer.Enabled = False
            If Modules.lSettings.lIRC.iSettings.sCustomizeOnStartup = True Then
                frmCustomize.Show()
                frmCustomize.Focus()
            End If
        End Sub

        Public Sub FlashDCCToolBarTimer_Tick(ByVal _Timer As Timer)
            If lFlashesLeft = 0 Then
                _Timer.Enabled = False
                Exit Sub
            End If
            lFlashesLeft = lFlashesLeft - 1
        End Sub

        Public Sub WindowsToolStrip_ItemClicked(ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
            Dim channelIndex As Integer = 0, meIndex As Integer
            If (IsNumeric(e.ClickedItem.Tag.ToString()) = True) Then
                meIndex = CType(e.ClickedItem.Tag.ToString(), Integer)
                If TextHelper.DoLeft(e.ClickedItem.Text, 1) = "#" Then
                    channelIndex = Modules.lChannels.Find(meIndex, e.ClickedItem.Text.ToString)
                    If (Modules.lChannels.Visible(channelIndex)) Then
                        Modules.lChannels.Focus(channelIndex)
                    Else
                        Modules.lChannels.Visible(channelIndex) = True
                    End If
                ElseIf InStr(e.ClickedItem.Text, "(") <> 0 And InStr(e.ClickedItem.Text, ")") <> 0 Then
                    If (Modules.lStatus.Window(meIndex) IsNot Nothing) Then
                        If (Modules.lStatus.Visible(meIndex)) Then
                            Modules.lStatus.Focus(meIndex)
                        Else
                            Modules.lStatus.Visible(meIndex) = True
                        End If
                    End If
                Else
                    If (Modules.lStatus.PrivateMessage_Visible(meIndex, e.ClickedItem.Text) = True) Then
                        Modules.lStatus.PrivateMessage_Focus(meIndex, Modules.lStatus.PrivateMessage_Find(meIndex, e.ClickedItem.Text))
                        'lStatus.GetObject(meIndex).sPrivateMessages.pPrivateMessage(Modules.lStatus.PrivateMessage_Find(meIndex, e.ClickedItem.Text)).pWindow.txtOutgoing.Focus()
                    Else
                        Modules.lStatus.PrivateMessage_Visible(meIndex, e.ClickedItem.Text) = True
                    End If
                End If
            End If
        End Sub

        Public Sub Connections_DoubleClick(ByVal _SelectedNode As TreeNode)
            Modules.lStatus.DblClickConnections(_SelectedNode)
        End Sub

        Public Sub cmdAcceptQuery_Click(ByVal _QueryPromptLabel As ToolStripItem, ByVal _QueryPromptToolStrip As ToolStrip)
            Dim splt() As String, _NickName As String, _HostName As String
            If Len(_QueryPromptLabel.Tag.ToString) = 1 Then
                Select Case CType(CType(_QueryPromptLabel.Tag.ToString, Integer), eInfoBar)
                    Case eInfoBar.iNickServ_NickTaken
                        frmNickServLogin.Show()
                        frmNickServLogin.SetStatusIndex(Modules.lStatus.ActiveIndex)
                End Select
            ElseIf InStr(_QueryPromptLabel.Tag.ToString, ":") <> 0 Then
                splt = Split(_QueryPromptLabel.Tag.ToString, ":")
                If (New QuerySettings(Application.StartupPath).Get().AutoShowWindow()) Then
                    _NickName = TextHelper.ParseData(_QueryPromptLabel.Text, "'", "(")
                    _HostName = TextHelper.ParseData(_QueryPromptLabel.Text, "(", ")")
                    Modules.lStatus.PrivateMessage_Add(Convert.ToInt32(Trim(splt(0))), _NickName, _HostName, splt(2), True)
                End If
                _QueryPromptToolStrip.Visible = False
            End If
        End Sub

        Public Sub cmdDeclineQuery_Click(ByVal _QueryPromptToolStrip As ToolStrip)
            _QueryPromptToolStrip.Visible = False
        End Sub

        Private Sub clearHistory()
            For i = 1 To Modules.lSettings.lRecientServers.sCount
                Modules.lSettings.lRecientServers.sItem(i) = ""
            Next i
        End Sub

        Public Sub cmd_ClearHistory_Click(ByVal _Recent1 As RadMenuItem, ByVal _Recent2 As RadMenuItem, ByVal _Recent3 As RadMenuItem)
            _Recent1.Text = "(Empty)"
            _Recent2.Text = "(Empty)"
            _Recent3.Text = "(Empty)"
            _Recent1.Enabled = False
            _Recent2.Enabled = False
            _Recent3.Enabled = False
            clearHistory()
        End Sub

        Private Sub InitializeSharedAddWindow(ByVal type As clsSharedAdd.eSharedAddType)
            Dim form As frmSharedAdd
            form = New frmSharedAdd()
            form.lSharedAddUI.SharedAddType = type
            form.lSharedAddUI.StatusIndex = Modules.lStatus.ActiveIndex
            form.Show()
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
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cHELP)
        End Sub

        Public Sub cmd_Die()
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cDIE)
        End Sub

        Public Sub cmd_Invite()
            Dim f As New FrmInvite
            f.Show()
        End Sub

        Public Sub cmd_ClearHistory_Click(ByVal _Recent1 As ToolStripMenuItem, ByVal _Recent2 As ToolStripMenuItem, ByVal _Recent3 As ToolStripMenuItem)
            _Recent1.Text = "(Empty)"
            _Recent2.Text = "(Empty)"
            _Recent3.Text = "(Empty)"
            _Recent1.Enabled = False
            _Recent2.Enabled = False
            _Recent3.Enabled = False
            clearHistory()
        End Sub

        Public Sub cmd_Connect_Click()
            Modules.lStatus.ActiveStatusConnect()
        End Sub

        Public Sub cmd_Disconnect_Click()
            Modules.lStatus.CloseStatusConnection(Modules.lStatus.ActiveIndex, True)
        End Sub

        Public Sub cmd_CloseStatus_Click()
            Dim i As Integer
            i = Modules.lStatus.ActiveIndex()
            Modules.lStatus.CloseWindow(i)
        End Sub

        Public Sub cmd_Exit_Click()
            End
        End Sub

        Public Sub cmd_Channels_ButtonClick()
            Modules.lChannelFolder.Show(Modules.lStatus.ActiveIndex)
        End Sub

        Public Sub cmd_Connection_ButtonClick()
            Modules.lStatus.ToggleConnection(Modules.lStatus.ActiveIndex)
        End Sub

        Public Sub cmd_Customize_Click()
            frmCustomize.Show()
        End Sub

        Public Sub cmd_ListChannels_Click()
            Dim n As Integer = Modules.lStatus.ActiveIndex
            Modules.lStrings.ProcessReplaceCommand(n, IrcCommandTypes.cLIST, Modules.lStatus.ServerDescription(n))
        End Sub

        Public Sub cmd_LeftBar_Click(ByVal _LeftBarButton As ToolStripMenuItem, ByVal _LeftPanel As Panel, ByVal _Form As Form)
            If _LeftBarButton.Checked = True Then
                _LeftBarButton.Checked = False
                _LeftPanel.Visible = False
                _Form.Width = _Form.Width + 1
            Else
                _LeftBarButton.Checked = True
                _LeftPanel.Visible = True
                _Form.Width = _Form.Width + 1
            End If
        End Sub

        Public Sub cmd_WindowBar_Click(ByVal _WindowBarButton As ToolStripMenuItem, ByVal _WindowsToolStrip As ToolStrip, ByVal _Form As Form)
            If _WindowBarButton.Checked = True Then
                _WindowBarButton.Checked = False
                _WindowsToolStrip.Visible = False
            Else
                _WindowBarButton.Checked = True
                _WindowsToolStrip.Visible = True
            End If
            _Form.Width = _Form.Width + 1
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
            _Form.LayoutMdi(MdiLayout.ArrangeIcons)
        End Sub

        Public Sub cmd_ChannelFolder_Click()
            Modules.lChannelFolder.Show(Modules.lStatus.ActiveIndex)
        End Sub

        Public Sub cmd_Window_ButtonClick(ByVal _Form As Form)
            _Form.LayoutMdi(MdiLayout.Cascade)
        End Sub

        Public Sub cmd_NewStatusWindow_Click()
            Modules.lStatus.Create(Modules.IrcSettings, Modules.lSettings.lServers)
        End Sub

        Public Sub cmd_DCCSend_Click()
            Modules.lProcessNumeric.lIrcNumericHelper.NewDCCSend()
        End Sub

        Public Sub cmd_DCCChat_Click()
            Modules.lProcessNumeric.lIrcNumericHelper.NewDCCChat()
        End Sub

        Public Sub cmd_DownloadManager_Click()
            frmDownloadManager.Show()
        End Sub

        Public Sub cmd_DCC_ButtonClick()
            Modules.lProcessNumeric.lIrcNumericHelper.NewDCCSend()
        End Sub

        Public Sub cmd_RecientServer1_Click(ByVal _Recent1 As String)
            If Len(_Recent1) <> 0 And _Recent1 <> "(Unknown)" Then Modules.lStatus.Connect_Specify(_Recent1, 6667)
        End Sub

        Public Sub cmd_RecientServer2_Click(ByVal _Recent2 As String)
            If Len(_Recent2) <> 0 And _Recent2 <> "(Unknown)" Then Modules.lStatus.Connect_Specify(_Recent2, 6667)
        End Sub

        Public Sub cmd_RecientServer3_Click(ByVal _Recent3 As String)
            If Len(_Recent3) <> 0 And _Recent3 <> "(Unknown)" Then Modules.lStatus.Connect_Specify(_Recent3, 6667)
        End Sub

        Public Sub cmdLeftBar_Click(ByVal _ActiveForm As Form, ByVal _cmd_LeftBarButton As ToolStripMenuItem, ByVal _LeftPanel As Panel, ByVal _Form As Form)
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
        End Sub

        Public Sub cmd_ServerLinks_Click()
            Modules.lStatus.SendSocket(Modules.lStatus.ActiveIndex, "LINKS")
        End Sub

        Public Sub cmd_Whois_Click()
            Dim msg As String, i As Integer
            i = Modules.lStatus.ActiveIndex()
            msg = InputBox("Enter whois nickname")
            If Len(msg) <> 0 Then Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cWHOIS, msg)
        End Sub

        Public Sub cmd_Whowas_Click()
            Dim msg As String, i As Integer
            i = Modules.lStatus.ActiveIndex()
            msg = InputBox("Enter whowas nickname")
            If Len(msg) <> 0 Then Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cWHOWAS, msg)
        End Sub

        Public Sub cmd_Time_Click()
            Dim i As Integer
            i = Modules.lStatus.ActiveIndex()
            Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cTIME)
        End Sub

        Public Sub tmrStartup_Tick(ByVal startupTimer As Timer)
            startupTimer.Enabled = False
            If (Modules.lSettings.lIRC.iSettings.sCustomizeOnStartup = True) Then
                frmCustomize.Show()
            End If
            If (Modules.lSettings.lIRC.iSettings.sAutoConnect = True) Then
                Modules.lStatus.ToggleConnection(Modules.lStatus.ActiveIndex)
            End If
        End Sub

        Public Sub cmd_Admin_Click()
            Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cADMIN)
        End Sub

        Public Sub tmrFirstFocus_Tick(firstFocusTimer As Timer)
            firstFocusTimer.Enabled = False
            Modules.lStatus.Window(0).Focus()
            If Modules.lSettings.lIRC.iSettings.sCustomizeOnStartup = True Then
                Dim f As New frmCustomize()
                f.Show()
                f.Focus()
            End If
        End Sub

        Public Sub cmd_Stats_Click()
            Dim i As Integer
            i = Modules.lStatus.ActiveIndex()
            Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cSTATS)
        End Sub

        Public Sub cmd_Away_Click()
            Dim i As Integer, msg As String
            i = Modules.lStatus.ActiveIndex()
            msg = InputBox("Enter away message:")
            Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cAWAY, msg)
        End Sub

        Public Sub cmd_Back_Click()
            Dim i As Integer
            i = Modules.lStatus.ActiveIndex()
            Modules.lStrings.ProcessReplaceCommand(i, IrcCommandTypes.cBACK)
        End Sub

        Public Sub mnuExit_Click(ByVal _Form As Form)
            _Form.Close()
        End Sub

        Public Sub cmd_CloseConnection_Click()
            Modules.lStatus.Quit(Modules.lStatus.ActiveIndex())
        End Sub

        Public Sub cmdAccept_Click(ByVal _UserToolStripLabel As ToolStripLabel, ByVal _ToolStrip As ToolStrip, ByVal _DCCToolBarToolStrip As ToolStrip)
            Dim splt() As String, lForm As New frmDccGet
            splt = Split(_UserToolStripLabel.Tag.ToString, Environment.NewLine)
            _ToolStrip.Visible = False
            _DCCToolBarToolStrip.Visible = False
            _ToolStrip.Visible = True
            lForm.InitDCCGet(splt(0), splt(1), splt(2), splt(3), splt(4))
            lForm.Show()
        End Sub

        Public Sub cmdDeny_Click(ByVal _DCCToolBarToolStrip As ToolStrip)
            _DCCToolBarToolStrip.Visible = False
        End Sub

        Public Sub nicSystray_MouseDoubleClick(ByVal _Form As Form)
            _Form.Show()
            _Form.WindowState = FormWindowState.Normal
            _Form.Focus()
        End Sub

        Public Sub cmd_SelectAServer_Click()
            frmCustomize.Show()
        End Sub

        Public Sub cmd_ShowAbout_Click()
            frmAbout.Show()
        End Sub

        Public Sub cmdRedirectDeny_Click(ByVal _RedirectToolStrip As ToolStrip)
            _RedirectToolStrip.Visible = False
        End Sub

        Public Sub cmdRedirectAccept_Click(ByVal _RedirectToolStrip As ToolStrip, ByVal _RedirectMessageLabel As ToolStripLabel)
            Dim splt() As String
            _RedirectToolStrip.Visible = False
            If (IsNumeric(_RedirectMessageLabel.Tag.ToString().Trim()) = True) Then
                splt = _RedirectMessageLabel.Text.ToString().Split(Convert.ToChar("'"))
                Modules.lChannels.Join(Convert.ToInt32(_RedirectMessageLabel.Tag.ToString().Trim()), splt(3))
            End If
        End Sub

        Public Sub tmrWaitForQuit_Tick()
            End
        End Sub

        Public Sub tmrHideRedirect_Tick(ByVal _RedirectToolStrip As ToolStrip, ByVal _HideRedirectTimer As Timer)
            _RedirectToolStrip.Visible = False
            _HideRedirectTimer.Enabled = False
        End Sub
    End Class
End Namespace