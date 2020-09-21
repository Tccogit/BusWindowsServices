using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace BusManagment.Transaction
{
    public class JTicketTransactions
    {
        public static bool AddTicketTransaction(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db)
        {
            return AddTicketTransaction(TH, TT, recordNumber, Header_IMEI, Header_BusSerial, Header_Version, db, 0, false);
        }

        public static bool AddTicketTransaction(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db, int ArchiveContentCode = 0)
        {
            return AddTicketTransaction(TH, TT, recordNumber, Header_IMEI, Header_BusSerial, Header_Version, db, ArchiveContentCode, false);
        }

        public static bool AddTicketTransaction(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db, int ArchiveContentCode = 0, bool pThread = false)
        {
            if (pThread)
                db = new ClassLibrary.JDataBase();
            try
            {
                db.Params.Clear();
                if (db.Params.Count > 0)
                {
                    db.Params.Remove("recordNumber");
                    db.Params.Remove("TransactionID");
                    db.Params.Remove("LineNumber");
                    db.Params.Remove("BusSerial");
                    db.Params.Remove("DriverSerialCard");
                    db.Params.Remove("PassengerCardSerial");
                    db.Params.Remove("CardType");
                    db.Params.Remove("EventDate");
                    db.Params.Remove("TicketPrice");
                    db.Params.Remove("ReaderID");
                    db.Params.Remove("RemainPrice");
                    db.Params.Remove("IMEI");
                    db.Params.Remove("VERSION");
                    db.Params.Remove("Bin");
                    db.Params.Remove("TerminalID");
                    db.Params.Remove("WaletID");
                    db.Params.Remove("CType");
                    db.Params.Remove("LTD");
                    db.Params.Remove("ServerMac");
                    db.Params.Remove("MacOut");
                    db.Params.Remove("LTB");
                    db.Params.Remove("Counter");
                    db.Params.Remove("ServerID");
                    db.Params.Remove("CardVersion");

                }

                string date = (new DateTime(TH.DATE.Year, TH.DATE.Month, TH.DATE.Day, TT.Time[0], TT.Time[1], TT.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");



                db.setQuery(@"EXEC SP_InsertAUTTicketTransaction
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
                        @DriverSerialCard2,
	                    @PassengerCardSerial,
                        @PassengerCardSerial2,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION,
                        @Bin,
                        @TerminalID,
                        @WaletID,
                        @CType,
                        @LTD,
                        @ServerMac,
                        @ServerMac2,
                        @MacOut,
                        @MacOut2,
                        @LTB,
                        @Counter,
                        @ServerID,
                        @BankType,
                        @CardVersion");

                db.AddParams("recordNumber", recordNumber);
                db.AddParams("TransactionID", Convert.ToInt64(TT.transactionid));
                db.AddParams("LineNumber", Convert.ToInt32(TH.LineNumber));
                db.AddParams("BusSerial", Convert.ToDouble(TH.busSerial.ToString().Replace('-', '.')));
                //
                UInt64 DriverSerialCard = Convert.ToUInt64(TH.DriverSerialCard);
                Int64 DriverSerialCard1 = 0;
                Int64 DriverSerialCard2 = 0;
                if (DriverSerialCard > Int64.MaxValue)
                {
                    DriverSerialCard1 = (Int64)(DriverSerialCard % Int64.MaxValue);
                    DriverSerialCard2 = 1;
                }
                else
                {
                    DriverSerialCard1 = Convert.ToInt64(TH.DriverSerialCard);
                    DriverSerialCard2 = 0;
                }
                db.AddParams("DriverSerialCard", DriverSerialCard1);
                db.AddParams("DriverSerialCard2", DriverSerialCard2);
                //
                UInt64 PassengerCardSerial = Convert.ToUInt64(TT.PassengerCardSerial);
                Int64 PassengerCardSerial1 = 0;
                Int64 PassengerCardSerial2 = 0;
                if (PassengerCardSerial > Int64.MaxValue)
                {
                    PassengerCardSerial1 = (Int64)(PassengerCardSerial % Int64.MaxValue);
                    PassengerCardSerial2 = 1;
                }
                else
                {
                    PassengerCardSerial1 = Convert.ToInt64(TT.PassengerCardSerial);
                    PassengerCardSerial2 = 0;
                }
                db.AddParams("PassengerCardSerial", PassengerCardSerial1);
                db.AddParams("PassengerCardSerial2", PassengerCardSerial2);
                //END
                db.AddParams("CardType", Convert.ToInt32(TT.CardType));
                db.AddParams("EventDate", date);
                db.AddParams("TicketPrice", Convert.ToInt32(TT.TicketPrice));
                db.AddParams("ReaderID", Convert.ToInt32(TT.ReaderID));
                db.AddParams("RemainPrice", Convert.ToInt32(TT.RemainPrice));
                db.AddParams("IMEI", Convert.ToInt64(Header_IMEI));
                db.AddParams("VERSION", Header_Version);
                db.AddParams("Bin", TT.Bin);
                db.AddParams("TerminalID", Convert.ToInt64(TT.TerminalID));
                db.AddParams("WaletID", TT.WaletID);
                db.AddParams("CType", TT.CType);
                db.AddParams("LTD", Convert.ToInt32(TT.LTD));
                //start1

                UInt64 ServerMac = Convert.ToUInt64(TT.ServerMac);
                Int64 ServerMac1 = 0;
                Int64 ServerMac2 = 0;
                if (ServerMac > Int64.MaxValue)
                {
                    ServerMac1 = (Int64)(ServerMac % Int64.MaxValue);
                    ServerMac2 = 1;
                }
                else
                {
                    ServerMac1 = Convert.ToInt64(TT.ServerMac);
                    ServerMac2 = 0;
                }
                db.AddParams("ServerMac", Convert.ToInt64(ServerMac1));
                db.AddParams("ServerMac2", Convert.ToInt64(ServerMac2));
                //end1
                //start2

                UInt64 MacOut = Convert.ToUInt64(TT.MacOut);
                Int64 MacOut1 = 0;
                Int64 MacOut2 = 0;
                if (MacOut > Int64.MaxValue)
                {
                    MacOut1 = (Int64)(MacOut % Int64.MaxValue);
                    MacOut2 = 1;
                }
                else
                {
                    MacOut1 = Convert.ToInt64(TT.MacOut);
                    MacOut2 = 0;
                }
                db.AddParams("MacOut", Convert.ToInt64(MacOut1));
                db.AddParams("MacOut2", Convert.ToInt64(MacOut2));
                //end221
                db.AddParams("LTB", TT.LTB);

                db.AddParams("Counter", Convert.ToInt32(TT.Counter));
                db.AddParams("ServerID", Convert.ToInt32(TT.ServerID));
                db.AddParams("BankType", Convert.ToInt32(TT.BankType));
                db.AddParams("CardVersion", Convert.ToInt32(TT.CardVersion));

                db.CommandTimeout = 60;
                if (db.Query_Execute(pThread) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                //if (pThread)
                //db.Dispose();
            }
            return true;
        }

        public static void AddTicketTransaction(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version
            , ref System.Data.DataTable pDT)
        {
            try
            {
                if (pDT == null)
                {
                    pDT = new System.Data.DataTable("List");
                    pDT.Columns.Add("recordNumber", typeof(Int64));
                    pDT.Columns.Add("TransactionID", typeof(Int32));
                    pDT.Columns.Add("LineNumber", typeof(float));
                    pDT.Columns.Add("BusSerial", typeof(Int64));
                    pDT.Columns.Add("DriverCardSerial", typeof(Int64));
                    pDT.Columns.Add("DriverCardSerial2", typeof(Int64));
                    pDT.Columns.Add("PassengerCardSerial", typeof(Int64));
                    pDT.Columns.Add("PassengerCardSerial2", typeof(Int64));
                    pDT.Columns.Add("CardType", typeof(int));
                    pDT.Columns.Add("EventDate", typeof(DateTime));
                    pDT.Columns.Add("TicketPrice", typeof(Int32));
                    pDT.Columns.Add("ReaderID", typeof(byte));
                    pDT.Columns.Add("RemainPrice", typeof(Int32));
                    pDT.Columns.Add("IMEI", typeof(Int64));
                    pDT.Columns.Add("VERSION", typeof(byte[]));
                    pDT.Columns.Add("Bin", typeof(byte));
                    pDT.Columns.Add("TerminalID", typeof(Int64));
                    pDT.Columns.Add("WaletID", typeof(byte));
                    pDT.Columns.Add("CType", typeof(byte));
                    pDT.Columns.Add("LTD", typeof(Int32));
                    pDT.Columns.Add("ServerMac", typeof(Int64));
                    pDT.Columns.Add("ServerMac2", typeof(Int64));
                    pDT.Columns.Add("MacOut", typeof(Int64));
                    pDT.Columns.Add("MacOut2", typeof(Int64));
                    pDT.Columns.Add("LTB", typeof(byte));
                    pDT.Columns.Add("Counter", typeof(int));
                    pDT.Columns.Add("ServerID", typeof(Int32));
                    pDT.Columns.Add("BankType", typeof(Int32));
                    pDT.Columns.Add("CardVersion", typeof(byte));
                }

                string date = (new DateTime(TH.DATE.Year, TH.DATE.Month, TH.DATE.Day, TT.Time[0], TT.Time[1], TT.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");


                Dictionary<string, object> Params = new Dictionary<string, object>();

                Params.Add("recordNumber", recordNumber);
                Params.Add("TransactionID", Convert.ToInt64(TT.transactionid));
                Params.Add("LineNumber", Convert.ToInt32(TH.LineNumber));
                Params.Add("BusSerial", Convert.ToDouble(TH.busSerial.ToString().Replace('-', '.')));
                //
                UInt64 DriverSerialCard = Convert.ToUInt64(TH.DriverSerialCard);
                Int64 DriverSerialCard1 = 0;
                Int64 DriverSerialCard2 = 0;
                if (DriverSerialCard > Int64.MaxValue)
                {
                    DriverSerialCard1 = (Int64)(DriverSerialCard % Int64.MaxValue);
                    DriverSerialCard2 = 1;
                }
                else
                {
                    DriverSerialCard1 = Convert.ToInt64(TH.DriverSerialCard);
                    DriverSerialCard2 = 0;
                }
                Params.Add("DriverSerialCard", DriverSerialCard1);
                Params.Add("DriverSerialCard2", DriverSerialCard2);
                //
                UInt64 PassengerCardSerial = Convert.ToUInt64(TT.PassengerCardSerial);
                Int64 PassengerCardSerial1 = 0;
                Int64 PassengerCardSerial2 = 0;
                if (PassengerCardSerial > Int64.MaxValue)
                {
                    PassengerCardSerial1 = (Int64)(PassengerCardSerial % Int64.MaxValue);
                    PassengerCardSerial2 = 1;
                }
                else
                {
                    PassengerCardSerial1 = Convert.ToInt64(TT.PassengerCardSerial);
                    PassengerCardSerial2 = 0;
                }
                Params.Add("PassengerCardSerial", PassengerCardSerial1);
                Params.Add("PassengerCardSerial2", PassengerCardSerial2);
                Params.Add("CardType", Convert.ToInt32(TT.CardType));
                Params.Add("EventDate", date);
                Params.Add("TicketPrice", Convert.ToInt32(TT.TicketPrice));
                Params.Add("ReaderID", Convert.ToInt32(TT.ReaderID));
                try
                {
                    Params.Add("RemainPrice", Convert.ToInt32(TT.RemainPrice));
                }
                catch
                {
                    Params.Add("RemainPrice", 0);
                }
                Params.Add("IMEI", Convert.ToInt64(Header_IMEI));
                Params.Add("VERSION", Header_Version);
                Params.Add("Bin", TT.Bin);
                try
                {
                    Params.Add("TerminalID", Convert.ToInt64(TT.TerminalID));
                }
                catch
                {

                }
                Params.Add("WaletID", TT.WaletID);
                Params.Add("CType", TT.CType);
                
                Params.Add("LTD", Convert.ToInt32(TT.LTD));

                UInt64 ServerMac = Convert.ToUInt64(TT.ServerMac);
                Int64 ServerMac1 = 0;
                Int64 ServerMac2 = 0;
                if (ServerMac > Int64.MaxValue)
                {
                    ServerMac1 = (Int64)(ServerMac % Int64.MaxValue);
                    ServerMac2 = 1;
                }
                else
                {
                    ServerMac1 = Convert.ToInt64(TT.ServerMac);
                    ServerMac2 = 0;
                }
                Params.Add("ServerMac", Convert.ToInt64(ServerMac1));
                Params.Add("ServerMac2", Convert.ToInt64(ServerMac2));
                //end1
                //start2

                UInt64 MacOut = Convert.ToUInt64(TT.MacOut);
                Int64 MacOut1 = 0;
                Int64 MacOut2 = 0;
                if (MacOut > Int64.MaxValue)
                {
                    MacOut1 = (Int64)(MacOut % Int64.MaxValue);
                    MacOut2 = 1;
                }
                else
                {
                    MacOut1 = Convert.ToInt64(TT.MacOut);
                    MacOut2 = 0;
                }
                Params.Add("MacOut", Convert.ToInt64(MacOut1));
                Params.Add("MacOut2", Convert.ToInt64(MacOut2));
                //end221
                Params.Add("LTB", TT.LTB);

                Params.Add("Counter", Convert.ToInt32(TT.Counter));
                Params.Add("ServerID", Convert.ToInt32(TT.ServerID));
                Params.Add("BankType", Convert.ToInt32(TT.BankType));
                Params.Add("CardVersion", Convert.ToInt32(TT.CardVersion));

                pDT.Rows.Add(Params.Values.ToArray());

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }


        public static bool AddTicketTransactionManual(ClassLibrary.JDataBase db, Int64 recordNumber, int TransactionID, int LineNumber, int BusSerial, Int64 DriverSerialCard, Int64 PassengerCardSerial
            , int CardType, int TicketPrice, int ReaderID, int RemainPrice, Int64 IMEI, byte[] VERSION
            , DateTime pEventDate, bool pThread = false)
        {
            if (pThread)
                db = new ClassLibrary.JDataBase();
            try
            {
                db.Params.Clear();
                if (db.Params.Count > 0)
                {
                    db.Params.Remove("recordNumber");
                    db.Params.Remove("TransactionID");
                    db.Params.Remove("LineNumber");
                    db.Params.Remove("BusSerial");
                    db.Params.Remove("DriverSerialCard");
                    db.Params.Remove("PassengerCardSerial");
                    db.Params.Remove("CardType");
                    db.Params.Remove("EventDate");
                    db.Params.Remove("TicketPrice");
                    db.Params.Remove("ReaderID");
                    db.Params.Remove("RemainPrice");
                    db.Params.Remove("IMEI");
                    db.Params.Remove("VERSION");
                    db.Params.Remove("Bin");
                    db.Params.Remove("TerminalID");
                    db.Params.Remove("WaletID");
                    db.Params.Remove("CType");
                    db.Params.Remove("LTD");
                    db.Params.Remove("ServerMac");
                    db.Params.Remove("MacOut");
                    db.Params.Remove("LTB");
                    db.Params.Remove("Counter");
                    db.Params.Remove("ServerID");
                }

                string date = pEventDate.ToString("yyyy-MM-dd HH:mm:ss");

                db.setQuery(@"EXEC SP_InsertAUTTicketTransaction
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
	                    @PassengerCardSerial,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION
                        ");

                db.AddParams("recordNumber", recordNumber);
                db.AddParams("TransactionID", Convert.ToInt64(TransactionID));
                db.AddParams("BusSerial", BusSerial);
                db.AddParams("DriverSerialCard", DriverSerialCard);

                db.AddParams("PassengerCardSerial", PassengerCardSerial);
                db.AddParams("CardType", Convert.ToInt32(CardType));
                db.AddParams("EventDate", date);
                db.AddParams("TicketPrice", TicketPrice);
                db.AddParams("ReaderID", ReaderID);
                db.AddParams("RemainPrice", RemainPrice);
                db.AddParams("IMEI", IMEI);
                db.AddParams("VERSION", VERSION);
                db.AddParams("LineNumber", LineNumber);


                db.CommandTimeout = 60;
                if (db.Query_Execute(pThread) > 0)
                {
                    return true;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                //if (pThread)
                //db.Dispose();
            }
            return true;
        }

        static Semaphore[] semaphore = new Semaphore[10000];

        public static void Serialize(DataSet ds, Stream stream)
        {
            try
            {
                if (stream == null)
                    stream = new MemoryStream();
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, ds);
            }
            catch (Exception ex)
            {

            }
        }

        public static DataSet Deserialize(Stream stream)
        {
            try
            {
                BinaryFormatter serializer = new BinaryFormatter();
                stream.Position = 0;
                return (DataSet)serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void WriteDataTableToFile(DataTable pDT, string pFileName, bool IsTicket = true, bool toTemp = false)
        {
            try
            {
                string DataTableSubPath = "DataTable" + (IsTicket ? "Ticket" : "AVL");
                if (toTemp)
                    DataTableSubPath += "\\temp";
                MemoryStream StremDT = new MemoryStream();
                DataSet DS = new DataSet();
                DS.Tables.Add(pDT);
                Serialize(DS, StremDT);
                string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), DataTableSubPath) + "\\" + pFileName;
                FileStream F = new FileStream(DataTableTicket, FileMode.Create);
                StremDT.WriteTo(F);
                StremDT.Close();
                StremDT.Dispose();
                F.Close();
                F.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        public static void ReadDataTableFromFile(string[] pFileName, int pCount, bool IsTicket = true)
        {
            try
            {
                int Count = 0;
                DataTable DT = null;
                foreach (string FileName in pFileName)
                {
                    if (Count > pCount)
                        break;
                    Count++;
                    if (File.Exists(FileName))
                    {
                        MemoryStream StremDT = new MemoryStream();
                        try
                        {
                            FileStream F = new FileStream(FileName, FileMode.Open);
                            F.Seek(0, SeekOrigin.Begin);
                            F.CopyTo(StremDT);
                            try
                            {
                                if (DT == null)
                                    DT = Deserialize(StremDT).Tables[0].Copy();
                                else
                                    DT.Merge(Deserialize(StremDT).Tables[0].Copy());
                            }
                            catch
                            {
                            }
                            finally
                            {
                                F.Close();
                                F.Dispose();
                                StremDT.Dispose();
                                System.IO.File.Delete(FileName);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {

                        }
                    }
                }
                if (IsTicket && DT != null)
                    AddTicket(ref DT, "");
                else
                    BusManagment.AVL.JAVLTransactions.AddAVL(ref DT, "");
            }
            catch (Exception ex)
            {

            }
        }
        public static void ReadDataTableFromFile(string pFileName, bool IsTicket = true)
        {
            try
            {
                if (!File.Exists(pFileName))
                    return;
                MemoryStream StremDT = new MemoryStream();
                FileStream F = new FileStream(pFileName, FileMode.Open);
                F.Seek(0, SeekOrigin.Begin);
                F.CopyTo(StremDT);
                DataTable DT = Deserialize(StremDT).Tables[0].Copy();

                F.Close();
                F.Dispose();
                StremDT.Dispose();
                System.IO.File.Delete(pFileName);
                if (IsTicket)
                {
                    AddTicket(ref DT, "");
                }
                else
                    BusManagment.AVL.JAVLTransactions.AddAVL(ref DT, "");
            }
            catch (Exception ex)
            {

            }
        }

        public static void Deleted(string pFileName, bool IsTicket = true)
        {
            try
            {
                string DataTableSubPath = "DataTable" + (IsTicket ? "Ticket" : "AVL");
                string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), DataTableSubPath) + "\\" + pFileName;
                System.IO.File.Delete(DataTableTicket);
            }
            catch
            {

            }
        }

        public static void ProcessOldFileTicketDataTable(bool IsTicket = true)
        {
            try
            {
                string DataTableSubPath = "DataTable" + (IsTicket ? "Ticket" : "AVL");
                string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), DataTableSubPath);
                DirectoryInfo info = new DirectoryInfo(DataTableTicket);
                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                string[] File = new string[500];
                int Count = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    DateTime T = System.IO.File.GetLastWriteTime(files[i].FullName);
                    if (System.IO.File.Exists(files[i].FullName) && DateTime.Now.Subtract(T).TotalMinutes > 10)
                    {
                        long length = new System.IO.FileInfo(files[i].FullName).Length;

                        if (length >= 1024 * 1000)
                            ReadDataTableFromFile(files[i].FullName, IsTicket);
                        else
                        {
                            if (Count > 0 && Count % 500 == 0)
                            {
                                ReadDataTableFromFile(File, Count, IsTicket);
                                Count = 0;
                            }
                            File[i % 500] = files[i].FullName;
                            Count++;
                        }
                    }

                }
                if (Count > 0)
                {
                    ReadDataTableFromFile(File, Count, IsTicket);
                }
            }
            catch(Exception ex)
            {
                string DataTableSubPath = "DataTable" + (IsTicket ? "Ticket" : "AVL");
                string DataTableTicket = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), DataTableSubPath);
                System.IO.File.AppendAllText(DataTableTicket + Path.DirectorySeparatorChar + "Error.txt", Environment.NewLine + ex.Message);
            }
        }

        public static Semaphore semaphoreAddTicket = new Semaphore(500, 500);
        public static int AddTicketCountIsRun = 0;

        //public static bool AddTicket(ref System.Data.DataTable pDT, string pErrorCommand, bool pCheckPassenger = true)
        //{
        //}

        public static bool AddTicket(ref System.Data.DataTable pDT, string pErrorCommand, bool pCheckPassenger = true)
        {

            if (pDT == null || pDT.Rows.Count == 0)
                return true;
            string fileName = Guid.NewGuid().ToString();
            WriteDataTableToFile(pDT, fileName);
            semaphoreAddTicket.WaitOne();
            AddTicketCountIsRun++;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            int BusSerial = 0;
            try
            {
                if (pDT.Rows.Count >= 1)
                    int.TryParse(pDT.Rows[0]["BusSerial"].ToString(), out BusSerial);
                if (BusSerial >= 0 && BusSerial < 10000)
                {
                    if (semaphore[BusSerial] == null)
                    {
                        semaphore[BusSerial] = new Semaphore(1, 1);
                    }
                    semaphore[BusSerial].WaitOne();
                }

                int pageNum = 1;
                int pageSize = (pDT.Rows.Count + 1) / 2;
                while (true)
                {
                    DataTable dtPage = null;
                    try
                    {
                        dtPage = pDT.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                    }
                    catch
                    {
                        break;
                    }
                    if (dtPage == null || dtPage.Rows.Count == 0)
                        break;
                    DateTime T;
                    for (int i=0; i< dtPage.Rows.Count;i++)
                    {
                        if(!DateTime.TryParse( dtPage.Rows[i]["EventDate"].ToString(), out T) || T.Year < 2000)
                        {
                            dtPage.Rows[i].Delete();
                            dtPage.AcceptChanges();
                            i--;
                        }
                    }

                    db.DataTypesName = "dbo.AUTTicketTransactionList";
                      if (pCheckPassenger)
                        db.setQuery(@"EXEC SP_InsertAUTTicketTransactionWithDataTable @List");
                    else
                        db.setQuery(@"EXEC SP_InsertAUTTicketTransactionWithDataTableWithOutPassengerCheck @List");
                    db.Params.Remove("@List");
                    db.AddParams("@List", dtPage);
                    db.CommandTimeout = 60 + 5 * dtPage.Rows.Count;
                    db.Query_Execute();
                    if (db.Error == false)
                    {
                    }
                    else
                    {
                        string NewfileName = "Error_" + Guid.NewGuid().ToString();
                        WriteDataTableToFile(dtPage, NewfileName, true, dtPage.Rows.Count <= 1);
                    }
                    IEnumerable<DataRow> DR = pDT.Rows.Cast<System.Data.DataRow>().Skip(pageNum * pageSize);
                    if (DR != null && DR.Count() > 0)
                    {

                        pDT = DR.Take(DR.Count()).CopyToDataTable();
                        string NewfileName = Guid.NewGuid().ToString();
                        WriteDataTableToFile(pDT, NewfileName);
                        Deleted(fileName);
                        fileName = NewfileName;
                        System.Threading.Thread.Sleep(1);
                    }
                    else
                    {
                        pDT.Clear();
                        Deleted(fileName);
                        break;
                    }
                }
                pDT.Clear();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (AddTicketCountIsRun > 0)
                {
                    AddTicketCountIsRun--;
                }
                try
                {
                    semaphoreAddTicket.Release();
                }
                catch
                {

                }
                Deleted(fileName);
                if (BusSerial >= 0 && BusSerial < 10000)
                {
                    semaphore[BusSerial].Release();
                }
                db.Dispose();
            }

        }

        public static int GetLinePrice(string LineNumber, DateTime EventDate)
        {
            int Res = 0;
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            try
            {
                Db.setQuery(@"select Price from AUTPrice where LineCode = " + LineNumber + @"
                            and '" + EventDate.ToString("yyyy/MM/dd") + "' >= StartDate and '" + EventDate.ToString("yyyy/MM/dd") + "' <= EndDate Order By StartDate Desc");
                System.Data.DataTable Dt = Db.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        Res = Convert.ToInt32(Dt.Rows[0]["Price"].ToString());
                    }
                }
            }
            finally
            {
                Db.Dispose();
            }
            return Res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TH"></param>
        /// <param name="TT"></param>
        /// <param name="recordNumber"></param>
        /// <param name="Header_IMEI"></param>
        /// <param name="Header_BusSerial"></param>
        /// <param name="Header_Version"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool AddTicketTransactionExtract(DataTable pDT, int ArchiveContentCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();

            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                db.Params.Remove("recordNumber");
                db.Params.Remove("TransactionID");
                db.Params.Remove("LineNumber");
                db.Params.Remove("BusSerial");
                db.Params.Remove("DriverSerialCard");
                db.Params.Remove("PassengerCardSerial");
                db.Params.Remove("CardType");
                db.Params.Remove("EventDate");
                db.Params.Remove("TicketPrice");
                db.Params.Remove("ReaderID");
                db.Params.Remove("RemainPrice");
                db.Params.Remove("IMEI");
                db.Params.Remove("VERSION");
            }
            try
            {
                int Count = 0;
                string sql = "";
                foreach (DataRow dr in pDT.Rows)
                {
                    try
                    {
                        Count++;
                        sql += @"INSERT INTO ExtractedTickets
                            (
	                            recordNumber,
	                            TransactionID,
	                            LineNumber,
	                            BusSerial,
	                            DriverSerialCard,
	                            PassengerCardSerial,
	                            CardType,
	                            EventDate,
	                            TicketPrice,
	                            ReaderID,
	                            RemainPrice,
	                            IMEI,
	                            VERSION
                            )
                            VALUES
                            (
	                    @recordNumber" + Count + @",
	                    @TransactionID" + Count + @",
	                    @LineNumber" + Count + @",
	                    @BusSerial" + Count + @",
	                    @DriverSerialCard" + Count + @",
	                    @PassengerCardSerial" + Count + @",
	                    @CardType" + Count + @",
	                    @EventDate" + Count + @",
	                    @TicketPrice" + Count + @",
	                    @ReaderID" + Count + @",
	                    @RemainPrice" + Count + @",
	                    @IMEI" + Count + @",
	                    @VERSION" + Count + @");";

                        db.AddParams("recordNumber" + Count, dr["recordNumber"]);
                        db.AddParams("TransactionID" + Count, dr["TransactionID"]);
                        db.AddParams("LineNumber" + Count, dr["LineNumber"]);
                        db.AddParams("BusSerial" + Count, dr["BusSerial"]);
                        db.AddParams("DriverSerialCard" + Count, dr["DriverCardSerial"]);
                        db.AddParams("PassengerCardSerial" + Count, dr["PassengerCardSerial"]);
                        db.AddParams("CardType" + Count, dr["CardType"]);
                        db.AddParams("EventDate" + Count, dr["EventDate"]);
                        db.AddParams("TicketPrice" + Count, dr["TicketPrice"]);
                        db.AddParams("ReaderID" + Count, dr["ReaderID"]);
                        db.AddParams("RemainPrice" + Count, dr["RemainPrice"]);
                        db.AddParams("IMEI" + Count, dr["IMEI"]);
                        db.AddParams("VERSION" + Count, dr["VERSION"]);

                        if (Count >= 50)
                        {
                            db.setQuery(sql);
                            db.Query_Execute();
                            sql = "";
                            db.Params.Clear();
                            Count = 0;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (Count > 0)
                {
                    db.setQuery(sql);
                    db.Query_Execute();
                }
                try
                {
                    InsertBusOfflineFilesRecordInDb(ArchiveContentCode, pDT);
                }
                catch
                {
                }

            }
            catch (Exception ex)
            {
                ex.Source += "BusManagment.Transaction.JTicketTransaction.AddTicketTransactionExtract";
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return true;
        }

        public static void InsertBusOfflineFilesRecordInDb(int ArchiveContentCode, DataTable pDT)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                string sql = "";
                int count = 0;
                db.AddParams("ArchiveContentCode", ArchiveContentCode);
                foreach (DataRow dr in pDT.Rows)
                {
                    count++;
                    sql += @"INSERT INTO ArchiveContentExtracted
                            (
                                ArchiveContentCode,
	                            recordNumber,
	                            TransactionID,
	                            LineNumber,
	                            BusSerial,
	                            DriverSerialCard,
	                            PassengerCardSerial,
	                            CardType,
	                            EventDate,
	                            TicketPrice,
	                            ReaderID,
	                            RemainPrice,
	                            IMEI,
	                            VERSION
                            )
                            VALUES
                            (
                        @ArchiveContentCode,
	                    @recordNumber" + count + @",
	                    @TransactionID" + count + @",
	                    @LineNumber" + count + @",
	                    @BusSerial" + count + @",
	                    @DriverSerialCard" + count + @",
	                    @PassengerCardSerial" + count + @",
	                    @CardType" + count + @",
	                    @EventDate" + count + @",
	                    @TicketPrice" + count + @",
	                    @ReaderID" + count + @",
	                    @RemainPrice" + count + @",
	                    @IMEI" + count + @",
	                    @VERSION" + count + @");";
                    db.AddParams("recordNumber" + count, dr["recordNumber"]);
                    db.AddParams("TransactionID" + count, dr["TransactionID"]);
                    db.AddParams("LineNumber" + count, dr["LineNumber"]);
                    db.AddParams("BusSerial" + count, dr["BusSerial"]);
                    db.AddParams("DriverSerialCard" + count, dr["DriverCardSerial"]);
                    db.AddParams("PassengerCardSerial" + count, dr["PassengerCardSerial"]);
                    db.AddParams("CardType" + count, dr["CardType"]);
                    db.AddParams("EventDate" + count, dr["EventDate"]);
                    db.AddParams("TicketPrice" + count, dr["TicketPrice"]);
                    db.AddParams("ReaderID" + count, dr["ReaderID"]);
                    db.AddParams("RemainPrice" + count, dr["RemainPrice"]);
                    db.AddParams("IMEI" + count, dr["IMEI"]);
                    db.AddParams("VERSION" + count, dr["VERSION"]);

                    if (count >= 50)
                    {
                        db.setQuery(sql);
                        db.Query_Execute();
                        db.Params.Clear();
                        db.AddParams("ArchiveContentCode", ArchiveContentCode);
                        count = 0;
                        sql = "";
                    }
                }
                if (count > 0)
                {
                    db.setQuery(sql);
                    db.Query_Execute();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                db.Dispose();
            }
        }




        public static void TransactionPrintCheckDataTicketForAllPrinterReport(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            //            return;
            //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start Update Shifti Daily From MySql " + DateTime.Now.ToLongTimeString()));


            //            db.setQuery(@"select top 1000 Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
            //                                        where [ShiftDriverCode] > 0 and [State] = 0
            //                                        order by Code desc");
            //            System.Data.DataTable DtPrinterReport = db.Query_DataTable();
            //            if (DtPrinterReport != null)
            //            {
            //                if (DtPrinterReport.Rows.Count > 0)
            //                {
            //                    for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
            //                    {
            //                        try
            //                        {
            //                            MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
            //                            System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
            //                            if (DtMyDqlGetDataTicket != null)
            //                            {
            //                                if (DtMyDqlGetDataTicket.Rows.Count > 0)
            //                                {
            //                                    db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
            //                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
            //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());

            //                                    //                                    db.setQuery(@"select ISNULL(sum(TCount),-1)TCount from [dbo].[AUTDailyPerformanceRportOnBus]
            //                                    //                                                where BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
            //                                    //                                                      And [Date] = cast('" + DtPrinterReport.Rows[i]["FDate"].ToString() + @"' as date)
            //                                    //                                                      And FirstTicketDate >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
            //                                    //                                                      And LastTicketDate <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
            //                                    db.setQuery(@"SELECT sum(Tcount)TCount
            //                                                                  FROM [dbo].[AUTShiftDriver]
            //                                                                  where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
            //                                                                  and 
            //                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
            //                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
            //                                    System.Data.DataTable DtSumTransaction = db.Query_DataTable();
            //                                    if (DtSumTransaction != null && Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) > -1)
            //                                    {
            //                                        if (DtSumTransaction.Rows.Count > 0)
            //                                        {
            //                                            if (Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) == Convert.ToInt32(DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString()))
            //                                            {
            //                                                db.setQuery(@"Update [AUTShiftDriver] set [SetPrinter] = 1  where 
            //                                                                  BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
            //                                                                  and 
            //                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
            //                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
            //                                                db.Query_Execute();
            //                                            }

            //                                            //                                            db.setQuery(@"Update [AUTPrinterRporte] set [GetTicket] = 1,[State] = 1,[RequestCount]= IsNull(RequestCount,0) + 1 where 
            //                                            //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
            //                                            //                                            db.Query_Execute();

            //                                            //                                            db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
            //                                            //                                                            [TCount]  = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
            //                                            //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
            //                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
            //                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))
            //                                            //                                                          , Price = ((" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
            //                                            //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
            //                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
            //                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) * TicketPrice) 
            //                                            //															from AUTDailyPerformanceRportOnBus b
            //                                            //                                                           where DocumentCode = 0 and Code = " + DtPrinterReport.Rows[i]["DailyCode"].ToString() + @"
            //                                            //                                                            and (" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
            //                                            //                                                            (select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
            //                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
            //                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) >= 0");
            //                                            //                                            db.Query_Execute();
            //                                            //                                            db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
            //                                            //                                                            [TCount]  = 0  , Price = 0
            //                                            //                                                            where DocumentCode = 0 and BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
            //                                            //                                                            and FirstTicketDate > '" + DtPrinterReport.Rows[i]["StartDate"].ToString() +
            //                                            //                                                            "' AND LastTicketDate < '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
            //                                            //                                            db.Query_Execute();

            //                                            db.setQuery(@"Update [AUTWorkedDay] set [Active] = 1 where Date = '"
            //                                               + DtPrinterReport.Rows[i]["FDate"].ToString() + "'");
            //                                            db.Query_Execute();
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        catch
            //                        {

            //                        }
            //                    }
            //                }
            //            }
            //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End Update Shifti Daily From MySql " + DateTime.Now.ToLongTimeString()));
        }


        public static void TransactionPrintCheckDataTicket(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb, DateTime InsertDate)
        {
            //            return;
            //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start TransactionPrintCheckDataTicket " + DateTime.Now.ToLongTimeString()));

            //            //db.setQuery(@"select Date from AutWorkedDay where Active = 1 and Date > = '" + InsertDate.ToString("yyyy-MM-dd") + "' order by Date Desc");
            //            //System.Data.DataTable DtWorkedDay = db.Query_DataTable();
            //            //DateTime ProcDate = DateTime.Now;
            //            //if (DtWorkedDay != null)
            //            //{
            //            //    if (DtWorkedDay.Rows.Count > 0)
            //            //    {
            //            //        for (int WD = 0; WD < DtWorkedDay.Rows.Count; WD++)
            //            //        {

            //            // ProcDate = Convert.ToDateTime(DtWorkedDay.Rows[WD]["Date"].ToString());


            //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start UpdateAUTDailyPerformanceRportOnBus For " +
            //            //    ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

            //            //db.setQuery("EXEC UpdateAUTDailyPerformanceRportOnBus @ProcessDate");
            //            //db.Params.Clear();
            //            //if (db.Params.Count > 0)
            //            //{
            //            //    db.Params.Remove("ProcessDate");
            //            //}
            //            //db.AddParams("ProcessDate", ProcDate);
            //            //db.Query_Execute();

            //            //ClassLibrary.JSystem.Except.AddException(new Exception("END UpdateAUTDailyPerformanceRportOnBus For " +
            //            //    ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

            //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintCheckDataTicket For " +
            //            //    ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

            //            db.setQuery(@"select Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
            //                                        where [ShiftDriverCode] > 0 and [State] = 0
            //                                        order by Code desc");
            //            System.Data.DataTable DtPrinterReport = db.Query_DataTable();
            //            if (DtPrinterReport != null)
            //            {
            //                if (DtPrinterReport.Rows.Count > 0)
            //                {
            //                    for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
            //                    {
            //                        try
            //                        {
            //                            MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
            //                            System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
            //                            if (DtMyDqlGetDataTicket != null)
            //                            {
            //                                if (DtMyDqlGetDataTicket.Rows.Count > 0)
            //                                {
            //                                    db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
            //                                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
            //                                                             Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
            //                                    db.Query_Execute();
            //                                    db.setQuery(@"SELECT sum(Tcount)TCount
            //                                                                  FROM [dbo].[AUTShiftDriver]
            //                                                                  where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
            //                                                                  and 
            //                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
            //                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
            //                                    System.Data.DataTable DtSumTransaction = db.Query_DataTable();
            //                                    if (DtSumTransaction != null && Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) > -1)
            //                                    {
            //                                        if (DtSumTransaction.Rows.Count > 0)
            //                                        {
            //                                            if (Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) == Convert.ToInt32(DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString()))
            //                                            {
            //                                                db.setQuery(@"Update [AUTShiftDriver] set [SetPrinter] = 1 
            //                                                                            where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" 
            //                                                                            and Error = 0 and CardType = 0
            //                                                                            and 
            //                                                                            ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
            //                                                                            and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
            //                                                db.Query_Execute();
            //                                            }
            //                                            //db.setQuery(@"Update [AUTWorkedDay] set [Active] = 1 where Date = '"
            //                                            //   + DtPrinterReport.Rows[i]["FDate"].ToString() + "'");
            //                                            //db.Query_Execute();
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        catch
            //                        {

            //                        }
            //                    }
            //                }
            //            }

            //            //if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour < 2)
            //            //{
            //            //    ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsert " + DateTime.Now.ToLongTimeString()));
            //            //    TransactionPrintInsert(db, MySqlDb, InsertDate);
            //            //    ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionPrintInsert " + DateTime.Now.ToLongTimeString()));
            //            //}



            //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start UpdateAUTDailyPerformanceRportOnBus For " +
            //            //    DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

            //            //db.setQuery("EXEC UpdateAUTDailyPerformanceRportOnBus @ProcessDate");
            //            //db.Params.Clear();
            //            //if (db.Params.Count > 0)
            //            //{
            //            //    db.Params.Remove("ProcessDate");
            //            //}
            //            //db.AddParams("ProcessDate", DateTime.Now);
            //            //db.Query_Execute();

            //            //ClassLibrary.JSystem.Except.AddException(new Exception("End UpdateAUTDailyPerformanceRportOnBus For " +
            //            //    DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));



            //            //        }
            //            //    }
            //            //}

            //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** END TransactionPrintCheckDataTicket" + DateTime.Now.ToLongTimeString()));
        }

        //        public static void TransactionDailyPrintUpdateFromMySql(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionDailyPrintUpdateFromMySql For " + DateTime.Now.ToLongTimeString()));

        //            db.setQuery(@"select Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
        //                                        where [DailyCode] = 0 and [State] = 0 and [ShiftDriverCode] = 0
        //                                        and RequestDate > DATEADD(month,-1,getdate())
        //                                        order by Code desc");
        //            System.Data.DataTable DtPrinterReport = db.Query_DataTable();
        //            if (DtPrinterReport != null)
        //            {
        //                if (DtPrinterReport.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
        //                    {
        //                        try
        //                        {
        //                            MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent`,`state` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString());// + @" and `state` = 1");
        //                            System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
        //                            if (DtMyDqlGetDataTicket != null)
        //                            {
        //                                if (DtMyDqlGetDataTicket.Rows.Count > 0 && int.Parse(DtMyDqlGetDataTicket.Rows[0]["state"].ToString()) == 1)
        //                                {
        //                                    db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
        //                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
        //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
        //                                    db.Query_Execute();
        //                                    System.Threading.Thread.Sleep(50);

        //                                }
        //                                else
        //                                {
        //                                    if (DtMyDqlGetDataTicket.Rows.Count == 0)
        //                                    {
        //                                        SavePrintInMySql(MySqlDb, (int)DtPrinterReport.Rows[i]["Code"],
        //                                            Convert.ToInt32(DtPrinterReport.Rows[i]["BusNumber"].ToString()),
        //                                            Convert.ToDateTime(Convert.ToDateTime(DtPrinterReport.Rows[i]["StartDate"].ToString()).ToShortDateString() + " 00:00:00"),
        //                                            Convert.ToDateTime(Convert.ToDateTime(DtPrinterReport.Rows[i]["EndDate"].ToString()).ToShortDateString() + " 23:59:59"));
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        catch { }
        //                    }
        //                }
        //            }

        //ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionDailyPrintUpdateFromMySql For " + DateTime.Now.ToLongTimeString()));
        //}

        //        public static void TransactionPrintInsertForBeforeMonth(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            db.setQuery(@"select BusNumber,count(*)c from AUTTicketTransaction where eventdate between '2014-03-21 00:00:00' and '2014-05-21 23:59:59'
        //                            and Len(BusNumber)=4 and BusNumber < 5999
        //                            group by BusNumber
        //                            having count(*) > 20
        //                            order by c");
        //        }

        //        public static void TransactionPrintInsert(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb, DateTime InsertDate)
        //        {
        //            return;
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsert" + DateTime.Now.ToLongTimeString()));
        //            int SqlLastInsertCode;
        //            //            db.setQuery(@"select adprob.[Code],adprob.[Date],adprob.[BusCode],ab.BusNumber as BusNumber,adprob.[CardType],adprob.[DriverPersonCode],
        //            //                           adprob.[DriverCardSerial],
        //            //                           adprob.[LineNumber],adprob.[TicketPrice],adprob.[Price],adprob.[TCount],adprob.[DocumentCode],adprob.[OwnerCode],adprob.[IsHoliDay],
        //            //                           adprob.[FirstTicketDate],adprob.[LastTicketDate],adprob.[FirstAvlDate],
        //            //                           adprob.[LastAvlDate],adprob.[FrontDoor],adprob.[BackDoor],adprob.[SetPrinter],adprob.[InsertPrintRequest] 
        //            //                           from AUTDailyPerformanceRportOnBus adprob
        //            //                           Left Join AutBus ab on adprob.BusCode = ab.Code
        //            //                           where adprob.SetPrinter = 0 and adprob.InsertPrintRequest = 0 and adprob.CardType = 0 
        //            //                           and (adprob.[Date] >= '" + InsertDate.ToShortDateString() + @"' and adprob.[Date] < cast(getdate() as date))
        //            //                           and adprob.FirstTicketDate is not null and adprob.LastTicketDate is not null
        //            //                           Order By adprob.[Date] Desc");
        //            db.setQuery(@"SELECT max([Code])Code,[BusNumber],[Startdate],[Enddate]
        //                              FROM [dbo].[AUTShiftDriver]
        //                              where [InsertPrintRequest] = 0 and SetPrinter = 0 and Error = 0 and CardType = 0
        //                              and cast(Startdate as date) < cast(getdate() as date)
        //                              group by [BusNumber],[Startdate],[Enddate]
        //                              order by Code Desc");
        //            System.Data.DataTable DtDailyTicket = db.Query_DataTable();
        //            if (DtDailyTicket != null)
        //            {
        //                if (DtDailyTicket.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
        //                    {
        //                        BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();

        //                        if (!TransactionPrint.GetShiftDriverData(Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                            Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
        //                            Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString())))
        //                        {
        //                            TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
        //                            TransactionPrint.StartDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString());
        //                            TransactionPrint.EndDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString());
        //                            TransactionPrint.TicketCount = 0;
        //                            TransactionPrint.TicketSent = 0;
        //                            TransactionPrint.State = 0;
        //                            TransactionPrint.DailyCode = 0;
        //                            TransactionPrint.ShiftDriverCode = Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString());

        //                            SqlLastInsertCode = TransactionPrint.Insert();

        //                            SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
        //                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
        //                            UpdateInserPrintInShift(db, Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString()));

        //                        }
        //                        else
        //                        {
        //                            TransactionPrint.StartDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString());
        //                            TransactionPrint.EndDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString());
        //                            TransactionPrint.State = 0;

        //                            TransactionPrint.Update();
        //                            SqlLastInsertCode = TransactionPrint.Code;
        //                            if (GetMySqlData(MySqlDb, SqlLastInsertCode))
        //                            {
        //                                UpdatePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                                    Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                                    Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
        //                                    Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
        //                            }
        //                            else
        //                            {
        //                                SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
        //                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
        //                            }
        //                            UpdateInserPrintInShift(db, Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString()));
        //                        }
        //                    }
        //                }
        //            }
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionPrintInsert" + DateTime.Now.ToLongTimeString()));
        //        }

        //        public static void TransactionPrintInsertMonthly(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsertMonthly " + DateTime.Now.ToLongTimeString()));

        //            System.Globalization.PersianCalendar PersCal = new System.Globalization.PersianCalendar();
        //            if (PersCal.GetDayOfMonth(DateTime.Now) == 1)
        //            {
        //                int SqlLastInsertCode;
        //                db.setQuery(@"select ab.BUSNumber,convert(varchar(7),adp.[Date],120)YearMonth,cast((convert(varchar(7),adp.[Date],120)+'-01') as date)SMonth,
        //                                dateadd(day,-1,dateadd(month,1,cast((convert(varchar(7),adp.[Date],120)+'-01') as date)))EMonth
        //                                from AUTDailyPerformanceRportOnBus adp
        //                                left join AutBus ab on adp.BusCode = ab.Code
        //                                where adp.MonthlyPrint = 0
        //                                and ab.BUSNumber IS NOT NULL
        //                                group by ab.BUSNumber,convert(varchar(7),adp.[Date],120),cast((convert(varchar(7),adp.[Date],120)+'-01') as date)
        //                                order by SMonth desc");
        //                System.Data.DataTable DtDailyTicket = db.Query_DataTable();
        //                if (DtDailyTicket != null)
        //                {
        //                    if (DtDailyTicket.Rows.Count > 0)
        //                    {
        //                        BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
        //                        for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
        //                        {

        //                            TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
        //                            TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["SMonth"].ToString()).ToShortDateString() + " 00:00:00");
        //                            TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["EMonth"].ToString()).ToShortDateString() + " 23:59:59");
        //                            TransactionPrint.TicketCount = 0;
        //                            TransactionPrint.TicketSent = 0;
        //                            TransactionPrint.State = 0;
        //                            TransactionPrint.DailyCode = 0;
        //                            SqlLastInsertCode = TransactionPrint.Insert();

        //                            SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                                Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["SMonth"].ToString()).ToShortDateString() + " 00:00:00"),
        //                                Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["EMonth"].ToString()).ToShortDateString() + " 23:59:59"));

        //                            db.setQuery(@"update AUTDailyPerformanceRportOnBus set MonthlyPrint = 1 where BusCode = (select code from AutBus where BusNumber = " + DtDailyTicket.Rows[i]["BusNumber"].ToString() + @") and convert(varchar(7),[Date],120) = '" + DtDailyTicket.Rows[i]["YearMonth"].ToString() + @"'");
        //                            db.Query_Execute();
        //                        }
        //                    }
        //                }
        //            }

        //            //ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionPrintInsertMonthly " + DateTime.Now.ToLongTimeString()));
        //        }

        //        public static void TransactionPrintInsertDaily(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            return;
        //            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsertDailyMontly " + DateTime.Now.ToLongTimeString()));
        //            int SqlLastInsertCode;
        //            db.setQuery(@"select BusNumber,cast(startdate as date)FDate from AUTShiftDriver
        //							where DailyPrint = 0
        //							and cast(startdate as date) < cast(getdate() as date)
        //                            and BusNumber IS NOT NULL and LEN(BusNumber)=4 and BusNumber < 6999
        //							group by BusNumber,cast(startdate as date)
        //                            order by FDate desc");
        //            System.Data.DataTable DtDailyTicket = db.Query_DataTable();
        //            if (DtDailyTicket != null)
        //            {
        //                if (DtDailyTicket.Rows.Count > 0)
        //                {
        //                    BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
        //                    for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
        //                    {

        //                        TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
        //                        TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00");
        //                        TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59");
        //                        TransactionPrint.TicketCount = 0;
        //                        TransactionPrint.TicketSent = 0;
        //                        TransactionPrint.State = 0;
        //                        TransactionPrint.DailyCode = 0;
        //                        SqlLastInsertCode = TransactionPrint.Insert();

        //                        SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                            Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
        //                            Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00"),
        //                            Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59"));

        //                        db.setQuery(@"update AUTShiftDriver set DailyPrint = 1 where BusNumber = " + DtDailyTicket.Rows[i]["BusNumber"].ToString() + @" and cast(startdate as date) = cast('" + DtDailyTicket.Rows[i]["FDate"].ToString() + @"' as date)");
        //                        db.Query_Execute();

        //                    }
        //                }
        //            }
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionPrintInsertDailyMontly " + DateTime.Now.ToLongTimeString()));
        //        }

        //        public static void TransactionDailyPrintCheck(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionDailyPrintCheck" + DateTime.Now.ToLongTimeString()));

        //            db.setQuery(@"select [Code],[BusNumber],[StartDate],[EndDate]
        //                            ,[TicketCount],[TicketSent],[State],
        //                            [GetTicket],[DailyCode],ISNULL([RequestCount] ,0)RequestCount
        //                            from AUTPrinterRporte 
        //                            where cast(StartDate as time) = '00:00:00' and cast(EndDate as time) = '23:59:59' and cast(StartDate as date) = cast(EndDate as date)
        //                            and State = 1 and DailyCode = 0 and GetTicket = 0 and StartDate < Dateadd(day,-2,GetDate())
        //                            and (BusNumber > 1000 and BusNumber < 7000)
        //                            Order By StartDate desc");
        //            System.Data.DataTable DtDailyPrint = db.Query_DataTable();
        //            if (DtDailyPrint != null)
        //            {
        //                if (DtDailyPrint.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < DtDailyPrint.Rows.Count; i++)
        //                    {
        //                        System.Threading.Thread.Sleep(10);
        //                        db.setQuery(@"select adp.Date,ab.BusNumber,Sum(Tcount)Tcount from AUTDailyPerformanceRportOnBus adp
        //                                        left join AutBus ab on ab.Code = adp.BusCode
        //                                        where adp.CardType = 0 and ab.BusNumber = " + DtDailyPrint.Rows[i]["BusNumber"].ToString() + @" and adp.Date = 
        //                                        cast('" + DtDailyPrint.Rows[i]["StartDate"].ToString() + @"' as date)
        //                                        group by adp.Date,ab.BusNumber");
        //                        System.Data.DataTable DtSumDailyTable = db.Query_DataTable();
        //                        if (DtSumDailyTable != null)
        //                        {
        //                            if (DtSumDailyTable.Rows.Count > 0)
        //                            {
        //                                if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) == Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
        //                                {
        //                                    db.setQuery(@"Update AUTPrinterRporte set DailyCode = -3,RequestCount = 0 where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
        //                                    db.Query_Execute();
        //                                }
        //                                else if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) > Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
        //                                {
        //                                    db.setQuery(@"Update AUTPrinterRporte set DailyCode = -2,RequestCount = IsNull(RequestCount,0) + 1 where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
        //                                    db.Query_Execute();
        //                                }
        //                                else if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) < Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
        //                                {
        //                                    if (Convert.ToInt32(DtDailyPrint.Rows[i]["RequestCount"].ToString()) <= 2)
        //                                    {
        //                                        db.setQuery(@"Update AUTPrinterRporte set DailyCode = -1,RequestCount = IsNull(RequestCount,0) + 1,GetTicket=1  where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
        //                                        db.Query_Execute();

        //                                        try
        //                                        {
        //                                            MySqlDb.setQuery(@"UPDATE `getdataticket` SET 
        //                                                                                            `state`=0,
        //                                                                                            `isSent`=1,
        //                                                                                            `GetTicket`=1
        //                                                                                            WHERE `Code` = " + DtDailyPrint.Rows[i]["Code"].ToString());
        //                                            MySqlDb.Query_Execute();
        //                                        }
        //                                        catch(Exception ex)
        //                                        {

        //                                        }

        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            //ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionDailyPrintCheck" + DateTime.Now.ToLongTimeString()));
        //        }

        //        public static bool DeleteDuplicatePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB)
        //        {
        //            mysqlDB.setQuery(@"delete from `getdataticket` where code in
        //                                (
        //                                select Code from(
        //                                SELECT a2.Code FROM `getdataticket` a1 inner join
        //                                `getdataticket` a2
        //                                on
        //                                a1.`busserial` = a2.`busserial`
        //                                and a1.Code<>a2.Code
        //                                and a1.StartDate<=a2.StartDate and a1.EndDate>=a2.EndDate
        //                                and time(a1.StartDate)<>'00:00:00'
        //                                and time(a1.Enddate)<>'23:59:59'
        //                                and a2.State=0
        //                                group by a2.Code
        //                                ) as a
        //                                )");
        //            return mysqlDB.Query_Execute() >= 0 ? true : false;
        //        }

        //        public static bool DeleteDuplicatePrintInSqlServer(ClassLibrary.JDataBase DB)
        //        {
        //            DB.setQuery(@"delete from AUTPrinterRporte where code in
        //                            (
        //                            select Code from(
        //                            SELECT a2.Code FROM AUTPrinterRporte a1 inner join
        //                            AUTPrinterRporte a2
        //                            on
        //                            a1.BusNumber = a2.BusNumber
        //                            and a1.Code<>a2.Code
        //                            and a1.StartDate<=a2.StartDate and a1.EndDate>=a2.EndDate
        //                            and cast(a1.StartDate as time)<>'00:00:00'
        //                            and cast (a1.Enddate as time)<>'23:59:59'
        //                            and a2.State=0
        //                            group by a2.Code
        //                            ) as a
        //                            )");
        //            return DB.Query_Execute() >= 0 ? true : false;
        //        }

        //        public static bool SavePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate)
        //        {
        //            try
        //            {
        //                mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
        //                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
        //                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"',0,0,0)");
        //                return mysqlDB.Query_Execute() >= 0 ? true : false;
        //            }
        //            catch
        //            {
        //                return false;
        //            }
        //        }

        public static bool GetMySqlData(ClassLibrary.JMySQLDataBase MySqlDB, int Code)
        {
            try
            {
                MySqlDB.setQuery("select * from `getdataticket` where `Code` = " + Code.ToString());
                MySqlDB.Query_DataTable();
                if (MySqlDB.datatable.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                MySqlDB.Dispose();
            }
        }

        public static bool GetMySqlData(ClassLibrary.JMySQLDataBase MySqlDB, int BusSerial, DateTime startdate, DateTime enddate)
        {
            try
            {
                MySqlDB.setQuery("select * from `getdataticket` where `busserial` = " + BusSerial + " and `startdate` = '" + startdate + "' and `enddate` = '" + enddate + "'");
                MySqlDB.Query_DataTable();
                if (MySqlDB.datatable.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                MySqlDB.Dispose();
            }
        }

        public static bool UpdatePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate)
        {
            mysqlDB.setQuery(@"UPDATE `getdataticket` SET 
                                `busserial`=" + BusNumber + @",
                                `state`=0,
                                `startdate`='" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
                                `enddate`='" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"',
                                `isSent`=0,
                                `RowCount`=0,
                                `RowSent`=0
                                WHERE `Code` = " + Code.ToString());
            return mysqlDB.Query_Execute() >= 0 ? true : false;
        }

        public static bool UpdateInserPrintInDaily(ClassLibrary.JDataBase sqlDB, int Code)
        {
            sqlDB.setQuery(@"Update AUTDailyPerformanceRportOnBus set InsertPrintRequest = 1 where Code = " + Code);
            return sqlDB.Query_Execute() >= 0 ? true : false;
        }

        public static bool UpdateInserPrintInShift(ClassLibrary.JDataBase sqlDB, int Code)
        {
            return false;
            sqlDB.setQuery(@"Update AUTShiftDriver set InsertPrintRequest = 1 where Code = " + Code);
            return sqlDB.Query_Execute() >= 0 ? true : false;
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Transaction.JTicketTransactions.GetWebQuery", "ticket.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string CardTypePermitionSql = ClassLibrary.JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql.Length < 5)
            {
                CardTypePermitionSql = "";
            }
            else
            {
                ClassLibrary.JDataBase mydb = new ClassLibrary.JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                System.Data.DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and ticket.CardType in (" + String.Join(",", ClassLibrary.JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                mydb.Dispose();
            }

            return @"SELECT top 100   ticket.Code
                              ,bus.BUSNumber
                              ,ticket.LineNumber
                              ,ticket.TicketPrice
                              ,ticket.RemainPrice
                              ,ticket.EventDate
                              ,ticket.RecievedDate
                              ,ticket.DriverCardSerial
                              ,ticket.DriverPersonName
                              ,ticket.PassengerCardSerial
                              ,N'نامشخص' AS PassengerName
                        FROM   AUTTicketTransaction ticket
                               INNER JOIN AUTBus bus
                                    ON  bus.Code = ticket.BusCode
                                where 1 = 1 " + PermitionSql + @"
                                Order by ticket.Code desc";
        }


    }
}
