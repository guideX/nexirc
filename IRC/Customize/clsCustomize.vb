Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Imports nexIRC.Classes.UI
Imports nexIRC.Modules
Imports nexIRC.clsSharedAdd
Imports nexIRC.Settings
Namespace IRC.Customize
    Public Class clsCustomize
        Public Event Apply()
        Public lStartupNetwork As String
        Public Sub cmdDCCIgnoreAdd_Click()
            Try
                Dim f As New frmDCCIgnoreAdd
                f.optNickName.Checked = True
                f.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click")
            End Try
        End Sub
        Public Sub lvwStrings_DoubleClick()
            Try
                'cmdEditString_Click(sender, e)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lvwStrings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwStrings.DoubleClick")
            End Try
        End Sub
        Public Sub lstDCCIgnoreItems_MouseClick(_ListBox As RadListControl)
            Try
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick")
            End Try
        End Sub
        Public Sub cmdDCCIgnoreRemove_Click(_ListBox As RadListControl)
            Try
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
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(c.ToString))
                    For i = 1 To 100
                        With lSettings_DCC.lDCC.dIgnorelist.dItem(i)
                            If Len(lItems(i)) <> 0 Then
                                .dData = lItems(i)
                                Files.WriteINI(lSettings.lINI.iDCC, "Ignore", Trim(i.ToString), .dData)
                            Else
                                .dData = ""
                            End If
                        End With
                    Next i
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click")
            End Try
        End Sub
        Public Sub cmdNetworkSettings_Click()
            Try
                frmNetworkSettings.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click")
            End Try
        End Sub
        Public Sub cmdCompatibilityEnable_Click(_Name As String, _ListItem As ListViewDataItem)
            Try
                For i As Integer = 1 To lSettings.lCompatibility.cCount
                    If lSettings.lCompatibility.cCompatibility(i).cDescription = _Name Then
                        lSettings.lCompatibility.cCompatibility(i).cEnabled = True
                        _ListItem.Item(1) = "True"
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdCompatibilityEnable_Click()")
            End Try
        End Sub
        Public Sub cmdCompatibilityDisable_Click(_Name As String, _ListItem As ListViewDataItem)
            Try
                For i As Integer = 1 To lSettings.lCompatibility.cCount
                    If lSettings.lCompatibility.cCompatibility(i).cDescription = _Name Then
                        lSettings.lCompatibility.cCompatibility(i).cEnabled = False
                        _ListItem.Item(1) = "False"
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdCompatibilityDisable_Click()")
            End Try
        End Sub
        Public Sub cmdRemoveNotify_Click(_NotifyListView As RadListView)
            Try
                _NotifyListView.Items.Remove(_NotifyListView.SelectedItem)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveNotify.Click")
            End Try
        End Sub
        Public Sub cmdEditIdentSettings_Click()
            Try
                frmIdentdSettings.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditIdentSettings.Click")
            End Try
        End Sub
        Public Sub cmdRemoveIgnoreExtension_Click(_ListBox As RadListControl)
            Try
                _ListBox.Items.RemoveAt(_ListBox.SelectedIndex)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click")
            End Try
        End Sub
        Public Sub cmdAddIgnoreExtension_Click(_ListBox As RadListControl)
            Try
                Dim msg As String = InputBox("Add Ignore Extension")
                If Len(msg) <> 0 Then
                    _ListBox.Items.Add(msg)
                Else
                    If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Warning: No items were added!", MsgBoxStyle.Critical)
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdAddIgnoreExtension_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click")
            End Try
        End Sub
        Public Sub lstDCCIgnoreItems_Click(_Button As RadButton)
            Try
                _Button.Enabled = True
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lstDCCIgnoreItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDCCIgnoreItems.Click")
            End Try
        End Sub
        Public Sub lstIgnoreExtensions_SelectedIndexChanged(_RemoveButton As RadButton)
            Try
                _RemoveButton.Enabled = True
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged")
            End Try
        End Sub
        Public Sub lvwServers_DoubleClick(_CheckBox As RadCheckBox, _Form As Form)
            Try
                If _CheckBox.Checked = True Then
                    lStatus.Create(lSettings.lIRC, lSettings.lServers)
                    Application.DoEvents()
                End If
                If lStatus.ActiveIndex() <> 0 Then
                    RaiseEvent Apply()
                    lStatus.ActiveStatusConnect()
                End If
                _Form.Close()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lvwServers_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwServers.DoubleClick")
            End Try
        End Sub
        Public Sub lnkNetworkDelete_LinkClicked(_DropDownList As RadDropDownList)
            Try
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lnkNetworkDelete_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked")
            End Try
        End Sub
        Public Sub lnkNetworkAdd_LinkClicked()
            Try
                Dim f As New frmSharedAdd
                f.lSharedAddUI.SharedAddType = eSharedAddType.sAddNetwork
                'animate.Animate(f, animate.Effect.Center, 200, 1)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lnkNetworkAdd_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked")
            End Try
        End Sub
        Public Sub cmdServerEdit_Click(_ListView As RadListView)
            Try
                Dim i As Integer
                If (_ListView.SelectedItem IsNot Nothing) Then
                    i = lSettings.FindServerIndexByIp(_ListView.SelectedItem.Item(1).ToString)
                    If (i <> 0) Then
                        frmEditServer.Show()
                        frmEditServer.SetServerInfo(i)
                    End If
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdServerEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdServerEdit.Click")
            End Try
        End Sub
        Public Sub cmdServerDelete_Click(_ListView As RadListView)
            Try
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdServerDelete_Click()")
            End Try
        End Sub
        Public Sub cmdServerAdd_Click()
            Dim f As frmAddServer
            Try
                f = New frmAddServer()
                f.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdServerAdd_Click()")
            End Try
        End Sub
        Public Sub UpdateSelectedServer(_ServerListView As RadListView, _Description As String, _Ip As String, _Port As String)
            Try
                If (_ServerListView.SelectedItem IsNot Nothing) Then
                    _ServerListView.SelectedItem.Item(0) = _Description
                    _ServerListView.SelectedItem.Item(1) = _Ip
                    _ServerListView.SelectedItem.Item(2) = _Port
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub UpdateSelectedServer(_ServerListView As ListView, _Description As String, Ip As String, _Port As String, _Network As String)")
            End Try
        End Sub
        Public Sub lvwNotify_SelectedIndexChanged(_NotifyListView As RadListView, _NotifyNickNameTextBox As RadTextBox, _NotifyMessageTextBox As RadTextBox, _NetworkNotifyDropDownList As RadDropDownList)
            Try
                Dim i As Integer, n As Integer
                For i = 0 To _NotifyListView.SelectedItems.Count - 1
                    n = lSettings.FindNotifyIndex(_NotifyListView.SelectedItems(i).Text)
                    _NotifyNickNameTextBox.Text = lSettings.lNotify.nNotify(n).nNickName
                    _NotifyMessageTextBox.Text = lSettings.lNotify.nNotify(n).nMessage
                    _NetworkNotifyDropDownList.SelectedItem = _NetworkNotifyDropDownList.Items(FindRadComboIndex(_NetworkNotifyDropDownList, lSettings.lNotify.nNotify(n).nNetwork))
                    Exit For
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub lvwNotify_SelectedIndexChanged(_NotifyListView As RadListView, _NotifyNickNameTextBox As RadTextBox, _NotifyMessageTextBox As RadTextBox, _NetworkNotify As RadTextBox, _NetworkNotifyDropDownList As RadDropDownList)")
            End Try
        End Sub
        Public Sub cmdEditString_Click(_StringsListView As RadListView)
            Try
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
                    n = lStrings.FindStringIndexByDescription(lItem.Text)
                    For i = 1 To 6
                        msg = Files.ReadINI(lSettings.lINI.iText, Trim(Convert.ToString(n)), "Find" & Trim(Str(i)), "")
                        If Len(msg) <> 0 Then f.lstParameters.Items.Add(msg)
                    Next i
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdEditString_Click()")
            End Try
        End Sub
        Public Sub cmdServersClear_Click(_Network As String, _RadListView As RadListView)
            Try
                Dim _MsgBoxResult As MsgBoxResult
                If lSettings.lIRC.iSettings.sPrompts = True Then
                    _MsgBoxResult = MsgBox("Are you sure you wish to clear the irc servers for the network '" & _Network & "'?", vbYesNo)
                    If _MsgBoxResult = MsgBoxResult.Yes Then _RadListView.Items.Clear()
                Else
                    _RadListView.Items.Clear()
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdClearServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearServers.Click")
            End Try
        End Sub
        Public Sub cmdServersMove_Click(_Network As String, _Server As String)
            Try
                Dim f As frmChooseNetwork
                f = New frmChooseNetwork
                With f
                    .lChooseNetwork.lNetworkIndex = lSettings.FindNetworkIndex(_Network)
                    .lChooseNetwork.lServerToChange = lSettings.FindServerIndexByIp(_Server)
                    f.Show()
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click")
            End Try
        End Sub
        Public Function cmdConnectNow_Click(newStatus As Boolean, form As Form) As Boolean
            Dim result As Boolean
            'Try
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
            'Catch ex As Exception
            'Throw ex
            'End Try
        End Function
        Public Function cmdOK_Click(_NewStatus As Boolean, _Form As Form) As Boolean
            Dim _Result As Boolean, mbox As MsgBoxResult
            Try
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdOK_Click()")
                Return Nothing
            End Try
        End Function
        Public Sub cmdApplyNow_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdApplyNow_Click()")
            End Try
        End Sub
        Public Sub cmdCancelNow_Click(_Form As Form)
            Try
                _Form.Close()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdCancelNow_Click()")
            End Try
        End Sub
        Public Sub cboNetworks_SelectedIndexChanged(_Network As String, _ServersListView As RadListView)
            Try
                RefreshServers(_ServersListView, lSettings.FindNetworkIndex(_Network))
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cboNetworks_SelectedIndexChanged()")
            End Try
        End Sub
        Public Sub frmCustomize_FormClosed()
            Try
                lSettings.lWinVisible.wCustomize = False
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub frmCustomize_FormClosed()")
            End Try
        End Sub
        Public Sub cmdAddNickName_Click()
            Dim _AddNickName As New frmSharedAdd
            Try
                _AddNickName = New frmSharedAdd
                _AddNickName.lSharedAddUI.SharedAddType = eSharedAddType.sAddNickName
                _AddNickName.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdAddNickName_Click(_NickName As String)")
            End Try
        End Sub
        Public Sub cmdRemoveNickName(_RadDropDownList As RadDropDownList)
            Try
                _RadDropDownList.Items.Remove(_RadDropDownList.SelectedItem)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs)")
            End Try
        End Sub
        Public Sub cmdClearMyNickName_Click(_RadDropDownList As RadDropDownList)
            Try
                _RadDropDownList.Items.Clear()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdClearMyNickName_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearMyNickName.Click")
            End Try
        End Sub
        Public Sub cmdQuerySettings_Click()
            Dim _QuerySettings As frmQuerySettings
            Try
                _QuerySettings = New frmQuerySettings
                _QuerySettings.Show()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdQuerySettings_Click()")
            End Try
        End Sub
        Public Sub cmdClearNotify_Click(_NotifyListView As RadListView)
            Try
                lSettings.lNotify.nModified = True
                _NotifyListView.Items.Clear()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub cmdClearNotify_Click()")
            End Try
        End Sub
        Public Sub cmdNotifyAdd_Click(_NotifyListView As RadListView)
            Try
                Dim _Notify As New gNotify
                lSettings.lNotify.nModified = True
                AddToNotifyListView("Users Nickname", "Notify Message", "Network Name", _NotifyListView)
                _Notify.nNickName = "Users Nickname"
                _Notify.nMessage = "Notify Message"
                _Notify.nNetwork = "My Network"
                lSettings.AddToNotifyList(_Notify)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub cmdAddNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNotify.Click")
            End Try
        End Sub
        Public Sub lnkAddServer_Click(_Network As String)
            Dim addServer As frmAddServer
            Try
                If (Not String.IsNullOrEmpty(_Network)) Then
                    addServer = New frmAddServer
                    addServer.Show()
                    addServer.cboNetwork.Text = _Network
                Else
                    addServer = New frmAddServer
                    addServer.Show()
                    addServer.cboNetwork.Text = lStartupNetwork
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub lnkAddServer_Click(_NetworksDropDownList As RadDropDownList)")
            End Try
        End Sub
        Public Sub lnkNetworkAdd_Click()
            Try
                Dim lSharedAdd As New frmSharedAdd
                lSharedAdd.Show()
                lSharedAdd.lSharedAddUI.SharedAddType = eSharedAddType.sAddNetwork
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub lnkNetworkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNetwork.Click")
            End Try
        End Sub
        Public Sub Form_Load(_Form As Form, _CancelButton As RadButton, _ServersListView As RadListView)
            Try
                _Form.CancelButton = _CancelButton
                lSettings.lWinVisible.wCustomize = True
                With _ServersListView.Columns
                    .Clear()
                    .Add(New ListViewDetailColumn("Description", "Description"))
                    .Add(New ListViewDetailColumn("Server", "Server"))
                    .Add(New ListViewDetailColumn("Port", "Port"))
                End With
                _Form.Icon = mdiMain.Icon
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Form_Load(_Form As Form, _CancelButton As RadButton, _ServersListView As RadListView)")
            End Try
        End Sub
        Public Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String, ByVal lServerIP As String, _RadListView As RadListView)
            Try
                If Len(lNickName) <> 0 And Len(lMessage) <> 0 Then
                    Dim _Item As New Telerik.WinControls.UI.ListViewDataItem
                    _Item.Text = lNickName
                    _Item.SubItems.Add(lNickName)
                    _Item.SubItems.Add(lMessage)
                    _Item.SubItems.Add(lServerIP)
                    _RadListView.Items.Add(_Item)
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String)")
            End Try
        End Sub
        Public Sub ClearServers(_RadListView As RadListView)
            Try
                _RadListView.Items.Clear()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ClearServers(_RadListView As ListView)")
            End Try
        End Sub
        Public Sub RefreshNetworks(_RadDropDownList As RadDropDownList)
            Try
                Dim i As Integer
                _RadDropDownList.Items.Clear()
                For i = 1 To lSettings.lNetworks.nCount
                    With lSettings.lNetworks.nNetwork(i)
                        If Len(.nDescription) <> 0 Then
                            _RadDropDownList.Items.Add(.nDescription)
                        End If
                    End With
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub RefreshNetworks()")
            End Try
        End Sub
        Public Sub RefreshServers(_RadListView As RadListView, _NetworkIndex As Integer)
            Try
                Dim i As Integer, t As Integer = 0, _Ip As String = "", _Port As String = "", n As Integer = -1
                _RadListView.Items.Clear()
                If _NetworkIndex <> 0 Then
                    For i = 1 To lSettings.lServers.sCount
                        With lSettings.lServers.sServer(i)
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
                        If _DataItem.Text = lSettings.lServers.sServer(lSettings.lServers.sIndex).sDescription Then
                            n = t
                            Exit For
                        End If
                        t = t + 1
                    Next _DataItem
                    _RadListView.SelectedIndex = n
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub RefreshServers(ByVal lFirstLoad As Boolean)")
            End Try
        End Sub
        Public Sub txtNotifyNetwork_TextChanged(_NotifyNetwork As String, _NotifyListView As RadListView)
            Try
                If (_NotifyListView.SelectedItem IsNot Nothing) Then
                    _NotifyListView.SelectedItem.Item(2) = _NotifyNetwork
                    lSettings.lNotify.nModified = True
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub txtNotifyNetwork_TextChanged(_NotifyNetwork As String, _NotifyListView As RadListView)")
            End Try
        End Sub
        Public Sub txtNotifyMessage_TextChanged(_NotifyMessage As String, _NotifyListView As RadListView)
            Try
                If (_NotifyListView.SelectedItem IsNot Nothing) Then
                    _NotifyListView.SelectedItem.Item(1) = _NotifyMessage
                    lSettings.lNotify.nModified = True
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub txtNotifyMessage_TextChanged(_NotifyMessage As String, _NotifyListView As RadListView)")
            End Try
        End Sub
        Public Sub Apply_Settings_Servers(_ServersListView As RadListView, _SelectedNetwork As String)
            Try
                If (_ServersListView.SelectedItem IsNot Nothing) Then
                    If (_ServersListView.SelectedItem IsNot Nothing) Then lSettings.lServers.sIndex = lSettings.FindServerIndexByIp(_ServersListView.SelectedItem.Item(1).ToString)
                    lSettings.lNetworks.nIndex = lSettings.FindNetworkIndex(_SelectedNetwork)
                    If Not (lStatus.Connected(lStatus.ActiveIndex)) Then
                        lStatus.SetStatus(lStatus.ActiveIndex)
                    End If
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Servers(_ServersListView As RadListView, _NetworksDropDown As RadDropDownList)")
            End Try
        End Sub
        Public Sub Apply_Settings_Startup(
            _AutoConnect As Boolean,
            _ShowCustomize As Boolean,
            _ShowBrowser As Boolean
        )
            Try
                With lSettings.lIRC.iSettings
                    .sAutoConnect = _AutoConnect
                    .sCustomizeOnStartup = _ShowCustomize
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings_Startup")
            End Try
        End Sub
        Public Sub Apply_Settings_Text(_UnknownTextStatus As Boolean,
                                       _UnknownTextOwn As Boolean,
                                       _UnknownTextHide As Boolean,
                                       _UnSupportedTextStatus As Boolean,
                                       _UnSupportedTextOwn As Boolean,
                                       _UnSupportedTextHide As Boolean)
            Try
                If (_UnknownTextStatus) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uStatusWindow
                ElseIf (_UnknownTextOwn) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uOwnWindow
                ElseIf (_UnknownTextHide) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnknowns = eUnknownsIn.uHide
                End If
                If (_UnSupportedTextStatus) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnsupported = eUnsupportedIn.uStatusWindow
                ElseIf (_UnSupportedTextOwn) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnsupported = eUnsupportedIn.uOwnWindow
                ElseIf (_UnSupportedTextHide) Then
                    lSettings.lIRC.iSettings.sStringSettings.sUnsupported = eUnsupportedIn.uHide
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings_Text")
            End Try
        End Sub
        Public Sub Apply_Settings_IRC(
                                 _NoIrcMessages As Boolean,
                                 _ExtendedMessages As Boolean,
                                 _ShowUserAddresses As Boolean,
                                 _HideMotds As Boolean
        )
            Try
                With lSettings.lIRC.iSettings
                    .sNoIRCMessages = _NoIrcMessages
                    .sExtendedMessages = _ExtendedMessages
                    .sShowUserAddresses = _ShowUserAddresses
                    .sHideMOTD = _HideMotds
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings_IRC")
            End Try
        End Sub
        Public Sub Apply_Settings_ServerModes(
                                 _Invisible As Boolean,
                                 _Wallops As Boolean,
                                 _Restricted As Boolean,
                                 _Operator As Boolean,
                                 _LocalOp As Boolean,
                                 _ServerNotices As Boolean
        )
            Try
                With lSettings.lIRC.iModes
                    .mInvisible = _Invisible
                    .mLocalOperator = _LocalOp
                    .mOperator = _Operator
                    .mRestricted = _Restricted
                    .mServerNotices = _ServerNotices
                    .mWallops = _Wallops
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings_ServerModes()")
            End Try
        End Sub
        Public Sub Apply_Settings_Interface(
                                 _Prompts As Boolean,
                                 _AutoShowWindows As Boolean,
                                 _HideStatusOnClose As Boolean,
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
                                 _NoticesInOwnWindow As Boolean)
            Try
                With lSettings.lIRC.iSettings
                    .sPrompts = _Prompts
                    .sShowWindowsAutomatically = _AutoShowWindows
                    .sHideStatusOnClose = _HideStatusOnClose
                    .sAutoMaximize = _AutoMaximized
                    .sPopupChannelFolders = _PopupChannelFolder
                    .sVideoBackground = _VideoBackground
                    .sChangeNickNameWindow = _ShowNickNameWindow
                    .sChannelFolderCloseOnJoin = _CloseChannelFolder
                    .sAutoAddToChannelFolder = _AddToChannelFolder
                    .sAutoNavigateChannelUrls = _BrowseChannelUrls
                    .sHideStatusOnClose = _CloseStatusWindow
                    .sShowRawWindow = _ShowRawWindow
                    .sMOTDInOwnWindow = _MotdInOwnWindow
                    .sNoticesInOwnWindow = _NoticesInOwnWindow
                    'If lBrowserEnabled = True And .sShowBrowser = False Then
                    'mdiMain.CloseBrowser()
                    'ElseIf lBrowserEnabled = False And .sShowBrowser = True Then
                    'mdiMain.BrowseURL(lIRC.iSettings.sURL, False)
                    'mdiMain.ResizeBrowser()
                    'End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings(_Prompts As Boolean, _AutoShowWindows As Boolean, _HideStatusOnClose As Boolean, _AutoMaximized As Boolean)")
            End Try
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
            Try
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_Settings_DCC()")
            End Try
        End Sub
        Public Sub Apply_Settings_User(_NickNamesDropDownList As RadDropDownList, _HomePage As String, _UserEmail As String, _Password As String, _RealName As String, _OperName As String, _OperPassword As String)
            Try
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
                lSettings.lIRC.iNicks.nCount = _NickNamesDropDownList.Items.Count + 1
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
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Apply_User(_NickNamesDropDownList As RadDropDownList, _HomePage As String)")
            End Try
        End Sub
        Public Sub txtNotifyNickname_TextChanged(_NotifyNickName As String, _NotifyListView As RadListView)
            Try
                If (_NotifyListView.SelectedItem IsNot Nothing) Then
                    _NotifyListView.SelectedItem.Item(0) = _NotifyNickName
                    lSettings.lNotify.nModified = True
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub txtNotifyNickname_TextChanged(_NotifyNickNameTextBox As RadTextBox, _NotifyListView As ListView)")
            End Try
        End Sub
    End Class
End Namespace