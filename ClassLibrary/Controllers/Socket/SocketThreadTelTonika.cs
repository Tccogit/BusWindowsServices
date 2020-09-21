using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClassLibrary
{
    public class SocketThreadTelTonika : BaseThread
    {
        private int _LiveTimeCounter = 0;
        private BSPTCPServerTeltonika _BSPTCPServer;
        private TcpClient _TcpClient;
        public event FinishedEvent onFinished;

        public SocketThreadTelTonika(BSPTCPServerTeltonika pBSPTCPServer, TcpClient pTcpClient)
        {
            this._BSPTCPServer = pBSPTCPServer;
            this._TcpClient = pTcpClient;
        }

        public override void FinishThread()
        {
        }
        public override void RunThread()
        {
            try
            {
                this.CheckClientReceiveData(this._TcpClient);
                if (_TcpClient != null)
                    _TcpClient.Close();
            }
            catch
            {
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _BSPTCPServer = null;
            _TcpClient = null;
            GC.Collect();

        }

        private void CheckClientReceiveData(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            try
            {
                byte[] array = new byte[8192];
                while (tcpClient.Connected && this._BSPTCPServer.IsListen)
                {
                    try
                    {
                        NetworkStream stream = tcpClient.GetStream();
                        stream.ReadTimeout = 120000;
                        int num = stream.Read(array, 0, array.Length);
                        if (num <= 0)
                        {
                            this._BSPTCPServer.Disconnect(tcpClient);
                            return;
                        }
                        this._LiveTimeCounter = 0;
                        string @string = Encoding.ASCII.GetString(array, 0, num);
                        byte[] array2 = new byte[num];
                        for (int i = 0; i < num; i++)
                        {
                            array2[i] = array[i];
                        }
                        this._BSPTCPServer.ReceiveData(this, tcpClient, array2, @string);
                    }
                    catch (IOException var_7_AF)
                    {
                        this._BSPTCPServer.Disconnect(tcpClient);
                    }
                }
                if (!this._BSPTCPServer.IsListen)
                {
                    this._BSPTCPServer.Disconnect(tcpClient);
                }
            }
            catch (Exception exception)
            {
                this._BSPTCPServer.Error(this, tcpClient, exception);
            }
        }
    }
}
