using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Documents
{
    public partial class JDocumentForm : JBaseForm
    {
        int _Code;

        public JDocumentForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            LoadData();
        }

        public JDocumentForm()
        {
            InitializeComponent();
            LoadDates();
            LoadData();
        }
       // List<JDocumentDate> Dates = new List<JDocumentDate>();
        private void LoadDates()
        {
            DataTable dates = BusManagment.Reports.JDailyPerformanceRportOnBus.GetDatesToIssueDocument();
            foreach (DataRow row in dates.Rows)
            {
                JAUTDocumentDate date = new JAUTDocumentDate();
                date.Date = Convert.ToDateTime(row["Date"]);
                date.DocumentCode = _Code;
                date.IsIssued = true;
               // Dates.Add(date);
                chListDates.Items.Add(date, true);
            }
        }
        private void LoadData()
        {
            if (_Code == 0)
            {
                txtIssuDate.Date = (new JDataBase()).GetCurrentDateTime();
            }
            else
            {
                DisableAll();
                JAUTDocument document = new JAUTDocument(null, _Code);
                txtDesc.Text = document.Description;
                chAllDates.Checked = document.AllDates;
                txtIssuDate.Date = document.IssueDate;

                DataTable dates = JAUTDocumentDates.GetData(_Code);
                foreach (DataRow row  in dates.Rows)
                {
                    JAUTDocumentDate date = new JAUTDocumentDate(Convert.ToInt32(row["Code"]));
                    chListDates.Items.Add(date);
                }
                DataTable details = JAUTDocumentDetails.GetData(_Code);
                grdReport.DataSource = details;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chAllDates_CheckedChanged(object sender, EventArgs e)
        {
            chListDates.Enabled = !chAllDates.Checked;
        }

        private void chListDates_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime[] dates = new DateTime[0];
            int j = 0;
            for (int i = 0; i < chListDates.Items.Count; i++)
            {
                if ((!chAllDates.Checked && chListDates.GetItemChecked(i)) || chAllDates.Checked)
                {
                    Array.Resize(ref dates, dates.Length + 1);
                    dates[j++] = ((JAUTDocumentDate)chListDates.Items[i]).Date;
                }
            }
            if (dates.Length > 0)
            {
                DataTable report = Reports.JDailyPerformanceRportOnBus.GetDriversReportByDate(dates);
                grdReport.DataSource = report;

                grdReport.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                grdReport.gridEX1.CurrentTable.Columns["OwnerCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["BusCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["BusNumber"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["OwnerName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["SumPrice"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["Count"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
            }
            else
                grdReport.DataSource = null;
          
        }

        private void chListDates_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void chListDates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chListDates.SelectedItem != null)
            {
                ((JAUTDocumentDate)chListDates.SelectedItem).IsIssued = chListDates.GetItemChecked(chListDates.SelectedIndex);
            }
        }

        private void btnExportToBank_Click(object sender, EventArgs e)
        {
            #region Validate

            if (txtDesc.Text.Trim() == "")
            {
                JMessages.Error("لطفا شرح سند را وارد کنید.", "");
                return;
            }
            if (grdReport.DataSource == null
                || grdReport.gridEX1.CurrentTable.Columns["OwnerCode"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["BusCode"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["BusNumber"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["OwnerName"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["SumPrice"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["Count"].EditType != Janus.Windows.GridEX.EditType.NoEdit)
            {
                JMessages.Error("لطفا ابتدا مشاهده خروجی را کلیک کنید.", "");
                return;
            }
            if (grdReport.DataSource.Rows.Count == 0)
            {
                JMessages.Error("هیچ تراکنشی برای این تاریخ ها ثبت نشده است.", "");
                return;
            } 
            #endregion Validate

            if (JMessages.Question("پس از بستن سند، قادر به تغییرات نخواهید بود. آیا میخواهید بستن انجام شود؟", "بستن تراکنشها") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase db = new JDataBase();
                try
                {
                    #region Save Document
                    JAUTDocument document = new JAUTDocument(db, _Code);
                    document.Description = txtDesc.Text;
                    document.IssueDate = txtIssuDate.Date;
                    document.AllDates = chAllDates.Checked;
                    document.Register_Full_Title = JMainFrame.CurrentPostTitle;
                    document.Register_Post_Code = JMainFrame.CurrentPostCode;
                    document.Register_User_Code = JMainFrame.CurrentUserCode;
                    db.beginTransaction("SaveDocument");
                    if (_Code > 0)
                    {
                        if (JAUTDocumentDates.DeleteDates(db, _Code) < 0)
                            throw new Exception();
                        document.Update(db);
                    }
                    else
                    {
                        _Code = document.Insert(db);
                        if (_Code == 0)
                            throw new Exception();
                    }
                    if (_Code > 0)
                    {
                        for (int i = 0; i < chListDates.Items.Count; i++)
                        {
                            JAUTDocumentDate date = (JAUTDocumentDate)chListDates.Items[i];
                            date.DocumentCode = _Code;
                            date.IsIssued = chListDates.GetItemChecked(i);
                            if (date.Insert(db) == 0)
                            {
                                throw new Exception();
                            }
                        }
                    }
                    else
                        throw new Exception();
                    #endregion Save

                    #region Save Details

                    DateTime[] dates = new DateTime[0];
                    int j = 0;
                    for (int i = 0; i < chListDates.Items.Count; i++)
                    {
                        if ((!chAllDates.Checked && chListDates.GetItemChecked(i)) || chAllDates.Checked)
                        {
                            Array.Resize(ref dates, dates.Length + 1);
                            dates[j++] = ((JAUTDocumentDate)chListDates.Items[i]).Date;
                        }
                    }
                    int[] owners = new int[0];
                    DataTable SelectedOwners = grdReport.DataSource;
                    foreach (DataRow row in SelectedOwners.Rows)
                    {
                       // if (Convert.ToBoolean(row["BeClosed"]))
                        {
                            Array.Resize(ref owners, owners.Length + 1);
                            owners[owners.Length - 1] = Convert.ToInt32(row["OwnerCode"]);
                        }
                    }
                    if (Reports.JDailyPerformanceRportOnBus.SetReportDocumentCode(db, dates, owners, _Code) < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        JAUTDocument doc = new JAUTDocument(db, _Code);
                        doc.IsClosed = true;
                        doc.Update(db);
                        #region Insert Details
                        foreach (DataRow row in SelectedOwners.Rows)
                        {
                           // if (Convert.ToBoolean(row["BeClosed"]))
                            {
                                JAUTDocumentDetail detail = new JAUTDocumentDetail();
                                detail.DocumentCode = _Code;
                                detail.CardCount = Convert.ToInt32(row["Count"]);
                                detail.Amount = Convert.ToDecimal(row["SumPrice"]);
                                detail.OwnerPCode = Convert.ToInt32(row["OwnerCode"]);
                                detail.BusCode = Convert.ToInt32(row["BusCode"]);
                              //  detail.SentToBank = Convert.ToBoolean(row["BeClosed"]);
                                if (detail.Insert(db) == 0)
                                    throw new Exception();
                            }
                        }
                        db.Commit();
                        #endregion Insert Details
                        JMessages.Information("بستن تراکنشها با موفقیت انجام شد. از قسمت پرداخت برای ارسال اسناد به بانک اقدام فرمائید.", "");
                        DisableAll();
                    }
                    #endregion Details

                }
                catch (Exception ex)
                {
                    db.Rollback("SaveDocument");
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        private void DisableAll()
        {
            btnReport.Enabled = false;
            btnExportToBank.Enabled = false;
            chAllDates.Enabled = false;
            chListDates.Enabled = false;
            txtDesc.Enabled = false;
            grdReport.Enabled = false;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
