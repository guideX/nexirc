using System.Net.Sockets;
namespace nexIRC.Business.Sockets {
    /// <summary>
    /// State Object
    /// </summary>
    public class StateObject {
        /// <summary>
        /// Work Socket
        /// </summary>
        public Socket WorkSocket { get; set; }
        /// <summary>
        /// Buffer Size
        /// </summary>
        public int BufferSize { get; set; }
        /// <summary>
        /// Buffer
        /// </summary>
        public byte[] Buffer { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="bufferSize"></param>
        public StateObject(int bufferSize = 32767) {
            BufferSize = bufferSize;
            Buffer = new byte[bufferSize];
        }
    }
}