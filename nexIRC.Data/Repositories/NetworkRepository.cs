using System.Linq;
using System.Collections.Generic;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories.Base;
using nexIRC.Models.Network;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Network Repository
    /// </summary>
    public class NetworkRepository : Repository<NetworkModel>, INetworkRepository {
        /// <summary>
        /// Network Repository
        /// </summary>
        /// <param name="ini"></param>
        public NetworkRepository(string ini) {
            Ini = ini;
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NetworkModel> ReadAll() {
            var obj = new List<NetworkModel>();
            if (!string.IsNullOrEmpty(Ini)) {
                for (var i = 1; i <= ReadCount(); i++) {
                    var n = new NetworkModel();
                    n.Name = NativeMethods.ReadINI(Ini, i.ToString(), "Name", "");
                    n.ID = i;
                    if (!string.IsNullOrEmpty(n.Name)) obj.Add(n);
                }
            }
            return obj;
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool Save(List<NetworkModel> models) {
            var n = 0;
            SetCount(models.Count);
            for (var i = 0; i <= models.Count - 1; i++) {
                if (models[i] != null && !string.IsNullOrEmpty(models[i].Name)) {
                    n++;
                    NativeMethods.WriteINI(Ini, n.ToString(), "Name", models[i].Name);
                }
            }
            return true;
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(NetworkModel model, List<NetworkModel> objs) {
            if (objs != null) {
                objs.Add(model);
                SetCount(objs.Count);
                NativeMethods.WriteINI(Ini, (objs.Count).ToString(), "Name", model.Name);
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// Clear Networks
        /// </summary>
        /// <returns></returns>
        public bool Clear() {
            SetCount(0);
            SetIndex(0);
            return true;
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public int? Find(string network, List<NetworkModel> networks) {
            for (var i = 0; i <= networks.Count() - 1; i++) {
                if (!string.IsNullOrEmpty(networks[i].Name)) {
                    return i;
                }
            }
            return null;
        }
    }
}