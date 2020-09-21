using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSignatureMen : JSystem
    {
        
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// فعال
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// سمت
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// حدود و اختیارات 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// کد شخص صاحب امضاء
        /// </summary>
        public int SignPCode{ get; set; }
        /// <summary>
        /// در صورت تغییر در ویرایش
        /// </summary>
        public bool Changed;//{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FromDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ToDate { get; set; }
        /// <summary>
        ///در صورت حذف  
        /// </summary>
        public bool Deleted ;//{ get; set; }
        #region Functions


        public bool Find(int pSignPCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.SignatureMen + " WHERE [Code] = " +this.PCode.ToString()+
                    " AND "+JSignatureMenFields.SignPCode.ToString()+" = "+pSignPCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public int Insert(JDataBase pDB)
        {
            if (Find(this.SignPCode))
            {
                JMessages.Error("PersonSignExists", "Error");
                return 0;
            }
            JSignatureMenTable signMen = new JSignatureMenTable();
            signMen.SetValueProperty(this);
            int r = signMen.Insert(pDB);
            return r;
        }

        public bool Update(JDataBase pDB)
        {
            JSignatureMenTable signMen = new JSignatureMenTable();
            signMen.SetValueProperty(this);
            return  signMen.Update(pDB);
        }

        public bool Delete(JDataBase pDB)
        {
            JSignatureMenTable signMen = new JSignatureMenTable();
            signMen.SetValueProperty(this);
            return signMen.Delete(pDB);
        }

        public bool GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.SignatureMen + " WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }

        }

        /// <summary>
        /// صاحبان امضاء یک شخص حقوقی را بصورت جدول برمیگرداند
        /// </summary>
        /// <param name="pPCode"></param>
        /// <returns></returns>
        public static System.Data.DataTable LoadSignatureMen(int pPCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(" SELECT "
                    + JTableNamesClassLibrary.SignatureMen + "." + JSignatureMenFields.Code.ToString() + ", "
                    + JSignatureMenFields.PCode.ToString() + ", "
                    + JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Name.ToString() + " AS "+JSignatureMenFields.FirstName.ToString()+ " , "
                    + JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Fam.ToString() + " AS " + JSignatureMenFields.LastName.ToString() + " , "
                    + JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.FatherName.ToString() + " AS " + JSignatureMenFields.FatherName.ToString() + " , "
                    + JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.ShSh.ToString() + ", "

                    + JSignatureMenFields.SignPCode.ToString() + ", "
                    + JSignatureMenFields.Post.ToString() + ", "
                    + JSignatureMenFields.Description.ToString() + " , "
                    + JSignatureMenFields.Active.ToString() + " , "
                    + " ISNULL((Select Fa_Date from StaticDates Where En_Date = FromDate),'') FromDate, "
                    + " ISNULL((Select Fa_Date from StaticDates Where En_Date = ToDate), '') ToDate "
                    + " FROM " + JTableNamesClassLibrary.SignatureMen 
                    + " INNER JOIN " + JTableNamesClassLibrary.PersonTable +
                    " ON " + JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Code.ToString() + " = "
                    + JTableNamesClassLibrary.SignatureMen + "." + JSignatureMenFields.SignPCode.ToString()
                    + " WHERE "+ JTableNamesClassLibrary.SignatureMen + "." + JSignatureMenFields.PCode.ToString()+
                        " = " + pPCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        //public JNode ObjectBase(System.Data.DataRow pRow)
        //{
        //    JNode node = new JNode(this.Code, this.GetType().ToString());
        //    node.MouseClickAction = new JAction("", "NameSpace.Class.Function", new object[] { 1 }, new object[] { 0 }, true);
        //    JToolbarNode tb = new JToolbarNode();
        //    node.Popup.Insert(
        //    return node;
        //}

        #endregion Functions
    }
}
