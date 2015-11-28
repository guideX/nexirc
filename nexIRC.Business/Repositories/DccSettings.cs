using System;
using System.Net;
using nexIRC.Business.Helpers;
using nexIRC.Business.Enums;
namespace nexIRC.Business.Repositories {
    /// <summary>
    /// Dcc Ignore Type
    /// </summary>
    public enum gDCCIgnoreType {
        dNicknames = 1,
        dHostnames = 2,
        dFileTypes = 3
    }
    /// <summary>
    /// Dcc Ignore Item
    /// </summary>
    public struct gDCCIgnoreItem {
        public gDCCIgnoreType dType;
        public string dData;
    }
    /// <summary>
    /// Dcc Ignore List
    /// </summary>
    public struct gDCCIgnoreList {
        public int dCount;
        public gDCCIgnoreItem[] dItem;
    }
    /// <summary>
    /// Dcc
    /// </summary>
    public struct gDCC {
        public eDccFileExistsAction dFileExistsAction;
        public eDccPrompt dChatPrompt;
        public eDccPrompt dSendPrompt;
        public gDCCIgnoreType dType;
        public bool dUseIpAddress;
        public string dCustomIpAddress;
        public gDCCIgnoreList dIgnorelist;
        public string dSendPort;
        public bool dRandomizePort;
        public long dBufferSize;
        public bool dAutoIgnore;
        public bool dAutoCloseDialogs;
        public string dDownloadDirectory;
        public bool dPopupDownloadManager;
    }
    /// <summary>
    /// Dcc Settings
    /// </summary>
    public static class DccSettings {
        /// <summary>
        /// Return Outside Ip Address
        /// </summary>
        /// <returns></returns>
        public static string IpAddress() {
            try {
                WebClient client = new WebClient();
                string baseurl = "http://checkip.dyndns.org:8245/";
                System.IO.Stream data = default(System.IO.Stream);
                System.IO.StreamReader reader = default(System.IO.StreamReader);
                string s = null;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)");
                data = client.OpenRead(baseurl);
                reader = new System.IO.StreamReader(data);
                s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                s = s.Replace("<html><head><title>Current IP Check</title></head><body>", "").Replace("</body></html>", "").ToString();
                s = s.Replace("Current IP Address: ", "");
                return s;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Load Dcc Settings
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="startupPath"></param>
        /// <returns></returns>
        public static gDCC Read(string startupPath) {
            var ini = startupPath + @"\data\config\dcc.ini";
            var dcc = new gDCC();
            var i = 0;
            var n = 0;
            dcc.dFileExistsAction = (eDccFileExistsAction)Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "FileExistsAction", "1"));
            n = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "ChatPrompt", "1"));
            if (n == 1) {
                dcc.dChatPrompt = eDccPrompt.ePrompt;
            } else if (n == 2) {
                dcc.dChatPrompt = eDccPrompt.eAcceptAll;
            } else if (n == 3) {
                dcc.dChatPrompt = eDccPrompt.eIgnore;
            }
            n = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "SendPrompt", "1"));
            if (n == 1) {
                dcc.dSendPrompt = eDccPrompt.ePrompt;
            } else if (n == 2) {
                dcc.dSendPrompt = eDccPrompt.eAcceptAll;
            } else if (n == 3) {
                dcc.dSendPrompt = eDccPrompt.eIgnore;
            }
            dcc.dPopupDownloadManager = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "PopupDownloadManager", "False"));
            dcc.dDownloadDirectory = IniFileHelper.ReadINI(ini, "Settings", "DownloadDirectory", "");
            if (string.IsNullOrEmpty(dcc.dDownloadDirectory) == true)
                dcc.dDownloadDirectory = startupPath + "\\";
            dcc.dDownloadDirectory = dcc.dDownloadDirectory.Replace("\\\\", "");
            dcc.dBufferSize = Convert.ToInt64(IniFileHelper.ReadINI(ini, "Settings", "BufferSize", "1024"));
            dcc.dUseIpAddress = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "UseIpAddress", "False"));
            dcc.dCustomIpAddress = IniFileHelper.ReadINI(ini, "Settings", "CustomIpAddress", "");
            if (dcc.dCustomIpAddress.Length == 0) {
                dcc.dCustomIpAddress = DccSettings.IpAddress();
            }
            dcc.dIgnorelist.dCount = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "IgnoreCount", "0"));
            dcc.dSendPort = IniFileHelper.ReadINI(ini, "Settings", "SendPort", "1024");
            dcc.dRandomizePort = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "RandomizePort", "True"));
            dcc.dIgnorelist.dCount = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString()));
            dcc.dAutoIgnore = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "AutoIgnore", "True"));
            dcc.dAutoCloseDialogs = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "AutoCloseDialogs", "False"));
            for (i = 1; i <= dcc.dIgnorelist.dCount; i++) {
                //var _with2 = dcc.dIgnorelist.dItem[i];
                dcc.dIgnorelist.dItem[i].dData = IniFileHelper.ReadINI(ini, i.ToString(), "Data", "");
                dcc.dType = (gDCCIgnoreType)Convert.ToInt32(IniFileHelper.ReadINI(ini, i.ToString(), "Type", "0"));
                switch (dcc.dType) {
                    case gDCCIgnoreType.dNicknames:
                        dcc.dType = gDCCIgnoreType.dNicknames;
                        break;
                    case gDCCIgnoreType.dHostnames:
                        dcc.dType = gDCCIgnoreType.dHostnames;
                        break;
                    case gDCCIgnoreType.dFileTypes:
                        dcc.dType = gDCCIgnoreType.dFileTypes;
                        break;
                }
            }
            return dcc;
        }
        /// <summary>
        /// Save Dcc Settings
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="dcc"></param>
        public static void SaveDCCSettings(string ini, gDCC dcc) {
            try {
                int i = 0;
                IniFileHelper.WriteINI(ini, "Settings", "PopupDownloadManager", dcc.dPopupDownloadManager.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "DownloadDirectory", dcc.dDownloadDirectory);
                IniFileHelper.WriteINI(ini, "Settings", "FileExistsAction", dcc.dFileExistsAction.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString());
                for (i = 1; i <= dcc.dIgnorelist.dCount; i++) {
                    IniFileHelper.WriteINI(ini, i.ToString().Trim(), "Data", dcc.dIgnorelist.dItem[i].dData.ToString());
                    IniFileHelper.WriteINI(ini, i.ToString().Trim(), "Type", dcc.dIgnorelist.dItem[i].dType.ToString());
                }
                if (dcc.dChatPrompt == eDccPrompt.ePrompt) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "1");
                } else if (dcc.dChatPrompt == eDccPrompt.eAcceptAll) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "2");
                } else if (dcc.dChatPrompt == eDccPrompt.eIgnore) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "3");
                }
                if (dcc.dSendPrompt == eDccPrompt.ePrompt) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "1");
                } else if (dcc.dSendPrompt == eDccPrompt.eAcceptAll) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "2");
                } else if (dcc.dSendPrompt == eDccPrompt.eIgnore) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "3");
                }
                IniFileHelper.WriteINI(ini, "Settings", "UseIpAddress", dcc.dUseIpAddress.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "CustomIpAddress", dcc.dCustomIpAddress);
                IniFileHelper.WriteINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "SendPort", dcc.dSendPort.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "RandomizePort", dcc.dRandomizePort.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "BufferSize", dcc.dBufferSize.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "AutoIgnore", dcc.dAutoIgnore.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "AutoCloseDialogs", dcc.dAutoCloseDialogs.ToString());
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}