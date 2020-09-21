using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ClassLibrary.Domains
{
    /// <summary>
    /// 
    /// </summary>
    public class JDomain
    {
        //public static JAutomation Automation = new JAutomation();
        //public static JCommunication Communication = new JCommunication();
        /// <summary>
        /// لیست را بصورت جدول بر می گرداند
        /// </summary>
        /// <param name="pType"></param>
        /// <returns></returns>
        public DataTable GetDomin(string pType)
        {
            //JDataBase db = new JDataBase();
			//DataTable dt = new DataTable();
			//try
			//{
			//	db.setQuery("SELECT  ap.Name,ap.Code as value,d.text as FarsiName  FROM Applications ap " +
			//				" inner join dic d  ON d.name=ap.Name "+
			//				" UNION ALL "+
			//				" SELECT wap.Name,wap.Code+1000 as value,d.text as FarsiName FROM WebApplications wap " +
			//				"left join dic d ON d.name=wap.Name  ");
			//	dt = db.Query_DataTable();
			//}
			//catch (Exception ex)
			//{
			//	JSystem.Except.AddException(ex);
			//}

			//return dt;


			DataTable dt = new DataTable();
			try
			{
				dt.Columns.Add("name", typeof(string));
				dt.Columns.Add("value", typeof(string));
				dt.Columns.Add("FarsiName", typeof(string));
				Assembly asm = Assembly.Load("ClassLibrary");
				Type type = asm.GetType("ClassLibrary.Domains." + pType);
				FieldInfo[] fInfo = type.GetFields();
				foreach (var inf in fInfo)
				{
					DataRow dr = dt.NewRow();
					dr["name"] = inf.Name.ToString();
					dr["value"] = inf.GetValue(inf.Name);
					dr["FarsiName"] = JLanguages._Text(inf.Name.ToString());
					dt.Rows.InsertAt(dr, 0);
				}
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
			}
			return dt;
        }

    }
    /// <summary>
    /// عمومی
    /// </summary>
    public static class JGlobal
    {

        /// <summary>
        /// انواع خصوصیات 
        /// </summary>
        public class JPropertyType
        {
            /// <summary>
            /// ویژگی تعرفه زمین
            /// </summary>
            public static int SheetGround = 10;
            /// <summary>
            ///  ویژگی پرسنل
            /// </summary>
            public static int Employment = 11;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JPropertyType");
            }
        }

        /// <summary>
        /// انواع وسیله ارسال SMS
        /// </summary>
        public class JSMSDeviceType
        {
            /// <summary>
            /// 
            /// </summary>
            public static int GSMModem = 1;
            /// <summary>
            ///  
            /// </summary>
            public static int WebService = 2;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JSMSDeviceType");
            }
        }

        /// <summary>
        /// نسبت
        /// </summary>
        public class JFamily
        {
            /// <summary>
            /// همسر
            /// </summary>
            public static int Spouse = 1;
            /// <summary>
            ///  پسر
            /// </summary>
            public static int Boy = 2;
            /// <summary>
            /// دختر
            /// </summary>
            public static int Dogther = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JFamily");
            }
        }
        /// <summary>
        /// انواع وضعیت مصوبه
        /// </summary>
        public class JStatus
        {
            /// <summary>
            /// اقدام شده
            /// </summary>
            public static int Action = 1;
            /// <summary>
            ///  اقدام نشده
            /// </summary>
            public static int NoAction = 2;
            /// <summary>
            /// در دست اقدام
            /// </summary>
            public static int Ongoing = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JStatus");
            }
        }
        /// <summary>
        /// انواع محرمانگی
        /// </summary>
        public class JPrivacy
        {
            /// <summary>
            /// عادی
            /// </summary>
            public static int Normal = 1;
            /// <summary>
            ///  محرمانه
            /// </summary>
            public static int Secure = 2;
            /// <summary>
            /// سری
            /// </summary>
            public static int VerySecure = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JPrivacy");
            }
        }
        /// <summary>
        /// انواع وضعیت درخواست آرشیو
        /// </summary>
        public class JStatusArchive
        {
            /// <summary>
            /// عادی
            /// </summary>
            public static int Request = 1;
            /// <summary>
            ///  محرمانه
            /// </summary>
            public static int Confirm = 2;
            /// <summary>
            /// سری
            /// </summary>
            public static int NotConfirm = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JStatusArchive");
            }
        }
        /// <summary>
        /// انواع تلفن
        /// </summary>
        public class JTelType
        {
            /// <summary>
            /// ثابت
            /// </summary>
            public static int Tel = 1;
            /// <summary>
            ///  همراه
            /// </summary>
            public static int Mobile = 2;
            /// <summary>
            /// منزل
            /// </summary>
            public static int Home = 3;
            /// <summary>
            /// محل کار
            /// </summary>
            public static int Work = 4;
            /// <summary>
            /// ضروری
            /// </summary>
            public static int Necessary = 5;
            /// <summary>
            /// فاکس
            /// </summary>
            public static int Fax = 6;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JTelType");
            }
        }

        /// <summary>
        /// انواع فوریت
        /// </summary>
        public class JUrgency
        {
            /// <summary>
            /// عادی
            /// </summary>
            public static int Normal = 1;
            /// <summary>
            ///  سریع
            /// </summary>
            public static int Quick = 2;
            /// <summary>
            /// خیلی سریع
            /// </summary>
            public static int VeryQuick = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JUrgency");
            }
        }
        /// <summary>
        /// انواع چارت
        /// </summary>
        public class JCharttype
        {
            /// <summary>
            /// چارت داخل سازمان  
            /// </summary>
            public static int Internal = 1;
            /// <summary>
            ///  چارت خارج سازمان
            /// </summary>
            public static int External = 2;            

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JCharttype");
            }
        }
        /// <summary>
        /// انواع وضعیت فرم
        /// </summary>
        public class JfrmState
        {
            /// <summary>
            /// عادی
            /// </summary>
            public static int Normal = 1;
            /// <summary>
            ///  دبیرخانه
            /// </summary>
            public static int secretariat = 2;
            /// <summary>
            ///  واگذاری
            /// </summary>
            public static int transfer = 3;
            /// <summary>
            ///  تایید
            /// </summary>
            public static int Confirm = 4;
            /// <summary>
            ///  ارجاع
            /// </summary>
            public static int Refer = 5;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JGlobal+JUrgency");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class JCommunication
    {
        /// <summary>
        /// انواع روش ارسال
        /// </summary>
        public class JSendType
        {
            /// <summary>
            ///  اتوماسیون
            /// </summary>
            public static int Automation = 1;
            /// <summary>
            /// پست الکترونیک
            /// </summary>
            public static int Email = 2;
            /// <summary>
            ///  ارسال به سرور
            /// </summary>
            public static int Server = 3;
            /// <summary>
            ///  فکس
            /// </summary>
            public static int Fax = 4;
            /// <summary>
            ///  پیک
            /// </summary>
            public static int Messenger = 5;
            /// <summary>
            ///  اس ام اس
            /// </summary>
            public static int SMS = 6;
            /// <summary>
            ///  ECE
            /// </summary>
            public static int ECE = 7;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JCommunication+JSendType");
            }
        }

        /// <summary>
        /// انواع فایل الگو
        /// </summary>
        public class JPatternFileType
        {
            /// <summary>
            ///  عمومی
            /// </summary>
            public static int General = 1;
            /// <summary>
            /// شخصی
            /// </summary>
            public static int Personal = 2;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JCommunication+JPatternFileType");
            }
        }
        /// <summary>
        /// انواع فایل  
        /// </summary>
        public static class JFileType
        {
            /// <summary>
            /// فایل ورد
            /// </summary>
            public static int word = 0;
            /// <summary>
            /// تصویر
            /// </summary>
            public static int image = 1;
            /// <summary>
            /// سایر فایل ها - از لیست
            /// </summary>
            /// <returns></returns>
            public static int other = 2;
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JCommunication+JFileType");
            }
        }

        /// <summary>
        /// انواع نامه
        /// </summary>
        public class JLetterType
        {
            /// <summary>
            ///  وارده
            /// </summary>
            public static int Import = 1;
            /// <summary>
            /// صادره
            /// </summary>
            public static int Export = 2;
            /// <summary>
            /// درون سازمانی
            /// </summary>
            public static int Internal = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JCommunication+JLetterType");
            }
        }

        /// <summary>
        /// انواع وضعیت نامه
        /// </summary>
        public class JLetterStatus
        {
            /// <summary>
            ///  پیشنویس
            /// </summary>
            public static int Minute = 1;
            /// <summary>
            ///  نامه
            /// </summary>
            public static int Letter = 2;
            /// <summary>
            ///  همگی حالات
            /// </summary>
            public static int All = 3;
            /// <summary>
            ///  بایگانی
            /// </summary>
            public static int Archive = 4;
            /// <summary>
            ///  امضا شده
            /// </summary>
            public static int Accept = 5;
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JCommunication+JLetterStatuse");
            }
        }       
    }
    /// <summary>
    /// 
    /// </summary>
    public static class JClassLibrary
    {
        /// <summary>
        /// انواع SMS
        /// </summary>
        public class JSMSType
        {
            public static int SendSMS = 0;
            public static int RecievedSMS = 1;
        }
        /// <summary>
        /// وضعیت SMS
        /// </summary>
        public class JSMSStatus
        {
            public static int NotSend = 0;
            public static int Sent = 1;
        }
        /// <summary>
        /// انواع مجوز اتصال به سرور
        /// </summary>
        public class JAuthenticationType
        {
            /// <summary>
            /// ویندوز
            /// </summary>
            public static int Windows = 1;
            /// <summary>
            ///  اس کیو ال
            /// </summary>
            public static int SQL = 2;
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JClassLibrary+JAuthenticationType");
            }
        }
        /// <summary>
        /// وضعیت EMail
        /// </summary>
        public class JEMailStatus
        {
            public static int Draft = 0;
            public static int ReadyForSend = 1;
            public static int Sent = 2;
            public static int SendError = 10;
        }
    }

    /// <summary>
    /// کلاس مجوزها
    /// </summary>
    public static class JPermission
    {
        /// <summary>
        /// انواع مجوز اتصال به فرم
        /// </summary>
        public class JPermissionEvents
        {
            /// <summary>
            /// درج
            /// </summary>
            public static int Insert = 1;
            /// <summary>
            ///  ویرایش
            /// </summary>
            public static int Edit = 2;
            /// <summary>
            ///  حذف
            /// </summary>
            public static int Del = 3;
            /// <summary>
            ///  مشاهده
            /// </summary>
            public static int View = 4;
            /// <summary>
            ///  نمایش
            /// </summary>
            public static int Visible = 5;
            /// <summary>
            ///  فعال
            /// </summary>
            public static int Enable = 6;
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JPermission+JPermissionEvents");
            }
        }
        public class JPermissionControl
        {
            /// <summary>
            /// کلاس
            /// </summary>
            public static int Class = 1;
            /// <summary>
            ///  فرم
            /// </summary>
            public static int Form = 2;
            
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JPermission+JPermissionControl");
            }
        }

    }

    /// <summary>
    /// اعیان
    /// </summary>
    public static class JRealEstate
    {
        /// <summary>
        /// انواع تاریخ پیشفرض پرداخت
        /// </summary>
        public class JDefaultPayDate
        {
           public static int DocumentDate = 1;
           public static int CurrentDate = 2;
           public static DataTable GetData()
           {
               return (new JDomain()).GetDomin("JRealEstate+JDefaultPayDate");
           }
        }

    }

    /// <summary>
    /// لیست پروژه ها
    /// </summary>
    public static class JApplication
    {
        public class JApplicationType
        {
            /// <summary>
            /// کلاس پایه
            /// </summary>
            public static int ClassLibrary = 1;
            /// <summary>
            ///  کارتابل
            /// </summary>
            public static int Automation = 2;
            /// <summary>
            /// پرسنلی
            /// </summary>
            public static int Employment = 3;
            /// <summary>
            /// اتوماسیون اداری
            /// </summary>
            public static int Communication = 5;
            /// <summary>
            /// مستغلات
            /// </summary>
            public static int RealEState = 11;
            /// <summary>
            /// اسناد
            /// </summary>
            public static int ArchivedDocuments = 6;
            /// <summary>
            /// مالی
            /// </summary>
            public static int Finance = 7;
            /// <summary>
            /// املاک
            /// 
            /// </summary>
            public static int Estates = 8;
           
            /// <summary>
            /// حقوقی
            /// </summary>
            public static int Legal = 9;
            ///// <summary>
            ///// 
            ///// </summary>
            public static int Managementshares = 23;
            ///// <summary>
            ///// 
            ///// </summary>
            public static int OfficeWord = 11;
            /// <summary>
            /// 
            /// </summary>
            public static int Globals = 30;
            /// <summary>
            /// 
            /// </summary>
            public static int Meeting = 13;
            /// <summary>
            /// حراست
            /// </summary>
            public static int Security = 17;
            /// <summary>
            /// رستوران
            /// </summary>
            public static int Restaurant = 18;
            /// <summary>
            /// کارت هوشمند
            /// </summary>
            public static int SmartCards = 19;
            /// <summary>
            /// مدیریت انبار
            /// </summary>
            public static int StoreManagement = 20;
            /// <summary>
            /// گردش کار
            /// </summary>
            public static int WorkFlow = 21;
            /// <summary>
            /// بازرگانی
            /// </summary>
            public static int Commercial = 22;
            /// <summary>
            /// حسابداری
            /// </summary>
            public static int FinancialAccounting = 7;
            /// <summary>
            /// پارکینگ
            /// </summary>
            public static int parking = 24;
           
            /// <summary>
            /// قرعه کشی
            /// </summary>
            public static int Lottery = 26;
            /// <summary>
            /// باسکول
            /// </summary>
            public static int Bascol = 27;
            /// <summary>
            ///کارت هوشمند سپاد  
            /// </summary>
            public static int SmartCardSepad = 28;
            /// <summary>
            /// مجتمع قراردادها
            /// </summary>
            public static int StoreComplex = 29;
            /// <summary>
            /// سرگرمی
            /// </summary>
            public static int Entertainment = 30;
            /// <summary>
            /// اتوبوس رانی
            /// </summary>
            public static int BusManagment = 34;
            public static int OilProductsDistributionCompany = 35;
            
            
            public static int OilChangeManagment = 36;
            public static int WarehouseManagement = 37;
            public static int WebArchivedDocuments = 10035;
            public static int WebAutomobile = 10036;
            public static int WebBaseDefine = 10037;
            public static int WebBusManagement = 10038;
            public static int WebClassLibrary = 10039;
            public static int WebControllers = 10040;
            public static int WebManagementShare = 10041;
            public static int WebOilManagement = 10042;
            public static int WebAutomation = 10043;
            public static int WebWarehouseManagement = 10044;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JApplication+JApplicationType");
            }
        }

    }

    /// <summary>
    /// اتوماسیون اداری
    /// </summary>
    public static class JAutomation
    {
        /// <summary>
        /// انواع ارجاع
        /// </summary>
        public class JReferType
        {
            /// <summary>
            /// داخلی
            /// </summary>
            public static int Internal = 1;
            /// <summary>
            ///  خارجی
            /// </summary>
            public static int External = 2;
            /// <summary>
            /// شرکت تابعه
            /// </summary>
            public static int Subsidiaries = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JAutomation+JReferType");
            }
        }
        /// <summary>
        /// انواع نحوه ارسال
        /// </summary>
        public class JSendExportType
        {
            /// <summary>
            /// پستی
            /// </summary>
            public static int Post = 1;
            /// <summary>
            ///  فکس
            /// </summary>
            public static int Fax = 2;
            /// <summary>
            /// تحویل حضوری
            /// </summary>
            public static int Delivery = 3;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JAutomation+JٍٍSendExportType");
            }
        }
        /// <summary>
        /// انواع ارتباط
        /// </summary>
        public class JRelatedType
        {
            /// <summary>
            /// عطف
            /// </summary>
            public static int Reply = 1;
            /// <summary>
            ///  پیرو
            /// </summary>
            public static int Peyro = 2;            

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JAutomation+JRelatedType");
            }
        }

        public class JReferStatus
        {
            /// <summary>
            /// جاری
            /// </summary>
            public static int Current = 1;
            /// <summary>
            ///  ارسال شده
            /// </summary>
            public static int Sent = 2;
            /// <summary>
            /// ابطال شده
            /// </summary>
            public static int Cancel = 3;
            /// <summary>
            /// تمام شده
            /// </summary>
            public static int Finish = 4;
            /// <summary>
            /// معلق
            /// </summary>
            public static int Flout = 5;
            /// <summary>
            /// واگذاری
            /// </summary>
            public static int Transfer = 6;
            /// <summary>
            /// آرشیو
            /// </summary>
            public static int Archive = 7;
            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JAutomation+JReferStatus");
            }

            public static string GetName(int pCode)
            {
                switch (pCode)
                {
                    case 1: return "Current";
                    case 2: return "Sent";
                    case 3: return "Cancel";
                    case 4: return "Finish";
                    case 5: return "Finish";
                    case 6: return "Finish";
                    case 7: return "Archive";
                }
                return "";
            }
        }

    }
    
    /// <summary>
    /// حقوقی
    /// </summary>
    public static class Legal
    {
        /// <summary>
        /// انواع وکالت
        /// </summary>
        public class JAdvocateType
        {
            /// <summary>
            ///  اداری
            /// </summary>
            public static int Official = 1;
            /// <summary>
            ///  بلاعزل
            /// </summary>
            public static int Exclusive = 2;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JLegal+JAdvocateType");
            }
        }
        /// <summary>
        /// انواع وکالت
        /// </summary>
        public class JPetitionType
        {
            /// <summary>
            ///  دادخواست
            /// </summary>
            public static int Petition = 1;
            /// <summary>
            ///  شکوائیه
            /// </summary>
            public static int Fey = 2;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JLegal+JPetitionType");
            }
        }
        /// <summary>
        /// انواع وکالت
        /// </summary>
        public class JPersonPetitionType
        {
            /// <summary>
            ///  خواهان
            /// </summary>
            public static int Petition = 1;
            /// <summary>
            ///  وکیل خواهان
            /// </summary>
            public static int PetitionAdvocate = 2;
            /// <summary>
            ///  خوانده
            /// </summary>
            public static int Fey = 3;
            /// <summary>
            ///وکیل خوانده  
            /// </summary>
            public static int FeyAdvocate = 4;
            /// <summary>
            ///محکوم له  
            /// </summary>
            public static int PetitionExecute = 5;
            /// <summary>
            ///محکوم علیه  
            /// </summary>
            public static int FeyExecute = 6;
            /// <summary>
            ///فروشنده  
            /// </summary>
            public static int Seller = 7;
            /// <summary>
            ///وکیل فروشنده  
            /// </summary>
            public static int SellerAdvocate = 8;
            /// <summary>
            ///خریدار  
            /// </summary>
            public static int Buyer = 9;
            /// <summary>
            ///وکیل خریدار  
            /// </summary>
            public static int BuyerAdvocate = 10;
            /// <summary>
            ///شهود  
            /// </summary>
            public static int intuition = 11;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JLegal+JPetitionType");
            }
        }
        /// <summary>
        /// انواع انحلال
        /// </summary>
        public class JBreakupType
        {
            /// <summary>
            ///  عزل نشده
            /// </summary>
            public static int None = 0;
            /// <summary>
            ///  ارائه گواهی عزل از محضر
            /// </summary>
            public static int Vicarious = 1;
            /// <summary>
            ///  انجام امور توسط موکل
            /// </summary>
            public static int Notary = 2;
            /// <summary>
            ///  فوت (حجر)وکیل یا موکل
            /// </summary>
            public static int Die = 3;
            /// <summary>
            ///  حکم دادگاه
            /// </summary>
            public static int tribunal = 4;
            /// <summary>
            /// عزل شده
            /// </summary>
            public static int Dismissal = 5;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("JLegal+JBreakupType");
            }
        }
    }

    /// <summary>
    /// کارگزینی
    /// </summary>
    public static class Employment
    {
        /// <summary>
        /// انواع وضعیت درخواست مرخصی
        /// </summary>
        public class JVacationStatus
        {
            /// <summary>
            ///  درخواست
            /// </summary>
            public static int Request = 1;
            /// <summary>
            ///  تایید
            /// </summary>
            public static int Confirm = 2;
            /// <summary>
            ///  تایید کارگزینی
            /// </summary>
            public static int Personnel = 3;
            /// <summary>
            ///  عدم تایید
            /// </summary>
            public static int NotConfirm = 4;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("Employment+JVacationStatus");
            }
        }
        /// <summary>
        ///انواع وضعیت درخواست مرخصی روزانه  
        /// </summary>
        public class JVacationDailyType
        {
            /// <summary>
            ///  استحقاقی
            /// </summary>
            public static int Entitlement = 1;
            /// <summary>
            ///  استعلاجی
            /// </summary>
            public static int Sick = 2;
            /// <summary>
            ///  بدون حقوق
            /// </summary>
            public static int NoSalary = 3;
            /// <summary>
            ///  تشویقی
            /// </summary>
            public static int Persuasive = 4;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("Employment+JVacationStatus");
            }
        }
    }

    
    /// <summary>
    /// حراست
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// انواع وضعیت درخواست تمدید قرارداد اجاره
        /// </summary>
        public class JRentalStatus
        {
            /// <summary>
            ///  درخواست حراست
            /// </summary>
            public static int RequestSecurity = 1;
            /// <summary>
            ///  تایید حراست
            /// </summary>
            public static int ConfirmSecurity = 2;
            /// <summary>
            ///   عدم تایید حراست
            /// </summary>
            public static int NotConfirmSecurity = 3;
            /// <summary>
            ///  درخواست خدمات
            /// </summary>
            public static int RequestService = 4;
            /// <summary>
            ///  تایید خدمات
            /// </summary>
            public static int ConfirmService = 5;
            /// <summary>
            ///   عدم تایید خدمات
            /// </summary>
            public static int NotConfirmService = 6;
            /// <summary>
            ///  درخواست روابط عمومی
            /// </summary>
            public static int RequestPublicRelations = 7;
            /// <summary>
            ///  تایید روابط عمومی
            /// </summary>
            public static int ConfirmPublicRelations = 8;
            /// <summary>
            ///   عدم تایید روابط عمومی
            /// </summary>
            public static int NotConfirmPublicRelations = 9;
            /// <summary>
            ///  درخواست امومالی
            /// </summary>
            public static int RequestFinance = 10;
            /// <summary>
            ///  تایید امومالی
            /// </summary>
            public static int ConfirmFinance = 11;
            /// <summary>
            ///   عدم تایید امومالی
            /// </summary>
            public static int NotConfirmFinance = 12;
            /// <summary>
            ///  درخواست مدیریت
            /// </summary>
            public static int RequestManagement = 13;
            /// <summary>
            ///  تایید  مدیریت
            /// </summary>
            public static int ConfirmManagement = 14;
            /// <summary>
            ///   عدم تایید  مدیریت 
            /// </summary>
            public static int NotConfirmManagement = 15;
            /// <summary>
            ///  درخواست املاک
            /// </summary>
            public static int RequestEstate = 16;
            /// <summary>
            ///  تایید املاک
            /// </summary>
            public static int ConfirmEstate = 17;
            /// <summary>
            ///   عدم تایید املاک
            /// </summary>
            public static int NotConfirmEstate = 18;

            public static DataTable GetData()
            {
                return (new JDomain()).GetDomin("Security+JRentalStatus");
            }
        }
      
    }
}
