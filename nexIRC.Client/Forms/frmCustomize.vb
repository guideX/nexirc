Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.IRC.Customize
Imports nexIRC.Client.nexIRC.Client
Imports nexIRC.Client.nexIRC.Client.IRC.Settings.Settings

Public Class frmCustomize
    Public WithEvents lCustomize As New clsCustomize

    Public Sub EventApply()
        Dim textBufferSize As Integer
        If (IsNumeric(txtTextBufferSize.Text)) Then
            textBufferSize = Convert.ToInt32(txtTextBufferSize.Text)
        End If
        lCustomize.Apply_Settings_Servers(lvwServers, cboNetworks.Text)
        lCustomize.Apply_Settings_User(cboMyNickNames,
                "",
                txtUserEmail.Text,
                txtPassword.Text,
                txtRealName.Text,
                txtOperName.Text,
                txtOperPassword.Text
            )
        lCustomize.Apply_Settings_Interface(
                chkShowPrompts.Checked,
                chkShowWindowsAutomatically.Checked,
                chkAutoMaximize.Checked,
                chkPopupChannelFolder.Checked,
                chkVideoBackground.Checked,
                chkShowNicknameWindow.Checked,
                chkCloseChannelFolder.Checked,
                chkAddToChannelFolder.Checked,
                False,
                chkCloseStatusWindow.Checked,
                chkShowRawWindow.Checked,
                chkMOTDInOwnWindow.Checked,
                chkNoticesInOwnWindow.Checked,
                textBufferSize,
                chkAutoSelectAlternateNickname.Checked
            )
        lCustomize.Apply_Settings_Startup(
                chkAutoConnect.Checked,
                chkShowCustomize.Checked,
                False
            )
        lCustomize.Apply_Settings_Startup(
                chkAutoConnect.Checked,
                chkShowCustomize.Checked,
                False
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
        lCustomize.Apply_Settings_Text(rdbUnknownTextStatus.IsChecked,
                rdbUnknownTextOwn.IsChecked,
                rdbUnknownTextHide.IsChecked,
                rdbUnsupportedStatus.IsChecked,
                rdbUnsupportedOwn.IsChecked,
                rdbUnsupportedHide.IsChecked
            )
        lCustomize.Apply_Settings_DCC(optDccChatPrompt.IsChecked,
                optDccChatAcceptAll.IsChecked,
                optDccChatIgnore.IsChecked,
                optDccSendPrompt.IsChecked,
                optDccSendAcceptAll.IsChecked,
                optDccSendIgnore.IsChecked,
                chkAutoCloseDialogs.Checked,
                chkAutoIgnoreExceptNotify.Checked,
                chkPopupDownloadManager.Checked,
                txtDownloadDirectory.Text
            )
    End Sub

    Public ReadOnly Property ServersListView() As RadListView
        Get
            Return lvwNotify
        End Get
    End Property

    Private Sub InitSettings()
        Dim i As Integer, _ListViewItem As ListViewDataItem
        For i = 1 To Modules.lSettings.lCompatibility.cCount
            If (Modules.lSettings.lCompatibility.cCompatibility(i).cEnabled = True) Then
                _ListViewItem = New ListViewDataItem()
                _ListViewItem.SubItems.Add(Modules.lSettings.lCompatibility.cCompatibility(i).cDescription)
                _ListViewItem.SubItems.Add(Modules.lSettings.lCompatibility.cCompatibility(i).cEnabled.ToString())
                lvwCompatibility.Items.Add(_ListViewItem)
            End If
        Next i
        lvwCompatibility.SelectedIndex = 0
        Modules.lStrings.PopulateListViewWithStrings(lvwStrings)
        'For i = 1 To Modules.lSettings.lNetworks.nCount
        'With Modules.lSettings.lNetworks.nNetwork(i)
        'cboNetworkNotify.Items.Add(.nDescription)
        'End With
        'Next i
        Dim networks = Modules.IrcSettings.IrcNetworks.Get()
        For Each network In networks
            cboNetworkNotify.Items.Add(network.Description)
        Next network
        For i = 1 To Modules.lSettings.lNotify.nCount
            With Modules.lSettings.lNotify.nNotify(i)
                lCustomize.AddToNotifyListView(.nNickName, .nMessage, .nNetwork, lvwNotify)
            End With
        Next i
        For i = 1 To Modules.lSettings.lIRC.iNicks.nCount
            With Modules.lSettings.lIRC.iNicks.nNick(i)
                If (Not String.IsNullOrEmpty(.nNick)) Then
                    cboMyNickNames.Items.Add(.nNick)
                End If
            End With
        Next i
        cboMyNickNames.Text = Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick
        With Modules.lSettings.lIRC.iModes
            chkInvisible.Checked = .mInvisible
            chkLocalOp.Checked = .mLocalOperator
            chkOperator.Checked = .mOperator
            chkRestricted.Checked = .mRestricted
            chkServerNotices.Checked = .mServerNotices
            chkWallops.Checked = .mWallops
        End With
        With Modules.lSettings_DCC
            Select Case .ChatPrompt
                Case DccPrompt.Prompt
                    optDccChatPrompt.IsChecked = True
                Case DccPrompt.AcceptAll
                    optDccChatAcceptAll.IsChecked = True
                Case DccPrompt.Ignore
                    optDccChatIgnore.IsChecked = True
            End Select
            Select Case .SendPrompt
                Case DccPrompt.Prompt
                    optDccSendPrompt.IsChecked = True
                Case DccPrompt.AcceptAll
                    optDccSendAcceptAll.IsChecked = True
                Case DccPrompt.Ignore
                    optDccSendIgnore.IsChecked = True
            End Select
            txtDownloadDirectory.Text = Modules.lSettings_DCC.dDownloadDirectory
            chkAutoIgnoreExceptNotify.Checked = Modules.lSettings_DCC.dAutoIgnore
            chkAutoCloseDialogs.Checked = Modules.lSettings_DCC.dAutoCloseDialogs
            chkPopupDownloadManager.Checked = Modules.lSettings_DCC.dPopupDownloadManager
            Select Case .FileExistsAction
                Case DccFileExistsAction.Prompt
                    cboDCCFileExists.SelectedIndex = 0
                Case DccFileExistsAction.Overwrite
                    cboDCCFileExists.SelectedIndex = 1
                Case DccFileExistsAction.Ignore
                    cboDCCFileExists.SelectedIndex = 2
            End Select
            For i = 1 To .IgnoreList.Count
                Dim ignoreListItem = .IgnoreList.Items.ElementAtOrDefault(i)
                If (ignoreListItem IsNot Nothing) Then
                    Select Case ignoreListItem.Type
                        Case DCCIgnoreType.Nicknames
                            If (Not String.IsNullOrEmpty(ignoreListItem.Data)) Then lstDCCIgnoreItems.Items.Add(ignoreListItem.Data)
                        Case DCCIgnoreType.Hostnames
                            If (Not String.IsNullOrEmpty(ignoreListItem.Data)) Then lstDCCIgnoreItems.Items.Add(ignoreListItem.Data)
                        Case DCCIgnoreType.FileTypes
                            If (Not String.IsNullOrEmpty(ignoreListItem.Data)) Then lstIgnoreExtensions.Items.Add(ignoreListItem.Data)
                    End Select
                End If
            Next i
        End With
        With Modules.lSettings.lIRC.iSettings
            txtTextBufferSize.Text = .sTextBufferSize.ToString()
            'txtURL.Text = .sURL
            chkCloseChannelFolder.Checked = .sChannelFolderCloseOnJoin
            chkAddToChannelFolder.Checked = .sAutoAddToChannelFolder
            chkCloseStatusWindow.Checked = .sCloseWindowOnDisconnect
            'chkBrowseChannelURLs.Checked = .sAutoNavigateChannelUrls
            chkShowUserAddresses.Checked = .sShowUserAddresses
            chkHideMOTDs.Checked = .sHideMOTD
            chkShowPrompts.Checked = .sPrompts
            chkExtendedMessages.Checked = .sExtendedMessages
            chkNoIRCMessages.Checked = .sNoIRCMessages
            chkShowCustomize.Checked = .sCustomizeOnStartup
            chkPopupChannelFolder.Checked = .sPopupChannelFolders
            chkShowNicknameWindow.Checked = .sChangeNickNameWindow
            chkAutoSelectAlternateNickname.Checked = .sAutoSelectAlternateNickname
            chkShowWindowsAutomatically.Checked = .sShowWindowsAutomatically
            chkAutoMaximize.Checked = .sAutoMaximize
            chkAutoConnect.Checked = .sAutoConnect
            chkVideoBackground.Checked = .sVideoBackground
        End With
        If (networks.Count <> 0) Then
            For Each network In networks
                If (Not String.IsNullOrEmpty(network.Description)) Then
                    cboNetworks.Items.Add(network.Description)
                    cboNetworks.Text = Modules.IrcSettings.IrcNetworks.GetDefault().Description
                    lCustomize.RefreshServers(lvwServers, Modules.IrcSettings.IrcNetworks.GetDefault().Id)
                End If
            Next
        End If
        'If Modules.lSettings.lNetworks.nCount <> 0 Then
        'For i = 1 To Modules.lSettings.lNetworks.nCount
        'With Modules.lSettings.lNetworks.nNetwork(i)
        'If (Not String.IsNullOrEmpty(.nDescription)) Then
        'cboNetworks.Items.Add(.nDescription)
        'End If
        'End With
        'Next i
        'cboNetworks.Text = Modules.lSettings.lNetworks.nNetwork(Modules.lSettings.lNetworks.nIndex).nDescription
        'lCustomize.lStartupNetwork = Modules.lSettings.lNetworks.nNetwork(Modules.lSettings.lNetworks.nIndex).nDescription
        'lCustomize.RefreshServers(lvwServers, Modules.lSettings.lNetworks.nIndex)
        'End If
        Modules.lSettings.lServers.sIndex = Convert.ToInt32(IniFileHelper.ReadINI(Modules.lSettings.lINI.iServers, "Settings", "Index", "0"))
        chkMOTDInOwnWindow.Checked = Modules.lSettings.lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = Modules.lSettings.lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = Modules.lSettings.lIRC.iSettings.sShowRawWindow
        With Modules.lSettings.lIRC
            txtUserEmail.Text = .iEMail
            txtPassword.Text = .iPass
            txtRealName.Text = .iRealName
            txtOperName.Text = .iOperName
            txtOperPassword.Text = .iOperPass
        End With
        Select Case Modules.lSettings.lIRC.iSettings.sStringSettings.sUnsupported
            Case UnsupportedIn.OwnWindow
                rdbUnsupportedOwn.IsChecked = True
            Case UnsupportedIn.Hide
                rdbUnsupportedHide.IsChecked = True
            Case UnsupportedIn.StatusWindow
                rdbUnsupportedStatus.IsChecked = True
        End Select
        Select Case Modules.lSettings.lIRC.iSettings.sStringSettings.sUnknowns
            Case eUnknownsIn.uStatusWindow
                rdbUnknownTextStatus.IsChecked = True
            Case eUnknownsIn.uHide
                rdbUnknownTextHide.IsChecked = True
            Case eUnknownsIn.uOwnWindow
                rdbUnknownTextOwn.IsChecked = True
        End Select
    End Sub

    Public Sub ClearServers()
        lCustomize.ClearServers(lvwServers)
    End Sub

    Public Sub UpdateSelectedServer(ByVal _Description As String, ByVal _Ip As String, ByVal _Port As String)
        lCustomize.UpdateSelectedServer(lvwServers, _Description, _Ip, _Port)
    End Sub

    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lCustomize.frmCustomize_FormClosed()
    End Sub

    Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lCustomize.Form_Load(Me, cmdCancelNow, lvwServers)
        InitSettings()
        With Modules.lSettings.lIRC.iIdent
            txtIdentdPort.Text = .iPort.ToString
            txtIdentdSystem.Text = .iSystem
            txtIdentdUserID.Text = .iUserID
            chkIdentdEnabled.Checked = .iSettings.iEnabled
        End With
        Me.Width = 551
        Me.Height = 448
    End Sub

    Private Sub lnkNetworkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNetworkAdd.Click
        lCustomize.lnkNetworkAdd_Click()
    End Sub

    Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerAdd.Click
        If (cboNetworks.SelectedItem IsNot Nothing) Then
            lCustomize.lnkAddServer_Click(cboNetworks.SelectedItem.Text)
        Else
            lCustomize.lnkAddServer_Click("")
        End If
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
        lCustomize.cmdDCCIgnoreAdd_Click()
    End Sub

    Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick
        lCustomize.lstDCCIgnoreItems_MouseClick(lstDCCIgnoreItems)
    End Sub

    Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click
        lCustomize.cmdDCCIgnoreRemove_Click(lstDCCIgnoreItems)
    End Sub

    Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyRemove.Click
        lCustomize.cmdRemoveNotify_Click(lvwNotify)
    End Sub

    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lCustomize.cmdEditIdentSettings_Click()
    End Sub

    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        lCustomize.cmdNetworkSettings_Click()
    End Sub

    Private Sub lnkNetworkDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked
        lCustomize.lnkNetworkDelete_LinkClicked(cboNetworks)
    End Sub

    Private Sub lnkNetworkAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked
        lCustomize.lnkNetworkAdd_LinkClicked()
    End Sub

    Private Sub cmdServerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerEdit.Click
        lCustomize.cmdServerEdit_Click(lvwServers)
    End Sub

    Private Sub cmdServerDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerDelete.Click
        lCustomize.cmdServerDelete_Click(lvwServers)
    End Sub

    Private Sub cmdServersClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServersClear.Click
        lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
    End Sub

    Private Sub cmdServersMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServersMove.Click
        If (lvwServers.SelectedItem IsNot Nothing) Then
            lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
        End If
    End Sub

    Private Sub cmdConnectNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnectNow.Click
        If lCustomize.cmdConnectNow_Click(chkNewStatus.Checked, Me) Then
            With Modules.lSettings.lIRC.iIdent
                .iPort = CType(txtIdentdPort.Text, Integer)
                .iSettings.iEnabled = chkIdentdEnabled.Checked
                .iSystem = txtIdentdSystem.Text
                .iUserID = txtIdentdUserID.Text
            End With
            EventApply()
            Modules.lSettings.SaveSettings()
        End If
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If lCustomize.cmdOK_Click(chkNewStatus.Checked, Me) Then
            With Modules.lSettings.lIRC.iIdent
                .iPort = CType(txtIdentdPort.Text, Integer)
                .iSettings.iEnabled = chkIdentdEnabled.Checked
                .iSystem = txtIdentdSystem.Text
                .iUserID = txtIdentdUserID.Text
            End With
            EventApply()
        End If
        Modules.lSettings.SaveSettings()
        Me.Close()
    End Sub

    Private Sub cmdApplyNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyNow.Click
        With Modules.lSettings.lIRC.iIdent
            .iPort = CType(txtIdentdPort.Text, Integer)
            .iSettings.iEnabled = chkIdentdEnabled.Checked
            .iSystem = txtIdentdSystem.Text
            .iUserID = txtIdentdUserID.Text
        End With
        EventApply()
        lCustomize.cmdApplyNow_Click(Me)
    End Sub

    Private Sub cmdCancelNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelNow.Click
        lCustomize.cmdCancelNow_Click(Me)
    End Sub

    Private Sub cboNetworks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        lCustomize.cboNetworks_SelectedIndexChanged(cboNetworks.SelectedItem.Text, lvwServers)
    End Sub

    Private Sub cmdAddMyNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMyNickName.Click
        lCustomize.cmdAddNickName_Click()
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveMyNickName.Click
        lCustomize.cmdRemoveNickName(cboMyNickNames)
    End Sub

    Private Sub cmdClearMyNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMyNickName.Click
        lCustomize.cmdClearMyNickName_Click(cboMyNickNames)
    End Sub

    Private Sub cmdQuerySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuerySettings.Click
        lCustomize.cmdQuerySettings_Click()
    End Sub

    Private Sub txtNotifyNickname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotifyNickname.TextChanged
        lCustomize.txtNotifyNickname_TextChanged(txtNotifyNickname.Text, lvwNotify)
    End Sub

    Private Sub txtNotifyMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotifyMessage.TextChanged
        lCustomize.txtNotifyMessage_TextChanged(txtNotifyMessage.Text, lvwNotify)
    End Sub

    Private Sub cboNetworkNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworkNotify.SelectedIndexChanged
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

    Private Sub lvwServers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwServers.DoubleClick
        lCustomize.lvwServers_DoubleClick(chkNewStatus, Me)
    End Sub

    Private Sub lCustomize_Apply() Handles lCustomize.Apply
        EventApply()
    End Sub

    Private Sub cmdCompatibilityEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibilityEnable.Click
        lCustomize.cmdCompatibilityEnable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
    End Sub

    Private Sub cmdCompatibilityDisable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCompatibilityDisable.Click
        lCustomize.cmdCompatibilityDisable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
    End Sub

    Private Sub lCustomize_Close() Handles lCustomize.Close
        tmrCloseMe.Interval = 200
        tmrCloseMe.Enabled = True
    End Sub

    Private Sub lCustomize_Save() Handles lCustomize.Save
        Modules.lSettings.SaveSettings()
    End Sub

    Private Sub tmrCloseMe_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCloseMe.Tick
        tmrCloseMe.Enabled = False
        Me.Close()
    End Sub
End Class