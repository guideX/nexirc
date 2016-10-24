using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories;
using nexIRC.Models.Server;
using System;
using System.Collections.Generic;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Recent Servers Controller
    /// </summary>
    public class RecentServersController {
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Compatibility Models
        /// </summary>
        public List<ServerModel> RecentServers { get; set; }
        /// <summary>
        /// Recent Server Repository
        /// </summary>
        private IRecentServerRepository _recentServerRepository;
        /// <summary>
        /// Entry Point
        /// </summary>
        public RecentServersController(string ini, bool load = true) {
            _ini = ini;
            _recentServerRepository = new RecentServerRepository(ini, load);
        }
        public void Save() {
            _recentServerRepository.SaveRecentServers();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            _recentServerRepository.Load();
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual void Dispose(bool _disposing) {
            if (_disposed) {
                return;
            }
            if (_disposing) {
            }
            _disposed = true;
        }
    }
}