using System;
using System.Linq;
using System.Collections.Generic;
using nexIRC.Enum;
using nexIRC.Models.Compatibility;
using nexIRC.Models.String;
using TeamNexgenCore.Helpers;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Compatibility Controller
    /// </summary>
    public class CompatibilityController : IDisposable {
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Compatibility Repository
        /// </summary>
        private ICompatibilityRepository _compatibilityRepository;
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
        public CompatibilityController(string ini) {
            _ini = ini;
            _compatibilityRepository = new CompatibilityRepository(ini);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(CompatibilityModel obj) {
            return _compatibilityRepository.Create(obj);
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
        /// <summary>
        /// Remove From Compatibility
        /// </summary>
        /// <returns></returns>
        public bool Delete(int ID) {
            return _compatibilityRepository.Delete(ID);
        }
        /// <summary>
        /// Find Index
        /// </summary>
        /// <returns></returns>
        //public int FindIndex() {
        //}
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            try {
                Dispose(true);
                GC.SuppressFinalize(this);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual void Dispose(bool _disposing) {
            try {
                if (_disposed) {
                    return;
                }
                if (_disposing) {
                    _compatibilityRepository = null;
                }
                _disposed = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}