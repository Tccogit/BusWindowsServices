using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Globals.Property;

namespace ClassLibrary
{
	public class JFormObjects
	{
		#region Constructor
		public JFormObjects()
		{
		}
		public JFormObjects(int FormObjectCode)
		{
			GetData(FormObjectCode);
		}
		#endregion

		#region Properties
		public int Code { get; set; }
		public int FormCode { get; set; }
		public int ObjectCode { get; set; }
		public DateTime Date { get; set; }
		public string Comment { get; set; }
		public string Description { get; set; }
		public int NoStorage { get; set; }

		public JForms Form
		{
			get
			{
				return new JForms(this.FormCode);
			}
		}

		#endregion

		#region Method
		public int Insert(JDataBase pdb)
		{
			JDataBase db;
			if (pdb == null)
				db = new JDataBase();
			else
				db = pdb;
			try
			{
				int MaxCode = 0;
				db.setQuery("Select MAX(Code) MCode FROM FormObjects");
				db.Query_DataReader();
				if (db.DataReader.Read())
				{
					if (db.DataReader[0] != DBNull.Value)
						MaxCode = Convert.ToInt32(db.DataReader[0]) + 1;
					else
						MaxCode = 1;
				}

				db.setQuery("INSERT INTO FormObjects(Code, FormCode, ObjectCode, Comment) VALUES(" + MaxCode + " ," + this.FormCode + ", " + this.ObjectCode + ", N'" + Comment + "')");
				if (db.Query_Execute() >= 0)
					return MaxCode;
				else
					return 0;
			}
			finally
			{
				if (pdb == null)
					db.Dispose();
			}
		}

		public bool Update()
		{
			JDataBase db = new JDataBase();
			try
			{
				JFormObjectsTable jFormsTable = new JFormObjectsTable();
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

		public void Update(int formObjectCode, string comment, string description)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Update FormObjects SET Comment = N'" + comment.Replace("'", "''") + "', Description = N'" + description.Replace("'", "''") + "' WHERE Code = " + formObjectCode.ToString());
				db.Query_Execute();
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
				JProperties jProperties = new JProperties("ClassLibrary.FormManagers", FormCode);
				db.setQuery("Delete From " + jProperties.TableName + " WHERE ObjectCode = " + Code);
				db.Query_Execute();
				JFormObjectsTable jFormsTable = new JFormObjectsTable();
				//jFormsTable.SetValueProperty(this);
				db.setQuery("Delete From FormObjects Where Code = " + this.Code);
				if (db.Query_Execute() >= 0)
					return true;
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
		private void GetData(int FormObjectCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("SELECT * FROM FormObjects Where Code = '" + FormObjectCode + "'");
				db.Query_DataReader();
				if (db.DataReader.Read())
					JTable.SetToClassProperty(this, db.DataReader);
			}
			finally
			{
				db.Dispose();
			}
		}

		public DataTable GetDataTable(int formCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("SELECT * FROM FormObjects Where FormCode = " + formCode + "");
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

		public DataTable GetMultipleObjectTable(int formCode, int objectCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("SELECT Code as [ObjectCode], ObjectCode as [ListObjectCode], (select Fa_Date From StaticDates where En_Date = CAST([Date] as date)) as [Date], Comment FROM FormObjects Where FormCode = " + formCode + " AND ObjectCode = " + objectCode);
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

		public DataTable GetObjectTable(int formCode, int objectCode, string pClassName = "ClassLibrary.FormManagers")
		{
			JForms jForms = new JForms(formCode);
			if (jForms.isMultiple == true)
				return GetMultipleObjectTable(formCode, objectCode);
			JDataBase db = new JDataBase();
			try
			{
				JProperties jProperties = new JProperties(pClassName, formCode);
				string query = @"SELECT 
                                  COLUMN_NAME
                                  ,DATA_TYPE
                                FROM   
                                  INFORMATION_SCHEMA.COLUMNS 
                                WHERE   
                                  TABLE_NAME = '{TABLE_NAME}' 
                                ORDER BY 
                                  ORDINAL_POSITION ASC; ";
				query = query.Replace("{TABLE_NAME}", jProperties.TableName.Replace("[", "").Replace("]", ""));
				db.setQuery(query);
				DataTable tmp = db.Query_DataTable();
				query = "";
				DataTable DDDDT = jProperties.GetDataTable();
				foreach (DataRow dr in tmp.Rows)
				{
					if (dr["DATA_TYPE"].ToString() == "datetime" || dr["DATA_TYPE"].ToString() == "date")
						query += ", (Select Fa_Date from StaticDates where En_Date = CAST(p.[" + dr["COLUMN_NAME"].ToString() + "] as DATE)) as [" + dr["COLUMN_NAME"].ToString() + "]";
					else
						query += ", p.[" + dr["COLUMN_NAME"].ToString() + "]";
				}
				foreach (DataRow dr in DDDDT.Rows)
				{
					if (dr["DataType"].ToString() == Globals.Property.JSQLDataType.اس_کیو_ال.ToString())
					{
						query = query.Replace("p.[" + dr["Name"].ToString().Replace(" ", "__") + "]", "(SELECT Title FROM (" + dr["List"] + ") AS A WHERE Cast(A.Code as char) = p.[" + dr["Name"].ToString().Replace(" ", "__") + "]) AS '" + dr["Name"].ToString().Replace(" ", "__") + "'");
					}
				}
				if (string.IsNullOrEmpty(query))
					return new DataTable();
				query = query.Substring(1);
				query = "Select " + query + ", (Select Fa_Date from StaticDates where En_Date = CAST(FormObjects.Date as DATE)) as RegisterDate From " + jProperties.TableName + " as p  inner join FormObjects on FormObjects.Code = p.ObjectCode where FormObjects.ObjectCode = " + objectCode + " AND FormObjects.FormCode = " + formCode + " order by p.ObjectCode, p.Code";
				db.Dispose();
				db = new JDataBase();
				db.setQuery(query);
				DataTable dt = db.Query_DataTable();
				return dt;
			}
			finally
			{
				db.Dispose();
			}
		}

		public DataTable GetObjectDataTable(int formCode, int objectCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("SELECT * FROM FormObjects Where FormCode = " + formCode + " AND ObjectCode = " + objectCode);
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}
		#endregion
	}
}
