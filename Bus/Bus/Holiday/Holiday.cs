using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Holiday
{
    public class JHoliday : JSystem
    {
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public short HoliDaysType { get; set; }
        public short DateType { get; set; }

        public JHoliday()
        {
        }
        public JHoliday(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            HolidayTable AT = new HolidayTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0, null, true);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            HolidayTable AT = new HolidayTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete(bool isWeb = false)
        {
            HolidayTable AT = new HolidayTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTHolidays where code=" + pCode.ToString());
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
}
