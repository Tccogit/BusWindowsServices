using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Transaction
{
    public class JDeviceDB
    {
        public static bool MoveAVLRecord(DataRow row, string error, int errorNumber)
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                mysqlDB.setQuery("Insert into avlinfo_bin_log(recordNumber,data,error,errNumber) Select recordNumber, data, '" + error + "' as error, '" + errorNumber + "' as errNumber from avlinfo_bin where recordNumber=" + row["recordNumber"].ToString());
                if (mysqlDB.Query_Execute() >= 0)
                {
                    mysqlDB.setQuery("delete from avlinfo_bin where recordNumber = '" + row["recordNumber"].ToString() + "'");
                    if (mysqlDB.Query_Execute() >= 0) return true;
                    return false;
                }
            }
            finally
            {
                mysqlDB.Dispose();
            }
            return false;
        }

		public static bool MoveTicketRecord(DataRowCollection rows, string error, int errorNumber, ClassLibrary.JMySQLDataBase mysqlDB)
		{
			string[] Row = new string[rows.Count];
			for (int i = 0; i < rows.Count; i++)
			{
				Row[i] = rows[i]["Code"].ToString();
			}
			try
			{
				mysqlDB.setQuery("Insert into cardinfo_bin_temp_log(code,recordNumber,data,error,errNumber,TryCount) Select code,recordNumber, data, '" +
					error +
					"' as error, '" + errorNumber +
                    "' as errNumber,TryCount from cardinfo_bin where Code in (" + String.Join(",", Row) + ")");
				if (mysqlDB.Query_Execute() >= 0)
				{
					mysqlDB.setQuery("delete from cardinfo_bin where Code in (" + String.Join(",", Row) + ")");
					if (mysqlDB.Query_Execute() >= 0) return true;
					return false;
				}
			}
			finally
			{
				//mysqlDB.Dispose();
			}
			return false;
		}

        public static bool MoveTicketRecord(Int64 Row, string error, int errorNumber)
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                mysqlDB.setQuery("Insert into cardinfo_bin_log(code,recordNumber,data,error,errNumber) Select code,recordNumber, data, '" +
                    error +
                    "' as error, '" + errorNumber +
                    "' as errNumber from cardinfo_bin_temp_log where Code in (" + Row + ")");
                mysqlDB.Query_Execute();

                mysqlDB.setQuery("delete from cardinfo_bin_temp_log where Code in (" + Row + ")");
                mysqlDB.Query_Execute();
                return true;

            }
            finally
            {
                mysqlDB.Dispose();
            }
            return false;
        }

        public static bool UpdateAndMoveTicketRecordWithError(Int64 Row)
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                mysqlDB.setQuery("Update cardinfo_bin_temp_log set TryCount = TryCount + 1 where Code in (" + Row + ")");
                mysqlDB.Query_Execute();

                mysqlDB.setQuery("Insert into cardinfo_bin_log(code,recordNumber,data,error,errNumber) Select code,recordNumber, data, error,errNumber from cardinfo_bin_temp_log where TryCount >= 3");
                mysqlDB.Query_Execute();

                mysqlDB.setQuery("delete from cardinfo_bin_temp_log where TryCount >= 3");
                mysqlDB.Query_Execute();

                mysqlDB.setQuery(@"
                        insert into cardinfo_bin
	                        select Code,recordNumber,`data`,TryCount from cardinfo_bin_temp_log where
		                        code not in (select code from cardinfo_bin) and TryCount > 0;
                        delete from cardinfo_bin_temp_log where TryCount > 0;
                        ");
                mysqlDB.Query_Execute();

                return true;

            }
            finally
            {
                mysqlDB.Dispose();
            }
            return false;
        }

        public static bool SendToOldDatabase(byte[] pData)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder constr = new System.Data.SqlClient.SqlConnectionStringBuilder();
            constr.DataSource = ".";
            constr.InitialCatalog = "BusAvlSendLogs";
            constr.UserID = "sa";
            constr.Password = "TcCoAvlServer1392";
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(constr);
            try
            {
                db.setQuery("Insert into SendLogs(SendLog) VALUES(@SendLog)");
                db.AddParams("SendLog", pData);
                if (db.Query_Execute() >= 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
