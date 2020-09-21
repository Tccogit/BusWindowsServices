using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.ApplicationManager
{
	public class JProject : JSystem
	{
		public int Code { get; set; }
		public int PCode { get; set; }
		public int BankCode { get; set; }
		public string Branch { get; set; }
		public int AccountType { get; set; }
		public string AccountNo { get; set; }
		public string SHEBA { get; set; }
		public string CardNo { get; set; }

		public JProject()
		{
		}
		//public JProject(int Code)
		//{
		//	if (Code > 0)
		//		GetData(Code);
		//}
		public int Insert()
		{
			JProjectTable PT = new JProjectTable();
			PT.SetValueProperty(this);
			Code = PT.Insert();
			return Code;
		}

		public bool Delete()
		{
			JProjectTable PT = new JProjectTable();
			PT.SetValueProperty(this);
			if (PT.Delete())
			{
				Nodes.Delete(Nodes.CurrentNode);
				return true;
			}
			else return false;
		}
		public bool Update()
		{
			JProjectTable PT = new JProjectTable();
			PT.SetValueProperty(this);
			return (PT.Update());
		}

		public bool GetData()
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select * from Projects ORDER BY Code Desc ");
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
	}
}
