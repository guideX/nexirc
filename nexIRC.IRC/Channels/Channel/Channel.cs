//nexIRC 3.0.31
//Sunday, Oct 4th, 2014 - guideX
//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Windows.Forms;
namespace IRC.Channels {
    public class Channel {
        public int nCount;
        public struct gChannel {
            public string cName;
            public string cURL;
            public frmChannel cWindow;
            public bool cVisible;
            public TreeNode cTreeNode;
            public bool cTreeNodeVisible;
            public string cIncomingText;
            public int cStatusIndex;
            public ToolStripItem cWindowBarItem;
            public bool cWindowBarItemVisible;
            public List<string> cNamesToAdd;
        }
        public struct gChannels {
            public int cCount;
            public int cIndex;
            public gChannel[] cChannel;
        }
        public struct gChannelCollection {
            public int[] cChannel;
            public int cCount;
        }
        private gChannels lChannels;
        public void Focus(int channelIndex) {
            try {
                var _with1 = lChannels.cChannel(channelIndex);
                _with1.cWindow.Focus();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void EnableDelayNamesTimer(int channelIndex) {
            try {
                lChannels.cChannel(channelIndex).cWindow.tmrAddNameDelay.Enabled = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void AddToNickListQue(int channelIndex, string nickName) {
            try {
                lChannels.cChannel(channelIndex).cWindow.MdiChildWindow.NicklistQue.Add(nickName);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void AddToNickList(int _ChannelIndex, string _NickName) {
            ListViewDataItem listViewDataItem = default(ListViewDataItem);
            bool b = false;
            try {
                var _with2 = lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList;
                listViewDataItem = new ListViewDataItem();
                listViewDataItem.Text = _NickName;
                if (Strings.InStr(listViewDataItem.Text, "@") != 0) {
                    listViewDataItem.ForeColor = Color.Red;
                } else if (Strings.InStr(listViewDataItem.Text, "+") != 0) {
                    listViewDataItem.ForeColor = Color.DarkGreen;
                } else {
                    listViewDataItem.ForeColor = Color.White;
                }
                _NickName = _NickName.Replace("@", "");
                _NickName = _NickName.Replace("+", "");
                foreach (ListViewDataItem msg in _with2.Items) {
                    if (msg.Text.Replace("@", "").Replace("+", "") == _NickName) {
                        b = true;
                    }
                }
                if ((!b)) {
                    _with2.Items.Add(listViewDataItem);
                }
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub AddToChannelNickList(ByVal lIndex As Integer, ByVal lNickName As String)")
            }
        }
        public void Minimize(int _ChannelIndex) {
            try {
                var _with3 = lChannels.cChannel(_ChannelIndex);
                _with3.cWindow.WindowState = FormWindowState.Minimized;
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub HideChannelWindow(ByVal lIndex As Integer)")
            }
        }
        public void PrivMsg(int _ChannelIndex, string _Data) {
            try {
                var _with4 = lChannels.cChannel(_ChannelIndex);
                DoChannelColor(_ChannelIndex, _Data);
                if (_with4.cVisible == false) {
                    if (_with4.cTreeNode.ImageIndex != 9)
                        _with4.cTreeNode.ImageIndex = 9;
                    if (_with4.cTreeNode.SelectedImageIndex != 9)
                        _with4.cTreeNode.SelectedImageIndex = 9;
                    if (_with4.cWindowBarItem.ImageIndex != 9)
                        _with4.cWindowBarItem.ImageIndex = 9;
                    //If .cWindowBarItem.SelectedImageIndex <> 9 Then .cWindowBarItem.SelectedImageIndex = 9
                }
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub DoChannelPrivMsg(ByVal lChannelIndex As Integer, ByVal lData As String)")
            }
        }
        public void DoChannelColor(int _ChannelIndex, string _Data) {
            try {
                if ((_ChannelIndex != 0)) {
                    var _with5 = lChannels.cChannel(_ChannelIndex);
                    lStrings.Print(_Data, _with5.cWindow.txtIncoming);
                }
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub DoChannelColor(ByVal lStatusIndex As Integer, ByVal lChannelName As String, ByVal lData As String)")
            }
        }
        public void Window_Closing(Form form, int meIndex, System.Windows.Forms.FormClosingEventArgs eventArgs) {
            try {
                var _with6 = lChannels.cChannel(meIndex);
                lSettings.lIRC.iSettings.sWindowSizes.iChannel.wWidth = _with6.cWindow.Width;
                lSettings.lIRC.iSettings.sWindowSizes.iChannel.wHeight = _with6.cWindow.Height;
                lSettings.SaveWindowSizes();
                if (lStatus.Closing() == false) {
                    SetChannelVisible(meIndex, false);
                }
                form.Visible = false;
                eventArgs.Cancel = true;
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub Window_Closing(_ChannelIndex As Integer)")
            }
        }
        public void Form_Load(int _ChannelIndex) {
            try {
                var _with7 = lChannels.cChannel(_ChannelIndex);
                _with7.cWindow = new frmChannel();
                _with7.cWindow.Show();
                _with7.cWindow.MdiChildWindow.FormType = MdiChildWindow.FormTypes.Channel;
                _with7.cWindow.MdiChildWindow.MeIndex = _ChannelIndex;
                _with7.cWindow.MdiChildWindow.Form_Load(MdiChildWindow.FormTypes.Channel);
                lStrings.Print(_with7.cIncomingText, _with7.cWindow.txtIncoming);
                _with7.cWindow.Text = _with7.cName;
                _with7.cWindow.Icon = mdiMain.Icon;
                _with7.cWindow.MdiParent = mdiMain;
                _with7.cWindow.lvwNickList.Columns.Add("Nickname");
                _with7.cWindow.txtOutgoing.Focus();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Window_Resize(int _ChannelIndex) {
            try {
                int m = 0;
                var _with8 = lChannels.cChannel(_ChannelIndex).cWindow;
                if ((_with8.ClientSize.Width != 0)) {
                    _with8.txtIncoming.Width = _with8.ClientSize.Width - _with8.lvwNickList.Width;
                    m = _with8.ClientSize.Height - (_with8.txtOutgoing.Height + _with8.tspChannel.ClientSize.Height);
                    if ((_with8.ClientSize.Height != 0)) {
                        if (((m <= _with8.txtIncoming.MinimumSize.Height) | m >= _with8.txtIncoming.MaximumSize.Height)) {
                            _with8.txtIncoming.Height = _with8.ClientSize.Height - (_with8.txtOutgoing.Height + _with8.tspChannel.ClientSize.Height);
                        }
                    }
                    _with8.txtOutgoing.Width = _with8.ClientSize.Width;
                    _with8.txtOutgoing.Top = _with8.txtIncoming.Height + _with8.tspChannel.ClientSize.Height;
                    _with8.lvwNickList.Left = _with8.txtIncoming.Width;
                    _with8.lvwNickList.Height = _with8.txtIncoming.Height;
                    _with8.lvwNickList.Top = _with8.txtIncoming.Top;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Outgoing_GotFocus(int _ChannelIndex) {
            try {
                var _with9 = lChannels.cChannel(_ChannelIndex);
                if (lSettings.lIRC.iSettings.sAutoMaximize == true)
                    _with9.cWindow.WindowState = FormWindowState.Maximized;
                lChannels.cIndex = _ChannelIndex;
                lStatus.ActiveIndex = _with9.cStatusIndex;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Outgoing_KeyDown(int _ChannelIndex, int _KeyCode) {
            try {
                string msg = null;
                string msg2 = null;
                if ((_ChannelIndex != 0)) {
                    var _with10 = lChannels.cChannel(_ChannelIndex);
                    if (_KeyCode == 13) {
                        msg = _with10.cWindow.txtOutgoing.Text;
                        _with10.cWindow.txtOutgoing.Text = "";
                        if (TextManipulation.Text.LeftRight(msg, 0, 1) == "/") {
                            lStatus.ProcessUserInput(lChannels.cChannel(_ChannelIndex).cStatusIndex, msg);
                        } else {
                            lStatus.DoStatusSocket(lChannels.cChannel(_ChannelIndex).cStatusIndex, "PRIVMSG " + lChannels.cChannel(_ChannelIndex).cName + " :" + msg);
                            msg2 = lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, lStatus.NickName(lChannels.cChannel(_ChannelIndex).cStatusIndex), msg);
                            DoChannelColor(_ChannelIndex, msg2);
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int StatusIndex(int channelIndex) {
            try {
                return lChannels.cChannel(channelIndex).cStatusIndex;
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public void SetChannelVisible(int _ChannelIndex, bool _Visible) {
            try {
                var _with11 = lChannels.cChannel(_ChannelIndex);
                _with11.cVisible = _Visible;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void NickList_DoubleClick(int _ChannelIndex) {
            try {
                string msg = null;
                var _with12 = lChannels.cChannel(_ChannelIndex);
                msg = Strings.Replace(_with12.cWindow.lvwNickList.SelectedItems(0).Text, "+", "");
                msg = Strings.Replace(msg, "@", "");
                //lStatus.PrivateMessage_Initialize(.cStatusIndex, msg)
                lStatus.PrivateMessage_Add(StatusIndex(_ChannelIndex), msg, "", "", true);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Users_DoubleClick(int _ChannelIndex) {
            try {
                var _with13 = lChannels.cChannel(_ChannelIndex);
                string msg = null;
                msg = Strings.Replace(_with13.cWindow.lvwNickList.Text, "+", "");
                msg = Strings.Replace(_with13.cWindow.lvwNickList.Text, "@", "");
                lStatus.PrivateMessage_Initialize(_with13.cStatusIndex, msg);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void ResetForeMostWindows() {
            try {
                for (int i = 1; i <= lChannels.cCount; i++) {
                    lChannels.cChannel(i).cWindow.MdiChildWindow.lForeMost = false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void ToggleChannelWindowState(int _ChannelIndex, bool _ForeMost) {
            try {
                var _with14 = lChannels.cChannel(_ChannelIndex).cWindow;
                if (_with14.WindowState == FormWindowState.Normal == true) {
                    if (_ForeMost == true) {
                        _with14.WindowState = FormWindowState.Minimized;
                    } else {
                        _with14.Focus();
                    }
                } else if (_with14.WindowState == FormWindowState.Maximized) {
                    if (_ForeMost == true) {
                        _with14.WindowState = FormWindowState.Minimized;
                    } else {
                        _with14.Focus();
                    }
                } else if (_with14.WindowState == FormWindowState.Minimized) {
                    _with14.WindowState = FormWindowState.Normal;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void AddText_WhereUserExists(int _StatusIndex, string _NickName, string _Text) {
            try {
                if ((_StatusIndex != 0 | _NickName.Trim().Length() == 0)) {
                    for (int _ChannelIndex = 1; _ChannelIndex <= lChannels.cCount; _ChannelIndex++) {
                        for (int n = 0; n <= lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList.Items.Count - 1; n++) {
                            if ((lChannels.cChannel(_ChannelIndex).cWindow.lvwNickList.Items(n).Text.Trim().ToLower.Replace("@", "").Replace("+", "") == _NickName.Trim().ToLower.Replace("@", "").Replace("+", ""))) {
                                DoChannelColor(_ChannelIndex, _Text);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public bool HaveChannels(int _StatusIndex) {
            try {
                bool _Result = false;
                for (int i = 1; i <= lChannels.cCount; i++) {
                    if (lChannels.cChannel(i).cStatusIndex == _StatusIndex)
                        _Result = true;
                }
                return _Result;
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public void RemoveTree(int _ChannelIndex) {
            try {
                var _with15 = lChannels.cChannel(_ChannelIndex);
                _with15.cTreeNode.Remove();
                _with15.cTreeNodeVisible = false;
                mdiMain.tspWindows.Items.Remove(_with15.cWindowBarItem);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Redirect(int _StatusIndex, string _Data) {
            try {
                string _ChannelA = null;
                string _ChannelB = null;
                string[] splt = null;
                string _NickName = null;
                splt = _Data.Split(Convert.ToChar(" "));
                _NickName = splt[2];
                _ChannelA = splt[3];
                _ChannelB = splt[4];
                if ((_NickName.ToLower == lStatus.NickName(_StatusIndex).ToLower())) {
                    if ((lSettings.lIRC.iSettings.sPrompts == true)) {
                        mdiMain.lblRedirectMessage.Text = "Notice: You have been redirected from '" + _ChannelA + "' to '" + _ChannelB + "'.";
                        mdiMain.lblRedirectMessage.Tag = _StatusIndex.ToString();
                        mdiMain.tmrHideRedirect.Enabled = true;
                        mdiMain.tspRedirect.Visible = true;
                    } else {
                        Strings.Join(_StatusIndex, _ChannelB);
                    }
                    if (lSettings.lIRC.iSettings.sNoIRCMessages == false)
                        lStrings.ProcessReplaceString(_StatusIndex, eStringTypes.sERR_LINKCHANNEL, _ChannelA, _ChannelB);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SomeoneChangedNickName(string _OldNickName, string _HostName, string _NickName, int _StatusIndex) {
            try {
                foreach (gChannel lChannel in lChannels.cChannel) {
                    if ((lChannel.cStatusIndex == _StatusIndex)) {
                        foreach (ListViewDataItem lListViewItem in lChannel.cWindow.lvwNickList.Items) {
                            if ((lListViewItem.Text == _OldNickName)) {
                                lListViewItem.Text = _NickName;
                                lStrings.Print(lStrings.ReturnReplacedString(eStringTypes.sNICK_CHANGE, _OldNickName, _HostName, _NickName), lChannel.cWindow.txtIncoming);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SomeoneJoined(int _StatusIndex, string _Data) {
            //:guide_X!~guide_X@pool-108-13-216-135.lsanca.fios.verizon.net JOIN #testerama
            try {
                string _NickName = null;
                string _IpAddress = null;
                string _Channel = null;
                string _TextToDisplay = null;
                int _ChannelIndex = 0;
                _NickName = TextManipulation.Text.ParseData(_Data, ":", "!");
                _IpAddress = TextManipulation.Text.ParseData(_Data, "~", " JOIN ");
                if (Strings.InStr(Strings.UCase(_Data), " JOIN :#") != 0) {
                    _Channel = Strings.Right(_Data, Strings.Len(_Data) - (Strings.InStr(Strings.Right(_Data, Strings.Len(_Data) - 1), ":", CompareMethod.Text) + 1));
                } else if (Strings.InStr(Strings.UCase(_Data), " JOIN #") != 0) {
                    _Channel = Strings.Right(_Data, Strings.Len(_Data) - (Strings.InStr(Strings.Right(_Data, Strings.Len(_Data) - 1), " JOIN ", CompareMethod.Text) + 1));
                    if (Strings.InStr(_Channel, "JOIN") != 0)
                        _Channel = Strings.Replace(_Channel, "JOIN", "");
                    _Channel = Strings.Trim(_Channel);
                } else {
                    return;
                }
                if (Strings.LCase(Strings.Trim(_NickName)) == Strings.LCase(Strings.Trim(lStatus.NickName(_StatusIndex)))) {
                    _ChannelIndex = Add(_Channel, _StatusIndex);
                    Form_Load(_ChannelIndex);
                    DoChannelColor(_ChannelIndex, lStrings.ReturnReplacedString(eStringTypes.sYOUJOIN, _Channel));
                    lSettings.AddToChannelFolders(_Channel, lStatus.NetworkIndex(_StatusIndex));
                    lChannelFolder.RefreshChannelFolderChannelList();
                } else {
                    if (lSettings.lIRC.iSettings.sShowUserAddresses == true) {
                        _TextToDisplay = lStrings.ReturnReplacedString(eStringTypes.sUSER_JOINED, _NickName + " (" + _IpAddress + ")", _Channel);
                    } else {
                        _TextToDisplay = lStrings.ReturnReplacedString(eStringTypes.sUSER_JOINED, _NickName, _Channel);
                    }
                    _ChannelIndex = Find(_StatusIndex, _Channel);
                    var _with16 = lChannels.cChannel(_ChannelIndex);
                    DoChannelColor(_ChannelIndex, _TextToDisplay);
                    AddToNickList(_ChannelIndex, _NickName);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void RemoveFromNickList(int _ChannelIndex, string _NickName) {
            try {
                int i = 0;
                string _NickListText = null;
                if (Strings.Len(_NickName) != 0) {
                    var _with17 = lChannels.cChannel(_ChannelIndex);
                    for (i = 0; i <= _with17.cWindow.lvwNickList.Items.Count - 1; i++) {
                        _NickListText = _with17.cWindow.lvwNickList.Items(i).Text;
                        if (Strings.LCase(Strings.Trim(_NickListText)) == Strings.LCase(Strings.Trim(_NickName)) | Strings.LCase(Strings.Trim(_NickListText)) == Strings.LCase(Strings.Trim("@" + _NickName)) | Strings.LCase(Strings.Trim(_NickListText)) == Strings.LCase(Strings.Trim("+" + _NickName))) {
                            _with17.cWindow.lvwNickList.Items.RemoveAt(i);
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SomeoneQuit(int _StatusIndex, string _Data) {
            List<int> nickListIds = default(List<int>);
            string nickName = null;
            string hostName = null;
            string quitMessage = null;
            string lastNickName = null;
            try {
                lastNickName = "";
                nickListIds = new List<int>();
                if ((_Data.Contains(":") & _Data.Contains("!"))) {
                    nickName = TextManipulation.Text.ParseData(_Data, ":", "!");
                    if ((_Data.Contains(" QUIT :"))) {
                        hostName = TextManipulation.Text.ParseData(_Data, ":" + nickName + "!", " QUIT :").Replace(nickName + "!", "");
                        quitMessage = _Data.Replace(":" + nickName + "!" + hostName + " QUIT :", "");
                        List<ListViewDataItem> nickListItems = default(List<ListViewDataItem>);
                        for (i = 1; i <= lChannels.cCount; i++) {
                            nickListItems = lChannels.cChannel(i).cWindow.lvwNickList.Items.Where(nickListItem => nickListItem.Text == nickName | nickListItem.Text == "@" + nickName | nickListItem.Text == "+" + nickName).ToList();
                            nickListItems = nickListItems.Distinct.ToList();
                            nickListItems.ForEach(m => {
                                if ((lastNickName != nickName)) {
                                    lastNickName = nickName;
                                    lChannels.cChannel(i).cWindow.lvwNickList.Items.Remove(m);
                                    DoChannelColor(i, lStrings.ReturnReplacedString(eStringTypes.sUSER_QUIT, nickName, hostName, quitMessage));
                                }
                                return true;
                            });
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SomeoneParted(int _StatusIndex, string _Data) {
            try {
                string[] splt = null;
                string[] splt2 = null;
                string[] splt3 = null;
                string _NickName = null;
                string _ChannelName = null;
                string _HostName = null;
                int _ChannelIndex = 0;
                string _TextToDisplay = null;
                _NickName = "";
                _ChannelName = "";
                _HostName = "";
                splt = _Data.Split(Convert.ToChar(" "));
                if ((Information.UBound(splt)) == 2) {
                    _ChannelName = splt(2);
                    splt2 = splt(0).Split(Convert.ToChar("@"));
                    if (Information.UBound(splt2) == 1) {
                        _NickName = splt2(0);
                        _NickName = TextManipulation.Text.ParseData(_NickName, ":", "!");
                        //_HostName = Split(splt2(0), "~")(1) & "@" & splt2(1)
                        splt3 = Strings.Split(splt2(0), "~");
                        if ((Information.UBound(splt3) > 0)) {
                            _HostName = splt3(1) + "@" + splt2(1);
                        } else {
                            _HostName = splt3(0);
                        }
                    }
                }
                _ChannelIndex = Find(_StatusIndex, _ChannelName);
                if (_NickName.Trim() == lStatus.NickName(_StatusIndex).Trim()) {
                    var _with18 = lChannels.cChannel(_ChannelIndex);
                    _with18.cIncomingText = "";
                    _with18.cName = "";
                    _with18.cStatusIndex = 0;
                    if (_with18.cVisible == true)
                        _with18.cWindow.Close();
                    _with18.cTreeNode.Remove();
                    _with18.cTreeNode = null;
                    _with18.cTreeNodeVisible = false;
                    _with18.cWindowBarItem = null;
                    _with18.cWindowBarItemVisible = false;
                } else {
                    RemoveFromNickList(Find(_StatusIndex, _ChannelName), _NickName);
                    if (lSettings.lIRC.iSettings.sShowUserAddresses == true) {
                        _TextToDisplay = lStrings.ReturnReplacedString(eStringTypes.sUSER_PARTED, _NickName + " (" + _HostName + ")", _ChannelName);
                    } else {
                        _TextToDisplay = lStrings.ReturnReplacedString(eStringTypes.sUSER_PARTED, _NickName, _ChannelName);
                    }
                    DoChannelColor(Find(_StatusIndex, _ChannelName), _TextToDisplay);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int Find(int _StatusIndex, string _ChannelName) {
            try {
                int i = 0;
                int _Result = 0;
                if (Strings.Len(_ChannelName) != 0) {
                    for (i = 1; i <= lChannels.cCount; i++) {
                        var _with19 = lChannels.cChannel(i);
                        if (Strings.Trim(Strings.LCase(_ChannelName)) == Strings.Trim(Strings.LCase(_with19.cName)) & _StatusIndex == _with19.cStatusIndex) {
                            _Result = i;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                return _Result;
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Shared Function Find(ByVal lStatusIndex As Integer, ByVal lChannelName As String) As Integer")
                return null;
            }
        }
        public void Delete(int _ChannelIndex) {
            try {
                var _with20 = lChannels.cChannel(_ChannelIndex);
                _with20.cName = "";
                if (_with20.cTreeNodeVisible == true)
                    _with20.cTreeNode.Remove();
                _with20.cTreeNode = null;
                _with20.cTreeNodeVisible = false;
                _with20.cWindow = null;
                _with20.cVisible = false;
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub KillChannel(ByVal lIndex As Integer)")
            }
        }

        public void Join(int lStatusIndex, string lChannelName) {
            try {
                if (lStatusIndex != 0 & Strings.Len(lChannelName) != 0)
                    lStatus.SendSocket(lStatusIndex, "JOIN " + lChannelName);
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub JoinChannel(ByVal lStatusIndex As Integer, ByVal lChannelName As String)")
            }
        }
        public void ClearAll(int _StatusIndex) {
            try {
                for (int _ChannelIndex = 1; _ChannelIndex <= lChannels.cCount; _ChannelIndex++) {
                    var _with21 = lChannels.cChannel(_ChannelIndex);
                    if (_with21.cStatusIndex == _StatusIndex) {
                        if (_with21.cVisible == true)
                            _with21.cWindow.Close();
                        _with21.cTreeNodeVisible = false;
                        _with21.cTreeNode = null;
                        _with21.cName = "";
                        //ReDim .cNickList.nItem(lArraySizes.aNickList)
                        //.cNickList.nCount = 0
                        _with21.cVisible = false;
                        _with21.cWindow = null;
                        _with21.cStatusIndex = 0;
                    }
                }
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub ClearAllChannels(_StatusIndex As Integer)")
            }
        }
        public void Topic(int _StatusIndex, string _Data) {
            try {
                string[] splt = Strings.Split(_Data.Trim(), ":");
                string[] splt2 = null;
                string _Message = null;
                string _Channel = null;
                int _ChannelIndex = 0;
                splt2 = Strings.Split(splt(1), " ");
                _Channel = splt2(3);
                _Message = Strings.Right(_Data, Strings.Len(_Data) - splt(1).Length() - 2);
                _ChannelIndex = Find(_StatusIndex, _Channel);
                var _with22 = lChannels.cChannel(_ChannelIndex);
                lStrings.Print(lStrings.ReturnReplacedString(eStringTypes.sRPL_TOPIC, _Channel, _Message), _with22.cWindow.txtIncoming);
                _with22.cWindow.Text = _Channel + ": " + TextManipulation.Text.StripColorCodes(_Message);
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Sub ChannelTopicMessage(_StatusIndex As Integer, _Data As String)")
            }
        }
        private int Add(string _Name, int _StatusIndex) {
            try {
                lChannels.cCount = lChannels.cCount + 1;
                Array.Resize(ref lChannels.cChannel, lChannels.cCount + 1);
                var _with23 = lChannels.cChannel(lChannels.cCount);
                _with23.cName = _Name;
                _with23.cStatusIndex = _StatusIndex;
                _with23.cTreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add(_Name, _Name, 1, 1);
                _with23.cTreeNodeVisible = true;
                _with23.cWindowBarItem = mdiMain.AddWindowBar(_with23.cName, gWindowBarImageTypes.wChannel);
                _with23.cWindowBarItem.Tag = Strings.Trim(_with23.cStatusIndex.ToString);
                _with23.cWindowBarItemVisible = true;
                return lChannels.cCount;
            } catch (Exception ex) {
                throw ex;
                return null;
            }
        }
        public int CurrentIndex {
            get {
                try {
                    return lChannels.cIndex;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property CurrentIndex(ByVal lIndex As Integer) As Integer")
                    return null;
                }
            }
            set {
                try {
                    lChannels.cIndex = value;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property CurrentIndex(ByVal lIndex As Integer) As Integer")
                }
            }
        }
        public frmChannel Window(int _ChannelIndex) {
            try {
                return lChannels.cChannel(_ChannelIndex).cWindow;
            } catch (Exception ex) {
                throw ex;
                //ProcessError(ex.Message, "Public Function Window(_ChannelIndex As Integer) As frmChannel")
                return null;
            }
        }
        public gChannel GetObject(int channelIndex) {
            try {
                return lChannels.cChannel(channelIndex);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public bool Visible {
            get {
                try {
                    return lChannels.cChannel(channelIndex).cVisible;
                } catch (Exception ex) {
                    throw ex;
                    return null;
                }
            }
            set {
                try {
                    var _with24 = lChannels.cChannel(channelIndex);
                    _with24.cVisible = value;
                    _with24.cWindow.Visible = value;
                    if ((value == true & _with24.cVisible == false)) {
                        if (_with24.cTreeNode.ImageIndex != 1)
                            _with24.cTreeNode.ImageIndex = 1;
                        if (_with24.cTreeNode.SelectedImageIndex != 1)
                            _with24.cTreeNode.SelectedImageIndex = 1;
                        if (_with24.cWindowBarItem.ImageIndex != 1)
                            _with24.cWindowBarItem.ImageIndex = 1;
                    }
                    _with24.cWindow.txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument();
                    if ((_with24.cTreeNode != null)) {
                        if ((_with24.cTreeNode.ImageIndex != 1))
                            _with24.cTreeNode.ImageIndex = 1;
                        if ((_with24.cTreeNode.SelectedImageIndex != 1))
                            _with24.cTreeNode.SelectedImageIndex = 1;
                    }
                    if ((_with24.cWindowBarItem != null)) {
                        if ((_with24.cTreeNode.ImageIndex != 1))
                            _with24.cTreeNode.ImageIndex = 1;
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        public int Count {
            get {
                try {
                    return lChannels.cCount;
                } catch (Exception ex) {
                    throw ex;
                    return null;
                }
            }
            set {
                try {
                    lChannels.cCount = value;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property ChannelCount() As Integer")
                }
            }
        }
        public string Name {
            get {
                try {
                    return lChannels.cChannel(_Index).cName;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property ChannelName(ByVal lIndex As Integer) As String")
                    return null;
                }
            }
            set {
                try {
                    lChannels.cChannel(_Index).cName = value;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property ChannelName(ByVal lIndex As Integer) As String")
                }
            }
        }
        public void Mode(int _StatusIndex, string _Data) {
            try {
                string[] splt = null;
                string[] splt2 = null;
                string msg = null;
                int _ChannelIndex = 0;
                if (Strings.Len(_Data) != 0 & _StatusIndex != 0) {
                    splt = Strings.Split(_Data, " ");
                    splt2 = Strings.Split(splt(0), "!");
                    if (Information.UBound(splt2) != 0) {
                        splt2(0) = Strings.Replace(splt2(0), ":", "");
                        splt2(1) = Strings.Replace(splt2(1), "n=", "");
                        _ChannelIndex = Find(_StatusIndex, splt(2));
                        switch (Strings.Trim(splt(3))) {
                            case "+o":
                                msg = lStrings.ReturnReplacedString(eStringTypes.sUSER_MODE, splt2(0), splt(3), splt(4));
                                PrivMsg(_ChannelIndex, msg);
                                break;
                            case "-o":
                                msg = lStrings.ReturnReplacedString(eStringTypes.sUSER_MODE, splt2(0), splt(3), splt(4));
                                PrivMsg(_ChannelIndex, msg);
                                break;
                        }
                    }
                }
                //'0: nickname!user@host
                //'1: mode
                //'2: channel
                //'3: mode
                //'4: username
                //':NickName!user@host MODE #channel +v username
            } catch (Exception ex) {
                throw ex;
            }
        }
        public string URL {
            get {
                try {
                    return lChannels.cChannel(lIndex).cURL;
                } catch (Exception ex) {
                    throw ex;
                    return null;
                }
            }
            set {
                try {
                    var _with25 = lChannels.cChannel(lIndex);
                    _with25.cURL = value;
                } catch (Exception ex) {
                    throw ex;
                    //ProcessError(ex.Message, "Public Property ChannelURL(ByVal lIndex As Integer) As String")
                }
            }
        }
        public Channel() {
            try {
                lChannels.cChannel = new gChannel[lSettings.lArraySizes.aChannelWindows + 1];
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}