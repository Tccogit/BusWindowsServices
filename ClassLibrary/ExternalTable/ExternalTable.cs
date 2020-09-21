using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JExternalTable
    {
        public int Code { get; set; }
        public int ExternalCode { get; set; }
        public string ExternalTableName { get; set; }

        public JExternalTable()
        {
        }

        public void Insert()
        {
            string SQL = @"SELECT * FROM ExternalTables WHERE ExternalCode = %ExternalCode%  
                    AND ExternalTableName = %ExternalTableName%  ";
            SQL = SQL.Replace("%Code%", Code.ToString());
            SQL = SQL.Replace("%ExternalCode%", ExternalCode.ToString());
            SQL = SQL.Replace("%ExternalTableName%", JDataBase.Quote(ExternalTableName));
            
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(SQL);
            DB.Query_DataReader();
            if (DB.DataReader.HasRows)
                return;
            
            SQL = "INSERT INTO ExternalTables VALUES(%Code%,%ExternalCode%,%ExternalTableName%)";
            SQL = SQL.Replace("%Code%", Code.ToString());
            SQL = SQL.Replace("%ExternalCode%", ExternalCode.ToString());
            SQL = SQL.Replace("%ExternalTableName%", JDataBase.Quote(ExternalTableName));

            //JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(SQL);
            DB.Query_Execute();
        }
        public bool Exists(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM ExternalTables WHERE ExternalCode = " + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.HasRows)
                    return true;
                return false;
            }
            finally
            {
                DB.Dispose();
            }

        }
        /// <summary>
        /// کد فرعی در جدول خارجی را برمیگرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static int GetExternalCode(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT  ExternalCode FROM ExternalTables WHERE Code = " + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                    return Convert.ToInt32(DB.DataReader[0]);
                else return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }
}
