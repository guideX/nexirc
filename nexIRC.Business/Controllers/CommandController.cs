using System.Linq;
using nexIRC.Business.Helpers;
using nexIRC.Enum;
using nexIRC.Models.Command;
using System.Collections.Generic;
using TeamNexgenCore.Helpers;

namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Command Controller
    /// </summary>
    public class CommandController {
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Commands
        /// </summary>
        public List<CommandModel> Commands { get; set; }
        /// <summary>
        /// Command Controller
        /// </summary>
        public CommandController(string ini, bool load = true) {
            _ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public CommandModel Find(CommandTypes type) {
            var obj = Commands.Where(c => c.CommandType == type);
            if (obj.Any()) {
                return obj.FirstOrDefault();
            } else {
                return null;
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            if (!string.IsNullOrEmpty(_ini)) {
                Commands = new List<CommandModel>();
                var c = NativeMethods.ReadINIInt(_ini, "Settings", "Count");
                for (var i = 0; i <= c - 1; i++) {
                    var command = new CommandModel();
                    command.CommandType = (CommandTypes)NativeMethods.ReadINIInt(_ini, i.ToString(), "CommandType");
                    command.Data = NativeMethods.ReadINI(_ini, i.ToString(), "Data");
                    command.Display = NativeMethods.ReadINI(_ini, i.ToString(), "Display");
                    command.Param1 = NativeMethods.ReadINI(_ini, i.ToString(), "Param1");
                    command.Param2 = NativeMethods.ReadINI(_ini, i.ToString(), "Param2");
                    command.Param3 = NativeMethods.ReadINI(_ini, i.ToString(), "Param3");
                    command.Param4 = NativeMethods.ReadINI(_ini, i.ToString(), "Param4");
                }
            }
        }
        /// <summary>
        /// Read Replaced Command
        /// </summary>
        /// <param name="type"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public CommandReturnDataModel ReadReplacedCommand(CommandTypes type, string p1 = "", string p2 = "", string p3 = "", string p4 = "") {
            var result = new CommandReturnDataModel();
            var msg = "";
            var msg2 = "";
            var cmd = Find(type);
            if (cmd != null) {
                msg = cmd.Data;
                msg2 = cmd.Display;
                msg = msg.Replace("$crlf", "");
                msg = msg.Replace("$crlf", "");
                msg = msg.Replace("$space", " ");
                msg = msg.Replace("$4sp", "    ");
                msg2 = msg2.Replace("$crlf", "");
                msg2 = msg2.Replace("$space", " ");
                msg2 = msg2.Replace("$4sp", "    ");
                if (msg.Contains("$activeservername")) {
                    //If(msg.Contains("$activeservername")) Then msg = msg.Replace("$activeservername", lStatus.Description(lStatus.ActiveIndex));
                    //If(msg2.Contains("$activeservername")) Then msg2 = msg2.Replace("$activeservername", lStatus.Description(lStatus.ActiveIndex));
                    // FUCK!
                }
                if (p1.Length != 0) {
                    msg = msg.Replace(cmd.Param1, p1);
                    msg2 = msg2.Replace(cmd.Param1, p1);
                }
                if (!string.IsNullOrEmpty(p2)) {
                    msg = msg.Replace(cmd.Param2, p2);
                    msg2 = msg2.Replace(cmd.Param2, p2);
                }
                if (!string.IsNullOrEmpty(p3)) {
                    msg = msg.Replace(cmd.Param3, p3);
                    msg2 = msg2.Replace(cmd.Param3, p3);
                }
                if (!string.IsNullOrEmpty(p4)) {
                    msg = msg.Replace(cmd.Param4, p4);
                    msg2 = msg2.Replace(cmd.Param4, p4);
                }
                result.SocketData = msg;
                result.DoColorData = msg2;
            } else {
                result.SocketData = "";
                result.DoColorData = "";
            }
            return result;
        }
    }
}