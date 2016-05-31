using System.Collections.Generic;
namespace nexIRC.Models.Server {
    /// <summary>
    /// Servers Model
    /// </summary>
    public class ServersModel {
        /// <summary>
        /// Modified
        /// </summary>
        public bool Modified { get; set; }
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Servers
        /// </summary>
        public List<ServerModel> Servers { get; set; }
        /// <summary>
        /// Servers Model
        /// </summary>
        public ServersModel() {
            Servers = new List<ServerModel>();
        }
    }
}