using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;

namespace ClassLibrary
{
	/// <summary>
	/// کلاس امنیت
	/// </summary>
	public class JPermissionUser : JCore
	{
		#region Property
		/// <summary>
		/// کد پرمیشن کاربر
		/// </summary>
		public int Code { get; set; }
		/// <summary>
		/// کد پرمیشن
		/// </summary>
		public int DecisionCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//public int DefineClassCode { get; set; }
		/// <summary>
		/// کد شی
		/// </summary>
		public int ObjectCode { get; set; }
		/// <summary>
		/// کد کاربر
		/// </summary>
		public int User_Post_Code { get; set; }
		/// <summary>
		/// مجوز
		/// </summary>
		public bool HasPermission { get; set; }
		/// <summary>
		/// ثبت کننده
		/// </summary>
		public int Creator { get; set; }
		/// <summary>
		///  تاریخ شروع مجوز 
		/// </summary>
		public DateTime Start_Date { get; set; }
		/// <summary>
		/// تاریخ پایان مجوز
		/// </summary>
		public DateTime End_Date { get; set; }

		#endregion

		/// <summary>
		/// سازنده کلاس
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pUserCode"></param>
		/// <param name="pObjectCode"></param>
		public JPermissionUser()
		{
			ObjectCode = 0;
		}
		public JPermissionUser(int pCode)
		{
			GetData(pCode);
		}
		/// <summary>
		/// جستجوی اطلاعات کاربر بر اساس کد جدول
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean GetData(int pCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUser + " WHERE Code=" + pCode.ToString());
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
		/// جستجوی اطلاعات کاربر بر اساس کد جدول
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean Check()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUser +
					" WHERE DecisionCode = " + DecisionCode.ToString() + " And User_Post_Code = " + User_Post_Code.ToString() +
					" And ObjectCode=" + ObjectCode.ToString()); //+ " And HasPermission=" + HasPermission.ToString());
				if (DB.Query_DataTable().Rows.Count > 0)
					return false;
				else
					return true;
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
		public bool Find(JPermissionUser pUser)
		{
			string query = " SELECT * FROM PermissionUser WHERE [User_Post_Code] = " + pUser.User_Post_Code +
				" AND [ObjectCode] =" + pUser.ObjectCode + " AND [DecisionCode] = " + pUser.DecisionCode;
			JDataBase db = new JDataBase();
			db.setQuery(query);
			try
			{
				db.Query_DataReader();
				if (db.DataReader.Read())
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				db.Dispose();
			}
		}
		/// <summary>
		/// درج مجوزهای کاربر
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			JPermissionUserTable PUT = new JPermissionUserTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Insert"))
				{
					PUT.SetValueProperty(this);
					if (!Find(this))
						Code = PUT.Insert();
					return Code;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
			finally
			{
				PUT.Dispose();
			}
		}
		/// <summary>
		/// ویرایش مجوزهای کاربر
		/// </summary>
		/// <returns></returns>
		public bool update()
		{
			JPermissionUserTable PUT = new JPermissionUserTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Update"))
				{
					PUT.SetValueProperty(this);
					return PUT.Update();
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}
		/// <summary>
		/// حذف مجوز کاربر
		/// </summary>
		/// <returns></returns>
		public bool delete()
		{
			JPermissionUserTable PUT = new JPermissionUserTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Delete"))
				{
					PUT.SetValueProperty(this);
					return PUT.Delete();
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}

        public static DataTable DTPermissionDecision;
		public override string ToString()
		{
            if(DTPermissionDecision == null)
            {
                DTPermissionDecision = JPermissionDecisions.GetDataTable(0);
                DataColumn[] DC = new DataColumn[1];
                DC[0] = DTPermissionDecision.Columns["Code"];
                DTPermissionDecision.PrimaryKey = DC;
                DTPermissionDecision.AcceptChanges();
            }
            DataRow DR = DTPermissionDecision.Rows.Find(new object[] { DecisionCode });
            JPermissionDefineClass PDC = new JPermissionDefineClass();
            if (DR != null)
			{
                PDC.Code = int.Parse(DR["PermissionDefineCode"].ToString());
                PDC.SQL = DR["SQL"].ToString();
                object objectValue = PDC.GetObjectValue(ObjectCode);
				if (objectValue != null)
					return DR["ClassName"] + "->" + objectValue.ToString() + "->" + DR["Name"];
			}

			return DR["ClassName"] + "->" + DR["Name"];
		}

	}


	/// <summary>
	/// کلاس امنیت کاربر
	/// </summary>
	public class JPermissionsUser : JCore
	{
		#region Property
		/// <summary>
		/// کد کاربر
		/// </summary>
		public int UserCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public JPermissionUser[] Items;
		#endregion

		/// <summary>
		///  سازنده کلاس
		/// </summary>
		/// <param name="pUserCode"></param>
		public JPermissionsUser(int pUserCode)
		{
			UserCode = pUserCode;
		}
		/// <summary>
		/// کاربرانی که مجوز این تصمیم را دارند (برای کاربری خاص)
		/// </summary>
		/// <param name="pDecisionCode"></param>
		/// <returns></returns>
		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery, int UserHasPermission)
		{
			string Query = "";
			if (pObjectsQuery.Trim() == "")
				Query = @" SELECT Code ,HasPermission
                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code) UserPermissionName
                  FROM [PermissionUser] PU";
			else
				Query = @"Select PU.Code
                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code";
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode + " AND  PU.User_Post_Code = " + UserHasPermission.ToString());
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
		}        /// <summary>
		/// کاربرانی که مجوز این تصمیم را دارند
		/// </summary>
		/// <param name="pDecisionCode"></param>
		/// <returns></returns>
		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery)
		{
			string Query = "";
			if (pObjectsQuery.Trim() == "")
				Query = @" SELECT Code ,HasPermission
                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
                  FROM [PermissionUser] PU ";
			else
				Query = @"Select PU.Code
                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code ";
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode);
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
		/// <summary>
		/// جستجوی کد مجوزهای کاربر بر اساس کد کاربر
		/// </summary>
		/// <returns></returns>
		public Boolean GetData()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM PermissionUser WHERE " + PermissionUser.User_post_Code + "=" + UserCode.ToString());

				DB.Query_DataReader();
				Items = new JPermissionUser[DB.RecordCount];
				int count = 0;
				while (DB.DataReader.Read())
				{
					Items[count] = new JPermissionUser();
                    JTable.SetToClassProperty(Items[count], DB.DataReader);
					count++;
				}
				return true;
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


	}

	#region Group
	/// <summary>
	/// کلاس امنیت
	/// </summary>
	public class JPermissionGroup : JCore
	{
		#region Property
		/// <summary>
		/// کد پرمیشن کاربر
		/// </summary>
		public int Code { get; set; }
		/// <summary>
		/// کد پرمیشن
		/// </summary>
		public int DecisionCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//public int DefineClassCode { get; set; }
		/// <summary>
		/// کد شی
		/// </summary>
		public int ObjectCode { get; set; }
		/// <summary>
		/// کد گروه
		/// </summary>
		public int GroupCode { get; set; }
		/// <summary>
		/// مجوز
		/// </summary>
		public bool HasPermission { get; set; }
		/// <summary>
		/// ثبت کننده
		/// </summary>
		public int Creator { get; set; }
		/// <summary>
		///  تاریخ شروع مجوز 
		/// </summary>
		public DateTime Start_Date { get; set; }
		/// <summary>
		/// تاریخ پایان مجوز
		/// </summary>
		public DateTime End_Date { get; set; }

		#endregion

		/// <summary>
		/// سازنده کلاس
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pUserCode"></param>
		/// <param name="pObjectCode"></param>
		public JPermissionGroup()
		{
			ObjectCode = 0;
		}
		public JPermissionGroup(int pCode)
		{
			GetData(pCode);
		}
		/// <summary>
		/// جستجوی اطلاعات کاربر بر اساس کد جدول
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean GetData(int pCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionGroup + " WHERE Code=" + pCode.ToString());
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
		/// جستجوی اطلاعات کاربر بر اساس کد جدول
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public Boolean Check()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionGroup +
					" WHERE DecisionCode = " + DecisionCode.ToString() + " And GroupCode = " + GroupCode.ToString() +
					" And ObjectCode=" + ObjectCode.ToString()); //+ " And HasPermission=" + HasPermission.ToString());
				if (DB.Query_DataTable().Rows.Count > 0)
					return false;
				else
					return true;
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
		public bool Find(JPermissionGroup pGroup)
		{
			string query = " SELECT * FROM PermissionGroup WHERE [GroupCode] = " + pGroup.GroupCode +
				" AND [ObjectCode] =" + pGroup.ObjectCode + " AND [DecisionCode] = " + pGroup.DecisionCode;
			JDataBase db = new JDataBase();
			db.setQuery(query);
			try
			{
				db.Query_DataReader();
				if (db.DataReader.Read())
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				db.Dispose();
			}
		}
		/// <summary>
		/// درج مجوزهای گروه
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			JPermissionGroupTable PUT = new JPermissionGroupTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroup.Insert"))
				{
					PUT.SetValueProperty(this);
					if (!Find(this))
						Code = PUT.Insert();
					return Code;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
			finally
			{
				PUT.Dispose();
			}
		}
		/// <summary>
		/// ویرایش مجوزهای گروه
		/// </summary>
		/// <returns></returns>
		public bool update()
		{
			JPermissionGroupTable PUT = new JPermissionGroupTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroup.Update"))
				{
					PUT.SetValueProperty(this);
					return PUT.Update();
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}
		/// <summary>
		/// حذف مجوز کاربر
		/// </summary>
		/// <returns></returns>
		public bool delete()
		{
			JPermissionGroupTable PUT = new JPermissionGroupTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroup.Delete"))
				{
					PUT.SetValueProperty(this);
					return PUT.Delete();
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}

		public override string ToString()
		{
			//JPermissionGroupDecision PD = new JPermissionGroupDecision();
			//PD.GetData(DecisionCode);

			//JPermissionDefineGroupClass pgdc = new JPermissionDefineGroupClass(PD.PermissionDefineGroupClassCode);

			//JPermissionDefineGroup PDC = new JPermissionDefineGroup();
			//PDC.GetData(pgdc.GroupCode);

			//if (pgdc.SQL != null && pgdc.SQL.Length > 0 && ObjectCode != 0)
			//{
			//	object objectValue = pgdc.GetObjectValue(ObjectCode);
			//	if (objectValue != null)
			//		return PDC + "->" + objectValue.ToString() + "->" + PD;
			//}

			//return PDC + "->" + PD;
			JPermissionDecision PD = new JPermissionDecision();
			PD.GetData(DecisionCode);

			JPermissionDefineClass PDC = new JPermissionDefineClass();
			PDC.GetData(PD.PermissionDefineCode);

			if (PDC.SQL != null && PDC.SQL.Length > 0 && ObjectCode != 0)
			{
				object objectValue = PDC.GetObjectValue(ObjectCode);
				if (objectValue != null)
					return PDC + "->" + objectValue.ToString() + "->" + PD;
			}

			return PDC + "->" + PD;
		}

	}


	/// <summary>
	/// کلاس امنیت گروه
	/// </summary>
	public class JPermissionsGroup : JCore
	{
		#region Property
		/// <summary>
		/// کد گروه
		/// </summary>
		public int GroupCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public JPermissionGroup[] Items;
		#endregion

		/// <summary>
		///  سازنده کلاس
		/// </summary>
		/// <param name="pUserCode"></param>
		public JPermissionsGroup(int pGroupCode)
		{
			GroupCode = pGroupCode;
		}
		//		/// <summary>
		//		/// کاربرانی که مجوز این تصمیم را دارند (برای کاربری خاص)
		//		/// </summary>
		//		/// <param name="pDecisionCode"></param>
		//		/// <returns></returns>
		//		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery, int GroupHasPermission)
		//		{
		//			string Query = "";
		//			if (pObjectsQuery.Trim() == "")
		//				Query = @" SELECT Code ,HasPermission
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code) UserPermissionName
		//                  FROM [PermissionUser] PU";
		//			else
		//				Query = @"Select PU.Code
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
		//					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code";
		//			JDataBase DB = JGlobal.MainFrame.GetDBO();
		//			try
		//			{
		//				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode + " AND  PU.User_Post_Code = " + GroupHasPermission.ToString());
		//				return DB.Query_DataTable();
		//			}
		//			catch (Exception ex)
		//			{
		//				Except.AddException(ex);
		//				return null;
		//			}
		//			finally
		//			{
		//				DB.Dispose();
		//			}
		//		}        /// <summary>
		//		/// کاربرانی که مجوز این تصمیم را دارند
		//		/// </summary>
		//		/// <param name="pDecisionCode"></param>
		//		/// <returns></returns>
		//		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery)
		//		{
		//			string Query = "";
		//			if (pObjectsQuery.Trim() == "")
		//				Query = @" SELECT Code ,HasPermission
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                  FROM [PermissionUser] PU ";
		//			else
		//				Query = @"Select PU.Code
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
		//					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code ";
		//			JDataBase DB = JGlobal.MainFrame.GetDBO();
		//			try
		//			{
		//				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode);
		//				return DB.Query_DataTable();
		//			}
		//			catch (Exception ex)
		//			{
		//				Except.AddException(ex);
		//				return null;
		//			}
		//			finally
		//			{
		//				DB.Dispose();
		//			}
		//		}
		/// <summary>
		/// جستجوی کد مجوزهای گروه بر اساس کد class
		/// </summary>
		/// <returns></returns>
		public Boolean GetData()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT Code FROM PermissionGroup WHERE " + PermissionGroup.GroupCode + "=" + GroupCode.ToString());

				DB.Query_DataReader();
				Items = new JPermissionGroup[DB.RecordCount];
				int count = 0;
				while (DB.DataReader.Read())
				{
					Items[count] = new JPermissionGroup();
					Items[count].GetData(int.Parse(DB.DataReader["Code"].ToString()));
					count++;
				}
				return true;
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


	}

	/// <summary>
	/// کلاس امنیت
	/// </summary>
	public class JPermissionGroupUsers : JCore
	{
		#region Property
		/// <summary>
		/// کد پرمیشن کاربر
		/// </summary>
		public int Code { get; set; }
		/// <summary>
		/// کد گروه
		/// </summary>
		public int GroupCode { get; set; }
		/// <summary>
		/// کد کاربر
		/// </summary>
		public int User_Post_Code { get; set; }
		#endregion

		/// <summary>
		/// سازنده کلاس
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pUserCode"></param>
		/// <param name="pObjectCode"></param>
		public JPermissionGroupUsers()
		{
		}
		public JPermissionGroupUsers(int pCode)
		{
			GetData(pCode);
		}
		public Boolean GetData(int pCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionGroupUsers + " WHERE Code=" + pCode.ToString());
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
		public Boolean GetData(int pGroupCode, bool isGroup = false)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionGroupUsers + " WHERE GroupCode=" + pGroupCode.ToString());
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
		public bool Find(JPermissionGroupUsers pGroupUsers)
		{
			string query = " SELECT * FROM PermissionGroupUsers WHERE [GroupCode] = " + pGroupUsers.GroupCode +
				" AND [User_Post_Code] =" + pGroupUsers.User_Post_Code;
			JDataBase db = new JDataBase();
			db.setQuery(query);
			try
			{
				db.Query_DataReader();
				if (db.DataReader.Read())
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				db.Dispose();
			}
		}
		/// <summary>
		/// درج مجوزهای گروه
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			JPermissionGroupUsersTable PUT = new JPermissionGroupUsersTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroupUsers.Insert"))
				{
					PUT.SetValueProperty(this);
					if (!Find(this))
						Code = PUT.Insert();
					return Code;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return 0;
			}
			finally
			{
				PUT.Dispose();
			}
		}
        /// <summary>
        /// درج مجوزهای گروه
        /// </summary>
        /// <returns></returns>
        public int Insert(bool checkPermission)
        {
            JPermissionGroupUsersTable PUT = new JPermissionGroupUsersTable();
            try
            {
                bool hasPermission = true;
                if (checkPermission)
                    hasPermission = JPermission.CheckPermission("ClassLibrary.JPermissionGroupUsers.Insert");
                if (hasPermission)
                {
                    PUT.SetValueProperty(this);
                    if (!Find(this))
                        Code = PUT.Insert();
                    return Code;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                PUT.Dispose();
            }
        }
		/// <summary>
		/// ویرایش مجوزهای گروه
		/// </summary>
		/// <returns></returns>
		public bool update()
		{
			JPermissionGroupUsersTable PUT = new JPermissionGroupUsersTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroupUsers.Update"))
				{
					PUT.SetValueProperty(this);
					return PUT.Update();
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}
		/// <summary>
		/// حذف مجوز کاربر
		/// </summary>
		/// <returns></returns>
		public bool delete()
		{
			JPermissionGroupUsersTable PUT = new JPermissionGroupUsersTable();
			try
			{
				if (JPermission.CheckPermission("ClassLibrary.JPermissionGroupUsers.Delete"))
				{
					PUT.SetValueProperty(this);
					return PUT.Delete(true, " groupcode = " + GroupCode + " and user_post_code = " + User_Post_Code, null);
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				Except.AddException(ex);
				return false;
			}
			finally
			{
				PUT.Dispose();
			}
		}
        public bool delete(bool checkPermission)
        {
            JPermissionGroupUsersTable PUT = new JPermissionGroupUsersTable();
            try
            {
                bool haspermission = true;
                if(checkPermission)
                    haspermission=JPermission.CheckPermission("ClassLibrary.JPermissionGroupUsers.Delete");
                if (haspermission)
                {
                    PUT.SetValueProperty(this);
                    return PUT.Delete(true, " groupcode = " + GroupCode + " and user_post_code = " + User_Post_Code, null);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PUT.Dispose();
            }
        }
		public override string ToString()
		{
			//JPermissionGroupDecision PD = new JPermissionGroupDecision();
			//PD.GetData(GroupCode);

			//JPermissionDefineGroupClass pgdc = new JPermissionDefineGroupClass();
			//pgdc.GetData(PD.PermissionDefineGroupClassCode);

			//JPermissionDefineGroup PDC = new JPermissionDefineGroup();
			//PDC.GetData(pgdc.GroupCode);

			////if (pgdc.SQL != null && pgdc.SQL.Length > 0)
			////{
			////	object objectValue = pgdc.GetObjectValue(ObjectCode);
			////	if (objectValue != null)
			////		return PDC + "->" + objectValue.ToString() + "->" + PD;
			////}

			//return PDC + "->" + PD;
			JPermissionDecision PD = new JPermissionDecision();
			PD.GetData(GroupCode);

			JPermissionDefineClass PDC = new JPermissionDefineClass();
			PDC.GetData(PD.PermissionDefineCode);

			//if (PDC.SQL != null && PDC.SQL.Length > 0 && ObjectCode != 0)
			//{
			//	object objectValue = PDC.GetObjectValue(ObjectCode);
			//	if (objectValue != null)
			//		return PDC + "->" + objectValue.ToString() + "->" + PD;
			//}

			return PDC + "->" + PD;
		}

	}

	public class JPermissionsGroupUsers : JCore
	{
		#region Property
		/// <summary>
		/// کد گروه
		/// </summary>
		public int GroupCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public JPermissionGroupUsers[] Items;
		#endregion

		/// <summary>
		///  سازنده کلاس
		/// </summary>
		/// <param name="pUserCode"></param>
		public JPermissionsGroupUsers(int pGroupCode)
		{
			GroupCode = pGroupCode;
		}
		//		/// <summary>
		//		/// کاربرانی که مجوز این تصمیم را دارند (برای کاربری خاص)
		//		/// </summary>
		//		/// <param name="pDecisionCode"></param>
		//		/// <returns></returns>
		//		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery, int GroupHasPermission)
		//		{
		//			string Query = "";
		//			if (pObjectsQuery.Trim() == "")
		//				Query = @" SELECT Code ,HasPermission
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code) UserPermissionName
		//                  FROM [PermissionUser] PU";
		//			else
		//				Query = @"Select PU.Code
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
		//					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code";
		//			JDataBase DB = JGlobal.MainFrame.GetDBO();
		//			try
		//			{
		//				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode + " AND  PU.User_Post_Code = " + GroupHasPermission.ToString());
		//				return DB.Query_DataTable();
		//			}
		//			catch (Exception ex)
		//			{
		//				Except.AddException(ex);
		//				return null;
		//			}
		//			finally
		//			{
		//				DB.Dispose();
		//			}
		//		}        /// <summary>
		//		/// کاربرانی که مجوز این تصمیم را دارند
		//		/// </summary>
		//		/// <param name="pDecisionCode"></param>
		//		/// <returns></returns>
		//		public static DataTable GetUsers(int pDecisionCode, string pObjectsQuery)
		//		{
		//			string Query = "";
		//			if (pObjectsQuery.Trim() == "")
		//				Query = @" SELECT Code ,HasPermission
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                  FROM [PermissionUser] PU ";
		//			else
		//				Query = @"Select PU.Code
		//                    ,(Select Full_Title From VOrganizationChart Where Code = User_Post_Code ) UserPermissionName
		//                    , objPermissions.Name  from PermissionUser PU Inner Join ( " +
		//					pObjectsQuery + " ) objPermissions on PU.ObjectCode = objPermissions.Code ";
		//			JDataBase DB = JGlobal.MainFrame.GetDBO();
		//			try
		//			{
		//				DB.setQuery(@Query + " WHERE PU.DecisionCode = " + pDecisionCode);
		//				return DB.Query_DataTable();
		//			}
		//			catch (Exception ex)
		//			{
		//				Except.AddException(ex);
		//				return null;
		//			}
		//			finally
		//			{
		//				DB.Dispose();
		//			}
		//		}
		/// <summary>
		/// جستجوی کد مجوزهای گروه بر اساس کد گروه
		/// </summary>
		/// <returns></returns>
		public Boolean GetData()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT Code FROM PermissionGroupUsers WHERE GroupCode=" + GroupCode.ToString());

				DB.Query_DataReader();
				Items = new JPermissionGroupUsers[DB.RecordCount];
				int count = 0;
				while (DB.DataReader.Read())
				{
					Items[count] = new JPermissionGroupUsers();
					Items[count].GetData(int.Parse(DB.DataReader["Code"].ToString()));
					count++;
				}
				return true;
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


	}
	#endregion
}
