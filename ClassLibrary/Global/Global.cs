using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JGlobal: JSystem
    {
        /// <summary>
        /// 
        /// </summary>
        public static JMainFrame MainFrame = new JMainFrame();
        /// <summary>
        /// 
        /// </summary>
        public JGlobal()
        {
            if (MainFrame == null)
            {
                MainFrame = new JMainFrame();
            }
        }

        //public static JUser CurrentUser;
    }
    /// <summary>
    /// خیلی مهم اعداد داده شده حتما به ترتیب باشد
    /// </summary>
    public enum JImageIndex
    {
        Default = 0,
        user_48 = 1,
        user_warning_48 = 2,
        mail_48 = 3,
        lock_48 = 4,
        lock_open_48 = 5,
        Person = 6,
        Died_Person = 7,
        Ground = 8,
        mail = 9,
        land = 10,
        Add = 11,
        Delete = 12,
        City = 13,
        LegalPerson = 14,
        building = 15,
        advocacy = 16,
        unitbuild = 17,
        MarketUsage = 18,
        ProfitSource = 19,
        Courses = 20,
        MoneyDocuments = 21,
        DollarCoin = 22,
        search2 = 23,
        finddoc = 24,
        Search = 25,
        Report = 26,
        PersonCard = 27,
        Error = 28,
        testimonial = 29,
        Distraint = 30,
        Vote = 31,
        Tribunal = 32,
        UsageGround = 33,
        ContractType = 34,
        Contract = 35,
        ConfirmedContract = 36,
        report = 37,
        woman = 38,
        man = 39,
        ManDied = 40,
        WomanDied = 41,
        ExMail = 42,
        InMail = 43,
        worldmail = 44,
        maildocument = 45,
        Contract1 = 46,
        Database = 47,
        SMSGroup = 48,
        Customer = 49,
        CompanyTypes = 50,
        Successor = 51,
        OrganizationChart = 52,
        Changepassword = 53,
        Users = 54,
        Permission = 55,
        Help = 56,
        Relation = 57,
        SearchLetter = 58,
        LetterImport = 59,
        LetterExport = 60,
        LetterInternal = 61,
        KartablRecycle = 62,
        UserGroup = 63,
        BaseDefine = 64,
        Activity = 65,
        Kartabl = 66,
        KartablSender = 67,
        LetterPattern = 68 ,
        LetterStorage = 69 ,
        LetterSubject = 70 ,
        LetterSecretariat = 71 ,
        LetterRecieverType = 72 ,
        ContractEmployee = 73 ,
        EmployeeInfo = 74 ,
        VacationPermissions = 75,
        ResCostCenter = 76 ,
        ResWeekDay = 77 ,
        Settings = 78 ,
        Secrecy = 79 ,
        Config = 80 ,
        OtherFood = 81,
        Food = 82 ,
        Vacation = 83,
        Documents = 84 ,
        SubjectDocument = 85 ,
        Notice = 86 ,
        Decision = 87 ,
        Expertise = 88 ,
        Secretariat = 89,
        Bazar = 90 ,
        User = 91 ,
        Print = 92 ,
        Printer = 93,

    }

    public class JImageIcon : JCore
    {

        private static JConfig _Config;

        private static System.Windows.Forms.ImageList[] ImageLists = new System.Windows.Forms.ImageList[0];

        public static System.Drawing.Image getImage(JImageIndex pIndex)
        {
            return JImageIcon.getImage(pIndex.ToString());
        }
        public static System.Drawing.Image getImage(string pName)
        {
            try
            {
                if (_Config == null)
                    _Config = new JConfig();
                
                string _file = _Config.BaseFileAddress + "\\" + pName + ".png";
                if (!System.IO.File.Exists(_file))
                {
                    _file = JImageIndex.Default + ".png";
                }
                if (System.IO.File.Exists(_file))
                {
                    System.Drawing.Image img = new System.Drawing.Bitmap(_file);
                    return img;
                }
                else
                {
                    System.Drawing.Image img = new System.Drawing.Bitmap(1, 1);
                    return img;
                }
            }
            catch (Exception e)
            {
                Except.AddException(e);
                return null;
            }
            return null;
        }

        public static System.Windows.Forms.ImageList GetImageList(System.Drawing.Size pSize)
        {
            foreach (System.Windows.Forms.ImageList IgList in ImageLists)
            {
                if (IgList.ImageSize == pSize)
                {
                    return IgList;
                }
            }

            System.Windows.Forms.ImageList ImageList;
            ImageList = new System.Windows.Forms.ImageList();
            JImageIcon.SetImageList(ImageList, pSize);
            Array.Resize(ref ImageLists, ImageLists.Length + 1);
            ImageLists[ImageLists.Length - 1] = ImageList;
            return ImageList;
        }

        public static void SetImageList(System.Windows.Forms.ImageList pImageList, System.Drawing.Size pSize)
        {
            try
            {
                pImageList.ImageSize = pSize;
                string[] Names = Enum.GetNames(Type.GetType("ClassLibrary.JImageIndex"));
                foreach (string name in Names)
                {
                    System.Drawing.Image img = JImageIcon.getImage(name);
                    if (img != null)
                        pImageList.Images.Add(name, img);
                }
            }
            catch
            {
            }
        }

    }
}
