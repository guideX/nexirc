'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Public Class clsChannelFolderWindow
    Private lStatusIndex As Integer
    Private lLastFocused As Control = Nothing
    Public Sub SetStatusIndex(ByVal _StatusIndex As Integer)
        Try
            lStatusIndex = _StatusIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub lstChannels_DoubleClick(_Channel As String, _AutoClose As Boolean, _Form As Form)
        Try
            lChannels.Join(lStatusIndex, _Channel)
            If _AutoClose = True Then _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
        End Try
    End Sub
    Public Sub cmdAdd_Click(_Channel As String, _ListBox As RadListControl, _Network As String)
        Try
            Dim i As Integer
            If Len(_Channel) <> 0 Then
                _ListBox.Items.Add(_Channel)
                i = FindNetworkIndex(_Network)
                If i <> 0 Then
                    AddToChannelFolders(_Channel, i)
                End If
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click")
        End Try
    End Sub
    Public Sub Init(_NetworksComboBox As RadDropDownList, _PopupOnConnectCheckBox As RadCheckBox, _AutoCloseCheckBox As RadCheckBox)
        Dim i As Integer, msg As String
        _NetworksComboBox.Items.Clear()
        For i = 1 To lNetworks.nCount
            With lNetworks.nNetwork(i)
                'MessageBox.Show(.nDescription)
                If Len(.nDescription.Trim) <> 0 Then _NetworksComboBox.Items.Add(.nDescription)
            End With
        Next i
        msg = lNetworks.nNetwork(lStatus.NetworkIndex(lStatus.ActiveIndex())).nDescription
        For i = 0 To _NetworksComboBox.Items.Count - 1
            If LCase(Trim(msg)) = LCase(Trim(_NetworksComboBox.Items(i).ToString)) Then
                _NetworksComboBox.SelectedIndex = i
                Exit For
            End If
        Next i
    End Sub
    Public Sub Form_Load(_Form As Form, _NetworksComboBox As RadDropDownList, _PopupOnConnectCheckBox As RadCheckBox, _AutoCloseCheckBox As RadCheckBox)
        Try
            Init(_NetworksComboBox, _PopupOnConnectCheckBox, _AutoCloseCheckBox)
            _PopupOnConnectCheckBox.Checked = lIRC.iSettings.sPopupChannelFolders
            _AutoCloseCheckBox.Checked = lIRC.iSettings.sChannelFolderCloseOnJoin
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Public Sub lstChannels_SelectedIndexChanged(_RadListBox As RadListControl, _ChannelTextBox As RadTextBox)
        Try
            If (_RadListBox.SelectedItem IsNot Nothing) Then
                _ChannelTextBox.Text = _RadListBox.SelectedItem.Text
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
        End Try
    End Sub
    Public Sub cmdRemove_Click(_Channel As String, _ChannelsListBox As RadListControl)
        Try
            Dim i As Integer
            If Len(_Channel) <> 0 Then
                RemoveChannelFolder(FindChannelFolderIndex(_Channel))
                i = ReturnRadListBoxIndex(_ChannelsListBox, _ChannelsListBox.SelectedItem().ToString)
                _ChannelsListBox.Items.RemoveAt(i)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
        End Try
    End Sub
    Public Sub cboNetwork_SelectedIndexChanged(_ChannelsListBox As RadListControl, _Network As String)
        Try
            Dim i As Integer
            _ChannelsListBox.Items.Clear()
            For i = 1 To lChannelFolders.cCount
                If lNetworks.nNetwork(FindNetworkIndex(lChannelFolders.cChannelFolder(i).cNetwork)).nDescription.Trim().ToLower() = _Network.Trim().ToLower() Then
                    If (lChannelFolders.cChannelFolder(i).cChannel.Trim().Length() <> 0) Then
                        _ChannelsListBox.Items.Add(lChannelFolders.cChannelFolder(i).cChannel)
                    End If
                End If
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        End Try
    End Sub
    Public Sub Form_FormClosed(_PopupOnConnect As Boolean, _AutoClose As Boolean, _Left As Integer, _Top As Integer)
        Try
            lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect
            lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose
            'clsFiles.WriteINI(lINI.iChannelFolders, "Settings", "Left", _Left.ToString())
            'clsFiles.WriteINI(lINI.iChannelFolders, "Settings", "Top", _Top.ToString())
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub frmChannelFolder_FormClosed(_PopupOnConnect As Boolean, _AutoClose As Boolean, _Left As Integer, _Top As Integer)")
        End Try
    End Sub
    Public Sub cmdClose_Click(_Form As Form)
        Try
            SaveChannelFolders()
            clsAnimate.Animate(_Form, clsAnimate.Effect.Center, 200, 1)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Form_Closed(lCloseWindow As Boolean)")
        End Try
    End Sub
    Public Sub cmdJoin_Click(_Channel As String, _AutoClose As Boolean, _Form As Form)
        Try
            If Len(_Channel) <> 0 Then
                If _AutoClose = True Then _Form.Close()
                lChannels.Join(lStatusIndex, _Channel)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
        End Try
    End Sub
    Public Sub lnkJumpToChannelList_LinkClicked(_Form As Form)
        Try
            ProcessReplaceCommand(lStatusIndex, eCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex))
            clsAnimate.Animate(_Form, clsAnimate.Effect.Center, 200, 1)
            _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "lnkJumpToChannelList_LinkClicked")
        End Try
    End Sub
    Public Sub txtChannel_Enter(_MouseButtons As Windows.Forms.MouseButtons, _Sender As Object)
        Try
            If _MouseButtons = Windows.Forms.MouseButtons.None Then lLastFocused = CType(_Sender, Control)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
        End Try
    End Sub
    Public Sub txtChannel_Leave()
        Try
            lLastFocused = Nothing
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
        End Try
    End Sub
    Private Sub txtChannel_GotFocus(_ChannelTextBox As RadTextBox)
        Try
            _ChannelTextBox.SelectAll()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
        End Try
    End Sub
    Public Sub txtChannel_MouseUp(sender As Object)
        Try
            With CType(sender, TextBox)
                If lLastFocused IsNot sender AndAlso .SelectionLength = 0 Then .SelectAll()
            End With
            lLastFocused = CType(sender, Control)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
        End Try
    End Sub
