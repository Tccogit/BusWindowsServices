using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Globals;
using System.Runtime.InteropServices;
using Legal;
using Estates;
using Meeting;
using System.IO;

namespace ClassLibrary
{
    public partial class JReport : UserControl
    {

        #region LegDescription               
        //--------قوانین----------
        /*
          1- در نامگذاری فیلدها عدد 1 برای جداسازی نام جدول با نام خود فیلد است در نام جدول از مخفف آن استفاده شده
          2- در نامگذاری کنترل ها عدد 2 برای کنترل هایی است که یک بازه دارند و عدد 2 در نام کنترل مشخص کننده بازه انتهایی است
          3-قرار می گیرد  = < > In Like  کنترل ها علامت مقایسه ای Tagدر تگ
          4 -در ها حتما مواظب باشید دو مسیر برای رسیدن به یک جدول ایجاد نکنید جانه مادرتونJoin
        */
        #endregion
       
        #region Private

        /// <summary>
        /// فیلدها
        /// </summary>
        private string _Fields;
        public string Fields
        {
            get
            {
                return _Fields;
            }
            set
            {
                _Fields = value;
            }
        }        
        public string _Where = "";
        public List<string> Tables = new List<string>();
        private List<string> _BaseTables = new List<string>();
        private List<string> _Tables = new List<string>();
        private List<string> _Stack = new List<string>();
        private List<string> _ReleationStack = new List<string>();
        private string _GroupBy ="";
        public JSubReport[] SubReports = new JSubReport[0];
        #endregion

        public JReport()
        {
            InitializeComponent();
            tabControl1.TabPages.Clear();            
        }

        #region Methods


