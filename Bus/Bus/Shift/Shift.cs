using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Shift
{

    public class JShift : JSystem
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public JShift()
        {
        }
        public JShift(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Shift.JShift.Insert"))
                return 0;
            ShiftTable AT = new ShiftTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JShift", Code, 0, 0, 0, "ثبت شیفت", "", 0);
            return Code;
        }

        public bool Update()
        {
            if (!JPermission.CheckPermission("BusManagment.Shift.JShift.Update"))
                return false;
            ShiftTable AT = new ShiftTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JShift", AT.Code, 0, 0, 0, "ویرایش شیفت", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.Shift.JShift.Delete"))
                return false;
            ShiftTable AT = new ShiftTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JShift", AT.Code, 0, 0, 0, "حذف شیفت", "", 0);
                return true;
            }
            else return false;
        }

        public int FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select code from AUTShift where Title = '" + this.Title + "'");
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
                DB.setQuery("select * from AUTShift where code=" + pCode.ToString());
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


    public class JShifts : JSystem
    {

        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = BusManagment.Shift.JShifts.GetWebQuery();
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
            return "select * from AUTShift";
        }

    }
}
