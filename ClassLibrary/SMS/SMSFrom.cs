using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using AxMmCtlLib;

namespace ClassLibrary
{
    public partial class JSMSFrom : JBaseForm
    {

        private Gsm objGsm;
        private SmsConstants objSmsConstants;

        public JSMSFrom()
        {
            InitializeComponent();
            //objGsm = new GsmClass();
            //objSmsConstants = new SmsConstantsClass();
        }

        //private void btnReceiveOptions_Click(object sender, EventArgs e)
        //{
        //    frmGsmReceiveOptions objFrmGsmReceiveOptions = new frmGsmReceiveOptions();
        //    objFrmGsmReceiveOptions.ShowDialog();
        //}

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (JMessages.Question(" برای انجام عملیات مطمئن هستید ؟ ", "") != System.Windows.Forms.DialogResult.Yes)
                return;
            JSMSSend tmpSMSSend = new JSMSSend();

            JDataBase tempDb = new JDataBase();
            tempDb.beginTransaction("SendSMS");
            if (rbGroupSend.Checked)
            {
                if (dgvEmployee.DataSource != null)
                {
                    foreach (DataRow dr in ((DataTable)(dgvEmployee.DataSource)).Rows)
                    {
                        //if (dr["Confirm"].ToString() == "True")
                        //{
                        tmpSMSSend.Mobile = dr["Mobile"].ToString();
                        tmpSMSSend.Text = txtMessage.Text.Trim();
                        tmpSMSSend.RegDate = JDateTime.Now();
                        tmpSMSSend.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                        tmpSMSSend.Description = "";
                        //tmpSMSSend.Project
                        tmpSMSSend.ClassName = cmbGroup.Text;
                        tmpSMSSend.SendDevice = Convert.ToInt32(cmbSMSDevice.SelectedValue);
                        //tmpSMSSend.ObjectCode
                        //tmpSMSSend.Delivery
                        if (tmpSMSSend.Insert(tempDb) < 1)
                        {
                            tempDb.Rollback("SendSMS");
                            JMessages.Error("", "");
                            return;
                        }
                        //}
                    }
                }
                else
                {
                    JMessages.Error(" لیست اشخاص خالی است  ", "");
                    tempDb.Rollback("SendSMS");
                    return;
                }
            }
            else
            {
                if (txtRecipient.Text == "")
                {
                    tempDb.Rollback("SendSMS");
                    JMessages.Error(" شماره موبایل را وارد کنید ", "");
                    return;
                }
                tmpSMSSend.Mobile = txtRecipient.Text.ToString();
                tmpSMSSend.Text = txtMessage.Text.Trim();
                tmpSMSSend.RegDate = JDateTime.Now();
                if (tmpSMSSend.Insert(tempDb) < 1)
                {
                    tempDb.Rollback("SendSMS");
                    JMessages.Error(" خطا در ثبت اطلاعات ", "");
                    return;
                }
            }
            if (tempDb.Commit())
                JMessages.Information(" Insert Successfuly", "");
            else
                JMessages.Error("Insert Not Successfuly", "");

            //JClsSMS tmpClsSMS = new JClsSMS();
            //tmpClsSMS.Pincode = "";
            //tmpClsSMS.PortName = "COM3";
            //tmpClsSMS.DeviceSpeed = Convert.ToInt32("115200");
            //if (tmpClsSMS.SendSMS(txtRecipient.Text, txtMessage.Text, "Unicode")) //cbxBodyType.Text))
            //    JMessages.Information(" Send Messeage Successfuly", "");
            //else
            //    JMessages.Error(" Send Not Messeage Successfuly", "");
        }

        private void JSMSFrom_Load(object sender, EventArgs e)
        {
            JGroupSMSs JCCs = new JGroupSMSs();
            JCCs.SetComboBox(cmbGroup, -1);

            cmbSMSDevice.DisplayMember = "FarsiName";
            cmbSMSDevice.ValueMember = "value";
            cmbSMSDevice.DataSource = ClassLibrary.Domains.JGlobal.JSMSDeviceType.GetData();
        }

        private void GetPattern()
        {
            if (dgvEmployee.DataSource != null)
            {
                //dgvEmployee.Columns["PersonCode"].Visible = false;
                //dgvEmployee.Columns["PersonName"].ReadOnly = true;
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            JGroupSMSSQL tmpSQL = new JGroupSMSSQL();
            try
            {

                if ((cmbGroup.SelectedValue != null) && (Convert.ToInt32(((System.Data.DataRowView)(cmbGroup.SelectedItem)).Row.ItemArray[0]) != -1))
                {
                    //dgvEmployee.DataSource = JGroupSMSEmployees.ViewPersonByGroup(Convert.ToInt32(cmbGroup.SelectedValue));
                    dgvEmployee.DataSource = tmpSQL.ViewPersonByGroup(Convert.ToInt32(cmbGroup.SelectedValue));
                    DataTable dt = tmpSQL.ViewPersonByGroup(Convert.ToInt32(cmbGroup.SelectedValue));
                    //dt.Columns.Add("Tik",  typeof(Boolean));
                    dgvEmployee.DataSource = dt;
                }
                GetPattern();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                tmpSQL.Dispose();
            }
        }

        private void rbGroupSend_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGroupSend.Checked)
            {
                txtRecipient.Enabled = false;
                //groupBox3.Enabled = true;
                cmbGroup.Enabled = true;
            }
        }

        private void rbSendPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSendPerson.Checked)
            {
                txtRecipient.Enabled = true;
                //groupBox3.Enabled = false;
                cmbGroup.Enabled = false;
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            lblLenCh.Text = txtMessage.Text.Length.ToString();
            lblCountSMS.Text = ((Convert.ToInt32(txtMessage.Text.Length.ToString()) / 70) + 1 ).ToString() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JClsSMS tmpClsSMS = new JClsSMS();
            //tmpClsSMS.Pincode = "";
            //tmpClsSMS.PortName = "COM5";
            //tmpClsSMS.DeviceSpeed = Convert.ToInt32("115200");
            //tmpClsSMS.ReceiveSMS();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.SelectedRow != null)
                    dgvEmployee.SelectedRow.Delete();
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

    }
}
