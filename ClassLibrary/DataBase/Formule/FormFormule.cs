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
    public partial class FormFormule : Form
    {
        private JFormuleManagers FormulesManagers;
        private JFormuleManager CurrentFM;
        private List<String> words = new List<String>();
        private List<String> syntax = new List<String>();
        private DataTable DataTb;

        public FormFormule(DataTable pDataTable, string pClassName)
        {
            InitializeComponent();
            FormulesManagers = new JFormuleManagers(pClassName);
            DataTb = pDataTable;
            if (DataTb == null)
            {
                this.Close();
                return;
            }
            SetFieldList();
            SetFormuleList();
        }

        private void SetFormuleList()
        {
            LBFormuleList.Items.Clear();
            LBFormuleList.Items.AddRange(FormulesManagers.GetFormules());
        }


        public void SetFieldList()
        {
            string[] Fields = new string[DataTb.Columns.Count + 2];
			Fields[0] = "'{تاریخ روز}'";
			Fields[1] = "'{اسکیول}'";
			int count = 2;
            foreach (DataColumn DC in DataTb.Columns)
            {
                Fields[count++] = DC.ColumnName;
            }
            if (DataTb != null)
                LBFields.Items.AddRange(Fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentFM = null;
            TxtFormule.Clear();
            TxtBoxFName.Clear();
        }

        private void LBFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectionIndex = TxtFormule.SelectionStart;
            TxtFormule.Text = TxtFormule.Text.Insert(selectionIndex, LBFields.SelectedItem.ToString());
            TxtFormule.SelectionStart = selectionIndex + LBFields.SelectedItem.ToString().Length;
        }

        private void BTNInsert_Click(object sender, EventArgs e)
        {
            bool _StatieInsert = false;
            if (TxtBoxFName.Text.Length > 0)
            {
                if (CurrentFM == null)
                {
                    CurrentFM = new JFormuleManager();
                    _StatieInsert = true;
                }
                if (!cbxAllUsers.Checked) CurrentFM.user_code = JMainFrame.CurrentUserCode;
                else CurrentFM.user_code = 0;
                CurrentFM.ClassName = FormulesManagers.ClassName;
                CurrentFM.Formule = TxtFormule.Text;
                CurrentFM.Name = TxtBoxFName.Text;
                CurrentFM.Numeric = chNumeric.Checked;
                if (_StatieInsert)
                    if (CurrentFM.Insert() > 0)
                    {
                        JMessages.Information("با موفقیت درج شد.", "درج");
                        SetFormuleList();
                    }
                    else
                        JMessages.Error("درج با خطا مواجه شد.", "درج");
                else
                    if (CurrentFM.Update())
                    {
                        JMessages.Information("با موفقیت به روزرسانی شد.", "به روزرسانی");
                        SetFormuleList();
                    }
                    else
                        JMessages.Error("به روز رسانی با خطا مواجه شد.", "به روز رسانی");

            }
        }

        private void LBFormuleList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LBFormuleList.SelectedItem != null)
            {
                CurrentFM = (LBFormuleList.SelectedItem as JFormuleManager);
                if (CurrentFM.user_code > 0)
                    cbxAllUsers.Checked = false;
                else
                    cbxAllUsers.Checked = true;
                TxtFormule.Text = CurrentFM.Formule;
                TxtBoxFName.Text = CurrentFM.Name;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LBFormuleList.SelectedItem != null)
            {
                if ((LBFormuleList.SelectedItem as JFormuleManager).Delete())
                {
                    JMessages.Information("فرمول حذف شد.", "حذف");
                    SetFormuleList();
                }
                else
                    JMessages.Error("حذف با خطا مواجه شد.", "حذف");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFormule_Load(object sender, EventArgs e)
        {
            ShowToAllUsers();
            for (int i = 0; i < LBFields.Items.Count; i++)
            {
                words.Add(LBFields.Items[i].ToString());
            }

            syntax.Add("COUNT");
            syntax.Add("MAX");
            syntax.Add("MIN");
            syntax.Add("IN");
            syntax.Add("LIKE");
            syntax.Add("SUM");
            syntax.Add("AVG");
            syntax.Add("STDEV");
            syntax.Add("VAR");
            syntax.Add("CONVERT");
            syntax.Add("LEN");
            syntax.Add("ISNULL");
            syntax.Add("IIF");
            syntax.Add("TRIM");
            syntax.Add("SUBSTRING");
        }

        public void ShowToAllUsers()
        {
            if (JPermission.CheckPermission("ClassLibrary.FormFormule.ShowToAllUsers", false))
                cbxAllUsers.Enabled = true;
            else
                cbxAllUsers.Enabled = false;
        }

        private void TxtFormule_TextChanged(object sender, EventArgs e)
        {
            int startIndex = TxtFormule.SelectionStart;
            TxtFormule.SelectAll();
            TxtFormule.SelectionColor = Color.Black;
            TxtFormule.SelectionStart = startIndex;
            TxtFormule.SelectionLength = 0;
            HighlightText(TxtFormule, syntax, Color.Blue);
            HighlightText(TxtFormule, words, Color.DarkGreen);
            HighlightQuote(TxtFormule, Color.DarkRed);
        }

        private void HighlightText(RichTextBox rtb, List<String> list, Color color)
        {
            int startIndex = rtb.SelectionStart;
            foreach (string word in list)
            {
                int i = 0;
                i = rtb.Find(word, i, rtb.Text.Length, RichTextBoxFinds.None);

                while (i != -1)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = word.Length;
                    rtb.SelectionColor = color;
                    i = rtb.Find(word, i + 1, rtb.Text.Length, RichTextBoxFinds.None);
                }
            }
            rtb.SelectionStart = startIndex;
            rtb.SelectionLength = 0;
        }
        private void HighlightQuote(RichTextBox rtb, Color color)
        {
            int startIndex = rtb.SelectionStart;
            int start = -1;
            bool isFind = false;
            while (rtb.Find("'", start + 1, rtb.Text.Length, RichTextBoxFinds.None) >= 0)
            {
                int i = rtb.Find("'", start + 1, rtb.Text.Length, RichTextBoxFinds.None);
                if (i == start || i < start) break;
                if (i >= 0)
                    if (isFind)
                    {
                        rtb.SelectionStart = start;
                        rtb.SelectionLength = i - start + 1;
                        rtb.SelectionColor = color;
                        start = i;
                        isFind = false;
                    }
                    else
                    {
                        start = i;
                        isFind = true;
                    }
            }
            if (isFind)
            {
                rtb.SelectionStart = start;
                rtb.SelectionLength = rtb.Text.Length - start + 1;
                rtb.SelectionColor = color;
                isFind = false;
            }

            rtb.SelectionStart = startIndex;
            rtb.SelectionLength = 0;
        }
    }
}
