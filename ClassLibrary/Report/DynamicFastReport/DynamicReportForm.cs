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
    public partial class JDynamicReportForm : JBaseForm
    {

        private Int64 _ReportCode;
        private JDynamicReport _DRC;
        private JDynamicReport[] DynamicReport;
        public System.Data.DataTable[] DataTables;


        //public JDynamicReportForm(int pRepCode, JDynamicReport[] pDynamicReport)
        //{
            //_ReportCode = pRepCode;
            //SubReports = pSubReports;

            //DRC = new JDynamicReport(_ReportCode);
            //DRC.AddRange(SubReports);

            //DynamicReport = pDynamicReport;
            //InitializeComponent();
        //}
        public JDynamicReportForm(int pNewRepCode)
            : this(0, pNewRepCode)
        {
            if (JMainFrame.IsAdmin)
                buttonAllReport.Visible = true;
        }

        public JDynamicReportForm(int pOldRepCode, Int64 pNewRepCode)
        {
            InitializeComponent();
            _ReportCode = pNewRepCode;
            JDynamicReport.UpdateOldCodetoNewCode(pOldRepCode, pNewRepCode);
            if (JMainFrame.IsAdmin)
                buttonAllReport.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            tBReportCaption.Clear();
            rBFastReport.Checked = true;
            if (_DRC != null)
            {
                _DRC.Dispose();
            }
            _DRC = new JDynamicReport(_ReportCode, _ReportCode);
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (tBReportCaption.Text.Length < 1)
                return;
            if (rBFastReport.Checked)
                _DRC.ReportType = JReportType.FastReport;
            else
                if (rBWord.Checked)
                    _DRC.ReportType = JReportType.WordRepor;
            _DRC.Caption = tBReportCaption.Text;
            
            if (DataTables != null)
                _DRC.AddRange(DataTables);
            
            if (_DRC.CreateNew() > 0)
            {
                groupBox1.Enabled = false;
                listBoxReports.Items.Add(_DRC);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _DRC.Label = txtLable.Text;
                bool _Insert = _DRC.Code == 0;
                if (_DRC.Save())
                {
                    groupBox1.Enabled = false;
                    if (_Insert)
                        listBoxReports.Items.Add(_DRC);
                }
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void listBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem != null)
            {
                _DRC = (JDynamicReport)listBoxReports.SelectedItem;
                tBReportCaption.Text = _DRC.Caption;
                txtLable.Text = _DRC.Label;
                if (_DRC.ReportType == JReportType.WordRepor)
                    rBFastReport.Checked = true;
                else
                    rBWord.Checked = true;
            }
        }

        private void getList()
        {
            JDynamicReports DRs = new JDynamicReports(_ReportCode, _ReportCode);
            DRs.GetDatas();
            listBoxReports.Items.AddRange(DRs.Items);
        }

        private void JDynamicReportForm_Load(object sender, EventArgs e)
        {
            getList();
        }

        private void btnPrview_Click(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem == null) return;
            ((JDynamicReport)listBoxReports.SelectedItem).Clear();
            if (DataTables != null)
                ((JDynamicReport)listBoxReports.SelectedItem).AddRange(DataTables);
            ((JDynamicReport)listBoxReports.SelectedItem).Prview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem == null) return;
            ((JDynamicReport)listBoxReports.SelectedItem).Clear();
            if (DataTables != null)
                ((JDynamicReport)listBoxReports.SelectedItem).AddRange(DataTables);
            ((JDynamicReport)listBoxReports.SelectedItem).Print();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem == null)
            {
                JMessages.Error("لطفا یکی از گزارشات را انتخاب کنید.", "Error");
                return;
            }
            ((JDynamicReport)listBoxReports.SelectedItem).Clear();
            if (((JDynamicReport)listBoxReports.SelectedItem).Delete())
                listBoxReports.Items.Remove(listBoxReports.SelectedItem);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem == null)
            {
                JMessages.Error("لطفا یکی از گزارشات را انتخاب کنید.", "Error");
                return;
            }
            ((JDynamicReport)listBoxReports.SelectedItem).Clear();
            if (DataTables != null)
                ((JDynamicReport)listBoxReports.SelectedItem).AddRange(DataTables);
            if (((JDynamicReport)listBoxReports.SelectedItem).CreateUpdate())
                listBoxReports.Refresh();

        }

        private void rBWord_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tBReportCaption_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLable_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnSave.Enabled = true;
        }

        int _DefaultIndex = -1;
        private void listBoxReports_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxReports.SelectedItem != null)
            {
                JDynamicReport _DRC;
                if (_DefaultIndex >= 0)
                {
                    _DRC = ((JDynamicReport)listBoxReports.Items[_DefaultIndex]);
                    _DRC.DefaultPrint = false;
                }
                _DRC = ((JDynamicReport)listBoxReports.SelectedItem);
                _DRC.ResetDefalt();
                _DRC.DefaultPrint = !_DRC.DefaultPrint;
                _DRC.Update();
                listBoxReports.Refresh();
            }
        }

        private void listBoxReports_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Font _Font;
                if (((JDynamicReport)listBoxReports.Items[e.Index]).DefaultPrint)
                {
                    _Font = new Font("Tahoma", 10, FontStyle.Bold);
                    _DefaultIndex = e.Index;
                }
                else
                {
                    _Font = listBoxReports.Font;
                }
                e.DrawBackground();
                e.Graphics.DrawString(listBoxReports.Items[e.Index].ToString(), _Font, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void rBFastReport_CheckedChanged(object sender, EventArgs e)
        {

        }
    
        public void Add(System.Data.DataTable pDataTable)
        {
            if (DataTables == null)
                DataTables = new DataTable[0];
            Array.Resize(ref DataTables, DataTables.Length + 1);
            DataTables[DataTables.Length - 1] = pDataTable;
        }

        public void AddRange(System.Data.DataTable[] pDataTables)
        {
            if (DataTables == null)
                DataTables = new DataTable[0];
            int Len = DataTables.Length;
            Array.Resize(ref DataTables, DataTables.Length + pDataTables.Length);
            int count = 0;
            foreach (System.Data.DataTable DataTable in pDataTables)
            {
                DataTables[Len + count] = DataTable;
                count++;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAllReport_Click(object sender, EventArgs e)
        {
            listBoxReports.Items.Clear();

            JDynamicReports DRs = new JDynamicReports(0, 0);
            DRs.GetData();
            listBoxReports.Items.AddRange(DRs.Items);
        }

    }
}
