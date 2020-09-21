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
    public partial class JPaymentForm : JBaseForm
    {
        int _Code = 0;
        public JPaymentForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            LoadData();
        }
        public JPaymentForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            if (_Code == 0)
            {
                txtIssuDate.Date = (new JDataBase()).GetCurrentDateTime();
                grdReport.DataSource = JAUTDocumentDetails.GetBusCredit();

                grdReport.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                grdReport.gridEX1.CurrentTable.Columns["AccountNo"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["OwnerPCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["BusCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["BusNumber"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["OwnerName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdReport.gridEX1.CurrentTable.Columns["TotalPrice"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
            }
            else
            {
                JAUTPayment payment = new JAUTPayment(null,_Code);
                txtDesc.Text = payment.Description;
                txtIssuDate.Date = payment.PaymentDate;
                grdReport.DataSource = JAUTPaymentDetails.GetData(_Code);
                grdReport.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                DisableAll();
            }
            CalcSum();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            #region Validate

            if (txtDesc.Text.Trim() == "")
            {
                JMessages.Error("لطفا شرح پرداخت را وارد کنید.", "");
                return;
            }
            if (grdReport.DataSource == null
                || grdReport.gridEX1.CurrentTable.Columns["OwnerPCode"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["AccountNo"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["BusCode"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["BusNumber"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["OwnerName"].EditType != Janus.Windows.GridEX.EditType.NoEdit
                || grdReport.gridEX1.CurrentTable.Columns["TotalPrice"].EditType != Janus.Windows.GridEX.EditType.NoEdit)
            {
                JMessages.Error("ثبت قابل انجام نمیباشد.", "");
                return;
            }
            if (grdReport.DataSource.Rows.Count == 0)
            {
                JMessages.Error("هیچ تراکنشی برای پرداخت ثبت نشده است.", "");
                return;
            }
            #endregion Validate

            if (JMessages.Question("آیا میخواهید پرداخت انجام شود؟", "پرداخت") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase db = new JDataBase();
                try
                {
                    #region Save Payment
                    JAUTPayment payment = new JAUTPayment(db, _Code);
                    payment.Description = txtDesc.Text;
                    payment.PaymentDate = txtIssuDate.Date;
                    payment.Register_Full_Title = JMainFrame.CurrentPostTitle;
                    payment.Register_Post_Code = JMainFrame.CurrentPostCode;
                    payment.Register_User_Code = JMainFrame.CurrentUserCode;
                    db.beginTransaction("SavePayment");
                    if (_Code > 0)
                    {
                        payment.Update(db);
                    }
                    else
                    {
                        _Code = payment.Insert(db, false);
                        if (_Code == 0)
                            throw new Exception();
                    }

                    #endregion Save

                    #region Save Details

                    DataTable SelectedOwners = grdReport.DataSource;
                    foreach (DataRow row in SelectedOwners.Rows)
                    {
                        JAUTPaymentDetail detail = new JAUTPaymentDetail();
                        detail.PaymentCode = _Code;
                        detail.BusCode = Convert.ToInt32(row["BusCode"]);
                        detail.OwnerPCode = Convert.ToInt32(row["OwnerPCode"]);
                        detail.PaymentPrice = Convert.ToDecimal(row["PaymentPrice"]);
                        detail.TotalPrice = Convert.ToDecimal(row["TotalPrice"]);
                        if (detail.Insert(db) == 0)
                            throw new Exception();
                    }
                    db.Commit();
                    if (JMessages.Question("پرداخت با موفقیت انجام شد. آیا میخواهید فایل خروجی را دریافت کنید؟", "") == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnGetFile.PerformClick();
                    }
                    DisableAll();
                    #endregion Details

                }
                catch (Exception ex)
                {
                    db.Rollback("SavePayment");
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
            txtDesc.Enabled = false;
            grdReport.Edited = false;
            btnPayment.Enabled = false;
            btnDelete.Enabled = false;
            btnGetFile.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdReport.Selected != null)
            {
                int selectedCount = grdReport.gridEX1.SelectedItems.Count;
                int currentPosition = grdReport.gridEX1.SelectedItems[0].Position;
                for (int i = currentPosition; i <currentPosition + selectedCount; i++)
                {
                    grdReport.DataSource.Rows[i].Delete();
                }
                grdReport.DataSource.AcceptChanges();
                CalcSum();
                //grdReport.gridEX1.SelectedItems.Clear();
            }
        }
        private void CalcSum()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable table = grdReport.DataSource;
                Int64 sumPrice = 0;
                foreach (DataRow row in table.Rows)
                {
                    sumPrice += Convert.ToInt32(row["PaymentPrice"]);
                }
                lbSum.Text = ClassLibrary.JMoney.StringToMoney(sumPrice.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void grdReport_Leave(object sender, EventArgs e)
        {
            grdReport.DataSource.AcceptChanges();
            CalcSum();
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".txt";
            var sb = new StringBuilder();
            string line = "1   1   " + JMoney.RemoveMoney(lbSum.Text);
            sb.AppendLine(line);
            line = txtAccountNo.Text + " " + JMoney.RemoveMoney(lbSum.Text) + " D";
            sb.AppendLine(line);

            //file.WriteLine(firstLine);
            DataTable table = grdReport.DataSource;
            foreach (DataRow row in table.Rows)
            {
                sb.AppendLine(row["AccountNo"].ToString() + " " + row["PaymentPrice"].ToString() + " C");
            }

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, sb.ToString());
            }
        }
    }
}
