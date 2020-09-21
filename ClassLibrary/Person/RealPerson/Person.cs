using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using ArchivedDocuments;
using System.Drawing;

namespace ClassLibrary
{
    public class JPerson : JSystem
    {
        #region Constructor
        public JPerson()
        {
            HomeAddress = new JPersonAddress();
            WorkAddress = new JPersonAddress();
        }

        public JPerson(int pCode)
        {
            if (find(pCode))
            {
                getData(pCode);
                HomeAddress = new JPersonAddress(pCode, JAddressTypes.Home);
                WorkAddress = new JPersonAddress(pCode, JAddressTypes.Work);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// حداکثر طول کد
        /// </summary>
        private int MaxCodeLength
        {
            get
            {
                return DefaultCode.ToString().Length + 1;
            }
        }
        /// <summary>
        /// مقدار پیشفرض برای کد
        /// </summary>
        private int DefaultCode
        {
            get
            {
                return 9999999;
            }
        }

        public Boolean HasData
        {
            get
            {
                return Code != 0;
            }
        }
        #region Main Properties
        /// <summary>
        /// کد فرد 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string Fam { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string ShSh { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string PDesc { get; set; }
        /// <summary>
        /// کد محل تولد
        /// </summary>
        public int BirthplaceCode { get; set; }
        /// <summary>
        /// تغییر نام داده است
        /// </summary>
        public int OldChangeName { get; set; }
        /// <summary>
        /// تغییر نام داده است
        /// </summary>
        public int NewChangeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BirthplaceCodeText
        {
            get
            {
                JCitiy Ci = new JCitiy();
                if (Ci.GetData(BirthplaceCode))
                    return Ci.Name;
                else
                    return "";

            }
        }
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BthDate { get; set; }
        /// <summary>
        /// محل صدور شناسنامه 
        /// </summary>
        public int Sader { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SaderText
        {
            get
            {
                JCitiy Ci = new JCitiy();
                if (Ci.GetData(Sader))
                    return Ci.Name;
                else
                    return "";

            }
        }
        /// <summary>
        /// شماره ملی
        /// </summary>
        public string ShMeli { get; set; }
        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// اطلاعات شخص ناقص می باشد-شماره شناسنامه و غیره ثبت نشده است
        /// </summary>
        public bool IncompleteInformation { get; set; }
        /// <summary>
        /// شماره پرونده سهام
        /// </summary>
        public Int64 _SharePCode;

        public int _TafsiliCode;

		public int _CompanyCode;

        #endregion Main

        #region Address Properties
        /// <summary>
        /// آدرس منزل
        /// </summary>
        public JPersonAddress HomeAddress
        {
            get;
            set;
        }
        /// <summary>
        /// آدرس محل کار
        /// </summary>
        public JPersonAddress WorkAddress
        {
            get;
            set;
        }

        #endregion Address

        #region Death Properties
        /// <summary>
        /// متوفی 
        /// </summary>
        public bool Died { get; set; }
        ///// <summary>
        ///// تاریخ فوت
        ///// </summary>
        //public DateTime DieDate { get; set; }
        ///// <summary>
        ///// شماره گواهی فوت
        ///// </summary>
        //public string DieNumber { get; set; }
        ///// <summary>
        ///// تاریخ گواهی فوت
        ///// </summary>
        //public DateTime DeathCertificateDate { get; set; }

        //public string DeatCertificateCode { get; set; }
        #endregion Death

        #region Employment Properties
        /// <summary>
        /// شماره پرسنلی
        /// </summary>
        public int PersonelNo;
        /// <summary>
        /// افراد تحت تکفل
        /// </summary>
        public int Suport { get; set; }
        #endregion Employment

        #region Legal Properties
        /// <summary>
        /// ممنوع المعامله
        /// </summary>
        public bool Blocked { get; set; }
        /// <summary>
        /// تائید حقوقی جهت ثبت قراردادها
        /// </summary>
        public bool LegelConfirm { get; set; }
        #endregion Legal

        #region Finance Properties
        /// <summary>
        ///کد تفصیلی
        /// </summary>
        public Int64 Detailed { get; set; }
        #endregion

        #region Image Properties
        /// <summary>
        /// کد تصویر شخص در سیستم بایگانی
        /// </summary>
        public int PersonImageCode
        {
            get;
            set;
        }
        /// <summary>
        /// کد تصویر امضا در سیستم بایگانی
        /// </summary>
        public int SignatureImageCode
        {
            get;
            set;
        }

        //private System.Drawing.Image _SignatureImage;

        //public System.Drawing.Image SignatureImage
        //{
        //    get
        //    {
        //        try
        //        {
        //            if (_SignatureImage != null)
        //                return _SignatureImage;
        //            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument();
        //            JFile sigFile = archive.RetrieveContent(this.GetType().FullName, this.Code, SignatureImageCode);
        //            _SignatureImage = System.Drawing.Image.FromStream(sigFile.Stream);
        //            return _SignatureImage;
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}

        public System.Drawing.Image SignatureImage
        {
            get
            {
                JArchiveDocument archive = new JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                JFile _PersonImage;
                try
                {
                    if (archive.Retrieve(this.SignatureImageCode))
                    {
                        _PersonImage = archive.Content;
                        if (_PersonImage != null)
                            return System.Drawing.Image.FromStream(_PersonImage.Stream);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return null;
                }
                finally
                {
                    archive.Dispose();
                }
            }
        }

        public System.Drawing.Image PersonImage
        {
            get
            {
                JArchiveDocument archive = new JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                JFile _PersonImage;
                try
                {
                    if (archive.Retrieve(this.PersonImageCode))
                    {
                        _PersonImage = archive.Content;
                        if (_PersonImage != null)
                            return System.Drawing.Image.FromStream(_PersonImage.Stream);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return null;
                }
                finally
                {
                    archive.Dispose();
                }
            }
        }

        #endregion Images

        #region NonIranian
        public bool NonIranian { get; set; }
        public string NonIranianSHCode { get; set; }
        public string NonIranianFamilyCode { get; set; }
        public int NonIranianCity { get; set; }
        public DateTime NonIraninDateCard { get; set; }

        #endregion

        #endregion Properties

        #region Search

        public int GetPersonPostCode(int code)
        {
            string query = "select Code from organizationchart where user_code =(select code from users where pcode = " + code + ")";
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(query);
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    return Convert.ToInt32(db.DataReader["Code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// جستجو بر اساس کد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.PersonTable + " WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader())
                {
                    return db.DataReader.HasRows;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }

        }

        public int find(JPerson pPerson)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();//JGlobal.MainFrame.GetConfig().PersonSahamTableName
            try
            {
                db.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.PersonTable + 
                    " WHERE " + JDataBase.RemoveSpaceQuery("Name", true) + "=" + JDataBase.Quote(JDataBase.RemoveSpaceQuery(pPerson.Name, false)) + 
                    " AND " +
                    JDataBase.RemoveSpaceQuery("Fam", true) + "="  + JDataBase.Quote(JDataBase.RemoveSpaceQuery(pPerson.Fam, false)) + 
                    " AND ShSh=" + JDataBase.Quote(pPerson.ShSh) +
                    " AND BirthplaceCode=" + pPerson.BirthplaceCode.ToString() +
                    " AND BthDate='" + pPerson.BthDate.ToString("yyyy/MM/dd") +"'"+
                    " AND Code <>" + pPerson.Code);
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    return Convert.ToInt32(db.DataReader["Code"]);
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس کد ملی
        /// </summary>
        /// <param name="pPerson"></param>
        /// <returns></returns>
        public int find(string pPerson, int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pPerson.Length >= 10)
                {
                    db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonTable +
                        " WHERE shMeli=" + JDataBase.Quote(pPerson) + " AND Code <>" + pCode.ToString());
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
        /// جستجو بر اساس فقط کد ملی
        /// </summary>
        /// <param name="shMeli"></param>
        /// <returns></returns>
        public bool find(string shMeli)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            DataTable dt = new DataTable();
            try
            {
                if (shMeli.Length >= 10)
                {
                    db.setQuery("SELECT * FROM clsperson WHERE shMeli = '" + shMeli + "'");
                    dt = db.Query_DataTable();
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
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
        public int find(Int64 SharePCode, int pCode)
        {
            try
            {
                return ManagementShares.ShareCompany.JSharepCode.GetPersonShare(_CompanyCode, SharePCode);
            }
            catch
            {
                return 0;
            }
			
           

			//JDataBase db = JGlobal.MainFrame.GetDBO();
			//try
			//{
			//	if (SharePCode > 0)
			//	{
			//		db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.AllPerson +
			//			" WHERE SharePCode=" + SharePCode.ToString() + " AND Code <>" + pCode.ToString());
			//		db.Query_DataReader();
			//		if (db.RecordCount > 0)
			//		{
			//			db.DataReader.Read();
			//			int Ret = Convert.ToInt32(db.DataReader["Code"]);
			//			return Ret;
			//		}
			//	}
			//	return 0;
			//}
			//finally
			//{
			//	db.Dispose();
			//}
        }


        /// <summary>
        /// دستور سلکت
        /// </summary>
        public static string _SelectQuery = " SELECT  " + JTableNamesClassLibrary.PersonTable + @".Code,
            (SELECT top 1 A.tafsilicode FROM clsAllPerson A WHERE A.Code = Code) 'tafsilicode'," +
                    JTableNamesClassLibrary.PersonTable + ".Fam+' - '+" + JTableNamesClassLibrary.PersonTable + ".Name Title, " +
                    JTableNamesClassLibrary.PersonTable + ".Name, " +
                    JTableNamesClassLibrary.PersonTable + ".Fam, " + JTableNamesClassLibrary.PersonTable + ".FatherName, " +
                    JTableNamesClassLibrary.PersonTable + ".ShSh, " +
                    "dbo.DateEnToFa(" + JTableNamesClassLibrary.PersonTable + ".BthDate) BthDate, " +
                    JTableNamesClassLibrary.PersonTable + ".ShMeli, BaseCitySader.Name Sader, BaseCity.Name Birthplace, Died , " +
                    " Case " + JTableNamesClassLibrary.PersonTable + ".Gender WHEN 1 THEN " + JDataBase.Quote(JLanguages._Text("Man")) +
                    " WHEN 0 THEN " + JDataBase.Quote(JLanguages._Text("Woman")) + @" ELSE '' END Gender ,PDesc 
                  ,(Select top 1 Tel from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 1 ) HomeTel
                  ,(Select top 1 Mobile from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 1 ) Mobile
                  ,(Select top 1 Tel from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 2 ) WorkTel
                  ,(Select top 1 Address from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 1 ) HomeAddress
                  ,(Select top 1 Address from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 2 ) WorkAddress
                  ,(Select  top 1 (select name from subdefine where Code=City) from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 1 ) CityHomeAddress
                  ,(Select  top 1 (select name from subdefine where Code=City) from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 2 ) CityWorkAddress 
                  ,(Select  top 1 PostalCode from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 1 ) PostalCodeHome 
                  ,(Select  top 1 PostalCode from clsPersonAddress  where PCode = clsPerson.Code and AddressType = 2 ) PostalCodeOffice 
                  --,(select top 1 (select Fam from VOrganizationChart where VOrganizationChart.Code=ERP_Archive.dbo.clsHistory.PostCode) from ERP_Archive.dbo.clsHistory where ObjectCode=ClsPerson.Code And Description='Insert') 'Creator' 
					--,Fields 
                    FROM " +
                    JTableNamesClassLibrary.PersonTable +
                    " LEFT OUTER JOIN " + JTableNamesClassLibrary.SubBaseDefine + " BaseCity ON " + JTableNamesClassLibrary.PersonTable + ".BirthplaceCode = BaseCity.Code " +
                    " LEFT OUTER JOIN " + JTableNamesClassLibrary.SubBaseDefine + " BaseCitySader ON " + JTableNamesClassLibrary.PersonTable + ".Sader = BaseCitySader.Code " +
					@" --JOIN 
					  where " + JPersonTableEnum.IncompleteInformation + "='0'";

        /// <summary>
        /// جستجو بر اساس فیلدهای اصلی شخص
        /// </summary>
        /// <param name="pCode">کد</param>
        /// <param name="pName">نام</param>
        /// <param name="pLastName">نام خانوادگی</param>
        /// <param name="pFatherName">نام پدر</param>
        /// <param name="pIdNo">شماره شناسنامه</param>
        /// <param name="pBirthPlaceCode">محل تولد</param>
        /// <param name="pBirthDateFrom">تاریخ تولد از</param>
        /// <param name="pBirthDateTo">تاریخ تولد تا</param>
        /// <param name="pSader">محل صدور</param>
        /// <param name="pNationalCode">کد ملی</param>
        /// <param name="Gender">جنسیت در صورتی که -1 باشد درنظر گرفته نمیشود. در صورت 0 زن و در صورت 1 مرد</param>
        /// <returns></returns>
        public static DataTable SearchPerson(int pCode, string pName, string pLastName, string pFatherName
                , string pIdNo, int pBirthPlaceCode, DateTime pBirthDateFrom, DateTime pBirthDateTo, int pSader
                , string pNationalCode, int Gender, string pDescription)
        {
            return SearchPerson(pCode, pName, pLastName, pFatherName, pIdNo, pBirthPlaceCode, pBirthDateFrom, pBirthDateTo, pSader, pNationalCode, Gender, "", pDescription);

        }

        public static DataTable SearchPerson(int pCode, string pName, string pLastName, string pFatherName
                , string pIdNo, int pBirthPlaceCode, DateTime pBirthDateFrom, DateTime pBirthDateTo, int pSader
                , string pNationalCode, int Gender, string pCondition, string pDescription)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = _SelectQuery.Replace("--JOIN", "").Replace("--,Fields", "");// +"  WHERE 1=1 ";
                if (pCode != 0)
                {
                    Query = Query + " AND " + JTableNamesClassLibrary.PersonTable + ".Code = " + pCode.ToString();
                }
                if (pName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery(JTableNamesClassLibrary.PersonTable + ".Name", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pName, false) + '%');
                }
                if (pLastName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery("Fam", true) + " LIKE "
                                            + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pLastName, false) + '%');
                }
                if (pFatherName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery("FatherName", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pFatherName, false) + '%');
                }
                if (pIdNo.Trim() != "")
                {
                    Query = Query + " AND ShSh =" + JDataBase.Quote(pIdNo);
                }
                if (pBirthPlaceCode != 0 && pBirthPlaceCode != -1)
                {
                    Query = Query + " AND BirthplaceCode=" + pBirthPlaceCode.ToString();
                }
                if (pSader != 0 && pSader != -1)
                {
                    Query = Query + " AND Sader=" + pSader.ToString();
                }
                if (pBirthDateFrom != DateTime.MinValue)
                {
                    Query = Query + " AND BthDate >= @BthFromDate";
                    DB.AddParams("@BthFromDate", pBirthDateFrom);
                }
                if (pBirthDateTo != DateTime.MinValue)
                {
                    Query = Query + " AND BthDate <= @BthToDate";
                    DB.AddParams("@BthToDate", pBirthDateTo);
                }
                if (pNationalCode.Trim() != "")
                {
                    Query = Query + " AND ShMeli =" + JDataBase.Quote(pNationalCode);
                }
                if (Gender != -1)
                {
                    Query = Query + " AND Gender =" + Gender.ToString();
                }
                if (pCondition != null)
                    if (pCondition.Trim().Length > 0)
                        Query += " AND " + pCondition;

                if (pDescription != null && pDescription.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery("PDesc", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pDescription, false) + '%');
                }
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

        /// <summary>
        /// جستجو بر اساس نام خانوادگی و کد شخص
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pLastName"></param>
        /// <returns></returns>
        public static DataTable SearchPerson(int pCode, string pLastName)
        {
            return SearchPerson(pCode, "", pLastName, "", "", 0, DateTime.MinValue, DateTime.MinValue, 0, "", -1, "");
        }

        /// <summary>
        /// خواندن اطلاعات شخص از دیتابیس
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean getData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonTable + " WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }


        #endregion

        #region Functions
        public override string ToString()
        {
            return this.Fam + " - " + this.Name;
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
            allPerson.IDNo = this.ShSh;
            allPerson.Active = !this.Died;
            allPerson.IncompleteInformation = this.IncompleteInformation;
            allPerson.PersonType = JPersonTypes.RealPerson;
            allPerson.TafsiliCode = _TafsiliCode;
            //allPerson.SharePCode = _SharePCode;
            return allPerson.Insert(pDB);
        }

        private bool _InsertInNonIranianAllPerson(JDataBase pDB)
        {
            JAllPerson allPerson = new JAllPerson();
            allPerson.Name = this.ToString();
            allPerson.Code = this.Code;
            allPerson.IDNo = this.ShSh;
            allPerson.Active = !this.Died;
            allPerson.IncompleteInformation = this.IncompleteInformation;
            allPerson.PersonType = JPersonTypes.NonIranianPerson;
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
            JAllPerson allPerson = null;
            if (this.Code <= 0)
                allPerson = new JAllPerson();
            else
                allPerson = new JAllPerson(this.Code);
            allPerson.Name = this.ToString();
            allPerson.Code = this.Code;
            allPerson.IDNo = this.ShSh;
            allPerson.Active = !this.Died;
            allPerson.IncompleteInformation = this.IncompleteInformation;
            allPerson.TafsiliCode = _TafsiliCode;
            //if (this.Code <= 0)
            //    allPerson.SharePCode = _SharePCode;
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

        public bool UpdateAvl()
        {
            JPersonTable AT = new JPersonTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }
        /// <summary>
        /// ویرایش اطلاعات فرد مشخص شده
        /// </summary>
        /// <returns></returns>
        public Boolean Update(bool SaveHistory)
        {
            if (find(Code))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    if (JPermission.CheckPermission("ClassLibrary.JPerson.Update"))
                    {
                        if (find(this) > 0)
                        {
                            JMessages.Error("PersonExists", "error");
                            return false;
                        }
                        if ((this.ShMeli != null) && find(this.ShMeli, this.Code) > 0)
                        {
                            JMessages.Error("NationalCodeRepeated", "error");
                            return false;
                        }
                        if (find(this._SharePCode, this.Code) > 0)
                        {
                            //JMessages.Error("این شماره سهامداری قبلا وارد شده است.", "error");
                            //return false;
                        }
                        JPersonTable JPT = new JPersonTable();
                        JPT.SetValueProperty(this);
                        DB.beginTransaction("UpdatePerson");
                        if (JPT.Update(DB))
                        {
							if (_SharePCode > 0)
								JShareWebLog.Insert(DB, "clsPerson", Code, 'i');
							if (_SharePCode > 0)
							{

								ManagementShares.ShareCompany.JSharepCode SC = new ManagementShares.ShareCompany.JSharepCode();
								//int TempShareCode = ManagementShares.ShareCompany.JSharepCode.(_CompanyCode, _SharePCode);
								if (!SC.find(_CompanyCode, Code, true))
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
							
                            if (_UpdateInAllPerson(DB))
                            {
                                if (_SharePCode > 0)
                                    if (JShareWebLog.Insert(DB, "clsPerson", Code, 'u') < 0)
                                    {
                                        DB.Rollback("UpdatePerson");
                                        return false;
                                    }

								
								DB.Commit();
								
								
								//JDataBase TDB1 = new JDataBase();
								//JDataBase TDB2 = new JDataBase();
								try
								{
									//TDB1.setQuery("exec SP_PersonAddressViewSharePCode");
									//TDB1.Query_Execute(true);

									//TDB2.setQuery("exec SP_PersonAddressView");
									//TDB2.Query_Execute(true);
								}
								finally
								{
								}
								
                                if (!IncompleteInformation)
                                    try
                                    {
										if (Nodes != null && !JMainFrame.IsWeb())
										{
												Nodes.Refreshdata(Nodes.CurrentNode, JPersons.GetDataTable(Code).Rows[0], Nodes.RefreshAuto);
										}

                                    }
                                    catch
                                    {
                                    }
                                if (SaveHistory)
                                    Histroy.Save(this, JPT, Code, "Update");
                                ///درصورتی که قبلا آدرسی درج شده بروزرسانی آدرس، در غیر اینصورت درج آدرس
                                if (HomeAddress.Find(this.Code, JAddressTypes.Home) > 0)
                                    HomeAddress.Update();
                                else
                                    HomeAddress.Insert(this.Code, this._SharePCode);
                                if (WorkAddress.Find(this.Code, JAddressTypes.Work) > 0)
                                    WorkAddress.Update();
                                else
                                    WorkAddress.Insert(this.Code, this._SharePCode);
                                return true;
                            }
                        }
                        DB.Rollback("UpdatePerson");
                        return false;
                    }
                    /// else
                    ///  return false;
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
            }
            return false;
        }

        public int GetPersonNumber()
        {
            int PersonNumber = 0;
            JDataBase DB = new JDataBase();// JGlobal.MainFrame.GetDBO();
            DB.setQuery(@"select PersonNumber from EmpEmployee  WHERE pcode = " + Code.ToString());
            Int32.TryParse(Convert.ToString(DB.Query_ExecutSacler()), out PersonNumber);
            return PersonNumber;
        }

        public Boolean DeleteEmp(JDataBase DB)
        {
            DB.setQuery("DELETE FROM [dbo].[EmpEmployee] WHERE [pCode] = " + Code + @" 
                SELECT 1");
            try
            {
                DataTable dt = DB.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JException.Exceptions.Add(ex);
                return false;
            }
            finally
            {
            }
        }
        public int InsertEmp(int PersonNumber)
        {
            JDataBase DB = new JDataBase();// JGlobal.MainFrame.GetDBO();
            string Query = @"DECLARE @Code int = 0
            SELECT @Code = Code FROM [dbo].[EmpEmployee] WHERE [pCode] = " + Code.ToString() + @"
            IF @Code > 0 
                UPDATE [dbo].[EmpEmployee] SET [PersonNumber] = " + PersonNumber + @" WHERE Code = @Code
            ELSE
            BEGIN
                SET @Code = (SELECT MAX(code) from EmpEmployee) + 1
                INSERT INTO [dbo].[EmpEmployee] 
                (
                    [Code],[pCode],[JobTitleCode],[PostTitleCode],[PersonNumber],[PersonCart],[Active],[PersonID]
                   ,[Activity],[Sector],[id_maghta],[id_cource],[graduatedPlace],[graduatedDate],[firstDrivingCard],[secondDrivingCard]
                   ,[motorCard],[id_militay],[moafReson],[servicePlace],[ServiceStart],[ServiceEnd],[warExpereience],[basigmembership]
                   ,[ShahidFamily],[janbazikind],[janbazPercent],[id_maskan],[azadefamily],[janbaz],[nesbatShahid],[nesbatJanbaz]
                   ,[nesbatAzade],[married],[bimeNom],[drivingcartNo],[lastSanavet],[employeeDate],[id_delayGroup],[accountnumber]
                   ,[id_bank],[id_parvandeh],[CompanyCode]
                ) 
                VALUES
                (
                    @Code, " + Code.ToString() + ",null,null," + PersonNumber + @",null,null,null
                    ,null,null,null,null,null,null,null,null
                    ,null,null,null,null,null,null,null,null
                    ,null,null,null,null,null,null,null,null
                    ,null,null,null,null,null,null,null,null
                    ,null,null,null
                )
            END";

            DB.setQuery(Query);
            DB.beginTransaction("InsertPersonNumber");
            try
            {
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                DB.Rollback("InsertPersonNumber");
                JException.Exceptions.Add(ex);
                return 0;
            }
            finally
            {
                DB.Commit();
            }
        }
        public Boolean UpdateEmp(int PersonNumber)
        {
            return InsertEmp(PersonNumber) > 0?true:false;
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
        /// حذف سمت وب
        /// </summary>
        /// <returns></returns>
        public Boolean WebDelete()
        {
            if (Code > 0)
            {
                if (JPermission.CheckPermission("ClassLibrary.JPerson.Delete"))
                {
                    JDataBase dataBase;
                    dataBase = JGlobal.MainFrame.GetDBO();
                    JPersonTable JPT = new JPersonTable();
                    JPT.SetValueProperty(this);
                    dataBase.beginTransaction("DeletePerson");
                    if (!this.HomeAddress.Delete(dataBase))
                    {
                        dataBase.Rollback("DeletePerson");
                        return false;
                    }
                    if (!this.WorkAddress.Delete(dataBase))
                    {
                        dataBase.Rollback("DeletePerson");
                        return false;
                    }
                    if (!this.DeleteEmp(dataBase))
                    {
                        dataBase.Rollback("DeletePerson");
                        return false;
                    }
                    if (JPT.Delete(dataBase))
                    {
                        if (_DeleteFromAllPeson(dataBase))
                        {
                            /// حذف از آرشیو
                            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument();
                            archive.DeleteArchive(this.GetType().FullName, this.Code, true);
                            archive.Dispose();
                            if (_SharePCode > 0)
                                JShareWebLog.Insert(dataBase, "clsPerson", Code, 'd');
                            dataBase.Commit();
                            return true;
                        }
                        else
                        {
                            dataBase.Rollback("DeletePerson");
                            return false;
                        }
                    }
                    else
                    {
                        dataBase.Rollback("DeletePerson");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// بررسی وجود شخص در جداول مختلف سیستم
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>

        public string DoNotDelete(int pCode, JDataBase pDB)
        {
            string res = "";
            JDataBase dataBase = pDB;// JGlobal.MainFrame.GetDBO();
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
        public Boolean Delete(JDataBase pDB, bool pMsg)
        {
            return Delete(Code, pDB, pMsg);
        }
        public Boolean Delete(int pCode)
        {
            return Delete(pCode, null, true);
        }
        public Boolean Delete(int pCode, JDataBase pDB, bool pMsg)
        {
            if (find(pCode))
            {
                Code = pCode;
                JDataBase dataBase;
                if (pDB == null)
                    dataBase = JGlobal.MainFrame.GetDBO();
                else
                    dataBase = pDB;
                try
                {
                    if (JPermission.CheckPermission("ClassLibrary.JPerson.Delete"))
                    {
                        /// بررسی وجود شخص در جداول مختلف سیستم
                        string error = DoNotDelete(pCode, dataBase);
                        if (error != "")
                        {
                            JMessages.Error(error, "error");
                            return false;
                        }
                        ///
                        JPersonTable JPT = new JPersonTable();
                        JPT.SetValueProperty(this);
                        System.Windows.Forms.DialogResult dr = new System.Windows.Forms.DialogResult();
                        dr = System.Windows.Forms.DialogResult.Yes;
                        if (pMsg)
                            dr = JMessages.Question("AreYouSureDeletePerson?", "Question");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            //dataBase.beginTransaction("DeletePerson");
                            /// حذف آدرسها
                            if (!this.HomeAddress.Delete(dataBase))
                            {
                                dataBase.Rollback("DeletePerson");
                                return false;
                            }
                            if (!this.WorkAddress.Delete(dataBase))
                            {
                                dataBase.Rollback("DeletePerson");
                                return false;
                            }
                            if (JPT.Delete(dataBase))
                            {
                                if (_DeleteFromAllPeson(dataBase))
                                {
                                    /// حذف از آرشیو
                                    ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument();
                                    archive.DeleteArchive(this.GetType().FullName, this.Code, true);
                                    archive.Dispose();
                                    if (_SharePCode > 0)
                                        JShareWebLog.Insert(dataBase, "clsPerson", Code, 'd');
                                    dataBase.Commit();

                                    if (Nodes.CurrentNode != null)
                                        Nodes.Delete(Nodes.CurrentNode);
                                    //Nodes.Delete(JStaticNode._PersonNode(this));
                                    //Nodes.JanusGrid.SelectedRow.Delete();
                                    return true;
                                }
                            }
                            dataBase.Rollback("DeletePerson");
                        }
                        return false;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    dataBase.Rollback("DeletePerson");
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    if (pDB == null)
                        dataBase.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// developer can define whether permission would be checked or not!
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pDB"></param>
        /// <param name="pMsg"></param>
        /// <param name="checkPermission"></param>
        /// <returns></returns>
        public Boolean DeleteAVL(int pCode, JDataBase pDB, bool pMsg,bool checkPermission)
        {
            bool haspermission = true;
            if (checkPermission)
                haspermission = JPermission.CheckPermission("ClassLibrary.JPerson.Delete");
            if (find(pCode))
            {
                Code = pCode;
                JDataBase dataBase;
                if (pDB == null)
                    dataBase = JGlobal.MainFrame.GetDBO();
                else
                    dataBase = pDB;
                try
                {
                    if (haspermission)
                    {
                        /// بررسی وجود شخص در جداول مختلف سیستم
                        string error = DoNotDelete(pCode, dataBase);
                        if (error != "")
                        {
                            JMessages.Error(error, "error");
                            return false;
                        }
                        ///
                        JPersonTable JPT = new JPersonTable();
                        JPT.SetValueProperty(this);
                        System.Windows.Forms.DialogResult dr = new System.Windows.Forms.DialogResult();
                        dr = System.Windows.Forms.DialogResult.Yes;
                        if (pMsg)
                            dr = JMessages.Question("AreYouSureDeletePerson?", "Question");
                        if (true)//dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            //dataBase.beginTransaction("DeletePerson");
                            /// حذف آدرسها
                            if (!this.HomeAddress.Delete(dataBase))
                            {
                                dataBase.Rollback("DeletePerson");
                                return false;
                            }
                            if (!this.WorkAddress.Delete(dataBase))
                            {
                                dataBase.Rollback("DeletePerson");
                                return false;
                            }
                            if (JPT.Delete(dataBase))
                            {
                                if (_DeleteFromAllPeson(dataBase))
                                {
                                    /// حذف از آرشیو
                                    ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument();
                                    archive.DeleteArchive(this.GetType().FullName, this.Code, true);
                                    archive.Dispose();
                                    if (_SharePCode > 0)
                                        JShareWebLog.Insert(dataBase, "clsPerson", Code, 'd');
                                    dataBase.Commit();

                                    if (Nodes.CurrentNode != null)
                                        Nodes.Delete(Nodes.CurrentNode);
                                    //Nodes.Delete(JStaticNode._PersonNode(this));
                                    //Nodes.JanusGrid.SelectedRow.Delete();
                                    return true;
                                }
                            }
                            dataBase.Rollback("DeletePerson");
                        }
                        return false;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    dataBase.Rollback("DeletePerson");
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    if (pDB == null)
                        dataBase.Dispose();
                }
            }
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
                if (JPermission.CheckPermission("ClassLibrary.JPerson.Insert"))
                {
                    JPersonTable JPT = new JPersonTable();
                    JPT.SetValueProperty(this);
                    if (this.IncompleteInformation == false && !pManual)
                    {
                        int _Code = find(this);
                        if (_Code > 0)
                        {
                            JMessages.Error("PersonExists", "error");
                            //jChangePersonCodeForm CPD = new jChangePersonCodeForm(_Code, Code);
                            //CPD.ShowDialog();
                            // return insert(pManual); // Karamad
                            return 0; // Karamad
                        }
                        if (find(this.ShMeli, this.Code) > 0)
                        {
                            JMessages.Error("NationalCodeRepeated", "error"); // unCommented by Karamad
                            return 0; // unCommented by Karamad
                        }
                        if (find(this._SharePCode, this.Code) > 0)
                        {
                            JMessages.Error("این شماره سهامداری قبلا وارد شده است.", "error");
                            return 0;
                        }
                    }
                    DB.beginTransaction("PersonInsert");
                    mCode = JPT.Insert(DefaultCode, DB, pManual);
					DB.Commit();
                    if (mCode > 0)
                    {
                        Code = mCode;
                        /// درج در جدول واسط
                        if (_InsertInAllPerson(DB))
                        {
                            if (_SharePCode > 0)
                                JShareWebLog.Insert(DB, "clsPerson", Code, 'i');
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
                            JPT.Code = mCode;
                            //Nodes.DataTable.Rows.Add(JPT.GetRow(Nodes.DataTable));
                            Code = mCode;
                            if (this.IncompleteInformation == false)
                            {
                                try
                                {
                                    ///////////////////////////Nodes.DataTable.Merge(JPersons.GetDataTable(Code));
                                }
                                catch
                                {
                                }
                                /// درج آدرسها
                                HomeAddress.AddressType = JAddressTypes.Home;
                                WorkAddress.AddressType = JAddressTypes.Work;
                                HomeAddress.Insert(mCode, this._SharePCode);
                                WorkAddress.Insert(mCode, this._SharePCode);
                            }
                            if (Histroy != null)
                                Histroy.Save(this, JPT, mCode, "Insert");


                            /*
                             * AVL Project
                            */
                            if (Code != 0)
                            {
                                try
                                {
                                    global::AVL.ObjectList.JObjectList ol = new global::AVL.ObjectList.JObjectList();
                                    ol.ClassName = "ClassLibrary.JPerson";
                                    ol.DynamicObjectCode = 0;
                                    ol.Label = this.Name + " " + this.Fam;
                                    ol.Type = "شخص";
                                    ol.ObjectCode = this.Code;
                                    ol.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                                    ol.RegisterDateTime = DateTime.Now;
                                    global::AVL.ObjectList.JObjectListTable olt = new global::AVL.ObjectList.JObjectListTable();
                                    olt.SetValueProperty(ol);
                                    ol.Code = olt.Insert();
                                }
                                catch
                                {
                                }
                            }
                            /*		 */
                            return mCode;
                        }

                    }
                    DB.Rollback("PersonInsert");
                    return 0;
                }
                else
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

        public int insertAVL(bool pManual,bool permissionCheck)
        {
            int mCode = 0;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                bool pcheck = true;
                if (permissionCheck)
                    pcheck = JPermission.CheckPermission("ClassLibrary.JPerson.Insert");
                if (pcheck)
                {
                    JPersonTable JPT = new JPersonTable();
                    JPT.SetValueProperty(this);
                    if (this.IncompleteInformation == false && !pManual)
                    {
                        int _Code = find(this);
                        if (_Code > 0)
                        {
                            JMessages.Error("PersonExists", "error");
                            //jChangePersonCodeForm CPD = new jChangePersonCodeForm(_Code, Code);
                            //CPD.ShowDialog();
                            // return insert(pManual); // Karamad
                            return 0; // Karamad
                        }
                        if (find(this.ShMeli, this.Code) > 0)
                        {
                            JMessages.Error("NationalCodeRepeated", "error"); // unCommented by Karamad
                            return 0; // unCommented by Karamad
                        }
                        if (find(this._SharePCode, this.Code) > 0)
                        {
                            JMessages.Error("این شماره سهامداری قبلا وارد شده است.", "error");
                            return 0;
                        }
                    }
                    DB.beginTransaction("PersonInsert");
                    mCode = JPT.Insert(DefaultCode, DB, pManual);
                    if (mCode > 0)
                    {
                        Code = mCode;
                        /// درج در جدول واسط
                        if (_InsertInAllPerson(DB))
                        {
                            if (_SharePCode > 0)
                                JShareWebLog.Insert(DB, "clsPerson", Code, 'i');
                            ManagementShares.ShareCompany.JSharepCode SC = new ManagementShares.ShareCompany.JSharepCode();
							SC.SharePCode = _SharePCode;
							SC.PersonCode = Code;
							SC.CompanyCode = _CompanyCode;
                            DB.Commit();
                            JPT.Code = mCode;
                            //Nodes.DataTable.Rows.Add(JPT.GetRow(Nodes.DataTable));
                            Code = mCode;
                            if (this.IncompleteInformation == false)
                            {
                                try
                                {
                                    Nodes.DataTable.Merge(JPersons.GetDataTable(Code));
                                }
                                catch
                                {
                                }
                                /// درج آدرسها
                                HomeAddress.AddressType = JAddressTypes.Home;
                                WorkAddress.AddressType = JAddressTypes.Work;
                                HomeAddress.Insert(mCode, this._SharePCode);
                                WorkAddress.Insert(mCode, this._SharePCode);
                            }
                            if (Histroy != null)
                                Histroy.Save(this, JPT, mCode, "Insert");


                            /*
                             * AVL Project
                            */
                            if (Code != 0)
                            {
                                try
                                {
                                    //global::AVL.ObjectList.JObjectList ol = new global::AVL.ObjectList.JObjectList();
                                    //ol.ClassName = "ClassLibrary.JPerson";
                                    //ol.DynamicObjectCode = 0;
                                    //ol.Label = this.Name + " " + this.Fam;
                                    //ol.Type = "شخص";
                                    //ol.ObjectCode = this.Code;
                                    //ol.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                                    //ol.RegisterDateTime = DateTime.Now;
                                    //global::AVL.ObjectList.JObjectListTable olt = new global::AVL.ObjectList.JObjectListTable();
                                    //olt.SetValueProperty(ol);
                                    //ol.Code = olt.Insert();
                                }
                                catch
                                {
                                }
                            }
                            /*		 */
                            return mCode;
                        }

                    }
                    DB.Rollback("PersonInsert");
                    return 0;
                }
                else
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

        public void ShowDialog()
        {
            ShowDialog(false);
        }
        public void ShowDialog(bool pView)
        {
            if (this.Code == 0)
            {
                if (!(JPermission.CheckPermission("ClassLibrary.JPerson.Insert")))
                    return;
                JPersonIn PE = new JPersonIn();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
                if (PE.DialogResult == System.Windows.Forms.DialogResult.Retry)
                    ShowDialog();
            }
            else
            {
                if (pView)
                    if (!ClassLibrary.JPermission.CheckPermission("ClassLibrary.JPersons.GetDataTable"))
                        return;
                if (!pView)
                    if (!ClassLibrary.JPermission.CheckPermission("ClassLibrary.JPerson.Update"))
                        return;
                JPersonIn PE = new JPersonIn(this);
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

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[JPersonTableEnum.Code.ToString()], "ClassLibrary.JPerson");
            bool Died = false;
            if ((pRow[JPersonTableEnum.Died.ToString()]).ToString() != "")
                if (!(bool)(pRow[JPersonTableEnum.Died.ToString()]))
                {
                    Died = false;
                    if (string.Compare(pRow[JPersonTableEnum.Gender.ToString()].ToString(), "مرد") == 0)
                        node.Icone = JImageIndex.man.GetHashCode();
                    else
                        node.Icone = JImageIndex.woman.GetHashCode();
                }
                else
                {

                    Died = true;
                    if (string.Compare(pRow[JPersonTableEnum.Gender.ToString()].ToString(), "مرد") == 0)
                        node.Icone = JImageIndex.ManDied.GetHashCode();
                    else
                        node.Icone = JImageIndex.WomanDied.GetHashCode();
                }
            node.Name = pRow[JPersonTableEnum.Fam.ToString()] + " - " + pRow[JPersonTableEnum.Name.ToString()];
            node.Hint = JLanguages._Text("LastName:") + " " + pRow[JPersonTableEnum.Fam.ToString()] + "\n" +
                       JLanguages._Text("Name:") + " " + pRow[JPersonTableEnum.Name.ToString()] + "\n" +
                       JLanguages._Text("FatherName:") + " " + pRow[JPersonTableEnum.FatherName.ToString()] + "\n" +
                       JLanguages._Text("ShSh:") + " " + pRow[JPersonTableEnum.ShSh.ToString()] + "\n" +
                       JLanguages._Text("ShMeli:") + " " + pRow[JPersonTableEnum.ShMeli.ToString()];
            if (Died)
                node.Hint += "\n(" + JLanguages._Text("Died") + ")";
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { node.Code });
            /// اکشن مشاهده
            JAction viewAction = new JAction("View...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { node.Code });
            node.MouseDBClickAction = viewAction;
            node.EnterClickAction = viewAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete", "ClassLibrary.JPerson.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "ClassLibrary.JPerson.ShowDialog", null, null);
            ///گواهی فوت
            JAction deadAction = new JAction("RegisterDead...", "Legal.JDeadPerson.ShowDialog", null, new object[] { node.Code });
            /// حذف گواهی فوت
            JAction DelDeadAction = new JAction("DeleteDead...", "Legal.JDeadPerson.DelDie", null, new object[] { node.Code });
            JAction Amalkard = new JAction("Amalkard...", "ClassLibrary.JPerson.ShowAmalkard", new object[] { node.Code }, null);
            JAction ChangeNameAction = new JAction("ChangeName...", "ClassLibrary.JPerson.ChangePersonName", null, new object[] { node.Code });
            Nodes.WordWrapColumn("HomeAddress", 4);
            Nodes.WordWrapColumn("WorkAddress", 4);
            /// اکشن سهامداری
            JAction SahamdarAction = new JAction("Sahamdar...", "ClassLibrary.JAllPerson.UpdateSahamdar", new object[] { node.Code }, null);

            JAction EditSharePCode = new JAction("Edit SharePCode", "ManagementShares.ShareCompany.SharePCodeChange.ShowDialog", null, new object[] { 0, node.Code });

            //// در صورتیکه شخص متوفی باشد آیتمهای منو متفاوت است
            if (!Died)
            {
                node.Popup.Insert(SahamdarAction);
                node.Popup.Insert(ChangeNameAction);
                node.Popup.Insert(deleteAction);
				node.Popup.Insert(deadAction);
				node.Popup.Insert(EditSharePCode);
				node.Popup.Insert(editAction);
                node.Popup.Insert(viewAction);
                node.Popup.Insert(newAction);
                node.Popup.Insert(Amalkard);
            }
            else
            {
                /// حذف گواهی فوت
                node.Popup.Insert(DelDeadAction);
                node.Popup.Insert(deadAction);
                node.Popup.Insert(deleteAction);
                node.Popup.Insert(editAction);
                node.Popup.Insert(viewAction);
                node.Popup.Insert(newAction);
            }

            return node;
        }

        #endregion

        #region AVL
        public const string _ConstClassName = "ClassLibrary.JPerson";
        public static string GridShow()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_GridShow";
            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
            //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "New", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null) });
            //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "Edit", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null) });

            jGridView.SQL =
                  @"SELECT [Code],[ObjectCode],[Label],[Type] FROM AVLObjectList WHERE ClassName='ClassLibrary.JPerson' AND personCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;

            jGridView.Title = "اشخاص";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //   jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            //   jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }


        public static string GetIcon(string id)
        {
            return "/WebAVL/Icons/person.png";
        }

        //public DataTable GetHtmlString(string id)
        //{
            
            // here we can put some details as car is in own line (AVL.Controls.Map.Line.IsInTheLine).
            // Or geofence details with (AVL.Controls.Map.Line.IsInTheArea).
            //ClassLibrary.JPerson p = new JPerson(int.Parse(id));

            //AVL.ObjectList.JObjectList ol = AVL.ObjectList.JObjectList.FindByObjectCode(p.Code.ToString(), "0");
            //if (ol.Code < 0)
              //  return string.Format(@"<div id='{3}' style='padding:5px;color:black;font-size:12px;background-color:white;box-shadow:0px 0px 1px gray;border-radius:15px;text-align:center;height:150px;'><img src='{4}' style='float:right;' height='32px' width='32px' onClick=""var a=getElementById('{3}');a.parentNode.removeChild(a)""/><strong>{0}</strong><br/><div style='float:left;'><img width='100px' height='110px' src='/getIcon.aspx?ic={1}&t={2}'/></div></div>", p.Name + " " + p.Fam, p.PersonImageCode, "hs", "infoWindow" + id, "/WebAvl/Icons/Close.png");
            //AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(ol.Code, true);
            //if (d.Code < 0)
            //return string.Format(@"<div id='{4}' style='padding:5px;color:black;font-size:12px;background-color:white;box-shadow:0px 0px 1px gray;border-radius:15px;text-align:center;height:150px;'><img src='{5}' style='float:right;' height='32px' width='32px' onClick=""var a=getElementById('{4}');a.parentNode.removeChild(a)""/><strong>{0}</strong><br/><div style='float:left;'><img width='100px' height='110px' src='/getIcon.aspx?ic={1}&t={2}'/></div><div style='float:right;text-align:right;'><ul><li>زمان آخرین ارسال: {3} </li></ul></div></div>", p.Name + " " + p.Fam, p.PersonImageCode, "hs", AVL.Tools.ConvertGregorianToPersianDateTime(d.lastSendDate), "infoWindow" + id, "/WebAvl/Icons/Close.png");
            //return string.Format(@"<div id='{5}' style='padding:5px;color:black;font-size:12px;background-color:white;box-shadow:0px 0px 1px gray;border-radius:15px;text-align:center;height:150px;'><img src='{6}' style='float:right;' height='32px' width='32px' onClick=""var a=getElementById('{5}');a.parentNode.removeChild(a)""/><strong>{0}</strong><br/><div style='float:left;'><img width='100px' height='110px' src='/getIcon.aspx?ic={1}&t={2}'/></div><div style='float:right;text-align:right;'><ul><li>زمان آخرین ارسال: {3} </li><li>نام دستگاه : {4}</li></ul></div></div>", p.Name + " " + p.Fam, p.PersonImageCode, "hs", AVL.Tools.ConvertGregorianToPersianDateTime(d.lastSendDate), d.Name, "infoWindow" + id, "/WebAvl/Icons/Close.png");
        //}
        #endregion
        /// كليه تخلفات و اخطاريه هاي يك شخص را نمايش مي دهد
        public void ShowAmalkard(int PCode)
        {
            PersonAmalkardForm frm = new PersonAmalkardForm(PCode);
            frm.ShowDialog();
        }

        public void ChangePersonName()
        {
            JPerson _Person = new JPerson(this.Code);
            _Person.OldChangeName = this.Code;
            JPersonIn PersonIn = new JPersonIn(_Person);
            PersonIn.State = JFormState.Insert;
            PersonIn.ShowDialog();
            if (_Person.Code != this.Code)
            {
                if (_Person.getData(_Person.Code))
                {
                    this.NewChangeName = _Person.Code;
                    this.Update();
                }
            }
        }

        public bool checkCodeMeli(string code)
        {
            //int L=code.Length;

            //if(L<8 || parseInt(code,10)==0) return false;
            //code=('0000'+code).substr(L+4-10);
            //if(parseInt(code.substr(3,6),10)==0) return false;
            //var c=parseInt(code.substr(9,1),10);
            //var s=0;
            //for(var i=0;i<9;i++)
            //  s+=parseInt(code.substr(i,1),10)*(10-i);
            //s=s%11;
            //return (s<2 && c==s) || (s>=2 && c==(11-s));
            return true;
        }

        public bool checkCodeMeliNew(string nationalCode)
        {
            if (String.IsNullOrEmpty(nationalCode))
                //throw new Exception("لطفا کد ملی را صحیح وارد نمایید");
                return false;


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                //throw new Exception("طول کد ملی باید ده کاراکتر باشد");
                return false;

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new System.Text.RegularExpressions.Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                //throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");
                return false;

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        /// <summary>
        /// تصویر شخص از جایی غیر از فرم ست میشود
        /// استفاده شده در وب سرویس موبایل سهام
        /// </summary>
        /// <param name="_PersonImage"></param>
        /// <returns></returns>
        public bool SetImage(Image _PersonImage)
        {
            try
            {
                JFile imageFile = new JFile(JFileTypes.Image);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Bitmap bmp = new Bitmap(_PersonImage);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageFile.Content = ms.ToArray();
                imageFile.Extension = ".jpg";
                imageFile.FileSource = JFile.JFileSource.FromMemory;
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                int ArchiveCode = 0;
                if (bmp != null)
                {
                    ArchiveCode = archive.ArchiveDocument(imageFile, this.GetType().FullName, this.Code, JLanguages._Text("PersonPicture"), true);
                    this.PersonImageCode = ArchiveCode;
                }
                if (ArchiveCode > 0 && this.Update())
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }





    }

    public class JPersons : JSystem
    {
        public JPerson[] Items = new JPerson[0];
        //  public String OrderName;
        public JPersons()
        {
            // OrderName = "Fam";
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
            if (!ClassLibrary.JPermission.CheckPermission("ClassLibrary.JPersons.GetDataTable", false))
                return null;

            Globals.Property.JPropertyTables PT = new Globals.Property.JPropertyTables("ClassLibrary.JRealPerson", 1);
			String PropSQL = PT.getSQL();
			string Query = JPerson._SelectQuery;

			if (PropSQL.Length > 0)
			{
				Query = JPerson._SelectQuery.
					Replace("--JOIN", " left join (" + PropSQL + ") as prop on prop.ObjectCode = clsPerson.Code ").
					Replace("--,Fields", "," + String.Join(",", PT.getFieldsNameTable("prop")));
			}

            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "";
                if (pCode != 0)
                    WHERE = " AND " + JTableNamesClassLibrary.PersonTable + ".Code = " + pCode;
				DB.setQuery(Query + WHERE + " And " +
                    JPermission.getObjectSql("ClassLibrary.JPersons.GetDataTable", JTableNamesClassLibrary.PersonTable + ".Code"));

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
            return @"SELECT top 100 percent cp.Code, cp.Fam, cp.Name, cp.FatherName, cp.ShSh, CASE cp.Gender WHEN 0 THEN N'زن' WHEN 1 THEN N'مرد' END AS Gender
                          FROM clsPerson cp
                        ORDER BY cp.Fam, cp.Name";
        }

        /// <summary>
        /// آخرین شماره پرونده سهام را برمیگرداند
        /// </summary>
        /// <returns></returns>
		public static Int64 GetMaxSharePCode(int _CompanyCode)
        {
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT isnull(max(SharePCode),0)+1 mCode from SharePCodeSheet WHERE CompanyCode=" + _CompanyCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				return Convert.ToInt64(dt.Rows[0]["mCode"].ToString());
			}
			finally
			{
				DB.Dispose();
			}
		}

        public DataRow GetCurrentRow(int pCode)
        {
            DataTable DT = GetDataTable(pCode);
            return DT == null || DT.Rows.Count == 0 ? null : DT.Rows[0];
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetPerson", "ClassLibrary.JPerson.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "ClassLibrary.JPerson.ShowDialog", null, null);

            JAction ImportImage = new JAction("Import...", "ClassLibrary.Person.RealPerson.PeronImportForm.ShowDialog", null, null);
            
            Nodes.GlobalMenuActions.Insert(newAction);


            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            if (JMainFrame.CurrentUser.IsAdmin)
            {
                JToolbarNode TN1 = new JToolbarNode();
                TN1.Icon = JImageIndex.Contract;
                TN1.Hint = "Import...";
                TN1.Click = ImportImage;
                Nodes.AddToolbar(TN1);
            }
            

            //ListView(OrderName, "");
        }

        //public void GetLists()
        //{
        //    GetLists("");
        //}
        //public void GetLists(string Where)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        DB.setQuery(@"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + " * FROM " + JTableNamesClassLibrary.PersonTable
        //        + Where +
        //        " ORDER BY " + OrderName);
        //        DB.Query_DataReader();
        //        Array.Resize(ref Items, DB.RecordCount);
        //        int Count = 0;
        //        while (DB.DataReader.Read())
        //        {
        //            Items[Count] = new JPerson();
        //            JTable.SetToClassProperty(Items[Count], DB.DataReader);
        //            Count++;
        //        }
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}

        //public void ListView(IDictionary<string, object> Fields)
        //{
        //    string Where = "";
        //    string And = "";
        //    if (Fields != null)
        //        foreach (KeyValuePair<string, object> Field in Fields)
        //        {
        //            Where += And + Field.Key + " Like " + JDataBase.Quote("%" + Field.Value + "%");
        //            And = " AND ";
        //        }
        //    if (Where.Length > 0)
        //        Where = "WHERE " + Where;
        //    ListView(OrderName, Where);
        //}

        //public void ListView(string pOrderName, string Where)
        //{
        //    OrderName = pOrderName;
        //    GetLists(Where);
        //    foreach (JPerson Per in Items)
        //    {
        //        Nodes.Insert(Per.GetNode());
        //    }

        //    Nodes.GlobalMenuActions = new JPopupMenu("ClassLibrary.JPerson", 0);
        //    Nodes.GlobalMenuActions.Insert(JStaticAction._PersonsNew());
        //    Nodes.GlobalMenuActions.Insert(JStaticAction._PersonsSearch());

        //    Nodes.AddColumn("Name");
        //    Nodes.AddColumn("Fam");
        //    Nodes.AddColumn("sh");

        //    //Nodes.SQLNode.SQL = @"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + " * FROM " + JTableNamesClassLibrary.PersonTable;


        //    JToolbarNode TN = new JToolbarNode();

        //    TN.Click = new JAction("test","ClassLibrary.JPerson.Delete",null,null);
        //    TN.Icon = JImageIndex.user_48;
        //    Nodes.AddToolbar(TN);
        //}
    }
}