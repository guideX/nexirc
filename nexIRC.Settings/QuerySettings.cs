using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nexIRC.IniFile;
namespace nexIRC.IrcSettings {
    /// <summary>
    /// Query Permission
    /// </summary>
    public enum QueryPermission {
        List = 1,
        EveryOne = 2,
        NoOne = 3
    }
    /// <summary>
    /// Query Settings Data
    /// </summary>
    public class QuerySettingsData {
        public QueryPermission AutoAllow { get; set; }
        public QueryPermission AutoDeny { get; set; }
        public string StandByMessage { get; set; }
        public string DeclineMessage { get; set; }
        public bool EnableSpamFilter { get; set; }
        public bool PromptUser { get; set; }
        public List<string> AutoAllowList { get; set; }
        public List<string> AutoDenyList { get; set; }
        public List<string> SpamPhrases { get; set; }
        public int SpamPhraseCount { get; set; }
        public int AutoAllowCount { get; set; }
        public int AutoDenyCount { get; set; }
        public bool AutoShowWindow { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        public QuerySettingsData() {
            try {
                AutoAllowList = new List<string>();
                AutoDenyList = new List<string>();
                SpamPhrases = new List<string>();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
    public class QuerySettings {
        private bool _useCached = false;
        private QuerySettingsData _cached;
        private string _iniFile;
        private string _startupPath;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="_startupPath"></param>
        public QuerySettings(string _startupPath) {
            try {
                _iniFile = _startupPath + @"data\config\query.ini";
            } catch (Exception ex) {
                throw ex;
            }
    
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public QuerySettingsData Get() {
            try {
                if (_useCached) {
                    return _cached;
                } else {
                    var data = new QuerySettingsData();
                    data.SpamPhrases = new List<string>();
                    data.AutoAllowList = new List<string>();
                    data.AutoDenyList = new List<string>();
                    int n = 0;
                    if (int.TryParse(Files.ReadINI(_iniFile, "Settings", "AutoAllow", "1"), out n)) {
                        data.AutoAllow = (QueryPermission)n;
                    }
                    if (int.TryParse(Files.ReadINI(_iniFile, "Settings", "AutoDeny", "1"), out n)) {
                        data.AutoDeny = (QueryPermission)n;
                    }
                    data.StandByMessage = Files.ReadINI(_iniFile, "Settings", "StandByMessage", "");
                    data.DeclineMessage = Files.ReadINI(_iniFile, "Settings", "DeclineMessage", "");
                    data.EnableSpamFilter = Convert.ToBoolean(Files.ReadINI(_iniFile, "Settings", "EnableSpamFilter ", "True"));
                    data.PromptUser = Convert.ToBoolean(Files.ReadINI(_iniFile, "Settings", "PromptUser", "False"));
                    data.AutoAllowCount = Convert.ToInt32(Files.ReadINI(_iniFile, "Settings", "AutoAllowCount", "0"));
                    data.AutoDenyCount = Convert.ToInt32(Files.ReadINI(_iniFile, "Settings", "AutoDenyCount", "0"));
                    data.SpamPhraseCount = Convert.ToInt32(Files.ReadINI(_iniFile, "Settings", "SpamPhraseCount", "0"));
                    data.AutoShowWindow = Convert.ToBoolean(Files.ReadINI(_iniFile, "Settings", "AutoShowWindow", "True"));
                    data.AutoAllowList = new List<string>();
                    for (var i = 1; i <= data.AutoAllowCount; i++) {
                        data.AutoAllowList.Add(Files.ReadINI(_iniFile, "AutoAllowList", i.ToString(), ""));
                    }
                    for (var i = 1; i <= data.AutoDenyCount; i++) {
                        data.AutoDenyList.Add(Files.ReadINI(_iniFile, "AutoDenyList", i.ToString(), ""));
                    }
                    for (var i = 1; i <= data.SpamPhraseCount; i++) {
                        data.SpamPhrases.Add(Files.ReadINI(_iniFile, "SpamPhrases", i.ToString(), ""));
                    }
                    _useCached = true;
                    _cached = data;
                    return data;
                }
                
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(QuerySettingsData data) {
            try {
                Files.WriteINI(_iniFile, "Settings", "AutoAllow",  ((int)data.AutoAllow).ToString());
                Files.WriteINI(_iniFile, "Settings", "AutoDeny", ((int)data.AutoDeny).ToString());
                Files.WriteINI(_iniFile, "Settings", "StandByMessage", data.StandByMessage);
                Files.WriteINI(_iniFile, "Settings", "DeclineMessage", data.DeclineMessage);
                Files.WriteINI(_iniFile, "Settings", "EnableSpamFilter", data.EnableSpamFilter.ToString());
                Files.WriteINI(_iniFile, "Settings", "PromptUser", data.PromptUser.ToString());
                Files.WriteINI(_iniFile, "Settings", "AutoAllowCount", data.AutoAllowCount.ToString());
                Files.WriteINI(_iniFile, "Settings", "AutoDenyCount", data.AutoDenyCount.ToString());
                Files.WriteINI(_iniFile, "Settings", "SpamPhraseCount", data.SpamPhraseCount.ToString());
                Files.WriteINI(_iniFile, "Settings", "AutoShowWindow", data.AutoShowWindow.ToString());
                for (var i = 1; i <= data.AutoAllowList.Count; i++) {
                    Files.WriteINI(_iniFile, "AutoAllowList", i.ToString(), data.AutoAllowList[i]);
                }
                for (var i = 1; i <= data.AutoDenyList.Count; i++) {
                    Files.WriteINI(_iniFile, "AutoDenyList", i.ToString(), data.AutoDenyList[i]);
                }
                for (var i = 1; i <= data.SpamPhrases.Count; i++) {
                    Files.WriteINI(_iniFile, "SpamPhrases", i.ToString(), data.SpamPhrases[i]);
                }
                _useCached = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}