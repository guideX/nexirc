using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace nexIRC.Sockets {
    public class AsyncSocket {
        public event SocketDisconnectedEventHandler SocketDisconnected;
        public delegate void SocketDisconnectedEventHandler(string SocketID);
        public event SocketDataArrivalEventHandler SocketDataArrival;
        public delegate void SocketDataArrivalEventHandler(string SocketID, string SocketData, byte[] lBytes, int lBytesRead);
        public event SocketConnectedEventHandler SocketConnected;
        public delegate void SocketConnectedEventHandler(string SocketID);
        public event CouldNotConnectEventHandler CouldNotConnect;
        public delegate void CouldNotConnectEventHandler(string SocketID);
        private string _socketId;
        private Socket _tempSocket;
        public AsyncSocket(Socket tmp_Socket, string tmp_SocketID) {
            _socketId = tmp_SocketID;
            _tempSocket = tmp_Socket;
            var obj_Socket = tmp_Socket;
            var obj_SocketState = new StateObject();
            obj_SocketState.WorkSocket = obj_Socket;
            obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, new AsyncCallback(onDataArrival), obj_SocketState);
        }
        public bool Connected {
            get {
                return (_tempSocket.Connected);
            }
        }
        public AsyncSocket() {
            _tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void SendBytes(byte[] Buffer) {
            var obj_StateObject = new StateObject();
            obj_StateObject.WorkSocket = _tempSocket;
            _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
        }
        public void Send(string tmp_Data) {
            var obj_StateObject = new StateObject();
            obj_StateObject.WorkSocket = _tempSocket;
            var Buffer = Encoding.UTF8.GetBytes(tmp_Data);
            _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
        }
        public void Close() {
            _tempSocket.Shutdown(SocketShutdown.Both);
            _tempSocket.Close();
        }
        public void Connect(string hostIP, long hostPort) {
            var hostEndPoint = new IPEndPoint(Dns.Resolve(hostIP).AddressList[0], Convert.ToInt32(hostPort));
            var obj_Socket = _tempSocket;
            obj_Socket.BeginConnect(hostEndPoint, new AsyncCallback(onConnectionComplete), obj_Socket);
        }
        private void onDataArrival(IAsyncResult ar) {
            try {
                var obj_SocketState = (StateObject)ar.AsyncState;
                var obj_Socket = obj_SocketState.WorkSocket;
                string sck_Data = null;
                int BytesRead = obj_Socket.EndReceive(ar);
                if (BytesRead > 0) {
                    sck_Data = Encoding.UTF8.GetString(obj_SocketState.Buffer, 0, BytesRead);
                    if (SocketDataArrival != null) {
                        SocketDataArrival(_socketId, sck_Data, obj_SocketState.Buffer, BytesRead);
                    }
                }
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, new AsyncCallback(onDataArrival), obj_SocketState);
            } catch (SocketException) {
                if (SocketDisconnected != null) {
                    SocketDisconnected(SocketID);
                }
            } catch (Exception ex) {
                if (SocketDisconnected != null) {
                    SocketDisconnected(SocketID);
                }
                if ((!ex.Message.Contains("Cannot access a disposed object"))) {
                    throw ex;
                }
            }
        }
        public string ReturnLocalIp() {
            return new WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp");
        }
        public long ReturnLocalPort() {
            return Convert.ToInt64(((IPEndPoint)_tempSocket.LocalEndPoint).Port);
        }
        private void onSendComplete(IAsyncResult ar) {
            var obj_SocketState = (StateObject)ar.AsyncState;
            var obj_Socket = obj_SocketState.WorkSocket;
        }
        private void onConnectionComplete(IAsyncResult ar) {
            try {
                _tempSocket = (Socket)ar.AsyncState;
                _tempSocket.EndConnect(ar);
                if (SocketConnected != null) {
                    SocketConnected("null");
                }
                var socketState = new StateObject();
                socketState.WorkSocket = _tempSocket;
                _tempSocket.BeginReceive(socketState.Buffer, 0, socketState.BufferSize, 0, new AsyncCallback(onDataArrival), socketState);
            } catch (Exception ex) {
                if ((ex.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond"))) {
                    if (CouldNotConnect != null) {
                        CouldNotConnect(SocketID);
                    }
                } else {
                    throw ex;
                }
            }
        }
        public string SocketID {
            get {
                return _socketId;
            }
        }
    }
}