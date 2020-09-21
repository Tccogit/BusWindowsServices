using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Data.SqlTypes;
using System.Security.Principal;
using System.DirectoryServices;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// این کلاس برای ارتباط با بانک اطلاعاتی میباشد
    /// </summary>
    public class JMySQLDataBase : JCore
    {
        public static volatile List<JMySQLDataBase> DataBases = new List<JMySQLDataBase>();
        public static string setQuerySQLs = "";
        public static volatile int Counter;
        /// <summary>
        /// 
        /// </summary>
        private static JConfig _Config ;
        private string _ServerName;
        private DateTime _ConnectTime;
        public DateTime ConnectTime
        {
            get
            {
                return _ConnectTime;
            }
        }
        #region Constructor
        /// <summary>
        /// ساخت یک کلاس از دیتابیس
        /// </summary>
        public JMySQLDataBase(MySqlConnection pSqlConnectionStringBuilder)
        {
            _ServerName = pSqlConnectionStringBuilder.DataSource;
            _cnStrBuilder = pSqlConnectionStringBuilder;
            CreateConnection();
        }

        public JMySQLDataBase(string pHost, string pUser, string pPass, string pDataBase)
        {
            ConectionStringBuilder(pHost, pUser, pPass, pDataBase);
            CreateConnection();
        }

        public JMySQLDataBase(JConnection pCN)
            : this(pCN.ServerName, pCN.UserName, pCN.Password, pCN.DataBaseName)
        {
        }

        #endregion


        #region Properties
        
        /// <summary>
        /// گزارش کلاس که در دستورات مختلف از آن استفاده میگردد
        /// </summary>
        private string _SQL;
        /// <summary>
        /// 
        /// </summary>
        public string SQL
        {
            get
            {
                return _SQL;
            }
        }
        /// <summary>
        /// کانکشن اصلی اتصال به بانک اطلاعاتی
        /// </summary>
        public MySqlConnection cn;
        /// <summary>
        /// ساخت یک کانکشن برای ارتباط با بانک اطلاعاتی
        /// </summary>
        private MySqlConnection _cnStrBuilder;
        /// <summary>
        ///  ساخت 
        ///  SqlConnectionString
        ///  مربوط به کانکشن
        /// </summary>
        public MySqlConnection cnStrBuilder
        {
            get
            {
                CreateConnection();
                return _cnStrBuilder;
            }
        }
        /// <summary>
        /// DataReader 
        /// مربوط به کلاس را که قبلا توسط تابع
        /// Query_DataReader()
        /// ساخته شده را برمیگرداند
        /// </summary>
        public MySqlDataReader DataReader
        {
            get
            {
                return _DataReader;
            }
        }

        /// <summary>
        /// DataSet 
        /// مربوط به کلاس را که قبلا توسط تابع
        /// Query_DataSet()
        /// ساخته شده را برمیگرداند
        /// </summary>
        public DataSet DataSet
        {
            get
            {
                return _DataSet;
            }
        }

        public string TransactionName
        {
            get
            {
                return _TransactionName;
            }
        }
        /// <summary>
        /// تعداد رکوردهای کلاس
        /// </summary>
        public int RecordCount
        {
            get
            {
                if (_RecordCount == -1)
                    _getRecordCount();
                return _RecordCount;
            }
        }
        public MySqlTransaction Transaction
        {
            get
            {
                return _Transaction;
            }
        }

        public IDictionary<string, object> Params = new Dictionary<string, object>();

        public DataTable datatable;
        #endregion

        #region Fields
        /// <summary>
        /// ترنزکشن
        /// </summary>
        private MySqlTransaction _Transaction;
        public static int _numTransaction;
        public static bool isTransaction
        {
            get
            {
                return _numTransaction > 0;
            }
        }

        /// <summary>
        /// نام تراکنش
        /// </summary>
        private string _TransactionName;
        private MySqlDataReader _DataReader;

        /// <summary>
        /// 
        /// </summary>
        private DataSet _DataSet;


        private Timer ConnectionLive = new Timer();

        private int _RecordCount;

        /// <summary>
        /// 
        /// </summary>
        public static readonly string FieldSeparateRight = @"]";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string FieldSeparateLeft = @"[";
        #endregion

        #region Private Functions
        private void ConectionStringBuilder(string pHost,string pUser,string pPass,string pDataBase)
        {
            _cnStrBuilder = new MySqlConnection();
            _cnStrBuilder.ConnectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; Allow Zero Datetime=true;charset=utf8 ;",
                pHost, pUser, pPass, pDataBase);

        }
        /// <summary>
        /// ساخت کانکشن برای ارتباط با بانک اطلاعاتی
        /// </summary>
        /// <returns>درست یا غلط</returns>
        private Boolean CreateConnection()
        {
            try
            {
                string Name = WindowsIdentity.GetCurrent().Name;
                Random Ran = new Random();
                if (Ran.Next(40) == 32)
                    if (!JFreeClass.Check())
                        JFreeClass.hangProgram();
                _RecordCount = -1;
                if (cn != null)
                    return true;
                cn = new MySqlConnection();
                cn.ConnectionString = _cnStrBuilder.ConnectionString;
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }


        /// <summary>
        /// دریافت تعداد رکوردهای گزارش 
        /// </summary>
        /// <returns></returns>
        private int _getRecordCount()
        {
            try
            {
                _RecordCount = -1;
                if (Connect())
                {
                    string SQLCount = "SELECT count(*) AS Record_Count FROM (" + _SQL + ") AS SQLCOUNT";
                    object ret;
                    ret = _Query_ExecutSacler(SQLCount);
                    if (ret != null)
                        _RecordCount = (int)ret;
                    else
                    {
                        DataTable _DT = _Query_DataTable(_SQL);
                        _RecordCount = _DT.Rows.Count;
                    }
                }
                return _RecordCount;
            }
            catch (Exception ex)
            {
                if (_TransactionName != null)
                    Rollback(TransactionName);
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        # region Transaction Functions
        /// <summary>
        /// یک ترانزکشن با یک نام مشخص را آغاز می کند
        /// </summary>
        /// <param name="name">Transaction Name</param>
        /// <returns></returns>
        public Boolean beginTransaction(string name)
        {
            try
            {
                if (cn == null)
                    CreateConnection();
                Connect();
                _Transaction = cn.BeginTransaction();
                _TransactionName = name;
                SetTimer();
                if (_Transaction != null)
                    _numTransaction++;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// ترانزکشن ساخته شده را کامیت میکند
        /// </summary>
        /// <returns></returns>
        public Boolean Commit()
        {
            if (_Transaction != null)
            {
                try
                {
                    _numTransaction--;

                    if (DataReader != null)
                        DataReader.Close();
                    _Transaction.Commit();
                    _Transaction = null;
                    StopTimer();
                    //DisConnect();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
                finally
                {

                }
            }
            return true;
        }
        /// <summary>
        /// یک ترانزکشن با نام مشخص را رولبک میکند
        /// </summary>
        /// <returns></returns>
        public Boolean Rollback(string name)
        {
            if (_Transaction != null)
            {
                try
                {
                    _numTransaction--;
                    _Transaction.Rollback();
                    _Transaction = null;
                    _TransactionName = "";
                    StopTimer();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
                finally
                {
                    if (_DataReader != null)
                        _DataReader.Close();
                }
            }
            return true;
        }
        /// <summary>
        /// دستور اس کیو ال خاص را به دستور اصلی کلاس نسبت میدهد
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        #endregion

        private Boolean _Query_DataReader(string SQL, CommandBehavior CB)
        {
            if (_DataReader != null && !_DataReader.IsClosed)
                _DataReader.Close();
            _getRecordCount();
            if (Connect())
            {
                try
                {
                    MySqlCommand myCommand = new MySqlCommand(SQL, cn);
                    if (_Transaction != null)
                        myCommand.Transaction = _Transaction;
                    _SetParams(myCommand);
                    _DataReader = myCommand.ExecuteReader();
                    object tObject = _DataReader;
                    JSystem.AddObject(ref tObject);
                    return true;
                }
                catch (Exception ex)
                {
                    if (_TransactionName != null)
                        Rollback(TransactionName);
                    Except.AddException(ex);
                    return false;
                }
            }
            return false;
        }

        private bool _Query_DataSet()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(_SQL, cn);
            _SetParams(adapter.SelectCommand);
            if (!Connect())
                return false;    ///////// rais Exception
            try
            {
                if (_DataSet == null)
                    _DataSet = new DataSet();
                adapter.Fill(_DataSet);
                return true;
            }
            catch (Exception ex)
            {
                if (_TransactionName != null)
                    Rollback(TransactionName);
                Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// برای اجرای دستوراتی که تنها یک مقدار برمیگرداند ، مانند ماکسیموم، مینیموم و ... استفاده میشود
        /// </summary>
        private object _Query_ExecutSacler(string SQL)
        {
            string strTemp = SQL.ToLower();
            int startOrderBy, endOrderBy;
            startOrderBy = strTemp.IndexOf("order by");
            if (startOrderBy > 0)
            {
                endOrderBy = startOrderBy + (strTemp.Substring(startOrderBy)).IndexOf(")");
                SQL = SQL.Substring(0, startOrderBy) + SQL.Substring(endOrderBy);
            }
            MySqlCommand command = new MySqlCommand(SQL, cn);
            object retData;
            try
            {
                if (!Connect())
                    return false;
                _SetParams(command);

                if (_Transaction != null)
                    command.Transaction = _Transaction;

                retData = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (_TransactionName != null)
                    Rollback(TransactionName);
                Except.AddException(ex);
                return null;
            }
            finally
            {
                //command.Cancel();
                //if (_TransactionName == null)
                //DisConnect();
            }
            return retData;
        }

        public virtual void Dispose()
        {
            try
            {
                if (_Transaction == null)
                {
                    DisConnect();
                    cn.Dispose();
                    ConnectionLive.Dispose();
                    base.Dispose();
                }
                else
                {
                    //JMessages.Message("You Need Commit or Rullback Transaction", "Transaction", JMessageType.Error);
                }
            }
            catch
            {
            }
            finally
            {

            }
        }

        private void SetTimer()
        {
            ConnectionLive.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 5 seconds.
            ConnectionLive.Interval = 5000;
            ConnectionLive.Enabled = true;
        }

        private void StopTimer()
        {
            ConnectionLive.Enabled = false;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ((Timer)source).Enabled = false;
            if (isTransaction)
            {
                Rollback(TransactionName);
            }

        }

        private void _SetParams(MySqlCommand pSqlCommand)
        {
            foreach (KeyValuePair<string, object> Param in Params)
            {
                object Value = Param.Value;
                if (Param.Value is DateTime)
                {
                    DateTime D = (DateTime)Param.Value;
                    if (D.Year <= DateTime.MinValue.Year)
                        Value = SqlDateTime.Null;
                }
                pSqlCommand.Parameters.Add(Param.Key, Value);
            }
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// اتصال به بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public Boolean Connect()
        {
            return Connect(true);
        }

        public Boolean Connect(bool pWaitForConnect)
        {
            try
            {
                if (cn == null)
                    CreateConnection();
                if (cn.State == ConnectionState.Closed)
                {
                    //if (!JPing.PingWait(_ServerName," ERROR! Server not Found "))
                    //  return false;
                    cn.Open();
                    Counter++;
                    DataBases.Add(this);
                    //_Query_ExecutSacler("SET NAMES 'utf8'");

                }
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                if (cn.State == ConnectionState.Closed && pWaitForConnect)
                {
                    //if (System.Windows.Forms.MessageBox.Show("Can Not Connect to DataBase. Try Again?" + (char)13 + ex.Message, "ERROR DB Connect",
                    //    System.Windows.Forms.MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    //return  Connect(pWaitForConnect);
                    //}
                }
                return false;
            }
        }

        /// <summary>
        /// قطع اتصال از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public Boolean DisConnect()
        {
            if (_Transaction != null)
                return false;

            try
            {
                _RecordCount = -1;
                if (_DataReader != null)
                    _DataReader.Close();
                if (_DataSet != null)
                {
                    //_DataSet.Reset();
                    //_DataSet.Dispose();
                }
                cn.Close();
                //OpenDatabase--;
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                Counter--;
                DataBases.Remove(this);
            }
        }
        /// <summary>
        /// اصلاح رشته اس کیو ال
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static string _ImproveSQL(string SQL)
        {
            string imSQL = SQL;
            //if (SQL.Contains('ي'))
            imSQL = imSQL.Replace('ي', 'ی');
            if (SQL.Contains('ك'))
                imSQL = imSQL.Replace('ك', 'ک');
            return imSQL;
        }

        public Boolean setQuery(string SQL)
        {
            return setQuery(SQL, true);
        }
        public Boolean setQuery(string SQL, bool Improve)
        {
            //setQuerySQLs += (char)13 + SQL;
            string newSQL;
            if (Improve)
                newSQL = _ImproveSQL(SQL);
            else
                newSQL = SQL;
            try
            {
                _RecordCount = -1;
                if (_DataSet != null)
                    _DataSet.Reset();
                if (_DataReader != null)
                    _DataReader.Close();
            }
            catch (Exception ex)
            {
                if (_TransactionName != null)
                    Rollback(TransactionName);
                Except.AddException(ex);
            }
            _SQL = newSQL;
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Query_DataReader()
        {
            if (_SQL.Length > 0)
            {
                return _Query_DataReader(_SQL, CommandBehavior.CloseConnection);
            }
            return false;
        }
        /// <summary>
        ///  ایکس ام ال مربوط به کلاس را تولید میکند
        /// </summary>
        /// <param name="fileName"> نام فایل خروجی </param>
        /// <returns></returns>
        public Boolean Query_XML(string fileName)
        {
            if (_Query_DataSet())
            {
                _DataSet.WriteXml(fileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// دیتاست مربوط به کلاس را با دستور اصلی اس کیو ال پر میکند
        /// </summary>
        public bool Query_DataSet()
        {
            return _Query_DataSet();
        }


        /// <summary>
        /// Execute Commands for DML Operations (Update, Delete, ...)
        /// </summary>
        /// <returns>تعداد رکوردهای متاثر را برمیگرداند</returns>
        public int Query_Execute()
        {
            MySqlCommand command = new MySqlCommand(_SQL, cn);
            int recordAffect;
            try
            {
                if (!Connect())
                    return -1;
                try
                {
                    if (_Transaction != null)
                        command.Transaction = _Transaction;
                    _SetParams(command);
                    recordAffect = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (_Transaction != null)
                        Rollback(TransactionName);
                    //Except.AddException(ex);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                //if (_Transaction == null)
                //DisConnect();
            }
            return recordAffect;
        }

        public object Query_ExecutSacler()
        {
            return _Query_ExecutSacler(_SQL);
        }
        /// <summary>
        /// یک رویه ذخیره شده را با پارامترهای داده شده اجرا میکند
        /// </summary>
        /// <param name="prcName">نام رویه ذخیره شده</param>
        /// <param name="parNames">نام پرامترها</param>
        /// <param name="parValues">مقادیر</param>
        /// <returns></returns>
        public object Query_ExecStProc_NonQuery(string prcName, string[] parNames, params string[] parValues)
        {
            object retData = null;
            MySqlCommand command = new MySqlCommand(prcName, cn);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parNames.Length; i++)
                command.Parameters.Add(parNames[i], parValues[i]);
            command.Parameters.Add("@ReturnValue", SqlDbType.BigInt);
            command.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;
            try
            {
                Connect();
                if (_Transaction != null)
                    command.Transaction = _Transaction;

                _SetParams(command);
                retData = command.ExecuteNonQuery();
                if (Convert.ToInt32(retData) == 0)
                    retData = command.Parameters["@ReturnValue"].Value;
            }

            catch (Exception ex)
            {
                Except.AddException(ex);
                if (_TransactionName != null)
                    Rollback(TransactionName);
                return null;
            }
            finally
            {
                //DisConnect();
            }
            return retData;
        }
        /// <summary>
        /// فیلد مورد نظر در دیتاریدر را به صورت کوتیشن شده برمیگرداند
        /// </summary>
        /// <param name="name">نام فیلد</param>
        /// <returns></returns>
        public string QuoteField(string name)
        {
            return Quote(DataReader[name].ToString());
        }
        /// <summary>
        ///  رشته مورد نظر را به صورت کوتیشن شده برمیگرداند
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Quote(string name)
        {
            return Quote(name, true);
        }
        /// <summary>
        ///  رشته مورد نظر را به صورت کوتیشن شده برمیگرداند و جهت جستجوی رشته در اس کیو ال یک N به انتهای  آن اضافه میکند
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pWithN"></param>
        /// <returns></returns>
        public static string Quote(string name, bool pWithN)
        {
            if (name == null) name = "";
            name = name.Replace("'", "''");
            name = name.Replace("\'", "''");
            if (pWithN)
                name = "N'" + name;
            else
                name = "'" + name;
            return name + "'";
        }
        /// <summary>
        /// دریافت تاریخ جاری سرور
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurrentDateTime()
        {
            DateTime currentDate = DateTime.MinValue;
            try
            {
                MySqlCommand command = new MySqlCommand("select getdate()", cn);
                Connect();
                currentDate = Convert.ToDateTime(command.ExecuteScalar());
            }

            catch (Exception ex)
            {
                Except.AddException(ex);
                return DateTime.MinValue;
            }
            finally
            {
                if (_SQL == null)
                    DisConnect();
            }
            return currentDate;
        }




        public void AddParams(string pParamName, object pValue)
        {
            object tmpValue = pValue;
            if (pValue is string)
                tmpValue = _ImproveSQL(((string)tmpValue));

            if (pValue == null)
                Params.Add(pParamName, DBNull.Value);
            else
                Params.Add(pParamName, tmpValue);
        }

        public void AddParamsRang(IDictionary<string, object> pParams)
        {
            Params.Clear();
            foreach (KeyValuePair<string, object> Param in pParams)
                AddParams(Param.Key, Param.Value);
            //Params.Add(Param);
        }


        public static DateTime GetStartDateTime()
        {
            try
            {
                return DateTime.MinValue;
            }
            finally
            {
            }
        }
        /// <summary>
        /// یک آرایه را از ورودی گرفته و معادل عبارت (IN) اسکیوال را بر میگرداند
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string GetInSQLClause(int[] array)
        {
            string IN = "";
            if (array.Length >= 1)
                IN = "(" + array[0].ToString();
            else
                return "";
            for (int index = 1; index < array.Length; index++)
            {
                IN = IN + ", " + array[index].ToString();
            }
            IN = IN + ")";
            return IN;
        }
        /// <summary>
        ///بر می گرداند DataTable رشته اس کیو ال را اجرا می کند و خروجی را بصورت
        /// </summary>
        /// <param name="pDB">JDataBase</param>
        /// <returns>DataTable</returns>
        private DataTable _Query_DataTable(string pSQL)
        {
            if (Connect())
            {
                MySqlCommand myCommand = new MySqlCommand(pSQL, cn);
                try
                {
                    if (_Transaction != null)
                        myCommand.Transaction = _Transaction;

                    _SetParams(myCommand);
                    DataTable dt = new DataTable("datatable");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
                    adapter.Fill(dt);
                    datatable = dt;
                    if (dt.Columns.IndexOf("rowguid") > -1)
                        dt.Columns.Remove("rowguid");
                    object tObject = dt;
                    JSystem.AddObject(ref tObject);
                    return dt;
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                    if (_Transaction != null)
                        Rollback(TransactionName);
                }
            }
            return null;
        }
        public DataTable Query_DataTable()
        {
            return _Query_DataTable(_SQL);
        }
        /// <summary>
        /// رشته ورودی را بصورت دستور Replace SQL بر میگرداند
        /// </summary>
        /// <param name="InputString"></param>
        /// <param name="IsFieldName"></param>
        /// <returns></returns>
        public static string RemoveSpaceQuery(string InputString, bool IsFieldName)
        {
            string tmpString = "";
            if (IsFieldName)
                tmpString = " Replace(" + InputString + ", ' ', '')";
            else
                //tmpString = " Replace('" + InputString + "', ' ', '')";
                tmpString = InputString.Replace(" ", "");
            return tmpString;
        }

        public static string ReplaceUnicodes(string InputString)
        {
            return ReplaceUnicodes(InputString, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InputString"></param>
        /// <param name="OutputFielName"></param>
        /// <returns></returns>
        public static string ReplaceUnicodes(string InputString, string OutputFielName)
        {

            string tmpString = "";
            tmpString = " Replace(Replace(" + InputString + ", N'ي',N'ی'),N'ك',N'ک') ";
            if (OutputFielName.Trim() != "")
                tmpString = tmpString + OutputFielName;
            else
                tmpString = tmpString + InputString;
            return tmpString;
        }

        /// <summary>
        /// در دستورات سلکت بکار میرود. کلاس اینام را بصورت عبارت کیس برمیگرداند
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pEnumClass"></param>
        /// <returns></returns>
        public static string EnumToCaseStatement(string pFileName, Type pEnumClass)
        {
            string[] EnumNames = Enum.GetNames(pEnumClass);
            int[] EnumValues = Enum.GetValues(pEnumClass).Cast<int>().ToArray();
            string temp = " CASE " + pFileName;
            for (int i = 0; i < EnumValues.Count(); i++)
            {
                temp += "\n WHEN " + EnumValues[i].ToString() + " THEN " + JDataBase.Quote(JLanguages._Text(EnumNames[i]));
            }
            temp += " ELSE '' END ";
            return temp;
        }

        public static string SQLMiladiToShamsi(string pFieldName, string pAs)
        {
            return " dbo.MiladiTOShamsi(" + pFieldName + ") AS " + pAs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTableName"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static int GetColumnsize(string pTableName, string pFieldName)
        {
            JDataBase DB = new JDataBase();
            DB.setQuery(@"SELECT isnull(syscolumns.LENGTH,0) AS ""LENGTH"" FROM sysobjects 
                INNER JOIN 	syscolumns ON sysobjects.id = syscolumns.id INNER JOIN	
                systypes ON syscolumns.xtype = systypes.xtype WHERE (sysobjects.xtype = 'U') and
                sysobjects.name = '" + pTableName + "' AND syscolumns.name = '" + pFieldName +
                                     "' ORDER BY sysobjects.name, syscolumns.colid");
            return (int)DB.Query_DataTable().Rows[0][0];
        }
        /// <summary>
        /// تبدیل یک فیلد دیتاتیبل به آرایه ای از int
        /// </summary>
        /// <param name="pDataTable"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static int[] DataTableToIntArray(DataTable pDataTable, string pFieldName)
        {
            int[] array = new int[0];
            try
            {
                foreach (DataRow row in pDataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = Convert.ToInt32(row[pFieldName]);
                    }
                }
                return array;
            }
            catch
            {
                return array;
            }
        }
        /// <summary>
        /// تبدیل یک فیلد دیتاتیبل به آرایه ای از رشته
        /// </summary>
        /// <param name="pDataTable"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static string[] DataTableToStringtArray(DataTable pDataTable, string pFieldName)
        {
            string[] array = new string[0];
            try
            {
                foreach (DataRow row in pDataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = row[pFieldName].ToString();
                    }
                }
                return array;
            }
            catch
            {
                return array;
            }
        }

        public static string GetInsertSQL(string pTable)
        {
            return JDataBase.GetInsertSQL(pTable, "0", true);
        }

        public static string GetInsertSQL(string pTable, string pDefault, bool pComplex)
        {
            if (pComplex)
            {
                return
                 @"SET @Code = ISNULL((SELECT MAX(Code) FROM [" + pTable + "] WHERE Code >= " + pDefault + "+" + JMainFrame.CurrentUser.UniqCode.ToString() +
                 " AND Code < " + pDefault + "+" + JMainFrame.CurrentUser.UniqCode.ToString() + " + 1000000 )," + pDefault + "+" +
                 JMainFrame.CurrentUser.UniqCode.ToString() + ") + 1 ";
            }
            return
                 @"SET @Code = ISNULL((SELECT MAX(Code) FROM [" + pTable + "])," + pDefault +") + 1 ";
        }

        public static string GetStringFiledsName(DataTable pDT)
        {
            try
            {
                string _Key = "";
                foreach (System.Data.DataColumn DC in pDT.Columns)
                {
                    _Key += DC.ColumnName;
                }
                return _Key;
            }
            catch
            {
                return "";
            }
        }

        public void KillSleepProcess(int pTimeOut)
        {
            int time;
            setQuery("SHOW FULL PROCESSLIST");
            DataTable dt = Query_DataTable();
            foreach (DataRow DR in dt.Rows)
            {
                try
                {
                    int process_id = int.Parse(DR["Id"].ToString());
                    if (int.TryParse(DR["Time"].ToString(), out time) && int.Parse(DR["Time"].ToString()) > pTimeOut)
                    {
                        string sql = "KILL " + process_id.ToString();
                        setQuery(sql);
                        Query_Execute();
                    }
                }
                catch(Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
        }
        #endregion
    }
}
