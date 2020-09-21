using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Data.SqlTypes;
using System.Security.Principal;
using System.DirectoryServices;
using System.Threading;
using System.Reflection;

namespace ClassLibrary
{
    public class JOpenDataBase
    {

        public static int MaxConnection;

        public int Count
        {
            //testحخخ
            get
            {
                //lock (listLock)
                {
                    return DBS.Count;
                }
            }
        }

        //int hasnull = 0;

        private volatile List<JDataBase> DBS = new List<JDataBase>();
        private readonly object listLock = new object();

        public JDataBase LastDataBase;

        public int add(JDataBase pdb)
        {
            try
            {
                LastDataBase = pdb;
                if (DBS.Count == 0)
                {
                    JSystem.FreeObjectsDataReaer();
                }

                lock (listLock)
                {
                    if (DBS.IndexOf(pdb) >= 0)
                        return 0;
                    DBS.Add(pdb);
                    try
                    {
                        if (DBS.Count >= 10000)
                        {
                            //System.IO.File.Delete("c:\\123\\connection.txt");
                            foreach (JDataBase db in DBS)
                            {
                                //System.IO.File.AppendAllText("c:\\123\\connection.txt", db.SQL.Substring(0,40) + " : " + pdb.DateRun.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                return DBS.Count;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(new Exception("JOpenDataBase public int add(JDataBase pdb)" + ex.Message));
                return -1;
            }
            finally
            {
                //Locked = false;
            }
        }

        public void delete(JDataBase pDB)
        {
            try
            {
                lock (listLock)
                {
                    DBS.Remove(pDB);
                }
                if (DBS.Count == 0)
                    JDataBase._numTransaction = 0;
            }
            catch (Exception ex)
            {
                DBS.Remove(pDB);
                JSystem.Except.AddException(new Exception("JOpenDataBase public int delete(JDataBase pdb)" + ex.Message));
            }
            finally
            {
            }
        }

        public void DeleteOlder()
        {
            DateTime _dtime = DateTime.MaxValue;
            int olderIndex = 0;
            for (int i = 0; i < DBS.Count; i++)
            {
            }
        }

        public void Clear()
        {
            for (; DBS.Count > 0;)
            {
                if (DBS[0] != null && DBS[0].cnState() == ConnectionState.Closed)
                {
                    delete(DBS[0]);
                }
                else
                    if (DBS[0] == null)
                {
                    delete(DBS[0]);
                }
            }
        }

        public string[] GetSql(int MinLifTime)
        {
            string[] SQL = new String[0];
            for (int i = 0; i < DBS.Count; i++)
            {
                if (DBS[i] != null && (JDateTime.Now() - DBS[i].ConnectTime).TotalSeconds > MinLifTime)
                {
                    Array.Resize(ref SQL, SQL.Length + 1);
                    SQL[SQL.Length - 1] = DBS[i].SQL;
                }
            }
            return SQL;
        }

        public void Dispose(int pSessionId)
        {
            try
            {
                for (int i = 0; i < DBS.Count; i++)
                {
                    if (DBS[i] != null && DBS[i].SessionId == pSessionId)
                    {
                        DBS[i].Dispose();
                        i--;
                    }
                }
            }
            catch
            {

            }
        }

    }
    /// <summary>
    /// این کلاس برای ارتباط با بانک اطلاعاتی میباشد
    /// </summary>
    [Serializable()]
    public class JDataBase : JCore
    {
        public bool RunTempPrviuseTable = false;
        public DateTime DateRun;
        public bool Error = false;
        public bool Paging;
        public static string setQuerySQLs = "";
        private int MaxConnection = 1000;
        public int SessionId = 0;
        /// <summary>
        /// 
        /// </summary>
        private static JConfig __Config;
        private JConfig _Config
        {
            get
            {
                //if (JMainFrame.IsWeb() == false)
                return __Config;
                //else
                //{
                //	if (WebClassLibrary.SessionManager.Current.Session["JConfig"] == null)
                //		return null;
                //	return (WebClassLibrary.SessionManager.Current.Session["JConfig"] as JConfig);
                //}
            }
            set
            {
                //if (JMainFrame.IsWeb() == false)
                __Config = value;
                //else
                //{
                //	WebClassLibrary.SessionManager.Current.Session["JConfig"]  = value;
                //}
            }
        }
        private string _ServerName;
        //public static int OpenDatabase
        //{
        //    get
        //    {
        //        return dbsOpen.Count;
        //    }
        //}
        public static JOpenDataBase dbsOpen = new JOpenDataBase();
        public int OpendbIndex = -1;
        private Thread _ThreadExecuted;
        private Boolean _StartThread = false;
        private DateTime _ConnectTime;
        public DateTime ConnectTime
        {
            get
            {
                return _ConnectTime;
            }
        }

        private int _CommandTimeout = 60;
        public int CommandTimeout
        {
            get
            {
                return _CommandTimeout;
            }

            set
            {
                _CommandTimeout = value;
            }
        }

        #region Constructor
        /// <summary>
        /// ساخت یک کلاس از دیتابیس
        /// </summary>
        public JDataBase()
        {

            while (JDataBase.dbsOpen.Count > MaxConnection)
                Thread.Sleep(100);

            if (_Config == null)
            {
                _Config = new JConfig();
            }
            _ServerName = _Config.Server;

            _ThreadExecuted = new Thread(new ParameterizedThreadStart(_TreadRun));
            //_ThreadExecuted.Priority = ThreadPriority.Lowest;
            ConectionStringBuilder(_Config);
            CreateConnection();
        }

        private bool _EmptyDB;
        public JDataBase(bool EmptyDB)
        {
            while (JDataBase.dbsOpen.Count > MaxConnection)
                Thread.Sleep(100);
            _EmptyDB = true;
            _ThreadExecuted = new Thread(new ParameterizedThreadStart(_TreadRun));
            //_ThreadExecuted.Priority = ThreadPriority.Lowest;
        }

        public void ConnectEmptyDataBase(JConfig pDBConfig)
        {
            while (JDataBase.dbsOpen.Count > MaxConnection)
                Thread.Sleep(100);
            _ThreadExecuted = new Thread(new ParameterizedThreadStart(_TreadRun));
            //_ThreadExecuted.Priority = ThreadPriority.Lowest;
            if (_EmptyDB)
            {
                _ServerName = pDBConfig.Server;
                ConectionStringBuilder(pDBConfig);
                CreateConnection();
            }
        }

        public JDataBase(JConfig pDBConfig)
        {
            while (JDataBase.dbsOpen.Count > MaxConnection)
                Thread.Sleep(100);
            _ThreadExecuted = new Thread(new ParameterizedThreadStart(_TreadRun));
            //_ThreadExecuted.Priority = ThreadPriority.Lowest;
            _ServerName = pDBConfig.Server;
            ConectionStringBuilder(pDBConfig);
            CreateConnection();
        }

        public JDataBase(SqlConnectionStringBuilder pSqlConnectionStringBuilder)
        {
            while (JDataBase.dbsOpen.Count > MaxConnection)
                Thread.Sleep(100);
            _ThreadExecuted = new Thread(new ParameterizedThreadStart(_TreadRun));
            //_ThreadExecuted.Priority = ThreadPriority.Lowest;
            if (_Config == null)
                _Config = new JConfig();
            _ServerName = pSqlConnectionStringBuilder.DataSource;
            _cnStrBuilder = pSqlConnectionStringBuilder;
            CreateConnection();
        }

        public void SetServer(string pServer)
        {
            _ServerName = pServer;
        }

        public JDataBase[] RelationsDB;

        public void ADDRelation(JDataBase pDB)
        {
            if (RelationsDB == null)
                RelationsDB = new JDataBase[0];
            Array.Resize(ref RelationsDB, RelationsDB.Length + 1);
            RelationsDB[RelationsDB.Length - 1] = pDB;
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

        public string DataBaseName;
        /// <summary>
        /// کانکشن اصلی اتصال به بانک اطلاعاتی
        /// </summary>
        private SqlConnection cn;
        /// <summary>
        /// ساخت یک کانکشن برای ارتباط با بانک اطلاعاتی
        /// </summary>
        private SqlConnectionStringBuilder _cnStrBuilder;
        /// <summary>
        ///  ساخت 
        ///  SqlConnectionString
        ///  مربوط به کانکشن
        /// </summary>
        private SqlConnectionStringBuilder cnStrBuilder
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
        public JMyDataReader DataReader
        {
            get
            {
                try
                {
                    if (_DataReader == null)
                    {
                        _DataReader = new JMyDataReader();

                    }

                    if (_DataReader.DR == null)
                    {
                        if (datatable != null && datatable.Rows.Count > 0 && _DataReader.DR == null)
                        {
                            _DataReader.DR = datatable.Rows[0];
                        }
                        else
                        {
                            _DataReader.DR = datatable.NewRow();
                        }
                    }
                    return _DataReader;
                }
                catch (Exception ex)
                {
                    return null;
                }
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
        public SqlTransaction Transaction
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
        private SqlTransaction _Transaction;
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
        private JMyDataReader _DataReader;

        /// <summary>
        /// 
        /// </summary>
        private DataSet _DataSet;

        public string ClassName = "";

        private System.Timers.Timer ConnectionLive = new System.Timers.Timer();

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

        public ConnectionState cnState()
        {
            return cn.State;
        }

        public SqlConnection Connection
        {
            get
            {
                return cn;
            }
        }

        bool ConnectionServer = true;
        private void ConectionStringBuilder(JConfig pDBConfig)
        {
            try
            {
                _cnStrBuilder = new SqlConnectionStringBuilder();
                _cnStrBuilder.IntegratedSecurity = pDBConfig.IntegratedSecurity;
                if (!_cnStrBuilder.IntegratedSecurity)
                {
                    _cnStrBuilder.UserID = pDBConfig.Username;
                    _cnStrBuilder.Password = pDBConfig.Password;
                }
                _cnStrBuilder.InitialCatalog = pDBConfig.Database;
                _cnStrBuilder.DataSource = pDBConfig.Server;
                if (pDBConfig.Server == "")
                {
                    ConnectionServer = false;
                    _Config = null;
                }
                else
                {
                    ConnectionServer = true;
                }

                DataBaseName = pDBConfig.Database;
                _cnStrBuilder.ConnectTimeout = _CommandTimeout;
                _cnStrBuilder.Pooling = false;
                _cnStrBuilder.MaxPoolSize = 20000;
                //_cnStrBuilder.ConnectTimeout = 10;
                //_cnStrBuilder.ConnectionReset = false;
            }
            catch
            {
                Error = true;
            }

        }
        /// <summary>
        /// ساخت کانکشن برای ارتباط با بانک اطلاعاتی
        /// </summary>
        /// <returns>درست یا غلط</returns>
        private Boolean CreateConnection()
        {
            try
            {
                while (JDataBase.dbsOpen.Count > MaxConnection)
                    Thread.Sleep(100);
                string Name = WindowsIdentity.GetCurrent().Name;
                _RecordCount = -1;
                if (cn != null)
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.ConnectionString = _cnStrBuilder.ConnectionString;
                    return true;
                }

                cn = new SqlConnection();

                cn.ConnectionString = _cnStrBuilder.ConnectionString;
                return true;
            }
            catch (Exception ex)
            {
                Error = true;
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
                        DataTable _DT = _Query_DataTable(_SQL,false);
                        _RecordCount = _DT.Rows.Count;
                        _DT.Clear();
                        _DT.Dispose();
                    }
                }
                return _RecordCount;
            }
            catch (Exception ex)
            {
                Error = true;
                if (_TransactionName != null)
                    Rollback(TransactionName);
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {

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
                _Transaction = cn.BeginTransaction(name);
                _TransactionName = name;
                if (_Transaction != null)
                    _numTransaction++;
                return true;
            }
            catch (Exception ex)
            {
                Error = true;
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
                    _Transaction.Dispose();
                    _Transaction = null;
                    if (RelationsDB != null)
                    {
                        foreach (JDataBase DB in RelationsDB)
                        {
                            DB.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error = true;
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
                    _Transaction.Rollback(name);
                    _Transaction.Dispose();
                    _Transaction = null;
                    _TransactionName = "";
                    if (RelationsDB != null)
                    {
                        foreach (JDataBase DB in RelationsDB)
                        {
                            DB.Rollback("");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error = true;
                    Except.AddException(ex);
                }
                finally
                {
                    if (_DataReader != null)
                        _DataReader.Close();
                    if (_Transaction != null)
                        _Transaction.Dispose();
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

        //private Boolean _Query_DataReader(string SQL, CommandBehavior CB, bool fromLog = false)
        //{
        //    if (_DataReader != null && !_DataReader.IsClosed)
        //        _DataReader.Close();
        //    _getRecordCount();
        //    if (Connect())
        //    {
        //        try
        //        {
        //            SqlCommand myCommand = new SqlCommand(SQL, cn);
        //            if (_Transaction != null)
        //                myCommand.Transaction = _Transaction;
        //            _SetParams(myCommand);
        //            _DataReader = myCommand.ExecuteReader();
        //            object tObject = _DataReader;
        //            JSystem.AddObject(ref tObject);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Error = true;
        //            if (_TransactionName != null)
        //                Rollback(TransactionName);
        //            Exception exl = new Exception(SQL, ex);
        //            Except.AddException(exl);
        //            return false;
        //        }
        //        finally
        //        {
        //        }
        //    }
        //    return false;
        //}

        private bool _Query_DataSet()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(_SQL, cn);
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
                Error = true;
                if (_TransactionName != null)
                    Rollback(TransactionName);
                Exception exl = new Exception(_SQL, ex);
                Except.AddException(exl);
                return false;
            }
        }

        public Guid QueryGuid;
        public int SPID;
        DateTime QueryLogTime;
        private void DeleteQueryLog(bool pUpdate = false)
        {
            try
            {
                string QueryLog = "";
                if (QueryGuid != null && QueryGuid != Guid.Empty)
                {
                    if ((DateTime.Now - QueryLogTime).TotalSeconds < 120 && !pUpdate)
                        QueryLog = "delete from ClsQueryLog WHERE Code = @Code";
                    else
                        QueryLog = "UPDATE ClsQueryLog set EndTime = GETDATE() , SPID = 0 where Code= @Code";
                    using (SqlConnection cnQueryLog = new SqlConnection(_cnStrBuilder.ConnectionString))
                    {
                        cnQueryLog.Open();
                        using (SqlCommand comm = new SqlCommand(QueryLog, cnQueryLog))
                        {
                            comm.Parameters.Add("Code", QueryGuid.ToString());
                            int iii = comm.ExecuteNonQuery();
                        }
                        cnQueryLog.Close();
                    }
                }
            }
            catch
            {

            }
        }

        private void InsertQueryLog()
        {
            try
            {
                string QueryLog = string.Format(@"insert into ClsQueryLog(Code, query, startTime, endTime, spid, userid) 
                    OUTPUT inserted.Code , @@spid spid
                    Values(newid(), @query, getdate(), null, "+ SPID + ", {0})", JMainFrame.CurrentUserCode);
                QueryLogTime = DateTime.Now;
                using (SqlConnection cnQueryLog = new SqlConnection(_cnStrBuilder.ConnectionString))
                {
                    cnQueryLog.Open();
                    using (SqlCommand comm = new SqlCommand(QueryLog, cnQueryLog))
                    {
                        comm.Parameters.Add(new SqlParameter("query", SQL));
                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        QueryGuid = Guid.Parse(dt.Rows[0]["Code"].ToString());
                    }
                    cnQueryLog.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// برای اجرای دستوراتی که تنها یک مقدار برمیگرداند ، مانند ماکسیموم، مینیموم و ... استفاده میشود
        /// </summary>
        private object _Query_ExecutSacler(string SQL, bool removeOrderBy = true, bool pExceptionTable = true)
        {
            _ConnectTime = DateTime.Now;
            string strTemp = SQL.ToLower();
            int startOrderBy, endOrderBy;
            startOrderBy = strTemp.IndexOf("order by");
            if (startOrderBy > 0 && removeOrderBy)
            {
                endOrderBy = startOrderBy + (strTemp.Substring(startOrderBy)).IndexOf(")");
                SQL = SQL.Substring(0, startOrderBy) + SQL.Substring(endOrderBy);
            }

            SqlCommand command = new SqlCommand(SQL, cn);
            object retData = 0;
            try
            {
                if (!Connect())
                    return false;

                InsertQueryLog();

                _SetParams(command);

                if (_Transaction != null)
                    command.Transaction = _Transaction;

                command.CommandTimeout = _CommandTimeout;

                retData = command.ExecuteScalar();
                if (retData == null)
                    retData = 1;
                DeleteQueryLog();
            }
            catch (Exception ex)
            {
                DeleteQueryLog(true);
                Error = true;
                if (_TransactionName != null)
                    Rollback(TransactionName);
                if (pExceptionTable)
                {
                    Exception exl = new Exception(ex.Message.Substring(0, 50) + Environment.NewLine + _SQL);
                    Except.AddException(exl);
                }
                return null;
            }
            finally
            {
                command.Cancel();
                command.Dispose();
                //if (_TransactionName == null)
                //DisConnect();
            }
            return retData;
        }

        public virtual void Dispose()
        {
            if (_StartThread)
                return;
            DeleteQueryLog();
            try
            {
                try
                {
                    if (_Transaction != null)
                    {
                        _Transaction.Rollback();
                    }
                }
                catch
                {
                    Error = true;
                }
                DisConnect();
                if (RelationsDB != null)
                {
                    foreach (JDataBase DB in RelationsDB)
                    {
                        DB.Dispose();
                    }
                }
                cn.Close();
                cn.Dispose();
                base.Dispose();
            }
            catch(Exception ex)
            {
                DeleteQueryLog(true);
                Error = true;
            }
        }

        private void SetTimer()
        {
            //ConnectionLive.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 5 seconds.
            //ConnectionLive.Interval = 60000;
            //ConnectionLive.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //((Timer)source).Enabled = false;
            //if (cn != null)
            //{
            // DisConnect();
            //}

        }

        public string DataTypesName;
        private void _SetParams(SqlCommand pSqlCommand)
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
                SqlParameter tvparam = pSqlCommand.Parameters.Add(Param.Key, Value);
                if (Value is System.Data.DataTable)
                {
                    tvparam.TypeName = DataTypesName;//"dbo.AVLPointList";
                    tvparam.SqlDbType = SqlDbType.Structured;
                }

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
            return Connect(false);
        }

        public Boolean Connect(bool pWaitForConnect)
        {
            bool designMode = (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
            if (designMode)
                return false;
            try
            {
                if (cn == null || cn.ConnectionString == "")
                    CreateConnection();
                if (cn.State == ConnectionState.Closed && ConnectionServer)
                {
                    if (cnStrBuilder.InitialCatalog.Length == 0 || cnStrBuilder.DataSource.Length == 0)
                    {
                        _Config = null;
                        return false;
                    }
                    cn.Open();

                    using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", cn))
                    {
                        comm.ExecuteNonQuery();
                    }
                    using (SqlCommand comm = new SqlCommand("SELECT @@SPID SPID", cn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        adapter.Fill(dt);
                        SPID = int.Parse(dt.Rows[0][0].ToString());
                    }

                    _ConnectTime = DateTime.Now;
                    SetTimer();
                    if (JMainFrame.IsWeb())
                        SessionId = WebClassLibrary.SessionManager.Current.SessionID.GetHashCode();
                    OpendbIndex = dbsOpen.add(this);
                    DataBaseName = cnStrBuilder.DataSource;
                    return true;
                }
                return cn.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                Error = true;
                //Except.AddException(ex);
                if (cn.State == ConnectionState.Closed && pWaitForConnect && !JMainFrame.IsWeb())
                {
                    if (System.Windows.Forms.MessageBox.Show("Can Not Connect to DataBase. Try Again?" + (char)13 + _SQL, "ERROR DB Connect",
                        System.Windows.Forms.MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    {
                        return  Connect(pWaitForConnect);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// قطع اتصال از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        private Boolean DisConnect()
        {
            if (_Transaction != null)
                return false;

            try
            {
                _RecordCount = -1;
                if (_DataReader != null)
                {
                    _DataReader.Close();
                    _DataReader.Dispose();
                }
                if (_DataSet != null)
                {
                }
                cn.Close();
                dbsOpen.delete(this);
                if (RelationsDB != null)
                {
                    foreach (JDataBase DB in RelationsDB)
                    {
                        DB.DisConnect();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.cn.Close();
                dbsOpen.delete(this);
                Error = true;
                Except.AddException(ex);
                return false;
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
            imSQL = imSQL.Replace("[[", "[").Replace("]]", "]");
            return imSQL;
        }

        public Boolean setQuery(string SQL)
        {
            return setQuery(SQL, true);
        }
        public Boolean setQuery(string SQL, bool Improve)
        {
            Error = false;
            _ConnectTime = DateTime.Now;
            DateRun = _ConnectTime;

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
                Error = true;
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
            return Query_DataReader(false);
        }

        public Boolean Query_DataReader(bool fromLog = false)
        {
            if (_SQL.Length > 0)
            {
                _DataReader = null;
                _Query_DataTable(_SQL, false);
                return !Error;
                //return _Query_DataReader(_SQL, CommandBehavior.CloseConnection, fromLog);
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
        public int Query_Execute(bool pThread = false)
		{
            return Query_Execute(pThread, false);
		}

		private readonly object ExecuteLock = new object();
        public int Query_Execute(bool pThread, bool fromLog = false)
        {
            return Query_Execute(pThread, "", fromLog);
        }
        public int Query_Execute(bool pThread, string pErrorCommand, bool fromLog = false)
        {
            return Query_Execute(pThread, "", fromLog, 0);
        }
        public int Query_Execute(bool pThread, string pErrorCommand, bool fromLog = false, int pTryCount = 0)
		{
			{
				SqlCommand command = new SqlCommand(_SQL, cn);
				int recordAffect;
				try
				{
					if (!Connect())
						return -1;
                    InsertQueryLog();
                    try
                    {
                        if (_Transaction != null)
                            command.Transaction = _Transaction;
                        _SetParams(command);
                        command.CommandTimeout = _CommandTimeout;
                        if (pThread)
                        {
                            _StartThread = true;
                            Object b = new object[] { command, pErrorCommand, fromLog };
                            _ThreadExecuted.Start(b);
                            recordAffect = 1;
                        }
                        else
                        {
                            recordAffect = command.ExecuteNonQuery();
                            DeleteQueryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        DeleteQueryLog(true);
                        if (ex.ToString().IndexOf("deadlocked on lock") > 0 && pTryCount < 50)
                        {
                            System.Threading.Thread.Sleep(3000);
                            return Query_Execute(pThread, pErrorCommand, fromLog, pTryCount++);
                        }
                        else
                        {
                            DeleteQueryLog(true);
                            Error = true;
                            if (_Transaction != null)
                                Rollback(TransactionName);
                            Except.AddException(new Exception(SQL));
                            Except.AddException(ex);
                            return -1;
                        }
                    }
				}
				catch (Exception ex)
				{
                    DeleteQueryLog(true);
                    Error = true;
                    Exception exl = new Exception(SQL, ex);
                    Except.AddException(exl);
					return -1;
				}
				finally
				{
					//if (_Transaction == null)
					//DisConnect();
				}
				return recordAffect;
			}

		}

		private void _TreadRun(Object b)
		{
                SqlCommand command = ((b as object[])[0] as SqlCommand);
                string Error = ((b as object[])[1] as string);
            try
            {
                while (JDataBase.dbsOpen.Count > MaxConnection)
                    Thread.Sleep(100);

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                try
                {
                    if (Error.Length > 0)
                    {
                        SqlCommand command1 = new SqlCommand(Error, cn);
                        command1.ExecuteNonQuery();
                    }
                }
                catch (Exception ex1)
                {

                }
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                Dispose();
                _StartThread = false;
            }

		}

        public object Query_ExecutSacler()
        {
            bool removeOrderBy = true;
            return _Query_ExecutSacler(_SQL, removeOrderBy);
        }
        public object Query_ExecutSacler(bool removeOrderBy = true)
        {
            return _Query_ExecutSacler(_SQL, removeOrderBy);
        }

        public object Query_ExecutSacler(bool removeOrderBy = true, bool pExceptionTable = true)
        {
            return _Query_ExecutSacler(_SQL, removeOrderBy, pExceptionTable);
        }

        /// <summary>
        /// یک رویه ذخیره شده را با پارامترهای داده شده اجرا میکند
        /// </summary>
        /// <param name="prcName">نام رویه ذخیره شده</param>
        /// <param name="parNames">نام پرامترها</param>
        /// <param name="parValues">مقادیر</param>
        /// <returns></returns>
        public object Query_ExecStProc_NonQuery(string prcName, string[] parNames, bool fromLog = false, params string[] parValues)
        {
            object retData = null;
            SqlCommand command = new SqlCommand(prcName, cn);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parNames.Length; i++)
            {
                 SqlParameter tvparam = command.Parameters.AddWithValue(parNames[i], parValues[i]);
                 if (parValues[i] is System.Data.DataTable)
                    tvparam.SqlDbType = SqlDbType.Structured;
            }
            command.Parameters.Add("@ReturnValue", SqlDbType.BigInt);
            command.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;
            try
            {
                if (!Connect())
                    return null;

                InsertQueryLog();

                if (_Transaction != null)
                    command.Transaction = _Transaction;

                _SetParams(command);
                retData = command.ExecuteNonQuery();
                DeleteQueryLog();
                if (Convert.ToInt32(retData) == 0)
                    retData = command.Parameters["@ReturnValue"].Value;

            }

            catch (Exception ex)
            {
                DeleteQueryLog(true);
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

        public DataTable ExecuteProcedure_Query(string procedureName, string[] parNames, params string[] parValues)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(procedureName, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parNames.Length; i++)
                    cmd.Parameters.AddWithValue(parNames[i], parValues[i]);
                da.Fill(dt);
            }
            //ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            //jHistory.Save("ClassLibrary.JDataBase", 0, 0, 0, 0, "اجرای پروسیجر روی پایگاه داده", "", 0);
            return dt;
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
                SqlCommand command = new SqlCommand("select getdate()", cn);
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
        private DataTable _Query_DataTable(string pSQL, bool pgetNewQuery)
        {

            if (pgetNewQuery)
            {
                pSQL = DataBase.JQuery.getNewQuery(pSQL);
            }

            _ConnectTime = DateTime.Now;
            if (Connect())
            {

                InsertQueryLog();

                JDataTable dt;
                dt = new JDataTable("datatable");
                dt.BaseSQL = pSQL;
                if (Paging)
                {
                    dt.Paging = new JPage();
                    dt.Paging.Start = 1;
                    dt.Paging.Count = 50;
                    dt.Paging.BaseSQL = pSQL;
                    dt.Paging.Condition = "";
                    dt.Paging.Ordered = "Code";
                    pSQL = dt.Paging.PagingSQL();
                }


                SqlCommand myCommand = new SqlCommand(pSQL, cn);
                try
                {
                    if (_Transaction != null)
                        myCommand.Transaction = _Transaction;

                    myCommand.CommandTimeout = _CommandTimeout;
                    _SetParams(myCommand);
                    SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
                    adapter.Fill(dt);

                    DeleteQueryLog();

                    datatable = (DataTable)dt;
                    if (dt.Columns.IndexOf("rowguid") > -1)
                        dt.Columns.Remove("rowguid");
                    return (DataTable)dt;
                }
                catch (Exception ex)
                {
                    ///به علت اینکه گاهی اوقات اکسپت نال است فعلا یک جدول خالی بر می گردانیم
                    ///در نتیجه خطا مدیریت نمی شود و ثبت نمی گردد
                    DeleteQueryLog(true);
                    if (Except == null)
                        return new DataTable();

                    Exception exl = new Exception(pSQL, ex);
                    Except.AddException(exl);

                    if (_Transaction != null)
                        Rollback(TransactionName);
                }
            }
            return null;
        }
        public DataTable Query_DataTable()
        {
            return _Query_DataTable(_SQL,true);
        }

        public DataTable Query_DataTable(bool pgetNewQuery)
        {
            return _Query_DataTable(_SQL, pgetNewQuery);
        }

        public JDataBase NewDataBase()
        {
            JDataBase DB = new JDataBase(cnStrBuilder);
            return DB;
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

        public static Int64[] DataTableToInt_64_Array(DataTable pDataTable, string pFieldName)
        {
            Int64[] array = new Int64[0];
            try
            {
                foreach (DataRow row in pDataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = Convert.ToInt64(row[pFieldName]);
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
            if (pDataTable == null) return null;
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
                return null;
            }
        }

        public static JKeyValue[] DataTableColumnToKeyValueArray(DataTable pDataTable)
        {
            JKeyValue[] array = new JKeyValue[pDataTable.Columns.Count];
            int Count = 0;
            try
            {
                foreach (DataColumn DC in pDataTable.Columns)
                {
                    array[Count] = new JKeyValue();
                    array[Count].Key = DC.ColumnName;
                    if (pDataTable.Rows.Count > 0)
                        array[Count].Value = pDataTable.Rows[0][DC.ColumnName];
                    Count++;
                }
                return array;
            }
            catch
            {
                return null;
            }
        }

        public static string GetInsertSQL(string pTable)
        {
            return JDataBase.GetInsertSQL(pTable, "0", true);
        }

        public static string GetInsertSQL(string pTable, string pDefault, bool pComplex)
        {
            //if (pComplex)
            //{
            //    return
            //     @"SET @Code = ISNULL((SELECT MAX(Code) FROM [" + pTable + "] WHERE Code >= " + pDefault + "+" + JMainFrame.CurrentUser.UniqCode.ToString() +
            //     " AND Code < " + pDefault + "+" + JMainFrame.CurrentUser.UniqCode.ToString() + " + 1000000 )," + pDefault + "+" +
            //     JMainFrame.CurrentUser.UniqCode.ToString() + ") + 1 ";
            //}
            return
                 @"SET @Code = ISNULL((SELECT MAX(Code) FROM [" + pTable + "]),0" + pDefault + ") + 1 ";
        }


        public static bool isTempTable(string pTempTable, JDataBase pDB)
		{
			try
			{
                pDB.setQuery("IF OBJECT_ID('tempdb.." + pTempTable + "') IS NOT NULL select 1 OK else select 0 OK");
				DataTable DT = pDB.Query_DataTable();
				if (DT != null && DT.Rows.Count == 1)
				{
					return DT.Rows[0][0].ToString() == "1";
				}
				return false;
			}
			finally
			{
			}
		}
        public static string GetStringFiledsName(DataTable pDT)
        {
            try
            {
                string _Key = "";
                foreach (System.Data.DataColumn DC in pDT.Columns)
                {
                    if (DC.ColumnName != "row_number" && (DC.Expression == null || DC.Expression.Length == 0))
                        _Key += DC.ColumnName;
                }
                return _Key;
            }
            catch
            {
                return "";
            }
        }
        #endregion
        public static void Dispose(int pSessionId)
        {
            dbsOpen.Dispose(pSessionId);
        }
    }

    public class JMyDataReader : IDisposable
    {

        public int i = -1;
        public DataRow DR;

        public JMyDataReader()
        {

        }

        public Object this[int i]
        {
            get
            {
                return DR[i];
            }
        }
        DataTable Table
        {
            get
            {
                return DR.Table;
            }
        }
        public Object this[string i]
        {
            get
            {
                return DR[i];
            }
        }

        public void Close()
        {
        }

        public bool IsClosed
        {
            get
            {
                return true;
            }
        }

        public void Dispose()
        {
        }

        public bool Read()
        {
            if (DR==null || i >= DR.Table.Rows.Count -1)
                return false;
            i++;
            DR = DR.Table.Rows[i];
            return true;
        }

        public bool HasRows
        {
            get
            {
                return Table != null && Table.Rows.Count > 0;
            }
        }

        public int FieldCount
        {
            get
            {
                if (Table == null)
                    return 0;
                return  Table.Columns.Count;
            }
        }

        public string GetName(int i)
        {
            if (Table != null)
                return Table.Columns[i].ColumnName;
            return "";
        }

        public object GetValue(int i)
        {
            return this[i];
        }
    }
}
