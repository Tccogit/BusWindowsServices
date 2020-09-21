using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Permission
{
	public class JPermissionDefineControl
	{
		public int Code { get; set; }
		public string PermissionName { get; set; }

		private static System.Data.DataTable PermissionDefineControl;
		public int Insert()
		{
			int _Index = Find(PermissionName);
			if (_Index > 0)
				return _Index;
			else
			{
				PermissionDefineControl.Clear();
				PermissionDefineControl = null;
			}
			Permission.JPermissionDefineControlTable PDT = new Permission.JPermissionDefineControlTable();
			PDT.SetValueProperty(this);
			return PDT.Insert();
		}

		public int Find(String pPermissionName)
		{
			if (PermissionDefineControl == null)
			{
				JDataBase DB = new JDataBase();
				try
				{
					DB.setQuery("select * from PermissionDefineControl");
					PermissionDefineControl = DB.Query_DataTable();
				}
				catch
				{
					return 0;
				}
				finally
				{
					DB.Dispose();
				}
			}

			System.Data.DataRow[] Rows = PermissionDefineControl.Select("PermissionName='" + pPermissionName + "'");
			if (Rows.Length > 0)
			{
				return (int)Rows[0]["Code"];
			}
			else
			{
				return 0;
			}

		}

	}

	public class JPermissionDefineControls
	{
		public static System.Data.DataTable GetData()
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select * from PermissionDefineControl order by PermissionName");
				return DB.Query_DataTable();
			}
			catch
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}
	}
}

