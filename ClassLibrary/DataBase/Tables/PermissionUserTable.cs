using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	public class JPermissionUserTable : JTable
	{
		public int DecisionCode;
		//public int DefineClassCode;
		public int ObjectCode;
		public int User_Post_Code;
		public bool HasPermission;
		public int Creator;
		public DateTime Start_Date;
		public DateTime End_Date;

		public JPermissionUserTable()
			: base(JTableNamesPermission.PermissionUser)
		{
		}
	}

	public enum PermissionUser
	{
		Code,
		DecisionCode,
		//DefineClassCode,
		ObjectCode,
		User_post_Code,
		HasPermission,
		Creator,
		Start_Date,
		End_Date,
	}
	#region Group
	public class JPermissionGroupTable : JTable
	{
		public int DecisionCode;
		public int ObjectCode;
		public int GroupCode;
		public bool HasPermission;
		public int Creator;
		public DateTime Start_Date;
		public DateTime End_Date;

		public JPermissionGroupTable()
			: base(JTableNamesPermission.PermissionGroup)
		{
		}
	}

	public enum PermissionGroup
	{
		Code,
		DecisionCode,
		ObjectCode,
		GroupCode,
		HasPermission,
		Creator,
		Start_Date,
		End_Date,
	}

	public class JPermissionGroupUsersTable : JTable
	{
		public int GroupCode;
		public int User_Post_Code;

		public JPermissionGroupUsersTable()
			: base(JTableNamesPermission.PermissionGroupUsers)
		{
		}
	}

	public enum PermissionGroupUsers
	{
		Code,
		GroupCode,
		User_Post_Code
	}
	#endregion
}
