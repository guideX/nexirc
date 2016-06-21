using System.Linq;
using System.Collections.Generic;
using nexIRC.Business.Helpers;
using nexIRC.Enum;
using nexIRC.Models.Compatibility;
using nexIRC.Models.String;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Compatibility Controller
    /// </summary>
    public class CompatibilityController {
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Compatibility Models
        /// </summary>
        public List<CompatibilityModel> Compatibilities { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        public CompatibilityController(string ini, bool load = true) {
            _ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            if (!string.IsNullOrEmpty(_ini)) {
                Compatibilities = new List<CompatibilityModel>();
                for (var i = 1; i <= NativeMethods.ReadINIInt(_ini, "Settings", "Count", 0); i++) {
                    var c = new CompatibilityModel();
                    c.Description = NativeMethods.ReadINI(_ini, i.ToString(), "Description", "");
                    c.Enabled = NativeMethods.ReadINIBool(_ini, i.ToString(), "Enabled", false);
                    if (!string.IsNullOrEmpty(c.Description)) {
                        Compatibilities.Add(c);
                    }
                }
            }
        }
        /// <summary>
        /// Save Compatibilities
        /// </summary>
        /// <returns></returns>
        public void Save() {
            var n = 0;
            NativeMethods.WriteINI(_ini, "Settings", "Count", Compatibilities.Count.ToString());
            for (var i = 0; i <= Compatibilities.Count - 1; i++) {
                n++;
                NativeMethods.WriteINI(_ini, n.ToString(), "Description", Compatibilities[i].Description);
                NativeMethods.WriteINI(_ini, n.ToString(), "Enabled", Compatibilities[i].Enabled.ToString());
            }
        }
        /// <summary>
        /// Is Compatible
        /// </summary>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public bool IsCompatible(IrcNumeric numeric, FixedStringModel fixedString) {
            var obj = Compatibilities.Where(c => c.Enabled && c.Description.Contains(fixedString.Support));
            var result = true;
            if (obj.Any()) {
                result = true;
            }
            return result;
        }
    }
}