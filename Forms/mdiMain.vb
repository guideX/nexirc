'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.nexIRC.MainWindow
Imports nexIRC.nexIRC.MainWindow.clsMainWindowUI
Public Class mdiMain
    Private lMainWindowUI As New clsMainWindowUI
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub ShowQueryBar(_Text As String, _Function As eInfoBar)
        lMainWindowUI.ShowQueryBar(_Text, _Function, lblQueryPrompt, tspQueryPrompt)
    End Sub
    Public Sub SetFlashesLeft(_Value As Integer)
        lMainWindowUI.SetFlashesLeft(_Value, tmrFlashDCCToolBar)
    End Sub
    Public Function AddWindowBar(_Text As String, _ImageType As gWindowBarImageTypes) As ToolStripItem
        Return lMainWindowUI.AddWindowBar(_Text, _ImageType, ImageList1, tspWindows)
    End Function
    Public Sub RemoveWindowBar(_Text As String)
        lMainWindowUI.RemoveWindowBar(_Text, tspWindows)
    End Sub
    Public Sub ClearWindowBar()
        lMainWindowUI.ClearWindowBar(tspWindows)
    End Sub
    Public Sub CloseBrowser()
        lMainWindowUI.CloseBrowser()
    End Sub
    Public Sub TriggerBrowserResize()
        lMainWindowUI.TriggerBrowserResize()
    End Sub
    Public Sub PlayVideo(_File As String)
        lMainWindowUI.PlayVideo(_File)
    End Sub
    Public Sub BrowseURL(_Url As String, Optional _Startup As Boolean = False)
        lMainWindowUI.BrowseURL(_Url, _Startup, Me)
    End Sub
    Private Sub mdiMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lMainWindowUI.FormClosed(Me, nicSystray)
    End Sub
    Private Sub mdiMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lMainWindowUI.FormClosing(e, Me, tmrWaitForQuit)
    End Sub
    Public Sub SetLoadingFormProgress(ByVal _Data As String, ByVal _Value As Integer)
        lMainWindowUI.SetLoadingFormProgress(_Data, _Value)
    End Sub
    Public Function OpenDialogFileNames(_InitDir As String, _Title As String, _File As String) As String()
        Return lMainWindowUI.OpenDialogFileNames(fdgOpen, _InitDir, _Title, _File)
    End Function
    Public Sub ResizeBrowser()
        lMainWindowUI.ResizeBrowser(Me, pnlLeftNav, tspMain, tspWindows)
    End Sub
    Public Sub SetWindowFocus(ByVal _Form As Form)
        lMainWindowUI.SetWindowFocus(Me)
    End Sub
    Public Sub HideChildren(_Except As Form, _ActiveWindow As Form)
        lMainWindowUI.HideChildren(Me, _Except, _ActiveWindow)
    End Sub
    Private Sub tmrFlashDCCToolBar_Tick(sender As System.Object, e As System.EventArgs) Handles tmrFlashDCCToolBar.Tick
        lMainWindowUI.FlashDCCToolBarTimer_Tick(tmrFlashDCCToolBar)
    End Sub
    Private Sub tmrStartupSettings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStartupSettings.Tick
        lMainWindowUI.StartupSettingsTimer_Tick(tmrStartupSettings)
    End Sub
    Private Sub mdiMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lMainWindowUI.Form_Load(Me, nicSystray, tmrStartupSettings, cmdLeftBar, pnlLeftNav, tspMain, tspWindows)
    End Sub
    Private Sub mdiMain_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        lMainWindowUI.Form_Resize(Me, cmdLeftBar, pnlLeftNav, tspMain, tspWindows)
    End Sub
    Private Sub tspWindows_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tspWindows.ItemClicked
        lMainWindowUI.WindowsToolStrip_ItemClicked(e)
    End Sub
    Private Sub tvwConnections_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwConnections.DoubleClick
        lMainWindowUI.Connections_DoubleClick(tvwConnections.SelectedNode)
    End Sub
    Private Sub cmdAcceptQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lMainWindowUI.cmdAcceptQuery_Click(lblQueryPrompt, tspQueryPrompt)
    End Sub
    Private Sub cmdDeclineQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeclineQuery.Click
        lMainWindowUI.cmdDeclineQuery_Click(tspQueryPrompt)
    End Sub
    Private Sub cmd_ClearHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ClearHistory.Click
        lMainWindowUI.cmd_ClearHistory_Click(cmd_RecientServer1, cmd_RecientServer2, cmd_RecientServer3)
    End Sub
    Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click
        lMainWindowUI.cmd_Connect_Click()
    End Sub
    Private Sub cmd_Disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Disconnect.Click
        lMainWindowUI.cmd_Disconnect_Click()
    End Sub
    Private Sub cmd_CloseStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_CloseStatus.Click
        lMainWindowUI.cmd_CloseStatus_Click()
    End Sub
    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        lMainWindowUI.cmd_Exit_Click()
    End Sub
    Private Sub cmd_Channels_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Channels.ButtonClick
        lMainWindowUI.cmd_Channels_ButtonClick()
    End Sub
    Private Sub cmd_Connection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connection.ButtonClick
        lMainWindowUI.cmd_Connection_ButtonClick()
    End Sub
    Private Sub cmd_Customize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Customize.Click
        lMainWindowUI.cmd_Customize_Click()
    End Sub
    Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ListChannels.Click
        lMainWindowUI.cmd_ListChannels_Click()
    End Sub
    Private Sub cmd_LeftBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_LeftBar.Click
        lMainWindowUI.cmd_LeftBar_Click(cmd_LeftBar, pnlLeftNav, Me)
    End Sub
    Private Sub cmd_WindowBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WindowBar.Click
        lMainWindowUI.cmd_WindowBar_Click(cmd_WindowBar, tspWindows, Me)
    End Sub
    Private Sub cmd_Cascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Cascade.Click
        lMainWindowUI.cmd_Cascade_Click(Me)
    End Sub
    Private Sub cmd_TileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileHorizontal.Click
        lMainWindowUI.cmd_TileHorizontal_Click(Me)
    End Sub
    Private Sub cmd_TileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileVertical.Click
        lMainWindowUI.cmd_TileVertical_Click(Me)
    End Sub
    Private Sub cmd_ArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ArrangeIcons.Click
        lMainWindowUI.cmd_ArrangeIcons_Click(Me)
    End Sub
    Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click
        lMainWindowUI.cmd_ChannelFolder_Click()
    End Sub
    Private Sub cmd_Window_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Window.ButtonClick
        lMainWindowUI.cmd_Window_ButtonClick(Me)
    End Sub
    Private Sub cmd_NewStatusWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_NewStatusWindow.Click
        lMainWindowUI.cmd_NewStatusWindow_Click()
    End Sub
    Private Sub cmd_View_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.ButtonClick
        lMainWindowUI.cmd_View_ButtonClick()
    End Sub
    Private Sub cmd_DCCSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCSend.Click
        lMainWindowUI.cmd_DCCSend_Click()
    End Sub
    Private Sub cmd_DCCChat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCChat.Click
        lMainWindowUI.cmd_DCCChat_Click()
    End Sub
    Private Sub cmd_DownloadManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DownloadManager.Click
        lMainWindowUI.cmd_DownloadManager_Click()
    End Sub
    Private Sub cmd_DCC_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCC.ButtonClick
        lMainWindowUI.cmd_DCC_ButtonClick()
    End Sub
    Private Sub cmd_RecientServer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer1.Click
        lMainWindowUI.cmd_RecientServer1_Click(cmd_RecientServer1.Text)
    End Sub
    Private Sub cmd_RecientServer2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer2.Click
        lMainWindowUI.cmd_RecientServer2_Click(cmd_RecientServer2.Text)
    End Sub
    Private Sub cmd_RecientServer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer3.Click
        lMainWindowUI.cmd_RecientServer3_Click(cmd_RecientServer3.Text)
    End Sub
    Private Sub cmdLeftBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeftBar.Click
        lMainWindowUI.cmdLeftBar_Click(mdiMain.ActiveForm, cmd_LeftBar, pnlLeftNav, Me)
    End Sub
    Private Sub cmd_ServerLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ServerLinks.Click
        lMainWindowUI.cmd_ServerLinks_Click()
    End Sub
    Private Sub cmd_Whois_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whois.Click
        lMainWindowUI.cmd_Whois_Click()
    End Sub
    Private Sub cmd_Whowas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whowas.Click
        lMainWindowUI.cmd_Whowas_Click()
    End Sub
    Private Sub cmd_Time_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Time.Click
        lMainWindowUI.cmd_Time_Click()
    End Sub
    Private Sub cmd_Stats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Stats.Click
        lMainWindowUI.cmd_Stats_Click()
    End Sub
    Private Sub cmd_Away_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Away.Click
        lMainWindowUI.cmd_Away_Click()
    End Sub
    Private Sub cmd_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Back.Click
        lMainWindowUI.cmd_Back_Click()
    End Sub
    Private Sub cmd_PlayVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_PlayVideo.Click
        lMainWindowUI.cmd_PlayVideo_Click(fdgOpen)
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lMainWindowUI.mnuExit_Click(Me)
    End Sub
    Private Sub cmd_CloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_CloseConnection.Click
        lMainWindowUI.cmd_CloseConnection_Click()
    End Sub
    Private Sub cmdAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccept.Click
        lMainWindowUI.cmdAccept_Click(lblUser, tspMain, tspDCCToolBar)
    End Sub
    Private Sub cmdDeny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeny.Click
        lMainWindowUI.cmdDeny_Click(tspDCCToolBar)
    End Sub
    Private Sub nicSystray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nicSystray.MouseDoubleClick
        lMainWindowUI.nicSystray_MouseDoubleClick(Me)
    End Sub
    Private Sub cmd_SelectAServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_SelectAServer.Click
        lMainWindowUI.cmd_SelectAServer_Click()
    End Sub
    Private Sub cmd_ShowAbout_Click(sender As System.Object, e As System.EventArgs) Handles cmd_ShowAbout.Click
        lMainWindowUI.cmd_ShowAbout_Click()
    End Sub
    Private Sub cmdRedirectDeny_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedirectDeny.Click
        lMainWindowUI.cmdRedirectDeny_Click(tspRedirect)
    End Sub
    Public Sub cmdRedirectAccept_Click()
        lMainWindowUI.cmdRedirectAccept_Click(tspRedirect, lblRedirectMessage)
    End Sub
    Private Sub tmrWaitForQuit_Tick(sender As System.Object, e As System.EventArgs) Handles tmrWaitForQuit.Tick
        lMainWindowUI.tmrWaitForQuit_Tick()
    End Sub
    Private Sub tmrHideRedirect_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHideRedirect.Tick
        lMainWindowUI.tmrHideRedirect_Tick(tspRedirect, tmrHideRedirect)
    End Sub
End Class