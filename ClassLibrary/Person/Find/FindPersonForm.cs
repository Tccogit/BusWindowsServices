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

    public partial class JFindPersonForm : JBaseForm
    {
        private string Condition = "";

        public JFindPersonForm()
            : this("")
        {
        }
        JPersonTypes _pType = JPersonTypes.None;
        /// <summary>
        /// در صورتی که نوع شخص انتخاب شود، کاربر فقط باید از این نوع شخص انتخاب کند
        /// </summary>
public JFindPersonForm(JPersonTypes pType)
            : this(pType, "")
        {
        }

        public JFindPersonForm(JPersonTypes pType, string pCondition)
                {
            InitializeComponent();
            Condition = pCondition;
            _pType = pType;
            if (pType == JPersonTypes.LegalPerson)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Remove(tabAllPerson);
                tabControl1.TabPages.Remove(tabRealPerson);
                tabControl1.TabPages.Add(tabLegalPerson);
            }
            if (pType == JPersonTypes.RealPerson)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Remove(tabAllPerson);
                tabControl1.TabPages.Remove(tabLegalPerson);
                tabControl1.TabPages.Add(tabRealPerson);
            }
            _FillComboBox();
        }

        public JFindPersonForm(string pCondition)
        {
            InitializeComponent();
            _FillComboBox();
            Condition = pCondition;
        }


        /// <summary>
        /// کد شخص انتخاب شده
        /// </summary>
        public int SelectedPersonCode;
		public Int64 SelectSharePCode;
        public int[] SelectedPersonsCode = new int[0];
        public bool MultiSelect;
		private int _CompanyCode = 1;
		public int CompanyCode { 
			get
			{
				return _CompanyCode;
			}
			set
			{
				_CompanyCode = value;
				
			}
		}
        /// <summary>
        /// نام شخص انتخاب شده
        /// </summary>
        public JAllPerson SelectedPerson { get; set; }
        /// <summary>
        ///  مقادیر وضعیت شرکت
        /// </summary>
        private int[] coStatusValues = Enum.GetValues(typeof(JCompanyStatuses)).Cast<int>().ToArray();

        private void JFindPersonForm_Load(object sender, EventArgs e)
        {
            
        }

        public void _FillComboBox()
        {
            cmbSex.Items.Add("زن");
            cmbSex.Items.Add("مرد");
            
            //JCities cities = new JCities();
            //JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            //nullDeff.Code = -1;
            //nullDeff.Name = "-----------";
            ///// شهر محل صدور شناسنامه
            //cmbSaderAz.Items.Clear();
            //cmbSaderAz.Items.Add(nullDeff);
            //cmbSaderAz.SelectedItem = nullDeff;
            //foreach (JSubBaseDefine city in cities.Items)
            //{
            //    cmbSaderAz.Items.Add(city);
            //}

            cmbSaderAz.DataSource = JSubBaseDefines.GetDataTable(JBaseDefine.CityCode);
            cmbSaderAz.ValueMember = "Code";
            cmbSaderAz.DisplayMember = "Name";

            cmbLocationRegister.DataSource = JSubBaseDefines.GetDataTable(JBaseDefine.CityCode);
            cmbLocationRegister.ValueMember = "Code";
            cmbLocationRegister.DisplayMember = "Name";
            cmbLocationRegister.SelectedIndex = -1;
            cmbSaderAz.SelectedIndex = -1;
            ///شهر محل ثبت شرکت
            //cmbLocationRegister.Items.Clear();
            //cmbLocationRegister.Items.Add(nullDeff);
            //cmbLocationRegister.SelectedItem = nullDeff;
            //foreach (JSubBaseDefine city in cities.Items)
            //{
            //    cmbLocationRegister.Items.Add(city);
            //}
            /////انواع شرکت
            //JCompanyTypes coTypes = new JCompanyTypes();
            //cmbCompanyType.Items.Clear();
            //cmbCompanyType.Items.Add(nullDeff);
            //cmbCompanyType.SelectedItem = nullDeff;
            //foreach (JSubBaseDefine coType in coTypes.Items)
            //{
            //    cmbCompanyType.Items.Add(coType);
            //}

            ///وضعیت شرکت
            ///
            cmbStatus.Items.Clear();
            //cmbStatus.Items.Add(nullDeff);
            //cmbStatus.SelectedItem = nullDeff;

            string[] coStatuses = Enum.GetNames(typeof(JCompanyStatuses));
            foreach (string coStatus in coStatuses)
            {
                cmbStatus.Items.Add(JLanguages._Text(coStatus));
            }
            cmbStatus.SelectedIndex = 0;
            txtCodeRealPerson.BackColor = SystemColors.Window;
            txtCodeLegal.BackColor = SystemColors.Window;
           
        }

        private void bmtFindRealPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int sader = 0;
                if (cmbSaderAz.SelectedValue != null)
                    sader = (int)cmbSaderAz.SelectedValue;

                grdPerson.DataSource =
                     JPerson.SearchPerson(txtCodeRealPerson.IntValue, txtNameReal.Text, txtLastNameReal.Text, txtFatherName.Text, txtIDNumber.Text, 0, txtDateBirthFrom.Date, txtDateBirthTo.Date, sader, txtNationalCode.Text, cmbSex.SelectedIndex, Condition, txtDesc.Text.Trim()); //((JSubBaseDefine)cmbSaderAz.SelectedItem).Code
                /// اولین فیلد که بصورت عنوان آورده شده، نمایش داده نمیشود
                grdPerson.Columns[0].Visible = false;
                if (grdPerson.RowCount > 0)
                    grdPerson.CurrentCell = grdPerson["Name", 0];
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void bmtSelectPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPerson.SelectedRows.Count == 0)
                    return;
                if (MultiSelect)
                {
                    int i = 0;
                    foreach (DataGridViewRow row in grdPerson.SelectedRows)
                    {
                        Array.Resize(ref SelectedPersonsCode, SelectedPersonsCode.Length + 1);
                        SelectedPersonsCode[i] = Convert.ToInt32(row.Cells["Code"].Value);
                        i++;
                    }
                }
                else
                {
                    SelectedPersonCode = Convert.ToInt32(grdPerson.SelectedRows[0].Cells["Code"].Value);
                    SelectedPerson = new JAllPerson(SelectedPersonCode);                   
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                grdAllPerson.DataSource = JAllPerson.SearchPerson(txtAllCode.IntValue, txtAllName.Text, -1, JPersonTypes.None, Condition ,txtTafsiliCode.IntValue,txtSharePCode.Int64Value);
                /// اولین فیلد که بصورت عنوان آورده شده، نمایش داده نمیشود
                grdAllPerson.Columns[0].Visible = false;
                if (grdAllPerson.RowCount > 0)
                    grdAllPerson.CurrentCell = grdAllPerson["Name", 0];
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdAllPerson.SelectedRows.Count == 0)
                return;
            if (MultiSelect)
            {
                int i = 0;
                Array.Resize(ref SelectedPersonsCode, grdAllPerson.SelectedRows.Count);
                foreach (DataGridViewRow row in grdAllPerson.SelectedRows)
                {
                    SelectedPersonsCode[i] = Convert.ToInt32(row.Cells["Code"].Value);
                    i++;
                }
            }
            SelectedPersonCode = Convert.ToInt32(grdAllPerson.SelectedRows[0].Cells["Code"].Value);
			SelectSharePCode = ManagementShares.ShareCompany.JSharepCode.GetPersonShare(CompanyCode,SelectedPersonCode);
            SelectedPerson = new JAllPerson(SelectedPersonCode);

            DialogResult = DialogResult.OK;
        }

        private void bmtFindlegalPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int regPlace = 0;
                if (cmbLocationRegister.SelectedValue != null)
                    regPlace = (int)cmbLocationRegister.SelectedValue;
                grdLegalPerson.DataSource = JOrganization.SearchPerson(txtCodeLegal.IntValue, txtNameLegal.Text, "", txtRegistrationNum.Text,regPlace, txtTopic.Text, (Convert.ToInt32(cmbCompanyType.SelectedValue)), coStatusValues[cmbStatus.SelectedIndex]);
                /// اولین فیلد که بصورت عنوان آورده شده، نمایش داده نمیشود
                grdLegalPerson.Columns[0].Visible = false;
                if (grdLegalPerson.RowCount > 0)
                    grdLegalPerson.CurrentCell = grdLegalPerson["Name", 0];
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void grdAllPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectAllPerson.PerformClick();
        }

        private void btnSelectLegalPerson_Click(object sender, EventArgs e)
        {
            if (grdLegalPerson.SelectedRows.Count == 0)
                return;
            if (MultiSelect)
            {
                int i = 0;
                foreach (DataGridViewRow row in grdLegalPerson.SelectedRows)
                {
                    SelectedPersonsCode[i] = Convert.ToInt32(row.Cells["Code"].Value);
                    i++;
                }
            }
            else
            {
                SelectedPersonCode = Convert.ToInt32(grdLegalPerson.SelectedRows[0].Cells["Code"].Value);
                SelectedPerson = new JAllPerson(SelectedPersonCode);                
            }
            DialogResult = DialogResult.OK;
        }

        private void DataGridRealPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectPerson.PerformClick();
        }

        private void grdLegalPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectLegalPerson.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdAllPerson.SelectedRows.Count == 0)
                return;
            SelectedPersonCode = Convert.ToInt32(grdAllPerson.SelectedRows[0].Cells["Code"].Value);
            JAllPerson allPerson = new JAllPerson(SelectedPersonCode);
            if (allPerson.PersonType == JPersonTypes.LegalPerson)
            {
                JOrganization legPerson = new JOrganization(allPerson.Code);
                legPerson.ShowDialog();
            }
            else if (allPerson.PersonType == JPersonTypes.RealPerson)
            {
                JPerson person = new JPerson(allPerson.Code);
                person.ShowDialog();
            }
            btnSearchAll.PerformClick();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            if (grdPerson.SelectedRows.Count == 0)
                return;
            SelectedPersonCode = Convert.ToInt32(grdPerson.SelectedRows[0].Cells["Code"].Value);
            JPerson person = new JPerson(SelectedPersonCode);
            person.ShowDialog();
            btnSearchRealPerson.PerformClick();
        }

        private void btnNewAllPerson_Click(object sender, EventArgs e)
        {
            mnuNew.Show(MousePosition.X, MousePosition.Y);
        }

        private void شخصحقیقیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //btnNewPerson.PerformClick();
            btnNewPerson_Click(sender, e);
        }

        private void شخصحقوقیToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   btnNewLegalPerson.PerformClick();
            btnNewLegalPerson_Click(sender, e);
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            JPerson person = new JPerson();
            person.ShowDialog();
            btnSearchRealPerson.PerformClick();
        }

        private void btnEditLegalPerson_Click(object sender, EventArgs e)
        {
            if (grdLegalPerson.SelectedRows.Count == 0)
                return;
            SelectedPersonCode = Convert.ToInt32(grdLegalPerson.SelectedRows[0].Cells["Code"].Value);
            JOrganization legPerson = new JOrganization(SelectedPersonCode);
            legPerson.ShowDialog();
            btnSearchLegalPerson.PerformClick();
        }

        private void btnNewLegalPerson_Click(object sender, EventArgs e)
        {
            JOrganization legPerson = new JOrganization();
            legPerson.ShowDialog();
            btnSearchLegalPerson.PerformClick();
        }        

        private void JFindPersonForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == (int)Keys.Enter)
            {
                if(tabControl1.SelectedTab == tabAllPerson)                    
                    btnSearchAll_Click(null, null);
                else if(tabControl1.SelectedTab == tabRealPerson)
                    bmtFindRealPerson_Click(null,null);
                else if(tabControl1.SelectedTab == tabLegalPerson)
                    bmtFindlegalPerson_Click(null, null);
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabRealPerson)
                txtLastNameReal.Focus();
            if (tabControl1.SelectedTab == tabAllPerson)
                txtAllName.Focus();
            if (tabControl1.SelectedTab == tabLegalPerson)
                txtNameLegal.Focus();
        }

        private void JFindPersonForm_Shown(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabRealPerson)
                txtLastNameReal.Focus();
            if (tabControl1.SelectedTab == tabAllPerson)
                txtAllName.Focus();
            if(tabControl1.SelectedTab == tabLegalPerson)
                txtNameLegal.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabRealPerson)
                txtLastNameReal.Focus();
            if (tabControl1.SelectedTab == tabAllPerson)
                txtAllName.Focus();
            if (tabControl1.SelectedTab == tabLegalPerson)
                txtNameLegal.Focus();
        }

        private void mnuNew_Opening(object sender, CancelEventArgs e)
        {

        }

        private void شخصنامشخصtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            JOtherPersonForm OP = new JOtherPersonForm();
            OP.ShowDialog();
            btnSearchLegalPerson.PerformClick();
        }

        private void txtCodeRealPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdPerson.CurrentRow != null)
            {
                e.Handled = true;
                if (e.KeyData == Keys.Up)
                {
                    if (grdPerson.CurrentRow.Index - 1 >= 0)
                    {
                        grdPerson.Rows[grdPerson.CurrentRow.Index - 1].Selected = true;
                        grdPerson.CurrentCell = grdPerson["Name", grdPerson.CurrentRow.Index - 1];
                    }
                }

                if (e.KeyData == Keys.Down)
                {
                    try
                    {
                        if (grdPerson.CurrentRow.Index + 1 < grdPerson.Rows.Count)
                        {
                            grdPerson.Rows[grdPerson.CurrentRow.Index + 1].Selected = true;
                            grdPerson.CurrentCell = grdPerson["Name", grdPerson.CurrentRow.Index + 1];
                        }
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
                if (e.KeyData == Keys.Enter)
                {
                    btnSelectPerson.PerformClick();
                }
            }
        }

        private void txtAllCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdAllPerson.CurrentRow != null)
            {
                e.Handled = true;
                if (e.KeyData == Keys.Up)
                {
                    if (grdAllPerson.CurrentRow.Index - 1 >= 0)
                    {
                        grdAllPerson.Rows[grdAllPerson.CurrentRow.Index - 1].Selected = true;
                        grdAllPerson.CurrentCell = grdAllPerson["Name", grdAllPerson.CurrentRow.Index - 1];
                    }
                }

                if (e.KeyData == Keys.Down)
                {
                    try
                    {
                        if (grdAllPerson.CurrentRow.Index + 1 < grdAllPerson.Rows.Count)
                        {
                            grdAllPerson.Rows[grdAllPerson.CurrentRow.Index + 1].Selected = true;
                            grdAllPerson.CurrentCell = grdAllPerson["Name", grdAllPerson.CurrentRow.Index + 1];
                        }
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
                if (e.KeyData == Keys.Enter)
                {
                    btnSelectAllPerson.PerformClick();
                }
            }
        }

        private void txtCodeLegal_KeyDown(object sender, KeyEventArgs e)
        {

            if (grdLegalPerson.CurrentRow != null)
            {
                e.Handled = true;
                if (e.KeyData == Keys.Up)
                {
                    if (grdLegalPerson.CurrentRow.Index - 1 >= 0)
                    {
                        grdLegalPerson.Rows[grdLegalPerson.CurrentRow.Index - 1].Selected = true;
                        grdLegalPerson.CurrentCell = grdLegalPerson["Name", grdLegalPerson.CurrentRow.Index - 1];
                    }
                }

                if (e.KeyData == Keys.Down)
                {
                    try
                    {
                        if (grdLegalPerson.CurrentRow.Index + 1 < grdLegalPerson.Rows.Count)
                        {
                            grdLegalPerson.Rows[grdLegalPerson.CurrentRow.Index + 1].Selected = true;
                            grdLegalPerson.CurrentCell = grdLegalPerson["Name", grdLegalPerson.CurrentRow.Index + 1];
                        }
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
                if (e.KeyData == Keys.Enter)
                {
                    btnSelectLegalPerson.PerformClick();
                }
            }
        }
    }
}
