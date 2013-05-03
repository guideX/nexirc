'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class mdiMain
    Structure gVideo
        Public vWindow As frmVideoPlayer
        Public vFile As String
        Public vVisible As Boolean
    End Structure

    Structure gBrowser
        Public bWindow As frmBrowser
        Public bURL As String
        Public bVisible As Boolean
    End Structure

    'Public WithEvents lFlashWindow As clsFlashWindow
    Public WithEvents lProcesses As New clsProcess
    Public lVideo As New gVideo
    Public lBrowser As gBrowser
    Private lLoadingForm As New frmLoading
    Private lFlashesLeft As Integer

    Enum gWindowBarImageTypes
        wStatus = 1
        wChannel = 2
        wServer = 3
        wNotice = 4
    End Enum

    Enum eInfoBar
        iWelcome = 1
        iSocketError = 2
        iNetworkAvailable = 3
        iNetworkUnavailable = 4
        iNickServ_NickTaken = 5
    End Enum

    Public Sub ShowQueryBar(ByVal lText As String, ByVal lFunction As eInfoBar)
        'Try
        If Len(lText) <> 0 Then
            lblQueryPrompt.Text = lText
            tspQueryPrompt.Visible = True
            tspQueryPrompt.Tag = Trim(CType(lFunction, Integer).ToString)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ShowQueryBar(ByVal lText As String)")
        'End Try
    End Sub

    Public Sub SetFlashesLeft(ByVal lValue As Integer)
        'Try
        lFlashesLeft = lValue
        tmrFlashDCCToolBar.Enabled = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetFlashesLeft(ByVal lValue As Integer)")
        'End Try
    End Sub

    Public Function AddWindowBar(ByVal lText As String, ByVal lImageType As gWindowBarImageTypes) As ToolStripItem
        'Try
        Dim lImage As Image, i As Integer
        Select Case lImageType
            Case gWindowBarImageTypes.wStatus
                i = 0
            Case gWindowBarImageTypes.wChannel
                i = 1
            Case gWindowBarImageTypes.wServer
                i = 2
            Case gWindowBarImageTypes.wNotice
                i = 3
        End Select
        lImage = ImageList1.Images(i)
        Return tspWindows.Items.Add(lText, lImage)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function AddWindowBar(ByVal lText As String, ByVal lImageType As gWindowBarImageTypes, ByVal lSender As Object, ByVal lEventArgs As System.EventArgs) As ToolStripItem")
        'Return Nothing
        'End Try
    End Function

    Public Sub RemoveWindowBar(ByVal lText As String)
        'Try
        Dim i As Integer
        For i = 0 To tspWindows.Items.Count - 1
            If LCase(Trim(tspWindows.Items(i).Text)) = LCase(Trim(lText)) Then
                tspWindows.Items.Remove(tspWindows.Items(i))
                Exit For
            End If
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub RemoveWindowBar(ByVal lText As String)")
        'End Try
    End Sub

    Public Sub ClearWindowBar()
        'Try
        tspWindows.Items.Clear()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ClearWindowBar()")
        'End Try
    End Sub

    Public Sub CloseBrowser()
        'Try
        lBrowser.bWindow.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub CloseBrowser()")
        'End Try
    End Sub

    Public Sub TriggerBrowserResize()
        'Try
        lBrowser.bWindow.TriggerResize()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub TriggerBrowserResize()")
        'End Try
    End Sub

    Public Sub PlayVideo(ByVal lFile As String)
        'Try
        If Len(lFile) <> 0 And DoesFileExist(lFile) = True Then
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub PlayVideo(ByVal lFile As String)")
        'End Try
    End Sub

    Private Function IsPageExempt(ByVal lURL As String) As Boolean
        'Try
        Dim splt() As String = Split(lURL, "/")
        If InStr(splt(2), "'02-27-2013 - guideX") <> 0 Or InStr(splt(0), "tnexgen.com") <> 0 Then
            Return True
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function IsPageExempt(ByVal lURL As String) As Boolean")
        'End Try
    End Function

    Public Sub BrowseURL(ByVal _URL As String, Optional ByVal _Startup As Boolean = False)
        'Try
        Dim mbox As MsgBoxResult
        If Len(_URL) = 0 Then Exit Sub
        If lIRC.iSettings.sShowBrowser = True Then
            If IsPageExempt(_URL) = False Then
                If _Startup = False Then
                    If lIRC.iSettings.sPrompts = True Then
                        mbox = MsgBox("nexIRC would like to browse a webpage. Would you like to browse this page?" & vbCrLf & vbCrLf & "Details: " & _URL, MsgBoxStyle.YesNoCancel)
                        If mbox = MsgBoxResult.No Or mbox = MsgBoxResult.Cancel Then Exit Sub
                    End If
                End If
            End If
            If lBrowser.bVisible = False Then
                lBrowser.bWindow = Nothing
                lBrowser.bWindow = New frmBrowser
                lBrowser.bWindow.MdiParent = Me
                lBrowser.bWindow.Show()
                lBrowser.bVisible = True
            End If
            lBrowser.bURL = _URL
            lBrowser.bWindow.WebBrowser1.Navigate(_URL)
            If Err.Number = 5 Then
                lBrowser.bWindow = Nothing
                lBrowser.bWindow = New frmBrowser
                lBrowser.bWindow.MdiParent = Me
                clsAnimate.Animate(lBrowser.bWindow, clsAnimate.Effect.Center, 200, 1)

                lBrowser.bVisible = True
                lBrowser.bURL = _URL
                lBrowser.bWindow.WebBrowser1.Navigate(_URL)
                lBrowser.bWindow.Width = Me.Width
                lBrowser.bWindow.Height = Me.Width
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub BrowseURL(ByVal lURL As String, Optional ByVal lStartup As Boolean = False)")
        'End Try
    End Sub

    Private Sub mdiMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        If Me.WindowState = FormWindowState.Minimized Then nicSystray.Visible = True
        WriteINI(lINI.iIRC, "mdiMain", "Left", Str(Trim(CStr(Me.Left))))
        WriteINI(lINI.iIRC, "mdiMain", "Top", Str(Trim(CStr(Me.Top))))
        WriteINI(lINI.iIRC, "mdiMain", "Width", Str(Trim(Trim(CStr(Me.Width)))))
        WriteINI(lINI.iIRC, "mdiMain", "Height", Str(Trim(Trim(CStr(Me.Height)))))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub mdiMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
    End Sub

    Private Sub mdiMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        lStatus.Closing = True
        If lStatus.QuitAll() = False Then
            e.Cancel = True
            Me.Visible = False
            Me.tmrWaitForQuit.Enabled = True
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub mdiMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        'End Try
    End Sub

    Public Sub SetLoadingFormProgress(ByVal lData As String, ByVal lValue As Integer)
        On Error Resume Next
        lLoadingForm.SetProgress(lData, lValue)
        lLoadingForm.Refresh()
        Application.DoEvents()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetLoadingFormProgress(ByVal lData As String, ByVal lValue As Integer)")
    End Sub

    Public Function OpenDialogFileNames(ByVal lInitDir As String, ByVal lTitle As String, ByVal lFilter As String) As String()
        On Error Resume Next
        With fdgOpen
            .Filter = lFilter
            .InitialDirectory = lInitDir
            .Title = lTitle
            .ShowDialog()
            .Multiselect = True
            Return .FileNames
        End With
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ShowOpenDialog(ByVal lInitDir As String, ByVal lTitle As String, ByVal lFilter As String) As String")
    End Function

    Private Sub mdiMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'For Each control As Control In Me.Controls
        'Dim ctlMDI As MdiClient
        'Dim c As System.Drawing.Color = System.Drawing.Color.FromArgb(RGB(191, 219, 255))
        'For Each ctl As Object In Me.Controls
        'Try
        ' Attempt to cast the control to type MdiClient.
        'ctlMDI = CType(ctl, MdiClient)
        ' Set the BackColor of the MdiClient control.
        'ctlMDI.BackColor = c
        'Catch exc As InvalidCastException
        ' Catch and ignore the error if casting failed.
        'End Try
        'Next
        'Next control

        'Dim client As MdiClient = New MdiClient

        'If client IsNot Nothing Then
        'client.BackColor = System.Drawing.Color.FromArgb(RGB(191, 219, 255))
        'End If
        'Next control
        'Timer1.Interval = 500
        'Timer1.Enabled = True
        'Timer1.Start()
        'On Error Resume Next

        'Panel1.BackColor = Color.Black
        nicSystray.Visible = True
        nicSystray.Icon = Me.Icon
        lLoadingForm = New frmLoading
        clsAnimate.Animate(lLoadingForm, clsAnimate.Effect.Center, 200, 1)
        lLoadingForm.Focus()
        Application.DoEvents()
        SetLoadingFormProgress("Initializing Status Windows", 2)
        SetArraySizes()
        lStatus = New IRC.Status.clsStatus(lArraySizes.aStatusWindows)
        SetLoadingFormProgress("Initializing Processes", 5)
        lProcesses.Initialize()
        SetLoadingFormProgress("Loading Settings", 7)
        LoadSettings()
        SetLoadingFormProgress("Browsing URL", 95)
        BrowseURL(lIRC.iSettings.sURL, True)
        lLoadingForm.Focus()
        If lServers.sIndex <> 0 Then lStatus.Create(lIRC, lServers)
        Me.Left = CInt(Trim(ReadINI(lINI.iIRC, "mdiMain", "Left", CStr(Me.Left))))
        Me.Top = CInt(Trim(ReadINI(lINI.iIRC, "mdiMain", "Top", CStr(Me.Top))))
        Me.Width = CInt(Trim(ReadINI(lINI.iIRC, "mdiMain", "Width", CStr(Me.Width))))
        Me.Height = CInt(Trim(ReadINI(lINI.iIRC, "mdiMain", "Height", CStr(Me.Height))))
        If lIRC.iIdent.iSettings.iEnabled = True Then
            lIdent.InitListenSocket(113)
        End If
        SetLoadingFormProgress("Loading Complete", 100)
        lLoadingForm.Close()
        tmrStartupSettings.Enabled = True
        Me.Text = "nexIRC v" & Application.ProductVersion
        Me.LayoutMdi(MdiLayout.Cascade)
        'frmAbout.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub mdiMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub mdiMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        cmdLeftBar.Top = CInt(Me.ClientSize.Height / 2)
        If Panel1.Visible = True Then
            cmdLeftBar.Left = Panel1.ClientSize.Width
        Else
            cmdLeftBar.Left = 0
        End If
        If lVideo.vVisible = True Then
            If lVideo.vWindow.Left <> 0 Then lVideo.vWindow.Left = 0
            If lVideo.vWindow.Top <> 0 Then lVideo.vWindow.Top = 0
            If Panel1.Visible = True Then
                lVideo.vWindow.Width = Me.ClientSize.Width - (Panel1.ClientSize.Width + 4)
            Else
                lVideo.vWindow.Width = Me.ClientSize.Width - (4)
            End If
            If tspWindows.Visible = True Then
                If ToolStrip.Visible = True Then
                    lVideo.vWindow.Height = Me.ClientSize.Height - (ToolStrip.ClientSize.Height + tspWindows.ClientSize.Height + 4)
                Else
                    lVideo.vWindow.Height = Me.ClientSize.Height - (tspWindows.ClientSize.Height + 4)
                End If
            Else
                If ToolStrip.Visible = True Then
                    lVideo.vWindow.Height = Me.ClientSize.Height - (ToolStrip.ClientSize.Height + 4)
                Else
                    lVideo.vWindow.Height = Me.ClientSize.Height - (4)
                End If
            End If
        End If
        ResizeBrowser()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomize.Click")
    End Sub

    Public Sub ResizeBrowser()
        'Try
        If lBrowser.bVisible = True Then
            If Panel1.Visible = True Then
                lBrowser.bWindow.Width = Me.ClientSize.Width - (Panel1.ClientSize.Width + 5)
            Else
                lBrowser.bWindow.Width = Me.ClientSize.Width - (5)
            End If
            If tspWindows.Visible = True Then
                If ToolStrip.Visible = True Then
                    lBrowser.bWindow.Height = Me.ClientSize.Height - (ToolStrip.ClientSize.Height + tspWindows.ClientSize.Height + 6)
                Else
                    lBrowser.bWindow.Height = Me.ClientSize.Height - (tspWindows.ClientSize.Height + 6)
                End If
            Else
                If ToolStrip.Visible = True Then
                    lBrowser.bWindow.Height = Me.ClientSize.Height - (ToolStrip.ClientSize.Height + 6)
                Else
                    lBrowser.bWindow.Height = Me.ClientSize.Height - 6
                End If
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ResizeBrowser()")
        'End Try
    End Sub

    Public Sub New()
        On Error Resume Next
        'lFlashWindow = New clsFlashWindow(CInt(Me.Handle))
        InitializeComponent()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub New()")
    End Sub

    Public Sub SetWindowFocus(ByVal lForm As Form)
        On Error Resume Next
        'If lIRC.iSettings.sHideChildrenOnFocus = True Then HideChildren(lForm)
        If lForm.WindowState = FormWindowState.Minimized Then lForm.WindowState = FormWindowState.Normal
        If lIRC.iSettings.sAutoMaximize = True And lForm.WindowState <> FormWindowState.Maximized Then lForm.WindowState = FormWindowState.Maximized
        lForm.BringToFront()
        lForm.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SetWindowFocus(ByVal lForm As Form)")
    End Sub

    Public Sub HideChildren(ByVal lExcept As Form)
        On Error Resume Next
        Dim i As Integer
        If ActiveForm.Name = lExcept.Name Then Exit Sub
        For i = 0 To (Me.MdiChildren.Length) - 1
            If Me.MdiChildren(i).Visible = True Then Me.MdiChildren(i).Visible = False
        Next i
        lExcept.Visible = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub HideMdiChildren()")
    End Sub

    Private Sub tmrStartupSettings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStartupSettings.Tick
        On Error Resume Next
        StartupSettings()
        tmrStartupSettings.Enabled = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrStartupSettings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStartupSettings.Tick")
    End Sub

    Private Sub tmrFlashDCCToolBar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlashDCCToolBar.Tick
        On Error Resume Next
        If lFlashesLeft = 0 Then
            tmrFlashDCCToolBar.Enabled = False
            Exit Sub
        End If
        lFlashesLeft = lFlashesLeft - 1
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrFlashDCCToolBar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlashDCCToolBar.Tick")
    End Sub

    Private Sub tspWindows_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tspWindows.ItemClicked
        On Error Resume Next
        Dim i As Integer, n As Integer, msg As String
        i = CInt(Trim(e.ClickedItem.Tag.ToString))
        msg = e.ClickedItem.Text
        n = lChannels.Find(i, msg)
        If n <> 0 Then
            lChannels.ToggleChannelWindowState(n)
        Else
            lStatus.ToggleStatusWindowState(i)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tspWindows_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tspWindows.ItemClicked")
    End Sub

    Private Sub tvwConnections_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwConnections.DoubleClick
        On Error Resume Next
        lStatus.DblClickConnections(tvwConnections.SelectedNode)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tvwConnections_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwConnections.DoubleClick")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'Try
        Dim splt() As String
        If Len(lblQueryPrompt.Tag.ToString) = 1 Then
            Select Case CType(CType(lblQueryPrompt.Tag.ToString, Integer), eInfoBar)
                Case eInfoBar.iNickServ_NickTaken
                    clsAnimate.Animate(frmNickServLogin, clsAnimate.Effect.Center, 200, 1)
                    frmNickServLogin.SetStatusIndex(lStatus.ActiveIndex)
            End Select
        ElseIf InStr(lblQueryPrompt.Tag.ToString, ":") <> 0 Then
            splt = Split(lblQueryPrompt.Tag.ToString, ":")
            If lQuerySettings.qAutoShowWindow = True Then
                MsgBox("TODO!!!")
                'GLITCHY!!!!!
                'TODO!!!!!!!!
                'lStatus.PrivateMessages_Add(CInt(Trim(splt(0))), CInt(Trim(splt(1))), splt(2), True)
                'LEON!!!!!!!!
                'LEON!!!!!!!!
                'LEON!!!!!!!!
                'LEON!!!!!!!!
            Else
                MsgBox("TODO!!!")
                'GLITCHY!!!!!
                'TODO!!!!!!!!
                'lStatus.PrivateMessages_Add(CInt(Trim(splt(0))), CInt(Trim(splt(1))), splt(2), False)
                'LEON!!!!!!!!
                'LEON!!!!!!!!
                'LEON!!!!!!!!
            End If
            tspQueryPrompt.Visible = False
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click")
        'End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        On Error Resume Next
        tspQueryPrompt.Visible = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click")
    End Sub

    Private Sub cmd_ClearHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ClearHistory.Click
        On Error Resume Next
        Dim i As Integer
        cmd_RecientServer1.Text = "(Empty)"
        cmd_RecientServer2.Text = "(Empty)"
        cmd_RecientServer3.Text = "(Empty)"
        cmd_RecientServer1.Enabled = False
        cmd_RecientServer2.Enabled = False
        cmd_RecientServer3.Enabled = False
        For i = 1 To lRecientServers.sCount
            lRecientServers.sItem(i) = ""
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_ClearHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ClearHistory.Click")
    End Sub

    Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click
        On Error Resume Next
        lStatus.ActiveStatusConnect()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click")
    End Sub

    Private Sub cmd_Disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Disconnect.Click
        On Error Resume Next
        lStatus.CloseStatusConnection(lStatus.ActiveIndex, True)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click")
    End Sub

    Private Sub cmd_CloseStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_CloseStatus.Click
        On Error Resume Next
        Dim i As Integer
        i = lStatus.ActiveIndex()
        lStatus.CloseWindow(i)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click")
    End Sub

    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        'Try
        End
        'Catch ex As Exception
        'ProcessError(ex.Message,"Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click"
        'End Try
    End Sub

    Private Sub cmd_Channels_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Channels.ButtonClick
        On Error Resume Next
        frmChannelFolder.SetStatusIndex(lStatus.ActiveIndex())
        clsAnimate.Animate(frmChannelFolder, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connect.Click")
    End Sub

    Private Sub cmd_Connection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connection.ButtonClick
        'Try
        lStatus.ToggleConnection(lStatus.ActiveIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Connection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Connection.ButtonClick")
        'End Try
    End Sub

    Private Sub cmd_Customize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Customize.Click
        'Try
        frmCustomize.Show()
        'clsAnimate.Animate(frmCustomize, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_Customize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Customize.Click")
        'End Try
    End Sub

    Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ListChannels.Click
        'Try
        Dim n As Integer = lStatus.ActiveIndex
        ProcessReplaceCommand(n, eCommandTypes.cLIST, lStatus.ServerDescription(n))
        'lStatus.ShowChannelList(lStatus.ActiveIndex())
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ListChannels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ListChannels.Click")
        'End Try
    End Sub

    Private Sub cmd_LeftBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_LeftBar.Click
        On Error Resume Next
        If cmd_LeftBar.Checked = True Then
            cmd_LeftBar.Checked = False
            Panel1.Visible = False
            Me.Width = Me.Width + 1
        Else
            cmd_LeftBar.Checked = True
            Panel1.Visible = True
            Me.Width = Me.Width + 1
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_LeftBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_LeftBar.Click")
    End Sub

    Private Sub cmd_WindowBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WindowBar.Click
        On Error Resume Next
        If cmd_WindowBar.Checked = True Then
            cmd_WindowBar.Checked = False
            tspWindows.Visible = False
        Else
            cmd_WindowBar.Checked = True
            tspWindows.Visible = True
        End If
        Me.Width = Me.Width + 1
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_WindowBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WindowBar.Click")
    End Sub

    Private Sub cmd_Cascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Cascade.Click
        On Error Resume Next
        Me.LayoutMdi(MdiLayout.Cascade)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Cascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Cascade.Click")
    End Sub

    Private Sub cmd_TileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileHorizontal.Click
        On Error Resume Next
        Me.LayoutMdi(MdiLayout.TileHorizontal)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_TileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileHorizontal.Click")
    End Sub

    Private Sub cmd_TileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileVertical.Click
        On Error Resume Next
        Me.LayoutMdi(MdiLayout.TileVertical)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_TileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_TileVertical.Click")
    End Sub

    Private Sub cmd_ArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ArrangeIcons.Click
        On Error Resume Next
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_ArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ArrangeIcons.Click")
    End Sub

    Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click
        On Error Resume Next
        frmChannelFolder.SetStatusIndex(lStatus.ActiveIndex())
        clsAnimate.Animate(frmChannelFolder, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_ChannelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChannelFolder.Click")
    End Sub

    Private Sub cmd_Window_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Window.ButtonClick
        On Error Resume Next
        Me.LayoutMdi(MdiLayout.Cascade)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Window_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Window.ButtonClick")
    End Sub

    Private Sub cmd_NewStatusWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_NewStatusWindow.Click
        On Error Resume Next
        lStatus.Create(lIRC, lServers)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_NewStatusWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_NewStatusWindow.Click")
    End Sub

    Private Sub cmd_View_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.ButtonClick
        On Error Resume Next
        cmd_RecientServer1.Text = "Test"
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_View_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.ButtonClick")
    End Sub

    Private Sub cmd_DCCSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCSend.Click
        On Error Resume Next
        lStatus.lIRCMisc.NewDCCSend()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_DCCSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCSend.Click")
    End Sub

    Private Sub cmd_DCCChat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCChat.Click
        On Error Resume Next
        lStatus.lIRCMisc.NewDCCChat()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_DCCChat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCCChat.Click")
    End Sub

    Private Sub cmd_DownloadManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DownloadManager.Click
        On Error Resume Next
        clsAnimate.Animate(frmDownloadManager, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_DownloadManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DownloadManager.Click")
    End Sub

    Private Sub cmd_DCC_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCC.ButtonClick
        On Error Resume Next
        lStatus.lIRCMisc.NewDCCSend()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_DCC_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_DCC.ButtonClick")
    End Sub

    Private Sub cmd_RecientServer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer1.Click
        On Error Resume Next
        If Len(cmd_RecientServer1.Text) <> 0 And cmd_RecientServer1.Text <> "(Unknown)" Then lStatus.Connect_Specify(cmd_RecientServer1.Text, 6667)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_RecientServer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer1.Click")
    End Sub

    Private Sub cmd_RecientServer2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer2.Click
        On Error Resume Next
        If Len(cmd_RecientServer2.Text) <> 0 And cmd_RecientServer2.Text <> "(Unknown)" Then lStatus.Connect_Specify(cmd_RecientServer2.Text, 6667)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_RecientServer2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer2.Click")
    End Sub

    Private Sub cmd_RecientServer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer3.Click
        On Error Resume Next
        If Len(cmd_RecientServer3.Text) <> 0 And cmd_RecientServer3.Text <> "(Unknown)" Then lStatus.Connect_Specify(cmd_RecientServer3.Text, 6667)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_RecientServer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_RecientServer3.Click")
    End Sub

    Private Sub cmdLeftBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeftBar.Click
        On Error Resume Next
        If cmd_LeftBar.Checked = True Then
            cmd_LeftBar.Checked = False
            Panel1.Visible = False
        Else
            cmd_LeftBar.Checked = True
            Panel1.Visible = True
        End If
        Me.Width = Me.Width + 1
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdLeftBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeftBar.Click")
    End Sub

    Private Sub cmd_ServerLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ServerLinks.Click
        On Error Resume Next
        lStatus.SendSocket(lStatus.ActiveIndex, "LINKS")
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_ServerLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ServerLinks.Click")
    End Sub

    Private Sub cmd_Whois_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whois.Click
        On Error Resume Next
        Dim msg As String, i As Integer
        i = lStatus.ActiveIndex()
        msg = InputBox("Enter whois nickname")
        If Len(msg) <> 0 Then ProcessReplaceCommand(i, eCommandTypes.cWHOIS, msg)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Whois_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whois.Click")
    End Sub

    Private Sub cmd_Whowas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whowas.Click
        On Error Resume Next
        Dim msg As String, i As Integer
        i = lStatus.ActiveIndex()
        msg = InputBox("Enter whowas nickname")
        If Len(msg) <> 0 Then ProcessReplaceCommand(i, eCommandTypes.cWHOWAS, msg)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Whowas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Whowas.Click")
    End Sub

    Private Sub cmd_Time_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Time.Click
        On Error Resume Next
        Dim i As Integer
        i = lStatus.ActiveIndex()
        ProcessReplaceCommand(i, eCommandTypes.cTIME)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Time_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Time.Click")
    End Sub

    Private Sub cmd_Stats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Stats.Click
        On Error Resume Next
        Dim i As Integer
        i = lStatus.ActiveIndex()
        ProcessReplaceCommand(i, eCommandTypes.cSTATS)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Stats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Stats.Click")
    End Sub

    Private Sub cmd_Away_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Away.Click
        On Error Resume Next
        Dim i As Integer, msg As String
        i = lStatus.ActiveIndex()
        msg = InputBox("Enter away message:")
        ProcessReplaceCommand(i, eCommandTypes.cAWAY, msg)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Away_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Away.Click")
    End Sub

    Private Sub cmd_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Back.Click
        On Error Resume Next
        Dim i As Integer
        i = lStatus.ActiveIndex()
        ProcessReplaceCommand(i, eCommandTypes.cBACK)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Away_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Away.Click")
    End Sub

    Private Sub cmd_PlayVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_PlayVideo.Click
        On Error Resume Next
        Dim msg() As String, i As Integer
        msg = OpenDialogFileNames(Application.StartupPath, "Play Video", "Video Files |*.avi,*.mov,*.wmv,*.mpg,*.mpeg")
        i = msg.Length - 1
        If i <> -1 Then PlayVideo(msg(i))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_PlayVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_PlayVideo.Click")
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
    End Sub

    Private Sub cmd_CloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_CloseConnection.Click
        On Error Resume Next
        lStatus.Quit(lStatus.ActiveIndex())
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_CloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_CloseConnection.Click")
    End Sub

    Private Sub cmdAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccept.Click
        On Error Resume Next
        Dim splt() As String, lForm As New frmDCCGet
        splt = Split(lblUser.Tag.ToString, vbCrLf)
        ToolStrip.Visible = False
        tspDCCToolBar.Visible = False
        ToolStrip.Visible = True
        lForm.InitDCCGet(splt(0), splt(1), splt(2), splt(3), splt(4))
        clsAnimate.Animate(lForm, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccept.Click")
    End Sub

    Private Sub cmdDeny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeny.Click
        On Error Resume Next
        tspDCCToolBar.Visible = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdDeny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeny.Click")
    End Sub

    Private Sub cmd_Notepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notepad.Click
        On Error Resume Next
        clsAnimate.Animate(frmNotepad, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmd_Notepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Notepad.Click")
    End Sub

    Private Sub nicSystray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nicSystray.MouseDoubleClick
        On Error Resume Next
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Focus()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub nicSystray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nicSystray.MouseDoubleClick")
    End Sub

    Private Sub cmd_ChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeConnection.Click
        'Try
        clsAnimate.Animate(frmChangeConnection, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ChangeConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeConnection.Click")
        'End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        Dim lScript As clsScript
        lScript = New clsScript
        lScript.ReadCodeFile(lINI.iBasePath & "data\script\status.txt")
        'lScript.DoCode(1)
        lScript.DoCodeByName("MakeStatus")
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub

    Private Sub cmd_SelectAServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_SelectAServer.Click
        'Try
        frmCustomize.Show()
        'clsAnimate.Animate(frmCustomize, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_SelectAServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_SelectAServer.Click")
        'End Try
    End Sub

    Private Sub cmd_ShowAbout_Click(sender As System.Object, e As System.EventArgs) Handles cmd_ShowAbout.Click
        'Try
        clsAnimate.Animate(frmAbout, clsAnimate.Effect.Slide, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmd_ShowAbout_Click(sender As System.Object, e As System.EventArgs) Handles cmd_ShowAbout.Click")
        'End Try
    End Sub

    Private Sub tmrHideInfoBar_Tick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lProcesses_ProcessError(_Error As String, _Sub As String) Handles lProcesses.ProcessError
        'Try
        ProcessError(_Error, _Sub)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lProcesses_ProcessError(_Error As String, _Sub As String) Handles lProcesses.ProcessError")
        'End Try
    End Sub

    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    'Me.Text = lStatus.ActiveIndex().ToString
    'End Sub

    Private Sub cmdRedirectDeny_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedirectDeny.Click
        tspRedirect.Visible = False
    End Sub

    Private Sub cmdRedirectAccept_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedirectAccept.Click
        'Try
        Dim splt() As String
        tspRedirect.Visible = False
        If (IsNumeric(lblRedirectMessage.Tag.ToString().Trim()) = True) Then
            splt = lblRedirectMessage.Text.ToString().Split(Convert.ToChar("'"))
            lChannels.Join(Convert.ToInt32(lblRedirectMessage.Tag.ToString().Trim()), splt(3))
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRedirectAccept_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedirectAccept.Click")
        'End Try
    End Sub

    Private Sub tmrWaitForQuit_Tick(sender As System.Object, e As System.EventArgs) Handles tmrWaitForQuit.Tick
        'Try
        End
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub tmrWaitForQuit_Tick(sender As System.Object, e As System.EventArgs) Handles tmrWaitForQuit.Tick")
        'End Try
    End Sub

    Private Sub tmrHideRedirect_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHideRedirect.Tick
        'Try
        tspRedirect.Visible = False
        tmrHideRedirect.Enabled = False
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub tmrHideRedirect_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHideRedirect.Tick")
        'End Try
    End Sub

    Private Sub mnu_Commands_Click(sender As System.Object, e As System.EventArgs) Handles mnu_Commands.Click

    End Sub
End Class