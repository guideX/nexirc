// nexIRC 3.0.31
// Sunday, Oct 4th, 2014 - guideX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.RichTextBox.Model;
using System.Drawing;
using Microsoft.VisualBasic;
namespace nexIRC.TextManipulation {
    public static class Text {
        /// <summary>
        /// Parse Data
        /// </summary>
        /// <param name="whole"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ParseData(string whole, string start, string end) {
            try {
                if (whole.Length != 0) {
                    var i = Strings.InStr(whole, start);
                    var n = Strings.InStr(whole, end);
                    var msg = Strings.Right(whole, whole.Length - i);
                    var msg2 = Strings.Right(whole, whole.Length - n);
                    if (msg2.Length < msg.Length) {
                        return TextManipulation.Text.DoLeft(msg, msg.Length - msg2.Length - 1);
                    } else {
                        return "";
                    }
                } else {
                    return "";
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Left Right
        /// </summary>
        /// <param name="str"></param>
        /// <param name="left"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static string LeftRight(string str, int left, int distance) {
            try {
                if (str.Length != 0) {
                    return str.Substring(left, distance);
                } else {
                    return "";
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Do Left
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DoLeft(string data, int length) {
            try {
                return Strings.Left(data, length);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Do Right
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DoRight(string data, int length) {
            try {
                return Strings.Right(data, length);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Rnd
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <returns></returns>
        public static long GetRnd(int _start, int _end) {
            try {
                Random random = new Random();
                return random.Next(_start, _end);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Encode IP Address
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeIPAddr(string data) {
            try {
                var msg4 = 1;
                var msg = "";
                do {
                    var msg2 = Strings.InStr(msg4, data + ".", ".");
                    var msg3 = Conversion.Hex(Conversion.Val(Strings.Mid(data + ".", msg4, msg2 - msg4)));
                    msg = (msg3.Length == 1 ? "0" + msg3 : msg3);
                    msg4 = msg2 + 1;
                } while (!(msg4 >= (data + ".").Length));
                var msg5 = Conversion.Val("&H" + Strings.Mid(msg, 1, 2)) * 256f + Conversion.Val("&H" + Strings.Mid(msg, 3, 2));
                var i = Conversion.Val("&H" + Strings.Mid(msg, 5, 2)) * 256f + Conversion.Val("&H" + Strings.Mid(msg, 7, 2));
                var msg6 = Conversion.Str(msg5 * 65536 + i);
                return Strings.Trim(msg6);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Convert Int to System Color
        /// </summary>
        /// <param name="lColor"></param>
        /// <param name="lBlackSetting"></param>
        /// <returns></returns>
        public static System.Drawing.Color ConvertIntToSystemColor(int lColor, bool lBlackSetting = false) {
            var value = default(System.Drawing.Color);
            try {
                switch (lColor) {
                    case 0:
                        if (lBlackSetting == true) {
                            value = Color.White;
                        } else {
                            value = Color.Black;
                        }
                        break;
                    case 1:
                        if (lBlackSetting == true) {
                            value = Color.White;
                        } else {
                            value = Color.Black;
                        }
                        break;
                    case 2:
                        value = Color.DarkBlue;
                        break;
                    case 3:
                        value = Color.Coral;
                        break;
                    case 4:
                        value = Color.Red;
                        break;
                    case 5:
                        value = Color.DarkRed;
                        break;
                    case 6:
                        value = Color.Purple;
                        break;
                    case 7:
                        value = Color.Orange;
                        break;
                    case 8:
                        value = Color.Yellow;
                        break;
                    case 9:
                        value = Color.LightGreen;
                        break;
                    case 10:
                        value = Color.Turquoise;
                        break;
                    case 11:
                        value = Color.Aquamarine;
                        break;
                    case 12:
                        value = Color.Blue;
                        break;
                    case 13:
                        value = Color.Pink;
                        break;
                    case 14:
                        value = Color.Cyan;
                        break;
                    case 15:
                        value = Color.Gray;
                        break;
                    case 16:
                        if (lBlackSetting == true) {
                            value = Color.Black;
                        } else {
                            value = Color.White;
                        }
                        break;
                }
                return value;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Strip Color Codes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string StripColorCodes(string data) {
            try {
                var i = 0;
                var n = 0;
                for (i = 0; i <= 15; i++) {
                    for (n = 0; n <= 15; n++) {
                        var msg2 = "\u0003" + i.ToString().Trim() + "," + n.ToString().Trim();
                        if (Strings.InStr(msg2, data) != 0) {
                            data = data.Replace(msg2, "");
                        }
                    }
                    var msg = "\u0003" + i.ToString().Trim();
                    if (Strings.InStr(msg, data) != 0) {
                        data = Strings.Replace(data, msg, "");
                    }
                }
                return data;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}