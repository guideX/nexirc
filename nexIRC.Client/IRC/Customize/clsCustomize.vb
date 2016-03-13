Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.Client
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows.clsSharedAdd
Imports nexIRC.Client.nexIRC.Client.IRC.Settings.Settings

Namespace nexIRC.IRC.Customize
    Public Class clsCustomize
        Public Event Apply()
        Public Event Save()
        Public Event Close()
        Public lStartupNetwork As String

        Public Sub cmdDCCIgnoreAdd_Click()
            Dim f As New frmDccIgnoreAdd
            f.optNickName.IsChecked = True
            f.Show()
        End Sub

        Public Sub lstDCCIgnoreItems_MouseClick(ByVal _ListBox As RadListControl)
            Dim msg As String
            If _ListBox.SelectedIndex = -1 Then
                Exit Sub
            End If
            msg = Trim(_ListBox.SelectedItem.ToString)
            If InStr(Err.Description, "Object reference not set to an instance of an object.") <> 0 Then
                Err.Clear()
                Exit Sub
            End If
            If Len(msg) <> 0 Then _ListBox.Enabled = True
        End Sub

        Public Sub cmdDCCIgnoreRemove_Click(ByVal _ListBox As RadListControl)
            Dim lItems() As String, i As Integer, c As Integer, msg As String
            msg = _ListBox.SelectedItem.ToString
            If InStr(Err.Description, "Object reference not set to an instance of an object.") <> 0 Then
                Err.Clear()
                Exit Sub
            End If
            If Len(Trim(msg)) <> 0 Then
                _ListBox.Items.Remove(_ListBox.SelectedItem)
                ReDim lItems(100)
                For i = 1 To Modules.lSettings_DCC.IgnoreList.Count
                    With Modules.lSettings_DCC.IgnoreList.Items(i)
                        If LCase(Trim(.Data)) = LCase(Trim(msg)) Then
                            .Data = ""
                        Else
                            If Len(.Data) <> 0 Then
                                c = c + 1
                                lItems(c) = .Data
                            End If
                        End If
                    End With
                Next i
                Modules.lSettings_DCC.IgnoreList.Count = c
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(c.ToString))
                For i = 1 To 100
                    With Modules.lSettings_DCC.IgnoreList.Items(i)
                        If Len(lItems(i)) <> 0 Then
                            .Data = lItems(i)
                            IniFileHelper.WriteINI(Modules.lSettings.lINI.iDCC, "Ignore", Trim(i.ToString), .Data)
                        Else
                            .Data = ""
                        End If
                    End With
                Next i
            End If
        End Sub

        Public Sub cmdNetworkSettings_Click()
            frmNetworkSettings.Show()
        End Sub

        Public Sub cmdCompatibilityEnable_Click(ByVal _Name As String, ByVal _ListItem As ListViewDataItem)
            For i As Integer = 1 To Modules.lSettings.lCompatibility.cCount
                If Modules.lSettings.lCompatibility.cCompatibility(i).cDescription = _Name Then
                    Modules.lSettings.lCompatibility.cCompatibility(i).cEnabled = True
                    _ListItem.Item(1) = "True"
                    Exit For
                End If
            Next i
        End Sub

        Public Sub cmdCompatibilityDisable_Click(ByVal _Name As String, ByVal _ListItem As ListViewDataItem)
            For i As Integer = 1 To Modules.lSettings.lCompatibility.cCount
                If Modules.lSettings.lCompatibility.cCompatibility(i).cDescription = _Name Then
                    Modules.lSettings.lCompatibility.cCompatibility(i).cEnabled = False
                    _ListItem.Item(1) = "False"
                    Exit For
                End If
            Next i
        End Sub

        Public Sub cmdRemoveNotify_Click(ByVal _NotifyListView As RadListView)
            _NotifyListView.Items.Remove(_NotifyListView.SelectedItem)
        End Sub

        Public Sub cmdEditIdentSettings_Click()
            frmIdentdSettings.Show()
        End Sub

        Public Sub cmdRemoveIgnoreExtension_Click(ByVal _ListBox As RadListControl)
            _ListBox.Items.RemoveAt(_ListBox.SelectedIndex)
        End Sub

        Public Sub cmdAddIgnoreExtension_Click(ByVal _ListBox As RadListControl)
            Dim msg As String = InputBox("Add Ignore Extension")
            If Len(msg) <> 0 Then
                _ListBox.Items.Add(msg)
            Else
                If Modules.lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
            End If
        End Sub

        Public Sub lstDCCIgnoreItems_Click(ByVal _Button As RadButton)
            _Button.Enabled = True
        End Sub

        Public Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal _RemoveButton As RadButton)
            _RemoveButton.Enabled = True
        End Sub

        Public Sub lvwServers_DoubleClick(ByVal _CheckBox As RadCheckBox, ByVal _Form As Form)
            If _CheckBox.Checked = True Then
                Modules.lStatus.Create(Modules.IrcSettings, Modules.lSettings.lServers)
                Application.DoEvents()
            End If
            If Modules.lStatus.ActiveIndex() <> 0 Then
                RaiseEvent Apply()
                RaiseEvent Save()
                Modules.lStatus.ActiveStatusConnect()
            End If
            RaiseEvent Close()
        End Sub

        Public Sub lnkNetworkDelete_LinkClicked(ByVal _DropDownList As RadDropDownList)
            Dim _MsgBoxResult As MsgBoxResult, msg As String
            msg = _DropDownList.SelectedItem.ToString
            If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                _MsgBoxResult = MsgBox("Really, delete '" & msg & "'?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            Else
                _MsgBoxResult = MsgBoxResult.Yes
            End If
            If _MsgBoxResult = MsgBoxResult.Yes Then
                _DropDownList.Items.Remove(_DropDownList.SelectedItem)
                Modules.IrcSettings.IrcNetworks.Delete(Modules.IrcSettings.IrcNetworks.Find(msg))
            End If
        End Sub

        Public Sub lnkNetworkAdd_LinkClicked()
            Dim f As New frmSharedAdd
            f.lSharedAddUI.SharedAddType = Business.Enums.SharedAddType.AddNetwork
        End Sub

        Public Sub cmdServerEdit_Click(ByVal _ListView As RadListView)
            Dim i As Integer
            If (_ListView.SelectedItem IsNot Nothing) Then
                i = Modules.lSettings.FindServerIndexByIp(_ListView.SelectedItem.Item(1).ToString)
                If (i <> 0) Then
                    frmEditServer.Show()
                    frmEditServer.SetServerInfo(i)
                End If
            End If
        End Sub

        Public Sub cmdServerDelete_Click(ByVal _ListView As RadListView)
            Dim _MessageBoxResult As MsgBoxResult
            For Each _Item As Telerik.WinControls.UI.ListViewDataItem In _ListView.SelectedItems
                If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                    _MessageBoxResult = MsgBox("Are you sure you wish to remove '" & _Item.Text & "'?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                Else
                    _MessageBoxResult = MsgBoxResult.Yes
                End If
                If _MessageBoxResult = MsgBoxResult.Yes Then
                    _ListView.Items.Remove(_Item)
                ElseIf _MessageBoxResult = MsgBoxResult.Cancel Then
                    Exit For
                End If
            Next _Item
        End Sub

        Public Sub cmdServerAdd_Click()
            Dim f As frmAddServer
            f = New frmAddServer()
            f.Show()
        End Sub

        Public Sub UpdateSelectedServer(ByVal _ServerListView As RadListView, ByVal _Description As String, ByVal _Ip As String, ByVal _Port As String)
            If (_ServerListView.SelectedItem IsNot Nothing) Then
                _ServerListView.SelectedItem.Item(0) = _Description
                _ServerListView.SelectedItem.Item(1) = _Ip
                _ServerListView.SelectedItem.Item(2) = _Port
            End If
        End Sub

        Public Sub lvwNotify_SelectedIndexChanged(ByVal _NotifyListView As RadListView, ByVal _NotifyNickNameTextBox As RadTextBox, ByVal _NotifyMessageTextBox As RadTextBox, ByVal _NetworkNotifyDropDownList As RadDropDownList)
            Dim i As Integer, n As Integer
            For i = 0 To _NotifyListView.SelectedItems.Count - 1
                n = Modules.lSettings.FindNotifyIndex(_NotifyListView.SelectedItems(i).Text)
                _NotifyNickNameTextBox.Text = Modules.lSettings.lNotify.nNotify(n).nNickName
                _NotifyMessageTextBox.Text = Modules.lSettings.lNotify.nNotify(n).nMessage
                _NetworkNotifyDropDownList.SelectedItem = _NetworkNotifyDropDownList.Items(General.FindRadComboIndex(_NetworkNotifyDropDownList, Modules.lSettings.lNotify.nNotify(n).nNetwork))
                Exit For
            Next i
        End Sub

        Public Sub cmdEditString_Click(ByVal _StringsListView As RadListView)
            Dim lItem As ListViewDataItem, f As frmEditString, i As Integer, msg As String, n As Integer
            lItem = New ListViewDataItem
            If _StringsListView.SelectedItems.Count <> 0 Then
                For i = 0 To _StringsListView.SelectedItems.Count
                    lItem = _StringsListView.SelectedItems(i)
                    Exit For
                Next i
                f = New frmEditString
                f.Show()
                f.txtDescription.Text = lItem.Text
                f.txtSupport.Text = lItem.Item(1).ToString '  .SubItems(1).Text
                f.txtSyntax.Text = lItem.Item(2).ToString
                f.cboNumeric.Text = lItem.Item(3).ToString
                f.txtData.Text = lItem.Item(4).ToString
                n = Modules.lStrings.FindStringIndexByDescription(lItem.Text)
                For i = 1 To 6
                    msg = IniFileHelper.ReadINI(Modules.lSettings.lINI.iText, Trim(Convert.ToString(n)), "Find" & Trim(Str(i)), "")
                    If Len(msg) <> 0 Then f.lstParameters.Items.Add(msg)
                Next i
            End If
        End Sub

        Public Sub cmdServersClear_Click(ByVal _Network As String, ByVal _RadListView As RadListView)
            Dim _MsgBoxResult As MsgBoxResult
            If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                _MsgBoxResult = MsgBox("Are you sure you wish to clear the irc servers for the network '" & _Network & "'?", vbYesNo)
                If _MsgBoxResult = MsgBoxResult.Yes Then _RadListView.Items.Clear()
            Else
                _RadListView.Items.Clear()
            End If
        End Sub

        Public Sub cmdServersMove_Click(ByVal _Network As String, ByVal _Server As String)
            Dim f As frmChooseNetwork
            f = New frmChooseNetwork
            With f
                .lChooseNetwork.lNetworkIndex = Modules.IrcSettings.IrcNetworks.Find(_Network).ID
                .lChooseNetwork.lServerToChange = Modules.lSettings.FindServerIndexByIp(_Server)
                f.Show()
            End With
        End Sub

        Public Function cmdConnectNow_Click(ByVal newStatus As Boolean, ByVal form As Form) As Boolean
            Dim result As Boolean
            result = False
            If (newStatus = True) Then
                Modules.lStatus.Create(Modules.IrcSettings, Modules.lSettings.lServers)
                Application.DoEvents()
            End If
            If Modules.lStatus.ActiveIndex() <> 0 Then
                result = True
                Modules.lStatus.ActiveStatusConnect()
            End If
            form.Close()
            Return result
        End Function

        Public Function cmdOK_Click(ByVal _NewStatus As Boolean, ByVal _Form As Form) As Boolean
            Dim _Result As Boolean, mbox As MsgBoxResult
            _Result = False
            If _NewStatus = True Then
                Modules.lStatus.Create(Modules.IrcSettings, Modules.lSettings.lServers)
                Application.DoEvents()
            Else
                If Modules.lStatus.Connected(Modules.lStatus.ActiveIndex) = True Then
                    If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                        mbox = MsgBox("You are currently connected on this status window, you will not be able to change the server settings if you continue, would you like to continue anyways?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                        If (mbox = MsgBoxResult.Yes) Then
                            _Result = True
                        Else
                            _Result = False
                        End If
                    End If
                Else
                    _Result = True
                End If
            End If
            Return _Result
        End Function

        Public Sub cmdApplyNow_Click(ByVal _Form As Form)
            _Form.Close()
        End Sub

        Public Sub cmdCancelNow_Click(ByVal _Form As Form)
            _Form.Close()
        End Sub

        Public Sub cboNetworks_SelectedIndexChanged(ByVal _Network As String, ByVal _ServersListView As RadListView)
            RefreshServers(_ServersListView, Modules.IrcSettings.IrcNetworks.Find(_Network).ID)
        End Sub

        Public Sub frmCustomize_FormClosed()
            Modules.lSettings.lWinVisible.wCustomize = False
        End Sub

        Public Sub cmdAddNickName_Click()
            Dim _AddNickName As New frmSharedAdd
            _AddNickName = New frmSharedAdd
            _AddNickName.lSharedAddUI.SharedAddType = Business.Enums.SharedAddType.AddNickName
            _AddNickName.Show()
        End Sub

        Public Sub cmdRemoveNickName(ByVal _RadDropDownList As RadDropDownList)
            _RadDropDownList.Items.Remove(_RadDropDownList.SelectedItem)
        End Sub

        Public Sub cmdClearMyNickName_Click(ByVal _RadDropDownList As RadDropDownList)
            _RadDropDownList.Items.Clear()
        End Sub

        Public Sub cmdQuerySettings_Click()
            Dim _QuerySettings As frmQuerySettings
            _QuerySettings = New frmQuerySettings
            _QuerySettings.Show()
        End Sub

        Public Sub cmdClearNotify_Click(ByVal _NotifyListView As RadListView)
            Modules.lSettings.lNotify.nModified = True
            _NotifyListView.Items.Clear()
        End Sub

        Public Sub cmdNotifyAdd_Click(ByVal _NotifyListView As RadListView)
            Dim _Notify As New gNotify
            Modules.lSettings.lNotify.nModified = True
            AddToNotifyListView("Users Nickname", "Notify Message", "Network Name", _NotifyListView)
            _Notify.nNickName = "Users Nickname"
            _Notify.nMessage = "Notify Message"
            _Notify.nNetwork = "My Network"
            Modules.lSettings.AddToNotifyList(_Notify)
        End Sub

        Public Sub lnkAddServer_Click(ByVal _Network As String)
            Dim addServer As frmAddServer
            If (Not String.IsNullOrEmpty(_Network)) Then
                addServer = New frmAddServer
                addServer.Show()
                addServer.cboNetwork.Text = _Network
            Else
                addServer = New frmAddServer
                addServer.Show()
                addServer.cboNetwork.Text = lStartupNetwork
            End If
        End Sub

        Public Sub lnkNetworkAdd_Click()
            Dim lSharedAdd As New frmSharedAdd
            lSharedAdd.Show()
            lSharedAdd.lSharedAddUI.SharedAddType = Business.Enums.SharedAddType.AddNetwork
        End Sub

        Public Sub Form_Load(ByVal _Form As Form, ByVal _CancelButton As RadButton, ByVal _ServersListView As RadListView)
            _Form.CancelButton = _CancelButton
            Modules.lSettings.lWinVisible.wCustomize = True
            With _ServersListView.Columns
                .Clear()
                .Add(New ListViewDetailColumn("Description", "Description"))
                .Add(New ListViewDetailColumn("Server", "Server"))
                .Add(New ListViewDetailColumn("Port", "Port"))
            End With
            _Form.Icon = mdiMain.Icon
        End Sub

        Public Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String, ByVal lServerIP As String, ByVal _RadListView As RadListView)
            If Len(lNickName) <> 0 And Len(lMessage) <> 0 Then
                Dim _Item As New Telerik.WinControls.UI.ListViewDataItem
                _Item.Text = lNickName
                _Item.SubItems.Add(lNickName)
                _Item.SubItems.Add(lMessage)
                _Item.SubItems.Add(lServerIP)
                _RadListView.Items.Add(_Item)
            End If
        End Sub

        Public Sub ClearServers(ByVal _RadListView As RadListView)
            _RadListView.Items.Clear()
        End Sub

        Public Sub RefreshServers(ByVal _RadListView As RadListView, ByVal _NetworkIndex As Integer)
            Dim i As Integer, t As Integer = 0, _Ip As String = "", _Port As String = "", n As Integer = -1
            _RadListView.Items.Clear()
            If _NetworkIndex <> 0 Then
                For i = 1 To Modules.lSettings.lServers.sCount
                    With Modules.lSettings.lServers.sServer(i)
                        If Len(.sDescription) <> 0 Then
                            If .sNetworkIndex = _NetworkIndex Then
                                Dim _Values(2) As String
                                _Values(0) = .sDescription
                                _Values(1) = .sIP
                                _Values(2) = .sPort.ToString
                                _RadListView.Items.Add(New ListViewDataItem(.sDescription, _Values))
                                If String.IsNullOrEmpty(_Ip) = True Then _Ip = .sIP
                                If String.IsNullOrEmpty(_Port) = True Then _Port = .sPort.ToString
                            End If
                        End If
                    End With
                Next i
                For Each _DataItem As ListViewDataItem In _RadListView.Items
                    If _DataItem.Text = Modules.lSettings.lServers.sServer(Modules.lSettings.lServers.sIndex).sDescription Then
                        n = t
                        Exit For
                    End If
                    t = t + 1
                Next _DataItem
                _RadListView.SelectedIndex = n
            End If
        End Sub

        Public Sub txtNotifyNetwork_TextChanged(ByVal _NotifyNetwork As String, ByVal _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(2) = _NotifyNetwork
                Modules.lSettings.lNotify.nModified = True
            End If
        End Sub

        Public Sub txtNotifyMessage_TextChanged(ByVal _NotifyMessage As String, ByVal _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(1) = _NotifyMessage
                Modules.lSettings.lNotify.nModified = True
            End If
        End Sub

        Public Sub Apply_Settings_Servers(ByVal _ServersListView As RadListView, ByVal _SelectedNetwork As String)
            If (_ServersListView.SelectedItem IsNot Nothing) Then
                If (_ServersListView.SelectedItem IsNot Nothing) Then Modules.lSettings.lServers.sIndex = Modules.lSettings.FindServerIndexByIp(_ServersListView.SelectedItem.Item(1).ToString)
                Modules.IrcSettings.IrcNetworks.SetDefault(Modules.IrcSettings.IrcNetworks.Find(_SelectedNetwork))
                If Not (Modules.lStatus.Connected(Modules.lStatus.ActiveIndex)) Then
                    Modules.lStatus.SetStatus(Modules.lStatus.ActiveIndex)
                End If
            End If
        End Sub

        Public Sub Apply_Settings_Startup(
            ByVal _AutoConnect As Boolean,
            ByVal _ShowCustomize As Boolean,
            ByVal _ShowBrowser As Boolean
        )
            With Modules.lSettings.lIRC.iSettings
                .sAutoConnect = _AutoConnect
                .sCustomizeOnStartup = _ShowCustomize
            End With
        End Sub

        Public Sub Apply_Settings_Text(ByVal _UnknownTextStatus As Boolean,
                                       ByVal _UnknownTextOwn As Boolean,
                                       ByVal _UnknownTextHide As Boolean,
                                       ByVal _UnSupportedTextStatus As Boolean,
                                       ByVal _UnSupportedTextOwn As Boolean,
                                       ByVal _UnSupportedTextHide As Boolean)
            If (_UnknownTextStatus) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uStatusWindow
            ElseIf (_UnknownTextOwn) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uOwnWindow
            ElseIf (_UnknownTextHide) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uHide
            End If
            If (_UnSupportedTextStatus) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.StatusWindow
            ElseIf (_UnSupportedTextOwn) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.OwnWindow
            ElseIf (_UnSupportedTextHide) Then
                Modules.lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.Hide
            End If
        End Sub

        Public Sub Apply_Settings_IRC(
                                 ByVal _NoIrcMessages As Boolean,
                                 ByVal _ExtendedMessages As Boolean,
                                 ByVal _ShowUserAddresses As Boolean,
                                 ByVal _HideMotds As Boolean
        )
            With Modules.lSettings.lIRC.iSettings
                .sNoIRCMessages = _NoIrcMessages
                .sExtendedMessages = _ExtendedMessages
                .sShowUserAddresses = _ShowUserAddresses
                .sHideMOTD = _HideMotds
            End With
        End Sub

        Public Sub Apply_Settings_ServerModes(
                                 ByVal _Invisible As Boolean,
                                 ByVal _Wallops As Boolean,
                                 ByVal _Restricted As Boolean,
                                 ByVal _Operator As Boolean,
                                 ByVal _LocalOp As Boolean,
                                 ByVal _ServerNotices As Boolean
        )
            With Modules.lSettings.lIRC.iModes
                .mInvisible = _Invisible
                .mLocalOperator = _LocalOp
                .mOperator = _Operator
                .mRestricted = _Restricted
                .mServerNotices = _ServerNotices
                .mWallops = _Wallops
            End With
        End Sub

        Public Sub Apply_Settings_Interface(
                                 ByVal _Prompts As Boolean,
                                 ByVal _AutoShowWindows As Boolean,
                                 ByVal _AutoMaximized As Boolean,
                                 ByVal _PopupChannelFolder As Boolean,
                                 ByVal _VideoBackground As Boolean,
                                 ByVal _ShowNickNameWindow As Boolean,
                                 ByVal _CloseChannelFolder As Boolean,
                                 ByVal _AddToChannelFolder As Boolean,
                                 ByVal _BrowseChannelUrls As Boolean,
                                 ByVal _CloseStatusWindow As Boolean,
                                 ByVal _ShowRawWindow As Boolean,
                                 ByVal _MotdInOwnWindow As Boolean,
                                 ByVal _NoticesInOwnWindow As Boolean,
                                 ByVal _TextBufferSize As Integer,
                                 ByVal _AutoSelectAlternateNickname As Boolean)
            With Modules.lSettings.lIRC.iSettings
                .sPrompts = _Prompts
                .sShowWindowsAutomatically = _AutoShowWindows
                .sAutoMaximize = _AutoMaximized
                .sPopupChannelFolders = _PopupChannelFolder
                .sVideoBackground = _VideoBackground
                .sAutoSelectAlternateNickname = _AutoSelectAlternateNickname
                .sChangeNickNameWindow = _ShowNickNameWindow
                .sChannelFolderCloseOnJoin = _CloseChannelFolder
                .sAutoAddToChannelFolder = _AddToChannelFolder
                .sAutoNavigateChannelUrls = _BrowseChannelUrls
                .sShowRawWindow = _ShowRawWindow
                .sMOTDInOwnWindow = _MotdInOwnWindow
                .sNoticesInOwnWindow = _NoticesInOwnWindow
                .sTextBufferSize = _TextBufferSize
            End With
        End Sub

        Public Sub Apply_Settings_DCC(ByVal _DccChatPrompt As Boolean,
                                      ByVal _DccChatAcceptAll As Boolean,
                                      ByVal _DccChatIgnore As Boolean,
                                      ByVal _DccSendPrompt As Boolean,
                                      ByVal _DccSendAcceptAll As Boolean,
                                      ByVal _DccSendIgnore As Boolean,
                                      ByVal _AutoCloseDccDialogs As Boolean,
                                      ByVal _OnlyAllowUsersInNotifyList As Boolean,
                                      ByVal _PopupDownloadManager As Boolean,
                                      ByVal _DownloadDirectory As String)
            If (_DccChatPrompt) Then
                Modules.lSettings_DCC.ChatPrompt = DccPrompt.Prompt
            ElseIf (_DccChatAcceptAll) Then
                Modules.lSettings_DCC.ChatPrompt = DccPrompt.AcceptAll
            ElseIf (_DccChatIgnore) Then
                Modules.lSettings_DCC.ChatPrompt = DccPrompt.Ignore
            End If
            If (_DccSendPrompt) Then
                Modules.lSettings_DCC.SendPrompt = DccPrompt.Prompt
            ElseIf (_DccSendAcceptAll) Then
                Modules.lSettings_DCC.SendPrompt = DccPrompt.AcceptAll
            ElseIf (_DccSendIgnore) Then
                Modules.lSettings_DCC.SendPrompt = DccPrompt.Ignore
            End If
            Modules.lSettings_DCC.dAutoCloseDialogs = _AutoCloseDccDialogs
            Modules.lSettings_DCC.dAutoIgnore = _OnlyAllowUsersInNotifyList
            Modules.lSettings_DCC.dDownloadDirectory = _DownloadDirectory
            Modules.lSettings_DCC.dPopupDownloadManager = _PopupDownloadManager
        End Sub

        Public Sub Apply_Settings_User(ByVal _NickNamesDropDownList As RadDropDownList, ByVal _HomePage As String, ByVal _UserEmail As String, ByVal _Password As String, ByVal _RealName As String, ByVal _OperName As String, ByVal _OperPassword As String)
            Dim _SelectedNick As String = "", _LastSelectedNickName As String = "", splt() As String
            If Modules.lSettings.lIRC.iNicks.nIndex <> 0 Then _LastSelectedNickName = Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick
            Modules.lSettings.lIRC.iNicks = New gNicks()
            ReDim Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lArraySizes.aNickNames)
            For i As Integer = 0 To _NickNamesDropDownList.Items.Count - 1
                Modules.lSettings.lIRC.iNicks.nNick(i + 1).nNick = _NickNamesDropDownList.Items(i).Text
                If (i = _NickNamesDropDownList.SelectedIndex) Then
                    _SelectedNick = _NickNamesDropDownList.Items(i).Text
                End If
            Next i
            Modules.lSettings.lIRC.iNicks.nCount = _NickNamesDropDownList.Items.Count
            If (_SelectedNick.Length <> 0) Then
                Modules.lSettings.lIRC.iNicks.nIndex = Modules.lSettings.FindNickNameIndex(_SelectedNick)
            Else
                Modules.lSettings.lIRC.iNicks.nIndex = Modules.lSettings.FindNickNameIndex(_LastSelectedNickName)
            End If
            Modules.lSettings.lIRC.iSettings.sURL = _HomePage
            With Modules.lSettings.lIRC
                .iEMail = _UserEmail
                .iPass = _Password
                .iOperName = _OperName
                .iOperPass = _OperPassword
                If InStr(_UserEmail, "@") <> 0 Then
                    splt = Split(_UserEmail, "@")
                    .iRealName = splt(0)
                Else
                    .iRealName = _RealName
                End If
            End With
        End Sub

        Public Sub txtNotifyNickname_TextChanged(ByVal _NotifyNickName As String, ByVal _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(0) = _NotifyNickName
                Modules.lSettings.lNotify.nModified = True
            End If
        End Sub
    End Class
End Namespace