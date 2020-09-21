using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace ClassLibrary
{
    public class JOtherPerson : JSystem
    {

        // خواص
        #region Peroperties
        /// <summary>
        /// حداکثر طول کد
        /// </summary>
        private int MaxCodeLength
        {
            get
            {
                return DefaultCode.ToString().Length;
            }
        }
        /// <summary>
        /// مقدار پیشفرض برای کد
        /// </summary>
        private int DefaultCode
        {
            get
            {
                return 29999999;
            }
        }
        /// <summary>
        /// کد فرد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// سایر توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region سازنده

        public JOtherPerson()
        {
        }

        public JOtherPerson(int pCode)
        {
            Code=pCode;
            if (pCode > 0)
                GetData(Code);
        }
         
        #endregion

        #region Functions
        public override string ToString()
        {
            return this.Title;
        }

        #region AllPerson Functions
        /// <summary>
        /// درج در جدول واسط
        /// </summary>
        /// <returns></returns>
        private bool _InsertInAllPerson(JDataBase pDB)
        {
            JAllPerson allPerson = new JAllPerson();
            allPerson.Name = this.ToString();
            allPerson.Code = this.Code;
            //allPerson.IDNo = this.ShSh;
            allPerson.Active = true;
            //allPerson.IncompleteInformation = this.IncompleteInformation;
            allPerson.PersonType = JPersonTypes.OtherPerson;
            return allPerson.Insert(pDB);
        }

        /// <summary>
        /// ویرایش جدول واسط
        /// </summary>
        /// <returns></returns>
        private bool _UpdateInAllPerson(JDataBase pDB)
        {
            JAllPerson allPerson = new JAllPerson();
            allPerson.Name = this.ToString();
            allPerson.Code = this.Code;
            //allPerson.IDNo = this.ShSh;
            allPerson.Active = true;
            //allPerson.IncompleteInformation = this.IncompleteInformation;
            return allPerson.Update(pDB);
        }
        /// <summary>
        /// حذف از جدول واسط
        /// </summary>
        /// <returns></returns>
        private bool _DeleteFromAllPeson(JDataBase pDB)
        {
            JAllPerson allPerson = new JAllPerson();
            allPerson.Code = this.Code;
            return allPerson.Delete(pDB);
        }
        #endregion

        /// <summary>
        /// بروزرسانی شخص و ثبت در هیستوری
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            return Update(true);
        }
        /// <summary>
        /// ویرایش اطلاعات فرد مشخص شده
        /// </summary>
        /// <returns></returns>
        public Boolean Update(bool SaveHistory)
        {
            //if (find(Code))
            //{
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (!(JPermission.CheckPermission("ClassLibrary.JOtherPerson.Update")))
                    return false;

                JOtherPersonsTable JPT = new JOtherPersonsTable();
                JPT.SetValueProperty(this);
                DB.beginTransaction("UpdatePerson");
                if (JPT.Update(DB))
                {
                    if (_UpdateInAllPerson(DB))
                    {
                        if (DB.Commit())
                            return true;
                        else
                        {
                            DB.Rollback("UpdatePerson");
                            return false;
                        }
                    }
                    else
                    {
                        DB.Rollback("UpdatePerson");
                        return false;
                    }
                }
                else
                {
                    DB.Rollback("UpdatePerson");
                    return false;
                }               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                DB.Rollback("UpdatePerson");
                return false;
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        /// <summary>
        /// حذف
        /// </summary>
        /// <returns></returns>
        public Boolean Delete()
        {
            //int Code = (int)Nodes.JanusGrid.SelectedRow["Code"];
            if (Code > 0)
                return Delete(Code);
            return false;
        }

        /// <summary>
        /// بررسی وجود شخص در جداول مختلف سیستم
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public string DoNotDelete(int pCode)
        {
            string res = "";
            JDataBase dataBase = JGlobal.MainFrame.GetDBO();
            dataBase.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.UsersTable + " WHERE pcode=" + pCode.ToString());
            if (dataBase.RecordCount > 0)
            {
                res = "FoundInUsers";
            }
            return res;
        }
        /// <summary>
        /// حذف شخص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Delete(int pCode)
        {
            //if (find(pCode))
            //{
                Code = pCode;
                JDataBase dataBase = JGlobal.MainFrame.GetDBO();
                try
                {
                    if (!(JPermission.CheckPermission("ClassLibrary.JOtherPerson.Delete")))
                        return false;
                        /// بررسی وجود شخص در جداول مختلف سیستم
                        string error = DoNotDelete(pCode);
                        if (error != "")
                        {
                            JMessages.Error(error, "error");
                            return false;
                        }
                        ///
                        JOtherPersonsTable JPT = new JOtherPersonsTable();
                        JPT.SetValueProperty(this);
                        if (JMessages.Question("AreYouSureDeletePerson?", "Question") == System.Windows.Forms.DialogResult.Yes)
                        {
                            dataBase.beginTransaction("DeletePerson");
                            /// حذف آدرسها
                            //if (!this.HomeAddress.Delete(dataBase))
                            //{
                            //    dataBase.Rollback("DeletePerson");
                            //    return false;
                            //}
                            //if (!this.WorkAddress.Delete(dataBase))
                            //{
                            //    dataBase.Rollback("DeletePerson");
                            //    return false;
                            //}
                            if (JPT.Delete(dataBase))
                            {
                                if (_DeleteFromAllPeson(dataBase))
                                {
                                    ///// حذف از آرشیو
                                    //ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument();
                                    //archive.DeleteArchive(this.GetType().FullName, this.Code, true);

                                    dataBase.Commit();

                                    Nodes.Delete(Nodes.CurrentNode);
                                    //Nodes.Delete(JStaticNode._PersonNode(this));
                                    //Nodes.JanusGrid.SelectedRow.Delete();
                                    return true;
                                }
                            }
                            dataBase.Rollback("DeletePerson");
                        }
                        return false;
                    //}
                    //else
                    //    return false;
                }
                catch (Exception ex)
                {
                    dataBase.Rollback("DeletePerson");
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    dataBase.Dispose();
                }
            //}
            return false;
        }

        /// <summary>
        /// درج یک فرد جدید
        /// </summary>
        /// <returns></returns>
        public int insert()
        {
            return insert(false);
        }
        public int insert(bool pManual)
        {
            int mCode = 0;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (!(JPermission.CheckPermission("ClassLibrary.JOtherPerson.Insert",true)))
                    return 0;
                JOtherPersonsTable JPT = new JOtherPersonsTable();
                    JPT.SetValueProperty(this);

                    DB.beginTransaction("PersonInsert");
                    mCode = JPT.Insert(DefaultCode, DB, pManual);
                    if (mCode > 0)
                    {
                        Code = mCode;
                        /// درج در جدول واسط
                        if (_InsertInAllPerson(DB))
                        {
                            if (DB.Commit())
                            {
                                JPT.Code = mCode;
                                Histroy.Save(this, JPT, mCode, "");
                                return mCode;
                            }
                            else
                            {
                                DB.Rollback("PersonInsert");
                                return 0;
                            }
                        }
                        else
                        {
                            DB.Rollback("PersonInsert");
                            return 0;
                        }
                    }
                    
                //}
                //else
                    return 0;
            }
            catch (Exception ex)
            {
                DB.Rollback("PersonInsert");
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        //public JNode GetNode()
        //{
        //    return JStaticNode._PersonNode(this);
        //}
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesClassLibrary.OtherPerson + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public static DataTable SearchPerson(int pCode, string pTitle, string pPhone, string pAddress,string pDesc)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = "Select * from " + JTableNamesClassLibrary.OtherPerson + "  WHERE 1=1 ";
                if (pCode != 0)
                    Query = Query + " AND Code = " + pCode.ToString();
                if (pTitle.Trim() != "")
                    Query = Query + " AND Title LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pTitle, false) + '%');
                if (pPhone.Trim() != "")
                    Query = Query + " AND Phone LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pPhone, false) + '%');
                if (pAddress.Trim() != "")
                    Query = Query + " AND Address LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pAddress, false) + '%');

                if (pDesc.Trim() != "")
                    Query = Query + " AND Description LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pDesc, false) + '%');             

                DB.setQuery(Query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JOtherPersonForm PE = new JOtherPersonForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
                if (PE.DialogResult == System.Windows.Forms.DialogResult.Retry)
                    ShowDialog();
            }
            else
            {
                JOtherPersonForm PE = new JOtherPersonForm(this);
                PE.State = JFormState.Update;
                PE.ShowDialog();
                if (PE.DialogResult == System.Windows.Forms.DialogResult.Retry)
                {
                    PE.State = JFormState.Insert;
                    Code = 0;
                    ShowDialog();
                }
            }
        }     
        #endregion

        #region Node
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.JOtherPerson");
            Node.Icone = JImageIndex.LegalPerson.GetHashCode();
            Node.Name = pRow["Title"].ToString();
            //Node.Hint = JLanguages._Text("RegisterNo:") + " " + pRow[JOrganizationsTableEnum.RegisterNo.ToString()] + "\n" +
            //    JLanguages._Text("Status:") + pRow[JOrganizationsTableEnum.Status.ToString()];
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.JOtherPerson.ShowDialog", null, new object[] { Node.Code });
            //اکشن مشاهده
            JAction viewAction = new JAction("View...", "ClassLibrary.JOtherPerson.ShowDialog", new object[] { true }, new object[] { Node.Code });
            Node.MouseDBClickAction = viewAction;
            Node.EnterClickAction = viewAction;
            //اکشن حذف
            JAction deleteAction = new JAction("Delete...", "ClassLibrary.JOtherPerson.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = deleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "ClassLibrary.JOtherPerson.ShowDialog", null, null);
            JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JOtherPerson", Node.Code);
            pMenu.Insert(newAction);
            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(viewAction);
            Node.Popup = pMenu;
            return Node;
        }
        #endregion Node
    }

    public class JOtherPersons : JSystem
    {
        public JPerson[] Items = new JPerson[0];
        public JOtherPersons()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = " Where 1=1 ";
                if (pCode != 0)
                    WHERE = " AND " + JTableNamesClassLibrary.OtherPerson + ".Code = " + pCode;
                DB.setQuery(" Select * from ClsOtherPerson " + WHERE );
                    //+ " And " +
                    //JPermission.getObjectSql("ClassLibrary.JOtherPerson.GetDataTable", JTableNamesClassLibrary.OtherPerson + ".Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetPerson", "ClassLibrary.JOtherPerson.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "ClassLibrary.JOtherPerson.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }
    }
}
