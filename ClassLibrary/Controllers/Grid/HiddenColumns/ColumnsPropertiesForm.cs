using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class ColumnsPropertiesForm : JBaseForm
    {
        private DataTable _DataTable;
        private string _ClassName;

        public ColumnsPropertiesForm(DataTable pDataTable, string className)
        {
            InitializeComponent();
            _DataTable = pDataTable;
            _ClassName = className;
            SetFieldList();
        }

        public void SetFieldList()
        {
            if (_DataTable == null)
            {
                this.Close();
                return;
            }
            if (_DataTable != null)
            {
                JKeyValue[] Fields = JDataBase.DataTableColumnToKeyValueArray(_DataTable);
                checkedListBox1.Items.AddRange(Fields);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    (checkedListBox1.Items[i] as JKeyValue).Value = -1;
                }

                JHiddenColumns jHiddenColumns = new JHiddenColumns();
                string[] columns = jHiddenColumns.GetColumns(JMainFrame.CurrentUserCode, _ClassName);
                if (columns != null)
                    foreach (string item_data in columns)
                    {
                        try
                        {
                            string[] D = item_data.Split(new string[] { ":" }, StringSplitOptions.None);

                            string item = D.Length >= 1 ? D[0] : "";
                            bool hidden = D.Length >= 2 ? D[1] == "hidden" : false;

                            int size = D.Length >= 3 && int.TryParse(D[2], out size) ? int.Parse(D[2]) : -1;
                            int ordered = D.Length >= 4 ? int.Parse(D[3]) : -1;

                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                try
                                {
                                    string str = (checkedListBox1.Items[i] as JKeyValue).Key;
                                    (checkedListBox1.Items[i] as JKeyValue).Value = size;
                                    if (item == str)
                                    {
                                        if (hidden)
                                            checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                                        if (ordered != -1)
                                        {
                                            Object V = checkedListBox1.Items[i];
                                            checkedListBox1.Items.Remove(V);
                                            checkedListBox1.Items.Insert(ordered, V);
                                            checkedListBox1.SetItemChecked(ordered, !hidden);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                        catch(Exception ex)
                        {

                        }
                    }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (JMainFrame.IsAdmin)
            {
                ClassLibrary.Report.DynamicFastReport.jDynamicReprotManagers DRM = new ClassLibrary.Report.DynamicFastReport.jDynamicReprotManagers(_DataTable);
                DRM.ShowDialog();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string columns = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                    columns += "," + (checkedListBox1.Items[i] as JKeyValue).Key + ":hidden:" + (checkedListBox1.Items[i] as JKeyValue).Value.ToString() + ":" + i.ToString();
                else
                    columns += "," + (checkedListBox1.Items[i] as JKeyValue).Key + ":unhidden:" + (checkedListBox1.Items[i] as JKeyValue).Value.ToString() + ":" + i.ToString();
            }

            if (columns.Length >= 1) columns = columns.Substring(1);
            JHiddenColumns jHiddenColumns = new JHiddenColumns();
            jHiddenColumns.DeleteByUserCodeClassName(JMainFrame.CurrentUserCode, _ClassName);
            jHiddenColumns = new JHiddenColumns();
            jHiddenColumns.Columns = columns;
            jHiddenColumns.ClassName = _ClassName;
            jHiddenColumns.user_code = JMainFrame.CurrentUserCode;
            if (columns == "" || jHiddenColumns.Insert() > 0)
            {
                JMessages.Information("تنظیمات ستون ها با موفقیت ثبت شد.", "تنظیمات ستون ها");
                this.Close();
            }
            else
                JMessages.Error("در ثبت تنظیمات ستون ها خطا رخ داده است.", "تنظیمات ستون ها");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int D;
            if (int.TryParse(textBox1.Text , out D))
            {
                (checkedListBox1.SelectedItem as JKeyValue).Value = D;
            }
        }



        public void MoveUp()
        {
            MoveItem(-1);
        }

        public void MoveDown()
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (checkedListBox1.SelectedItem == null || checkedListBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = checkedListBox1.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= checkedListBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = checkedListBox1.SelectedItem;
            bool c = checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Checked;
            // Removing removable element
            checkedListBox1.Items.Remove(selected);
            // Insert it in new position
            checkedListBox1.Items.Insert(newIndex, selected);
            // Restore selection
            checkedListBox1.SetSelected(newIndex, true);

            checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
                textBox1.Text = (checkedListBox1.SelectedItem as JKeyValue).Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassLibrary.JHiddenColumns HC = new JHiddenColumns();
            HC.DeleteByUserCodeClassName(JMainFrame.CurrentUserCode, _ClassName);
        }
    }
}
