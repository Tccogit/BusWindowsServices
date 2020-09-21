using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusManagment.Transaction
{
    public struct TicketReader
    {
        public byte BIN_LTB;
        public UInt32 TerminalID;
        public DateTime DateTime;
        public UInt16 Price;
        public UInt32 BusID;
        public byte Type;
        public byte WaletID;
        public UInt32 LTD_SeverCID;
        public UInt32 RemaningPrice;
        public UInt64 ServerMAC;
        public UInt64 M_O;
        public UInt64 PassengerID;
        public UInt64 DriverID;
        public UInt32 LineNumber;
        public byte CardType;
        public byte ReaderID;
        public byte BankType;
    }

    public class ExtractOfflineReaderFile
    {
        public ExtractOfflineReaderFile()
        {

        }
        public byte[] fileData;

        private static int CountOccurences(byte[] target, byte[] pattern)
        {
            var targetString = BitConverter.ToString(target);
            var patternString = BitConverter.ToString(pattern);
            return new Regex(patternString).Matches(targetString).Count;
        }
        public bool HasBinaryContent()
        {
            return CountOccurences(fileData, new byte[] { 32 }) * 4 < fileData.Length;
        }
        public List<TicketReader> ReadData()
        {
            if (HasBinaryContent())
            {
                return ReadDataBinary();
            }
            List<TicketReader> Transaction = new List<TicketReader>();
            if (fileData == null || fileData.Length == 0)
                return Transaction;

            byte[] TempBuff = new byte[50000000];
            byte BuffCounter = 0;

            for (int i = 0; i < fileData.Length; i += 3)
            {
                byte[] ConvertedByte;
                try
                {
                    ConvertedByte = StringToByteArray(Convert.ToChar(fileData[i]) + Convert.ToChar(fileData[i + 1]).ToString());
                    TempBuff[BuffCounter] = ConvertedByte[0];
                }
                catch { }
                try
                {
                    if (BuffCounter >= 2 && TempBuff[BuffCounter] == 30 && TempBuff[BuffCounter - 1] == 30 && TempBuff[BuffCounter - 2] == 30)
                    {
                        if (BuffCounter >= 66)
                        {
                            if (BuffCounter > 66)
                            {

                            }
                            byte[] buffer = new byte[64];
                            for (int k = BuffCounter - 66; k < BuffCounter - 2; k++)
                            {
                                try
                                {
                                    buffer[k - (BuffCounter - 66)] = TempBuff[k];
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            TicketReader _Ticket;
                            if (GetTicket(buffer, out _Ticket))
                            {
                                Transaction.Add(_Ticket);
                                BuffCounter = 0;
                            }
                            else
                            {
                                BuffCounter = 0;
                            }
                        }
                    }
                    else
                        BuffCounter++;
                }
                catch (Exception ex)
                {

                }
            }
            return Transaction;
        }

        public List<TicketReader> ReadDataBinary()
        {
            List<TicketReader> Transaction = new List<TicketReader>();
            if (fileData == null || fileData.Length == 0)
                return Transaction;

            byte[] TempBuff = new byte[50000000];
            byte BuffCounter = 0;

            for (int i = 0; i < fileData.Length; i++)
            {
                try
                {
                    TempBuff[BuffCounter] = fileData[i];
                }
                catch { }
                try
                {
                    if (BuffCounter >= 2 && TempBuff[BuffCounter] == 30 && TempBuff[BuffCounter - 1] == 30 && TempBuff[BuffCounter - 2] == 30)
                    {
                        if (BuffCounter >= 66)
                        {
                            if (BuffCounter > 66)
                            {

                            }
                            byte[] buffer = new byte[64];
                            for (int k = BuffCounter - 66; k < BuffCounter - 2; k++)
                            {
                                try
                                {
                                    buffer[k - (BuffCounter - 66)] = TempBuff[k];
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            TicketReader _Ticket;
                            if (GetTicket(buffer, out _Ticket))
                            {
                                Transaction.Add(_Ticket);
                                BuffCounter = 0;
                            }
                            else
                            {
                                BuffCounter = 0;
                            }
                        }
                    }
                    else
                        BuffCounter++;
                }
                catch (Exception ex)
                {

                }
            }
            return Transaction;
        }
        public void ReadAllBytes(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
        }

        public static byte[] StringToByteArray(string hex)
        {

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public bool GetTicket(byte[] pBufferDate, out TicketReader pTicket)
        {
            TicketReader _Ticket = new TicketReader();
            pTicket = _Ticket;
            try
            {
                byte[] b4 = new byte[4];
                byte[] b8 = new byte[8];

                byte[] b2 = new byte[2];

                int tCounter = 1;

                _Ticket.BIN_LTB = pBufferDate[0];
                for (int i = 0; i < 4; i++)
                    b4[3 - i] = pBufferDate[i + tCounter];
                _Ticket.TerminalID = BitConverter.ToUInt32(b4, 0);
                tCounter += 4;
                for (int i = 0; i < 4; i++)
                    b4[3 - i] = pBufferDate[i + tCounter];
                _Ticket.DateTime = ExtractDateTime((UInt32)BitConverter.ToInt32(b4, 0));
                tCounter += 4;
                for (int i = 0; i < 2; i++)
                    b2[1 - i] = pBufferDate[i + tCounter];
                _Ticket.Price = BitConverter.ToUInt16(b2, 0);

                tCounter += 2;
                for (int i = 0; i < 3; i++)
                    b4[2 - i] = pBufferDate[i + tCounter];
                b4[3] = 0;
                _Ticket.BusID = BitConverter.ToUInt32(b4, 0);

                tCounter += 3;
                _Ticket.WaletID = pBufferDate[tCounter];

                tCounter += 1;
                _Ticket.Type = pBufferDate[tCounter];

                tCounter += 1;
                for (int i = 0; i < 4; i++)
                    b4[3 - i] = pBufferDate[i + tCounter];
                _Ticket.LTD_SeverCID = BitConverter.ToUInt32(b4, 0);

                tCounter += 4;
                for (int i = 0; i < 4; i++)
                    b4[3 - i] = pBufferDate[i + tCounter];
                _Ticket.RemaningPrice = BitConverter.ToUInt32(b4, 0);

                tCounter += 4;
                for (int i = 0; i < 8; i++)
                    b8[7 - i] = pBufferDate[i + tCounter];
                _Ticket.ServerMAC = BitConverter.ToUInt64(b8, 0);

                tCounter += 8;
                for (int i = 0; i < 8; i++)
                    b8[7 - i] = pBufferDate[i + tCounter];
                _Ticket.M_O = BitConverter.ToUInt64(b8, 0);

                tCounter += 8;
                for (int i = 0; i < 8; i++)
                    b8[7 - i] = pBufferDate[i + tCounter];
                _Ticket.PassengerID = BitConverter.ToUInt64(b8, 0);

                tCounter += 8;
                for (int i = 0; i < 4; i++)
                    b4[3 - i] = pBufferDate[i + tCounter];
                _Ticket.DriverID = BitConverter.ToUInt32(b4, 0);

                tCounter += 8;
                for (int i = 0; i < 3; i++)
                    b4[2 - i] = pBufferDate[i + tCounter];
                b4[3] = 0;
                _Ticket.LineNumber = BitConverter.ToUInt32(b4, 0);

                tCounter += 3;
                for (int i = 0; i < 2; i++)
                    b2[1 - i] = pBufferDate[i + tCounter];
                int tempcardbank = BitConverter.ToInt16(b2, 0);
                if ((tempcardbank > 255 && tempcardbank < 266) || tempcardbank == 512 || tempcardbank == 768)
                {
                    _Ticket.CardType = b2[0];
                    _Ticket.BankType = b2[1];
                }
                else
                {
                    _Ticket.CardType = b2[1];
                    _Ticket.BankType = b2[0];
                }
                tCounter += 2;
                _Ticket.ReaderID = pBufferDate[tCounter];

                pTicket = _Ticket;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public DateTime ExtractDateTime(UInt32 RecDateTime)
        {
            UInt32 temp = 0;
            temp = (byte)(RecDateTime & 0x0000003F); //second:6

            byte Second = (byte)temp;

            temp = (RecDateTime & 0x00000FC0); //minute:6

            byte Minute = (byte)(temp >> 6);

            temp = (RecDateTime & 0x0001F000); //hour:5

            byte Hour = (byte)(temp >> 12);

            temp = (RecDateTime & 0x003E0000); //day:5

            byte Day = (byte)(temp >> 17);

            temp = (RecDateTime & 0x03C00000); //month:4

            byte Month = (byte)(temp >> 22);

            temp = (RecDateTime & 0xFC000000); //year:6

            byte Year = (byte)(temp >> 26);

            return DateTime.Parse(2000 + Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second);
        }
    }
}
