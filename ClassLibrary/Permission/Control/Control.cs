using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ClassLibrary
{
    public class JPermissionControl : JCore
    {

        /// <summary>
        /// لیست فیلدها
        /// </summary>
        #region Property
        public int Code { get; set; }
        public int Parent_code { get; set; }
        public String Class_Name { get; set; }
        public String Object_Name { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Class_Code { get; set; }
        public int Decision_Code { get; set; }
        //public int Object_Code { get; set; }
        public String Description { get; set; }
        #endregion

        
        #region Functions
        /// <summary>
        /// سازنده
        /// </summary>
        public JPermissionControl()
        {
        }

        public bool Find(string pClassName, int pDecisionCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select " + PermissionControl.Code + " from " + JTableNamesPermission.PermissionControl +
                    " where " + PermissionControl.Class_Name + "=" + JDataBase.Quote(pClassName) +
                    " And " + PermissionControl.Decision_Code + "=" + pDecisionCode.ToString());
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        ///بر اساس کلاس و تصمیم  DLL پیدا کردن نام کلاس
        /// </summary>
        /// <param name="pClassCode"></param>
        /// <param name="pDecisionCode"></param>
        /// <returns></returns>
        public DataTable FindClassName()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * from " + JTableNamesPermission.PermissionControl +
                    " where " + PermissionControl.Class_Code + "=" + Class_Code.ToString() +
                    " And " + PermissionControl.Decision_Code + "=" + Decision_Code.ToString());
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// درج در جدول کنترل
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (Find(this.Class_Name, this.Decision_Code))
            {
                JMessages.Error("DecisionExists", "Error");
                return 0;
            }
            JPermissionControlTable PDT = new JPermissionControlTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Insert();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JPermissionControlTable PDT = new JPermissionControlTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        /// <summary>
        /// حذف دستی
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JPermissionControlTable PDT = new JPermissionControlTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.DeleteManual(PermissionControl.Class_Name + "=" + JDataBase.Quote(PDT.Class_Name) + 
                    " And " + PermissionControl.Object_Name + "=" + JDataBase.Quote(PDT.Object_Name) + 
                    " And " + PermissionControl.Class_Code + "=" + PDT.Class_Code + 
                    " And " + PermissionControl.Decision_Code + "=" + PDT.Decision_Code + 
                    " And " + PermissionControl.Type + "=" + PDT.Type);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        public bool Delete(string pClassName, int pDecisionCode)
        {
            JPermissionControlTable PDT = new JPermissionControlTable();
            try
            {
                //PDT.SetValueProperty(this);
                return PDT.DeleteManual(PermissionControl.Class_Name + "=" + JDataBase.Quote(pClassName) +
                    " And " + PermissionControl.Decision_Code + "=" + pDecisionCode.ToString());
                
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        public static int[] GetDecisions(string pClassName)
        {
            int[] decisions = new int[0];
            int i = 0;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT " + PermissionControl.Decision_Code.ToString() + " FROM " + JTableNamesPermission.PermissionControl +
                    " WHERE " + PermissionControl.Class_Name.ToString() + " = " + JDataBase.Quote(pClassName));
                DB.Query_DataReader();
                while (DB.DataReader.Read())
                {
                    Array.Resize(ref decisions, i + 1);
                    decisions[i] = (int)DB.DataReader[PermissionControl.Decision_Code.ToString()];
                    i++;
                }
                return decisions;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// چک کردن پدر
        /// </summary>
        /// <param name="Class_name"></param>
        /// <returns></returns>
        public int CheckParent(string Class_name)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("Select " + PermissionControl.Code + " from " + JTableNamesPermission.PermissionControl + " where " + PermissionControl.Class_Name+"=" +JDataBase.Quote(Class_name));
                return Convert.ToInt32(DB.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// جستجوی کنترلی خاص در جدول
        /// </summary>
        /// <returns></returns>
        public bool SearchControl()
        {
            JDataBase db = new JDataBase();
            try
            {
                //if (Object_Code != 0)
                //    db.setQuery("Select " + PermissionControl.Code + " from " + JTableNamesPermission.PermissionControl + " where " + PermissionControl.Class_Name + "='" + Class_Name + "' And " + PermissionControl.Object_Name + "='" + Object_Name + "' And " + PermissionControl.Type + "=" + Type + " And " + PermissionControl.Class_Code + "=" + Class_Code + " And " + PermissionControl.Decision_Code + "=" + Decision_Code + " And " + PermissionControl.Object_Code + "=" + Object_Code);
                //else
                    db.setQuery("Select " + PermissionControl.Code + " from " + JTableNamesPermission.PermissionControl + " where " + PermissionControl.Class_Name + "='" + Class_Name + "' And " + PermissionControl.Object_Name + "='" + Object_Name + "' And " + PermissionControl.Type + "=" + Type + " And " + PermissionControl.Class_Code + "=" + Class_Code + " And " + PermissionControl.Decision_Code + "=" + Decision_Code);
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    db.DataReader.Read();
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }     
        /// <summary>
        /// کلیه اطلاعات کنترل ها را از جدول می آورد
        /// </summary>
        /// <returns></returns>
        //public DataTable GetData()
        //{
        //    JDataBase DB = new JDataBase();
        //    DB.setQuery(@"Select * from " + JTableNamesPermission.PermissionControl );
        //    return DB.Query_DataTable();
        //}

        ///// <summary>
        ///// چک کردن مجوز کاربری خاص به کنترل
        ///// </summary>
        ///// <param name="User_code"></param>
        ///// <returns></returns>
        //public bool CheckPermission(int pUser_post_code)
        //{
        //    JDataBase DB = new JDataBase();
        //    JPermission tmpJPermission = new JPermission();
        //    int Object_Code = 0;
        //    bool Has;
        //    bool flag = false;
        //    try
        //    {
        //        DB.setQuery(@"Select *  from " + JTableNamesPermission.PermissionControl + " where " + PermissionControl.Class_Name + "=" +JDataBase.Quote(Class_Name) + 
        //            " And " +PermissionControl.Object_Name + "='" + Object_Name + "' And "+PermissionControl.Type+"=" + Type);
        //        DataTable tmpdt = new DataTable();
        //        tmpdt = DB.Query_DataTable();
        //        if (tmpdt.Rows.Count > 0)
        //        {
        //            DataRow dr = tmpdt.Rows[0];
        //            //foreach (DataRow dr in tmpdt.Rows)
        //            //{
        //                if ((dr[PermissionControl.Object_Code.ToString()] == null) || (dr[PermissionControl.Object_Code.ToString()].ToString() == ""))
        //                    Object_Code = 0;
        //                else
        //                    Object_Code = Convert.ToInt32(dr[PermissionControl.Object_Code.ToString()].ToString());
        //                //Has = tmpJPermission.UserAllowbyCodeObject1(JMainFrame.CurrentPostCode, Convert.ToInt32(dr[PermissionControl.Class_Code.ToString()].ToString()), 0, Convert.ToInt32(dr[PermissionControl.Decision_Code.ToString()].ToString()));
        //                return true;
        //        }
        //        else
        //            return true;
        //        return flag;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //        tmpJPermission.Dispose();
        //    }
        //}

        ///// <summary>
        /////چک کردن مجوز کاربری خاص به کنترل با توجه به جدول ورودی 
        ///// </summary>
        ///// <param name="User_code"></param>
        ///// <returns></returns>
        //public bool CheckPermissionByDataTable(DataTable pDt)
        //{
        //    JDataBase DB = new JDataBase();
        //    JPermission tmpJPermission = new JPermission();
        //    int Object_Code = 0;
        //    bool Has;
        //    bool flag = false;
        //    try
        //    {
        //        DataView dv =new DataView(pDt);
        //        dv.RowFilter = PermissionControl.Class_Name + "='" + Class_Name + "' And " + PermissionControl.Object_Name + "=" +JDataBase.Quote(Object_Name)+ " And " + PermissionControl.Type + "=" + Type;
        //        if (dv.Count > 0)
        //        {                    
        //                if ((dv[0][PermissionControl.Object_Code.ToString()] == null) || (dv[0][PermissionControl.Object_Code.ToString()].ToString() == ""))
        //                    Object_Code = 0;
        //                else
        //                    Object_Code = Convert.ToInt32(dv[0][PermissionControl.Object_Code.ToString()].ToString());
        //                Has = tmpJPermission.UserAllowbyCodeObject1(JMainFrame.CurrentPostCode, Convert.ToInt32(dv[0][PermissionControl.Class_Code.ToString()].ToString()), 0, Convert.ToInt32(dv[0][PermissionControl.Decision_Code.ToString()].ToString()));
        //                return Has;                    
        //        }
        //        else
        //            return true;
        //        return flag;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //        tmpJPermission.Dispose();
        //    }
        //}
        #endregion
    }
    public class JPermissionsControl : JCore
    {
        #region static property
        private static DataTable _ControlsDatatable;
        public static DataTable ControlsDatatable
        {
            get
            {
                if (_ControlsDatatable == null)
                {
                    _ControlsDatatable = GetData();

                }
                return _ControlsDatatable;
            }
        }
        #endregion

        public static bool CheckHasFunction(string pFuncName)
        {
            if (ControlsDatatable != null)
            {
                if (ControlsDatatable.Select("ClassName=" + JDataBase.Quote(pFuncName)).Length > 0)
                    return true;
            }
            return false;
        }

        public static DataTable GetData()
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = "SELECT * FROM " + JTableNamesPermission.PermissionControl + " ";
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }
    }

}
