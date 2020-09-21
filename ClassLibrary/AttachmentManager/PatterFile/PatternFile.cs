using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ClassLibrary
{
    public class JCPatternFile : JSystem
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده کلاس
        /// </summary>
        public JCPatternFile()
        {
        }

        #endregion Constructors
        // Peroperties
        #region Properties
        /// <summary>
        /// کد رکورد در جدول
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام الگو
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نوع الگو الگو
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// فایل الگو
        /// </summary>
        public string Pattern { get; set; }
        #endregion Properties
        // Insert , Update , Delete
        #region BaseFunctions

        /// <summary>
        /// درج الگوی جدید در بانک اطلاعاتی
        /// </summary>
        /// <returns>بر می گرداند True در صورت درج صحیح مقدار</returns>
        public bool Insert()
        {
            if (Find(Code) || Find(Name))
                return false;
            JCPatternFileTable JST = new JCPatternFileTable();
            JST.SetValueProperty(this);
            int mCode = JST.Insert();
            if (mCode != 0)
            {
                Code = mCode;
                Nodes.Insert(GetNode());
                return true;
            }
            return false;
        }

        /// <summary>
        /// ویرایش اطلاعات الگو
        /// </summary>
        /// <returns>بر می گرداند True در صورت ویرایش صحیح مقدار</returns>        
        public bool Update()
        {
            if (Find(Code))
            {
                JCPatternFileTable JST = new JCPatternFileTable();
                JST.SetValueProperty(this);
                //JST.
                Nodes.Refresh(GetNode());
                return JST.Update();
            }
            return false;
        }

        /// <summary>
        /// حذف یک الگو از بانک اطلاعاتی
        /// </summary>
        /// <param name="pCode">کد مخزنی که باید حذف شود</param>
        /// <returns>بر می گرداند True در صورت حذف صحیح مقدار</returns>
        public bool Delete(int pCode)
        {
            if (Find(pCode))
            {
                if (JMessages.Message(JLanguages._Text("Do you want to Delete This Selected Item?"), JLanguages._Text("Question"), JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                 return false;
                
                GetData(pCode);
                JCPatternFileTable JST = new JCPatternFileTable();
                JST.SetValueProperty(this);
                if (JST.Delete())
                {
                    Nodes.Delete(GetNode());
                    return true;
                }
            }
            return false;
        }

        #endregion BaseFunctions
        // GetInfo
        #region GetInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode">کد الگو در جدول بانک اطلاعاتی</param>
        /// <returns>را بر می گرداند True در صورت وجود رکورد</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM patternfile WHERE [code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
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
        /// بررسی وجود الگو
        /// </summary>
        /// <param name="PName">کد الگو</param>
        /// <returns>را بر می گرداند True در صورت وجود رکورد</returns>
        public Boolean Find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM patternfile WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// بررسی وجود الگو بر اساس نام
        /// </summary>
        /// <param name="PName">نام الگو</param>
        /// <returns>را بر می گرداند True در صورت وجود رکورد</returns>
        public Boolean Find(string PName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM patternfile WHERE [Name]=" + JDataBase.Quote(PName));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion GetInfo
        //Forms
        #region Forms
        /// <summary>
        /// نمایش فرم ثبت رکورد جدید
        /// </summary>
        /// <returns>را برمی گرداند True و در صورت ثبت False در صورت انصراف مقدار </returns>
        public bool InsertForm()
        {
            JCfrmPatternFile jc = new  JCfrmPatternFile(this);
            jc.State = JFormState.Insert;
            jc.ShowDialog();
            return true;
        }
        /// <summary>
        /// نمایش فرم مخزن شماره نامه برای ویرایش اطلاعات
        /// </summary>
        /// <param name="pCode">کد مخزن</param>
        /// <returns>را برمی گرداند True و در صورت ثبت False در صورت انصراف مقدار </returns>      
        public bool UpdateForm(int Code)
        {
            if (GetData(Code))
            {
                JCfrmPatternFile jc = new JCfrmPatternFile(this);
                jc.State = JFormState.Update;
                jc.ShowDialog();
            }
            return true;
        }
        #endregion Forms
        // Node
        #region Node    
        /// <summary>
        /// نود الگو را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public JNode GetNode()
        {
            return JStaticNode._PatternFileNode(this);
        }
        public string ListView()
        {
            return null;
        }
        #endregion Node
    }

    public class JCPatternFiles : JSystem
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCPatternFiles()
            : this("")
        {
        }
        /// <summary>
        /// سازنده کلاس الگو که با دریافت یک شرط اطلاعات کلاس را مقدار دهی اولیه می کند
        /// </summary>
        /// <param name="where">شرط اس کیو ال</param>
        public JCPatternFiles(string where)
        {
            if (where.Length > 0)
                where = "AND" + where;
            _SQL = _SQL.Replace("%WHERE%", "WHERE 1=1 "+where);
            _getItems();
        }
        #endregion Constructors
        // Peroperties
        #region Properties
        private string _SQL = "SELECT [code],[name] FROM patternfile %WHERE% ORDER BY [name]";
        private JCPatternFile[] _Items;
        public JCPatternFile[] Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion Properties
        // View Nodes
        #region View
        public JNode[] TreeView()
        {
            return null;
        }
        public void ListView()
        {
            JAction InsertAction = new JAction("New", "Communication.JCPatternFile.InsertForm");
            Nodes.GlobalMenuActions = new JPopupMenu("Communication.JCPatternFile", 0);
            Nodes.GlobalMenuActions.Insert(InsertAction);

            foreach (JCPatternFile Sec in Items)
            {
                Nodes.Insert(Sec.GetNode());
            }
        }

        #endregion View
        // GetInfo
        #region GetInfo
        /// <summary>
        /// خواندن اطلاعات  الگو ها از بانک اطلاعاتی و و قرار دادن در متغیر 
        /// </summary>
        private void _getItems()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                _Items = new JCPatternFile[DB.DataSet.Tables[0].Rows.Count];
                int count = 0;
                foreach (DataRow DR in DB.DataSet.Tables[0].Rows)
                {
                    Items[count] = new JCPatternFile();
                    Items[count].GetData(int.Parse(DR["code"].ToString()));
                    count++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// دریافت 
        /// </summary>
        /// <returns></returns>
        public DataTable GetStorageLetterNo()
        {
            JDataBase db = new JDataBase();
            db.setQuery("select * FROM patternfile");
            return  db.Query_DataTable();
        }
        #endregion GetInfo
    }
}
