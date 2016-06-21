using System.Collections.Generic;
using nexIRC.Business.Helpers;
using nexIRC.Models.Network;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Network Controller
    /// </summary>
    public class NetworkController {
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Index
        /// </summary>
        public int Index;
        /// <summary>
        /// Networks
        /// </summary>
        public List<NetworkModel> Networks { get; set; }
        /// <summary>
        /// Network Controller
        /// </summary>
        /// <param name="ini"></param>
        public NetworkController(string ini, bool load = true) {
            Networks = new List<NetworkModel>();
            _ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            if (!string.IsNullOrEmpty(_ini)) {
                Index = NativeMethods.ReadINIInt(_ini, "Settings", "Index", 0);
                for (var i = 1; i <= NativeMethods.ReadINIInt(_ini, "Settings", "Count", 0); i++) {
                    var n = new NetworkModel();
                    n.Name = NativeMethods.ReadINI(_ini, i.ToString(), "Name", "");
                    n.ID = i;
                    if (!string.IsNullOrEmpty(n.Name)) {
                        Networks.Add(n);
                    }
                }
            }
        }
        /// <summary>
        /// Save Networks
        /// </summary>
        public void Save() {
            var n = 0;
            NativeMethods.WriteINI(_ini, "Settings", "Count", Networks.Count.ToString());
            for (var i = 0; i <= Networks.Count - 1; i++) {
                n++;
                NativeMethods.WriteINI(_ini, n.ToString(), "Name", Networks[i].Name);
            }
        }
    }
}