End Class
Public Class clsChannelFolder
    Public lVisible As Boolean
    Private WithEvents lWindow As frmChannelFolder
    Public Sub Show(_StatusIndex As Integer)
        Try
            ShowWindow()
            SetStatusIndex(_StatusIndex)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub Show(_StatusIndex As Integer)")
        End Try
    End Sub
    Private Sub ShowWindow()
        Try
            lWindow = New frmChannelFolder
            'lWindow.Left = CInt(Trim(clsFiles.ReadINI(lINI.iChannelFolders, "Settings", "Left", "300")))
            'lWindow.Top = CInt(Trim(clsFiles.ReadINI(lINI.iChannelFolders, "Settings", "Top", "300")))
            clsAnimate.Animate(lWindow, clsAnimate.Effect.Center, 200, 1)
            lVisible = True
            'lWindow.Show()
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ShowWindow()")
        End Try
    End Sub
    Public Sub RefreshChannelFolderChannelList()
        Try
            If (lVisible = True) Then
                lWindow.Init()
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub RefreshChannelFolderChannelList()")
        End Try
    End Sub
    Private Sub SetStatusIndex(_StatusIndex As Integer)
        Try
            lWindow.SetStatusIndex(_StatusIndex)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(_StatusIndex As Integer)")
        End Try
    End Sub
    Private Sub lWindow_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed
        Try
            lVisible = False
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub lWindow_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed")
        End Try
    End Sub
    Public Function Window() As Form
        Return lWindow
    End Function
End Class