using System.Windows.Forms;
using System;
using nexIRC.IRC.Links;
namespace nexIRC.IRC.Structures {
    public class gLinks {
        public TreeNode sTreeNode;
        public bool sTreeNodeVisible;
        public bool sVisible;
        public frmLinks sWindow;
        public gLink[] sLink;
        public int sLinkCount;
    }
    public class gLink {
        public string lServerIP;
        public string lPort;
    }
    public class ServerLinks {
        private int lStatusIndex;
        private int lNetworkIndex;
        public void SetNetworkIndex(int lIndex, ComboBox _ComboBox) {
            try {
                lNetworkIndex = lIndex;
                _ComboBox.Text = lSettings.lNetworks.nNetwork[lIndex].nDescription;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SetStatusIndex(int lIndex) {
            try {
                lStatusIndex = lIndex;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void AddToLinks(string lServerIP, string lPort, ListView _ListView) {
            try {
                ListViewItem lItem = default(ListViewItem);
                lItem = new ListViewItem();
                lItem = _ListView.Items.Add(lServerIP);
                lItem.SubItems.Add(lPort);
                lItem.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void frmServerLinks_FormClosing(ListView _ListView) {
            try {
                int i = 0;
                lStatus.ClearServerLinks(lStatusIndex);
                lStatus.SetLinksWindowsVisible(lStatusIndex, false);
                for (i = 0; i <= _ListView.Items.Count - 1; i++) {
                    var _with1 = _ListView.Items(i);
                    lStatus.SaveServerLink(lStatusIndex, _with1.Text, _with1.SubItems(1).Text);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Form_Load(Form _Form, ComboBox _ComboBox, ListView _ListView) {
            try {
                int i = 0;
                _Form.Icon = mdiMain.Icon;
                for (i = 1; i <= lSettings.lNetworks.nCount; i++) {
                    var _with2 = lSettings.lNetworks.nNetwork(i);
                    if (Strings.Len(lSettings.lNetworks.nNetwork(i).nDescription) != 0) {
                        _ComboBox.Items.Add(_with2.nDescription);
                    }
                }
                var _with3 = _ListView.Columns;
                _with3.Add("Server IP", 160);
                _with3.Add("Port", 140);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdOK_Click(Form _Form, ListView _ListView, ComboBox _ComboBox) {
            try {
                int i = 0;
                ListViewItem lItem = default(ListViewItem);
                //if (lSettings.lIRC.iSettings.sPrompts == true) {
                    //mbox = Interaction.MsgBox("Warning! You are about to add a range of servers to a network group via /LINKS command, are you sure you wish to proceed?", MsgBoxStyle.YesNo | MsgBoxStyle.Question);
                //} else {
                    //mbox = MsgBoxResult.Yes;
                //}
                //if (mbox == MsgBoxResult.Yes) {
                for (i = 0; i <= _ListView.Items.Count - 1; i++) {
                    lItem = _ListView.Items(i);
                    if (Strings.Len(lItem.Text) != 0) {
                        if (lItem.Checked == true) {
                            lSettings.AddServer(_ComboBox.Text + ": " + lItem.Text, lItem.Text, lSettings.FindNetworkIndex(_ComboBox.Text), Convert.ToInt64(Strings.Trim(lItem.SubItems(1).Text)));
                        }
                    }
                }
                //}
                _Form.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void cmdCancel_Click(Form _Form) {
            try {
                _Form.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}