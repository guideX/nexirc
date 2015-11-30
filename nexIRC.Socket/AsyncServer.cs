using System;
using System.Net;
using System.Net.Sockets;
namespace nexIRC.Sockets {
    public class AsyncServer {
        public event ConnectionAcceptEventHandler ConnectionAccept;
        public delegate void ConnectionAcceptEventHandler(AsyncSocket tmp_Socket);
        private bool _closed;
        private int _socketPort;
        public AsyncServer(int port) {
            _socketPort = port;
        }
        public void Start() {
            var listenIP = IPAddress.Any;
            var listenPort = _socketPort;
            var listenEp = new IPEndPoint(listenIP, listenPort);
            if (_closed == true) {
                _closed = false;
                return;
            }
            var obj_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            obj_Socket.Bind(listenEp);
            obj_Socket.Listen(100);
            obj_Socket.BeginAccept(new AsyncCallback(onIncomingConnection), obj_Socket);
        }
        public void Close() {
            _closed = true;
        }
        private void onIncomingConnection(IAsyncResult result) {
            var obj_Socket = (Socket)result.AsyncState;
            var obj_Connected = obj_Socket.EndAccept(result);
            if ((_closed == true)) {
                obj_Connected.Shutdown(SocketShutdown.Both);
                obj_Connected.Close();
            } else {
                if (ConnectionAccept != null) {
                    ConnectionAccept(new AsyncSocket(obj_Connected, System.Guid.NewGuid().ToString()));
                }
            }
            obj_Socket.BeginAccept(new AsyncCallback(onIncomingConnection), obj_Socket);
        }
    }
}