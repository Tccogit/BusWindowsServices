using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using ClassLibrary;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace ClassLibrary
{

    public class JTreeView : JSystem
    {
        TreeNode Root;

        public JTreeView()
        {
            Root = new TreeNode();
        }

        public int load(string XmlFile)
        {
            return 0;
        }

        private string getAttribNode(XmlNode Node, string attname)
        {
            if (Node.Attributes.GetNamedItem(attname) != null)
            {
                return Node.Attributes.GetNamedItem(attname).Value;
            }
            return "";
        }

    }



    public class JListView : JSystem
    {

        private JListViewActions ListViewActions = new JListViewActions();
        private JAction _CurrentAction;
        public JAction CurrentAction
        {
            get
            {
                return _CurrentAction;
            }
            set
            {
                _CurrentAction = value;
                if (value != null && value is JAction)
                {
                    ListViewActions.Push(value);
                }
                Nodes.CurrentAction = value;
            }
        }

        public static TabPage PerTabPage;
        public JListView(ListView pListView, TabControl pTabControl)
        {
            TabPage TT = new TabPage();
            pTabControl.TabPages.Add(TT);

            Nodes = new JListViewsNodes(TT, null);
            Nodes.AddListView(pListView);
            Nodes.ToolStripInt = null;
            Nodes.ToolStripNode = null;
        }

        public JListView(ListView pListView, ToolStrip pToolStrip, ToolStrip pToolStripNode, TreeView pTreeView, Janus.Windows.ButtonBar.ButtonBar pButtonBar
            , TabControl pTabControl, StatusStrip pStatusStrip, Panel pAddressPanel, JShortCuts pShortCuts)
        {
            //if (pJanusGrid != null)
                //pJanusGrid.DataSource = GlobalTable;

            //TabPage TT = new TabPage();
            //pTabControl.TabPages.Add(TT);

            pTabControl.Selected += new TabControlEventHandler(pTabControl_Selected);
            pTabControl.Selecting += new TabControlCancelEventHandler(pTabControl_Selecting);

            Nodes = new JListViewsNodes(null, null);
            Nodes.AddListView(pListView);
            Nodes.ToolStripInt = pToolStrip;
            Nodes.ToolStripNode = pToolStripNode;
            Nodes.TreeNodes.AddTreeView(pTreeView);
            Nodes.AddBottunBar(pButtonBar);
            //Nodes.JanusGrid = pJanusGrid;
            Nodes.StatusStripMain = pStatusStrip;
            Nodes.TreeNodes.AddressPanel = pAddressPanel;
            Nodes.ShortCuts = pShortCuts;
            JTreeViewsNodes.TabControler = pTabControl;
            JFreeClass.RUN(new JAction("lo", "ClassLibrary.JMainFrame.Check"));

        }

        void pTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //PerTabPage = (e.TabPage.Parent as TabControl).SelectedTab;
        }

        void pTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage!=null && e.TabPage.Tag != null)
            {
                (e.TabPage.Tag as JListViewsNodes).RefreshToolbar();
                JSystem.Nodes = (e.TabPage.Tag as JListViewsNodes);
                if (JSystem.Nodes.DataTable!=null && JSystem.Nodes.DataTable.DefaultView != null)
                {
                    JSystem.Nodes.StatusStripMain.Items[0].Text = JSystem.Nodes.DataTable.DefaultView.Count.ToString();
                }
                //JSystem.Nodes.StatusStripMain.Items[2].Text = JDataBase.OpenDatabase.ToString();
                JSystem.Nodes.TreeNodes.ListViewNodes = JSystem.Nodes;
                JSystem.Nodes.TreeNodes.RefreshAddressBar(JSystem.Nodes.TreeNodeSelectedTreeView);
            }
        }



        public int NodeLoad()
        {
            if (Nodes == null) return 0;

            foreach (JNode node in Nodes.Items)
            {
                Nodes.Insert(node);
            }
            return 0;
        }


        private Boolean CrateDynamicListNode(JAction jnode)
        {
            return true;
        }
        private string getAttribNode(XmlNode Node, string attname)
        {
            if (Node.Attributes.GetNamedItem(attname) != null && Node.Attributes.GetNamedItem(attname).Value.Length > 0)
            {
                return Node.Attributes.GetNamedItem(attname).Value;
            }
            return null;
        }

        private void _Refresh(JAction Action)
        {
            if (Action != null)
                Action.run(Nodes);
        }

        public void Refresh()
        {
            _Refresh(CurrentAction);
        }

    }

    public class JListViewActions
    {
        public static JAction[] Items = new JAction[0];
        public int Length = 0;
        public int Current = -1;

        public JAction Pop()
        {
            if (Length > 0)
            {
                JAction Ret = Items[Length - 1];
                Length--;
                return Ret;
            }
            return null;
        }

        public void Push(JAction pNode)
        {
            Array.Resize(ref Items, Length + 1);
            Items[Length] = pNode;
            Length++;
        }
    }

    public class JFreeClass
    {

        private static string Key;

        public static bool RUN(JAction Action)
        {
            try
            {
                    if (!(bool)Action.run())
                    {
                        return false;
                    }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Check()
        {
            return true;
            //Random ran = new Random();

            //if (ran.Next(10) == 9)
            //    if (!pingServer())
            //        return false;
            //JFile File = new JFile();

            //File.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\database.lxt";

            //if (File.Exists())
            //{

            //    File.Read();
            //    File.FileText = File.ReadFileText();
            //    string strfile = JEnryption.DecryptStr(File.FileText, JFreeClass.geKey());
            //    string strlock = LogicalSerialNumber();
            //    bool ch = (strfile == strlock);
            //    if (!ch)
            //    {
            //        closeProgram();
            //    }
            //    return ch;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static string geKey()
        {
           
            if (Key != null && Key.Length > 0)
                return Key;
            
            string _Name = System.AppDomain.CurrentDomain.FriendlyName;
            //if (JSystem.DesckTopProject && !(_Name.IndexOf("ERP") != -1 || _Name.IndexOf("NotificationProjects") != -1))
            //    {
            //        JMainFrame.Terminated = 1;
            //        System.Windows.Forms.Application.Exit();
            //    }

            string _NodeWidth;
            JFile File = new JFile();
            File.FileName = JConfig.appPath + "\\number.lxt";
            if (System.IO.File.Exists(File.FileName)
                && 
                (
                    JMainFrame.Key == "626e5c3d-c8db-4529-940d-6ef16db4c5c2"
                    ||
                    JMainFrame.Key == ""
                    ||
                    JMainFrame.Key == null
                )
                && File.Read())
            {
                _NodeWidth = "626e5c3d-c8db-4529-940d-6ef16db4c5c2";
                File.FileText = File.ReadFileText();
                Key = JEnryption.DecryptStr(File.FileText, _NodeWidth);
                if (Key.Length > 0)
                    return Key;
            }
         
            //views.NumberFileForm NF = new ClassLibrary.views.NumberFileForm();
            //NF.ShowDialog();
            //return JFreeClass.geKey();
            return "";
        }

        public static void setKey(string pKey)
        {
            string _NodeWidth = "626e5c3d-c8db-4529-940d-6ef16db4c5c2";

            JFile File = new JFile();
            File.FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\number.lxt";
            #region
            File.FileText = JEnryption.EncryptStr(pKey, _NodeWidth);
            File.Write();
            _NodeWidth = "";
            #endregion
        }

        public static string LogicalSerialNumber()
        {
            string SerialNo = "";
            SerialNo = System.Environment.MachineName;
            return SerialNo.Trim();
        }

        static void closeProgram()
        {
            System.Windows.Forms.Application.Exit();
        }

        public static void hangProgram()
        {
            System.Windows.Forms.Application.Exit();
        }

        public static bool pingServer()
        {
            return pingServer("storage-server.3epad.net");
        }
        public static bool pingServer(string phost)
        {
            
            Ping PingSend = new Ping();
            PingReply pr = PingSend.Send(phost);
            if (pr.Status == IPStatus.Success)
                return true;
            return false;
        }
    }
}




