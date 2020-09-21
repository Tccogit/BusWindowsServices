using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary.SMS
{
    public class JSMSGroupDefine
    {
        public JSMSGroupDefine()
        {
        }
        public JSMSGroupDefine(int code)
        {
            GetData(code);
        }

        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        public string SQL { get; set; }
        public int UserCode { get; set; }
        #endregion

        #region Methods
        public int Insert()
        {
            return Insert(null);
        }
        public int Insert(JDataBase db)
        {
            JDataBase _db = null;
            try
            {
                if (db == null) _db = new JDataBase();
                else _db = db;
                JSMSGroupDefineTable jSMSGroupDefineTable = new JSMSGroupDefineTable();
                jSMSGroupDefineTable.SetValueProperty(this);
                return jSMSGroupDefineTable.Insert(_db);
            }
            finally
            {
                if (db == null)
                    _db.Dispose();
            }
        }


        public bool Update(JDataBase db)
        {
            JDataBase _db;
            if (db == null) _db = new JDataBase();
            else _db = db;
            try
            {
                JSMSGroupDefineTable jSMSGroupDefineTable = new JSMSGroupDefineTable();
                jSMSGroupDefineTable.SetValueProperty(this);
                return jSMSGroupDefineTable.Update(_db);
            }
            finally
            {
                if (db == null) _db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From SMSGroupDefine Where Code=" + Code);
                return db.Query_Execute() >= 0 ? true : false;
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        #region GetData
        public void GetData(int code)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSGroupDefine where Code=" + code + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                Db.Dispose();
            }
        }
        #endregion
    }

    public class JSMSGroupDefines
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(false);
        }

        public static DataTable GetDataTable(bool getPublicGroups)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = "SELECT * FROM SMSGroupDefine Where UserCode = " + JMainFrame.CurrentUserCode;
                if (getPublicGroups)
                    query += " OR UserCode = 0";
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
