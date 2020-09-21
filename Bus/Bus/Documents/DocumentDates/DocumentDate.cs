using ClassLibrary;
using System
;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentDate
    {
        #region Properties 
        public int Code	{get;set;}
        /// <summary>
        /// کد سند
        /// </summary>
        public int DocumentCode	{get;set;}
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime  Date	{get;set;}
        /// <summary>
        /// این تاریخ صادر شده
        /// </summary>
        public bool  IsIssued{get;set;}
        #endregion Properties

        public JAUTDocumentDate()
        {
        }

        public JAUTDocumentDate(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDocumentDate where code=" + pCode.ToString());
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

        public override string ToString()
        {
            return ClassLibrary.JDateTime.FarsiDate(Date);
        }

        public int Insert(JDataBase pDB)
        {
            JAUTDocumentDateTable AT = new JAUTDocumentDateTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(pDB);
            return Code;
        }
    }

    public class JAUTDocumentDates
    {
        public static DataTable GetData(int pDocumentCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"  SELECT [Code]
                      ,[DocumentCode]
                      ,(Select Fa_date FROM StaticDates WHere En_Date = [Date]) FaDate
                      ,[Date]
                      ,[IsIssued]
                  FROM [AUTDocumentDate] WHERE 1=1 ";
                if (pDocumentCode > 0)
                    query += " AND DocumentCode = " + pDocumentCode;
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

        public static  int DeleteDates(JDataBase DB, int pDocumentCode)
        {
            try
            {
                string query = @"   Delete 
                  FROM [AUTDocumentDate] WHERE  DocumentCode = " + pDocumentCode;
                DB.setQuery(query);
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
               // DB.Dispose();
            }
        }
    }
}
