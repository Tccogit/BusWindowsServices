using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.Line
{
    public class JLineDailyTransactionCount : JSystem
    {
        #region Properties
        public int Code { get; set; }
        public int LineCode { get; set; }
        public int TransactionCount { get; set; }
        #endregion

        public int Insert(bool isWeb = false)
        {
            JLineDailyTransactionCountTable AT = new JLineDailyTransactionCountTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JLines.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JLineDailyTransactionCount", Code, 0, 0, 0, "ثبت متوسط درآمد خطوط", "", 0);
            return Code;
        }

        public JLineDailyTransactionCount()
        {
        }
        public JLineDailyTransactionCount(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public JLineDailyTransactionCount(string pLineNumber)
        {
            if (pLineNumber.Length > 0)
                this.GetData(pLineNumber);
        }
        public bool Update(bool isWeb = false)
        {
            JDataBase DB = new JDataBase();
            DB.setQuery(@"update AUTDailyLineTransactionCount set TransactionCount = " + TransactionCount + " where LineCode = " + LineCode);
            if (DB.Query_Execute() >= 0)
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JLineDailyTransactionCount", LineCode, 0, 0, 0, "ویرایش متوسط درآمد خطوط", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            JLineDailyTransactionCountTable AT = new JLineDailyTransactionCountTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JLineDailyTransactionCount", AT.Code, 0, 0, 0, "حذف متوسط درآمد خطوط", "", 0);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDailyLineTransactionCount where code=" + pCode.ToString());
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
        public bool GetDataByLine(int pLineCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDailyLineTransactionCount where LineCode = " + pLineCode.ToString());
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
        public bool GetData(string pLineNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AUTDailyLineTransactionCount where LineCode=" + pLineNumber + " order by Code desc");
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
    public class JLineDailyTransactionCounts
    {
        public static bool HasLineCode(string LineCode)
        {
            JDataBase DB = new JDataBase();
            DB.setQuery("select * from AUTDailyLineTransactionCount where LineCode=" + LineCode);
            DataTable Dt = DB.Query_DataTable();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; };
        }
        public static string GetWebQuery()
        {
            return @"select a.Code,LineCode,b.LineNumber,TransactionCount,InsertDate from AUTDailyLineTransactionCount a left join AUTLine b on a.LineCode = b.Code";
        }
    }
}
