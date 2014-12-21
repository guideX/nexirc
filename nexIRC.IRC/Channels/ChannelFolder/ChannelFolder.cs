//nexIRC 3.0.31
//Sunday, Oct 4th, 2014 - guideX
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics;
//using Microsoft.VisualBasic;
using Telerik.WinControls.UI;
using System.Windows.Forms;
namespace nexIRC.IRC.Channels.ChannelFolder {
    public class ChannelFolder {
        public bool lVisible;
        private frmChannelFolder withEventsField_lWindow;
        private frmChannelFolder lWindow {
            get { return withEventsField_lWindow; }
            set {
                if (withEventsField_lWindow != null) {
                    withEventsField_lWindow.FormClosed -= lWindow_FormClosed;
                }
                withEventsField_lWindow = value;
                if (withEventsField_lWindow != null) {
                    withEventsField_lWindow.FormClosed += lWindow_FormClosed;
                }
            }
        }
        public void Show(int _StatusIndex) {
            try {
                ShowWindow();
                SetStatusIndex(_StatusIndex);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void ShowWindow() {
            try {
                lWindow = new Form();
                lWindow.Show();
                lVisible = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void RefreshChannelFolderChannelList() {
            try {
                if ((lVisible == true)) {
                    lWindow.Init();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void SetStatusIndex(int _StatusIndex) {
            try {
                lWindow.SetStatusIndex(_StatusIndex);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void lWindow_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e) {
            try {
                lVisible = false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public Form Window() {
            try {
                return lWindow;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}