using System;
using System.Net;
using System.Net.Sockets;
using nexIRC.Models.Sockets;
namespace nexIRC.Business.Sockets {
    /// <summary>
    /// Async Server
    /// </summary>
    public class AsyncServer {
        /// <summary>
        /// Connection Accept
        /// </summary>
        public event ConnectionAcceptEventHandler ConnectionAccept;
        /// <summary>
        /// Connection Accept Event Handler
        /// </summary>
        /// <param name="tmp_Socket"></param>
        public delegate void ConnectionAcceptEventHandler(AsyncSocket tmp_Socket);
        /// <summary>
        /// Model
        /// </summary>
        public AsyncServerModel Model { get; set; }
        /// <summary>
        /// Async Server
        /// </summary>
        /// <param name="lPort"></param>
        public AsyncServer(int port) {
            Model = new AsyncServerModel();
            Model.Port = port;
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            var listenIP = IPAddress.Any;
            var listenEp = new IPEndPoint(listenIP, Model.Port);
            if (Model.Closed) {
                Model.Closed = false;
                return;
            }
            var obj = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            obj.Bind(listenEp);
            obj.Listen(100);
            obj.BeginAccept(new AsyncCallback(onIncomingConnection), obj);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            Model.Closed = true;
        }
        /// <summary>
        /// On Incoming Connection
        /// </summary>
        /// <param name="result"></param>
        private void onIncomingConnection(IAsyncResult result) {
            var obj = (System.Net.Sockets.Socket)result.AsyncState;
            var connected = obj.EndAccept(result);
            if (Model.Closed) {
                connected.Shutdown(SocketShutdown.Both);
                obj.Close();
            } else {
                if (ConnectionAccept != null) {
                    ConnectionAccept(new AsyncSocket(connected, System.Guid.NewGuid().ToString()));
                }
            }
            obj.BeginAccept(new AsyncCallback(onIncomingConnection), obj);
        }
    }
}