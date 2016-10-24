using System.Linq;
using System.Collections.Generic;
using nexIRC.Models.Server;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories.Base;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Server Repository
    /// </summary>
    public class ServerRepository : Repository<ServerModel>, IServerRepository {
        /// <summary>
        /// Server Repository
        /// </summary>
        /// <param name="ini"></param>
        public ServerRepository(string ini) {
            Ini = ini;
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ServerModel> ReadAll() {
            var obj = new List<ServerModel>();
            if (!string.IsNullOrEmpty(Ini)) {
                for (var i = 1; i <= ReadCount(); i++) {
                    var s = new ServerModel();
                    s.Description = NativeMethods.ReadINI(Ini, i.ToString(), "Description", "");s.Description = NativeMethods.ReadINI(Ini, i.ToString(), "Description", "");
                    s.Ip = NativeMethods.ReadINI(Ini, i.ToString(), "Ip", "");
                    s.NetworkIndex = NativeMethods.ReadINIInt(Ini, i.ToString(), "NetworkIndex", 0);
                    s.Port = NativeMethods.ReadINIInt(Ini, i.ToString(), "Port", 0);
                    if (!string.IsNullOrEmpty(s.Description)) obj.Add(s);
                }
            }
            return obj;
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public bool Save(List<ServerModel> objs) {
            SetCount(objs.Count());
            for (var i = 0; i <= objs.Count - 1; i++) {
                if (!string.IsNullOrEmpty(objs[i].Description)) {
                    NativeMethods.WriteINI(Ini, i.ToString(), "Ip", objs[i].Ip);
                    NativeMethods.WriteINI(Ini, i.ToString(), "Description", objs[i].Description);
                    NativeMethods.WriteINI(Ini, i.ToString(), "NetworkIndex", objs[i].NetworkIndex.ToString());
                    NativeMethods.WriteINI(Ini, i.ToString(), "Port", objs[i].Port.ToString());
                }
            }
            return true;
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(ServerModel model) {
            var obj = ReadAll();
            if (obj != null) {
                var _obj = obj.ToList();
                _obj.Add(model);
                SetCount(_obj.Count);
                NativeMethods.WriteINI(Ini, (_obj.Count).ToString(), "Description", model.Description);
                NativeMethods.WriteINI(Ini, (_obj.Count).ToString(), "Ip", model.Ip);
                NativeMethods.WriteINI(Ini, (_obj.Count).ToString(), "NetworkIndex", model.NetworkIndex.ToString());
                NativeMethods.WriteINI(Ini, (_obj.Count).ToString(), "Port", model.Port.ToString());
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// Clear
        /// </summary>
        /// <returns></returns>
        public bool Clear() {
            var objs = ReadAll().ToList();
            SetCount(0);
            SetIndex(0);
            for (var i = 0; i <= objs.Count() - 1; i++) {
                NativeMethods.WriteINI(Ini, (i + 1).ToString(), "Description", "");
                NativeMethods.WriteINI(Ini, (i + 1).ToString(), "Ip", "");
                NativeMethods.WriteINI(Ini, (i + 1).ToString(), "Port", "0");
                NativeMethods.WriteINI(Ini, (i + 1).ToString(), "NetworkIndex", "0");
            }
            return true;
        }
    }
}