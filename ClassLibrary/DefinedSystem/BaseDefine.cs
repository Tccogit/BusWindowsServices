using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace ClassLibrary
{
    /// <summary>
    /// کلاس تعریف پایه
    /// </summary>
    public class JBaseDefine : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int ParentCode { get; set; }

        public static readonly int BulletinType = 1050;

        #region ClassLibrary BaseDefineCodes
        public static readonly int CityCode = 1;
        public static readonly int DegreeCode = 2;
        public static readonly int ProvinceCode = 3;
        public static readonly int ClassCode = 4;
        public static readonly int MajorCode = 5;
        public static readonly int SahamMaliCash = 6;
        public static readonly int States = 7;
        /// <summary>
        /// انواع شرکتها
        /// </summary>
        public static readonly int CompanyTypes = 8;
        /// <summary>
        /// انواع گروهای SMS
        /// </summary>
        public static readonly int SMSGroup = 9;
        /// <summary>
        /// انواع گروهای Lottery
        /// </summary>
        public static readonly int LotteryGroup = 10;

        #endregion ClassLibrary BaseDefineCodes

        #region Automation BaseDefineCodes
        /// <summary>
        /// انواع ضمیمه نامه
        /// </summary>
        public static readonly int AttachmentTypeCode = 100;
        /// <summary>
        /// نحوه ارسال نامه
        /// </summary>
        public static readonly int SendTypeCode = 105;
        /// <summary>
        /// نحوه  دریافت نامه
        /// </summary>
        public static readonly int RecieveTypeCode = 103;
        /// <summary>
        /// انواع اقدامات
        /// </summary>
        public static readonly int EmpriseTypeCode = 101;
        /// <summary>
        /// انواع ارجاع
        /// </summary>
        public static readonly int ReferTypeCode = 104;
        /// <summary>
        /// انواع نتایج پیگیری
        /// </summary>
        public static readonly int PursueTypeCode = 105;
        /// <summary>
        /// انواع فوریت نامه
        /// </summary>
        public static readonly int UrgencyTypeCode = 106;
        /// <summary>
        /// انواع محرمانگی
        /// </summary>
        public static readonly int PrivacyTypeCode = 107;
        /// <summary>
        /// انواع فایل
        /// </summary>
        public static readonly int FileType = 108;
        /// <summary>
        /// انواع دلیل رونوشت
        /// </summary>
        public static readonly int CopyType = 109;

        #endregion Automation BaseDefineCodes

        #region Employment BaseDefineCodes
        /// <summary>
        /// عناوین شغلی
        /// </summary>
        public static readonly int MetierCode = 201;
        /// <summary>
        /// واحد سازمانی
        /// </summary>
        public static readonly int OrganizationUnitCode = 202;

        #endregion Employment BaseDefineCodes

        #region Estate BaseDefineCodes
        /// <summary>
        /// انواع اعیان
        /// </summary>
        public static readonly int UnitTypes = 301;
        /// <summary>
        /// کاربری
        /// </summary>
        public static readonly int MarketUsage = 302;
        /// <summary>
        /// انواع مستغلات
        /// </summary>
        public static readonly int UnitBuildType = 303;
        /// <summary>
        /// انواع شغل در اعیان
        /// </summary>
        public static readonly int UnitJobs = 304;

        #endregion Estate BaseDefineCodes

        #region ShareProfit BaseDefineCodes
        /// <summary>
        /// محل پرداخت سود
        /// </summary>
        public static readonly int PaymentSource = 401;
        /// <summary>
        /// نوع پرداخت سود
        /// </summary>
        public static readonly int PaymentType = 402;
        #endregion ShareProfit BaseDefineCodes

        #region Legal BaseDefineCodes
        /// <summary>
        /// انواع دادخواست / شکوائیه
        /// </summary>
        public static readonly int PetitionSubjectTypes = 501;
        /// <summary>
        /// نسبت خانوادگی
        /// </summary>
        public static readonly int FamilyRelation = 502;
        /// <summary>
        /// انواع سند
        /// </summary>
        public static readonly int ConcernType = 503;
        /// <summary>
        /// انواع بانک
        /// </summary>
        public static readonly int BankTypes = 504;
        /// <summary>
        /// انواع شعب بانکها
        /// </summary>
        public static readonly int BranchTypes = 505;
        /// <summary>
        /// موضوع دادخواست
        /// </summary>
        public static readonly int IssueBriefs = 508;

        #endregion

        #region Meeting

        /// <summary>
        /// انواع گروه مصوبه
        /// </summary>
        public static readonly int LegislationGroupType = 506;
        /// <summary>
        /// انواع کمیسیون
        /// </summary>
        public static readonly int CommissionType = 507;
        #endregion

        #region Accounting

        /// <summary>
        /// گردش
        /// </summary>
        public static readonly int FlowAccounting = 801;
        /// <summary>
        /// نوع مصرف بودجه
        /// </summary>
        public static readonly int Consumption = 802;
        /// <summary>
        /// نوع سند
        /// </summary>
        public static readonly int DocumentType = 803;
        /// <summary>
        /// محل سند
        /// </summary>
        public static readonly int DocumentLocation = 804;
        #endregion

        #region StoreManagment

        /// <summary>
        /// گروه کالا
        /// </summary>
        public static readonly int GoodsGroup = 1018;
        /// <summary>
        /// نوع کالا
        /// </summary>
        public static readonly int GoodsType = 1019;
        /// <summary>
        /// واحد اندازه گیری
        /// </summary>
        public static readonly int MeasureType = 1020;
        /// <summary>
        ///  انواع انبار
        /// </summary>
        public static readonly int StorageType = 1021;
        #endregion

        #region SmartCards
        /// <summary>
        ///  انواع کارت هوشمند
        /// </summary>
        public static readonly int CardServiceType = 903;
        #endregion

        #region Bascol
        /// <summary>
        /// انواع محصول
        /// </summary>
        public static readonly int BascolProduct = 901;
        #endregion

        #region StoreComlex
        /// <summary>
        /// انواع خدمات
        /// </summary>
        public static readonly int SCServices = 1101;
        /// <summary>
        /// 
        /// </summary>
        public static readonly int SCUnits = 1102;
        /// <summary>
        /// انواع وسائل نقلیه
        /// </summary>
        public static readonly int SCVanTypes = 1103;
        #endregion StoreComlex

        #region Automobile
        /// <summary>
        ///  انواع اتومبیل
        /// </summary>
        public static readonly int AutomobileType = 9001001;
        public static readonly int MakerCompany = 9001002;
        public static readonly int CertificateType = 9001003;
        #endregion

        #region BusManagement
        /// <summary>
        ///  انواع ایستگاهها
        /// </summary>
        public static readonly int TypeStation = 9001010;
        /// <summary>
        ///  انواع باجه های بلیط فروشی
        /// </summary>
        public static readonly int TypeSallerTicket = 9101011;
        /// <summary>
        ///  انواع خطها 
        /// </summary>
        public static readonly int TypeLine = 9101021;
        /// <summary>
        ///  انواع ناوگان 
        /// </summary>
        public static readonly int TypeFleet = 9101031;
        /// <summary>
        ///  انواع کارت 
        /// </summary>
        public static readonly int TypeCard = 9101023;
        /// <summary>
        /// انواع تخصص
        /// </summary>
        public static readonly int SpecificationType = 9101024;
        /// <summary>
        /// انواع استخدام
        /// </summary>
        public static readonly int EmploymentType = 9101025;
        /// <summary>
        /// انواع مرخصی
        /// </summary>
        public static readonly int VacationType = 9101026;
        /// <summary>
        /// انواع دلایل عدم فعالیت اتوبوس
        /// </summary>
        public static readonly int BusFailureType = 9101032;
        /// <summary>
        ///گروه های نت
        /// </summary>
        public static readonly int GroupNetType = 9101034;
        

        #endregion

        #region
        #endregion

        public static string GetName(int pCode)
        {
            string SQL = "SELECT [name] FROM define WHERE [Code]=" + pCode.ToString();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(SQL);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return DB.DataReader["name"].ToString();
                }
                return "";
            }
            finally
            {
                DB.Dispose();
            }
        }

        private static Dictionary<int,DataRow>_oldDataTable = new Dictionary<int, DataRow>();
        public Boolean GetData(int pCode)
        {
            DataRow DR;
            if (!_oldDataTable.TryGetValue(pCode, out DR))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    string SQL = "SELECT * FROM define";
                    DB.setQuery(SQL);
                    DataTable DT = DB.Query_DataTable();
                    foreach (DataRow _DR in DT.Rows)
                    {
                        try
                        {
                            DataRow __DR = _oldDataTable[(int)_DR["code"]];
                        }
                        catch
                        {
                            _oldDataTable.Add((int)_DR["code"], _DR);
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    DB.Dispose();
                }
            }
            
            {
                if (_oldDataTable.TryGetValue(pCode, out DR))
                {
                    JTable.SetToClassProperty(this, DR);
                    return true;
                }
            }
            return false;
        }



        public void ListView()
        {
            int Count = 0;
            Nodes.AddColumn("Name");

            Nodes.Insert(GetNode(CityCode));
            Nodes.Insert(GetNode(CompanyTypes));
            Nodes.Insert(GetNode(SMSGroup));
            //    Nodes.Insert(GetNode(MajorCode));
            // Nodes.Insert(GetNode(FamilyRelation));
        }

        public JNode[] TreeView()
        {
            JNode[] J = new JNode[] { GetNode(CityCode), GetNode(CompanyTypes), GetNode(SMSGroup) };
            //, GetNode(DegreeCode) , GetNode(MajorCode)
            //GetNode(FamilyRelation)
            return J;
        }

        public JNode GetNode(int pCode)
        {
            if (GetData(pCode))
            {
                JNode Node = new JNode(Code, "ClassLibrary.JSubBaseDefines");
                Node.Name = Name;
                JAction DBClick = new JAction(Name, "ClassLibrary.JSubBaseDefines.ListView", null, new object[] { Code }, true);
                Node.MouseDBClickAction = DBClick;
                Node.MouseClickAction = DBClick;

                try
                {
                    Node.Icone = (int)Enum.Parse(Type.GetType("ClassLibrary.JImageIndex"), Name);
                }
                catch
                {
                    Node.Icone = JImageIndex.Default.GetHashCode();
                }
                //Node.ChildsAction = DBClick;
                return Node;
            }
            return null;
        }
    }

    /// <summary>
    /// تعاریف پایه در سیستم مانند شهرها
    /// </summary>
    public class JSubBaseDefine : JSystem
    {
        /// <summary>
        /// کد تعریف
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد شاخه
        /// </summary>
        public int BCode { get; set; }
        /// <summary>
        /// نام تعریف
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد پدر در تعاریف پایه
        /// </summary>
        public int ParentCode { get; set; }
        private JBaseDefine _BaseDefine;
        /// <summary>
        /// ارسال نام تعریف
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return Name;
        }
        /// <summary>
        /// کد شاخه را به عنوان پیشفرض دریافت می کند
        /// </summary>
        /// <param name="pBCode"></param>
        public JSubBaseDefine(int pBCode)
        {
            BCode = pBCode;
            _BaseDefine = new JBaseDefine();
            _BaseDefine.GetData(BCode);
        }
        public JSubBaseDefine(int pBCode, int pCode)
        {
            BCode = pBCode;
            GetData(pCode);
            _BaseDefine = new JBaseDefine();
            _BaseDefine.GetData(BCode);
        }
        /// <summary>
        /// ویرایش
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            if (Find(Code))
            {
                string WhereSQL = "[name]=" + JDataBase.Quote(Name) +
                    " AND [bcode] = " + BCode +
                    " AND [Code]<>" + Code;
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    if (JPermission.CheckPermission("ClassLibrary.JSubBaseDefine.Update", BCode, 0, false))
                    {

                        if ((Code != -1) && (Code != 0))
                        {
                            DB.setQuery("SELECT [Code] FROM [subdefine] WHERE " + WhereSQL);
                            DB.Query_DataReader();
                            if (!DB.DataReader.HasRows)
                            {
                                JSubBaseDefineTable JSBDT = new JSubBaseDefineTable();
                                JSBDT.SetValueProperty(this);
                                if (JSBDT.Update())
                                {
                                    Histroy.Save(this, JSBDT, Code, "Update");
                                    // JTable.SetToDataRow(this, Nodes.CurrentNode.Row);
                                    if (JMainFrame.IsWeb() == false)
                                        Nodes.Refreshdata(Nodes.CurrentNode, JSubBaseDefines.GetDataTable(this.BCode, this.Code).Rows[0]);
                                    return true;
                                }
                            }
                            else
                            {
                                Except.NewException("NAME_IS_EXIST");
                                return false;
                            }
                        }
                    }
                    else
                        return false;
                }
                finally
                {
                    DB.Dispose();
                }
            }
            return false;
        }
        /// <summary>
        /// درج
        /// </summary>
        /// <returns>کد جدید را بر میگرداند و -1 یعنی درج نشده است</returns>
        public int Insert()
        {
            return Insert(0);
        }
        /// <summary>
        /// درج با کد خاص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public int Insert(int pCode)
        {
            return Insert(pCode, null);
        }

        public int Insert(int pCode, JDataBase pDB)
        {
            if (pDB == null)
            {
                pDB = new JDataBase();
            }
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JSubBaseDefine.Insert", BCode, 0, false))
                {
                    if (Find(BCode, Name) > 0)
                    {
                        if (!ClassLibrary.JMainFrame.IsWeb()) JMessages.Error("ThisItemAlreadyExists", "Error");
                        return 0;
                    }
                    int MaxCode;
                    if (pCode == 0)
                        MaxCode = FindMax(BCode) + 1;
                    else
                        MaxCode = pCode;
                    Code = MaxCode;

                    JSubBaseDefineTable JSBDT = new JSubBaseDefineTable();
                    JSBDT.SetValueProperty(this);
                    int reCode = JSBDT.InsertManual(pDB);
                    if (reCode > 0)
                    {
                        Histroy.Save(this, JSBDT, reCode, "Insert");
                        Code = reCode;
                        if (ClassLibrary.JMainFrame.IsWeb() == false)
                            Nodes.DataTable.Rows.Add(JSBDT.GetRow(Nodes.DataTable));
                    }
                    return reCode;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
        }
        /// <summary>
        /// حذف
        /// </summary>
        /// <returns></returns>
        public Boolean Delete(int pCode)
        {
            if (JPermission.CheckPermission("ClassLibrary.JSubBaseDefine.Delete", BCode, 0, false))
            {
                if (ClassLibrary.JMainFrame.IsWeb() == true
                     || JMessages.Question("آیا میخواهید این تعریف حذف شود؟", "حذف تعاریف پایه") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Find(pCode))
                    {
                        GetData(pCode);
                        JSubBaseDefineTable JSBDT = new JSubBaseDefineTable();
                        JSBDT.SetValueProperty(this);
                        if (JSBDT.Delete())
                        {
                            Histroy.Save(this, JSBDT, Code, "Delete");
                            if (ClassLibrary.JMainFrame.IsWeb() == false) Nodes.Delete(GetNode());
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// جستجو بر اساس کد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [Code] FROM [subdefine] WHERE [Code]=" + pCode.ToString());
                DB.Query_DataReader();
                bool find = DB.DataReader.HasRows;
                //DB.DisConnect();
                return find;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// جستجو بر اساس کد و نام
        /// </summary>
        /// <param name="pBCode"></param>
        /// <param name="PName"></param>
        /// <returns></returns>
        public static int Find(int pBCode, string PName)
        {
            string WhereSQL = "[bcode]=" + pBCode.ToString() + " AND [name]=" + JDataBase.Quote(PName);

            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {

                DB.setQuery("SELECT [Code] FROM [subdefine] WHERE " + WhereSQL);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                    return int.Parse(DB.DataReader["Code"].ToString());
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// بزرگترین کد مربوط به کد پایه را پیدا میکند
        /// </summary>
        /// <param name="pBCode"></param>
        /// <returns></returns>
        public static int FindMax(int pBCode)
        {
            string Query = "SELECT ISNULL((Select Max(Code) FROM [subdefine]), 0)";
            ///// در صورتی که در همان رکوردی برای بیس ثبت نشده 10000 به کد قبل اضافه میگردد
            //string Query = " Select ISNULL(ISNull((SELECT Max(Code) FROM [subdefine] WHERE [bcode] = " + pBCode.ToString() +
            //    "), (Select (MAX(Code)+10000) - (MAX(Code)+10000) % 10 from subdefine)),10000) ";
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(Query);
                object result = DB.Query_ExecutSacler();
                if (result != null)
                    return Convert.ToInt32(result);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// دریافت اطلاعات از دیتابیس و ذخیره در خواص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (Find(pCode))
                {
                    DB.setQuery("SELECT * FROM [subdefine] WHERE [Code]=" + pCode.ToString());
                    DB.Query_DataReader();
                    if (DB.DataReader.Read())
                    {
                        return JTable.SetToClassProperty(this, DB.DataReader);
                    }
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowDialog()
        {
            JBaseDefineForm JBDF = new JBaseDefineForm(this);
            JBDF.State = JFormState.Insert;
            JBDF.ShowDialog();
        }


        public void EditForm(int Code)
        {
            GetData(Code);
            JBaseDefineForm JBDF = new JBaseDefineForm(this);
            JBDF.State = JFormState.Update;
            JBDF.ShowDialog();
            JBDF.Dispose();
        }
        public JNode GetNode()
        {
            return JStaticNode._SubBaseDefineNode(Code, BCode, Name, _BaseDefine.Name);
        }

        public JNode GetNode(DataRow DR)
        {
            JBaseDefine Bd = new JBaseDefine();
            Bd.GetData(BCode);
            return JStaticNode._SubBaseDefineNode((int)DR["Code"], BCode, (string)DR["Name"], _BaseDefine.Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetList()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [Code],[name] From [subdefine] WHERE [bcode]=" + BCode.ToString() + " ORDER BY [name]");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }

        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class JSubBaseDefines : JSystem
    {

        //private JSubBaseDefine[] _Items;
        //public JSubBaseDefine[] Items
        //{
        //    get
        //    {
        //        if (_Items == null)
        //        {
        //            _Items = new JSubBaseDefine[0];
        //        }
        //        GetData(_code, null);
        //        return _Items;
        //    }
        //}

        public JSubBaseDefine SelectedItem;
        private int _code;
        /// <summary>
        /// سازنده کلاس تعاریف پایه
        /// </summary>
        /// <param name="pCode"></param>
        public JSubBaseDefines(int pCode)
        {
            _code = pCode;
            //GetData(_code, null);
        }

        //private void GetData(int pBCode, IDictionary<string, object> Fields)
        //{
        //    _code = pBCode;

        //    string Where = "";
        //    if (Fields != null && Fields.Count > 0)
        //        Where = " AND Name like " + JDataBase.Quote("%" + Fields["Name"] + "%");
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    DB.setQuery("SELECT [Code],[name] From [subdefine] WHERE [bcode]=" + pBCode.ToString() + Where + " ORDER BY [name]");
        //    try
        //    {
        //        DataTable DT = DB.Query_DataTable();
        //        Array.Resize(ref _Items, DT.Rows.Count);
        //        int count = 0;
        //        foreach (DataRow DR in DT.Rows)
        //        {
        //            _Items[count] = new JSubBaseDefine(pBCode);
        //            JTable.SetToClassProperty(_Items[count], DR);
        //            count++;
        //        }
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}

        public static DataTable GetDataTable(int pBCode, int pCode)
        {
            return GetDataTable(pCode, null, null, "", false,pCode, false,true);
            //string Query = " SELECT Code,name,bcode From [subdefine] WHERE [bcode] = " + pBCode;
            //if (pCode > 0)
            //    Query = Query + " AND Code=" + pCode.ToString();
            //JDataBase pDB = new JDataBase();
            //pDB.setQuery(Query);
            //try
            //{
            //    DataTable tmp = pDB.Query_DataTable();
            //    return tmp;
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //    return null;
            //}
            //finally
            //{
            //    pDB.Dispose();
            //}
        }
        public static DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, null, null,"",false,0, false,true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="Fields"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode, IDictionary<string, object> Fields)
        {
            return GetDataTable(pCode, Fields, null,"",false,0, false,true);
        }

        private static Dictionary<String, DataTable> DataTables = new Dictionary<string, DataTable>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="Fields"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pBCode, IDictionary<string, object> Fields, JDataBase pDB, string pWhere, bool List,int pCode,bool CheckPermission, bool pUserDatatablesStatic)
        {
            bool DBSend = pDB == null;
            if (pWhere == null)
                pWhere = "";
            string Where = " AND " + (pWhere.Length == 0 ? "1=1" : pWhere);
            if (Fields != null && Fields.Count > 0)
                Where = Where + " AND Name like " + JDataBase.Quote("%" + Fields["Name"] + "%");
            if (pCode > 0)
                Where = Where + " AND Code=" + pCode.ToString();
            if (CheckPermission)
                Where = Where + " And " + JPermission.getObjectSql("ClassLibrary.JSubBaseDefine.GetDataTable." + JBaseDefine.GetName(pBCode), "Code");

            if (pDB == null)
                pDB = JGlobal.MainFrame.GetDBO();
            pDB.setQuery("SELECT Code,name" + (List == true? ", bcode" : "") + " From [subdefine] WHERE Code=-1 or [bcode]=" + pBCode.ToString() + Where + " ORDER BY [name]");
            try
            {
                DataTable tmp = null;
                string key = "-1_"+(pBCode.ToString() + Where).Replace(' ', '_');
                if (pUserDatatablesStatic && !DataTables.TryGetValue(key , out tmp))
                {
                    tmp = pDB.Query_DataTable();
                    
                    DataTables.Add(key , tmp);
                }
                else
                {
                    tmp = pDB.Query_DataTable();

                }
                return tmp;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                if (DBSend)
                    pDB.Dispose();
            }
        }

        public void ListView()
        {
            ListView(null);
        }


        public void ListView(IDictionary<string, object> Fields)
        {
            int Count = 0;
            JAction NewItem = new JAction("New...", "ClassLibrary.JSubBaseDefine.ShowDialog", null, new object[] { _code });
            JAction EditItem = new JAction("Edit...", "ClassLibrary.JSubBaseDefine.EditForm", null, new object[] { _code });
            JAction SearchItem = new JAction("Search...", "ClassLibrary.JSubBaseDefines.Search", null, new object[] { _code });
            Nodes.GlobalMenuActions = new JPopupMenu("ClassLibrary.JSubBaseDefine", 0);
            Nodes.GlobalMenuActions.Insert(NewItem);
            Nodes.GlobalMenuActions.Insert(SearchItem);
            Nodes.GlobalMenuActions.Insert(EditItem);
            Nodes.hidColumns = "bCode";
            Nodes.ObjectBase = new JAction("New...", "ClassLibrary.JSubBaseDefine.GetNode", null, new object[] { _code });
            Nodes.DataTable = GetDataTable(_code, Fields);

            JToolbarNode TN = new JToolbarNode();
            TN.Click = JStaticAction._SubBaseDefineInsert(_code);
            TN.Icon = JImageIndex.Add;

            Nodes.AddToolbar(TN);
            //Array.Resize(ref Nodes.Items, Items.Length);
            //foreach (JSubBaseDefine SB in Items)
            //{
            //    Nodes.Insert(SB.GetNode());
            //}
        }

        public void ShowList()
        {
            JBaseDefineList list = new JBaseDefineList(this);
            list.ShowDialog();
            SelectedItem = list.SelectedItem;
        }

        public void Search()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int pBCode)
        {
            return GetDataTable(pBCode, null, null, "" , true,0, false,true);
            //JDataBase DB = JGlobal.MainFrame.GetDBO();
            //try
            //{
            //    DB.setQuery("SELECT [Code],[name] From [subdefine] WHERE [bcode]=" + pBCode.ToString() + " ORDER BY [name]");
            //    return DB.Query_DataTable();
            //}
            //finally
            //{
            //    DB.Dispose();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int pBCode, int parentCode)
        {
            return GetDataTable(pBCode, null, null, "parentcode =" + parentCode , true,0,false,true);
            //JDataBase DB = JGlobal.MainFrame.GetDBO();
            //try
            //{
            //    DB.setQuery("SELECT [Code],[name] From [subdefine] WHERE [bcode]=" + pBCode.ToString() + " AND parentcode =" + parentCode + " ORDER BY [name]");
            //    return DB.Query_DataTable();
            //}
            //finally
            //{
            //    DB.Dispose();
            //}
        }

        public DataTable GetList()
        {
            return GetList(_code);
        }

        public void SetComboBox(System.Windows.Forms.ComboBox pComboBox)
        {
            SetComboBox(pComboBox, 0);
        }

        public void SetComboBox(System.Windows.Forms.ComboBox pComboBox, int pDefaultValue)
        {
            DataTable TB = GetDataTable(_code);
            TB.TableName = "SubDefine";
            pComboBox.DataSource = TB;
            pComboBox.DisplayMember = "name";
            pComboBox.ValueMember = "Code";
            pComboBox.SelectedValue = pDefaultValue;
        }

        public void SetComboBox(JComboBox pComboBox)
        {
            SetComboBox(pComboBox, 0);
        }

        public void SetComboBox(JComboBox pComboBox, int pDefaultValue)
        {
            DataTable TB = GetDataTable(_code, null, null, "", false, 0, false,false);
            TB.TableName = "SubDefine";
            pComboBox.DataSource = TB;
            pComboBox.DisplayMember = "name";
            pComboBox.ValueMember = "Code";
            pComboBox.SelectedValue = pDefaultValue;
            pComboBox.BaseCode = _code;
        }
		public void SetDropDownList(DropDownList pDropDownList, int pDefaultValue)
		{
			DataTable TB = GetDataTable(_code);
			TB.TableName = "SubDefine";
			pDropDownList.DataTextField = "name";
			pDropDownList.DataValueField = "Code";
			pDropDownList.DataSource = TB;
			pDropDownList.DataBind();
			if (pDropDownList.Items.Count > 0 && pDefaultValue > 0)
				pDropDownList.SelectedValue = pDefaultValue.ToString();
		}


        public void SetListBox(System.Windows.Forms.ListBox pListBox, int pDefaultValue)
        {
            DataTable TB = GetDataTable(_code);
            pListBox.DataSource = TB;
            pListBox.DisplayMember = "name";
            pListBox.ValueMember = "Code";
            pListBox.SelectedValue = pDefaultValue;
        }
    }

}