using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Query
{

    public class JQueryAutoAuto : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string QueryText { get; set; }

        public string DataBaseName { get; set; }
        public int LineNumber { get; set; }
        public int BusCode { get; set; }

        public JQueryAutoAuto()
        {
        }
        public JQueryAutoAuto(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Query.JQueryAuto.Insert"))
            //    return 0;
            QueryTableAuto AT = new QueryTableAuto();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JQueryAuto", Code, 0, 0, 0, "ثبت کوئری", "", 0);
            return Code;
        }

        public bool Update()
        {
            //if (!JPermission.CheckPermission("BusManagment.Query.JQueryAuto.Update"))
            //    return false;
            QueryTableAuto AT = new QueryTableAuto();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JQueryAuto", AT.Code, 0, 0, 0, "ویرایش کوئری", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            //if (!JPermission.CheckPermission("BusManagment.Query.JQueryAuto.Delete"))
            //    return false;
            QueryTableAuto AT = new QueryTableAuto();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JQueryAuto", AT.Code, 0, 0, 0, "حذف کوئری", "", 0);
                return true;
            }
            else return false;
        }

        public int FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select code from "+JMainFrame.Server01+@"erp_tabrizbus.dbo.AUTConsoleQueryAuto where Name = '" + this.Name + "'");
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
                DB.setQuery("select * from "+JMainFrame.Server01+@"erp_tabrizbus.dbo.AUTConsoleQueryAuto where code=" + pCode.ToString());
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


    public class JQueryAutoAutos : JSystem
    {

        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = BusManagment.Query.JQueryAutoAutos.GetWebQuery();
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
            return "select Code, Name,InsertDate from "+JMainFrame.Server01+@"erp_tabrizbus.dbo.AUTConsoleQueryAuto";
        }

    }
}
