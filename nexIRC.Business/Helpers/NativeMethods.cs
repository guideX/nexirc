using nexIRC.Enum;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.RichTextBox;
namespace nexIRC.Business.Helpers {
    /// <summary>
    /// Ini File
    /// </summary>
    public static class NativeMethods {
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);
        public static void Animate(Control ctl, AnimateWindowFlags effect, int time, int angle) {
            if (ctl.Visible) {
                angle += 180;
            } else {
                if (ctl.TopLevelControl == ctl) {
                    effect = AnimateWindowFlags.AW_ACTIVATE;
                } else {
                    throw new ArgumentException();
                }
            }
            var obj = AnimateWindow(ctl.Handle, time, effect);
            if (!obj) {
                throw new Exception("Animation failed");
            }
            ctl.Visible = !ctl.Visible;
        }
        /// <summary>
        /// WM_VSCROLL
        /// </summary>
        private const int WM_VSCROLL = 227;
        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Scroll to Bottom
        /// </summary>
        /// <param name="rtb"></param>
        public static void ScrollToBottom(RichTextBox rtb) {
            SendMessage(rtb.Handle, WM_VSCROLL, (IntPtr)7, IntPtr.Zero);
        }
        /// <summary>
        /// Scroll to Bottom
        /// </summary>
        /// <param name="rtb"></param>
        public static void ScrollToBottom(RadRichTextBox rtb) {
            SendMessage(rtb.Handle, WM_VSCROLL, (IntPtr)7, IntPtr.Zero);
        }
        /// <summary>
        /// Reading of INI Files
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Default"></param>
        /// <param name="RetVal"></param>
        /// <param name="Size"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        public static string ReadINI(string file, string section, string key, string _default = "") {
            var msg = new StringBuilder(500);
            if (GetPrivateProfileString(section, key, "", msg, msg.Capacity, file) == 0) {
                return _default;
            } else {
                return msg.ToString().Trim();
            }
        }
        /// <summary>
        /// Writing of INI Files
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void WriteINI(string file, string section, string key, string value) {
            WritePrivateProfileString(section, key, value, file);
        }
        /// <summary>
        /// Read Ini Float
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static float ReadINIFloat(string file, string section, string key, float def = 0.0f) {
            float ff;
            if (float.TryParse(ReadINI(file, section, key, def.ToString()), out ff)) {
                return ff;
            } else {
                return 0f;
            }
            //return float.Parse(ReadINI(file, section, key, def.ToString()), CultureInfo.InvariantCulture.NumberFormat);
        }
        public static IrcNumeric? ReadINIIrcNumeric(string file, string section, string key, IrcNumeric _default = IrcNumeric.sCUSTOM) {
            IrcNumeric n; 
            int nn;
            if (int.TryParse(ReadINI(file, section, key, _default.ToString()), out nn)) {
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
        /// <summary>
        /// Read Ini Int
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ReadINIInt(string file, string section, string key, int def = 0) {
            int n;
            if (int.TryParse(ReadINI(file, section, key, def.ToString()), out n)) {
                return n;
            } else {
                return 0;
            }
        }
        /// <summary>
        /// Read INI Decimal
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static decimal ReadINIDecimal(string file, string section, string key, decimal def = decimal.Zero) {
            decimal d;
            if (decimal.TryParse(ReadINI(file, section, key, def.ToString()), out d)) {
                return d;
            } else {
                return decimal.Zero;
            }
        }
        /// <summary>
        /// Read INI Bool
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static bool ReadINIBool(string file, string section, string key, bool def = false) {
            bool b;
            if (bool.TryParse(ReadINI(file, section, key, def.ToString()), out b)) {
                return b;
            } else {
                return false;
            }
        }
        /// <summary>
        /// Read Ini Double
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static double ReadIniDouble(string file, string section, string key, double def = 0.0) {
            var msg = ReadINI(file, section, key, def.ToString());
            double result;
            double.TryParse(msg, out result);
            return result;
        }
        /// <summary>
        /// Read From Ini Float
        /// </summary>
        /// <param name="file"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static float ReadIniFloat(string file, string section, string key, float def = 0.0f) {
            var msg = ReadINI(file, section, key, def.ToString());
            float result;
            float.TryParse(msg, out result);
            return result;
        }
    }
}