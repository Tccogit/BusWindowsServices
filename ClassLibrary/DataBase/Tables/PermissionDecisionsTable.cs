using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	public class JPermissionDecisionsTable : JTable
	{
		public String Name;
		public int PermissionDefineCode;
		public bool DefaultValue;

		public JPermissionDecisionsTable()
			: base(JTableNamesPermission.PermissionDecision)
		{
		}
	}

	public enum PermissionDecision
	{
		Code,
		Name,
		PermissionDefineCode,
		DefaultValue,
	}
	#region Group
	public class JPermissionDecisionGroupsTable : JTable
	{
		public String Name;
		public int PermissionDefineGroupClassCode;
		public bool DefaultValue;

		public JPermissionDecisionGroupsTable()
			: base(JTableNamesPermission.PermissionDecisionGroup)
		{
		}
	}

	public enum PermissionDecisionGroup
	{
		Code,
		Name,
		PermissionDefineGroupClassCode,
		DefaultValue,
	}
	#endregion
}
