using nexIRC.Models.ChannelFolder;
using System.Collections.Generic;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Channel Folder Repository
    /// </summary>
    public interface IChannelFolderRepository : Base.IRepository<ChannelFolderModel> {
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChannelFolderModel> ReadAll();
    }
}