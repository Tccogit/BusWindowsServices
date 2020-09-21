using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.ComponentModel;
using System.IO;
using ClassLibrary;

namespace ClassLibrary
{


    public class BSPTCPServer : Component
    {
        public delegate void OnReceiveDataHandler(object sender, System.Net.Sockets.Socket client, byte[] bytes);
        public delegate void OnClientConnectHandler(object sender, System.Net.Sockets.Socket client);
        public delegate void OnClientDisconnectHandler(object sender, System.Net.Sockets.Socket client);
        public delegate void OnErrorHandler(object sender, System.Net.Sockets.Socket client, Exception exception);

        public event OnReceiveDataHandler OnReceiveData;
        public event OnClientConnectHandler OnClientConnect;
        public event OnClientDisconnectHandler OnClientDisconnect;
        public event OnErrorHandler OnError;

        private System.Net.Sockets.Socket _listener = null;
        public int SleepTime = 10;


        private ushort port;
        public ushort Port
        {
            get { return port; }
            set { port = value; }
        }

		public BSPTCPServer()
		{
		}

        private volatile bool _isListen = false;
        public bool IsListen
        {
            get
            {
                return _isListen;
            }
            set
            {
                if (value && !_isListen)
                {
                    Listen();
                }
                else if (!value)
                {
                    _listener.Close();
                    _listener = null;
                    DisconnectAll();

                }
                _isListen = value;
            }
        }

        public void Listen()
        {
            try
            {
                if (_listener == null)
                {
                }
                else
                {
                }
                IPEndPoint Ip = new IPEndPoint(IPAddress.Any,port);
                _listener = new System.Net.Sockets.Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                _listener.Bind(Ip);

                _isListen = true;

                Thread thread = new Thread(new ParameterizedThreadStart(CheckForConnect));
                thread.Priority = ThreadPriority.Highest;
                thread.Start(_listener);
            }
            catch (Exception ex)
            {
                _isListen = false;
                throw new IOException();

            }
        }

        private void CheckForConnect(object obj)
        {
            System.Net.Sockets.Socket listener = (System.Net.Sockets.Socket)obj;
            listener.Listen(10000);
            while (_isListen)
            {
                try
                {
                    System.Net.Sockets.Socket client = listener.Accept();

                    if (client != null)
                    {
                        Connect(client, listener);
                    }
                }
                catch (System.Net.Sockets.SocketException se)
                {
                    JSystem.Except.AddException(se);
                }
            }
            try
            {
                listener.Close();
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Connect(System.Net.Sockets.Socket client, System.Net.Sockets.Socket listener)
        {
            try
            {
                if (OnClientConnect != null)
                    OnClientConnect(this, client);

                SocketThread _SocketThread = new SocketThread(this, client);
                _SocketThread.Start();
                _SocketThread.onFinished += new FinishedEvent(this._SocketThread_onFinished);
            }
            catch
            {

            }
        }

        void _SocketThread_onFinished(object source, BSPTCPServer pBSPTCPServer, System.Net.Sockets.Socket pTcpClient)
        {
            (source as SocketThread).Dispose();
            source = null;
            GC.Collect();
        }

        public void ReceiveData(object sender, System.Net.Sockets.Socket client, byte[] bytes)
		{
			if (OnReceiveData != null)
				OnReceiveData(sender, client, bytes);
		}

        public void Error(object sender, System.Net.Sockets.Socket client, Exception exception)
		{
			if (OnError != null)
				OnError(this, client, exception);
		}
        private void DisconnectAllClient()
        {
        }

        public void DisconnectAll()
        {
            if (_listener != null)
            {
                _listener.Close();
                _listener = null;
                _isListen = false;
            }
            DisconnectAllClient();
        }

        public void Disconnect(System.Net.Sockets.Socket client)
        {
            Disconnect(client, true);
        }

        public void Disconnect(System.Net.Sockets.Socket client, bool pRemove)
        {
            if (client != null)
            {
				try
				{
                    

                    client.Shutdown(SocketShutdown.Both);
                    client.Disconnect(true);
					client.Close();
                    
                    if (OnClientDisconnect != null)
                        OnClientDisconnect(this, client);
                    
                    client = null;

                }
				catch (Exception ex)
				{
					if (pRemove)
					{
                        client = null;
					}
				}
            }
        }

        public void Listen(ushort pPort)
        {
            Port = pPort;
            Listen();
        }


        public static BSPTCPClientInfo GetClientInfo(System.Net.Sockets.Socket client)
        {
            return new BSPTCPClientInfo(client);
        }

        private void ConnectCallBack(IAsyncResult ar)
        {


        }

        private void DiconnectCallBack(IAsyncResult ar)
        {
            System.Net.Sockets.Socket client = (System.Net.Sockets.Socket)ar.AsyncState;
            Disconnect(client);
        }


        public bool SendData(System.Net.Sockets.Socket client, string data)
        {
            if (_listener != null && _isListen)
            {
                byte[] B = BSPTCPClient.StringToBytes(data);
                int i = client.Send(B);
                return i == B.Length;
            }
            return false;
        }

        public bool SendData(System.Net.Sockets.Socket client, byte[] data)
        {
            int SendLen = 0;
            if (_listener != null && _isListen)
                SendLen = client.Send(data);
            return SendLen == data.Length;
        }

        public void BroadcastData(byte[] data)
        {
        }

        public void BroadcastData(string data)
        {
        }

		public bool SocketConnected(TcpClient s)
		{
			bool part1 = s.Client.Poll(1000, SelectMode.SelectRead);
			bool part2 = (s.Client.Available == 0);
			if (part1 && part2)
				return false;
			else
				return true;
		}

    }

    public class BSPTCPClientInfo
    {
        public BSPTCPClientInfo(System.Net.Sockets.Socket client)
        {
            try
            {
                SocketAddress sa = client.RemoteEndPoint.Serialize();
                Port = (ushort)(sa[2] << 8 + sa[3]);
                //IP = sa[4].ToString() + "." + sa[5].ToString() + "." + sa[6].ToString() + "." + sa[7].ToString();
                IP = client.RemoteEndPoint.ToString().Split(':')[0];
                Bytes[0] = sa[4];
                Bytes[1] = sa[5];
                Bytes[2] = sa[6];
                Bytes[3] = sa[7];
            }catch
            {
                IP = "";
                Port = 0;
            }
        }
        public string IP;
        public byte[] Bytes = new byte[4];
        public ushort Port;

        private string IPAddressToString(IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();
            string host = "";
            for (int i = 0; i < bytes.Length; i++)
                if (i > 0)
                    host += ".";
                else
                    host += bytes[i].ToString();
            return host;
        }
        public static BSPTCPClientInfo GetClientInfo(System.Net.Sockets.Socket client)
        {
            return new BSPTCPClientInfo(client);
        }

    }
  

}
