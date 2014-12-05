// nexIRC 3.0.31
// Sunday, Oct 4th, 2014 - guideX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.RichTextBox.Model;
using System.Drawing;
namespace nexIRC.TextManipulation {
    public static class Text {
        public static string ParseData(string whole, string start, string end) {
            try {
                if (whole.Length != 0) {
                    var i = Strings.InStr(whole, start);
                    var n = Strings.InStr(whole, end);
                    var msg = Strings.Right(whole, whole.Length - i);
                    var msg2 = Strings.Right(whole, whole.Length - n);
                    if (msg2.Length < msg.Length) {
                        return Strings.Left(msg, msg.Length - msg2.Length - 1);
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
        public static string DoLeft(string data, int length) {
            try {
                return Strings.Left(data, length);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string DoRight(string data, int length) {
            try {
                return Strings.Right(data, length);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static long GetRnd(int _start, int _end) {
            try {
                VBMath.Randomize();
                var i = _start + Convert.ToInt32(VBMath.Rnd() * (_end - _start));
                return i;
            } catch (Exception ex) {
                throw ex;
            }
        }
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
        /*
        public static void Print(string data, RadRichTextBox richTextBox) {
            var ircChar = "\u0003";
            var s = default(Span);
            var mint = 0;
            var i = 0;
            var msg = "";
            var currentText = "";
            var subText1 = "";
            var subText2 = "";
            var isForeColorSet = false;
            //bool isBackColorSet = false;
            richTextBox.Document.Selection.Clear();
            richTextBox.Document.CaretPosition.MoveToLastPositionInDocument();
            if ((!string.IsNullOrEmpty(data))) {
                if (richTextBox.RichTextBoxElement.Tag == null || richTextBox.RichTextBoxElement.Tag.ToString() == "1") {
                    richTextBox.InsertLineBreak();
                } else {
                    richTextBox.RichTextBoxElement.Tag = "1";
                }
                if ((!data.Contains(ircChar))) {
                    s = new Span(data);
                    s.FontSize = 20;
                    s.ForeColor = Color.White;
                    richTextBox.InsertInline(s);
                } else {
                    s = new Span(data);
                    s.ForeColor = Color.White;
                    for (i = 0; i <= data.Length; i++) {
                        if ((!string.IsNullOrEmpty(data))) {
                            msg = data.Substring(0, 1);
                            if ((msg == ircChar)) {
                                if ((!isForeColorSet)) {
                                    if ((!string.IsNullOrEmpty(currentText))) {
                                        s.FontSize = 20;
                                        s.ForeColor = Color.White;
                                        s.Text = currentText;
                                        richTextBox.InsertInline(s);
                                        currentText = "";
                                        isForeColorSet = false;
                                        //isBackColorSet = False
                                        s = new Span();
                                    }
                                    data = data.Remove(0, 1);
                                    if ((!string.IsNullOrEmpty(data))) {
                                        if ((data.Length > 1)) {
                                            subText2 = data.Substring(0, 2);
                                        } else {
                                            subText2 = "<>";
                                        }
                                        subText1 = data.Substring(0, 1);
                                        if ((int.TryParse(subText2, out mint))) {
                                            isForeColorSet = true;
                                            data = data.Remove(0, 2);
                                            s.ForeColor = ConvertIntToSystemColor(mint, true);
                                        } else if ((int.TryParse(subText1, out mint))) {
                                            isForeColorSet = true;
                                            data = data.Remove(0, 1);
                                            s.ForeColor = ConvertIntToSystemColor(mint, true);
                                        }
                                        if ((data.Substring(0, 1) == ",")) {
                                            subText2 = data.Substring(0, 2);
                                            subText1 = data.Substring(0, 1);
                                            if ((int.TryParse(subText2, out mint))) {
                                                data = data.Remove(0, 2);
                                                //isBackColorSet = True
                                                //s.BackColor = ConvertIntToSystemColor(mint, True)
                                            } else if ((int.TryParse(subText1, out mint))) {
                                                data = data.Remove(0, 1);
                                                //isBackColorSet = True
                                                //s.BackColor = ConvertIntToSystemColor(mint, True)
                                            }
                                        }
                                    }
                                } else {
                                    if ((!string.IsNullOrEmpty(currentText))) {
                                        s.FontSize = 20;
                                        s.Text = currentText;
                                        richTextBox.InsertInline(s);
                                        currentText = "";
                                        isForeColorSet = false;
                                        //isBackColorSet = False
                                        s = new Span();
                                        s.ForeColor = Color.White;
                                    }
                                }
                            } else {
                                data = data.Remove(0, 1);
                                currentText = currentText + msg;
                            }
                        }
                    }
                    if ((!string.IsNullOrEmpty(currentText))) {
                        if ((!string.IsNullOrEmpty(currentText))) {
                            s.FontSize = 20;
                            s.Text = currentText;
                            richTextBox.InsertInline(s);
                            currentText = "";
                            var documentElements = new List<Telerik.WinControls.RichTextBox.Model.DocumentElement>();
                            foreach (var documentElement in richTextBox.Document.Sections.FirstOrDefault().Children.FirstOrDefault().Children) {
                                documentElements.Add(documentElement);
                            }
                            documentElements.Reverse();
                            i = 0;
                            foreach (var documentElement in documentElements) {
                                i = i + 1;
                                if ((i > 150)) {
                                    richTextBox.Document.Sections.FirstOrDefault().Children.FirstOrDefault().Children.Remove(documentElement);
                                }
                            }
                        }
                    }
                }
            }
            richTextBox.Document.CaretPosition.MoveToLastPositionInDocument();
        }
         */
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