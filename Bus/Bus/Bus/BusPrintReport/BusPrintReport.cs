using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusPrintReport
    {

        public int Code { get; set; }
        public int BusNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public int TicketSent { get; set; }
        public int State { get; set; }
        public int DailyCode { get; set; }
        public int ShiftDriverCode { get; set; }

        public JBusPrintReport()
        {
        }
        public JBusPrintReport(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {


			if (GetDailyData(BusNumber, StartDate, EndDate))
			{
				State = 0;
				Update();
				return Code;
			}
			else
			{
				JBusPrintReportTable AT = new JBusPrintReportTable();
				AT.SetValueProperty(this);
				if (db == null)
					Code = AT.Insert();
				else
					Code = AT.Insert(db);
				ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
				// jHistory.Save("BusManagment.JBusPrintReport", Code, 0, 0, 0, "ثبت پرینت اتوبوس", "", 0);

				return Code;
			}
        }
        public bool Delete()
        {
            JBusPrintReportTable AT = new JBusPrintReportTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
          //  jHistory.Save("BusManagment.JBusPrintReport", AT.Code, 0, 0, 0, "حذف پرینت اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusPrintReportTable AT = new JBusPrintReportTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
        //    jHistory.Save("BusManagment.JBusPrintReport", AT.Code, 0, 0, 0, "ویرایش پرینت اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrinterRporte where code=" + pCode.ToString());
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

        public bool GetDailyData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrinterRporte where dailyCode=" + pCode.ToString());
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

        public bool GetDailyData(int BusNumber, DateTime StartDate, DateTime EndDate)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrinterRporte where BusNumber = " + BusNumber.ToString() + " And StartDate = '" + StartDate.ToString() + "' and EndDate = '" + EndDate.ToString() + "'");
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




        public bool GetShiftDriverData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrinterRporte where ShiftDriverCode=" + pCode.ToString());
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

        public bool GetShiftDriverData(int BusNumber, DateTime StartDate, DateTime EndDate)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrinterRporte where BusNumber = " + BusNumber.ToString() + " And StartDate = '" + StartDate.ToString() + "' and EndDate = '" + EndDate.ToString() + "'");
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




    public class JBusPrintReports
    {

		public static string GetDailyPrintReportWithState(int busNumber,string date,string state)
		{
			return string.Format(@"
SELECT [Code]
	  ,[BusNumber]
      ,[StartDate]
      ,[EndDate]
      ,[TicketCount]
      ,[TicketSent]
      ,(case when [State]=1 then N'پاسخ دریافت شده' else N'بدون پاسخ' end) as State
  FROM [dbo].[AUTPrinterRporte] where (StartDate between '{0} 00:00:00' and '{0} 23:59:59') and  DailyCode<1 and ShiftDriverCode=0 and BusNumber={1} and [State]={2}", date,busNumber,state);
		}
        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTPrinterRporte  WHERE BusCode = " + pBusCode.ToString());
            DB.Query_Execute();
        }


        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select * from AUTPrinterRporte order by code");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
