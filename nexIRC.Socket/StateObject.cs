using System.Net.Sockets;
namespace nexIRC.Sockets {
    public class StateObject {
        public Socket WorkSocket = null;
        public int BufferSize = 32767;
        public byte[] Buffer = new byte[32768];
    }
}