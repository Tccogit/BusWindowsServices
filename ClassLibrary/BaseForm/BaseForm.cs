using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Globals;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    
    /// <summary>
    /// تمام فرمهای سیستم از این فرم مشتق میگردد
    /// </summary>
    public partial class JBaseForm : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        public JShortCuts ShortCuts;

        /// <summary>
        ///فرم بسته شود یا نه Esc مشخص میکند که با انتخاب کلید
        /// </summary>
        //private bool _DiscardEsc;
        /// <summary>
        ///فرم بسته شود یا نه Esc مشخص میکند که با انتخاب کلید
        /// </summary>
        public bool DiscardEsc
        {
            get;
            set;
        }

        private bool _NextControlOnPressEnter = true;
        /// <summary>
        /// انتخاب کنترل بعدی با فشردن کلید اینتر
        /// </summary>
        public bool NextControlOnPressEnter
        {
            get
            {
                return _NextControlOnPressEnter;
            }
            set
            {
                _NextControlOnPressEnter = value;
            }
        }

        /// <summary>
        /// وضعیت فرم به لحاظ درج یا ویرایش اطلاعات
        /// </summary>
        public JFormState State;
        public JBaseForm()
        {
            try
            {
                InitializeComponent();
                object tObject = this;
                JSystem.AddObject(ref tObject);
            }
            catch
            {

            }
        }

        private void JBaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.DesignMode == false)
                {
                    ShortCuts = new JShortCuts();
                    ShortCuts.Clear();
                    this.Text = JLanguages._Text(this.Text);
                    InitController(this);
                }
            }
            catch
            {

            }
        }

        public void InitController(object sender)
        {

            Type type = sender.GetType();

            //-----------------Permission-----------------
            string Name;
            string Parent;
            int Status;
            //JPermissionControls tmpJPermissionControls = new JPermissionControls();
            //tmpJPermissionControls.Type = 2;
            //tmpJPermissionControls.Class_Name = type.FullName;
            //tmpJPermissionControls.Object_Name = type.Name;
            //Parent=tmpJPermissionControls.Class_Name;
            //if(tmpJPermissionControls.CheckPermission(JMainFrame.CurrentPostCode))
            //{
            ///


            FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
            for (int count = 0; count < Finfo.Length; count++)
            {
                try
                {
                    object Obj = Finfo[count].GetValue(sender);
                    if (Obj is DataGridView)
                    {
                        (Obj as DataGridView).ColumnAdded +=
                            new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
                        RefreshDataGridColumns(Obj as DataGridView);
                    }
                    //--------------------------------------------
                    if (Obj is UserControl)
                    {
                        InitController(Obj);
                    }
                    //--------------------------------------------
                    if (Obj is ContextMenuStrip)
                    {
                        (Obj as ContextMenuStrip).ItemAdded +=
                            new System.Windows.Forms.ToolStripItemEventHandler(this.ContextMenuStrip_ItemAdded);
                        foreach (ToolStripMenuItem menu in (Obj as ContextMenuStrip).Items)
                        {
                            menu.Text = JLanguages._Text(menu.Text);
                            RefreshContextMenuDropDownItems(menu.DropDown);
                        }
                    }
                    //--------------------------------------------
                    if (Obj is ListView)
                    {
                        foreach (ListViewGroup item in ((ListView)Obj).Groups)
                        {
                            item.Header = JLanguages._Text(item.Header);
                        }
                    }
                    //--------------------------------------------
                    if (Obj is ToolStripMenuItem)
                    {
                        ((ToolStripMenuItem)Obj).Text = JLanguages._Text(((ToolStripMenuItem)Obj).Text);
                    }
                    //--------------------------------------------
                    if (Obj is ToolStripItem)
                    {
                        ((ToolStripItem)Obj).Text = JLanguages._Text(((ToolStripItem)Obj).Text);
                    }
                    //--------------------------------------------
                    if ((Obj is Label || Obj is RadioButton) && this.RightToLeftLayout)
                    {
                        (Obj as Control).TextChanged +=
                            new System.EventHandler(this.label_TextChanged);
                        (Obj as Control).SizeChanged +=
                            new System.EventHandler(this.label_SizeChanged);

                        ////-----------------------------------                
                        //tmpJPermissionControls.Class_Name = type.Namespace + "." + this.Name + "." + type.Name + "." + (Obj as Control).Name;
                        //tmpJPermissionControls.Object_Name = (Obj as Control).Name;
                        //if (!tmpJPermissionControls.CheckPermission(JMainFrame.CurrentPostCode))
                        //    (Obj as Control).Enabled = false;
                    }
                    //if (Obj is Button)
                    //{
                    //    tmpJPermissionControls.Class_Name = type.Namespace + "." + this.Name;
                    //    tmpJPermissionControls.Object_Name = (Obj as Control).Name;
                    //    if (!tmpJPermissionControls.CheckPermission(JMainFrame.CurrentPostCode))
                    //        (Obj as Control).Enabled = false;
                    //}
                    ////-----------------------------------       

                    Control Cont = (Obj as Control);
                    if ((Cont != null) && !(Cont is TextBox) && !(Cont is ComboBox) && !(Cont is MaskedTextBox))
                        Cont.Text = JLanguages._Text(Cont.Text);

                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
            //} //Permission
        }

        private void JBaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == 13)
            {
                if (_NextControlOnPressEnter)
                {
                    //e.KeyChar = Convert.ToChar(Keys.Tab.GetHashCode());
                    //SendKeys.Send("{TAB}");
                    //SendMessage(this.Handle.ToInt32(), 0x09, 0, 0);

                    if (this.ActiveControl is TextBox)
                        if ((this.ActiveControl as TextBox).Multiline)
                            return;
                    if (this.ActiveControl is RichTextBox)
                        return;

                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled = true;
                }
            }

            if (!DiscardEsc && e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
            if (Convert.ToInt32(e.KeyChar) == 1610)
                e.KeyChar = Convert.ToChar(1740);
            if (Convert.ToInt32(e.KeyChar) == 1603) // ک
                e.KeyChar = Convert.ToChar(1705);


        }

        public void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if(e.Column.HeaderText.ToString().IndexOfAny(new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'}) >= 0)
                e.Column.HeaderText = JLanguages._Text(e.Column.HeaderText);
        }
        #region ContextMenuStrip
        /// <summary>
        /// در هنگام اضافه شدن منوی جدید ContextMenuStrip ترجمه عنوان منوها ی یک 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            e.Item.Text = JLanguages._Text(e.Item.Text);
        }
        /// <summary>
        /// بصورت بازگشتی ContextMenu ترجمه زیر منو های
        /// </summary>
        /// <param name="pToolStripDropDown"></param>
        private void RefreshContextMenuDropDownItems(ToolStripDropDown pToolStripDropDown)
        {
            foreach (ToolStripMenuItem menu in pToolStripDropDown.Items)
            {
                menu.Text = JLanguages._Text(menu.Text);
                RefreshContextMenuDropDownItems(menu.DropDown);
            }
        }
        #endregion ContextMenuStrip

        #region ToolStrip
        /// <summary>
        /// بصورت بازگشتی ToolStrip ترجمه زیر منو های
        /// </summary>
        /// <param name="pToolStripDropDown"></param>
        private void RefreshToolStripDropDownItems(ToolStripDropDown pToolStripMenuItem)
        {
            try
            {
                foreach (ToolStripMenuItem menu in pToolStripMenuItem.Items)
                {
                    menu.Text = JLanguages._Text(menu.Text);
                    RefreshToolStripDropDownItems(menu.DropDown);
                }
            }
            catch
            {

            }
        }
        #endregion ToolStrip
        //-----------------------------------------------------------------------
        public void RefreshDataGridColumns(DataGridView datagridview)
        {
            try
            {
                foreach (DataGridViewColumn column in datagridview.Columns)
                {
                    column.HeaderText = JLanguages._Text(column.HeaderText);
                }
            }
            catch
            {

            }
        }

        private void label_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((sender as Control).Tag == null)
                {
                    int Right = (sender as Control).Right;
                    (sender as Control).Tag = Right;
                }
            }
            catch
            {

            }
        }

        private void label_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                Control L = (sender as Control);
                if (L.Tag == null)
                    return;
                if (L.Tag is int)
                {
                    L.Left = L.Left - (L.Right - ((int)L.Tag));
                    L.Tag = null;
                }
            }
            catch
            {

            }
        }

        private void JBaseForm_KeyDown(object sender, KeyEventArgs e)
        {


        }
        public void ShowFromHamkaran()
        {
            try
            {
                if (!(JPermission.CheckPermission("ClassLibrary.JBaseForm.ShowFromHamkaran")))
                    return;

                JHamkaranForm LF = new JHamkaranForm();
                LF.ShowDialog();
            }
            catch
            {

            }
        }

        private void JBaseForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.L && e.Alt && e.Control)
            {
                JLanguageForm LF = new JLanguageForm();
                LF.ShowDialog();
            }
            else if (e.KeyCode == Keys.A && e.Alt && e.Control)
            {
                ShowFromHamkaran();
            }
            else if (e.KeyCode == Keys.P && e.Alt && e.Control)
            {
                jChangePersonCodeForm LF = new jChangePersonCodeForm(0, 0);
                LF.ShowDialog();
            }
            else
            {
                ShortCuts.Run(e);
            }
        }

        private void JBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Control.ControlCollection Controls = this.Controls;
                foreach (Control Conte in Controls)
                {
                    try
                    {
                        object Obj = Conte;
                        if (Obj is ArchivedDocuments.JArchiveImage)
                        {
                            (Obj as ArchivedDocuments.JArchiveImage).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is PictureBox)
                        {
                            (Obj as PictureBox).Image.Dispose();
                            (Obj as PictureBox).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is DataGridView)
                        {
                            (Obj as DataGridView).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is UserControl)
                        {
                            (Obj as UserControl).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is ContextMenuStrip)
                        {
                            (Obj as ContextMenuStrip).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is ListView)
                        {
                            (Obj as ListView).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is ToolStripMenuItem)
                        {
                            (Obj as ToolStripMenuItem).Dispose();
                        }
                        //--------------------------------------------
                        if (Obj is ToolStripItem)
                        {
                            (Obj as ToolStripItem).Dispose();
                        }
                        //--------------------------------------------
                        if ((Obj is Label || Obj is RadioButton) && this.RightToLeftLayout)
                        {
                            (Obj as Label).Dispose();
                        }
                        //-----------------------------------       

                        Control Cont = (Obj as Control);
                        if ((Cont != null))
                        {
                            (Obj as Control).Dispose();
                        }

                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
