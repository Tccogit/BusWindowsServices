using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JFormUserPostCode
    {
        #region Constructor
        public JFormUserPostCode()
        {
        }
        #endregion

        #region Method
        public void Insert(int FormCode, int User_Post_Code)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Insert into FormUserPostCode(FormCode, User_Post_Code) VALUES(" + FormCode.ToString() + ", " + User_Post_Code.ToString() + ")");
                db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }

        public void DeleteByFormCode(int FormCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From FormUserPostCode Where FormCode = " + FormCode.ToString());
                db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        #region GetData
        public DataTable GetData(int FormCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select User_Post_Code From FormUserPostCode Where FormCode = " + FormCode.ToString());
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion
    }
}
