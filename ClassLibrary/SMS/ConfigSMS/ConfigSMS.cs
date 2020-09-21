using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JConfigSMS : JSystem
    {
        #region constructor
        public JConfigSMS()
        {

        }
        public JConfigSMS(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string PinCode { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string Speed { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string BodyType { get; set; }
        
        #endregion

        #region method

        public int Insert()
        {
            JDataBase tempDb = new JDataBase();
            return Insert(tempDb);
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {
            JSMSConfigTable JLT = new JSMSConfigTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert(tempDb);
                if (Code > 0)
                    return Code;
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
                tempDb.Dispose();
                JLT.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            JSMSConfigTable PDT = new JSMSConfigTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
            return false;
        }

        /// <summary>
        /// حذف 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JDataBase Db = new JDataBase();
            JSMSConfigTable PDT = new JSMSConfigTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(Db))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
            return false;
        }
        #endregion

        #region GetData
                
        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSConfig where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                Db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSConfig where Code=" + pCode;
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

        #region Nodes
        public void ShowDialog()
        {
            ShowDialog(0);
        }
   
        public void ShowDialog(int pCode)
        {
            if (pCode == 0)
            {
                JConfigSMSFrom JEFF = new JConfigSMSFrom();
                JEFF.State = JFormState.Insert;
                JEFF.ShowDialog();
            }
            else
            {
                //JDefineKolForm JEFF = new JDefineKolForm(pCode);
                //JEFF.State = JFormState.Update;
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)(pRow["Code"]), "ClassLibrary.JConfigSMS");
            Node.Name = pRow["name"].ToString();
                //+ "\n" + pRow[JEmployeeFoodTableEnum.DateRegister.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "ClassLibrary.JConfigSMS.ShowDialog", new object[] { 0 }, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "ClassLibrary.JConfigSMS.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "ClassLibrary.JConfigSMS.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);
            return Node;
        }
        #endregion
    }

    public class JConfigSMSs : JSystem
    {
         public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = "";
            if (pCode > 0)
                Where = " and Code=" + pCode;
            string Qoury = @"select * from ACFiscalYear " + Where;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "ClassLibrary.JConfigSMS.GetNode");
            Nodes.DataTable = GetDataTable(0);
            //اکشن جدید
            JAction newaction = new JAction("new...", "ClassLibrary.JConfigSMS.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }

    public class JSMSConfigTable : JTable
    {
        public JSMSConfigTable()
            : base("SMSConfig")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public string ServerName;
        /// <summary>
        ///  
        /// </summary>
        public string PinCode;
        /// <summary>
        ///  
        /// </summary>
        public string Speed;
        /// <summary>
        ///  
        /// </summary>
        public string PortName;
        /// <summary>
        ///  
        /// </summary>
        public string BodyType;
    }
}
