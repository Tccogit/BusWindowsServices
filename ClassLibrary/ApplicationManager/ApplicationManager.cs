using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace ClassLibrary
{
    public class JApplicationManager
    {
        public int Code;
        public String Name;
        public string ClassName;
        public String Action;
        public String ActionChilds;
        public int ParentCode;
        public int Ordered;

        public JNode GetNode()
        {
            string[] temp = Action.Split('.');
            Array.Resize(ref temp, temp.Length - 1);
            JNode N = new JNode(0, string.Join(".", temp));
            N.Name = Name;

            JAction ActionClick = new JAction(Name, Action, null, null, true);
            N.MouseClickAction = ActionClick;
            N.MouseDBClickAction = ActionClick;

            JAction ActionChild = new JAction(Name, ActionChilds);
            N.ChildsAction = ActionChild;
            return N;
        }
    }

    public class JApplicationsManager
    {
        JApplicationManager[] Items = new JApplicationManager[0];
        public static JNode[] ANodes;

        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " Where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"SELECT * FROM Applications " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public JApplicationsManager()
        {
        }

        public JNode[] GetNods()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (ANodes == null)
                {
                    DB.setQuery("SELECT * FROM Applications WHERE  " + JPermission.getObjectSql(this.GetType().FullName + ".GetNods") + " AND Show=1 ORDER BY Ordered");
                    if (DB.Query_DataReader())
                        while (DB.DataReader.Read())
                        {
                            Array.Resize(ref Items, Items.Length + 1);
                            Items[Items.Length - 1] = new JApplicationManager();
                            JTable.SetToClassField(Items[Items.Length - 1], DB.DataReader);
                        }

                    int Counter = 0;
                    ANodes = new JNode[Items.Length];
                    foreach (JApplicationManager AM in Items)
                    {
                        ANodes[Counter++] = AM.GetNode();
                    }
                    DB.Dispose();
                }
                return ANodes;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public string appPath
        {
            get
            {
                return Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            }

        }

        public void UpdateVersion(int pCode, string pVersion)
        {
            JDataBase pDB = new JDataBase();
            try
            {
                pDB.setQuery("Update Applications Set Version='" + pVersion + "' WHERE Code=" + pCode.ToString());
                pDB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                pDB.Dispose();
            }
        }

        public string CheckVersion()
        {
            try
            {
                Assembly asm = null;
                foreach (DataRow dr in GetDataTable().Rows)
                {
                    if (System.IO.File.Exists(appPath + "\\" + dr["Name"].ToString() + ".dll"))
                    {
                        asm = Assembly.LoadFrom(appPath + "\\" + dr["Name"].ToString() + ".dll");
                        if (!(dr["Version"].ToString() == asm.GetName().Version.ToString()))
                        {
                            return dr["Name"].ToString() + ".dll";
                        }
                        else
                        {
                            //var attribute = (System.Runtime.InteropServices.GuidAttribute)asm.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true)[0];
                            //var _GUID = attribute.Value;
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }
    }

}