        /// <summary>
        /// نمایش تب ها
        /// </summary>
        /// <param name="str"></param>
        public void ShowTabs(string str)
        {
            if (DesignMode) return;
            try
            {
                tabControl1.TabPages.Clear();
                string[] tab = str.Split(',');
                for (int i = 0; i < tab.Length; i++)
                {
                    //---------------زمین-------------
                    if (tab[i] == "tpestGround")
                        tabControl1.TabPages.Add(tpestGround);
                    if (tab[i] == "tpestPrimaryOwnerGround")
                        tabControl1.TabPages.Add(tpestPrimaryOwnerGround);
                    if (tab[i] == "tpestGroundBreakDown")
                        tabControl1.TabPages.Add(tpestGroundBreakDown);
                    if (tab[i] == "tpestLand")
                        tabControl1.TabPages.Add(tpestLand);
                    if (tab[i] == "tpestAboute")
                        tabControl1.TabPages.Add(tpestAboute);
                    //if (tab[i] == "tpestDivision")
                    //    tabControl1.TabPages.Add(tpestDivision);
                    if (tab[i] == "tpestAggregate")
                        tabControl1.TabPages.Add(tpestAggregate);
                    //if (tab[i] == "tpestGBreak")
                    //    tabControl1.TabPages.Add(tpestGBreak);
                    //---------------اعیان-------------
                    if (tab[i] == "tprestBuild")
                        tabControl1.TabPages.Add(tprestBuild);
                    if (tab[i] == "tpestPrimaryOwnerBuild")
                        tabControl1.TabPages.Add(tpestPrimaryOwnerBuild);
                    //if (tab[i] == "tpestOwnerBuild")
                    //    tabControl1.TabPages.Add(tpestOwnerBuild);
                    //---------------اموال-------------
                    if (tab[i] == "tpfinAsset")
                        tabControl1.TabPages.Add(tpfinAsset);
                    if (tab[i] == "tpfinActiveAssetShare")
                        tabControl1.TabPages.Add(tpfinActiveAssetShare);
                    if (tab[i] == "tpfinNActiveAssetShare")
                        tabControl1.TabPages.Add(tpfinNActiveAssetShare);
                    if (tab[i] == "tpfinBlockAssetShare")
                        tabControl1.TabPages.Add(tpfinBlockAssetShare);
                    if (tab[i] == "tpfinGoodWillAssetTransfer")
                        tabControl1.TabPages.Add(tpfinGoodWillAssetTransfer);
                    if (tab[i] == "tpfinDefinitiveAssetTransfer")
                        tabControl1.TabPages.Add(tpfinDefinitiveAssetTransfer);
                    //---------------قرارداد-------------
                    if (tab[i] == "tplegContract")
                        tabControl1.TabPages.Add(tplegContract);
                    if (tab[i] == "tplegBuyerContract")
                        tabControl1.TabPages.Add(tplegBuyerContract);
                    if (tab[i] == "tplegAdBuyerContract")
                        tabControl1.TabPages.Add(tpAdBuyerContract);
                    if (tab[i] == "tplegSellerContract")
                        tabControl1.TabPages.Add(tpSellerContract);
                    if (tab[i] == "tplegAdSellerContract")
                        tabControl1.TabPages.Add(tpAdSellerContract);
                    if (tab[i] == "tplegIntutionContract")
                        tabControl1.TabPages.Add(tpIntutionContract);
                    if (tab[i] == "tplegContractCheque")
                        tabControl1.TabPages.Add(tplegContractCheque);
                    if (tab[i] == "tplegContractFish")
                        tabControl1.TabPages.Add(tplegContractFish);
                    if (tab[i] == "tplegContractProm")
                        tabControl1.TabPages.Add(tplegContractProm);
                    //---------------وکالت-------------
                    if (tab[i] == "tplegAdvocacy")
                        tabControl1.TabPages.Add(tplegAdvocacy);
                    if (tab[i] == "tplegAdvocacyVicarious")
                        tabControl1.TabPages.Add(tplegAdvocacyVicarious);
                    if (tab[i] == "tplegAdvocacyAdvocate")
                        tabControl1.TabPages.Add(tplegAdvocacyAdvocate);
                    if (tab[i] == "tplegAdvocacySubject")
                        tabControl1.TabPages.Add(tplegAdvocacySubject);
                    //---------------اظهارنامه-------------
                    if (tab[i] == "tplegAssertion")
                        tabControl1.TabPages.Add(tplegAssertion);
                    if (tab[i] == "tplegAssertionPerson")
                        tabControl1.TabPages.Add(tplegAssertionPerson);
                    //---------------دادخواست-------------
                    if (tab[i] == "tplegPetition")
                        tabControl1.TabPages.Add(tplegPetition);
                    if (tab[i] == "tplegComplainantPetition")
                        tabControl1.TabPages.Add(tplegComplainantPetition);
                    if (tab[i] == "tplegAdComplainantPetition")
                        tabControl1.TabPages.Add(tplegAdComplainantPetition);
                    if (tab[i] == "tplegFeyPetition")
                        tabControl1.TabPages.Add(tplegFeyPetition);
                    if (tab[i] == "tplegAdFeyPetition")
                        tabControl1.TabPages.Add(tplegAdFeyPetition);
                    if (tab[i] == "tplegDecision")
                        tabControl1.TabPages.Add(tplegDecision);
                    if (tab[i] == "tplegDecisionType")
                        tabControl1.TabPages.Add(tplegDecisionType);
                    if (tab[i] == "tplegExcutive")
                        tabControl1.TabPages.Add(tplegExcutive);
                    if (tab[i] == "tplegWinnerExecute")
                        tabControl1.TabPages.Add(tplegWinnerExecute);
                    if (tab[i] == "tplegLoserExecute")
                        tabControl1.TabPages.Add(tplegLoserExecute);
                    if (tab[i] == "tplegNotice")
                        tabControl1.TabPages.Add(tplegNotice);
                    //---------------مجتمع-------------
                    if (tab[i] == "tprestMarket")
                        tabControl1.TabPages.Add(tprestMarket);
                    if (tab[i] == "tprestMarketUsage")
                        tabControl1.TabPages.Add(tprestMarketUsage);
                    if (tab[i] == "tpMarketLocation")
                        tabControl1.TabPages.Add(tpMarketLocation);
                    if (tab[i] == "tpMarketFloor")
                        tabControl1.TabPages.Add(tpMarketFloor);
                    if (tab[i] == "tpMarketPrice")
                        tabControl1.TabPages.Add(tpMarketPrice);
                    //---------------رستوران-------------
                    if (tab[i] == "tpPersonFood")
                        tabControl1.TabPages.Add(tpPersonFood);
                    if (tab[i] == "tpEmployeeFood")
                        tabControl1.TabPages.Add(tpEmployeeFood);
                    if (tab[i] == "tpResPerFood")
                        tabControl1.TabPages.Add(tpResPerFood);
                    if (tab[i] == "tpResEmpFood")
                        tabControl1.TabPages.Add(tpResEmpFood);
                    
                    //---------------جلسات-------------
                    if (tab[i] == "tpMetMeeting")
                        tabControl1.TabPages.Add(tpMetMeeting);
                    if (tab[i] == "tpMetLegislation")
                        tabControl1.TabPages.Add(tpMetLegislation);
                    if (tab[i] == "tpMetPersonMeeting")
                        tabControl1.TabPages.Add(tpMetPersonMeeting);
                    if (tab[i] == "tpMetProgram")
                        tabControl1.TabPages.Add(tpMetProgram);
              }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #region FillAllData
                
        /// <summary>
        /// پر کردن Combo و ...
        /// </summary>
        private void FillData()
        {
            if (DesignMode) return;
            try
            {
                //Contract
                Fill_Contract();
                //Contract Cheque----------چک قرارداد------------
                Fill_ContractCheque();
                //UnitBuild----------اعیان------------
                Fill_UnitBuild();
                // Asset----------اموال------------
                foreach (Finance.JAssetType type in Finance.JAsset.GetAssetType())
                    A1ClassName.Items.Add(type);
                //Advocacy----------وکالت------------
                LAS1SubjectCode.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ClassLibrary.ContractType")));//Legal.ContractType
                //Decision----------رای دادگاه------------
                DT1Type.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ClassLibrary.DecisionType")));//Legal.DecisionType                
                //Petition----------دادخواست------------
                Fill_Petition();
                //Market----------مجتمع------------
                Fill_Market();
                //Ground----------زمین------------
                Fill_Ground();
                //Restaurant------رستوران------------
                FillRestaurant();
                //Restaurant------جلسات------------
                FillMeeting();
            }            
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #region Meeting
        private void FillMeeting()
        {
            DataTable dtCommission = new DataTable();
            dtCommission = JCommissions.GetDataTable(0);
            DataRow dr = dtCommission.NewRow();
            dr["Code"] = -1;
            dr["name"] = "-----------";
            dtCommission.Rows.Add(dr);
            Meet1CommissionCode.DisplayMember = "Name";
            Meet1CommissionCode.ValueMember = "Code";
            Meet1CommissionCode.DataSource = dtCommission;
            Meet1CommissionCode.SelectedValue = -1;

            DataTable dtLeg1Flow = new DataTable();
            dtLeg1Flow = ClassLibrary.Domains.JGlobal.JStatus.GetData();
            DataRow dr1 = dtLeg1Flow.NewRow();
            dr1["value"] = -1;
            dr1["FarsiName"] = "-----------";
            dr1["name"] = "-----------";
            dtLeg1Flow.Rows.Add(dr1);
            MetLeg1Flow.DisplayMember = "FarsiName";
            MetLeg1Flow.ValueMember = "value";
            MetLeg1Flow.DataSource = dtLeg1Flow;
            MetLeg1Flow.SelectedValue = -1;

   
            JSubBaseDefines LegGroup = new JSubBaseDefines(JBaseDefine.LegislationGroupType);
            JLegislation tmpLeg = new JLegislation();
            LegGroup.SetComboBox(MetLeg1LegislationGroup, tmpLeg.LegislationGroup);            
        }

        #endregion

        #region MyRegion
        public void FillRestaurant()
        {
            try
            {
                //پرکردن کمبو غذاها
                JSubBaseDefine NullDef = new JSubBaseDefine(0);
                NullDef.Name = "-----------";
                NullDef.Code = -1;
                ResP1FoodCode.Items.Add(NullDef);
                ResP1FoodCode.SelectedItem = NullDef;
                DataTable FoodTable = Restaurant.JFoods.GetDataTable(0, Restaurant.JFoodType.All);
                DataRow NullRow = FoodTable.NewRow();
                NullRow["Code"] = -1;
                NullRow["Name"] = "-----------";
                FoodTable.Rows.InsertAt(NullRow, 0);
                ResP1FoodCode.DataSource = FoodTable;
                ResP1FoodCode.DisplayMember = "Name";
                ResP1FoodCode.ValueMember = "Code";
                //if (EmployeeFood.CodeFood != 0)
                //    ResP1FoodCode.SelectedValue = EmployeeFood.CodeFood;

                //پرکردن کمبو غذاها
                JSubBaseDefine NullDef1 = new JSubBaseDefine(0);
                NullDef1.Name = "-----------";
                NullDef1.Code = -1;
                ResEM1FoodCode.Items.Add(NullDef1);
                ResEM1FoodCode.SelectedItem = NullDef1;
                DataTable FoodTable1 = Restaurant.JFoods.GetDataTable(0, Restaurant.JFoodType.All);
                DataRow NullRow1 = FoodTable1.NewRow();
                NullRow1["Code"] = -1;
                NullRow1["Name"] = "-----------";
                FoodTable1.Rows.InsertAt(NullRow1, 0);
                ResEM1FoodCode.DataSource = FoodTable1;
                ResEM1FoodCode.DisplayMember = "Name";
                ResEM1FoodCode.ValueMember = "Code";
                //if (EmployeeFood.CodeFood != 0)
                //ResEm1CodeFood.SelectedValue = EmployeeFood.CodeFood;

                NullDef.Name = "-----------";
                NullDef.Code = -1;
                ResEM1CostCenter.Items.Add(NullDef);
                ResEM1CostCenter.SelectedItem = NullDef;
                Restaurant.JCostCenters JCCs = new Restaurant.JCostCenters();
                JCCs.SetComboBox(ResEM1CostCenter, 0);
                //foreach (JSubBaseDefine Cc in JCCs.Items)
                //    ResEM1CostCenter.Items.Add(Cc);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        #region Contract
        /// <summary>
            /// پر کردن اطلاعات قیش و چک و سفته
            /// </summary>
            private void Fill_ContractCheque()
            {
                Finance.JConcernTypes Subjects = new Finance.JConcernTypes();
                JSubBaseDefine nullDeffConcern = new JSubBaseDefine(0);
                nullDeffConcern.Code = -1;
                nullDeffConcern.Name = "-----------";

                Ch1Concern.Items.Clear();
                Ch1Concern.Items.Clear();
                Ch1Concern.Items.Add(nullDeffConcern);
                Ch1Concern.SelectedItem = nullDeffConcern;
                F1Concern.Items.Clear();
                F1Concern.Items.Add(nullDeffConcern);
                F1Concern.SelectedItem = nullDeffConcern;
                P1Concern.Items.Clear();
                P1Concern.Items.Add(nullDeffConcern);
                P1Concern.SelectedItem = nullDeffConcern;
                Subjects.SetComboBox(Ch1Concern, 0);
                Subjects.SetComboBox(F1Concern, 0);
                Subjects.SetComboBox(P1Concern, 0);

                //foreach (JSubBaseDefine Subject in Subjects.Items)
                //{
                //    Ch1Concern.Items.Add(Subject);
                //    //Contract Fish
                //    F1Concern.Items.Add(Subject);
                //    //Contract Pro
                //    P1Concern.Items.Add(Subject);
                //}

                Finance.JBankTypes Banks = new Finance.JBankTypes();
                JSubBaseDefine nullDeffbank = new JSubBaseDefine(0);
                nullDeffbank.Code = -1;
                nullDeffbank.Name = "-----------";

                Ch1Bank_Code.Items.Clear();
                Ch1Bank_Code.Items.Add(nullDeffbank);
                Ch1Bank_Code.SelectedItem = nullDeffbank;
                F1Bank_Code.Items.Clear();
                F1Bank_Code.Items.Add(nullDeffbank);
                F1Bank_Code.SelectedItem = nullDeffbank;
                Banks.SetComboBox(Ch1Bank_Code, 0);
                Banks.SetComboBox(F1Bank_Code, 0);
                Banks.SetComboBox(Ch1Bank_Code, 0);
                Banks.SetComboBox(F1Bank_Code, 0);
                //foreach (JSubBaseDefine Bank in Banks.Items)
                //{
                //    Ch1Bank_Code.Items.Add(Bank);
                //    //Contract Fish
                //    F1Bank_Code.Items.Add(Bank);
                //}

                Finance.JBranchTypes Branchs = new Finance.JBranchTypes();
                JSubBaseDefine nullDeffbranch = new JSubBaseDefine(0);
                nullDeffbranch.Code = -1;
                nullDeffbranch.Name = "-----------";

                Ch1branch_Code.Items.Clear();
                Ch1branch_Code.Items.Add(nullDeffbranch);
                Ch1branch_Code.SelectedItem = nullDeffbranch;
                F1branch_Code.Items.Clear();
                F1branch_Code.Items.Add(nullDeffbranch);
                F1branch_Code.SelectedItem = nullDeffbranch;
                Branchs.SetComboBox(Ch1branch_Code);
                Branchs.SetComboBox(F1branch_Code);
                //foreach (JSubBaseDefine Branch in Branchs.Items)
                //{
                //    Ch1branch_Code.Items.Add(Branch);
                //    //Contract Fish  
                //    F1branch_Code.Items.Add(Branch);
                //}
            }
            /// <summary>
            /// پر کردن اطلاعات قرارداد
            /// </summary>        
            private void Fill_Contract()
            {
                try
                {
                    DataTable dtLocation = (new JOrganizations()).GetOrganization(0);
                    DataRow dr = dtLocation.NewRow();
                    dr["Code"] = -1;
                    dr["name"] = "-----------";
                    dtLocation.Rows.Add(dr);
                    C1Location.DisplayMember = "name";
                    C1Location.ValueMember = "Code";
                    C1Location.DataSource = dtLocation;
                    C1Location.Text = "";

                    DataTable dt = Legal.JContractdefines.GetDataTable(0, 0, null);
                    DataRow dr1 = dt.NewRow();
                    dr1["Code"] = -1;
                    dr1["Title"] = "-----------";
                    dt.Rows.Add(dr1);
                    C1Type.DisplayMember = "Title";
                    C1Type.ValueMember = "Code";
                    C1Type.DataSource = dt;
                    C1Type.Text = "";

                    C1Status.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ClassLibrary.JContractStatus")));
                    
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
            #endregion

        #region Ground
            /// <summary>
            /// پر کردن اطلاعات زمین
            /// </summary>
            private void Fill_Ground()
            {
                try
                {
                    JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                    nullDeff.Code = -1;
                    nullDeff.Name = "-----------";

                    JLands lands = new JLands();
                    DataTable dt = lands.GetDataTable();
                    DataRow dr1 = dt.NewRow();
                    dr1["Code"] = -1;
                    dr1["Name"] = "-----------";
                    dt.Rows.Add(dr1);
                    G1Land.DisplayMember = "Name";
                    G1Land.ValueMember = "Code";
                    G1Land.DataSource = dt;

                    dt = Estates.JUsageGrounds.GetDataTable();
                    DataRow dr = dt.NewRow();
                    dr["Code"] = -1;
                    dr["Name"] = "-----------";
                    dt.Rows.Add(dr);
                    G1Usage.DisplayMember = "Name";
                    G1Usage.ValueMember = "Code";
                    G1Usage.DataSource = dt;

                    //txtArea.Text = Convert.ToString(_newGround.Area);
                    G1EstateType.Items.Clear();
                    G1EstateType.Items.Add(nullDeff);
                    G1EstateType.SelectedItem = nullDeff;
                    Estates.JEstateTypes EsType = new Estates.JEstateTypes();
                    EsType.SetComboBox(G1EstateType);
                    //foreach (JSubBaseDefine Type in EsType.Items)
                    //    G1EstateType.Items.Add(Type);

                    G1DocumentType.Items.Clear();
                    G1DocumentType.Items.Add(nullDeff);
                    G1DocumentType.SelectedItem = nullDeff;
                    Estates.JDocumentTypes DTypes = new Estates.JDocumentTypes();
                    DTypes.SetComboBox(G1DocumentType);
                    //foreach (JSubBaseDefine DType in DTypes.Items)
                    //    G1DocumentType.Items.Add(DType);
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }

            #endregion

        #region Markets
            /// <summary>
            /// پر کردن اطلاعات اعیان
            /// </summary>
            private void Fill_UnitBuild()
            {
                try
                {
                    RealEstate.JUnitTypes UnitType = new RealEstate.JUnitTypes();
                    JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                    nullDeff.Code = -1;
                    nullDeff.Name = "-----------";

                    B1TypeCode.Items.Clear();
                    B1TypeCode.Items.Add(nullDeff);
                    B1TypeCode.SelectedItem = nullDeff;
                    UnitType.SetComboBox(B1TypeCode);
                    //foreach (JSubBaseDefine city in UnitType.Items)
                    //    B1TypeCode.Items.Add(city);

                    RealEstate.JUnitJobs UnitJobs = new RealEstate.JUnitJobs();
                    B1UnitJob.Items.Clear();
                    B1UnitJob.Items.Add(nullDeff);
                    B1UnitJob.SelectedItem = nullDeff;
                    UnitJobs.SetComboBox(B1UnitJob);
                    //foreach (JSubBaseDefine job in UnitJobs.Items)
                    //    B1UnitJob.Items.Add(job);

                    DataTable Markets = RealEstate.jMarkets.GetDataTable(0);
                    DataRow dr = Markets.NewRow();
                    dr["Code"] = -1;
                    dr[RealEstate.estMarket.Title.ToString()] = "-----------";
                    Markets.Rows.Add(dr);
                    B1MarketCode.DisplayMember = RealEstate.estMarket.Title.ToString();
                    B1MarketCode.ValueMember = RealEstate.estMarket.Code.ToString();
                    B1MarketCode.DataSource = Markets;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
            /// <summary>
            ///مجتمع پر کردن لیست کاربری ها
            /// </summary>
            private void Fill_Market()
            {
                try
                {
                    RealEstate.JDefineMarketUsages Usages = new RealEstate.JDefineMarketUsages();
                    MU1UsageCode.Items.Clear();
                    Usages.SetComboBox(MU1UsageCode);
                    //foreach (JSubBaseDefine Usage in Usages.Items)
                    //    MU1UsageCode.Items.Add(Usage);
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }

            #endregion

        #region Petition
            /// <summary>
            /// پر کردن اطلاعات دادخواست
            /// </summary>
            private void Fill_Petition()
            {
                try
                {
                    JDefineSubjectTypes Subjects = new JDefineSubjectTypes();
                    LP1Subject_Code.Items.Clear();
                    Subjects.SetComboBox(LP1Subject_Code);
                    //foreach (JSubBaseDefine Subject in Subjects.Items)
                    //    LP1Subject_Code.Items.Add(Subject);
                    //------------مجتمع قضائی
                    Legal.JJudicialComplexs Jcs = new Legal.JJudicialComplexs();
                    Jcs.getData();
                    foreach (JJudicialComplex Jc in Jcs.items)
                        cmbJudicalComplex.Items.Add(Jc);
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }

            private void cmbJudicalComplex_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    JJudicialComplex tmpJJudicialComplex = new JJudicialComplex();
                    LP1judicialCode.DisplayMember = "Name";
                    LP1judicialCode.ValueMember = "Code";
                    LP1judicialCode.DataSource = JJudicialComplex.ListBranch(((Legal.JJudicialComplex)(cmbJudicalComplex.SelectedItem)).Code);
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }

            #endregion

        #region Advocacy
            /// <summary>
            /// اطلاعات اموال
            /// </summary>
            /// <param name="pPersonCode"></param>
            private void FillAsset(int pPersonCode)
            {
                //لیست اموال
                //AF1FinanceCode.Items.Clear();
                //Finance.JAssetShares shares = new Finance.JAssetShares();
                //shares.GetPersonAssetShares(pPersonCode);
                //foreach (Finance.JAssetShare share in shares.Items)
                //    AF1FinanceCode.Items.Add(share);
            }

            private void LA2Person_Code_Leave(object sender, EventArgs e)
            {
                try
                {
                    if (LV1Person_Code.SelectedCode > 0)
                        FillAsset(Convert.ToInt32(LV1Person_Code.SelectedCode));
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }                
            }
            /// <summary>
            /// تب وکالت
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnSearchNotary_Click(object sender, EventArgs e)
            {
                try
                {
                    Legal.JNotaryLetterSearchForm p = new Legal.JNotaryLetterSearchForm();
                    p.ShowDialog();
                    AD1NotaryCode.Text = p.Code.ToString();
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }

            #endregion

        #endregion

        #region Join

        private bool StackFind(List<string> pS, string pName)
        {
            try
            {
                foreach (string S in pS)
                {
                    if (pName == S)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        string[][] Joins = { 
                              //---------------------اموال--------------------
                              
                              new string[] { "FinAssetTransfer", "VActiveAssetShare","finAssetTransfer.Code = VActiveAssetShare.TCode" } 
                              ,
                              new string[] { "FinAssetTransfer", "VNActiveAssetShare","finAssetTransfer.Code = VNActiveAssetShare.TCode" } 
                              ,
                              new string[] { "FinAssetTransfer", "VBlockAssetShare","finAssetTransfer.Code = VBlockAssetShare.TCode" } 
                              ,
                              new string[] { "VGoodWillAssetTransfer", "finAssetShare","finAssetShare.Code = VGoodWillAssetTransfer.ACode" } 
                              ,
                              new string[] { "VDefinitiveAssetTransfer", "finAssetShare","finAssetShare.Code = VDefinitiveAssetTransfer.ACode" } 
                              ,
                              new string[] { "FinAssetTransfer", "finAssetShare","finAssetTransfer.Code = finAssetShare.TCode" } 
                              ,
                              //new string[] { "FinAssetTransfer", "finAsset","finAssetTransfer.ACode = finAsset.Code" } 
                              //,
                              //new string[] { "finAssetShare", "FinAssetTransfer","finAssetTransfer.Code = finAssetShare.TCode" } 
                              new string[] { "finAsset", "finAssetShare","finAssetShare.ACode = finAsset.Code" } 
                              ,
                              //ارتباط اموال با قرارداد
                              new string[]{"FinAsset","LegSubjectContract","finAsset.Code = LegSubjectContract.FinanceCode"}
                              ,//ارتباط اموال با وکالت
                              new string[] {"finAssetShare","LegAdvocacyFinance","LegAdvocacyFinance.FinanceCode = finAssetShare.Code"}
                              ,//ارتباط اموال با اشخاص
                              new string[] {"finAssetShare","ClsAllPerson","ClsAllPerson.Code = finAssetShare.personcode"}
                              ,//ارتباط اموال با اعیان
                              //new string[]{"FinAsset","estUnitBuild","finAsset.ClassName='JAssetType.Estates_JUnitBuild' and finAsset.ObjectCode= estUnitBuild.Code"}
                              //,//ارتباط اموال با اعیان
                              new string[] { "estUnitBuild", "finAsset","estUnitBuild.Code = finAsset.ObjectCode AND finAsset.ClassName='RealEstate.JUnitBuild'" } 
                              ,
                              //new string[] { "VActiveAssetShare", "clsPersonAddress","VActiveAssetShare.PersonCode = clsPersonAddress.PCode" } 
                              //,
                              //new string[] { "VNActiveAssetShare", "clsPersonAddress","VNActiveAssetShare.PersonCode = clsPersonAddress.PCode" } 
                              //,
                              //new string[] { "finAssetShare", "clsPersonAddress","finAssetShare.PersonCode = clsPersonAddress.PCode" } 
                              //,
                              //---------------------قرارداد--------------------
                              new string[]{"LegSubjectContract","LegDocumentContract","LegSubjectContract.Code = LegDocumentContract.ContractSubjectCode"}
                              ,
                              new string[]{"FinFish","LegDocumentContract","FinFish.Code = LegDocumentContract.ObjectCode AND LegDocumentContract.ClassName='Finance.JFish'"}
                              ,
                              new string[]{"FinPromissoryNote","LegDocumentContract","FinPromissoryNote.Code = LegDocumentContract.ObjectCode AND LegDocumentContract.ClassName='Finance.JPromissoryNote'"}
                              ,
                              new string[]{"FinCheques","LegDocumentContract","finCheques.Code = LegDocumentContract.ObjectCode AND LegDocumentContract.ClassName='Finance.JCheque'"}
                              ,
                              new string[]{"VSellerContract","LegSubjectContract","LegSubjectContract.Code = VSellerContract.ContractSubjectCode"}
                              ,
                              new string[]{"VAdSellerContract","LegSubjectContract","LegSubjectContract.Code = VAdSellerContract.ContractSubjectCode"}
                              ,
                              new string[]{"VBuyerContract","LegSubjectContract","LegSubjectContract.Code = VBuyerContract.ContractSubjectCode"}
                              ,
                              new string[]{"VAdBuyerContract","LegSubjectContract","LegSubjectContract.Code = VAdBuyerContract.ContractSubjectCode"}
                              ,
                              new string[]{"VIntuitionContract","LegSubjectContract","LegSubjectContract.Code = VIntuitionContract.ContractSubjectCode"}
                              ,
                              //-----------------------وکالت------------------
                              new string[] {"LegAdvocacy","LegAdvocacyFinance","LegAdvocacyFinance.Advocacy_Code = LegAdvocacy.Code"}
                              ,
                              new string[] {"LegAdvocacy","LegSubject","LegSubject.Advocacy_Code = LegAdvocacy.Code"}
                              ,
                              new string[] {"LegAdvocacy","LegAdvocate","LegAdvocate.Advocacy_Code = LegAdvocacy.Code"}
                              ,
                              new string[] {"LegAdvocacy","LegVicarious","LegVicarious.Advocacy_Code = LegAdvocacy.Code"}
                              ,
                              //-------------------------زمین----------------
                              new string[] {"estground","estLand","estLand.Code = estground.Land"}
                              ,
                              new string[] {"estground","FinAsset","FinAsset.ObjectCode = estground.Code AND FinAsset.ClassName='Estates.JGround' "}
                              ,
                              new string[] {"estPrimaryOwnerGround","estground","estPrimaryOwnerGround.CodeGround = estground.Code"}
                              ,
                              new string[] {"estAboute","estground","estAboute.CodeGround = estground.Code"}
                              ,
                              new string[] {"estGroundBreakDown","estground","estGroundBreakDown.GroundBreakDown = estground.Code"}
                              ,
                              new string[] {"estGroundBreakDown","estGroundsBreakDown","estGroundsBreakDown.BreakDownCode = estGroundBreakDown.Code"}
                              ,
                              new string[] {"estAggregateGround","estground","estAggregateGround.GroundAggregationbyCode = estground.Code"}
                              ,
                              new string[] {"estAggregateGround","estAggregateGrounds","estAggregateGrounds.GroundAggregationbyCode = estAggregateGround.Code"}
                              ,
                              new string[] {"estGroundPartition","estground","estGroundPartition.GroundMainCode = estground.Code"}
                              ,
                              new string[] {"estGroundPartition","estGroundPartitions","estGroundPartitions.PartitionCode = estGroundPartition.Code"}
                              ,
                              //--------------------------مجتمع---------------
                              new string[] { "estMarket", "estMarketFloors","estMarket.Code = estMarketFloors.MarketCode"} 
                              ,
                              new string[] {"estMarket","estMarketLocation","estMarketLocation.MarketCode = estMarket.Code"}
                              ,
                              new string[] {"estMarket","estMarketGoodwill","estMarket.Code = estMarketGoodwill.MarketCode"}
                              ,
                              new string[] {"estMarket","estMarketUsage","estMarket.Code = estMarketUsage.MarketCode"}
                              ,
                              new string[] {"estMarketLocation","estGround","estMarketLocation.GroundCode = estGround.Code"}
                              ,
                              new string[] {"estMarket","estUnitBuild","estMarket.Code = estUnitBuild.MarketCode"}
                              ,
                              new string[] {"estPrimaryOwnerBuild","estUnitBuild","estPrimaryOwnerBuild.BuildCode = estUnitBuild.Code"}
                              ,
                              new string[] {"estPrimaryOwnerBuild","clsAllPerson","estPrimaryOwnerBuild.PCode = clsAllPerson.Code"}
                              ,
                              //-----------------------------دادخواست------------------------
                              new string[] {"LegNotice","LegPetition","LegPetition.Code = LegNotice.PetitionCode"}
                              ,
                              new string[] {"LegDecision","LegPetition","LegPetition.Code = LegDecision.PetitionCode"}
                              ,
                              new string[] {"LegExecute","LegDecision","LegExecute.DecisionCode = LegDecision.Code"}
                              ,
                              new string[] {"VlegWinnerExecute","LegExecute","VlegWinnerExecute.ExecutiveCode = LegExecute.Code"}                              
                              ,
                              new string[] {"VlegLoserExecute","LegExecute","VlegLoserExecute.ExecutiveCode = LegExecute.Code"}                              
                              ,                              
                              new string[] {"LegDecisionType","LegDecision","LegDecisionType.DecisionCode = LegDecision.Code"}                              
                              ,
                              new string[] {"VlegComplainantPetition","LegPetition","VlegComplainantPetition.PetitionCode = LegPetition.Code"}                              
                              ,
                              new string[] {"VlegAdComplainantPetition","LegPetition","VlegAdComplainantPetition.PetitionCode = LegPetition.Code"}                              
                              ,
                              new string[] {"VlegFeyPetition","LegPetition","VlegFeyPetition.PetitionCode = LegPetition.Code"}                              
                              ,
                              new string[] {"VlegAdFeyPetition","LegPetition","VlegAdFeyPetition.PetitionCode = LegPetition.Code"}                              
                              ,                              
                              //-----------------------------اظهارنامه--------------------                            
                              new string[] {"LegAssertion","LegAssertionPerson","LegAssertion.Code = LegAssertionPerson.AssertionCode"}
                              ,                              
                              //-----------------------------رستوران--------------------                            
                              new string[] {"ResEmployeeFood","ResFood","ResFood.Code = ResEmployeeFood.FoodCode"}
                              , 
                              new string[] {"ResEmployeeFood","clsAllPerson","clsAllPerson.Code = ResEmployeeFood.EmployeeCode"}
                              , 
                              new string[] {"ResEmployeeFood","Subdefine","Subdefine.Code = ResEmployeeFood.CostCenter"}
                              ,                              
                              new string[] {"ResPersonFood","ResPersonFoodOrder","ResPersonFood.Code = ResPersonFoodOrder.PersonFood"}
                              ,                              
                              new string[] {"ResPersonFoodOrder","ResFood","ResFood.Code = ResPersonFoodOrder.FoodCode"}
                              , 
                              //new string[] {"ResPersonFood","clsAllPerson","clsAllPerson.Code = ResPersonFood.PersonCode"}
                              //,
                              //-----------------------------جلسات--------------------                            
                              new string[] {"MetMeeting","MetLegislation","MetMeeting.Code = metlegislation.MeetingCode"}
                              , 
                              new string[] {"MetMeeting","MetMeetingPersons","MetMeeting.Code = MetMeetingPersons.MeetingCode"}
                              ,                                
                              new string[] {"MetMeeting","MetProgram","MetMeeting.Code = MetProgram.MeetingCode"}
                              ,
                              new string[] {"MetMeetingPersons","clsAllPerson","MetMeetingPersons.PersonCode = clsAllPerson.Code"}
                              ,
                           };

        /// <summary>
        ///SQL گرفتن لیست جداول و ساختن دستورات 
        /// </summary>
        /// <returns></returns>
        public string getSQL()
        {
            try
            {
                string SQL = "";
                ReadControls();
                _ReleationStack.Clear();
                foreach (string BaseTable in _BaseTables)
                    _AddToTablesList(BaseTable);
                if (_Tables.Count > 0)
                {
                    if (Fields != null && Fields.Length>0)
                        SQL = "SELECT distinct " + Fields + " FROM " + _Tables[0];
                    else
                        SQL = "SELECT distinct * FROM " + _Tables[0];
                    for (int i = 1; i < _Tables.Count; i++)
                    {
                        _Stack.Clear();
                        SQL = SQL + (char)13 + " " + CreateJoin(_Tables[i - 1], _Tables[i]);
                    }
                }
                return SQL + (char)13 + " WHERE " + _Where +" AND "+ GetSqlPermisshions()+ " "+ _GroupBy;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }         
        }

        public string getSQL(string pFields, string pTables, string pGroupBy)
        {
            try
            {
                string SQL = "";

                List<string>_Tables = new List<string>();
                foreach (string S in pTables.Split(new char[] { ',' }))
                {
                    _Tables.Add(S);
                }

                if (_Tables.Count > 0)
                {
                    if (pFields != null && pFields.Length > 0)
                        SQL = "SELECT distinct " + pFields + " FROM " + _Tables[0];
                    else
                        SQL = "SELECT distinct * FROM " + _Tables[0];
                    for (int i = 1; i < _Tables.Count; i++)
                    {
                        SQL = SQL + (char)13 + " " + CreateJoin(_Tables[i - 1], _Tables[i]);
                    }
                }
                return SQL + (char)13 + " WHERE 1=1 AND " + GetSqlPermisshions(_Tables) + " " + pGroupBy;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }

        private string GetSqlPermisshions()
        {
            return GetSqlPermisshions(Tables);
        }

        private string GetSqlPermisshions(List<string> Tables)
        {
            try
            {
                string Ret = "";
                foreach (string tab in Tables)
                {
                    string _sql = GetSqlPermisshion(tab);
                    if (_sql.Length > 0)
                    {
                        Ret += _sql + " AND ";
                    }
                }
                return Ret + " 1=1 ";
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }

        private string GetSqlPermisshion(string pTableName)
        {
            string Ret = "";
            if (pTableName == "estMarket")
                Ret = JPermission.getObjectSql("RealEstate.jMarkets.GetDataTable", JTableNamesEstate.Market + ".Code");
            if (pTableName == "LegAdvocacy")
                Ret = JPermission.getObjectSql("Legal.JAdvocacys.GetDataTable", JTableNamesLegal.AdvocacyTable + ".Code");
            if (pTableName == "LegAssertion")
                Ret = JPermission.getObjectSql("Legal.JAssertions.GetDataTable", JTableNamesPetition.Assertion + ".Code");
            if (pTableName == "LegDecision")
                Ret = JPermission.getObjectSql("Legal.JDecisions.GetDataTable", JTableNamesLegal.Decision + ".Code");
            if (pTableName == "LegExecute")
                Ret = JPermission.getObjectSql("Legal.JExecutives.GetDataTable", JTableNamesLegal.Executive + ".Code");
            if (pTableName == "LegNotary")
                Ret = JPermission.getObjectSql("Legal.JNotarys.GetDataTable", JTableNamesLegal.NotaryTable + ".Code");
            if (pTableName == "LegNotary")
                Ret = JPermission.getObjectSql("Legal.JNotarys.GetDataTable", JTableNamesLegal.NotaryTable + ".Code");
            if (pTableName == "LegNotice")
                Ret = JPermission.getObjectSql("Legal.JNotices.GetDataTable", JTableNamesLegal.Notice + ".Code");
            if (pTableName == "LegPetition")
                Ret = JPermission.getObjectSql("Legal.JPetitions.GetDataTable", JTableNamesLegal.Petition + ".Code");
            if (pTableName == "estUnitBuild")
                Ret = JPermission.getObjectSql("RealEstate.JUnitBuilds.GetDataTable", JTableNamesEstate.UnitBuild + ".Code") + " And " + JPermission.getObjectSql("RealEstate.jMarkets.GetDataTable", JTableNamesEstate.UnitBuild + ".MarketCode");
            if (pTableName == "estGroundBreakDown")
                Ret = JPermission.getObjectSql("Estates.JGroundBreakDownAll.GetDataTable", "estGroundBreakDown.Code");
            if (pTableName == "estGroundBreakDown")
                Ret = JPermission.getObjectSql("Estates.JGroundBreakDownAll.GetDataTable", "estGroundBreakDown.Code");
            if (pTableName == "estGroundBreakDown")
                Ret = JPermission.getObjectSql("Estates.JAggregateGroundAll.GetDataTable", "estAggregateGround.Code");
            if (pTableName == "estGroundPartition")
                Ret = JPermission.getObjectSql("Estates.JGroundPartitionAll.GetDataTable", "estGroundPartition.Code");
            if (pTableName == "estLand")
                Ret = JPermission.getObjectSql("Estates.JLands.GetDataTable", JTableNamesEstate.LandTable + ".Code");

            return Ret;
        }

        /// <summary>
        /// ایجاد Join
        /// </summary>
        /// <param name="pTableName1"></param>
        /// <param name="pTableName2"></param>
        /// <returns></returns>
        private string CreateJoin(string pTableName1, string pTableName2)
        {
            pTableName1 = pTableName1.ToLower();
            pTableName2 = pTableName2.ToLower();
            if (pTableName1 == pTableName2) return "";
            try
            {
                string T = "";
                foreach (string[] Join in Joins)
                {
                    Join[0] = Join[0].ToLower();
                    Join[1] = Join[1].ToLower();
                    if (Join[0] == pTableName1 && Join[1] == pTableName2 && !StackFind(_ReleationStack, Join[0] + "-->" + Join[1]))
                    {
                        T = " INNER JOIN " + Join[1] + " ON " + Join[2];
                        _ReleationStack.Add(Join[0] + "-->" + Join[1]);
                        break;
                    }
                    else
                        if (Join[0] == pTableName2 && Join[1] == pTableName1 && !StackFind(_ReleationStack, Join[0] + "-->" + Join[1]))
                        {
                            T = " INNER JOIN " + Join[0] + " ON " + Join[2];
                            _ReleationStack.Add(Join[0] + "-->" + Join[1]);
                            break;
                        }
                }

                if (T.Length == 0)
                {
                    string Temp = "";
                    foreach (string[] Join in Joins)
                    {

                        Join[0] = Join[0].ToLower();
                        Join[1] = Join[1].ToLower();
                        if (pTableName1 == Join[0] && !StackFind(_Stack, pTableName1) && !StackFind(_Stack, Join[1]))
                        {
                            _Stack.Add(pTableName1);
                            Temp = CreateJoin(Join[1], pTableName2);
                            if (Temp.Length > 0)
                            {
                                T = CreateJoin(pTableName1, Join[1]) + (char)13 + " " + Temp;
                                break;
                            }
                            else
                            {
                                _Stack.Remove(pTableName1);
                            }
                        }
                        //else
                        if (pTableName1 == Join[1] && !StackFind(_Stack, pTableName1) && !StackFind(_Stack, Join[0]))
                        {
                            _Stack.Add(pTableName1);
                            Temp = CreateJoin(Join[0], pTableName2);
                            if (Temp.Length > 0)
                            {
                                T = CreateJoin(pTableName1, Join[0]) + (char)13 + " " + Temp;
                                break;
                            }
                            else
                                _Stack.Remove(pTableName1);
                        }
                        //else
                        if (pTableName2 == Join[0] && !StackFind(_Stack, pTableName2) && !StackFind(_Stack, Join[1]))
                        {
                            _Stack.Add(pTableName2);
                            Temp = CreateJoin(pTableName1, Join[1]);
                            if (Temp.Length > 0)
                            {
                                T = Temp + (char)13 + " " + CreateJoin(Join[1], pTableName2);
                                break;
                            }
                            else
                                _Stack.Remove(pTableName2);
                        }
                        // else
                        if (pTableName2 == Join[1] && !StackFind(_Stack, pTableName2) && !StackFind(_Stack, Join[0]))
                        {
                            _Stack.Add(pTableName2);
                            Temp = CreateJoin(pTableName1, Join[0]);
                            if (Temp.Length > 0)
                            {
                                T = Temp + (char)13 + " " + CreateJoin(Join[0], pTableName2);
                                break;
                            }
                            else
                                _Stack.Remove(pTableName2);
                        }
                    }
                }
                return T;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }
        /// <summary>
        /// اضافه کردن جدول
        /// </summary>
        /// <param name="PClassName"></param>
        private  void _AddToTablesList(string PClassName)
        {
            try
            {
                foreach (string Table in _Tables)
                {
                    if (Table.ToLower() == PClassName.ToLower())
                        return;
                }
                _Tables.Add(PClassName);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void AddToTablesList(string PClassName)
        {
            try
            {
                foreach (string Table in _BaseTables)
                {
                    if (Table.ToLower() == PClassName.ToLower())
                        return;
                }
                _BaseTables.Add(PClassName);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void AddToSubReport(JSubReport pSubReport)
        {
            try
            {
                Array.Resize(ref SubReports, SubReports.Length + 1);
                SubReports[SubReports.Length - 1] = pSubReport;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// اجرای دستورات 
        /// </summary>
        public void Run()
        {
            JDataBase Db = new JDataBase();
            //Copy File در فایل sql ریختن
            //System.IO.StreamWriter sWrite;
            //sWrite = System.IO.File.AppendText("C:\\Sql.txt");
            string Query = "";
            try
            {
                foreach (JSubReport SubReport in SubReports)
                {
                    _BaseTables.Clear();
                    _BaseTables.AddRange(SubReport.GetTables());

                    _Fields = SubReport.Fields;
                    _GroupBy = SubReport.GroupBy;

                    Query = getSQL();
                    //Copy File
                    //sWrite.WriteLine(Query);
                    //sWrite.WriteLine("----------------------------");

                    SubReport.DataTable.Clear();
                    Db.setQuery(Query);
                    DataTable tempdt = Db.Query_DataTable();
                    if (tempdt != null)
                        SubReport.DataTable.Merge(tempdt.Copy());
                    else
                        JMessages.Warning("", "");
                }
                //sWrite.Close();
                //sWrite.Close();
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                //sWrite.Close();
                Db.Dispose();
            }
        }

        /// <summary>
        /// اجرای دستورات 
        /// </summary>
        public DataTable RunMultiTab(JSubReport[] pSubReports)
        {
            JDataBase Db = new JDataBase();
            //Copy File در فایل sql ریختن
            System.IO.StreamWriter sWrite;
            sWrite = System.IO.File.AppendText("C:\\Sql.txt");
            string Query = "";
            try
            {
                _BaseTables.Clear();
                _Fields = "";
                foreach (JSubReport SubReport in pSubReports)
                {
                    _BaseTables.AddRange(SubReport.GetTables());
                    if (_Fields.Length > 0)
                        _Fields += ",";
                    _Fields += SubReport.Fields;
                }

                Query = getSQL();
                //Copy File
                sWrite.WriteLine(Query);
                sWrite.WriteLine("----------------------------");

                Db.setQuery(Query);
                DataTable tempdt = Db.Query_DataTable();
                return tempdt;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                sWrite.Close();
                Db.Dispose();
            }
            return null;
        }

        public void ClearTablesList()
        {
            _BaseTables.Clear();
        }

        #endregion

        /// <summary>
        /// نام جداول بانک
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetClassName(string Name)
        {
            try
            {
                string _ClassName = "";
                //-----قرارداد------
                if (Name == "C")
                    _ClassName = JTableNamesLegal.SubjectContract;
                if (Name == "Ch")
                    _ClassName = JTableNamesFinance.Cheques;
                if (Name == "F")
                    _ClassName = JTableNamesFinance.Fish;
                if (Name == "P")
                    _ClassName = JTableNamesFinance.PromissoryNote;
                if (Name == "VS")
                    _ClassName = "VSellerContract";
                if (Name == "VAS")
                    _ClassName = "VAdSellerContract";
                if (Name == "VB")
                    _ClassName = "VBuyerContract";
                if (Name == "VAB")
                    _ClassName = "VAdBuyerContract";
                if (Name == "VI")
                    _ClassName = "VIntuitionContract";

                //-----اعیان------
                if (Name == "B")
                    _ClassName = JTableNamesEstate.UnitBuild;
                if (Name == "POB")
                    _ClassName = JTableNamesEstate.PrimaryOwnerBuild;

                //-----مجتمع------
                if (Name == "M")
                    _ClassName = JTableNamesEstate.Market;
                if (Name == "MU")
                    _ClassName = JTableNamesEstate.MarketUsage;
                if (Name == "ML")
                    _ClassName = JTableNamesEstate.MarketLocation;
                if (Name == "MF")
                    _ClassName = JTableNamesEstate.MarketFloors;
                if (Name == "MG")
                    _ClassName = JTableNamesEstate.Market;

                //-----اموال------
                if (Name == "A")
                    _ClassName = JTableNamesFinance.finAssetTable;
                if (Name == "AS")
                    _ClassName = JTableNamesFinance.finAssetShareTable;
                if (Name == "VNAAS")
                    _ClassName = "VNActiveAssetShare";
                if (Name == "VAAS")
                    _ClassName = "VActiveAssetShare";
                if (Name == "VBAS")
                    _ClassName = "VBlockAssetShare";
                if (Name == "VGAS")
                    _ClassName = "ResPersonFoodOrder";
                if (Name == "VDAS")
                    _ClassName = "ResPersonFoodOrder";
                //-----زمین------
                if (Name == "G")
                    _ClassName = JTableNamesEstate.GroundTable;
                if (Name == "L")
                    _ClassName = JTableNamesEstate.LandTable;
                if (Name == "GBD")
                    _ClassName = JTableNamesEstate.GroundBreakDown;
                if (Name == "POG")
                    _ClassName = JTableNamesEstate.PrimaryOwnerGround;
                if (Name == "GA")
                    _ClassName = JTableNamesEstate.AggregateGround;
                if (Name == "GAB")
                    _ClassName = JTableNamesEstate.AboutTable;

                //-----وکالت------
                if (Name == "AD")
                    _ClassName = JTableNamesLegal.AdvocacyTable;
                if (Name == "AF")
                    _ClassName = JTableNamesLegal.LegAdvocacyFinanceTable;
                if (Name == "LAS")
                    _ClassName = JTableNamesLegal.SubjectTable;
                if (Name == "LA")
                    _ClassName = JTableNamesLegal.AdvocateTable;
                if (Name == "LV")
                    _ClassName = JTableNamesLegal.LegVicariousTable;

                //-----دادخواست------
                if (Name == "LD")
                    _ClassName = JTableNamesLegal.Decision;
                if (Name == "DT")
                    _ClassName = JTableNamesLegal.DecisionType;
                if (Name == "LE")
                    _ClassName = JTableNamesLegal.Executive;
                if (Name == "VWE")
                    _ClassName = "vlegWinnerExecute";
                if (Name == "VLE")
                    _ClassName = "VlegLoserExecute";
                if (Name == "LP")
                    _ClassName = JTableNamesLegal.Petition;
                if (Name == "LN")
                    _ClassName = JTableNamesLegal.Notice;
                if (Name == "LPP")
                    _ClassName = JTableNamesLegal.PersonPetition;
                if (Name == "VCP")
                    _ClassName = "VlegComplainantPetition";
                if (Name == "VACP")
                    _ClassName = "VlegAdComplainantPetition";
                if (Name == "VFP")
                    _ClassName = "VlegFeyPetition";
                if (Name == "VAFP")
                    _ClassName = "VlegAdFeyPetition";

                //-----اظهارنامه------
                if (Name == "LASS")
                    _ClassName = JTableNamesLegal.LegAssertion;
                if (Name == "LASSP")
                    _ClassName = JTableNamesLegal.LegAssertionPerson;

                //---------------رستوران-------------
                if (Name == "ResEM")
                    _ClassName = "ResEmployeeFood";
                if (Name == "ResEmL")
                    _ClassName = "ResEmployeeFoodList";                
                if (Name == "Res")
                    _ClassName = "ResPersonFood";
                if (Name == "ResP")
                    _ClassName = "ResPersonFoodOrder";
                //---------------جلسات-------------
                if (Name == "MetLeg")
                    _ClassName = "MetLegislation";
                if (Name == "MeetPerson")
                    _ClassName = "MetMeetingPersons";
                if (Name == "Meet")
                    _ClassName = "MetMeeting";
                if (Name == "MetProg")
                    _ClassName = "MetProgram";
                
                if (_ClassName.Length > 0)
                    _AddToTablesList(_ClassName);
                return _ClassName;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }

        #region ReadControls
                
        /// <summary>
        ///  SQlخواندن شرط های دستور
        /// </summary>
        public void ReadControls()
        {
            try
            {
                _Tables.Clear();
                _Tables = Tables;
                _Where = "";
                _Where = ReadControls(this, ref _Where);
                _Where = " 1=1 " + _Where;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// خواندن تمامی کنترل ها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        private string ReadControls(object sender, ref string Where)
        {
            try
            {
                string[] str = { "" };
                string StrObj = "";
                Type type = sender.GetType();
                FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
                for (int count = 0; count < Finfo.Length; count++)
                {
                    object Obj = Finfo[count].GetValue(sender);
                    if (Obj is RadioButton)
                    {
                        if (((RadioButton)(Obj)).Checked)
                        {
                            str = ((RadioButton)Obj).Name.Split('1');
                            Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((RadioButton)Obj).Tag;// +" '" + ((RadioButton)Obj).SelectedValue + "'";
                        }
                    }
                    if (Obj is CheckBox)
                    {
                        if (((CheckBox)(Obj)).Checked)
                        {
                            str = ((CheckBox)Obj).Name.Split('1');
                            if (str.Length > 1)
                                Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((CheckBox)Obj).Tag + "1";
                        }
                        //else
                        //{
                        //    str = ((CheckBox)Obj).Name.Split('1');
                        //    if (str.Length > 1)
                        //        Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((CheckBox)Obj).Tag + "0";
                        //}
                    }
                    if (Obj is CheckedListBox)
                    {
                        string value = "";
                        for (int i = 0; i < ((CheckedListBox)Obj).Items.Count; i++)                        
                            if (((CheckedListBox)Obj).GetItemChecked(i))
                            {
                                str = ((CheckedListBox)Obj).Name.Split('1');
                                value = value +  (Convert.ToInt32(((ClassLibrary.JKeyValue)((CheckedListBox)Obj).Items[i]).Value)).ToString() + ",";
                            }
                        if (value != "")
                            Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + " " + ((CheckedListBox)Obj).Tag + " (" + value+ "-1)";
                    }
                    if (Obj is UserControl)
                    {
                        StrObj = Obj.ToString();
                        ReadControls(Obj,ref Where);
                    }
                    if ((Obj is TextEdit) && (((TextEdit)Obj).Text != "") && ((TextEdit)Obj).Text != "0")
                    {
                        if ((((TextEdit)Obj).Parent.Parent.Parent is UserControl) && (String.Compare(((TextEdit)Obj).Parent.Parent.Parent.ToString(), "ClassLibrary.JReport") != 0))
                            str = ((TextEdit)Obj).Parent.Parent.Parent.Name.Split('1');
                        else
                            str = ((TextEdit)Obj).Name.Split('1');
                        if ((((TextEdit)Obj).Tag == "Like")&&(str.Length > 1))
                            Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + " " +  ((TextEdit)Obj).Tag + " '%" + ((TextEdit)Obj).Text + "%'";
                        else if (str.Length > 1)
                           Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((TextEdit)Obj).Tag + " '" + ((TextEdit)Obj).Text + "'";
                    }
                    if (Obj is ComboBox)
                    {// && Convert.ToInt32(((ComboBox)Obj).SelectedValue) > 0) )
                        if (((ComboBox)Obj).SelectedValue != null && Convert.ToInt32(((ComboBox)Obj).SelectedValue) != -1)
                        {
                            str = ((ComboBox)Obj).Name.Split('1');
                            if (str.Length > 1)
                                Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((ComboBox)Obj).Tag + " '" + ((ComboBox)Obj).SelectedValue + "'";
                        }
                        else if(((ComboBox)Obj).SelectedValue == null && ((ComboBox)Obj).SelectedItem != null)
                        {
                            if (((ComboBox)Obj).SelectedItem.ToString() != "-----------")
                            //if (((ClassLibrary.JSubBaseDefine)(((ComboBox)Obj).SelectedItem)).Code != -1)
                            {
                                str = ((ComboBox)Obj).Name.Split('1');
                                if (str.Length > 1)
                                    Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((ComboBox)Obj).Tag + " '" + (Convert.ToInt32(((ComboBox)Obj).SelectedValue)).ToString() + "'";
                            }
                        }
                    }
                    if ((Obj is DateEdit) && (((DateEdit)Obj).Date != DateTime.MinValue))
                    {
                        str = ((DateEdit)Obj).Name.Split('1');
                        if (str.Length > 1)
                            Where = Where + " And " + GetClassName(str[0]) + "." + str[1].Replace("2", "") + ((DateEdit)Obj).Tag + " '" + ((DateEdit)Obj).StringDate + "'";
                    }
                    if ((Obj != null) && !(Obj is TextBox) && !(Obj is ComboBox) && !(Obj is MaskedTextBox))
                    {
                        
                    }
                }
                return Where;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }

   #endregion

        #region ClearControl

        /// <summary>
        /// خالی کردن کنترل ها
        /// </summary>
        public void ClearControl(bool Flag)
        {            
            if (Flag)
                ClearControl(this);//تمام کنترل ها را پاک کند
            else
                ClearTabControl(this);//کنترل تب جاری را پاک کند
        }
        /// <summary>
        /// خالی کردن کنترل ها
        /// </summary>
        /// <param name="sender"></param>
        public void ClearControl(object sender)
        {
            try
            {
                Type type = sender.GetType();
                FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
                for (int count = 0; count < Finfo.Length; count++)
                {
                    object Obj = Finfo[count].GetValue(sender);
                    if (Obj is DataGridView)
                    {
                    }
                    //--------------------------------------------
                    if (Obj is UserControl)
                    {
                        ClearControl(Obj);
                    }
                    if ((Obj is TextEdit) && (((TextEdit)Obj).Text != ""))
                    {
                        ((TextEdit)Obj).Text = "";
                    }
                    if (Obj is ComboBox)
                    {
                        if (((ComboBox)Obj).SelectedValue != null && Convert.ToInt32(((ComboBox)Obj).SelectedValue) != -1)
                            ((ComboBox)Obj).SelectedValue = -1;
                        else if (((ComboBox)Obj).SelectedValue == null && ((ComboBox)Obj).SelectedItem != null)
                        {
                            if ((Convert.ToInt32(((ComboBox)Obj).SelectedValue)) != -1)
                                (((ComboBox)Obj).SelectedValue) = -1;
                        }
                    }
                    if ((Obj is DateEdit) && (((DateEdit)Obj).Date != DateTime.MinValue))
                    {
                        ((DateEdit)Obj).Text = "";
                    }

                    if (Obj is CheckedListBox)
                    {
                        for (int i = 0; i < ((CheckedListBox)Obj).Items.Count; i++)
                            if (((CheckedListBox)Obj).GetItemChecked(i))
                                ((ClassLibrary.JKeyValue)((CheckedListBox)Obj).Items[i]).Value = false;
                    }

                    if ((Obj != null) && !(Obj is TextBox) && !(Obj is ComboBox) && !(Obj is MaskedTextBox))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// خالی کردن کنترل ها
        /// </summary>
        /// <param name="sender"></param>
        public void ClearTabControl(object sender)
        {
            try
            {
                Type type = sender.GetType();
                FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
                for (int count = 0; count < Finfo.Length; count++)
                {
                    object Obj = Finfo[count].GetValue(sender);                    
                    if (Obj is UserControl)
                    {
                        ClearControl(Obj);
                    }
                    if ((Obj is TextEdit) && (((TextEdit)Obj).Text != ""))
                    {
                        if ((((TextEdit)Obj).Parent.Name == tabControl1.SelectedTab.Name) || ((((TextEdit)Obj).Parent.Parent != null) && ((TextEdit)Obj).Parent.Parent.Name == tabControl1.SelectedTab.Name))
                            ((TextEdit)Obj).Text = "";
                    }
                    if (Obj is ComboBox)
                    {
                        if ((((ComboBox)Obj).Parent.Name == tabControl1.SelectedTab.Name) || ((((ComboBox)Obj).Parent.Parent != null) && ((ComboBox)Obj).Parent.Parent.Name == tabControl1.SelectedTab.Name))
                        {
                            if (((ComboBox)Obj).SelectedValue != null && Convert.ToInt32(((ComboBox)Obj).SelectedValue) != -1)
                                ((ComboBox)Obj).SelectedValue = -1;
                            else if (((ComboBox)Obj).SelectedValue == null && ((ComboBox)Obj).SelectedItem != null)
                            {
                                if ((Convert.ToInt32(((ComboBox)Obj).SelectedValue)) != -1)
                                    ((ComboBox)Obj).SelectedValue = -1;
                            }
                        }
                    }
                    if ((Obj is DateEdit) && (((DateEdit)Obj).Date != DateTime.MinValue))
                    {
                        if ((((DateEdit)Obj).Parent.Name == tabControl1.SelectedTab.Name) || ((((DateEdit)Obj).Parent.Parent != null) && ((DateEdit)Obj).Parent.Parent.Name == tabControl1.SelectedTab.Name))
                            ((DateEdit)Obj).Text = "";
                    }

                    if (Obj is CheckedListBox)
                    {
                        if ((((CheckedListBox)Obj).Parent.Name == tabControl1.SelectedTab.Name) || ((((CheckedListBox)Obj).Parent.Parent != null) && ((CheckedListBox)Obj).Parent.Parent.Name == tabControl1.SelectedTab.Name))
                        for (int i = 0; i < ((CheckedListBox)Obj).Items.Count; i++)
                            if (((CheckedListBox)Obj).GetItemChecked(i))
                                ((ClassLibrary.JKeyValue)((CheckedListBox)Obj).Items[i]).Value=false;
                    }

                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
  #endregion

        #endregion

        #region Events

        private void JReport_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            FillData();
        }

        private void JReport_VisibleChanged(object sender, EventArgs e)
        {
            B1MarketCode.SelectedValue = -1;
            MU1UsageCode.SelectedValue = -1;
            G1Usage.SelectedValue = -1;
            G1Land.SelectedValue = -1;
            C1Location.SelectedValue = -1;
            C1Type.SelectedValue = -1;
        }

        private void B1MarketCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //نمایش طبقات مجتمع بر اساس مجتمع انتخاب شده
                int CodeMarket = Convert.ToInt32(B1MarketCode.SelectedValue);
                RealEstate.jMarketFloors Floor = new RealEstate.jMarketFloors();
                DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

                B1FloorCode.DataSource = TableFloor;
                B1FloorCode.DisplayMember = RealEstate.estMarketFloors.Name.ToString();
                B1FloorCode.ValueMember = RealEstate.estMarketFloors.Code.ToString();
                B1FloorCode.Text = "";
                B1FloorCode.SelectedItem = null;

                //نمایش کاربری های  مجتمع بر اساس مجتمع انتخاب شده
                RealEstate.jMarketUsage Usage = new RealEstate.jMarketUsage();
                DataTable UsageTable = Usage.GetDataByMarketCode(CodeMarket);
                B1UsageCode.DataSource = UsageTable;
                B1UsageCode.DisplayMember = "Name";
                B1UsageCode.ValueMember = RealEstate.estMarketUsage.Code.ToString();
                B1UsageCode.Text = "";
                B1UsageCode.SelectedItem = null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        } 
        
        #region تجمیع زمین
               
        /// <summary>
        /// تجمیع زمین
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAgregatedGrands_Click(object sender, EventArgs e)
        {
            try
            {
                JSearchGroundForm JSGF = new JSearchGroundForm();
                JAggregateGround JAG = new JAggregateGround();
                if (JSGF.ShowDialog() == DialogResult.OK)
                {
                    if (JAG.FindGroundAggregate(JSGF.Code))
                    {
                        JMessages.Error("این زمین قبلا انتخاب شده است", "error");
                        return;
                    }

                    //چک کردن برابر بودن مالکین اولیه و سهام آن ها برای تجمیع
                    if (!JAG.CheckSharePrimaryOwner(JSGF.Code))
                        return;
                    //
                    JGround Newground = new JGround(JSGF.Code);
                    DataRow Row = JAG.GroundsAggregationby.NewRow();
                    Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()] = Newground.Code;
                    Row[JGroundTableEnum.MainAve.ToString()] = Newground.MainAve;
                    Row[JGroundTableEnum.SubNo.ToString()] = Newground.SubNo;
                    Row[JGroundTableEnum.Area.ToString()] = Newground.Area;
                    //محاسبه مساحت زمین جدید
                    //double Area = 0;
                    //Area = JAG.GroundAggregationby.Area;
                    //CountGrounds++;
                    //Area += Newground.Area;
                    //JAG.GroundAggregationby.Area = Area;
                    //JAG.GroundsAggregationby.Rows.Add(Row);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelAgregatedGrands_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroundsAggregationby.Rows.Count == 0)
                    return;
                if (dgvGroundsAggregationby.SelectedRows.Count == 0)
                {
                    JMessages.Error("یک زمین برای حذف انتخاب کنید", "خطا");
                    return;
                }
                dgvGroundsAggregationby.Rows.RemoveAt(dgvGroundsAggregationby.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        private void btmSearchGround_Click(object sender, EventArgs e)
        {
            try
            {
                Finance.JAssetSearchForm p = new Finance.JAssetSearchForm();
                if (p.ShowDialog() != DialogResult.OK)
                    return;
                Finance.JAsset tmp = new Finance.JAsset(p._Code);                
                if (tmp.Code > 0)
                    A1Code.Text = tmp.Code.ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion

        private void AS1PCode_Load(object sender, EventArgs e)
        {

        }

    }

    #region Enum
        
    /// <summary>
    /// انواع رای
    /// </summary>
    public enum DecisionType
    {
        /// <summary>
        /// فسخ
        /// </summary>
        revoke = 1,
        /// <summary>
        /// گواهی حصرووراثت
        /// </summary>
        inheritance = 2,
        /// <summary>
        /// توقیف/رد توقیف
        /// </summary>
        Lockup = 3,
        /// <summary>
        /// الزام به پرداخت وجه:
        /// </summary>
        Pay = 4,
        /// <summary>
        /// الزام تنظیم سند
        /// </summary>
        document = 5,
        /// <summary>
        /// سایرموارد
        /// </summary>
        Other = 6,
        /// <summary>
        /// الزام به انجام تعهد
        /// </summary>
        guarantee = 7,
        /// <summary>
        /// قرار
        /// </summary>
        agreement = 8,
    }


    public enum ContractType
    {
        /// <summary>
        /// انتقال قطعی -  -  -  -  -  -  -  - - 
        /// </summary>
        Definitive_transfer = 1,
        /// <summary>
        /// اجاره صلح سرقفلی
        /// </summary>
        rent_locks_for_peace = 2,
        /// <summary>
        /// مشارکت
        /// </summary>
        Contribute = 3,
        /// <summary>
        /// اجاره
        /// </summary>
        Rental = 4,
        /// <summary>
        /// مشاعات
        /// </summary>
        Condominium = 5,
        /// <summary>
        /// پیمانکاران
        /// </summary>
        Contractors = 6,
        /// <summary>
        /// انبارداری
        /// </summary>
        Storage = 7,
        /// <summary>
        /// پرسنلی
        /// </summary>
        personnel = 8,
        /// <summary>
        /// تعهد با ساخت
        /// </summary>
        making_a_commitment = 9,
        /// <summary>
        /// غیره
        /// </summary>
        etc = 10,
    }

        /// <summary>
    /// وضعیت قرارداد
    /// </summary>
    public enum JContractStatus
    {
        None=0,
         /// <summary>
         /// جاری
         /// </summary>
        CurrentContract = 1,
        /// <summary>
        /// اتمام
        /// </summary>
        ExpiredContract = 2,
        /// <summary>
        /// فسخ شده
        /// </summary>
        CanceledContract = 3,
        /// <summary>
        /// غبر فعال
        /// </summary>
        Disabled=4,
    }

    #endregion

}
