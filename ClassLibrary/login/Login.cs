using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JLogin: JCore
    {
        public Boolean HasLogin = false;

        public JLogin()
        {
        }

        public Boolean Login(string pUserName, string pPassword)
        {
            if (CheckUserNamePass(pUserName, pPassword) > 0)
            {
                return true;
            }
            return false;
        }

        private Boolean _ActiveUser(JUser pUser)
        {
            try
            {
                pUser.Active = true;
                pUser.Guide = GuidCode.ToString();
                pUser.Update();
                JMainFrame.CurrentUserCode = pUser.code;
                return true;
            }
            catch(Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// بررسی نام کاربری و کلمه عبور، همزمان پراپرتی ها نیز ست میشوند
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int CheckUserNamePass(string pUserName, string pPassword)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT pcode FROM " + JTableNamesClassLibrary.UsersTable + " WHERE [username] = " + JDataBase.Quote(pUserName) +
                        " AND password=" + JDataBase.Quote(JEnryption.EncryptStr(pPassword)));
                db.Query_DataReader();
                if (db.RecordCount > 0)
                {
                    if (db.Query_DataReader() && db.DataReader.Read())
                    {
                        JMainFrame.CurrentUserCode = Convert.ToInt32(db.DataReader["pcode"]);
                        return Convert.ToInt32(db.DataReader["pcode"]);
                    }
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void Show()
        {
            JLoginForm LForm = new JLoginForm();
            LForm.ShowDialog();
        }
    }
}
