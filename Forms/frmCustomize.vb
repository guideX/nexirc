'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Imports Telerik.WinControls.UI

Public Class frmCustomize
    Private lSelectedNotifyItem As ListViewItem
    Private lListViewSorter As clsListViewSorter
    Private lBrowserEnabled As Boolean
    Private lIntegratedMode As Boolean

    Public Sub RefreshNetworks()
        'Try
        Dim i As Integer
        cboNetworks.Items.Clear()
        For i = 1 To lNetworks.nCount
            With lNetworks.nNetwork(i)
                If Len(.nDescription) <> 0 Then
                    cboNetworks.Items.Add(.nDescription)
                End If
            End With
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub RefreshNetworks()")
        'End Try
    End Sub

    Public Sub EventApply()
        On Error Resume Next
        Dim i As Integer
        With lDCC
            .dDownloadDirectory = txtDownloadDirectory.Text
            .dFileExistsAction = CType(cboDCCFileExists.SelectedIndex + 1, eDCCFileExistsAction)
            If optDCCChatPrompt.Checked = True Then
                .dChatPrompt = eDCCPrompt.ePrompt
            ElseIf optDCCChatAcceptAll.Checked = True Then
                .dChatPrompt = eDCCPrompt.eAcceptAll
            ElseIf optDCCChatIgnore.Checked = True Then
                .dChatPrompt = eDCCPrompt.eIgnore
            End If
            If optDCCSendPrompt.Checked = True Then
                .dSendPrompt = eDCCPrompt.ePrompt
            ElseIf optDCCSendAcceptAll.Checked = True Then
                .dSendPrompt = eDCCPrompt.eAcceptAll
            ElseIf optDCCSendIgnore.Checked = True Then
                .dSendPrompt = eDCCPrompt.eIgnore
            End If
            .dIgnorelist.dCount = 0
            .dAutoIgnore = chkAutoIgnoreExceptNotify.Checked
            .dAutoCloseDialogs = chkAutoCloseDialogs.Checked
            If lstDCCIgnoreItems.Items.Count <> 0 Then
                For i = 0 To lstDCCIgnoreItems.Items.Count - 1
                    If Len(lstDCCIgnoreItems.Items(i).ToString) <> 0 Then
                        .dIgnorelist.dCount = .dIgnorelist.dCount + 1
                        .dIgnorelist.dItem(.dIgnorelist.dCount).dData = lstDCCIgnoreItems.Items(i).ToString
                        .dIgnorelist.dItem(.dIgnorelist.dCount).dType = gDCCIgnoreType.dNicknames
                    End If
                Next i
                For i = 0 To lstIgnoreExtensions.Items.Count - 1
                    If Len(lstIgnoreExtensions.Items(i).ToString) <> 0 Then
                        .dIgnorelist.dCount = .dIgnorelist.dCount + 1
                        .dIgnorelist.dItem(.dIgnorelist.dCount).dData = lstIgnoreExtensions.Items(i).ToString
                        .dIgnorelist.dItem(.dIgnorelist.dCount).dType = gDCCIgnoreType.dFileTypes
                    End If
                Next i
            End If
        End With
        With lIRC.iSettings.sStringSettings
            If optDisplayModeNormal.Checked = True Then
                .sDisplay = eStringsDisplayMode.dNormal
            ElseIf optDisplayModeRaw.Checked = True Then
                .sDisplay = eStringsDisplayMode.dRaw
            ElseIf optDisplayModeMinimal.Checked = True Then
                .sDisplay = eStringsDisplayMode.dMinimal
            End If
            If optUnknownsStatus.Checked = True Then
                .sUnknowns = eUnknownsIn.uStatusWindow
            ElseIf optUnknownsOwn.Checked = True Then
                .sUnknowns = eUnknownsIn.uOwnWindow
            ElseIf optUnknownsHide.Checked = True Then
                .sUnknowns = eUnknownsIn.uHide
            End If
            If optUnsupportedStatus.Checked = True Then
                .sUnsupported = eUnsupportedIn.uStatusWindow
            ElseIf optUnsupportedOwn.Checked = True Then
                .sUnsupported = eUnsupportedIn.uOwnWindow
            ElseIf optUnsupportedHide.Checked = True Then
                .sUnsupported = eUnsupportedIn.uHide
            End If
            .sServerInNotices = CBool(chkServerInNotices.Checked)
        End With
        With lIRC.iModes
            .mInvisible = chkInvisible.Checked
            .mLocalOperator = chkLocalOp.Checked
            .mOperator = chkOperator.Checked
            .mRestricted = chkRestricted.Checked
            .mServerNotices = chkServerNotices.Checked
            .mWallops = chkWallops.Checked
        End With
        lIRC.iNicks.nIndex = ReturnNickIndex(cboNickNames.Text)
        lNetworks.nSelected = cboNetworks.SelectedItem
        lNetworks.nIndex = FindNetworkIndex(cboNetworks.Text)
        lServers.sIndex = FindServerIndexByIp(txtServer.Text)
        With lIRC.iSettings
            .sAutoCloseSupportingWindows = chkAutoCloseSupportingWindows.Checked
            .sChannelFolderCloseOnJoin = chkChannelFolderCloseOnJoin.Checked
            .sAutoAddToChannelFolder = chkAutoAddToChannelFolder.Checked
            .sCloseWindowOnDisconnect = chkCloseWindowOnDisconnect.Checked
            .sAutoNavigateChannelUrls = chkAutoNavigateChannelUrls.Checked
            .sShowUserAddresses = chkShowUserAddresses.Checked
            .sHideMOTD = chkHideMOTD.Checked
            .sPrompts = chkShowPrompts.Checked
            .sExtendedMessages = chkExtendedMessages.Checked
            .sNoIRCMessages = chkNoIRCMessages.Checked
            .sCustomizeOnStartup = chkShowCustomizeOnStartup.Checked
            .sPopupChannelFolders = chkPopupChannelFolder.Checked
            '.sAntiConnectHammer = chkAntiConnectHammer.Checked
            .sChangeNickNameWindow = chkChangeNickNameWindow.Checked
            .sShowBrowser = chkShowBrowser.Checked
            .sURL = txtURL.Text
            .sShowWindowsAutomatically = chkShowWindowsAutomatically.Checked
            .sTextSpeed = 10
            .sHammerTime = 10
            .sAutoMaximize = chkAutoMaximize.Checked
            .sHideStatusOnClose = chkHideStatusOnClose.Checked
            .sVideoBackground = chkVideoBackground.Checked
            .sAutoConnect = chkAutoConnect.Checked
            If lBrowserEnabled = True And .sShowBrowser = False Then
                mdiMain.CloseBrowser()
            ElseIf lBrowserEnabled = False And .sShowBrowser = True Then
                mdiMain.BrowseURL(lIRC.iSettings.sURL)
                mdiMain.ResizeBrowser()
            End If
        End With
        PopulateNotifyByListView(lvwNotify)
        i = lStatus.ActiveIndex()
        lStatus.NickName(i, False) = cboNickNames.Text
        lStatus.Email(i) = lIRC.iEMail
        lStatus.Pass(i) = lIRC.iPass
        lStatus.RealName(i) = lIRC.iRealName
        lStatus.SetOperSettings(i, lIRC.iOperName, lIRC.iOperPass)
        If lStatus.Connected(i) = False Then
            lStatus.SetStatus(i)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub EventApply()")
    End Sub

    Public Sub RefreshServers(ByVal _FirstLoad As Boolean)
        'Try
        Dim i As Integer, _Ip As String = "", _Port As String = "" '_Item As ListViewDataItem
        lvwServers.Items.Clear()
        If lNetworks.nIndex <> 0 Then
            For i = 1 To lServers.sCount
                With lServers.sServer(i)
                    If Len(.sDescription) <> 0 Then
                        If .sNetworkIndex = lNetworks.nIndex Then
                            Dim _Values(2) As String
                            _Values(0) = .sDescription
                            _Values(1) = .sIP
                            _Values(2) = .sPort.ToString
                            lvwServers.Items.Add(New ListViewDataItem(.sDescription, _Values))
                            '_Item = New ListViewDataItem
                            '_Item.Text = .sDescription
                            'MsgBox(.sDescription)
                            '_Item(0) = .sDescription
                            '_Item(1) = .sIP
                            '_Item(2) = .sPort
                            '_Item("Description") = .sDescription
                            '_Item("Server") = .sIP
                            '_Item("Port") = .sPort
                            'lvwServers.Items.Add(_Item)
                            If String.IsNullOrEmpty(_Ip) = True Then _Ip = .sIP
                            If String.IsNullOrEmpty(_Port) = True Then _Port = .sPort.ToString
                        End If
                    End If
                End With
            Next i
            If _FirstLoad = False Then
                txtServer.Text = _Ip
                txtServerPort.Text = _Port
                'Else
                'lvwServers.Items.SelectedIndices.Add(FindListViewIndex(lvwServers, lServers.sServer(lServers.sIndex).sDescription))
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub RefreshServers(ByVal lFirstLoad As Boolean)")
        'End Try
    End Sub

    Private Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String, ByVal lServerIP As String)
        On Error Resume Next
        Dim lItem As ListViewItem
        If Len(lNickName) <> 0 And Len(lMessage) <> 0 Then
            lItem = lvwNotify.Items.Add(lNickName)
            lItem.SubItems.Add(lMessage)
            lItem.SubItems.Add(lServerIP)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String)")
    End Sub

    Private Sub InitSettings()
        On Error Resume Next
        Dim i As Integer
        PopulateListViewWithStrings(lvwStrings)
        'For i = 1 To lNetworks.nCount
        'With lNetworks.nNetwork(i)
        'If DoesNetworkHaveAService(.nDescription) Then
        'cboServicesNetwork.Items.Add(.nDescription)
        'End If
        'End With
        'Next i
        For i = 1 To lNetworks.nCount
            With lNetworks.nNetwork(i)
                cboNetworkNotify.Items.Add(.nDescription)
            End With
        Next i
        For i = 1 To lNotify.nCount
            With lNotify.nNotify(i)
                AddToNotifyListView(.nNickName, .nMessage, .nNetwork)
            End With
        Next i
        For i = 1 To lIRC.iNicks.nCount
            With lIRC.iNicks.nNick(i)
                If Len(.nNick) <> 0 Then
                    cboNickNames.Items.Add(.nNick)
                End If
            End With
        Next i
        cboNickNames.Text = lIRC.iNicks.nNick(lIRC.iNicks.nIndex).nNick
        'With lIRC.iIdent
        'txtIdentdUserID.Text = .iUserID
        'txtIdentdSystem.Text = .iSystem
        'txtIdentdPort.Text = Trim(CStr(.iPort))
        'chkIdentdEnabled.Checked = .iSettings.iEnabled
        'End With
        With lIRC.iSettings.sStringSettings
            Select Case .sUnknowns
                Case eUnknownsIn.uStatusWindow
                    optUnknownsStatus.Checked = True
                Case eUnknownsIn.uOwnWindow
                    optUnknownsOwn.Checked = True
                Case eUnknownsIn.uHide
                    optUnknownsHide.Checked = True
            End Select
            Select Case .sDisplay
                Case eStringsDisplayMode.dNormal
                    optDisplayModeNormal.Checked = True
                Case eStringsDisplayMode.dMinimal
                    optDisplayModeMinimal.Checked = True
                Case eStringsDisplayMode.dRaw
                    optDisplayModeRaw.Checked = True
            End Select
            Select Case .sUnsupported
                Case eUnsupportedIn.uStatusWindow
                    optUnsupportedStatus.Checked = True
                Case eUnsupportedIn.uOwnWindow
                    optUnsupportedOwn.Checked = True
                Case eUnsupportedIn.uHide
                    optUnsupportedHide.Checked = True
            End Select
            chkServerInNotices.Checked = .sServerInNotices
        End With
        With lIRC.iModes
            chkInvisible.Checked = .mInvisible
            chkLocalOp.Checked = .mLocalOperator
            chkOperator.Checked = .mOperator
            chkRestricted.Checked = .mRestricted
            chkServerNotices.Checked = .mServerNotices
            chkWallops.Checked = .mWallops
        End With
        With lDCC
            Select Case .dChatPrompt
                Case eDCCPrompt.ePrompt
                    optDCCChatPrompt.Checked = True
                Case eDCCPrompt.eAcceptAll
                    optDCCChatAcceptAll.Checked = True
                Case eDCCPrompt.eIgnore
                    optDCCChatIgnore.Checked = True
            End Select
            Select Case .dSendPrompt
                Case eDCCPrompt.ePrompt
                    optDCCSendPrompt.Checked = True
                Case eDCCPrompt.eAcceptAll
                    optDCCSendAcceptAll.Checked = True
                Case eDCCPrompt.eIgnore
                    optDCCSendIgnore.Checked = True
            End Select

            txtDownloadDirectory.Text = lDCC.dDownloadDirectory
            chkAutoIgnoreExceptNotify.Checked = lDCC.dAutoIgnore
            chkAutoCloseDialogs.Checked = lDCC.dAutoCloseDialogs
            Select Case .dFileExistsAction
                Case eDCCFileExistsAction.dPrompt
                    cboDCCFileExists.SelectedIndex = 0
                Case eDCCFileExistsAction.dOverwrite
                    cboDCCFileExists.SelectedIndex = 1
                Case eDCCFileExistsAction.dIgnore
                    cboDCCFileExists.SelectedIndex = 2
            End Select
            For i = 1 To .dIgnorelist.dCount
                Select Case .dIgnorelist.dItem(i).dType
                    Case gDCCIgnoreType.dNicknames
                        If Len(.dIgnorelist.dItem(i).dData) <> 0 Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                    Case gDCCIgnoreType.dHostnames
                        If Len(.dIgnorelist.dItem(i).dData) <> 0 Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                    Case gDCCIgnoreType.dFileTypes
                        If Len(.dIgnorelist.dItem(i).dData) <> 0 Then lstIgnoreExtensions.Items.Add(.dIgnorelist.dItem(i).dData)
                End Select
            Next i
        End With
        With lIRC.iSettings
            txtURL.Text = .sURL
            'sldTextSpeed.Value = .sTextSpeed
            'sldHammerTime.Value = CInt(.sHammerTime)
            chkChannelFolderCloseOnJoin.Checked = .sChannelFolderCloseOnJoin
            chkAutoAddToChannelFolder.Checked = .sAutoAddToChannelFolder
            chkCloseWindowOnDisconnect.Checked = .sCloseWindowOnDisconnect
            chkAutoNavigateChannelUrls.Checked = .sAutoNavigateChannelUrls
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
            'chkShowRawWindow.Checked = .sShowRawWindow
            'chkHideChildrenOnFocus.Checked = .sHideChildrenOnFocus
            chkShowUserAddresses.Checked = .sShowUserAddresses
            chkHideMOTD.Checked = .sHideMOTD
            chkShowPrompts.Checked = .sPrompts
            chkExtendedMessages.Checked = .sExtendedMessages
            chkNoIRCMessages.Checked = .sNoIRCMessages
            chkShowCustomizeOnStartup.Checked = .sCustomizeOnStartup
            chkPopupChannelFolder.Checked = .sPopupChannelFolders
            'chkMOTDInOwnWindow.Checked = .sMOTDInOwnWindow
            chkChangeNickNameWindow.Checked = .sChangeNickNameWindow
            'chkNoticesInOwnWindow.Checked = .sNoticesInOwnWindow
            chkShowBrowser.Checked = .sShowBrowser
            chkShowWindowsAutomatically.Checked = .sShowWindowsAutomatically
            'chkAntiConnectHammer.Checked = .sAntiConnectHammer
            chkAutoMaximize.Checked = .sAutoMaximize
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
            lBrowserEnabled = .sShowBrowser
            chkAutoConnect.Checked = .sAutoConnect
            chkVideoBackground.Checked = .sVideoBackground
            chkAutoCloseSupportingWindows.Checked = .sAutoCloseSupportingWindows
        End With
        If lNetworks.nCount <> 0 Then
            For i = 1 To lNetworks.nCount
                With lNetworks.nNetwork(i)
                    If Len(.nDescription) <> 0 Then
                        cboNetworks.Items.Add(.nDescription)
                    End If
                End With
            Next i
            cboNetworks.Text = lNetworks.nNetwork(lNetworks.nIndex).nDescription
        End If
        If lServers.sIndex <> 0 Then
            With lServers.sServer(lServers.sIndex)
                txtServer.Text = .sIP
                txtServerPort.Text = Trim(CStr(.sPort))
            End With
        End If
        RefreshServers(True)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub InitSettings()")
    End Sub

    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        lWinVisible.wCustomize = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
    End Sub

    Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.RadRibbonBar1.RibbonBarElement.TabStripElement.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
            'Dim _TopCorrection As Integer = -100
            'cmdConnect.Top = cmdConnect.Top + _TopCorrection
            'cmdOK.Top = cmdOK.Top + _TopCorrection
            'cmdApply.Top = cmdApply.Top + _TopCorrection
            'cmdCancel.Top = cmdCancel.Top + _TopCorrection
            'chkNewStatusWindow.Top = chkNewStatusWindow.Top + _TopCorrection
            'TabControl1.Top = 50
            'Me.Height = 430
            Me.CancelButton = cmdCancelNow
            Me.Icon = mdiMain.Icon
            lWinVisible.wCustomize = True
            With lvwStrings.Columns
                .Add("Description", 70)
                .Add("Support", 70)
                .Add("Syntax", 70)
                .Add("Numeric", 50)
                .Add("Data", 70)
            End With
            With lvwServers.Columns
                .Clear()
                .Add(New ListViewDetailColumn("Description", "Description"))
                .Add(New ListViewDetailColumn("Server", "Server"))
                .Add(New ListViewDetailColumn("Port", "Port"))
                '.Add("Description", "Description")
                '.Add("Server", "Server")
                '.Add("Ports", "Port")
            End With
            With lvwNotify.Columns
                .Add("NickName", 140)
                .Add("Message", 140)
                .Add("Network", 140)
            End With
            lListViewSorter = New clsListViewSorter(lvwStrings)
            InitSettings()
            'Me.Visible = True
            'clsAnimate.Animate(lvwServers, clsAnimate.Effect.Center, 25, 1)
            'clsAnimate.Animate(cboNetworks, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(lnkNetworkAdd, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(lnkNetworkDelete, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(cmdClearServers, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(cmdMove, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(cmdAddServer, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(cmdEdit, clsAnimate.Effect.Roll, 25, 1)
            'clsAnimate.Animate(cmdDelete, clsAnimate.Effect.Roll, 25, 1)
            'lListViewSorter = New clsListViewSorter( lvwServers)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdAddNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        clsAnimate.Animate(frmAddNetwork, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNetwork.Click")
    End Sub

    Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        clsAnimate.Animate(frmAddServer, clsAnimate.Effect.Center, 200, 1)
        frmAddServer.SetNetwork(cboNetworks.Text)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddServer.Click")
    End Sub

    Private Sub lvwServers_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim i As Integer
        txtServer.Text = lvwServers.SelectedItems(0).Item(1).ToString
        txtServerPort.Text = lvwServers.SelectedItems(0).Item(2).ToString
        i = FindServerIndexByIp(txtServer.Text)
        lServers.sModified = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lvwServers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwServers.Click")
    End Sub

    Private Sub cmdAddAlternateNickname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        clsAnimate.Animate(frmAddNickName, clsAnimate.Effect.Center, 200, 1)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddAlternateNickname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAlternateNickname.Click")
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click")
    End Sub

    Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteButton.Click")
    End Sub

    Private Sub cmdMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub cmdAddNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        If Len(txtNotifyNickName.Text) <> 0 And Len(txtNotifyMessage.Text) <> 0 Then
            lNotify.nModified = True
            AddToNotifyListView(txtNotifyNickName.Text, txtNotifyMessage.Text, cboNetworkNotify.Text)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNotify.Click")
    End Sub

    Private Sub cmdClearNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        lNotify.nModified = True
        lvwNotify.Items.Clear()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdClearNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearNotify.Click")
    End Sub

    Private Sub cmdClearServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub cmdEditString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditString.Click
        On Error Resume Next
        Dim lItem As ListViewItem, f As frmEditString, i As Integer, msg As String, n As Integer
        lItem = New ListViewItem
        If lvwStrings.SelectedItems.Count <> 0 Then
            For i = 0 To lvwStrings.SelectedItems.Count
                lItem = lvwStrings.SelectedItems(i)
                Exit For
            Next i
            f = New frmEditString
            f.Show()
            f.txtDescription.Text = lItem.Text
            f.txtSupport.Text = lItem.SubItems(1).Text
            f.txtSyntax.Text = lItem.SubItems(2).Text
            f.cboNumeric.Text = lItem.SubItems(3).Text
            f.txtData.Text = lItem.SubItems(4).Text
            n = FindStringIndexByDescription(lItem.Text)
            For i = 1 To 6
                msg = ReadINI(lINI.iText, Trim(CStr(n)), "Find" & Trim(Str(i)), "")
                If Len(msg) <> 0 Then f.lstParameters.Items.Add(msg)
            Next i
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdEditString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditString.Click")
    End Sub

    Private Sub lvwNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwNotify.SelectedIndexChanged
        On Error Resume Next
        Dim i As Integer, n As Integer
        cmdRemove.Enabled = True
        'cmdRemoveNotify.Enabled = True
        For i = 0 To lvwNotify.SelectedItems.Count - 1
            n = FindNotifyIndex(lvwNotify.SelectedItems(i).Text)
            txtNotifyNickName.Text = lNotify.nNotify(n).nNickName
            txtNotifyMessage.Text = lNotify.nNotify(n).nMessage
            cboNetworkNotify.SelectedItem = cboNetworkNotify.Items(FindComboIndex(cboNetworkNotify, lNotify.nNotify(n).nNetwork))
            Exit For
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lvwNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwNotify.SelectedIndexChanged")
    End Sub

    Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim f As New frmDCCIgnoreAdd
        f.optNickName.Checked = True
        f.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click")
    End Sub

    Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick
        On Error Resume Next
        cmdEditString_Click(sender, e)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick")
    End Sub

    Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        On Error Resume Next
        Dim msg As String
        If lstDCCIgnoreItems.SelectedIndex = -1 Then
            Exit Sub
        End If
        msg = Trim(lstDCCIgnoreItems.SelectedItem.ToString)
        If InStr(Err.Description, "Object reference not set to an instance of an object.") <> 0 Then
            Err.Clear()
            Exit Sub
        End If
        If Len(msg) <> 0 Then cmdDCCIgnoreRemove.Enabled = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick")
    End Sub

    Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim lItems() As String, i As Integer, c As Integer, msg As String
        msg = lstDCCIgnoreItems.SelectedItem.ToString
        If InStr(Err.Description, "Object reference not set to an instance of an object.") <> 0 Then
            Err.Clear()
            Exit Sub
        End If
        If Len(Trim(msg)) <> 0 Then
            lstDCCIgnoreItems.Items.Remove(lstDCCIgnoreItems.SelectedItem)
            ReDim lItems(100)
            For i = 1 To lDCC.dIgnorelist.dCount
                With lDCC.dIgnorelist.dItem(i)
                    If LCase(Trim(.dData)) = LCase(Trim(msg)) Then
                        .dData = ""
                    Else
                        If Len(.dData) <> 0 Then
                            c = c + 1
                            lItems(c) = .dData
                        End If
                    End If
                End With
            Next i
            lDCC.dIgnorelist.dCount = c
            WriteINI(lINI.iDCC, "Settings", "IgnoreCount", Trim(c.ToString))
            For i = 1 To 100
                With lDCC.dIgnorelist.dItem(i)
                    If Len(lItems(i)) <> 0 Then
                        .dData = lItems(i)
                        WriteINI(lINI.iDCC, "Ignore", Trim(i.ToString), .dData)
                    Else
                        .dData = ""
                    End If
                End With
            Next i
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click")
    End Sub

    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        On Error Resume Next
        frmNetworkSettings.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click")
    End Sub

    Private Sub cmdUserSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserSettings.Click
        On Error Resume Next
        frmEditUserProfile.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdUserSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserSettings.Click")
    End Sub

    Private Sub cmdAddIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim f As New frmDCCIgnoreAdd
        f.optFileType.Checked = True
        f.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click")
    End Sub

    Private Sub cmdSecureQuerySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSecureQuerySettings.Click
        On Error Resume Next
        frmQuerySettings.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdSecureQuerySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSecureQuerySettings.Click")
    End Sub

    Private Sub cmdAddAlternateNickname_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAlternateNickname.Click
        On Error Resume Next
        frmAddNickName.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdAddAlternateNickname_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAlternateNickname.Click")
    End Sub

    Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click
        On Error Resume Next
        frmCompatibility.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click")
    End Sub

    Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        'cmdRemoveNotify.Enabled = False
        For Each _SelectedListViewItem As ListViewItem In lvwNotify.SelectedItems
            lvwNotify.Items.RemoveAt(_SelectedListViewItem.Index)
        Next _SelectedListViewItem
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveNotify.Click")
    End Sub

    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditIdentSettings.Click
        On Error Resume Next
        frmIdentdSettings.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditIdentSettings.Click")
    End Sub

    Private Sub cmdShowInOwnWinddow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowInOwnWinddow.Click
        On Error Resume Next
        frmInOwnWindow.Show()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditIdentSettings.Click")
    End Sub

    Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click
        'Try
        lstIgnoreExtensions.Items.RemoveAt(lstIgnoreExtensions.SelectedIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click")
        'End Try
    End Sub

    Private Sub cmdAddIgnoreExtension_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click
        'Try
        Dim msg As String = InputBox("Add Ignore Extension")
        If Len(msg) <> 0 Then
            lstIgnoreExtensions.Items.Add(msg)
        Else
            If lIRC.iSettings.sPrompts = True Then MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdAddIgnoreExtension_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click")
        'End Try
    End Sub

    Private Sub lstDCCIgnoreItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDCCIgnoreItems.Click
        'Try
        cmdDCCIgnoreRemove.Enabled = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDCCIgnoreItems.Click")
        'End Try
    End Sub

    Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged
        'Try
        cmdRemoveIgnoreExtension.Enabled = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged")
        'End Try
    End Sub

    Private Sub optUnknownsStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optUnknownsStatus.CheckedChanged

    End Sub
    Private Sub lvwServers_DoubleClick(sender As Object, e As System.EventArgs)
        'Try
        If chkNewStatus.Checked = True Then
            lStatus.Create(lIRC, lServers)
            Application.DoEvents()
        End If
        If lStatus.ActiveIndex() <> 0 Then
            EventApply()
            lStatus.ActiveStatusConnect()
        End If
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwServers_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwServers.DoubleClick")
        'End Try
    End Sub

    Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked
        'Try
        Dim _MsgBoxResult As MsgBoxResult, msg As String
        msg = cboNetworks.SelectedItem.ToString
        If lIRC.iSettings.sPrompts = True Then
            _MsgBoxResult = MsgBox("Really, delete '" & msg & "'?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
        Else
            _MsgBoxResult = MsgBoxResult.Yes
        End If
        If _MsgBoxResult = MsgBoxResult.Yes Then
            cboNetworks.Items.Remove(cboNetworks.SelectedItem)
            RemoveNetwork(FindNetworkIndex(msg))
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked")
        'End Try
    End Sub

    Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked
        'Try
        clsAnimate.Animate(frmAddNetwork, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked")
        'End Try
    End Sub

    Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click
        'Try
        Dim i As Integer
        i = FindServerIndexByIp(txtServer.Text)
        clsAnimate.Animate(frmEditServer, clsAnimate.Effect.Center, 200, 1)
        frmEditServer.SetServerInfo(i)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click")
        'End Try
    End Sub

    Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click
        Try
            Dim _MessageBoxResult As MsgBoxResult
            For Each _Item As Telerik.WinControls.UI.ListViewDataItem In lvwServers.SelectedItems
                If lIRC.iSettings.sPrompts = True Then
                    _MessageBoxResult = MsgBox("Are you sure you wish to remove '" & _Item.Text & "'?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                Else
                    _MessageBoxResult = MsgBoxResult.Yes
                End If
                If _MessageBoxResult = MsgBoxResult.Yes Then
                    lvwServers.Items.Remove(_Item)
                ElseIf _MessageBoxResult = MsgBoxResult.Cancel Then
                    Exit For
                End If
            Next _Item
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click")
        End Try
    End Sub

    Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click
        'Try
        clsAnimate.Animate(frmAddNetwork, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click")
        'End Try
    End Sub

    Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click
        'Try
        Dim _MsgBoxResult As MsgBoxResult
        If lIRC.iSettings.sPrompts = True Then
            _MsgBoxResult = MsgBox("Are you sure you wish to clear the irc servers for the network '" & cboNetworks.Text & "'?", vbYesNo)
            If _MsgBoxResult = MsgBoxResult.Yes Then lvwServers.Items.Clear()
        Else
            lvwServers.Items.Clear()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdClearServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearServers.Click")
        'End Try
    End Sub

    Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click
        'Try
        Dim f As frmChooseNetwork
        f = New frmChooseNetwork
        With f
            .SetServerToChange(FindServerIndexByIp(txtServer.Text))
            .SetNetworkIndex(FindNetworkIndex(cboNetworks.Text))
            .SetNetworkOpType(frmChooseNetwork.eNetworkOpType.nMoveNetwork)
            clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click")
        'End Try
    End Sub

    Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click
        'Try
        If chkNewStatus.Checked = True Then
            lStatus.Create(lIRC, lServers)
            Application.DoEvents()
        End If
        If lStatus.ActiveIndex() <> 0 Then
            EventApply()
            lStatus.ActiveStatusConnect()
        End If
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click")
        'End Try
    End Sub

    Private Sub cmdConnect_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub RadButton1_Click(sender As System.Object, e As System.EventArgs) Handles RadButton1.Click
        'Try
        Dim mbox As MsgBoxResult
        If chkNewStatus.Checked = True Then
            lStatus.Create(lIRC, lServers)
            Application.DoEvents()
        End If
        If lStatus.Connected(lStatus.ActiveIndex) = False Then
            EventApply()
            SaveSettings()
            Me.Close()
        Else
            If lIRC.iSettings.sPrompts = True Then
                mbox = MsgBox("You are currently connected on this status window, you will not be able to change the server settings if you continue, would you like to continue anyways?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
            Else
                mbox = MsgBoxResult.Yes
            End If
            If mbox = MsgBoxResult.Yes Then
                EventApply()
                SaveSettings()
                Me.Close()
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub RadButton1_Click(sender As System.Object, e As System.EventArgs) Handles RadButton1.Click")
        'End Try
    End Sub

    Private Sub cmdApplyNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyNow.Click
        'Try
        EventApply()
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdApplyNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyNow.Click")
        'End Try
    End Sub

    Private Sub cmdCancelNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNow.Click
        'Try
        clsAnimate.Animate(Me, clsAnimate.Effect.Center, 200, 1)
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message,"Private Sub cmdCancelNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNow.Click")
        'End Try
    End Sub

    Private Sub RadPageView1_SelectedPageChanged(sender As System.Object, e As System.EventArgs) Handles RadPageView1.SelectedPageChanged

    End Sub

    Private Sub cboNetworks_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        'Try
        lNetworks.nIndex = FindNetworkIndex(cboNetworks.Text)
        RefreshServers(False)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cboNetworks_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged")
        'End Try
    End Sub
End Class