using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary
{
    public class JSMSSend : JSystem
    {
        #region constructor
        public JSMSSend()
        {

        }
        public JSMSSend(int pCode)
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
        ///  ارسال شده
        /// </summary>
        public int Send { get; set; }
        /// <summary>
        ///  تاریخ ثبت
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        ///  تاریخ ارسال
        /// </summary>
        public DateTime SendDate { get; set; }
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  نام پروژه
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        ///  تایید دریافت تاریخ
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        ///  کد شخص ارسال کننده پیامک
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        ///  نوع ارسال با چه وسیله ای
        /// </summary>
        public int SendDevice { get; set; }
        /// <summary>
        /// کد برای پیگیری وضعیت ارسال
        /// </summary>
        public string BatchId { get; set; }

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
            return Insert(tempDb, false);
        }

        public int Insert(JDataBase tempDb, bool pManualInsert)
        {
            JWebServiceSMS SMS = new JWebServiceSMS();
            if (JSystem.SMSSend)
            {
				if (Mobile==null || Mobile.Length < 10) return 0;
                JSMSSendTable JLT = new JSMSSendTable();
                try
                {
                    JLT.SetValueProperty(this);
                    RegDate = JDateTime.Now();
                    if (pManualInsert == true) JLT.Set_ComplexInsert(false);
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
            JSMSSendTable PDT = new JSMSSendTable();
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
            JSMSSendTable PDT = new JSMSSendTable();
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
                string Query = "select * from SMSSend where Code=" + pCode + "";
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
                string Query = "select * from SMSSend where Send = 0 ";
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
            /*JSMSFrom JEFF = new JSMSFrom();
            JEFF.State = JFormState.Insert;
            JEFF.ShowDialog();*/
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)(pRow["Code"]), "ClassLibrary.JSMSSend");
            Node.Name = pRow["Mobile"].ToString();
            //+ "\n" + pRow[JEmployeeFoodTableEnum.DateRegister.ToString()];

            //اکشن جدید
            JAction NewAction = new JAction("new...", "ClassLibrary.JSMSSend.ShowDialog", new object[] { 0 }, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "ClassLibrary.JSMSSend.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "ClassLibrary.JSMSSend.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);
            return Node;
        }
        #endregion
    }

    public class JSMSSends : JSystem
    {
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, "");
        }
        public static DataTable GetDataTable(string where)
        {
            return GetDataTable(0, where);
        }

        public static DataTable GetDataTable(int pCode, string where)
        {
            string Where = "";
            if (pCode > 0)
                Where += " and Code=" + pCode;
            if (where != "")
                Where += " and " + where;
            string Qoury = @"select * from SMSSend " + (Where.Length > 0 ? "Where 1=1 " + Where : "");
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
            Nodes.ObjectBase = new JAction("NewNode", "ClassLibrary.JSMSSend.GetNode");
            Nodes.DataTable = GetDataTable(0);
            //اکشن جدید
            JAction newaction = new JAction("new...", "ClassLibrary.JSMSSend.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
}
