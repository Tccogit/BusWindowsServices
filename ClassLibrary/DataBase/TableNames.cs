using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	/// <summary>
	///ClassLibrary جداول پروژه 
	/// </summary>
	public class JTableNamesClassLibrary : JBase
	{
		/// <summary>
		/// جدول اشخاص
		/// clsPerson
		/// </summary>
		public static string ConnectionsTable = "clsConnections";
		/// <summary>
		/// جدول اشخاص
		/// clsPerson
		/// </summary>
		public static string PersonTable = "clsPerson";
		/// <summary>
		/// اشخاص حقوقی
		/// </summary>
		public static string LegalPerson = "Organization";
		/// <summary>
		/// اشخاص متفرقه
		/// </summary>
		public static string OtherPerson = "clsOtherPerson";
		/// <summary>
		/// جدول صاحبان امضاء شرکت
		/// </summary>
		public static string SignatureMen = "clsSignatureMen";
		/// <summary>
		/// جدول آدرس آشخاص
		/// </summary>
		public static string PersonAddress = "clsPersonAddress";
		/// <summary>
		/// users
		/// </summary>
		public static string UsersTable = "users";
		/// <summary>
		/// History
		/// </summary>
		public static string History = "clsHistory";
		/// <summary>
		/// همه اشخاص حقیقی و حقوقی
		/// </summary>
		public static string AllPerson = "clsAllPerson";
		/// <summary>
		/// گواهی فوت
		/// </summary>
		public static string DeadPerson = "clsDeadPerson";
		/// <summary>
		/// تعاریف اولیه
		/// </summary>
		public static string SubBaseDefine = "subdefine";
		/// <summary>
		/// تاریخ های استاتیک
		/// </summary>
		public static string StaticDates = "StaticDates";
		/// <summary>
		/// ارتباطات کلاسها
		/// </summary>
		public static string Relation = "ClsRelation";
		/// <summary>
		/// تنظیمات چاپ
		/// </summary>
		public static string ClsSettingPrint = "ClsSettingPrint";
	}

	/// <summary>
	///جداول پروژه اتوماسیون  
	/// </summary>
	public class JTableNamesAutomation : JBase
	{
		/// <summary>
		/// جدول ارجاع
		/// </summary>
		public static string Refer = "Refer";
		/// <summary>
		/// جدول اشیا
		/// </summary>
		public static string Objects = "Objects";
		/// <summary>
		/// جدول کار/ وظیفه
		/// </summary>
		public static string Tasks = "Tasks";
		/// <summary>
		/// کارتابل
		/// </summary>
		public static string Folders = "Folders";
		public static string ReferFolders = "ReferFolders";
		/// <summary>
		/// شرط کارتابل
		/// </summary>
		public static string ExternalRefer = "ExternalRefer";
		/// <summary>
		/// اقدامی
		/// </summary>
		public static string Emprise = "Emprise";
	}

	/// <summary>
	///جداول پروژه مجوزها  
	/// </summary>
	public class JTableNamesPermission : JBase
	{
		/// <summary>
		/// جدول مجوزهای کاربر
		/// </summary>
		public static string PermissionUser = "PermissionUser";
		/// <summary>
		/// جدول کلاس
		/// </summary>
		public static string PermissionDefineClass = "PermissionDefineClass";
		/// <summary>
		/// جدول تصمیمات
		/// </summary>
		public static string PermissionDecision = "PermissionDecision";
		/// <summary>
		/// جدول کنترل ها
		/// </summary>
		public static string PermissionControl = "PermissionControl";
		/// <summary>
		/// جدول مجوزهای کاربر جانشین
		/// </summary>
		public static string PermissionUserSuccessor = "PermissionUserSuccessor";
		/// <summary>
		/// جدول تعریف گروه ها
		/// </summary>
		public static string PermissionDefineGroup = "PermissionDefineGroup";

		public static string PermissionDefineGroupClass = "PermissionDefineGroupClass";
		/// <summary>
		/// جدول مجوزهای گروه
		/// </summary>
		public static string PermissionGroup = "PermissionGroup";
		/// <summary>
		/// جدول کاربران هر گروه
		/// </summary>
		public static string PermissionGroupUsers = "PermissionGroupUsers";
		public static string PermissionDecisionGroup = "PermissionGroupDecision";
	}

	/// <summary>
	///جداول پروژه نامه ها  
	/// </summary>
	public class JTableNamesLetters : JBase
	{
		/// <summary>
		/// جدول نامه
		/// </summary>
		public static string Letters = "Letters";
		/// <summary>
		/// جدول کلاس
		/// </summary>
		public static string LetterCopy = "LetterCopy";
		/// <summary>
		/// جدول ضمائم
		/// </summary>
		public static string Letterattachments = "Letterattachments";
		/// <summary>
		/// جدول فایل ضمائم
		/// </summary>
		public static string Letterattachmentfile = "Letterattachmentfile";
		/// <summary>
		/// جدول عطف 
		/// </summary>
		public static string LetterDependent = "LetterDependent";
		/// <summary>
		/// جدول اطلاعات دبیرخانه نامه ها 
		/// </summary>
		public static string secretariatLetters = "secretariatLetters";

	}

	/// <summary>
	///جداول پروژه کارمندان سازمان  
	/// </summary>
	public class JTableNamesEmployment : JBase
	{
		/// <summary>
		/// چارت سازمانی
		/// </summary>
		public static string OrganizationChart = "OrganizationChart";
		/// <summary>
		/// چارت سازمانی
		/// </summary>
		public static string Charts = "Charts";

	}

	/// <summary>
	/// جداول پروژه املاک
	/// </summary>
	public class JTableNamesEstate : JBase
	{
		public static string LandTable = "estLand";
		public static string GroundTable = "estGround";
		public static string GroundUsageTable = "estUsageGround";
		public static string AboutTable = "estAboute";
		public static string GroundHistory = "estGroundHistory";
		public static string PrimaryOwnerGround = "estPrimaryOwnerGround";

		public static string AggregateGround = "estAggregateGround";
		public static string AggregateGrounds = "estAggregateGrounds";
		public static string GroundBreakDown = "estGroundBreakDown";
		public static string GroundsBreakDown = "estGroundsBreakDown";
		public static string GroundPartition = "estGroundPartition";
		public static string GroundPartitions = "estGroundPartitions";

		public static string Market = "estMarket";
		public static string MarketLocation = "estMarketLocation";
		public static string MarketUsage = "estMarketUsage";
		public static string MarketFloors = "estMarketFloors";
		public static string MarketFaz = "estMarketFaz";

		public static string UnitBuild = "estUnitBuild";
		/// <summary>
		/// مالکین اولیه اعیان
		/// </summary>
		public static string PrimaryOwnerBuild = "estPrimaryOwnerBuild";

	}

	/// <summary>
	/// جداول پروژه آرشیو
	/// </summary>
	public class JTableNameArchive : JBase
	{
		public static string ContentTable = "ArchiveContent";
		public static string ArchiveTable = "ArchiveInterface";
	}
	/// <summary>
	/// جداول پروژه حقوقی
	/// </summary>
	public class JTableNamesLegal : JBase
	{
		public static string AdvocacyTable = "legAdvocacy";
		public static string SubjectTable = "legSubject";
		public static string AdvocateTable = "LegAdvocate";
		public static string LegNotaryLetterTable = "LegNotaryLetter";
		public static string LegVicariousTable = "LegVicarious";
		public static string LegAdvocacyFinanceTable = "LegAdvocacyFinance";

		public static string NotaryTable = "legNotary";
		public static string JudicialComplex = "legJudicialComplex";
		public static string JudicialBranch = "legJudicialBranch";

		public static string LegAssertion = "LegAssertion";
		public static string LegAssertionPerson = "LegAssertionPerson";

		/// <summary>
		/// جدول انحصاروراثت
		/// </summary>
		public static string Probate = "legProbate";
		public static string ProbateInheritance = "legProbateInheritance";

		/// <summary>
		/// جداول دادگاه
		/// </summary>
		public static string Petition = "LegPetition";
		public static string PersonPetition = "LegPersonPetition";
		public static string Notice = "LegNotice";
		public static string Distraint = "LegDistraint";
		public static string Decision = "LegDecision";
		public static string DecisionType = "LegDecisionType";
		public static string Executive = "LegExecute";
		public static string PersonExecute = "LegPersonExecute";
		public static string DistraintAssetShare = "LegDistraintAssetShare";

		/// <summary>
		/// قراردادها
		/// </summary>
		public static string SubjectContract = "LegSubjectContract";
		public static string PersonContract = "LegPersonContract";
		public static string DocumentContract = "LegDocumentContract";
		public static string ContractType = "LegContractType";
	}

	/// <summary>
	/// جداول پروژه سهام
	/// </summary>
	public class JTableNamesShares : JBase
	{
		/// <summary>
		/// سهامداران در جدول نرم افزار سهام 
		/// </summary>
		public static string OtherPerson = JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + JGlobal.MainFrame.GetConfig().PersonSahamTableName;//  ".General.OtherPerson";
		/// <summary>
		/// جدول شهرها در نرم افزار سهام 
		/// </summary>
		public static string ShareCities = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.Cities";

		public static string VarPropertyPerson = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.VarPropertyPerson";

		public static string VarProperty = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.VarProperty";

		public static string StaticPropertyPerson = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.PersonProperty";

		public static string PropertyTitle = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.PropertyTitle";

		public static string Properties = JGlobal.MainFrame.GetConfig().DatabaseSaham + ".General.Properties";

	}
	/// <summary>
	/// جداول پروژه مالی
	/// </summary>
	public class JTableNamesFinance : JBase
	{
		/// <summary>
		/// جدول دارائی
		/// </summary>
		public static string finAssetTable = "finAsset";
		/// <summary>
		/// جدول مالکین دارائی
		/// </summary>
		public static string finAssetShareTable = "finAssetShare";
		/// <summary>
		/// سفته
		/// </summary>
		public static string PromissoryNote = "FinPromissoryNote";
		/// <summary>
		/// فیش
		/// </summary>
		public static string Fish = "FinFish";
		/// <summary>
		/// چک
		/// </summary>
		public static string Cheques = "finCheques";

	}
	/// <summary>
	/// جداول پروژه پرداخت سود
	/// </summary>
	public class JTableNamesShareProfit : JBase
	{
		/// <summary>
		/// جدول دوره های پرداخت سود سهام
		/// </summary>
		public static string Cources = "sahamcourse";
		/// <summary>
		/// اسناد پرداخت سود سهام
		/// </summary>
		public static string Documents = "sahamdocument";


	}

	public class JTableNamesReport
	{
		public static string Report = "Report";
		public static string SubReport = "SubReport";
	}

	public class JTableNamesCMS : JBase
	{
		public static string CMSModules = "CMSModules";
		public static string CMSTemplateStyles = "CMSTemplateStyles";
		public static string CMSSites = "CMSSites";
		public static string CMSExtensions = "CMSExtensions";
		public static string CMSCategories = "CMSCategories";
		public static string CMSContents = "CMSContents";
		public static string CMSStatus = "CMSStatus";
		public static string CMSSiteTemplates = "CMSSiteTemplates";
	}
}
