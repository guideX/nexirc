using nexIRC.Enum;
using System.Collections.Generic;
namespace nexIRC.Models.Query {
    /// <summary>
    /// Query Model
    /// </summary>
    public class QueryModel {
        /// <summary>
        /// Auto Allow
        /// </summary>
        public QueryOption AutoAllow { get; set; }
        /// <summary>
        /// Auto Deny
        /// </summary>
        public QueryOption AutoDeny { get; set; }
        /// <summary>
        /// Stand By Message
        /// </summary>
        public string StandByMessage { get; set; }
        /// <summary>
        /// Decline Message
        /// </summary>
        public string DeclineMessage { get; set; }
        /// <summary>
        /// Enable Spam Filter
        /// </summary>
        public bool EnableSpamFilter { get; set; }
        /// <summary>
        /// Prompt User
        /// </summary>
        public bool PromptUser { get; set; }
        /// <summary>
        /// Auto Allow List
        /// </summary>
        public List<string> AutoAllowList { get; set; }
        /// <summary>
        /// Auto Deny List
        /// </summary>
        public List<string> AutoDenyList { get; set; }
        /// <summary>
        /// Spam Phrases
        /// </summary>
        public List<string> SpamPhrases { get; set; }
        /// <summary>
        /// Auto Show Window
        /// </summary>
        public bool AutoShowWindow { get; set; }
        /// <summary>
        /// Query Model
        /// </summary>
        public QueryModel() {
            AutoAllowList = new List<string>();
            AutoDenyList = new List<string>();
            SpamPhrases = new List<string>();
        }
    }
}