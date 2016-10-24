using System;
using System.Linq;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories.Base;
using nexIRC.Models.Server;
using System.Collections.Generic;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Recent Server Repository
    /// </summary>
    public class RecentServerRepository : Repository<ServerModel>, IRecentServerRepository {
        /// <summary>
        /// Recent Servers
        /// </summary>
        public List<ServerModel> RecentServers { get; set; }
        /// <summary>
        /// Save Recent Servers
        /// </summary>
        public void SaveRecentServers() {
            var n = 0;
            SetCount(RecentServers.Count);
            for (var i = 0; i <= RecentServers.Count - 1; i++) {
                if (RecentServers[i] != null && !string.IsNullOrEmpty(RecentServers[i].Description)) {
                    n++;
                    NativeMethods.WriteINI(Ini, n.ToString(), "Description", RecentServers[i].Description);
                    NativeMethods.WriteINI(Ini, n.ToString(), "Ip", RecentServers[i].Ip);
                    NativeMethods.WriteINI(Ini, n.ToString(), "NetworkIndex", RecentServers[i].NetworkIndex.ToString());
                    NativeMethods.WriteINI(Ini, n.ToString(), "Port", RecentServers[i].Port.ToString());
                }
            }
        }
        /// <summary>
        /// INI
        /// </summary>
        /// <param name="ini"></param>
        public RecentServerRepository(string ini, bool load = true) {
            Ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public void Load() {
            if (!string.IsNullOrEmpty(Ini)) {
                RecentServers = new List<ServerModel>();
                for (var i = 1; i <= ReadCount() - 1; i++) {
                    var obj = new ServerModel();
                    obj.Description = NativeMethods.ReadINI(Ini, i.ToString(), "Description");
                    obj.Ip = NativeMethods.ReadINI(Ini, i.ToString(), "Ip");
                    obj.NetworkIndex = NativeMethods.ReadINIInt(Ini, i.ToString(), "NetworkIndex");
                    obj.Port = NativeMethods.ReadINIInt(Ini, i.ToString(), "Port");
                    if (!string.IsNullOrEmpty(obj.Description) && !string.IsNullOrEmpty(obj.Ip)) { 
                        RecentServers.Add(obj);
                    }
                }
                if (RecentServers.Count > 2) {
                    RecentServers = RecentServers.Skip(Math.Max(0, RecentServers.Count() - 2)).Take(2).ToList();
                }
            }
        }
    }
}