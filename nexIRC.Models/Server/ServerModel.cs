namespace nexIRC.Models.Server {
    /// <summary>
    /// Server Model
    /// </summary>
    public class ServerModel {
        /// <summary>
        /// Ip
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public long Port { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Network Index
        /// </summary>
        public int NetworkIndex { get; set; }
    }
}