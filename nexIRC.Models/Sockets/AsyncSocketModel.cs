using System.Net.Sockets;
namespace nexIRC.Models.Sockets {
    /// <summary>
    /// Async Socket Model
    /// </summary>
    public class AsyncSocketModel {
        /// <summary>
        /// SocketID
        /// </summary>
        public string SocketID { get; set; }
        /// <summary>
        /// Temp Socket
        /// </summary>
        public Socket TempSocket { get; set; }
    }
}