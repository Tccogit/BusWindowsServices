using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.BusEvent
{
    public class JEventActivity
    {
        public int Code { get; set; }
        public int Event { set; get; }
        public int activity { get; set; }
        public int Priority { get; set; }
        public JEventActivity()
        {
        }
        public JEventActivity(int pCode)
        {
            if (pCode > 0)
            {
                this.GetData(pCode);
            }
        }
        public int Insert(JDataBase db = null)
        {
            EventActivityTable AT = new EventActivityTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);

            return Code;
            //JDataBase _db = db;
            //if (db == null)
            //    _db = new JDataBase();
            //try
            //{
            //    _db.setQuery(@"
            //            insert into [AUTBusEventActivity] values
            //            (
            //            (select isnull(max(Code),0)+1 from [AUTBusEventActivity] where code < 10000)
            //            ," + Event + @"
            //            ," + activity + @"
            //            ," + Priority + @"
            //            , getdate()
            //            )
            //            select isnull(max(Code),0) from [AUTBusEventActivity] where code < 10000
            //            ");
            //    Code = (int)_db.Query_ExecutSacler();
        //}
        //    finally
        //    {
        //        if (db == null)
        //            _db.Dispose();
        //    }

        //    return Code;
        }
        public bool Update()
        {
            EventActivityTable EAT = new EventActivityTable();
            EAT.SetValueProperty(this);
           return  EAT.Update();

        }
        public bool Delete()
        {
            EventActivityTable EAT = new EventActivityTable();

            EAT.SetValueProperty(this);
            return EAT.Delete();


        }
        public bool GetData(int pcode)
        {
            JDataBase d = new JDataBase();
            try
            {
                d.setQuery("select * from AUTBusEventActivity where code=" + pcode.ToString());
                d.Query_DataReader();
                if (d.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, d.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                d.Dispose();
            }

        }
    }
    public class JEventActivitys
    {
        public DataTable GetEventActivity()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from AUTBusEventActivity");
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
