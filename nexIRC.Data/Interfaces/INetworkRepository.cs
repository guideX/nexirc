using nexIRC.Data.Interfaces.Base;
using nexIRC.Models.Network;
using System.Collections.Generic;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Network Repository
    /// </summary>
    public interface INetworkRepository : IRepository<NetworkModel> {
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        IEnumerable<NetworkModel> ReadAll();
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        bool Save(List<NetworkModel> models);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Create(NetworkModel model, List<NetworkModel> objs);
        /// <summary>
        /// Clear All
        /// </summary>
        /// <returns></returns>
        bool Clear();
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        int? Find(string network, List<NetworkModel> networks);
    }
}