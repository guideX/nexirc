using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories.Base;
using nexIRC.Models.Compatibility;
using System.Collections.Generic;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Compatibility Repository
    /// </summary>
    public class CompatibilityRepository : Repository<CompatibilityModel>, ICompatibilityRepository {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="ini"></param>
        public CompatibilityRepository(string ini) {
            Ini = ini;
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(CompatibilityModel obj) {
            var c = ReadCount();
            c = c++;
            SetCount(c);
            NativeMethods.WriteINI(Ini, c.ToString(), "Description", obj.Description);
            NativeMethods.WriteINI(Ini, c.ToString(), "Enabled", obj.Enabled.ToString());
            return true;
        }
        /// <summary>
        /// Load
        /// </summary>
        public IEnumerable<CompatibilityModel> ReadAll() {
            var obj = new List<CompatibilityModel>();
            if (!string.IsNullOrEmpty(Ini)) {
                for (var i = 1; i <= ReadCount(); i++) {
                    var c = new CompatibilityModel();
                    c.Description = NativeMethods.ReadINI(Ini, i.ToString(), "Description", "");
                    c.Enabled = NativeMethods.ReadINIBool(Ini, i.ToString(), "Enabled", false);
                    if (!string.IsNullOrEmpty(c.Description)) {
                        obj.Add(c);
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID) {
            NativeMethods.WriteINI(Ini, ID.ToString(), "Description", "");
            NativeMethods.WriteINI(Ini, ID.ToString(), "Enabled", "");
            return true;
        }
    }
}