using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.SMS
{
    public partial class SMSGroupForm : ClassLibrary.JBaseForm
    {
        public int _GroupCode;

        public SMSGroupForm()
        {
            InitializeComponent();
        }

        public void _SetGroups()
        {
            cmbGroups.DisplayMember = "Name";
            cmbGroups.ValueMember = "Code";
            cmbGroups.DataSource = JSMSGroupDefines.GetDataTable();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SMSGroupForm_Load(object sender, EventArgs e)
        {
            _SetGroups();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable _DataTable = (DataTable)dgrGroupDetails.DataSource;
                if (_GroupCode == -1)
                {
                    JMessages.Error("گروه را انتخاب کنید", "error");
                    return;
                }
                JFindPersonForm JFPF = new JFindPersonForm();
                JFPF.MultiSelect = true;
                JFPF.ShowDialog();
                if (JFPF.SelectedPersonsCode.Length != 0)
                {
                    for (int i = 0; i < JFPF.SelectedPersonsCode.Length; i++)
                    {
                        if ((((_DataTable.Rows.Count > 0) && (_DataTable.Select("PersonCode=" + JFPF.SelectedPersonsCode[i].ToString()).Length < 1)) || (_DataTable.Rows.Count == 0)))
                        {
                            JAllPerson Person = new JAllPerson(JFPF.SelectedPersonsCode[i]);
                            JPersonAddress jPersonAddress = new JPersonAddress(JFPF.SelectedPersonsCode[i]);
                            DataRow Row = _DataTable.NewRow();
                            Row["PersonCode"] = Person.Code;
                            Row["PersonName"] = Person.Name;
                            Row["Mobile"] = jPersonAddress.Mobile;
                            _DataTable.Rows.Add(Row);
                            dgrGroupDetails.DataSource = _DataTable;
                            dgrGroupDetails.Refresh();
                        }
                        else
                            JMessages.Message("Person is Repeat", "", JMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);

            }

        }

        private void btnAddNonPerson_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jTextInput = new JTextInputDialogForm("شماره همراه", "", false);
            if (jTextInput.ShowDialog() == DialogResult.OK)
            {
                DataTable _DataTable = dgrGroupDetails.DataSource as DataTable;
                DataRow dr = _DataTable.NewRow();
                dr["PersonCode"] = 0;
                dr["PersonName"] = "ناشناس";
                dr["Mobile"] = jTextInput.Text;
                _DataTable.Rows.Add(dr);
                dgrGroupDetails.DataSource = _DataTable;
                dgrGroupDetails.Refresh();
            }
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            btnSave.Enabled = false;
            if (cmbGroups.SelectedIndex >= 0 && cmbGroups.SelectedValue.GetType() != typeof(DataRowView))
            {
                _GroupCode = Convert.ToInt32(cmbGroups.SelectedValue);
                dgrGroupDetails.DataSource = JSMSGroups.GetGroupData(_GroupCode);
                JSMSGroupDefine jSMSGroupDefine = new JSMSGroupDefine(_GroupCode);
                jQueryEditor1.Text = jSMSGroupDefine.SQL;
                if (_GroupCode > 0)
                {
                    panel3.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnRefreshMobile_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("شماره ها طبق آخرین اطلاعات به روز می شود. آیا مطمئن هستید؟", "به روز رسانی شماره ها") != DialogResult.Yes)
                return;
            DataTable DT = dgrGroupDetails.DataSource as DataTable;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToInt32(DT.Rows[i]["PersonCode"]) > 0)
                {
                    JPersonAddress jPersonAddress = new JPersonAddress(Convert.ToInt32(DT.Rows[i]["PersonCode"]));
                    DT.Rows[i]["Mobile"] = jPersonAddress.Mobile;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("SMSGroupUpdate");
                JSMSGroups.DeleteGroupData(_GroupCode, db);
                DataTable DT = dgrGroupDetails.DataSource as DataTable;
                foreach (DataRow item in DT.Rows)
                {
                    JSMSGroup jSMSGroup = new JSMSGroup();
                    jSMSGroup.Mobile = item["Mobile"].ToString();
                    jSMSGroup.GroupCode = _GroupCode;
                    jSMSGroup.PersonCode = Convert.ToInt32(item["PersonCode"]);
                    if (jSMSGroup.Insert(db) == false)
                    {
                        db.Rollback("SMSGroupUpdate");
                        JMessages.Error("ثبت اطلاعات با خطا مواجه شد. مجددا سعی نمایید.", "مشکل در ثبت");
                        return;
                    }
                }
                // Update SQL Query
                JSMSGroupDefine jSMSGroupDefine = new JSMSGroupDefine(_GroupCode);
                jSMSGroupDefine.SQL = jQueryEditor1.Text;
                if (jSMSGroupDefine.Update(db) == false)
                    db.Rollback("SMSGroupUpdate");
                else
                    db.Commit();
                JMessages.Information("ثبت با موفقیت ذخیره شد.", "ثبت");
            }
            catch
            {
                db.Rollback("SMSGroupUpdate");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void btnDeleteFromGroup_Click(object sender, EventArgs e)
        {
            if (dgrGroupDetails.SelectedRows.Count <= 0) return;
            if (JMessages.Question("آیا از حذف این شماره از این گروه مطمئن هستید؟", "حذف") != DialogResult.Yes) return;
            DataTable DT = dgrGroupDetails.DataSource as DataTable;
            DT.Rows.RemoveAt(dgrGroupDetails.SelectedRows[0].Index);
            dgrGroupDetails.DataSource = DT;
            dgrGroupDetails.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jTextInput = new JTextInputDialogForm("نام گروه", "", false);
            if (jTextInput.ShowDialog() == DialogResult.OK)
            {
                JSMSGroupDefine jSMSGroupDefine = new JSMSGroupDefine();
                jSMSGroupDefine.Name = jTextInput.Text;
                jSMSGroupDefine.SQL = "";
                jSMSGroupDefine.UserCode = JMainFrame.CurrentUserCode;
                jSMSGroupDefine.Insert();
                _SetGroups();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jTextInput = new JTextInputDialogForm("نام گروه", cmbGroups.Text, false);
            if (jTextInput.ShowDialog() == DialogResult.OK)
            {
                int index = cmbGroups.SelectedIndex;
                JSMSGroupDefine jSMSGroupDefine = new JSMSGroupDefine(_GroupCode);
                jSMSGroupDefine.Name = jTextInput.Text;
                jSMSGroupDefine.Update(null);
                _SetGroups();
                cmbGroups.SelectedIndex = index;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("از حذف گروه مطمئن هستید؟", "حذف گروه") == DialogResult.Yes)
            {
                JSMSGroupDefine jSMSGroupDefine = new JSMSGroupDefine();
                jSMSGroupDefine.Code = _GroupCode;
                jSMSGroupDefine.Delete();
                _SetGroups();
            }
        }
    }
}
