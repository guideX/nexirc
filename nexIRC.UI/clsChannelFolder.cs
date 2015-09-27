using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nexIRC.UI
{
    public class clsChannelFolderUI
    {
        private int lStatusIndex;
        private Control lLastFocused = null;
        public event FormClosedEventHandler FormClosed;
        public delegate void FormClosedEventHandler();
        public event AddChannelToListBoxEventHandler AddChannelToListBox;
        public delegate void AddChannelToListBoxEventHandler(string _Channel);
        public event ClearNetworkComboBoxEventHandler ClearNetworkComboBox;
        public delegate void ClearNetworkComboBoxEventHandler();
        public event AddNetworkComboBoxItemEventHandler AddNetworkComboBoxItem;
        public delegate void AddNetworkComboBoxItemEventHandler(string _Network);
        public event SetDefaultNetworkEventHandler SetDefaultNetwork;
        public delegate void SetDefaultNetworkEventHandler(string _Network);
        public event SetPopupChannelFoldersCheckBoxValueEventHandler SetPopupChannelFoldersCheckBoxValue;
        public delegate void SetPopupChannelFoldersCheckBoxValueEventHandler(bool _Value);
        public event SetAutoCloseCheckBoxValueEventHandler SetAutoCloseCheckBoxValue;
        public delegate void SetAutoCloseCheckBoxValueEventHandler(bool _Value);
        public event SetChannelTextBoxTextToListBoxTextEventHandler SetChannelTextBoxTextToListBoxText;
        public delegate void SetChannelTextBoxTextToListBoxTextEventHandler();
        public event RemoveChannelListBoxItemEventHandler RemoveChannelListBoxItem;
        public delegate void RemoveChannelListBoxItemEventHandler(string _Channel);
        public event ClearChannelsListBoxEventHandler ClearChannelsListBox;
        public delegate void ClearChannelsListBoxEventHandler();
        public event ChannelTextBoxSelectAllEventHandler ChannelTextBoxSelectAll;
        public delegate void ChannelTextBoxSelectAllEventHandler();
        public void SetStatusIndex(int _StatusIndex)
        {
            try
            {
                lStatusIndex = _StatusIndex;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
            }
        }
        public void lstChannels_DoubleClick(string _Channel, bool _AutoClose)
        {
            try
            {
                lChannels.Join(lStatusIndex, _Channel);
                if (_AutoClose == true)
                    if (FormClosed != null)
                    {
                        FormClosed();
                    }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub lstChannels_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstChannels.DoubleClick")
            }
        }
        public void cmdAdd_Click(string channel, string network)
        {
            try
            {
                object channelFolder = new global::nexIRC.IrcSettings.ChannelFolderModel();
                channelFolder.Channel = channel;
                channelFolder.Network = network;
                Modules.IrcSettings.ChannelFolders.Add(channelFolder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Form_Load(RadDropDownList dropDown)
	{
		//Try
		//Dim i As Integer, msg As String
		if (ClearNetworkComboBox != null) {
			ClearNetworkComboBox();
		}
		foreach (void network_loopVariable in Modules.IrcSettings.IrcNetworks.Get()) {
			network = network_loopVariable;
			dropDown.Items.Add(network.Description);
		}
		if (SetDefaultNetwork != null) {
			SetDefaultNetwork(Modules.IrcSettings.IrcNetworks.GetDefault().Description);
		}
		if (SetPopupChannelFoldersCheckBoxValue != null) {
			SetPopupChannelFoldersCheckBoxValue(lSettings.lIRC.iSettings.sPopupChannelFolders);
		}
		if (SetAutoCloseCheckBoxValue != null) {
			SetAutoCloseCheckBoxValue(lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin);
		}
		//Catch ex As Exception
		//Throw ex 'ProcessError(ex.Message, "Private Sub frmChannelFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
		//End Try
	}
        public void lstChannels_SelectedIndexChanged()
        {
            try
            {
                if (SetChannelTextBoxTextToListBoxText != null)
                {
                    SetChannelTextBoxTextToListBoxText();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub lstChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstChannels.SelectedIndexChanged")
            }
        }
        public void cmdRemove_Click(string _Channel)
        {
            try
            {
                if (RemoveChannelListBoxItem != null)
                {
                    RemoveChannelListBoxItem(_Channel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click")
            }
        }

        public void cboNetwork_SelectedIndexChanged(string _Network)
	{
		//Try
		if (ClearChannelsListBox != null) {
			ClearChannelsListBox();
		}
		object channelFolders = Modules.IrcSettings.ChannelFolders.Get(_Network);
		foreach (void channelFolder_loopVariable in channelFolders) {
			channelFolder = channelFolder_loopVariable;
			if (AddChannelToListBox != null) {
				AddChannelToListBox(channelFolder.Channel);
			}
		}
		//Catch ex As Exception
		//Throw ex 'ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
		//End Try
	}
        public void Form_FormClosed(bool _PopupOnConnect, bool _AutoClose, int _Left, int _Top)
        {
            try
            {
                lSettings.lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect;
                lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cmdClose_Click()
        {
            try
            {
                //lSettings.SaveChannelFolders()
                if (AnimateClose != null)
                {
                    AnimateClose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cmdJoin_Click(string _Channel, bool _AutoClose)
        {
            try
            {
                if (Strings.Len(_Channel) != 0)
                {
                    if (_AutoClose == true)
                        if (FormClosed != null)
                        {
                            FormClosed();
                        }
                    lChannels.Join(lStatusIndex, _Channel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub cmdJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoin.Click")
            }
        }
        public event AnimateCloseEventHandler AnimateClose;
        public delegate void AnimateCloseEventHandler();
        public void lnkJumpToChannelList_LinkClicked()
        {
            try
            {
                lStrings.ProcessReplaceCommand(lStatusIndex, eCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex));
                if (AnimateClose != null)
                {
                    AnimateClose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "lnkJumpToChannelList_LinkClicked")
            }
        }
        public void txtChannel_Enter(Windows.Forms.MouseButtons _MouseButtons, object _Sender)
        {
            try
            {
                if (_MouseButtons == Windows.Forms.MouseButtons.None)
                    lLastFocused = (Control)_Sender;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub txtChannel_Enter(sender As Object, e As System.EventArgs) Handles txtChannel.Enter")
            }
        }
        public void txtChannel_Leave()
        {
            try
            {
                lLastFocused = null;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub txtChannel_Leave(sender As Object, e As System.EventArgs) Handles txtChannel.Leave")
            }
        }
        private void txtChannel_GotFocus(RadTextBox _ChannelTextBox)
        {
            try
            {
                if (ChannelTextBoxSelectAll != null)
                {
                    ChannelTextBoxSelectAll();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub txtChannel_GotFocus(sender As Object, e As System.EventArgs) Handles txtChannel.GotFocus")
            }
        }
        public void txtChannel_MouseUp(object sender)
        {
            try
            {
                var _with1 = (RadTextBox)sender;
                if (!object.ReferenceEquals(lLastFocused, sender) && _with1.SelectionLength == 0)
                    _with1.SelectAll();
                lLastFocused = (Control)sender;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub txtChannel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtChannel.MouseUp")
            }
        }
    }
    public class clsChannelFolder
    {
        public bool lVisible;
        private frmChannelFolder withEventsField_lWindow;
        private frmChannelFolder lWindow
        {
            get { return withEventsField_lWindow; }
            set
            {
                if (withEventsField_lWindow != null)
                {
                    withEventsField_lWindow.FormClosed -= lWindow_FormClosed;
                }
                withEventsField_lWindow = value;
                if (withEventsField_lWindow != null)
                {
                    withEventsField_lWindow.FormClosed += lWindow_FormClosed;
                }
            }
        }
        public void Show(int _StatusIndex)
        {
            try
            {
                ShowWindow();
                SetStatusIndex(_StatusIndex);
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Public Sub Show(_StatusIndex As Integer)")
            }
        }
        private void ShowWindow()
        {
            try
            {
                lWindow = new frmChannelFolder();
                lWindow.Show();
                lVisible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RefreshChannelFolderChannelList()
        {
            try
            {
                if ((lVisible == true))
                {
                    lWindow.Init();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetStatusIndex(int _StatusIndex)
        {
            try
            {
                lWindow.SetStatusIndex(_StatusIndex);
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Public Sub SetStatusIndex(_StatusIndex As Integer)")
            }
        }
        private void lWindow_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                lVisible = false;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Private Sub lWindow_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles lWindow.FormClosed")
            }
        }
        public Form Window()
        {
            try
            {
                return lWindow;
            }
            catch (Exception ex)
            {
                throw ex;
                //ProcessError(ex.Message, "Public Function Window() As Form")
            }
        }
    }
}