//test1111
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class JAction : JCore
    {
        public JAction()
        { }
        public bool Enabled = true;
        private string _Name;
        public string Name
        {
            set { _Name = value; }
            get
            {
                return _Name;
            }
        }

        private string _Namespace;
        private string _Classname;
        private string _Methodname;

        private static string _oldNamespace;
        private static string _oldClassName;
        private static object[] _oldConstArg;
        private static object _oldobj;

        public string ActionCommand;

        private object[] _Arg;
        private object[] _ConstArg;
        public object Obj;
        public object SenderObject;

        public delegate void BeforRunEventHandler(object sender);
        public event BeforRunEventHandler BeforRun;

        public delegate void AfterRunEventHandler(object sender);
        public event AfterRunEventHandler AfterRun;


        public object[] Arg
        {
            set
            {
                _Arg = value;
            }
            get
            {
                return _Arg;
            }
        }
        public object[] ConstArg
        {
            set
            {
                _ConstArg = value;
            }
            get
            {
                return _ConstArg;
            }
        }

        private bool _CleareList = false;
        public bool CleareList
        {
            get
            {
                return _CleareList;
            }
        }

        public JAction[] Childs = new JAction[0];

        public JAction(string pName, string pActions)
            : this(pName, pActions, null, null, false)
        {
        }

        public JAction(string pName, string pActions, object[] pArg, object[] pConstArg)
            : this(pName, pActions, pArg, pConstArg, false)
        {
        }

        public JAction(string pName, string pActions, object[] pArg, object[] pConstArg, bool pClearList)
        {
            if (pActions != null && pActions.Length > 0)
            {
                ActionCommand = pActions;
                _Namespace = "";
                string dot = "";
                string[] action = pActions.Split('.');
                for (int i = 0; i < action.Length - 2; i++)
                {
                    _Namespace = _Namespace + dot + action[i].Trim();
                    dot = ".";

                }
                _Classname = action[action.Length - 2].Trim();
                _Methodname = action[action.Length - 1].Trim();
            }
            _Arg = pArg;
            _ConstArg = pConstArg;
            _CleareList = pClearList;
            _Name = pName;
        }


        public object run()
        {
            return run(false);
        }

        public object run(bool pCheckOld)
        {
            if (Obj != null)
                return run(Obj);
            else
                return run(null, pCheckOld);
        }

        static Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        static Dictionary<string, Type> Types = new Dictionary<string, Type>();
        public object run(JListViewsNodes pNodes, bool pCheckOld)
        {
            System.Diagnostics.Stopwatch watch;
            double D;

            if (BeforRun != null)
                BeforRun(SenderObject);

            try
            {
                if (!JMainFrame.IsWeb())
                    if (JMainFrame.CurrentUser != null && !JMainFrame.CurrentUser.UserIsLogin())
                    {
                        Employment.JLogin Login = new Employment.JLogin();
                        Login.Show();
                    }

                if (!pCheckOld || (_oldNamespace != _Namespace || _oldClassName != _Classname || !Array.Equals(_oldConstArg, _ConstArg)))
                {
                    _oldNamespace = _Namespace;
                    _oldClassName = _Classname;
                    _oldConstArg = _ConstArg;
                    if (Obj != null)
                        return run(Obj);
                    Assembly asm;
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    if (!Assemblies.TryGetValue(_Namespace.Split('.')[0], out asm))
                    {
                        asm = Assembly.Load(_Namespace.Split('.')[0]);
                        Assemblies.Add(_Namespace.Split('.')[0], asm);
                    }
                    D = watch.Elapsed.TotalMilliseconds;

                    Type type;
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    if (!Types.TryGetValue(_Namespace + "." + _Classname, out type))
                    {
                        type = asm.GetType(_Namespace + "." + _Classname);
                        Types.Add(_Namespace + "." + _Classname, type);
                    }
                    D = watch.Elapsed.TotalMilliseconds;

                    watch = System.Diagnostics.Stopwatch.StartNew();
                    _oldobj = asm.CreateInstance(_Namespace + "." + _Classname, false, BindingFlags.Default, null, _ConstArg, null, null);
                    D = watch.Elapsed.TotalMilliseconds;
                }
                object obj = RunInstance(_oldobj, _Methodname, _Arg);

                if (AfterRun != null)
                    AfterRun(SenderObject);

                return obj;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }

        }


        public object run(object pObj)
        {
            if (BeforRun != null)
                BeforRun(SenderObject);
            object obj;
            if (pObj is JListViewsNodes)
                obj = run((JListViewsNodes)pObj, false);
            else
                if (pObj == null)
                obj = run(null, false);
            else
                obj = RunInstance(pObj, _Methodname, _Arg);

            if (AfterRun != null)
                AfterRun(SenderObject);
            return obj;
        }

        public void AddArg(object pObj)
        {
            Array.Resize(ref _Arg, Arg.Length + 1);
            _Arg[_Arg.Length - 1] = pObj;
        }

        public override string ToString()
        {
            try
            {
                return _Namespace + '.' + _Classname + '.' + _Methodname;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// درج در جدول اکشن ها
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="FunctionName"></param>
        /// <param name="Arguments"></param>
        /// <param name="ConstArguments"></param>
        public static void Insert(string ActionName, string FunctionName, string Arguments, string ConstArguments)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"DECLARE @Code INT " +
                    JDataBase.GetInsertSQL("Actions") +

                        @"INSERT INTO Actions (Code, ActionName, FunctionName, Arguments, ConstArguments)
                        VALUES (@Code," + JDataBase.Quote(ActionName) + ", " + JDataBase.Quote(FunctionName) + ", " + JDataBase.Quote(Arguments) + ", " + JDataBase.Quote(ConstArguments) + ")");
                DB.Query_Execute();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void Load()
        {
        }

        public static DataTable LoadData()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList.ToString() + " * FROM Actions ");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static JAction XmlToAction(string XMLStr)
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(XMLStr);
                JAction _action = (JAction)JSerialization.DeserializeXML(doc, typeof(JAction));
                return _action;
            }
            catch
            {
                return null;
            }
        }


        public static object RunInstance(object pInstanse, string pMethodName, object[] pParams)
        {
            try
            {
                if (pInstanse == null)
                    return null;
                Type type = pInstanse.GetType();
                try
                {
                    object ret = type.InvokeMember(
                    pMethodName,
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null,
                    pInstanse,
                    pParams
                    );
                    return ret;
                }
                catch (Exception ex)
                {
                }

            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            return null;
        }

        public void AddChild(JAction pAction)
        {
            Array.Resize(ref Childs, Childs.Length + 1);
            Childs[Childs.Length - 1] = pAction;
        }

        public static object onlineCode(string pText)
        {
            return null;
        }
    }
}
