using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JHiddenColumns
    {
        #region Constructor
        public JHiddenColumns(int code)
        {
            GetData(code);
        }

        public JHiddenColumns()
        {

        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public int user_code { get; set; }
        public string ClassName { get; set; }
        public string Columns { get; set; }
        #endregion

        #region Methods
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JHiddenColumnsTable jHiddenColumns = new JHiddenColumnsTable();
                jHiddenColumns.user_code = this.user_code;
                jHiddenColumns.Columns = this.Columns;
                jHiddenColumns.ClassName = this.ClassName;
                int code = jHiddenColumns.Insert(db);
                return code;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                JHiddenColumnsTable jHiddenColumns = new JHiddenColumnsTable();
                jHiddenColumns.SetValueField(this);
                if (jHiddenColumns.Update())
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                JHiddenColumnsTable jHiddenColumns = new JHiddenColumnsTable();
                jHiddenColumns.SetValueField(this);
                if (jHiddenColumns.Delete())
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteByUserCodeClassName(int UserCode, string className)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From HiddenColumns Where user_code = " + UserCode + " AND ClassName = N'" + className + "'");
                if (db.Query_Execute() >= 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteByUserCode(int UserCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From HiddenColumns Where user_code = " + UserCode);
                if (db.Query_Execute() >= 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteByClassName(int className)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From HiddenColumns Where ClassName = N'" + className + "'");
                if (db.Query_Execute() >= 0)
                    return true;
                else
                    return false;
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
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From HiddenColumns Where Code = " + code);
                db.Query_DataReader();
                if (db.DataReader.Read())
                    JTable.SetToClassField(this, db.DataReader);
                db.DataReader.Close();
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
           
        }

        public string[] GetColumns(int UserCode, string className)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From HiddenColumns Where user_code = " + UserCode.ToString() + " AND ClassName = N'" + className + "'");
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0]["Columns"].ToString().Split(',');
                else
                    return null;
            }
           catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion
    }
}
