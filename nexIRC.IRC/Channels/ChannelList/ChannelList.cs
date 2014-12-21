using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace nexIRC.IRC.Channels.ChannelList {
    public class clsChannelList {
        public struct gChannelListItem {
            public string cChannel;
            public string cTopic;
            public int cUserCount;
        }
        public struct gChannelListItems {
            public int cCount;
            public gChannelListItem[] cChannelListItem;
        }
        public struct gChannelList {
            public frmChannelList cWindow;
            public bool cVisible;
            public TreeNode cTreeNode;
            public bool cTreeNodeVisible;
            public gChannelListItems cItem;
            public int cStatusIndex;
            public string cStatusDescription;
        }
        public struct gChannelLists {
            public gChannelList[] cChannelList;
            public int cCount;
        }
        private gChannelLists lChannelLists;
        public int ReturnChannelListIndex(int _StatusIndex) {
            try {
                int n = 0;
                for (int i = 1; i <= lChannelLists.cCount; i++) {
                    if (lChannelLists.cChannelList(i).cStatusIndex == _StatusIndex) {
                        n = i;
                    }
                }
                return n;
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public int ReturnStatusIndex(int _ChannelListIndex) {
            try {
                if ((lChannelLists.cChannelList != null)) {
                    return lChannelLists.cChannelList(_ChannelListIndex).cStatusIndex;
                } else {
                    return 0;
                }
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public void NewChannelList(int _StatusIndex) {
            try {
                bool b = false;
                int _ChannelListIndex = 0;
                for (int i = 1; i <= lChannelLists.cCount; i++) {
                    if (_StatusIndex == lChannelLists.cChannelList(i).cStatusIndex) {
                        _ChannelListIndex = i;
                        b = true;
                    }
                }
                if (b == false) {
                    lChannelLists.cCount = lChannelLists.cCount + 1;
                    lChannelLists.cChannelList = new gChannelList[lChannelLists.cCount + 1];
                    var _with1 = lChannelLists.cChannelList(lChannelLists.cCount);
                    _with1.cStatusIndex = _StatusIndex;
                    _with1.cTreeNodeVisible = true;
                    _with1.cTreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add("Channel List", "Channel List", 1);
                    _with1.cWindow = new frmChannelList();
                } else {
                    var _with2 = lChannelLists.cChannelList(_ChannelListIndex);
                    _with2.cStatusIndex = _StatusIndex;
                    _with2.cWindow = new frmChannelList();
                    _with2.cItem = new gChannelListItems();
                    _with2.cWindow.MeIndex = _ChannelListIndex;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Clear(int _ChannelListIndex) {
            try {
                var _with3 = lChannelLists.cChannelList(_ChannelListIndex);
                _with3.cWindow.lvwChannels.Clear();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Unload(int _ChannelListIndex) {
            try {
                if (lChannelLists.cCount != 0) {
                    var _with4 = lChannelLists.cChannelList(_ChannelListIndex);
                    if (_with4.cVisible == true)
                        _with4.cWindow.Close();
                    if (_with4.cTreeNodeVisible == true)
                        _with4.cTreeNode = null;
                    _with4.cTreeNodeVisible = false;
                    _with4.cVisible = false;
                    _with4.cWindow = null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public string StatusDescription {
            set {
                try {
                    lChannelLists.cChannelList(_ChannelListIndex).cStatusDescription = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        public void Display(int _ChannelListIndex) {
            try {
                var _with5 = lChannelLists.cChannelList(_ChannelListIndex);
                //.cWindow.Text = "Channel List [" & lStatusObjects.sStatusObject(lStatusIndex).sDescription & "]"
                _with5.cWindow = new frmChannelList();
                _with5.cWindow.Text = "Channel List [" + lStatus.Window(_with5.cStatusIndex).Text + "]";
                _with5.cWindow.lvwChannels.Items.Clear();
                _with5.cWindow.Show();
                SetItems(_ChannelListIndex);
                _with5.cWindow.MeIndex = _ChannelListIndex;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void SetItems(int _ChannelListIndex) {
            try {
                ListViewItem _Item = default(ListViewItem);
                var _with6 = lChannelLists.cChannelList(_ChannelListIndex);
                for (int i = 1; i <= _with6.cItem.cCount; i++) {
                    _Item = _with6.cWindow.lvwChannels.Items.Add(_with6.cItem.cChannelListItem(i).cChannel);
                    _Item.SubItems.Add(_with6.cItem.cChannelListItem(i).cTopic);
                    _Item.SubItems.Add(_with6.cItem.cChannelListItem(i).cUserCount.ToString);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Close(int _ChannelListIndex) {
            try {
                var _with7 = lChannelLists.cChannelList(_ChannelListIndex);
                if (_with7.cVisible == true)
                    _with7.cWindow.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void HideTreeNode(int _ChannelListIndex) {
            try {
                var _with8 = lChannelLists.cChannelList(_ChannelListIndex);
                if (_with8.cTreeNodeVisible == true) {
                    _with8.cTreeNodeVisible = false;
                    _with8.cTreeNode.Remove();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void DoubleClick(int _ChannelListIndex) {
            try {
                var _with9 = lChannelLists.cChannelList(_ChannelListIndex);
                if (_with9.cVisible == false) {
                    Display(_ChannelListIndex);
                } else {
                    _with9.cWindow.Focus();
                    return;
                }
                var _with10 = lChannelLists.cChannelList(_ChannelListIndex);
                //With lStatusObjects.sStatusObject(n)
                if (_with10.cVisible == false) {
                    //Display(_ChannelListIndex)
                    SetItems(_ChannelListIndex);
                    //.cWindow = New frmChannelList
                    //.cWindow.Show()
                    //.cVisible = True
                    //.cWindow.SetStatusIndex(n)
                    //SetChannelListItems(n, .sChannelList.cWindow.lvwChannels)
                } else {
                    //mdiMain.SetWindowFocus(.sChannelList.cWindow)
                    mdiMain.SetWindowFocus(_with10.cWindow);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public bool DoesChannelExist(int _ChannelListIndex, string _Channel) {
            try {
                bool _Result = false;
                var _with11 = lChannelLists.cChannelList(_ChannelListIndex);
                for (int i = 1; i <= _with11.cItem.cCount; i++) {
                    if (_with11.cItem.cChannelListItem(i).cChannel.ToLower() == _Channel.ToLower() == true) {
                        _Result = true;
                    }
                }
                return _Result;
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public void Add(int _ChannelListIndex, string _Data) {
            try {
                string[] splt = null;
                string[] splt2 = null;
                int i = 0;
                string msg = null;
                if (Strings.Left(_Data, 1) != ":")
                    _Data = ":" + _Data;
                if (Strings.Len(_Data) != 0) {
                    _Data = Strings.Trim(_Data);
                    splt = Strings.Split(_Data, ":");
                    splt2 = Strings.Split(splt(1), " ");
                    i = Strings.Len(splt2(0)) + Strings.Len(splt2(1)) + Strings.Len(splt2(2)) + Strings.Len(splt2(3)) + Strings.Len(splt2(4)) + 7;
                    msg = Strings.Right(_Data, Strings.Len(_Data) - i);
                    msg = TextManipulation.Text.StripColorCodes(msg);
                    if (msg == null)
                        msg = "";
                    if (DoesChannelExist(_ChannelListIndex, splt2(3)) == false) {
                        var _with12 = lChannelLists.cChannelList(_ChannelListIndex);
                        _with12.cItem.cCount = _with12.cItem.cCount + 1;
                        Array.Resize(ref _with12.cItem.cChannelListItem, _with12.cItem.cCount + 1);
                        var _with13 = _with12.cItem.cChannelListItem(_with12.cItem.cCount);
                        _with13.cChannel = splt2(3);
                        _with13.cTopic = msg;
                        if (Information.IsNumeric(splt2(4)) == true) {
                            _with13.cUserCount = Convert.ToInt32(splt2(4).Trim);
                        }
                        if (_with12.cTreeNodeVisible == false) {
                            _with12.cTreeNodeVisible = true;
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SetOpen(int _ChannelListIndex) {
            try {
                var _with14 = lChannelLists.cChannelList(_ChannelListIndex);
                _with14.cVisible = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SetClosed(int _ChannelListIndex) {
            try {
                var _with15 = lChannelLists.cChannelList(_ChannelListIndex);
                _with15.cVisible = false;
                _with15.cWindow = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}