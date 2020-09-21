using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Permission
{
	public class JPermissionDefineControlTable:JTable
	{
		public JPermissionDefineControlTable()
			: base("PermissionDefineControl")
		{
		}

		public string PermissionName;
	}
}
