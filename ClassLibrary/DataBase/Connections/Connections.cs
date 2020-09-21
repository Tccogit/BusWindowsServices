using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;
using Finance;
using MySql;

namespace ClassLibrary
{
    public enum JDataBaseType
    {
        SQLServer = 0 ,
        MySQL = 1 ,
    }
    public class JConnection : JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DataBaseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public JDataBaseType DataBaseType { get; set; }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JConnection.Insert"))
                {
                    JConnectionTable JLT = new JConnectionTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        return Code;
                    }
                    return 0;
                }
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
                //tempDb.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JConnectionTable PDT = new JConnectionTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JConnection.Delete"))
                {
                    JDataBase DB = JGlobal.MainFrame.GetDBO();
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                        return true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //Db.Dispose();
            }
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            try
            {
                JConnectionTable PDT = new JConnectionTable();
                if (JPermission.CheckPermission("ClassLibrary.JConnection.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, JLegislations.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //Db.Dispose();
            }
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Meeting.JLegislation");
            Node.Name = pRow["Legislation"].ToString() + "-" + pRow["FlowDate"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Legislation"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Meeting.JLegislation.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Meeting.JLegislation.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Meeting.JLegislation.ShowDialog", null, null);

            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);

            return Node;

        }
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JConnectionForm LandForm = new JConnectionForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JConnectionForm LandForm = new JConnectionForm(Code);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        public System.Data.SqlClient.SqlConnectionStringBuilder GetConnection(string pClassName, int pObjectCode)
        {
            return GetSQlServerConnection(pClassName, pObjectCode);
        }

        public System.Data.SqlClient.SqlConnectionStringBuilder GetSQlServerConnection(string pClassName, int pObjectCode)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder SCSB = new System.Data.SqlClient.SqlConnectionStringBuilder();
            if (GetData(pClassName, pObjectCode))
            {
                SCSB.Password = Password;
                SCSB.UserID = UserName;
                SCSB.InitialCatalog = DataBaseName;
                SCSB.DataSource = ServerName;
            }
            return SCSB;
        }

        public MySql.Data.MySqlClient.MySqlConnection GetMySQLConnection(string pClassName, int pObjectCode)
        {
            MySql.Data.MySqlClient.MySqlConnection SCSB = new MySql.Data.MySqlClient.MySqlConnection();
            if (GetData(pClassName, pObjectCode))
            {
                SCSB.ConnectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false;Connection Timeout=50;",
                    ServerName, UserName, Password, DataBaseName);
            }
            return SCSB;
        }

        public System.Data.SQLite.SQLiteConnection GetSQLiteConnection(string pDataBaseName)
        {
            try
            {
                System.Data.SQLite.SQLiteConnection SCSB = new System.Data.SQLite.SQLiteConnection();
                SCSB.ConnectionString = String.Format("Data Source='{0}';Version=3;", pDataBaseName);
                //SCSB.DataSource = pDataBaseName;
                return SCSB;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool GetData(string pClassName, int pObjectCode)
        {
            string Query = @"select * from " + JTableNamesClassLibrary.ConnectionsTable + "  WHERE classname = '" + pClassName + "' AND objectcode=" + pObjectCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                db.Query_DataReader();
                if(db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
    }

    public class JConnections: JSystem
    {
        public JConnections[] Items = new JConnections[0];
        public JConnections()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And " + JTableNamesClassLibrary.ConnectionsTable + ".Code=" + pCode;
            string Query = @"select * from " + JTableNamesClassLibrary.ConnectionsTable + Where;
                //" And " + JPermission.getObjectSql("Meeting.JLegislation.GetDataTable", JTableNamesMeeting.MetLegislation + ".Code");
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

        #endregion GetData

        #region Node
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JConnection", "Meeting.JMeetings.GetNode");
            Nodes.DataTable = JConnections.GetDataTable(0);
            JAction newAction = new JAction("New...", "Meeting.JLegislation.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
