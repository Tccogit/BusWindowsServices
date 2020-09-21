using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JFormuleManager : ClassLibrary.JSystem
    {
        #region Properties
        public int Code { get; set; }
        public int user_code { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
		public string Formule { get; set; }
		public bool Numeric { get; set; }
		#endregion

        #region Constructor
        public JFormuleManager()
        {
        }
        #endregion

        #region Method (Insert, Update, Delete)
        public int Insert()
        {
            JFormuleManagerTable JLT = new JFormuleManagerTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert();
                if (Code > 0)
                {
                    return Code;
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JLT.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            JFormuleManagerTable PDT = new JFormuleManagerTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
                PDT.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JFormuleManagerTable PDT = new JFormuleManagerTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
                PDT.Dispose();
            }
        }
        #endregion

        #region Other Methods, Overrides, ...
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }

    public class JFormuleManagers
    {
        public string ClassName;

        public JFormuleManagers(string pClassName)
        {
            ClassName = pClassName;
        }

        static Dictionary<string, DataTable> GetDataList = new Dictionary<string, DataTable>();
        public DataTable GetData()
        {
            DataTable dt;
            if (GetDataList.TryGetValue(ClassName + JMainFrame.CurrentUserCode, out dt))
                return dt;
            JDataBase Db = new JDataBase();
            try
            {
                string query = @"Select * From FormuleManager Where ClassName = N'" + ClassName + "' AND (user_code = 0 OR user_code = '" + JMainFrame.CurrentUserCode + "')";
                Db.setQuery(query);
                dt = Db.Query_DataTable();
                GetDataList.Add(ClassName + JMainFrame.CurrentUserCode, dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public JFormuleManager[] GetFormules()
        {
            DataTable DT = GetData();
            JFormuleManager[] FM = new JFormuleManager[DT.Rows.Count];
            try {
                int i = 0;
                foreach (DataRow DR in DT.Rows)
                {
                    FM[i] = new JFormuleManager();
                    FM[i].Code = Convert.ToInt32(DR["Code"]);
                    FM[i].user_code = Convert.ToInt32(DR["user_code"]);
                    FM[i].Name = DR["Name"].ToString();
                    FM[i].ClassName = DR["ClassName"].ToString();
                    FM[i].Formule = DR["Formule"].ToString();
                    FM[i].Numeric = (bool)DR["Numeric"];
                    i++;
                }
            }
            catch
            {

            }
            return FM;
        }

        public void SetDataTableFormule(System.Data.DataTable pDataTable)
        {
            try
            {
                DataTable DT = GetData();
                if (DT == null) return;
                foreach (DataRow DR in DT.Rows)
                {
                    try
                    {
                        Type T;
                        if((bool)DR["Numeric"])
                            T = System.Type.GetType("System.Int32");
                        else 
                            T = System.Type.GetType("System.String");
                        System.Data.DataColumn DC = new DataColumn(DR["Name"].ToString(),T);
                        DC.Expression = DR["Formule"].ToString();
                        pDataTable.Columns.Add(DC);


						if (DC.Expression.IndexOf("{تاریخ روز}") >= 0)
							DC.Expression = DC.Expression.Replace("{تاریخ روز}", JDateTime.FarsiDate(DateTime.Now.Date));

					}
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

    }
}
