using System;
using System.Net;
namespace nexIRC.Settings2 {
    public enum eDCCFileExistsAction {
        dPrompt = 1,
        dOverwrite = 2,
        dIgnore = 3
    }
    public enum eDCCPrompt {
        ePrompt = 1,
        eAcceptAll = 2,
        eIgnore = 3
    }
    public enum gDCCIgnoreType {
        dNicknames = 1,
        dHostnames = 2,
        dFileTypes = 3
    }
    public struct gDCCIgnoreItem {
        public gDCCIgnoreType dType;
        public string dData;
    }
    public struct gDCCIgnoreList {
        public int dCount;
        public gDCCIgnoreItem[] dItem;
    }
    public struct gDCC {
        public eDCCFileExistsAction dFileExistsAction;
        public eDCCPrompt dChatPrompt;
        public eDCCPrompt dSendPrompt;
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
    public static class DccSettings {
        public static string ReturnOutsideIPAddress() {
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


        public static void LoadDCCSettings(string ini, gDCC dcc, string startupPath) {
            int i = 0;
            int n = 0;
            dcc.dFileExistsAction = (eDCCFileExistsAction)Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "FileExistsAction", "1"));
            n = Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "ChatPrompt", "1"));
            if (n == 1) {
                dcc.dChatPrompt = eDCCPrompt.ePrompt;
            } else if (n == 2) {
                dcc.dChatPrompt = eDCCPrompt.eAcceptAll;
            } else if (n == 3) {
                dcc.dChatPrompt = eDCCPrompt.eIgnore;
            }
            n = Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "SendPrompt", "1"));
            if (n == 1) {
                dcc.dSendPrompt = eDCCPrompt.ePrompt;
            } else if (n == 2) {
                dcc.dSendPrompt = eDCCPrompt.eAcceptAll;
            } else if (n == 3) {
                dcc.dSendPrompt = eDCCPrompt.eIgnore;
            }
            dcc.dPopupDownloadManager = Convert.ToBoolean(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "PopupDownloadManager", "False"));
            dcc.dDownloadDirectory = nexIRC.IniFile.Files.ReadINI(ini, "Settings", "DownloadDirectory", "");
            if (string.IsNullOrEmpty(dcc.dDownloadDirectory) == true)
                dcc.dDownloadDirectory = startupPath + "\\";
            dcc.dDownloadDirectory = dcc.dDownloadDirectory.Replace("\\\\", "");
            dcc.dBufferSize = Convert.ToInt64(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "BufferSize", "1024"));
            dcc.dUseIpAddress = Convert.ToBoolean(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "UseIpAddress", "False"));
            dcc.dCustomIpAddress = nexIRC.IniFile.Files.ReadINI(ini, "Settings", "CustomIpAddress", "");
            if (dcc.dCustomIpAddress.Length == 0)
                dcc.dCustomIpAddress = DccSettings.ReturnOutsideIPAddress();
            dcc.dIgnorelist.dCount = Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "IgnoreCount", "0"));
            dcc.dSendPort = nexIRC.IniFile.Files.ReadINI(ini, "Settings", "SendPort", "1024");
            dcc.dRandomizePort = Convert.ToBoolean(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "RandomizePort", "True"));
            dcc.dIgnorelist.dCount = Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString()));
            dcc.dAutoIgnore = Convert.ToBoolean(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "AutoIgnore", "True"));
            dcc.dAutoCloseDialogs = Convert.ToBoolean(nexIRC.IniFile.Files.ReadINI(ini, "Settings", "AutoCloseDialogs", "False"));
            for (i = 1; i <= dcc.dIgnorelist.dCount; i++) {
                //var _with2 = dcc.dIgnorelist.dItem[i];
                dcc.dIgnorelist.dItem[i].dData = nexIRC.IniFile.Files.ReadINI(ini, i.ToString(), "Data", "");
                dcc.dType = (gDCCIgnoreType)Convert.ToInt32(nexIRC.IniFile.Files.ReadINI(ini, i.ToString(), "Type", "0"));
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
        }
        public static void SaveDCCSettings(string ini, gDCC dcc) {
            try {
                int i = 0;
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "PopupDownloadManager", dcc.dPopupDownloadManager.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "DownloadDirectory", dcc.dDownloadDirectory);
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "FileExistsAction", dcc.dFileExistsAction.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString());
                for (i = 1; i <= dcc.dIgnorelist.dCount; i++) {
                    nexIRC.IniFile.Files.WriteINI(ini, i.ToString().Trim(), "Data", dcc.dIgnorelist.dItem[i].dData.ToString());
                    nexIRC.IniFile.Files.WriteINI(ini, i.ToString().Trim(), "Type", dcc.dIgnorelist.dItem[i].dType.ToString());
                }
                if (dcc.dChatPrompt == eDCCPrompt.ePrompt) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "ChatPrompt", "1");
                } else if (dcc.dChatPrompt == eDCCPrompt.eAcceptAll) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "ChatPrompt", "2");
                } else if (dcc.dChatPrompt == eDCCPrompt.eIgnore) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "ChatPrompt", "3");
                }
                if (dcc.dSendPrompt == eDCCPrompt.ePrompt) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "SendPrompt", "1");
                } else if (dcc.dSendPrompt == eDCCPrompt.eAcceptAll) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "SendPrompt", "2");
                } else if (dcc.dSendPrompt == eDCCPrompt.eIgnore) {
                    nexIRC.IniFile.Files.WriteINI(ini, "Settings", "SendPrompt", "3");
                }
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "UseIpAddress", dcc.dUseIpAddress.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "CustomIpAddress", dcc.dCustomIpAddress);
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "IgnoreCount", dcc.dIgnorelist.dCount.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "SendPort", dcc.dSendPort.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "RandomizePort", dcc.dRandomizePort.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "BufferSize", dcc.dBufferSize.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "AutoIgnore", dcc.dAutoIgnore.ToString());
                nexIRC.IniFile.Files.WriteINI(ini, "Settings", "AutoCloseDialogs", dcc.dAutoCloseDialogs.ToString());
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}