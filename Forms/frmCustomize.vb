'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Imports nexIRC.Classes.UI
Imports nexIRC.IRC.Customize
Imports nexIRC.Modules
Public Class frmCustomize
    Public WithEvents lCustomize As New clsCustomize
    Public Sub ClearServers()
        lCustomize.ClearServers(lvwServers)
    End Sub
    Public ReadOnly Property ServersListView() As RadListView
        Get
            'Try
            Return lvwNotify
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public ReadOnly Property ServersListView() As RadListView")
            'Return Nothing
            'End Try
        End Get
    End Property
    Public Sub EventApply()
        'Try
        Dim i As Integer
        lIRC.iSettings.sMOTDInOwnWindow = chkMOTDInOwnWindow.Checked
        lIRC.iSettings.sNoticesInOwnWindow = chkNoticesInOwnWindow.Checked
        lIRC.iSettings.sShowRawWindow = chkShowRawWindow.Checked
        With lDCC
            .dDownloadDirectory = txtDownloadDirectory.Text
            '.dFileExistsAction = CType(cboDCCFileExists.SelectedIndex + 1, eDCCFileExistsAction)
            If optDccChatPrompt.IsChecked = True Then
                .dChatPrompt = eDCCPrompt.ePrompt
            ElseIf optDccChatAcceptAll.IsChecked = True Then
                .dChatPrompt = eDCCPrompt.eAcceptAll
            ElseIf optDccChatIgnore.IsChecked = True Then
                .dChatPrompt = eDCCPrompt.eIgnore
            End If
            If optDccSendPrompt.IsChecked = True Then
                .dSendPrompt = eDCCPrompt.ePrompt
            ElseIf optDccSendAcceptAll.IsChecked = True Then
                .dSendPrompt = eDCCPrompt.eAcceptAll
            ElseIf optDccSendIgnore.IsChecked = True Then
                .dSendPrompt = eDCCPrompt.eIgnore
            End If
            .dIgnorelist.dCount = 0
            .dAutoIgnore = chkAutoIgnoreExceptNotify.Checked
            .dAutoCloseDialogs = chkAutoCloseDialogs.Checked
            'If lstDCCIgnoreItems.Items.Count <> Nothing Then
            'If lstDCCIgnoreItems.Items.Count <> 0 Then
            'For i = 0 To lstDCCIgnoreItems.Items.Count - 1
            'If Len(lstDCCIgnoreItems.Items(i).ToString) <> 0 Then
            '.dIgnorelist.dCount = .dIgnorelist.dCount + 1
            '.dIgnorelist.dItem(.dIgnorelist.dCount).dData = lstDCCIgnoreItems.Items(i).ToString
            '.dIgnorelist.dItem(.dIgnorelist.dCount).dType = gDCCIgnoreType.dNicknames
            'End If
            'Next i
            'For i = 0 To lstIgnoreExtensions.Items.Count - 1
            'If Len(lstIgnoreExtensions.Items(i).ToString) <> 0 Then
            '.dIgnorelist.dCount = .dIgnorelist.dCount + 1
            '.dIgnorelist.dItem(.dIgnorelist.dCount).dData = lstIgnoreExtensions.Items(i).ToString
            '.dIgnorelist.dItem(.dIgnorelist.dCount).dType = gDCCIgnoreType.dFileTypes
            'End If
            'Next i
            'End If
            'End If
        End With
        With lIRC.iSettings.sStringSettings
            If rdbUnknownTextStatus.IsChecked = True Then
                .sUnknowns = eUnknownsIn.uStatusWindow
            ElseIf rdbUnknownTextOwn.IsChecked = True Then
                .sUnknowns = eUnknownsIn.uOwnWindow
            ElseIf rdbUnknownTextHide.IsChecked = True Then
                .sUnknowns = eUnknownsIn.uHide
            End If
            If rdbUnsupportedStatus.IsChecked = True Then
                .sUnsupported = eUnsupportedIn.uStatusWindow
            ElseIf rdbUnknownTextOwn.IsChecked = True Then
                .sUnsupported = eUnsupportedIn.uOwnWindow
            ElseIf rdbUnsupportedHide.IsChecked = True Then
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
        'lIRC.iNicks.nIndex = ReturnNickIndex(cboMyNickNames.Text)
        'lNetworks.nSelected = cboNetworks.SelectedItem
        'lNetworks.nIndex = FindNetworkIndex(cboNetworks.Text)
        lServers.sIndex = FindServerIndexByIp(lvwServers.SelectedItem.Item(1).ToString)
        With lIRC.iSettings
            .sAutoCloseSupportingWindows = chkAutoCloseSupportingWindows.Checked
            .sChannelFolderCloseOnJoin = chkCloseChannelFolder.Checked
            .sAutoAddToChannelFolder = chkAddToChannelFolder.Checked
            .sCloseWindowOnDisconnect = chkCloseStatusWindow.Checked
            .sAutoNavigateChannelUrls = chkBrowseChannelURLs.Checked
            .sShowUserAddresses = chkShowUserAddresses.Checked
            .sHideMOTD = chkHideMOTDs.Checked
            .sPrompts = chkShowPrompts.Checked
            .sExtendedMessages = chkExtendedMessages.Checked
            .sNoIRCMessages = chkNoIRCMessages.Checked
            .sCustomizeOnStartup = chkShowCustomize.Checked
            .sPopupChannelFolders = chkPopupChannelFolder.Checked
            .sChangeNickNameWindow = chkShowNicknameWindow.Checked
            .sShowBrowser = chkShowBrowser.Checked
            .sURL = txtURL.Text
            .sShowWindowsAutomatically = chkShowWindowsAutomatically.Checked
            .sTextSpeed = 10
            .sHammerTime = 10
            .sAutoMaximize = chkAutoMaximize.Checked
            .sHideStatusOnClose = chkHideStatusOnClose.Checked
            .sVideoBackground = chkVideoBackground.Checked
            .sAutoConnect = chkAutoConnect.Checked
            If lCustomize.lBrowserEnabled = True And .sShowBrowser = False Then
                mdiMain.CloseBrowser()
            ElseIf lCustomize.lBrowserEnabled = False And .sShowBrowser = True Then
                mdiMain.BrowseURL(lIRC.iSettings.sURL, False)
                mdiMain.ResizeBrowser()
            End If
        End With
        PopulateNotifyByListView(lvwNotify)
        i = lStatus.ActiveIndex()
        'lStatus.NickName(i, False) = cboMyNickNames.Text
        lStatus.Email(i) = lIRC.iEMail
        lStatus.Pass(i) = lIRC.iPass
        lStatus.RealName(i) = lIRC.iRealName
        lStatus.SetOperSettings(i, lIRC.iOperName, lIRC.iOperPass)
        If lStatus.Connected(i) = False Then
            lStatus.SetStatus(i)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub EventApply()")
        'End Try
    End Sub
    Private Sub InitSettings()
        'Try
        Dim i As Integer
        PopulateListViewWithStrings(lvwStrings)
        For i = 1 To lNetworks.nCount
            With lNetworks.nNetwork(i)
                cboNetworkNotify.Items.Add(.nDescription)
            End With
        Next i
        For i = 1 To lNotify.nCount
            With lNotify.nNotify(i)
                lCustomize.AddToNotifyListView(.nNickName, .nMessage, .nNetwork, lvwNotify)
            End With
        Next i
        For i = 1 To lIRC.iNicks.nCount
            With lIRC.iNicks.nNick(i)
                If Len(.nNick) <> 0 Then
                    cboMyNickNames.Items.Add(.nNick)
                End If
            End With
        Next i
        cboMyNickNames.Text = lIRC.iNicks.nNick(lIRC.iNicks.nIndex).nNick
        With lIRC.iSettings.sStringSettings
            Select Case .sUnknowns
                Case eUnknownsIn.uStatusWindow
                    rdbUnknownTextStatus.IsChecked = True
                Case eUnknownsIn.uOwnWindow
                    rdbUnknownTextOwn.IsChecked = True
                Case eUnknownsIn.uHide
                    rdbUnknownTextHide.IsChecked = True
            End Select
            Select Case .sUnsupported
                Case eUnsupportedIn.uStatusWindow
                    rdbUnsupportedStatus.IsChecked = True
                Case eUnsupportedIn.uOwnWindow
                    rdbUnsupportedOwn.IsChecked = True
                Case eUnsupportedIn.uHide
                    rdbUnsupportedHide.IsChecked = True
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
                    optDccChatPrompt.IsChecked = True
                Case eDCCPrompt.eAcceptAll
                    optDccChatAcceptAll.IsChecked = True
                Case eDCCPrompt.eIgnore
                    optDccChatIgnore.IsChecked = True
            End Select
            Select Case .dSendPrompt
                Case eDCCPrompt.ePrompt
                    optDccSendPrompt.IsChecked = True
                Case eDCCPrompt.eAcceptAll
                    optDccSendAcceptAll.IsChecked = True
                Case eDCCPrompt.eIgnore
                    optDccSendIgnore.IsChecked = True
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
            chkCloseChannelFolder.Checked = .sChannelFolderCloseOnJoin
            chkAddToChannelFolder.Checked = .sAutoAddToChannelFolder
            chkCloseStatusWindow.Checked = .sCloseWindowOnDisconnect
            chkBrowseChannelURLs.Checked = .sAutoNavigateChannelUrls
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
            chkShowUserAddresses.Checked = .sShowUserAddresses
            chkHideMOTDs.Checked = .sHideMOTD
            chkShowPrompts.Checked = .sPrompts
            chkExtendedMessages.Checked = .sExtendedMessages
            chkNoIRCMessages.Checked = .sNoIRCMessages
            chkShowCustomize.Checked = .sCustomizeOnStartup
            chkPopupChannelFolder.Checked = .sPopupChannelFolders
            chkShowNicknameWindow.Checked = .sChangeNickNameWindow
            chkShowBrowser.Checked = .sShowBrowser
            chkShowWindowsAutomatically.Checked = .sShowWindowsAutomatically
            chkAutoMaximize.Checked = .sAutoMaximize
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
            lCustomize.lBrowserEnabled = .sShowBrowser
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
        lServers.sIndex = Convert.ToInt32(clsFiles.ReadINI(lINI.iServers, "Settings", "Index", "0"))
        lCustomize.RefreshServers(lvwServers)
        chkMOTDInOwnWindow.Checked = lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = lIRC.iSettings.sShowRawWindow
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub InitSettings()")
        'End Try
    End Sub
    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lCustomize.frmCustomize_FormClosed()
    End Sub
    Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        lCustomize.Form_Load(Me, cmdCancelNow, lvwServers)
        InitSettings()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Private Sub lnkNetworkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNetworkAdd.Click
        lCustomize.lnkNetworkAdd_Click()
    End Sub
    Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerAdd.Click
        lCustomize.lnkAddServer_Click(cboNetworks.SelectedItem.Text)
    End Sub
    Private Sub cmdAddAlternateNickname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMyNickName.Click
        lCustomize.cmdAddNickName_Click()
    End Sub
    Private Sub cmdNotifyAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyAdd.Click
        lCustomize.cmdNotifyAdd_Click(lvwNotify)
    End Sub
    Private Sub cmdClearNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyClear.Click
        lCustomize.cmdClearNotify_Click(lvwNotify)
    End Sub
    Private Sub cmdEditString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditString.Click
        lCustomize.cmdEditString_Click(lvwStrings)
    End Sub
    Private Sub lvwNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwNotify.SelectedItemChanged
        lCustomize.lvwNotify_SelectedIndexChanged(lvwNotify, txtNotifyNickname, txtNotifyMessage, cboNetworkNotify)
    End Sub
    Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click
        'Try
        Dim f As New frmDCCIgnoreAdd
        f.optNickName.Checked = True
        f.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click")
        'End Try
    End Sub
    Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick
        'Try
        cmdEditString_Click(sender, e)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick")
        'End Try
    End Sub
    Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick
        'Try
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick")
        'End Try
    End Sub
    Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click
        'Try
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
            clsFiles.WriteINI(lINI.iDCC, "Settings", "IgnoreCount", Trim(c.ToString))
            For i = 1 To 100
                With lDCC.dIgnorelist.dItem(i)
                    If Len(lItems(i)) <> 0 Then
                        .dData = lItems(i)
                        clsFiles.WriteINI(lINI.iDCC, "Ignore", Trim(i.ToString), .dData)
                    Else
                        .dData = ""
                    End If
                End With
            Next i
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click")
        'End Try
    End Sub
    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        'Try
        frmNetworkSettings.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click")
        'End Try
    End Sub
    Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click
        'Try
        frmCompatibility.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click")
        'End Try
    End Sub
    Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyRemove.Click
        'Try
        'For Each _SelectedListViewItem As ListViewDataItem In lvwNotify.SelectedItems
        'lvwNotify.Items.Remove(_SelectedListViewItem)
        'Next _SelectedListViewItem
        lvwNotify.Items.Remove(lvwNotify.SelectedItem)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveNotify.Click")
        'End Try
    End Sub
    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIdentdEdit.Click
        'Try
        frmIdentdSettings.Show()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditIdentSettings.Click")
        'End Try
    End Sub
    Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click
        'Try
        lstIgnoreExtensions.Items.RemoveAt(lstIgnoreExtensions.SelectedIndex)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click")
        'End Try
    End Sub
    Private Sub cmdAddIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click
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
    Private Sub lvwServers_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwServers.DoubleClick
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
        Dim f As New frmSharedAdd
        f.lSharedAddType = frmSharedAdd.eSharedAddType.sAddNetwork
        'clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked")
        'End Try
    End Sub
    Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click
        'Try
        Dim i As Integer
        i = FindServerIndexByIp(lvwServers.SelectedItem.Item(1).ToString)
        If (i <> 0) Then
            clsAnimate.Animate(frmEditServer, clsAnimate.Effect.Center, 200, 1)
            frmEditServer.SetServerInfo(i)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click")
        'End Try
    End Sub
    Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click
        'Try
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click")
        'End Try
    End Sub
    Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click
        'Try
        clsAnimate.Animate(frmSharedAdd, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click")
        'End Try
    End Sub
    Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click
        lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
    End Sub
    Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click
        lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
    End Sub
    Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click
        If lCustomize.cmdConnectNow_Click(chkNewStatus.Checked, Me) Then
            EventApply()
        End If
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        If lCustomize.cmdOK_Click(chkNewStatus.Checked, Me) Then
            EventApply()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        'End Try
    End Sub
    Private Sub cmdApplyNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyNow.Click
        'Try
        EventApply()
        lCustomize.cmdApplyNow_Click(Me)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdApplyNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyNow.Click")
        'End Try
    End Sub
    Public Sub UpdateSelectedServer(_Description As String, _Ip As String, _Port As String)
        lCustomize.UpdateSelectedServer(lvwServers, _Description, _Ip, _Port)
    End Sub
    Private Sub cmdCancelNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNow.Click
        lCustomize.cmdCancelNow_Click(Me)
    End Sub
    Private Sub cboNetworks_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        If cboNetworks.SelectedItem IsNot Nothing Then lCustomize.cboNetworks_SelectedIndexChanged(cboNetworks.SelectedItem.Text, lvwServers)
    End Sub
    Private Sub cmdAddMyNickName_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddMyNickName.Click
        lCustomize.cmdAddNickName_Click()
    End Sub
    Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemoveMyNickName.Click
        lCustomize.cmdRemoveNickName(cboMyNickNames)
    End Sub
    Private Sub cmdClearMyNickName_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearMyNickName.Click
        lCustomize.cmdClearMyNickName_Click(cboMyNickNames)
    End Sub
    Private Sub cmdEditUserSettings_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditUserSettings.Click
        lCustomize.cmdEditUserSettings_Click()
    End Sub
    Private Sub cmdQuerySettings_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuerySettings.Click
        lCustomize.cmdQuerySettings_Click()
    End Sub
    Private Sub txtNotifyNickname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNotifyNickname.TextChanged
        lCustomize.txtNotifyNickname_TextChanged(txtNotifyNickname.Text, lvwNotify)
    End Sub
    Private Sub txtNotifyMessage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNotifyMessage.TextChanged
        lCustomize.txtNotifyMessage_TextChanged(txtNotifyMessage.Text, lvwNotify)
    End Sub
    Private Sub cboNetworkNotify_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworkNotify.SelectedIndexChanged
        lCustomize.txtNotifyNetwork_TextChanged(cboNetworkNotify.Text, lvwNotify)
    End Sub
End Class