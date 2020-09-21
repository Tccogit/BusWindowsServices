using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JException 
    {

        public int Count
        {
            get
            {
				return _exceptions.Count;
            }
        }


        public string ToString()
        {
			try
			{
				lock (listLock)
				{
					return _exceptions.Last().Message;
				}
			}
			catch
			{
				return "";
			}
        }

		public static List<Exception> Exceptions
		{
			get
			{
				try
				{
					return JSystem.Except._exceptions;
				}
				catch
				{
					return null;
				}
			}
		}

		List<Exception> _exceptions = new List<Exception>();
		private readonly object listLock = new object();

        /// <summary>
        /// افزودن استثناء به استثناهای برنامه
        /// </summary>
        /// <param name="ex"></param>
        public void AddException(Exception ex)
        {
            try
            {
                //lock (listLock)
                {
                    JExceptionTable ET = new JExceptionTable();
                    ET.PostCode = JMainFrame.CurrentPostCode;
                    ET.Message = ex.Message;
                    ET.Source = ex.Source;
                    ET.StackTrace = ex.StackTrace;
                    ET.HelpLink = ex.HelpLink;
                    ET.InsertDate = DateTime.Now;
                    ET.InsertException(0, true);

                    if (JMainFrame.IsWeb())
                    {
                        return;
                    }
                    else
                    {
                        _exceptions.Add(ex);
                    }
                }
            }
            catch
            {
            }
        }

        public void NewException(string message)
        {
            NewException(message, false);
        }

        public void NewException(string message, bool RunThrow)
        {
            Exception ex = new ArgumentException(message);
            AddException(ex);
            if (RunThrow)
            {
                throw ex;
            }
        }

        public void EmptyExceptions()
        {
			lock (listLock)
			{
				_exceptions.Clear();
			}
        }

		public Exception GetByIndex(int i)
		{
			lock (listLock)
			{
				if (i > _exceptions.Count)
					return null;
				return _exceptions[i];
			}
		}

		public string[] GetAll()
		{
			string[] Res = new string[_exceptions.Count];
			int icount=0;
			foreach (Exception ex in _exceptions)
			{
				Res[icount++] = ex.Message;
			}
			return Res;
		}
    }
    
}
