using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            JAction ActionClick = new JAction(Name,Action,null,null,true);
            N.MouseClickAction = ActionClick;
            N.MouseDBClickAction = ActionClick;

            JAction ActionChild = new JAction(Name,ActionChilds);
            N.ChildsAction= ActionChild;
            return N;
        }
    }

    public class JApplicationsManager
    {
        JApplicationManager[] Items = new JApplicationManager[0];
        public static JNode[] ANodes;

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
                    DB.setQuery("SELECT * FROM Application WHERE  "+JPermission.getObjectSql(this.GetType().FullName+".GetNods")+" ORDER BY Ordered");
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
    }

}
