using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class JPopupMenu: JCore
    {
        public Object[] Actions = new Object[0];
        private JListViewsNodes _Nodes;
        private int _Last = 0;
        
        public JPopupMenu()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassName"> نام کلاسی که در آن هستیم برای استفاده در راهنما namespace.classname</param>
        public JPopupMenu(string pClassName, int pObjectCode)
        {
            BaseAction(pClassName, pObjectCode);
        }
        public void BaseAction(string pClassName, int pObjectCode)
        {
            ClearItems();
            JAction splitter = new JAction("-", "");

            JAction Ac = new JAction("Help", "ClassLibrary.JSystem.ShowHelp", new object[] { pClassName }, null);
            Insert(Ac);
            JAction History = new JAction("History", "ClassLibrary.JHistory.ShowModal", new object[] { pObjectCode }, new object[] { pClassName });
            Insert(History);
            //JAction Refresh = new JAction("Refresh", "ClassLibrary.JListViewsNodes.RefreshNode", null, null);
            //Refresh.Obj = JSystem.Nodes;
            //Insert(Refresh);

            Insert(splitter);
            
//          JAction PermissionAction = new JAction("Permission", "Globals.JPermissionObject.ShowDialog", null, new object[] { pClassName, pObjectCode });
//          Insert(PermissionAction);
        }

        public void Clear()
        {
        }

        public void ClearItems()
        {
            try
            {
                for (int i = 0; i < Actions.Length; i++)
                {
                    JAction Action = (JAction)Actions[i];
                    if (Action != null)
                        Action.Dispose();
                }
            }
            catch
            {
            }
            _Last = 0;
            Array.Resize(ref Actions, 0);
        }

        public override void Dispose()
        {
            ClearItems();
            base.Dispose();
        }

        public void InsertSubMenu(string pName, JAction[] Actions)
        {

        }

        public void Insert(Object pAction)
        {
            Array.Resize(ref Actions, _Last + 1);

            Actions[_Last] = pAction;
            _Last++;
        }

        //public ContextMenuStrip GetPopup(bool Inverse)
        //{
        //    return GetPopup(null, Inverse);
        //}
        //public ContextMenuStrip GetPopup()
        //{
        //    return GetPopup(null, false);
        //}
        public ContextMenuStrip GetPopup(JListViewsNodes pNodes)
        {
            return GetPopup(pNodes, false);
        }
        public ContextMenuStrip GetPopup(JListViewsNodes pNodes, bool Inverse)
        {
            if (pNodes != null)
                _Nodes = pNodes;
            ContextMenuStrip Popup = new ContextMenuStrip();
            Popup.RightToLeft = RightToLeft.Yes;
            //Popup.RightToLeft = RightToLeft.Inherit;
            if (Inverse)
            {
                for (int i = 0; i < Actions.Length; i++)
                {
                    if (Actions[i] is JAction)
                    {
                        EventHandler e = new EventHandler(run);
                        ToolStripItem ti = Popup.Items.Add(JLanguages._Text(((JAction)Actions[i]).Name), null, e);
                        ti.Tag = Actions[i];
                        ti.Enabled = ((JAction)Actions[i]).Enabled;
                    }
                    else
                        if (Actions[i] is string)
                            Popup.Items.Add((string)Actions[i]);
                        else
                        {
                        }
                }
                return Popup;
            }
            else
            {
                for (int i = Actions.Length - 1; i > -1; i--)
                {
                    if (Actions[i] is JAction)
                    {
                        EventHandler e = new EventHandler(run);
                        ToolStripItem ti = Popup.Items.Add(JLanguages._Text(((JAction)Actions[i]).Name), null, e);
                        ti.Tag = Actions[i];
                        ti.Enabled = ((JAction)Actions[i]).Enabled;
                        GetSubMenu(ti, (JAction)Actions[i]);
                    }
                    else
                        if (Actions[i] is string)
                            Popup.Items.Add((string)Actions[i]);
                        else
                        {
                        }
                }
                return Popup;
            }
        }

        private void GetSubMenu(ToolStripItem pToolStripItem, JAction pAction)
        {
            for (int i = pAction.Childs.Length - 1; i > -1; i--)
            {
                EventHandler e = new EventHandler(run);
                ToolStripItem ti = ((ToolStripMenuItem)pToolStripItem).DropDownItems.Add(JLanguages._Text((pAction.Childs[i]).Name), null, e);
                ti.Tag = pAction.Childs[i];
                ti.Enabled = pAction.Childs[i].Enabled;
                GetSubMenu(ti, pAction.Childs[i]);
            }
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run(_Nodes);
            if (_Nodes != null)
                _Nodes.refreshGrid(false,true);
        }
    }
}
