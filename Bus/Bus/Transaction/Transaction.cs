using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;
using ClassLibrary.CRC;
using System.Diagnostics;
using System.Threading;
using Renci.SshNet;
using System.IO;

namespace BusManagment.Transaction
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

    public struct AVLStruct
    {
        public Int64 IMEI;
        public int LayerID;
        public float Lon;
        public float Lat;
        public float Alt;
        public DateTime DateSend;
        public int Speed;
        public int ChargeSIMCard;
        public int MsgType;
        public int BattryCharge;
        public int GpsAnt;
        public int GsmAnt;
        public float Course;
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
            try
            {
                string err = "";
                int errNum = 0;

                // Check SizeOfBytes
                if (pData.Length - pStart < 15)
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

                    byte[] bbusSerial = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 8, bbusSerial, 0, 4);
                    this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);

                    if (busSerial == 1111)
                        busSerial = 1111;

                    byte[] bVERSION = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 12, bVERSION, 0, 3);
                    this.VERSION = bVERSION;
                    pOldData.AddRange(bVERSION);
                }

                return new Tuple<int, string, int, List<byte>>(8 + 4 + 3 + pStart, err, errNum, pOldData);
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return new Tuple<int, string, int, List<byte>>(8 + 4 + 3 + pStart, ex.Message, 1, pOldData);
            }
        }

    }

    //public class JTransactionDriver
    //{
    //    public int Code { get; set; }
    //    public string GsmSerialNumber { get; set; } //len 8
    //    public string Version { get; set; }         //len 3
    //    public string EventDate { get; set; }       //len 3
    //    /// <summary>
    //    /// Bus Code + Device Code Front is 1 AND back is 2 12031-->1203 is bus code and 1 is CardReader Front
    //    /// </summary>
    //    public string DriveCart { get; set; }       //len 4
    //    public int LineNumber { get; set; }         //len 2
    //    public int DeviceNum { get; set; }          //len 3
    //    /// <summary>
    //    /// Uniq Code is Send From Device
    //    /// </summary>
    //    public int SendCode { get; set; }

    //    public bool Process(byte[] pData, int pStart)
    //    {
    //        return false;
    //    }

    //    public int Insert()
    //    {
    //        return 0;
    //    }
    //}

    public class JTransactionTicketHeader
    {
        public DateTime DATE; // 3
        public string DriverSerialCard; // 4
        public uint LineNumber; // 4
        public UInt32 busSerial; // 4

        public List<JTransactionTicket> Tickets = new List<JTransactionTicket>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;
            int DriverCardSerialLen = 0;
            // Check SizeOfBytes
            if (//(pData.Length - pStart) > 0 & 
                (pData.Length - pStart) < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":TH:" + (pData.Length - pStart).ToString() + "/15";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {


                byte[] bVERSION = new byte[3];
                Buffer.BlockCopy(pData, 12, bVERSION, 0, 3);
                DateTime VersionDate = ClassLibrary.JDateTime.GregorianDate(1300 + bVERSION[0], bVERSION[1], bVERSION[2]);

                if (VersionDate < Convert.ToDateTime("2015-05-10 00:00:00"))
                {
                    DriverCardSerialLen = 4;
                    byte[] bDate = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 0, bDate, 0, 3);
                    this.DATE = JTransactions.ConvertBytesToDateTime(bDate);
                    pOldData.AddRange(bDate);

                    byte[] bDriverSerialCard = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 3, bDriverSerialCard, 0, 4);
                    this.DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0).ToString();
                    pOldData.AddRange(bDriverSerialCard);

                    byte[] bLineNumber = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 7, bLineNumber, 0, 4);
                    this.LineNumber = BitConverter.ToUInt32(bLineNumber, 0);
                    try
                    {
                        pOldData.AddRange(BitConverter.GetBytes(Convert.ToInt32(this.LineNumber)).Take(2));
                    }
                    catch
                    {
                        pOldData.AddRange(new byte[] { bLineNumber[2], bLineNumber[3] });
                    }
                    //pOldData.AddRange(bLineNumber);

                    byte[] bbusSerial = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 11, bbusSerial, 0, 4);
                    this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);
                    if (busSerial == 1111)
                    {
                        busSerial = 1111;
                    }
                    pOldData.AddRange(new byte[] { bbusSerial[1], bbusSerial[2], bbusSerial[3] });
                    //pOldData.AddRange(bbusSerial);
                }
                else
                {
                    DriverCardSerialLen = 8;
                    byte[] bDate = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 0, bDate, 0, 3);
                    this.DATE = JTransactions.ConvertBytesToDateTime(bDate);
                    pOldData.AddRange(bDate);

                    byte[] bDriverSerialCard = new byte[8];
                    Buffer.BlockCopy(pData, pStart + 3, bDriverSerialCard, 0, 8);
                    this.DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0).ToString();
                    pOldData.AddRange(bDriverSerialCard);

                    byte[] bLineNumber = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 11, bLineNumber, 0, 4);
                    this.LineNumber = BitConverter.ToUInt32(bLineNumber, 0);
                    try
                    {
                        pOldData.AddRange(BitConverter.GetBytes(Convert.ToInt32(this.LineNumber)).Take(2));
                    }
                    catch
                    {
                        pOldData.AddRange(new byte[] { bLineNumber[2], bLineNumber[3] });
                    }
                    //pOldData.AddRange(bLineNumber);

                    byte[] bbusSerial = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 15, bbusSerial, 0, 4);
                    this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);

                    if (busSerial == 1111)
                        busSerial = 1111;

                    pOldData.AddRange(new byte[] { bbusSerial[1], bbusSerial[2], bbusSerial[3] });
                    //pOldData.AddRange(bbusSerial);
                }


            }

            return new Tuple<int, string, int, List<byte>>(3 + DriverCardSerialLen + 4 + 4 + pStart, err, errNum, pOldData);
        }
    }

    public class JTransactionTicket
    {
        public uint transactionid;      //4
        public UInt64 PassengerCardSerial;//8
        public uint CardType;           //1
        public int[] Time;              //3
        public uint TicketPrice;	    //2
        public UInt32 RemainPrice;	    //4
        public uint ReaderID;           //1
        public byte Bin;           //1
        public UInt32 TerminalID;           //4
        public byte WaletID;           //1
        public byte CType;           //1
        public UInt32 LTD;           //4
        public UInt64 ServerMac;           //8
        public UInt64 MacOut;           //8
        public byte LTB;           //1
        public UInt16 Counter;           //2
        public UInt32 ServerID;
        public UInt16 BankType; //1
        public uint CardVersion; //1

        public byte[] ShiftRight(byte[] value, int bitcount)
        {
            byte[] temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, 0, temp, bitcount / 8, temp.Length - (bitcount / 8));
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    temp[i] >>= bitcount % 8;
                    if (i > 0)
                    {
                        temp[i] |= (byte)(temp[i - 1] << 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }

        public static byte[] ShiftLeft(byte[] value, int bitcount)
        {
            byte[] temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, bitcount / 8, temp, 0, temp.Length - (bitcount / 8));
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] <<= bitcount % 8;
                    if (i < temp.Length - 1)
                    {
                        temp[i] |= (byte)(temp[i + 1] >> 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            int ccount = 0;
            int PassengerCardSerialLen = 0;
            int RemainPriceLen = 0;

            int TicketLengh = 17;
            byte[] btransactionidForerr = new byte[4];

            if (pData.Length - pStart > 4)
            {
                Buffer.BlockCopy(pData, pStart + 0, btransactionidForerr, 0, 4);
                UInt32 transactionidForerr = BitConverter.ToUInt32(btransactionidForerr, 0);

                if (transactionidForerr == 999999999)
                {
                    TicketLengh = 58;
                }
            }

            // Check SizeOfBytes
            if (//(pData.Length - pStart) > 0 & 
                (pData.Length - pStart) < TicketLengh)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":T:" + (pData.Length - pStart).ToString() + "/17";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] btransactionid = new byte[4];
                Buffer.BlockCopy(pData, pStart + 0, btransactionid, 0, 4);
                this.transactionid = BitConverter.ToUInt32(btransactionid, 0);


                byte[] bCardType = new byte[1];

                byte[] bTime = new byte[3];

                byte[] bTicketPrice = new byte[2];

                byte[] bRemainPrice = new byte[4];
                byte[] bReaderID = new byte[1];
                if (transactionid == 999999999)
                {
                    byte[] bPassengerCardSerial = new byte[8];
                    PassengerCardSerialLen = 8;
                    //byte[] bPassengerCardSerial = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 4, bPassengerCardSerial, 0, 8);
                    int iTempCounter = 0;
                    if (bPassengerCardSerial[0] == 0
                            && bPassengerCardSerial[1] == 0
                            && bPassengerCardSerial[2] == 0
                            && bPassengerCardSerial[3] == 0
                        )
                    {
                        while (
                            iTempCounter < 4 &&
                            bPassengerCardSerial[0] == 0 &&
                            BitConverter.ToUInt64(bPassengerCardSerial, 0) > 0
                            )
                        {
                            bPassengerCardSerial = ShiftLeft(bPassengerCardSerial, 8);
                            iTempCounter++;
                        }
                    }
                    this.PassengerCardSerial = BitConverter.ToUInt64(bPassengerCardSerial, 0);
                    pOldData.AddRange(bPassengerCardSerial);
                    if (PassengerCardSerial == 1154669733)
                    {
                        PassengerCardSerial = 1154669733;
                    }
                    //byte[] bCardType = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 12, bCardType, 0, 1);
                    this.CardType = bCardType.First();
                    pOldData.AddRange(bCardType);

                    //byte[] bTime = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 13, bTime, 0, 3);
                    this.Time = JTransactions.ConvertBytesToTime(bTime);
                    pOldData.AddRange(bTime);

                    //byte[] bTicketPrice = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 16, bTicketPrice, 0, 2);
                    this.TicketPrice = BitConverter.ToUInt16(bTicketPrice, 0);
                    pOldData.AddRange(bTicketPrice);

                    //byte[] bRemainPrice = new byte[2];
                    RemainPriceLen = 4;
                    Buffer.BlockCopy(pData, pStart + 18, bRemainPrice, 0, 4);
                    this.RemainPrice = BitConverter.ToUInt32(bRemainPrice, 0);
                    pOldData.AddRange(bRemainPrice);

                    //byte[] bReaderID = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 22, bReaderID, 0, 1);
                    this.ReaderID = bReaderID.First();

                    byte[] bBin = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 23, bBin, 0, 1);
                    this.Bin = bBin.First();
                    ccount = ccount + 1;

                    byte[] BTerminalID = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 24, BTerminalID, 0, 4);
                    this.TerminalID = BitConverter.ToUInt32(BTerminalID, 0);
                    ccount = ccount + 4;

                    byte[] bWaletID = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 28, bWaletID, 0, 1);
                    this.WaletID = bWaletID.First();
                    ccount = ccount + 1;

                    byte[] bCType = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 29, bCType, 0, 1);
                    this.CType = bCType.First();
                    ccount = ccount + 1;

                    byte[] BLTD = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 30, BLTD, 0, 4);
                    this.LTD = BitConverter.ToUInt32(BLTD, 0);
                    ccount = ccount + 4;

                    byte[] BServerMac = new byte[8];
                    Buffer.BlockCopy(pData, pStart + 34, BServerMac, 0, 8);
                    this.ServerMac = BitConverter.ToUInt64(BServerMac, 0);
                    ccount = ccount + 8;

                    byte[] BMacOut = new byte[8];
                    Buffer.BlockCopy(pData, pStart + 42, BMacOut, 0, 8);
                    this.MacOut = BitConverter.ToUInt64(BMacOut, 0);
                    ccount = ccount + 8;

                    byte[] bLTB = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 50, bLTB, 0, 1);
                    this.LTB = bLTB.First();
                    ccount = ccount + 1;

                    byte[] BCounetr = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 51, BCounetr, 0, 2);
                    this.Counter = BitConverter.ToUInt16(BCounetr, 0);
                    ccount = ccount + 2;

                    byte[] BServerId = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 53, BServerId, 0, 4);
                    this.ServerID = BitConverter.ToUInt32(BServerId, 0);
                    ccount = ccount + 4;

                    byte[] bBankType = new byte[1];
                    Buffer.BlockCopy(pData, pStart + 57, bBankType, 0, 1);
                    this.BankType = bBankType.First();
                    ccount = ccount + 1;
                    if ((this.CardType >= 1 && this.CardType < 3 && this.BankType == 0)
                        ||
                        (this.BankType == 9))
                    {
                        ushort t = (ushort)this.CardType;
                        this.CardType = this.BankType;
                        this.BankType = t;
                        this.CardVersion = 0;
                    }

                }
                else
                    if (this.CardType == 3)
                    {
                        this.CardVersion = (ushort)this.CardType;
                        CardType = 0;
                    }
                    else
                    {
                        byte[] bPassengerCardSerial = new byte[4];
                        PassengerCardSerialLen = 4;
                        Buffer.BlockCopy(pData, pStart + 4, bPassengerCardSerial, 0, 4);
                        this.PassengerCardSerial = BitConverter.ToUInt32(bPassengerCardSerial, 0);
                        pOldData.AddRange(bPassengerCardSerial);

                        //byte[] bCardType = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 8, bCardType, 0, 1);
                        this.CardType = bCardType.First();
                        pOldData.AddRange(bCardType);

                        // byte[] bTime = new byte[3];
                        Buffer.BlockCopy(pData, pStart + 9, bTime, 0, 3);
                        this.Time = JTransactions.ConvertBytesToTime(bTime);
                        pOldData.AddRange(bTime);

                        //byte[] bTicketPrice = new byte[2];
                        Buffer.BlockCopy(pData, pStart + 12, bTicketPrice, 0, 2);
                        this.TicketPrice = BitConverter.ToUInt16(bTicketPrice, 0);
                        pOldData.AddRange(bTicketPrice);

                        RemainPriceLen = 2;
                        Buffer.BlockCopy(pData, pStart + 14, bRemainPrice, 0, 2);
                        this.RemainPrice = BitConverter.ToUInt32(bRemainPrice, 0);
                        pOldData.AddRange(bRemainPrice);

                        //byte[] bReaderID = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 16, bReaderID, 0, 1);
                        this.ReaderID = bReaderID.First();

                        ccount = 0;
                        this.Bin = 0;
                        this.TerminalID = 0;
                        this.WaletID = 0;
                        this.CType = 0;
                        this.LTD = 0;
                        this.ServerMac = 0;
                        this.MacOut = 0;
                        this.LTB = 0;
                        this.Counter = 0;
                        this.ServerID = 0;
                        this.BankType = 0;
                    }
            }

            return new Tuple<int, string, int, List<byte>>(4 + PassengerCardSerialLen + 1 + 3 + 2 + RemainPriceLen + 1 + ccount + pStart, err, errNum, pOldData);
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
        public UInt32 busLine;//4

        public List<JTransactionAVL> AVLs = new List<JTransactionAVL>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;
            int BusLineCount = 0;
            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":AH:" + (pData.Length - pStart).ToString() + "/13";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
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
                this.GpsAnttena = bGpsAnttena.First();
                pOldData.AddRange(bGpsAnttena);

                byte[] bGsmAnttena = new byte[1];
                Buffer.BlockCopy(pData, pStart + 8, bGsmAnttena, 0, 1);
                this.GsmAnttena = bGsmAnttena.First();
                pOldData.AddRange(bGsmAnttena);

                byte[] bbusSerial = new byte[4];
                Buffer.BlockCopy(pData, pStart + 9, bbusSerial, 0, 4);
                this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);
                if (this.busSerial == 1111)
                {
                    this.busSerial = 1111;
                }

                try
                {
                    byte[] bVERSION = new byte[3];
                    Buffer.BlockCopy(pData, 12, bVERSION, 0, 3);
                    DateTime VersionDate = ClassLibrary.JDateTime.GregorianDate(1300 + bVERSION[0], bVERSION[1], bVERSION[2]);
                    if (VersionDate >= Convert.ToDateTime("2016-04-04 00:00:00"))
                    {
                        byte[] bbusLine = new byte[4];
                        Buffer.BlockCopy(pData, pStart + 13, bbusLine, 0, 4);
                        this.busLine = BitConverter.ToUInt32(bbusLine, 0);
                        BusLineCount = 4;
                    }
                }
                catch
                {

                }
            }

            return new Tuple<int, string, int, List<byte>>(3 + 2 + 2 + 1 + 1 + 4 + BusLineCount + pStart, err, errNum, pOldData);
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
        //public int Order;


        public JTransactionAVL()
        {
        }
        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            try
            {
                string err = "";
                int errNum = 0;

                // Check SizeOfBytes
                if (pData.Length < pStart + 20)
                {

                    err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":A:" + (pData.Length - pStart).ToString() + "/18";
                    errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
                }
                if (pData.Length - pStart < 15)
                {
                    err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":A:" + (pData.Length - pStart).ToString() + "/18";
                    errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
                }
                else
                {
                    byte[] btransactionid = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 0, btransactionid, 0, 4);
                    this.transactionid = BitConverter.ToUInt32(btransactionid, 0);

                    byte[] bTime = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 4, bTime, 0, 3);
                    this.Time = JTransactions.ConvertBytesToTime(bTime);
                    pOldData.AddRange(bTime);

                    float NewLon;
                    byte[] bLon = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 7, bLon, 0, 4);
                    NewLon = BitConverter.ToSingle(bLon, 0);
                    int TempNewLon = (int)Math.Floor(NewLon);
                    if (TempNewLon > 999)
                        this.Lon = Transaction.JTransactions.ConvertNMEAToDecimal(NewLon);
                    else
                        this.Lon = NewLon;
                    pOldData.AddRange(bLon);

                    float NewLat;
                    byte[] bLat = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 11, bLat, 0, 4);
                    NewLat = BitConverter.ToSingle(bLat, 0);
                    int TempNewLat = (int)Math.Floor(NewLat);
                    if (TempNewLat > 999)
                        this.Lat = Transaction.JTransactions.ConvertNMEAToDecimal(NewLat);
                    else
                        this.Lat = NewLat;
                    pOldData.AddRange(bLat);

                    byte[] bAlt = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 15, bAlt, 0, 2);
                    this.Alt = BitConverter.ToUInt16(bAlt, 0);
                    pOldData.AddRange(bAlt);

                    byte[] bSpeed = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 17, bSpeed, 0, 2);
                    this.Speed = BitConverter.ToUInt16(bSpeed, 0);
                    pOldData.AddRange(bSpeed);

                    if (pData.Length > pStart + 19)
                    {
                        byte[] bCource = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 19, bCource, 0, 1);
                        this.Cource = bCource.First();
                        pOldData.AddRange(bCource);
                    }

                    if (pData.Length > pStart + 20)
                    {
                        byte[] bDir = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 20, bDir, 0, 1);
                        this.Dir = bDir.First();
                        pOldData.AddRange(bDir);
                    }
                }

                return new Tuple<int, string, int, List<byte>>(4 + 3 + 4 + 4 + 2 + 2 + 1 + 1 + pStart, err, errNum, pOldData);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string, int, List<byte>>(4 + 3 + 4 + 4 + 2 + 2 + 1 + 1 + pStart, ex.Message, 1, pOldData);
            }
        }


        public static void GetClassNameBusNumberTeltonika(List<AVLStruct> pData, Int64 pRecordNumber, bool Public, bool processWithDelay = false)
        {
            JTransactions t = new JTransactions();
            if (pData != null && pData.Count > 0)
            {
                bool DelayProcess = false;
                if (processWithDelay)
                    try
                    {
                        DelayProcess = (JDataBase.dbsOpen.Count > 500);
                        if (!DelayProcess && pData.Count > 0)
                        {
                            var minDateTime = pData.Min(x => x.DateSend);
                            //DateTime avlDate = pData[0].DateSend;
                            DelayProcess = minDateTime < DateTime.Now.AddMinutes(-15);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JMainFrame.Except.AddException(ex);
                    }

                if (!DelayProcess)
                {
                    BusManagment.Transaction.JTransactions.ProcessAvlData(pData, pRecordNumber, true, true);
                }
                else
                {
                    BusManagment.Transaction.JTransactions.UpdateSocketCheckDataAVL(null, pRecordNumber
                        , BusManagment.Transaction.SocketDataState.Teltonika_InList.GetHashCode()); // Process Letter for  teletonika
                }
            }
            else
            {
                BusManagment.Transaction.JTransactions.UpdateSocketCheckDataAVL(null, pRecordNumber
                   , BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode()); // Error
            }

        }
        public static KeyValuePair<string, int> GetClassNameBusNumber(byte[] pData, Int64 pRecordNumber, bool Public)
        {
            JTransactions t = new JTransactions();
            Tuple<JTransactionHeader, byte[]> item = t.Process(pData);
            if (item != null && item.Item1.AVLHeaders.Count > 0)
            {
                bool DelayProcess = false;
                try
                {
                    DelayProcess = (JDataBase.dbsOpen.Count > 500);
                    if (!DelayProcess && item.Item1.AVLHeaders[0].AVLs.Count > 0)
                    {
                        DateTime date = item.Item1.AVLHeaders[0].DATE;
                        //int[] time = item.Item1.AVLHeaders[0].AVLs[item.Item1.AVLHeaders[0].AVLs.Count - 1].Time;
                        var avlDate = item.Item1.AVLHeaders[0].AVLs.Min(x => date.Date
                            .AddHours(x.Time[0])
                            .AddMinutes(x.Time[1] > 59 ? 59 : x.Time[1])
                            .AddSeconds(x.Time[2] > 59 ? 59 : x.Time[2]));
                        //DateTime avlDate = new DateTime(date.Year, date.Month, date.Day, time[0], time[1] > 59 ? 59 : time[1], time[2] > 59 ? 59 : time[2]);
                        if (avlDate < DateTime.Now.AddMinutes(-3) && !Public)
                            DelayProcess = true;
                    }
                }
                catch (Exception ex)
                {
                    ClassLibrary.JMainFrame.Except.AddException(ex);
                }
                if (!DelayProcess)
                {
                    if ((int)item.Item1.AVLHeaders[0].busSerial <= 9999)
                    {
                        t.ProcessAvlData(item, pRecordNumber, true, true);
                    }
                    else
                    {
                        BusManagment.Transaction.JTransactions.UpdateSocketCheckDataAVL(null, pRecordNumber,
                            BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                        DelayProcess = true;
                    }
                }
                else
                {
                    BusManagment.Transaction.JTransactions.UpdateSocketCheckDataAVL(null, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode());
                }
                KeyValuePair<string, int> K = new KeyValuePair<string, int>("BusManagment.TransactionAVL", (int)item.Item1.AVLHeaders[0].busSerial);
                return K;
            }
            else
            {
                BusManagment.Transaction.JTransactions.UpdateSocketCheckDataAVL(null, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                KeyValuePair<string, int> K = new KeyValuePair<string, int>("BusManagment.TransactionAVL", -1);
                return K;
            }
        }
    }

    public enum SocketDataState
    {
        Bus_InList = 0,
        Bus_SuccessProcess = 1,
        Bus_ErrorProcess = 2,
        Bus_InProcess = 3,

        Teltonika_InList = 10,
        Teltonika_SuccessProcess = 11,
        Teltonika_ErrorProcess = 12,
        Teltonika_InProcess = 13,

        OnlineReaderTicket_InList = 20,
        OnlineReaderTicket_SuccessProcess = 21,
        OnlineReaderTicket_ErrorProcess = 22,
        OnlineReaderTicket_InProcess = 23,

        OnlineReaderConfig_InList = 24,
        OnlineReaderConfig_SuccessProcess = 25,
        OnlineReaderConfig_ErrorProcess = 26,
        OnlineReaderConfig_InProcess = 27,

        OnlineReaderDriverLoginLogout_InList = -28,
        OnlineReaderDriverLoginLogout_SuccessProcess = -29,
        OnlineReaderDriverLoginLogout_ErrorProcess = -30,
        OnlineReaderDriverLoginLogout_InProcess = -31,
    }

    public class JTransactions
    {
        public Tuple<JTransactionHeader, byte[]> Process(byte[] pData)
        {
            try
            {
                int NextIndex = 0;
                List<byte> OldData = new List<byte>();

                JTransactionHeader TH = new JTransactionHeader();
                Tuple<int, string, int, List<byte>> result = TH.SetValue(pData, 0, OldData);
                if (TH.busSerial > 9999)
                {
                    return null;
                }
                if (TH.busSerial == 1111)
                {
                    NextIndex = 0;
                }
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
                        try
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
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }

                    else if (_NCode == JTransactionType.TicketData.GetHashCode())
                    {
                        try
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
                            if (TH != null && TH.TicketHeaders != null && TH.TicketHeaders.Last().Tickets != null)
                                TH.TicketHeaders.Last().Tickets.Add(TT);
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }

                    else if (_NCode == JTransactionType.AVLHeder.GetHashCode())
                    {
                        try
                        {
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
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }

                    else if (_NCode == JTransactionType.AVLData.GetHashCode())
                    {
                        try
                        {
                            if (TH.AVLHeaders.Count == 0)
                                return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
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
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }

                    else
                    {
                        //TH.ErrorNum = 1;

                    }

                }

                return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
            }
            catch (Exception ex)
            {

                JSystem.Except.AddException(new Exception("public Tuple<JTransactionHeader, byte[]> Process(byte[] pData) " + ex));
                return null;
            }
        }

        struct BusTicketRecord
        {
            public byte[] Data;
            public Int64 RecordNumber;
            public Int64 Code;
        }

        struct BusHandHeldTicketRecord
        {
            public byte[] Data;
            public int Code;
        }


        private static readonly object listLock = new object();


        public void CheckDataTicketHandHeld()
        {

            ClassLibrary.JDataBase DB = new JDataBase();
            try
            {
                DataTable dt;
                lock (listLock)
                {
                    DB.setQuery("Select * from AUTHandHeldDeviceTicket where IsProceced=0 order by Code desc");
                    dt = DB.Query_DataTable();
                }
                foreach (DataRow row in dt.Rows)
                {
                    byte[] Data = (byte[])row["Data"];
                    Int64 RecordNumber = 0;
                    ProcessHandHeldTicketData(Data, true, (int)row["Code"]);

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }
        }
        public void CheckDataTicketOnlineReader()
        {
            ClassLibrary.JDataBase DB = new JDataBase();
            try
            {
                DataTable dt;
                lock (listLock)
                {
                    DB.setQuery("Select top 100 * from AUTOnlineReaderTicket where IsProceced=0 order by Code desc");
                    dt = DB.Query_DataTable();
                }
                string[] Codes = JDataBase.DataTableToStringtArray(dt, "Code");
                foreach (DataRow row in dt.Rows)
                {
                    byte[] Data = (byte[])row["Data"];
                    ProcessOnlineReaderTicketData(Data, true, (int)row["Code"]);

                }
                do
                {
                    DB.setQuery("Select Count(*) C from AUTOnlineReaderTicket where IsProceced in(0,2) AND Code in (" +
                        string.Join(",", Codes) + ")");
                    dt = DB.Query_DataTable();
                    System.Threading.Thread.Sleep(1000);
                }
                while (int.Parse(dt.Rows[0]["C"].ToString()) > 100);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }
        }
        public void CheckDataTicketQRScanner()
        {
            ClassLibrary.JDataBase DB = new JDataBase();
            try
            {
                DataTable dt;
                lock (listLock)
                {
                    DB.setQuery("Select top 100 * from AUTQRReaderTransaction where IsProceced=0 order by Code desc");
                    dt = DB.Query_DataTable();
                }
                string[] Codes = JDataBase.DataTableToStringtArray(dt, "Code");
                foreach (DataRow row in dt.Rows)
                {
                    byte[] Data = (byte[])row["Data"];
                    ProcessQRscannerTicketData(Data, true, (int)row["Code"]);

                }
                do
                {
                    DB.setQuery("Select Count(*) C from AUTQRReaderTransaction where IsProceced in(0,2) AND Code in (" +
                        string.Join(",", Codes) + ")");
                    dt = DB.Query_DataTable();
                    System.Threading.Thread.Sleep(1000);
                }
                while (int.Parse(dt.Rows[0]["C"].ToString()) > 100);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        public volatile static int MySQLCounter;

        static volatile int RunSendLogToArchive = 0;
        public void CheckDataTicket()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                DataTable dt;
                lock (listLock)
                {
                    int Day = DateTime.Now.Day;
                    if (Day == 1 && RunSendLogToArchive == 0)
                    {
                        RunSendLogToArchive++;
                        mysqlDB.setQuery(@"insert into cardinfo_bin_log_archive
                                        	    SELECT  *  FROM `bus`.`cardinfo_bin_log` c where ReciveDate<'" + (DateTime.Now.AddMonths(-3)).ToString("yyyy-MM-dd") + @"';
                                           delete FROM `bus`.`cardinfo_bin_log` where ReciveDate<'" + (DateTime.Now.AddMonths(-3)).ToString("yyyy-MM-dd") + "';");
                        mysqlDB.Query_Execute();
                    }
                    if (Day != 1 && RunSendLogToArchive != 0)
                    {
                        RunSendLogToArchive = 0;
                    }

                    mysqlDB.setQuery(@"(Select * from cardinfo_bin where trycount = 0 order by Code desc LIMIT 0,190)
                                        union
                                        (Select * from cardinfo_bin where trycount > 0 order by Code desc LIMIT 0, 10)");
                    dt = mysqlDB.Query_DataTable();
                    if (dt.Rows.Count > 0 && Transaction.JDeviceDB.MoveTicketRecord(dt.Rows, "", 0, mysqlDB) == true)
                    {
                        //test
                    }
                }
                if (MySQLCounter == 0)
                {
                    mysqlDB.setQuery(@"
                        insert into cardinfo_bin(Code,recordNumber,`data`)
	                        select Code,recordNumber,`data` from cardinfo_bin_temp_log where
		                        code not in (select code from cardinfo_bin);
                        delete from cardinfo_bin_temp_log;
                        ");
                    mysqlDB.Query_Execute();
                }
                while (MySQLCounter > 200)
                    System.Threading.Thread.Sleep(1000);

                foreach (DataRow row in dt.Rows)
                {
                    MySQLCounter++;
                    byte[] Data = (byte[])row["Data"];
                    Int64 RecordNumber = Convert.ToInt64(row["RecordNumber"]);
                    Int64 Code = Convert.ToInt64(row["Code"]);
                    ProcessTicketData(Data, RecordNumber, true, Code);
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


        public void CheckDataTicketSocket(byte[] Data, long RecordNumber, Int64 Code)
        {
            try
            {
                ProcessTicketData(Data, RecordNumber, true, Code);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }


        //        public static bool SavePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate, int SendData)
        //        {
        //            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
        //                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
        //                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"'," + SendData + @",0,0)");
        //            return mysqlDB.Query_Execute() >= 0 ? true : false;
        //        }


        //        public void SetZeroBusNumberInConsole(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            Db.setQuery(@"select a.BusNumber BusNumber,a.Date FDate,0 SendData from AUTBusPerformanceCalenderReport a
        //                            left join AUTPrinterRporte b on a.BusNumber = b.BusNumber and cast(a.Date as date) = cast(b.StartDate as date)
        //                            where a.ApplyTicketCount = 0 and cast(a.Date as date) < cast(getdate() as date)-- and b.ShiftDriverCode = 0
        //                            and a.BusNumber < 6999
        //                            and a.Date > '2013-01-01'
        //                            and b.code is null
        //                            order by a.date desc");
        //            DataTable Dt = Db.Query_DataTable();
        //            if (Dt != null & Dt.Rows.Count > 0)
        //            { }
        //        }


        //        public void CalenderRepairMethodGetPrintFromConsole(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairMethodGetPrintFromConsole " + DateTime.Now.ToLongTimeString()));
        //            Db.setQuery(@"select a.BusNumber BusNumber,a.Date FDate,0 SendData from AUTBusPerformanceCalenderReport a
        //                            left join AUTPrinterRporte b on a.BusNumber = b.BusNumber and cast(a.Date as date) = cast(b.StartDate as date)
        //                            where a.ApplyTicketCount = 0 and cast(a.Date as date) < cast(getdate() as date)-- and b.ShiftDriverCode = 0
        //                            and a.BusNumber < 6999
        //                            and a.Date > '2013-01-01'
        //                            and b.code is null
        //                            order by a.date desc");
        //            DataTable Dt = Db.Query_DataTable();
        //            if (Dt != null & Dt.Rows.Count > 0)
        //            {
        //                int SqlLastInsertCode;
        //                BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
        //                for (int i = 0; i < Dt.Rows.Count; i++)
        //                {

        //                    Db.setQuery(@"delete from AUTPrinterRporte where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @" 
        //                                  and cast(StartDate as date) = '" + Dt.Rows[i]["FDate"].ToString() + @"' and cast(startdate as time)='00:00:00' and cast(EndDate as time)='23:59:59'");
        //                    Db.Query_Execute();

        //                    TransactionPrint.BusNumber = Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString());
        //                    TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00");
        //                    TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59");
        //                    TransactionPrint.TicketCount = 0;
        //                    TransactionPrint.TicketSent = 0;
        //                    TransactionPrint.State = 0;
        //                    TransactionPrint.DailyCode = 0;
        //                    SqlLastInsertCode = TransactionPrint.Insert();

        //                    SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //                        Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString()),
        //                        Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00"),
        //                        Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59"), Convert.ToInt32(Dt.Rows[i]["SendData"].ToString()));

        //                    Db.setQuery(@"update AUTBusPerformanceCalenderReport set RepairOk = ISNULL(RepairOk,0) + 1 where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @"
        //                    and cast(Date as date) = cast('" + Dt.Rows[i]["FDate"].ToString() + @"' as date)");
        //                    Db.Query_Execute();

        //                }
        //                ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethodGetPrintFromConsole - InsertDailyPrintRequest " + DateTime.Now.ToLongTimeString()));
        //            }
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethodGetPrintFromConsole " + DateTime.Now.ToLongTimeString()));
        //        }

        //        public void CalenderRepairMethod(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        //        {
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairMethod " + DateTime.Now.ToLongTimeString()));
        //            Db.setQuery(@"select BusNumber,cast(Date as date)FDate,(case when ApplyTicketCount = 0 or TicketCount > ApplyTicketCount then 0 else 1 end)SendData
        //                            from AUTBusPerformanceCalenderReport 
        //                            where ((TicketCount < ApplyTicketCount) or (ApplyTicketCount = 0) or (TicketCount > ApplyTicketCount)) and RepairOk = 0 and Date < DATEADD(DAY,-2,GETDATE()) 
        //                            order by Date desc");
        //            DataTable Dt = Db.Query_DataTable();
        //            if (Dt != null & Dt.Rows.Count > 0)
        //            {
        //                //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairMethod - InsertDailyPrintRequest " + DateTime.Now.ToLongTimeString()));
        //                int SqlLastInsertCode;
        //                BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
        //                for (int i = 0; i < Dt.Rows.Count; i++)
        //                {

        //                    Db.setQuery(@"delete from AUTPrinterRporte where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @" 
        //                                  and cast(StartDate as date) = '" + Dt.Rows[i]["FDate"].ToString() + @"' and cast(startdate as time)='00:00:00' and cast(EndDate as time)='23:59:59'");
        //                    Db.Query_Execute();

        //TransactionPrint.BusNumber = Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString());
        //TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00");
        //TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59");
        //TransactionPrint.TicketCount = 0;
        //TransactionPrint.TicketSent = 0;
        //TransactionPrint.State = 0;
        //TransactionPrint.DailyCode = 0;
        //SqlLastInsertCode = TransactionPrint.Insert();

        //SavePrintInMySql(MySqlDb, SqlLastInsertCode,
        //    Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString()),
        //    Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00"),
        //    Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59"), Convert.ToInt32(Dt.Rows[i]["SendData"].ToString()));

        //                    Db.setQuery(@"update AUTBusPerformanceCalenderReport set RepairOk = ISNULL(RepairOk,0) + 1 where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @"
        //                    and cast(Date as date) = cast('" + Dt.Rows[i]["FDate"].ToString() + @"' as date)");
        //                    Db.Query_Execute();

        //                }
        //                //ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethod - InsertDailyPrintRequest " + DateTime.Now.ToLongTimeString()));
        //            }
        //            //ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethod " + DateTime.Now.ToLongTimeString()));
        //        }

        //public void CalenderRepairFrontAndBackDoorMethod(ClassLibrary.JDataBase Db)
        //{
        //    //ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairFrontAndBackDoorMethod " + DateTime.Now.ToLongTimeString()));

        //    Db.setQuery(@"select Code,BusNumber,cast(Date as date)FDate from AUTBusPerformanceCalenderReport a where (a.FrontDoor+a.BackDoor)<>a.TicketCount and Date < DATEADD(DAY,-2,getdate()) order by Date desc");
        //    DataTable Dt = Db.Query_DataTable();
        //    if (Dt != null & Dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < Dt.Rows.Count; i++)
        //        {
        //            Db.setQuery("EXEC [dbo].[UpdateAUTBusPerformanceCalenderReportFrontAndBackDoor] '" + Dt.Rows[i]["FDate"].ToString() + "'," +
        //                Dt.Rows[i]["BusNumber"].ToString() + "," + Dt.Rows[i]["Code"].ToString());
        //            Db.Query_Execute();
        //        }
        //    }

        //    //ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairFrontAndBackDoorMethod " + DateTime.Now.ToLongTimeString()));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="pRecordNumber"></param>
        /// <param name="pThread"></param>
        public void ProcessTicketData(byte[] Data, Int64 pRecordNumber, bool pThread, Int64 Code)
        {
            BusTicketRecord B = new BusTicketRecord();
            B.Data = Data;
            B.RecordNumber = pRecordNumber;
            B.Code = Code;
            if (pThread)
            {
                if (JTicketTransactions.AddTicketCountIsRun > 500)
                    Thread.Sleep(1000);
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
            CheckDataTicket(((BusTicketRecord)B).RecordNumber, ((BusTicketRecord)B).Data, ((BusTicketRecord)B).Code);
        }

        public void CheckDataTicket(long RecordNumber, byte[] Data, Int64 Code)
        {
            DataTable DT = null;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                Tuple<JTransactionHeader, byte[]> result = Process(Data as byte[]);
                bool isSuccess = true;
                Int64 recordNumber = Convert.ToInt64(RecordNumber);
                bool CheckAllTicketTrue = true;
                if (result.Item1.ErrorNum == 0)
                    if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
                        foreach (var TH in result.Item1.TicketHeaders)
                        {
                            if (isSuccess == false) break;

                            if (TH.Tickets != null && TH.Tickets.Count() > 0)
                            {
                                DateTime date = TH.DATE;
                                foreach (var Ticket in TH.Tickets)
                                {
                                    DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);
                                    Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, ref DT);
                                }
                            }
                        }
                isSuccess = Transaction.JTicketTransactions.AddTicket(ref DT, "");
                if (isSuccess == false)
                {
                }

                if (CheckAllTicketTrue)
                    BusManagment.Transaction.JDeviceDB.MoveTicketRecord(Code, "", 0);
                else
                    BusManagment.Transaction.JDeviceDB.UpdateAndMoveTicketRecordWithError(Code);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                MySQLCounter--;
                db.Dispose();
            }
        }


        public void ProcessHandHeldTicketData(byte[] Data, bool pThread, int pCode)
        {
            BusHandHeldTicketRecord B = new BusHandHeldTicketRecord();
            B.Data = Data;
            B.Code = pCode;

            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_CheckDataHandHeldTicket));
                N.Start(B);
            }
            else
            {
                _CheckDataHandHeldTicket(B);
            }
        }

        public void ProcessOnlineReaderTicketData(byte[] Data, bool pThread, int pCode)
        {
            BusHandHeldTicketRecord B = new BusHandHeldTicketRecord();
            B.Data = Data;
            B.Code = pCode;

            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_CheckDataOnlineReaderTicket));
                N.Start(B);
            }
            else
            {
                _CheckDataOnlineReaderTicket(B);
            }
        }
        public void ProcessQRscannerTicketData(byte[] Data, bool pThread, int pCode)
        {
            BusHandHeldTicketRecord B = new BusHandHeldTicketRecord();
            B.Data = Data;
            B.Code = pCode;

            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_CheckDataQRScannerTicket));
                N.Start(B);
            }
            else
            {
                _CheckDataQRScannerTicket(B);
            }
        }

        private void _CheckDataHandHeldTicket(Object B)
        {
            CheckDataHandHeldTicket(((BusHandHeldTicketRecord)B).Data, ((BusHandHeldTicketRecord)B).Code);
        }

        private void _CheckDataOnlineReaderTicket(Object B)
        {
            CheckDataOnlineReaderTicket(((BusHandHeldTicketRecord)B).Data, ((BusHandHeldTicketRecord)B).Code);
        }
        private void _CheckDataQRScannerTicket(Object B)
        {
            CheckDataQRScannerTicket(((BusHandHeldTicketRecord)B).Data, ((BusHandHeldTicketRecord)B).Code);
        }
        public void CheckDataHandHeldTicket(byte[] Data, int pCode)
        {
            DataTable DT = null;
            try
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                try
                {
                    db.setQuery("update AUTHandHeldDeviceTicket set IsProceced=2 where code=" + pCode.ToString());
                    db.Query_Execute();
                }
                catch
                {
                }
                finally
                {
                    db.Dispose();
                }

                Int64 IMEI;//8
                int SimCharg;//4
                Int16 Batterycharge;//2
                byte GSMSignal;//1
                string ModuleVersion;//3
                string ReaderVersion;//3
                int ReadIndex;//4
                int WriteIndex;//4
                Int16 NotSendPacket;//2';
                byte GlobalSector;//1
                byte PacketLength;//1
                byte PacketNumber;//1
                byte StartOfPacket;//1
                byte[] _Data;//PacketLength
                byte EndOfPacket;//1


                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, 0, bIMEI, 0, 8);
                IMEI = BitConverter.ToInt64(bIMEI, 0);

                byte[] bSimCharg = new byte[4];
                Buffer.BlockCopy(Data, 8, bSimCharg, 0, 4);
                SimCharg = BitConverter.ToInt32(bSimCharg, 0);

                byte[] bBatteryCharge = new byte[2];
                Buffer.BlockCopy(Data, 12, bBatteryCharge, 0, 2);
                Batterycharge = BitConverter.ToInt16(bBatteryCharge, 0);


                byte[] bReaderVersion = new byte[3];
                Buffer.BlockCopy(Data, 14, bReaderVersion, 0, 3);
                ReaderVersion = bReaderVersion[0].ToString() + bReaderVersion[1].ToString() + bReaderVersion[2].ToString();
                int rv;
                int.TryParse(ReaderVersion, out rv);

                byte[] bModuleVersion = new byte[3];
                Buffer.BlockCopy(Data, 17, bModuleVersion, 0, 3);
                ModuleVersion = bModuleVersion[0].ToString() + bModuleVersion[1].ToString() + bModuleVersion[2].ToString();
                int mv;
                int.TryParse(ModuleVersion, out mv);

                byte[] bReadIndex = new byte[4];
                Buffer.BlockCopy(Data, 20, bReadIndex, 0, 4);
                ReadIndex = BitConverter.ToInt32(bReadIndex, 0);

                byte[] bWriteIndex = new byte[4];
                Buffer.BlockCopy(Data, 24, bWriteIndex, 0, 4);
                WriteIndex = BitConverter.ToInt32(bWriteIndex, 0);

                byte[] bNotSendPacket = new byte[2];
                Buffer.BlockCopy(Data, 28, bNotSendPacket, 0, 2);
                NotSendPacket = BitConverter.ToInt16(bNotSendPacket, 0);

                byte[] bGlobalSector = new byte[1];
                Buffer.BlockCopy(Data, 30, bGlobalSector, 0, 1);
                GlobalSector = bGlobalSector[0];//BitConverter.ToChar(bGlobalSector, 0);

                byte[] bPacketLength = new byte[1];
                Buffer.BlockCopy(Data, 31, bPacketLength, 0, 1);
                PacketLength = bPacketLength[0];//BitConverter.ToChar(bPacketLength, 0);

                byte[] bPacketNumber = new byte[1];
                Buffer.BlockCopy(Data, 32, bPacketNumber, 0, 1);
                PacketNumber = bPacketNumber[0];//BitConverter.ToChar(bPacketNumber, 0);

                byte[] bStartOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 33, bStartOfPacket, 0, 1);
                StartOfPacket = bStartOfPacket[0];

                _Data = new byte[PacketNumber * PacketLength];
                Buffer.BlockCopy(Data, 34, _Data, 0, PacketNumber * PacketLength);

                byte[] bEndOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 34 + (PacketNumber * PacketLength), bEndOfPacket, 0, 1);
                EndOfPacket = bEndOfPacket[0];


                // Data structure
                uint BIN_LTB;//1
                uint TerminalId;//4
                uint DataTime;//4
                uint Price;//2
                uint StationId;//3
                uint WaletId;//1
                uint Type;//1
                uint LTD_ServerCid;//4
                uint RemainingPrice;//4
                UInt64 ServerMAC;//8
                UInt64 MAC_OUT;//8
                UInt64 PassengerId;//8
                UInt64 DriverId;//8
                uint LineNumber;//3
                uint CardType;//1
                uint CardVersion;//1
                UInt16 BankType;//1
                uint ReaderId;//1
                uint CRC;//2

                int PStart = 0;
                for (int i = 0; i < PacketNumber; i++)
                {
                    PStart = i * PacketLength;
                    byte[] bBIN_LTB = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bBIN_LTB, 0, 1);
                    BIN_LTB = bBIN_LTB[0];//BitConverter.ToChar(bBIN_LTB, 0);
                    PStart += 1;
                    byte[] bTerminalId = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bTerminalId, 0, 4);
                    Array.Reverse(bTerminalId);
                    TerminalId = BitConverter.ToUInt32(bTerminalId, 0);
                    PStart += 4;
                    byte[] bDataTime = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bDataTime, 0, 4);
                    Array.Reverse(bDataTime);
                    DataTime = BitConverter.ToUInt32(bDataTime, 0);
                    PStart += 4;
                    byte[] bPrice = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bPrice, 0, 2);
                    Array.Reverse(bPrice);
                    Price = BitConverter.ToUInt16(bPrice, 0);
                    Price = Price / 10;
                    PStart += 2;
                    byte[] bStationId = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bStationId, 0, 3);
                    Array.Reverse(bStationId);
                    StationId = BitConverter.ToUInt16(bStationId, 0);
                    PStart += 3;
                    byte[] bWaletId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bWaletId, 0, 1);
                    WaletId = bWaletId[0];
                    PStart += 1;
                    byte[] bType = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bType, 0, 1);
                    Type = bType[0];
                    PStart += 1;
                    byte[] bLTD_ServerCid = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bLTD_ServerCid, 0, 4);
                    Array.Reverse(bLTD_ServerCid);
                    LTD_ServerCid = BitConverter.ToUInt32(bLTD_ServerCid, 0);
                    PStart += 4;
                    byte[] bRemaningPrice = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bRemaningPrice, 0, 4);
                    Array.Reverse(bRemaningPrice);
                    RemainingPrice = BitConverter.ToUInt32(bRemaningPrice, 0);
                    PStart += 4;
                    byte[] bServerMac = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bServerMac, 0, 8);
                    Array.Reverse(bServerMac);
                    ServerMAC = BitConverter.ToUInt64(bServerMac, 0);
                    PStart += 8;
                    byte[] bMAC_OUT = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bMAC_OUT, 0, 8);
                    Array.Reverse(bMAC_OUT);
                    MAC_OUT = BitConverter.ToUInt64(bMAC_OUT, 0);
                    PStart += 8;
                    byte[] bPassengerID = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bPassengerID, 0, 8);
                    Array.Reverse(bPassengerID);
                    PassengerId = BitConverter.ToUInt64(bPassengerID, 0);
                    PStart += 8;
                    byte[] bDriverId = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bDriverId, 0, 8);
                    Array.Reverse(bDriverId);
                    DriverId = BitConverter.ToUInt64(bDriverId, 0);
                    PStart += 8;
                    byte[] bLineNumber = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bLineNumber, 0, 3);
                    Array.Reverse(bLineNumber);
                    LineNumber = BitConverter.ToUInt16(bLineNumber, 0);
                    PStart += 3;
                    byte[] bCardType = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCardType, 0, 2);
                    CardType = bCardType[0];
                    BankType = bCardType[1];
                    CardVersion = 0;
                    if (BankType != 0)
                    {
                        CardType = 0;
                        CardVersion = bCardType[0];
                    }
                    PStart += 2;
                    byte[] bReaderId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bReaderId, 0, 1);
                    ReaderId = bReaderId[0];//BitConverter.ToChar(bReaderId, 0);
                    PStart += 1;
                    byte[] bCRC = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCRC, 0, 2);
                    CRC = BitConverter.ToUInt16(bCRC, 0);
                    PStart += 2;

                    try
                    {

                        Reader.JReader R = new Reader.JReader();
                        R.ReaderVersion = rv;
                        R.ModuleVersion = mv;
                        R.IMEI = IMEI;
                        R.BusNumber = (int)StationId;
                        R.ReaderId = (int)ReaderId;
                        R.VersionDate = DateTime.Now;
                        R.Insert();
                    }
                    catch
                    {

                    }


                    JTransactionTicketHeader TH = new JTransactionTicketHeader();
                    TH.busSerial = StationId;
                    TH.DATE = JTransactions.ConvertUintToDateTime(DataTime);
                    TH.DriverSerialCard = DriverId.ToString();
                    TH.LineNumber = LineNumber;
                    JTransactionTicket TT = new JTransactionTicket();
                    TT.CardType = CardType;
                    TT.PassengerCardSerial = PassengerId;
                    TT.ReaderID = ReaderId;
                    TT.RemainPrice = RemainingPrice;
                    TT.TicketPrice = Price;
                    TT.transactionid = (uint)pCode;
                    TT.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                    TT.LTB = (byte)BIN_LTB;
                    TT.MacOut = MAC_OUT;
                    TT.LTD = LTD_ServerCid;
                    TT.TerminalID = TerminalId;
                    TT.ServerMac = ServerMAC;
                    TT.WaletID = (byte)WaletId;
                    TT.BankType = BankType;
                    TT.CardVersion = CardVersion;
                    if (BankType == 2)
                        TT.Counter = (ushort)MAC_OUT;
                    Transaction.JTicketTransactions.AddTicketTransaction(TH, TT, pCode, IMEI.ToString(), (float)StationId, bReaderVersion, ref DT);
                }
                if (Transaction.JTicketTransactions.AddTicket(ref DT, ""))
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTHandHeldDeviceTicket set IsProceced=1 where code=" + pCode.ToString());
                        db.Query_Execute();

                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
                else
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTHandHeldDeviceTicket set IsProceced=0 where code=" + pCode.ToString());
                        db.Query_Execute();
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                try
                {
                    db.setQuery("update AUTHandHeldDeviceTicket set IsProceced=3 where code=" + pCode.ToString());
                    db.Query_Execute();
                }
                finally
                {
                    db.Dispose();
                }

            }
            finally
            {
            }
            //{
            //    DataTable DT = null;
            //    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            //    try
            //    {
            //        db.setQuery("update AUTHandHeldDeviceTicket set IsProceced=1 where code=" + pCode.ToString());
            //        db.Query_Execute();

            //        int control;//2

            //        Int64 IMEI;//8
            //        int SimCharg;//4
            //        int BatteryCharg;//2
            //        int FirmwareVersion;//4
            //        int PacketLength;//1
            //        int PacketNumber;//1
            //        int StartOfPacket;//1

            //        byte[] bIMEI = new byte[8]; Buffer.BlockCopy(Data, 0, bIMEI, 0, 8); IMEI = BitConverter.ToInt64(bIMEI, 0);
            //        byte[] bSimCharg = new byte[4]; Buffer.BlockCopy(Data, 8, bSimCharg, 0, 4); SimCharg = BitConverter.ToInt32(bSimCharg, 0);
            //        byte[] bBatteryCharg = new byte[2]; Buffer.BlockCopy(Data, 12, bBatteryCharg, 0, 2); BatteryCharg = BitConverter.ToInt16(bBatteryCharg, 0);
            //        byte[] bFirmwareVersion = new byte[4]; Buffer.BlockCopy(Data, 14, bFirmwareVersion, 0, 4); FirmwareVersion = BitConverter.ToInt32(bFirmwareVersion, 0);
            //        byte[] bPacketLength = new byte[2]; Buffer.BlockCopy(Data, 18, bPacketLength, 0, 1); PacketLength = BitConverter.ToInt16(bPacketLength, 0);
            //        byte[] bPacketNumber = new byte[2]; Buffer.BlockCopy(Data, 19, bPacketNumber, 0, 1); PacketNumber = BitConverter.ToInt16(bPacketNumber, 0);
            //        byte[] bStartOfPacket = new byte[2]; Buffer.BlockCopy(Data, 20, bStartOfPacket, 0, 1); StartOfPacket = BitConverter.ToInt16(bStartOfPacket, 0);

            //        uint PassengerID;//7
            //        uint DeviceOperatorID;//7
            //        ulong DataTime;//4
            //        uint LineNumber;//3
            //        uint DeviceID;//3
            //        uint RemaningPrice;//3
            //        uint CardType;//1
            //        uint Price;//2
            //        int CRC;//2

            //        int PStart = 21;
            //        while (PStart + 32 <= Data.Length)
            //        {
            //            byte[] bPassengerID = new byte[7]; Buffer.BlockCopy(Data, PStart + 0, bPassengerID, 0, 7); PassengerID = BitConverter.ToUInt32(bPassengerID, 0);
            //            byte[] bDeviceOperatorID = new byte[7]; Buffer.BlockCopy(Data, PStart + 7, bDeviceOperatorID, 0, 7); DeviceOperatorID = BitConverter.ToUInt32(bDeviceOperatorID, 0);
            //            byte[] bDataTime = new byte[4]; Buffer.BlockCopy(Data, PStart + 14, bDataTime, 0, 4); DataTime = BitConverter.ToUInt32(bDataTime, 0);
            //            byte[] bDeviceID = new byte[4]; Buffer.BlockCopy(Data, PStart + 18, bDeviceID, 0, 3); DeviceID = BitConverter.ToUInt32(bDeviceID, 0);
            //            byte[] bLineNumber = new byte[4]; Buffer.BlockCopy(Data, PStart + 21, bLineNumber, 0, 3); LineNumber = BitConverter.ToUInt32(bLineNumber, 0);
            //            byte[] bRemaningPrice = new byte[4]; Buffer.BlockCopy(Data, PStart + 24, bRemaningPrice, 0, 3); RemaningPrice = BitConverter.ToUInt32(bRemaningPrice, 0);
            //            byte[] bPrice = new byte[2]; Buffer.BlockCopy(Data, PStart + 27, bPrice, 0, 2); Price = BitConverter.ToUInt16(bPrice, 0);
            //            byte[] bCardType = new byte[2]; Buffer.BlockCopy(Data, PStart + 29, bCardType, 0, 1); CardType = BitConverter.ToUInt16(bCardType, 0);
            //            byte[] bCRC = new byte[2]; Buffer.BlockCopy(Data, PStart + 30, bCRC, 0, 2); CRC = BitConverter.ToInt16(bCRC, 0);
            //            PStart += 32;

            //            JTransactionTicketHeader TH = new JTransactionTicketHeader();
            //            TH.busSerial = DeviceID;
            //            TH.DATE = JTransactions.ConvertUintToDateTime(DataTime);
            //            TH.DriverSerialCard = DeviceOperatorID.ToString();
            //            TH.LineNumber = LineNumber;

            //            JTransactionTicket TT = new JTransactionTicket();
            //            TT.CardType = CardType;
            //            TT.PassengerCardSerial = PassengerID;
            //            TT.ReaderID = 0;
            //            TT.RemainPrice = RemaningPrice;
            //            TT.TicketPrice = Price;
            //            TT.transactionid = 0;
            //            TT.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
            //            Transaction.JTicketTransactions.AddTicketTransaction(TH, TT, 0, IMEI.ToString(), (float)DeviceID, bFirmwareVersion, ref DT);


            //        }
            //        Transaction.JTicketTransactions.AddTicket(ref DT, "");
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    finally
            //    {
            //        db.Dispose();
            //    }
        }

        public void CheckDataOnlineReaderTicket(byte[] Data, int pCode)
        {
            DataTable DT = null;
            try
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                try
                {
                    db.setQuery("update AUTOnlineReaderTicket set IsProceced=2 where code=" + pCode.ToString());
                    db.Query_Execute();
                }
                catch
                { }
                finally
                {
                    db.Dispose();
                }

                Int64 IMEI;//8
                int SimCharg;//4
                string ModuleVersion;//3
                string ReaderVersion;//3
                int ReadIndex;//4
                int WriteIndex;//4
                Int16 NotSendPacket;//2';
                byte GlobalSector;//1
                byte PacketLength;//1
                byte PacketNumber;//1
                byte StartOfPacket;//1
                byte[] _Data;//PacketLength
                byte EndOfPacket;//1

                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, 0, bIMEI, 0, 8);
                IMEI = BitConverter.ToInt64(bIMEI, 0);

                byte[] bSimCharg = new byte[4];
                Buffer.BlockCopy(Data, 8, bSimCharg, 0, 4);
                SimCharg = BitConverter.ToInt32(bSimCharg, 0);


                byte[] bReaderVersion = new byte[3];
                Buffer.BlockCopy(Data, 12, bReaderVersion, 0, 3);
                ReaderVersion = bReaderVersion[0].ToString() + bReaderVersion[1].ToString() + bReaderVersion[2].ToString();
                int rv;
                int.TryParse(ReaderVersion, out rv);

                byte[] bModuleVersion = new byte[3];
                Buffer.BlockCopy(Data, 15, bModuleVersion, 0, 3);
                ModuleVersion = bModuleVersion[0].ToString() + bModuleVersion[1].ToString() + bModuleVersion[2].ToString();
                int mv;
                int.TryParse(ModuleVersion, out mv);

                byte[] bReadIndex = new byte[4];
                Buffer.BlockCopy(Data, 18, bReadIndex, 0, 4);
                ReadIndex = BitConverter.ToInt32(bReadIndex, 0);

                byte[] bWriteIndex = new byte[4];
                Buffer.BlockCopy(Data, 22, bWriteIndex, 0, 4);
                WriteIndex = BitConverter.ToInt32(bWriteIndex, 0);

                byte[] bNotSendPacket = new byte[2];
                Buffer.BlockCopy(Data, 26, bNotSendPacket, 0, 2);
                NotSendPacket = BitConverter.ToInt16(bNotSendPacket, 0);

                byte[] bGlobalSector = new byte[1];
                Buffer.BlockCopy(Data, 28, bGlobalSector, 0, 1);
                GlobalSector = bGlobalSector[0];//BitConverter.ToChar(bGlobalSector, 0);

                byte[] bPacketLength = new byte[1];
                Buffer.BlockCopy(Data, 29, bPacketLength, 0, 1);
                PacketLength = bPacketLength[0];//BitConverter.ToChar(bPacketLength, 0);

                byte[] bPacketNumber = new byte[1];
                Buffer.BlockCopy(Data, 30, bPacketNumber, 0, 1);
                PacketNumber = bPacketNumber[0];//BitConverter.ToChar(bPacketNumber, 0);

                byte[] bStartOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 31, bStartOfPacket, 0, 1);
                StartOfPacket = bStartOfPacket[0];//BitConverter.ToChar(bStartOfPacket, 0);

                _Data = new byte[PacketNumber * PacketLength];
                Buffer.BlockCopy(Data, 32, _Data, 0, PacketNumber * PacketLength);

                byte[] bEndOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 32 + (PacketNumber * PacketLength), bEndOfPacket, 0, 1);
                EndOfPacket = bEndOfPacket[0];//BitConverter.ToChar(bEndOfPacket, 0);


                // Data structure
                uint BIN_LTB;//1
                uint TerminalId;//4
                uint DataTime;//4
                uint Price;//2
                uint StationId;//3
                uint WaletId;//1
                uint Type;//1
                uint LTD_ServerCid;//4
                uint RemainingPrice;//4
                UInt64 ServerMAC;//8
                UInt64 MAC_OUT;//8
                UInt64 PassengerId;//8
                UInt64 DriverId;//8
                uint LineNumber;//3
                uint CardType;//1
                uint CardVersion;//1
                UInt16 BankType;//1
                uint ReaderId;//1
                uint CRC;//2

                int PStart;
                for (int i = 0; i < PacketNumber; i++)
                {
                    PStart = i * PacketLength;
                    byte[] bBIN_LTB = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bBIN_LTB, 0, 1);
                    BIN_LTB = bBIN_LTB[0];//BitConverter.ToChar(bBIN_LTB, 0);
                    PStart += 1;
                    byte[] bTerminalId = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bTerminalId, 0, 4);
                    Array.Reverse(bTerminalId);
                    TerminalId = BitConverter.ToUInt32(bTerminalId, 0);
                    PStart += 4;
                    byte[] bDataTime = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bDataTime, 0, 4);
                    Array.Reverse(bDataTime);
                    DataTime = BitConverter.ToUInt32(bDataTime, 0);
                    PStart += 4;
                    byte[] bPrice = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bPrice, 0, 2);
                    Array.Reverse(bPrice);
                    Price = BitConverter.ToUInt16(bPrice, 0);
                    Price = Price / 10;
                    PStart += 2;
                    byte[] bStationId = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bStationId, 0, 3);
                    Array.Reverse(bStationId);
                    StationId = BitConverter.ToUInt16(bStationId, 0);
                    PStart += 3;
                    byte[] bWaletId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bWaletId, 0, 1);
                    WaletId = bWaletId[0];//BitConverter.ToChar(bWaletId, 0);
                    PStart += 1;
                    byte[] bType = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bType, 0, 1);
                    Type = bType[0];//BitConverter.ToChar(bType, 0);
                    PStart += 1;
                    byte[] bLTD_ServerCid = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bLTD_ServerCid, 0, 4);
                    Array.Reverse(bLTD_ServerCid);
                    LTD_ServerCid = BitConverter.ToUInt32(bLTD_ServerCid, 0);
                    PStart += 4;
                    byte[] bRemaningPrice = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bRemaningPrice, 0, 4);
                    Array.Reverse(bRemaningPrice);
                    RemainingPrice = BitConverter.ToUInt32(bRemaningPrice, 0);
                    //RemainingPrice = RemainingPrice / 10;
                    PStart += 4;
                    byte[] bServerMac = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bServerMac, 0, 8);
                    Array.Reverse(bServerMac);
                    ServerMAC = BitConverter.ToUInt64(bServerMac, 0);
                    PStart += 8;
                    byte[] bMAC_OUT = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bMAC_OUT, 0, 8);
                    Array.Reverse(bMAC_OUT);
                    MAC_OUT = BitConverter.ToUInt64(bMAC_OUT, 0);
                    PStart += 8;
                    byte[] bPassengerID = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bPassengerID, 0, 8);
                    Array.Reverse(bPassengerID);
                    PassengerId = BitConverter.ToUInt64(bPassengerID, 0);
                    PStart += 8;
                    byte[] bDriverId = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bDriverId, 0, 8);
                    Array.Reverse(bDriverId);
                    DriverId = BitConverter.ToUInt64(bDriverId, 0);
                    PStart += 8;
                    byte[] bLineNumber = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bLineNumber, 0, 3);
                    Array.Reverse(bLineNumber);
                    LineNumber = BitConverter.ToUInt16(bLineNumber, 0);
                    PStart += 3;
                    byte[] bCardType = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCardType, 0, 2);
                    CardType = bCardType[0];
                    BankType = bCardType[1];
                    CardVersion = 0;
                    if (BankType != 0)
                    {
                        CardType = 0;
                        CardVersion = bCardType[0];
                    }
                    PStart += 2;
                    byte[] bReaderId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bReaderId, 0, 1);
                    ReaderId = bReaderId[0];//BitConverter.ToChar(bReaderId, 0);
                    PStart += 1;
                    byte[] bCRC = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCRC, 0, 2);
                    CRC = BitConverter.ToUInt16(bCRC, 0);
                    PStart += 2;

                    try
                    {

                        Reader.JReader R = new Reader.JReader();
                        R.ReaderVersion = rv;
                        R.ModuleVersion = mv;
                        R.IMEI = IMEI;
                        R.BusNumber = (int)StationId;
                        R.ReaderId = (int)ReaderId;
                        R.VersionDate = DateTime.Now;
                        R.Insert();
                    }
                    catch
                    {

                    }
                    JTransactionTicketHeader TH = new JTransactionTicketHeader();
                    TH.busSerial = StationId;
                    TH.DATE = JTransactions.ConvertUintToDateTime(DataTime);
                    TH.DriverSerialCard = DriverId.ToString();
                    TH.LineNumber = LineNumber;
                    JTransactionTicket TT = new JTransactionTicket();
                    TT.CardType = CardType;
                    TT.PassengerCardSerial = PassengerId;
                    TT.ReaderID = ReaderId;
                    TT.RemainPrice = RemainingPrice;
                    TT.TicketPrice = Price;
                    try
                    {
                        TT.transactionid = (uint)pCode;
                    }
                    catch (Exception ex)
                    {

                    }
                    TT.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                    TT.LTB = (byte)BIN_LTB;
                    TT.MacOut = MAC_OUT;
                    TT.LTD = LTD_ServerCid;
                    TT.TerminalID = TerminalId;
                    TT.ServerMac = ServerMAC;
                    TT.WaletID = (byte)WaletId;
                    TT.BankType = BankType;
                    TT.CardVersion = CardVersion;
                    if (BankType == 2)
                        TT.Counter = (ushort)MAC_OUT;
                    Transaction.JTicketTransactions.AddTicketTransaction(TH, TT, pCode, IMEI.ToString(), (float)StationId, bReaderVersion, ref DT);
                }
                if (Transaction.JTicketTransactions.AddTicket(ref DT, ""))
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTOnlineReaderTicket set IsProceced=1, LastProcessDate = getdate(),FirstProcessDate = Isnull(FirstProcessDate,getdate()), ProcessCount = isnull(ProcessCount,0)+1 where code=" + pCode.ToString());
                        db.Query_Execute();
                        db.setQuery("insert into AutOnlineReaderMemoryStatus values(@IMEI, @Version, @ReadIndex, @WriteIndex, @RecordNumber, @PacketNumber, getdate())");
                        db.AddParams("IMEI", IMEI);
                        db.AddParams("Version", ReaderVersion);
                        db.AddParams("ReadIndex", ReadIndex);
                        db.AddParams("WriteIndex", WriteIndex);
                        db.AddParams("RecordNumber", pCode);
                        db.AddParams("PacketNumber", PacketNumber);
                        db.Query_Execute();

                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
                else
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTOnlineReaderTicket set IsProceced=0 where code=" + pCode.ToString());
                        db.Query_Execute();
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                //JDataBase db = new ClassLibrary.JDataBase();
                //try
                //{
                //    db.setQuery("update AUTOnlineReaderTicket set IsProceced=0 where code=" + pCode.ToString());
                //    db.Query_Execute();
                //}
                //finally
                //{
                //    db.Dispose();
                //}
                //System.Threading.Thread.CurrentThread.Abort();
            }
            finally
            {
            }
        }

        public void CheckDataQRScannerTicket(byte[] Data, int pCode)
        {
            DataTable DT = null;
            try
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                try
                {
                    db.setQuery("update AUTQRReaderTransaction set IsProceced=2 where code=" + pCode.ToString());
                    db.Query_Execute();
                }
                catch
                { }
                finally
                {
                    db.Dispose();
                }

                Int64 IMEI;//8
                int SimCharg;//4
                string ModuleVersion;//3
                string ReaderVersion;//3
                int ReadIndex;//4
                int WriteIndex;//4
                Int16 NotSendPacket;//2';
                byte GlobalSector;//1
                byte PacketLength;//1
                byte PacketNumber;//1
                byte StartOfPacket;//1
                byte[] _Data;//PacketLength
                byte EndOfPacket;//1

                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, 0, bIMEI, 0, 8);
                IMEI = BitConverter.ToInt64(bIMEI, 0);

                byte[] bSimCharg = new byte[4];
                Buffer.BlockCopy(Data, 8, bSimCharg, 0, 4);
                SimCharg = BitConverter.ToInt32(bSimCharg, 0);


                byte[] bReaderVersion = new byte[3];
                Buffer.BlockCopy(Data, 12, bReaderVersion, 0, 3);
                ReaderVersion = bReaderVersion[0].ToString() + bReaderVersion[1].ToString() + bReaderVersion[2].ToString();
                int rv;
                int.TryParse(ReaderVersion, out rv);

                byte[] bModuleVersion = new byte[3];
                Buffer.BlockCopy(Data, 15, bModuleVersion, 0, 3);
                ModuleVersion = bModuleVersion[0].ToString() + bModuleVersion[1].ToString() + bModuleVersion[2].ToString();
                int mv;
                int.TryParse(ModuleVersion, out mv);

                byte[] bReadIndex = new byte[4];
                Buffer.BlockCopy(Data, 18, bReadIndex, 0, 4);
                ReadIndex = BitConverter.ToInt32(bReadIndex, 0);

                byte[] bWriteIndex = new byte[4];
                Buffer.BlockCopy(Data, 22, bWriteIndex, 0, 4);
                WriteIndex = BitConverter.ToInt32(bWriteIndex, 0);

                byte[] bNotSendPacket = new byte[2];
                Buffer.BlockCopy(Data, 26, bNotSendPacket, 0, 2);
                NotSendPacket = BitConverter.ToInt16(bNotSendPacket, 0);

                byte[] bGlobalSector = new byte[1];
                Buffer.BlockCopy(Data, 28, bGlobalSector, 0, 1);
                GlobalSector = bGlobalSector[0];//BitConverter.ToChar(bGlobalSector, 0);

                byte[] bPacketLength = new byte[1];
                Buffer.BlockCopy(Data, 29, bPacketLength, 0, 1);
                PacketLength = bPacketLength[0];//BitConverter.ToChar(bPacketLength, 0);

                byte[] bPacketNumber = new byte[1];
                Buffer.BlockCopy(Data, 30, bPacketNumber, 0, 1);
                PacketNumber = bPacketNumber[0];//BitConverter.ToChar(bPacketNumber, 0);

                byte[] bStartOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 31, bStartOfPacket, 0, 1);
                StartOfPacket = bStartOfPacket[0];//BitConverter.ToChar(bStartOfPacket, 0);

                _Data = new byte[PacketNumber * PacketLength];
                Buffer.BlockCopy(Data, 32, _Data, 0, PacketNumber * PacketLength);

                byte[] bEndOfPacket = new byte[1];
                Buffer.BlockCopy(Data, 32 + (PacketNumber * PacketLength), bEndOfPacket, 0, 1);
                EndOfPacket = bEndOfPacket[0];//BitConverter.ToChar(bEndOfPacket, 0);


                // Data structure
                uint BIN_LTB;//1
                uint TerminalId;//4
                uint DataTime;//4
                uint Price;//2
                uint StationId;//3
                uint WaletId;//1
                uint Type;//1
                uint LTD_ServerCid;//4
                uint RemainingPrice;//4
                UInt64 ServerMAC;//8
                UInt64 MAC_OUT;//8
                UInt64 PassengerId;//8
                UInt64 DriverId;//8
                uint LineNumber;//3
                uint CardType;//1
                uint CardVersion;//1
                UInt16 BankType;//1
                uint ReaderId;//1
                uint CRC;//2

                int PStart;
                for (int i = 0; i < PacketNumber; i++)
                {
                    PStart = i * PacketLength;
                    byte[] bBIN_LTB = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bBIN_LTB, 0, 1);
                    BIN_LTB = bBIN_LTB[0];//BitConverter.ToChar(bBIN_LTB, 0);
                    PStart += 1;
                    byte[] bTerminalId = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bTerminalId, 0, 4);
                    Array.Reverse(bTerminalId);
                    TerminalId = BitConverter.ToUInt32(bTerminalId, 0);
                    PStart += 4;
                    byte[] bDataTime = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bDataTime, 0, 4);
                    Array.Reverse(bDataTime);
                    DataTime = BitConverter.ToUInt32(bDataTime, 0);
                    PStart += 4;
                    byte[] bPrice = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bPrice, 0, 2);
                    Array.Reverse(bPrice);
                    Price = BitConverter.ToUInt16(bPrice, 0);
                    Price = Price / 10;
                    PStart += 2;
                    byte[] bStationId = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bStationId, 0, 3);
                    Array.Reverse(bStationId);
                    StationId = BitConverter.ToUInt16(bStationId, 0);
                    PStart += 3;
                    byte[] bWaletId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bWaletId, 0, 1);
                    WaletId = bWaletId[0];//BitConverter.ToChar(bWaletId, 0);
                    PStart += 1;
                    byte[] bType = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bType, 0, 1);
                    Type = bType[0];//BitConverter.ToChar(bType, 0);
                    PStart += 1;
                    byte[] bLTD_ServerCid = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bLTD_ServerCid, 0, 4);
                    Array.Reverse(bLTD_ServerCid);
                    LTD_ServerCid = BitConverter.ToUInt32(bLTD_ServerCid, 0);
                    PStart += 4;
                    byte[] bRemaningPrice = new byte[4];
                    Buffer.BlockCopy(_Data, PStart, bRemaningPrice, 0, 4);
                    Array.Reverse(bRemaningPrice);
                    RemainingPrice = BitConverter.ToUInt32(bRemaningPrice, 0);
                    //RemainingPrice = RemainingPrice / 10;
                    PStart += 4;
                    byte[] bServerMac = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bServerMac, 0, 8);
                    Array.Reverse(bServerMac);
                    ServerMAC = BitConverter.ToUInt64(bServerMac, 0);
                    PStart += 8;
                    byte[] bMAC_OUT = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bMAC_OUT, 0, 8);
                    Array.Reverse(bMAC_OUT);
                    MAC_OUT = BitConverter.ToUInt64(bMAC_OUT, 0);
                    PStart += 8;
                    byte[] bPassengerID = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bPassengerID, 0, 8);
                    Array.Reverse(bPassengerID);
                    PassengerId = BitConverter.ToUInt64(bPassengerID, 0);
                    PStart += 8;
                    byte[] bDriverId = new byte[8];
                    Buffer.BlockCopy(_Data, PStart, bDriverId, 0, 8);
                    Array.Reverse(bDriverId);
                    DriverId = BitConverter.ToUInt64(bDriverId, 0);
                    PStart += 8;
                    byte[] bLineNumber = new byte[3];
                    Buffer.BlockCopy(_Data, PStart, bLineNumber, 0, 3);
                    Array.Reverse(bLineNumber);
                    LineNumber = BitConverter.ToUInt16(bLineNumber, 0);
                    PStart += 3;
                    byte[] bCardType = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCardType, 0, 2);
                    CardType = bCardType[0];
                    BankType = bCardType[1];
                    CardVersion = 0;
                    if (BankType != 0)
                    {
                        CardType = 0;
                        CardVersion = bCardType[0];
                    }
                    PStart += 2;
                    byte[] bReaderId = new byte[1];
                    Buffer.BlockCopy(_Data, PStart, bReaderId, 0, 1);
                    ReaderId = bReaderId[0];//BitConverter.ToChar(bReaderId, 0);
                    PStart += 1;
                    byte[] bCRC = new byte[2];
                    Buffer.BlockCopy(_Data, PStart, bCRC, 0, 2);
                    CRC = BitConverter.ToUInt16(bCRC, 0);
                    PStart += 2;

                    try
                    {

                        Reader.JReader R = new Reader.JReader();
                        R.ReaderVersion = rv;
                        R.ModuleVersion = mv;
                        R.IMEI = IMEI;
                        R.BusNumber = (int)StationId;
                        R.ReaderId = (int)ReaderId;
                        R.VersionDate = DateTime.Now;
                        R.Insert();
                    }
                    catch
                    {

                    }
                    JTransactionTicketHeader TH = new JTransactionTicketHeader();
                    TH.busSerial = StationId;
                    TH.DATE = JTransactions.ConvertUintToDateTime(DataTime);
                    TH.DriverSerialCard = DriverId.ToString();
                    TH.LineNumber = LineNumber;
                    JTransactionTicket TT = new JTransactionTicket();
                    TT.CardType = CardType;
                    TT.PassengerCardSerial = PassengerId;
                    TT.ReaderID = ReaderId;
                    TT.RemainPrice = RemainingPrice;
                    TT.TicketPrice = Price;
                    try
                    {
                        TT.transactionid = (uint)pCode;
                    }
                    catch (Exception ex)
                    {

                    }
                    TT.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                    TT.LTB = (byte)BIN_LTB;
                    TT.MacOut = MAC_OUT;
                    TT.LTD = LTD_ServerCid;
                    TT.TerminalID = TerminalId;
                    TT.ServerMac = ServerMAC;
                    TT.WaletID = (byte)WaletId;
                    TT.BankType = BankType;
                    TT.CardVersion = CardVersion;
                    if (BankType == 2)
                        TT.Counter = (ushort)MAC_OUT;
                    Transaction.JTicketTransactions.AddTicketTransaction(TH, TT, pCode, IMEI.ToString(), (float)StationId, bReaderVersion, ref DT);
                }
                if (Transaction.JTicketTransactions.AddTicket(ref DT, ""))
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTQRReaderTransaction set IsProceced=1, LastProcessDate = getdate(),FirstProcessDate = Isnull(FirstProcessDate,getdate()), ProcessCount = isnull(ProcessCount,0)+1 where code=" + pCode.ToString());
                        db.Query_Execute();
                        db.setQuery("insert into AutOnlineReaderMemoryStatus values(@IMEI, @Version, @ReadIndex, @WriteIndex, @RecordNumber, @PacketNumber, getdate())");
                        db.AddParams("IMEI", IMEI);
                        db.AddParams("Version", ReaderVersion);
                        db.AddParams("ReadIndex", ReadIndex);
                        db.AddParams("WriteIndex", WriteIndex);
                        db.AddParams("RecordNumber", pCode);
                        db.AddParams("PacketNumber", PacketNumber);
                        db.Query_Execute();

                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
                else
                {
                    db = new ClassLibrary.JDataBase();
                    try
                    {
                        db.setQuery("update AUTQRReaderTransaction set IsProceced=0 where code=" + pCode.ToString());
                        db.Query_Execute();
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                //JDataBase db = new ClassLibrary.JDataBase();
                //try
                //{
                //    db.setQuery("update AUTOnlineReaderTicket set IsProceced=0 where code=" + pCode.ToString());
                //    db.Query_Execute();
                //}
                //finally
                //{
                //    db.Dispose();
                //}
                //System.Threading.Thread.CurrentThread.Abort();
            }
            finally
            {
            }
        }

        public static void SaveConfigOnOnlineReader(byte[] Data)//, int pCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                //db.setQuery("update AUTOnlineReaderTicket set IsProceced=1 where code=" + pCode.ToString());
                //db.Query_Execute();

                Int64 IMEI;//8
                string ServerIP;//4
                Int16 ServerPort;//2
                Int16 BaudRate;//2
                uint DateTime;//4
                int LineNumber;//4
                int StationId;//4
                byte ReaderId;//1
                List<Int16> PriceTable = new List<Int16>();//20 byte array [10 price]
                int SendOldTicketCountAgain;//4
                bool Status;//1
                UInt16 CRC;//2

                int start = 2;
                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, start, bIMEI, 0, bIMEI.Length);
                IMEI = BitConverter.ToInt64(bIMEI, 0);
                start += bIMEI.Length;

                byte[] bServerIP = new byte[4];
                Buffer.BlockCopy(Data, start, bServerIP, 0, bServerIP.Length);
                ServerIP = BitConverter.ToString(bServerIP, 0);
                start += bServerIP.Length;

                byte[] bServerPort = new byte[2];
                Buffer.BlockCopy(Data, start, bServerPort, 0, bServerPort.Length);
                ServerPort = BitConverter.ToInt16(bServerPort, 0);
                start += bServerPort.Length;

                byte[] bBaudRate = new byte[2];
                Buffer.BlockCopy(Data, start, bBaudRate, 0, bBaudRate.Length);
                BaudRate = BitConverter.ToInt16(bBaudRate, 0);
                start += bBaudRate.Length;

                byte[] bDataTime = new byte[4];
                Buffer.BlockCopy(Data, start, bDataTime, 0, bDataTime.Length);
                Array.Reverse(bDataTime);
                DateTime = BitConverter.ToUInt32(bDataTime, 0);
                start += bDataTime.Length;

                byte[] bLineNumber = new byte[4];
                Buffer.BlockCopy(Data, start, bLineNumber, 0, bLineNumber.Length);
                LineNumber = BitConverter.ToInt32(bLineNumber, 0);
                start += bLineNumber.Length;

                byte[] bStationId = new byte[4];
                Buffer.BlockCopy(Data, start, bStationId, 0, bStationId.Length);
                StationId = BitConverter.ToInt32(bStationId, 0);
                start += bStationId.Length;

                byte[] bReaderId = new byte[1];
                Buffer.BlockCopy(Data, start, bReaderId, 0, bReaderId.Length);
                ReaderId = bReaderId[0];
                start += bReaderId.Length;

                byte[] bPriceTable = new byte[20];
                Buffer.BlockCopy(Data, start, bPriceTable, 0, bPriceTable.Length);
                start += bPriceTable.Length;
                int priceTableIndex = 0;
                while (priceTableIndex < bPriceTable.Length)
                {
                    byte[] bTempPrice = new byte[2];
                    Buffer.BlockCopy(Data, priceTableIndex, bTempPrice, 0, bTempPrice.Length);
                    PriceTable.Add(BitConverter.ToInt16(bTempPrice, 0));
                    priceTableIndex += bTempPrice.Length;
                }

                byte[] bSendOldTicketCountAgain = new byte[4];
                Buffer.BlockCopy(Data, start, bSendOldTicketCountAgain, 0, bSendOldTicketCountAgain.Length);
                SendOldTicketCountAgain = BitConverter.ToInt32(bSendOldTicketCountAgain, 0);
                start += bLineNumber.Length;

                byte[] bStatus = new byte[1];
                Buffer.BlockCopy(Data, start, bStatus, 0, bStatus.Length);
                Status = bStatus[0] == 0xBA;
                start += bStatus.Length;

                byte[] bCRC = new byte[2];
                Buffer.BlockCopy(Data, start, bCRC, 0, bCRC.Length);
                CRC = BitConverter.ToUInt16(bCRC, 0);
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static byte[] ProcessOnlineReaderSaveConfig(byte[] Data)//, int pCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                //db.setQuery("update AUTOnlineReaderTicket set IsProceced=1 where code=" + pCode.ToString());
                //db.Query_Execute();

                Int64 IMEI;//8
                string ServerIP;//4
                Int16 ServerPort;//2
                Int16 BaudRate;//2
                uint DateTime;//4
                int LineNumber;//4
                int StationId;//4
                byte ReaderId;//1
                List<Int16> PriceTable = new List<Int16>();//20 byte array [10 price]
                UInt16 CRC;//2

                int start = 2;
                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, start, bIMEI, 0, bIMEI.Length);
                IMEI = BitConverter.ToInt64(bIMEI, 0);
                start += bIMEI.Length;

                string query = @"SELECT TOP 1 * FROM [dbo].[AUTOnlineReaderConfig] WHERE [IMEI] = @IMEI ORDER BY CODE DESC";
                db.setQuery(query);
                db.AddParams("@IMEI", IMEI);
                var result = db.Query_DataTable();
                if (result == null || result.Rows.Count <= 0)
                    return null;

                byte[] bCRC = new byte[2];
                Buffer.BlockCopy(Data, Data.Length - 2, bCRC, 0, bCRC.Length);
                CRC = BitConverter.ToUInt16(bCRC, 0);

                //byte[] tempData = new byte[Data.Length - 2 /* Header Length */ - 2 /* CRC Length */];
                //Buffer.BlockCopy(Data, 2, tempData, 0, tempData.Length);
                //if (tempData.CRC16() != CRC)
                //    return null;

                UInt16 existConfigCRC, existConfigCRC2;
                byte[] existConfigData2;
                byte[] existConfigData = GetOnlineReaderConfig(result.Rows[0], out existConfigCRC, out existConfigData2, out existConfigCRC2);
                //try
                //{


                //    db.setQuery(@"UPDATE [dbo].[AUTOnlineReaderConfig] SET GetConfigDate=GETDATE() WHERE [IMEI]=" + IMEI);

                //}
                //catch (Exception ex)
                //{

                //}
                if (CRC == existConfigCRC2)
                    return null;




                ////byte[] bServerIP = new byte[4];
                ////Buffer.BlockCopy(Data, start, bServerIP, 0, bServerIP.Length);
                ////ServerIP = BitConverter.ToString(bServerIP, 0);
                ////start += bServerIP.Length;

                ////byte[] bServerPort = new byte[2];
                ////Buffer.BlockCopy(Data, start, bServerPort, 0, bServerPort.Length);
                ////ServerPort = BitConverter.ToInt16(bServerPort, 0);
                ////start += bServerPort.Length;

                ////byte[] bBaudRate = new byte[2];
                ////Buffer.BlockCopy(Data, start, bBaudRate, 0, bBaudRate.Length);
                ////BaudRate = BitConverter.ToInt16(bBaudRate, 0);
                ////start += bBaudRate.Length;

                ////byte[] bDataTime = new byte[4];
                ////Buffer.BlockCopy(Data, start, bDataTime, 0, bDataTime.Length);
                ////Array.Reverse(bDataTime);
                ////DateTime = BitConverter.ToUInt32(bDataTime, 0);
                ////start += bDataTime.Length;

                ////byte[] bLineNumber = new byte[4];
                ////Buffer.BlockCopy(Data, start, bLineNumber, 0, bLineNumber.Length);
                ////LineNumber = BitConverter.ToInt32(bLineNumber, 0);
                ////start += bLineNumber.Length;

                ////byte[] bStationId = new byte[4];
                ////Buffer.BlockCopy(Data, start, bStationId, 0, bStationId.Length);
                ////StationId = BitConverter.ToInt32(bStationId, 0);
                ////start += bStationId.Length;

                ////byte[] bReaderId = new byte[1];
                ////Buffer.BlockCopy(Data, start, bReaderId, 0, bReaderId.Length);
                ////ReaderId = bReaderId[0];
                ////start += bReaderId.Length;

                ////byte[] bPriceTable = new byte[20];
                ////Buffer.BlockCopy(Data, start, bPriceTable, 0, bPriceTable.Length);
                ////start += bPriceTable.Length;
                ////int priceTableIndex = 0;
                ////while (priceTableIndex < bPriceTable.Length)
                ////{
                ////    byte[] bTempPrice = new byte[2];
                ////    Buffer.BlockCopy(Data, priceTableIndex, bTempPrice, 0, bTempPrice.Length);
                ////    PriceTable.Add(BitConverter.ToInt16(bTempPrice, 0));
                ////    priceTableIndex += bTempPrice.Length;
                ////}

                //byte[] bCRC = new byte[2];
                //Buffer.BlockCopy(Data, start, bCRC, 0, bCRC.Length);
                //CRC = BitConverter.ToUInt16(bCRC, 0);

                //byte[] tempData = new byte[Data.Length - 2 /* Header Length */ - 2 /* CRC Length */];
                //Buffer.BlockCopy(Data, 2, tempData, 0, tempData.Length);
                //if (tempData.CRC16() != CRC)
                //    return null;

                //string query = @"SELECT TOP 1 * FROM [dbo].[AUTOnlineReaderConfig] WHERE [IMEI] = @IMEI ORDER BY CODE DESC";
                //db.setQuery(query);
                //db.AddParams("@IMEI", IMEI);
                //var result = db.Query_DataTable();
                //if (result == null || result.Rows.Count <= 0)
                //    return null;
                //UInt16 existConfigCRC, existConfigCRC2;
                //byte[] existConfigData2;
                //byte[] existConfigData = GetOnlineReaderConfig(result.Rows[0], out existConfigCRC);
                //if (tempData.CRC16() == existConfigCRC)
                //    return null;
                //////byte[] configData = new byte[existConfigData2.Length + 2];
                //////Buffer.BlockCopy(existConfigData, 0, configData, 0, existConfigData.Length);
                //////byte[] crcByteArray = BitConverter.GetBytes(existConfigCRC);
                //////Buffer.BlockCopy(crcByteArray, 0, configData, configData.Length - 2, crcByteArray.Length);
                //////return configData;
                return existConfigData2;
            }
            catch (Exception ex)
            {
                //System.Threading.Thread.CurrentThread.Abort();
                return System.Text.Encoding.UTF8.GetBytes("SAVE CONFIG FAILURE - " + ex.Message); ;
            }
            finally
            {
                db.Dispose();
            }
        }
        public static byte[] GetOnlineReaderConfig(DataRow row, out UInt16 crc1, out byte[] _data2, out UInt16 crc2)
        {
            string saveConfigText = "SAVE CFG";
            byte[] saveConfigByteArray = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            byte[] data = new byte[48 + saveConfigByteArray.Length];
            byte[] data2 = new byte[48 - 2/*CRC Length*/ - 4/*SendOldTicketCount Length*/ - 1/*Disable Length*/];
            try
            {
                int start = 0
                    , start2 = 0;
                Buffer.BlockCopy(saveConfigByteArray, 0, data, start, saveConfigByteArray.Length);
                start += saveConfigByteArray.Length;

                byte[] serverIpByteArray = new byte[4];
                string[] serverIp = row["ServerIP"].ToString().Split('.');
                for (int j = 0; j < serverIp.Length; j++)
                    serverIpByteArray[j] = byte.Parse(serverIp[j]);
                Buffer.BlockCopy(serverIpByteArray, 0, data, start, serverIpByteArray.Length);
                Buffer.BlockCopy(serverIpByteArray, 0, data2, start2, serverIpByteArray.Length);
                start += serverIpByteArray.Length;
                start2 += serverIpByteArray.Length;

                byte[] serverPortByteArray = BitConverter.GetBytes(Int16.Parse(row["ServerPort"].ToString()));
                Buffer.BlockCopy(serverPortByteArray, 0, data, start, serverPortByteArray.Length);
                Buffer.BlockCopy(serverPortByteArray, 0, data2, start2, serverPortByteArray.Length);
                start += serverPortByteArray.Length;
                start2 += serverPortByteArray.Length;

                byte[] baudRateByteArray = BitConverter.GetBytes(Int16.Parse(row["BaudRate"].ToString()));
                Buffer.BlockCopy(baudRateByteArray, 0, data, start, baudRateByteArray.Length);
                Buffer.BlockCopy(baudRateByteArray, 0, data2, start2, baudRateByteArray.Length);
                start += baudRateByteArray.Length;
                start2 += baudRateByteArray.Length;

                byte[] datetimeByteArray = BitConverter.GetBytes(JTransactions.ConvertDateTimeToUint(DateTime.Now));
                Buffer.BlockCopy(datetimeByteArray, 0, data, start, datetimeByteArray.Length);
                Buffer.BlockCopy(datetimeByteArray, 0, data2, start2, datetimeByteArray.Length);
                start += datetimeByteArray.Length;
                start2 += datetimeByteArray.Length;

                byte[] lineNumberByteArray = BitConverter.GetBytes(int.Parse(row["LineNumber"].ToString()));
                Buffer.BlockCopy(lineNumberByteArray, 0, data, start, lineNumberByteArray.Length);
                Buffer.BlockCopy(lineNumberByteArray, 0, data2, start2, lineNumberByteArray.Length);
                start += lineNumberByteArray.Length;
                start2 += lineNumberByteArray.Length;

                byte[] stationIdByteArray = BitConverter.GetBytes(int.Parse(row["StationId"].ToString()));
                Buffer.BlockCopy(stationIdByteArray, 0, data, start, stationIdByteArray.Length);
                Buffer.BlockCopy(stationIdByteArray, 0, data2, start2, stationIdByteArray.Length);
                start += stationIdByteArray.Length;
                start2 += stationIdByteArray.Length;

                byte[] readerIdByteArray = new byte[1];
                readerIdByteArray[0] = byte.Parse(row["ReaderId"].ToString());
                Buffer.BlockCopy(readerIdByteArray, 0, data, start, readerIdByteArray.Length);
                Buffer.BlockCopy(readerIdByteArray, 0, data2, start2, readerIdByteArray.Length);
                start += readerIdByteArray.Length;
                start2 += readerIdByteArray.Length;

                byte[] priceTableByteArray = new byte[20];
                int i = 0;
                try
                {
                    if (row["PriceTable"] != null && row["PriceTable"].ToString().Length > 0)
                    {
                        string[] priceTableStringArray = row["PriceTable"].ToString().Split(',');
                        for (; i < priceTableStringArray.Length; i++)
                        {
                            byte[] priceByteArray = BitConverter.GetBytes(int.Parse(priceTableStringArray[i]));
                            Buffer.BlockCopy(priceByteArray, 0, priceTableByteArray, i * 2, 2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (i <= 0)
                    {
                        crc1 = 0;
                        crc2 = 0;
                        _data2 = System.Text.Encoding.UTF8.GetBytes("PRICETABLE FAILURE - " + ex.Message);
                        return System.Text.Encoding.UTF8.GetBytes("PRICETABLE FAILURE - " + ex.Message);
                    }
                }
                Buffer.BlockCopy(priceTableByteArray, 0, data, start, priceTableByteArray.Length);
                Buffer.BlockCopy(priceTableByteArray, 0, data2, start2, priceTableByteArray.Length);
                start += priceTableByteArray.Length;

                byte[] sendOldTicketCountByteArray = BitConverter.GetBytes(int.Parse(row["SendOldTicketCount"].ToString()));
                Buffer.BlockCopy(sendOldTicketCountByteArray, 0, data, start, sendOldTicketCountByteArray.Length);
                start += sendOldTicketCountByteArray.Length;

                byte[] disableByteArray = new byte[1];
                disableByteArray[0] = (byte)(bool.Parse(row["Disable"].ToString()) ? 0xBA : 0xBB);
                Buffer.BlockCopy(disableByteArray, 0, data, start, disableByteArray.Length);
                start += disableByteArray.Length;

                byte[] tempData = new byte[data.Length - saveConfigByteArray.Length - 2 /* CRC Length */];
                Buffer.BlockCopy(data, saveConfigByteArray.Length, tempData, 0, tempData.Length);
                crc1 = tempData.CRC16();
                byte[] crcByteArray = BitConverter.GetBytes(crc1);
                Buffer.BlockCopy(crcByteArray, 0, data, start, crcByteArray.Length);

                byte[] tempData2 = new byte[data2.Length - 2 /* CRC Length */];
                Buffer.BlockCopy(data2, 0, tempData2, 0, tempData2.Length);
                crc2 = tempData2.CRC16();
                byte[] crcByteArray2 = BitConverter.GetBytes(crc2);
                Buffer.BlockCopy(crcByteArray2, 0, data2, data2.Length - 2, crcByteArray2.Length);
            }
            catch (Exception ex)
            {
                crc1 = 0;
                crc2 = 0;
                _data2 = System.Text.Encoding.UTF8.GetBytes("GET CONFIG FAILURE - " + ex.Message);
                return System.Text.Encoding.UTF8.GetBytes("GET CONFIG FAILURE - " + ex.Message);
            }
            _data2 = data2;
            return data;
        }
        public static byte[] ProcessOnlineReaderGetConfig(byte[] Data, out UInt16 crc1, out byte[] data2, out UInt16 crc2)
        {
            string saveConfigText = "SAVE CFG";
            byte[] saveConfigByteArray = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            //byte[] data = new byte[48 + saveConfigByteArray.Length];
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                Int64 IMEI;//8

                int start = 2;
                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, start, bIMEI, 0, bIMEI.Length);
                IMEI = BitConverter.ToInt64(bIMEI, 0);

                string query = @"SELECT TOP 1 * FROM [dbo].[AUTOnlineReaderConfig] WHERE [IMEI] = @IMEI ORDER BY CODE DESC";
                db.setQuery(query);
                db.AddParams("IMEI", IMEI);
                DataTable dt = db.Query_DataTable();
                if (dt == null || dt.Rows.Count <= 0)
                {
                    crc1 = 0;
                    crc2 = 0;
                    data2 = System.Text.Encoding.UTF8.GetBytes("NO CONFIG");
                    return System.Text.Encoding.UTF8.GetBytes("NO CONFIG");
                }
                else
                {
                    return GetOnlineReaderConfig(dt.Rows[0], out crc1, out data2, out crc2);
                }
            }
            catch (Exception ex)
            {
                //System.Threading.Thread.CurrentThread.Abort();
                crc1 = 0;
                crc2 = 0;
                data2 = System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetConfig FAILURE - " + ex.Message);
                return System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetConfig FAILURE - " + ex.Message);
            }
            finally
            {
                db.Dispose();
            }
            //return data;
        }
        /// <summary>
        /// //
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static byte[] ProcessOnlineReaderCheckUpdate(byte[] Data, out UInt16 crc1, out byte[] data2, out UInt16 crc2)
        {
            try
            {
                string ReaderFileUpdateName = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "UpdateReader") + "\\UpdateReade.BIN";
                string array = File.ReadAllText(ReaderFileUpdateName);

                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, 2, bIMEI, 0, bIMEI.Length);
                Int64 IMEI = BitConverter.ToInt64(bIMEI, 0);
                
                
                //for (int i = ReaderVersion.Length - 1; i >= 0; i--)
                //{
                //    double x = Math.Pow(10.0, i * 2.0);
                //    int div = ReaderVersion[ReaderVersion.Length - i - 1] / 16;
                //    int mode = ReaderVersion[ReaderVersion.Length - i - 1] % 16;
                //    rv += (int)((div * 10 + mode) * x);
                //}
                string  RV = "";
                byte[] bReaderVersion = new byte[3];
                Buffer.BlockCopy(Data, 10, bReaderVersion, 0, 3);
                RV = bReaderVersion[0].ToString() + bReaderVersion[1].ToString() + bReaderVersion[2].ToString();
                ClassLibrary.JDataBase DB = new JDataBase();

                DataTable dt;
                DB.setQuery("update AutOnlinereaderPermissionUpdate set version = " + RV + " where imei = " + IMEI);
                DB.Query_Execute();
                DB.setQuery("Select Distinct imei,Version from AutOnlinereaderPermissionUpdate where imei = " + IMEI + " and uppermission = 1");
                dt = DB.Query_DataTable();
                if (dt.Rows.Count > 0 && IMEI.ToString() == dt.Rows[0]["IMEI"].ToString() && RV != dt.Rows[0]["Version"])
                {
                    try
                    {

                        UInt16 UpdateOnlineReaderCRC, UpdateOnlineReaderCRC2;
                        byte[] UpdateOnlineReader2;
                        byte[] UpdateOnlineReader = ProcessOnlineReaderCheckUpdateD(array, out UpdateOnlineReaderCRC, out UpdateOnlineReader2, out UpdateOnlineReaderCRC2);

                        data2 = ProcessOnlineReaderCheckUpdateD(array, out crc1, out UpdateOnlineReader2, out crc2);
                        return data2;

                    }
                    catch (Exception ex)
                    {
                        crc1 = 0;
                        crc2 = 0;

                        data2 = System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetUpdate FAILURE - " + ex.Message + crc1 + crc2);
                        return System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetUpdate FAILURE - " + ex.Message + crc1 + crc2);
                    }
                }
                else
                {
                    crc1 = 0;
                    crc2 = 0;

                    data2 = System.Text.Encoding.UTF8.GetBytes("NO " + crc1 + crc2);
                    return System.Text.Encoding.UTF8.GetBytes("NO " + crc1 + crc2);
                }
            }
            catch (Exception ex)
            {
                crc1 = 0;
                crc2 = 0;
                data2 = System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetUpdate FAILURE - " + ex.Message + crc1 + crc2);
                return System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetUpdate FAILURE - " + ex.Message + crc1 + crc2);
            }

        }
        public static byte[] ProcessOnlineReaderCheckUpdateD(string row, out UInt16 crc1, out byte[] _data2, out UInt16 crc2)
        {
            string ReaderFileUpdateName = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "UpdateReader") + "\\UpdateReade.BIN";

            string saveConfigText = "YES";
            string array = File.ReadAllText(ReaderFileUpdateName);
            byte[] saveConfigByteArray = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            byte[] Info = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            byte[] data = new byte[10];
            byte[] data2 = new byte[10];


            try
            {

                int start = 0;

                Buffer.BlockCopy(saveConfigByteArray, 0, data, start, saveConfigByteArray.Length);
                start += saveConfigByteArray.Length;


                byte[] VersionByteArray = new byte[3];
                string[] Version = "97.08.01".ToString().Split('.');
                for (int j = 0; j < Version.Length; j++)
                    VersionByteArray[j] = byte.Parse(Version[j]);
                Buffer.BlockCopy(VersionByteArray, 0, data, start, VersionByteArray.Length);

                start += VersionByteArray.Length;

                Int16 NumberofPackets = 390; //(Int16)(array.Length / 512);

                byte[] SizeByteArray = new byte[2];
                SizeByteArray = BitConverter.GetBytes(NumberofPackets);
                Array.Reverse(SizeByteArray);
                Buffer.BlockCopy(SizeByteArray, 0, data, start, SizeByteArray.Length);
                start += SizeByteArray.Length;

                crc1 = 0;
                byte[] crcByteArray = BitConverter.GetBytes(crc1);
                Buffer.BlockCopy(crcByteArray, 0, data, start, crcByteArray.Length);
                crc2 = 0;
                byte[] crcByteArray2 = BitConverter.GetBytes(crc2);
                Buffer.BlockCopy(crcByteArray2, 0, data, start, crcByteArray2.Length);
            }
            catch (Exception ex)
            {
                crc1 = 0;
                crc2 = 0;
                _data2 = System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderCheckUpdateD FAILURE - " + ex.Message);
                return System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderCheckUpdateD FAILURE - " + ex.Message);
            }
            _data2 = data2;
            return data;
        }
        public static byte[] ProcessOnlineReaderSendUpdate(byte[] Data, out byte[] _data2)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            string ReaderFileUpdateName = Path.Combine(ClassLibrary.JFiles.GetExecutingDirectory(), "UpdateReader") + "\\UpdateReade.BIN";
            string saveConfigText = "UPDATE";
            string array = File.ReadAllText(ReaderFileUpdateName);
            byte[] saveConfigByteArray = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            byte[] Info = System.Text.Encoding.UTF8.GetBytes(saveConfigText);
            byte[] data = new byte[522];
            byte[] data2 = new byte[522];
            try
            {

                int start = 2;
                Int16 PacketID;
                byte[] bPacketId = new byte[2];
                Buffer.BlockCopy(Data, start, bPacketId, 0, 2);
                PacketID = BitConverter.ToInt16(bPacketId, 0);


                int StartFrom = PacketID * 512;
                int EndTo = (PacketID + 1) * 512;
                byte[] SendBytes = File.ReadAllBytes(ReaderFileUpdateName).Skip(StartFrom).Take(EndTo).ToArray();

                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, 4, bIMEI, 0, bIMEI.Length);
                Int64 IMEI = BitConverter.ToInt64(bIMEI, 0);


                int startOfP = 0;
                Buffer.BlockCopy(saveConfigByteArray, 0, data, startOfP, saveConfigByteArray.Length);
                startOfP += saveConfigByteArray.Length;

                byte[] NumOfPacketArray = new byte[2];
                NumOfPacketArray = BitConverter.GetBytes(PacketID);
                Array.Reverse(NumOfPacketArray);
                Buffer.BlockCopy(NumOfPacketArray, 0, data, startOfP, NumOfPacketArray.Length);
                startOfP += NumOfPacketArray.Length;


                byte[] packarray = new byte[512];

                for (int j = 0; j < packarray.Length; j++)
                    packarray[j] = SendBytes[j];
                Buffer.BlockCopy(packarray, 0, data, startOfP, packarray.Length);

                startOfP += packarray.Length;
                byte[] crcByteArray = new byte[2];
                short crc = 00;
                crcByteArray = BitConverter.GetBytes(crc);
                Buffer.BlockCopy(crcByteArray, 0, data, startOfP, crcByteArray.Length);
                //int crc2 = 0;
                //byte[] crcByteArray2 = BitConverter.GetBytes(crc2);
                //Buffer.BlockCopy(crcByteArray2, 0, data, startOfP, crcByteArray2.Length);
                string sql = "";
                sql += @"insert into AutOnlineReaderUpdateLog(IMEI,Numofpacket,RequestDate) values(" + IMEI + "," + PacketID + ",getdate())";
                db.setQuery(sql);
                db.Query_Execute();
                db.Dispose();


            }
            catch (Exception ex)
            {
                //crc1 = 0;
                //crc2 = 0;
                data2 = System.Text.Encoding.UTF8.GetBytes("ProcessOnlineReaderGetUpdate FAILURE - " + ex.Message);//+ crc1 + crc2);
                _data2 = data2;
                return data2;
            }
            _data2 = data2;
            return data;


        }



        public static bool ProcessOnlineReaderDriverLoginLogout(byte[] Data)//, int pCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                Int64 IMEI;//8
                Int64 DriverId;//8
                uint DateTime;//4
                bool LoginLogout;//1
                int LineNumber;//4
                int StationId;//4
                byte ReaderId;//1
                UInt16 CRC;//2

                int start = 2;
                byte[] bIMEI = new byte[8];
                Buffer.BlockCopy(Data, start, bIMEI, 0, bIMEI.Length);
                IMEI = BitConverter.ToInt64(bIMEI, 0);
                start += bIMEI.Length;

                byte[] bDriverId = new byte[8];
                Buffer.BlockCopy(Data, start, bDriverId, 0, bDriverId.Length);
                Array.Reverse(bDriverId);
                DriverId = BitConverter.ToInt64(bDriverId, 0);
                start += bDriverId.Length;

                byte[] bDataTime = new byte[4];
                Buffer.BlockCopy(Data, start, bDataTime, 0, bDataTime.Length);
                Array.Reverse(bDataTime);

                DateTime = BitConverter.ToUInt32(bDataTime, 0);
                start += bDataTime.Length;

                byte[] bLoginLogout = new byte[1];
                Buffer.BlockCopy(Data, start, bLoginLogout, 0, bLoginLogout.Length);
                LoginLogout = bLoginLogout[0] == 0xAA;
                start += bLoginLogout.Length;

                byte[] bLineNumber = new byte[4];
                Buffer.BlockCopy(Data, start, bLineNumber, 0, bLineNumber.Length);
                Array.Reverse(bLineNumber);
                LineNumber = BitConverter.ToInt32(bLineNumber, 0);
                start += bLineNumber.Length;

                byte[] bStationId = new byte[4];
                Buffer.BlockCopy(Data, start, bStationId, 0, bStationId.Length);
                Array.Reverse(bStationId);
                StationId = BitConverter.ToInt32(bStationId, 0);
                start += bStationId.Length;

                byte[] bReaderId = new byte[1];
                Buffer.BlockCopy(Data, start, bReaderId, 0, bReaderId.Length);
                ReaderId = bReaderId[0];
                start += bReaderId.Length;

                byte[] bCRC = new byte[2];
                Buffer.BlockCopy(Data, start, bCRC, 0, bCRC.Length);
                Array.Reverse(bCRC);
                CRC = BitConverter.ToUInt16(bCRC, 0);

                byte[] tempData = new byte[Data.Length - 2 /* Header Length */ - 2 /* CRC Length */];
                Buffer.BlockCopy(Data, 2, tempData, 0, tempData.Length);
                if (tempData.CRC16() != CRC)
                    return false;
                EventLog.JEventLog.SaveDriverLoginLogout(
                    LoginLogout ?
                        EventLog.JEventLog.EventLogType.DriverLogin_EventType.GetHashCode().ToString()
                        :
                        EventLog.JEventLog.EventLogType.DriverLogout_EventType.GetHashCode().ToString()
                    , JTransactions.ConvertUintToDateTime(DateTime).ToString()
                    , (uint)StationId
                    , DriverId
                    , db);
                return true;
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentThread.Abort();
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbyte"></param>
        /// <param name="pState">1 is Left and 2 is Right Shift</param>
        /// <param name="pLen"></param>
        /// <returns></returns>
        private Byte[] RightLeftShift(ref Byte[] pbyte, int pState, int pLen)
        {
            if (pState == 1)
            {
                for (int i = 0; i < pbyte.Length; i++)
                {
                    if (i + pLen >= pbyte.Length)
                        pbyte[i] = 0;
                    else
                        pbyte[i] = pbyte[i + pLen];
                }
            }
            else
            {
                for (int i = pbyte.Length - pLen; i >= 0; i--)
                {
                    if (i - pLen <= 0)
                    {
                        pbyte[i] = 0;
                    }
                    else
                        pbyte[i] = pbyte[i - pLen];
                }
            }
            return pbyte;
        }

        public void CheckDataSQLiteTicket(bool all = false)
        {
            try
            {

                int Code = 0;
                int ArchiveCode = 0;
                byte[] Content = new byte[0];
                JSQLiteDataBase SQLiteDB = null;
                DataTable SQLiteDT = null;

                int trueCount = 0;
                int falseCount = 0;

                ClassLibrary.JFile File = new ClassLibrary.JFile();

                ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
                try
                {
                    if (all)
                        Archivedb.setQuery(@"SELECT ac.[Code] ,ac.[Contents],(select top 1 Code From ArchiveInterface where ArchiveCode = ac.[Code]) as ArchiveCode 
                                    FROM [ArchiveContent] ac  where Status=1 and FileExtension like N'.dball'");
                    else
                        Archivedb.setQuery(@"SELECT ac.[Code] ,ac.[Contents],(select top 1 Code From ArchiveInterface where ArchiveCode = ac.[Code]) as ArchiveCode 
                                    FROM [ArchiveContent] ac  where Status=1 and FileExtension like N'.db'");
                    DataTable DT = Archivedb.Query_DataTable();
                    DataTable TicketDT = null;
                    foreach (DataRow DR in DT.Rows)
                    {

                        try
                        {
                            Code = int.Parse(DR["Code"].ToString());
                            Content = (DR["Contents"] as byte[]);
                            ArchiveCode = int.Parse(DR["ArchiveCode"].ToString());

                            string FileName = Guid.NewGuid().ToString() + ".db";

                            File.Content = Content;
                            File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
                            File.Write();

                            JConnection C = new JConnection();

                            SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

                            if (all)
                                SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\";");
                            else
                                SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\" WHERE issent = 0;");
                            SQLiteDT = SQLiteDB.Query_DataTable();
                        }
                        catch (Exception ex)
                        {
                        }
                        ProcessSqliteDataTable(SQLiteDT, ref TicketDT, ref trueCount, ref falseCount, Code);
                        SQLiteDB.DisConnect();
                        SQLiteDB.Dispose();
                        SQLiteDB = null;
                        int count = 0;
                        while (count < 10)
                        {
                            try
                            {
                                System.IO.File.Delete(File.FileName);
                                count = 10;
                            }
                            catch (Exception ex)
                            {
                                Thread.Sleep(1000);
                                count++;
                            }
                        }
                        if (TicketDT != null && TicketDT.Rows.Count > 0)
                        {
                            Transaction.JTicketTransactions.AddTicketTransactionExtract(TicketDT, ArchiveCode);
                            Transaction.JTicketTransactions.AddTicket(ref TicketDT, "", false);
                            TicketDT.Clear();
                        }
                        TicketDT = null;
                        Archivedb.setQuery("Update ArchiveContent Set Status=2,TrueTCount=" + trueCount + ",FalseTCount=" + falseCount + " where Code=" + Code.ToString());
                        Archivedb.Query_Execute();
                    }//foreach
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    Archivedb.Dispose();
                    //db.Dispose();
                }
            }
            catch
            {

            }
        }
        public static void ProcessSqliteDataTable(DataTable SQLiteDT, ref DataTable TicketDT, ref int trueCount, ref int falseCount, int ArchiveCode)
        {
            if (SQLiteDT != null)
            {
                trueCount = 0;
                falseCount = 0;
                foreach (DataRow SQLiteDR in SQLiteDT.Rows)
                {
                    try
                    {

                        bool isSuccess = true;
                        JTransactionTicketHeader TH = new JTransactionTicketHeader();
                        TH.busSerial = uint.Parse(SQLiteDR["BUSSerial"].ToString());
                        try
                        {
                            TH.DATE = JTransactions.ConvertUintToDateTime(ulong.Parse(SQLiteDR["DateTime"].ToString()));
                        }
                        catch (Exception ex)
                        {

                        }
                        TH.DriverSerialCard = SQLiteDR["DriverSerial"].ToString();
                        TH.LineNumber = uint.Parse(SQLiteDR["LineNumber"].ToString());

                        DateTime date = TH.DATE;

                        JTransactionTicket Ticket = new JTransactionTicket();
                        Ticket.CardType = uint.Parse(SQLiteDR["Type"].ToString());

                        int iTempCounter = 0;
                        byte[] b = BitConverter.GetBytes(UInt64.Parse(SQLiteDR["RFID"].ToString()));
                        if (b[0] == 0
                                && b[1] == 0
                                && b[2] == 0
                                && b[3] == 0
                            )
                        {
                            while (
                                iTempCounter < 4 &&
                                b[0] == 0 &&
                                BitConverter.ToUInt64(b, 0) > 0
                                )
                            {
                                b = JTransactionTicket.ShiftLeft(b, 8);
                                iTempCounter++;
                            }
                        }
                        Ticket.PassengerCardSerial = BitConverter.ToUInt64(b, 0);
                        Ticket.ReaderID = uint.Parse(SQLiteDR["ReaderId"].ToString());
                        Ticket.RemainPrice = uint.Parse(SQLiteDR["RemainPrice"].ToString());
                        Ticket.TicketPrice = uint.Parse(SQLiteDR["Price"].ToString());
                        Ticket.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                        Ticket.transactionid = uint.Parse(SQLiteDR["index"].ToString());

                        DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                        Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, Ticket.transactionid, "0"
                            , TH.busSerial, new byte[] { 1 }, ref TicketDT);
                        trueCount++;
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                        falseCount++;
                    }
                    finally
                    {
                    }

                }// FOreach

            }//IF
        }

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


        public static DataTable OpenSQLiteTicketDataBaseSt(int ArchiveContentCode)
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


        public void CheckDataOfflineTicket()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Status=1 and FileExtension like N'.BUS'");
                DataTable DT = Archivedb.Query_DataTable();
                DataTable TicketTB = null;
                foreach (DataRow DR in DT.Rows)
                {
                    byte[] Content = (DR["Contents"] as byte[]);
                    int Code = (int)DR["Code"];

                    int i = 0;
                    while (i < Content.Length)
                    {
                        try
                        {
                            JTransactionTicketOffline TransactionTicketOffline = new JTransactionTicketOffline();
                            Tuple<int> result = TransactionTicketOffline.SetValueOffline(Content, i);

                            bool isSuccess = true;
                            JTransactionTicketHeader TH = new JTransactionTicketHeader();
                            TH.busSerial = TransactionTicketOffline.BusID;
                            try
                            {
                                TH.DATE = JTransactions.ConvertUintToDateTime(TransactionTicketOffline.DateTime);
                            }
                            catch (Exception ex)
                            {

                            }
                            TH.DriverSerialCard = TransactionTicketOffline.DriverID.ToString();
                            TH.LineNumber = TransactionTicketOffline.LineNumber;
                            DateTime date = TH.DATE;

                            JTransactionTicket Ticket = new JTransactionTicket();
                            Ticket.CardType = TransactionTicketOffline.CardType;
                            Ticket.PassengerCardSerial = (uint)TransactionTicketOffline.PassengerID;
                            Ticket.ReaderID = TransactionTicketOffline.ReaderID;
                            Ticket.RemainPrice = TransactionTicketOffline.RemaningPrice;
                            Ticket.TicketPrice = TransactionTicketOffline.Price;
                            Ticket.Time = new int[3] { TH.DATE.Hour,
                            TH.DATE.Minute,
                            TH.DATE.Second };
                            Ticket.transactionid = (uint)Code;

                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                            Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, Code, "0", TransactionTicketOffline.BusID, new byte[] { 1 }, ref TicketTB);
                        }//try
                        catch (Exception ex)
                        {
                            ClassLibrary.JSystem.Except.AddException(ex);
                        }
                        finally
                        {
                        }

                        i += 32;

                    }// While
                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                }//foreach
                Transaction.JTicketTransactions.AddTicket(ref TicketTB, "");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }

        public void CheckDataReaderTicket()
        {
            int Code = 0;
            int falseCount = 0;
            DataTable TicketTB = null;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                ExtractOfflineReaderFile EX = new ExtractOfflineReaderFile();
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Status=1 and FileExtension like N'.reader'");
                DataTable DT = Archivedb.Query_DataTable();
                foreach (DataRow DR in DT.Rows)
                {
                    if (TicketTB != null)
                    {
                        TicketTB.Clear();
                        TicketTB.Dispose();
                        TicketTB = null;
                    }
                    byte[] Content = (DR["Contents"] as byte[]);
                     Code = (int)DR["Code"];
                    EX.fileData = Content;
                    List<TicketReader> Tickets = EX.ReadData();
                    foreach (TicketReader TicketReader in Tickets)
                    {
                        try
                        {
                            bool isSuccess = true;
                            JTransactionTicketHeader TH = new JTransactionTicketHeader();
                            TH.busSerial = TicketReader.BusID;
                            TH.DATE = TicketReader.DateTime;
                            TH.DriverSerialCard = TicketReader.DriverID.ToString();
                            TH.LineNumber = TicketReader.LineNumber;
                            DateTime date = TH.DATE;
                            JTransactionTicket Ticket = new JTransactionTicket();
                            Ticket.CardType = TicketReader.CardType;
                            Ticket.PassengerCardSerial = TicketReader.PassengerID;
                            byte[] b = BitConverter.GetBytes(Ticket.PassengerCardSerial);
                            if (b[0] == 0 && b[1] == 0 && b[2] == 0 && b[3] == 0)
                            {
                                Array.Reverse(b);
                                Ticket.PassengerCardSerial = BitConverter.ToUInt64(b, 0);
                            }
                            Ticket.ReaderID = TicketReader.ReaderID;
                            Ticket.RemainPrice = (UInt32)TicketReader.RemaningPrice;
                            Ticket.TicketPrice = (uint)TicketReader.Price / 10;
                            Ticket.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                            Ticket.transactionid = (uint)Code;
                            Ticket.CType = TicketReader.Type;
                            Ticket.BankType = TicketReader.BankType;
                            Ticket.LTB = TicketReader.BIN_LTB;
                            Ticket.LTD = TicketReader.LTD_SeverCID;
                            Ticket.MacOut = TicketReader.M_O;
                            Ticket.ServerID = TicketReader.LTD_SeverCID;
                            Ticket.ServerMac = TicketReader.ServerMAC;
                            Ticket.TerminalID = TicketReader.TerminalID;
                            Ticket.WaletID = TicketReader.WaletID;

                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                            Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, Code, "0", TicketReader.BusID, new byte[] { 1 }, ref TicketTB);
                        }//try
                        catch (Exception ex)
                        {
                            falseCount++;
                            ClassLibrary.JSystem.Except.AddException(ex);
                        }
                        finally
                        {
                        }

                    }// While 
                    int TrueCount = TicketTB.Rows.Count;
                    //Transaction.JTicketTransactions.AddTicketTransactionExtract(TicketTB, Code);
                    Transaction.JTicketTransactions.AddTicket(ref TicketTB, "", false);
                    Archivedb.setQuery("Update ArchiveContent Set Status=2 ,TrueTCount=" + TrueCount + ",FalseTCount=" + falseCount + "where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                }//foreach
            }
            catch (Exception ex)
            {
                Archivedb.setQuery("Update ArchiveContent Set Status=13 where Code=" + Code.ToString());
                Archivedb.Query_Execute();
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }

        //Open Bus Offline Files
        public DataTable OpenBusOfflineTicketFile(int ArchiveContentCode)
        {
            DataTable dt = new DataTable();
            dt = null;
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="IsProceced"></param>
        /// <returns></returns>
        public static int UpdateSocketCheckDataAVL(JDataBase pdb, Int64 Code, int IsProceced)
        {
            ClassLibrary.JDataBase db;
            if (pdb == null)
                db = new ClassLibrary.JDataBase();
            else
                db = pdb;
            try
            {
                if (IsProceced == BusManagment.Transaction.SocketDataState.Bus_InProcess.GetHashCode())
                {
                    BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread++;
                }
                else if (IsProceced == BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode())
                    BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread++;
                else if (IsProceced < 10)
                {
                    if (BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread > 0)
                        BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread--;
                }
                else if (IsProceced > 9)
                {
                    if (BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread > 0)
                        BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread--;
                }
                db.setQuery("update ClsSocketClientDataManager set IsProceced=" + IsProceced + " where code = " + Code);
                return db.Query_Execute();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                if (pdb == null)
                    db.Dispose();
            }
        }


        private static UInt64 GetLongLE(byte[] buffer)
        {
            UInt64 num = 0L;
            UInt64 num2 = 1L;
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                num += (UInt64)((ulong)buffer[i] * (UInt64)num2);
                num2 *= 256L;
            }
            return num;
        }

        private static bool FromMS(UInt64 microSec, out DateTime result)
        {
            result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            bool result2;
            try
            {
                TimeSpan value = TimeSpan.FromMilliseconds((double)microSec);
                result = result.Add(value);
                result2 = true;
            }
            catch (Exception ex)
            {
                result2 = false;
            }
            return result2;
        }

        public static UInt32 ProceddTeltonika(byte[] bytes, Int64 IMEI, Int64 pIndex, bool Public, bool processWithDelay = false)
        {
            UInt32 RecivePointCount = 0;
            byte b2 = 0;
            int num = 8;
            b2 = bytes[num + 1];
            byte[] array = new byte[8];
            byte[] array2 = new byte[4];
            byte[] array3 = new byte[2];
            List<AVLStruct> Points = new List<AVLStruct>();
            num = 10;
            for (int i = 0; i < (int)b2; i++)
            {
                try
                {
                    RecivePointCount += 1;
                    Buffer.BlockCopy(bytes, num, array, 0, 8);
                    UInt64 longLE = GetLongLE(array);
                    DateTime t;
                    if (FromMS(longLE, out t))
                    {
                        //if (t.DayOfYear > 80 && t.DayOfYear < 265)
                        //{
                        //    t = t.AddMinutes(270.0);
                        //}
                        //else
                        //{
                        //    t = t.AddMinutes(210.0);
                        //}
                        string DateSend = t.ToString("yyyy/MM/dd HH:mm:ss");

                        num += 9;

                        Buffer.BlockCopy(bytes, num, array2, 0, 4);
                        string text3 = GetLongLE(array2).ToString();
                        string Lon = text3.Substring(0, 2) + "." + text3.Substring(2, text3.Length - 2);

                        num += 4;

                        Buffer.BlockCopy(bytes, num, array2, 0, 4);
                        string text5 = GetLongLE(array2).ToString();
                        string Lat = text5.Substring(0, 2) + "." + text5.Substring(2, text5.Length - 2);

                        num += 4;
                        Buffer.BlockCopy(bytes, num, array3, 0, 2);
                        string Alt = GetLongLE(array3).ToString();

                        num += 2;
                        Buffer.BlockCopy(bytes, num, array3, 0, 2);
                        string Angle = GetLongLE(array3).ToString();

                        num += 2;
                        byte b3 = bytes[num];
                        byte GpsAnt;
                        if (b3 <= 14)
                        {
                            GpsAnt = Convert.ToByte((double)b3 * 3.5);
                        }
                        else
                        {
                            GpsAnt = 35;
                        }

                        num += 1;

                        Buffer.BlockCopy(bytes, num, array3, 0, 2);
                        string Speed = GetLongLE(array3).ToString();

                        num += 2;

                        if (t > DateTime.Now.AddDays(-10.0) && t < DateTime.Now.AddDays(10.0))
                        {
                            BusManagment.Transaction.AVLStruct detailList = new AVLStruct();
                            detailList.IMEI = IMEI;
                            detailList.LayerID = 0;
                            detailList.Lon = float.Parse(Lon);
                            detailList.Lat = float.Parse(Lat);
                            detailList.Alt = float.Parse(Alt);
                            detailList.DateSend = DateTime.Parse(DateSend);
                            detailList.Speed = int.Parse(Speed);
                            detailList.ChargeSIMCard = 0;
                            detailList.MsgType = 0;
                            detailList.BattryCharge = 0;
                            detailList.GpsAnt = GpsAnt;
                            detailList.GsmAnt = 0;
                            detailList.Course = float.Parse(Angle) / 2;
                            Points.Add(detailList);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                    num += 1;
                    int NumberIo = bytes[num];
                    num += 1;
                    int OneIo = bytes[num] * 2 + 1;
                    num += OneIo;
                    int TowIo = bytes[num] * 3 + 1;
                    num += TowIo;
                    int FourIo = bytes[num] * 5 + 1;
                    num += FourIo;
                    int EightIo = bytes[num] * 9 + 1;
                    num += EightIo;

                    //if (bytes[num + 2] == 0)
                    //    num += 6;
                    //else
                    //{
                    //    num += 16;
                    //}
                }
                catch (Exception ex)
                {
                }
            } // for
            if (Points.Count > 0)
            {
                BusManagment.Transaction.JTransactionAVL.GetClassNameBusNumberTeltonika(Points, pIndex, Public, processWithDelay);
            }
            else
                JTransactions.UpdateSocketCheckDataAVL(null, pIndex, BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode()); // Error

            return RecivePointCount;
        }



        public static int UpdateSocketCheckDataAVL(JDataBase pdb, Int64[] Code, int pSetIsProcess)
        {
            if (Code == null || Code.Length == 0)
                return 0;
            ClassLibrary.JDataBase db;
            if (pdb == null)
                db = new ClassLibrary.JDataBase();
            else
                db = pdb;
            try
            {
                //BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread++;

                if (pSetIsProcess == BusManagment.Transaction.SocketDataState.Bus_InProcess.GetHashCode())
                {
                    BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread += Code.Length;
                }
                else if (pSetIsProcess == BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode())
                    BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread += Code.Length;
                else if (pSetIsProcess < 10)
                {
                    if (BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread > 0)
                        BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread -= Code.Length;
                }
                else if (pSetIsProcess > 9)
                {
                    if (BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread > 0)
                        BusManagment.Transaction.JTransactions.SocketCheckDataTeltonikaAVLThread -= Code.Length;
                }

                db.setQuery("update ClsSocketClientDataManager set IsProceced=" + pSetIsProcess + " where code in (" + string.Join(",", Code) + ")");
                return db.Query_Execute();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                if (pdb == null)
                    db.Dispose();
            }
        }

        public volatile static int SocketCheckDataAVLThread = 0;
        public volatile static int SocketCheckDataTeltonikaAVLThread = 0;
        static int MaxSleep = 60;
        DateTime TempD;
        static int DelayTime = 0;
        public volatile static String DelayMessageUpdate = "";
        public volatile static String DelayMessageProcess = "";
        public volatile static String DelayMessageSaveAVL = "";
        public volatile static int IsProcess = 0;
        public volatile static int IsProcessTeltonika = 0;
        public void SocketCheckDataAVL(JDataBase db, bool Public, int pSetIsProceced)
        {
            string IsProceced = "IsProceced=" + pSetIsProceced;
            try
            {
                if (SocketCheckDataAVLThread > MaxSleep)
                    return;

                IsProcess = 0;

                db.setQuery(@"select top " + (MaxSleep - SocketCheckDataAVLThread).ToString() + " * from [ClsSocketClientDataManager] where " + IsProceced + " order by Code desc");
                DataTable dt = db.Query_DataTable();

                if (dt == null || dt.Rows.Count == 0)
                    return;

                TempD = DateTime.Now;
                if (dt.Rows.Count == 0)
                {

                }
                else
                {
                    //if (pSetIsProceced == BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode())
                    UpdateSocketCheckDataAVL(db, JDataBase.DataTableToInt_64_Array(dt, "code")
                        , BusManagment.Transaction.SocketDataState.Bus_InProcess.GetHashCode());
                    //else
                    //if (pSetIsProceced == BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode())
                    //    UpdateSocketCheckDataAVL(db, JDataBase.DataTableToInt_64_Array(dt, "code")
                    //        , BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode());

                    DelayTime = (DateTime.Now - TempD).Milliseconds;
                    DelayMessageUpdate = "UpdateSocketCheckDataAVL:" + DelayTime;
                }
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        byte[] Bdata = (row["data"] as byte[]);
                        if (pSetIsProceced == BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode() && (Bdata.Length < 33 || Bdata[15] != 100 || !(Bdata[33] == 101 || Bdata[29] == 101)))
                        {
                            UpdateSocketCheckDataAVL(db, Convert.ToInt64(row["code"]), BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode()); // error
                        }
                        else
                        {
                            if (DateTime.Now.Hour <= 5)
                            {
                                MaxSleep = 150;
                            }
                            else
                            {
                                MaxSleep = 50;
                            }

                            TempD = DateTime.Now;
                            //if (pSetIsProceced == BusManagment.Transaction.SocketDataState.Bus_InList.GetHashCode())
                            //{
                            Tuple<JTransactionHeader, byte[]> P = Process(Bdata);
                            ProcessAvlData(P, Convert.ToInt64(row["code"]), true, true);
                            //}
                            //if (pSetIsProceced == BusManagment.Transaction.SocketDataState.Teltonika_InList.GetHashCode())
                            //{
                            //    ProceddTeltonika(Bdata, Convert.ToInt64(row["ID"]), Convert.ToInt64(row["code"]), Public);
                            //}
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                    catch (Exception ex)
                    {
                        UpdateSocketCheckDataAVL(db, Convert.ToInt64(row["code"]), BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                        ClassLibrary.JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                //db.Dispose();
            }
        }
        public void SocketCheckDataTeltonikaAVL(JDataBase db, bool Public, int pSetIsProceced)
        {
            string IsProceced = "IsProceced=" + pSetIsProceced;
            try
            {
                if (SocketCheckDataTeltonikaAVLThread > MaxSleep)
                    return;

                IsProcessTeltonika = 0;

                db.setQuery(@"select top " + (MaxSleep - SocketCheckDataTeltonikaAVLThread).ToString() + " * from [ClsSocketClientDataManager] where " + IsProceced + " order by Code desc");
                DataTable dt = db.Query_DataTable();

                if (dt == null || dt.Rows.Count == 0)
                    return;

                TempD = DateTime.Now;
                if (dt.Rows.Count == 0)
                {

                }
                else
                {
                    UpdateSocketCheckDataAVL(db, JDataBase.DataTableToInt_64_Array(dt, "code")
                        , BusManagment.Transaction.SocketDataState.Teltonika_InProcess.GetHashCode());

                    DelayTime = (DateTime.Now - TempD).Milliseconds;
                    DelayMessageUpdate = "UpdateSocketCheckDataAVL:" + DelayTime;
                }
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        byte[] Bdata = (row["data"] as byte[]);
                        if (DateTime.Now.Hour <= 5)
                        {
                            MaxSleep = 150;
                        }
                        else
                        {
                            MaxSleep = 50;
                        }

                        TempD = DateTime.Now;
                        ProceddTeltonika(Bdata, Convert.ToInt64(row["ID"]), Convert.ToInt64(row["code"]), Public);
                        System.Threading.Thread.Sleep(1);
                    }
                    catch (Exception ex)
                    {
                        UpdateSocketCheckDataAVL(db, Convert.ToInt64(row["code"]), BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode());
                        ClassLibrary.JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                //db.Dispose();
            }
        }

        struct BusAvlRecord
        {
            public Tuple<JTransactionHeader, byte[]> Data;
            public Int64 RecordNumber;
            public bool UpdateSocketTable;
        }

        struct BusAvlRecordList
        {
            public List<AVLStruct> Data;
            public Int64 RecordNumber;
            public bool UpdateSocketTable;
        }

        public static void ProcessAvlData(List<AVLStruct> result, Int64 pRecordNumber, bool pUpdateSocketTable, bool pThread)
        {

            BusAvlRecordList B = new BusAvlRecordList();
            if (result == null || result.Count == 0)
            {
                UpdateSocketCheckDataAVL(null, pRecordNumber, BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode()); //Error
                return;
            }

            B.Data = result;
            B.RecordNumber = pRecordNumber;
            B.UpdateSocketTable = pUpdateSocketTable;

            if (pThread)
            {
                try
                {
                    System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_ProcessAvlData));
                    N.Priority = System.Threading.ThreadPriority.Normal;
                    N.Start(B);
                }
                catch
                {

                }
            }
            else
            {
                _ProcessAvlData(B);
            }

        }
        public void ProcessAvlData(Tuple<JTransactionHeader, byte[]> result, Int64 pRecordNumber, bool pUpdateSocketTable, bool pThread)
        {

            BusAvlRecord B = new BusAvlRecord();
            if (result == null || result.Item1.AVLHeaders == null || result.Item1.AVLHeaders.Count() == 0)
            {
                UpdateSocketCheckDataAVL(null, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                return;
            }

            B.Data = result;
            B.RecordNumber = pRecordNumber;
            B.UpdateSocketTable = pUpdateSocketTable;

            if (pThread)
            {
                try
                {
                    System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_ProcessAvlData));
                    N.Priority = System.Threading.ThreadPriority.Normal;
                    N.Start(B);
                }
                catch
                {

                }
            }
            else
            {
                _ProcessAvlData(B);
            }

        }

        private static void _ProcessAvlData(Object pBusAvlRecord)
        {
            bool _UpdateSocketCheckDataAVL = false;
            Int64 pRecordNumber = 0;
            bool pUpdateSocketTable;
            Tuple<JTransactionHeader, byte[]> result = null;
            List<AVLStruct> resultList = null;

            if (pBusAvlRecord is BusAvlRecord)
            {
                pRecordNumber = ((BusAvlRecord)pBusAvlRecord).RecordNumber;
                pUpdateSocketTable = ((BusAvlRecord)pBusAvlRecord).UpdateSocketTable;
                result = ((BusAvlRecord)pBusAvlRecord).Data;
            }
            else
                if (pBusAvlRecord is BusAvlRecordList)
                {
                    pRecordNumber = ((BusAvlRecordList)pBusAvlRecord).RecordNumber;
                    pUpdateSocketTable = ((BusAvlRecordList)pBusAvlRecord).UpdateSocketTable;
                    resultList = ((BusAvlRecordList)pBusAvlRecord).Data;
                }

            JDataBase _DB = new JDataBase();
            try
            {
                Int64 recordNumber = pRecordNumber;
                DataTable DT = new DataTable("List");

                DT.Columns.Add("Longitude", typeof(System.Decimal));
                DT.Columns.Add("Latitude", typeof(System.Decimal));
                DT.Columns.Add("Altitude", typeof(System.Decimal));
                DT.Columns.Add("Speed", typeof(System.Int32));
                DT.Columns.Add("Course", typeof(System.Int16));
                DT.Columns.Add("EventDate", typeof(System.DateTime));
                DT.Columns.Add("SimCardCharge", typeof(System.Int32));
                DT.Columns.Add("BusSerial", typeof(System.Decimal));
                DT.Columns.Add("IMEI", typeof(System.Int64));
                DT.Columns.Add("Version", typeof(System.Byte[]));
                DT.Columns.Add("BatteryCharge", typeof(System.Int32));
                DT.Columns.Add("GpsAnt", typeof(System.Int16));
                DT.Columns.Add("GsmAnt", typeof(System.Int16));
                DT.Columns.Add("recordNumber", typeof(System.Int64));
                DT.Columns.Add("TransactionID", typeof(System.Int64));
                DT.Columns.Add("Dir", typeof(System.Int16));
                DT.Columns.Add("BusLine", typeof(System.Decimal));
                try
                {
                    if (result != null)
                    {
                        bool isSuccess = true;
                        foreach (var AH in result.Item1.AVLHeaders)
                        {
                            if (isSuccess == false)
                            {
                                break;
                            }

                            if (AH.AVLs != null && AH.AVLs.Count() > 0)
                            {
                                if (AH.busSerial > 9999 || AH.busSerial <= 0)
                                {
                                    if (!_UpdateSocketCheckDataAVL)
                                    {
                                        UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                                        _UpdateSocketCheckDataAVL = true;
                                    }
                                }
                                else
                                {
                                    DateTime date = AH.DATE;
                                    foreach (var AVL in AH.AVLs)
                                    {
                                        DateTime avlDate = new DateTime(date.Year, date.Month, date.Day, AVL.Time[0], AVL.Time[1], AVL.Time[2]);
                                        if (AVL.Speed < 255)
                                            DT.Rows.Add(new object[] { AVL.Lon, AVL.Lat, AVL.Alt, AVL.Speed, AVL.Cource, avlDate, AH.SimCharge, AH.busSerial, result.Item1.IMEI, result.Item1.VERSION, AH.Battryvoltvalue, AH.GpsAnttena, AH.GsmAnttena, recordNumber, AVL.transactionid, AVL.Dir, AH.busLine });
                                        else
                                        {
                                            System.Threading.Thread.Sleep(10);
                                        }
                                    }
                                }
                            }
                        }
                        isSuccess = BusManagment.AVL.JAVLTransactions.AddAVL(ref DT, "update ClsSocketClientDataManager set IsProceced=0 where code = " + pRecordNumber);
                        if (isSuccess == false)
                        {
                            {
                                if (!_UpdateSocketCheckDataAVL)
                                {
                                    UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode());
                                    _UpdateSocketCheckDataAVL = true;
                                }
                            }
                        }
                        else
                        {
                            if (!_UpdateSocketCheckDataAVL)
                            {
                                UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_SuccessProcess.GetHashCode());
                                _UpdateSocketCheckDataAVL = true;
                            }

                        }
                    } // if
                }
                catch (Exception ex)
                {
                    if (!_UpdateSocketCheckDataAVL)
                    {
                        UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode()); // Error
                        _UpdateSocketCheckDataAVL = true;
                    }
                    JSystem.Except.AddException(ex);
                }
                try
                {
                    if (resultList != null)
                    {
                        bool isSuccess = true;
                        foreach (AVLStruct AH in resultList)
                        {
                            if (isSuccess == false)
                            {
                                break;
                            }

                            if (AH.IMEI > 0)
                            {
                                if (AH.Lat <= 0 || AH.Lon <= 0)
                                {
                                    if (!_UpdateSocketCheckDataAVL)
                                    {
                                        UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode());//error
                                        _UpdateSocketCheckDataAVL = true;
                                    }
                                }
                                else
                                {
                                    DateTime avlDate = AH.DateSend;
                                    if (AH.Speed < 255)
                                    {
                                        //DT.Rows.Add(new object[] { AVL.Lon, AVL.Lat, AVL.Alt, AVL.Speed, AVL.Cource, avlDate, AH.SimCharge, AH.busSerial, result.Item1.IMEI, result.Item1.VERSION, AH.Battryvoltvalue, AH.GpsAnttena, AH.GsmAnttena, recordNumber, AVL.transactionid, AVL.Dir, AH.busLine });
                                        DT.Rows.Add(new object[] { AH.Lon, AH.Lat, AH.Alt, AH.Speed, AH.Course, avlDate, AH.ChargeSIMCard, 0, AH.IMEI, new byte[] { 11, 11, 11 }, AH.BattryCharge, AH.GpsAnt, AH.GsmAnt, recordNumber, 0, 0, 0 });
                                    }
                                    else
                                    {
                                        System.Threading.Thread.Sleep(10);
                                    }
                                }
                            }
                        }
                        isSuccess = BusManagment.AVL.JAVLTransactions.AddAVL(ref DT, "update ClsSocketClientDataManager set IsProceced=10 where code = " + pRecordNumber);
                        if (isSuccess == false)
                        {
                            {
                                if (!_UpdateSocketCheckDataAVL)
                                {
                                    UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode()); // Error
                                    _UpdateSocketCheckDataAVL = true;
                                }
                            }
                        }
                        else
                        {
                            if (!_UpdateSocketCheckDataAVL)
                            {
                                UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Teltonika_SuccessProcess.GetHashCode()); // Success
                                _UpdateSocketCheckDataAVL = true;
                            }

                        }
                    } // if
                }
                catch (Exception ex)
                {
                    if (!_UpdateSocketCheckDataAVL)
                    {
                        UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Teltonika_ErrorProcess.GetHashCode()); // Error
                        _UpdateSocketCheckDataAVL = true;
                    }
                    JSystem.Except.AddException(ex);
                }
            }
            catch (Exception ex)
            {
                //if (!_UpdateSocketCheckDataAVL)
                //{
                //    UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode()); // Error
                //    _UpdateSocketCheckDataAVL = true;
                //}
                //JSystem.Except.AddException(ex);
                //return;
            }
            finally
            {
                //if (!_UpdateSocketCheckDataAVL)
                //{
                //    UpdateSocketCheckDataAVL(_DB, pRecordNumber, BusManagment.Transaction.SocketDataState.Bus_ErrorProcess.GetHashCode()); // Error
                //    _UpdateSocketCheckDataAVL = true;
                //}
                _DB.Dispose();
            }
        }


        public void CheckMySQLDataAVL()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                // AVL Info
                mysqlDB.setQuery("SELECT * FROM avlinfo_bin ORDER BY `ReciveDate` DESC LIMIT 0 , 20");
                DataTable dt = mysqlDB.Query_DataTable();
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        //db.beginTransaction("avl");
                        Tuple<JTransactionHeader, byte[]> result = Process(row["data"] as byte[]);
                        bool isSuccess = true;
                        Int64 recordNumber = Convert.ToInt64(row["recordNumber"]);
                        if (result.Item1.ErrorNum == 0)
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
                                            if (isSuccess) isSuccess = BusManagment.AVL.JAVLTransactions.AddAVL(AH, AVL, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db, "");
                                            if (isSuccess == false)
                                            {
                                                ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save AVL:" +
                                                    AVL.transactionid.ToString() + " " +
                                                    AH.busSerial.ToString() + " " +
                                                    AH.DATE.ToString() +
                                                    " date:" + AH.DATE.Year + "-" + AH.DATE.Month + "-" + AH.DATE.Day + " " + AVL.Time[0] + ":" + AVL.Time[1] + ":" + AVL.Time[2] +
                                                    " Longitude " + AVL.Lon +
                                                    " Latitude " + AVL.Lat +
                                                    " Altitude" + AVL.Alt.ToString() +
                                                    " Speed" + AVL.Speed.ToString() +
                                                    " Course" + AVL.Cource.ToString() +
                                                    " EventDate" + date +
                                                    " SimCardCharge" + AH.SimCharge.ToString() +
                                                    " BusSerial" + AH.busSerial.ToString() +
                                                    " IMEI" + result.Item1.IMEI.ToString() +
                                                    " Version" + result.Item1.VERSION +
                                                    " BatteryCharge" + AH.Battryvoltvalue.ToString() +
                                                    " GpsAnt" + AH.GpsAnttena.ToString() +
                                                    " GsmAnt" + AH.GsmAnttena.ToString() +
                                                    " recordNumber" + recordNumber.ToString() +
                                                    " TransactionID" + AVL.transactionid.ToString() +
                                                    " Dir" + AVL.Dir.ToString() +
                                                    " BusLine" + AH.busLine.ToString()
                                                    ));
                                                //break;
                                            }
                                        }
                                    }
                                }
                        if (isSuccess)
                        {
                            if (Transaction.JDeviceDB.MoveAVLRecord(row, result.Item1.Error, result.Item1.ErrorNum) == true)
                            {
                                db.Commit();
                                //Transaction.JDeviceDB.SendToOldDatabase(result.Item2);
                            }
                            //else
                            //db.Rollback("avl");
                        }
                        //else
                        //db.Rollback("avl");
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
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
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                mysqlDB.Dispose();
                db.Dispose();
            }
        }




        //public void CheckData2()
        //{
        //    ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
        //    try
        //    {
        //        // Card Info
        //        mysqlDB.setQuery("Select * from cardinfo_bin_log");
        //        DataTable dt = mysqlDB.Query_DataTable();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //            try
        //            {
        //                //db.beginTransaction("card");
        //                Tuple<JTransactionHeader, byte[]> result = Process(row["data"] as byte[]);
        //                bool isSuccess = true;
        //                Int64 recordNumber = Convert.ToInt64(row["recordNumber"]);
        //                if (result.Item1.ErrorNum == 0)
        //                    if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
        //                        foreach (var TH in result.Item1.TicketHeaders)
        //                        {
        //                            if (isSuccess == false) break;

        //                            if (TH.Tickets != null && TH.Tickets.Count() > 0)
        //                            {
        //                                DateTime date = TH.DATE;
        //                                foreach (var Ticket in TH.Tickets)
        //                                {
        //                                    // We've got new Ticket ;)
        //                                    DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

        //                                    if (isSuccess) isSuccess = Transaction.JTicketTransactions.AddTicketTransaction2(TH, Ticket, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db);
        //                                    if (isSuccess == false) break;
        //                                }
        //                            }
        //                        }
        //                //if (isSuccess)
        //                //{
        //                //    if (Transaction.JDeviceDB.MoveTicketRecord(row, result.Item1.Error, result.Item1.ErrorNum) == true)
        //                //    {
        //                //        db.Commit();
        //                //        Transaction.JDeviceDB.SendToOldDatabase(result.Item2);
        //                //    }
        //                //    else
        //                //        db.Rollback("card");

        //                // Insert to Old Database
        //                //}
        //                //else
        //                //    db.Rollback("card");
        //            }
        //            finally
        //            {
        //                db.Dispose();
        //            }

        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        mysqlDB.Dispose();
        //    }
        //}

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

                //int i = 0;
                //if(year > 2050)
                //{
                //    i++;
                //}

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

                byte[] bMinute = new byte[1];
                Buffer.BlockCopy(data, 1, bMinute, 0, 1);
                int minute = bMinute.Select(m => Convert.ToInt32(m)).First();

                byte[] bSecond = new byte[1];
                Buffer.BlockCopy(data, 2, bSecond, 0, 1);
                int second = bSecond.Select(m => Convert.ToInt32(m)).First();

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
        public static float ConvertNMEAToDecimal(double d)
        {
            float ret = 0;
            string[] str = d.ToString().Split(new char[] { '.', '/' });
            try
            {
                int Houre = int.Parse(str[0].Substring(0, 2));
                int Minute = int.Parse(str[0].Substring(2, 2));
                int Secound = int.Parse(str[1].Substring(0, 2)) * 60 / 100;
                ret = (float)(Houre + Minute / 60.0 + Secound / 3600.0);
            }
            catch
            {
            }
            return ret;
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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CityBankOutPUTFile(String BankType, DateTime StartDate, DateTime Enddate)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM[dbo].[AUTTicketTransaction_CityBank_Protocol_Binary] ('" + BankType + "','"
                    + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                    + Enddate.ToString("yyyy-MM-dd HH:mm:ss") + "') order by 1");
                DB.CommandTimeout = 500000;
                DataTable DT = DB.Query_DataTable();

                if (DT.Rows.Count > 1)
                {
                    string[] SB = new string[DT.Rows.Count];
                    int Count = 0;
                    while (Count < DT.Rows.Count)
                    {
                        SB[Count] = DT.Rows[Count][0].ToString().Trim();
                        Count++;
                    }

                    Count = 0;
                    string NewFileName = "";
                    do
                    {
                       Count =  Count+2;
                        NewFileName = ClassLibrary.JConfig.appPath + "\\CityBankFiles\\"
                            + DateTime.Now.ToString("yyyyMMdd").Substring(2, 6) + Count.ToString("D2") + ".csf";
                    }
                    while (System.IO.File.Exists(NewFileName));

                    Count = 0;
                    foreach (string S in SB)
                    {
                        System.IO.File.AppendAllText(NewFileName, S + (Count + 1 < SB.Length ? Environment.NewLine : ""));
                        Count++;
                    }
                    try
                    {

                        SftpClient client = new SftpClient("5.160.217.218", "tcco", "ticiCIow#%!^$");
                        client.Connect();

                        using (var fileStream = new FileStream(NewFileName, FileMode.Open))
                        {
                            client.UploadFile(fileStream, Path.GetFileName(NewFileName));

                        }
                        client.Disconnect();

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            finally
            {
                DB.Dispose();
            }


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