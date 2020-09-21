using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary
{
    public class JSMSGet : JSystem
    {
        #region constructor
        public JSMSGet()
        {

        }
        public JSMSGet(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        ///  
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///  موبیل
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        ///  متن
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        ///  خوانده شده
        /// </summary>
        public bool Read { get; set; }
        /// <summary>
        ///  تاریخ خواندن 
        /// </summary>
        public DateTime ReadDate { get; set; }
        /// <summary>
        ///  کد شخص دریافت کننده پیامک
        /// </summary>
        public int PersonCode { get; set; }
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
            JSMSGetTable JLT = new JSMSGetTable();
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
            JSMSGetTable PDT = new JSMSGetTable();
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
            JSMSGetTable PDT = new JSMSGetTable();
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
                string Query = "select * from SMSGet where Code=" + pCode + "";
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

        public static DataTable GetSMSNotSend()
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSGet where Send=0 ";
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
                //JSMSSendTable JEFF = new JSMSSendTable();
                //JEFF.State = JFormState.Insert;
                //JEFF.ShowDialog();
            }
            else
            {
                //JDefineKolForm JEFF = new JDefineKolForm(pCode);
                //JEFF.State = JFormState.Update;
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)(pRow["Code"]), "ClassLibrary.JSMSSend");
            Node.Name = pRow["Mobile"].ToString();
            //+ "\n" + pRow[JEmployeeFoodTableEnum.DateRegister.ToString()];
            
            //اکشن جدید
            JAction NewAction = new JAction("new...", "ClassLibrary.JSMSGet.ShowDialog", new object[] { 0 }, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "ClassLibrary.JSMSGet.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "ClassLibrary.JSMSGet.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);
            return Node;
        }
        #endregion
    }

    public class JSMSGets : JSystem
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
            string Qoury = @"select * from SMSGet " + Where;
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
            Nodes.ObjectBase = new JAction("NewNode", "ClassLibrary.JSMSGet.GetNode");
            Nodes.DataTable = GetDataTable(0);
            //اکشن جدید
            JAction newaction = new JAction("new...", "ClassLibrary.JSMSGet.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
}
