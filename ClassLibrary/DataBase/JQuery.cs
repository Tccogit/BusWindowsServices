using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary.DataBase
{
    public class JQuery : JSystem
    {
        public int Code { get; set; }
        public string QueryText { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }

        public string RowColors { get; set; }
        public Int64 HashCode { get; set; }
        public string QueryName { get; set; }
        //public string Parameters { get; set; }

        public static bool useQuery = false;

        public JQuery()
        {
        }

        public JQuery(string className, int objectCode = 0, params object[] parameters)
            : this(className, null, objectCode,null, parameters)
        {
        }
        public JQuery(string className, string query, int objectCode = 0, string rowColors = null, params object[] parameters)
        {
            className = className + "_" + JMainFrame.CurrentPostCode;//WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode.ToString();
            
            QueryText = query;
            ClassName = className;
            ObjectCode = objectCode;
            RowColors = rowColors;

            if (!useQuery)
                return;

            JDataBase db = new JDataBase();
            try
            {
                if (JMainFrame.IsWeb())
                {
                    Code = (className + objectCode).GetHashCode();
                    //if (Code < 0) Code *= -1;
                    JQuery _A = (JQuery)WebClassLibrary.SessionManager.Current.Session[Code.ToString()];
                    if (_A == null)
                    {
                        WebClassLibrary.SessionManager.Current.Session.Add(Code.ToString(), this);
                    }
                    else
                    {
                        if (query != null)
                        {
                            WebClassLibrary.SessionManager.Current.Session.Remove(Code.ToString());
                            WebClassLibrary.SessionManager.Current.Session.Add(Code.ToString(), this);
                        }
                        else
                            setProperty(_A);
                    }

                    if (string.IsNullOrWhiteSpace(QueryText))
                        return;
                    if (parameters != null)
                        QueryText = string.Format(QueryText, parameters);

                    return;
                }

                string _query = "SELECT * FROM Queries WHERE ClassName = '" + className + "'";
                _query += objectCode > 0 ? " AND ObjectCode = " + objectCode : "";
                db.setQuery(_query);
                if (db.Query_DataReader() && db.DataReader.Read())
                    JTable.SetToClassProperty(this, db.DataReader);
                if (this.Code <= 0 && !string.IsNullOrWhiteSpace(query))
                {
                    Insert();
                }

                if (string.IsNullOrWhiteSpace(QueryText))
                    return;
                if (parameters != null)
                    QueryText = string.Format(QueryText, parameters);
            }
            catch
            { }
            finally
            {
                db.Dispose();
            }
        }

        private void setProperty(JQuery _this)
        {
            this.ClassName = _this.ClassName;
            this.Code = _this.Code;
            this.HashCode = _this.HashCode;
            this.ObjectCode = _this.ObjectCode;
            this.QueryName = _this.QueryName;
            this.RowColors = _this.RowColors;
            this.QueryText = _this.QueryText;
        }

        public bool GetData(int pCode)
        {
            if (JMainFrame.IsWeb())
            {
                JQuery _A = (JQuery)WebClassLibrary.SessionManager.Current.Session[pCode.ToString()];
                if (_A == null)
                    return false;
                else
                {
                    setProperty(_A);
                    return true;
                }
            }

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from Queries where code=" + pCode.ToString());
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

        private bool Insert()
        {
            if (!useQuery)
                return true;
            try
            {
                if (JMainFrame.IsWeb())
                {
                    return true;
                }

                //if (JPermission.CheckPermission("WebControllers.MainControls.Grid.Query.Insert"))
                {
                    JQueryTable qt = new JQueryTable();
                    qt.SetValueProperty(this);
                    qt.HashCode = QueryText.GetHashCode();
                    Code = qt.Insert();
                    return Code > 0;
                }
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }
        public bool Update()
        {
            if (!useQuery)
                return true;
            if (JMainFrame.IsWeb())
            {
                JQuery _A = (JQuery)WebClassLibrary.SessionManager.Current.Session[Code];
                if (_A == null)
                    return false;
                else
                {
                    WebClassLibrary.SessionManager.Current.Session[Code] = this;
                }
                return true;
            }

            try
            {
                //if (JPermission.CheckPermission("WebControllers.MainControls.Grid.Query.Update"))
                {
                    JQueryTable qt = new JQueryTable();
                    qt.SetValueProperty(this);
                    qt.HashCode = QueryText.GetHashCode();
                    return qt.Update();
                }
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }

        public static string getNewQuery(string pQuery)
        {
            if (!useQuery)
                return pQuery;

            if (JMainFrame.IsWeb())
            {
                return pQuery;
            }

            JDataBase DB = new JDataBase();
            try
            {

                //DB.setQuery("select Code from queries where HashCode = " + pQuery.GetHashCode());
                //DB.Query_DataReader();
                //if (DB.DataReader != null && DB.DataReader.Read())
                {
                    //int _Code = (int)DB.DataReader["Code"];
                    //DB.DisConnect();
                    DataTable DT = JQueries.getDatatable(0);
                    DataRow DR = DT.Rows.Find(pQuery.GetHashCode());
                    int _Code = 0;
                    if (DR!=null)
                        _Code = (int)DR["Code"];
                        if (_Code > 0)
                    {
                        DB.setQuery("select QueryText from queriesUser where QueryCode = " + _Code + " and PostCode=" + JMainFrame.CurrentPostCode);
                        DB.Query_DataReader();
                        if (DB.DataReader.Read())
                        {
                            if (DB.DataReader[0].ToString().Trim().Length > 0)
                                return DB.DataReader[0].ToString();
                        }

                    }
                }
                //else
                //{
                //}
                return pQuery;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
    public class JQueryTable : JTable
    {
        public JQueryTable()
            : base("queries")
        {
            Set_ComplexInsert(false);
        }
        public string QueryText;
        public string ClassName;
        public int ObjectCode;

        public string RowColors;
        public Int64 HashCode;
        public string QueryName;
    }

    public class JQueries
    {

        static DataTable DT;
        public static DataTable getDatatable(int p)
        {
            if (DT != null)
                return DT;

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from Queries");
                DT = db.Query_DataTable(false);
                DataColumn[] keys = DT.PrimaryKey.Clone() as DataColumn[];
                DataColumn[] keysNew = new DataColumn[1];
                keysNew[0] = DT.Columns["HashCode"];
                DT.PrimaryKey = keysNew;
                DT.AcceptChanges();
                return DT;
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable getDatatable()
        {
            return JQueries.getDatatable(0);
        }
    }

    public class JQueriesUser
    {
        public int Code { get; set; }
        public int QueryCode { get; set; }
        public int PostCode { get; set; }
        public string QueryText { get; set; }

        public int Insert()
        {
            JQueriesUserTable Qt = new JQueriesUserTable();
            Qt.SetValueProperty(this);
            return Qt.Insert();
        }

        public bool Update()
        {
            JQueriesUserTable Qt = new JQueriesUserTable();
            Qt.SetValueProperty(this);
            return Qt.Update();
        }

        public bool Delete()
        {
            JQueriesUserTable Qt = new JQueriesUserTable();
            Qt.SetValueProperty(this);
            return Qt.Delete();
        }
    }

    public class JQueriesUserTable:JTable
    {
        public int QueryCode;
        public int PostCode;
        public string QueryText;

        public JQueriesUserTable()
            : base("queriesUser")
        {
        }
    }
}
