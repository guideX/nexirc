using System;
using System.Linq;
using System.Collections.Generic;
using nexIRC.Business.Helpers;
using nexIRC.Business.Models.ChannelFolder;
namespace nexIRC.Business.Repositories {
    /// <summary>
    /// Channel Folders
    /// </summary>
    public class ChannelFolderRepository {
        private string _iniFile;
        //private List<ChannelFolderModel> _cached;
        //private bool _useCache = false;
        /// <summary>
        /// Entry Point
        /// </summary>
        public ChannelFolderRepository(string startupPath) {
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
        public List<ChannelFolderModel> Get(string network = "") {
            var channelFolders = new List<ChannelFolderModel>();
            //if (!_useCache) {
            var n = Convert.ToInt32(IniFileHelper.ReadINI(_iniFile, "Settings", "Count", "0"));
            for (var i = 1; i <= n; i++) {
                var c = new ChannelFolderModel();
                var b = false;
                c.Network = IniFileHelper.ReadINI(_iniFile, i.ToString(), "Network", "");
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
                    c.Channel = IniFileHelper.ReadINI(_iniFile, i.ToString(), "Channel", "");
                    var msg = IniFileHelper.ReadINI(_iniFile, i.ToString(), "Order", "0");
                    var t = 0;
                    if (int.TryParse(msg, out t)) {
                        c.Order = t;
                    }
                    channelFolders.Add(c);
                }
            }
            //_cached = channelFolders;
            //_useCache = true;
            return channelFolders;
            //} else {
            //return _cached.Where(c => c.Network == network).ToList();
            //}
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="channelFolder"></param>
        public bool Add(ChannelFolderModel channelFolder) {
            var channelFolders = Get();
            channelFolders.Add(channelFolder);
            Clear();
            Save(channelFolders);
            //_useCache = false;
            return true;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="channelFolder"></param>
        public bool Add(string channel, string network) {
            if (!string.IsNullOrEmpty(channel) && !string.IsNullOrEmpty(network)) {
                var channelFolders = Get();
                var channelFolder = new ChannelFolderModel();
                channelFolder.Channel = channel;
                channelFolder.Network = network;
                channelFolder.Order = 0;
                channelFolders.Add(channelFolder);
                Save(channelFolders);
                //_useCache = false;
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// Clear
        /// </summary>
        public bool Clear() {
            var channelFolders = Get();
            IniFileHelper.WriteINI(_iniFile, "Settings", "Count", "0");
            var n = 0;
            foreach (var channelFolder in channelFolders) {
                n++;
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Channel", "");
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Network", "");
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Order", "");
            }
            //_useCache = false;
            return true;
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="channelFolders"></param>
        /// <returns></returns>
        public bool Save(List<ChannelFolderModel> channelFolders) {
            var n = 0;
            IniFileHelper.WriteINI(_iniFile, "Settings", "Count", channelFolders.Count.ToString());
            foreach (var channelFolder in channelFolders) {
                n++;
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Channel", channelFolder.Channel);
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Network", channelFolder.Network);
                IniFileHelper.WriteINI(_iniFile, n.ToString(), "Order", channelFolder.Order.ToString());
            }
            //_useCache = false;
            return true;
        }
        /// <summary>
        /// Clean
        /// </summary>
        /// <param name="channelFolders"></param>
        /// <returns></returns>
        public List<ChannelFolderModel> Clean(List<ChannelFolderModel> channelFolders) {
            var result = new List<ChannelFolderModel>();
            foreach (var channelFolder in channelFolders) {
                if (!string.IsNullOrEmpty(channelFolder.Channel) && !string.IsNullOrEmpty(channelFolder.Network)) {
                    result.Add(channelFolder);
                }
            }
            return result;
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="channelFolderString"></param>
        /// <returns></returns>
        public ChannelFolderModel Find(string channelFolderString) {
            return Get().Where(cf => cf.Channel == channelFolderString).FirstOrDefault();
        }
        /// <summary>
        /// Find (With Network)
        /// </summary>
        /// <param name="channelFolderString"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        public ChannelFolderModel Find(string channelFolderString, string network) {
            return Get().Where(cf => cf.Channel == channelFolderString && cf.Network == network).FirstOrDefault();
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="channelFolder"></param>
        /// <returns></returns>
        public bool Delete(ChannelFolderModel channelFolder) {
            var channelFolders = Get();
            var itemToRemove = channelFolders.Where(cf => cf.Channel == channelFolder.Channel && cf.Network == channelFolder.Network && cf.Order == channelFolder.Order).FirstOrDefault();
            channelFolders.Remove(itemToRemove);
            if (Clear()) {
                if (Save(channelFolders)) {
                    return true;
                }
            }
            return false;
        }
    }
}