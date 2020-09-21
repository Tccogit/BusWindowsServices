using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ClassLibrary
{

    public abstract class BaseThread : IDisposable
    {
        private Thread _thread;
        protected BaseThread()
        {
            ThreadStart starter = this.RunThread;
            starter += () => {
                this.FinishThread();
            };
            _thread = new Thread(starter);
            _thread.Priority = ThreadPriority.Normal;
        }

        public void Start()
        {
            _thread.Start();
        }
        public void Join()
        {
            try
            {
                _thread.Join(5000);
            }
            catch
            {
            }
            finally
            {
            }
            try
            {
                //_thread.Abort();
            }
            catch
            {
            }
            finally
            {
            }
            _thread = null;
        }

        public bool IsAlive { get { return _thread.IsAlive; } }

        // Override in base class
        public abstract void RunThread();
        public abstract void FinishThread();

        public virtual void Dispose()
        {
            try
            {
                Join();
            }
            catch(Exception ex)
            {

            }
            try
            {
                
            }
            catch
            {

            }
        }

    }

    public delegate void FinishedEvent(object source, BSPTCPServer pBSPTCPServer, System.Net.Sockets.Socket pTcpClient);


    public class SocketThread : BaseThread
    {

        private int _LiveTimeCounter = 0;

        private BSPTCPServer _BSPTCPServer;
        private System.Net.Sockets.Socket _TcpClient;

        public event FinishedEvent onFinished;

        public SocketThread(BSPTCPServer pBSPTCPServer, System.Net.Sockets.Socket pTcpClient)
        {
            _BSPTCPServer = pBSPTCPServer;
            _TcpClient = pTcpClient;
        }

        public override void FinishThread()
        {
            onFinished(this, _BSPTCPServer, _TcpClient);
        }

        public override void RunThread()
        {
            try
            {
                CheckClientReceiveData(_TcpClient);
                try
                {
                    if (_TcpClient != null)
                        _TcpClient.Close();
                }
                catch
                {

                }
            }
            catch
            {
            }
        }

        private void CheckClientReceiveData(object obj)
        {
            System.Net.Sockets.Socket client = (System.Net.Sockets.Socket)obj;
            try
            {
                DateTime D1;
                D1 = DateTime.Now;
                while (client.Connected && _BSPTCPServer.IsListen)
                {
                    try
                    {
                        byte[] readBuffer = new byte[client.ReceiveBufferSize];
                        using (var writer = new MemoryStream())
                        {
                            bool TimeOut = false;
                            client.ReceiveTimeout = 1000 * 60 * 2;
                            client.SendTimeout = 1000 * 60 * 2;
                            int numberOfBytesRead = client.Receive(readBuffer);
                            if (numberOfBytesRead <= 0)
                            {
                                return;
                            }
                            writer.Write(readBuffer, 0, numberOfBytesRead);
                            if ((DateTime.Now - D1).TotalSeconds > 2 * 60)
                                TimeOut = true;
                            if (writer.Length > 0)
                            {
                                TimeOut = false;
                                D1 = DateTime.Now;
                                _BSPTCPServer.ReceiveData(this, client, writer.ToArray());
                            }
                            else
                                if (TimeOut)
                            {
                                _BSPTCPServer.Disconnect(client);
                                return;
                            }
                        }
                    }
                    catch (IOException exception)
                    {
                        return;
                    }
                }
                return;
            }
            catch (Exception exception)
            {
            }
            finally
            {
            }
        }


        public override void Dispose()
        {
            try
            {
                base.Dispose();
                _BSPTCPServer = null;
                _TcpClient = null;
                GC.Collect();
            }
            catch
            {

            }
        }
    }
}
