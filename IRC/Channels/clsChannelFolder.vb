'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports nexIRC.Models.ChannelFolder

Public Class clsChannelFolderUI
    Private lStatusIndex As Integer
    Private lLastFocused As Control = Nothing
    Public Event FormClosed()
    Public Event AddChannelToListBox(_Channel As String)
    Public Event ClearNetworkComboBox()
    Public Event AddNetworkComboBoxItem(_Network As String)
    Public Event SetDefaultNetwork(_Network As String)
    Public Event SetPopupChannelFoldersCheckBoxValue(_Value As Boolean)
    Public Event SetAutoCloseCheckBoxValue(_Value As Boolean)
    Public Event SetChannelTextBoxTextToListBoxText()
    Public Event RemoveChannelListBoxItem(_Channel As String)
    Public Event ClearChannelsListBox()
    Public Event ChannelTextBoxSelectAll()
    Public Sub SetStatusIndex(ByVal _StatusIndex As Integer)
        lStatusIndex = _StatusIndex
    End Sub
    Public Sub lstChannels_DoubleClick(_Channel As String, _AutoClose As Boolean)
        lChannels.Join(lStatusIndex, _Channel)
        If _AutoClose = True Then RaiseEvent FormClosed()
    End Sub
    Public Sub cmdAdd_Click(_Channel As String, _Network As String)
        Dim i As Integer
        If Len(_Channel) <> 0 Then
            RaiseEvent AddChannelToListBox(_Channel)
            i = lSettings.FindNetworkIndex(_Network)
            If i <> 0 Then
                lSettings.AddToChannelFolders(_Channel, i)
            End If
        End If
    End Sub
    Public Sub Init()
        For i = 0 To lSettings.lNetworks.Networks.Count - 1
            With lSettings.lNetworks.Networks(i)
                If Len(.Name.Trim) <> 0 Then RaiseEvent AddNetworkComboBoxItem(.Name)
            End With
        Next i
    End Sub
    Public Sub Form_Load()
        Dim msg As String
        RaiseEvent ClearNetworkComboBox()
        Init()
        msg = lSettings.lNetworks.Networks(lStatus.NetworkIndex(lStatus.ActiveIndex())).Name
        RaiseEvent SetDefaultNetwork(msg)
        RaiseEvent SetPopupChannelFoldersCheckBoxValue(lSettings.lIRC.iSettings.sPopupChannelFolders)
        RaiseEvent SetAutoCloseCheckBoxValue(lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin)
    End Sub
    Public Sub lstChannels_SelectedIndexChanged()
        RaiseEvent SetChannelTextBoxTextToListBoxText()
    End Sub
    Public Sub cmdRemove_Click(_Channel As String)
        RaiseEvent RemoveChannelListBoxItem(_Channel)
    End Sub
    Private Function ReturnListOfChannels(network As String) As List(Of String)
        Dim channels As New List(Of String), n As Integer, msg As String
        For Each channelFolder As ChannelFolderModel In lSettings.lChannelFolders.OrderBy(Function(f) f.Order)
            n = lSettings.FindNetworkIndex(channelFolder.Network)
            msg = lSettings.lNetworks.Networks(n).Name
            If (Not String.IsNullOrEmpty(msg)) Then
                If (msg.Trim().ToLower() = network.Trim().ToLower()) Then
                    If (channelFolder.Channel.Trim().Length() <> 0) Then
                        channels.Add(channelFolder.Channel)
                    End If
                End If
            End If
        Next channelFolder
        channels = channels.OrderBy(Function(c) c).ToList()
        Return channels
    End Function
    Public Sub cboNetwork_SelectedIndexChanged(_Network As String)
        Dim channels As List(Of String)
        RaiseEvent ClearChannelsListBox()
        channels = ReturnListOfChannels(_Network)
        For Each channel As String In channels
            RaiseEvent AddChannelToListBox(channel)
        Next channel
    End Sub
    Public Sub Form_FormClosed(_PopupOnConnect As Boolean, _AutoClose As Boolean, _Left As Integer, _Top As Integer)
        lSettings.lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect
        lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose
    End Sub
    Public Sub cmdClose_Click()
        lSettings.SaveChannelFolders()
        RaiseEvent AnimateClose()
    End Sub
    Public Sub cmdJoin_Click(_Channel As String, _AutoClose As Boolean)
        If Len(_Channel) <> 0 Then
            If _AutoClose = True Then RaiseEvent FormClosed()
            lChannels.Join(lStatusIndex, _Channel)
        End If
    End Sub
    Public Event AnimateClose()
    Public Sub lnkJumpToChannelList_LinkClicked()
        lStrings.ProcessReplaceCommand(lStatusIndex, eCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex))
        RaiseEvent AnimateClose()
    End Sub
    Public Sub txtChannel_Enter(_MouseButtons As Windows.Forms.MouseButtons, _Sender As Object)
        If _MouseButtons = Windows.Forms.MouseButtons.None Then lLastFocused = CType(_Sender, Control)
    End Sub
    Public Sub txtChannel_Leave()
        lLastFocused = Nothing
    End Sub
    Private Sub txtChannel_GotFocus(_ChannelTextBox As RadTextBox)
        RaiseEvent ChannelTextBoxSelectAll()
    End Sub
    Public Sub txtChannel_MouseUp(sender As Object)
        With CType(sender, TextBox)
            If lLastFocused IsNot sender AndAlso .SelectionLength = 0 Then .SelectAll()
        End With
        lLastFocused = CType(sender, Control)
    End Sub
End Class
Public Class clsChannelFolder
    Public lVisible As Boolean
    Private WithEvents lWindow As frmChannelFolder
    Public Sub Show(_StatusIndex As Integer)
        ShowWindow()
        SetStatusIndex(_StatusIndex)
    End Sub
    Private Sub ShowWindow()
        lWindow = New frmChannelFolder
        lWindow.Show()
        lVisible = True
    End Sub
    Public Sub RefreshChannelFolderChannelList()
        If (lVisible = True) Then
            lWindow.Init()
        End If
    End Sub
    Private Sub SetStatusIndex(_StatusIndex As Integer)
        lWindow.SetStatusIndex(_StatusIndex)
    End Sub
    Private Sub lWindow_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed
        lVisible = False
    End Sub
    Public Function Window() As Form
        Return lWindow
    End Function
End Class