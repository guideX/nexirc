using System;
using System.Linq;
using System.Collections.Generic;
using nexIRC.Models.Network;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories;
using nexIRC.Models.Server;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Network Controller
    /// </summary>
    public class ConnectionController : IDisposable {
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Network Repository
        /// </summary>
        private INetworkRepository _networkRepository;
        /// <summary>
        /// Server Repository
        /// </summary>
        private IServerRepository _serverRepository;
        /// <summary>
        /// Network Controller
        /// </summary>
        /// <param name="ini"></param>
        public ConnectionController(string networksIni, string serversIni) {
            _networkRepository = new NetworkRepository(networksIni);
            _serverRepository = new ServerRepository(serversIni);
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public List<NetworkModel> ReadAllNetworks() {
            var obj = _networkRepository.ReadAll();
            if (obj.Any()) {
                return obj.ToList();
            } else {
                return new List<NetworkModel>();
            }
        }
        /// <summary>
        /// Read Network Index
        /// </summary>
        /// <returns></returns>
        public int ReadNetworkIndex() {
            return _networkRepository.ReadIndex();
        }
        /// <summary>
        /// Read Server Index
        /// </summary>
        /// <returns></returns>
        public int ReadServerIndex() {
            return _serverRepository.ReadIndex();
        }
        /// <summary>
        /// Save Networks
        /// </summary>
        public bool SaveNetworks(List<NetworkModel> models) {
            return _networkRepository.Save(models);
        }
        /// <summary>
        /// Clear Networks
        /// </summary>
        /// <returns></returns>
        public bool ClearNetworks() {
            return _networkRepository.Clear();
        }
        /// <summary>
        /// Add Network
        /// </summary>
        /// <returns></returns>
        public bool CreateNetwork(NetworkModel obj, List<NetworkModel> objs) {
            return _networkRepository.Create(obj, objs);
        }
        /// <summary>
        /// Create Server
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CreateServer(ServerModel obj) {
            return _serverRepository.Create(obj);
        }
        /// <summary>
        /// Find Network Index
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public int? FindNetworkIndex(string network, List<NetworkModel> networks) {
            return _networkRepository.Find(network, networks);
        }
        /// <summary>
        /// Read All Servers
        /// </summary>
        /// <returns></returns>
        public List<ServerModel> ReadAllServers() {
            var obj = _serverRepository.ReadAll();
            if (obj.Any()) {
                return obj.ToList();
            } else {
                return new List<ServerModel>();
            }
        }
        /// <summary>
        /// Save Servers
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public bool SaveServers(List<ServerModel> objs) {
            return _serverRepository.Save(objs);
        }
        /// <summary>
        /// Clear Servers
        /// </summary>
        /// <returns></returns>
        public bool ClearServers() {
            return _serverRepository.Clear();
        }
        /// <summary>
        /// Set Server Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool SetServerIndex(int index) {
            return _serverRepository.SetIndex(index);
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            try {
                Dispose(true);
                GC.SuppressFinalize(this);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual void Dispose(bool _disposing) {
            try {
                if (_disposed) {
                    return;
                }
                if (_disposing) {
                    _networkRepository = null;
                    _serverRepository = null;
                }
                _disposed = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}