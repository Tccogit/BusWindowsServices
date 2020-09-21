using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Globals.Property;

namespace ClassLibrary
{
    public class JForms
    {
        #region Constructor
        public JForms()
        {
        }
        public JForms(int FormCode)
        {
            GetData(FormCode);
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public string ClassName { get; set; }
        public string FormName { get; set; }
        public string SQL { get; set; }
        public int user_code { get; set; }
        public DateTime Date { get; set; }
        public bool isMultiple { get; set; }
        public string Action { get; set; }
        #endregion

        #region Method
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JFormsTable jFormsTable = new JFormsTable();
                jFormsTable.SetValueProperty(this);
                int code = jFormsTable.Insert(db);
                return code;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                JFormsTable jFormsTable = new JFormsTable();
                jFormsTable.SetValueProperty(this);
                if (jFormsTable.Update())
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                JFormsTable jFormsTable = new JFormsTable();
                jFormsTable.SetValueProperty(this);
                JProperty jProperty = new JProperty();
                if (jProperty.DeleteByObjectCode("ClassLibrary.FormManagers", Code)) // Deleting Properties and Table
                    if (jFormsTable.Delete()) // Delete Form
                        return true;
                    else
                        return false;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        #region GetData

        public static DataTable GetListForm(string className = "")
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * FROM Forms Where " + (className == "" ? "" : "ClassName = '" + className + "' AND ") + JPermission.getObjectSql("ClassLibrary.JForms.GetListForm", "Code"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetDataTable(string className)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT frm.*, 
(select clsAllPerson.Name from users inner join clsAllPerson on 
clsAllPerson.Code = users.pcode where users.code = frm.user_code) 
as user_name FROM Forms as frm Where frm.ClassName = '" + className + "' And "
                + JPermission.getObjectSql("ClassLibrary.JForms.GetDataTable") +
                " ORDER BY FormName");
                //DataTable dt = db.Query_DataTable();
                //foreach (DataRow dr in dt.Rows)
                //    dr["Date"] = JDateTime.FarsiDate(Convert.ToDateTime(dr["Date"]));
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void GetData(int code)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM Forms Where Code = '" + code + "'");
                db.Query_DataReader();
                if (db.DataReader.Read())
                    JTable.SetToClassProperty(this, db.DataReader);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetSQL(int ObjectCode)
        {
            if (String.IsNullOrEmpty(SQL)) return null;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From ( " + SQL.Replace("@ObjectCode", ObjectCode.ToString()) + " ) tbl1");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        public JNode[] GetFormNode(JAction pChildAction)
        {
            DataTable DT = JForms.GetListForm();

            JNode[] TNodes = new JNode[DT.Rows.Count];
            int count = 0;
            object[] BaseObj = pChildAction.Arg;
            foreach (DataRow DR in DT.Rows)
            {
				JNode N = new JNode((int)DR["Code"], "ClassLibrary.FormManagers" + DR["Code"].ToString());
                N.Name = (string)DR["FormName"];

                object[] tempObj = BaseObj;
                if (BaseObj != null)
                {
                    Array.Resize(ref tempObj, tempObj.Length + 1);
                    tempObj[tempObj.Length - 1] = new object[] { (int)DR["Code"] };
                }
                else
                {
                    tempObj = new object[] { (int)DR["Code"] };
                }
				JAction tempAction = new JAction(pChildAction.Name + DR["Code"].ToString(), pChildAction.ActionCommand, tempObj, pChildAction.ConstArg, pChildAction.CleareList);
                N.MouseClickAction = tempAction;
                N.MouseDBClickAction = tempAction;

				JAction newAction = new JAction("New...", "ClassLibrary.FormObjectViewForm" + DR["Code"].ToString(), new object[] { DR["ClassName"], (int)DR["Code"], 0 }, null);
                //N..Nodes.GlobalMenuActions.Insert(newAction);
                JToolbarNode TN = new JToolbarNode();
                TN.Icon = JImageIndex.Add;
                TN.Hint = "New...";
                TN.Click = newAction;
                N.AddToolbar(TN);

                TNodes[count++] = N;
            }

            return TNodes;
        }

    }
}
