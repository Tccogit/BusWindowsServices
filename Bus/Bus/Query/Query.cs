using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Query
{

    public class JQuery : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string QueryText { get; set; }

        public JQuery()
        {
        }
        public JQuery(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Query.JQuery.Insert"))
                return 0;
            QueryTable AT = new QueryTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JQuery", Code, 0, 0, 0, "ثبت دستور", "", 0);
            return Code;
        }

        public bool Update()
        {
            if (!JPermission.CheckPermission("BusManagment.Query.JQuery.Update"))
                return false;
            QueryTable AT = new QueryTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JQuery", AT.Code, 0, 0, 0, "ویرایش دستور", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.Query.JQuery.Delete"))
                return false;
            QueryTable AT = new QueryTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JQuery", AT.Code, 0, 0, 0, "حذف دستور", "", 0);
                return true;
            }
            else return false;
        }

        public int FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select code from AUTConsoleQuery where Name = '" + this.Name + "'");
                DataTable dt = DB.Query_DataTable();
                if (dt != null && dt.Rows.Count>0)
                    return Convert.ToInt32(dt.Rows[0]["code"]);
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
                DB.setQuery("select * from AUTConsoleQuery where code=" + pCode.ToString());
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


    public class JQueries : JSystem
    {

        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = BusManagment.Query.JQueries.GetWebQuery();
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery() 
        {
            return "select Code, Name from AUTConsoleQuery";
        }

    }
}
