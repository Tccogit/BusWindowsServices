using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JFolderTable : JTable
    {
        #region Properties

        /// <summary>
        ///کد پست کاربر 
        /// </summary>
        public int User_post_code;
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code;
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        public string Name;
        /// <summary>
        /// نوع فولدر
        /// </summary>
        public int FolderType;
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>        
        public DateTime Create_Date_Time;
        /// <summary>
        /// ارسال کننده 
        /// </summary>
        public int Sender_User_post_code;
        /// <summary>
        /// نوع شی
        /// </summary>
        public int Object_type;

        #endregion

        public JFolderTable() :
            base(JTableNamesAutomation.Folders, Folder.parent_code.ToString())
        {
        }
    }

    public enum Folder
    {
        Code,
        User_post_code,
        /// <summary>
        ///کد پدر
        /// </summary>
        parent_code,
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        Name,
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>
        Create_Date_Time,
        /// <summary>
        /// نوع فولدر
        /// </summary>
        FolderType,
        /// <summary>
        /// ارسال کننده 
        /// </summary>
        Sender_User_post_code,
        /// <summary>
        /// نوع شی
        /// </summary>
        Object_type,
    }
}
