using System.Linq;
using System.Collections.Generic;
using nexIRC.Business.Helpers;
using nexIRC.Enum;
using nexIRC.Models.String;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Fixed String Controller
    /// </summary>
    public class FixedStringController {
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Loaded
        /// </summary>
        private bool Loaded { get; set; }
        /// <summary>
        /// Fixed Strings
        /// </summary>
        public List<FixedStringModel> FixedStrings { get; set; }
        /// <summary>
        /// Fixed String Controller
        /// </summary>
        public FixedStringController(string ini, bool load = true) {
            _ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            if (!string.IsNullOrEmpty(_ini)) {
                Loaded = true;
                FixedStrings = new List<FixedStringModel>();
                var c = NativeMethods.ReadINIInt(_ini, "Settings", "Count");
                for (var i = 1; i <= c - 1; i++) {
                    var fs = new FixedStringModel();
                    fs.Description = NativeMethods.ReadINI(_ini, i.ToString(), "Description").Replace("$syschar", "•").Replace("$arrowchar", "»");
                    fs.Support = NativeMethods.ReadINI(_ini, i.ToString(), "Support").Replace("$syschar", "•").Replace("$arrowchar", "»");
                    fs.Syntax = NativeMethods.ReadINI(_ini, i.ToString(), "Syntax").Replace("$syschar", "•").Replace("$arrowchar", "»");
                    fs.Data = NativeMethods.ReadINI(_ini, i.ToString(), "Data").Replace("$syschar", "•").Replace("$arrowchar", "»");
                    var obj = NativeMethods.ReadINIIrcNumeric(_ini, i.ToString(), "Type");
                    if (obj != null) {
                        fs.Type = obj.Value;
                        var b = true;
                        for (var i2 = 1; i2 <= 8; i2++) {
                            if (b) {
                                var msg = NativeMethods.ReadINI(_ini, i.ToString(), "Find" + i2.ToString()).Replace("$syschar", "•").Replace("$arrowchar", "»");
                                if (string.IsNullOrEmpty(msg)) {
                                    b = false;
                                } else {
                                    fs.Find.Add(msg);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(fs.Description)) {
                            FixedStrings.Add(fs);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public bool Save() {
            var n = 0;
            if (!Loaded) Load();
            foreach (var item in FixedStrings) {
                n++;
                NativeMethods.WriteINI(_ini, n.ToString(), "Description", item.Description);
                NativeMethods.WriteINI(_ini, n.ToString(), "Data", item.Data);
                NativeMethods.WriteINI(_ini, n.ToString(), "Support", item.Support);
                NativeMethods.WriteINI(_ini, n.ToString(), "Syntax", item.Syntax);
                NativeMethods.WriteINI(_ini, n.ToString(), "Type", item.Type.ToString());
                var n2 = 0;
                foreach (var find in item.Find) {
                    if (!string.IsNullOrEmpty(find)) {
                        n2++;
                        NativeMethods.WriteINI(_ini, n.ToString(), "Find" + n2.ToString(), find);
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public FixedStringModel Find(IrcNumeric numeric) {
            if (!Loaded) Load();
            var obj = FixedStrings.Where(fs => fs.Type == numeric);
            if (obj.Any()) {
                return obj.FirstOrDefault();
            } else {
                return null;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public bool DeleteFind(int id, string parameterName) {
            var b = false;
            if (!Loaded) Load();
            if (!string.IsNullOrEmpty(parameterName)) {
                var obj = FixedStrings[id];
                if (obj != null) {
                    for (var i = 1; i <= 5; i++) {
                        if (obj.Find[i] != null) {
                            if (obj.Find[i].ToLower().Trim() == parameterName.ToLower().Trim()) {
                                obj.Find[i] = "";
                                NativeMethods.WriteINI(_ini, i.ToString(), "Find" + i.ToString(), "");
                                b = true;
                            }
                        }
                    }
                }
            }
            return b;
        }
        /// <summary>
        /// Add Find
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public bool AddFind(int id, string parameterName) {
            if (!Loaded) Load();
            var b = false;
            if (!string.IsNullOrEmpty(parameterName)) {
                var obj = FixedStrings[id];
                if (obj != null) {
                    if (obj.Find.Count < 5) {
                        obj.Find.Add(parameterName);
                        b = true;
                    }
                }
            }
            return b;
        }
        /// <summary>
        /// Set String Data
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void SetStringData(int index, string data) {
            if (!Loaded) Load();
            FixedStrings[index].Data = data;
        }
        /// <summary>
        /// Set String Description
        /// </summary>
        /// <param name="index"></param>
        /// <param name="description"></param>
        public void SetStringDescription(int index, string description) {
            if (!Loaded) Load();
            FixedStrings[index].Description = description;
        }
        /// <summary>
        /// Set String Syntax
        /// </summary>
        /// <param name="index"></param>
        /// <param name="syntax"></param>
        public void SetStringSyntax(int index, string syntax) {
            if (!Loaded) Load();
            FixedStrings[index].Syntax = syntax;
        }
        /// <summary>
        /// Set String Support
        /// </summary>
        /// <param name="index"></param>
        /// <param name="support"></param>
        public void SetStringSupport(int index, string support) {
            if (!Loaded) Load();
            FixedStrings[index].Support = support;
        }
        /// <summary>
        /// Find String Index By Description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public FixedStringModel FindStringIndexByDescription(string description) {
            if (!Loaded) Load();
            var obj = FixedStrings.Where(fs => fs.Description.ToLower().Trim() == description.ToLower().Trim());
            if (obj.Any()) {
                return obj.FirstOrDefault();
            } else {
                return null;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public bool Update(FixedStringModel model, string description = null) {
            var result = false;
            var des = "";
            if (!string.IsNullOrEmpty(description)) {
                des = description;
            } else {
                des = model.Description;
            }
            var objs = FixedStrings.Where(fs => fs.Description == des);
            if (objs.Any()) {
                var obj = objs.FirstOrDefault();
                obj.Data = model.Data;
                obj.Description = model.Description;
                obj.Support = model.Support;
                obj.Syntax = model.Syntax;
                obj.Type = model.Type;
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Read By Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public FixedStringModel ReadByType(IrcNumeric type) {
            var obj = FixedStrings.Where(fs => fs.Type == type);
            if (obj.Any()) {
                return obj.FirstOrDefault();
            } else {
                return null;
            }
        }
        /// <summary>
        /// Read Replaced String
        /// </summary>
        /// <param name="type"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        /// <param name="r5"></param>
        /// <param name="r6"></param>
        /// <param name="r7"></param>
        /// <param name="r8"></param>
        /// <returns></returns>
        public string ReadReplacedString(IrcNumeric type, string r1 = "", string r2 = "", string r3 = "", string r4 = "", string r5 = "", string r6 = "", string r7 = "", string r8 = "") {
            var obj = ReadByType(type);
            if (obj != null) {
                var msg = obj.Data;
                msg = msg.Replace("$crlf", ((char)10).ToString());
                msg = msg.Replace("$space", " ");
                msg = msg.Replace("$4sp", "    ");
                if (!string.IsNullOrEmpty(r1)) {
                    if (obj.Find.Count > 0 && r1 != null) msg = msg.Replace(obj.Find[0], r1);
                    if (obj.Find.Count > 1 && r2 != null) msg = msg.Replace(obj.Find[1], r2);
                    if (obj.Find.Count > 2 && r3 != null) msg = msg.Replace(obj.Find[2], r3);
                    if (obj.Find.Count > 3 && r4 != null) msg = msg.Replace(obj.Find[3], r4);
                    if (obj.Find.Count > 4 && r5 != null) msg = msg.Replace(obj.Find[4], r5);
                    if (obj.Find.Count > 5 && r6 != null) msg = msg.Replace(obj.Find[5], r6);
                    if (obj.Find.Count > 6 && r7 != null) msg = msg.Replace(obj.Find[6], r7);
                    if (obj.Find.Count > 7 && r8 != null) msg = msg.Replace(obj.Find[7], r8);
                    return msg;
                } else {
                    return null;
                }
            } else {
                return null;
            }
        }
        /// <summary>
        /// Get Rnd
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <returns></returns>
        //public long GetRnd(int s, int e) {
        //var l = 0;
        //VBMath.Randomize();
        //l = s + Convert.ToInt32(VBMath.Rnd() * (_end - _start));
        //return l;
        //}

        //public string DoRight(string lData, int lLength) {
        //return Right(lData, lLength).ToString;
        //}

        //public string DoLeft(string lData, int lLength) {
        //return Strings.Left(lData, lLength).ToString;
        //}

        public string LeftRight(string lString, int lLeft, int lDistance) {
            string functionReturnValue = null;
            if (lString.Length != 0) {
                functionReturnValue = lString.Substring(lLeft, lDistance);
            } else {
                functionReturnValue = "";
            }
            return functionReturnValue;
        }

    }
}