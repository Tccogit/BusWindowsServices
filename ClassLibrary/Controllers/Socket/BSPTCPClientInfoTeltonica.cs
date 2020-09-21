using System;
using System.Net;
using System.Net.Sockets;

namespace ClassLibrary
{
    public class BSPTCPClientInfoTeltonica
    {
        public string IP;

        public byte[] Bytes = new byte[4];

        public ushort Port;

        public BSPTCPClientInfoTeltonica(TcpClient client)
        {
            SocketAddress socketAddress = client.Client.RemoteEndPoint.Serialize();
            this.Port = (ushort)(socketAddress[2] << (int)(8 + socketAddress[3]));
            this.IP = client.Client.RemoteEndPoint.ToString();
            this.Bytes[0] = socketAddress[4];
            this.Bytes[1] = socketAddress[5];
            this.Bytes[2] = socketAddress[6];
            this.Bytes[3] = socketAddress[7];
        }

        private string IPAddressToString(IPAddress ip)
        {
            byte[] addressBytes = ip.GetAddressBytes();
            string text = "";
            for (int i = 0; i < addressBytes.Length; i++)
            {
                if (i > 0)
                {
                    text += ".";
                }
                else
                {
                    text += addressBytes[i].ToString();
                }
            }
            return text;
        }

        public static BSPTCPClientInfoTeltonica GetClientInfo(TcpClient client)
        {
            return new BSPTCPClientInfoTeltonica(client);
        }
    }
}
