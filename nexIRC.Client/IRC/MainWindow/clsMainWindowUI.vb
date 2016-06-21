﻿'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Helpers
Imports System.Windows.Forms
Imports nexIRC.Enum

Namespace nexIRC.MainWindow
    Public Class clsMainWindowUI
        Public WithEvents lProcesses As New IrcProcess
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
        Public Event SetBackgroundColor()
        Public Event QueryBarPromptLabelVisible(text As String, tag As String)
        Public Event SetDimensions(left As Integer, top As Integer, width As Integer, height As Integer)
        Public Event EnableStartupSettingsTimer(tickInterval As Integer)
        Public Event FormTitle(title As String)
        Public Sub ShowQueryBar(ByVal _Text As String, ByVal _Function As eInfoBar, _QueryPromptLabel As ToolStripLabel, _ToolStrip As Windows.Forms.ToolStrip)
            If Len(_Text) <> 0 Then
                RaiseEvent QueryBarPromptLabelVisible(_Text, Trim(CType(_Function, Integer).ToString))
            End If
        End Sub
        Public Sub SetFlashesLeft(ByVal _Value As Integer, _FlashDCCToolBarTimer As Timer)
            lFlashesLeft = _Value
            _FlashDCCToolBarTimer.Enabled = True
        End Sub
        Public Function AddWindowBar(ByVal _Text As String, ByVal _ImageType As gWindowBarImageTypes, _ImageList As ImageList, _ToolStrip As ToolStrip) As ToolStripItem
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
        Public Sub RemoveWindowBar(ByVal _Text As String, _ToolStrip As ToolStrip)
            Dim i As Integer
            For i = 0 To _ToolStrip.Items.Count - 1
                If LCase(Trim(_ToolStrip.Items(i).Text)) = LCase(Trim(_Text)) Then
                    _ToolStrip.Items.Remove(_ToolStrip.Items(i))
                    Exit For
                End If
            Next i
        End Sub
        Public Sub ClearWindowBar(_ToolStrip As ToolStrip)
            _ToolStrip.Items.Clear()
        End Sub
        Public Sub PlayVideo(ByVal file As String)
            If (file.Length <> 0 And System.IO.File.Exists(file) = True) Then
                If lVideo.vVisible = False Then
                    lVideo.vVisible = True
                    lVideo.vWindow = Nothing
                    lVideo.vWindow = New frmVideoPlayer
                    lVideo.vWindow.Show()
                    lVideo.vWindow.OpenAndPlay(file)
                Else
                    lVideo.vWindow.OpenAndPlay(file)
                End If
            End If
        End Sub
        Public Sub FormClosed(_Form As Form, _NotifyIcon As NotifyIcon, _SideBarShown As Boolean)
            If _Form.WindowState = FormWindowState.Minimized Then _NotifyIcon.Visible = True
            NativeMethods.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Left", _Form.Left.ToString().Trim())
            NativeMethods.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Top", _Form.Top.ToString().Trim())
            NativeMethods.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Width", _Form.Width.ToString().Trim())
            NativeMethods.WriteINI(lSettings.lINI.iIRC, "mdiMain", "Height", _Form.Height.ToString().Trim())
            NativeMethods.WriteINI(lSettings.lINI.iIRC, "mdiMain", "SideBarShown", _SideBarShown.ToString())
        End Sub
        Public Sub FormClosing(e As System.Windows.Forms.FormClosingEventArgs, _Form As Form, _WaitForQuitTimer As Timer)
            lStatus.Closing = True
            If lStatus.QuitAll() = False Then
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
        Public Function OpenDialogFileNames(_DialogOpen As OpenFileDialog, ByVal _InitDir As String, ByVal _Title As String, ByVal _Filter As String) As String()
            With _DialogOpen
                .Filter = _Filter
                .InitialDirectory = _InitDir
                .Title = _Title
                .ShowDialog()
                .Multiselect = True
                Return .FileNames
            End With
        End Function
        Public Sub Form_Load(_Form As Form, _NotifyIcon As NotifyIcon, _TimerStartupSettings As Timer, _LeftBarButton As Button, _LeftNav As Panel, _ToolStrip As ToolStrip, _WindowsToolStrip As ToolStrip)
            Dim sideBarShown As Boolean
            _WindowsToolStrip.ForeColor = Color.White
            _NotifyIcon.Visible = True
            _NotifyIcon.Icon = _Form.Icon
            lLoadingForm = New frmLoading
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
            If lSettings.lServers.Index <> 0 Then lStatus.Create(lSettings.lIRC, lSettings.lServers)
            _Form.Left = NativeMethods.ReadINIInt(lSettings.lINI.iIRC, "mdiMain", "Left", _Form.Left)
            _Form.Top = NativeMethods.ReadINIInt(lSettings.lINI.iIRC, "mdiMain", "Top", _Form.Top)
            _Form.Width = NativeMethods.ReadINIInt(lSettings.lINI.iIRC, "mdiMain", "Width", _Form.Width)
            _Form.Height = NativeMethods.ReadINIInt(lSettings.lINI.iIRC, "mdiMain", "Height", _Form.Height)
            If lSettings.lIRC.iIdent.iSettings.iEnabled = True Then
                lIdent.Listen(113)
            End If
            SetLoadingFormProgress("Loading Complete", 100)
            lLoadingForm.Close()
            _TimerStartupSettings.Interval = 500
            _TimerStartupSettings.Enabled = True
            _Form.Text = "nexIRC v" & Application.ProductVersion
            sideBarShown = NativeMethods.ReadINIBool(lSettings.lINI.iIRC, "mdiMain", "SideBarShown", False)
            _LeftBarButton.Left = 0
            If (Not sideBarShown) Then
                _LeftNav.Visible = False
            Else
                _LeftNav.Visible = True
            End If
            Form_Resize(_Form, _LeftBarButton, _LeftNav, _ToolStrip, _WindowsToolStrip)
            RaiseEvent SetBackgroundColor()
        End Sub
        Public Sub Form_Resize(_Form As Form, _LeftButton As Button, _LeftNav As Panel, _ToolStrip As ToolStrip, _WindowsToolStrip As ToolStrip)
            'clsLockWindowUpdate.LockWindowUpdate(_Form.Handle)
            _LeftButton.Top = Convert.ToInt32(_Form.ClientSize.Height / 2)
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
        End Sub
        Public Sub SetWindowFocus(ByVal _Form As Form)
            If _Form.WindowState = FormWindowState.Minimized Then _Form.WindowState = FormWindowState.Normal
            If lSettings.lIRC.iSettings.sAutoMaximize = True And _Form.WindowState <> FormWindowState.Maximized Then _Form.WindowState = FormWindowState.Maximized
            _Form.BringToFront()
            _Form.Focus()
        End Sub
        Public Sub HideChildren(_Form As Form, ByVal _Except As Form, _ActiveForm As Form)
            Dim i As Integer
            If _ActiveForm.Name = _Except.Name Then Exit Sub
            For i = 0 To (_Form.MdiChildren.Length) - 1
                If _Form.MdiChildren(i).Visible = True Then _Form.MdiChildren(i).Visible = False
            Next i
            _Except.Visible = True
        End Sub
        Public Sub StartupSettingsTimer_Tick(_Timer As Timer)
            _Timer.Enabled = False
            If lSettings.lIRC.iSettings.sCustomizeOnStartup = True Then
                frmCustomize.Show()
                frmCustomize.Focus()
            End If
        End Sub
        Public Sub FlashDCCToolBarTimer_Tick(_Timer As Timer)
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
                If lStrings.DoLeft(e.ClickedItem.Text, 1) = "#" Then
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
        End Sub
        Public Sub Connections_DoubleClick(_SelectedNode As TreeNode)
            lStatus.DblClickConnections(_SelectedNode)
        End Sub

        Public Sub cmdAcceptQuery_Click(_QueryPromptLabel As ToolStripItem, _QueryPromptToolStrip As Windows.Forms.ToolStrip)
            Dim splt() As String, _NickName As String, _HostName As String
            If (_QueryPromptLabel.Tag IsNot Nothing) Then
                If Len(_QueryPromptLabel.Tag.ToString) = 1 Then
                    Select Case CType(CType(_QueryPromptLabel.Tag.ToString, Integer), eInfoBar)
                        Case eInfoBar.iNickServ_NickTaken
                            'frmNickServLogin.Show()
                            'frmNickServLogin.SetStatusIndex(lStatus.ActiveIndex)
                    End Select
                ElseIf InStr(_QueryPromptLabel.Tag.ToString, ":") <> 0 Then
                    splt = Split(_QueryPromptLabel.Tag.ToString, ":")
                    If lSettings.lQuerySettings.AutoShowWindow = True Then
                        _NickName = lStrings.ParseData(_QueryPromptLabel.Text, "'", "(")
                        _HostName = lStrings.ParseData(_QueryPromptLabel.Text, "(", ")")
                        lStatus.PrivateMessage_Add(Convert.ToInt32(Trim(splt(0))), _NickName, _HostName, splt(2), True)
                    End If
                    _QueryPromptToolStrip.Visible = False
                End If
            End If
        End Sub

        Public Sub cmdDeclineQuery_Click(_QueryPromptToolStrip As Windows.Forms.ToolStrip)
            _QueryPromptToolStrip.Visible = False
        End Sub
        Public Sub cmd_ClearHistory_Click(_Recent1 As ToolStripMenuItem, _Recent2 As ToolStripMenuItem, _Recent3 As ToolStripMenuItem)
            Dim i As Integer
            _Recent1.Text = "(Empty)"
            _Recent2.Text = "(Empty)"
            _Recent3.Text = "(Empty)"
            _Recent1.Enabled = False
            _Recent2.Enabled = False
            _Recent3.Enabled = False
            For i = 1 To lSettings.lRecientServers.sCount
                lSettings.lRecientServers.sItem(i) = ""
            Next i
        End Sub
        Public Sub cmd_Connect_Click()
            lStatus.ActiveStatusConnect()
        End Sub
        Public Sub cmd_Disconnect_Click()
            lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        End Sub
        Public Sub cmd_CloseStatus_Click()
            Dim i As Integer
            i = lStatus.ActiveIndex()
            lStatus.CloseWindow(i)
        End Sub
        Public Sub cmd_Exit_Click()
            End
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
            lStrings.ProcessReplaceCommand(n, CommandTypes.cLIST, lStatus.ServerDescription(n))
        End Sub
        Public Sub cmd_LeftBar_Click(_LeftBarButton As ToolStripMenuItem, _LeftPanel As Panel, _Form As Form)
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
        Public Sub cmd_WindowBar_Click(_WindowBarButton As ToolStripMenuItem, _WindowsToolStrip As ToolStrip, _Form As Form)
            If _WindowBarButton.Checked = True Then
                _WindowBarButton.Checked = False
                _WindowsToolStrip.Visible = False
            Else
                _WindowBarButton.Checked = True
                _WindowsToolStrip.Visible = True
            End If
            _Form.Width = _Form.Width + 1
        End Sub
        Public Sub cmd_Cascade_Click(_Form As Form)
            _Form.LayoutMdi(MdiLayout.Cascade)
        End Sub
        Public Sub cmd_TileHorizontal_Click(_Form As Form)
            _Form.LayoutMdi(MdiLayout.TileHorizontal)
        End Sub
        Public Sub cmd_TileVertical_Click(_Form As Form)
            _Form.LayoutMdi(MdiLayout.TileVertical)
        End Sub
        Public Sub cmd_ArrangeIcons_Click(_Form As Form)
            _Form.LayoutMdi(MdiLayout.ArrangeIcons)
        End Sub
        Public Sub cmd_ChannelFolder_Click()
            lChannelFolder.Show(lStatus.ActiveIndex)
        End Sub
        Public Sub cmd_Window_ButtonClick(_Form As Form)
            _Form.LayoutMdi(MdiLayout.Cascade)
        End Sub
        Public Sub cmd_NewStatusWindow_Click()
            lStatus.Create(lSettings.lIRC, lSettings.lServers)
        End Sub
        Public Sub cmd_View_ButtonClick()
        End Sub
        Public Sub cmd_DCCSend_Click()
            lProcessNumeric.lIrcNumericHelper.NewDCCSend()
        End Sub
        Public Sub cmd_DCCChat_Click()
            lProcessNumeric.lIrcNumericHelper.NewDCCChat()
        End Sub
        Public Sub cmd_DownloadManager_Click()
            frmDownloadManager.Show()
        End Sub
        Public Sub cmd_DCC_ButtonClick()
            lProcessNumeric.lIrcNumericHelper.NewDCCSend()
        End Sub
        Public Sub cmd_RecientServer1_Click(_Recent1 As String)
            If Len(_Recent1) <> 0 And _Recent1 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent1, 6667)
        End Sub
        Public Sub cmd_RecientServer2_Click(_Recent2 As String)
            If Len(_Recent2) <> 0 And _Recent2 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent2, 6667)
        End Sub
        Public Sub cmd_RecientServer3_Click(_Recent3 As String)
            If Len(_Recent3) <> 0 And _Recent3 <> "(Unknown)" Then lStatus.Connect_Specify(_Recent3, 6667)
        End Sub
        Public Sub cmdLeftBar_Click(_ActiveForm As Form, _cmd_LeftBarButton As ToolStripMenuItem, _LeftPanel As Panel, _Form As Form)
            If _cmd_LeftBarButton.Checked = True Then
                NativeMethods.Animate(_LeftPanel, [Enum].AnimateWindowFlags.AW_SLIDE, 200, 1)
                mdiMain.cmdLeftBar.Left = 168
                _cmd_LeftBarButton.Checked = False
            Else
                _cmd_LeftBarButton.Checked = True
                mdiMain.cmdLeftBar.Left = 0
                NativeMethods.Animate(_LeftPanel, [Enum].AnimateWindowFlags.AW_SLIDE, 200, 1)
            End If
            _Form.Width = _Form.Width + 1
            _ActiveForm.Focus()
        End Sub
        Public Sub cmd_ServerLinks_Click()
            lStatus.SendSocket(lStatus.ActiveIndex, "LINKS")
        End Sub
        Public Sub cmd_Whois_Click()
            Dim msg As String, i As Integer
            i = lStatus.ActiveIndex()
            msg = InputBox("Enter whois nickname")
            If Len(msg) <> 0 Then lStrings.ProcessReplaceCommand(i, CommandTypes.cWHOIS, msg)
        End Sub
        Public Sub cmd_Whowas_Click()
            Dim msg As String, i As Integer
            i = lStatus.ActiveIndex()
            msg = InputBox("Enter whowas nickname")
            If Len(msg) <> 0 Then lStrings.ProcessReplaceCommand(i, CommandTypes.cWHOWAS, msg)
        End Sub
        Public Sub cmd_Time_Click()
            Dim i As Integer
            i = lStatus.ActiveIndex()
            lStrings.ProcessReplaceCommand(i, CommandTypes.cTIME)
        End Sub
        Public Sub cmd_Stats_Click()
            Dim i As Integer
            i = lStatus.ActiveIndex()
            lStrings.ProcessReplaceCommand(i, CommandTypes.cSTATS)
        End Sub
        Public Sub cmd_Away_Click()
            Dim i As Integer, msg As String
            i = lStatus.ActiveIndex()
            msg = InputBox("Enter away message:")
            lStrings.ProcessReplaceCommand(i, CommandTypes.cAWAY, msg)
        End Sub
        Public Sub cmd_Back_Click()
            Dim i As Integer
            i = lStatus.ActiveIndex()
            lStrings.ProcessReplaceCommand(i, CommandTypes.cBACK)
        End Sub
        Public Sub cmd_PlayVideo_Click(_OpenFileDialog As OpenFileDialog)
            Dim msg() As String, i As Integer
            msg = OpenDialogFileNames(_OpenFileDialog, Application.StartupPath, "Play Video", "Video Files |*.avi,*.mov,*.wmv,*.mpg,*.mpeg")
            i = msg.Length - 1
            If i <> -1 Then PlayVideo(msg(i))
        End Sub
        Public Sub mnuExit_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub cmd_CloseConnection_Click()
            lStatus.Quit(lStatus.ActiveIndex())
        End Sub
        Public Sub cmdAccept_Click(_UserToolStripLabel As ToolStripLabel, _ToolStrip As ToolStrip, _DCCToolBarToolStrip As ToolStrip)
            Dim n = 0
            Dim splt() As String, lForm As New frmDCCGet
            splt = Split(_UserToolStripLabel.Tag.ToString, Environment.NewLine)
            If (Integer.TryParse(splt(2), n)) Then
                _ToolStrip.Visible = False
                _DCCToolBarToolStrip.Visible = False
                _ToolStrip.Visible = True
                lForm.InitDCCGet(splt(0), splt(1), n, splt(3), splt(4))
                lForm.Show()
            End If
        End Sub
        Public Sub cmdDeny_Click(_DCCToolBarToolStrip As ToolStrip)
            _DCCToolBarToolStrip.Visible = False
        End Sub
        Public Sub nicSystray_MouseDoubleClick(_Form As Form)
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
        Public Sub cmdRedirectDeny_Click(_RedirectToolStrip As ToolStrip)
            _RedirectToolStrip.Visible = False
        End Sub
        Public Sub cmdRedirectAccept_Click(_RedirectToolStrip As ToolStrip, _RedirectMessageLabel As ToolStripLabel)
            Dim splt() As String
            _RedirectToolStrip.Visible = False
            If (IsNumeric(_RedirectMessageLabel.Tag.ToString().Trim()) = True) Then
                splt = _RedirectMessageLabel.Text.ToString().Split(Convert.ToChar("'"))
                lChannels.Join(Convert.ToInt32(_RedirectMessageLabel.Tag.ToString().Trim()), splt(3))
            End If
        End Sub
        Public Sub tmrWaitForQuit_Tick()
            End
        End Sub
        Public Sub tmrHideRedirect_Tick(_RedirectToolStrip As ToolStrip, _HideRedirectTimer As Timer)
            _RedirectToolStrip.Visible = False
            _HideRedirectTimer.Enabled = False
        End Sub
    End Class
End Namespace