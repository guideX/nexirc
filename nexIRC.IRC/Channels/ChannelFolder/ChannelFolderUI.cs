using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Telerik.WinControls.UI;
namespace nexIRC.IRC.Channels.ChannelFolder {
    public class ChannelFolderUI {
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
        public void SetStatusIndex(int _StatusIndex) {
            try {
                lStatusIndex = _StatusIndex;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void lstChannels_DoubleClick(string _Channel, bool _AutoClose) {
            try {
                lChannels.Join(lStatusIndex, _Channel);
                if (_AutoClose == true)
                    if (FormClosed != null) {
                        FormClosed();
                    }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdAdd_Click(string _Channel, string _Network) {
            try {
                int i = 0;
                if (Strings.Len(_Channel) != 0) {
                    if (AddChannelToListBox != null) {
                        AddChannelToListBox(_Channel);
                    }
                    i = lSettings.FindNetworkIndex(_Network);
                    if (i != 0) {
                        lSettings.AddToChannelFolders(_Channel, i);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Init() {
            try {
                for (var i = 1; i <= lSettings.lNetworks.nCount; i++) {
                    var _with1 = lSettings.lNetworks.nNetwork(i);
                    if (Strings.Len(_with1.nDescription.Trim) != 0)
                        if (AddNetworkComboBoxItem != null) {
                            AddNetworkComboBoxItem(_with1.nDescription);
                        }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Form_Load() {
            int i = 0;
            string msg = null;
            if (ClearNetworkComboBox != null) {
                ClearNetworkComboBox();
            }
            Init();
            msg = lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(lStatus.ActiveIndex())).nDescription;
            if (SetDefaultNetwork != null) {
                SetDefaultNetwork(msg);
            }
            if (SetPopupChannelFoldersCheckBoxValue != null) {
                SetPopupChannelFoldersCheckBoxValue(lSettings.lIRC.iSettings.sPopupChannelFolders);
            }
            if (SetAutoCloseCheckBoxValue != null) {
                SetAutoCloseCheckBoxValue(lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin);
            }
        }
        public void lstChannels_SelectedIndexChanged() {
            try {
                if (SetChannelTextBoxTextToListBoxText != null) {
                    SetChannelTextBoxTextToListBoxText();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdRemove_Click(string _Channel) {
            try {
                if (RemoveChannelListBoxItem != null) {
                    RemoveChannelListBoxItem(_Channel);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private List<string> ReturnListOfChannels(string network) {
            List<string> channels = new List<string>();
            int n = 0;
            string msg = null;
            foreach (Settings.gChannelFolder channelFolder in lSettings.lChannelFolders.cChannelFolder.OrderBy(f => f.cOrder)) {
                n = lSettings.FindNetworkIndex(channelFolder.cNetwork);
                msg = lSettings.lNetworks.nNetwork(n).nDescription;
                if ((!string.IsNullOrEmpty(msg))) {
                    if ((msg.Trim().ToLower() == network.Trim().ToLower())) {
                        if ((channelFolder.cChannel.Trim().Length() != 0)) {
                            channels.Add(channelFolder.cChannel);
                        }
                    }
                }
            }
            channels = channels.OrderBy(c => c).ToList();
            return channels;
        }
        public void cboNetwork_SelectedIndexChanged(string _Network) {
            List<string> channels = default(List<string>);
            if (ClearChannelsListBox != null) {
                ClearChannelsListBox();
            }
            channels = ReturnListOfChannels(_Network);
            foreach (string channel in channels) {
                if (AddChannelToListBox != null) {
                    AddChannelToListBox(channel);
                }
            }
        }
        public void Form_FormClosed(bool _PopupOnConnect, bool _AutoClose, int _Left, int _Top) {
            try {
                lSettings.lIRC.iSettings.sPopupChannelFolders = _PopupOnConnect;
                lSettings.lIRC.iSettings.sChannelFolderCloseOnJoin = _AutoClose;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdClose_Click() {
            try {
                lSettings.SaveChannelFolders();
                if (AnimateClose != null) {
                    AnimateClose();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdJoin_Click(string _Channel, bool _AutoClose) {
            try {
                if (Strings.Len(_Channel) != 0) {
                    if (_AutoClose == true)
                        if (FormClosed != null) {
                            FormClosed();
                        }
                    lChannels.Join(lStatusIndex, _Channel);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public event AnimateCloseEventHandler AnimateClose;
        public delegate void AnimateCloseEventHandler();
        public void lnkJumpToChannelList_LinkClicked() {
            try {
                lStrings.ProcessReplaceCommand(lStatusIndex, eCommandTypes.cLIST, lStatus.Description(lStatus.ActiveIndex));
                if (AnimateClose != null) {
                    AnimateClose();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void txtChannel_Enter(MouseButtons _MouseButtons, object _Sender) {
            try {
                if (_MouseButtons == System.Windows.Forms.MouseButtons.None)
                    lLastFocused = (Control)_Sender;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void txtChannel_Leave() {
            try {
                lLastFocused = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void txtChannel_GotFocus(RadTextBox _ChannelTextBox) {
            try {
                if (ChannelTextBoxSelectAll != null) {
                    ChannelTextBoxSelectAll();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void txtChannel_MouseUp(object sender) {
            try {
                var _with2 = (TextBox)sender;
                if (!object.ReferenceEquals(lLastFocused, sender) && _with2.SelectionLength == 0)
                    _with2.SelectAll();
                lLastFocused = (Control)sender;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}