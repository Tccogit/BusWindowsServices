using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Globals.Property;
using System.Windows.Forms;
using Automation;

namespace ClassLibrary
{
    public class FormManagers
    {
        public FormManagers()
        {
        }

        public void ReferShow(int valueObjectCode, int referCode)
        {
            (new ClassLibrary.FormObjectViewForm(valueObjectCode, referCode)).ShowDialog();
        }

        public string GetFromQueryForReport(int FormCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                JForms form = new JForms(FormCode);
                string sql = form.SQL;
                //if (sql == "") sql = "Select * from [Propperty_ClassName_ClassLibrary.FormManagers_1000018]";
                string TableName = (new Globals.Property.JProperties(form.ClassName, FormCode)).TableName;
                string query = @"SELECT 
                                  COLUMN_NAME
                                  ,DATA_TYPE
                                FROM   
                                  INFORMATION_SCHEMA.COLUMNS 
                                WHERE   
                                  TABLE_NAME = '{TABLE_NAME}' 
                                ORDER BY 
                                  ORDINAL_POSITION ASC; ";
                query = query.Replace("{TABLE_NAME}", TableName.Replace("[", "").Replace("]", ""));
                db.setQuery(query);
                DataTable tmp = db.Query_DataTable();
                List<string> ColumnNames = new List<string>();
                ColumnNames.Add("RegistaerUser");
                query = "(select username from users where code in (select user_code from organizationchart where code =  f.[RegisterPostCode])) RegistaerUser";
                foreach (DataRow dr in tmp.Rows)
                {
                    if (dr["DATA_TYPE"].ToString() == "datetime" || dr["DATA_TYPE"].ToString() == "date")
                        query += ", (Select Fa_Date from StaticDates where En_Date = CAST(f.[" + dr["COLUMN_NAME"].ToString() + "] as DATE)) as [" + dr["COLUMN_NAME"].ToString() + "]";
                    else
                        query += ", f.[" + dr["COLUMN_NAME"].ToString() + "]";
                    ColumnNames.Add(dr["COLUMN_NAME"].ToString());
                }



                DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("Select TOP 0 * from (" + sql.Replace("@ObjectCode", "-1") + ") tbl ", false, db);
                if (dt == null)
                {
                    if (query.IndexOf("where") > 0)
                        dt = WebClassLibrary.JWebDataBase.GetDataTable(query.Replace("where", "where 1<>0 and "), false, db);
                    else
                        dt = WebClassLibrary.JWebDataBase.GetDataTable(query.Replace("order by", " where 1<>0 order by "), false, db);
                }
                db.Dispose();

                foreach (DataColumn dc in dt.Columns)
                {
                    if (ColumnNames.Contains(dc.ColumnName))
                        query += ", a.[" + dc.ColumnName + "] " + dc.ColumnName + "1";
                    else
                        query += ", a.[" + dc.ColumnName + "]";
                }
                //query = query.Substring(1);




                query = "Select " + query  + " From " + TableName + " f OUTER APPLY ( " +
                    sql.Replace("@ObjectCode", "(select ObjectCode from FormObjects WHERE Code = f.ObjectCode)") + ") as a";
                return query;
                db.Dispose();
                db = new JDataBase();
                db.setQuery(query);
                dt = db.Query_DataTable();

                query = "";
                if ((dt.Rows.Count > 0) && (sql != ""))
                {
                    db.setQuery(sql.Replace("@ObjectCode", "-1"));
                    DataTable dt2 = db.Query_DataTable();
                    foreach (DataColumn dc in dt2.Columns)
                    {
                        string caption = dc.Caption;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (caption.ToLower() == dt.Columns[i].Caption.ToLower())
                            {
                                caption = caption + "1";
                            }
                        }
                        query += "," + caption;
                    }
                }
                query = query.Substring(1);
                query = "Select " + query + " From " + TableName + " f OUTER APPLY ( " +
                    sql.Replace("@ObjectCode", "(select ObjectCode from FormObjects WHERE Code = f.ObjectCode)") + ") as a";
                //db = new JDataBase();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //	JFormObjects jFormObjects = new JFormObjects(Convert.ToInt32(dt.Rows[i]["ObjectCode"]));
                //	if (jFormObjects.Code > 0)
                //	{
                //		query = sql.Replace("@ObjectCode", jFormObjects.ObjectCode.ToString());
                //	}
                //	else
                //	{
                //		query = sql.Replace("@ObjectCode", "-1");
                //	}
                //	db.setQuery(query);
                //	DataTable cDataTable = db.Query_DataTable();
                //	if ((cDataTable != null) && (cDataTable.Rows.Count == 0)) cDataTable.Rows.Add(cDataTable.NewRow());
                //	if (cDataTable != null)
                //	{
                //		int startColumnIndex = dt.Columns.Count - cDataTable.Columns.Count;
                //		for (int j = 0; j < cDataTable.Columns.Count; j++)
                //		{
                //			dt.Rows[i][startColumnIndex + j] = cDataTable.Rows[0][j];
                //		}
                //	}
                //}

