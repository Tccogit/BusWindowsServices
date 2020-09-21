using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary
{
	/// <summary>
	/// کلاسهای از پیش تعریف شده
	/// </summary>
	public class JPermissionDefinesStatic
	{
		/// <summary>
		/// ثبت مرخصی اشخاص
		/// تائید مرخصی اشخاص
		/// تائید در کارگزینی
		/// تائید در اداری
		/// </summary>
		public static string VacationDefines = "(1000016, 1000017, 1000019, 1000035)";
	}
	public class JPermissionDefineClass : JCore
	{
		/// <summary>
		/// لیست فیلد ها
		/// </summary>
		#region Property
		//public JPermissionDecision[] Items;
		public int Code { get; set; }
		public string ClassName { get; set; }
		public string SQL { get; set; }
		public int ParentCode { get; set; }
		public bool HasData;
		#endregion
		/// <summary>
		/// سازنده
		/// </summary>
		#region Constructor
		public JPermissionDefineClass()
		{
		}
		/// <summary>
		/// سازنده
		/// </summary>
		/// <param name="pClassName"></param>
		public JPermissionDefineClass(string pClassName)
		{
			ClassName = pClassName;
			HasData = GetData(ClassName);
		}
		/// <summary>
		/// سازنده
		/// </summary>
		/// <param name="pClassName"></param>
		public JPermissionDefineClass(int pCode)
		{
			Code = pCode;
			HasData = GetData(Code);
		}
		#endregion


		public JNode GetNode(DataRow pRow)
		{
			JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.JPermissionDefineClass");
			//اکشن ویرایش
			int defineCode = (int)pRow["Code"];
			foreach (DataRow decisionRow in JPermissionDecisions.GetDataTable(defineCode).Rows)
			{
				JAction editAction = new JAction(" مجوز" + decisionRow["Name"].ToString(), "ClassLibrary.JGroupPermissionForm.ShowForm", null, new object[] { (int)pRow["Code"], (int)decisionRow["Code"], " مجوزدهی " + decisionRow["Name"].ToString() + " - " + pRow["ClassName"].ToString() });
				Node.MouseDBClickAction = editAction;
				Node.Popup.Insert(editAction);
			}
			return Node;
		}
		/// <summary>
		/// جستجوی اطلاعات کلاس بر اساس نام آن
		/// </summary>
		/// <param name="pClassName"></param>
		/// <returns></returns>
		public Boolean GetData(string pClassName)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				try
				{
					DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass + " WHERE ClassName=" + JDataBase.Quote(pClassName));
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
			}
			finally
			{
				DB.Dispose();
			}
			return false;
		}
		/// <summary>
		/// جستجوی کلاس خاص بر اساس کد آن
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean GetData(int pCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				try
				{
					DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass + " WHERE " + PermissionDefineClass.Code + "=" + pCode.ToString());
					DB.Query_DataReader();
					if (DB.DataReader.Read())
					{
						JTable.SetToClassProperty(this, DB.DataReader);
					}
				}
				catch (Exception ex)
				{
					Except.AddException(ex);
				}
			}
			finally
			{
				DB.Dispose();
			}
			return true;
		}
		/// <summary>
		/// درج کلاس
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			/// در صورتی که نام کلاس وجود دارد
			if (GetData(ClassName))
			{
				JMessages.Error("ClassNameExists", "Error");
				return 0;
			}
			JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
			try
			{
				PDC.SetValueProperty(this);
				int result = PDC.Insert();
				if (result > 0)
				{
					Code = result;
					JPermissionDecision decInsert = new JPermissionDecision();
					decInsert.PermissionDefineCode = result;
					decInsert.DefaultValue = false;
					decInsert.Name = JLanguages._Text("Insert");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("Update");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("Delete");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("View");
					decInsert.Insert();
				}
				return result;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
			finally
			{
			}
		}
		/// <summary>
		/// حذف کلاس
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean Delete()
		{
			return Delete(this.Code);
		}

		public Boolean Delete(int pCode)
		{
			try
			{
				JDataBase DB = JGlobal.MainFrame.GetDBO();
				DB.setQuery("SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionUser +
					" WHERE " + PermissionUser.DecisionCode.ToString() + " IN (" +
					" SELECT  " + PermissionDecision.Code.ToString() + " FROM " + JTableNamesPermission.PermissionDecision +
					" WHERE " + PermissionDecision.PermissionDefineCode.ToString() + "=" + pCode.ToString() + ")");
				if ((int)DB.Query_ExecutSacler() > 0)
				{
					JMessages.Error("DefineClassHasPermissions", "Error");
					return false;
				}

				JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
				PDC.SetValueProperty(this);
				return PDC.Delete();
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
			}
			finally
			{
			}
			return false;
		}
		/// <summary>
		/// بروزرسانی کلاس
		/// </summary>
		public Boolean Update()
		{
			JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
			try
			{
				PDC.SetValueProperty(this);
				return PDC.Update();
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
			}
			finally
			{
			}
			return false;
		}

		/// <summary>
		/// لیست آبجکتهایی که از اس کیو ال برگردانده شده
		/// </summary>
		/// <returns></returns>
		public IDictionary<string, object> GetObjectList()
		{
			IDictionary<string, object> Dic = new Dictionary<string, object>();
			if (SQL.Length > 0)
			{
				JDataBase DB = JGlobal.MainFrame.GetDBO();
				try
				{
					//sq
					DB.setQuery("select * from (" + SQL + ") AS A Where " +
						JPermission.getObjectSql("ClassLibrary.JPermissionDefineClass.GetObjectList"));
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
					}
					return Dic;
				}
				catch (Exception ex)
				{
					Except.AddException(ex);
				}
				finally
				{
					DB.Dispose();
				}
			}
			return null;
		}

        public static IDictionary<int, DataTable> DTGetObjectLists;
        /// <summary>
        /// لیست آبجکتهایی که از اس کیو ال برگردانده شده
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetObjectList(int pObjectCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            IDictionary<string, object> Dic = new Dictionary<string, object>();
            if (SQL != null && SQL.Length > 0)
            {
                try
                {
                    DataTable DTGetObjectList;
                    if (DTGetObjectLists==null || !DTGetObjectLists.TryGetValue(SQL.GetHashCode(), out DTGetObjectList))
                    {
                        DTGetObjectLists = new Dictionary<int, DataTable>();
                        DB.setQuery("select * from (" + SQL + ") AS A ");
                        DTGetObjectList = DB.Query_DataTable();
                        DTGetObjectLists.Add(SQL.GetHashCode(), DTGetObjectList);
                        DTGetObjectList.PrimaryKey = new DataColumn[] { DTGetObjectList.Columns["Code"] };
                        DTGetObjectList.AcceptChanges();
                    }
                    DataRow DR = DTGetObjectList.Rows.Find(new object[] { pObjectCode });
                    if(DR !=null)
                    {
                        Dic.Add(DR[0].ToString(), DR[1]);
                    }
                    return Dic;
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
                finally
                {
                    DB.Dispose();
                }
            }
            return null;
        }

		public object GetObjectValue(int pCode)
		{
            IDictionary<string, object> Dics = GetObjectList(pCode);
            if (Dics == null || Dics.Count == 0)
                return null;
            foreach (KeyValuePair<string, object> dic in Dics)
				if (Int32.Parse(dic.Key) == pCode)
					return dic.Value;
			return null;
		}

		public override string ToString()
		{
			try
			{
				return JLanguages._Text(ClassName);
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return "";
			}
		}
	}

	/// <summary>
	/// کلاس ها
	/// </summary>
	public class JPermissionsDefineClass : JSystem
	{
		public JPermissionDefineClass[] Items;

		public JPermissionsDefineClass()
		{
		}
		/// <summary>
		/// لیست کلاسها
		/// </summary>
		public void GetData()
		{
			GetData(0, 0);
		}
		/// <summary>
		/// لیست کلاسها
		/// </summary>
		public void GetData(int pParentCode, int Flag)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string Where = " 1=1 ";
				if (pParentCode > 0) Where = "ParentCode=" + pParentCode;
				DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass + " Where " + Where + " And " +
						JPermission.getObjectSql("ClassLibrary.JPermissionsDefineClass.GetData"));
				DB.Query_DataReader();
				Items = new JPermissionDefineClass[DB.RecordCount];
				int count = 0;
				while (DB.DataReader.Read())
				{
					Items[count] = new JPermissionDefineClass();
					JTable.SetToClassProperty(Items[count], DB.DataReader);
					count++;
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
		}

		public static DataTable GetData(int pDefine)
		{
			JDataBase db = new JDataBase();
			string Query = "SELECT * FROM PermissionDefineClass ";
			if (pDefine != 0)
			{
				Query = Query + " Where Code = " + pDefine;
			}
			db.setQuery(Query);
			try
			{
				return db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				db.Dispose();
			}
		}

		public static DataTable GetData(string pDefines)
		{
			JDataBase db = new JDataBase();
			db.setQuery(" SELECT Code, ClassName FROM PermissionDefineClass Where Code IN " + pDefines);
			try
			{
				return db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				db.Dispose();
			}
		}

		public void PermissionsListView()
		{
			Nodes.ObjectBase = new JAction("DefinePermissions", "ClassLibrary.JPermissionDefineClass.GetNode");
			Nodes.DataTable = JPermissionsDefineClass.GetData(0);
		}

		public void ListView()
		{
			Nodes.ObjectBase = new JAction("DefinePermissions", "ClassLibrary.JPermissionDefineClass.GetNode");
			Nodes.DataTable = JPermissionsDefineClass.GetData(JPermissionDefinesStatic.VacationDefines);
			//Nodes.ObjectBase = new JAction("PermissionDefine", "ClassLibrary.JPermissionDefineClass.GetNode");
			//Nodes.DataTable = JPermissionsDefineClass.GetData(JPermissionDefinesStatic.VacationDefines);
		}
	}

	#region Group
	#region old
	//public class JPermissionDefineGroupClass : JCore
	//{
	//	/// <summary>
	//	/// لیست فیلد ها
	//	/// </summary>
	//	#region Property
	//	public int Code { get; set; }
	//	public string ClassName { get; set; }
	//	public string SQL { get; set; }
	//	public int ParentCode { get; set; }
	//	public int GroupCode { get; set; }
	//	public bool HasData;
	//	#endregion
	//	/// <summary>
	//	/// سازنده
	//	/// </summary>
	//	#region Constructor
	//	public JPermissionDefineGroupClass()
	//	{
	//	}
	//	/// <summary>
	//	/// سازنده
	//	/// </summary>
	//	/// <param name="pGroupName"></param>
	//	public JPermissionDefineGroupClass(string pClassName)
	//	{
	//		ClassName = pClassName;
	//		HasData = GetData(ClassName);
	//	}
	//	/// <summary>
	//	/// سازنده
	//	/// </summary>
	//	/// <param name="pCode"></param>
	//	public JPermissionDefineGroupClass(int pCode)
	//	{
	//		Code = pCode;
	//		HasData = GetData(Code);
	//	}
	//	#endregion

	//	/// <summary>
	//	/// جستجوی اطلاعات کلاس بر اساس نام آن
	//	/// </summary>
	//	/// <param name="pGroupName"></param>
	//	/// <returns></returns>
	//	public Boolean GetData(string pClassName)
	//	{
	//		JDataBase DB = JGlobal.MainFrame.GetDBO();
	//		try
	//		{
	//			try
	//			{
	//				DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroupClass + " WHERE ClassName=" + JDataBase.Quote(pClassName));
	//				DB.Query_DataReader();
	//				if (DB.DataReader.Read())
	//				{
	//					JTable.SetToClassProperty(this, DB.DataReader);
	//					return true;
	//				}
	//			}
	//			catch (Exception ex)
	//			{
	//				Except.AddException(ex);
	//			}
	//		}
	//		finally
	//		{
	//			DB.Dispose();
	//		}
	//		return false;
	//	}
	//	/// <summary>
	//	/// جستجوی کلاس خاص بر اساس کد آن
	//	/// </summary>
	//	/// <param name="pCode"></param>
	//	/// <returns></returns>
	//	public Boolean GetData(int pCode)
	//	{
	//		JDataBase DB = JGlobal.MainFrame.GetDBO();
	//		try
	//		{
	//			try
	//			{
	//				DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroupClass + " WHERE " + PermissionDefineGroup.Code + "=" + pCode.ToString());
	//				DB.Query_DataReader();
	//				if (DB.DataReader.Read())
	//				{
	//					JTable.SetToClassProperty(this, DB.DataReader);
	//				}
	//			}
	//			catch (Exception ex)
	//			{
	//				Except.AddException(ex);
	//			}
	//		}
	//		finally
	//		{
	//			DB.Dispose();
	//		}
	//		return true;
	//	}
	//	/// <summary>
	//	/// درج کلاس
	//	/// </summary>
	//	/// <returns></returns>
	//	public int Insert()
	//	{
	//		/// در صورتی که نام کلاس وجود دارد
	//		if (GetData(ClassName))
	//		{
	//			JMessages.Error("ClassNameExists", "Error");
	//			return 0;
	//		}
	//		JPermissionDefineGroupClassTable PDC = new JPermissionDefineGroupClassTable();
	//		try
	//		{
	//			PDC.SetValueProperty(this);
	//			int result = PDC.Insert();
	//			if (result > 0)
	//			{
	//				Code = result;
	//				JPermissionGroupDecision decInsert = new JPermissionGroupDecision();
	//				decInsert.PermissionDefineGroupClassCode = result;
	//				decInsert.DefaultValue = false;
	//				decInsert.Name = JLanguages._Text("Insert");
	//				decInsert.Insert();
	//				decInsert.Name = JLanguages._Text("Update");
	//				decInsert.Insert();
	//				decInsert.Name = JLanguages._Text("Delete");
	//				decInsert.Insert();
	//				decInsert.Name = JLanguages._Text("View");
	//				decInsert.Insert();
	//			}
	//			return result;
	//		}
	//		catch (Exception ex)
	//		{
	//			Except.AddException(ex);
	//			return 0;
	//		}
	//		finally
	//		{
	//		}
	//	}
	//	/// <summary>
	//	/// حذف کلاس
	//	/// </summary>
	//	/// <param name="pCode"></param>
	//	/// <returns></returns>
	//	public Boolean Delete()
	//	{
	//		return Delete(this.Code);
	//	}

	//	public Boolean Delete(int pCode)
	//	{
	//		try
	//		{
	//			JDataBase DB = JGlobal.MainFrame.GetDBO();
	//			DB.setQuery("SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionGroup +
	//				" WHERE " + PermissionGroup.DecisionCode.ToString() + " IN (" +
	//				" SELECT  " + PermissionDecisionGroup.Code.ToString() + " FROM " + JTableNamesPermission.PermissionDecisionGroup +
	//				" WHERE " + PermissionDecisionGroup.PermissionDefineGroupClassCode.ToString() + "=" + pCode.ToString() + ")");
	//			if ((int)DB.Query_ExecutSacler() > 0)
	//			{
	//				JMessages.Error("DefineGroupClassHasPermissions", "Error");
	//				return false;
	//			}

	//			JPermissionDefineGroupClassTable PDC = new JPermissionDefineGroupClassTable();
	//			PDC.SetValueProperty(this);
	//			return PDC.Delete();
	//		}
	//		catch (Exception ex)
	//		{
	//			Except.AddException(ex);
	//		}
	//		finally
	//		{
	//		}
	//		return false;
	//	}
	//	/// <summary>
	//	/// بروزرسانی کلاس
	//	/// </summary>
	//	public Boolean Update()
	//	{
	//		JPermissionDefineGroupClassTable PDC = new JPermissionDefineGroupClassTable();
	//		try
	//		{
	//			PDC.SetValueProperty(this);
	//			return PDC.Update();
	//		}
	//		catch (Exception ex)
	//		{
	//			Except.AddException(ex);
	//		}
	//		finally
	//		{
	//		}
	//		return false;
	//	}

	//	/// <summary>
	//	/// لیست آبجکتهایی که از اس کیو ال برگردانده شده
	//	/// </summary>
	//	/// <returns></returns>
	//	public IDictionary<string, object> GetObjectList()
	//	{
	//		IDictionary<string, object> Dic = new Dictionary<string, object>();
	//		if (SQL.Length > 0)
	//		{
	//			JDataBase DB = JGlobal.MainFrame.GetDBO();
	//			try
	//			{
	//				//sq
	//				DB.setQuery("select * from (" + SQL + ") AS A Where " +
	//					JPermission.getObjectSql("ClassLibrary.JPermissionDefineGroupClass.GetObjectList"));
	//				DB.Query_DataReader();
	//				while (DB.DataReader.Read())
	//				{
	//					Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
	//				}
	//				return Dic;
	//			}
	//			catch (Exception ex)
	//			{
	//				Except.AddException(ex);
	//			}
	//			finally
	//			{
	//				DB.Dispose();
	//			}
	//		}
	//		return null;
	//	}

	//	/// <summary>
	//	/// لیست آبجکتهایی که از اس کیو ال برگردانده شده
	//	/// </summary>
	//	/// <returns></returns>
	//	public IDictionary<string, object> GetObjectList(int pObjectCode)
	//	{
	//		IDictionary<string, object> Dic = new Dictionary<string, object>();
	//		if (SQL.Length > 0)
	//		{
	//			JDataBase DB = JGlobal.MainFrame.GetDBO();
	//			try
	//			{
	//				//sq
	//				DB.setQuery("select * from (" + SQL + ") AS A Where Code=" + pObjectCode);
	//				DB.Query_DataReader();
	//				while (DB.DataReader.Read())
	//				{
	//					Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
	//				}
	//				return Dic;
	//			}
	//			catch (Exception ex)
	//			{
	//				Except.AddException(ex);
	//			}
	//			finally
	//			{
	//				DB.Dispose();
	//			}
	//		}
	//		return null;
	//	}

	//	public object GetObjectValue(int pCode)
	//	{
	//		foreach (KeyValuePair<string, object> dic in GetObjectList(pCode))
	//			if (Int32.Parse(dic.Key) == pCode)
	//				return dic.Value;
	//		return null;
	//	}

	//	public override string ToString()
	//	{
	//		try
	//		{
	//			return JLanguages._Text(ClassName);
	//		}
	//		catch (Exception ex)
	//		{
	//			Except.AddException(ex);
	//			return "";
	//		}
	//	}
	//}

	///// <summary>
	///// کلاس ها
	///// </summary>
	//public class JPermissionsGroupDefineClass : JSystem
	//{
	//	public JPermissionDefineGroupClass[] Items;

	//	public JPermissionsGroupDefineClass()
	//	{
	//	}
	//	/// <summary>
	//	/// لیست کلاسها
	//	/// </summary>
	//	public void GetData()
	//	{
	//		GetData(0, 0);
	//	}
	//	/// <summary>
	//	/// لیست کلاسها
	//	/// </summary>
	//	public void GetData(int pParentCode, int Flag)
	//	{
	//		JDataBase DB = new JDataBase();
	//		try
	//		{
	//			string Where = " 1=1 ";
	//			if (pParentCode > 0) Where = "ParentCode=" + pParentCode;
	//			DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroupClass + " Where " + Where + " And " +
	//					JPermission.getObjectSql("ClassLibrary.JPermissionsGroupDefineClass.GetData"));
	//			DB.Query_DataReader();
	//			Items = new JPermissionDefineGroupClass[DB.RecordCount];
	//			int count = 0;
	//			while (DB.DataReader.Read())
	//			{
	//				Items[count] = new JPermissionDefineGroupClass();
	//				JTable.SetToClassProperty(Items[count], DB.DataReader);
	//				count++;
	//			}
	//		}
	//		catch (Exception ex)
	//		{
	//			Except.AddException(ex);
	//		}
	//		finally
	//		{
	//			DB.Dispose();
	//		}
	//	}

	//	public static DataTable GetGroupClasses(int pGroupCode)
	//	{
	//		JDataBase db = new JDataBase();
	//		string Query = "SELECT * FROM PermissionDefineGroupClass WHERE GroupCode = " + pGroupCode;
	//		db.setQuery(Query);
	//		try
	//		{
	//			return db.Query_DataTable();
	//		}
	//		catch (Exception ex)
	//		{
	//			JSystem.Except.AddException(ex);
	//			return null;
	//		}
	//		finally
	//		{
	//			db.Dispose();
	//		}
	//	}

	//	public static DataTable GetData(int pDefine)
	//	{
	//		JDataBase db = new JDataBase();
	//		string Query = "SELECT * FROM PermissionDefineGroupClass ";
	//		if (pDefine != 0)
	//		{
	//			Query = Query + " Where Code = " + pDefine;
	//		}
	//		db.setQuery(Query);
	//		try
	//		{
	//			return db.Query_DataTable();
	//		}
	//		catch (Exception ex)
	//		{
	//			JSystem.Except.AddException(ex);
	//			return null;
	//		}
	//		finally
	//		{
	//			db.Dispose();
	//		}
	//	}

	//	public static DataTable GetData(string pDefines)
	//	{
	//		JDataBase db = new JDataBase();
	//		db.setQuery(" SELECT Code, ClassName FROM PermissionDefineGroupClass Where Code IN " + pDefines);
	//		try
	//		{
	//			return db.Query_DataTable();
	//		}
	//		catch (Exception ex)
	//		{
	//			JSystem.Except.AddException(ex);
	//			return null;
	//		}
	//		finally
	//		{
	//			db.Dispose();
	//		}
	//	}

	//	public void PermissionsListView()
	//	{
	//		Nodes.ObjectBase = new JAction("DefinePermissions", "ClassLibrary.JPermissionDefineGroup.GetNode");
	//		Nodes.DataTable = JPermissionsDefineClass.GetData(0);
	//	}
	//}



	//public class JPermissionDefineGroup : JCore
	#endregion
	public class JPermissionDefineGroup : JCore
	{
		/// <summary>
		/// لیست فیلد ها
		/// </summary>
		#region Property
		public int Code { get; set; }
		public string GroupName { get; set; }
		#endregion
		/// <summary>
		/// سازنده
		/// </summary>
		#region Constructor
		public JPermissionDefineGroup()
		{
		}
		/// <summary>
		/// سازنده
		/// </summary>
		/// <param name="pGroupName"></param>
		public JPermissionDefineGroup(string pGroupName)
		{
			GroupName = pGroupName;
			GetData(GroupName);
		}
		/// <summary>
		/// سازنده
		/// </summary>
		/// <param name="pCode"></param>
		public JPermissionDefineGroup(int pCode)
		{
			Code = pCode;
			GetData(Code);
		}
		#endregion

		/// <summary>
		/// جستجوی اطلاعات کلاس بر اساس نام آن
		/// </summary>
		/// <param name="pGroupName"></param>
		/// <returns></returns>
		public Boolean GetData(string pGroupName)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				try
				{
					DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroup + " WHERE GroupName=" + JDataBase.Quote(pGroupName));
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
			}
			finally
			{
				DB.Dispose();
			}
			return false;
		}
		/// <summary>
		/// جستجوی کلاس خاص بر اساس کد آن
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean GetData(int pCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				try
				{
					DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroup + " WHERE " + PermissionDefineGroup.Code + "=" + pCode.ToString());
					DB.Query_DataReader();
					if (DB.DataReader.Read())
					{
						JTable.SetToClassProperty(this, DB.DataReader);
					}
				}
				catch (Exception ex)
				{
					Except.AddException(ex);
				}
			}
			finally
			{
				DB.Dispose();
			}
			return true;
		}
		/// <summary>
		/// درج کلاس
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			/// در صورتی که نام کلاس وجود دارد
			if (GetData(GroupName))
			{
				JMessages.Error("GroupNameExists", "Error");
				return 0;
			}
			JPermissionDefineGroupTable PDC = new JPermissionDefineGroupTable();
			try
			{
				PDC.SetValueProperty(this);
				int result = PDC.Insert();
				if (result > 0)
				{
					Code = result;
					JPermissionGroupDecision decInsert = new JPermissionGroupDecision();
					decInsert.PermissionDefineGroupClassCode = result;
					decInsert.DefaultValue = false;
					decInsert.Name = JLanguages._Text("Insert");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("Update");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("Delete");
					decInsert.Insert();
					decInsert.Name = JLanguages._Text("View");
					decInsert.Insert();
				}
				return result;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
			finally
			{
			}
		}
		/// <summary>
		/// حذف کلاس
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean Delete()
		{
			return Delete(this.Code);
		}

		public Boolean Delete(int pCode)
		{
			try
			{
				JDataBase DB = JGlobal.MainFrame.GetDBO();
				DB.setQuery("SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionDefineGroupClass +
					" WHERE " + PermissionDefineGroup.Code.ToString() + " IN (" +
					" SELECT  " + PermissionDefineGroupClass.GroupCode.ToString() + " FROM " + JTableNamesPermission.PermissionDefineGroupClass +
					" WHERE " + PermissionDefineGroupClass.GroupCode.ToString() + "=" + pCode.ToString() + ")");
				if ((int)DB.Query_ExecutSacler() > 0)
				{
					JMessages.Error("DefineGroupHasPermissions", "Error");
					return false;
				}

				JPermissionDefineGroupTable PDC = new JPermissionDefineGroupTable();
				PDC.SetValueProperty(this);
				return PDC.Delete();
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
			}
			finally
			{
			}
			return false;
		}
		/// <summary>
		/// بروزرسانی کلاس
		/// </summary>
		public Boolean Update()
		{
			JPermissionDefineGroupTable PDC = new JPermissionDefineGroupTable();
			try
			{
				PDC.SetValueProperty(this);
				return PDC.Update();
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
			}
			finally
			{
			}
			return false;
		}

		/// <summary>
		/// لیست آبجکتهایی که از اس کیو ال برگردانده شده
		/// </summary>
		/// <returns></returns>
		//public IDictionary<string, object> GetObjectList()
		//{
		//	IDictionary<string, object> Dic = new Dictionary<string, object>();
		//	if (SQL.Length > 0)
		//	{
		//		JDataBase DB = JGlobal.MainFrame.GetDBO();
		//		try
		//		{
		//			//sq
		//			DB.setQuery("select * from (" + SQL + ") AS A Where " +
		//				JPermission.getObjectSql("ClassLibrary.JPermissionDefineGroup.GetObjectList"));
		//			DB.Query_DataReader();
		//			while (DB.DataReader.Read())
		//			{
		//				Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
		//			}
		//			return Dic;
		//		}
		//		catch (Exception ex)
		//		{
		//			Except.AddException(ex);
		//		}
		//		finally
		//		{
		//			DB.Dispose();
		//		}
		//	}
		//	return null;
		//}

		///// <summary>
		///// لیست آبجکتهایی که از اس کیو ال برگردانده شده
		///// </summary>
		///// <returns></returns>
		//public IDictionary<string, object> GetObjectList(int pObjectCode)
		//{
		//	IDictionary<string, object> Dic = new Dictionary<string, object>();
		//	if (SQL.Length > 0)
		//	{
		//		JDataBase DB = JGlobal.MainFrame.GetDBO();
		//		try
		//		{
		//			//sq
		//			DB.setQuery("select * from (" + SQL + ") AS A Where Code=" + pObjectCode);
		//			DB.Query_DataReader();
		//			while (DB.DataReader.Read())
		//			{
		//				Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
		//			}
		//			return Dic;
		//		}
		//		catch (Exception ex)
		//		{
		//			Except.AddException(ex);
		//		}
		//		finally
		//		{
		//			DB.Dispose();
		//		}
		//	}
		//	return null;
		//}

		//public object GetObjectValue(int pCode)
		//{
		//	foreach (KeyValuePair<string, object> dic in GetObjectList(pCode))
		//		if (Int32.Parse(dic.Key) == pCode)
		//			return dic.Value;
		//	return null;
		//}

		public override string ToString()
		{
			try
			{
				return JLanguages._Text(GroupName);
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return "";
			}
		}
	}

	/// <summary>
	/// کلاس ها
	/// </summary>
	public class JPermissionsGroupDefine : JSystem
	{
		public JPermissionDefineGroup[] Items;

		public JPermissionsGroupDefine()
		{
		}
		/// <summary>
		/// لیست گروه ها
		/// </summary>
		public void GetData()
		{
			GetData(0, false);
		}
		/// <summary>
		/// لیست گروه ها
		/// </summary>
		public void GetData(int pCode, bool fake = false)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string Where = " 1=1 ";
				if (pCode > 0) Where = "Code=" + pCode;
				DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineGroup + " Where " + Where + " And " +
						JPermission.getObjectSql("ClassLibrary.JPermissionsGroupDefine.GetData"));
				DB.Query_DataReader();
				Items = new JPermissionDefineGroup[DB.RecordCount];
				int count = 0;
				while (DB.DataReader.Read())
				{
					Items[count] = new JPermissionDefineGroup();
					JTable.SetToClassProperty(Items[count], DB.DataReader);
					count++;
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
		}

		public static DataTable GetData(int pDefine)
		{
			JDataBase db = new JDataBase();
			string Query = "SELECT * FROM PermissionDefineGroup ";
			if (pDefine != 0)
			{
				Query = Query + " Where Code = " + pDefine;
			}
			db.setQuery(Query);
			try
			{
				return db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				db.Dispose();
			}
		}

		public static DataTable GetData(string pDefines)
		{
			JDataBase db = new JDataBase();
			db.setQuery(" SELECT Code, GroupName FROM PermissionDefineGroup Where Code IN " + pDefines);
			try
			{
				return db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				db.Dispose();
			}
		}

		public void PermissionsListView()
		{
			Nodes.ObjectBase = new JAction("DefinePermissions", "ClassLibrary.JPermissionDefineGroup.GetNode");
			Nodes.DataTable = JPermissionsDefineClass.GetData(0);
		}
	}
	#endregion
}
