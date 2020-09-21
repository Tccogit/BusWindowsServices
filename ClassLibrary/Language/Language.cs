using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClassLibrary
{
    public class JLanguageNames : JSystem
    {
        public static string Farsi = "Fa";
        public static string English = "En";
        public static string Arabic = "Ar";
    }

    public class JLanguage : JSystem
    {
        public string name { get; set; }
        public string lang { get; set; }
        public string text { get; set; }

        public bool Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("INSERT INTO dic VALUES(@name,@text,@lang)");
                db.AddParams("@name", name);
                db.AddParams("@lang", lang);
                db.AddParams("@text", text);
                return db.Query_Execute() >= 0;
            }
            catch(Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("UPDATE dic SET [text]=@text WHERE [name]=@name AND [lang]=@lang");
                db.AddParams("@name", name);
                db.AddParams("@lang", lang);
                db.AddParams("@text", text);
                return db.Query_Execute() >= 0;
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

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("DELETE FROM dic  WHERE [name]=@name AND [lang]=@lang)");
                db.AddParams("@name", name);
                db.AddParams("@lang", lang);
                return db.Query_Execute() >= 0;
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

    }

    public class JLanguages: JSystem
    {
        private string Symbole = @"!@#$%^&*()-_=+\|`~[]{}'"";:/?.>,<";
        private string Digit = "1234567890";
        private string _Lang;

        private static DataTable _DT;
        public static DataTable DT
        {
            get
            {
                Load();
                return _DT;
            }
        }
        public JLanguages()
        {
        }

        public static void Load()
        {
            if (_DT == null || _DT.Rows.Count == 0)
            {
                _DT = new DataTable();

                var nameColumn = _DT.Columns.Add("name", typeof(string));
                var langColumn = _DT.Columns.Add("lang", typeof(string));
                _DT.Columns.Add().ColumnName = "text";

                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    DB.setQuery("SELECT [name],[text],[lang] FROM dic WHERE [lang]=" +
                        JDataBase.Quote(JLanguageNames.Farsi) + " ORDER BY [name]");
                    DataTable Temp = DB.Query_DataTable();
                    if (Temp != null)
                    {
                        Temp.TableName = "Language";
                        _DT = Temp.Copy();
                        Temp.Clear();
                        Temp.Dispose();
                    }

                    DataColumn[] keys = _DT.PrimaryKey.Clone() as DataColumn[];
                    DataColumn[] keysNew = new DataColumn[2];

                    keysNew[0] = _DT.Columns[nameColumn.ColumnName];
                    keysNew[1] = _DT.Columns[langColumn.ColumnName];

                    _DT.PrimaryKey = keysNew;

                    _DT.AcceptChanges();

                    DataView view = new DataView(_DT);
                    view.Sort = "name,lang";
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    DB.Dispose();
                }
            }
        }

        public static void Refresh()
        {
            if (_DT != null)
            {
                _DT.Clear();
                _DT.Dispose();
                _DT = null;
            }
            Load();
        }

        public static void Save()
        {
            foreach (DataRow DR in DT.Rows)
            {
                if (DR.RowState == DataRowState.Added)
                {
                    JLanguage Lan = new JLanguage();
                    Lan.name = DR["name"].ToString();
                    Lan.lang = DR["lang"].ToString();
                    Lan.text = DR["text"].ToString();
                    Lan.Insert();
                }
                else
                if (DR.RowState == DataRowState.Modified)
                {
                    JLanguage Lan = new JLanguage();
                    Lan.name = DR["name"].ToString();
                    Lan.lang = DR["lang"].ToString();
                    Lan.text = DR["text"].ToString();
                    Lan.Update();
                }
            }
            DT.AcceptChanges();
            Refresh();
        }

        public static string _Text(string PName)
        {
            if (PName == null) return "";
            try
            {
                if (PName.IndexOfAny(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }) < 0)
                    return PName;
                Load();
                string tempStr = "";
                if (PName.Contains(':'))
                {
                    tempStr = _Text(PName.Split(':')[0]) + ":";
                }
                else
                    if (PName.Contains("..."))
                {
                    tempStr = _Text(PName.Replace("...", "")) + "...";
                }
                else
                {

                    DataRow DRow = _DT.Rows.Find(new object[] { PName, "Fa" });

                    if (DRow != null)
                    {
                        return DRow["text"].ToString();
                    }
                    else
                        return PName;
                }
                return tempStr;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }

            return PName;
        }

        public static string _Farsi(string PName)
        {
            if (PName == null) return "";
            try
            {
                Load();
                string tempStr = "";
                if (PName.Contains(':'))
                {
                    tempStr = _Text(PName.Split(':')[0]) + ":";
                }
                else
                    if (PName.Contains("..."))
                {
                    tempStr = _Text(PName.Replace("...", "")) + "...";
                }
                else
                {
                    DataRow DRow = _DT.Rows.Find(new object[] { PName, "Fa" });

                    if (DRow != null)
                    {
                        return DRow["Name"].ToString();
                    }
                    else
                        return PName;
                }
                return tempStr;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }

            return PName;
        }
        /// <summary>
        /// جستجوی متنهایی که دارای پارامتر هستند
        /// </summary>
        /// <param name="PName"></param>
        /// <param name="Params"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static string _Text(string PName, string[] Params, object[] Values)
        {
            if (PName == null) return "";
            try
            {
                if (_DT == null)
                {
                    Load();
                }
                else
                {

                    //DataRow DRow = _DT.Rows.Find(new string[] { PName.ToLower(), JGlobal.MainFrame.GetConfig().CurrentLang });
                    //DataRow DRow = _DT.Select(" name =" +JDataBase.Quote(PName.ToLower()) + " AND lang=" + JDataBase.Quote(JGlobal.MainFrame.GetConfig().CurrentLang))[0];
                    string TempStr = "";
                    //if (DRow != null)
                    {
                        TempStr = _Text(PName);// DRow["text"].ToString();
                        for (int i = 0; i < Params.Length; i++)
                        {
                            TempStr = TempStr.Replace(Params[i], _Text(Values[i].ToString()));
                        }
                        return TempStr;
                    }
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            //لطفا  @Value را وارد کنید
            return PName;
        }
    }
}
