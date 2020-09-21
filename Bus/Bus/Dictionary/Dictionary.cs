using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Dictionary
{
    public class JDictionary : JSystem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Lang { get; set; }

        public JDictionary()
        {
        }
        public JDictionary(int Code)
        {
            this.GetData(Code);
        }

        public bool GetData(int Code)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"with tbl as (
                    select rank() over (order by name asc) as code, name, text, lang from dic
                    )
                    select name, text, lang from tbl where code = " + Code);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    Name = DB.DataReader["name"].ToString();
                    Text = DB.DataReader["text"].ToString();
                    Lang = DB.DataReader["lang"].ToString();
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Dictionary.JDictionary.Insert"))
                return false;

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("insert into dic (name, text, lang) output inserted.* values(N'" + Name + "', N'" + Text + "', N'" + Lang + "')");
                DataTable dt = DB.Query_DataTable();
                if (dt == null || dt.Rows.Count == 0)
                    return false;
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JDictionary", 0, 0, 0, 0, "ثبت در لغت نامه ", "", 0);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Dictionary.JDictionary.Update"))
                return false;

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("update dic set text = N'" + Text + "' output inserted.text where name = N'" + Name + "' and lang = N'" + Lang + "'");
                DataTable dt = DB.Query_DataTable();
                if (dt == null || dt.Rows.Count == 0)
                    return false;
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JDictionary", 0, 0, 0, 0, "ویرایش در لغت نامه ", "", 0);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Dictionary.JDictionary.Delete"))
                return false;

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("delete from dic output deleted.*  where name = N'" + Name + "' and lang = N'" + Lang + "'");
                DataTable dt = DB.Query_DataTable();
                if (dt == null || dt.Rows.Count == 0)
                    return false;
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JDictionary", 0, 0, 0, 0, "حذف از لغت نامه ", "", 0);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }

    public class JDictionaries : JSystem
    {
        public static string GetWebQuery()
        {
            return "select rank() over (order by name asc) Code, name N'عبارت', text N'ترجمه', lang N'زبان' from dic";
        }
    }
}
