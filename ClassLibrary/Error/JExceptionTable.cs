using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	public class JExceptionTable: JTable
	{

		public int PostCode;
		public string Message;
		public string Source;
		public string StackTrace;
		public string HelpLink;
        public DateTime InsertDate;

		public JExceptionTable()
			: base("ExceptionTable")
		{

		}
	}
}
