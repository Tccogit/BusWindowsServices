using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.CardBlackList
{
    public class JCardBlackList : JSystem
    {
        public int Code { get; set; }
        public Int64 RfidNumber { get; set; }

        public JCardBlackList()
        {
        }
        public JCardBlackList(int pCode)
        {
            this.GetData(pCode);
        }

        public int Insert()
        {
            if (!JPermission.CheckPermission("BusManagment.CardBlackList.JCardBlackList.Insert"))
                return 0;
            CardBlackListTable AT = new CardBlackListTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JCardBlackList", Code, 0, 0, 0, "ثبت در لیست سیاه کارت مسافر", "", 0);
            return Code;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.CardBlackList.JCardBlackList.Delete"))
                return false;
            CardBlackListTable AT = new CardBlackListTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JCardBlackList", AT.Code, 0, 0, 0, "حذف از لیست سیاه کارت مسافر", "", 0);
            return AT.Delete();
        }

        public int FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select code from AUTCardBlackList where RfidNumber = " + this.RfidNumber);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                    return Convert.ToInt32(DB.DataReader["code"]);
                else
                    return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTCardBlackList where code=" + pCode.ToString());
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

    public class JCardBlackLists : JSystem
    {
        public static string GetWebQuery()
        {
            return "select * from AUTCardBlackList";
        }
    }
}
