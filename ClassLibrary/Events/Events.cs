using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JEvents
    {
        public int Code { get; set; }
        public string EventName { get; set; }
        public string EventAction { get; set; }
        
        /// <summary>
        /// اجرای رویداد ثبت شده در دیتابیس
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pParams"></param>
        public static void Run(string pName,JDataBase pDB, object[] pParams)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string eventAction = "";
                DB.setQuery("SELECT * FROM events WHERE ename = " + JDataBase.Quote(pName));
                while (DB.DataReader.Read())
                {
                    eventAction = DB.DataReader["eaction"].ToString();
                    JAction action = new JAction(pName, eventAction, pParams, null);
                    action.run();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static void Add(string pName, string pAction)
        {
            JEventTable table = new JEventTable();
            JEvents evnt = new JEvents();
            evnt.EventName = pName;
            evnt.EventAction = pAction;
            table.SetValueProperty(evnt);
            table.Insert();
        }

        public static void Delete(string pName, string pAction)
        {
            JEventTable table = new JEventTable();
            JEvents evnt = new JEvents();
            evnt.Code = Find(pName, pAction);
            table.SetValueProperty(evnt);
            table.Insert();
        }

        private static int Find(string pName, string pAction)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT code FROM Events WHERE ename = " + JDataBase.Quote(pName)
                    + " AND eaction = " + JDataBase.Quote(pAction));
                if (DB.DataReader.Read())
                    return Convert.ToInt32(DB.DataReader[0]);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
