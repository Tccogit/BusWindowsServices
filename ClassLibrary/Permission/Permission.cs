using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary;
using Globals;

namespace ClassLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class JPermission : JSystem
	{
		/// <summary>
		/// 
		/// </summary>
		/// 
		private static string PermissionTableName
		{
			get
			{

				if (JMainFrame.Successor)
					return "PermissionUserSuccessor";
				else
					return "PermissionUser";

			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// 
		private static string WherePermission
		{
			get
			{
				if (JMainFrame.Successor)
					return " And Creator=" + JMainFrame.CurrentPostCode.ToString();
				else
					return "";

			}
		}

		public JPermission()
		{

		}

		public void ListView()
		{
			Nodes.Insert(JStaticNode._PermissionShowClassForm());
			Nodes.Insert(JStaticNode._PermissionShowDllForm());
			Nodes.Insert(JStaticNode._PermissionDefineForm());
			Nodes.Insert(JStaticNode._PermissionSet(JMainFrame.CurrentUserCode));
		}

		public JNode[] TreeView()
		{
			JNode[] N = new JNode[4];
			N[0] = JStaticNode._PermissionShowClassForm();
			N[1] = JStaticNode._PermissionShowDllForm();
			N[2] = JStaticNode._PermissionDefineForm();
			N[3] = JStaticNode._PermissionSet(JMainFrame.CurrentUserCode);
			return N;
		}

		public void ShowLoadDLL()
		{
			JPermissionLoadDLLForm LF = new JPermissionLoadDLLForm();
			LF.ShowDialog();
		}

		public void ShowClassForm()
		{
			JPermisionClassForm LF = new JPermisionClassForm();
			LF.ShowDialog();
		}

		public void SetUserPermission(int pCode)
		{
			if (JPermission.CheckPermission("ClassLibrary.JPermission.SetUserPermission"))
			{
				JPermissionSetUserForm PUS = new JPermissionSetUserForm(pCode);
				PUS.ShowDialog();
			}
		}

		public static bool CheckPermission(string pClassName, int pObjectCode)
		{
			return CheckPermission(pClassName, pObjectCode, JMainFrame.BaseCurrentPostCode);//JMainFrame.CurrentPostCode
		}

		public static bool CheckPermission(string pClassName)
		{
			return CheckPermission(pClassName, 0, JMainFrame.BaseCurrentPostCode);//JMainFrame.CurrentPostCode
		}

		public static bool CheckPermission(string pClassName, int pObjectCode, int pPostCode)
		{
			return CheckPermission(pClassName, pObjectCode, pPostCode, false);
		}

		public static bool CheckPermission(string pClassName, bool pShowMessage)
		{
			return CheckPermission(pClassName, 0, JMainFrame.BaseCurrentPostCode, pShowMessage);//JMainFrame.CurrentPostCode
		}

		public static bool CheckPermission(string pClassName, int pObjectCode, int pPostCode, bool pShowMessgae)
		{
			if (pPostCode == 0) pPostCode = JMainFrame.CurrentPostCode;
			return CheckPermission(pClassName, pObjectCode, pPostCode, pShowMessgae, null);
		}

        public static DataTable PermissionDataTable;
        public static DataTable PermissionDataTableGroup;
        public static int PPermissionPostCode;
        public static bool CheckPermission(string pClassName, int pObjectCode, int pPostCode, bool pShowMessgae, string pMessage)
		{
            if (pPostCode == 1 || JMainFrame.IsAdmin || JMainFrame.IsAndroid)
                return true;

            JDataBase DB = new JDataBase();
            DataTable dt = null;
            bool HasPermission = false;
                Permission.JPermissionDefineControl PDC = new Permission.JPermissionDefineControl();
                PDC.PermissionName = pClassName;
                PDC.Insert();
            if (!JMainFrame.IsWeb())
            {
                string query;
                if (PermissionDataTable == null || (PermissionDataTable != null && PermissionDataTable.PrimaryKey.Length == 0) || PPermissionPostCode != pPostCode)
                {
                    PPermissionPostCode = pPostCode;
                    query = @"select Class_Name,ObjectCode from " + PermissionTableName + @" pu
                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                    where pu.User_Post_Code=" + pPostCode.ToString() + WherePermission + " group by Class_Name,ObjectCode";

                    DB.setQuery(query);
                    PermissionDataTable = DB.Query_DataTable();

                    DataColumn[] keys = PermissionDataTable.PrimaryKey.Clone() as DataColumn[];
                    DataColumn[] keysNew = new DataColumn[2];
                    keysNew[0] = PermissionDataTable.Columns["class_name"];
                    keysNew[1] = PermissionDataTable.Columns["ObjectCode"];
                    PermissionDataTable.PrimaryKey = keysNew;
                    PermissionDataTable.AcceptChanges();
                }
                dt = PermissionDataTable;
                HasPermission = dt.Rows.Find(new object[] { pClassName, pObjectCode } ) != null;
                if (!HasPermission)
                {
                    JHistory H = new JHistory();
                    H.ClassName = "ClassLibrary.JPermission";
                    H.ObjectCode = pPostCode;
                    H.UserCode = JMainFrame.CurrentUserCode;
                    H.History = pClassName + "_" + pObjectCode;
                    H.Date = DateTime.Now;
                    H.Save();

                    if (PermissionDataTableGroup == null || (PermissionDataTableGroup != null && PermissionDataTableGroup.PrimaryKey.Length == 0)|| pPostCode != PPermissionPostCode)
                    {
                        PPermissionPostCode = pPostCode;
                        query =
                            @"select Class_Name,ObjectCode from PermissionGroupUsers pgu
                            inner join PermissionGroup pg on pgu.GroupCode = pg.GroupCode
                            inner join PermissionDecision pd on pd.Code = pg.DecisionCode
                            inner join PermissionControl pc on pc.Decision_Code = pd.Code and pc.Class_Code = pd.PermissionDefineCode
                            where pgu.User_Post_Code = " + pPostCode + " group by Class_Name,ObjectCode";
                        DB.setQuery(query);
                        PermissionDataTableGroup = DB.Query_DataTable();
                        DataColumn[] keys = PermissionDataTableGroup.PrimaryKey.Clone() as DataColumn[];
                        DataColumn[] keysNew = new DataColumn[2];
                        keysNew[0] = PermissionDataTableGroup.Columns["class_name"];
                        keysNew[1] = PermissionDataTableGroup.Columns["ObjectCode"];
                        PermissionDataTableGroup.PrimaryKey = keysNew;
                        PermissionDataTableGroup.AcceptChanges();
                    }

                    dt = PermissionDataTableGroup;
                    HasPermission = dt.Rows.Find(new object[] { pClassName, pObjectCode }) != null;
                }
            }
            else
            {
                if (WebClassLibrary.SessionManager.Current.Session[PermissionTableName + "_DataTable"] == null || (int)WebClassLibrary.SessionManager.Current.Session["PPermissionPostCode_DataTable"] != pPostCode)
                {
                    WebClassLibrary.SessionManager.Current.Session["PPermissionPostCode_DataTable"] = pPostCode;
                    string query = @"select Class_Name,ObjectCode from " + PermissionTableName + @" pu
                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                    where pu.User_Post_Code=" + pPostCode.ToString() + " group by Class_Name,ObjectCode";

                    DB.setQuery(query);
                    dt = DB.Query_DataTable();
                    DataColumn[] keys = dt.PrimaryKey.Clone() as DataColumn[];
                    DataColumn[] keysNew = new DataColumn[2];
                    keysNew[0] = dt.Columns["class_name"];
                    keysNew[1] = dt.Columns["ObjectCode"];
                    dt.PrimaryKey = keysNew;
                    dt.AcceptChanges();
                    WebClassLibrary.SessionManager.Current.Session.Add(PermissionTableName + "_DataTable", dt);
                }
                else
                    dt = (WebClassLibrary.SessionManager.Current.Session[PermissionTableName + "_DataTable"] as DataTable);
                try
                {
                    HasPermission = dt.Rows.Find(new object[] { pClassName, pObjectCode }) != null;
                }
                catch (Exception ex)
                {

                }
                if (!HasPermission)
                {
                    //JHistory H = new JHistory();
                    //H.ClassName = "ClassLibrary.JPermission";
                    //H.ObjectCode = pPostCode;
                    //H.UserCode = JMainFrame.CurrentUserCode;
                    //H.History = pClassName + "_" + pObjectCode;
                    //H.Date = DateTime.Now;
                    //H.Save();
                    if (WebClassLibrary.SessionManager.Current.Session[PermissionTableName + "_Groups_DataTable"] == null || (int)WebClassLibrary.SessionManager.Current.Session["PPermissionPostCode_DataTable"] != pPostCode)
                    {
                        WebClassLibrary.SessionManager.Current.Session["PPermissionPostCode_DataTable"] = pPostCode;
                        string query =
                            @"select Class_Name,ObjectCode from PermissionGroupUsers pgu
                            inner join PermissionGroup pg on pgu.GroupCode = pg.GroupCode
                            inner join PermissionDecision pd on pd.Code = pg.DecisionCode
                            inner join PermissionControl pc on pc.Decision_Code = pd.Code and pc.Class_Code = pd.PermissionDefineCode
                            where pgu.User_Post_Code = " + JMainFrame.CurrentPostCode + " group by Class_Name,ObjectCode";
                        DB.setQuery(query);
                        dt = DB.Query_DataTable();
                        DataColumn[] keys = dt.PrimaryKey.Clone() as DataColumn[];
                        DataColumn[] keysNew = new DataColumn[2];
                        keysNew[0] = dt.Columns["class_name"];
                        keysNew[1] = dt.Columns["ObjectCode"];
                        dt.PrimaryKey = keysNew;
                        dt.AcceptChanges();
                        WebClassLibrary.SessionManager.Current.Session.Add(PermissionTableName + "_Groups_DataTable", dt);
                    }
                    else
                        dt = (WebClassLibrary.SessionManager.Current.Session[PermissionTableName + "_Groups_DataTable"] as DataTable);
                   if (pClassName.IndexOf("RealPerson")>0)
                        HasPermission = false;
                    HasPermission = dt.Rows.Find(new object[] { pClassName, pObjectCode }) != null;
                }

            }

            try
			{
				string Msg;
				if (pMessage != null)
					Msg = pMessage;
				else
                    Msg = "YouDontHavePermission " + pClassName;
				if (pShowMessgae && !HasPermission)
					ClassLibrary.JMessages.Error(Msg, "AccessDenied");
				return HasPermission;
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

		public static string getObjectSql(string pFuncName)
		{
			return getObjectSql(JMainFrame.BaseCurrentPostCode, pFuncName, "Code");//JMainFrame.CurrentPostCode
		}

		public static string getObjectSql(string pFuncName, string pFieldName)
		{
			return getObjectSql(JMainFrame.BaseCurrentPostCode, pFuncName, pFieldName);//JMainFrame.CurrentPostCode
		}

		public static string getObjectSql(int pPostCode, string pFuncName, string pFieldName)
		{
			string query = " 1 = 1 ";
			Permission.JPermissionDefineControl PDC = new Permission.JPermissionDefineControl();
			PDC.PermissionName = pFuncName;
			PDC.Insert();
			if (pPostCode == 1 || JMainFrame.IsAdmin)
				return query;
			JDataBase db = new JDataBase();
			try
			{
				string tempquery = @"select pu.ObjectCode from " + PermissionTableName + @" pu
                                        inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                        inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                        where pu.ObjectCode=0 AND pu.User_Post_Code=" + pPostCode.ToString() + " AND pc.Class_Name=" + JDataBase.Quote(pFuncName) + WherePermission;
				db.setQuery(tempquery);
				DataTable dt = db.Query_DataTable();
				if (dt.Rows.Count == 0)
				{

                    query = " " + pFieldName + @" IN (" + "select pu.ObjectCode from " + PermissionTableName + @" pu
                                                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                                    where pu.User_Post_Code=" + pPostCode.ToString() + " and pc.Class_Name=" + JDataBase.Quote(pFuncName) + WherePermission + ") ";


                    db.setQuery("select pu.ObjectCode from " + PermissionTableName + @" pu
                                                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                                    where pu.User_Post_Code=" + pPostCode.ToString() + " and pc.Class_Name=" + JDataBase.Quote(pFuncName) + WherePermission);

                    dt = db.Query_DataTable();
                    if (String.Join(",", JDataBase.DataTableToStringtArray(dt, "ObjectCode")).Length == 0)
                        query = " 1=0";
                    else
                        query = " " + pFieldName + @" IN (" + String.Join(",", JDataBase.DataTableToStringtArray(dt, "ObjectCode")) + ") ";

                }
				else
				{
					query = @"select '" + pFieldName + @" IN (select Code FROM ('+CASE WHEN LEN(CAST(pdc.SQL AS VARCHAR(MAX))) > 5 THEN CAST(pdc.SQL AS VARCHAR(MAX)) ELSE (SELECT 'select -1 code' AS code) END +')as a )' 
                         from " + PermissionTableName + @" pu
                         INNER JOIN PermissionDecision pd on pu.DecisionCode=pd.Code
                         INNER JOIN PermissionControl pc on pc.Decision_Code = pd.Code
                         INNER JOIN PermissionDefineClass pdc ON pdc.Code=pd.PermissionDefineCode
                         where pu.User_Post_Code=" + pPostCode.ToString() + " and pc.Class_Name=" + JDataBase.Quote(pFuncName) + WherePermission + "";
					if (query.IndexOf("(SELECT 'select -1 code' AS code)") > 0)
						return "1=1";
					db.setQuery(query);
					dt = db.Query_DataTable();
					if (dt != null && dt.Rows.Count == 1)
						return dt.Rows[0][0].ToString();
					else
						return "1=1";
				}


			}
			catch
			{
			}
			finally
			{
                db.Dispose();
			}
			return query;
		}

		public static string getUserSql(string pFuncName, string pFieldName)
		{

			string Query = "" + pFieldName + @" IN (select pu.User_Post_Code from " + PermissionTableName + @" pu
	inner join PermissionDecision pd on pu.DecisionCode=pd.Code
	inner join PermissionControl pc on pc.Decision_Code = pd.Code
	where pc.Class_Name=" + JDataBase.Quote(pFuncName) + WherePermission + ")";
			return Query;

		}
	}
}

