using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	public class JPermissionDefineClassTable : JTable
	{
		public String ClassName;
		public String SQL;
		public int ParentCode;

		public JPermissionDefineClassTable()
			: base(JTableNamesPermission.PermissionDefineClass)
		{
		}
	}

	public enum PermissionDefineClass
	{
		Code,
		ClassName,
		SQL,
		ParentCode,
	}

	#region Group
	public class JPermissionDefineGroupTable : JTable
	{
		public String GroupName;

		public JPermissionDefineGroupTable()
			: base(JTableNamesPermission.PermissionDefineGroup)
		{
		}
	}

	public enum PermissionDefineGroup
	{
		Code,
		GroupName,
	}

	public class JPermissionDefineGroupClassTable : JTable
	{
		public String GroupName;
		public String SQL;
		public int ParentCode;
		public int GroupCode;

		public JPermissionDefineGroupClassTable()
			: base(JTableNamesPermission.PermissionDefineGroupClass)
		{
		}
	}

	public enum PermissionDefineGroupClass
	{
		Code,
		GroupName,
		SQL,
		ParentCode,
		GroupCode
	}
	#endregion
}
