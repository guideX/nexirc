using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace nexIRC.IRC.Channels.ChannelList {
    public class ChannelListUI {
        public event SaveColumnWidthsEventHandler SaveColumnWidths;
        public delegate void SaveColumnWidthsEventHandler();
        public SortOrder lSortOrder;
        private string lCurrentChannel;
        private int lMeIndex;
        public void cmdAddToChannelFolder_Click(string channel) {
            try {
                lSettings.AddToChannelFolders(channel, lSettings.lNetworks.nIndex);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdRefresh_Click(Form form) {
            try {
                int n = lStatus.ActiveIndex;
                lStrings.ProcessReplaceCommand(n, eCommandTypes.cLIST, lStatus.ServerDescription(n));
                form.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int MeIndex {
            set {
                try {
                    lMeIndex = value;
                    lChannelLists.SetOpen(lMeIndex);
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        public void FormClosed(ListView _ChannelsListView, int _FormLeft, int _FormTop, int _FormWidth, int _FormHeight) {
            try {
                Files.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Left", _FormLeft.ToString);
                Files.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Top", _FormTop.ToString);
                Files.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Width", _FormWidth.ToString);
                Files.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Height", _FormHeight.ToString);
                lChannelLists.SetClosed(lMeIndex);
                if (SaveColumnWidths != null) {
                    SaveColumnWidths();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void ResetList(ListView _ListView) {
            try {
                _ListView.Items.Clear();
                _ListView.View = View.Details;
                _ListView.HeaderStyle = ColumnHeaderStyle.Clickable;
                _ListView.Columns.Add("Channel", Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "1", "150"))), HorizontalAlignment.Left);
                _ListView.Columns.Add("Topic", Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "2", "350"))), HorizontalAlignment.Left);
                _ListView.Columns.Add("Users", Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "3", "100"))), HorizontalAlignment.Left);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Load(Form _Form, ListView _ListView) {
            try {
                _Form.Left = Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Left", "300")));
                _Form.Top = Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Top", "300")));
                _Form.Width = Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Width", "300")));
                _Form.Height = Convert.ToInt32(Strings.Trim(Files.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Height", "300")));
                _Form.MdiParent() = mdiMain;
                _Form.Icon = mdiMain.Icon;
                ResetList(_ListView);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Resize(ListView _ListView, Form _Form, int _ToolStripHeight) {
            try {
                _ListView.Width = _Form.ClientSize.Width;
                _ListView.Height = _Form.ClientSize.Height - _ToolStripHeight;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void DoubleClick(ListView _ListView) {
            try {
                int i = 0;
                for (i = 0; i <= _ListView.SelectedItems.Count; i++) {
                    lChannels.Join(lChannelLists.ReturnStatusIndex(lMeIndex), lCurrentChannel);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void ItemSelectionChanged(ListView _ListView, int _ItemIndex) {
            try {
                lCurrentChannel = _ListView.Items(_ItemIndex).Text;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}