'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Imports nexIRC.Classes.UI
Imports nexIRC.IRC.Customize
Imports nexIRC.Modules
Imports nexIRC.nexIRC.IRC.Settings.clsDCC
Public Class frmCustomize
    Public WithEvents lCustomize As New clsCustomize
    Public Sub EventApply()
        'Try
        Dim _SelectedIndex As Integer = 0
        lCustomize.Apply_Servers(lvwServers, cboNetworks.Text)
        lCustomize.Apply_User(cboMyNickNames, txtURL.Text)
        lCustomize.Apply_Settings_Interface(
            chkShowPrompts.Checked,
            chkShowWindowsAutomatically.Checked,
            chkHideStatusOnClose.Checked,
            chkAutoMaximize.Checked,
            chkPopupChannelFolder.Checked,
            chkVideoBackground.Checked,
            chkShowNicknameWindow.Checked,
            chkCloseChannelFolder.Checked,
            chkAddToChannelFolder.Checked,
            chkBrowseChannelURLs.Checked,
            chkCloseStatusWindow.Checked,
            chkShowRawWindow.Checked,
            chkMOTDInOwnWindow.Checked,
            chkNoticesInOwnWindow.Checked
        )
        lCustomize.Apply_Settings_Startup(
            chkAutoConnect.Checked,
            chkShowCustomize.Checked,
            chkShowBrowser.Checked
        )
        lCustomize.Apply_Settings_Startup(
            chkAutoConnect.Checked,
            chkShowCustomize.Checked,
            chkShowBrowser.Checked
        )
        lCustomize.Apply_Settings_ServerModes(
            chkInvisible.Checked,
            chkWallops.Checked,
            chkRestricted.Checked,
            chkOperator.Checked,
            chkLocalOp.Checked,
            chkServerNotices.Checked
        )
        lCustomize.Apply_Settings_IRC(
            chkNoIRCMessages.Checked,
            chkExtendedMessages.Checked,
            chkShowUserAddresses.Checked,
            chkHideMOTDs.Checked
        )
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub EventApply()")
        'End Try
    End Sub
    Public Sub EventApply1()
        'Try
        'NETWORKS/SERVERS
        Dim i As Integer
        lIRC.iSettings.sMOTDInOwnWindow = chkMOTDInOwnWindow.Checked
        lIRC.iSettings.sNoticesInOwnWindow = chkNoticesInOwnWindow.Checked
        lIRC.iSettings.sShowRawWindow = chkShowRawWindow.Checked
        With lSettings_DCC.lDCC
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
            '.sServerInNotices = CBool(chkServerInNotices.Checked)
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
        'If lvwServers.SelectedItem.Item(1) <> Nothing then lServers.sIndex = FindServerIndexByIp(lvwServers.SelectedItem.Item(1).ToString)

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
            'chkServerInNotices.Checked = .sServerInNotices
        End With
        With lIRC.iModes
            chkInvisible.Checked = .mInvisible
            chkLocalOp.Checked = .mLocalOperator
            chkOperator.Checked = .mOperator
            chkRestricted.Checked = .mRestricted
            chkServerNotices.Checked = .mServerNotices
            chkWallops.Checked = .mWallops
        End With
        With lSettings_DCC.lDCC
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
            txtDownloadDirectory.Text = lSettings_DCC.lDCC.dDownloadDirectory
            chkAutoIgnoreExceptNotify.Checked = lSettings_DCC.lDCC.dAutoIgnore
            chkAutoCloseDialogs.Checked = lSettings_DCC.lDCC.dAutoCloseDialogs
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
            'chkCloseOnDisconnect.Checked = .sCloseOnDisconnect
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
            lCustomize.RefreshServers(lvwServers, lNetworks.nIndex)
        End If
        lServers.sIndex = Convert.ToInt32(clsFiles.ReadINI(lINI.iServers, "Settings", "Index", "0"))
        chkMOTDInOwnWindow.Checked = lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = lIRC.iSettings.sShowRawWindow
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub InitSettings()")
        'End Try
    End Sub
    Public Sub ClearServers()
        Try
            lCustomize.ClearServers(lvwServers)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ClearServers()")
        End Try
    End Sub
    Public Sub UpdateSelectedServer(_Description As String, _Ip As String, _Port As String)
        lCustomize.UpdateSelectedServer(lvwServers, _Description, _Ip, _Port)
    End Sub
    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        lCustomize.frmCustomize_FormClosed()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        'End Try
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
        lCustomize.cmdDCCIgnoreAdd_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click")
        'End Try
    End Sub
    Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick
        'Try
        lCustomize.lvwStrings_DoubleClick()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick")
        'End Try
    End Sub
    Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick
        'Try
        lCustomize.lstDCCIgnoreItems_MouseClick(lstDCCIgnoreItems)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick")
        'End Try
    End Sub
    Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click
        'Try
        lCustomize.cmdDCCIgnoreRemove_Click(lstDCCIgnoreItems)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click")
        'End Try
    End Sub
    Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click
        Try
            lCustomize.cmdCompatibility_Click()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCompatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibility.Click")
        End Try
    End Sub
    Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyRemove.Click
        'Try
        lCustomize.cmdRemoveNotify_Click(lvwNotify)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyRemove.Click")
        'End Try
    End Sub
    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIdentdEdit.Click
        'Try
        lCustomize.cmdEditIdentSettings_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIdentdEdit.Click")
        'End Try
    End Sub
    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        'Try
        lCustomize.cmdNetworkSettings_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click")
        'End Try
    End Sub
    Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked
        'Try
        lCustomize.lnkNetworkDelete_LinkClicked(cboNetworks)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked")
        'End Try
    End Sub
    Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked
        'Try
        lCustomize.lnkNetworkAdd_LinkClicked()
        'clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked")
        'End Try
    End Sub
    Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click
        'Try
        lCustomize.cmdServerEdit_Click(lvwServers)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click")
        'End Try
    End Sub
    Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click
        'Try
        lCustomize.cmdServerDelete_Click(lvwServers)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click")
        'End Try
    End Sub
    Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click
        'Try
        lCustomize.cmdServerAdd_Click()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServerAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerAdd.Click")
        'End Try
    End Sub
    Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click
        'Try
        lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click")
        'End Try
    End Sub
    Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click
        'Try
        lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click")
        'End Try
    End Sub
    Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click
        'Try
        If lCustomize.cmdConnectNow_Click(chkNewStatus.Checked, Me) Then
            EventApply()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click")
        'End Try
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        If lCustomize.cmdOK_Click(chkNewStatus.Checked, Me) Then
            EventApply()
        End If
        SaveSettings()
        Me.Close()
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
    Private Sub cmdCancelNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNow.Click
        lCustomize.cmdCancelNow_Click(Me)
    End Sub
    Private Sub cboNetworks_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        lCustomize.cboNetworks_SelectedIndexChanged(cboNetworks.SelectedItem.Text, lvwServers)
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
    Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click
        lCustomize.cmdRemoveIgnoreExtension_Click(lstIgnoreExtensions)
    End Sub
    Private Sub cmdAddIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click
        lCustomize.cmdAddIgnoreExtension_Click(lstIgnoreExtensions)
    End Sub
    Private Sub lstDCCIgnoreItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDCCIgnoreItems.Click
        lCustomize.lstDCCIgnoreItems_Click(cmdDCCIgnoreAdd)
    End Sub
    Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged
        lCustomize.lstIgnoreExtensions_SelectedIndexChanged(cmdDCCIgnoreRemove)
    End Sub
    Private Sub lvwServers_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwServers.DoubleClick
        lCustomize.lvwServers_DoubleClick(chkNewStatus, Me)
    End Sub
    Private Sub lCustomize_Apply() Handles lCustomize.Apply
        EventApply()
    End Sub
End Class