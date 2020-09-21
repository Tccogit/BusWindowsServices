using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary.SMS
{
    class JSMSGroup
    {
        #region Constructor
        public JSMSGroup()
        {
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public int GroupCode { get; set; }
        public int PersonCode { get; set; }
        public string Mobile { get; set; }
        #endregion

        #region GroupManagement
        public static bool CreateNewGroup(string GroupName)
        {
            return false;
        }
        public static bool UpdateGroup(int GroupCode, string NewGroupName)
        {
            return false;
        }
        public static bool DeleteGroup(int GroupCode)
        {
            return false;
        }
        #endregion

        #region Insert,Delete,Update
        public bool Insert()
        {
            return Insert(null);
        }
        public bool Insert(JDataBase db)
        {
            JDataBase _db = null;
            try
            {
                if (db == null) _db = new JDataBase();
                else _db = db;
                JSMSGroupTable jSMSGroupTable = new JSMSGroupTable();
                jSMSGroupTable.SetValueProperty(this);
                if (jSMSGroupTable.Insert(_db) > 0)
                    return true;
                return false;
            }
            finally
            {
                if (db == null)
                    _db.Dispose();
            }
        }
        public bool Update()
        {
            return false;
        }
        public bool Delete()
        {
            return false;
        }
        #endregion

        #region GetData
        #endregion

    }

    public class JSMSGroups
    {
        public static DataTable GetGroupData(int GroupCode)
        {
            string SQL = (new JSMSGroupDefine(GroupCode)).SQL;
            JDataBase db = new JDataBase();
            try
            {
                if (SQL.Trim().Length == 0)
                    db.setQuery(@"Select PersonCode, 
                    CASE PersonCode WHEN 0 THEN 'ناشناس' ELSE (SELECT TOP 1 Name From [clsAllPerson] Where Code = PersonCode) END as PersonName, 
                    Mobile from SMSGroup Where GroupCode = " + GroupCode.ToString());
                else
                    db.setQuery(@"Select PersonCode, 
                    CASE PersonCode WHEN 0 THEN 'ناشناس' ELSE (SELECT TOP 1 Name From [clsAllPerson] Where Code = PersonCode) END as PersonName, 
                    Mobile from SMSGroup Where GroupCode = " + GroupCode.ToString() +
                      @"union all select clsAllPerson.Code as PersonCode,	clsAllPerson.Name as PersonName, clsPersonAddress.Mobile as Mobile from clsAllPerson
                    inner join clsPersonAddress on clsPersonAddress.PCode = clsAllPerson.Code
                    where AddressType=1 and clsAllPerson.Code in (" + SQL + ")");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static bool DeleteGroupData(int GroupCode, JDataBase _db)
        {
            JDataBase db;
            if (_db == null) db = new JDataBase();
            else db = _db;
            try
            {
                db.setQuery("Delete From SMSGroup Where GroupCode = " + GroupCode.ToString());
                if (db.Query_Execute() >= 0)
                    return true;
                return false;
            }
            finally
            {
                if (_db == null) db.Dispose();
            }
        }
    }
}
