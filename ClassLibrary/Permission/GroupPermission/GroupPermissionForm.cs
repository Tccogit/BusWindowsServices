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
    public partial class JGroupPermissionForm : JBaseForm
    {
        int _permissionDesicion;
        int _permissionDefine;
        public JGroupPermissionForm(int permissionDefine, int permissionDesicion, string pFormTitle)
        {
            InitializeComponent();
            _permissionDefine = permissionDefine;
            _permissionDesicion = permissionDesicion;
            SetForm();
            grdUsers.Text = "لیست کاربران";
            grdObjects.Text = "لیست داده ها";

            grdPermissions.gridEX1.SelectedInactiveFormatStyle.BackColor = Color.Blue;
            grdUsers.gridEX1.SelectedInactiveFormatStyle.BackColor = Color.Blue;
            this.Text = pFormTitle;
        }
        public void ShowForm()
        {
            this.ShowDialog();
        }
        public void SetForm()
        {
            grdUsers.DataSource = Employment.JEOrganizationChart.GetAllData();
        }
        public void SetPermissions(Nullable<int> UserCode)
        {
            if (UserCode == null) return;
            grdPermissions.DataSource = JPermissionsUser.GetUsers(_permissionDesicion, defineQuery, Convert.ToInt32(UserCode));
        }

        string defineQuery = "";
        private void SetObjectList(Nullable<int> UserCode)
        {
            if (UserCode == null) return;

            DataTable define = ClassLibrary.JPermissionsDefineClass.GetData(_permissionDefine);
            if (define.Rows.Count > 0)
            {
                defineQuery = define.Rows[0]["SQL"].ToString();
                if (defineQuery != "")
                {
                    defineQuery += " Where Code Not IN(select ObjectCode from PermissionUser where DecisionCode = " + _permissionDesicion + " AND User_Post_Code = " + UserCode.ToString() + ")";
                    JDataBase db = new JDataBase();
                    try
                    {
                        db.setQuery(defineQuery);
                        grdObjects.DataSource = db.Query_DataTable();
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                        db.Dispose();
                    }
                }
                else
                    grdObjects.DataSource = null;
            }
        }

        private void checkBoxNone_CheckedChanged(object sender, EventArgs e)
        {
            grdObjects.Enabled = !checkBoxNone.Checked;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (grdUsers.SelectedRow == null)
                return;
            Nullable<int> UserCode = (Nullable<int>)(grdUsers.SelectedRow[0]);

            int chartCode = (int)grdUsers.SelectedRow["Code"];
            int objectCode = 0;
            if (checkBoxNone.Checked || grdObjects.DataSource == null)
            {
                JPermissionUser pUser = new JPermissionUser();
                pUser.DecisionCode = _permissionDesicion;
                pUser.ObjectCode = 0;
                pUser.HasPermission = true;
                pUser.User_Post_Code = chartCode;
                pUser.Insert();
            }
            else
            {
                if (grdObjects.gridEX1.SelectedItems.Count == 0)
                {
                    JMessages.Error("لطفا یک یا چند داده را انتخاب کنید.", "");
                    return;
                }
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in grdObjects.gridEX1.SelectedItems)
                {
                    if (item.RowType == Janus.Windows.GridEX.RowType.Record)
                    {
                        objectCode = (int)((DataRowView)(item.GetRow().DataRow)).Row["Code"];
                        JPermissionUser pUser = new JPermissionUser();
                        pUser.HasPermission = true;
                        pUser.User_Post_Code = chartCode;
                        pUser.DecisionCode = _permissionDesicion;
                        pUser.ObjectCode = objectCode;
                        pUser.Insert();
                    }
                }
            }
            SetObjectList(UserCode);
            SetPermissions(UserCode);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdUsers.SelectedRow == null)
                return;
            Nullable<int> UserCode = (Nullable<int>)(grdUsers.SelectedRow[0]);

            foreach (Janus.Windows.GridEX.GridEXSelectedItem item in grdPermissions.gridEX1.SelectedItems)
            {
                if (item.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    int permissionCode = (int)((DataRowView)(item.GetRow().DataRow)).Row["Code"];
                    JPermissionUser pUser = new JPermissionUser(permissionCode);
                    pUser.delete();
                }
            }
            SetObjectList(UserCode);
            SetPermissions(UserCode);
        }

        private void JGroupPermissionForm_Load(object sender, EventArgs e)
        {
            lblStatus.SingleText = this.Text;
            grdUsers.gridEX1.SelectionChanged += new EventHandler(gridEX1_SelectionChanged);
        }

        void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            Nullable<int> UserCode = null;
            if (grdUsers.SelectedRow != null)
                UserCode = (Nullable<int>)(grdUsers.SelectedRow[0]);
            SetPermissions(UserCode);
            SetObjectList(UserCode);
        }
    }
}
