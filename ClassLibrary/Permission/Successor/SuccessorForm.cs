using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace ClassLibrary
{
    public partial class JSuccessorForm : JBaseForm
    {

        int _UserPostCode;

        public JSuccessorForm()
        {
            InitializeComponent();
        }

        private void Set_Data()
        {
            DataTable dt = JSuccessor.GetDataTableSuccessor();// JSuccessor.GetDataTable(JMainFrame.CurrentPostCode);
            jdgvSuccessor.DataSource = dt;
            //jdgvSuccessor.bind(dt, "JanusSuccessor", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
        }

        private void FillPermission()
        {
            PermissionUserlistBox.Items.Clear();
            _UserPostCode = 0;
            JPermissionsUser PerUser = new JPermissionsUser(JMainFrame.CurrentPostCode);//
            PerUser.GetData();
            PermissionUserlistBox.Items.AddRange(PerUser.Items);

        }

        private void JSuccessorForm_Load(object sender, EventArgs e)
        {
            //-------------- ارجاعات داخل سازمانی ----------
            cdbReferInternal.DisplayMember = "Full_title";
            cdbReferInternal.ValueMember = "Code";
            cdbReferInternal.DataSource = Employment.JEOrganizationChart.GetAllData();
            Set_Data();

            jdgvSuccessor.Columns["Code"].Visible = false;
            jdgvSuccessor.Columns["Successer_post_code"].Visible = false;
            jdgvSuccessor.Columns["Person_post_code"].Visible = false;
            jdgvSuccessor.Columns["Active"].Visible = false;

            FillPermission();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region CheckData

            if (cdbReferInternal.SelectedValue == null || Convert.ToInt32(cdbReferInternal.SelectedValue) == -1)
            {
                JMessages.Message("لطفا جانشین را انتخاب کنید", "", JMessageType.Information);
                return;
            }
            if (txtStartDate.Date > txtEndDate.Date)
            {
                JMessages.Message(" تاریخ شروع نمی تواند بزرگتر از تاریخ پایان باشد ", "", JMessageType.Information);
                return;
            }
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Message("لطفا تاریخ شروع را وارد کنید", "", JMessageType.Information);
                return;
            }
            if (txtEndDate.Date == DateTime.MinValue)
            {
                JMessages.Message("لطفا تاریخ پایان را وارد کنید", "", JMessageType.Information);
                return;
            }

            #endregion

            JSuccessor tmpSuccessor = new JSuccessor();
            tmpSuccessor.Successer_post_code = Convert.ToInt32(cdbReferInternal.SelectedValue);
            tmpSuccessor.Person_post_code = JMainFrame.CurrentPostCode;
            tmpSuccessor.Start_date_time = txtStartDate.Date;
            tmpSuccessor.End_date_time = txtEndDate.Date;
            if (chkActive.Checked)
                tmpSuccessor.Active = true;
            else
                tmpSuccessor.Active = false;
            if (State == JFormState.Insert)
            {
                if (tmpSuccessor.Insert() > 0)
                {
                    JMessages.Message("ثبت با موفقیت انجام شد", "", JMessageType.Information);
                    Set_Data();
                }
                else
                    JMessages.Message("ثبت با موفقیت انجام نشد", "", JMessageType.Information);
            }
            else
            {
                tmpSuccessor.Code = Convert.ToInt32(jdgvSuccessor.CurrentRow.Cells["Code"].Value.ToString());
                if (tmpSuccessor.Update())
                {
                    JMessages.Message("ویرایش با موفقیت انجام شد", "", JMessageType.Information);
                    Set_Data();
                }
                else
                    JMessages.Message("ویرایش با موفقیت انجام نشد", "", JMessageType.Information);
                this.State = JFormState.Insert;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jdgvSuccessor.SelectedRows != null)
            {
                JSuccessor tmpSuccessor = new JSuccessor(Convert.ToInt32(jdgvSuccessor.CurrentRow.Cells["Code"].Value.ToString()));
                tmpSuccessor.Delete();
                _UserPostCode = 0;
                Set_Data();
            }
        }

        private void PermissionUserlistBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_UserPostCode == 0)
            {
                JMessages.Message(" ثبت با موفقیت انجام نشد", "", JMessageType.Error);
                return;
            }
            JPermissionSuccessor tmp = new JPermissionSuccessor();
            if (PermissionUserlistBox.SelectedIndex != -1)
            {
                tmp.User_Post_Code = _UserPostCode;
                tmp.Start_Date = txtStartDate.Date;//Convert.ToDateTime(jdgvSuccessor.CurrentRow.Cells[3].Value);
                tmp.End_Date = txtEndDate.Date;//Convert.ToDateTime(jdgvSuccessor.CurrentRow.Cells[4].Value);
                tmp.Creator = JMainFrame.CurrentPostCode;
                tmp.ObjectCode = ((ClassLibrary.JPermissionUser)(((System.Windows.Forms.ListBox)(PermissionUserlistBox)).SelectedItem)).ObjectCode;
                tmp.HasPermission = true;
                tmp.DecisionCode = ((ClassLibrary.JPermissionUser)(((System.Windows.Forms.ListBox)(PermissionUserlistBox)).SelectedItem)).DecisionCode;
                if (!PermissionUserlistBox.GetItemChecked(PermissionUserlistBox.SelectedIndex))
                {
                    if (tmp.Insert() <= 0)
                        JMessages.Message(" ثبت با موفقیت انجام نشد", "", JMessageType.Error);
                }
                else
                {
                    if (!tmp.delete())
                        JMessages.Message("  در عملیات حذف خطا وجود دارد", "", JMessageType.Error);
                }
            }
        }

        private void jdgvSuccessor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            jdgvSuccessor_SelectionChanged(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.State = JFormState.Update;
            btnAdd_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void jdgvSuccessor_SelectionChanged(object sender, EventArgs e)
        {
            if (jdgvSuccessor.SelectedRows != null && jdgvSuccessor.CurrentRow!= null)
            {
                FillPermission();
                _UserPostCode = Convert.ToInt32(jdgvSuccessor.CurrentRow.Cells["Successer_post_code"].Value);
                txtStartDate.Text = jdgvSuccessor.CurrentRow.Cells["Start_date_time"].Value.ToString();
                txtEndDate.Text = jdgvSuccessor.CurrentRow.Cells["End_date_time"].Value.ToString();
                if (jdgvSuccessor.CurrentRow.Cells["Active"].Value.ToString() == "True")
                    chkActive.Checked = true;
                else
                    chkActive.Checked = false;
                JSuccessor tmpSuccessor = new JSuccessor(Convert.ToInt32(jdgvSuccessor.CurrentRow.Cells["Code"].Value));
                JPermissionsSuccessor PerUser = new JPermissionsSuccessor(_UserPostCode);
                DataTable dt = PerUser.GetDataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < PermissionUserlistBox.Items.Count; i++)
                    {
                        DateTime start_dt = Convert.ToDateTime(dr["Start_Date"]);
                        DateTime end_dt = Convert.ToDateTime(dr["End_Date"]);
                        if ((dr["ObjectCode"].ToString() == (((ClassLibrary.JPermissionUser)(((System.Windows.Forms.ListBox)(PermissionUserlistBox)).Items[i])).ObjectCode.ToString()))
                            && (dr["DecisionCode"].ToString() == (((ClassLibrary.JPermissionUser)(((System.Windows.Forms.ListBox)(PermissionUserlistBox)).Items[i])).DecisionCode.ToString()))
                            && start_dt == tmpSuccessor.Start_date_time && end_dt == tmpSuccessor.End_date_time)
                            PermissionUserlistBox.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void jdgvSuccessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
