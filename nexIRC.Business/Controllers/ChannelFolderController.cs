using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories;
using nexIRC.Models.ChannelFolder;
using System;
using System.Linq;
using System.Collections.Generic;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Channel Folder Controller
    /// </summary>
    public class ChannelFolderController: IDisposable {
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Channel Folder Repository
        /// </summary>
        private IChannelFolderRepository _channelFolderRepository;
        /// <summary>
        /// Channel Folder Controller
        /// </summary>
        public ChannelFolderController(string ini) {
            _channelFolderRepository = new ChannelFolderRepository(ini);
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public List<ChannelFolderModel> ReadAll() {
            var objs = _channelFolderRepository.ReadAll();
            if (objs.Any()) {
                return objs.ToList();
            } else {
                return new List<ChannelFolderModel>();
            }
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
                    _channelFolderRepository = null;
                }
                _disposed = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}