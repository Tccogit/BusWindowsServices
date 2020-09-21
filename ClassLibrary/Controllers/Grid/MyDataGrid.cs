using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace ClassLibrary
{
    public partial class JDataGrid : DataGridView
    {
        #region Properties
        private string[] _DefaultSettings ;
        public string TableName { get; set; }
        public bool ReadHeadersFromDB { get; set; }
        public bool ShowRowNumber { get; set; }
        public string RegistryPath { get; set; }
        public string KeyName { get; set; }
        public bool EnableContexMenu { get; set; }
        /// <summary>
        /// اکشنها
        /// </summary>
        private List<JAction> Actions { get; set; }
        public JPopupMenu ActionMenu { get; set; }
        /// <summary>
        /// ستونی که بر روی آن راست کلیک صورت گرفته
        /// </summary>
        private DataGridViewColumn _RightClickedColumn;
        #endregion

        #region Constructor
        public JDataGrid()
        {
            InitializeComponent();
            RegistryPath = @"Software\Sepad\Automation\GridSettings";// @"Software\" + Application.CompanyName + "\\" + Application.ProductName + @"\GridSettings";
            EnableContexMenu = true;
            ShowRowNumber = true;
            ActionMenu = new JPopupMenu();
        }
        #endregion

        #region Events
        /// <summary>
        /// شماره گذاری سطرها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (!ShowRowNumber)
                    return;
                if (!this.RowHeadersVisible)
                    return;
                // get the row number in leading zero format, 
                //  where the width of the number = the width of the maximum number
                int RowNumWidth = this.RowCount.ToString().Length;
                StringBuilder RowNumber = new StringBuilder(RowNumWidth);
                RowNumber.Append(e.RowIndex + 1);
                while (RowNumber.Length < RowNumWidth)
                    RowNumber.Insert(0, " ");

                // get the size of the row number string
                SizeF Sz = e.Graphics.MeasureString(RowNumber.ToString(), this.Font);

                // adjust the width of the column that contains the row header cells 
                if (this.RowHeadersWidth < (int)(Sz.Width + 20))
                    this.RowHeadersWidth = (int)(Sz.Width + 20);

                // draw the row number
                int gridWidth = this.Width - 35;
                if (this.RightToLeft == RightToLeft.Yes)
                    e.Graphics.DrawString(
                        RowNumber.ToString(),
                        this.Font,
                        SystemBrushes.ControlText,
                        e.RowBounds.Location.X + gridWidth - (this.RowHeadersWidth) + 40,
                        e.RowBounds.Location.Y + ((e.RowBounds.Height - Sz.Height) / 2));
                else
                    e.Graphics.DrawString(
                        RowNumber.ToString(),
                        this.Font,
                        SystemBrushes.ControlText,
                        e.RowBounds.Location.X + 10,
                        e.RowBounds.Location.Y + ((e.RowBounds.Height - Sz.Height) / 2));
            }
            catch
            { }
        }
        /// <summary>
        /// رویداد راست کلیک بر روی هدر ستونها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (!EnableContexMenu)
                    return;
                if (e.Button == MouseButtons.Right)
                    mnuDataGrid.Show(Cursor.Position);
                if (_RightClickedColumn == null)
                    _RightClickedColumn = new DataGridViewColumn();
                _RightClickedColumn = this.Columns[e.ColumnIndex];
                itemFrozen.Checked = _RightClickedColumn.Frozen;
            }
            catch
            {
            }
        }


        /// <summary>
        ///رویداد انتخاب آیتم منو
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDataGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == itemExportToExcel)
            {
                mnuDataGrid.Hide();
                ExportToExcel();
            }
            if (e.ClickedItem == itemDisplayFields)
            {
                DisplayFields();
            }
            if (e.ClickedItem == itemeSaveSetting)
            {
                SaveSettings();
            }
            if (e.ClickedItem == itemFrozen)
            {
                FreezColumn(_RightClickedColumn);
                itemFrozen.Checked = !_RightClickedColumn.Frozen;
            }
            if (e.ClickedItem == itemDefaultSettings)
            {
                LoadDefaultSetting();
            }
        }
        #endregion

        #region Functions
        public void AddAction(JAction pAction)
        {
            //
            //Actions.Add(pAction);
            if (ActionMenu == null)
                ActionMenu = new JPopupMenu();
            ActionMenu.Insert(pAction);
            this.ContextMenuStrip = ActionMenu.GetPopup(JSystem.Nodes);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearActions()
        {
            if (ActionMenu != null)
                ActionMenu.ClearItems();
        }
        /// <summary>
        /// ذخیره تنظیمات
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                if (KeyName == null)
                    return;
                if (KeyName.Trim() == "")
                    return;
                //StringCollection stringCollection = new StringCollection();
                string[] strGridSettigs = new string[this.ColumnCount];
                int i = 0;
                foreach (DataGridViewColumn column in this.Columns)
                {
                    strGridSettigs[i++] = string.Format(
                        "{0}, {1}, {2}, {3}",
                        column.DisplayIndex,
                        column.Width,
                        Convert.ToByte(column.Visible),
                        Convert.ToByte(column.Frozen));
                }
                RegistryKey Key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
                if (Key == null)
                {
                    Key = Registry.CurrentUser.CreateSubKey(RegistryPath);
                }
                Key.SetValue(KeyName, strGridSettigs);
            }
            catch
            {
            }
        }
        /// <summary>
        /// بازیابی تنظیمات پیشفرض
        /// </summary>
        public void LoadDefaultSetting()
        {
            try
            {
                string[] cols = _DefaultSettings;
                for (int i = 0; i < cols.Length; ++i)
                {
                    string[] a = cols[i].Split(',');
                    this.Columns[i].Frozen = Convert.ToBoolean(Int16.Parse(a[3]));
                }
                for (int i = 0; i < cols.Length; ++i)
                {
                    string[] a = cols[i].Split(',');
                    this.Columns[i].DisplayIndex = Int16.Parse(a[0]);
                    this.Columns[i].Width = Int16.Parse(a[1]);
                    this.Columns[i].Visible = Convert.ToBoolean(Int16.Parse(a[2]));
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// بازیابی تنظیمات
        /// </summary>
        public void LoadSettings()
        {

            try
            {
                RegistryKey Key = Registry.CurrentUser.OpenSubKey(RegistryPath);
                if (Key == null)
                {
                    return;
                }
                /// set Default Settings in pivate field
                int i = 0;
                if (_DefaultSettings==null)
                    _DefaultSettings = new string[this.ColumnCount];
                foreach (DataGridViewColumn column in this.Columns)
                {
                    _DefaultSettings[i++] = string.Format(
                        "{0}, {1}, {2}, {3}",
                        column.DisplayIndex,
                        column.Width,
                        Convert.ToByte(column.Visible),
                        Convert.ToByte(column.Frozen));
                }
                string[] cols = (string[])Key.GetValue(KeyName);
                for (i = 0; i < cols.Length; ++i)
                {
                    string[] a = cols[i].Split(',');
                    if (!Columns[i].Frozen)
                        this.Columns[i].DisplayIndex = Int16.Parse(a[0].Trim()) + 1;
                    this.Columns[i].Width = Int16.Parse(a[1].Trim());
                    this.Columns[i].Visible = Convert.ToBoolean(Int16.Parse(a[2].Trim()));
                    this.Columns[i].Frozen = Convert.ToBoolean(Int16.Parse(a[3].Trim()));
                }
            }
            catch (Exception ex)
            {
                string temp = "";
                temp = "";
                string t = temp;
                //MessageBox.Show(ex.Message);
                // This happens when settings values are empty
            }
        }

        private void FreezColumn(DataGridViewColumn pColumn)
        {
            pColumn.Frozen = !pColumn.Frozen;
        }

        public void DisplayFields()
        {
            JDisplayFieldsForm fieldsForm = new JDisplayFieldsForm(this);
            fieldsForm.ShowDialog();
        }
        /// <summary>
        /// ارسال به اکسل
        /// </summary>
        public void ExportToExcel()
        {
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                JExcel.ExportToExcel(this, "", saveFileDialog1.FileName);
            }
        }

        public void bind(JDataBase pDs)
        {
            this.DataSource = pDs.Query_DataTable();
        }

        #endregion

        private void JDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSettings();
        }

        private void JDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //if (e.Button == MouseButtons.Right)
            //    this.CurrentCell = this.Rows[e.RowIndex].Cells[0];//. Selected = true;
        }
    }
}

