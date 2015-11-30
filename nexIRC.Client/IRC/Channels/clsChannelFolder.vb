Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Business.Enums
Imports nexIRC.Business.Repositories
Imports nexIRC.Business.Models.ChannelFolder

Namespace nexIRC.Client.IRC.Channels
    Public Class clsChannelFolderUI
        Public Event AnimateClose()
        Private lStatusIndex As Integer
        Private lLastFocused As Control = Nothing
        Public Event FormClosed()
        Public Event AddChannelToListBox(ByVal _Channel As String)
        Public Event ClearNetworkComboBox()
        Public Event AddNetworkComboBoxItem(ByVal _Network As String)
        Public Event SetDefaultNetwork(ByVal _Network As String)
        Public Event SetPopupChannelFoldersCheckBoxValue(ByVal _Value As Boolean)
        Public Event SetAutoCloseCheckBoxValue(ByVal _Value As Boolean)
        Public Event SetChannelTextBoxTextToListBoxText()
        Public Event RemoveChannelListBoxItem(ByVal _Channel As String)
        Public Event ClearChannelsListBox()
        Public Event ChannelTextBoxSelectAll()

        Public Sub SetStatusIndex(ByVal _StatusIndex As Integer)
            lStatusIndex = _StatusIndex
        End Sub

        Public Sub lstChannels_DoubleClick(ByVal _Channel As String, ByVal _AutoClose As Boolean)
            Modules.lChannels.Join(lStatusIndex, _Channel)
            If _AutoClose = True Then RaiseEvent FormClosed()
        End Sub

        Public Sub cmdAdd_Click(ByVal channel As String, ByVal network As String)
            Dim channelFolder = New ChannelFolderModel()
            channelFolder.Channel = channel
            channelFolder.Network = network
            Dim s = New IrcSettings(Application.StartupPath)
            s.ChannelFoldersRepository.Add(channelFolder)
        End Sub

        Public Sub Form_Load(ByVal dropDown As RadDropDownList)
            RaiseEvent ClearNetworkComboBox()
            For Each network In Modules.IrcSettings.IrcNetworks.Get()
                dropDown.Items.Add(network.Description)
            Next network
            RaiseEvent SetDefaultNetwork(Modules.IrcSettings.IrcNetworks.GetDefault().Description)
            RaiseEvent SetPopupChannelFoldersCheckBoxValue(Modules.lSettings.lIRC.iSettings.sPopupChannelFolders)
            RaiseEvent SetAutoCloseCheckBoxValue(Modules.lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin)
        End Sub

        Public Sub lstChannels_SelectedIndexChanged()
            RaiseEvent SetChannelTextBoxTextToListBoxText()
        End Sub

        Public Sub cmdRemove_Click(ByVal _Channel As String)
            RaiseEvent RemoveChannelListBoxItem(_Channel)
        End Sub

        Public Sub cboNetwork_SelectedIndexChanged(ByVal _Network As String)
            RaiseEvent ClearChannelsListBox()
            Dim channelFolders = Modules.IrcSettings.ChannelFoldersRepository.Get(_Network)
            For Each cfm As ChannelFolderModel In channelFolders
                RaiseEvent AddChannelToListBox(cfm.Channel)
            Next cfm
        End Sub

        Public Sub Form_FormClosed(ByVal _PopupOnConnect As Boolean, ByVal _AutoClose As Boolean, ByVal _Left As Integer, ByVal _Top As Integer)
            Modules.lSettings.lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect
            Modules.lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose
        End Sub

        Public Sub cmdClose_Click()
            RaiseEvent AnimateClose()
        End Sub

        Public Sub cmdJoin_Click(ByVal _Channel As String, ByVal _AutoClose As Boolean)
            If Len(_Channel) <> 0 Then
                If _AutoClose = True Then RaiseEvent FormClosed()
                Modules.lChannels.Join(lStatusIndex, _Channel)
            End If
        End Sub

        Public Sub lnkJumpToChannelList_LinkClicked()
            Modules.lStrings.ProcessReplaceCommand(lStatusIndex, IrcCommandTypes.cLIST, Modules.lStatus.Description(Modules.lStatus.ActiveIndex))
            RaiseEvent AnimateClose()
        End Sub

        Public Sub txtChannel_Enter(ByVal _MouseButtons As Windows.Forms.MouseButtons, ByVal _Sender As Object)
            If _MouseButtons = Windows.Forms.MouseButtons.None Then lLastFocused = CType(_Sender, Control)
        End Sub

        Public Sub txtChannel_Leave()
            lLastFocused = Nothing
        End Sub

        Private Sub txtChannel_GotFocus(ByVal _ChannelTextBox As RadTextBox)
            RaiseEvent ChannelTextBoxSelectAll()
        End Sub

        Public Sub txtChannel_MouseUp(ByVal sender As Object)
            With CType(sender, RadTextBox)
                If lLastFocused IsNot sender AndAlso .SelectionLength = 0 Then .SelectAll()
            End With
            lLastFocused = CType(sender, Control)
        End Sub
    End Class

    Public Class clsChannelFolder
        Public lVisible As Boolean
        Private WithEvents lWindow As frmChannelFolder

        Public Sub Show(ByVal _StatusIndex As Integer)
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

        Private Sub SetStatusIndex(ByVal _StatusIndex As Integer)
            lWindow.SetStatusIndex(_StatusIndex)
        End Sub

        Private Sub lWindow_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed
            lVisible = False
        End Sub

        Public Function Window() As Form
            Return lWindow
        End Function
    End Class
End Namespace