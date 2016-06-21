/*
//nexIRC 3.0.31
//05-30-2016 - guideX
using System;
using System.Windows.Forms;
namespace nexIRC.Business.Sockets {
    public class StatusSocket {
        public event DataArrivalEventHandler DataArrival;
        public delegate void DataArrivalEventHandler(string data);
        private AsyncSocket withEventsField_socket;
        private AsyncSocket socket {
            get { return withEventsField_socket; }
            set {
                if (withEventsField_socket != null) {
                    withEventsField_socket.CouldNotConnect -= socket_CouldNotConnect;
                    withEventsField_socket.SocketConnected -= lSocket_socketConnected;
                    withEventsField_socket.SocketDataArrival -= lSocket_socketDataArrival;
                    withEventsField_socket.SocketDisconnected -= socket_socketDisconnected;
                }
                withEventsField_socket = value;
                if (withEventsField_socket != null) {
                    withEventsField_socket.CouldNotConnect += socket_CouldNotConnect;
                    withEventsField_socket.SocketConnected += lSocket_socketConnected;
                    withEventsField_socket.SocketDataArrival += lSocket_socketDataArrival;
                    withEventsField_socket.SocketDisconnected += socket_socketDisconnected;
                }
            }
        }
        private int statusId;
        private delegate void StringDelegate(string data);
        private delegate void IntegerDelegate(int @int);
        private delegate void DataArrivalDelegate(int id, string data);
        private delegate void DisconnectDelegate(int id, bool closeSocket);
        private Form _invoke;
        private SocketType _socketType = SocketType.Status;
        public enum SocketType {
            Status = 1,
            Ident = 2
        }
        public SocketType SetSocketType {
            set { _socketType = value; }
        }

        public AsyncSocket PassSocket {
            set {
                _invoke = invokeForm;
                socket = value;
            }
        }
        public bool Connected() {
            return socket.Connected;
        }
        public string ReturnLocalIp() {
            return socket.ReturnLocalIp();
        }
        public int ReturnLocalPort() {
            if ((Connected() == true)) {
                return socket.ReturnLocalPort();
            }
            return 0;
        }

        public void NewSocket(int id, Form form) {
            socket = new AsyncSocket();
            statusId = id;
            _invoke = new Form();
            _invoke = form;
        }

        public void SendSocket(string data) {
            if ((Connected() == true))
                socket.Send(data + Environment.NewLine);
        }

        public void CloseSocket() {
            if (Connected() == true)
                socket.Close();
        }

        public void ConnectSocket(string ip, int port) {
            if (Connected() == false)
                socket.Connect(ip, port);
        }

        public void CouldNotConnect(string data) {
            lStrings.ProcessReplaceString(statusId, IrcNumeric.sCOULD_NOT_CONNECT, lStatus.ServerDescription(statusId));
        }

        private void socket_CouldNotConnect(string SocketID) {
            StringDelegate couldNotConnectEvent = new StringDelegate(CouldNotConnect);
            _invoke.Invoke(couldNotConnectEvent, SocketID);
        }

        private void lSocket_socketConnected(string socketID) {
            try {
                IntegerDelegate connectEvent = new IntegerDelegate(lStatus.ConnectEvent);
                _invoke.Invoke(connectEvent, statusId);
            } catch (Exception ex) {
                throw;
            }
        }

        public void DataArrivalProc(int id, string data) {
            if (DataArrival != null) {
                DataArrival(data);
            }
        }

        private void lSocket_socketDataArrival(string socketID, string socketData, byte[] bytes, int lByteRead) {
            switch (_socketType) {
                case SocketType.Status:
                    DataArrivalDelegate processDataArrival = new DataArrivalDelegate(lProcessNumeric.lIrcNumericHelper.ProcessDataArrival);
                    _invoke.Invoke(processDataArrival, statusId, socketData);
                    break;
                case SocketType.Ident:
                    DataArrivalDelegate p = new DataArrivalDelegate(DataArrivalProc);
                    _invoke.Invoke(p, statusId, socketData);
                    break;
            }
        }

        private void socket_socketDisconnected(string socketId) {
            DisconnectDelegate disconnectEvent = new DisconnectDelegate(lStatus.CloseStatusConnection);
            if (Connected() == true)
                _invoke.Invoke(disconnectEvent, statusId, false);
        }
    }
}*/