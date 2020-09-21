using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.ApplicationManager
{
	public class JProjectTable : JTable
	{
		public int PCode;
		public int BankCode;
		public string Branch;
		public int AccountType;
		public string AccountNo;
		public string SHEBA;
		public string CardNo;

		public JProjectTable()
			: base("Projects")
		{
		}
	}
}
