using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;

namespace ClassLibrary
{

    /// <summary>
    /// کلاس امنیت
    /// </summary>
    public class JPermissionSuccessor : JCore
    {
        #region Property
        /// <summary>
        /// کد پرمیشن کاربر
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد پرمیشن
        /// </summary>
        public int DecisionCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public int DefineClassCode { get; set; }
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int User_Post_Code { get; set; }
        /// <summary>
        /// مجوز
        /// </summary>
        public bool HasPermission { get; set; }
        /// <summary>
        /// ثبت کننده
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        ///  تاریخ شروع مجوز 
        /// </summary>
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// تاریخ پایان مجوز
        /// </summary>
        public DateTime End_Date { get; set; }

        #endregion

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pUserCode"></param>
        /// <param name="pObjectCode"></param>
        public JPermissionSuccessor()
        {
            ObjectCode = 0;
        }

        public JPermissionSuccessor(int code)
        {
            GetData(code);
        }
        /// <summary>
        /// جستجوی اطلاعات کاربر بر اساس کد جدول
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUserSuccessor + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        public Boolean Check()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUserSuccessor +
                    " WHERE DecisionCode = " + DecisionCode.ToString() + " And User_Post_Code = " + User_Post_Code.ToString() +
                    " And ObjectCode=" + ObjectCode.ToString()); //+ " And HasPermission=" + HasPermission.ToString());
                if (DB.Query_DataTable().Rows.Count > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// درج مجوزهای کاربر
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JPermissionSuccessorTable PUT = new JPermissionSuccessorTable();
            try
            {
                //if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Insert"))
                //{
                PUT.SetValueProperty(this);
                Code = PUT.Insert();
                return Code;
                //}
                //else
                //    return 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                PUT.Dispose();
            }
        }
        /// <summary>
        /// ویرایش مجوزهای کاربر
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            JPermissionSuccessorTable PUT = new JPermissionSuccessorTable();
            try
            {
                //if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Update"))
                //{
                PUT.SetValueProperty(this);
                return PUT.Update();
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PUT.Dispose();
            }
        }
        /// <summary>
        /// حذف مجوز کاربر
        /// </summary>
        /// <returns></returns>
        public bool delete()
        {
            JPermissionSuccessorTable PUT = new JPermissionSuccessorTable();
            try
            {
                //if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Delete"))
                //{
                PUT.SetValueProperty(this);
                string Where = " 1=1 ";
                Where = Where + " And Creator =" + PUT.Creator;
                Where = Where + " And User_Post_Code =" + PUT.User_Post_Code;
                Where = Where + " And ObjectCode =" + PUT.ObjectCode;
                Where = Where + " And DecisionCode =" + PUT.DecisionCode;
                return PUT.DeleteManual(Where);
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PUT.Dispose();
            }
        }
        /// <summary>
        /// حذف مجوز کاربر بر اساس تاریخ مجوز ها
        /// </summary>
        /// <returns></returns>
        public bool deleteByDate()
        {
            JPermissionSuccessorTable PUT = new JPermissionSuccessorTable();
            try
            {
                //if (JPermission.CheckPermission("ClassLibrary.JPermissionUser.Delete"))
                //{
                PUT.SetValueProperty(this);
                string Where = " 1=1 ";
                Where = Where + " And Creator =" + PUT.Creator;
                Where = Where + " And User_Post_Code =" + PUT.User_Post_Code;
                Where = Where + " And Start_Date =CAST('" + PUT.Start_Date.ToString("yyyy-MM-dd") + "' AS datetime)";
                Where = Where + " And End_Date =CAST('" + PUT.End_Date.ToString("yyyy-MM-dd") + "' AS datetime)";
                JDataBase db = new JDataBase();
                db.setQuery("Delete From [PermissionUserSuccessor] Where " + Where);
                db.Query_Execute();
                return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PUT.Dispose();
            }
        }

        public override string ToString()
        {
            JPermissionDecision PD = new JPermissionDecision();
            PD.GetData(DecisionCode);

            JPermissionDefineClass PDC = new JPermissionDefineClass();
            PDC.GetData(PD.PermissionDefineCode);

            if (PDC.SQL != null && PDC.SQL.Length > 0 && ObjectCode != 0)
            {
                object objectValue = PDC.GetObjectValue(ObjectCode);
                if (objectValue != null)
                    return PDC + "->" + objectValue.ToString() + "->" + PD;
            }

            return PDC + "->" + PD;
        }

    }


    /// <summary>
    /// کلاس امنیت کاربر
    /// </summary>
    public class JPermissionsSuccessor : JCore
    {
        #region Property
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JPermissionSuccessor[] Items;
        #endregion

        /// <summary>
        ///  سازنده کلاس
        /// </summary>
        /// <param name="pUserCode"></param>
        public JPermissionsSuccessor(int pUserCode)
        {
            UserCode = pUserCode;
        }

        /// <summary>
        /// جستجوی کد مجوزهای کاربر بر اساس کد کاربر
        /// </summary>
        /// <returns></returns>
        public Boolean GetData()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT Code FROM " + JTableNamesPermission.PermissionUserSuccessor + " WHERE " +
                    PermissionUser.User_post_Code + "=" + UserCode.ToString() + " And Creator = " + JMainFrame.CurrentPostCode);
                DB.Query_DataReader();
                Items = new JPermissionSuccessor[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    Items[count] = new JPermissionSuccessor();
                    Items[count].GetData(int.Parse(DB.DataReader["Code"].ToString()));
                    count++;
                }
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        /// <summary>
        /// جستجوی کد مجوزهای کاربر بر اساس کد کاربر
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUserSuccessor + " WHERE " +
                    PermissionUser.User_post_Code + "=" + UserCode.ToString() + " And Creator = " + JMainFrame.CurrentPostCode);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
