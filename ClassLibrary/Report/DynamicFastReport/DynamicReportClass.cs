using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public enum JReportDesignCodes
    {
        /// <summary>
        /// نامه های محضر در قرارداد
        /// </summary>
        RegistryOfficeLetter = 1000000,
        /// <summary>
        /// گزارش اعیان و قراردادها
        /// </summary>
        RealEstateReport = 1000001,
        /// <summary>
        /// چاپ قبض شارژ
        /// </summary>
        PrintBill = 1000002,
        /// <summary>
        /// گواهی انتقال اعیان
        /// </summary>
        Transfer = 1000003,
        /// <summary>
        /// گواهی تایید انتقال اعیان
        /// </summary>
        ConfirmTransfer = 1000004,
        /// <summary>
        /// 2, گواهی نامه محضر 1
        /// </summary>
        OfficeLetter = 1000005,
        /// <summary>
        /// گزارش جلسات
        /// </summary>
        Meeting = 1000006,
        /// <summary>
        /// چاپ كارت هوشمند-كارت الكترونيك
        /// </summary>
        PrintCard = 1000007,
        /// <summary>
        /// چاپ قرعه کشی زمین
        /// </summary>
        PrintLottery = 1000008,
        /// <summary>
        /// زمین
        /// </summary>
        Ground = 15,
        /// <summary>
        /// تعرفه
        /// </summary>
        SheetGround = 1000009,
        /// <summary>
        /// شرکت کنندگان قرعه کشی
        /// </summary>
        LotteryRegister =13,
        /// <summary>
        /// گزارش قرارداد
        /// </summary>
        ReportContract = 1000010,
        /// <summary>
        /// درخواست انتقال برگه
        /// </summary>
        RequestTransferSheet = 1000011,
        /// <summary>
        /// باسکول
        /// </summary>
        Bascool = 1000012,
        /// <summary>
        /// 
        /// </summary>
        Sheet = 1000013,
        /// <summary>
        /// گزارش خرید و فروش کالا
        /// </summary>
        BillGoods = 1000014,
        /// <summary>
        /// 
        /// </summary>
        FormManager = 1000015,
        /// <summary>
        /// 
        /// </summary>
        ShareProfit = 1000016,
        /// <summary>
        /// رستوران
        /// </summary>
        Restaurant = 10,
        
    }
    public enum JReportType
    {
        FastReport = 1,
        WordRepor = 2,
    }
    public class JDynamicReport: JSystem
    {
        public int Code { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorUserCode { get; set; }
        public int CreatorPostCode { get; set; }
        public DateTime LastUpdate { get; set; }
        public JReportType ReportType { get; set; }
        public Int64 ReportCode { get; set; }
        public string Label { get; set; }
        public bool DefaultPrint { get; set; }
        public int FileWordCode { get; set; }
        public bool AccessAll { get; set; }

        //private JSubReport[] SubReports;
        private System.Data.DataTable[] DataTables;

        public JDynamicReport(Int64 pOldRepCode, Int64 pNewRepCode)
        {
            ReportCode = pNewRepCode;
            JDynamicReport.UpdateOldCodetoNewCode(pOldRepCode,pNewRepCode);
            DataTables = new System.Data.DataTable[0];
        }

        public JDynamicReport(string pLabel)
        {
            if (GetData(pLabel))
            {
                //SubReports = new JSubReport[0];
                DataTables = new System.Data.DataTable[0];
            }
        }

        public void Add(JSubReport pDataTable)
        {
            //Array.Resize(ref SubReports, SubReports.Length + 1);
            //SubReports[SubReports.Length - 1] = pDataTable;
        }

        public void Clear()
        {
            //Array.Resize(ref SubReports, 0);
            Array.Resize(ref DataTables, 0);
        }

        //public void AddRange(JSubReport[] pDataTables)
        //{
            //int Len = SubReports.Length;
            //Array.Resize(ref SubReports, SubReports.Length + pDataTables.Length);
            //int count = 0;
            //foreach (JSubReport DataTable in pDataTables)
            //{
                //SubReports[Len + count] = DataTable;
                //count++;
            //}
        //}


        public int CreateNew()
        { 
            if (ReportType == JReportType.FastReport)
            {
                FastReport.Report Rep = new FastReport.Report();
                SetDataTable(Rep);
                Rep.Design();
                //if (Rep.Design())
                  //  && ClassLibrary.JMessages.Question("آیا میخواهید تغییرات ذخیره شود؟", "Save") == System.Windows.Forms.DialogResult.Yes)
                {
                    FileName = Rep.FileName;
                    Content = Rep.SaveToString();
                    CreateDate = JDateTime.Now();
                    CreatorPostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    CreatorUserCode = ClassLibrary.JMainFrame.CurrentUserCode;
                    LastUpdate = ClassLibrary.JDateTime.Now();
                    return Insert();
                }
            }
            else
                if (ReportType == JReportType.WordRepor)
                {
                    if (DataTables.Length > 0)
                    {
                        CreateDate = JDateTime.Now();
                        CreatorPostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                        CreatorUserCode = ClassLibrary.JMainFrame.CurrentUserCode;
                        LastUpdate = ClassLibrary.JDateTime.Now();
                        Insert();
                        if (Code > 0)
                        {
                            OfficeWord.Controls.JTextControlForm Txt = new OfficeWord.Controls.JTextControlForm("ClassLibrary.JDynamicReport", Code);
                            Txt.DataTable = DataTables[0];
                            if (Txt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                FileWordCode = Txt.FileCode;
                            }
                            Txt.Dispose();
                            Update();
                        }
                        return Code;
                    }
                }
            return 0;
        }

        public bool CreateUpdate()
        {
            if (ReportType == JReportType.FastReport)
            {
                FastReport.Report Rep = new FastReport.Report();
                SetDataTable(Rep);
                Rep.LoadFromString(Content);
                if (Rep.Design()
                    && ClassLibrary.JMessages.Question("آیا میخواهید تغییرات ذخیره شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    Content = Rep.SaveToString();
                    LastUpdate = ClassLibrary.JDateTime.Now();
                    return Update();
                }
            }
            else
                if (ReportType == JReportType.WordRepor)
                {
                    if (Code > 0)
                    {
                        OfficeWord.Controls.JTextControlForm Txt = new OfficeWord.Controls.JTextControlForm("ClassLibrary.JDynamicReport", Code);
                        Txt.DataTable = DataTables[0];
                        if (Txt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            FileWordCode = Txt.FileCode;
                        }
                        Txt.Dispose();
                        LastUpdate = ClassLibrary.JDateTime.Now();
                        Update();
                    }
                }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (Code == 0)
                return Insert() > 0;
            else
                return Update();
        }
        /// <summary>
        /// درج
        /// </summary>
        /// <returns></returns
        public int Insert()
        {
            if (JPermission.CheckPermission("ClassLibrary.JDynamicReport.Insert"))
            {
                JDynamicReportTable DRT = new JDynamicReportTable();
                DRT.SetValueProperty(this);
                Code = DRT.Insert();
                return Code;
            }
            else
                return 0;
        }
        /// <summary>
        /// ویرایش
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (JPermission.CheckPermission("ClassLibrary.JDynamicReport.Update"))
            {
                JDynamicReportTable DRT = new JDynamicReportTable();
                DRT.SetValueProperty(this);
                return DRT.Update();
            }
            else
                return false;
        }
        /// <summary>
        /// حذف
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (JPermission.CheckPermission("ClassLibrary.JDynamicReport.Delete"))
            {
                JDynamicReportTable DRT = new JDynamicReportTable();
                DRT.SetValueProperty(this);
                return DRT.Delete();
            }
            else
                return false;
        }
        public bool GetData(string pLable)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {

                DB.setQuery("SELECT * FROM clsDynamicReport WHERE [Label]=N'" + pLable + "'");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                else
                {
                    JMessages.Error(".[گزارش پیدا نشد لطفا جهت طراحی گزارش با مدیر سیستم تماس بگیرید" + pLable + "]", "خطا");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// دریافت اطلاعات
        /// </summary>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {

                DB.setQuery("SELECT * FROM clsDynamicReport WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRep"></param>
        private void SetDataTable(FastReport.Report pRep)
        {
            try
            {
                foreach (System.Data.DataTable Dt in DataTables)
                {
                    pRep.RegisterData(Dt, Dt.TableName.Trim());
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Prview()
        {
            try
            {
                if (ReportType == JReportType.FastReport)
                {
                    FastReport.Report Rep = new FastReport.Report();
                    Rep.LoadFromString(Content);
                    SetDataTable(Rep);
                    Rep.Show();
                }
                else
                    if (ReportType == JReportType.WordRepor)
                    {
                        PrintPrviewWord(DataTables[0]);
                    }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            try
            {
                if (ReportType == JReportType.FastReport)
                {
                    FastReport.Report Rep = new FastReport.Report();
                    Rep.LoadFromString(Content);
                    SetDataTable(Rep);
                    Rep.PrintSettings.ShowDialog = false;
                    //Hassanzadeh
                    //Rep.PrintSettings.Collate = false;
                    //Rep.PrintSettings.Reverse = false;
                    Rep.Print();
                    if (Rep.Report.IsPrinting)
                    {
                    }
                }
                else
                    if (ReportType == JReportType.WordRepor && FileWordCode >= 0 && DataTables.Length > 0)
                    {
                        DataTable dt = DataTables[0];
                        string str = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                str = dt.Rows[i][j].ToString();
                                if ((str.Length == 10) && (str[4] == '/') && (str[7] == '/'))
                                    dt.Rows[i][j] = JGeneral.ReverseDate(str);
                            }

                        PrintWord(dt);
                    }
            }
            catch(Exception ex)
            {
            }
        }

        public void PrintWord(System.Data.DataTable pDT)
        {
            OfficeWord.JOfficeWord Off = new OfficeWord.JOfficeWord();
            Off.GetData(FileWordCode);

            System.Data.DataTable _temp = pDT.Clone();
            System.Data.DataRow _temprow = _temp.NewRow();
            _temp.Rows.Add(_temprow);

            OfficeWord.WinWordControl WinWord = new OfficeWord.WinWordControl();
            foreach (System.Data.DataRow _DR in pDT.Rows)
            {
                JTable.CopyRow(_DR, _temprow);
                string Content = Off.ReplaceXml(_temp, Off.DocumentContent, Off.Code);

                WinWord.LoadDocument(Content);

                if (pDT.Columns.IndexOf("Code") > -1)
                {
                    ClassLibrary.JBarcode Bar = new JBarcode();
                    System.Drawing.Bitmap BitBarCode = Bar.Draw(_DR["Code"].ToString());

                    WinWord.InsertImage("BarCode", BitBarCode);
                    BitBarCode.Dispose();
                }
                WinWord.Print();
                System.Windows.Forms.Application.DoEvents();
            }
            System.Windows.Forms.Application.DoEvents();
            WinWord.CloseWord();
            WinWord.Dispose();
        }


        public void PrintPrviewWord(System.Data.DataTable pDT)
        {
            OfficeWord.JOfficeWord Off = new OfficeWord.JOfficeWord();
            Off.GetData(FileWordCode);

            System.Data.DataTable _temp = pDT.Clone();
            System.Data.DataRow _temprow = _temp.NewRow();
            _temp.Rows.Add(_temprow);

            OfficeWord.WinWordControl WinWord = new OfficeWord.WinWordControl();
            System.Data.DataRow _DR = pDT.Rows[0];
            JTable.CopyRow(_DR, _temprow);
            string Content = Off.ReplaceXml(_temp, Off.DocumentContent, Off.Code);

            WinWord.LoadDocument(Content);
            WinWord.PrintPrview();
            System.Windows.Forms.Application.DoEvents();
            //JMessages.Message("", "", JMessageType.Confirmation);
            //WinWord.CloseWord();
            //WinWord.Dispose();
        }

        public void ResetDefalt()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("UPDATE clsDynamicReport SET DefaultPrint=0 WHERE ReportCode = " + ReportCode.ToString());
                DB.Query_Execute();
            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void Add(System.Data.DataTable pDataTable)
        {
            Array.Resize(ref DataTables, DataTables.Length + 1);
            DataTables[DataTables.Length - 1] = pDataTable;
        }

        public void AddRange(System.Data.DataTable[] pDataTables)
        {
            int Len = DataTables.Length;
            Array.Resize(ref DataTables, DataTables.Length + pDataTables.Length);
            int count = 0;
            foreach (System.Data.DataTable DataTable in pDataTables)
            {
                DataTables[Len + count] = DataTable;
                count++;
            }
        }

        public static void UpdateOldCodetoNewCode(Int64 pOldRepCode, Int64 pNewRepCode)
        {
            if (pOldRepCode == pNewRepCode || pOldRepCode == 0) return;
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("update clsDynamicReport set ReportCode=" + pNewRepCode.ToString() + " where ReportCode=" + pOldRepCode.ToString());
                DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }
    }

    public class JDynamicReports : JSystem
    {
        private Int64 _ReportCode;
        public JDynamicReport[] Items = new JDynamicReport[0];
        public System.Data.DataTable[] DataTables;
        public JDynamicReports(int pNewRepCode)
            : this(0, pNewRepCode)
        {
        }

        public JDynamicReports(Int64 pOldRepCode, Int64 pNewRepCode)
        {
            _ReportCode = pNewRepCode;
            JDynamicReport.UpdateOldCodetoNewCode(pOldRepCode, pNewRepCode);
            if (pNewRepCode >= 0)
                GetDatas();
        }

        public void GetDatas()
        {                
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM clsDynamicReport WHERE ReportCode=" + _ReportCode.ToString()
                    + " And ( AccessAll=1 OR " + JPermission.getObjectSql("ClassLibrary.JDynamicReports.GetDatas", "Code")
                    + ")");
                System.Data.DataTable DT = DB.Query_DataTable();

                Array.Resize(ref Items, DT.Rows.Count);
                int count = 0;
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    Items[count] = new JDynamicReport(_ReportCode, _ReportCode);
                    JTable.SetToClassProperty(Items[count], DR);
                    count++;
                }
            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        public System.Data.DataTable GetData()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                if (_ReportCode == 0)
                {
                    DB.setQuery("SELECT * FROM clsDynamicReport WHERE " +
                         JPermission.getObjectSql("ClassLibrary.JDynamicReports.GetDatas", "Code"));
                }
                else
                {
                    DB.setQuery("SELECT * FROM clsDynamicReport WHERE ReportCode=" + _ReportCode.ToString()
                        + " And " + JPermission.getObjectSql("ClassLibrary.JDynamicReports.GetDatas", "Code"));
                }
                System.Data.DataTable DT = DB.Query_DataTable();

                Array.Resize(ref Items, DT.Rows.Count);
                int count = 0;
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    Items[count] = new JDynamicReport(_ReportCode, _ReportCode);
                    JTable.SetToClassProperty(Items[count], DR);
                    count++;
                }
                
                return DT;
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void Add(System.Data.DataTable pDataTable)
        {
            if (DataTables == null)
                DataTables = new System.Data.DataTable[0];
            Array.Resize(ref DataTables, DataTables.Length + 1);
            DataTables[DataTables.Length - 1] = pDataTable;
        }
        
        public bool Print(string pLabel, bool pPreview, bool pDesign)
        {
            JDynamicReport DR = new JDynamicReport(pLabel);
            DR.AddRange(DataTables);
            if (DR.ReportCode > 0)
            {
                if (pDesign)
                    DR.CreateUpdate();
                else
                    if (pPreview)
                        DR.Prview();
                    else
                        DR.Print();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PrintDefault()
        {
            bool _Print = false;
            foreach (JDynamicReport _Rep in Items)
            {
                _Rep.Clear();
                _Rep.AddRange(DataTables);
                if (_Rep.DefaultPrint)
                {
                    if (_Rep.ReportType == JReportType.FastReport)
                        _Rep.Print();
                    else
                        if (_Rep.ReportType == JReportType.WordRepor)
                            _Rep.PrintWord(DataTables[0]);
                    _Print = true;
                }

            }
            if (!_Print)
                JMessages.Error("پرینت پیش فرض پیدا نشد", "پرینت پیش فرض");
            return _Print;
        }

    }
}
