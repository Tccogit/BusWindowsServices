using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusTransactionPrint
    {  

        public int Code { get; set; }
        public int BusCode { get; set; }
        public int PersonCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ReportDate { get; set; }
        public int TransactionCount { get; set; }
        public Int64 Income { get; set; }

        public JBusTransactionPrint()
        {
        }
        public JBusTransactionPrint(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JBusTransactionPrintTable AT = new JBusTransactionPrintTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            return Code;
        }
        public bool Delete()
        {
            JBusTransactionPrintTable AT = new JBusTransactionPrintTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusTransactionPrintTable AT = new JBusTransactionPrintTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusTransactionPrint where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

    public class JBusTransactionPrints
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTBusTransactionPrint  WHERE BusCode = " + pBusCode.ToString());
            DB.Query_Execute();
        }

        public static DataTable GetDataTable(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT abtp.Code,ab.BUSNumber,clsp.Name AS PersonName,abtp.FromDate,
                                abtp.ToDate,abtp.ReportDate,abtp.TransactionCount,abtp.Income
                                ,abtp.InsertDate
                                FROM [dbo].[AUTBusTransactionPrint] abtp
                                LEFT JOIN AUTBus ab ON abtp.BusCode = ab.Code
                                LEFT JOIN clsAllPerson clsp ON clsp.Code = abtp.PersonCode
                        WHERE abtp.BusCode=" + pBusCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"SELECT abtp.Code,ab.BUSNumber,clsp.Name AS PersonName,abtp.FromDate,
                                abtp.ToDate,abtp.ReportDate,abtp.TransactionCount TransactionCountConsole,abtp.Income IncomeConsole
								,(select sum(TCount) from AUTDailyPerformanceRportOnBus where BusCode = abtp.BusCode and CardType = 0
								and [Date] between cast(abtp.FromDate as date) and cast(abtp.ToDate as date))TransactionCountDataBase
								,(select sum(Price) from AUTDailyPerformanceRportOnBus where BusCode = abtp.BusCode  and CardType = 0
								and [Date] between cast(abtp.FromDate as date) and cast(abtp.ToDate as date))PriceDataBase
								,abtp.InsertDate
                                FROM [dbo].[AUTBusTransactionPrint] abtp
                                LEFT JOIN AUTBus ab ON abtp.BusCode = ab.Code
                                LEFT JOIN clsAllPerson clsp ON clsp.Code = abtp.PersonCode";
        }
    }
}
