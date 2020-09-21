using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSettingPrint
    {
        #region property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code
        {
            set;
            get;
        }
        /// <summary>
        /// نام تنظیم 
        /// </summary>
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// لیست فیلدها 
        /// </summary>
        public string FieldList
        {
            set;
            get;
        }
        /// <summary>
        ///  
        /// </summary>
        public bool LandScape
        {
            set;
            get;
        }
        /// <summary>
        /// حاشیه 
        /// </summary>
        public string MarginL
        {
            set;
            get;
        }
        /// <summary>
        /// حاشیه 
        /// </summary>
        public string MarginR
        {
            set;
            get;
        }
        /// <summary>
        /// حاشیه 
        /// </summary>
        public string MarginT
        {
            set;
            get;
        }
        /// <summary>
        /// حاشیه 
        /// </summary>
        public string MarginB
        {
            set;
            get;
        }
        /// <summary>
        /// هدر 
        /// </summary>
        public string Header
        {
            set;
            get;
        }
        /// <summary>
        /// پاورقی 
        /// </summary>
        public string Footer
        {
            set;
            get;
        }
        #endregion

        #region Constructor
        public JSettingPrint()
        {
        }
        public JSettingPrint(int pCode)
        {
            GetData(pCode);
        }
        #endregion
        
        #region Method
        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = " select * from " + JTableNamesClassLibrary.ClsSettingPrint + " where Code=" + pCode;
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            return false;
        }

               
        public int insert()
        {
            JSettingPrintTable JAGsT = new JSettingPrintTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Insert();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }

        public bool Update()
        {
            JSettingPrintTable JAGsT = new JSettingPrintTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Update();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }
        public bool Delete()
        {
            JSettingPrintTable JAGsT = new JSettingPrintTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Delete();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }
        #endregion
    }


    public class JSettingPrints
    {
        public JSettingPrint[] Items = new JSettingPrint[0];
        public JSettingPrints()
        {
        }

        public void GetDatas()
        {
            try
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                DB.setQuery("SELECT * FROM " + JTableNamesClassLibrary.ClsSettingPrint);
                System.Data.DataTable DT = DB.Query_DataTable();

                Array.Resize(ref Items, DT.Rows.Count);
                int count = 0;
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    Items[count] = new JSettingPrint(Convert.ToInt32(DR["Code"]));
                    JTable.SetToClassProperty(Items[count], DR);
                    count++;
                }
            }
            catch
            {
            }
        }
    }
}
