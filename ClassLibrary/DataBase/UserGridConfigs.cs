using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.DataBase
{
    public class JUserGridConfigs : JSystem
    {
        public int Code { get; set; }
        public string ClassName { get; set; }
        public int UserCode { get; set; }
        public string ColumnName { get; set; }
        public string SortType { get; set; }

        public JUserGridConfigs()
        {
        }
        public JUserGridConfigs(string className, int userCode, string columnName = null)
        {
            GetData(className, userCode, columnName);
        }
        private void setProperty(JUserGridConfigs _this)
        {
            this.ClassName = _this.ClassName;
            this.Code = _this.Code;
            this.ColumnName = _this.ColumnName;
            this.UserCode = _this.UserCode;
            this.SortType = _this.SortType;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT * FROM UserGridConfigs WHERE code = {0}", pCode));
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
        public bool GetData(string className, int userCode, string columnName = null)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT * FROM UserGridConfigs WHERE ClassName='{0}' AND UserCode = {1} AND ColumnName = {2}", className, userCode, string.IsNullOrWhiteSpace(columnName) ? "ColumnName" : "'" + columnName + "'"));
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

        public bool Insert()
        {
            try
            {
                JUserGridConfigsTable ugct = new JUserGridConfigsTable();
                ugct.SetValueProperty(this);
                Code = ugct.Insert();
                return Code > 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                JUserGridConfigsTable ugct = new JUserGridConfigsTable();
                ugct.SetValueProperty(this);
                return ugct.Delete();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }
    }
    public class JUserGridConfigsTable : JTable
    {
        public JUserGridConfigsTable()
            : base("usergridconfigs")
        {
            Set_ComplexInsert(false);
        }
        public string ClassName;
        public int UserCode;
        public string ColumnName;
        public string SortType;
    }
}