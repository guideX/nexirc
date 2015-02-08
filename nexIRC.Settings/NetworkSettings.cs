using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nexIRC.IniFile;
namespace nexIRC.IrcSettings {
    /// <summary>
    /// Network Data
    /// </summary>
    public class NetworkData {
        public string Description { get; set; }
        public int Id { get; set; }
    }
    public class NetworkSettings {
        private string _iniFile;
        private List<NetworkData> _cache;
        private bool _useCache;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public NetworkSettings(string startupPath) {
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
        public List<NetworkData> Get() {
            try {
                if (!_useCache) {
                    var n = Convert.ToInt32(Files.ReadINI(_iniFile, "Settings", "Count", "0"));
                    var result = new List<NetworkData>();
                    for (var i = 1; i <= n; i++) {
                        var d = new NetworkData();
                        d.Description = Files.ReadINI(_iniFile, i.ToString(), "Description", "");
                        d.Id = i;
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
        public int Count() {
            var msg = Files.ReadINI(_iniFile, "Settings", "Count", "0");
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
        public bool Save(List<NetworkData> networks) {
            try {
                var n = 0;
                foreach (var network in networks) {
                    if (!string.IsNullOrEmpty(network.Description)) {
                        n++;
                        Files.WriteINI(_iniFile, n.ToString(), "Description", network.Description);
                    }
                }
                Files.WriteINI(_iniFile, "Settings", "Count", n.ToString());
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
        public bool Delete(NetworkData network) {
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
                Files.WriteINI(_iniFile, "Settings", "Count", "0");
                var n = 0;
                foreach (var network in networks) {
                    n++;
                    Files.WriteINI(_iniFile, n.ToString(), "Description", "");
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
        public NetworkData GetDefault() {
            try {
                var network = new NetworkData();
                var msg = Files.ReadINI(_iniFile, "Settings", "Index", "0");
                int n = 0;
                if (int.TryParse(msg, out n)) {
                    if (n != 0) {
                        network.Description = Files.ReadINI(_iniFile, n.ToString(), "Description", "");
                        network.Id = n;
                        return network;
                    } else {
                        return new NetworkData();
                    }
                } else {
                    return new NetworkData();
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
        public bool SetDefault(NetworkData network) {
            try {
                var networks = Get();
                var t = 0;
                foreach (var n in networks) {
                    t++;
                    if (n.Description == network.Description) {
                        Files.WriteINI(_iniFile, "Settings", "Index", t.ToString());
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
        public NetworkData GetById(int networkId) {
            try {
                var network = new NetworkData();
                network.Description = Files.ReadINI(_iniFile, networkId.ToString(), "Description", "");
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
        public int Add(NetworkData network) {
            try {
                var msg = Files.ReadINI(_iniFile, "Settings", "Count", "0");
                var n = 0;
                if(int.TryParse(msg, out(n))) {
                    n = n + 1;
                    Files.WriteINI(_iniFile, "Settings", "Count", n.ToString());
                    Files.WriteINI(_iniFile, n.ToString(), "Description", network.Description);
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
        public NetworkData Find(string networkDescription) {
            try {
                var result = new NetworkData();
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