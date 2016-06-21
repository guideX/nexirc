namespace nexIRC.Models.Mode {
    /// <summary>
    /// Mode Model
    /// </summary>
    public class ModeModel {
        /// <summary>
        /// Invisible
        /// </summary>
        public bool Invisible { get; set; }
        /// <summary>
        /// Wallops
        /// </summary>
        public bool Wallops { get; set; }
        /// <summary>
        /// Restricted
        /// </summary>
        public bool Restricted { get; set; }
        /// <summary>
        /// Operator
        /// </summary>
        public bool Operator { get; set; }
        /// <summary>
        /// Local Operator
        /// </summary>
        public bool LocalOperator { get; set; }
        /// <summary>
        /// Server Notices
        /// </summary>
        public bool ServerNotices { get; set; }
    }
}