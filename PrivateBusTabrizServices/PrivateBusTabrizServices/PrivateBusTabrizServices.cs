using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BusManagment.Transaction;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace PrivateBusTabrizServices
{
    public partial class PrivateBusTabrizServices : ServiceBase
    {

        AVLService A;
        public PrivateBusTabrizServices()
        {
            InitializeComponent();
            A = new AVLService();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            if (A == null)
                A = new AVLService();
            A.Start();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            A.Stop();
        }

        protected override void OnPause()
        {
            base.OnPause();
            A.Stop();
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }
    }

    public partial class AVLService
    {
        private ClassLibrary.BSPTCPServer BspTcpServer;
        private ClassLibrary.BSPTCPServer BSPTCPServerTeltonika;

        Thread AVLThread;
        Thread AVLThreadOffLine;
        Thread AVLThreadTeltonika;
        Thread TicketThread;
        Thread TicketThreadOffilne;
        Thread BusUpdateLocationThread;
        Thread ShowExceptionThread;
        Thread KillSleetConnThread;
        Thread DistanceMeasurement;
        Thread TransactionPrintCheck;
        Thread TransactionPrintInsert;
        Thread TransactionPrintInsertDailyMontly;
        Thread CalenderRepair;
        Thread SendSMS;
        Thread EventLog;
        Thread EventReaderDetails;
        Thread EventBazrasLog;
        Thread EventBusPassingStation;
        Thread SendQuery;
        Thread SendMessage;
        Thread TicketHandHeldThread;
        Thread TicketOnlineReaderThread;
        Thread ServiceProcess;
        Thread AnswerRtpisSMS;
        Thread CityBankOutPUTFile;
        Thread CheckCityBankcsrNewFileThread;
        Thread QRScannerprocessThread;

        bool _NoClose = false;
        bool _AVLThread = false;
        bool _AVLThreadOffLine = false;
        bool _AVLThreadTeltonika = false;
        bool _TicketThread = false;
        bool _TicketThreadOffilne = false;
        bool _BusUpdateLocationThread = false;
        bool _ShowExceptionThread = false;
        bool _KillSleetConnThread = false;
        bool _DistanceMeasurement = false;
        bool _TransactionPrintCheck = false;
        bool _TransactionPrintInsert = false;
        bool _TransactionPrintInsertDailyMontly = false;
        bool _CalenderRepair = false;
        bool _SendSMS = false;
        bool _EventLog = false;
        bool _SendQuery = false;
        bool _SendMessage = false;
        bool _TicketHandHeldThread = false;
        bool _TicketOnlineReaderThread = false;
        bool _QRScannerprocessThread = false;
        bool _ServiceProcess = false;
        bool _EventBusPassingStation = false;
        bool _AnswerRtpisSMS = false;
        bool _CityBankOutPUTFile = false;
        bool _CheckCityBankcsrNewFile = false;

        public AVLService()
        {
            string OutStr = "";
            ClassLibrary.JMainFrame.FConfig.TryGetValue("Public", out OutStr);

            ClassLibrary.DataBase.JQuery.useQuery = false;

            AVLThread = new Thread(AVLProcess);
            AVLThreadOffLine = new Thread(AVLProcessOffLine);
            AVLThreadTeltonika = new Thread(AVLProcessTeltonika);
            TicketThread = new Thread(TicketProcess);
            TicketHandHeldThread = new Thread(TicketHandHeldProcess);
            TicketOnlineReaderThread = new Thread(TicketOnlineReaderProcess);
            TicketThreadOffilne = new Thread(TicketProcessOffline);
            BusUpdateLocationThread = new Thread(BusUpdateLocation);
            ShowExceptionThread = new Thread(ShowException);
            KillSleetConnThread = new Thread(KillConnection);
            DistanceMeasurement = new Thread(DistanceMeasur);
            TransactionPrintCheck = new Thread(TransactionPrintCheckProcess);
            TransactionPrintInsert = new Thread(TransactionPrintInsertProcess);
            TransactionPrintInsertDailyMontly = new Thread(TransactionPrintInsertDailyMontlyProcess);
            CalenderRepair = new Thread(CalenderRepairProcess);
            SendSMS = new Thread(SendSMSProcess);
            EventLog = new Thread(EventLogProcess);
            EventReaderDetails = new Thread(EventReaderDetailsProcess);
            EventBazrasLog = new Thread(EventBazrasLogProcess);
            EventBusPassingStation = new Thread(EventBusPassingStationProcess);
            SendQuery = new Thread(SendQueryProcess);
            SendMessage = new Thread(SendMessageProcess);
            ServiceProcess = new Thread(ServiceProcessFunction);
            AnswerRtpisSMS = new Thread(AnswerRtpisSMSFunction);
            CityBankOutPUTFile = new Thread(CityBankOutPUTFileFunction);
            CheckCityBankcsrNewFileThread = new Thread(CheckCityBankcsrNewFile);
            QRScannerprocessThread = new Thread(QRScannerProcess);

        }

        public void Start()
        {
            try
            {
                BspTcpServer = new ClassLibrary.BSPTCPServer();

                BspTcpServer.OnClientConnect += new ClassLibrary.BSPTCPServer.OnClientConnectHandler(BspTcpServer_OnClientConnect);
                BspTcpServer.OnClientDisconnect += new ClassLibrary.BSPTCPServer.OnClientDisconnectHandler(BspTcpServer_OnClientDisconnect);
                BspTcpServer.OnError += new ClassLibrary.BSPTCPServer.OnErrorHandler(BspTcpServer_OnError);
                BspTcpServer.OnReceiveData += new ClassLibrary.BSPTCPServer.OnReceiveDataHandler(BspTcpServer_OnReceiveData);

                BspTcpServer.Port = 8572;
                String BspTcpServerValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("BspTcpServer", out BspTcpServerValue) && BspTcpServerValue == "0")
                {
                }
                else
                {
                    BspTcpServer.IsListen = true;
                }

                BSPTCPServerTeltonika = new ClassLibrary.BSPTCPServer();

                BSPTCPServerTeltonika.OnClientConnect += new ClassLibrary.BSPTCPServer.OnClientConnectHandler(BspTcpServerTelTonika_OnClientConnect);
                BSPTCPServerTeltonika.OnClientDisconnect += new ClassLibrary.BSPTCPServer.OnClientDisconnectHandler(BspTcpServerTelTonika_OnClientDisconnect);
                BSPTCPServerTeltonika.OnError += new ClassLibrary.BSPTCPServer.OnErrorHandler(BspTcpServerTelTonika_OnError);
                BSPTCPServerTeltonika.OnReceiveData += new ClassLibrary.BSPTCPServer.OnReceiveDataHandler(ReceiveTelTonikaData);

                BSPTCPServerTeltonika.Port = 8573;
                String BspTcpServerValueTeltonika = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("BspTcpServerValueTeltonika", out BspTcpServerValueTeltonika) && BspTcpServerValueTeltonika == "0")
                {
                }
                else
                {
                    BSPTCPServerTeltonika.IsListen = true;
                }


                _NoClose = true;
                _AVLThread = true;
                _AVLThreadOffLine = true;
                _AVLThreadTeltonika = true;
                _TicketThread = true;
                _TicketThreadOffilne = true;
                _ShowExceptionThread = true;
                _TransactionPrintCheck = true;
                _TransactionPrintInsert = true;
                _TransactionPrintInsertDailyMontly = true;
                _CalenderRepair = true;
                _SendSMS = true;
                _EventLog = true;
                _SendQuery = true;
                _SendMessage = true;
                _TicketHandHeldThread = true;
                _TicketOnlineReaderThread = true;
                _ServiceProcess = true;
                _EventBusPassingStation = true;
                _AnswerRtpisSMS = true;
                _CityBankOutPUTFile = true;
                _CheckCityBankcsrNewFile = true;
                _QRScannerprocessThread = true;

                string ShowExceptionThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("ShowExceptionThread", out ShowExceptionThreadValue) && ShowExceptionThreadValue == "0")
                {

                }
                else
                {
                    ShowExceptionThread.Start();
                }

                string AVLThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("AVLThread", out AVLThreadValue) && AVLThreadValue == "0")
                {

                }
                else
                {
                    AVLThread.Start();
                }

                string AVLThreadOfflineValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("AVLThreadOffline", out AVLThreadOfflineValue) && AVLThreadOfflineValue == "0")
                {

                }
                else
                {
                    AVLThreadOffLine.Start();
                }

                string AVLThreadTeltonikaValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("AVLThreadTeltonika", out AVLThreadTeltonikaValue) && AVLThreadTeltonikaValue == "0")
                {
                }
                else
                {
                    AVLThreadTeltonika.Start();
                }
                string TicketThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TicketThread", out TicketThreadValue) && TicketThreadValue == "0")
                {
                }
                else
                {
                    TicketThread.Start();
                }

                string TicketHandHeldThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TicketHandHeldThread", out TicketHandHeldThreadValue) && TicketHandHeldThreadValue == "0")
                {
                }
                else
                {
                    TicketHandHeldThread.Start();
                }

                string TicketOnlineReaderThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TicketOnlineReaderThread", out TicketOnlineReaderThreadValue) && TicketOnlineReaderThreadValue == "0")
                {
                }
                else
                {
                    TicketOnlineReaderThread.Start();
                }
                string QRScannerprocessThreadValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("QRScannerprocessThread", out QRScannerprocessThreadValue) && QRScannerprocessThreadValue == "0")
                {
                }
                else
                {
                    QRScannerprocessThread.Start();
                }
                string TicketThreadOffilneValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TicketThreadOffilne", out TicketThreadOffilneValue) && TicketThreadOffilneValue == "0")
                {
                }
                else
                {
                    TicketThreadOffilne.Start();
                }

                string TransactionPrintCheckValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TransactionPrintCheck", out TransactionPrintCheckValue) && TransactionPrintCheckValue == "0")
                {
                }
                else
                {
                    TransactionPrintCheck.Start();
                }

                string TransactionPrintInsertkValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TransactionPrintInsert", out TransactionPrintInsertkValue) && TransactionPrintInsertkValue == "0")
                {
                }
                else
                {
                    TransactionPrintInsert.Start();
                }

                string TransactionPrintInsertDailyMontlyValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("TransactionPrintInsertDailyMontly", out TransactionPrintInsertDailyMontlyValue) && TransactionPrintInsertDailyMontlyValue == "0")
                {
                }
                else
                {
                    TransactionPrintInsertDailyMontly.Start();
                }

                string CalenderRepairValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("CalenderRepair", out CalenderRepairValue) && CalenderRepairValue == "0")
                {
                }
                else
                {
                    CalenderRepair.Start();
                }

                string SendSMSValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("SendSMS", out SendSMSValue) && SendSMSValue == "0")
                {
                }
                else
                {
                    SendSMS.Start();
                }

                string EventLogValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("EventLog", out EventLogValue) && EventLogValue == "0")
                {
                }
                else
                {
                    EventLog.Start();
                }
                string EventReaderDetailsValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("EventReaderDetails", out EventReaderDetailsValue) && EventReaderDetailsValue == "0")
                {
                }
                else
                {
                    EventReaderDetails.Start();
                }


                string EventBazrasLogValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("EventBazrasLog", out EventBazrasLogValue) && EventBazrasLogValue == "0")
                {
                }
                else
                {
                    EventBazrasLog.Start();
                }

                string EventBusPassingStationValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("EventBusPassingStation", out EventBusPassingStationValue) && EventBusPassingStationValue == "0")
                {
                }
                else
                {
                    EventBusPassingStation.Start();
                }

                string SendQueryValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("SendQuery", out SendQueryValue) && SendQueryValue == "0")
                {
                }
                else
                {
                    SendQuery.Start();
                }

                string SendMessageValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("SendMessage", out SendMessageValue) && SendMessageValue == "0")
                {
                }
                else
                {
                    SendMessage.Start();
                }

                string ServiceProcessValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("ServiceProcess", out ServiceProcessValue) && ServiceProcessValue == "0")
                {
                }
                else
                {
                    ServiceProcess.Start();
                }

                string AnswerRtpisSMSValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("AnswerRtpisSMS", out AnswerRtpisSMSValue) && AnswerRtpisSMSValue == "0")
                {
                }
                else
                {
                    AnswerRtpisSMS.Start();
                }

                string CityBankOutPUTFileValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("CityBankOutPUTFile", out CityBankOutPUTFileValue) && CityBankOutPUTFileValue == "0")
                {
                }
                else
                {
                    CityBankOutPUTFile.Start();
                }

                string CheckCityBankcsrNewFileValue = "";
                if (ClassLibrary.JMainFrame.FConfig.TryGetValue("CheckCityBankcsrNewFile", out CheckCityBankcsrNewFileValue) && CheckCityBankcsrNewFileValue == "0")
                {
                }
                else
                {
                    CheckCityBankcsrNewFileThread.Start();
                }
            }
            catch (Exception ex)
            {
                SetText(ex.ToString(), 1);
            }

        }

        public void Stop()
        {
            try
            {
                BspTcpServer.IsListen = false;
                BspTcpServer.DisconnectAll();
            }
            catch
            {

            }
            try
            {

                _NoClose = false;
                _AVLThread = false;
                _AVLThreadOffLine = false;
                _AVLThreadTeltonika = false;
                _TicketThread = false;
                _TicketThreadOffilne = false;
                _BusUpdateLocationThread = false;
                _ShowExceptionThread = false;
                _KillSleetConnThread = false;
                _DistanceMeasurement = false;
                //_SocketAvl = false;
                _TransactionPrintCheck = false;
                _TransactionPrintInsert = false;
                _TransactionPrintInsertDailyMontly = false;
                _CalenderRepair = false;
                _SendSMS = false;
                _EventLog = false;
                _EventBusPassingStation = false;
                _SendQuery = false;
                _SendMessage = false;
                _TicketHandHeldThread = false;
                _TicketOnlineReaderThread = false;
                _ServiceProcess = false;
                _CityBankOutPUTFile = false;
                _CheckCityBankcsrNewFile = false;
                _QRScannerprocessThread = false;



                System.Threading.Thread.Sleep(60 * 1000);

                CLoseThread(ShowExceptionThread, true);
                CLoseThread(AVLThread, true);
                CLoseThread(AVLThreadTeltonika, true);
                CLoseThread(AVLThreadOffLine, true);
                CLoseThread(TicketThread, true);
                CLoseThread(TicketHandHeldThread, true);
                CLoseThread(TicketOnlineReaderThread, true);
                CLoseThread(QRScannerprocessThread, true);
                CLoseThread(TicketThreadOffilne, true);
                CLoseThread(BusUpdateLocationThread, true);
                CLoseThread(ShowExceptionThread, true);
                CLoseThread(KillSleetConnThread, true);
                CLoseThread(DistanceMeasurement, true);
                //CLoseThread(SocketAvl, true);
                CLoseThread(TransactionPrintCheck, true);
                CLoseThread(TransactionPrintInsert, true);
                CLoseThread(TransactionPrintInsertDailyMontly, true);
                CLoseThread(CalenderRepair, true);
                CLoseThread(SendSMS, true);
                CLoseThread(EventLog, true);
                CLoseThread(EventReaderDetails, true);
                CLoseThread(EventBazrasLog, true);
                CLoseThread(EventBusPassingStation, true);
                CLoseThread(SendQuery, true);
                CLoseThread(SendMessage, true);
                CLoseThread(ServiceProcess, true);
                CLoseThread(CityBankOutPUTFile, true);
                CLoseThread(CheckCityBankcsrNewFileThread, true);

                ShowException();

            }
            catch (Exception ex)
            {
                SetText(ex.ToString(), 1);
            }


        }

        delegate void SetTextCallback(string text, int pType);

        private void SetText(string text, int pType)
        {
            try
            {
                //System.IO.File.AppendAllText(ClassLibrary.JConfig.appPath + "\\" + DateTime.Today.ToString("yyyyMMdd") + ".log",text+Environment.NewLine);
            }
            catch
            {

            }
        }

        #region
        private void ShowException()
        {
            while (_NoClose)
            {
                Thread.Sleep(1000 * 60);
                try
                {
                    try
                    {
                        string[] S = ClassLibrary.JDataBase.dbsOpen.GetSql(60);
                        foreach (string s in S)
                            SetText(s, 2);
                    }
                    catch
                    {

                    }


                    if (ClassLibrary.JDataBase.dbsOpen.Count > 2000)
                    {
                        SetText("Number of Open DataBase : " + ClassLibrary.JDataBase.dbsOpen.Count.ToString(), 2);
                    }

                    if (ClassLibrary.JSystem.Except.Count > 0)
                    {
                        for (int i = 0; i < ClassLibrary.JSystem.Except.Count; i++)
                        {
                            if (ClassLibrary.JSystem.Except.GetByIndex(i) != null)
                            {
                                SetText(ClassLibrary.JSystem.Except.GetByIndex(i).Message + '-' + ClassLibrary.JSystem.Except.GetByIndex(i).Source, 1);
                                if (ClassLibrary.JSystem.Except.GetByIndex(i).InnerException != null)
                                {
                                    SetText(ClassLibrary.JSystem.Except.GetByIndex(i).InnerException.Message +
                                        '-' + ClassLibrary.JSystem.Except.GetByIndex(i).InnerException.Source, 1);
                                }
                            }
                        }
                        ClassLibrary.JSystem.Except.EmptyExceptions();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            ShowExceptionThread.Abort();
        }

        private void SocketAvlProcess()
        {

        }

        private void ServiceProcessFunction()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_ServiceProcess)
                {
                    Thread.Sleep(30 * 1000);
                    BusManagment.WorkOrder.JTariff.ServiceProcessFunction(db);
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
            ServiceProcess.Abort();
        }

        private void TransactionPrintInsertDailyMontlyProcess()
        {
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            //try
            //{
            //    while (_TransactionPrintInsertDailyMontly)
            //    {
            //        Thread.Sleep(3600 * 1000);
            //       if(DateTime.Now.Hour > 16)
            //           BusManagment.Transaction.JTicketTransactions.TransactionPrintInsertDaily(db, mysqlDB);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClassLibrary.JSystem.Except.AddException(ex);
            //}
            //finally
            //{
            //    db.Dispose();
            //    mysqlDB.Dispose();
            //}
            //TransactionPrintInsertDailyMontly.Abort();
        }

        private void TransactionPrintInsertProcess()
        {
            //int TimerCount = 1;
            //DateTime InsertDate;
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            //try
            //{
            //    //while (_TransactionPrintInsert)
            //    //{
            //        //if (txt_InsertPrintTimer.Text.Length > 0)
            //        //{
            //        //    if (int.TryParse(txt_InsertPrintTimer.Text, out TimerCount))
            //        //    {
            //        //        Thread.Sleep(TimerCount);
            //        //        if (txt_InsertPrintDate.Text.Length > 0)
            //        //        {
            //        //            if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
            //        //            {
            //        //                //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, InsertDate);
            //        //            }
            //        //        }
            //        //    }
            //        //}
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    ClassLibrary.JSystem.Except.AddException(ex);
            //}
            //finally
            //{
            //    db.Dispose();
            //    mysqlDB.Dispose();
            //}
            //TransactionPrintInsert.Abort();
        }

        private void TransactionPrintCheckProcess()
        {
            //int TimerCount = 3600*1000;
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            //try
            //{
            //    DateTime InsertDate = DateTime.Now.AddMonths(-1);
            //    while (_TransactionPrintCheck)
            //    {
            //        Thread.Sleep(TimerCount);
            //        if(DateTime.Now.Hour>=16)
            //        //if (txt_CheckPrintTimer.Text.Length > 0)
            //        {
            //            //if (int.TryParse(txt_CheckPrintTimer.Text, out TimerCount))
            //            {

            //                //if (txt_InsertPrintDate.Text.Length > 0)
            //                {
            //                    //if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
            //                    {
            //                        if (Public)
            //                        {
            //                            BusManagment.TransactionPublic.JTransactions.TransactionPrintCheckDataTicketPublic(db, mysqlDB, InsertDate);
            //                        }
            //                        else
            //                        {
            //                            BusManagment.Transaction.JTicketTransactions.TransactionPrintCheckDataTicket(db, mysqlDB, InsertDate);
            //                        }
            //                        //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, InsertDate);
            //                    }
            //                }
            //                if (!Public)
            //                {
            //                    // BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, DateTime.Now);
            //                    BusManagment.Transaction.JTicketTransactions.TransactionPrintCheckDataTicketForAllPrinterReport(db, mysqlDB);
            //                    BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintUpdateFromMySql(db, mysqlDB);
            //                    BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintCheck(db, mysqlDB);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClassLibrary.JSystem.Except.AddException(ex);
            //}
            //finally
            //{
            //    db.Dispose();
            //    mysqlDB.Dispose();
            //}
            //TransactionPrintCheck.Abort();
        }

        private void AVLProcess()
        {


            string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "DataTableAvl");
            if (!System.IO.Directory.Exists(DataTableTicket))
                System.IO.Directory.CreateDirectory(DataTableTicket);

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("update ClsSocketClientDataManager set IsProceced="
                    + BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode()
                    + ",[GetDate] = GetDate() where IsProceced="
                    + BusManagment.Transaction.SocketDataState.Bus_InProcess.GetHashCode());

                db.Query_Execute();

                while (_AVLThread)
                {
                    Thread.Sleep(10);
                    (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL(db, false, BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode());

                    if (DateTime.Now.Hour == 23 && DateTime.Now.Second == 01)
                    {
                        db.setQuery("update ClsSocketClientDataManager set IsProceced="
                            + BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode()
                            + ",[GetDate] = GetDate() where IsProceced="
                            + BusManagment.Transaction.SocketDataState.Bus_InProcess.GetHashCode());

                        db.Query_Execute();
                    }
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
            AVLThread.Abort();
        }


        private void AVLProcessOffLine()
        {
            while (_AVLThread)
            {
                Thread.Sleep(1000 * 5);
                BusManagment.Transaction.JTicketTransactions.ProcessOldFileTicketDataTable(false);

            }
            AVLThreadOffLine.Abort();
        }


        private void AVLProcessTeltonika()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("update ClsSocketClientDataManager set IsProceced="
                    + BusManagment.Transaction.SocketDataState.Teltonika_InList.GetHashCode()
                    + ",[GetDate] = GetDate() where IsProceced="
                    + BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode());

                db.Query_Execute();

                while (_AVLThreadTeltonika)
                {
                    Thread.Sleep(10);
                    (new BusManagment.Transaction.JTransactions()).SocketCheckDataTeltonikaAVL(db, false, BusManagment.Transaction.SocketDataState.Teltonika_InList.GetHashCode()); // List sample teltonika
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
            AVLThreadTeltonika.Abort();
        }

        private void TicketProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TicketThread)
                {
                    Thread.Sleep(1000 * 15);
                    //if (Public)
                    //{
                    //    (new BusManagment.TransactionPublic.JTransactions()).CheckDataTicket();
                    //    (new BusManagment.Transaction.JTransactions()).CheckDataTicket();
                    //}
                    //else
                    (new BusManagment.Transaction.JTransactions()).CheckDataTicket();
                }
                TicketThread.Abort();
            }
            finally
            {
                db.Dispose();
            }
        }

        private void TicketHandHeldProcess()
        {
            try
            {
                while (_TicketHandHeldThread)
                {
                    Thread.Sleep(1000 * 60);
                    (new BusManagment.Transaction.JTransactions()).CheckDataTicketHandHeld();
                }
                TicketHandHeldThread.Abort();
            }
            finally
            {
            }
        }

        private void TicketOnlineReaderProcess()
        {
            try
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                db.setQuery("update AUTOnlineReaderTicket set IsProceced=0 where IsProceced=2");
                db.Query_Execute();
                db.Dispose();

                while (_TicketOnlineReaderThread)
                {
                    try
                    {
                        Thread.Sleep(1000 * 60);
                        (new BusManagment.Transaction.JTransactions()).CheckDataTicketOnlineReader();
                    }
                    catch
                    {

                    }
                }
                TicketOnlineReaderThread.Abort();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private void QRScannerProcess()
        {
            try
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                db.setQuery("update AUTQRReaderTransaction set IsProceced=0 where IsProceced=2");
                db.Query_Execute();
                db.Dispose();

                while (_QRScannerprocessThread)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        (new BusManagment.Transaction.JTransactions()).CheckDataTicketQRScanner();
                    }
                    catch
                    {

                    }
                }
                QRScannerprocessThread.Abort();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        public void EventLogProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_EventLog)
                {
                    Thread.Sleep(10000);//600000
                    //if (!Public)
                    {
                        (new BusManagment.EventLog.JEventLog()).EventLogProcess(db);
                    }
                }
                EventLog.Abort();
            }
            finally
            {
                db.Dispose();
            }
        }
        public void EventReaderDetailsProcess()
        {
            ClassLibrary.JDataBase ReaderDetailsProcessDB = new ClassLibrary.JDataBase();
            try
            {
                while (_EventLog)
                {
                    Thread.Sleep(1000);
                    //if (!Public)
                    {
                        BusManagment.EventLog.JEventLog.ReaderDetailsProcess(ReaderDetailsProcessDB);
                    }
                }
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                ReaderDetailsProcessDB.Dispose();
            }
        }

        public void EventBazrasLogProcess()
        {
            ClassLibrary.JDataBase BazRasServicesProcessDB = new ClassLibrary.JDataBase();
            try
            {
                while (_EventLog)
                {
                    Thread.Sleep(1000 * 60);
                    //if (!Public)
                    {
                        BusManagment.EventLog.JEventLog.BazrasServicesProcess(BazRasServicesProcessDB);
                        BusManagment.EventLog.JEventLog.BazrasServicesGoBackProcess(BazRasServicesProcessDB);
                    }
                }
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                BazRasServicesProcessDB.Dispose();
            }
        }


        public void EventBusPassingStationProcess()
        {
            ClassLibrary.JDataBase BazRasServicesProcessDB = new ClassLibrary.JDataBase();
            try
            {
                while (_EventBusPassingStation)
                {
                    Thread.Sleep(1000);
                    //if (!Public)
                    {
                        BusManagment.EventLog.JEventLog.BusPassingStationProcess(BazRasServicesProcessDB);
                    }
                }
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                BazRasServicesProcessDB.Dispose();
            }
        }
        public void SendQueryProcess()
        {
            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server01", 0));
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_SendQuery)
                {
                    Thread.Sleep(150000);//600000
                    //if (!Public)
                    {
                        (new BusManagment.EventLog.JEventLog()).InsertIntoGetQuery(db, MySqlDb);
                        (new BusManagment.EventLog.JEventLog()).UpdateAUTConsoleQuerySendStatus(db, MySqlDb);
                        (new BusManagment.EventLog.JEventLog()).InsertIntoAUTConsoleQuerySendStatus(db);
                        //(new BusManagment.EventLog.JEventLog()).SendMessage(db, MySqlDb);
                    }

                }
                SendQuery.Abort();
            }
            finally
            {
                db.Dispose();
                MySqlDb.Dispose();
            }
        }
        public void SendMessageProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_SendMessage)
                {
                    Thread.Sleep(3000);//600000
                    //if (!Public)
                    {
                        (new BusManagment.EventLog.JEventLog()).SendMessage(db, MySqlDb);
                    }

                }
                SendMessage.Abort();
            }
            finally
            {
                db.Dispose();
                MySqlDb.Dispose();
            }
        }

        public void SendSMSProcess()
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            while (_SendSMS)
            {
                Thread.Sleep(1000);
                try
                {
                    (new ClassLibrary.SMS.ClsMainSmsClass()).SendSMSService();
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            Db.Dispose();
            SendSMS.Abort();
        }

        private void CalenderRepairProcess()
        {
            //ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            //while (_CalenderRepair)
            //{
            //    Thread.Sleep(180000);
            //    try
            //    {
            //        if (!Public && DateTime.Now.Hour>=16)
            //        {
            //            (new BusManagment.Transaction.JTransactions()).CalenderRepairMethod(Db, MySqlDb);
            //            (new BusManagment.Transaction.JTransactions()).CalenderRepairMethodGetPrintFromConsole(Db, MySqlDb);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Db.Dispose();
            //        MySqlDb.Dispose();
            //        ClassLibrary.JSystem.Except.AddException(ex);
            //    }
            //    finally
            //    {
            //        Db.Dispose();
            //        MySqlDb.Dispose();
            //    }
            //}
            //CalenderRepair.Abort();
        }

        private void TicketProcessOffline()
        {
            for (int i = 0; i <= 7; i++)
            {
                Thread T1 = new Thread(new System.Threading.ParameterizedThreadStart(TicketProcessOfflineRun));
                T1.Start(i);
            }
        }

        private void TicketProcessOfflineRun(Object pProcess)
        {
            try
            {
                string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "DataTableTicket");
                if (!System.IO.Directory.Exists(DataTableTicket))
                    System.IO.Directory.CreateDirectory(DataTableTicket);
            }
            catch
            {

            }

            int p = (int)pProcess;
            while (_TicketThreadOffilne)
            {
                Thread.Sleep(1000);
                try
                {
                    switch (p)
                    {
                        case 0:
                            (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublic();
                            break;
                        case 1:
                            (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublicForStatus3();
                            break;
                        case 2:
                            (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublicForStatus4();
                            break;
                        case 3:
                            (new BusManagment.Transaction.JTransactions()).CheckDataSQLiteTicket();
                            break;
                        case 4:
                            (new BusManagment.Transaction.JTransactions()).CheckDataOfflineTicket();
                            break;
                        case 5:
                            (new BusManagment.Transaction.JTransactions()).CheckDataReaderTicket();
                            break;
                        case 6:
                            BusManagment.Transaction.JTicketTransactions.ProcessOldFileTicketDataTable();
                            break;
                        case 7:
                            (new BusManagment.Transaction.JTransactions()).CheckDataSQLiteTicket();
                            break;
                    }
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
                Thread.Sleep(1000);
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
                    Thread.Sleep(1000 * 60);
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
            _AVLThread = true;// chkAVL.Checked;
            //if (chkAVL.Checked)
            {
                AVLThread.Start();
            }
        }

        private void chkTicket_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string S = "";
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            //    S += listBox1.Items[i].ToString() + Environment.NewLine;
            //}
            //System.IO.File.WriteAllText("c:\\serviceAVL.txt", S);
            //listBox1.Items.Clear();

        }

        private void chkTicket_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        //private void chkBusLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _BusUpdateLocationThread = chkBusLocation.Checked;
        //    if (chkBusLocation.Checked)
        //    {
        //        BusUpdateLocationThread.Start();
        //    }
        //}

        private void chkTicket_CheckedChanged_2(object sender, EventArgs e)
        {
            _TicketThread = true;// chkTicket.Checked;
            //if (chkTicket.Checked)
            {
                TicketThread.Start();
            }
        }

        private void ChkSocket_CheckedChanged(object sender, EventArgs e)
        {
            //_SocketAvl = true;// ChkSocket.Checked;
            //if (ChkSocket.Checked)
            {
                //SocketAvl.Start();
            }
        }

        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.Socket client, byte[] bytes)
        {

            if (bytes.Length == 0)
            {
                BspTcpServer.SendData(client, "FALSE");
                return;
            }

            if (bytes.Length == 65017)
            {
                Thread.Sleep(100);
            }
            if (bytes[0] == (byte)200 && bytes[1] == (byte)3)
            {
                if (bytes[1] == (byte)3)
                {
                    BspTcpServer.SendData(client, "OK - " + ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    byte[] NewByte = new byte[32];
                    int counter = 0;
                    for (int i = 2; i < 34; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery("insert into AUTGroundDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        DB.Query_Execute();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                }
            }
            else if (bytes[0] == (byte)201 && bytes[1] == (byte)1)
            {
                if (bytes[1] == (byte)1)
                {
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        byte[] NewByte = new byte[bytes.Length - 2];
                        Array.Copy(bytes, 2, NewByte, 0, NewByte.Length);
                        int IMEI = int.Parse(Encoding.Unicode.GetString(NewByte));
                        DB.setQuery(@"declare @cur_date datetime; 
                            set @cur_date = getdate();
                            update AUTStation set LastRTPISRequest = @cur_date where IMEI = " + IMEI);
                        if (DB.Query_Execute() >= 0)
                        {
                            DB.setQuery("select dbo.fngetrtpistextforboard(" + IMEI + ")");
                            string res = DB.Query_ExecutSacler().ToString();
                            byte[] uni = Encoding.Unicode.GetBytes(res);
                            BspTcpServer.SendData(client, uni);
                        }
                        else
                            BspTcpServer.SendData(client, Encoding.Unicode.GetBytes(","));
                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                }
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)6)
            {
                byte[] NewByte = new byte[bytes.Length - 2];
                for (int i = 2; i < bytes.Length; i++)
                    NewByte[i - 2] = bytes[i];

                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery("insert into AUTOnlineReaderTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                    DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    DB.Params.Add("Data", NewByte);
                    DB.Params.Add("GetDate", DateTime.Now);
                    DB.Params.Add("IsProceced", 0);
                    if (DB.Query_Execute() > 0)
                        BspTcpServer.SendData(client, "SAVE OK");
                    else
                        BspTcpServer.SendData(client, "FALSE");
                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)12)
            {
                byte[] NewByte = new byte[bytes.Length - 2];
                for (int i = 2; i < bytes.Length; i++)
                    NewByte[i - 2] = bytes[i];

                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery("insert into AUTQRReaderTransaction(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                    DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    DB.Params.Add("Data", NewByte);
                    DB.Params.Add("GetDate", DateTime.Now);
                    DB.Params.Add("IsProceced", 0);
                    if (DB.Query_Execute() > 0)
                        BspTcpServer.SendData(client, "SAVE OK");
                    else
                        BspTcpServer.SendData(client, "FALSE");
                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)7)
            {
                //New config from reader
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    Int64 Index = ClassLibrary.Socket.JSocketManager.GetData(
                        client
                        , bytes
                        , "BusManagment.Transaction.JTransactionOnlineReader.GetClassNameNewConfig"
                        , 0
                        , BusManagment.Transaction.SocketDataState.OnlineReaderConfig_InProcess.GetHashCode()
                        );
                    if (Index > 0)
                    {
                        var data = BusManagment.Transaction.JTransactions.ProcessOnlineReaderSaveConfig(bytes);
                        if (data == null)
                            BspTcpServer.SendData(client, "No CONFIG");
                        else
                            BspTcpServer.SendData(client, data);
                    }
                    else
                    {
                        BspTcpServer.SendData(client, "FALSE");
                    }
                }
                catch (Exception ex)
                {
                    BspTcpServer.SendData(client, System.Text.Encoding.UTF8.GetBytes(ex.Message));
                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)8)
            {
                //Reader request config from server
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    UInt16 crc, crc2;
                    byte[] data2;
                    var data = BusManagment.Transaction.JTransactions.ProcessOnlineReaderGetConfig(bytes, out crc, out data2, out crc2);
                    if (data == null)
                        BspTcpServer.SendData(client, "No CONFIG");
                    else
                        BspTcpServer.SendData(client, data);
                }
                catch (Exception ex)
                {
                    BspTcpServer.SendData(client, System.Text.Encoding.UTF8.GetBytes(ex.Message));
                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)9)
            {
                //DriverLoginLogout
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    Int64 Index = ClassLibrary.Socket.JSocketManager.GetData(
                        client
                        , bytes
                        , "BusManagment.Transaction.JTransactionOnlineReader.GetClassNameDriverLoginLogout"
                        , 0
                        , BusManagment.Transaction.SocketDataState.OnlineReaderDriverLoginLogout_InProcess.GetHashCode()
                        );
                    if (Index > 0)
                    {
                        BspTcpServer.SendData(
                            client
                            , BusManagment.Transaction.JTransactions.ProcessOnlineReaderDriverLoginLogout(bytes) ?
                                "LOGIN OK"
                                :
                                "LOGIN FALSE"
                            );
                    }
                    else
                    {
                        BspTcpServer.SendData(client, "FALSE");
                    }
                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)10)
            {
                try
                {
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {

                        UInt16 crc, crc2;
                        byte[] data2;
                        var data = BusManagment.Transaction.JTransactions.ProcessOnlineReaderCheckUpdate(bytes, out crc, out data2, out crc2);
                        BspTcpServer.SendData(client, data);
                    }
                    catch (Exception ex)
                    {
                        BspTcpServer.SendData(client, System.Text.Encoding.UTF8.GetBytes(ex.Message));
                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                }
                catch
                {

                }
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)11)
            {
                try
                {

                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    DataTable dt;

                    byte[] bIMEI = new byte[8];
                    Buffer.BlockCopy(bytes, 4, bIMEI, 0, bIMEI.Length);
                    Int64 IMEI = BitConverter.ToInt64(bIMEI, 0);

                    DB.setQuery("Select Distinct imei,Version from AutOnlinereaderPermissionUpdate where imei = " + IMEI + " and uppermission = 1");
                    dt = DB.Query_DataTable();
                    if (IMEI.ToString() == dt.Rows[0]["IMEI"].ToString())
                    {
                        try
                        {

                            byte[] data2;
                            var data = BusManagment.Transaction.JTransactions.ProcessOnlineReaderSendUpdate(bytes, out data2);
                            BspTcpServer.SendData(client, data);
                        }
                        catch (Exception ex)
                        {
                            BspTcpServer.SendData(client, System.Text.Encoding.UTF8.GetBytes(ex.Message));
                        }

                        finally
                        {
                            DB.Dispose();
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else if (bytes[0] == (byte)202 && bytes[1] == (byte)4)
            {
                if (bytes[1] == (byte)4)
                {
                    byte[] NewByte = new byte[bytes.Length - 2];
                    int counter = 0;
                    for (int i = 2; i < bytes.Length; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }

                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery("insert into AUTHandHeldDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        if (DB.Query_Execute() > 0)
                            BspTcpServer.SendData(client, "SAVE OK " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        else
                            BspTcpServer.SendData(client, "FALSE");
                        DB.Query_Execute();

                        //BspTcpS erver.SendData(client, "SAVE OK "+DateTime.Now+"");
                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                }
            }

            else if (bytes[0] == (byte)203 && bytes[1] == (byte)4)
            {
                if (bytes[1] == (byte)4)
                {
                    byte[] NewByte = new byte[bytes.Length - 2];
                    int counter = 0;
                    for (int i = 2; i < bytes.Length; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }

                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery("insert into AUTHandHeldDeviceTicketCityBank(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        DB.Query_Execute();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    BspTcpServer.SendData(client, "SAVE OK");

                    return;
                }
            }
            else if (bytes[0] == (byte)204 && bytes.Length == 18)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    string res = "";
                    int Hour = DateTime.Now.Hour;
                    if (Hour >= 6 & Hour < 22)
                    {
                        byte[] NewByte = new byte[15];
                        string s = Encoding.UTF8.GetString(bytes, 0, bytes.Length).Substring(1);
                        DB.setQuery("select dbo.fngetrtpistextforboard(" + Int64.Parse(s.Substring(1, 15)) + ")");
                        res = DB.Query_DataTable().Rows[0][0].ToString();
                    }
                    byte[] uni = Encoding.UTF8.GetBytes(res);
                    byte[] uni2 = new byte[uni.Length + 7];
                    uni2[0] = 1;
                    uni2[1] = (byte)(uni.Length / 256);
                    uni2[2] = (byte)(uni.Length & 255);
                    UInt32 CheckSum = uni2[1];
                    CheckSum += uni2[2];
                    for (int i = 0; i < uni.Length; i++)
                    {
                        uni2[i + 3] = uni[i];
                        CheckSum += uni[i];
                    }

                    uni2[uni.Length + 3] = (byte)((CheckSum >> 24) & 255);
                    uni2[uni.Length + 4] = (byte)((CheckSum >> 16) & 255);
                    uni2[uni.Length + 5] = (byte)((CheckSum >> 8) & 255);
                    uni2[uni.Length + 6] = (byte)(CheckSum & 255);

                    BspTcpServer.SendData(client, uni2);
                }
                catch
                {

                }
                finally
                {
                    DB.Dispose();
                }
                return;
            }
            else if (bytes[0] == (byte)205 && bytes.Length == 18)
            {
                try
                {
                    string s = Encoding.UTF8.GetString(bytes, 0, bytes.Length).Substring(1);
                    Int64 IMEI = Int64.Parse(s.Substring(2, 15));

                    long b = System.IO.File.GetCreationTime(RTPISFileUpdateName).ToBinary();

                    if (BusManagment.RTPIS.JRTPISUpdate.Find(IMEI, b))
                    {
                        byte[] _temp = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
                        BspTcpServer.SendData(client, _temp);
                    }
                    else
                    {
                        SendDataToRTPIS(bytes[1], client, IMEI);
                    }
                }
                catch
                {
                    byte[] _temp = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
                    BspTcpServer.SendData(client, _temp);
                }
            }

            else
            {
                try
                {
                    if (bytes.Length < 34 || bytes[15] != 100 || !(bytes[33] == 101 || bytes[29] == 101))
                        BspTcpServer.SendData(client, "FALSE");
                    else
                    {
                        Int64 Index = ClassLibrary.Socket.JSocketManager.GetData(client, bytes, "BusManagment.Transaction.JTransactionAVL.GetClassNameBusNumber"
                            , 0, BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode()
                            );
                        if (Index > 0)
                        {
                            BspTcpServer.SendData(client, "OK");
                        }
                        else
                        {
                            BspTcpServer.SendData(client, "FALSE");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }

        string RTPISFileUpdateName = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "RTPISFile") + "\\Tablo.Bin";
        private void SendDataToRTPIS(int PackNumber, System.Net.Sockets.Socket client, Int64 IMEI)
        {
            try
            {
                byte[] b = System.IO.File.ReadAllBytes(RTPISFileUpdateName);
                if (((b.Length + 2047) / 2048) <= PackNumber)
                {
                    BusManagment.RTPIS.JRTPISUpdate RU = new BusManagment.RTPIS.JRTPISUpdate();
                    RU.IMEI = IMEI;
                    RU.Version = System.IO.File.GetCreationTime(RTPISFileUpdateName).ToBinary();
                    RU.Insert();
                    return;
                }
                byte[] bTemp = new byte[2048 + 14];
                int Index = 0;
                int Counter = PackNumber;
                int Len = 0;
                Index = PackNumber * 2048;
                //while (Index < b.Length)
                {
                    if (Index + 2048 < b.Length)
                    {
                        Len = 2048;
                    }
                    else
                    {
                        Len = b.Length - Index;
                        Array.Resize(ref bTemp, Len + 8 + 6);
                    }
                    bTemp[0] = (byte)(((b.Length + 2047) / 2048) / 256);
                    bTemp[1] = (byte)(((b.Length + 2047) / 2048) & 255);

                    bTemp[2] = (byte)(Counter / 256);
                    bTemp[3] = (byte)(Counter & 255);

                    bTemp[4] = (byte)(Len / 256);
                    bTemp[5] = (byte)(Len & 255);

                    Array.Copy(b, Index, bTemp, 6, Len);

                    UInt32 CheckSum = 0;
                    for (int i = 0; i < Len + 6; i++)
                    {
                        CheckSum += bTemp[i];
                    }

                    bTemp[Len + 6] = (byte)((CheckSum >> 24) & 255);
                    bTemp[Len + 7] = (byte)((CheckSum >> 16) & 255);
                    bTemp[Len + 8] = (byte)((CheckSum >> 8) & 255);
                    bTemp[Len + 9] = (byte)(CheckSum & 255);

                    if (Index + 2048 >= b.Length)
                    {
                        CheckSum = 0;
                        for (int i = 0; i < b.Length; i++)
                        {
                            CheckSum += b[i];
                        }
                        bTemp[Len + 10] = (byte)((CheckSum >> 24) & 255);
                        bTemp[Len + 11] = (byte)((CheckSum >> 16) & 255);
                        bTemp[Len + 12] = (byte)((CheckSum >> 8) & 255);
                        bTemp[Len + 13] = (byte)(CheckSum & 255);
                    }

                    if (BspTcpServer.SendData(client, bTemp))
                    {
                        //Index += Len;
                        //Counter++;
                    }
                    else
                        return;
                }
            }
            catch
            {

            }
            finally
            {
            }
            return;

        }

        private readonly object listLock = new object();

        private static Dictionary<Int32, String> IMELList = new Dictionary<Int32, String>();
        public void ReceiveTelTonikaData(object sender, System.Net.Sockets.Socket client, byte[] bytes)
        {
            UInt32 RecivePointCount = 0;
            string IMEI = "";
            IMELList.TryGetValue(client.Handle.ToInt32(), out IMEI);
            if (IMEI == "861359031752148")
                IMEI = "861359031752148";
            if (client == null)
            {
                return;
            }

            if (bytes.Length > 2)
            {
                if (bytes[1] == 15)
                {
                    IMEI = Encoding.ASCII.GetString(bytes, 2, bytes.Length - 2);
                    if (IMEI == "861359031752148")
                        IMEI = "861359031752148";

                    BSPTCPServerTeltonika.SendData(client, new byte[] { 1 });
                    string Temp = "";
                    if (IMELList.TryGetValue(client.Handle.ToInt32(), out Temp))
                        IMELList.Remove(client.Handle.ToInt32());
                    IMELList.Add(client.Handle.ToInt32(), IMEI);
                    return;
                }
                else if (bytes[1] == 0)
                {
                    if (client != null)
                    {

                        if (IMEI == "" || IMEI == null)
                        {
                            BSPTCPServerTeltonika.SendData(client, new byte[4] { 0, 0, 0, 0 });
                            BSPTCPServerTeltonika.Disconnect(client);
                            IMELList.Remove(client.Handle.ToInt32());
                            return;
                        }
                    }

                    Int64 Index = ClassLibrary.Socket.JSocketManager.GetData(
                        client, bytes,
                        "BusManagment.Transaction.JTransactionAVL.GetClassNameBusNumberTeltonika",
                        Int64.Parse(IMEI),
                        BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode());

                    if (Index <= 0)
                    {
                        BSPTCPServerTeltonika.SendData(client, new byte[4] { 0, 0, 0, 0 });
                        BSPTCPServerTeltonika.Disconnect(client);
                        IMELList.Remove(client.Handle.ToInt32());
                        return;
                    }
                    //IMELList.Remove(client.Handle.ToInt32());
                    RecivePointCount = BusManagment.Transaction.JTransactions.ProceddTeltonika(bytes, Int64.Parse(IMEI), Index, false, true);
                }
                else
                {
                    BSPTCPServerTeltonika.SendData(client, new byte[1] { 0 });
                    BSPTCPServerTeltonika.Disconnect(client);
                    IMELList.Remove(client.Handle.ToInt32());
                }
            }
            if (RecivePointCount > 0)
            {
                byte[] temp = BitConverter.GetBytes(RecivePointCount);
                Array.Reverse(temp);
                //var s = temp.ToList().((x, y) => x.ToString("00") + y.ToString("00"));
                //var s = BitConverter.ToString(temp, 0, temp.Length).Replace("-","");
                BSPTCPServerTeltonika.SendData(client, temp);
                //BSPTCPServerTeltonika.Disconnect(client);
                // IMELList.Remove(client.Handle.ToInt32());
            }
            else
            {
                BSPTCPServerTeltonika.SendData(client, new byte[4] { 0, 0, 0, 0 });
                BSPTCPServerTeltonika.Disconnect(client);
                IMELList.Remove(client.Handle.ToInt32());
            }
        }
        private void BspTcpServerTelTonika_OnClientConnect(object sender, System.Net.Sockets.Socket client)
        {

        }

        private void BspTcpServerTelTonika_OnClientDisconnect(object sender, System.Net.Sockets.Socket client)
        {
            IMELList.Remove(client.Handle.ToInt32());
        }

        private void BspTcpServerTelTonika_OnError(object sender, System.Net.Sockets.Socket client, Exception exception)
        {
            ClassLibrary.JSystem.Except.AddException(exception);
        }

        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.Socket client)
        {

        }

        private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.Socket client)
        {
            UpdateTempTables();
        }

        private void BspTcpServer_OnError(object sender, System.Net.Sockets.Socket client, Exception exception)
        {
            ClassLibrary.JSystem.Except.AddException(exception);
        }

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            _TicketThreadOffilne = true;// chkOffline.Checked;
            //if (chkOffline.Checked)
            {
                TicketThreadOffilne.Start();
            }
        }

        private void chkKillSleepCon_CheckedChanged(object sender, EventArgs e)
        {
            _KillSleetConnThread = true;// chkKillSleepCon.Checked;
            //if (chkKillSleepCon.Checked)
            {
                KillSleetConnThread.Start();
            }
        }


        private void CLoseThread(Thread pT, bool _Check)
        {
            _Check = false;
            try
            {
                if (pT.ThreadState == System.Threading.ThreadState.Running)
                {
                    pT.Abort();
                    pT.Join();
                }
            }
            catch { }
        }

        private void AVLServiceClosed(object sender)
        {
            _NoClose = false;

            CLoseThread(AVLThread, _AVLThread);
            CLoseThread(AVLThreadOffLine, _AVLThreadOffLine);
            CLoseThread(AVLThreadTeltonika, _AVLThreadTeltonika);
            CLoseThread(TicketThread, _TicketThread);
            CLoseThread(TicketThreadOffilne, _TicketThreadOffilne);
            CLoseThread(BusUpdateLocationThread, _BusUpdateLocationThread);
            CLoseThread(ShowExceptionThread, _ShowExceptionThread);
            CLoseThread(TransactionPrintCheck, _TransactionPrintCheck);
            CLoseThread(TransactionPrintInsert, _TransactionPrintInsert);
            CLoseThread(TransactionPrintInsertDailyMontly, _TransactionPrintInsertDailyMontly);
            CLoseThread(CalenderRepair, _CalenderRepair);
            CLoseThread(EventLog, _EventLog);
            CLoseThread(EventReaderDetails, _EventLog);
            CLoseThread(EventBazrasLog, _EventLog);
            CLoseThread(EventBusPassingStation, _EventBusPassingStation);
            CLoseThread(SendQuery, _SendQuery);
            CLoseThread(SendMessage, _SendMessage);
        }

        private void chkDistanceMeasurement_CheckedChanged(object sender, EventArgs e)
        {
            _DistanceMeasurement = true;// chkDistanceMeasurement.Checked;
            //if (chkDistanceMeasurement.Checked)
            {
                DistanceMeasurement.Start();
            }
        }

        private void chkTransactionPrintCheck_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintCheck = true;// chkTransactionPrintCheck.Checked;
            //if (chkTransactionPrintCheck.Checked)
            {
                TransactionPrintCheck.Start();
            }
        }

        private void chkTransactionPrintInsert_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintInsert = true;// chkTransactionPrintInsert.Checked;
            //if (chkTransactionPrintInsert.Checked)
            {
                TransactionPrintInsert.Start();
            }
        }

        private void chkTransactionPrintInsertDailyMontly_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintInsertDailyMontly = true;// chkTransactionPrintInsertDailyMontly.Checked;
            //if (chkTransactionPrintInsertDailyMontly.Checked)
            {
                TransactionPrintInsertDailyMontly.Start();
            }
        }

        private void chkCalenderRapir_CheckedChanged(object sender, EventArgs e)
        {
            _CalenderRepair = true;// chkCalenderRapir.Checked;
            //if (chkCalenderRapir.Checked)
            {
                CalenderRepair.Start();
            }
        }

        private void chkSendSMS_CheckedChanged(object sender, EventArgs e)
        {
            _SendSMS = true;// chkSendSMS.Checked;
            //if (chkSendSMS.Checked)
            {
                SendSMS.Start();
            }
        }

        private void chkEventLog_CheckedChanged(object sender, EventArgs e)
        {
            _EventLog = true;// chkEventLog.Checked;
            //if (chkEventLog.Checked)
            {
                EventLog.Start();
            }
        }
        private void chkSendQuery_CheckedChanged(object sender, EventArgs e)
        {
            _SendQuery = true;// chkSendQuery.Checked;
            //if (chkSendQuery.Checked)
            {
                SendQuery.Start();
            }
        }
        private void chkSendMessage_CheckedChanged(object sender, EventArgs e)
        {
            _SendMessage = true;// chkSendQuery.Checked;
            //if (chkSendQuery.Checked)
            {
                SendMessage.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            //    DateTime FDate = Convert.ToDateTime(("2015-01-21 00:00:00").ToString());
            //    DateTime EDate = Convert.ToDateTime(("2015-03-20 00:00:00").ToString());
            //    for (DateTime date = FDate; date <= EDate; date = date.AddDays(1))
            //    {
            //        DB.setQuery("INSERT INTO [dbo].[StaticDates]  ([En_Date],[Fa_Date]) " +
            //                       "VALUES " +
            //                      "('" + date + "', dbo.DateEnToFa('" + date + "') )");
            //        DB.Query_Execute();
            //    }
            //    MessageBox.Show("عملیات با موفقیت انجام شد", "توجه");
            //}
            //catch (Exception ex) { MessageBox.Show("درج با خطا مواجه شد", "هشدار"); }
        }

        private void chkTicketHandHeldTransaction_CheckedChanged(object sender, EventArgs e)
        {
            _TicketHandHeldThread = true;// chkTicketHandHeldTransaction.Checked;
            //if (chkTicketHandHeldTransaction.Checked)
            {
                TicketHandHeldThread.Start();
            }

        }

        private void chkServiceProcess_CheckedChanged(object sender, EventArgs e)
        {
            _ServiceProcess = true;// chkServiceProcess.Checked;
            //if (chkServiceProcess.Checked)
            {
                ServiceProcess.Start();
            }
        }

        private static ClassLibrary.JDataBase DataBaseUpdateTemptables;

        private void UpdateTempTables()
        {
        }


        private string convert_from_unicode(string str)
        {
            string rtstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length - i < 4)
                {
                    rtstr += str.Substring(i, str.Length - i);
                    break;
                }
                if (str[i] == '\\' && str[i + 1] == 'u')
                {
                    string m = str.Substring(i + 2, 4);
                    try
                    {
                        rtstr += (char)Int16.Parse(m, System.Globalization.NumberStyles.HexNumber);
                    }
                    catch
                    {
                        rtstr += m;
                    }
                    i += 5;
                }
                else
                {
                    rtstr += str[i];
                }
            }
            return rtstr;

        }

        private void AnswerRtpisSMSFunction()
        {
            while (_AnswerRtpisSMS)
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");
                    request.Timeout = 100000;

                    request.Method = "POST";
                    string postData = "op=inboxlist&uname=tcco&pass=4077223";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    System.Threading.Thread.Sleep(1000);
                    dataStream.Close();

                    WebResponse response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    responseFromServer = responseFromServer.Replace("\\\\", "\\");
                    if (responseFromServer.Length > 10)
                    {
                        string[] messages = responseFromServer.Replace("[0,\"[{\\\"message\\\":\\\"", "").Split(new string[] { "\\\"},{\\\"message\\\":\\\"" }, StringSplitOptions.None);
                        string CostFrom = "\\\",\\\"from\\\":\\\"";
                        string ToFrom = "\\\",\\\"to\\\":\\\"";
                        string TimeFrom = "\\\",\\\"time\\\":\\\"";

                        foreach (string message in messages)
                        {
                            int StartFromIndex = message.IndexOf(CostFrom);
                            int StartToIndex = message.IndexOf(ToFrom);
                            int StartTimeIndex = message.IndexOf(TimeFrom);

                            string Text = convert_from_unicode(message.Substring(0, StartFromIndex));
                            string From = convert_from_unicode(message.Substring(StartFromIndex + CostFrom.Length, StartToIndex - (StartFromIndex + CostFrom.Length))).Replace("+98", "0");
                            string To = convert_from_unicode(message.Substring(StartToIndex + ToFrom.Length, StartTimeIndex - (StartToIndex + ToFrom.Length)));
                            string Time = convert_from_unicode(message.Substring(StartTimeIndex + TimeFrom.Length, 23)).Replace("\\", "");

                            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
                            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                            try
                            {
                                ClassLibrary.SMS.JSMSesReceived SG = new ClassLibrary.SMS.JSMSesReceived();
                                SG.Sender_Number = From;
                                SG.Sender_PersonCode = 0;
                                SG.SMS_Text = Text;
                                DateTime SendDate;
                                if (DateTime.TryParse(Time, out SendDate))
                                    SG.Send_Date = SendDate;
                                else
                                    SG.Send_Date = DateTime.Now;
                                SG.Service_Read_Date = DateTime.Now;

                                SG.Insert();

                                DB.setQuery("select dbo.FnGetRTPISTextForBoardWithCode_WebTest(" + Text + ")");
                                string res = DB.Query_ExecutSacler().ToString();
                                ClassLibrary.JSMSSend SS = new ClassLibrary.JSMSSend();
                                SS.Text = res;
                                SS.Mobile = From;
                                SS.ClassName = "SMSToRTPISPerson";
                                SS.SendDevice = 3;
                                SS.Insert();
                            }
                            finally
                            {
                                C.Dispose();
                                DB.Dispose();
                            }
                        }
                    }
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                    request = null;
                    System.Threading.Thread.Sleep(1000);
                }

                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
        }

        private void CityBankOutPUTFileFunction()
        {
            while (_CityBankOutPUTFile)
            {

                System.Threading.Thread.Sleep(400);
                if (DateTime.Now.ToString("HH:mm:ss") == "23:59:59")
                {
                    BusManagment.Transaction.JTransactions.CityBankOutPUTFile(
                       "2",
                       DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"))
                       ,
                       DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"))
                       );
                    BusManagment.Transaction.JTransactions.CityBankOutPUTFile(
                       "3",
                       DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"))
                       ,
                       DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"))
                       );
                }
            }
        }

        public void CheckCityBankcsrNewFile()
        {
            while (_CheckCityBankcsrNewFile)
            {
                try
                {

                    string dir = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "CityBankFiles");

                    string[] myFiles = System.IO.Directory.GetFiles(dir, "*.csr");
                    foreach (string S in myFiles)
                    {
                        try
                        {
                            if (CheckCityBankcsr(S))
                                File.Delete(S);
                            else
                                File.Move(S, Path.ChangeExtension(S, ".ERROR"));
                        }
                        catch (Exception ex)
                        {
                            ClassLibrary.JMainFrame.Except.AddException(ex);
                        }
                    }
                    System.Threading.Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    ClassLibrary.JMainFrame.Except.AddException(ex);
                }
            }
        }
        public static bool CheckCityBankcsr(string pFileName)
        {
            bool ret = true;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string[] Responses = File.ReadAllLines(pFileName);
                string SQL = "";
                int Count = 0;
                foreach (string Res in Responses)
                {
                    try
                    {
                        //W; 497430027; 10; 15403556; 180508; 145446; 000395255289; 00; FDED; 2A9BE6E5; M150002
                        string[] R = Res.Split(new char[] { ';' });
                        if (R.Length == 11)
                        {
                            Int64 Code = Int64.Parse(R[1]);
                            int ResponseCityBank = int.Parse(R[7]);
                            SQL += "Update AUTTicketTransactionCityBank set CityBankResponse=" + ResponseCityBank + " where isnull(CityBankResponse,-1)<>0 and Code=" + Code + ";" + Environment.NewLine;
                            Count++;
                            if (Count >= 50)
                            {
                                DB.setQuery(SQL);
                                DB.Query_Execute();
                                if (DB.Error)
                                    ret = false;
                                Count = 0;
                                SQL = "";
                            }
                        }
                    }
                    catch
                    {
                        ret = false;
                    }
                }
                if (Count >= 1)
                {
                    DB.setQuery(SQL);
                    DB.Query_Execute();
                    if (DB.Error)
                        ret = false;
                    Count = 0;
                    SQL = "";
                }

            }
            catch (Exception ex)
            {
                ret = false;
            }
            finally
            {
                DB.Dispose();
            }
            return ret;
        }

    }
}
