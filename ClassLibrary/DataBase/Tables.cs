using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// کلاسی برای انجام اتوماتیک کار بر روی بانکهای اطلاعاتی
    /// </summary>
    public class JTable : JCore
    {
        private bool _ComplexInsert = true;
        public void Set_ComplexInsert(bool pComplexInsert)
        {
            _ComplexInsert = pComplexInsert;
        }

        /// <summary>
        /// 
        /// </summary>
        const string QuerySQL = "SELECT top 100 percent %FieldsName% FROM %TableName% WHERE 1=1 %WHERE% %GROUP% %ORDER%";
        /// <summary>
        /// 
        /// </summary>
        private string InsertSQL()
        {
            return @"DECLARE @Code INT " +
            JDataBase.GetInsertSQL("%TableName%", "%DefaultValue%", _ComplexInsert) +
            @"
                INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)
                SELECT @Code";
        }
        private string InsertSQLWithManulaCode()
        {
            return @"INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)
                SELECT @Code";
        }

        const string InsertAutoIncCodeSQL =
                @"INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)
                SELECT @@IDENTITY;";

        const string InsertAutoIncCodeSQLFromView =
                @"INSERT INTO %TableName% (%FieldsName%) VALUES(%FieldsValue%)
                SELECT Code FROM %TableName% WHERE %WHERE%;";

        /// <summary>
        /// 
        /// </summary>
        const string DeleteSQL = "DELETE FROM %TableName% WHERE Code =%Code%";
        /// <summary>
        /// 
        /// </summary>
        const string DeleteManualSQL = "DELETE FROM %TableName% WHERE %WHERE%";
        /// <summary>
        /// 
        /// </summary>
        const string UpdateSQL = "UPDATE %TableName% SET %FielddNameValues% WHERE Code = %Code%";
        /// <summary>
        /// 
        /// </summary>
        const string UpdateManualSQL = "UPDATE %TableName% SET %FielddNameValues% WHERE %WHERE%";
        /// <summary>
        /// 
        /// </summary>
        private string _TableName;
        private string _FieldsName;
        private string _FieldsValue;
        private string _FieldsNameValues;
        private string _FieldsNameValuesWhere;
        /// <summary>
        /// را ثبت کنند null فیلد هایی که در صورت صفر بودن باید مقدار 
        /// </summary>
        private string[] _strNulledZeroFeilds;

        public int Code;
        private object _jclass;

        private int _DeleteCount = 0;
        public int GetDeleteCount()
        {
            return _DeleteCount;
        }
        private bool _isview;
        public bool IsView
        {
            get
            {
                return _isview;
            }
            set
            {
                _isview = value;
            }
        }

        private IDictionary<string, object> Params = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        public JTable(string PTbname)
        {
            _TableName = PTbname;
            _getFields();

        }
        /// <summary>
        /// 
        /// </summary>
        public JTable(string PTbname, string pStrNulledZeroFeilds)
        {
            _TableName = PTbname;
            _getFields();
            //--------------- شوند null تنظیم آرایه فیلدهایی که در صورت صفر بودن باید ---------------
            _strNulledZeroFeilds = pStrNulledZeroFeilds.Split(',');
        }

        private bool IS_NulledZeroFeilds(string pFeild)
        {
            if (_strNulledZeroFeilds == null)
                return false;

            for (int i = 0; i < _strNulledZeroFeilds.Length; i++)
            {
                if (_strNulledZeroFeilds[i].Trim() == pFeild)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// لیست فیلدهای کلاس را بر میگرداند
        /// </summary>
        /// <returns></returns>
        private Boolean _getFields()
        {
            Type type = GetType();
            FieldInfo[] finfo = type.GetFields();
            string Comma = "";
            string And = "";
            for (int count = 0; count < finfo.Length; count++)
            {
                _FieldsName += Comma + JDataBase.FieldSeparateLeft + finfo[count].Name + JDataBase.FieldSeparateRight;
                _FieldsValue += Comma + '@' + finfo[count].Name;
                if (finfo[count].Name.ToLower() != "code")
                    _FieldsNameValues += Comma + finfo[count].Name + "=@" + finfo[count].Name;
                if (finfo[count].Name.ToLower() != "code")
                    _FieldsNameValuesWhere += And + finfo[count].Name + "=@" + finfo[count].Name;
                Comma = ",";
                And = " AND ";
            }
            return true;
        }
        /// <summary>
        /// لیست فیلدهای کلاس را بر میگرداند
        /// </summary>
        /// <returns></returns>
        public static string getFields()
        {
            //Type type = GetType();
            //FieldInfo[] finfo = type.GetFields();
            //string Comma = "";
            //string FieldsName = "";
            //for (int count = 0; count < finfo.Length; count++)
            //{
            //    FieldsName += Comma + JDataBase.FieldSeparateLeft + finfo[count].Name + JDataBase.FieldSeparateRight;
            //    Comma = ",";
            //}
            //return FieldsName;
            return "*";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean _SetParams(bool pManual)
        {
            try
            {
                Params.Clear();
                Type type = GetType();
                FieldInfo[] finfo = type.GetFields();
                for (int count = 0; count < finfo.Length; count++)
                {
                    if (finfo[count].GetValue(this) == null || (JGeneral.is_Number(finfo[count].GetValue(this)) && Convert.ToDecimal(finfo[count].GetValue(this)) == 0 && IS_NulledZeroFeilds(finfo[count].Name)))
                        Params.Add('@' + finfo[count].Name, DBNull.Value);
                    else if (finfo[count].GetValue(this) is System.DateTime && ((DateTime)finfo[count].GetValue(this)).Year < 1900)
                        Params.Add('@' + finfo[count].Name, DBNull.Value);
                    else if (finfo[count].Name.ToLower() != "code")
                        Params.Add('@' + finfo[count].Name, finfo[count].GetValue(this));
                    else if (finfo[count].Name.ToLower() == "code")
                        if (pManual)
                            Params.Add('@' + finfo[count].Name, this.Code);
                }
            }
            catch
            {
            }
            return true;
        }

        private Boolean _SetParams()
        {
            return _SetParams(false);
        }

        private static int _HasColumn(JMyDataReader DR, string fieldName)
        {
            return _HasColumn(DR.DR, fieldName);
        }
            private static int _HasColumn(SqlDataReader DR, string fieldName)
            {
                for (int i = 0; i < DR.FieldCount; i++)
                if (DR.GetName(i).ToLower() == fieldName.ToLower())
                    return i;
            return -1;
        }
        private static int _HasColumn(DataRow DR, string fieldName)
        {
            try
            {
                return DR.Table.Columns.IndexOf(fieldName);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            //return 0;
        }
        /// <summary>
        /// مقادیر را از دیتابیس خوانده و در خواص متناظر کلاس ثبت میکند
        /// </summary>
        /// <param name="jclass"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        public static Boolean SetToClassProperty(object jclass, JMyDataReader DR)
        {
            return SetToClassProperty(jclass, DR.DR);
        }
            public static Boolean SetToClassProperty(object jclass, SqlDataReader DR)
        {
            Type type = jclass.GetType();
            PropertyInfo[] pinfo = type.GetProperties();
            object value;
            for (int count = 0; count < pinfo.Length; count++)
            {
                string pname = pinfo[count].Name;
                try
                {
                    if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                    {
                        if (pinfo[count].GetValue(jclass, null) is Enum)
                        {
                            if (DR[pname] is DBNull)
                            {
                                value = Assembly.GetAssembly(pinfo[count].PropertyType).CreateInstance(pinfo[count].PropertyType.Name);
                            }
                            else
                            {
                                Type eType = pinfo[count].PropertyType;
                                value = DR[pname];
                            }
                            //Convert.ChangeType(value, eType);
                            //value = Convert.ChangeType(DR[pname], pinfo[count].PropertyType);
                        }
                        else
                        {
                            if (DR[pname] is DBNull)
                            {
                                value = Assembly.GetAssembly(pinfo[count].PropertyType).CreateInstance(pinfo[count].PropertyType.Name);
                            }
                            else
                            {
                                try
                                {
                                    value = Convert.ChangeType(DR[pname], pinfo[count].PropertyType);
                                }
                                catch
                                {
                                    value = Assembly.GetAssembly(pinfo[count].PropertyType).CreateInstance(pinfo[count].PropertyType.Name);
                                }
                            }
                        }
                        pinfo[count].SetValue(jclass, value, null);
                    }
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jclass"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        public static Boolean SetToClassField(object jclass, JMyDataReader DR)
        {
            return SetToClassField(jclass, DR.DR);
        }
            public static Boolean SetToClassField(object jclass, SqlDataReader DR)
            {
                Type type = jclass.GetType();
            FieldInfo[] pinfo = type.GetFields();
            for (int count = 0; count < pinfo.Length; count++)
            {
                string pname = pinfo[count].Name;
                try
                {
                    if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                    {
                        if (!(DR[pname] is DBNull && pinfo[count].FieldType.ToString() == "System.Int32"))
                        {
                            object value = Convert.ChangeType(DR[pname], pinfo[count].FieldType);
                            pinfo[count].SetValue(jclass, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            return true;
        }
        /// <summary>
        /// مقادیر را از دیتابیس خوانده و در خواص متناظر کلاس ثبت میکند
        /// </summary>
        /// <param name="jclass"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        public static Boolean SetToClassProperty(object jclass, DataRow DR)
        {
            Type type = jclass.GetType();
            PropertyInfo[] pinfo = type.GetProperties();
            for (int count = 0; count < pinfo.Length; count++)
            {
                string pname = pinfo[count].Name;
                try
                {
                    if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                    {
                        object value;
                        try
                        {
                            value = Convert.ChangeType(DR[pname], pinfo[count].PropertyType);
                        }
                        catch
                        {
                            object vobject = pinfo[count].PropertyType.Assembly.CreateInstance(pinfo[count].PropertyType.FullName);
                            if (vobject is Enum)
                            {
                                value = Enum.ToObject(vobject.GetType(), DR[pname]);
                            }
                            else
                            {
                                value = vobject;
                            }
                        }
                        pinfo[count].SetValue(jclass, value, null);
                    }
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jclass"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        public static Boolean SetToClassField(object jclass, DataRow DR)
        {
            Type type = jclass.GetType();
            FieldInfo[] pinfo = type.GetFields();
            for (int count = 0; count < pinfo.Length; count++)
            {
                string pname = pinfo[count].Name;
                try
                {
                    if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                    {
                        object value;
                        try
                        {
                            value = Convert.ChangeType(DR[pname], pinfo[count].FieldType);
                        }
                        catch
                        {
                            object vobject = pinfo[count].FieldType.Assembly.CreateInstance(pinfo[count].FieldType.FullName);
                            if (vobject is Enum)
                            {
                                value = Enum.ToObject(vobject.GetType(), DR[pname]);
                            }
                            else
                            {
                                value = vobject;
                            }
                        }
                        pinfo[count].SetValue(jclass, value);
                    }
                }
                catch (Exception ex)
                {
                    // Except.AddException(ex);
                }
            }
            return true;
        }
        /// <summary>
        /// انتقال اطلاعات از کلاس به دیتا
        /// </summary>
        /// <param name="jclass"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        public static Boolean SetToDataRow(object jclass, DataRow DR)
        {
            Type type = jclass.GetType();
            PropertyInfo[] pinfo = type.GetProperties();
            for (int count = 0; count < pinfo.Length; count++)
            {
                string pname = pinfo[count].Name;
                try
                {
                    if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                        DR[pname] = pinfo[count].GetValue(jclass, null);
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            return true;
        }
        /// <summary>
        /// مقادیر خواص یک کلاس را در فیلدهای این کلاس ذخیره می کند
        /// </summary>
        /// <param name="jclass"></param>
        /// <returns></returns>
        public Boolean SetValueProperty(object jclass)
        {
            return SetValue(jclass, true); ;
        }

        /// <summary>
        /// مقادیر فیلدهای یک کلاس را در فیلدهای این کلاس ذخیره می کند
        /// </summary>
        /// <param name="jclass"></param>
        /// <returns></returns>
        public Boolean SetValueField(object jclass)
        {
            return SetValue(jclass, false); ;
        }


        private Boolean SetValue(object jclass, bool IsProperty)
        {
            _jclass = jclass;
            string[] Fields = _FieldsName.Split(',');
            Type type = jclass.GetType();
            PropertyInfo[] pinfo;
            FieldInfo[] finfo;
            pinfo = type.GetProperties();
            finfo = type.GetFields();
            string Comma = "";
            for (int count = 0; count < Fields.Length; count++)
            {
                int i = 0;
                int Len;
                if (IsProperty)
                    Len = pinfo.Length;
                else
                    Len = finfo.Length;
                while (i < Len)
                {
                    string pname;
                    if (IsProperty)
                        pname = JDataBase.FieldSeparateLeft + pinfo[i++].Name + JDataBase.FieldSeparateRight;
                    else
                        pname = JDataBase.FieldSeparateLeft + finfo[i++].Name + JDataBase.FieldSeparateRight;
                    if (pname.Trim().ToLower() == Fields[count].Trim().ToLower())
                    {
                        try
                        {
                            object Value = null;
                            if (IsProperty)
                            {
                                if (pinfo[i - 1].Name.ToLower() == "code")
                                    Code = (int)pinfo[i - 1].GetValue(jclass, null);
                                else if (pinfo[i - 1].GetValue(jclass, null) is Enum)
                                {
                                    Value = pinfo[i - 1].GetValue(jclass, null);
                                    if (Value != null)
                                        Value = int.Parse(((Enum)Value).GetHashCode().ToString());
                                }
                                else
                                {
                                    Value = pinfo[i - 1].GetValue(jclass, null);
                                }
                                Type typeTemp = GetType();
                                FieldInfo finfoTemp = typeTemp.GetField(pinfo[i - 1].Name);
                                if (pinfo[i - 1].Name.ToLower() != "code")
                                    finfoTemp.SetValue(this, Value);
                            }
                            else
                            {
                                if (finfo[i - 1].Name.ToLower() == "code")
                                    Code = (int)finfo[i - 1].GetValue(jclass);
                                else if (finfo[i - 1].GetValue(jclass) is Enum)
                                {
                                    Value = finfo[i - 1].GetValue(jclass);
                                    Value = ((Enum)Value).GetHashCode().ToString();
                                }
                                else
                                {
                                    Value = finfo[i - 1].GetValue(jclass);
                                }
                                Type typeTemp = GetType();
                                FieldInfo finfoTemp = typeTemp.GetField(finfo[i - 1].Name);
                                if (finfo[i - 1].Name.ToLower() != "code")
                                    finfoTemp.SetValue(this, Value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Except.AddException(ex);
                        }
                        i = Len;
                    }
                }
            }
            return true;
        }
        /// ساخت اسکیول درج
        /// </summary>
        /// <returns></returns>
        private string CreayeInsert(int DefaultCode, bool pAutoIncrement, Boolean pManual, bool pIsView = false)
        {
            if (_FieldsValue == null)
                return null;
            string SQL;
            if (pAutoIncrement && !pIsView)
                SQL = InsertAutoIncCodeSQL;
            else
            if (pAutoIncrement && pIsView)
                SQL = InsertAutoIncCodeSQLFromView;
            else
                if (pManual)
                SQL = InsertSQLWithManulaCode();
            else
                SQL = InsertSQL();
            SQL = SQL.Replace("%TableName%", _TableName);
            if (pAutoIncrement)
            {
                SQL = SQL.Replace("%FieldsName%", _FieldsName.Replace(",[Code]", ""));
                SQL = SQL.Replace("%FieldsValue%", _FieldsValue.Replace(",@Code", ""));
                if (pIsView)
                {
                    SQL = SQL.Replace("%WHERE%", _FieldsNameValuesWhere.Replace(",@Code", ""));
                }
            }
            else
            {
                SQL = SQL.Replace("%FieldsName%", _FieldsName);
                SQL = SQL.Replace("%FieldsValue%", _FieldsValue);
            }
            SQL = SQL.Replace("%DefaultValue%", DefaultCode.ToString());
            return SQL;
        }
        /// <summary>
        /// ساخت اسکیول ویرایش
        /// </summary>
        /// <returns></returns>
        private string CreayeUpdate(bool pManual, string pWhere)
        {
            if (_FieldsNameValues == null)
                return null;
            string SQL;
            if (pManual)
                SQL = UpdateManualSQL;
            else
                SQL = UpdateSQL;
            SQL = SQL.Replace("%TableName%", _TableName);
            SQL = SQL.Replace("%FielddNameValues%", _FieldsNameValues);
            SQL = SQL.Replace("%Code%", Code.ToString());
            SQL = SQL.Replace("%WHERE%", pWhere);

            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string CreateQuery(string pWhere)
        {
            return CreateQuery(pWhere, "", "", "");
        }
        /// <summary>
        /// ساخت اسکیول
        /// </summary>
        /// <returns></returns>
        public string CreateQuery(string where, string pFields, string pOrder, string pGroup)
        {
            if (where.Length > 0 && where.Trim().IndexOf("and", StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                where =

                    " and " + where;
            }
            string SQL = QuerySQL;
            SQL = SQL.Replace("%TableName%", _TableName);
            if (pFields.Length > 0)
                SQL = SQL.Replace("%FieldsName%", pFields);
            else
                SQL = SQL.Replace("%FieldsName%", _FieldsName);
            SQL = SQL.Replace("%WHERE%", where);
            if (pOrder.Length > 0)
                pOrder = " ORDER BY " + pOrder;
            SQL = SQL.Replace("%ORDER%", pOrder);
            if (pGroup.Length > 0)
                pGroup = " GROUP BY " + pGroup;
            SQL = SQL.Replace("%GROUP%", pGroup);
            return SQL;
        }
        /// <summary>
        /// ساخت اسکیول حذف
        /// </summary>
        /// <returns></returns>
        private string CreayeDelete()
        {
            return CreayeDelete(false, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pManual"></param>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        private string CreayeDelete(bool pManual, string pWhere)
        {
            string SQL;
            if (pManual)
                SQL = DeleteManualSQL;
            else
                SQL = DeleteSQL;
            SQL = SQL.Replace("%TableName%", _TableName);
            SQL = SQL.Replace("%Code%", Code.ToString());
            SQL = SQL.Replace("%WHERE%", pWhere);
            return SQL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int Insert()
        {
            return Insert(0);
        }
        public virtual int Insert(int DefaultValue)
        {
            return Insert(DefaultValue, null, false);
        }
        public virtual int Insert(JDataBase db)
        {
            return Insert(0, db, false);
        }
        public virtual int InsertManual()
        {
            return Insert(0, null, false, false, true);
        }
        public virtual int InsertManual(JDataBase db)
        {
            return Insert(0, db, false, false, true);
        }
        public virtual int Insert(int DefaultValue, bool pAutoIncrement)
        {
            return Insert(DefaultValue, null, pAutoIncrement);
        }

        public virtual int Insert(int DefaultValue, JDataBase db, bool pAutoIncrement)
        {
            return Insert(DefaultValue, db, pAutoIncrement, true);
        }
        public virtual int Insert(int DefaultValue, JDataBase db, bool pAutoIncrement, bool isLog)
        {
            return Insert(DefaultValue, db, pAutoIncrement, isLog, false);
        }

        public int InsertException(int DefaultValue, bool pAutoIncrement)
        {
            return Insert(DefaultValue, null, pAutoIncrement, true, false, false);
        }
        public virtual int Insert(int DefaultValue, JDataBase db, bool pAutoIncrement, bool isLog, bool pManual)
        {
            return Insert(DefaultValue, db, pAutoIncrement, isLog, pManual, true);
        }
        //------------------------------------------------------------------------------------------
        /// <summary>
        /// درج اطلاعات در جدول
        /// </summary>
        /// <param name="DefaultValue">مقدار پیش فرض</param>
        /// <param name="db">کانکشن به بانک</param>
        /// <returns></returns>
        public virtual int Insert(int DefaultValue, JDataBase db, bool pAutoIncrement, bool isLog, bool pManual, bool pAddException)
        {
            _SetParams(pManual);
            // متغیر برای تست اینکه کانکشن در تابع ایجاد می شود یا از پارامتر غیر تهی آمده است
            bool ReceiveConnection = true;
            if (db == null)
            {
                db = JGlobal.MainFrame.GetDBO();
                ReceiveConnection = false;
            }

            string SQL = CreayeInsert(DefaultValue, pAutoIncrement, pManual, IsView);
            try
            {
                //db.AutoTrans = true;

                db.setQuery(@SQL);
                db.AddParamsRang(Params);
                object ret = db.Query_ExecutSacler(true, pAddException);
                if (ret == null)
                    return 0;
                int retCode = int.Parse(ret.ToString());
				if (isLog && retCode > 0)
				{
					//JHistory H = new JHistory();
					//H.ClassName = "ClassLibrary.JTable";
					//H.ObjectCode = 0;
					//H.Save(this, this, Code);
				}
                try
                {
                    if (!pManual)
                        Code = retCode;
                    if (Code > 0)
                    {
                        try
                        {
                            if (JSystem.Nodes != null && JSystem.Nodes.DataTable != null)
                            {
                                //JSystem.Nodes.DataTable.Rows.Add(this.GetRow(JSystem.Nodes.DataTable));
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                        }
                    }
                    //Type type = _jclass.GetType();
                    //FieldInfo finfo = type.GetField("Code");
                    //if (finfo != null)
                    //    finfo.SetValue(_jclass, retCode);
                    //else
                    //{
                    //    PropertyInfo pinfo = type.GetProperty("Code");
                    //    pinfo.SetValue(_jclass, retCode, null);
                    //}
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
                return retCode;
            }
            catch (Exception ex)
            {
                if (ReceiveConnection)
                {
                    //db.Rollback(db.TransactionName);
                }
                Except.AddException(ex);
            }
            finally
            {
                //--
               //--- --------- در صورتی که کانکشن دریافتی باشد آنرا خراب نمی کند بدلیل اینکه ممکن است ترنسکشن داشته باشد
                if (!ReceiveConnection)
                    db.Dispose();
            }
            return 0;
        }
        //------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Delete()
        {
            return Delete(false, "", null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean DeleteManual(string pWhere)
        {
            return Delete(true, pWhere, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public Boolean DeleteManual(string pWhere, ref int pExec)
        {
            return Delete(true, pWhere, null, ref pExec);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Delete(JDataBase pDB)
        {
            return Delete(false, "", pDB);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean DeleteManual(string pWhere, JDataBase pDB)
        {
            return Delete(true, pWhere, pDB);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public Boolean DeleteManual(string pWhere, JDataBase pDB, ref int pExec)
        {
            return Delete(true, pWhere, pDB, ref pExec);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Delete(bool pManual, string pWhere, JDataBase pDB)
        {
            int exec = 0;
            return Delete(pManual, pWhere, pDB, ref exec);
        }
        public Boolean Delete(bool pManual, string pWhere, JDataBase pDB, ref int pExec)
        {
            _SetParams();
            string SQL = CreayeDelete(pManual, pWhere);
            JDataBase db;
            if (pDB == null)
                db = JGlobal.MainFrame.GetDBO();
            else
                db = pDB;


            int Exec = 0;
            try
            {
                //if (pDB == null)
                //db.beginTransaction("Delete_Table");
                db.setQuery(SQL);
                db.AddParamsRang(Params);
                Exec = db.Query_Execute();

                if (Exec > 0)
                {
                    //JHistory H = new JHistory();
                    //H.ClassName = "ClassLibrary.JTable";
                    //H.ObjectCode = 0;
                    //H.Save(this, this, Code);
                }

                //if (pDB == null)
                //db.Commit();
            }
            catch (Exception ex)
            {
                Exec = -1;
                _DeleteCount = -1;
                //if (pDB == null)
                //db.Rollback(db.TransactionName);
                JSystem.Except.AddException(ex);
            }
            finally
            {
                pExec = Exec;
                if (pDB == null)
                    db.Dispose();
            }
            _DeleteCount = Exec;
            return Exec > 0;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            return Update(null, false, "");
        }
        public Boolean Updateit1()
        {
            return Update(null, false, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean UpdateManual(string pWhere)
        {
            return Update(null, true, pWhere);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public Boolean Update(JDataBase db)
        {
            return Update(db, false, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public Boolean UpdateManual(JDataBase db, string pWhere)
        {
            return Update(db, true, pWhere);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Update(JDataBase db, bool pManual, string pWhere)
        {
            _SetParams();
            // متغیر برای تست اینکه کانکشن در تابع ایجاد می شود یا از پارامتر غیر تهی آمده است
            bool ReceiveConnection = true;
            if (db == null)
            {
                db = JGlobal.MainFrame.GetDBO();
                ReceiveConnection = false;
            }

            bool Exec = false;

            string SQL = CreayeUpdate(pManual, pWhere);

            try
            {
                if (!ReceiveConnection)
                {
                    //db.beginTransaction("Update_Table");
                }
                db.setQuery(SQL);
                db.AddParamsRang(Params);
                Exec = db.Query_Execute() >= 0;

                if (!ReceiveConnection)
                //if (db.Commit())
                {
                    Exec = true;//Azimian
                }

                if (Exec)
                {
                    //JHistory H = new JHistory();
                    //H.ClassName = "ClassLibrary.JTable";
                    //H.ObjectCode = 0;
                    //H.Save(this, this, Code);
                }

                if (Exec)
                {
                    try
                    {
                        if (JSystem.Nodes != null && JSystem.Nodes.CurrentNode != null && JSystem.Nodes.CurrentRows != null)
                        {
                            //JSystem.Nodes.Refreshdata(JSystem.Nodes.CurrentNode, this.SetRow(JSystem.Nodes.CurrentRows[0]));

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }
                //Exec = true;
            }
            catch (Exception ex)
            {
                //db.Rollback(db.TransactionName);
                Exec = false;
                JSystem.Except.AddException(ex);
            }
            finally
            {
                if (!ReceiveConnection)
                    db.Dispose();
            }

            return Exec;
        }

        public bool Find(int pCode)
        {
            string SQL = CreateQuery("Code = " + pCode.ToString(), "Code", "", "");
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(SQL);
                return DB.Query_DataTable().Rows.Count == 1;
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

        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public DataTable GetDataTable(int pCode)
        {

            string _where = "";
            if (pCode > 0)
                _where = "Code = " + pCode.ToString();
            string SQL = CreateQuery(_where, "", "", "");
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(SQL);
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }

        }
        public Boolean GetData(object jclass, int pCode)
        {
            JMyDataReader DR;
            string SQL = CreateQuery("Code = " + pCode.ToString(), "", "", "");
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(SQL);
                if (DB.Query_DataReader() && DB.DataReader.Read())
                    DR = DB.DataReader;
                else
                    return false;

                Type type = jclass.GetType();
                PropertyInfo[] pinfo = type.GetProperties();
                for (int count = 0; count < pinfo.Length; count++)
                {
                    string pname = pinfo[count].Name;
                    try
                    {
                        if (_HasColumn(DR, pname) >= 0 && DR[pname] != null)
                        {
                            object value;
                            try
                            {
                                value = Convert.ChangeType(DR[pname], pinfo[count].PropertyType);
                            }
                            catch
                            {
                                object vobject = pinfo[count].PropertyType.Assembly.CreateInstance(pinfo[count].PropertyType.FullName);
                                if (vobject is Enum)
                                {
                                    value = Enum.ToObject(vobject.GetType(), DR[pname]);
                                }
                                else
                                {
                                    value = vobject;
                                }
                            }
                            pinfo[count].SetValue(jclass, value, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Except.AddException(ex);
                    }
                }
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable Query(string pWhereSQL, JDataBase pDB)
        {
            return Query(pWhereSQL, "", "", "", pDB);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pWhereSQL"></param>
        /// <returns></returns>
        public DataTable Query(string pWhereSQL)
        {
            return Query(pWhereSQL, "", "", "", null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereSQL"></param>
        /// <param name="Fields"></param>
        /// <param name="pOrder"></param>
        /// <param name="pGroup"></param>
        /// <returns></returns>
        public DataTable Query(string whereSQL, string Fields, string pOrder, string pGroup, JDataBase pDB)
        {
            bool setpDB = pDB == null;
            try
            {
                string where = "";
                if (whereSQL != null && whereSQL.Length > 0)
                    where = " AND " + whereSQL;
                string SQL = CreateQuery(where, Fields, pOrder, pGroup);
                if (pDB == null)
                    pDB = JGlobal.MainFrame.GetDBO();
                pDB.setQuery(SQL);
                return pDB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (setpDB)
                    pDB.Dispose();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public DataRow GetRow(DataTable pDT)
        {
            if (pDT.Columns.IndexOf("Code") < 0) return null;
            _SetParams();
            DataRow dr = pDT.NewRow();
            try
            {
                string[] fields = _FieldsName.Replace('[', ' ').Replace(']', ' ').Trim().Split(',');
                foreach (string field in fields)
                {
                    try
                    {
                        if (field.Trim() == "Code")
                            dr["Code"] = Code;
                        else
                            if (pDT.Columns.IndexOf(field.Trim()) >= 0)
                        {
                            dr[field.Trim()] = Params["@" + field.Trim()];
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Except.AddException(e);
            }
            return dr;
        }

        public void CopyRow(DataTable pMainDT, DataTable pAdded)
        {
            //_SetParams();
            //DataRow dr = pAdded.NewRow();
            try
            {
                pMainDT.Merge(pAdded);
                //foreach (DataRow MainDR in pMainDT.Rows)
                //{
                //    foreach (DataColumn field in pAdded.Columns)
                //    {
                //        try
                //        {
                //            dr[field] = MainDR[field];
                //        }
                //        catch (Exception ex)
                //        {
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                Except.AddException(e);
            }
            return;
        }


        public static void CopyRow(DataRow pSuorce, DataRow pDestination)
        {
            try
            {
                foreach (DataColumn field in pSuorce.Table.Columns)
                {
                    try
                    {
                        pDestination[field.ColumnName] = pSuorce[field.ColumnName];
                    }
                    catch (Exception ex)
                    {
                        Except.AddException(ex);
                    }
                }
            }

            catch (Exception e)
            {
                Except.AddException(e);
            }
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDR"></param>
        /// <returns></returns>
        public DataRow SetRow(DataRow pDR)
        {
            try
            {
                pDR.BeginEdit();
                string[] fields = _FieldsName.Replace('[', ' ').Replace(']', ' ').Trim().Split(',');
                foreach (string field in fields)
                {
                    if (field.Trim() == "Code")
                        pDR["Code"] = Code;
                    else
                        if (pDR.Table.Columns.IndexOf(field.Trim()) >= 0)
                    {
                        pDR[field.Trim()] = Params["@" + field.Trim()];
                    }
                }
                pDR.EndEdit();
                pDR.Table.AcceptChanges();
            }
            catch (Exception e)
            {
                pDR.CancelEdit();
                Except.AddException(e);
            }
            return pDR;
        }

        public DataTable GetEmptyDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return GetEmptyDataTable(DB);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public DataTable GetEmptyDataTable(JDataBase pDB)
        {
            return Query(" 1=0 ", pDB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetXML()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return GetXML(DB);
            }
            finally
            {
                DB.Dispose();
            }

        }

        public string GetXML(JDataBase pDB)
        {
            DataTable DT = GetEmptyDataTable(pDB);
            DT.TableName = "CurrentRow";
            DataRow DR = GetRow(DT);
            DT.Rows.Add(DR);

            //DataSet DS = new DataSet();
            //DS.Tables.Add(DT);

            System.Xml.XmlDocument XD = JSerialization.SerilizeXML(DT);// new System.Xml.XmlDataDocument(DS);
            //System.Xml.XmlDocument XD = new System.Xml.XmlDataDocument(DS);

            return XD.InnerXml;
        }

        public static DataTable Join(DataTable D1, DataTable D2)
        {
            DataTable N = D1.Clone();
            foreach (DataColumn _DC in D2.Columns)
            {
                if (N.Columns.IndexOf(_DC.ColumnName) >= 0)
                {
                    _DC.ColumnName += "2";
                }
                N.Columns.Add(_DC.ColumnName, _DC.DataType, _DC.Expression);
            }

            foreach (DataRow _DR1 in D1.Rows)
                foreach (DataRow _DR2 in D2.Rows)
                {
                    DataRow NR = N.NewRow();
                    JTable.CopyRow(_DR1, NR);
                    JTable.CopyRow(_DR2, NR);
                    N.Rows.Add(NR);
                }

            return N;
        }

    }
}
