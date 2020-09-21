using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	/// <summary>
	/// کلاس پدر برای تمام کلاسهای درون این فضای کاری
	/// </summary>
    [Serializable()]
    public class JBase : IDisposable
	{
		#region Except
		protected static JException _Except = new JException();
		public static JException Except
		{
			get
			{
					if (_Except == null)
						_Except = new JException();
					return _Except;
			}
			set
			{
				_Except = value;
			}
		}
		#endregion

		#region GuidCode
		private static Guid _GuidCode = Guid.NewGuid();
		public static Guid GuidCode
		{
			get
			{
				if (JMainFrame.IsWeb())
				{
					if (WebClassLibrary.SessionManager.Current.MainFrame.GuidCode == Guid.Empty)
						WebClassLibrary.SessionManager.Current.MainFrame.GuidCode = Guid.NewGuid();
					return WebClassLibrary.SessionManager.Current.MainFrame.GuidCode;
				}
				else
				{
					return _GuidCode;
				}
			}
		}
		#endregion

		// Track whether Dispose has been called.
		private bool disposed = false;

		public virtual void Dispose()
		{
			try
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			catch
			{
			}
		}

		private void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed
				// and unmanaged resources.
				if (disposing)
				{
				}

				// Call the appropriate methods to clean up
				// unmanaged resources here.
				// If disposing is false,
				// only the following code is executed.
				// Note disposing has been done.
				disposed = true;

			}
		}

	}

	public class JSystem : JBase
	{
		public static JException Except
		{
			get
			{
				if (_Except == null)
					_Except = new JException();
				return _Except;
			}
			set
			{
				_Except = value;
			}
		}
		public static bool SMSSend = true;

		public static bool WebConnect
		{
			get
			{
				return JMainFrame.IsWeb();
			}
		}

		public static bool DesckTopProject = !JMainFrame.IsWeb();
		/// <summary>
		/// 
		/// </summary>
		public static JHistory Histroy;
		/// <summary>
		/// کد ارجاع یک شدی در اتوماسیون
		/// </summary>
		public int Current_Refer_Code = 0;

		/// <summary>
		/// 
		/// </summary>
		//public JPermission Permission = new JPermission();

		private static JListViewsNodes[] Nodeses;

		private static JListViewsNodes CurrentNodes;

		private static int CurrentNodesIndex;

		/// <summary>
		/// 
		/// </summary>
		private static JListViewsNodes _Nodes;
		public static JListViewsNodes Nodes
		{
			get
			{
				if (JMainFrame.IsWeb())
				{
					if (_Nodes == null)
						_Nodes = new JListViewsNodes(null, null);
					return _Nodes;
				}
				else
				{
					return _Nodes;
				}
			}
			set
			{
				if (JMainFrame.IsWeb())
				{
				}
				else
				{
					AddNodes(value);
					_Nodes = value;
					if (_Nodes != null && _Nodes.TabPageBase != null)
						CurrentNodes = _Nodes;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private static System.Data.DataTable _GlobalTable;
		public static System.Data.DataTable GlobalTable
		{
			get
			{
				if (JMainFrame.IsWeb())
				{
					return WebClassLibrary.SessionManager.Current.MainFrame.GlobalTable;
				}
				else
				{
					return _GlobalTable;
				}
			}
			set
			{
				if (JMainFrame.IsWeb())
				{
					WebClassLibrary.SessionManager.Current.MainFrame.GlobalTable = value;
				}
				else
				{
					_GlobalTable = value;
				}
			}
		}

		#region Functions
		private static void AddNodes(JListViewsNodes pNodes)
		{
			if (Nodeses == null) Nodeses = new JListViewsNodes[0];
			if (pNodes.TabPageBase != null && findNodes(pNodes.CurrentAction) == null)
			{
				Array.Resize(ref Nodeses, Nodeses.Length + 1);
				Nodeses[Nodeses.Length - 1] = pNodes;
				CurrentNodes = pNodes;
			}
		}

		public static int GetNodeIndex(JListViewsNodes pNodes)
		{
			for (int i = 0; i < Nodeses.Length; i++)
			{
				if (Nodeses[i] == pNodes)
				{
					return i;
				}
			}
			return -1;
		}

		public static void FreeNodes(JListViewsNodes pNodes)
		{
			int index = GetNodeIndex(pNodes);
			if (index < 0) return;
			for (int i = index; i < Nodeses.Length - 1; i++)
			{
				Nodeses[i] = Nodeses[i + 1];
			}
			Array.Resize(ref Nodeses, Nodeses.Length - 1);
		}


		public static JListViewsNodes findNodes(JAction pAction)
		{
			if (pAction == null)
				return null;
			foreach (JListViewsNodes N in Nodeses)
			{
				if (N.CurrentAction == null || (N.CurrentAction.ActionCommand == pAction.ActionCommand && N.CurrentAction.Arg == pAction.Arg
					&& N.CurrentAction.ConstArg == pAction.ConstArg))
				{
					CurrentNodes = N;
					return N;
				}
			}
			return null;
		}

		private static object[] _Objects;

		/// <summary>
		/// 
		/// </summary>
		public JSystem()
		{
			try
			{
             //   if (JMainFrame.IsWeb())
             //       return;
				//string _Name = System.AppDomain.CurrentDomain.FriendlyName;


				//if (!(_Name.IndexOf("ERP") != -1 || _Name.IndexOf("NotificationProjects") != -1))
				//{
					//JMainFrame.Terminated = 1;
					//System.Windows.Forms.Application.Exit();
				//}
				if (Histroy == null)
					Histroy = new JHistory(this);
				//Lock.JLock l = new ClassLibrary.Lock.JLock();
				//if (!l.CheckLock())
				//{
					//System.Windows.Forms.MessageBox.Show("lock");
					//JMainFrame.Terminated = 1;
					//System.Windows.Forms.Application.Exit();
				//}
			}
			catch
			{
			}
		}

		/// <summary>
		/// ذخیره تاریخچه یک عمل
		/// </summary>
		/// <param name="Description">توضیحات</param>
		/// <param name="OCode">کد شی</param>
		/// 
		public void AddHistory(string Description, int OCode)
		{
			Histroy.Save(Description, this.GetType().Name, OCode);
		}

		public void ShowHelp(object t1)
		{

		}
		public void ListView()
		{
			Nodes.clear();

			JBaseDefine city = new JBaseDefine();
			JBaseDefine CompanyType = new JBaseDefine();

			JNode node = new JNode(0, "Globals.JUsers");
			node.Name = "Users";
			node.MouseClickAction = new JAction("Users List", "Globals.JUsers.ListView");
			node.Icone = JImageIndex.Users.GetHashCode();
			// Nodes.Insert(JStaticNode._PersonsNode());
			//Nodes.Insert(JStaticNode._LegalPersonsNode());
			Nodes.Insert(JStaticNode._AllPerson());
			Nodes.Insert(JStaticNode._BaseDefine());

			// Nodes.Insert(city.GetNode(JBaseDefine.CityCode));
			// Nodes.Insert(CompanyType.GetNode(JBaseDefine.CompanyTypes));
			Nodes.Insert(node);
			Nodes.Insert(JStaticNode._Successor());
			Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.ClassLibrary));
			Nodes.Insert(JStaticNode._SetPermissions());
			Nodes.Insert(JStaticNode._ShowSendSMSForm());

		}

		public JNode[] TreeView()
		{
			JBaseDefine city = new JBaseDefine();
			JBaseDefine CompanyType = new JBaseDefine();

			JNode node = new JNode(0, "Globals.JUsers");
			node.Name = "Users";
			node.MouseClickAction = new JAction("Users List", "Globals.JUsers.ListView");
			node.Icone = JImageIndex.Users.GetHashCode();

			JNode[] TNodes = new JNode[9];
			TNodes[0] = JStaticNode._BaseDefine();
			TNodes[1] = JStaticNode._AllPerson();
			//   TNodes[1] = city.GetNode(JBaseDefine.CityCode);
			//  TNodes[2] = CompanyType.GetNode(JBaseDefine.CompanyTypes);
			TNodes[2] = node;
			TNodes[3] = JStaticNode._Successor();
			TNodes[4] = ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.ClassLibrary);
			TNodes[5] = JStaticNode._SetPermissions();
			TNodes[6] = JStaticNode._ShowSendSMSForm();
            TNodes[7] = JStaticNode._ShowFormManager();
            TNodes[8] = JStaticNode._ShowFormCustomQuery();
            return TNodes;
		}


		public static void AddObject(ref object pPic)
		{
			return;
			if (_Objects == null)
				_Objects = new object[0];
			for (int i = 0; i < _Objects.Length; i++)
			{
				if (_Objects[i] == null && pPic is System.Data.SqlClient.SqlDataReader)
				{
					_Objects[i] = pPic;
					return;
				}
			}
			Array.Resize(ref _Objects, _Objects.Length + 1);
			_Objects[_Objects.Length - 1] = pPic;
		}

		public static void FreeObjectsDataReaer()
		{

			if (_Objects != null)
			{
				for (int i = 0; i < _Objects.Length; i++)
				{
					try
					{
						if (_Objects[i] != null)
						{
							if (_Objects[i] is System.Data.SqlClient.SqlDataReader)
							{
								(_Objects[i] as System.Data.SqlClient.SqlDataReader).Close();
								(_Objects[i] as System.Data.SqlClient.SqlDataReader).Dispose();
								_Objects[i] = null;
							}
						}
					}
					catch
					{
					}
				}
			}
		}

		public static void FreeObjectsDataTable()
		{

			if (_Objects != null)
			{
				for (int i = 0; i < _Objects.Length; i++)
				{
					try
					{
						if (_Objects[i] != null)
						{
							if (_Objects[i] is System.Data.DataTable
								&&
								(_Objects[i] as System.Data.DataTable).Rows.Count <= 50

								)
							{
								System.Data.DataTable _DT = (System.Data.DataTable)_Objects[i];
								_DT.Clear();
								_DT.Dispose();
								_DT = null;
								_Objects[i] = null;
							}
						}
					}
					catch
					{
					}
				}
			}
		}

		private static void FreeObjects()
		{
			if (_Objects != null)
			{
				for (int i = 0; i < _Objects.Length; i++)
				{
					try
					{
						if (_Objects[i] != null)
						{
							if (_Objects[i] is ClassLibrary.JBaseForm)
							{
								if (!(_Objects[i] as ClassLibrary.JBaseForm).Visible)
								{
									(_Objects[i] as ClassLibrary.JBaseForm).Dispose();
								}
							}
							if (_Objects[i] is System.Drawing.Bitmap)
							{
								(_Objects[i] as System.Drawing.Bitmap).Dispose();
							}
							if (_Objects[i] is System.IO.MemoryStream)
							{
								(_Objects[i] as System.IO.MemoryStream).Dispose();
							}
							if (_Objects[i] is System.Drawing.Image)
							{
								(_Objects[i] as System.Drawing.Image).Dispose();
							}
							if (_Objects[i] is System.Data.DataTable)
							{
								System.Data.DataTable _DT = (System.Data.DataTable)_Objects[i];
								_DT.Clear();
								_DT.Dispose();
								_DT = null;
							}
							if (_Objects[i] is System.Data.SqlClient.SqlDataReader)
							{
								(_Objects[i] as System.Data.SqlClient.SqlDataReader).Close();
								(_Objects[i] as System.Data.SqlClient.SqlDataReader).Dispose();
							}
							_Objects[i] = null;
						}
					}
					catch
					{
					}

				}

				foreach (JListViewsNodes _N in Nodeses)
				{
					_N.Dispose();
				}
				Array.Resize(ref _Objects, 0);
				Array.Resize(ref Nodeses, 0);
			}
		}

		public static void Free()
		{
			FreeObjects();
		}
		#endregion

	}

	public class JSystemNode : JBase
	{
		public static JException Except
		{
			get
			{
				if (_Except == null)
					_Except = new JException();
				return _Except;
			}
			set
			{
				_Except = value;
			}
		}
	}
    [Serializable()]
    public class JCore : JBase
	{
		public static JException Except
		{
			get
			{
				if (_Except == null)
					_Except = new JException();
				return _Except;
			}
			set
			{
				_Except = value;
			}
		}
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
