Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Public Class clsCustomize
    Public lBrowserEnabled As Boolean
    Public Sub lvwNotify_SelectedIndexChanged(_NotifyListView As RadListView, _NotifyNickNameTextBox As RadTextBox, _NotifyMessageTextBox As RadTextBox, _NetworkNotifyDropDownList As RadDropDownList)
        Try
            Dim i As Integer, n As Integer
            For i = 0 To _NotifyListView.SelectedItems.Count - 1
                n = FindNotifyIndex(_NotifyListView.SelectedItems(i).Text)
                _NotifyNickNameTextBox.Text = lNotify.nNotify(n).nNickName
                _NotifyMessageTextBox.Text = lNotify.nNotify(n).nMessage
                _NetworkNotifyDropDownList.SelectedItem = _NetworkNotifyDropDownList.Items(FindRadComboIndex(_NetworkNotifyDropDownList, lNotify.nNotify(n).nNetwork))
                Exit For
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub lvwNotify_SelectedIndexChanged(_NotifyListView As RadListView, _NotifyNickNameTextBox As RadTextBox, _NotifyMessageTextBox As RadTextBox, _NetworkNotify As RadTextBox, _NetworkNotifyDropDownList As RadDropDownList)")
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
                n = FindStringIndexByDescription(lItem.Text)
                For i = 1 To 6
                    msg = clsFiles.ReadINI(lINI.iText, Trim(CStr(n)), "Find" & Trim(Str(i)), "")
                    If Len(msg) <> 0 Then f.lstParameters.Items.Add(msg)
                Next i
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdEditString_Click()")
        End Try
    End Sub
    Public Sub cmdServersClear_Click(_Network As String, _RadListView As RadListView)
        Try
            Dim _MsgBoxResult As MsgBoxResult
            If lIRC.iSettings.sPrompts = True Then
                _MsgBoxResult = MsgBox("Are you sure you wish to clear the irc servers for the network '" & _Network & "'?", vbYesNo)
                If _MsgBoxResult = MsgBoxResult.Yes Then _RadListView.Items.Clear()
            Else
                _RadListView.Items.Clear()
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdClearServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearServers.Click")
        End Try
    End Sub
    Public Sub cmdServersMove_Click(_Network As String, _Server As String)
        Try
            Dim f As frmChooseNetwork
            f = New frmChooseNetwork
            With f
                .lChooseNetwork.lNetworkIndex = FindNetworkIndex(_Network)
                .lChooseNetwork.lServerToChange = FindServerIndexByIp(_Server)
                clsAnimate.Animate(f, clsAnimate.Effect.Center, 200, 1)
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdServersMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdServersMove.Click")
        End Try
    End Sub
    Public Function cmdConnectNow_Click(_NewStatus As Boolean, _Form As Form) As Boolean
        Dim _Result As Boolean
        Try
            _Result = False
            If _NewStatus = True Then
                lStatus.Create(lIRC, lServers)
                Application.DoEvents()
            End If
            If lStatus.ActiveIndex() <> 0 Then
                _Result = True
                lStatus.ActiveStatusConnect()
            End If
            _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdConnectNow_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectNow.Click")
        End Try
    End Function
    Public Function cmdOK_Click(_NewStatus As Boolean, _Form As Form) As Boolean
        Dim mbox As MsgBoxResult, _Result As Boolean
        Try
            _Result = False
            If _NewStatus = True Then
                lStatus.Create(lIRC, lServers)
                Application.DoEvents()
            End If
            If lStatus.Connected(lStatus.ActiveIndex) = False Then
                _Result = True
                SaveSettings()
                _Form.Close()
            Else
                If lIRC.iSettings.sPrompts = True Then
                    mbox = MsgBox("You are currently connected on this status window, you will not be able to change the server settings if you continue, would you like to continue anyways?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                Else
                    mbox = MsgBoxResult.Yes
                End If
                If mbox = MsgBoxResult.Yes Then
                    _Result = True
                    SaveSettings()
                    _Form.Close()
                End If
            End If
            Return _Result
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdOK_Click()")
            Return Nothing
        End Try
    End Function
    Public Sub cmdApplyNow_Click(_Form As Form)
        Try
            _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdApplyNow_Click()")
        End Try
    End Sub
    Public Sub cmdCancelNow_Click(_Form As Form)
        Try
            clsAnimate.Animate(_Form, clsAnimate.Effect.Center, 200, 1)
            _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdCancelNow_Click()")
        End Try
    End Sub
    Public Sub cboNetworks_SelectedIndexChanged(_Network As String, _ServersListView As RadListView)
        Try
            lNetworks.nIndex = FindNetworkIndex(_Network)
            RefreshServers(_ServersListView)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cboNetworks_SelectedIndexChanged()")
        End Try
    End Sub
    Public Sub frmCustomize_FormClosed()
        Try
            lWinVisible.wCustomize = False
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub frmCustomize_FormClosed()")
        End Try
    End Sub
    Public Sub cmdAddNickName_Click()
        Dim _AddNickName As frmAddNickname
        Try
            _AddNickName = New frmAddNickname
            clsAnimate.Animate(_AddNickName, clsAnimate.Effect.Center, 200, 1)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdAddNickName_Click(_NickName As String)")
        End Try
    End Sub
    Public Sub cmdRemoveNickName(_RadDropDownList As RadDropDownList)
        Try
            _RadDropDownList.Items.Remove(_RadDropDownList.SelectedItem)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs)")
        End Try
    End Sub
    Public Sub cmdClearMyNickName_Click(_RadDropDownList As RadDropDownList)
        Try
            _RadDropDownList.Items.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdClearMyNickName_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearMyNickName.Click")
        End Try
    End Sub
    Public Sub cmdEditUserSettings_Click()
        Dim _EditUserProfile As frmEditUserProfile
        Try
            _EditUserProfile = New frmEditUserProfile
            _EditUserProfile.Show()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdEditUserSettings()")
        End Try
    End Sub
    Public Sub cmdQuerySettings_Click()
        Dim _QuerySettings As frmQuerySettings
        Try
            _QuerySettings = New frmQuerySettings
            _QuerySettings.Show()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdQuerySettings_Click()")
        End Try
    End Sub
    Public Sub cmdClearNotify_Click(_NotifyListView As RadListView)
        Try
            lNotify.nModified = True
            _NotifyListView.Items.Clear()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub cmdClearNotify_Click()")
        End Try
    End Sub
    Public Sub cmdNotifyAdd_Click(_NotifyNickName As String, _NotifyMessage As String, _NotifyNetwork As String, _NotifyListView As RadListView)
        Try
            If _NotifyNickName.Length <> 0 And _NotifyMessage.Length <> 0 Then
                lNotify.nModified = True
                AddToNotifyListView(_NotifyNickName, _NotifyMessage, _NotifyNetwork, _NotifyListView)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdAddNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNotify.Click")
        End Try
    End Sub
    Public Sub lnkAddServer_Click(_Network As String)
        Try
            clsAnimate.Animate(frmAddServer, clsAnimate.Effect.Center, 200, 1)
            frmAddServer.lAddServer.Network = _Network
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub lnkAddServer_Click(_NetworksDropDownList As RadDropDownList)")
        End Try
    End Sub
    Public Sub lnkNetworkAdd_Click()
        Try
            Dim lSharedAdd As New frmSharedAdd
            clsAnimate.Animate(lSharedAdd, clsAnimate.Effect.Center, 200, 1)
            lSharedAdd.lSharedAddType = frmSharedAdd.eSharedAddType.sAddNetwork
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lnkNetworkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNetwork.Click")
        End Try
    End Sub
    Public Sub Form_Load(_Form As Form, _CancelButton As RadButton, _ServersListView As RadListView)
        Try
            _Form.CancelButton = _CancelButton
            lWinVisible.wCustomize = True
            With _ServersListView.Columns
                .Clear()
                .Add(New ListViewDetailColumn("Description", "Description"))
                .Add(New ListViewDetailColumn("Server", "Server"))
                .Add(New ListViewDetailColumn("Port", "Port"))
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Load(_Form As Form, _CancelButton As RadButton, _ServersListView As RadListView)")
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
            ProcessError(ex.Message, "Private Sub AddToNotifyListView(ByVal lNickName As String, ByVal lMessage As String)")
        End Try
    End Sub
    Public Sub RefreshNetworks(_RadDropDownList As RadDropDownList)
        Try
            Dim i As Integer
            _RadDropDownList.Items.Clear()
            For i = 1 To lNetworks.nCount
                With lNetworks.nNetwork(i)
                    If Len(.nDescription) <> 0 Then
                        _RadDropDownList.Items.Add(.nDescription)
                    End If
                End With
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub RefreshNetworks()")
        End Try
    End Sub
    Public Sub RefreshServers(_RadListView As RadListView)
        Try
            Dim i As Integer, t As Integer = 0, _Ip As String = "", _Port As String = "", n As Integer = -1
            _RadListView.Items.Clear()
            If lNetworks.nIndex <> 0 Then
                For i = 1 To lServers.sCount
                    With lServers.sServer(i)
                        If Len(.sDescription) <> 0 Then
                            If .sNetworkIndex = lNetworks.nIndex Then
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
                    If _DataItem.Text = lServers.sServer(lServers.sIndex).sDescription Then
                        n = t
                    End If
                    t = t + 1
                Next _DataItem
                _RadListView.SelectedIndex = n
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub RefreshServers(ByVal lFirstLoad As Boolean)")
        End Try
    End Sub
End Class