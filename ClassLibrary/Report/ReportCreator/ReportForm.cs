using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;


namespace ClassLibrary
{
    public partial class JReportForm : ClassLibrary.JBaseForm
    {
        int ReportCode = 1;
        public TabPage CustomPage;
        public JJanusGrid CustomGrid;
        public CheckedListBox CustomListBox;

        public JReportForm(int pReportCode)
        {
            ReportCode = pReportCode;
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            JReportManagement tmp = new JReportManagement();
            tmp.GetData(ReportCode);
            this.Text = tmp.Title;
            jReport1.ShowTabs(tmp.Tabs);

            JSubReports Reps = new JSubReports(ReportCode);
            foreach (JSubReport sudreport in Reps.Items)
            {
                TabPage Tp = new TabPage(sudreport.TabTitle);
                tabControlShow.TabPages.Add(Tp);

                JJanusGrid dg = new JJanusGrid();
                dg.Parent = Tp;
                Tp.Controls.Add(dg);
                dg.Dock = DockStyle.Fill;
                dg.DataSource = sudreport.DataTable;
                //dg.ColumnAdded +=
                //    new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
                //this.RefreshDataGridColumns(dg);

                jReport1.AddToSubReport(sudreport);

                Panel P = new Panel();
                P.Parent = Tp;
                Tp.Controls.Add(P);
                P.Dock = DockStyle.Top;
                P.Height = 30;

                Button B = new Button();
                B.Parent = P;
                P.Controls.Add(B);
                B.Text = "Edit";
                B.Click += B_Click;
                B.Tag = sudreport;
                B.Dock = DockStyle.Left;
            }
            {
                CustomPage = new TabPage("Custom Create");
                tabControlShow.TabPages.Add(CustomPage);

                CustomGrid = new JJanusGrid();
                CustomGrid.Parent = CustomPage;
                CustomPage.Controls.Add(CustomGrid);
                CustomGrid.Dock = DockStyle.Fill;
                //CustomGrid.ColumnAdded +=
                //    new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
                //this.RefreshDataGridColumns(CustomGrid);

                CustomListBox = new CheckedListBox();
                CustomListBox.Parent = CustomPage;
                CustomListBox.Dock = DockStyle.Right;
                CustomListBox.Width = 200;

            }
            foreach (JSubReport sudreport in Reps.Items)
            {
                CustomListBox.Items.Add(sudreport);
            }
        }

        void B_Click(object sender, EventArgs e)
        {
            if (JMainFrame.CurrentUserCode == 1)
            {
                JSubReport SR = ((sender as Button).Tag as JSubReport);
                ClassLibrary.Report.ReportCreator.ReportFormEditor RF = new ClassLibrary.Report.ReportCreator.ReportFormEditor(SR);
                RF.ShowDialog(); 
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            jReport1.Run();

            if (CustomListBox.CheckedItems.Count > 0)
            {
                if (CustomGrid.DataSource != null && CustomGrid.DataSource is DataTable)
                {
                    ((DataTable)CustomGrid.DataSource).Clear();
                    ((DataTable)CustomGrid.DataSource).Dispose();
                }

                JSubReport[] TempSubReport = new JSubReport[CustomListBox.CheckedItems.Count];

                int count = 0;
                foreach (object S in CustomListBox.CheckedItems)
                {
                    TempSubReport[count++] = (JSubReport)S;
                }

                CustomGrid.DataSource = jReport1.RunMultiTab(TempSubReport);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            jReport1.Run();
            JDynamicReportForm DRF = new JDynamicReportForm(ReportCode, ReportCode);
            int i = 0;
            foreach (JSubReport sudreport in jReport1.SubReports)
            {
                sudreport.DataTable.TableName = jReport1.SubReports[i++].TabTitle;
                DRF.Add(sudreport.DataTable);
                //R.RegisterData(sudreport.DataTable, sudreport.TabTitle);
            } 
            DRF.ShowDialog();

            //FastReport.Report R = new Report();
            //foreach (JSubReport sudreport in jReport1.SubReports)
            //{
            //    R.RegisterData(sudreport.DataTable, sudreport.TabTitle);
            //}
            //R.Design();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            jReport1.ClearControl(false);
        }

        private void btnCLearAll_Click(object sender, EventArgs e)
        {
            jReport1.ClearControl(true);
        }
    }
}
