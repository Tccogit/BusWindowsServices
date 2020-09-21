using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.TransactionPublic
{
    public enum JTransactionErrorType
    {
        UnknownHeader = 1,
        InvalidSizeOfBytes = 2,
        TimeHourOutOfRange = 10,
        TimeMinuteOutOfRange = 11,
        TimeSecondOutOfRange = 12,
        DateYearOutOfRange = 13,
        DateMonthOutOfRange = 14,
        DateDayOutOfRange = 15,
    }

    public enum JTransactionType
    {
        TicketHeader = 1,//بلیط اتوبوس
        TicketData = 2,
        AVLHeder = 100,
        AVLData = 101,
        //DriverLogin = 3 ,
        //DriverLogout = 4 ,
        //StartService = 5 ,
        //EndOfService = 6 ,
    }

    struct BusTicketRecord
    {
        public byte[] Data;
        public Int64 RecordNumber;
        public Int64 Code;
    }


    public class JTransactionHeader
    {
        public string IMEI;//8
        public UInt32 busSerial;//4
        public byte[] VERSION;//3

        #region Properties
        public List<JTransactionTicketHeader> TicketHeaders = new List<JTransactionTicketHeader>();
        public List<JTransactionAVLHeader> AVLHeaders = new List<JTransactionAVLHeader>();
        public string Error = "";
        public int ErrorNum = 0;
        #endregion

        public JTransactionHeader()
        {

        }

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 11)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":H:" + (pData.Length - pStart).ToString() + "/15";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(pData, pStart + 0, bIMEI, 0, 8);
                this.IMEI = BitConverter.ToInt64(bIMEI, 0).ToString();
                pOldData.AddRange(bIMEI);

                byte[] bVERSION = new byte[3];
                Buffer.BlockCopy(pData, pStart + 8, bVERSION, 0, 3);
                this.VERSION = bVERSION;
                pOldData.AddRange(bVERSION);
            }

            return new Tuple<int, string, int, List<byte>>(8 + 3 + pStart, err, errNum, pOldData);
        }

    }


    public class JTransactionTicketHeader
    {
        public DateTime DATE; // 3
        public string DriverSerialCard; // 4
        public uint LineNumber; // 2
        public UInt32 busSerial; // 2
        public UInt16 ReaderID;//1

        public List<JTransactionTicket> Tickets = new List<JTransactionTicket>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 12)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":TH:" + (pData.Length - pStart).ToString() + "/12";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] bDate = new byte[3];
                Buffer.BlockCopy(pData, pStart + 0, bDate, 0, 3);
                this.DATE = JTransactions.ConvertBytesToDateTime(bDate);
                pOldData.AddRange(bDate);

                byte[] bDriverSerialCard = new byte[4];
                Buffer.BlockCopy(pData, pStart + 3, bDriverSerialCard, 0, 4);
                this.DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0).ToString();
                pOldData.AddRange(bDriverSerialCard);

                byte[] bLineNumber = new byte[2];
                Buffer.BlockCopy(pData, pStart + 7, bLineNumber, 0, 2);
                this.LineNumber = BitConverter.ToUInt16(pData, pStart + 7);
                try
                {
                    pOldData.AddRange(BitConverter.GetBytes(Convert.ToInt16(this.LineNumber)).Take(2));
                }
                catch
                {
                    pOldData.AddRange(new byte[] { bLineNumber[0], bLineNumber[1] });
                }
                //pOldData.AddRange(bLineNumber);

                try
                {
                    byte[] bbusSerial = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 9, bbusSerial, 0, 3);
                    this.busSerial = (uint)bbusSerial[0] * 100 + (uint)bbusSerial[1];//Convert.ToUInt32(GetString(pData, pStart + 9, 3));
                    this.ReaderID = (UInt16)bbusSerial[2];
                    //BitConverter.ToUInt32(bbusSerial, 0);
                    pOldData.AddRange(new byte[] { bbusSerial[0], bbusSerial[1], bbusSerial[2] });
                    //pOldData.AddRange(bbusSerial);
                }
                catch
                {

                }
            }

            return new Tuple<int, string, int, List<byte>>(3 + 4 + 2 + 3 + pStart, err, errNum, pOldData);
        }

        public string GetString(byte[] Data, int Index, int Length)
        {
            string Result = "";
            for (int i = Index; i < Index + Length; i++)
            {
                if (Data[i] < 10)
                    Result += '0';
                Result += Data[i].ToString();
            }
            return Result;
        }

    }

    public class JTransactionTicket
    {
        public ulong PassengerCardSerial;//4
        public uint CardType;           //1
        public int[] Time;              //3
        public uint TicketPrice;	    //2
        public uint RemainPrice;	    //2

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":T:" + (pData.Length - pStart).ToString() + "/17";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] bPassengerCardSerial = new byte[4];
                Buffer.BlockCopy(pData, pStart + 0, bPassengerCardSerial, 0, 4);
                this.PassengerCardSerial = BitConverter.ToUInt64(bPassengerCardSerial, 0);
                pOldData.AddRange(bPassengerCardSerial);

                byte[] bCardType = new byte[1];
                Buffer.BlockCopy(pData, pStart + 4, bCardType, 0, 1);
                this.CardType = Convert.ToUInt32(bCardType.First());
                pOldData.AddRange(bCardType);

                byte[] bTime = new byte[3];
                Buffer.BlockCopy(pData, pStart + 5, bTime, 0, 3);
                this.Time = JTransactions.ConvertBytesToTime(bTime);
                pOldData.AddRange(bTime);

                byte[] bTicketPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 8, bTicketPrice, 0, 2);
                this.TicketPrice = BitConverter.ToUInt16(bTicketPrice, 0);
                pOldData.AddRange(bTicketPrice);

                byte[] bRemainPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 10, bRemainPrice, 0, 2);
                this.RemainPrice = BitConverter.ToUInt16(bRemainPrice, 0);
                pOldData.AddRange(bRemainPrice);

            }

            return new Tuple<int, string, int, List<byte>>(4 + 1 + 3 + 2 + 2 + pStart, err, errNum, pOldData);
        }

    }

    public class JTransactionTicketOffline
    {
        public UInt64 PassengerID;       //7
        public UInt64 DriverID;          //7    14
        public UInt32 DateTime;      //4      18
        public UInt32 BusID;             //3    21
        public UInt32 LineNumber;        //3    24 
        public UInt32 RemaningPrice;     //3    27
        public UInt16 Price;             //2    29
        public uint CardType;          //0.5    29.5
        public uint ReaderID;          //0.5    30
        public uint CheckSum;           //2     32

        public JTransactionTicketOffline()
        {
        }

        public Tuple<int> SetValueOffline(byte[] pData, int pStart)
        {
            try
            {

                //memcpy(&info.Pasenger_ID, data.data(), 7);
                //index += 7;
                //info.Pasenger_ID = info.Pasenger_ID>>8;

                //memcpy(&info.Driver_ID, data.data()+index, 7);
                //index += 7;
                //info.Driver_ID = info.Driver_ID>>8;

                //memcpy(&info.Datetime, data.data()+index, 4);
                //index += 4;

                //memcpy(&info.Bus_ID, data.data()+index, 3);
                //index += 3;
                //info.Bus_ID = info.Bus_ID>>8;

                //memcpy(&info.Line_Number, data.data()+index, 3);
                //index += 3;
                //info.Line_Number = info.Line_Number>>8;

                //memcpy(&info.RemainingPrice, data.data()+index, 3);
                //index += 3;
                //info.RemainingPrice = info.RemainingPrice>>8;

                //memcpy(&info.Price, data.data()+index, 2);
                //index += 2;

                //memcpy(&tmp8, data.data()+index, 1);
                //info.CardType  = (tmp8 & 0b00001111);
                //info.Reader_ID = (tmp8 & 0b11110000)>>4;


                byte[] bPassengerID = new byte[8];
                Buffer.BlockCopy(pData, pStart + 0, bPassengerID, 0, 7);
                this.PassengerID = BitConverter.ToUInt64(bPassengerID, 0) >> 8;

                byte[] bDriverID = new byte[8];
                Buffer.BlockCopy(pData, pStart + 7, bDriverID, 0, 7);
                this.DriverID = BitConverter.ToUInt64(bDriverID, 0) >> 8;

                byte[] bDataTime = new byte[4];
                Buffer.BlockCopy(pData, pStart + 14, bDataTime, 0, 4);
                this.DateTime = BitConverter.ToUInt32(bDataTime, 0);

                byte[] bBusID = new byte[4];
                Buffer.BlockCopy(pData, pStart + 18, bBusID, 0, 3);
                this.BusID = BitConverter.ToUInt32(bBusID, 0) >> 8;

                byte[] bLineNumber = new byte[4];
                Buffer.BlockCopy(pData, pStart + 21, bLineNumber, 0, 3);
                this.LineNumber = BitConverter.ToUInt32(bLineNumber, 0) >> 8;

                byte[] bRemainPrice = new byte[4];
                Buffer.BlockCopy(pData, pStart + 24, bRemainPrice, 0, 3);
                this.RemaningPrice = BitConverter.ToUInt32(bRemainPrice, 0) >> 8;

                byte[] bPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 27, bPrice, 0, 2);
                this.Price = BitConverter.ToUInt16(bPrice, 0);

                byte pCardTypeReaderID = pData[pStart + 29];
                this.CardType = (uint)pCardTypeReaderID & 0x00001111;
                this.ReaderID = ((uint)pCardTypeReaderID & 0x11110000) >> 4;
            }
            catch (Exception ex)
            {
            }

            return new Tuple<int>(7 + 7 + 4 + 3 + 3 + 3 + 2 + 1 + 2 + pStart);
        }


    }

    public class JTransactionAVLHeader
    {
        public DateTime DATE; //3
        public uint SimCharge;//2
        public uint Battryvoltvalue;//2
        public uint GpsAnttena;//1
        public uint GsmAnttena;//1
        public UInt32 busSerial;//4

        public List<JTransactionAVL> AVLs = new List<JTransactionAVL>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":AH:" + (pData.Length - pStart).ToString() + "/13";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {

                //byte[] bIMEI = new byte[3];
                //Buffer.BlockCopy(pData, 0, bIMEI, 0, 8);
                //this.DATE = Convert.ToUInt64(bIMEI);
                //pOldData.AddRange(bIMEI);

                byte[] bDATE = new byte[3];
                Buffer.BlockCopy(pData, pStart + 0, bDATE, 0, 3);
                this.DATE = JTransactions.ConvertBytesToDateTime(bDATE);
                pOldData.AddRange(bDATE);

                byte[] bSimCharge = new byte[2];
                Buffer.BlockCopy(pData, pStart + 3, bSimCharge, 0, 2);
                this.SimCharge = BitConverter.ToUInt16(bSimCharge, 0);
                pOldData.AddRange(bSimCharge);

                byte[] bBattryvoltvalue = new byte[2];
                Buffer.BlockCopy(pData, pStart + 5, bBattryvoltvalue, 0, 2);
                this.Battryvoltvalue = BitConverter.ToUInt16(bBattryvoltvalue, 0);
                pOldData.AddRange(bBattryvoltvalue);

                byte[] bGpsAnttena = new byte[1];
                Buffer.BlockCopy(pData, pStart + 7, bGpsAnttena, 0, 1);
                this.GpsAnttena = Convert.ToUInt32(bGpsAnttena.First());
                pOldData.AddRange(bGpsAnttena);

                byte[] bGsmAnttena = new byte[1];
                Buffer.BlockCopy(pData, pStart + 8, bGsmAnttena, 0, 1);
                this.GsmAnttena = Convert.ToUInt32(bGsmAnttena.First());
                pOldData.AddRange(bGsmAnttena);
            }

            return new Tuple<int, string, int, List<byte>>(3 + 2 + 2 + 1 + 1 + pStart, err, errNum, pOldData);
        }
    }

    public class JTransactionAVL
    {
        public uint transactionid;//4
        public int[] Time;//3
        public float Lon;//4
        public float Lat;//4
        public uint Alt;//2
        public uint Speed;//2
        public uint Cource;//1
        public uint Dir;//1

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":A:" + (pData.Length - pStart).ToString() + "/18";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                //byte[] btransactionid = new byte[4];
                //Buffer.BlockCopy(pData, pStart + 0, btransactionid, 0, 4);
                //this.transactionid = BitConverter.ToUInt32(btransactionid, 0);

                byte[] bTime = new byte[3];
                Buffer.BlockCopy(pData, pStart + 0, bTime, 0, 3);
                this.Time = JTransactions.ConvertBytesToTime(bTime);
                pOldData.AddRange(bTime);

                //byte[] bLon = new byte[4];
                //Buffer.BlockCopy(pData, pStart + 3, bLon, 0, 4);
                //this.Lon = BitConverter.ToSingle(bLon, 0) / 100;
                //pOldData.AddRange(bLon);

                //byte[] bLat = new byte[4];
                //Buffer.BlockCopy(pData, pStart + 7, bLat, 0, 4);
                //this.Lat = BitConverter.ToSingle(bLat, 0) / 100;
                //pOldData.AddRange(bLat);

                float NewLon;
                byte[] bLon = new byte[4];
                Buffer.BlockCopy(pData, pStart + 3, bLon, 0, 4);
                NewLon = BitConverter.ToSingle(bLon, 0);
                int TempNewLon = (int)Math.Floor(NewLon);
                //this.Lon = (float)((TempNewLon / 100) + ((TempNewLon % 100) / 60.0) + ((NewLon - TempNewLon) / 3600));// (float)(Math.Floor(TempNewLon / 100.0) + (TempNewLon % 100) / 60.0 + (NewLon - TempNewLon) / 3600.0);
                if (TempNewLon > 999)
                    this.Lon = Transaction.JTransactions.ConvertNMEAToDecimal(NewLon);
                else
                    this.Lon = NewLon;
                pOldData.AddRange(bLon);

                float NewLat;
                byte[] bLat = new byte[4];
                Buffer.BlockCopy(pData, pStart + 7, bLat, 0, 4);
                NewLat = BitConverter.ToSingle(bLat, 0);
                int TempNewLat = (int)Math.Floor(NewLat);
                //this.Lat = (float)((TempNewLat / 100) + ((TempNewLat % 100) / 60.0) + ((NewLat - TempNewLat) / 3600));// (float)(Math.Floor(TempNewLat / 100.0) + (TempNewLat % 100) / 60.0 + (NewLat - TempNewLat) / 3600.0);
                if (TempNewLat > 999)
                    this.Lat = Transaction.JTransactions.ConvertNMEAToDecimal(NewLat);
                else
                    this.Lat = NewLat;
                pOldData.AddRange(bLat);

                byte[] bAlt = new byte[2];
                Buffer.BlockCopy(pData, pStart + 11, bAlt, 0, 2);
                this.Alt = BitConverter.ToUInt16(bAlt, 0);
                pOldData.AddRange(bAlt);

                byte[] bSpeed = new byte[2];
                Buffer.BlockCopy(pData, pStart + 13, bSpeed, 0, 2);
                this.Speed = BitConverter.ToUInt16(bSpeed, 0);
                pOldData.AddRange(bSpeed);

                byte[] bCource = new byte[1];
                Buffer.BlockCopy(pData, pStart + 15, bCource, 0, 1);
                this.Cource = Convert.ToUInt32(bCource.First());
                pOldData.AddRange(bCource);

                byte[] bDir = new byte[1];
                Buffer.BlockCopy(pData, pStart + 16, bDir, 0, 1);
                this.Dir = Convert.ToUInt32(bDir.First());
                pOldData.AddRange(bDir);
            }

            return new Tuple<int, string, int, List<byte>>(3 + 4 + 4 + 2 + 2 + 1 + 1 + pStart, err, errNum, pOldData);
        }
    }

    public class JTransactions
    {
        public Tuple<JTransactionHeader, byte[]> ProcessPublic(byte[] pData)
        {
            try
            {
                int NextIndex = 0;
                List<byte> OldData = new List<byte>();

                JTransactionHeader TH = new JTransactionHeader();
                Tuple<int, string, int, List<byte>> result = TH.SetValue(pData, 0, OldData);
                if (result.Item3 > 0)
                {
                    TH.Error = result.Item2;
                    TH.ErrorNum = result.Item3;
                    return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                }
                OldData = result.Item4;
                NextIndex = result.Item1;

                while (NextIndex < pData.Length)
                {
                    int _NCode = (int)pData[NextIndex++];
                    if (_NCode == JTransactionType.TicketHeader.GetHashCode())
                    {
                        byte header = 1;
                        OldData.Add(header);
                        JTransactionTicketHeader TTH = new JTransactionTicketHeader();
                        result = TTH.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;

                        TH.TicketHeaders.Add(TTH);
                    }

                    else if (_NCode == JTransactionType.TicketData.GetHashCode())
                    {
                        JTransactionTicket TT = new JTransactionTicket();
                        byte header = 2;
                        OldData.Add(header);
                        result = TT.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.TicketHeaders.Last().Tickets.Add(TT);
                    }

                    else if (_NCode == JTransactionType.AVLHeder.GetHashCode())
                    {
                        TH.ErrorNum = 200;
                        JTransactionAVLHeader TAH = new JTransactionAVLHeader();
                        byte header = 100;
                        OldData.Add(header);
                        result = TAH.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.AVLHeaders.Add(TAH);
                        //  break;
                    }

                    else if (_NCode == JTransactionType.AVLData.GetHashCode())
                    {
                        TH.ErrorNum = 200;
                        JTransactionAVL TA = new JTransactionAVL();
                        byte header = 101;
                        OldData.Add(header);
                        result = TA.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.AVLHeaders.Last().AVLs.Add(TA);
                        // break;
                    }

                    else
                    {
                        //break;

                    }

                }

                return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }


        public static void TransactionPrintCheckDataTicketPublic(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb, DateTime InsertDate)
        {
            // ClassLibrary.JSystem.Except.AddException(new Exception("*** Start TransactionPrintCheckDataTicket " + DateTime.Now.ToLongTimeString()));

            db.setQuery(@"select Date from AutWorkedDay where Active = 1 order by Date Desc");
            System.Data.DataTable DtWorkedDay = db.Query_DataTable();
            if (DtWorkedDay != null)
            {
                if (DtWorkedDay.Rows.Count > 0)
                {
                    for (int WD = 0; WD < DtWorkedDay.Rows.Count; WD++)
                    {

                        //ClassLibrary.JSystem.Except.AddException(new Exception("Start UpdateAUTDailyPerformanceRportOnBus For " +
                        //    DtWorkedDay.Rows[WD]["Date"].ToString() + " " + DateTime.Now.ToLongTimeString()));

                        db.setQuery("EXEC UpdateAUTDailyPerformanceRportOnBus @ProcessDate");
                        db.Params.Clear();
                        if (db.Params.Count > 0)
                        {
                            db.Params.Remove("ProcessDate");
                        }
                        db.AddParams("ProcessDate", Convert.ToDateTime(DtWorkedDay.Rows[WD]["Date"].ToString()));
                        //  db.Query_Execute();

                        //ClassLibrary.JSystem.Except.AddException(new Exception("END UpdateAUTDailyPerformanceRportOnBus For " +
                        //    DtWorkedDay.Rows[WD]["Date"].ToString() + " " + DateTime.Now.ToLongTimeString()));

                        //                        ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintCheckDataTicket For " +
                        //                            DtWorkedDay.Rows[WD]["Date"].ToString() + " " + DateTime.Now.ToLongTimeString()));

                        //                        db.setQuery(@"select Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
                        //                                        where [DailyCode] > 0 and [State] = 0 and cast(StartDate as date) = cast('" + DtWorkedDay.Rows[WD]["Date"].ToString() + @"' as date)
                        //                                        order by Code desc");
                        //                        System.Data.DataTable DtPrinterReport = db.Query_DataTable();
                        //                        if (DtPrinterReport != null)
                        //                        {
                        //                            if (DtPrinterReport.Rows.Count > 0)
                        //                            {
                        //                                for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
                        //                                {
                        //                                    try
                        //                                    {
                        //                                        MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
                        //                                        System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
                        //                                        if (DtMyDqlGetDataTicket != null)
                        //                                        {
                        //                                            if (DtMyDqlGetDataTicket.Rows.Count > 0)
                        //                                            {
                        //                                                db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
                        //                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
                        //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
                        //                                                db.Query_Execute();

                        //                                                db.setQuery(@"select ISNULL(sum(TCount),-1)TCount from [dbo].[AUTDailyPerformanceRportOnBus]
                        //                                                where BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
                        //                                                      And [Date] = cast('" + DtPrinterReport.Rows[i]["FDate"].ToString() + @"' as date)
                        //                                                      And FirstTicketDate >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                        //                                                      And LastTicketDate <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
                        //                                                System.Data.DataTable DtSumTransaction = db.Query_DataTable();
                        //                                                if (DtSumTransaction != null && Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) > -1)
                        //                                                {
                        //                                                    if (DtSumTransaction.Rows.Count > 0)
                        //                                                    {
                        //                                                        if (Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) == Convert.ToInt32(DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString()))
                        //                                                        {
                        //                                                            db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 where Code = "
                        //                                                                + DtPrinterReport.Rows[i]["DailyCode"].ToString());
                        //                                                            db.Query_Execute();
                        //                                                        }

                        //                                                        db.setQuery(@"Update [AUTPrinterRporte] set [GetTicket] = 1,[State] = 1,[RequestCount]= IsNull(RequestCount,0) + 1 where 
                        //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
                        //                                                        db.Query_Execute();

                        //                                                        db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
                        //                                                            [TCount]  = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                        //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                        //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                        //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))
                        //                                                          , Price = ((" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                        //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                        //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                        //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) * TicketPrice) 
                        //															from AUTDailyPerformanceRportOnBus b
                        //                                                           where DocumentCode = 0 and Code = " + DtPrinterReport.Rows[i]["DailyCode"].ToString() + @"
                        //                                                            and (" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                        //                                                            (select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                        //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                        //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) >= 0");
                        //                                                        db.Query_Execute();
                        //                                                        db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
                        //                                                            [TCount]  = 0  , Price = 0
                        //                                                            where DocumentCode = 0 and BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
                        //                                                            and FirstTicketDate > '" + DtPrinterReport.Rows[i]["StartDate"].ToString() +
                        //                                                                        "' AND LastTicketDate < '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
                        //                                                        db.Query_Execute();

                        //                                                        db.setQuery(@"Update [AUTWorkedDay] set [Active] = 1 where Date = '"
                        //                                                           + DtPrinterReport.Rows[i]["FDate"].ToString() + "'");
                        //                                                        db.Query_Execute();
                        //                                                    }
                        //                                                }
                        //                                            }
                        //                                        }
                        //                                    }
                        //                                    catch
                        //                                    {

                        //                                    }
                        //                                }
                        //                            }
                        //                        }
                    }
                }
            }

            // ClassLibrary.JSystem.Except.AddException(new Exception("*** END TransactionPrintCheckDataTicket" + DateTime.Now.ToLongTimeString()));
        }


        public static void GetOfflineFileFromOldDbToNewDb()
        {
            //            System.Data.SqlClient.SqlConnectionStringBuilder C = new System.Data.SqlClient.SqlConnectionStringBuilder(@"
            //                Data Source=.;
            //                Initial Catalog=BusAvlSendLogs;
            //                Persist Security Info=True;
            //                User ID=sa;
            //                Password=AvlTabriz123;
            //                Connect Timeout=30000;");
            //            JDataBase DBPubic = new JDataBase(C);
            //            DBPubic.setQuery(@"");

            //            DataTable dt = DBPubic.Query_DataTable();
        }

        public void CheckDataAVLPublic()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder C = new System.Data.SqlClient.SqlConnectionStringBuilder(@"
                Data Source=.;
                Initial Catalog=BusAvlSendLogs;
                Persist Security Info=True;
                User ID=sa;
                Password=AvlTabriz123;
                Connect Timeout=30000;");
            ClassLibrary.JDataBase Db = new JDataBase();
            ClassLibrary.JDataBase DBPubic = new ClassLibrary.JDataBase(C);
            try
            {
                DBPubic.setQuery(@"Select top 200 SendLogId,ReceiveDate,SendLog 
                            from SendLogs where 
                            ErrorCount = 250
                            order by SendLogId desc");
                DataTable dt = DBPubic.Query_DataTable();
                foreach (DataRow row in dt.Rows)
                {
                    Int64 recordNumber = 0;
                    try
                    {
                        //db.beginTransaction("avl");
                        Tuple<JTransactionHeader, byte[]> result = ProcessPublic(row["SendLog"] as byte[]);
                        bool isSuccess = true;
                        recordNumber = Convert.ToInt64(row["SendLogId"]);
                        if (result.Item1.ErrorNum == 200)
                            if (result.Item1.AVLHeaders != null && result.Item1.AVLHeaders.Count() > 0)
                                foreach (var AH in result.Item1.AVLHeaders)
                                {
                                    if (isSuccess == false) break;

                                    if (AH.AVLs != null && AH.AVLs.Count() > 0)
                                    {
                                        DateTime date = AH.DATE;
                                        foreach (var AVL in AH.AVLs)
                                        {
                                            // We've got new AVL :)
                                            DateTime avlDate = new DateTime(date.Year, date.Month, date.Day, AVL.Time[0], AVL.Time[1], AVL.Time[2]);
                                            isSuccess = BusManagment.AVL.JAVLTransactionsPublic.AddAVL(AH, AVL, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION,Db);
                                            if (isSuccess == false)
                                            {
                                                ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save AVL:" +
                                                    AVL.transactionid.ToString() + " " +
                                                    AH.busSerial.ToString() + " " +
                                                    AH.DATE.ToString()));
                                                //break;
                                            }
                                        }
                                    }
                                }
                        //if (isSuccess)
                        {
                            ClassLibrary.JDataBase DBTemp = new ClassLibrary.JDataBase(C);
                            DBTemp.setQuery("Update SendLogs set Saved = 1,ErrorCount=251, EndProcess=GETDATE(), GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
                            DBTemp.Query_Execute(true);
                        }
                        //else
                        //{
                        //    ClassLibrary.JDataBase DBTemp = new ClassLibrary.JDataBase(C);
                        //    DBTemp.setQuery("Update SendLogs set ErrorCount=ErrorCount+1, EndProcess=GETDATE(),GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
                        //    DBTemp.Query_Execute(true);
                        //}
                        //else
                        //db.Rollback("avl");
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JDataBase DBTemp = new ClassLibrary.JDataBase(C);
                        DBTemp.setQuery("Update SendLogs set Saved = 1,ErrorCount=251, EndProcess=GETDATE(), GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
                        DBTemp.Query_Execute(true);
                        //ClassLibrary.JSystem.Except.AddException(ex);
                        //db.Rollback("avl");
                    }
                    finally
                    {
                        //if (db.Transaction != null) db.Rollback("avl");
                        //db.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                DBPubic.Dispose();
            }
            finally
            {
                DBPubic.Dispose();
            }
        }

        public void CheckDataTicketMySql()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                DataTable dt;
                {
                    mysqlDB.setQuery("Select * from cardinfo_bin order by Code desc LIMIT 0,200");
                    dt = mysqlDB.Query_DataTable();
                    if (dt.Rows.Count > 0 && Transaction.JDeviceDB.MoveTicketRecord(dt.Rows, "", 0, mysqlDB) == true)
                    {
                        //test
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    byte[] Data = (byte[])row["Data"];
                    Int64 RecordNumber = (Int64)row["RecordNumber"];
                    Int64 Code = (Int64)row["Code"];
                    ProcessTicketData(Data, RecordNumber, true,Code);

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mysqlDB.Dispose();
            }
        }

        public void ProcessTicketData(byte[] Data, Int64 pRecordNumber, bool pThread, Int64 Code)
        {
            BusTicketRecord B = new BusTicketRecord();
            B.Data = Data;
            B.RecordNumber = pRecordNumber;
            B.Code = Code;
            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_CheckDataTicket));
                N.Start(B);
            }
            else
            {
                _CheckDataTicket(B);
            }
        }

        private void _CheckDataTicket(Object B)
        {
            (new BusManagment.Transaction.JTransactions()).CheckDataTicket(((BusTicketRecord)B).RecordNumber, ((BusTicketRecord)B).Data, ((BusTicketRecord)B).Code);
        }

        //public void CheckDataTicketMysql(long RecordNumber, byte[] Data)
        //{
        //    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //    try
        //    {
        //        Tuple<JTransactionHeader, byte[]> result = (new BusManagment.Transaction.JTransactions()).Process(Data as byte[]);
        //        bool isSuccess = true;
        //        Int64 recordNumber = Convert.ToInt64(RecordNumber);
        //        if (result.Item1.ErrorNum == 0)
        //            if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
        //                foreach (var TH in result.Item1.TicketHeaders)
        //                {
        //                    if (isSuccess == false) break;

        //                    if (TH.Tickets != null && TH.Tickets.Count() > 0)
        //                    {
        //                        DateTime date = TH.DATE;
        //                        foreach (var Ticket in TH.Tickets)
        //                        {
        //                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);
        //                            isSuccess = Transaction.JTicketTransactions.AddTicketTransactionPublic(TH, Ticket, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db);
        //                            if (isSuccess == false)
        //                            {
        //                                //ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
        //                                //     Ticket.transactionid.ToString() + " " +
        //                                //     TH.busSerial.ToString() + " " +
        //                                //     TH.DATE.ToString()));
        //                                //break;
        //                            }
        //                        }
        //                    }
        //                }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

//        public void CheckDataTicket()
//        {
//            System.Data.SqlClient.SqlConnectionStringBuilder C = new System.Data.SqlClient.SqlConnectionStringBuilder(@"
//                Data Source=.;
//                Initial Catalog=BusAvlSendLogs;
//                Persist Security Info=True;
//                User ID=sa;
//                Password=AvlTabriz123;
//                Connect Timeout=30000;");
//            JDataBase DBPubic = new JDataBase(C);
//            JDataBase DB = new JDataBase();

//            try
//            {
//                DBPubic.setQuery(@"Select top 200 SendLogId,ReceiveDate,SendLog 
//                            from SendLogs where 
//                            saved = 0 and 
//                            ErrorCount<3 
//                            order by SendLogId desc");
//                DataTable dt = DBPubic.Query_DataTable();

//                foreach (DataRow row in dt.Rows)
//                {
//                    try
//                    {
//                        Tuple<JTransactionHeader, byte[]> result = ProcessPublic(row["SendLog"] as byte[]);
//                        bool isSuccess = true;
//                        Int64 recordNumber = Convert.ToInt64(row["SendLogId"]);
//                        if (result == null || result.Item1.ErrorNum == 200)
//                        {
//                            JDataBase TempDB = new JDataBase(C);
//                            TempDB.setQuery("Update SendLogs set ErrorCount = 250,Saved = 0 , EndProcess=GETDATE(), GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
//                            TempDB.Query_Execute(true);
//                            continue;
//                        }
//                        else if (result.Item1.ErrorNum == 0)
//                            if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
//                                foreach (var TH in result.Item1.TicketHeaders)
//                                {
//                                    //if (isSuccess == false) break;

//                                    if (TH.DATE >= DateTime.Parse("2014-05-22") && TH.Tickets != null && TH.Tickets.Count() > 0)
//                                    {
//                                        DateTime date = TH.DATE;
//                                        foreach (var Ticket in TH.Tickets)
//                                        {

//                                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

//                                            isSuccess = Transaction.JTicketTransactions.AddTicketTransactionPublic(TH,
//                                                Ticket,
//                                                recordNumber,
//                                                result.Item1.IMEI,
//                                                float.Parse(TH.busSerial.ToString()),
//                                                result.Item1.VERSION,DB);
//                                            if (isSuccess == false)
//                                            {
//                                                ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
//                                                     TH.DATE.ToString()));
//                                            }
//                                        }
//                                    }
//                                }
//                        if (isSuccess)
//                        {
//                            JDataBase TempDB = new JDataBase(C);
//                            TempDB.setQuery("Update SendLogs set Saved = 1,ErrorCount=100,EndProcess=GETDATE(), GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
//                            TempDB.Query_Execute();
//                            TempDB.Dispose();
//                        }
//                        else
//                        {
//                            JDataBase TempDB = new JDataBase(C);
//                            TempDB.setQuery("Update SendLogs set ErrorCount=3, EndProcess=GETDATE(),GSMSerialFound=1 where SendLogId = " + recordNumber.ToString());
//                            TempDB.Query_Execute();
//                            TempDB.Dispose();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        ClassLibrary.JSystem.Except.AddException(ex);
//                    }
//                    finally
//                    {
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            finally
//            {
//                DBPubic.Dispose();
//                DB.Dispose();
//            }
//        }


        //public void CheckDataTicket1(long RecordNumber, byte[] Data)
        //{
        //    JDataBase DB = new JDataBase();
        //    try
        //    {
        //        Tuple<JTransactionHeader, byte[]> result = ProcessPublic(Data as byte[]);
        //        bool isSuccess = true;
        //        Int64 recordNumber = Convert.ToInt64(RecordNumber);
        //        if (result.Item1.ErrorNum == 0)
        //            if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
        //                foreach (var TH in result.Item1.TicketHeaders)
        //                {
        //                    if (isSuccess == false) break;

        //                    if (TH.Tickets != null && TH.Tickets.Count() > 0)
        //                    {
        //                        DateTime date = TH.DATE;
        //                        foreach (var Ticket in TH.Tickets)
        //                        {
        //                            // We've got new Ticket ;)

        //                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

        //                            isSuccess = Transaction.JTicketTransactions.AddTicketTransactionPublic(TH, Ticket, recordNumber, result.Item1.IMEI, (float)TH.busSerial, result.Item1.VERSION,DB);
        //                            if (isSuccess == false)
        //                            {
        //                                ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
        //                                     TH.DATE.ToString()));
        //                                //break;
        //                            }
        //                        }
        //                    }
        //                }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}


//        public void CheckDataSQLiteTicket()
//        {
//            int Code = 0;
//            int ArchiveCode = 0;
//            byte[] Content = new byte[0];
//            JSQLiteDataBase SQLiteDB = null;
//            DataTable SQLiteDT = null;
//            bool ChangeSQLiteDB = false;

//            ClassLibrary.JFile File = new ClassLibrary.JFile();

//            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
//            JDataBase DB = new JDataBase();
//            Dictionary<Int64, DateTime> Change = new Dictionary<Int64, DateTime>();
//            try
//            {
//                Archivedb.setQuery(@"SELECT ac.[Code] ,ac.[Contents],ac.[ArchiveDate],(select top 1 Code From ArchiveInterface where ArchiveCode = ac.[Code]) as ArchiveCode 
//                                    FROM [ArchiveContent] ac  where Status=1 and FileExtension like N'.db'");
//                DataTable DT = Archivedb.Query_DataTable();
//                foreach (DataRow DR in DT.Rows)
//                {
//                    DateTime ArchiveDate = DateTime.Now;
//                    int trueCount, falseCount;
//                    trueCount = 0;
//                    falseCount = 0;
//                    try
//                    {
//                        ArchiveDate = (DateTime)DR["ArchiveDate"];

//                        Code = int.Parse(DR["Code"].ToString());
//                        Content = (DR["Contents"] as byte[]);
//                        ArchiveCode = int.Parse(DR["ArchiveCode"].ToString());

//                        string FileName = Guid.NewGuid().ToString() + ".db";

//                        File.Content = Content;
//                        File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
//                        File.Write();

//                        JConnection C = new JConnection();

//                        SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

//                        SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\" where IsSent=0;");
//                        SQLiteDT = SQLiteDB.Query_DataTable();
//                    }
//                    catch
//                    {
//                    }

//                    if (SQLiteDT != null)
//                    {
//                        Archivedb.setQuery("Update ArchiveContent Set TrueTCount=" + trueCount + ",FalseTCount=" + (SQLiteDT.Rows.Count - trueCount).ToString() + " where Code=" + Code.ToString());
//                        Archivedb.Query_Execute();
//                        Random R = new Random();
//                        foreach (DataRow SQLiteDR in SQLiteDT.Rows)
//                        {
//                            try
//                            {
//                                //"index" INTEGER PRIMARY KEY AUTOINCREMENT,
//                                //"RFID" INTEGER,
//                                //"DateTime" INTEGER,
//                                //"BusSerial" INTEGER,
//                                //"ReaderId" INTEGER,
//                                //"DriverSerial" INTEGER,
//                                //"CardType" INTEGER,
//                                //"LineNumber" INTEGER,
//                                //"Price" INTEGER,
//                                //"RemainPrice" INTEGER,
//                                //"isSent" INTEGER


//                                bool isSuccess = true;
//                                JTransactionTicketHeader TH = new JTransactionTicketHeader();
//                                TH.busSerial = uint.Parse(SQLiteDR["BUSSerial"].ToString());
//                                TH.DATE = JTransactions.ConvertUintToDateTime(ulong.Parse(SQLiteDR["DateTime"].ToString()));
//                                if (TH.DATE < DateTime.Now.AddMonths(-2))
//                                {
//                                    string FDay = JDateTime.FarsiDate(ArchiveDate);
//                                    string[] FDays = FDay.Split(new string[] { "/" }, StringSplitOptions.None);
//                                    int Y = int.Parse(FDays[0]);
//                                    int M = int.Parse(FDays[1]);
//                                    int D = int.Parse(TH.DATE.ToShortTimeString().Split(new string[] { ":" }, StringSplitOptions.None)[0]);

//                                    if (M == 1)
//                                    {
//                                        Y--;
//                                        M = 12;
//                                    }
//                                    else
//                                    {
//                                        M--;
//                                    }

//                                    TH.DATE = JDateTime.GregorianDate(Y, M, D).AddSeconds(int.Parse(TH.DATE.ToShortTimeString().Split(new string[] { ":" }, StringSplitOptions.None)[0]) * 3600 + TH.DATE.Minute * 60 + TH.DATE.Second);

//                                    Int64 indexTemp = 0;
//                                    if (Int64.TryParse(SQLiteDR["index"].ToString(), out indexTemp))
//                                    {
//                                        Change.Add(indexTemp, TH.DATE);
//                                        ChangeSQLiteDB = true;
//                                    }

//                                }
//                                TH.DriverSerialCard = SQLiteDR["DriverSerial"].ToString();
//                                TH.LineNumber = uint.Parse(SQLiteDR["LineNumber"].ToString());
//                                DateTime date = TH.DATE;

//                                JTransactionTicket Ticket = new JTransactionTicket();
//                                Ticket.CardType = uint.Parse(SQLiteDR["CardType"].ToString());
//                                Ticket.PassengerCardSerial = uint.Parse(SQLiteDR["RFID"].ToString());
//                                Ticket.RemainPrice = uint.Parse(SQLiteDR["RemainPrice"].ToString());
//                                Ticket.TicketPrice = uint.Parse(SQLiteDR["Price"].ToString());
//                                Ticket.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };

//                                DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

//                                isSuccess = Transaction.JTicketTransactions.AddTicketTransactionPublic(TH, Ticket, 0, "0"
//                                    , TH.busSerial, new byte[] { 1 }, DB, ArchiveCode);
//                                if (isSuccess)
//                                {
//                                    trueCount++;
//                                }
//                                else
//                                    if (isSuccess == false)
//                                    {
//                                        falseCount++;
//                                        //ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
//                                        //     TH.DATE.ToString()));
//                                        //break;
//                                    }
//                                if ((trueCount + falseCount) % 100 == 0)
//                                {
//                                    Archivedb.setQuery("Update ArchiveContent Set TrueTCount=" + trueCount + ",FalseTCount=" + (SQLiteDT.Rows.Count - trueCount).ToString() + " where Code=" + Code.ToString());
//                                    Archivedb.Query_Execute();
//                                }
//                            }//try
//                            catch (Exception ex)
//                            {
//                                ClassLibrary.JSystem.Except.AddException(ex);
//                            }
//                            finally
//                            {
//                            }

//                        }// FOreach
//                    }//IF
//                    if (ChangeSQLiteDB)
//                    {
//                        foreach (KeyValuePair<Int64,DateTime> D in Change)
//                        {
//                            SQLiteDB.setQuery("update \"cardinfo\" SET [DateTime]=" + JTransactions.ConvertDateTimeToUint(D.Value).ToString() + " where [index]=" + D.Key.ToString());
//                            SQLiteDB.Query_Execute();
//                        }

//                        SQLiteDB.DisConnect();
//                        ArchivedDocuments.JArchiveDocument F = new ArchivedDocuments.JArchiveDocument();
//                        F.UpdateArchive(File, Code, " Update DB for Set New DateTime",true);
//                    }
//                    Archivedb.setQuery("Update ArchiveContent Set Status=2,TrueTCount=" + trueCount + ",FalseTCount=" + falseCount + " where Code=" + Code.ToString());
//                    Archivedb.Query_Execute();
//                    System.IO.File.Delete(File.FileName);
//                }//foreach
//            }
//            catch (Exception ex)
//            {
//            }
//            finally
//            {
//                if(SQLiteDB != null)
//                    SQLiteDB.Dispose();
//                Archivedb.Dispose();
//            }
//        }




        //Open SqlLite File
        public DataTable OpenSQLiteTicketDataBase(int ArchiveContentCode)
        {
            int Code = 0;
            byte[] Content = new byte[0];
            JSQLiteDataBase SQLiteDB = null;
            DataTable SQLiteDT = null;

            ClassLibrary.JFile File = new ClassLibrary.JFile();

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Code = " + ArchiveContentCode);
                DataTable DT = Archivedb.Query_DataTable();
                //foreach (DataRow DR in DT.Rows)
                //{

                try
                {
                    Code = int.Parse(DT.Rows[0]["Code"].ToString());
                    Content = (DT.Rows[0]["Contents"] as byte[]);

                    string FileName = Guid.NewGuid().ToString() + ".db";

                    File.Content = Content;
                    File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
                    File.Write();

                    JConnection C = new JConnection();

                    SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

                    SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\";");
                    SQLiteDT = SQLiteDB.Query_DataTable();
                }
                catch
                {
                    return null;
                }

                if (SQLiteDT != null)
                {
                    return SQLiteDT;
                }
                else
                {
                    return null;
                }//IF
            }//foreach
            //}
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }

        public void CheckDataOfflineTicketPublic()
        {
            int FileCodeForUpdate = 0;
            int TransactionCounter = 0;
            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start " + DateTime.Now.ToLongTimeString()));

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();

            //db.setQuery(@"select isnull(max(code),0)+1 from AUTTicketTransaction");
            //DataTable DtMaxCode = db.Query_DataTable();
            //int MaxCode = Convert.ToInt32(DtMaxCode.Rows[0][0].ToString());
            JDataBase TempDB = new JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,cast([Contents] as varchar(max))Contents FROM [ArchiveContent]  where Status=1 and FileExtension like N'.ini' order by code desc");
                DataTable DT = Archivedb.Query_DataTable();
                int Code = 0;

                string Content = "";
                StringBuilder FinalQueryToRun = new StringBuilder();
                foreach (DataRow DR in DT.Rows)
                {
                    Code = Convert.ToInt32(DR["Code"].ToString());

                    Archivedb.setQuery("Update ArchiveContent Set TrueTCount=0,FalseTCount=0 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();

                    FileCodeForUpdate = Code;
                    Content = DR["Contents"].ToString();

                    string[] ContentDetailes = Content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    string BusNumber = ContentDetailes[0].ToString().Substring(12, 4);
                    string ReaderId = ContentDetailes[0].ToString().Substring(16, 2);
                    string DriverRFID = "0";
                    //DriverRFID = ContentDetailes[2].ToString().Split(' ')[0].Replace("\r\n", "");
                    //int IPluserIndex = 0;
                    //if (DriverRFID.Length == 6)
                    //{
                    //    DriverRFID = ContentDetailes[3].ToString().Replace("\r\n", "");
                    //    IPluserIndex = 1;
                    //}
                    string LineNumber = "";
                    string TicketPrice = "";
                    string[] LineNumberTemp = new string[0];
                    for (int i = 1; i < 10; i++)
                        if (ContentDetailes[i].Split(' ')[0] == "4")
                        {
                            LineNumber = (int.Parse(ContentDetailes[i].ToString().Split(' ')[1])).ToString(); ;
                            TicketPrice = (int.Parse(ContentDetailes[i + 1].ToString().Split(' ')[0]) / 10).ToString();
                            break;
                        }
                    if (LineNumber == "")
                        throw new Exception("LineNumber not found");
                    string[] TicketList = ContentDetailes;

                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query Start " + DateTime.Now.ToLongTimeString()));
                    DateTime EventDate = DateTime.Now;
                    for (int i = 21; i < TicketList.Length; i++)
                    {
                        string[] TicketDetailes = TicketList[i].ToString().Split(' ');
                        if (TicketDetailes.Length >= 4)
                        {
                            int Year, month, day, hour, minute, second;
                            try
                            {
                                Year = Convert.ToInt32(TicketDetailes[2].ToString().Substring(0, 2)) + 2000;
                                month = Convert.ToInt32(TicketDetailes[2].ToString().Substring(2, 2));
                                if (month == 0 || month > 12) month = DateTime.Now.Date.Month;

                                day = Convert.ToInt32(TicketDetailes[2].ToString().Substring(4, 2));
                                if (day == 0 || day > 31) day = 1;

                                hour = Convert.ToInt32(TicketDetailes[1].ToString().Substring(0, 2));
                                if (hour == 0 || hour > 23) hour = 7;

                                minute = Convert.ToInt32(TicketDetailes[1].ToString().Substring(1, 2));
                                if (minute == 0 || minute > 59) minute = 1;

                                second = Convert.ToInt32(TicketDetailes[1].ToString().Substring(4, 2));
                                if (second == 0 || second > 59) second = 1;
                                EventDate = new DateTime(Year, month, day, hour, minute, second);
                            }
                            catch
                            {
                                EventDate = EventDate.AddSeconds(1);
                            }

                            TransactionCounter++;
                            //TempDB.setQuery("select top 1 Code from AUTTicketTransaction where  EventDate = '" + EventDate + "' and PassengerCardSerial=cast(0x" + TicketDetailes[1].ToString().Replace("\r\n", "") + @" as bigint)");
                            //if (TempDB.Query_DataTable().Rows.Count == 0)
                            {
                                FinalQueryToRun.Append( @"
                                                    INSERT INTO [dbo].[AUTTicketTransaction]
                                                   (
                                                    [recordNumber]
                                                   ,[EventDate]
                                                   ,[RecievedDate]
                                                   ,[DriverCardSerial]
                                                   ,[DriverPersonCode]
                                                   ,[DriverPersonName]
                                                   ,[LineNumber]
                                                   ,[ZoneCode]
                                                   ,[ZoneName]
                                                   ,[FleetCode]
                                                   ,[FleetName]
                                                   ,[BusNumber]
                                                   ,[BusCode]
                                                   ,[TransactionId]
                                                   ,[PassengerCardSerial]
                                                   ,[CardType]
                                                   ,[TicketPrice]
                                                   ,[RemainPrice]
                                                   ,[ReaderId]
                                                   ,[HeaderTransactionCode])
                                             VALUES
                                                   (0
                                                   ,'" + EventDate + @"'
                                                   ,getdate()
                                                   ,cast(0x" + DriverRFID + @" as bigint)
                                                   ,0
                                                   ,null
                                                   ," + LineNumber + @"
                                                   ,isnull((select ZoneCode from AUTLine where LineNumber = " + LineNumber + @"),0)
                                                   ,null
                                                   ,isnull((select KeyValue from AUTSettings where KeyName = N'FleetCode'),0)
                                                   ,null
                                                   ," + BusNumber + @"
                                                   ,isnull((select Code from autbus where busnumber = " + BusNumber + @"),0)
                                                   ,0
                                                   ,cast(0x" + TicketDetailes[0].ToString().Replace("\r\n", "") + @" as bigint)
                                                   ,0
                                                   ," + TicketPrice + @"
                                                   ,0
                                                   ," + ReaderId + @"
                                                   ,0);");
                            }

                        }
                        if (i % 100 == 0)
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query End " + DateTime.Now.ToLongTimeString()));
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query " + DateTime.Now.ToLongTimeString()));
                            while (JDataBase.dbsOpen.Count > 1000)
                                System.Threading.Thread.Sleep(10);
                            JDataBase DbInsert = new JDataBase();
                            DbInsert.setQuery(FinalQueryToRun.ToString());
                            if (FinalQueryToRun.Length == 0 || DbInsert.Query_Execute() >= 0)
                            {
                                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Sucsesfull " + DateTime.Now.ToLongTimeString()));

                                Archivedb.setQuery("Update ArchiveContent Set TrueTCount=TrueTCount+" + TransactionCounter + " where Code=" + Code.ToString());
                                Archivedb.Query_Execute();

                                TransactionCounter = 0;
                                FinalQueryToRun.Clear();
                            }
                            else
                            {
                                Archivedb.setQuery("Update ArchiveContent Set FalseTCount=FalseTCount+" + TransactionCounter + " where Code=" + Code.ToString());
                                Archivedb.Query_Execute();
                                TransactionCounter = 0;
                                FinalQueryToRun.Clear();
                                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                            }
                            DbInsert.Dispose();
                        }
                    }



                    if (FinalQueryToRun.Length > 0)
                    {
                        //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally " + DateTime.Now.ToLongTimeString()));
                        JDataBase DbInsertFinally = new JDataBase();
                        DbInsertFinally.setQuery(FinalQueryToRun.ToString());
                        if (DbInsertFinally.Query_Execute() >= 0)
                        {
                            Archivedb.setQuery("Update ArchiveContent Set TrueTCount=TrueTCount+" + TransactionCounter + " where Code=" + Code.ToString());
                            Archivedb.Query_Execute();

                            TransactionCounter = 0;
                            FinalQueryToRun.Clear();
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally Sucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        else
                        {
                            Archivedb.setQuery("Update ArchiveContent Set FalseTCount=FalseTCount+" + TransactionCounter + " where Code=" + Code.ToString());
                            Archivedb.Query_Execute();
                            TransactionCounter = 0;
                            FinalQueryToRun.Clear();
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        DbInsertFinally.Dispose();
                    }

                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Update Status " + DateTime.Now.ToLongTimeString()));
                }

            }
            catch (Exception ex)
            {
                Archivedb.setQuery("Update ArchiveContent Set FalseTCount=FalseTCount+" + TransactionCounter + " where Code=" + FileCodeForUpdate.ToString());
                Archivedb.Query_Execute();
                TransactionCounter = 0;

                Archivedb.setQuery("Update ArchiveContent Set Status=3 where Code=" + FileCodeForUpdate.ToString());
                Archivedb.Query_Execute();
                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Error " + DateTime.Now.ToLongTimeString() + " " + ex.ToString()));
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
                TempDB.Dispose();
            }

            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End " + DateTime.Now.ToLongTimeString()));
        }


        public void CheckDataOfflineTicketPublicForStatus3()
        {
            int FileCodeForUpdate = 0;
            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start " + DateTime.Now.ToLongTimeString()));

            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();

            //db.setQuery(@"select isnull(max(code),0)+1 from AUTTicketTransaction");
            //DataTable DtMaxCode = db.Query_DataTable();
            //int MaxCode = Convert.ToInt32(DtMaxCode.Rows[0][0].ToString());

            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT top 1 [Code] ,cast([Contents] as varchar(max))Contents FROM [ArchiveContent]  where Status=3 and FileExtension like N'.ini'");
                DataTable DT = Archivedb.Query_DataTable();
                int Code = 0;
                string Content = "";
                StringBuilder FinalQueryToRun = new StringBuilder();
                foreach (DataRow DR in DT.Rows)
                {
                    Code = Convert.ToInt32(DR["Code"].ToString());
                    FileCodeForUpdate = Code;
                    Content = DR["Contents"].ToString();

                    string[] ContentDetailes = Content.Split(' ');
                    string BusNumber = ContentDetailes[0].ToString().Substring(12, 4);
                    string ReaderId = ContentDetailes[0].ToString().Substring(16, 2);
                    string[] DriverTemp = ContentDetailes[1].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    string DriverRFID = DriverTemp[1].ToString();
                    string LineNumber = Convert.ToInt32(ContentDetailes[4].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].ToString().Substring(2, 4)).ToString();
                    string TicketPrice = (Convert.ToInt32(ContentDetailes[4].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None)[1].ToString().Substring(ContentDetailes[4].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None)[1].ToString().Length - 4, 4)) / 10).ToString();
                    string[] TicketList = Content.Split(new string[] { " 00" }, StringSplitOptions.None);

                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query Start " + DateTime.Now.ToLongTimeString()));
                    for (int i = 21; i < TicketList.Length; i++)
                    {
                        string[] TicketDetailes = TicketList[i].ToString().Split(' ');
                        if (TicketDetailes.Length == 3)
                        {
                            DateTime EventDate;
                            try
                            {
                                EventDate = new DateTime(Convert.ToInt32(TicketDetailes[2].ToString().Substring(0, 2)) + 2000, Convert.ToInt32(TicketDetailes[2].ToString().Substring(2, 2)),
                                   Convert.ToInt32(TicketDetailes[2].ToString().Substring(4, 2)), Convert.ToInt32(TicketDetailes[1].ToString().Substring(0, 2)),
                                   Convert.ToInt32(TicketDetailes[1].ToString().Substring(2, 2)), Convert.ToInt32(TicketDetailes[1].ToString().Substring(4, 2)));
                            }
                            catch
                            {
                                EventDate = DateTime.Now;
                            }
                            FinalQueryToRun.Append(@"INSERT INTO [dbo].[AUTTicketTransaction]
                                                   ([recordNumber]
                                                   ,[EventDate]
                                                   ,[RecievedDate]
                                                   ,[DriverCardSerial]
                                                   ,[DriverPersonCode]
                                                   ,[DriverPersonName]
                                                   ,[LineNumber]
                                                   ,[ZoneCode]
                                                   ,[ZoneName]
                                                   ,[FleetCode]
                                                   ,[FleetName]
                                                   ,[BusNumber]
                                                   ,[BusCode]
                                                   ,[TransactionId]
                                                   ,[PassengerCardSerial]
                                                   ,[CardType]
                                                   ,[TicketPrice]
                                                   ,[RemainPrice]
                                                   ,[ReaderId]
                                                   ,[HeaderTransactionCode])
                                             VALUES
                                                   (0
                                                   ,'" + EventDate + @"'
                                                   ,getdate()
                                                   ,cast(0x" + DriverRFID + @" as bigint)
                                                   ,0
                                                   ,null
                                                   ," + LineNumber + @"
                                                   ,isnull((select ZoneCode from AUTLine where LineNumber = " + LineNumber + @"),0)
                                                   ,null
                                                   ,isnull((select KeyValue from AUTSettings where KeyName = N'FleetCode'),0)
                                                   ,null
                                                   ," + BusNumber + @"
                                                   ,isnull((select Code from autbus where busnumber = " + BusNumber + @"),0)
                                                   ,0
                                                   ,cast(0x" + TicketDetailes[0].ToString().Replace("\r\n", "") + @" as bigint)
                                                   ,0
                                                   ," + TicketPrice + @"
                                                   ,0
                                                   ," + ReaderId + @"
                                                   ,0)");

                        }
                        if (i % 200 == 0)
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query End " + DateTime.Now.ToLongTimeString()));
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query " + DateTime.Now.ToLongTimeString()));
                            //while (JDataBase.dbsOpen.Count > 300)
                            //    System.Threading.Thread.Sleep(10);
                            JDataBase DbInsert = new JDataBase();
                            if (FinalQueryToRun.Length > 0)
                            {
                                DbInsert.setQuery(FinalQueryToRun.ToString());
                                if (DbInsert.Query_Execute() >= 0)
                                {
                                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Sucsesfull " + DateTime.Now.ToLongTimeString()));
                                    FinalQueryToRun.Clear();
                                }
                                else
                                {
                                    FinalQueryToRun.Clear();
                                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                                }
                            }
                            DbInsert.Dispose();
                        }
                    }



                    if (FinalQueryToRun.Length > 0)
                    {
                        //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally " + DateTime.Now.ToLongTimeString()));
                        JDataBase DbInsertFinally = new JDataBase();
                        DbInsertFinally.setQuery(FinalQueryToRun.ToString());
                        if (DbInsertFinally.Query_Execute() >= 0)
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally Sucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        else
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        DbInsertFinally.Dispose();
                    }

                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Update Status " + DateTime.Now.ToLongTimeString()));
                }

            }
            catch (Exception ex)
            {
                Archivedb.setQuery("Update ArchiveContent Set Status=4 where Code=" + FileCodeForUpdate.ToString());
                Archivedb.Query_Execute();
                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Error " + DateTime.Now.ToLongTimeString() + " " + ex.ToString()));
            }
            finally
            {
                Archivedb.Dispose();
                //db.Dispose();
            }

            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End " + DateTime.Now.ToLongTimeString()));
        }


        public void CheckDataOfflineTicketPublicForStatus4()
        {
            int FileCodeForUpdate = 0;
            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start " + DateTime.Now.ToLongTimeString()));

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();


            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT top 1 [Code] ,cast([Contents] as varchar(max))Contents FROM [ArchiveContent]  where Status=4 and FileExtension like N'.ini'");
                DataTable DT = Archivedb.Query_DataTable();
                int Code = 0;
                string Content = "";
                StringBuilder FinalQueryToRun = new StringBuilder();
                foreach (DataRow DR in DT.Rows)
                {
                    Code = Convert.ToInt32(DR["Code"].ToString());
                    FileCodeForUpdate = Code;
                    Content = DR["Contents"].ToString();

                    string[] ContentDetailes = Content.Split(' ');
                    string BusNumber = ContentDetailes[0].ToString().Substring(12, 4);
                    string ReaderId = ContentDetailes[0].ToString().Substring(16, 2);
                    string[] DriverTemp = ContentDetailes[1].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    string DriverRFID = DriverTemp[1].ToString();
                    string LineNumber = Convert.ToInt32(ContentDetailes[4].ToString().Substring(2, 4)).ToString();
                    string TicketPrice = (Convert.ToInt32(ContentDetailes[5].ToString().Substring(ContentDetailes[5].ToString().Length - 4, 4)) / 10).ToString();
                    string[] TicketList = Content.Split(new string[] { " 00" }, StringSplitOptions.None);

                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query Start " + DateTime.Now.ToLongTimeString()));
                    for (int i = 21; i < TicketList.Length; i++)
                    {
                        string[] TicketDetailes = TicketList[i].ToString().Split(' ');
                        if (TicketDetailes.Length == 3)
                        {
                            DateTime EventDate;
                            try
                            {
                                EventDate = new DateTime(Convert.ToInt32(TicketDetailes[2].ToString().Substring(0, 2)) + 2000, Convert.ToInt32(TicketDetailes[2].ToString().Substring(2, 2)),
                                   Convert.ToInt32(TicketDetailes[2].ToString().Substring(4, 2)), Convert.ToInt32(TicketDetailes[1].ToString().Substring(0, 2)),
                                   Convert.ToInt32(TicketDetailes[1].ToString().Substring(2, 2)), Convert.ToInt32(TicketDetailes[1].ToString().Substring(4, 2)));
                            }
                            catch
                            {
                                EventDate = DateTime.Now;
                            }
                            FinalQueryToRun.Append(@"INSERT INTO [dbo].[AUTTicketTransaction]
                                                   ([recordNumber]
                                                   ,[EventDate]
                                                   ,[RecievedDate]
                                                   ,[DriverCardSerial]
                                                   ,[DriverPersonCode]
                                                   ,[DriverPersonName]
                                                   ,[LineNumber]
                                                   ,[ZoneCode]
                                                   ,[ZoneName]
                                                   ,[FleetCode]
                                                   ,[FleetName]
                                                   ,[BusNumber]
                                                   ,[BusCode]
                                                   ,[TransactionId]
                                                   ,[PassengerCardSerial]
                                                   ,[CardType]
                                                   ,[TicketPrice]
                                                   ,[RemainPrice]
                                                   ,[ReaderId]
                                                   ,[HeaderTransactionCode])
                                             VALUES
                                                   (0
                                                   ,'" + EventDate + @"'
                                                   ,getdate()
                                                   ,cast(0x" + DriverRFID + @" as bigint)
                                                   ,0
                                                   ,null
                                                   ," + LineNumber + @"
                                                   ,isnull((select ZoneCode from AUTLine where LineNumber = " + LineNumber + @"),0)
                                                   ,null
                                                   ,isnull((select KeyValue from AUTSettings where KeyName = N'FleetCode'),0)
                                                   ,null
                                                   ," + BusNumber + @"
                                                   ,isnull((select Code from autbus where busnumber = " + BusNumber + @"),0)
                                                   ,0
                                                   ,cast(0x" + TicketDetailes[0].ToString().Replace("\r\n", "") + @" as bigint)
                                                   ,0
                                                   ," + TicketPrice + @"
                                                   ,0
                                                   ," + ReaderId + @"
                                                   ,0)");

                        }
                        if (i % 200 == 0)
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Generate Query End " + DateTime.Now.ToLongTimeString()));
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query " + DateTime.Now.ToLongTimeString()));
                            //while (JDataBase.dbsOpen.Count > 300)
                                //System.Threading.Thread.Sleep(10);
                            JDataBase DbInsert = new JDataBase();
                            DbInsert.setQuery(FinalQueryToRun.ToString());
                            if (DbInsert.Query_Execute() >= 0)
                            {
                                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Sucsesfull " + DateTime.Now.ToLongTimeString()));
                                FinalQueryToRun.Clear();
                            }
                            else
                            {
                                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                            }
                            DbInsert.Dispose();
                        }
                    }



                    if (FinalQueryToRun.Length > 0)
                    {
                        //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally " + DateTime.Now.ToLongTimeString()));
                        JDataBase DbInsertFinally = new JDataBase();
                        DbInsertFinally.setQuery(FinalQueryToRun.ToString());
                        if (DbInsertFinally.Query_Execute() >= 0)
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally Sucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        else
                        {
                            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Run Query Finally UnSucsesfull " + DateTime.Now.ToLongTimeString()));
                        }
                        DbInsertFinally.Dispose();
                    }

                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Update Status " + DateTime.Now.ToLongTimeString()));
                }

            }
            catch (Exception ex)
            {
                Archivedb.setQuery("Update ArchiveContent Set Status=5 where Code=" + FileCodeForUpdate.ToString());
                Archivedb.Query_Execute();
                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Error " + DateTime.Now.ToLongTimeString() + " " + ex.ToString()));
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }

            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End " + DateTime.Now.ToLongTimeString()));
        }


        //public void CheckDataOfflineTicket()
        //{
        //    ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
        //    JDataBase DB = new JDataBase();
        //    try
        //    {
        //        Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Status=1 and FileExtension like N'.BUS'");
        //        DataTable DT = Archivedb.Query_DataTable();
        //        foreach (DataRow DR in DT.Rows)
        //        {
        //            byte[] Content = (DR["Contents"] as byte[]);
        //            int Code = (int)DR["Code"];

        //            int i = 0;
        //            while (i < Content.Length)
        //            {
        //                try
        //                {
        //                    JTransactionTicketOffline TransactionTicketOffline = new JTransactionTicketOffline();
        //                    Tuple<int> result = TransactionTicketOffline.SetValueOffline(Content, i);

        //                    bool isSuccess = true;
        //                    JTransactionTicketHeader TH = new JTransactionTicketHeader();
        //                    TH.busSerial = TransactionTicketOffline.BusID;
        //                    TH.DATE = JTransactions.ConvertUintToDateTime(TransactionTicketOffline.DateTime);
        //                    TH.DriverSerialCard = TransactionTicketOffline.DriverID.ToString();
        //                    TH.LineNumber = TransactionTicketOffline.LineNumber;
        //                    DateTime date = TH.DATE;

        //                    JTransactionTicket Ticket = new JTransactionTicket();
        //                    Ticket.CardType = TransactionTicketOffline.CardType;
        //                    Ticket.PassengerCardSerial = (ulong)TransactionTicketOffline.PassengerID;
        //                    Ticket.RemainPrice = TransactionTicketOffline.RemaningPrice;
        //                    Ticket.TicketPrice = TransactionTicketOffline.Price;
        //                    Ticket.Time = new int[3] { TH.DATE.Hour, 
        //                    TH.DATE.Minute, 
        //                    TH.DATE.Second };

        //                    DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

        //                    isSuccess = Transaction.JTicketTransactions.AddTicketTransactionPublic(TH, Ticket, Code, "0", (float)TransactionTicketOffline.BusID, new byte[] { 1 },DB);
        //                    if (isSuccess)
        //                    {
        //                    }
        //                    else
        //                        if (isSuccess == false)
        //                        {
        //                            //ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
        //                            //    TH.DATE.ToString()));
        //                            //break;
        //                        }

        //                }//try
        //                catch (Exception ex)
        //                {
        //                    ClassLibrary.JSystem.Except.AddException(ex);
        //                }
        //                finally
        //                {
        //                }

        //                i += 32;

        //            }// While
        //            Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
        //            Archivedb.Query_Execute();
        //        }//foreach
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        Archivedb.Dispose();
        //        DB.Dispose();
        //    }
        //}

        //Open Bus Offline Files
        public DataTable OpenBusOfflineTicketFile(int ArchiveContentCode)
        {
            DataTable dt = new DataTable();
            dt = null;
            return dt;
        }


        public int UpdateSocketCheckDataAVL(Int64 Code)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("update ClsSocketClientDataManager set IsProceced=1,[GetDate] = GetDate() where code = " + Code);
                return db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }









        public static DateTime ConvertBytesToDateTime(byte[] data)
        {
            try
            {
                byte[] bYear = new byte[1];
                Buffer.BlockCopy(data, 0, bYear, 0, 1);
                int year = bYear.Select(m => Convert.ToInt32(m)).First() + 2000;

                byte[] bMonth = new byte[1];
                Buffer.BlockCopy(data, 1, bMonth, 0, 1);
                int month = bMonth.Select(m => Convert.ToInt32(m)).First();

                byte[] bDay = new byte[1];
                Buffer.BlockCopy(data, 2, bDay, 0, 1);
                int day = bDay.Select(m => Convert.ToInt32(m)).First();

                return new DateTime(year, month, day);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static int[] ConvertBytesToTime(byte[] data)
        {
            try
            {
                byte[] bHour = new byte[1];
                Buffer.BlockCopy(data, 0, bHour, 0, 1);
                int hour = bHour.Select(m => Convert.ToInt32(m)).First();
                if (!(hour >= 1 && hour <= 23))
                    hour = 9;

                byte[] bMinute = new byte[1];
                Buffer.BlockCopy(data, 1, bMinute, 0, 1);
                int minute = bMinute.Select(m => Convert.ToInt32(m)).First();
                if (!(minute >= 1 && minute <= 59))
                    minute = 9;

                byte[] bSecond = new byte[1];
                Buffer.BlockCopy(data, 2, bSecond, 0, 1);
                int second = bSecond.Select(m => Convert.ToInt32(m)).First();
                if (!(second >= 1 && second <= 59))
                    second = 9;

                return new int[] { hour, minute, second };
            }
            catch
            {
                return new int[] { 0, 0, 0 };
            }
        }

        /// <summary>
        /// NMEA Coordinate System To Decimal Coordinate System
        /// </summary>
        /// <param name="d">NMEA Lat/Long value in dd.mmss Format (Example: 36.2533 (Result: 36 + 25.33/60))</param>
        /// <returns>Decimal Lat/Long value in double format.</returns>
        public static double ConvertNMEAToDecimal(double d)
        {
            string[] str = d.ToString("00.0000").Split('.');

            double o = Convert.ToDouble(str[1].Substring(0, 2) + "." + str[1].Substring(2, 2));
            return Convert.ToDouble(str[0]) + (o / 60);
        }


        public static UInt32 ConvertDateTimeToUint(DateTime dateTime)
        {

            UInt32 temp = 0, outPut = 0;

            temp = (UInt32)dateTime.Year - 2000;
            outPut |= (temp << 26);
            temp = (UInt32)dateTime.Month;
            outPut |= (temp << 22);
            temp = (UInt32)dateTime.Day;
            outPut |= (temp << 17);
            temp = (UInt32)dateTime.Hour;
            outPut |= (temp << 12);
            temp = (UInt32)dateTime.Minute;
            outPut |= (temp << 6);
            temp = (UInt32)dateTime.Second;
            outPut |= temp;

            return outPut;
        }

        public static DateTime ConvertUintToDateTime(UInt64 pDateTime)
        {
            UInt64 temp = 0;

            temp = (pDateTime & 63);//second:6
            UInt64 sec = temp;
            temp = (pDateTime & 4032);//minute:6
            UInt64 minute = (temp >> 6);
            temp = (pDateTime & 126976);//hour:5
            UInt64 hour = (temp >> 12);
            temp = (pDateTime & 4063232);//day:5
            UInt64 day = (temp >> 17);
            temp = (pDateTime & 62914560);//month:4
            UInt64 month = (temp >> 22);
            temp = (pDateTime & 4227858432);//year:6
            UInt64 year = (temp >> 26);

            return DateTime.Parse((year + 2000) + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + sec);

        }
    }

    /// <summary>
    /// Send Transaction to Archice Document for Accounting
    /// </summary>
    //public class JCloseTransaction
    //{
    //    public int Code { get; set; }
    //    public string Name { get; set; }
    //    public DateTime CloseDate { get; set; }
    //    public int Closer { get; set; }
    //}
    public class TransactionClass
    {
        //public static int GetHeaderCode(Int64 hIMEI, UInt32 hBusSerial, byte[] hVersion)
        //{
        //    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //    try
        //    {
        //        db.setQuery("Select Code From AUTHeaderTransaction where BusSerial=@BusSerial and IMEI=@IMEI and Version=@Version");
        //        db.AddParams("BusSerial", hBusSerial);
        //        db.AddParams("IMEI", hIMEI);
        //        db.AddParams("Version", hVersion);
        //        DataTable dt = db.Query_DataTable();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            return Convert.ToInt32(dt.Rows[0]["Code"]);
        //        }
        //        db.setQuery("INSERT INTO AUTHeaderTransaction (BusSerial, IMEI, Version) VALUES(@BusSerial, @IMEI, @Version);" +
        //                    " Select @@IDENTITY");
        //        return db.Query_Execute();
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}
    }
}
