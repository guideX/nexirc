using nexIRC.Data.Interfaces;
using nexIRC.Models.ChannelFolder;
using System.Collections.Generic;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Channel Folder Repository
    /// </summary>
    public class ChannelFolderRepository : Base.Repository<ChannelFolderModel>, IChannelFolderRepository {
        /// <summary>
        /// Channel Folder Repository
        /// </summary>
        public ChannelFolderRepository(string ini) {
            Ini = ini;
        }
        /// <summary>
        /// Load
        /// </summary>
        public IEnumerable<ChannelFolderModel> ReadAll() {
            var obj = new List<ChannelFolderModel>();
            if (!string.IsNullOrEmpty(Ini)) {
                for (var i = 1; i <= ReadCount(); i++) {
                    var c = new ChannelFolderModel();
                    c.Channel = NativeMethods.ReadINI(Ini, i.ToString(), "Channel", "");
                    c.Network = NativeMethods.ReadINI(Ini, i.ToString(), "Network", "");
                    if (!string.IsNullOrEmpty(c.Channel) && !string.IsNullOrEmpty(c.Network)) obj.Add(c);
                }
            }
            return obj;
        }
    }
}