using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using nexIRC.Models.Sockets;
namespace nexIRC.Business.Sockets {
    /// <summary>
    /// Async Socket
    /// </summary>
    public class AsyncSocket {
        /// <summary>
        /// Model
        /// </summary>
        public AsyncSocketModel Model { get; set; }
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        public event SocketDisconnectedEventHandler SocketDisconnected;
        /// <summary>
        /// Socket Disconnected Event Handler
        /// </summary>
        /// <param name="SocketID"></param>
        public delegate void SocketDisconnectedEventHandler(string SocketID);
        /// <summary>
        /// Socket Data Arrival
        /// </summary>
        public event SocketDataArrivalEventHandler SocketDataArrival;
        /// <summary>
        /// Socket Data Arrival Event Handler
        /// </summary>
        /// <param name="SocketID"></param>
        /// <param name="SocketData"></param>
        /// <param name="lBytes"></param>
        /// <param name="lBytesRead"></param>
        public delegate void SocketDataArrivalEventHandler(string SocketID, string SocketData, byte[] lBytes, int lBytesRead);
        /// <summary>
        /// Socket Connected
        /// </summary>
        public event SocketConnectedEventHandler SocketConnected;
        /// <summary>
        /// Socket Connected Event Handler
        /// </summary>
        /// <param name="SocketID"></param>
        public delegate void SocketConnectedEventHandler(string SocketID);
        /// <summary>
        /// Could Not Connect
        /// </summary>
        public event CouldNotConnectEventHandler CouldNotConnect;
        /// <summary>
        /// Could Not Connect Event Handler
        /// </summary>
        /// <param name="SocketID"></param>
        public delegate void CouldNotConnectEventHandler(string SocketID);
        /// <summary>
        /// Async Socket
        /// </summary>
        /// <param name="tmp_Socket"></param>
        /// <param name="tmp_SocketID"></param>
        public AsyncSocket(Socket tmp_Socket, string ID) {
            var obj = new StateObject();
            Model = new AsyncSocketModel();
            Model.SocketID = ID;
            Model.TempSocket = tmp_Socket;
            obj.WorkSocket = tmp_Socket;
            tmp_Socket.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, new AsyncCallback(onDataArrival), obj);
        }
        /// <summary>
        /// Async Socket
        /// </summary>
        public AsyncSocket() {
            Model = new AsyncSocketModel();
            Model.TempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected {
            get {
                return Model.TempSocket.Connected;
            }
        }
        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="Buffer"></param>
        public void SendBytes(byte[] Buffer) {
            var obj_StateObject = new StateObject();
            obj_StateObject.WorkSocket = Model.TempSocket;
            Model.TempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="tmp_Data"></param>
        public void Send(string tmp_Data) {
            var obj_StateObject = new StateObject();
            obj_StateObject.WorkSocket = Model.TempSocket;
            var buffer = Encoding.UTF8.GetBytes(tmp_Data);
            Model.TempSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            Model.TempSocket.Shutdown(SocketShutdown.Both);
            Model.TempSocket.Close();
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="hostIP"></param>
        /// <param name="hostPort"></param>
        public void Connect(string hostIP, Int32 hostPort) {
            try {
                IPEndPoint hostEndPoint = new IPEndPoint(Dns.Resolve(hostIP).AddressList[0], Convert.ToInt32(hostPort));
                System.Net.Sockets.Socket obj_Socket = Model.TempSocket;
                obj_Socket.BeginConnect(hostEndPoint, new AsyncCallback(onConnectionComplete), obj_Socket);
            } catch (SocketException sex) {
                var blah = "";
                if (sex.Message == "No such host is known") {
                    if (CouldNotConnect != null) {
                        CouldNotConnect(Model.SocketID);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// On Data Arrival
        /// </summary>
        /// <param name="ar"></param>
        private void onDataArrival(IAsyncResult ar) {
            try {
                StateObject obj_SocketState = (StateObject)ar.AsyncState;
                System.Net.Sockets.Socket obj_Socket = obj_SocketState.WorkSocket;
                string sck_Data = null;
                int BytesRead = obj_Socket.EndReceive(ar);
                if (BytesRead > 0) {
                    sck_Data = Encoding.UTF8.GetString(obj_SocketState.Buffer, 0, BytesRead);
                    if (SocketDataArrival != null) {
                        SocketDataArrival(Model.SocketID, sck_Data, obj_SocketState.Buffer, BytesRead);
                    }
                }
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, new AsyncCallback(onDataArrival), obj_SocketState);
            } catch (Exception ex) {
                if ((ex.Message.Contains("Cannot access a disposed object"))) {
                    if (SocketDisconnected != null) {
                        SocketDisconnected(SocketID);
                    }
                } else {
                    throw;
                }
            }
        }
        /// <summary>
        /// Return Local IP
        /// </summary>
        /// <returns></returns>
        public string ReturnLocalIp() {
            return new WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp");
        }
        /// <summary>
        /// Return Local Port
        /// </summary>
        /// <returns></returns>
        public int ReturnLocalPort() {
            return ((IPEndPoint)Model.TempSocket.LocalEndPoint).Port;
        }
        /// <summary>
        /// On Send Complete
        /// </summary>
        /// <param name="ar"></param>
        private void onSendComplete(IAsyncResult ar) {
            var obj_SocketState = (StateObject)ar.AsyncState;
            var obj_Socket = obj_SocketState.WorkSocket;
        }
        /// <summary>
        /// On Connection Complete
        /// </summary>
        /// <param name="ar"></param>
        private void onConnectionComplete(IAsyncResult ar) {
            try {
                Model.TempSocket = (System.Net.Sockets.Socket)ar.AsyncState;
                Model.TempSocket.EndConnect(ar);
                if (SocketConnected != null) {
                    SocketConnected("null");
                }
                var lTempSocket = Model.TempSocket;
                var lSocketState = new StateObject();
                lSocketState.WorkSocket = lTempSocket;
                lTempSocket.BeginReceive(lSocketState.Buffer, 0, lSocketState.BufferSize, 0, new AsyncCallback(onDataArrival), lSocketState);
            } catch (Exception ex) {
                if ((ex.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond"))) {
                    //Print(ProcessReplaceString(0,clsIrcNumerics.IrcNumeric.sCONNECTION_CLOSED
                    if (CouldNotConnect != null) {
                        CouldNotConnect(SocketID);
                    }
                } else {
                    throw;
                }
            }
        }
        /// <summary>
        /// SocketID
        /// </summary>
        public string SocketID {
            get {
                return Model.SocketID;
            }
        }
    }
}