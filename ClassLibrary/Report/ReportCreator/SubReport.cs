using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace ClassLibrary
{
    public class JSubReport : JSystem
    {       

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد گزارش
        /// </summary>
        public int  ReportCode{ get; set; }
        /// <summary>
        /// نام تب
        /// </summary>
        public string TabTitle { get; set; }
        /// <summary>
        /// فیلدها
        /// </summary>
        public string  Fields{ get; set; }
        /// <summary>
        /// جداول
        /// </summary>
        public string Tables { get; set; }
        /// <summary>
        /// فیلدهای مخفی
        /// </summary>
        public string Hide { get; set; }
        /// <summary>
        /// گروه بندی
        /// </summary>
        public string GroupBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataTable DataTable;

        #endregion

        #region سازنده

        public JSubReport()
        {
                DataTable = new DataTable();
        }
        public JSubReport(int pCode)
        {
            Code = pCode;
            GetData(Code);
            DataTable = new DataTable();
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesReport.SubReport + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        #endregion

        public List<string> GetTables()
        {
            List<string> Temp = new List<string>();
            Temp.AddRange(Tables.Split(','));
            return Temp;
        }

        public void Update()
        {
            JSubReportTable SRT = new JSubReportTable();
            SRT.SetValueProperty(this);
            SRT.Update();
        }

        public override string ToString()
        {
            return TabTitle;
        }
    }


    public class JSubReports : JSystem
    {
        #region Property

        private JSubReport[] _Items = new JSubReport[0];

        public JSubReport[] Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion 

        #region Constracour
        public JSubReports(int pCode)
        {
            GetItems(pCode);
        }

        #endregion
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetDataReport(int pReportCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesReport.SubReport + "  WHERE ReportCode=" + pReportCode.ToString());
                //DB.setQuery("SELECT * FROM " + JTableNamesReport.Report + " R inner join " + JTableNamesReport.SubReport + " SR on R.Code=SR.ReportCode  WHERE ReportCode=" + pReportCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }

        }

        private void GetItems(int pReportCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesReport.SubReport + "  WHERE ReportCode=" + pReportCode.ToString());
                DataTable DT = DB.Query_DataTable();
                Array.Resize(ref _Items, DT.Rows.Count);
                int Count = 0;
                foreach (DataRow DR in DT.Rows)
                {
                    _Items[Count] = new JSubReport();
                    JTable.SetToClassProperty(_Items[Count], DR);
                    Count++;
                }
                
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return ;
            }
            finally
            {
                DB.Dispose();
            }

        }

    }
}
