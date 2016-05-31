'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.IRC.Customize
Imports nexIRC.Modules
Imports nexIRC.nexIRC.IRC.Settings.clsDCC
Imports nexIRC.Enum
Imports nexIRC.Business.Helpers
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
                textBufferSize
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
        For i = 0 To lSettings.lCompatibility.Count - 1
            If (lSettings.lCompatibility(i).Enabled = True) Then
                _ListViewItem = New ListViewDataItem()
                _ListViewItem.SubItems.Add(lSettings.lCompatibility(i).Description)
                _ListViewItem.SubItems.Add(lSettings.lCompatibility(i).Enabled.ToString())
                lvwCompatibility.Items.Add(_ListViewItem)
            End If
        Next i
        lvwCompatibility.SelectedIndex = 0
        lStrings.PopulateListViewWithStrings(lvwStrings)
        lSettings.FillRadComboWithNetworks(cboNetworkNotify, True)
        For i = 1 To lSettings.lNotify.nCount
            With lSettings.lNotify.nNotify(i)
                lCustomize.AddToNotifyListView(.nNickName, .nMessage, .nNetwork, lvwNotify)
            End With
        Next i
        For i = 1 To lSettings.lIRC.iNicks.nCount
            With lSettings.lIRC.iNicks.nNick(i)
                If (Not String.IsNullOrEmpty(.nNick)) Then
                    cboMyNickNames.Items.Add(.nNick)
                End If
            End With
        Next i
        cboMyNickNames.Text = lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick
        With lSettings.lIRC.iModes
            chkInvisible.Checked = .Invisible
            chkLocalOp.Checked = .LocalOperator
            chkOperator.Checked = .Operator
            chkRestricted.Checked = .Restricted
            chkServerNotices.Checked = .ServerNotices
            chkWallops.Checked = .Wallops
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
            chkPopupDownloadManager.Checked = lSettings_DCC.lDCC.dPopupDownloadManager
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
                        If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                    Case gDCCIgnoreType.dHostnames
                        If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                    Case gDCCIgnoreType.dFileTypes
                        If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstIgnoreExtensions.Items.Add(.dIgnorelist.dItem(i).dData)
                End Select
            Next i
        End With
        With lSettings.lIRC.iSettings
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
            'chkShowBrowser.Checked = .sShowBrowser
            chkShowWindowsAutomatically.Checked = .sShowWindowsAutomatically
            chkAutoMaximize.Checked = .sAutoMaximize
            chkAutoConnect.Checked = .sAutoConnect
            chkVideoBackground.Checked = .sVideoBackground
        End With
        If lSettings.lNetworks.Networks.Count <> 0 Then
            lSettings.FillRadComboWithNetworks(cboNetworks)
            lCustomize.lStartupNetwork = lSettings.lNetworks.Networks(lSettings.lNetworks.Index).Name
            lCustomize.RefreshServers(lvwServers, lSettings.lNetworks.Index)
        End If
        lSettings.lServers.Index = NativeMethods.ReadINIInt(lSettings.lINI.iServers, "Settings", "Index", 0)
        chkMOTDInOwnWindow.Checked = lSettings.lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = lSettings.lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = lSettings.lIRC.iSettings.sShowRawWindow
        With lSettings.lIRC
            txtUserEmail.Text = .iEMail
            txtPassword.Text = .iPass
            txtRealName.Text = .iRealName
            txtOperName.Text = .iOperName
            txtOperPassword.Text = .iOperPass
        End With
        Select Case lSettings.lIRC.iSettings.sStringSettings.sUnsupported
            Case UnsupportedIn.OwnWindow
                rdbUnsupportedOwn.IsChecked = True
            Case UnsupportedIn.Hide
                rdbUnsupportedHide.IsChecked = True
            Case UnsupportedIn.StatusWindow
                rdbUnsupportedStatus.IsChecked = True
        End Select
        Select Case lSettings.lIRC.iSettings.sStringSettings.sUnknowns
            Case [Enum].UnknownsIn.StatusWindow
                rdbUnknownTextStatus.IsChecked = True
            Case [Enum].UnknownsIn.Hide
                rdbUnknownTextHide.IsChecked = True
            Case [Enum].UnknownsIn.OwnWindow
                rdbUnknownTextOwn.IsChecked = True
        End Select
    End Sub
    Public Sub ClearServers()
        lCustomize.ClearServers(lvwServers)
    End Sub
    Public Sub UpdateSelectedServer(_Description As String, _Ip As String, _Port As String)
        lCustomize.UpdateSelectedServer(lvwServers, _Description, _Ip, _Port)
    End Sub
    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lCustomize.frmCustomize_FormClosed()
    End Sub
    Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lCustomize.Form_Load(Me, cmdCancelNow, lvwServers)
        InitSettings()
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
    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIdentdEdit.Click
        lCustomize.cmdEditIdentSettings_Click()
    End Sub
    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        lCustomize.cmdNetworkSettings_Click()
    End Sub
    Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked
        lCustomize.lnkNetworkDelete_LinkClicked(cboNetworks)
    End Sub
    Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked
        lCustomize.lnkNetworkAdd_LinkClicked()
    End Sub
    Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click
        lCustomize.cmdServerEdit_Click(lvwServers)
    End Sub
    Private Sub cmdServerDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerDelete.Click
        lCustomize.cmdServerDelete_Click(lvwServers)
    End Sub
    Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click
        lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
    End Sub
    Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click
        If (lvwServers.SelectedItem IsNot Nothing) Then
            lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
        End If
    End Sub
    Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click
        If lCustomize.cmdConnectNow_Click(chkNewStatus.Checked, Me) Then
            EventApply()
            lSettings.SaveSettings()
        End If
        Me.Close()
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        If lCustomize.cmdOK_Click(chkNewStatus.Checked, Me) Then
            EventApply()
        End If
        lSettings.SaveSettings()
        Me.Close()
    End Sub
    Private Sub cmdApplyNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyNow.Click
        EventApply()
        lCustomize.cmdApplyNow_Click(Me)
    End Sub
    Private Sub cmdCancelNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNow.Click
        lCustomize.cmdCancelNow_Click(Me)
    End Sub
    Private Sub cboNetworks_SelectedIndexChanged(sender As System.Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        lCustomize.cboNetworks_SelectedIndexChanged(lvwServers, cboNetworks.SelectedItem.Tag.ToString.ToInt)
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
    Private Sub cmdCompatibilityEnable_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompatibilityEnable.Click
        lCustomize.cmdCompatibilityEnable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
    End Sub
    Private Sub cmdCompatibilityDisable_Click(sender As Object, e As System.EventArgs) Handles cmdCompatibilityDisable.Click
        lCustomize.cmdCompatibilityDisable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
    End Sub
    Private Sub lCustomize_Close() Handles lCustomize.Close
        tmrCloseMe.Interval = 200
        tmrCloseMe.Enabled = True
    End Sub
    Private Sub lCustomize_Save() Handles lCustomize.Save
        lSettings.SaveSettings()
    End Sub
    Private Sub tmrCloseMe_Tick(sender As System.Object, e As System.EventArgs) Handles tmrCloseMe.Tick
        tmrCloseMe.Enabled = False
        Me.Close()
    End Sub
End Class