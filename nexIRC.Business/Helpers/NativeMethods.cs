﻿using System.Runtime.InteropServices;
using System.Text;
namespace nexIRC.Business.Helpers {
    /// <summary>
    /// Ini File
    /// </summary>
    public static class NativeMethods {
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