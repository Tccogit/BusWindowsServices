using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JRelation : JSystem
    {

        #region Properties

        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام کلاس اصلی
        /// </summary>
        public string PrimaryClassName { get; set; }
        /// <summary>
        /// کد اصلی
        /// </summary>
        public int PrimaryObjectCode { get; set; }
        /// <summary>
        /// نام کلاس فرعی
        /// </summary>
        public string ForeignClassName { get; set; }
        /// <summary>
        /// کد کلاس فرعی
        /// </summary>
        public int ForeignObjectCode { get; set; }
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// کد پست کاربر
        /// </summary>
        public int UserPostCode { get; set; }
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int UserCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment { get; set; }

        #endregion

        #region سازنده

        public JRelation()
        {
        }
        public JRelation(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }

        #endregion


        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            JDataBase pDB = new JDataBase();
            if (Insert(pDB))
                return true;
            else
                return false;
        }
        public bool Insert(JDataBase pDB)
        {
            JRelationTable PDT = new JRelationTable();
            CreateDate = JDateTime.Now();
            UserPostCode = JMainFrame.CurrentPostCode;
            UserCode = JMainFrame.CurrentUserCode;

            PDT.SetValueProperty(this);
            Code = PDT.Insert(pDB);
            if (Code <= 0)
                return false;
            //Histroy.Save(this, PDT, PDT.Code, "Insert");
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPrimaryClassName"></param>
        /// <param name="pPrimaryObjectCode"></param>
        /// <returns></returns>
        public bool CheckRelation(string pPrimaryClassName, int pPrimaryObjectCode,JDataBase db)
        {
            try
            {
                db.setQuery("select * from " + JTableNamesClassLibrary.Relation + " where " + Relation.PrimaryClassName + "='" + pPrimaryClassName.ToString() + "' and " + Relation.PrimaryObjectCode + "=" + pPrimaryObjectCode.ToString());
                if (db.Query_DataTable().Rows.Count > 0)
                    return true;
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
              //  db.Dispose();
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPrimaryClassName"></param>
        /// <param name="pPrimaryObjectCode"></param>
        /// <returns></returns>
        public bool CheckRelation(string exp, JDataBase db)
        {
            try
            {
                db.setQuery("select * from " + JTableNamesClassLibrary.Relation + " where " + exp);
                if (db.Query_DataTable().Rows.Count > 0)
                    return true;
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
               // db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPrimaryClassName"></param>
        /// <param name="pPrimaryObjectCode"></param>
        /// <returns></returns>
        public bool CheckRelation(string pPrimaryClassName, int pPrimaryObjectCode)
        {
            JDataBase Db = new JDataBase();
            return CheckRelation(pPrimaryClassName, pPrimaryObjectCode,Db);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pForeignClassName"></param>
        /// <param name="pForeignObjectCode"></param>
        /// <returns></returns>
        public bool Delete(string pForeignClassName, int pForeignObjectCode)
        {
            try
            {
                JDataBase Db = new JDataBase();
                if (Delete(pForeignClassName, pForeignObjectCode, Db))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }
        public bool Delete(string pForeignClassName, int pForeignObjectCode, JDataBase Db)
        {
            if (!CheckRelation(pForeignClassName, pForeignObjectCode, Db))
            {
                try
                {
                    JRelationTable PDT = new JRelationTable();
                    if (PDT.DeleteManual(Relation.ForeignClassName + "='" + pForeignClassName.ToString() + "' and " + Relation.ForeignObjectCode + "=" + pForeignObjectCode.ToString(), Db) || PDT.GetDeleteCount() >= 0)
                        return true;
                    else
                        return false;

                    //Db.setQuery("Delete From " + JTableNamesClassLibrary.Relation + " where " + Relation.ForeignClassName + "= " + pForeignClassName.ToString() + " and " + Relation.ForeignObjectCode + "=" + pForeignObjectCode.ToString());
                    //Db.Query_DataReader();
                    ////Histroy.(PDT, PDT.Code, "Delete");
                    //return Db.DataReader.Read();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                    return false;
                }
                finally
                {
                    //Db.Dispose();
                }
            }
            return true;
        }

        /// <summary>
        ///  حذف دستی
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JRelationTable PDT = new JRelationTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesClassLibrary.Relation + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        #endregion


          
    }
}
