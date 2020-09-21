using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace ClassLibrary
{
    public enum ProjectsEnum
    {
        All = 0,
        ClassLibrary = 1,
        Employment = 2,
        Estates = 3,
        FastReport = 4,
        Finance = 5,
        Globals = 6,
        Legal = 7,
        RealState = 8,
        ShareProfit = 9,
        Contract = 10,
        ShopSharj = 500,
        Restaurant = 12,
        Meeting = 13,
        Parking=14,
        SmartCards=15,
    }

    public class JReportManagement : JSystem
    {
      
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// عنوان فرم 
        /// </summary>
        public string Title{ get; set; }
        /// <summary>
        /// تب ها
        /// </summary>
        public string Tabs{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Project { get; set; }
        #endregion

         #region سازنده

        public JReportManagement()
        {
        }
        public JReportManagement(int pCode)
        {
            Code=pCode;
            GetData(Code);
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
                DB.setQuery("SELECT * FROM " + JTableNamesReport.Report + " WHERE Code=" + pCode.ToString());
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
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetAllData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesReport.Report + " WHERE Code=" + pCode.ToString());
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
        #endregion

        #region Nodes
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], this.GetType().FullName);
            Node.Name = pRow["Title"].ToString();
            Node.Icone = (int)JImageIndex.report;
            Nodes.hidColumns = "Tabs,Project";
            JAction ShowAction = new JAction("Edit...", "ClassLibrary.JReportManagement.Show", new object[] { (int)pRow["Code"] }, null);
            Node.MouseDBClickAction = ShowAction;

            return Node;
        }

        #endregion

        public void Show(int pCode)
        {
            JReportForm R = new JReportForm(pCode);
            R.ShowDialog();
        }
    }


    public class JReportManagements : JSystem
    {
        public JReportManagement[] Items = new JReportManagement[0];
        //  public String OrderName;
        public JReportManagements()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, ProjectsEnum.All);
        }

        public static DataTable GetDataTable(int pCode, ProjectsEnum pProj)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "SELECT * FROM " + JTableNamesReport.Report + " WHERE Project=" + pProj.GetHashCode().ToString();
                if (pCode != 0)
                    WHERE = WHERE + " AND Code = " + pCode;
                DB.setQuery(WHERE);
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

        public void ListView(ProjectsEnum pProj)
        {
            Nodes.ObjectBase = new JAction("Reports", "ClassLibrary.JReportManagement.GetNode");
            Nodes.DataTable = GetDataTable(0, pProj);
        }
        
    }
}
