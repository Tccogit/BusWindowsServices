using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// انتقال اطلاعات از یک دیتا بیس به دیتا بیس دیگر
    /// </summary>
    public class JTransfer: JCore
    {
        private JConfig _OtherDB;

        public JTransfer(JConfig pOtherDB)
        {
            _OtherDB = pOtherDB;
        }

        public void Transfer(string pFromSQL,string pTableName, string pFieldsName)
        {
            string InsertSQL="";
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JDataBase OtherDB =new JDataBase(_OtherDB);
            OtherDB.setQuery(pFromSQL);
            OtherDB.Query_DataReader();
            if (OtherDB.DataReader.HasRows)
            {
                string[] Fields = pFieldsName.Split(',');
                while (OtherDB.DataReader.Read())
                {
                    string Values = "";
                    string Sep = "";
                    for (int i = 0; i < OtherDB.DataReader.FieldCount - 1; i++)
                    {
                        Values += Sep + OtherDB.DataReader[i].ToString();
                        Sep = ",";
                    }
                    InsertSQL += "INSERT INTO " + pTableName + "(" + pFieldsName + ") VALUES(" + Values + ");"+(char)13;
                }
                DB.setQuery(InsertSQL);
                DB.Query_Execute();
            }

        }
    }
}
