using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ClassLibrary
{
    public class BSPTCPServerTeltonika : Component
    {
        public delegate void OnReceiveDataHandler(object sender, TcpClient client, byte[] bytes, string data);

        public delegate void OnClientConnectHandler(object sender, TcpClient client);

        public delegate void OnClientDisconnectHandler(object sender, TcpClient client);

        public delegate void OnErrorHandler(object sender, TcpClient client, Exception exception);

        private TcpListener _listener = null;

        public int SleepTime = 10;

        private int _LiveTime = 0;

        public List<TcpClient> Clients = new List<TcpClient>();

        private ushort port;

        private bool _isListen = false;

        public event BSPTCPServerTeltonika.OnReceiveDataHandler OnReceiveData;

        public event BSPTCPServerTeltonika.OnClientConnectHandler OnClientConnect;

        public event BSPTCPServerTeltonika.OnClientDisconnectHandler OnClientDisconnect;

        public event BSPTCPServerTeltonika.OnErrorHandler OnError;

        public int LiveTime
        {
            get
            {
                return this._LiveTime;
            }
            set
            {
                this._LiveTime = value;
            }
        }

        public ushort Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        public bool IsListen
        {
            get
            {
                return this._isListen;
            }
            set
            {
                if (value && !this._isListen)
                {
                    this.Listen();
                }
                else if (!value)
                {
                    this.DisconnectAll();
                }
                this._isListen = value;
            }
        }

        public void Listen()
        {
            try
            {
                if (this._listener != null)
                {
                    this._listener.Stop();
                    this._listener = null;
                    this.DisconnectAllClient();
                }
                this._listener = new TcpListener((int)this.port);
                this._listener.ExclusiveAddressUse = false;
                this._listener.Start();
                this._isListen = true;
                new Thread(new ParameterizedThreadStart(this.CheckForConnect))
                {
                    IsBackground = true
                }.Start(this._listener);
            }
            catch (Exception var_1_8D)
            {
                this._isListen = false;
                throw new IOException();
            }
        }

        private void CheckForConnect(object obj)
        {
            TcpListener tcpListener = (TcpListener)obj;
            while (this._isListen)
            {
                try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    if (tcpClient != null)
                    {
                        this.Connect(tcpClient, tcpListener, null);
                    }
                }
                catch (SocketException var_2_2A)
                {
                    break;
                }
            }
        }

        private void Connect(TcpClient client, TcpListener listener, IAsyncResult pAR)
        {
            bool flag = false;
            if (pAR != null)
            {
                client = listener.EndAcceptTcpClient(pAR);
            }
            if (!flag)
            {
                this.Clients.Add(client);
            }
            if (this.OnClientConnect != null)
            {
                this.OnClientConnect(this, client);
            }
            if (pAR != null)
            {
                listener.BeginAcceptTcpClient(new AsyncCallback(this.ConnectCallBack), listener);
            }
            SocketThreadTelTonika socketThread = new SocketThreadTelTonika(this, client);
            socketThread.Start();
        }

        public void ReceiveData(object sender, TcpClient client, byte[] bytes, string data)
        {
            if (this.OnReceiveData != null)
            {
                this.OnReceiveData(sender, client, bytes, data);
            }
        }

        public void Error(object sender, TcpClient client, Exception exception)
        {
            if (this.OnError != null)
            {
                this.OnError(this, client, exception);
            }
        }

        private void DisconnectAllClient()
        {
            while (this.Clients.Count > 0)
            {
                this.Disconnect(this.Clients[0]);
            }
        }

        public void DisconnectAll()
        {
            if (this._listener != null)
            {
                this._listener.Stop();
                this._listener = null;
                this._isListen = false;
            }
            this.DisconnectAllClient();
        }

        public void Disconnect(TcpClient client)
        {
            this.Disconnect(client, true);
        }

        public void Disconnect(TcpClient client, bool pRemove)
        {
            if (client != null)
            {
                try
                {
                    BSPTCPClientInfoTeltonica bSPTCPClientInfo = new BSPTCPClientInfoTeltonica(client);
                    if (this.OnClientDisconnect != null)
                    {
                        this.OnClientDisconnect(this, client);
                    }
                    client.Close();
                    this.Clients.Remove(client);
                }
                catch (Exception var_1_44)
                {
                    if (pRemove)
                    {
                        this.Clients.Remove(client);
                        client = null;
                    }
                }
            }
        }

        public void Listen(ushort pPort)
        {
            this.Port = pPort;
            this.Listen();
        }

        public static BSPTCPClientInfoTeltonica GetClientInfo(TcpClient client)
        {
            return new BSPTCPClientInfoTeltonica(client);
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            TcpListener tcpListener = (TcpListener)ar.AsyncState;
            TcpClient client = tcpListener.EndAcceptTcpClient(ar);
            this.Connect(client, tcpListener, ar);
        }

        private void DiconnectCallBack(IAsyncResult ar)
        {
            TcpClient client = (TcpClient)ar.AsyncState;
            this.Disconnect(client);
        }

        public void SendData(TcpClient client, string data)
        {
            if (this._listener != null && this._isListen)
            {
                client.Client.Send(BSPTCPClient.StringToBytes(data));
            }
        }

        public void SendData(TcpClient client, byte[] data)
        {
            if (this._listener != null && this._isListen)
            {
                client.Client.Send(data);
            }
        }

        public void BroadcastData(byte[] data)
        {
            if (this._listener != null && this._isListen)
            {
                foreach (TcpClient current in this.Clients)
                {
                    current.Client.Send(data);
                }
            }
        }

        public void BroadcastData(string data)
        {
            if (this._isListen)
            {
                foreach (TcpClient current in this.Clients)
                {
                    current.Client.Send(BSPTCPClient.StringToBytes(data));
                }
            }
        }

        public bool SocketConnected(TcpClient s)
        {
            bool flag = s.Client.Poll(1000, SelectMode.SelectRead);
            bool flag2 = s.Client.Available == 0;
            return !flag || !flag2;
        }
    }
}
