using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.ComponentModel;
using System.IO;


namespace ClassLibrary
{

    public class BSPTCPClient : Component
    {
        public delegate void OnConnectHandler(object sender);
        public delegate void OnDisconnectHandler(object sender);
        public delegate void OnReceiveDataHandler(object sender, byte[] bytes, string data);
        public delegate void OnErrorHandler(object sender, Exception exception);
        public event OnConnectHandler OnConnect;
        public event OnDisconnectHandler OnDisconnect;
        public event OnReceiveDataHandler OnReceiveData;
        public event OnErrorHandler OnError;
        private bool isConnect = false;
        public bool IsConnect { get { return isConnect; } }

        public BSPTCPClient()
        {
            //client = new TcpClient();
        }

        private TcpClient client;
        private void OnServerConnect(IAsyncResult ar)
        {
            try
            {
                client.Client.EndConnect(ar);
                isConnect = true;
                if (OnConnect != null)
                    OnConnect(this);
                Thread thread = new Thread(new ParameterizedThreadStart(CheckForReceiveData));
                thread.IsBackground = true;
                thread.Start(client);
            }
            catch (SocketException socketEx)
            {
                if (OnError != null)
                    OnError(this, socketEx);
                //Disconnect();
                //if (OnDisconnect != null)
                  //  OnDisconnect(this);

            }
        }
        private string _serverIP="";
        public string ServerIP
        {
            get
            {
                return _serverIP;
            }
        }
        private ushort _port=0;
        public ushort Port
        {
            get
            {
                return _port;
            }
        }
        public bool Connect(string serverIP, ushort port)
        {
            try
            {
                _serverIP = serverIP;
                _port = port;
                client = new TcpClient();
                client.Client.BeginConnect(serverIP, port, new AsyncCallback(OnServerConnect), client);
                //client.Connect(serverIP, port);
                //OnServerConnect(null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CheckForReceiveData(object tc)
        {
            try
            {
                Byte[] bytes = new Byte[8192];
                NetworkStream stream = client.GetStream();
                while (client.Connected)
                {
                    try
                    {
                        //if (stream.DataAvailable)
                        {
                            int i = stream.Read(bytes, 0, bytes.Length);
                            //int i= client.Client.Receive(bytes);
                            if (i == 0)
                                break;
                            // Translate data bytes to a ASCII string.
                            string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            byte[] msg = new byte[i];
                            for (int j = 0; j < i; j++)
                                msg[j] = bytes[j];
                            if (OnReceiveData != null)
                                OnReceiveData(this, msg, data);
                        }
                    }

                    catch (IOException exception)
                    {
                        break;
                    }
                }
                if(isConnect)
                    Disconnect();
                //if (OnDisconnect != null)
                //    OnDisconnect(this);
                //client = null;
                //isConnect = false;
            }
            catch (Exception exception)
            {
                if (OnError != null)
                    OnError(this, exception);
            }
        }
        private void OnServerDisconect(IAsyncResult ar)
        {
            client.Client.EndDisconnect(ar);
            client = null;
            //client.Client.Disconnect(false);
            if (OnDisconnect != null)
                OnDisconnect(this);
        }
        public bool Disconnect()
        {
            if (client == null)
                return false;
            isConnect = false;
            client.Client.BeginDisconnect(false, new AsyncCallback(OnServerDisconect), client);
            return true;
        }
        public Boolean SendData(string data)
        {
            if (client == null)
                return false;
            if (client != null && isConnect)
            {
              int Code=client.Client.Send(StringToBytes(data));
              if (Code > 0) return true;
              else return false;
               
            }
            else return false;
        }

        public static byte[] StringToBytes(string str)
        {
            byte[] bytes = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                bytes[i] = (byte)str[i];
            }
            return bytes;
        }

        public void SendData(byte[] data)
        {
            if (client == null)
                return;
            if (client != null && isConnect)
                client.Client.Send(data);
        }
    }
}
