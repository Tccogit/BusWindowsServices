using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// انواع وضعیت شرکت
    /// </summary>
    public enum JCompanyStatuses
    {
        /// <summary>
        /// نامشخص
        /// </summary>
        UnDefined_ = 0,
        /// <summary>
        /// فعال
        /// </summary>
        Active = 1,
        /// <summary>
        /// غیر فعال
        /// </summary>
        Deactive = 2,
        /// <summary>
        /// ورشکسته
        /// </summary>
        Broke = 3,
        /// <summary>
        /// منحل شده
        /// </summary>
        Dissolved = 4
    }
    /// <summary>
    /// نود سازمان ها
    /// </summary>
    public class JOrganization : JSystem
    {
        // سازنده کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JOrganization()
        {
            Address = new JPersonAddress();
        }
        public JOrganization(int pCode)
            : this(pCode, "")
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="pCode">کد سازمان</param>
        public JOrganization(int pCode, string pDate)
        {
            GetData(pCode, pDate);
           // Address = new JPersonAddress(pCode);
        }
        #endregion Constructors
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
                return 19999999;
            }
        }

        /// <summary>
        /// کد سازمان 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام سازمان 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  کد سازمان پدر
        /// </summary>
        public int ParentCode { get; set; }
        /// <summary>
        /// نام مدیر عامل
        /// </summary>
        public string Managing_Director { get; set; }
        /// <summary>
        /// شماره تلفن
        /// </summary>
        //public string Phone_Number { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        //public string Address { get; set; }
        /// <summary>
        /// کد دسترسی آسان
        /// </summary>
        public int Access_Code { get; set; }
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public string RegisterNo { get; set; }
        /// <summary>
        /// محل ثبت
        /// </summary>
        public int RegisterPlace { get; set; }
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterPlaceText
        {
            get
            {
                JCitiy Ci = new JCitiy();
                if (Ci.GetData(RegisterPlace))
                    return Ci.Name;
                else
                    return "";
            }
        }
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// نوع شرکت
        /// </summary>
        public int CompanyType { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public JPersonAddress Address { get; set; }
        /// <summary>
        /// وضعیت (فعال - غیر فعال - ورشکسته - منحل شده) 
        /// </summary>
        public JCompanyStatuses Status { get; set; }
        /// <summary>
        /// سایر توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// کد اقتصادی شرکت
        /// </summary>
        public string CommercialCode { get; set; }
        /// <summary>
        /// شناسه اقتصادی
        /// </summary>
        public string ShenaseMeli { get; set; }
        /// <summary>
        /// صاحبان امضاء مجاز
        /// </summary>
        public DataTable SignatureMen { get; set; }
        public List<JSignatureMen> SignatureList { get; set; }
        public List<JSignatureMen> DelSignatureList = new List<JSignatureMen>();
		public int _CompanyCode;
        public List<string> SignatureListText
        {
            get
            {
                JAllPerson AllPerson = new JAllPerson();
                List<string> TList = new List<string>();
                if (SignatureList == null)
                {
                    JMessages.Error(" صاحبان امضا را مشخص کنید ", "");
                    return null;
                }
                foreach (JSignatureMen SM in SignatureList)
                {
                    TList.Add(SM.FirstName + " " + SM.LastName);
                }
                return TList;
            }
        }

        /// <summary>
        /// کد تصویر آرم در سیستم آرشیو
        /// </summary>
        public int ArmArchiveCode { get; set; }
        /// <summary>
        /// کانکشن استرینگ جهت اتصال به بانک اطلاعاتی شرکت
        /// </summary>
        public string ConnectionString { get; set; }

        public int _SharePCode;
        public int _TafsiliCode;

        #endregion Peroperties
        // Insert , Update , Delete
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
            allPerson.IDNo = this.RegisterNo;
            allPerson.Active = (this.Status == JCompanyStatuses.Active);
            allPerson.PersonType = JPersonTypes.LegalPerson;
            allPerson.TafsiliCode = _TafsiliCode;
            //allPerson.SharePCode = _SharePCode;
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
            allPerson.IDNo = this.RegisterNo;
            allPerson.Active = (this.Status == JCompanyStatuses.Active);
            allPerson.TafsiliCode = _TafsiliCode;
            //allPerson.SharePCode = _SharePCode;
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

        #region BaseFunctions

        public override string ToString()
        {
            return this.Name;
        }
        /// <summary>
        /// درج سازمان جدید در بانک اطلاعاتی
        /// </summary>
        /// <returns>بر می گرداند True در صورت درج صحیح مقدار</returns>
        public int Insert()
        {
            if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Insert"))
                return 0;
            if (Find(Code) || Find(Name, this.RegisterPlace, this.RegisterNo))
            {
                JMessages.Error("LegalPesonExists", "Error");
                return 0;
            }

            if (Find(this._SharePCode, this.Code) > 0)
            {
                JMessages.Error("این شماره سهامداری قبلا وارد شده است.", "error");
                return 0;
            }
            string strParentCode = "NULL";
            if (ParentCode != 0)
            {
                strParentCode = ParentCode.ToString();
            }
            string strAccess_Code = "NULL";
            if (Access_Code != 0)
            {
                strAccess_Code = Access_Code.ToString();
            }
            int retCode = 0;
            //string strInsert = @" DECLARE @Code INT  "+
            //                    JDataBase.GetInsertSQL("organization",DefaultCode.ToString(),true)+

            //                   " INSERT INTO organization ([Code],[name],[access_code],[description], " +
            //                   " [RegisterNo], [RegisterPlace], [Subject], [CompanyType], [Status], [ConnectionString], [CommercialCode])" +
            //                   " VALUES(@Code, @name, @Code, @description, " +
            //                   " @RegisterNo, @RegisterPlace, @Subject, @CompanyType, @Status, @ConnectionString, @CommercialCode)" +
            //                   " SELECT @Code";
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {

                //db.Params.Clear();
                //db.setQuery(strInsert);
                //db.AddParams("name", Name);
                ////db.AddParams("parentcode", ParentCode);
                ////db.AddParams("managing_director", Managing_Director);
                //db.AddParams("access_code", Access_Code);
                //db.AddParams("description", Description);
                //db.AddParams("RegisterNo", RegisterNo);
                //db.AddParams("RegisterPlace", RegisterPlace);
                //db.AddParams("Subject", Subject);
                //db.AddParams("CompanyType", CompanyType.GetHashCode());
                //db.AddParams("Status", Status);
                //db.AddParams("ConnectionString", ConnectionString);
                //db.AddParams("CommercialCode", CommercialCode);

                db.beginTransaction("InsertOrgan");
                //retCode = int.Parse(db.Query_ExecutSacler().ToString());

                JOrganizationsTable orgTable = new JOrganizationsTable();
                orgTable.SetValueProperty(this);
                retCode = orgTable.Insert(1000001,db,false);

                if (retCode != 0)
                {
                    orgTable.Access_Code = retCode;
                    orgTable.Update(db);


                    Code = retCode;
                    /// ثبت صاحبان امضاء
                    if (this.SignatureList != null)
                        foreach (JSignatureMen signMan in this.SignatureList)
                        {
                            if (signMan.Code == 0)
                            {
                                signMan.PCode = Code;
                                signMan.Insert(db);
                            }
                            if (signMan.Changed)
                            {
                                signMan.Update(db);
                            }
                            if (signMan.Deleted)
                            {
                                signMan.Delete(db);
                            }
                        }
                    ///
                    if (_InsertInAllPerson(db))
                    {
						if (_SharePCode > 0)
							JShareWebLog.Insert(db, "clsPerson", Code, 'i');
						if (_SharePCode > 0)
						{
							ManagementShares.ShareCompany.JSharepCode SC = new ManagementShares.ShareCompany.JSharepCode();
							int TempShareCode = ManagementShares.ShareCompany.JSharepCode.GetPersonShare(_CompanyCode, _SharePCode);
							if (TempShareCode == 0)
							{
								SC.Insert(_CompanyCode, Code, _SharePCode);
							}
							else
								if (TempShareCode == Code)
								{
									SC.find(_CompanyCode, Code, _SharePCode, true);
									SC.Update(_CompanyCode, Code, SC.SharePCode, _SharePCode);
								}
								else
								{
									JMessages.Error("کد سهامداری تکراری است", "خطا!");
								}
						}
						
						db.Commit();
                        Address.Insert(retCode, this._SharePCode);
						try
						{
							Nodes.DataTable.Merge(JOrganizations.GetDataTable(Code));
						}
						catch
						{
						}
                        JOrganizationsTable table = new JOrganizationsTable();
                        table.SetValueProperty(this);

                        Histroy.Save(this, table, this.Code, "Insert");

                        return retCode;
                    }
                }
                db.Rollback("InsertOrgan");
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("InsertOrgan");
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش سازمان
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Update"))
                return false;

            if (Find(this._SharePCode, this.Code) > 0)
            {
                ///JMessages.Error("این شماره سهامداری قبلا وارد شده است.", "error");
                //return false;
            }
            if (Find(Code))
            {
                string strParentCode = "NULL";
                if (ParentCode != 0)
                {
                    strParentCode = ParentCode.ToString();
                }
                string strAccess_Code = "NULL";
                if (Access_Code != 0)
                {
                    strAccess_Code = Access_Code.ToString();
                }

				string strUpdate = " UPDATE organization SET RegisterDate=@RegisterDate, name =@name ,RegisterNo=@RegisterNo," +
                                    "  RegisterPlace=@RegisterPlace  ,Subject=@Subject, CompanyType=@CompanyType, Status=@Status, " +
                                   " access_code=@access_code ,description=@description, ArmArchiveCode = @ArmArchiveCode," +
                                   " ConnectionString = @ConnectionString, CommercialCode=@CommercialCode,ShenaseMeli=@ShenaseMeli " +
                                   " WHERE Code = @Code";

                JDataBase db = JGlobal.MainFrame.GetDBO();
                try
                {
                    db.Params.Clear();
                    db.setQuery(strUpdate);
                    db.AddParams("Code", this.Code);
                    db.AddParams("name", Name);
                    //db.AddParams("parentcode", ParentCode);
                    //db.AddParams("managing_director", Managing_Director);
                    db.AddParams("access_code", Code);
                    db.AddParams("description", Description);
                    db.AddParams("RegisterNo", RegisterNo);
                    db.AddParams("RegisterPlace", RegisterPlace);
                    db.AddParams("Subject", Subject);
                    db.AddParams("CompanyType", CompanyType);
                    db.AddParams("Status", Status);
                    db.AddParams("ArmArchiveCode", ArmArchiveCode);
                    db.AddParams("ConnectionString", ConnectionString);
                    db.AddParams("CommercialCode", CommercialCode);
					db.AddParams("ShenaseMeli", ShenaseMeli);
					db.AddParams("RegisterDate", RegisterDate);

                    db.beginTransaction("UpdateOrgan");

                    if (db.Query_Execute() >= 0)
                    {
                        /// ثبت صاحبان امضاء
                        if (this.SignatureList != null)
                            foreach (JSignatureMen signMan in this.SignatureList)
                            {
                                if (signMan.Code == 0)
                                {
                                    signMan.PCode = Code;
                                    signMan.Insert(db);
                                }
                                if (signMan.Changed)
                                {
                                    signMan.Update(db);
                                }
                            }
                        /// حذف آیتمهای حذف شده
                        foreach (JSignatureMen delSignMan in this.DelSignatureList)
                        {
                            if (delSignMan.Deleted)
                            {
                                delSignMan.Delete(db);
                            }
                        }
                        if (_UpdateInAllPerson(db))
                        {
                            if (Address.Find(this.Code, JAddressTypes.Work) > 0)
                                Address.Update();
                            else
                                Address.Insert(this.Code, this._SharePCode, db);

							if (_SharePCode > 0)
								JShareWebLog.Insert(db, "clsPerson", Code, 'i');
							if (_SharePCode > 0)
							{
								ManagementShares.ShareCompany.JSharepCode SC = new ManagementShares.ShareCompany.JSharepCode();
								
								//int TempShareCode = ManagementShares.ShareCompany.JSharepCode.(_CompanyCode, _SharePCode);
								if (true)//!SC.find(_CompanyCode, Code,true))
								{
									SC.Insert(_CompanyCode, Code, _SharePCode);
								}
								else
									//if (TempShareCode == Code)
									{
										//SC.find(_CompanyCode, Code, _SharePCode, true);
										SC.Update(_CompanyCode, Code, SC.SharePCode, _SharePCode);
									}
									//else
									//{
//										JMessages.Error("کد سهامداری تکراری است", "خطا!");
									//}
							}

							
							db.Commit();

							JDataBase TDB1 = new JDataBase();
							JDataBase TDB2 = new JDataBase();
							try
							{
								TDB1.setQuery("exec SP_PersonAddressViewSharePCode");
								TDB1.Query_Execute(true);

								TDB2.setQuery("exec SP_PersonAddressView");
								TDB2.Query_Execute(true);
							}
							finally
							{
								//db.Dispose();
							}
							
							JOrganizationsTable table = new JOrganizationsTable();
                            table.SetValueProperty(this);
                            Histroy.Save(this, table, this.Code);
                            try
                            {
                                Nodes.Refreshdata(Nodes.CurrentNode, JOrganizations.GetDataTable(Code).Rows[0]);
                            }
                            catch { }
                            return true;
                        }
                    }
                    ///

                    db.Rollback("UpdateOrgan");
                }
                catch (Exception ex)
                {
                    db.Rollback("UpdateOrgan");
                    Except.AddException(ex);
                    return false;
                }
                finally
                {
                    db.Dispose();
                }
            }
            return false;
        }

        public bool Delete()
        {
            return Delete(this.Code);
        }

        public static bool CheckShenaseMeli(string pShenaseMeli, int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("IF Exists (SELECT Code FROM  " + JTableNamesClassLibrary.LegalPerson + " WHERE Code <> " + pCode + " And  ShenaseMeli = '" + pShenaseMeli.ToString() +
                    "') SELECT 1 ELSE SELECT 0");
                return ((int)DB.Query_ExecutSacler() == 1);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// حذف سازمان از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode, bool IsWeb = false)
        {
            if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Delete"))
                return false;
            if (Find(pCode))
            {
                JOrganization jOrg = new JOrganization();
                jOrg.ParentCode = pCode;
                if (jOrg.Find())
                {
                    if (!IsWeb)
                        JMessages.Message(JLanguages._Text("This Organ have subOrgan and can not remove"), JLanguages._Text("Error"), JMessageType.Error);
                    return false;
                }

                if (!IsWeb)
                    if (JMessages.Message(JLanguages._Text("Do you want to remove this organ?"), JLanguages._Text("Question"), JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                        return false;

                GetData(pCode);
                JOrganizationsTable JOT = new JOrganizationsTable();
                JOT.SetValueProperty(this);
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.beginTransaction("DeleteOrgan");
                if (JOT.Delete(DB))
                {
                    this.Address.Delete(DB);
                    if (_DeleteFromAllPeson(DB))
                    {
                        if (DB.Commit())
                        {
                            ArchivedDocuments.JArchiveDocument Ad = new ArchivedDocuments.JArchiveDocument();
                            Ad.DeleteArchive(this.GetType().FullName, Code, true);
                            if (!IsWeb)
                                Nodes.Delete(Nodes.CurrentNode);
                            Histroy.Save(this, JOT, this.Code, "Delete");
                            return true;
                        }
                    }
                }
                DB.Rollback("DeleteOrgan");
            }
            return false;
        }

        #endregion BaseFunctions

        #region SignatureMen Functions

        #endregion SignatureMen Functions
        // Forms
        #region Forms
        /// <summary>
        /// نمایش فرم اشخاص حقوقی
        /// </summary>
        public void ShowDialog()
        {
            ShowDialog(false);
        }

        public void ShowDialog(bool pView)
        {
            if (this.Code == 0)
            {
                if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Insert"))
                    return;
                JLegalPerson PE = new JLegalPerson();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                if (pView)
                    if (!JPermission.CheckPermission("ClassLibrary.JOrganizations.GetDataTable"))
                        return;
                if (!pView)
                    if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Update"))
                        return;

                JLegalPerson PE = new JLegalPerson(this);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }
        /// <summary>
        /// نمایش فرم سازمان برای ویرایش اطلاعات
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool UpdateForm(int Code)
        {
            if (GetData(Code))
            {
                JfrmOrganizatins jo = new JfrmOrganizatins(this);
                jo.State = JFormState.Update;
                jo.ShowDialog();
            }
            return true;
        }
        /// <summary>
        /// نمایش فرم سازمان ها جهت درج
        /// </summary>
        /// <returns></returns>
        public bool InsertForm()
        {
            JfrmOrganizatins jo = new JfrmOrganizatins(this);
            jo.State = JFormState.Insert;
            jo.ShowDialog();
            return true;
        }
        #endregion Forms
        // GetInfo
        #region GetInfo
        /// <summary>
        /// جستجوی  سازمان
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM organization WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی  سازمان
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public bool Find()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM organization WHERE 1=1 ";
            if (Code != null && Code != 0) strSQL += " AND Code = " + Code.ToString();
            if (Name != null) strSQL += " AND name  like '%" + Name + "%'";
            if (ParentCode != null && ParentCode != 0) strSQL += " AND parentcode = " + ParentCode.ToString();
            if (Managing_Director != null) strSQL += " AND managing_director like '%" + Managing_Director.ToString() + "%'";
            //if (Phone_Number != null) strSQL += " AND phone_number like '%" + Phone_Number.ToString() + "%'";
            //if (Address != null) strSQL += " AND address like '%" + Address.ToString() + "%'";
            if (Access_Code != null && Access_Code != 0) strSQL += " AND access_code like '%" + Access_Code.ToString() + "%'";
            if (Description != null) strSQL += " AND description like '%" + Description.ToString() + "%'";

            try
            {
                db.setQuery(strSQL);
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس نام شرکت
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(string PName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM organization WHERE [name]=" + JDataBase.Quote(PName));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس شماره سهامداری
        /// </summary>
        /// <param name="pPerson"></param>
        /// <returns></returns>
        public int Find(int SharePCode, int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (SharePCode > 0)
                {
                    db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.AllPerson +
                        " WHERE SharePCode=" + SharePCode.ToString() + " AND Code <>" + pCode.ToString());
                    db.Query_DataReader();
                    if (db.RecordCount > 0)
                    {
                        db.DataReader.Read();
                        int Ret = Convert.ToInt32(db.DataReader["Code"]);
                        return Ret;
                    }
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس نام، محل ثبت، شماره ثبت
        /// </summary>
        /// <param name="PName"></param>
        /// <param name="pRegisterPlace"></param>
        /// <param name="pRegisterCode"></param>
        /// <returns></returns>
        public Boolean Find(string PName, int pRegisterPlace, string pRegisterCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM organization WHERE Replace([name], ' ' ,'') = Replace(" + JDataBase.Quote(PName) + ",' ', '')" +
                    " AND [RegisterNo]=" + JDataBase.Quote(pRegisterCode) +
                    " AND [RegisterPlace]=" + pRegisterPlace.ToString());

                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///  جستجو بر اساس محل ثبت و شماره ثبت
        /// </summary>
        /// <param name="pRegisterPlace"></param>
        /// <param name="pRegisterCode"></param>
        /// <returns></returns>
        public bool Find(int pRegisterPlace, string pRegisterCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pRegisterCode.Trim() == "" || pRegisterPlace == -1)
                    return false;
                db.setQuery("SELECT * FROM organization WHERE [RegisterPlace]=" + pRegisterPlace.ToString() +
                    " AND [RegisterNo]=" + JDataBase.Quote(pRegisterCode));
                db.Query_DataReader();
                return db.DataReader.HasRows;
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
        private bool _GetSignList()
        {
            if (SignatureMen == null)
                return false;
            foreach (DataRow row in SignatureMen.Rows)
            {
                JSignatureMen signMan = new JSignatureMen();
                JTable.SetToClassProperty(signMan, row);
                if (SignatureList == null)
                    SignatureList = new List<JSignatureMen>();
                SignatureList.Add(signMan);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            return GetData(pCode, "");
        }
        public Boolean GetData(int pCode, string pDate)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM organization WHERE [Code] = " + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
				if (db.DataReader.Read())
				{
					JTable.SetToClassProperty(this, db.DataReader);
					SignatureMen = JSignatureMen.LoadSignatureMen(pCode);
					Address = new JPersonAddress(pCode);
					///انتخاب اشخاص صاحب امضایی که تاریخ شروع و پایان آنها با تاریخ ورودی مطابقت دارد
					if (pDate != "")
						SignatureMen.DefaultView.RowFilter =
							" (FromDate = '' OR FromDate<='" + pDate + "')" +//JDataBase.Quote(JDateTime.FarsiDate(Convert.ToDateTime(pDate)).ToString(), false)
							" AND (ToDate= '' OR ToDate>='" + pDate + "')";//JDataBase.Quote(JDateTime.FarsiDate(Convert.ToDateTime(pDate)).ToString(), false)
					//SignatureMen = SignatureMen.DefaultView.dat
					//SignatureMen = SignatureMen.DefaultView.ToTable();
					_GetSignList();
					return true;
				}
				else
				{
					Address = new JPersonAddress();
				}
                return false;
            }
            catch (Exception ex)
            {
                return false;
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        public static string _SelectQuery =
             @" SELECT " + JTableNamesClassLibrary.LegalPerson + @".name Title, 
             (SELECT top 1 A.tafsilicode FROM clsAllPerson A WHERE A.Code = " + JTableNamesClassLibrary.LegalPerson + ".Code) 'tafsilicode'," +
             JTableNamesClassLibrary.LegalPerson + ".Code, " + JTableNamesClassLibrary.LegalPerson + ".name, RegisterNo, " +
             @"(select top 1 name from subdefine where Code = Organization.RegisterPlace)
              RegisterPlace , 
              (select top 1 name from subdefine where Code = Organization.CompanyType)
               CompanyType, " +
             JTableNamesClassLibrary.LegalPerson + ".Subject, " + JTableNamesClassLibrary.LegalPerson + ".Description, " +
             JDataBase.EnumToCaseStatement(JTableNamesClassLibrary.LegalPerson + ".Status", typeof(JCompanyStatuses)) + " Status " +
                  @",(Select top 1 Tel from clsPersonAddress  where PCode = organization.Code and AddressType = 0 ) Tel
                  ,(Select top 1 Address from clsPersonAddress  where PCode = organization.Code and AddressType = 0 ) Address
                FROM " + JTableNamesClassLibrary.LegalPerson;
        public JMyDataReader GetUserData(int aCode)
        {
            JDataBase db = new JDataBase();
            db.setQuery(@"Select VOrganizationChart.Code as [Post_Code], VOrganizationChart.user_code as [User_Code] from EmpEmployee
                            inner join VOrganizationChart on VOrganizationChart.pCode = EmpEmployee.pCode
                            where EmpEmployee.PersonNumber = " + aCode);
            db.Query_DataReader();
            if (db.DataReader.Read())
                return db.DataReader;
            else
            {
                db.Dispose();
                return null;
            }
        }

        /// <summary>
        /// جستجو شخص حقوقی
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pRegisterNo"></param>
        /// <param name="pRegisterPlace"></param>
        /// <param name="pSubject"></param>
        /// <param name="pCompanyType"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public static DataTable SearchPerson(int pCode, string pName, string pDescription, string pRegisterNo
                , int pRegisterPlace, string pSubject, int pCompanyType, int pStatus)
        {
            return SearchPerson(pCode, pName, pDescription, pRegisterNo, pRegisterPlace, pSubject, pCompanyType, pStatus, "");
        }

        public static DataTable SearchPerson(int pCode, string pName, string pDescription, string pRegisterNo
                , int pRegisterPlace, string pSubject, int pCompanyType, int pStatus, string pCondition)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = _SelectQuery + " WHERE 1=1 ";
                if (pCode != 0)
                {
                    Query = Query + " AND " + JTableNamesClassLibrary.LegalPerson + ".Code = " + pCode.ToString();
                }
                if (pName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery(JTableNamesClassLibrary.LegalPerson + ".Name", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pName, false) + '%');
                }
                if (pDescription.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery(JTableNamesClassLibrary.LegalPerson + ".Description", true) + " LIKE "
                                            + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pDescription, false) + '%');
                }
                if (pRegisterNo.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery(JTableNamesClassLibrary.LegalPerson + ".RegisterNo", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pRegisterNo, false) + '%');
                }
                if (pRegisterPlace != 0 && pRegisterPlace != -1)
                {
                    Query = Query + " AND " + JTableNamesClassLibrary.LegalPerson + ".RegisterPlace=" + pRegisterPlace.ToString();
                }
                if (pSubject.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery(JTableNamesClassLibrary.LegalPerson + ".Subject", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pSubject, false) + '%');
                }

                if (pCompanyType != 0 && pCompanyType != -1)
                {
                    Query = Query + " AND " + JTableNamesClassLibrary.LegalPerson + ".CompanyType=" + pCompanyType.ToString();
                }

                if (pStatus != 0 && pStatus != -1)
                {
                    Query = Query + " AND Status=" + pStatus.ToString();
                }
                if (pCondition.Trim().Length > 0)
                    Query += " AND " + pCondition;

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


        #endregion GetInfo
        // Node
        #region Node
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JOrganizationsTableEnum.Code.ToString()], "ClassLibrary.JOrganization");
            Node.Icone = JImageIndex.LegalPerson.GetHashCode();
            Node.Name = pRow[JOrganizationsTableEnum.Name.ToString()].ToString();
            Node.Hint = JLanguages._Text("RegisterNo:") + " " + pRow[JOrganizationsTableEnum.RegisterNo.ToString()] + "\n" +
                JLanguages._Text("Status:") + pRow[JOrganizationsTableEnum.Status.ToString()];
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.JOrganization.ShowDialog", null, new object[] { Node.Code });
            //اکشن مشاهده
            JAction viewAction = new JAction("View...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { Node.Code });
            Node.MouseDBClickAction = viewAction;
            Node.EnterClickAction = viewAction;
            //اکشن حذف
            JAction deleteAction = new JAction("Delete...", "ClassLibrary.JOrganization.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = deleteAction;

            //اکشن انحلال
            JAction BreakupAction = new JAction("Breakup...", "Legal.JbreakupOrg.ShowDialog", new object[] { 0, Node.Code }, null);
            Node.DeleteClickAction = BreakupAction;

            //اکشن جدید
            JAction newAction = new JAction("New...", "ClassLibrary.JOrganization.ShowDialog", null, null);
            JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JOrganization", Node.Code);

            /// اکشن سهامداری
            JAction SahamdarAction = new JAction("Sahamdar...", "ClassLibrary.JAllPerson.UpdateSahamdar", new object[] { Node.Code }, null);

            pMenu.Insert(SahamdarAction);
            pMenu.Insert(BreakupAction);
            pMenu.Insert(newAction);
            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(viewAction);
            Node.Popup = pMenu;
            return Node;
        }
        #endregion Node
    }
    /// <summary>
    /// کلاس لیست سازمان ها
    /// </summary>
    public class JOrganizations : JSystem
    {
        //properties
        #region Properties
        private string _SQL = "SELECT [Code],[name] FROM organization %WHERE% ORDER BY [name]";
        public JOrganization[] Items;
        private JOrganization[] _Items;
        //public JOrganization[] Items
        //{
        //    get
        //    {
        //        return _Items;
        //    }
        //}
        #endregion properties
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public JOrganizations()
        //: this("")
        {
        }
        /// <summary>
        /// سازنده 
        /// </summary>
        /// <param name="where"></param>
        public JOrganizations(string where)
        {
            if (where.Length > 0)
                where = "AND" + where;
            _SQL = _SQL.Replace("%WHERE%", "WHERE 1=1 " + where);
            _getItems();
        }
        #endregion Constructors
        // GetInfo
        #region GetInfo

        #region MASOOMIAN
        /// <summary>
        /// خواندن اطلاعات سازمان ها از بانک اطلاعاتی و و قرار دادن در متغیر 
        /// </summary>
        private void _getItems()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                _Items = new JOrganization[DB.DataSet.Tables[0].Rows.Count];
                int count = 0;
                Array.Resize(ref Items, DB.DataSet.Tables[0].Rows.Count);
                foreach (DataRow DR in DB.DataSet.Tables[0].Rows)
                {
                    Items[count] = new JOrganization();
                    Items[count].GetData(int.Parse(DR["Code"].ToString()));
                    count++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        ///رشته اس کیو ال لیست سازمان ها را بر میگرداند
        /// </summary>
        /// <param name="pOrganizationCode">در صورتی که کد مخزن صفر باشد تمامی دبیرخانه ها را بر میگرداند  در غیر این صورت ، دبیرخانه هایی که از آن مخزن استفاده میکنند را می دهد</param>
        /// <returns>اطلاعات سازمان</returns>        
        public string GetOrganizationSql(int pOrganizationCode)
        {
            string strSql = "SELECT     o.Code, o.name, (CASE ISNULL(CAST(o.access_code AS nvarchar(20)), '0')  WHEN '0' THEN o.[name] ELSE o.[name] + '_' + CAST(o.access_code AS nvarchar(20)) END) AS 'full_title', o2.name AS 'parent_name', o.managing_director, o.phone_number, o.address, o.description, o.access_code FROM         organization AS o LEFT OUTER JOIN  organization AS o2 ON o2.Code = o.parentcode ORDER BY o.name";
            if (pOrganizationCode > 0)
            {
                strSql += " where Code = " + pOrganizationCode;
            }
            return strSql;
        }
        /// <summary>
        ///لیست سازمان ها را بر میگرداند
        /// </summary>
        /// <param name="pOrganizationCode">در صورتی که کد مخزن صفر باشد تمامی دبیرخانه ها را بر میگرداند  در غیر این صورت ، دبیرخانه هایی که از آن مخزن استفاده میکنند را می دهد</param>
        /// <returns>اطلاعات سازمان</returns>        
        public DataTable GetOrganization(int pOrganizationCode)
        {//+ '_' + CAST(access_code AS nvarchar(20))
            string strSql = "SELECT [Code],[name] ,(CASE ISNULL(CAST(access_code AS nvarchar(20)), '0') WHEN '0' THEN [name] ELSE [name] END)AS 'full_title',[parentcode],[managing_director],[phone_number],[address],[description],[access_code] as 'accesscode' FROM organization ";
            if (pOrganizationCode > 0)
            {
                strSql += " WHERE Code = " + pOrganizationCode;
            }
            strSql += " ORDER BY name ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(strSql);
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
        /// <summary>
        /// آخرین کد انتخاب شده برای سازمانها را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public int GetMaxAccessCode()
        {
            JDataBase db = new JDataBase();
            db.setQuery("SELECT ISNULL(MAX(access_code),0)+0 FROM organization");
            return int.Parse(db.Query_ExecutSacler().ToString());
        }
        #endregion معصومیان

        public static DataTable GetDataTable(int pCode)
        {
            if (!JPermission.CheckPermission("ClassLibrary.JOrganizations.GetDataTable", false))
                return null;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string where = "";
                if (pCode != 0)
                {
                    where = " WHERE " + JTableNamesClassLibrary.LegalPerson + ".Code=" + pCode;
                }
                DB.setQuery(JOrganization._SelectQuery + where);
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

        public static string GetWebQuery()
        {
            return @"SELECT top 100 percent o.code, o.name, o.[address], o.phone_number
                        FROM organization o ORDER BY o.name";
        }

        #endregion GetInfo
        // View Nodes
        #region View
        //public static DataTable GetDataTable(int 



        public void ListView()
        {
            try
            {
                Nodes.ObjectBase = new JAction("GetLegalPersonNodes", "ClassLibrary.JOrganization.GetNode");
                Nodes.DataTable = GetDataTable(0);

                //JAction newAction = new JAction("New...", "ClassLibrary.JOrganization.ShowDialog", null, null);
                Nodes.GlobalMenuActions.Insert(JStaticAction._LegalPersonsNew());
                JToolbarNode TN = new JToolbarNode();
                TN.Icon = JImageIndex.Add;
                TN.Hint = "New...";
                TN.Click = JStaticAction._LegalPersonsNew();
                Nodes.AddToolbar(TN);

                //try
                //{
                //    GetLists();
                //    JAction Action = new JAction("New...", "ClassLibrary.JOrganization.InsertForm");
                //    Nodes.GlobalMenuActions = new JPopupMenu("ClassLibrary.JOrganization", 0);
                //    Nodes.GlobalMenuActions.Insert(Action);
                //    Nodes.AddColumn("Name:200");
                //    Nodes.AddColumn("phone_number:120");
                //    Nodes.AddColumn("address:300");
                //    Nodes.AddColumn("description:400");
                //    Nodes.ListViewInt.View = System.Windows.Forms.View.Details;
                //    Nodes.ListViewInt.FullRowSelect = true;
                //    Nodes.ListViewInt.GridLines = true;

                //for (int i = 0; i < Items.Length; i++)
                //{
                //    Nodes.Insert(Items[i].GetNode());
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
        public void GetLists()
        {
            try
            {

                string strSql;
                strSql = "SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList +
                         " o1.Code, o1.name, o1.parentcode, o1.managing_director, o1.phone_number, o1.address, o1.description, o2.name AS 'parentname'" +
                         " FROM   organization AS o1 LEFT OUTER JOIN  organization AS o2 ON o1.parentcode = o2.Code order by o1.name";
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery(strSql);
                DB.Query_DataReader();
                Array.Resize(ref Items, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Items[Count] = new JOrganization();
                    JTable.SetToClassProperty(Items[Count], DB.DataReader);
                    Count++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        public JNode[] TreeView()
        {
            return null;
        }
        #endregion View
    }
}
