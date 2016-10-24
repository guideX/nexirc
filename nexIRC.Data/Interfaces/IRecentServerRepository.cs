using nexIRC.Data.Interfaces.Base;
using nexIRC.Models.Server;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Recent Server Repository
    /// </summary>
    public interface IRecentServerRepository : IRepository<ServerModel> {
        /// <summary>
        /// Load
        /// </summary>
        void Load();
        /// <summary>
        /// Save Recent Servers
        /// </summary>
        void SaveRecentServers();
    }
}