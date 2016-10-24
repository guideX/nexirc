namespace nexIRC.Models.Base {
    /// <summary>
    /// All Bots
    /// </summary>
    public abstract class AllBotModel {
        /// <summary>
        /// Status Index
        /// </summary>
        public virtual int StatusIndex { get; set; }
        /// <summary>
        /// Network Index
        /// </summary>
        public virtual int NetworkIndex { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }
    }
}