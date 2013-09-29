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
        lCustomize.Apply_Settings_Servers(lvwServers, cboNetworks.Text)
        lCustomize.Apply_Settings_User(cboMyNickNames,
            txtURL.Text,
            txtUserEmail.Text,
            txtPassword.Text,
            txtRealName.Text,
            txtOperName.Text,
            txtOperPassword.Text
        )
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
            False,
            chkCloseStatusWindow.Checked,
            chkShowRawWindow.Checked,
            chkMOTDInOwnWindow.Checked,
            chkNoticesInOwnWindow.Checked
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
        Dim i As Integer, _ListViewItem As ListViewDataItem
        For i = 1 To lCompatibility.cCount
            If (lCompatibility.cCompatibility(i).cEnabled = True) Then
                _ListViewItem = New ListViewDataItem()
                _ListViewItem.SubItems.Add(lCompatibility.cCompatibility(i).cDescription)
                _ListViewItem.SubItems.Add(lCompatibility.cCompatibility(i).cEnabled.ToString())
                lvwCompatibility.Items.Add(_ListViewItem)
            End If
        Next i
        lvwCompatibility.SelectedIndex = 0
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
            'chkBrowseChannelURLs.Checked = .sAutoNavigateChannelUrls
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
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
            chkHideStatusOnClose.Checked = .sHideStatusOnClose
            lCustomize.lBrowserEnabled = .sShowBrowser
            chkAutoConnect.Checked = .sAutoConnect
            chkVideoBackground.Checked = .sVideoBackground
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
            lCustomize.lStartupNetwork = lNetworks.nNetwork(lNetworks.nIndex).nDescription
            lCustomize.RefreshServers(lvwServers, lNetworks.nIndex)
        End If
        lServers.sIndex = Convert.ToInt32(clsFiles.ReadINI(lINI.iServers, "Settings", "Index", "0"))
        chkMOTDInOwnWindow.Checked = lIRC.iSettings.sMOTDInOwnWindow
        chkNoticesInOwnWindow.Checked = lIRC.iSettings.sNoticesInOwnWindow
        chkShowRawWindow.Checked = lIRC.iSettings.sShowRawWindow
        With lIRC
            txtUserEmail.Text = .iEMail
            txtPassword.Text = .iPass
            txtRealName.Text = .iRealName
            txtOperName.Text = .iOperName
            txtOperPassword.Text = .iOperPass
        End With
        Select Case lIRC.iSettings.sStringSettings.sUnsupported
            Case eUnsupportedIn.uOwnWindow
                rdbUnsupportedOwn.IsChecked = True
            Case eUnsupportedIn.uHide
                rdbUnsupportedHide.IsChecked = True
            Case eUnsupportedIn.uStatusWindow
                rdbUnsupportedStatus.IsChecked = True
        End Select
        Select Case lIRC.iSettings.sStringSettings.sUnknowns
            Case eUnknownsIn.uStatusWindow
                rdbUnknownTextStatus.IsChecked = True
            Case eUnknownsIn.uHide
                rdbUnknownTextHide.IsChecked = True
            Case eUnknownsIn.uOwnWindow
                rdbUnknownTextOwn.IsChecked = True
        End Select
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
        'Try
        If (cboNetworks.SelectedItem IsNot Nothing) Then
            lCustomize.lnkAddServer_Click(cboNetworks.SelectedItem.Text)
        Else
            lCustomize.lnkAddServer_Click("")
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerAdd.Click")
        'End Try
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
    Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click
        'Try
        lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdServersClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersClear.Click")
        'End Try
    End Sub
    Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click
        'Try
        If (lvwServers.SelectedItem IsNot Nothing) Then
            lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
        End If
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
End Class