using System.Collections.Generic;
namespace nexIRC.Models.Network {
    /// <summary>
    /// Networks Model
    /// </summary>
    public class NetworksModel {
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Networks
        /// </summary>
        public List<NetworkModel> Networks { get; set; }
        /// <summary>
        /// Networks Model
        /// </summary>
        public NetworksModel() {
            Networks = new List<NetworkModel>();
        }
    }
}