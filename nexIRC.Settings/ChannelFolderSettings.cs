using System;
using System.Linq;
using System.Collections.Generic;
using nexIRC.IniFile;
namespace nexIRC.IrcSettings {
    /// <summary>
    /// What contains the Channel Folder Data
    /// </summary>
    public class ChannelFolderData {
        public string Channel { get; set; }
        public string Network { get; set; }
        public int Order;
    }
    /// <summary>
    /// Channel Folders
    /// </summary>
    public class ChannelFolders {
        private string _iniFile;
        private List<ChannelFolderData> _cached;
        private bool _useCache = false;
        /// <summary>
        /// Entry Point
        /// </summary>
        public ChannelFolders(string startupPath) {
            try {
                _iniFile = startupPath + @"data\config\channelfolders.ini";
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Channel Folders
        /// </summary>
        /// <returns></returns>
        public List<ChannelFolderData> Get(string network = "") {
            var channelFolders = new List<ChannelFolderData>();
            try {
                if(!_useCache) {
                    var n = Convert.ToInt32(Files.ReadINI(_iniFile, "Settings", "Count", "0"));
                    for (var i = 1; i <= n; i++) {
                        var c = new ChannelFolderData();
                        var b = false;
                        c.Network = Files.ReadINI(_iniFile, i.ToString(), "Network", "");
                        if (!string.IsNullOrEmpty(network)) {
                            if (!string.IsNullOrEmpty(c.Network)) {
                                if (c.Network == network) {
                                    b = true;
                                }
                            } else {
                                b = false;
                            }
                        } else {
                            b = true;
                        }
                        if (b) {
                            c.Channel = Files.ReadINI(_iniFile, i.ToString(), "Channel", "");
                            var msg = Files.ReadINI(_iniFile, i.ToString(), "Order", "0");
                            var t = 0;
                            if (int.TryParse(msg, out t)) {
                                c.Order = t;
                            }
                            channelFolders.Add(c);
                        }
                    }
                } else {
                    return _cached;
                }
                _cached = channelFolders;
                _useCache = true;
                return channelFolders;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="channelFolder"></param>
        public bool Add(ChannelFolderData channelFolder) {
            try {
                var channelFolders = Get();
                channelFolders.Add(channelFolder);
                Clear();
                Save(channelFolders);
                _useCache = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }        /// <summary>
        /// Add
        /// </summary>
        /// <param name="channelFolder"></param>
        public bool Add(string channel, string network) {
            try {
                if (!string.IsNullOrEmpty(channel) && !string.IsNullOrEmpty(network)) {
                    var channelFolders = Get();
                    var channelFolder = new ChannelFolderData();
                    channelFolder.Channel = channel;
                    channelFolder.Network = network;
                    channelFolder.Order = 0;
                    channelFolders.Add(channelFolder);
                    Save(channelFolders);
                    _useCache = false;
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Clear
        /// </summary>
        public bool Clear() {
            try {
                var channelFolders = Get();
                Files.WriteINI(_iniFile, "Settings", "Count", "0");
                var n = 0;
                foreach (var channelFolder in channelFolders) {
                    n++;
                    Files.WriteINI(_iniFile, n.ToString(), "Channel", "");
                    Files.WriteINI(_iniFile, n.ToString(), "Network", "");
                    Files.WriteINI(_iniFile, n.ToString(), "Order", "");
                }
                _useCache = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="channelFolders"></param>
        /// <returns></returns>
        public bool Save(List<ChannelFolderData> channelFolders) {
            try {
                var n = 0;
                Files.WriteINI(_iniFile, "Settings", "Count", channelFolders.Count.ToString());
                foreach(var channelFolder in channelFolders) {
                    n++;
                    Files.WriteINI(_iniFile, n.ToString(), "Channel", channelFolder.Channel);
                    Files.WriteINI(_iniFile, n.ToString(), "Network", channelFolder.Network);
                    Files.WriteINI(_iniFile, n.ToString(), "Order", channelFolder.Order.ToString());
                }
                _useCache = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Clean
        /// </summary>
        /// <param name="channelFolders"></param>
        /// <returns></returns>
        public List<ChannelFolderData> Clean(List<ChannelFolderData> channelFolders) {
            try {
                var result = new List<ChannelFolderData>();
                foreach (var channelFolder in channelFolders) {
                    if (!string.IsNullOrEmpty(channelFolder.Channel) && !string.IsNullOrEmpty(channelFolder.Network)) {
                        result.Add(channelFolder);
                    }
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="channelFolderString"></param>
        /// <returns></returns>
        public ChannelFolderData Find(string channelFolderString) {
            try {
                return Get().Where(cf => cf.Channel == channelFolderString).FirstOrDefault();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Find (With Network)
        /// </summary>
        /// <param name="channelFolderString"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        public ChannelFolderData Find(string channelFolderString, string network) {
            try {
                return Get().Where(cf => cf.Channel == channelFolderString && cf.Network == network).FirstOrDefault();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="channelFolder"></param>
        /// <returns></returns>
        public bool Delete(ChannelFolderData channelFolder) {
            try {
                var channelFolders = Get();
                var itemToRemove = channelFolders.Where(cf => cf.Channel == channelFolder.Channel && cf.Network == channelFolder.Network && cf.Order == channelFolder.Order).FirstOrDefault();
                channelFolders.Remove(itemToRemove);
                if (Clear()) {
                    if(Save(channelFolders)) {
                        return true;
                    }
                }
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}