using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ClassLibrary
{
    /// <summary>
    /// برای ایجاد نود یک درخت از این کلاس استفاده میگردد
    /// </summary>
    public class JCustomTreeNode : JSystem
    {
        /// <summary>
        /// کد نود در بانک اطلاعاتی
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CodeName { get; set; }
        /// <summary>
        /// نام نود
        /// </summary>
        public string TitleName { get; set; }
        /// <summary>
        /// افزایش خودکار کد
        /// </summary>
        public bool AutoIncrement{ get; set; }
        /// <summary>
        /// کد پدر
        /// </summary>
        public int ParentCode
        {
            get
            {
                return (int)FieldsValue[ParentName];
            }
            set
            {
                FieldsValue[ParentName] = value;
            }
        }
        /// <summary>
        /// کد پیش فرض برای درج
        /// </summary>
        public int DefaultCode;
        /// <summary>
        /// 
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// لیست فیلدهای درخت در جدول همراه با مقادیر
        /// </summary>
        public IDictionary<string, object> FieldsValue = new Dictionary<string, object>();
        /// <summary>
        /// نام جدول در بانک اطلاعاتی
        /// </summary>
        private string _TableName = "tree";
        /// <summary>
        /// نحوه نمایش اطلاعات در درخت را مشخص میکند
        /// </summary>
        public string Pattern;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTableName"></param>
        
        public JCustomTreeNode(string pTableName,string pCodeName, string pTitleName, string pParentCodeName, IDictionary<string, object> pFieldsValue,string pPattern)
        {
            _TableName = pTableName;
            CodeName = pCodeName;
            TitleName = pTitleName;
            ParentName = pParentCodeName;
            Pattern = pPattern;
            foreach (KeyValuePair<string, object> 
                param in pFieldsValue)
            {
                FieldsValue.Add(param);
            }
        }

        /// <summary>
        /// فرزندان
        /// </summary>
        private int[] _ChildsCode;

        /// <summary>
        /// فرزندان نود
        /// </summary>
        public int[] ChildsCode
        {
            get
            {
                _GetChileds();
                return _ChildsCode;
            }
        }
        public void GetFields()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + _TableName + " WHERE 0=1");
                DB.Query_DataReader();
                for (int i = 0; i < DB.DataReader.FieldCount - 1; i++)
                {
                    Assembly asm = Assembly.GetAssembly(DB.DataSet.Tables[0].Columns[i].DataType);
                    object Value = asm.CreateInstance(DB.DataSet.Tables[0].Columns[i].DataType.Name, false, BindingFlags.Default, null, null, null, null);
                    FieldsValue.Add(DB.DataSet.Tables[0].Columns[i].Caption, Value);
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
        /// ویرایش اطلاعات یک نود
        /// </summary>
        /// <returns></returns>
        public Boolean Update(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string _FieldsNameValues = "";
                string Comma = "";
                foreach (KeyValuePair<string, object> param in FieldsValue)
                {
                    if (param.Key != "code")
                        _FieldsNameValues += Comma + param.Key + "=@" + param.Key;
                    Comma = ",";
                }
                string SQL = "UPDATE " + _TableName + " SET %FieldsNameValue% WHERE " + CodeName + "=" + pCode.ToString();
                SQL = SQL.Replace("%FieldsNameValue%", _FieldsNameValues);
                DB.AddParamsRang(FieldsValue);
                DB.setQuery(SQL);
                DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return true;
        }

        public int ImageIndex = 0;
        /// <summary>
        /// حذف نود به همراه فرزندان آن
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Delete(int pCode, bool DeleteChildren)
        {
            if (DeleteChildren)
            {
                Code = pCode;
                int[] _Children = ChildsCode;
                foreach (int ChildCode in _Children)
                {
                    Delete(ChildCode, true);
                }
            }
            if (!_HasChileds(pCode))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    string SQL = "DELETE FROM " + _TableName + " WHERE " + CodeName + "=" + pCode.ToString();
                    DB.setQuery(SQL);
                    DB.Query_Execute();
                }
                finally
                {
                    DB.Dispose();
                }
            }
            return true;
        }

        /// <summary>
        /// درج یک نود جدید در درخت
        /// </summary>
        /// <returns>کد درج شده در بانک اطلاعاتی</returns>
        public int Insert()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string _FieldsName = "";
                string _FieldsValue = "";
                string Comma = "";
                foreach (KeyValuePair<string, object> param in FieldsValue)
                {
                    _FieldsName += Comma + JDataBase.FieldSeparateLeft + param.Key + JDataBase.FieldSeparateRight;
                    _FieldsValue += Comma + '@' + param.Key;
                    Comma = ",";
                }
                string InsertSQL = "";
                if (AutoIncrement)
                    InsertSQL =
                        //@"declare @Code int "+
                        JDataBase.GetInsertSQL("%TableName%","%DefaultValue%",true)+

                        @"INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)
                        SELECT @Code";

                else
                    InsertSQL = @"INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)";

                InsertSQL = InsertSQL.Replace("%TableName%", _TableName);
                InsertSQL = InsertSQL.Replace("%FieldsName%", _FieldsName);
                InsertSQL = InsertSQL.Replace("%FieldsValue%", _FieldsValue);
                InsertSQL = InsertSQL.Replace("%DefaultValue%", DefaultCode.ToString());
                DB.AddParamsRang(FieldsValue);
                DB.setQuery(InsertSQL);
                return Convert.ToInt32(DB.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return -1;
        }

        public int Insert(int pParentCode)
        {
            this.ParentCode = pParentCode;
            return this.Insert();
        }

        public Boolean Find(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [Code] FROM " + _TableName + " WHERE "+CodeName+"=" + pCode.ToString());
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        ///  جستجوی نود بر اساس کد آبجکت و نام کلاس
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pObjectCode"></param>
        /// <returns></returns>
        public int Find(string pName)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT ["+CodeName+"] FROM " + _TableName + " WHERE " + TitleName + " Like" + JDataBase.Quote(pName));
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return Convert.ToInt32(DB.DataReader[CodeName]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public Boolean GetData(int pCode)
        {
            Code = pCode;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + _TableName + " WHERE "+CodeName+"=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    if (DB.DataReader.HasRows)
                    {
                        for (int i = 0; i < DB.DataReader.FieldCount ; i++)
                        {
                            FieldsValue[DB.DataReader.GetName(i)] = DB.DataReader[i];
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void _GetChileds()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [code] FROM " + _TableName + " WHERE "+ParentName+"=" + Code.ToString());
                DB.Query_DataReader();
                _ChildsCode = new int[DB.RecordCount];
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    _ChildsCode[Count++] = Int32.Parse(DB.DataReader["code"].ToString());
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

        private bool _HasChileds(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [code] FROM " + _TableName + " WHERE " + ParentName + "=" + pCode.ToString());
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public override string ToString()
        {
            if (Pattern == null)
            {
                return FieldsValue[TitleName].ToString();
            }
            string[] lFields = Pattern.Split(',');
            string lName = "";
            char Sp = '_';
            int Count = 0;
            foreach (string Field in lFields)
            {
                if (Count == 0)
                    lName = FieldsValue[Field.Trim()].ToString();
                else
                    lName += Sp + FieldsValue[Field.Trim()].ToString();
                Count++;
                //Sp = '_';
            }
            return lName;
        }

        public bool SetValue(string FieldName, object Value)
        {
            try
            {
                FieldsValue[FieldName] = Value;
                return true;
            }
            catch(Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }


    }

    public class JCustomTree : JSystem
    {
        private string _TableName;
        private string _CodeName;
        private string _TitleName;
        private string _ParentName;
        /// <summary>
        /// کد پیش فرض برای درج
        /// </summary>
        public int DefaultCode;
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }
        public bool AutoIncrement
        {
            get;
            set;
        }
        public string Pattern;

        public IDictionary<string, object> FieldsValue = new Dictionary<string, object>();

        public JCustomTree(string pTableName, string pCodeName, string pTitleName, string pParentName)
        {
            _TableName = pTableName;
            _CodeName = pCodeName;
            _TitleName = pTitleName;
            _ParentName = pParentName;
            GetFields();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFields"></param>
        /// <returns></returns>
        public JCustomTreeNode Insert(IDictionary<string, object> pFields)
        {
            JCustomTreeNode CTN = new JCustomTreeNode(_TableName,_CodeName,_TitleName,_ParentName,FieldsValue,Pattern);
            foreach (KeyValuePair<string, object> LocalField in pFields)
            {
                CTN.FieldsValue[LocalField.Key] = LocalField.Value;
            }
            CTN.AutoIncrement = AutoIncrement;
            int result = CTN.Insert();
            if (result > 0)
            {
                CTN.Code = result;
                return CTN;
            }
            else
                return null;
        }

        public bool Delete(int pCode, bool pDeleteChild)
        {
            JCustomTreeNode CTN = new JCustomTreeNode(_TableName, _CodeName, _TitleName, _ParentName, FieldsValue, Pattern);
            return CTN.Delete(pCode, pDeleteChild);
        }

        public JCustomTreeNode Update(IDictionary<string, object> pFields)
        {
            JCustomTreeNode CTN = new JCustomTreeNode(_TableName, _CodeName, _TitleName, _ParentName, FieldsValue, Pattern);
            foreach (KeyValuePair<string, object> LocalField in pFields)
            {
                CTN.FieldsValue[LocalField.Key] = LocalField.Value;
            }
            if (CTN.Update(Convert.ToInt32(CTN.FieldsValue[_CodeName])))
                return CTN;
            else
                return null;
        }

        public JCustomTreeNode[] GetChilds(int pParentCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT " + _CodeName + " FROM " + _TableName + " WHERE " + _ParentName + "=" + pParentCode.ToString());
                DB.Query_DataReader();
                JCustomTreeNode[] CTN = new JCustomTreeNode[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    CTN[count] = new JCustomTreeNode(_TableName, _CodeName, _TitleName, _ParentName, FieldsValue, Pattern);
                    CTN[count].Code = int.Parse(DB.DataReader[0].ToString());
                    CTN[count].GetData(CTN[count].Code);
                    count++;
                }
                return CTN;
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

        public System.Data.DataTable GetData()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + _TableName);
                return  DB.Query_DataTable();
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

        private void GetFields()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + _TableName + " WHERE 0=1");
                DB.Query_DataSet();
                for (int i = 0; i < DB.DataSet.Tables[0].Columns.Count ; i++)
                {
                    try
                    {
                        Assembly asm = Assembly.GetAssembly(DB.DataSet.Tables[0].Columns[i].DataType);
                        object Value = DB.DataSet.Tables[0].Columns[i].DefaultValue;
                            //asm.CreateInstance(DB.DataSet.Tables[0].Columns[i].DataType.FullName, false, BindingFlags.Default, null, null, null, null);
                        FieldsValue.Add(DB.DataSet.Tables[0].Columns[i].Caption, Value);
                    }
                    catch (Exception ex)
                    {
                        Except.AddException(ex);
                    }
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
    }
}
