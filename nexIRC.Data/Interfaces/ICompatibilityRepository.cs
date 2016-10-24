using nexIRC.Data.Interfaces.Base;
using nexIRC.Models.Compatibility;
using System.Collections.Generic;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Compatibility Repository
    /// </summary>
    public interface ICompatibilityRepository : IRepository<CompatibilityModel> {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Create(CompatibilityModel obj);
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        IEnumerable<CompatibilityModel> ReadAll();
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool Delete(int ID);
    }
}