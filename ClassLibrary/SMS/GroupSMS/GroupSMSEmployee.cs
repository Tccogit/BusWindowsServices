using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JGroupSMSEmployee : JSystem
    {

        #region Constructor
        public JGroupSMSEmployee()
        {
        }
        #endregion

        #region Field
        public int Code { set; get; }
        /// <summary>
        /// کد 
        /// </summary>
        public int GroupCode { set; get; }
        /// <summary>
        /// کد پرسنلی
        /// </summary>
        public int PersonCode { set; get; }
        #endregion

        #region MainMethod
        public int Insert()
        {
            JGroupSMSEmployeeTable JECCT = new JGroupSMSEmployeeTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSEmployee.Insert"))
                {
                    JECCT.SetValueProperty(this);
                    Code = JECCT.Insert();
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JEmployeeCostCenters.GetDataTable(JECCT.Code));
                        return Code;
                    }
                    else
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
        }

        public bool update()
        {
            JGroupSMSEmployeeTable JECCT = new JGroupSMSEmployeeTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSEmployee.update"))
                {

                    JECCT.SetValueProperty(this);
                    return JECCT.Update();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete()
        {
            JGroupSMSEmployeeTable JECCT = new JGroupSMSEmployeeTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSEmployee.Delete"))
                {
                    JECCT.SetValueProperty(this);
                    if (JECCT.Delete())
                    {
                        //Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
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
        }

        public bool DeleteManual(int pCostCenter)
        {
            JGroupSMSEmployeeTable JECCT = new JGroupSMSEmployeeTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSEmployee.Delete"))
                {
                    JECCT.SetValueProperty(this);
                    if (JECCT.DeleteManual(" GroupCode=" + pCostCenter))
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
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
        }
        #endregion

        #region find&getdata

        public bool Find()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qouery = "select * from smsgroup where GroupCode=" + GroupCode + " And PersonCode=" + PersonCode;
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                    return true;
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
                Db.Dispose();
            }
        }

        public static int FindCostCenterByPerson(int pPersonCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qouery = "select Top 1 GroupCode from smsgroup where PersonCode=" + pPersonCode;
            try
            {
                Db.setQuery(Qouery);
                if (Db.Query_ExecutSacler() != null)
                    return (int)(Db.Query_ExecutSacler());
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
                Db.Dispose();
            }
        }

        public bool Save(JFormState tmpJFormState,DataTable EmployeeList)
        {
            try
            {
                JGroupSMSEmployee JECC = new JGroupSMSEmployee();
                foreach (DataRow Row in EmployeeList.Rows)
                {
                    if ((Row.RowState == DataRowState.Added) && (Row["Code"].ToString() ==""))
                    {
                        JECC.GroupCode = this.GroupCode;
                        JECC.PersonCode = (int)Row["PersonCode"];
                        if (!JECC.Find())
                            if (JECC.Insert() <= 0)
                                return false;
                    }
                    if (Row.RowState == DataRowState.Deleted)
                    {
                        Row.RejectChanges();
                        JECC.GroupCode = this.GroupCode;
                        JECC.Code = (int)Row["Code"];
                        JECC.PersonCode = (int)Row["PersonCode"];
                        if (JECC.Find())
                        {
                            if (!JECC.Delete())
                                return false;
                            Row.Delete();
                        }
                    }
                }
                //if (tmpJFormState == JFormState.Insert)
                //    Nodes.DataTable.Merge(JGroupSMSEmployees.ListPersonByGroup(this.GroupCode));
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        #endregion

        #region ShowData&GetNode
        public void ShowDialog()
        {
            //if (Code == 0)
            //{
                JGroupSMSFrom JFF = new JGroupSMSFrom();
                //JPersonFoodForm JFF = new JPersonFoodForm();
                JFF.State = JFormState.Insert;
                if (JFF.ShowDialog() == System.Windows.Forms.DialogResult.Retry)
                    ShowDialog();
            //}
            //else
            //{
            //    JGroupSMSFrom JFF = new JGroupSMSFrom(Code);
            //    //JPersonFoodForm JFF = new JPersonFoodForm(Code);
            //    JFF.State = JFormState.Update;
            //    if (JFF.ShowDialog() == System.Windows.Forms.DialogResult.Retry)
            //    {
            //        Code = 0;
            //        ShowDialog();
            //    }
            //}
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.JGroupSMSEmployee");
            JAllPerson Person = new JAllPerson((int)pRow["PersonCode"]);
            Node.Name = Person.Name;            

            Nodes.hidColumns = "PersonCode";
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.JGroupSMSEmployee.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "ClassLibrary.JGroupSMSEmployee.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "ClassLibrary.JGroupSMSEmployee.ShowDialog", null, null);

            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);

            return Node;
        }
        #endregion
    }

    public class JGroupSMSEmployees : JSystem
    {
        public static DataTable ListPersonByGroup(int pGroupCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = "";
            if (pGroupCode > 0)
                Where = "where GroupCode=" + pGroupCode;
            string Qouery = @"select *,(select Name From Subdefine where code=GroupCode) 'Name',
                (Select Name From clsAllperson where Code=PersonCode) 'PersonName' ,
(select Mobile from clsPersonAddress where Code = PersonCode) 'Mobile'
From smsgroup " + Where;
            try
            {
                Db.setQuery(Qouery);
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

        public static DataTable ViewPersonByGroup(int pGroupCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = "";
            if (pGroupCode > 0)
                Where = "where GroupCode=" + pGroupCode;
            string Qouery = @"select cast('False' as bit) 'Confirm',PersonCode,
                (Select Name From clsAllperson where Code=PersonCode) 'PersonName' ,
(select Mobile from clsPersonAddress where Code = PersonCode) 'Mobile' From smsgroup " + Where;
            try
            {
                Db.setQuery(Qouery);
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
            //Nodes.ObjectBase = new JAction("PrsonFood", "Restaurant.JPersonFood.GetNode");
            //Nodes.DataTable = ListPersonByGroup(0);
            //JAction newAction = new JAction("New...", "Restaurant.JPersonFood.ShowDialog", null, null);
            //Nodes.GlobalMenuActions.Insert(newAction);
            //JToolbarNode JTN = new JToolbarNode();
            //JTN.Click = newAction;
            //JTN.Icon = JImageIndex.Add;
            //Nodes.AddToolbar(JTN);
        }
    }
}
