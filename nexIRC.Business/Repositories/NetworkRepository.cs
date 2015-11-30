using System;
using System.Collections.Generic;
using System.Linq;
using nexIRC.Business.Helpers;
using nexIRC.Business.Models.Network;

namespace nexIRC.Business.Repositories {
    /// <summary>
    /// Network Repository
    /// </summary>
    public class NetworkRepository {
        private string _iniFile;
        private List<NetworkDataModel> _cache;
        private bool _useCache;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public NetworkRepository(string startupPath) {
            try {
                _iniFile = startupPath + @"data\config\networks.ini";
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public List<NetworkDataModel> Get() {
            try {
                if (!_useCache) {
                    var n = Convert.ToInt32(IniFileHelper.ReadINI(_iniFile, "Settings", "Count", "0"));
                    var result = new List<NetworkDataModel>();
                    for (var i = 1; i <= n; i++) {
                        var d = new NetworkDataModel();
                        d.Description = IniFileHelper.ReadINI(_iniFile, i.ToString(), "Description", "");
                        d.ID = i;
                        if (!string.IsNullOrEmpty(d.Description)) {
                            result.Add(d);
                        }
                    }
                    _cache = result;
                    _useCache = true;
                    return result;
                } else {
                    return _cache;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count() {
            var msg = IniFileHelper.ReadINI(_iniFile, "Settings", "Count", "0");
            var n = 0;
            if (int.TryParse(msg, out n)) {
                return n;
            } else {
                return 0;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="networks"></param>
        /// <returns></returns>
        public bool Save(List<NetworkDataModel> networks) {
            try {
                var n = 0;
                foreach (var network in networks) {
                    if (!string.IsNullOrEmpty(network.Description)) {
                        n++;
                        IniFileHelper.WriteINI(_iniFile, n.ToString(), "Description", network.Description);
                    }
                }
                IniFileHelper.WriteINI(_iniFile, "Settings", "Count", n.ToString());
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public bool Delete(NetworkDataModel network) {
            try {
                var networks = Get();
                var itemToRemove = networks.Where(n => n.Description == network.Description).FirstOrDefault();
                networks.Remove(itemToRemove);
                if (Clear()) {
                    if (Save(networks)) {
                        return true;
                    }
                }
                _useCache = false;
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Clear
        /// </summary>
        /// <returns></returns>
        public bool Clear() {
            try {
                var networks = Get();
                IniFileHelper.WriteINI(_iniFile, "Settings", "Count", "0");
                var n = 0;
                foreach (var network in networks) {
                    n++;
                    IniFileHelper.WriteINI(_iniFile, n.ToString(), "Description", "");
                }
                _useCache = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Default
        /// </summary>
        /// <returns></returns>
        public NetworkDataModel GetDefault() {
            try {
                var network = new NetworkDataModel();
                var msg = IniFileHelper.ReadINI(_iniFile, "Settings", "Index", "0");
                int n = 0;
                if (int.TryParse(msg, out n)) {
                    if (n != 0) {
                        network.Description = IniFileHelper.ReadINI(_iniFile, n.ToString(), "Description", "");
                        network.ID = n;
                        return network;
                    } else {
                        return new NetworkDataModel();
                    }
                } else {
                    return new NetworkDataModel();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Set Default
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public bool SetDefault(NetworkDataModel network) {
            try {
                var networks = Get();
                var t = 0;
                foreach (var n in networks) {
                    t++;
                    if (n.Description == network.Description) {
                        IniFileHelper.WriteINI(_iniFile, "Settings", "Index", t.ToString());
                        return true;
                    }
                }
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="networkId"></param>
        /// <returns></returns>
        public NetworkDataModel GetById(int networkId) {
            try {
                var network = new NetworkDataModel();
                network.Description = IniFileHelper.ReadINI(_iniFile, networkId.ToString(), "Description", "");
                return network;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public int Add(NetworkDataModel network) {
            try {
                var msg = IniFileHelper.ReadINI(_iniFile, "Settings", "Count", "0");
                var n = 0;
                if(int.TryParse(msg, out(n))) {
                    n = n + 1;
                    IniFileHelper.WriteINI(_iniFile, "Settings", "Count", n.ToString());
                    IniFileHelper.WriteINI(_iniFile, n.ToString(), "Description", network.Description);
                }
                _useCache = false;
                return n;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="networkDescription"></param>
        /// <returns></returns>
        public NetworkDataModel Find(string networkDescription) {
            try {
                var result = new NetworkDataModel();
                foreach (var network in Get()) {
                    if (!string.IsNullOrEmpty(networkDescription)) {
                        if (!string.IsNullOrEmpty(network.Description)) {
                            if (networkDescription.Trim() == network.Description.Trim()) {
                                result = network;
                                break;
                            }
                        }
                    }
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}