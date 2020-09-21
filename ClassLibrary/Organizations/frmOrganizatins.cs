using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class JfrmOrganizatins : JBaseForm
    {
        private bool _ViewMode = false;
        private JOrganization _JOrg;
        private int ParentAccessCode;
        public DataGridViewRow SelectedRow;
        public DataGridViewSelectedRowCollection SelectedRows;
        private bool _MultiSelect = false;
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;
                uc_Grd_Organizations.MultiSelect = _MultiSelect;
            }
        }

        /// <summary>
        /// سازنده
        /// </summary>
        public JfrmOrganizatins(JOrganization jclass)
        {
            InitializeComponent();
            if (jclass != null)
            {
                _JOrg = jclass;
                txtOrganizationName.Text = _JOrg.Name;
                txtAddress.Text = _JOrg.Address.Address;
                txtDescription.Text = _JOrg.Description;
                txtManagingDirector.Text = _JOrg.Managing_Director;
                txtPhoneNumber.Text = _JOrg.Address.Tel;
                nedtAccessCode.Text = _JOrg.Access_Code.ToString();
                if (_JOrg.ParentCode != 0 )
                {
                    ParentAccessCode = Convert.ToInt32((new JOrganizations()).GetOrganization(_JOrg.ParentCode).Rows[0]["access_code"]);
                }
                State = JFormState.Update;
            }
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JfrmOrganizatins()
        {
            InitializeComponent();
            _ViewMode = true;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (txtOrganizationName.Text.Trim() == "")
            {
                JMessages.Message(JLanguages._Text("Please Enter Organ Name"), "Error", JMessageType.Error);
                txtOrganizationName.Focus();
                return;
            }

            JOrganization jOrg = new JOrganization();
            if ( ( State == JFormState.Insert &&  jOrg.Find(txtOrganizationName.Text.Trim()) ) ||
                 (State == JFormState.Update && jOrg.Find(txtOrganizationName.Text.Trim()) && txtOrganizationName.Text.Trim() != _JOrg.Name))
            {
                JMessages.Message(JLanguages._Text("an Organ with this name register Previous"), "Error", JMessageType.Error);
                txtOrganizationName.Focus();
                return;
            }
            if (nedtAccessCode.Text.Trim() == "")
            {
                JMessages.Message(JLanguages._Text("Please Enter Organ code"), "Error", JMessageType.Error);
                nedtAccessCode.Focus();
                return;
            }

            jOrg.Access_Code = int.Parse(nedtAccessCode.Text);
            if( ( State == JFormState.Insert && jOrg.Find()) || 
                ( State == JFormState.Update && jOrg.Find() && jOrg.Access_Code.ToString() != _JOrg.Access_Code.ToString()))
            {                
                JMessages.Message(JLanguages._Text("Code" )+" " + nedtAccessCode.Text + JLanguages._Text("Reserved by previous Organ") + "\n "+JLanguages._Text("Please change This")+"                                  ", "Error", JMessageType.Error);
                nedtAccessCode.Focus();
                return;
            }

            
            jOrg = new JOrganization();          
            jOrg.Name = txtOrganizationName.Text.Trim();
            //jOrg.Nodes = _JOrg.Nodes;
            jOrg.Managing_Director = txtManagingDirector.Text.Trim();
            jOrg.Address.Tel = txtPhoneNumber.Text.Trim();
            jOrg.Access_Code = int.Parse(nedtAccessCode.Text);
            jOrg.Address.Address = txtAddress.Text.Trim();
            jOrg.Description = txtDescription.Text.Trim();


            if (nedtAccessCode.Text != "" && cdbOrganizations.SelectedValue != null && int.Parse(cdbOrganizations.SelectedValue.ToString()) > 0)
            {
                jOrg.ParentCode = Convert.ToInt32(((System.Data.DataRowView)(cdbOrganizations.SelectedItem)).Row.ItemArray[0]);
            }
            if (State == JFormState.Insert)
            {
                if (jOrg.Insert()>0)
                {
                    _RefreshGrid();
                    uc_Grd_Organizations.Refresh();
                    _SetCmb();
                    _ClearFrom();
                    JMessages.Message(JLanguages._Text("New organization register successfully"), "", JMessageType.Information);
                }
                else
                {
                    JMessages.Message(JLanguages._Text("Error ! in Insert new Organization"), "Error", JMessageType.Error);
                }
            }
            else if (State == JFormState.Update)
            {
                jOrg.Code = _JOrg.Code;
                if (jOrg.Update())
                {
                    _RefreshGrid();
                    uc_Grd_Organizations.Refresh();
                    _SetCmb();
                    _ClearFrom();
                    JMessages.Message(JLanguages._Text("Organization Updated successfully"), "", JMessageType.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    JMessages.Message(JLanguages._Text("Error ! in Insert new Organization"), "Error", JMessageType.Error);
                }
            }

            //DialogResult = DialogResult.OK;
            //Close();
        }

        #region Functions
        /// <summary>
        /// 
        /// </summary>
        private void _ClearFrom()
        {
            txtOrganizationName.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtManagingDirector.Text = "";
            txtPhoneNumber.Text = "";
            nedtAccessCode.Text = ((new JOrganizations()).GetMaxAccessCode() + 1).ToString();
            cdbOrganizations.SelectedIndex = 0;
            txtOrganizationName.Focus();
        }
        /// <summary>
        /// مقدار دهی اولیه فرم
        /// </summary>
        private void _InitialazeForm()
        {
            if (_ViewMode)
            {
                uc_Grd_Organizations.Top = 0;
                //uc_Grd_Organizations.Height +=  100;          
                //pnlActions.Visible = false;
            }
            else if (State == JFormState.Insert)
            {
                JOrganizations jOrgs = new JOrganizations();
                nedtAccessCode.Text = (jOrgs.GetMaxAccessCode() + 1).ToString();
            }
            _SetCmb();
            _RefreshGrid();
        }
        /// <summary>
        /// جدول داده ها
        /// </summary>
        private void _RefreshGrid()
        {
            JDataBase db = new JDataBase();
            db.setQuery((new JOrganizations()).GetOrganizationSql(0));
            uc_Grd_Organizations.Bind(db,"");
        }
        /// <summary>
        /// تنظیم لیست های روی فرم
        /// </summary>
        private void _SetCmb()
        {
            try
            {
                //cmbOrganizations.DisplayMember = "full_title";
                //cmbOrganizations.ValueMember = "access_code";
                DataTable dt = new DataTable();
                dt = (new JOrganizations()).GetOrganization(0);
                //DataRow dr = dt.NewRow();
                //dr["code"] = "-1";
                //dr["full_title"] = "-----------";
                //dr["access_code"] = "-1";
                //dt.Rows.InsertAt(dr, 0);
                //cmbOrganizations.DataSource = dt;
                //if (ParentAccessCode != 0)
                //{
                //    nedtAccessCodeParent.Text = ParentAccessCode.ToString();
                //    cmbOrganizations.SelectedValue = ParentAccessCode;
                //}

                cdbOrganizations.TitleFieldName = "full_title";
                cdbOrganizations.CodeFieldName = "code";
                cdbOrganizations.AccessCodeFieldName = "access_code";
                cdbOrganizations.dataTable = dt;
                cdbOrganizations.SetComboBox();
                cdbOrganizations.SetValue(2);

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion Functions

        //private void nedtAccessCodeParent_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (nedtAccessCodeParent.Text != "")
        //        {
        //            cmbOrganizations.SelectedValue = nedtAccessCodeParent.Text;
        //        }
        //        else
        //        {
        //            cmbOrganizations.SelectedIndex = 0;
        //        }
        //    }
        //}

        //private void nedtAccessCodeParent_Leave(object sender, EventArgs e)
        //{
        //    if (nedtAccessCodeParent.Text != "")
        //    cmbOrganizations.SelectedValue = int.Parse(nedtAccessCodeParent.Text);
        //}

        //private void cmbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbOrganizations.SelectedValue != null && int.Parse(cmbOrganizations.SelectedValue.ToString()) != -1)
        //        {
        //            nedtAccessCodeParent.Text = cmbOrganizations.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            nedtAccessCodeParent.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //    }


        //}

        //private void cmbOrganizations_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //    if (cmbOrganizations.SelectedIndex != -1 && int.Parse(cmbOrganizations.SelectedValue.ToString()) != -1)
        //    {
        //    }
        //    else
        //    {
        //        nedtAccessCodeParent.Text = "";
        //        nedtAccessCodeParent.Focus();
        //    }
        //                }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //    }

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    JfrmOrganizatins jorg = new JfrmOrganizatins();
        //    object s = 0;
        //    if (jorg.ShowDialog() == DialogResult.OK)
        //    {
        //        s = jorg.SelectedRow["access_code"];
        //        //cdbOrganizations.txtCode.Text = jorg.SelectedRow["access_code"].ToString();
        //        jorg.Dispose();
        //    }
        //    cdbOrganizations.cmbTitles.SelectedValue = s;
        //}

        private void uc_Grd_Organizations_GridRowDoubleClick(object sender, System.EventArgs e)
        {
            if (_ViewMode)
            {
                SelectedRow = uc_Grd_Organizations.SelectedRow;
                DialogResult = DialogResult.OK;
                //this.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void uc_Grd_Organizations_SelectedRowChanged(object sender, EventArgs e)
        //{
           
        //}

        private void JfrmOrganizatins_Load(object sender, EventArgs e)
        {
            _InitialazeForm();      
            if (State == JFormState.Update)
            {                
                cdbOrganizations.SetValue(ParentAccessCode);
                cdbOrganizations.Enabled = false;
                btnSelOrganization.Enabled = false;
            }
        }



        private void cdbOrganizations_ButtonClick(object sender, EventArgs e)
        {
            JfrmOrganizatins jorg = new JfrmOrganizatins();
            if (jorg.ShowDialog() == DialogResult.OK)
            {
             //    jorg.SelectedRow["access_code"];
                //cdbOrganizations.SetValue(jorg.SelectedRow["access_code"]);
                jorg.Dispose();
            }
           // cdbOrganizations.cmbTitles.SelectedValue = s;
            cdbOrganizations.SetValue(2);

        }

        private void btnSelOrganization_Click(object sender, EventArgs e)
        {
          JfrmOrganizatins jorg = new JfrmOrganizatins();
            if (jorg.ShowDialog() == DialogResult.OK)
            {
                 cdbOrganizations.SetValue(jorg.SelectedRow.Cells["access_code"].Value);
                jorg.Dispose();
            }
        }

        private void uc_Grd_Organizations_SelectionChanged(object sender, EventArgs e)
        {
            if (uc_Grd_Organizations.SelectedRows != null)
            {
                SelectedRows = uc_Grd_Organizations.SelectedRows;
            }
        }

        private void btnReturnSelected_Click(object sender, EventArgs e)
        {
            if (uc_Grd_Organizations.SelectedRows != null)
            {
                SelectedRows = uc_Grd_Organizations.SelectedRows;
                DialogResult = DialogResult.OK;
            }
        }

    }
}
