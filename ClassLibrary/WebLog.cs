using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// لاگ برای ثبت تغییرات در وبسایت
    /// </summary>
    public class JShareWebLog : JSystem
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام جدول
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// کد تغییر یافته
        /// </summary>
        public int ChangedCode { get; set; }
        /// <summary>
        /// عملیات
        /// </summary>
        public char Operation { get; set; }
        /// <summary>
        /// اعمال شد
        /// </summary>
        public bool Applyed{ get; set; }

        #endregion Properties

        public static int Insert(JDataBase pDB, string TableName, int ChangedCode, char Operation )
        {
            JShareWebLogTable logTable = new JShareWebLogTable();
            try
            {
                logTable.Set_ComplexInsert(false);
                //logTable.SetValueProperty(this);
                logTable.TableName = TableName;
                logTable.Operation = Operation;
                logTable.ChangedCode = ChangedCode;
                return logTable.Insert(pDB);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

  
    }
}
