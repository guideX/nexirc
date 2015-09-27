'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules
Imports System.Linq
Imports nexIRC.Settings
Imports Telerik.WinControls
Imports nexIRC.Business.Models
Imports nexIRC.Business.Enums

Public Class clsChannelFolderUI
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
        Try
            lStatusIndex = _StatusIndex
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub lstChannels_DoubleClick(ByVal _Channel As String, ByVal _AutoClose As Boolean)
        Try
            lChannels.Join(lStatusIndex, _Channel)
            If _AutoClose = True Then RaiseEvent FormClosed()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
        End Try
    End Sub
    Public Sub cmdAdd_Click(ByVal channel As String, ByVal network As String)
        Try
            Dim channelFolder = New ChannelFolderModel()
            'Dim channelFolder = New Global.nexIRC.IrcSettings.ChannelFolderModel()
            channelFolder.Channel = channel
            channelFolder.Network = network
            Dim s = New IrcSettings.IrcSettings(Application.StartupPath)
            s.ChannelFolders.Add(channelFolder)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Form_Load(ByVal dropDown As RadDropDownList)
        'Try
        'Dim i As Integer, msg As String
        RaiseEvent ClearNetworkComboBox()
        For Each network In Modules.IrcSettings.IrcNetworks.Get()
            dropDown.Items.Add(network.Description)
        Next network
        RaiseEvent SetDefaultNetwork(Modules.IrcSettings.IrcNetworks.GetDefault().Description)
        RaiseEvent SetPopupChannelFoldersCheckBoxValue(lSettings.lIRC.iSettings.sPopupChannelFolders)
        RaiseEvent SetAutoCloseCheckBoxValue(lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin)
        'Catch ex As Exception
        'Throw ex 'ProcessError(ex.Message, "Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Public Sub lstChannels_SelectedIndexChanged()
        Try
            RaiseEvent SetChannelTextBoxTextToListBoxText()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
        End Try
    End Sub
    Public Sub cmdRemove_Click(ByVal _Channel As String)
        Try
            RaiseEvent RemoveChannelListBoxItem(_Channel)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
        End Try
    End Sub

    Public Sub cboNetwork_SelectedIndexChanged(ByVal _Network As String)
        'Try
        RaiseEvent ClearChannelsListBox()
        Dim channelFolders = Modules.IrcSettings.ChannelFolders.Get(_Network)
        For Each channelFolder In channelFolders
            RaiseEvent AddChannelToListBox(channelFolder.Channel)
        Next channelFolder
        'Catch ex As Exception
        'Throw ex 'ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        'End Try
    End Sub
    Public Sub Form_FormClosed(ByVal _PopupOnConnect As Boolean, ByVal _AutoClose As Boolean, ByVal _Left As Integer, ByVal _Top As Integer)
        Try
            lSettings.lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect
            lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cmdClose_Click()
        Try
            'lSettings.SaveChannelFolders()
            RaiseEvent AnimateClose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cmdJoin_Click(ByVal _Channel As String, ByVal _AutoClose As Boolean)
        Try
            If Len(_Channel) <> 0 Then
                If _AutoClose = True Then RaiseEvent FormClosed()
                lChannels.Join(lStatusIndex, _Channel)
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
        End Try
    End Sub
    Public Event AnimateClose()
    Public Sub lnkJumpToChannelList_LinkClicked()
        Try
            lStrings.ProcessReplaceCommand(lStatusIndex, IrcCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex))
            RaiseEvent AnimateClose()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "lnkJumpToChannelList_LinkClicked")
        End Try
    End Sub
    Public Sub txtChannel_Enter(ByVal _MouseButtons As Windows.Forms.MouseButtons, ByVal _Sender As Object)
        Try
            If _MouseButtons = Windows.Forms.MouseButtons.None Then lLastFocused = CType(_Sender, Control)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
        End Try
    End Sub
    Public Sub txtChannel_Leave()
        Try
            lLastFocused = Nothing
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
        End Try
    End Sub
    Private Sub txtChannel_GotFocus(ByVal _ChannelTextBox As RadTextBox)
        Try
            RaiseEvent ChannelTextBoxSelectAll()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
        End Try
    End Sub
    Public Sub txtChannel_MouseUp(ByVal sender As Object)
        Try
            With CType(sender, RadTextBox)
                If lLastFocused IsNot sender AndAlso .SelectionLength = 0 Then .SelectAll()
            End With
            lLastFocused = CType(sender, Control)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
        End Try
    End Sub
End Class
Public Class clsChannelFolder
    Public lVisible As Boolean
    Private WithEvents lWindow As frmChannelFolder
    Public Sub Show(ByVal _StatusIndex As Integer)
        Try
            ShowWindow()
            SetStatusIndex(_StatusIndex)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub Show(_StatusIndex As Integer)")
        End Try
    End Sub
    Private Sub ShowWindow()
        Try
            lWindow = New frmChannelFolder
            lWindow.Show()
            lVisible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub RefreshChannelFolderChannelList()
        Try
            If (lVisible = True) Then
                lWindow.Init()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetStatusIndex(ByVal _StatusIndex As Integer)
        Try
            lWindow.SetStatusIndex(_StatusIndex)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(_StatusIndex As Integer)")
        End Try
    End Sub
    Private Sub lWindow_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed
        Try
            lVisible = False
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lWindow_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed")
        End Try
    End Sub
    Public Function Window() As Form
        Try
            Return lWindow
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Function Window() As Form")
            Return Nothing
        End Try
    End Function
End Class