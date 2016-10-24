using nexIRC.Enum;
using TeamNexgenCore.Helpers;
namespace nexIRC.Business.Helpers {
    /// <summary>
    /// Native Method Extras
    /// </summary>
    public static class NativeMethodExtras {
        /// <summary>
        /// Read Ini Bot Type
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static BotTypes ReadINIBotType(string file, string section, string key, BotTypes def = BotTypes.NotSet) {
            BotTypes ff;
            if (BotTypes.TryParse(NativeMethods.ReadINI(file, section, key, def.ToString()), out ff)) {
                return ff;
            } else {
                return 0f;
            }
        }
        /// <summary>
        /// Read Irc Numeric
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static IrcNumeric? ReadINIIrcNumeric(string file, string section, string key, IrcNumeric _default = IrcNumeric.sCUSTOM) {
            IrcNumeric n;
            int nn;
            if (int.TryParse(NativeMethods.ReadINI(file, section, key, _default.ToString()), out nn)) {
                try {
                    n = (IrcNumeric)nn;
                    return n;
                } catch {
                    return null;
                }
            } else {
                return IrcNumeric.sCUSTOM;
            }
        }
    }
}