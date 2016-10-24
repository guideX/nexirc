using nexIRC.Business.Helpers;
using nexIRC.Models.Bot;
using System.Collections.Generic;
using TeamNexgenCore.Helpers;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Bot Controller
    /// </summary>
    public class BotController {
        /// <summary>
        /// Bots
        /// </summary>
        public List<BotModel> Bots { get; set; }
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini { get; set; }
        /// <summary>
        /// Bot Controller
        /// </summary>
        public BotController(string ini, bool load = true) {
            _ini = ini;
            
            if (load) Load();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            if (!string.IsNullOrEmpty(_ini)) {
                Bots = new List<BotModel>();
                var c = NativeMethods.ReadINIInt(_ini, "Settings", "Count");
                for (var i = 0; i <= c - 1; i++) {
                    var bot = new BotModel();
                    bot.Name = NativeMethods.ReadINI(_ini, i.ToString(), "Name");
                    bot.Type = NativeMethodExtras.ReadINIBotType(_ini, i.ToString(), "Type");
                }
            }
        }
    }
}