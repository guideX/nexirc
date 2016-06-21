Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.clsSharedAdd
Imports nexIRC.Settings
Imports nexIRC.Enum
Imports nexIRC.Business.Helpers

Namespace IRC.Customize
    Public Class clsCustomize
        Public Event Apply()
        Public Event Save()
        Public Event Close()
        Public lStartupNetwork As String
        Public Sub cmdDCCIgnoreAdd_Click()
            Dim f As New frmDCCIgnoreAdd
            f.optNickName.Checked = True
            f.Show()
        End Sub
        Public Sub lstDCCIgnoreItems_MouseClick(_ListBox As RadListControl)
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
        Public Sub cmdDCCIgnoreRemove_Click(_ListBox As RadListControl)
            Dim lItems() As String, i As Integer, c As Integer, msg As String
            msg = _ListBox.SelectedItem.ToString
            If InStr(Err.Description, "Object reference not set to an instance of an object.") <> 0 Then
                Err.Clear()
                Exit Sub
            End If
            If Len(Trim(msg)) <> 0 Then
                _ListBox.Items.Remove(_ListBox.SelectedItem)
                ReDim lItems(100)
                For i = 1 To lSettings_DCC.lDCC.dIgnorelist.dCount
                    With lSettings_DCC.lDCC.dIgnorelist.dItem(i)
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
                lSettings_DCC.lDCC.dIgnorelist.dCount = c
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(c.ToString))
                For i = 1 To 100
                    With lSettings_DCC.lDCC.dIgnorelist.dItem(i)
                        If Len(lItems(i)) <> 0 Then
                            .dData = lItems(i)
                            NativeMethods.WriteINI(lSettings.lINI.iDCC, "Ignore", Trim(i.ToString), .dData)
                        Else
                            .dData = ""
                        End If
                    End With
                Next i
            End If
        End Sub
        Public Sub cmdNetworkSettings_Click()
            frmNetworkSettings.Show()
        End Sub
        Public Sub cmdCompatibilityEnable_Click(_Name As String, _ListItem As ListViewDataItem)
            For i As Integer = 1 To lSettings.lCompatibility.Count
                If lSettings.lCompatibility(i).Description = _Name Then
                    lSettings.lCompatibility(i).Enabled = True
                    _ListItem.Item(1) = "True"
                    Exit For
                End If
            Next i
        End Sub
        Public Sub cmdCompatibilityDisable_Click(_Name As String, _ListItem As ListViewDataItem)
            For i As Integer = 1 To lSettings.lCompatibility.Count
                If lSettings.lCompatibility(i).Description = _Name Then
                    lSettings.lCompatibility(i).Enabled = False
                    _ListItem.Item(1) = "False"
                    Exit For
                End If
            Next i
        End Sub
        Public Sub cmdRemoveNotify_Click(_NotifyListView As RadListView)
            _NotifyListView.Items.Remove(_NotifyListView.SelectedItem)
        End Sub
        Public Sub cmdEditIdentSettings_Click()
            frmIdentdSettings.Show()
        End Sub
        Public Sub cmdRemoveIgnoreExtension_Click(_ListBox As RadListControl)
            _ListBox.Items.RemoveAt(_ListBox.SelectedIndex)
        End Sub
        Public Sub cmdAddIgnoreExtension_Click(_ListBox As RadListControl)
            Dim msg As String = InputBox("Add Ignore Extension")
            If Len(msg) <> 0 Then
                _ListBox.Items.Add(msg)
            Else
                If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
            End If
        End Sub
        Public Sub lstDCCIgnoreItems_Click(_Button As RadButton)
            _Button.Enabled = True
        End Sub
        Public Sub lstIgnoreExtensions_SelectedIndexChanged(_RemoveButton As RadButton)
            _RemoveButton.Enabled = True
        End Sub
        Public Sub lvwServers_DoubleClick(_CheckBox As RadCheckBox, _Form As Form)
            If _CheckBox.Checked = True Then
                lStatus.Create(lSettings.lIRC, lSettings.lServers)
                Application.DoEvents()
            End If
            If lStatus.ActiveIndex() <> 0 Then
                RaiseEvent Apply()
                RaiseEvent Save()
                lStatus.ActiveStatusConnect()
            End If
            RaiseEvent Close()
        End Sub
        Public Sub lnkNetworkDelete_LinkClicked(_DropDownList As RadDropDownList)
            Dim _MsgBoxResult As MsgBoxResult, msg As String
            msg = _DropDownList.SelectedItem.ToString
            If lSettings.lIRC.iSettings.sPrompts = True Then
                _MsgBoxResult = MsgBox("Really, delete '" & msg & "'?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            Else
                _MsgBoxResult = MsgBoxResult.Yes
            End If
            If _MsgBoxResult = MsgBoxResult.Yes Then
                _DropDownList.Items.Remove(_DropDownList.SelectedItem)
                lSettings.RemoveNetwork(lSettings.FindNetworkIndex(msg))
            End If
        End Sub
        Public Sub lnkNetworkAdd_LinkClicked()
            Dim f As New frmSharedAdd
            f.lSharedAddUI.SharedAddType = eSharedAddType.sAddNetwork
            'animate.Animate(f, animate.Effect.Center, 200, 1)
        End Sub
        Public Sub cmdServerEdit_Click(_ListView As RadListView)
            Dim i As Integer
            If (_ListView.SelectedItem IsNot Nothing) Then
                i = lSettings.FindServerIndexByIp(_ListView.SelectedItem.Item(1).ToString)
                If (i <> 0) Then
                    frmEditServer.Show()
                    frmEditServer.SetServerInfo(i)
                End If
            End If
        End Sub
        Public Sub cmdServerDelete_Click(_ListView As RadListView)
            Dim _MessageBoxResult As MsgBoxResult
            For Each _Item As Telerik.WinControls.UI.ListViewDataItem In _ListView.SelectedItems
                If lSettings.lIRC.iSettings.sPrompts = True Then
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
        Public Sub UpdateSelectedServer(_ServerListView As RadListView, _Description As String, _Ip As String, _Port As String)
            If (_ServerListView.SelectedItem IsNot Nothing) Then
                _ServerListView.SelectedItem.Item(0) = _Description
                _ServerListView.SelectedItem.Item(1) = _Ip
                _ServerListView.SelectedItem.Item(2) = _Port
            End If
        End Sub
        Public Sub lvwNotify_SelectedIndexChanged(_NotifyListView As RadListView, _NotifyNickNameTextBox As RadTextBox, _NotifyMessageTextBox As RadTextBox, _NetworkNotifyDropDownList As RadDropDownList)
            Dim i As Integer, n As Integer
            For i = 0 To _NotifyListView.SelectedItems.Count - 1
                n = lSettings.FindNotifyIndex(_NotifyListView.SelectedItems(i).Text)
                _NotifyNickNameTextBox.Text = lSettings.lNotify.nNotify(n).nNickName
                _NotifyMessageTextBox.Text = lSettings.lNotify.nNotify(n).nMessage
                _NetworkNotifyDropDownList.SelectedItem = _NetworkNotifyDropDownList.Items(FindRadComboIndex(_NetworkNotifyDropDownList, lSettings.lNotify.nNotify(n).nNetwork))
                Exit For
            Next i
        End Sub
        Public Sub cmdEditString_Click(_StringsListView As RadListView)
            Dim item As ListViewDataItem, f As frmEditString, i As Integer
            item = New ListViewDataItem
            If _StringsListView.SelectedItems.Count <> 0 Then
                For i = 0 To _StringsListView.SelectedItems.Count
                    item = _StringsListView.SelectedItems(i)
                    Exit For
                Next i
                f = New frmEditString
                f.Show()
                f.txtDescription.Text = item.Text
                f.txtSupport.Text = item.Item(1).ToString
                f.txtSyntax.Text = item.Item(2).ToString
                f.cboNumeric.Text = item.Item(3).ToString
                f.txtData.Text = item.Item(4).ToString
                Dim obj = lStringsController.FindStringIndexByDescription(item.Text)
                For Each o In obj.Find
                    If (Not String.IsNullOrEmpty(o)) Then
                        f.lstParameters.Items.Add(o)
                    End If
                Next o
            End If
        End Sub
        Public Sub cmdServersClear_Click(_Network As String, _RadListView As RadListView)
            Dim _MsgBoxResult As MsgBoxResult
            If lSettings.lIRC.iSettings.sPrompts = True Then
                _MsgBoxResult = MsgBox("Are you sure you wish to clear the irc servers for the network '" & _Network & "'?", vbYesNo)
                If _MsgBoxResult = MsgBoxResult.Yes Then _RadListView.Items.Clear()
            Else
                _RadListView.Items.Clear()
            End If
        End Sub
        Public Sub cmdServersMove_Click(_Network As String, _Server As String)
            Dim f As frmChooseNetwork
            f = New frmChooseNetwork
            With f
                .lChooseNetwork.lNetworkIndex = lSettings.FindNetworkIndex(_Network)
                .lChooseNetwork.lServerToChange = lSettings.FindServerIndexByIp(_Server)
                f.Show()
            End With
        End Sub
        Public Function cmdConnectNow_Click(newStatus As Boolean, form As Form) As Boolean
            Dim result As Boolean
            result = False
            If (newStatus = True) Then
                lStatus.Create(lSettings.lIRC, lSettings.lServers)
                Application.DoEvents()
            End If
            If lStatus.ActiveIndex() <> 0 Then
                result = True
                lStatus.ActiveStatusConnect()
            End If
            form.Close()
            Return result
        End Function
        Public Function cmdOK_Click(_NewStatus As Boolean, _Form As Form) As Boolean
            Dim _Result As Boolean, mbox As MsgBoxResult
            _Result = False
            If _NewStatus = True Then
                lStatus.Create(lSettings.lIRC, lSettings.lServers)
                Application.DoEvents()
            Else
                If lStatus.Connected(lStatus.ActiveIndex) = True Then
                    If lSettings.lIRC.iSettings.sPrompts = True Then
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
        Public Sub cmdApplyNow_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub cmdCancelNow_Click(_Form As Form)
            _Form.Close()
        End Sub
        Public Sub cboNetworks_SelectedIndexChanged(lv As RadListView, networkIndex As Integer)
            RefreshServers(lv, networkIndex)
        End Sub
        Public Sub frmCustomize_FormClosed()
            lSettings.lWinVisible.wCustomize = False
        End Sub
        Public Sub cmdAddNickName_Click()
            Dim _AddNickName As New frmSharedAdd
            _AddNickName = New frmSharedAdd
            _AddNickName.lSharedAddUI.SharedAddType = eSharedAddType.sAddNickName
            _AddNickName.Show()
        End Sub
        Public Sub cmdRemoveNickName(_RadDropDownList As RadDropDownList)
            _RadDropDownList.Items.Remove(_RadDropDownList.SelectedItem)
        End Sub
        Public Sub cmdClearMyNickName_Click(_RadDropDownList As RadDropDownList)
            _RadDropDownList.Items.Clear()
        End Sub
        Public Sub cmdQuerySettings_Click()
            Dim _QuerySettings As frmQuerySettings
            _QuerySettings = New frmQuerySettings
            _QuerySettings.Show()
        End Sub
        Public Sub cmdClearNotify_Click(_NotifyListView As RadListView)
            lSettings.lNotify.nModified = True
            _NotifyListView.Items.Clear()
        End Sub
        Public Sub cmdNotifyAdd_Click(_NotifyListView As RadListView)
            Dim _Notify As New gNotify
            lSettings.lNotify.nModified = True
            AddToNotifyListView("Users Nickname", "Notify Message", "Network Name", _NotifyListView)
            _Notify.nNickName = "Users Nickname"
            _Notify.nMessage = "Notify Message"
            _Notify.nNetwork = "My Network"
            lSettings.AddToNotifyList(_Notify)
        End Sub
        Public Sub lnkAddServer_Click(_Network As String)
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
            lSharedAdd.lSharedAddUI.SharedAddType = eSharedAddType.sAddNetwork
        End Sub
        Public Sub Form_Load(_Form As Form, _CancelButton As RadButton, _ServersListView As RadListView)
            _Form.CancelButton = _CancelButton
            lSettings.lWinVisible.wCustomize = True
            With _ServersListView.Columns
                .Clear()
                .Add(New ListViewDetailColumn("Description", "Description"))
                .Add(New ListViewDetailColumn("Server", "Server"))
                .Add(New ListViewDetailColumn("Port", "Port"))
            End With
            _Form.Icon = mdiMain.Icon
        End Sub
        Public Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String, ByVal lServerIP As String, _RadListView As RadListView)
            If Len(lNickName) <> 0 And Len(lMessage) <> 0 Then
                Dim _Item As New Telerik.WinControls.UI.ListViewDataItem
                _Item.Text = lNickName
                _Item.SubItems.Add(lNickName)
                _Item.SubItems.Add(lMessage)
                _Item.SubItems.Add(lServerIP)
                _RadListView.Items.Add(_Item)
            End If
        End Sub
        Public Sub ClearServers(_RadListView As RadListView)
            _RadListView.Items.Clear()
        End Sub
        Public Sub RefreshNetworks(_RadDropDownList As RadDropDownList)
            Dim i As Integer
            _RadDropDownList.Items.Clear()
            For i = 0 To lSettings.lNetworks.Networks.Count - 1
                With lSettings.lNetworks.Networks(i)
                    If Len(.Name) <> 0 Then
                        _RadDropDownList.Items.Add(.Name)
                    End If
                End With
            Next i
        End Sub
        Public Sub RefreshServers(lv As RadListView, networkIndex As Integer)
            Dim i As Integer, t As Integer = 0, _Ip As String = "", _Port As String = "", n As Integer = -1
            lv.Items.Clear()
            If (networkIndex <> 0) Then
                For i = 0 To lSettings.lServers.Servers.Count - 1
                    If (Not String.IsNullOrEmpty(lSettings.lServers.Servers(i).Description)) Then
                        If (lSettings.lServers.Servers(i).NetworkIndex = networkIndex) Then
                            Dim v(2) As String
                            v(0) = lSettings.lServers.Servers(i).Description
                            v(1) = lSettings.lServers.Servers(i).Ip
                            v(2) = lSettings.lServers.Servers(i).Port.ToString
                            lv.Items.Add(New ListViewDataItem(lSettings.lServers.Servers(i).Description, v))
                            If String.IsNullOrEmpty(_Ip) = True Then _Ip = lSettings.lServers.Servers(i).Ip
                            If String.IsNullOrEmpty(_Port) = True Then _Port = lSettings.lServers.Servers(i).Port.ToString
                        End If
                    End If
                Next i
                For Each di As ListViewDataItem In lv.Items
                    If di.Text = lSettings.lServers.Servers(lSettings.lServers.Index).Description Then
                        n = t
                        Exit For
                    End If
                    t = t + 1
                Next di
                lv.SelectedIndex = n
            End If
        End Sub
        Public Sub txtNotifyNetwork_TextChanged(_NotifyNetwork As String, _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(2) = _NotifyNetwork
                lSettings.lNotify.nModified = True
            End If
        End Sub
        Public Sub txtNotifyMessage_TextChanged(_NotifyMessage As String, _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(1) = _NotifyMessage
                lSettings.lNotify.nModified = True
            End If
        End Sub
        Public Sub Apply_Settings_Servers(_ServersListView As RadListView, _SelectedNetwork As String)
            If (_ServersListView.SelectedItem IsNot Nothing) Then
                If (_ServersListView.SelectedItem IsNot Nothing) Then lSettings.lServers.Index = lSettings.FindServerIndexByIp(_ServersListView.SelectedItem.Item(1).ToString)
                lSettings.lNetworks.Index = lSettings.FindNetworkIndex(_SelectedNetwork)
                If Not (lStatus.Connected(lStatus.ActiveIndex)) Then
                    lStatus.SetStatus(lStatus.ActiveIndex)
                End If
            End If
        End Sub
        Public Sub Apply_Settings_Startup(
            _AutoConnect As Boolean,
            _ShowCustomize As Boolean,
            _ShowBrowser As Boolean
        )
            With lSettings.lIRC.iSettings
                .sAutoConnect = _AutoConnect
                .sCustomizeOnStartup = _ShowCustomize
            End With
        End Sub
        Public Sub Apply_Settings_Text(_UnknownTextStatus As Boolean,
                                       _UnknownTextOwn As Boolean,
                                       _UnknownTextHide As Boolean,
                                       _UnSupportedTextStatus As Boolean,
                                       _UnSupportedTextOwn As Boolean,
                                       _UnSupportedTextHide As Boolean)
            If (_UnknownTextStatus) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnknowns = UnknownsIn.StatusWindow
            ElseIf (_UnknownTextOwn) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnknowns = UnknownsIn.OwnWindow
            ElseIf (_UnknownTextHide) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnknowns = UnknownsIn.Hide
            End If
            If (_UnSupportedTextStatus) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.StatusWindow
            ElseIf (_UnSupportedTextOwn) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.OwnWindow
            ElseIf (_UnSupportedTextHide) Then
                lSettings.lIRC.iSettings.sStringSettings.sUnsupported = UnsupportedIn.Hide
            End If
        End Sub
        Public Sub Apply_Settings_IRC(
                                 _NoIrcMessages As Boolean,
                                 _ExtendedMessages As Boolean,
                                 _ShowUserAddresses As Boolean,
                                 _HideMotds As Boolean
        )
            With lSettings.lIRC.iSettings
                .sNoIRCMessages = _NoIrcMessages
                .sExtendedMessages = _ExtendedMessages
                .sShowUserAddresses = _ShowUserAddresses
                .sHideMOTD = _HideMotds
            End With
        End Sub
        Public Sub Apply_Settings_ServerModes(
                                 _Invisible As Boolean,
                                 _Wallops As Boolean,
                                 _Restricted As Boolean,
                                 _Operator As Boolean,
                                 _LocalOp As Boolean,
                                 _ServerNotices As Boolean
        )
            With lSettings.lIRC.iModes
                .Invisible = _Invisible
                .LocalOperator = _LocalOp
                .Operator = _Operator
                .Restricted = _Restricted
                .ServerNotices = _ServerNotices
                .Wallops = _Wallops
            End With
        End Sub
        Public Sub Apply_Settings_Interface(
                                 _Prompts As Boolean,
                                 _AutoShowWindows As Boolean,
                                 _AutoMaximized As Boolean,
                                 _PopupChannelFolder As Boolean,
                                 _VideoBackground As Boolean,
                                 _ShowNickNameWindow As Boolean,
                                 _CloseChannelFolder As Boolean,
                                 _AddToChannelFolder As Boolean,
                                 _BrowseChannelUrls As Boolean,
                                 _CloseStatusWindow As Boolean,
                                 _ShowRawWindow As Boolean,
                                 _MotdInOwnWindow As Boolean,
                                 _NoticesInOwnWindow As Boolean,
                                 _TextBufferSize As Integer)
            With lSettings.lIRC.iSettings
                .sPrompts = _Prompts
                .sShowWindowsAutomatically = _AutoShowWindows
                .sAutoMaximize = _AutoMaximized
                .sPopupChannelFolders = _PopupChannelFolder
                .sVideoBackground = _VideoBackground
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
        Public Sub Apply_Settings_DCC(_DccChatPrompt As Boolean,
                                      _DccChatAcceptAll As Boolean,
                                      _DccChatIgnore As Boolean,
                                      _DccSendPrompt As Boolean,
                                      _DccSendAcceptAll As Boolean,
                                      _DccSendIgnore As Boolean,
                                      _AutoCloseDccDialogs As Boolean,
                                      _OnlyAllowUsersInNotifyList As Boolean,
                                      _PopupDownloadManager As Boolean,
                                      _DownloadDirectory As String)
            If (_DccChatPrompt) Then
                lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.ePrompt
            ElseIf (_DccChatAcceptAll) Then
                lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll
            ElseIf (_DccChatIgnore) Then
                lSettings_DCC.lDCC.dChatPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eIgnore
            End If
            If (_DccSendPrompt) Then
                lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.ePrompt
            ElseIf (_DccSendAcceptAll) Then
                lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eAcceptAll
            ElseIf (_DccSendIgnore) Then
                lSettings_DCC.lDCC.dSendPrompt = nexIRC.IRC.Settings.clsDCC.eDCCPrompt.eIgnore
            End If
            lSettings_DCC.lDCC.dAutoCloseDialogs = _AutoCloseDccDialogs
            lSettings_DCC.lDCC.dAutoIgnore = _OnlyAllowUsersInNotifyList
            lSettings_DCC.lDCC.dDownloadDirectory = _DownloadDirectory
            lSettings_DCC.lDCC.dPopupDownloadManager = _PopupDownloadManager
        End Sub
        Public Sub Apply_Settings_User(_NickNamesDropDownList As RadDropDownList, _HomePage As String, _UserEmail As String, _Password As String, _RealName As String, _OperName As String, _OperPassword As String)
            Dim _SelectedNick As String = "", _LastSelectedNickName As String = "", splt() As String
            If lSettings.lIRC.iNicks.nIndex <> 0 Then _LastSelectedNickName = lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick
            lSettings.lIRC.iNicks = New gNicks()
            ReDim lSettings.lIRC.iNicks.nNick(lSettings.lArraySizes.aNickNames)
            For i As Integer = 0 To _NickNamesDropDownList.Items.Count - 1
                lSettings.lIRC.iNicks.nNick(i + 1).nNick = _NickNamesDropDownList.Items(i).Text
                If (i = _NickNamesDropDownList.SelectedIndex) Then
                    _SelectedNick = _NickNamesDropDownList.Items(i).Text
                End If
            Next i
            lSettings.lIRC.iNicks.nCount = _NickNamesDropDownList.Items.Count
            If (_SelectedNick.Length <> 0) Then
                lSettings.lIRC.iNicks.nIndex = lSettings.FindNickNameIndex(_SelectedNick)
            Else
                lSettings.lIRC.iNicks.nIndex = lSettings.FindNickNameIndex(_LastSelectedNickName)
            End If
            lSettings.lIRC.iSettings.sURL = _HomePage
            With lSettings.lIRC
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
        Public Sub txtNotifyNickname_TextChanged(_NotifyNickName As String, _NotifyListView As RadListView)
            If (_NotifyListView.SelectedItem IsNot Nothing) Then
                _NotifyListView.SelectedItem.Item(0) = _NotifyNickName
                lSettings.lNotify.nModified = True
            End If
        End Sub
    End Class
End Namespace