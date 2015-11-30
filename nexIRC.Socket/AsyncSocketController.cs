using System;
using System.Collections;
namespace nexIRC.Sockets {
    public class AsyncSocketController {
        private SortedList _socketCol = new SortedList();
        private AsyncServer withEventsField__serverSocket;
        public event onConnectionAcceptEventHandler onConnectionAccept;
        public delegate void onConnectionAcceptEventHandler(string socketID);
        public event onSocketDisconnectedEventHandler onSocketDisconnected;
        public delegate void onSocketDisconnectedEventHandler(string socketID);
        public event onDataArrivalEventHandler onDataArrival;
        public delegate void onDataArrivalEventHandler(string socketID, string socketData, byte[] bytes, int bytesRecieved);
        private AsyncServer _serverSocket {
            get { return withEventsField__serverSocket; }
            set {
                if (withEventsField__serverSocket != null) {
                    withEventsField__serverSocket.ConnectionAccept -= m_ServerSocket_ConnectionAccept;
                }
                withEventsField__serverSocket = value;
                if (withEventsField__serverSocket != null) {
                    withEventsField__serverSocket.ConnectionAccept += m_ServerSocket_ConnectionAccept;
                }
            }
        }
        public AsyncSocketController(int tmp_Port) {
            _serverSocket = new AsyncServer(tmp_Port);
        }
        public void Start() {
            _serverSocket.Start();
        }
        public void StopServer() {
            _serverSocket.Close();
        }
        public void Send(string tmp_SocketID, string tmp_Data, bool tmp_Return = true) {
            if (tmp_Return == true) {
                ((AsyncSocket)_socketCol[tmp_SocketID]).Send(tmp_Data + Environment.NewLine);
            } else {
                ((AsyncSocket)_socketCol[tmp_SocketID]).Send(tmp_Data);
            }
        }
        public void Close(string tmp_SocketID) {
            ((AsyncSocket)_socketCol[tmp_SocketID]).Close();
        }
        public void Add(AsyncSocket tmp_Socket) {
            _socketCol.Add(tmp_Socket.SocketID, tmp_Socket);
            tmp_Socket.SocketDisconnected += SocketDisconnected;
            tmp_Socket.SocketDataArrival += SocketDataArrival;
        }
        public int Count {
            get {
                return _socketCol.Count;
            }
        }
        private void m_ServerSocket_ConnectionAccept(AsyncSocket tmp_Socket) {
            Add(tmp_Socket);
            if (onConnectionAccept != null) {
                onConnectionAccept(tmp_Socket.SocketID);
            }
        }
        private void SocketDisconnected(string socketId) {
            _socketCol.Remove(socketId);
            if (onSocketDisconnected != null) {
                onSocketDisconnected(socketId);
            }
        }
        private void SocketDataArrival(string socketId, string socketData, byte[] bytes, int bytesRecieved) {
            if (onDataArrival != null) {
                onDataArrival(socketId, socketData, bytes, bytesRecieved);
            }
        }
    }
}