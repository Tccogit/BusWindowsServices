using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class AVLServiceControl : UserControl
    {
        Thread AVLThread;
        Thread TicketThread;
        Thread TicketThreadOffilne;
        Thread BusUpdateLocationThread;
        Thread ShowExceptionThread;
        Thread KillSleetConnThread;
        Thread DistanceMeasurement;
        Thread SocketAvl;

        bool _NoClose = true;
        bool _AVLThread = false;
        bool _TicketThread = false;
        bool _TicketThreadOffilne = false;
        bool _BusUpdateLocationThread = false;
        bool _ShowExceptionThread = false;
        bool _KillSleetConnThread = false;
        bool _DistanceMeasurement = false;
        bool _SocketAvl = false;

        public AVLServiceControl()
        {
            InitializeComponent();

            AVLThread = new Thread(AVLProcess);
            TicketThread = new Thread(TicketProcess);
            TicketThreadOffilne = new Thread(TicketProcessOffline);
            BusUpdateLocationThread = new Thread(BusUpdateLocation);
            ShowExceptionThread = new Thread(ShowException);
            KillSleetConnThread = new Thread(KillConnection);
            DistanceMeasurement = new Thread(DistanceMeasur);
            SocketAvl = new Thread(SocketAvlProcess);

            ShowExceptionThread.Start();

        }


        delegate void SetTextCallback(string text, int pType);

        private void SetText(string text, int pType)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            switch (pType)
            {
                case 1:
                    if (this.listBox1.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { text, pType });
                    }
                    else
                        this.listBox1.Items.Add(text);

                    break;
                case 2:
                    this.toolStripStatusLabelConnectn.Text = text;
                    int dbcount = 0;
                    if (int.TryParse(text,out dbcount) && int.Parse(text) > 10)
                    {
                        SetText(String.Join(",", ClassLibrary.JDataBase.dbsOpen.GetSql(120)), 1);
                    }
                    break;

            }
        }

        #region
        private void ShowException()
        {
            while (_NoClose)
            {
                Thread.Sleep(2000);
                try
                {
                    SetText(ClassLibrary.JDataBase.dbsOpen.Count.ToString(), 2);

                    if (ClassLibrary.JException.Exceptions.Length > 0)
                    {
                        for (int i = 0; i < ClassLibrary.JException.Exceptions.Length; i++)
                        {
                            if (ClassLibrary.JException.Exceptions[i] != null)
                                SetText(ClassLibrary.JException.Exceptions[i].Message + '-' + ClassLibrary.JException.Exceptions[i].Source, 1);
                        }
                        ClassLibrary.JException.EmptyExceptions();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void SocketAvlProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_SocketAvl)
                {
                    Thread.Sleep(1);
                    (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL(db);
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            SocketAvl.Abort();
        }

        private void AVLProcess()
        {
            try
            {
                while (_AVLThread)
                {
                    Thread.Sleep(10);
                    (new BusManagment.Transaction.JTransactions()).CheckDataAVL();
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            AVLThread.Abort();
        }

        private void TicketProcess()
        {
            while (_TicketThread)
            {
                Thread.Sleep(10);
                (new BusManagment.Transaction.JTransactions()).CheckDataTicket();
            }
            TicketThread.Abort();
        }

        private void TicketProcessOffline()
        {
            while (_TicketThreadOffilne)
            {
                Thread.Sleep(10000);
                try
                {
                    (new BusManagment.Transaction.JTransactions()).CheckDataSQLiteTicket();
                    (new BusManagment.Transaction.JTransactions()).CheckDataOfflineTicket();
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            TicketThreadOffilne.Abort();
        }

        private void BusUpdateLocation()
        {
            int backtime, Period;
            while (_BusUpdateLocationThread)
            {
                Thread.Sleep(100);
                //if (int.TryParse(txtBackTime.Text, out backtime) == true & int.TryParse(txtPeriod.Text, out Period) == true)
                // {
                //  BusManagment.AVL.JOnlineMap.UpdateBusLocation(Convert.ToInt32(txtBackTime.Text), Convert.ToInt32(txtPeriod.Text));
                // }
                // else
                // {
                BusManagment.AVL.JOnlineMap.UpdateBusLocation(30, 5);
                //}
            }
            BusUpdateLocationThread.Abort();
        }

        private void KillConnection(object obj)
        {
            ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_KillSleetConnThread)
                {
                    Thread.Sleep(1000);
                    MyDB.KillSleepProcess(300);
                }
                KillSleetConnThread.Abort();
            }
            finally
            {
                MyDB.Dispose();
            }
        }


        private void DistanceMeasur(object obj)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_DistanceMeasurement)
                {
                    Thread.Sleep(1);
                    BusManagment.AVL.JAVLTransactions.DistanceMeasurement(db);
                }
                DistanceMeasurement.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        private void chkAVL_CheckedChanged(object sender, EventArgs e)
        {
            _AVLThread = chkAVL.Checked;
            if (chkAVL.Checked)
            {
                AVLThread.Start();
            }
        }

        private void chkTicket_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string S = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                S += listBox1.Items[i].ToString() + Environment.NewLine;
            }
            System.IO.File.WriteAllText("c:\\serviceAVL.txt", S);
            listBox1.Items.Clear();

        }

        private void chkTicket_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void chkBusLocation_CheckedChanged(object sender, EventArgs e)
        {
            _BusUpdateLocationThread = chkBusLocation.Checked;
            if (chkBusLocation.Checked)
            {
                BusUpdateLocationThread.Start();
            }
        }

        private void chkTicket_CheckedChanged_2(object sender, EventArgs e)
        {
            _TicketThread = chkTicket.Checked;
            if (chkTicket.Checked)
            {
                TicketThread.Start();
            }
        }

        private void ChkSocket_CheckedChanged(object sender, EventArgs e)
        {
            BspTcpServer.Port = ushort.Parse(TxtPort.Text);
            BspTcpServer.IsListen = ChkSocket.Checked;

            _SocketAvl = ChkSocket.Checked;
            if (ChkSocket.Checked)
            {
                SocketAvl.Start();
            }
        }

        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.TcpClient client, byte[] bytes, string data)
        {
            ClassLibrary.Socket.JSocketManager.GetData(client, bytes);
            //BspTcpServer.SendData(client, "OK");
        }

        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.TcpClient client)
        {
            ClassLibrary.Socket.JSocketManager.Connect(client);
        }

        private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.TcpClient client)
        {
            ClassLibrary.Socket.JSocketManager.DisConnect(client);
        }

        private void BspTcpServer_OnError(object sender, System.Net.Sockets.TcpClient client, Exception exception)
        {

        }

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            _TicketThreadOffilne = chkOffline.Checked;
            if (chkOffline.Checked)
            {
                TicketThreadOffilne.Start();
            }
        }

        private void chkKillSleepCon_CheckedChanged(object sender, EventArgs e)
        {
            _KillSleetConnThread = chkKillSleepCon.Checked;
            if (chkKillSleepCon.Checked)
            {
                KillSleetConnThread.Start();
            }
        }

        private void CLoseThread(Thread pT, bool _Check)
        {
            _Check = false;
            try
            {
                if (pT.ThreadState == ThreadState.Running)
                {
                    pT.Abort();
                    pT.Join();
                }
            }
            catch { }
        }

		public void CloseAll()
		{
			_NoClose = false;

			chkAVL.Checked = false;
			chkBusLocation.Checked = false;
			chkOffline.Checked = false;
			ChkSocket.Checked = false;
			chkTicket.Checked = false;

			CLoseThread(AVLThread, _AVLThread);
			CLoseThread(TicketThread, _TicketThread);
			CLoseThread(TicketThreadOffilne, _TicketThreadOffilne);
			CLoseThread(BusUpdateLocationThread, _BusUpdateLocationThread);
			CLoseThread(ShowExceptionThread, _ShowExceptionThread);

		}
		//private void AVLServiceForm_FormClosed(object sender, FormClosedEventArgs e)
		//{
		//	_NoClose = false;

		//	chkAVL.Checked = false;
		//	chkBusLocation.Checked = false;
		//	chkOffline.Checked = false;
		//	ChkSocket.Checked = false;
		//	chkTicket.Checked = false;

		//	CLoseThread(AVLThread, _AVLThread);
		//	CLoseThread(TicketThread, _TicketThread);
		//	CLoseThread(TicketThreadOffilne, _TicketThreadOffilne);
		//	CLoseThread(BusUpdateLocationThread, _BusUpdateLocationThread);
		//	CLoseThread(ShowExceptionThread, _ShowExceptionThread);

		//	Application.ExitThread();
		//	Application.Exit();


		//}

        private void chkDistanceMeasurement_CheckedChanged(object sender, EventArgs e)
        {
            _DistanceMeasurement = chkDistanceMeasurement.Checked;
            if (chkDistanceMeasurement.Checked)
            {
                DistanceMeasurement.Start();
            }
        }

    }
}
