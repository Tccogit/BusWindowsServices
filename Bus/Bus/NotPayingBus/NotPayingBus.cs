using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.NotPayingBus
{

    public class JNotPayingBus : JSystem
    {
        public int Code { get; set; }
        public int BusCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public JNotPayingBus()
        {
        }
        public JNotPayingBus(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            //if (!JPermission.CheckPermission("BusManagment.NotPayingBus.JNotPayingBus.Insert"))
            //    return 0;
            NotPayingBusTable AT = new NotPayingBusTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JNotPayingBus", Code, 0, 0, 0, "ثبت شیفت", "", 0);
            return Code;
        }

        public bool Delete()
        {
            //if (!JPermission.CheckPermission("BusManagment.NotPayingBus.JNotPayingBus.Delete"))
            //    return false;
            NotPayingBusTable AT = new NotPayingBusTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JNotPayingBus", AT.Code, 0, 0, 0, "حذف شیفت", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTNotPayingBus where code=" + pCode.ToString());
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
        public int FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select code from AUTNotPayingBus where BusCode = " + this.BusCode);
                DataTable dt = DB.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["code"]);
                else
                    return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }


    public class JNotPayingBuses : JSystem
    {

        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = BusManagment.NotPayingBus.JNotPayingBuses.GetWebQuery();
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
            return "select npb.Code, bus.BUSNumber, npb.FromDate, npb.ToDate from AUTNotPayingBus npb left join AUTBus bus on npb.BusCode = bus.Code";
        }

    }
}
