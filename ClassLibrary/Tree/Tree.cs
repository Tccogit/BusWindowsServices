using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ClassLibrary
{
    /// <summary>
    /// انواع درخت 
    /// </summary>
    public enum JTreeTypes
    {
        OrganizationUnit = 1,  ///واحدهای سازمانی
        Secretariats = 2,  //// دبیر خانه
        WorkFolders = 3,   /// کارپوشه
        UserFolders = 4,    
        MetierTopics = 5, ///عناوین شغلی
        ArchivedSubjectTree = 6 ///درخت موضوعات آرشیو
    }
    /// <summary>
    /// برای ایجاد نود یک درخت از این کلاس استفاده میگردد
    /// </summary>
    public class JTreeNode: JSystem
    {
        /// <summary>
        /// کد نود در بانک اطلاعاتی
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// عنوان کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد درخت
        /// </summary>
        public JTreeTypes  TreeCode { get; set; }
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// نام نود
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد پدر
        /// </summary>
        public int ParentCode { get; set; }
        /// <summary>
        /// وضعیت به لحاظ فعال یا غیر فعال بودن
        /// </summary>
        public Boolean State { get; set; }
        public int MainCode { get; set; }
        public int ExtraCode1 { get; set; }
        public int ExtraCode2 { get; set; }
        /// <summary>
        /// عملی که بایدبا کلیک بر روی نود انجام گردد
        /// </summary>
        public JAction Action;
        public string ActionXML
        {
            get
            {
                return Action.ToString();
            }
            set
            {
                Action = JAction.XmlToAction(value);
            }
        }
        public TreeView _treeView;
        public TreeView treeView
        {
            get
            {
                return _treeView;
            }
        }
        /// <summary>
        /// در هنگام ساخت این کلاس نام کلاس ایجاد کننده درخت و کد شی در بانک وارد میگردد
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pTreeCode">نوع درخت</param>
        /// <param name="pCode">کد نود</param>
        public JTreeNode(string pClassName, JTreeTypes pTreeCode, int pCode)
        {
            ClassName = pClassName;
            TreeCode = pTreeCode;
            Code = pCode;
            GetData(Code);
        }
        public JTreeNode(JTree tree, int pCode)
        {
            ClassName = tree.ClassName;
            TreeCode = tree.TreeCode;
            Code = pCode;
            GetData(Code);
        }
        
        /// <summary>
        /// فرزندان
        /// </summary>
        private int[] _ChildsCode;
        /// <summary>
        /// نام جدول در بانک اطلاعاتی
        /// </summary>
        private string _TableName = "tree";

        public JTreeNode()
        {
        }
        public JTreeNode(JTree pTree)
        {
            TreeCode = pTree.TreeCode;
            ClassName = pTree.ClassName;
        }
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
        /// <summary>
        /// ویرایش اطلاعات یک نود
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            JTreeTable JTT = new JTreeTable();
            JTT.SetValueProperty(this);
            JTT.Update();
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
            JTreeNode node = new JTreeNode();
            node.GetData(pCode);
            if (DeleteChildren)
            {
                foreach (int ChildCode in node.ChildsCode)
                {
                    Delete(ChildCode, true);
                }
            }
            else
            {
                if (node.ChildsCode.Length > 0)
                    return false;
            }
            JTreeTable JTT = new JTreeTable();
            JTT.Code = pCode;
            JTT.Delete();
            return true;
        }

        public Boolean Delete(string ClassName, int ObjectCode, JTreeTypes TreeType)
        {
            JTreeNode node = new JTreeNode();
            int _NodeCode = node.Find(ClassName, ObjectCode, TreeType);
            return node.Delete(_NodeCode, false);
        }
        /// <summary>
        /// تغییر نام نود درخت. (فقط در صورتیکه نام قدیم با نام نود برابر باشد تغییر نام انجام میشود)ا
        /// </summary>
        /// <param name="ClassName"></param>
        /// <param name="ObjectCode"></param>
        /// <param name="OldName"></param>
        /// <param name="NewName"></param>
        /// <param name="TreeType"></param>
        /// <returns></returns>
        public Boolean RenameNode(string ClassName, int ObjectCode,string OldName, string NewName, JTreeTypes TreeType)
        {
            JTreeNode node = new JTreeNode();
            int nodeCode = node.Find(ClassName, ObjectCode, TreeType);
            if (nodeCode > 0)
            {
                node.GetData(nodeCode);
                if (node.Name != OldName)
                    return false;
                node.Name = NewName;
                node.Update();
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// درج یک نود جدید در درخت
        /// </summary>
        /// <returns>کد درج شده در بانک اطلاعاتی</returns>
        public int Insert()
        {
            if (Find(this.ClassName, this.ObjectCode, this.TreeCode) > 0)
                return -1;
            JTreeTable JTT = new JTreeTable();
            JTT.SetValueProperty(this);
            return JTT.Insert();
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
                DB.setQuery("SELECT [Code] FROM " + _TableName + " WHERE code=" + pCode.ToString());
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
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
        public int Find(string pClassName, int pObjectCode, JTreeTypes TreeType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [code] FROM " + _TableName + " WHERE classname=" + JDataBase.Quote(pClassName) +
                        " AND objectcode = " + pObjectCode.ToString() + " AND treecode=" + TreeType.GetHashCode().ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return Convert.ToInt32(DB.DataReader["Code"]);
                }
                else
                {
                    return 0;
                }
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
                DB.setQuery("SELECT * FROM " + _TableName + " WHERE code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    if (DB.DataReader.HasRows)
                    {
                        JTable.SetToClassProperty(this, DB.DataReader);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
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

        private void _GetChileds()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [code] FROM " + _TableName + " WHERE parentcode=" + Code.ToString());
                DB.Query_DataReader();
                _ChildsCode = new int[DB.RecordCount];
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    _ChildsCode[Count++] = Int32.Parse(DB.DataReader["code"].ToString());
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public override string ToString()
        {
            return Name;
        }    
        

    }

    public class JTree: JSystem
    {
        private JTreeTypes _TreeCode;
        private List<JTreeNode> _Nodes = new List<JTreeNode>();
        private string _ClassName;
        //private JTreeNode[] _Roots;
        
        public JTreeTypes TreeCode
        {
            get
            {
                return _TreeCode;
            }
            set
            {
                _TreeCode = value;
            }
        }
        public List<JTreeNode> TreeNodes 
        {
            get
            {
                return _Nodes;
            }
        }
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }

        
        public JTree(JTreeTypes PTreeCode, string pClassName)
        {
            _TreeCode = PTreeCode;
            _ClassName = pClassName;
            _LoadTree();
        }

        private void _LoadTree()
        {
            int nodeCode = 0;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT code,parentcode FROM tree WHERE treecode=" + _TreeCode.GetHashCode().ToString() + " AND classname=" + JDataBase.Quote(ClassName));
                DB.Query_DataReader();
                while (DB.DataReader.Read())
                {
                    JTreeNode Node = new JTreeNode();
                    nodeCode = int.Parse(DB.DataReader["code"].ToString());
                    Node.GetData(nodeCode);
                    _Nodes.Add(Node);
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool HasTree()
        {
            JTreeNode Node;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT Code FROM tree WHERE treecode=" + _TreeCode.ToString() + " AND ParentCode=0");
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int CreateEmptyTree(JTreeNode pNode)
        {
            return pNode.Insert();
        }

        public void ArrangeTree(TreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (JTreeNode _tNode in this.TreeNodes)
            {
                TreeNode node;
                if (_tNode.ParentCode == 0)
                {
                    node = treeView.Nodes.Add(_tNode.ToString());
                    node.Tag = _tNode;
                    getChildren(node);
                }
            }
            //LoadNodes();
            treeView.Refresh();
        }

        private void getChildren(TreeNode node)
        {
            JTreeNode tNode = (JTreeNode)node.Tag;
            foreach (JTreeNode _tNode in this.TreeNodes)
            {
                TreeNode Node;
                if (_tNode.ParentCode == tNode.Code)
                {
                    Node = node.Nodes.Add(_tNode.ToString());
                    Node.Tag = _tNode;
                    getChildren(Node);
                }
            }
        }
    }
}
