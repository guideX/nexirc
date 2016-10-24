using nexIRC.Data.Interfaces.Base;
using nexIRC.Models.Server;
using System.Collections.Generic;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Server Repository
    /// </summary>
    public interface IServerRepository : IRepository<ServerModel> {
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        IEnumerable<ServerModel> ReadAll();
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        bool Save(List<ServerModel> objs);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create(ServerModel model);
        /// <summary>
        /// Clear
        /// </summary>
        /// <returns></returns>
        bool Clear();
    }
}