                //dt.Columns.Add("FormCode");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i]["FormCode"] = FormCode.ToString();
                //}


            }
            finally
            {
                db.Dispose();
            }
            return "";
        }

        public void GetFromManager(int FormCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = (new JForms(FormCode)).SQL;
                //if (sql == "") sql = "Select * from [Propperty_ClassName_ClassLibrary.FormManagers_1000018]";
                string TableName = (new Globals.Property.JProperties("ClassLibrary.FormManagers", FormCode)).TableName;
                string query = @"SELECT 
                                  COLUMN_NAME
                                  ,DATA_TYPE
                                FROM   
                                  INFORMATION_SCHEMA.COLUMNS 
                                WHERE   
                                  TABLE_NAME = '{TABLE_NAME}' 
                                ORDER BY 
                                  ORDINAL_POSITION ASC; ";
                query = query.Replace("{TABLE_NAME}", TableName.Replace("[", "").Replace("]", ""));
                db.setQuery(query);
                DataTable tmp = db.Query_DataTable();
                query = "(select username from users where code in (select user_code from organizationchart where code =  f.[RegisterPostCode])) RegistaerUser";
                foreach (DataRow dr in tmp.Rows)
                {
                    if (dr["DATA_TYPE"].ToString() == "datetime" || dr["DATA_TYPE"].ToString() == "date")
                        query += ", (Select Fa_Date from StaticDates where En_Date = CAST(f.[" + dr["COLUMN_NAME"].ToString() + "] as DATE)) as [" + dr["COLUMN_NAME"].ToString() + "]";
                    else
                        query += ", f.[" + dr["COLUMN_NAME"].ToString() + "]";
                }
                //query = query.Substring(1);
				query = "Select " + query + ",a.* From " + TableName + " f OUTER APPLY ( " +
					sql.Replace("@ObjectCode", "(select ObjectCode from FormObjects WHERE Code = f.ObjectCode)") + ") as a";
                db.Dispose();
                db = new JDataBase();
                db.setQuery(query);
                DataTable dt = db.Query_DataTable();

                query = "";
				if ((dt.Rows.Count > 0) && (sql != ""))
				{
					db.setQuery(sql.Replace("@ObjectCode", "-1"));
					DataTable dt2 = db.Query_DataTable();
					foreach (DataColumn dc in dt2.Columns)
					{
						string caption = dc.Caption;
						for (int i = 0; i < dt.Columns.Count; i++)
						{
							if (caption.ToLower() == dt.Columns[i].Caption.ToLower())
							{
								caption = caption + "1";
							}
						}
						dt.Columns.Add(caption);
					}
				}
                db.Dispose();
				//db = new JDataBase();
				//for (int i = 0; i < dt.Rows.Count; i++)
				//{
				//	JFormObjects jFormObjects = new JFormObjects(Convert.ToInt32(dt.Rows[i]["ObjectCode"]));
				//	if (jFormObjects.Code > 0)
				//	{
				//		query = sql.Replace("@ObjectCode", jFormObjects.ObjectCode.ToString());
				//	}
				//	else
				//	{
				//		query = sql.Replace("@ObjectCode", "-1");
				//	}
				//	db.setQuery(query);
				//	DataTable cDataTable = db.Query_DataTable();
				//	if ((cDataTable != null) && (cDataTable.Rows.Count == 0)) cDataTable.Rows.Add(cDataTable.NewRow());
				//	if (cDataTable != null)
				//	{
				//		int startColumnIndex = dt.Columns.Count - cDataTable.Columns.Count;
				//		for (int j = 0; j < cDataTable.Columns.Count; j++)
				//		{
				//			dt.Rows[i][startColumnIndex + j] = cDataTable.Rows[0][j];
				//		}
				//	}
				//}

                dt.Columns.Add("FormCode");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["FormCode"] = FormCode.ToString();
                }

                JSystem.Nodes.ObjectBase = new JAction("ShowFormManager", "ClassLibrary.FormManagers.GetNode");
                JSystem.Nodes.DataTable = dt;


            }
            finally
            {
                db.Dispose();
            }
        }

        public void ShowFormManager(int FormCode, int ObjectCode, int Code)
        {
            JFormObjects jFormObjectss = new JFormObjects(ObjectCode);
            FormObjectViewForm p = new FormObjectViewForm(FormCode, jFormObjectss.ObjectCode, ObjectCode);
            if ((p.ShowDialog() == DialogResult.OK) && (ObjectCode == 0))
            {
                ShowFormManager(FormCode, ObjectCode, Code);
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.FormManagers");
            //Node.Name = pRow["Full_Title"].ToString();
            //Node.Icone = JImageIndex.land.GetHashCode();

            JAction newAction = new JAction("New...", "ClassLibrary.FormManagers.ShowFormManager", new object[] {  Convert.ToInt32(pRow["FormCode"]), 0 ,0}, null);                
                Node.MouseDBClickAction = newAction;
            Node.Popup.Insert(newAction);
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.FormManagers.ShowFormManager", new object[] { Convert.ToInt32(pRow["FormCode"]), Convert.ToInt32(pRow["ObjectCode"]), Convert.ToInt32(pRow["Code"]) }, null);
            Node.MouseDBClickAction = editAction;
            Node.Popup.Insert(editAction);
            return Node;
        }

        public void ListView()
        {
            //JSystem.Nodes.ObjectBase = new JAction("GetFrom", "");
            //JSystem.Nodes.DataTable = GetFromManager(0);

            JAction newAction = new JAction("New...", "", null, null);
            JSystem.Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            JSystem.Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }


        public static DataTable GetData(int _ValueObjectCode)
        {
            string _ConstClassName = "ClassLibrary.FormManagers";

            JFormObjects jFormObjects = new JFormObjects(_ValueObjectCode);
            int _FormCode = jFormObjects.FormCode;
            int _ObjectCode = jFormObjects.ObjectCode;

            DataTable _DataTable = (new JForms(_FormCode)).GetSQL(_ObjectCode);

            if (_DataTable == null) return null;

            DataTable dt = (new JProperties(_ConstClassName, _FormCode)).GetPropertyTableDataForPrint(_ValueObjectCode);
            if (dt.Columns.IndexOf("Code") > -1)
            {
                dt.Columns["Code"].ColumnName = "PropPertyKeyCode";
            }
            DataTable NewDataTable = JTable.Join(_DataTable, dt);

            // Add SQL Fileds To DataTable
            JDataBase db = new JDataBase();
            try
            {
                JProperties jProperties = new JProperties(_ConstClassName, _FormCode);
                DataTable Fields = jProperties.GetDataTable();
                foreach (DataRow Field in Fields.Rows)
                {
                    if (Field["DataType"].ToString() == JSQLDataType.اس_کیو_ال.ToString())
                    {
                        string _SQL = Field["List"].ToString();
                        db.setQuery(_SQL);
                        DataTable PropertyData = db.Query_DataTable();
                        // Add Columns To NewDataTable
                        foreach (DataColumn PropertyDataColumn in PropertyData.Columns)
                        {
                            string columnName = Field["Name"] + "_" + PropertyDataColumn.ColumnName;
                            if (NewDataTable.Columns.IndexOf(columnName) < 0)
                                NewDataTable.Columns.Add(columnName);
                        }
                        // Update new columns with PropertData
                        foreach (DataRow _NDR in NewDataTable.Rows)
                        {
                            DataRow[] _DR = null;
                            try
                            {
                                _DR = PropertyData.Select("Code = '" + _NDR[Field["Name"].ToString().Replace(" ", "__")] + "'");
                            }
                            catch
                            {
                            }
                            foreach (DataColumn PropertyDataColumn in PropertyData.Columns)
                            {
                                string columnName = Field["Name"] + "_" + PropertyDataColumn.ColumnName.Replace(" ", "__");
                                if (NewDataTable.Columns.IndexOf(columnName) < 0)
                                    NewDataTable.Columns.Add(columnName);

                                if (_DR != null && _DR.Length == 1)
                                {
                                    if (PropertyDataColumn.ColumnName.ToLower() == "title" && _DR[0][PropertyDataColumn.ColumnName].ToString().Trim() == "")
                                        _NDR[columnName] = _NDR[Field["Name"].ToString().Replace(" ", "__")];
                                    else
                                        _NDR[columnName] = _DR[0][PropertyDataColumn.ColumnName];

                                }
                                else
                                {
                                    if (PropertyDataColumn.ColumnName.ToLower() == "title")
                                        _NDR[columnName] = _NDR[Field["Name"].ToString().Replace(" ", "__")];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            // Add FormObject Fileds To DataTable
            JFormObjects jFormObject = new JFormObjects(_ValueObjectCode);
            NewDataTable.Columns.Add("FormObject.Date");
            NewDataTable.Columns.Add("FormObject.Description");
            //NewDataTable.Rows[0]["FormObject.Date"] = JDateTime.FarsiDate(jFormObject.Date);
            //NewDataTable.Rows[0]["FormObject.Description"] = jFormObject.Description;

            for (int i = 0; i < NewDataTable.Rows.Count; i++)
            {
                NewDataTable.Rows[i]["FormObject.Date"] = JDateTime.FarsiDate(jFormObject.Date);
                NewDataTable.Rows[i]["FormObject.Description"] = jFormObject.Description;
            }

            return NewDataTable;            
        }

        public Panel GetPanel(int pDynamicClassCode, int pObjectCode,int pReferCode)
        {
            Automation.JKartable tmpK = new JKartable();
			if (!tmpK.SaveViewDate(pReferCode))
			{
			}

            Panel p = new Panel();
            p.Size = new System.Drawing.Size(932, 90);
            p.AutoScroll = true;
            //JForms F = new JForms(pDynamicClassCode);
            //if((F.SQL != "") && (F.SQL.Contains("@ObjectCode")))
            {
                JDataBase db = new JDataBase();
                try
                {
                    JProperties PT = new JProperties("ClassLibrary.FormManagers", pDynamicClassCode);
                    //JFormObjects FO = new JFormObjects(pObjectCode);
                    //db.setQuery(F.SQL.Replace("@ObjectCode", FO.ObjectCode.ToString()));
                    JDataGrid DG = new JDataGrid();
                    DG.DataSource = PT.GetPropertyTableDataForPrint(pObjectCode);
                    DG.Dock = DockStyle.Fill;
                    DG.BackColor = System.Drawing.Color.AntiqueWhite;
                    p.Controls.Add(DG);
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
            return p;
        }
    }
}
