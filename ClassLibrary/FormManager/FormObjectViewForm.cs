using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals.Property;
using Microsoft.Win32;

namespace ClassLibrary
{
    public partial class FormObjectViewForm : ClassLibrary.JBaseForm
    {
        public int _ReferCode;
        DataTable _DataTable;
        public const string _ConstClassName = "ClassLibrary.FormManagers";

        public bool isMultiple;
        public int _FormCode, _ObjectCode, _ValueObjectCode;
        public string _ClassName;
		public FormObjectViewForm()
		{
			try
			{
				InitializeComponent();
			}
			catch
			{
			}
		}
		public FormObjectViewForm(int valueObjectCode, int referCode)
			: this()
		{
			if (DesignMode)
				return;

			JFormObjects jFormObjects = new JFormObjects(valueObjectCode);

			_ClassName = jFormObjects.Form.ClassName;
			_FormCode = jFormObjects.FormCode;
			_ObjectCode = jFormObjects.ObjectCode;
			_ValueObjectCode = valueObjectCode;
			_ReferCode = referCode;

			jPropertyValueUserControl1.ObjectCode = _FormCode;
			jPropertyValueUserControl1.ValueObjectCode = _ValueObjectCode;
			jPropertyValueUserControl1.ClassName = _ConstClassName;

			propertyValueGridControl1.ObjectCode = _FormCode;
			propertyValueGridControl1.ValueObjectCode = _ValueObjectCode;
			propertyValueGridControl1.ClassName = _ConstClassName;

			panel3.Width = ReadValueRegister();

		}

        public FormObjectViewForm(string className, int formCode, int objectCode)
			: this()
		{
            _ClassName = className;
            _FormCode = formCode;
            _ObjectCode = objectCode;

            jPropertyValueUserControl1.ObjectCode = formCode;
            jPropertyValueUserControl1.ClassName = _ConstClassName;

            propertyValueGridControl1.ObjectCode = formCode;
            propertyValueGridControl1.ClassName = _ConstClassName;
		
			panel3.Width = ReadValueRegister();
		}

        public FormObjectViewForm(int formCode, int objectCode, int valueObjectCode)
			: this()
		{
            JForms jForms = new JForms(formCode);
            _ClassName = jForms.ClassName;
            _FormCode = formCode;
            _ObjectCode = objectCode;
            _ValueObjectCode = valueObjectCode;

            jPropertyValueUserControl1.ObjectCode = formCode;
            jPropertyValueUserControl1.ValueObjectCode = _ValueObjectCode;
            jPropertyValueUserControl1.ClassName = _ConstClassName;

            propertyValueGridControl1.ObjectCode = formCode;
            propertyValueGridControl1.ValueObjectCode = _ValueObjectCode;
            propertyValueGridControl1.ClassName = _ConstClassName;

			panel3.Width = ReadValueRegister();
		}

        public FormObjectViewForm(string className, int formCode, int objectCode, int valueObjectCode)
			: this()
		{
            _ClassName = className;
            _FormCode = formCode;
            _ObjectCode = objectCode;
            _ValueObjectCode = valueObjectCode;

            jPropertyValueUserControl1.ObjectCode = formCode;
            jPropertyValueUserControl1.ValueObjectCode = _ValueObjectCode;
            jPropertyValueUserControl1.ClassName = _ConstClassName;

            propertyValueGridControl1.ObjectCode = formCode;
            propertyValueGridControl1.ValueObjectCode = _ValueObjectCode;
            propertyValueGridControl1.ClassName = _ConstClassName;

			panel3.Width = ReadValueRegister();
		}

		private void SetValueRegister(int SubPanelWidth)
		{
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                if (key == null)
                    key = Registry.CurrentUser.CreateSubKey("Software");

                key.CreateSubKey("ERPTarahan");
                key = key.OpenSubKey("ERPTarahan", true);

                key.CreateSubKey("Version2015");
                key = key.OpenSubKey("Version2015", true);

                key.SetValue("PanelWidthForms_" + _ClassName + _FormCode.ToString(), SubPanelWidth);
            }
            catch
            {
            }

		}

		private int ReadValueRegister()
		{
			try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
			if (key == null)
				key = Registry.CurrentUser.CreateSubKey("Software");

			key = key.OpenSubKey("ERPTarahan");
			if (key == null)
			{
				return 250;
			}

			key = key.OpenSubKey("Version2015", true);
			if (key == null)
			{
				return 250;
			}

			return (int)key.GetValue("PanelWidthForms_" + _ClassName + _FormCode.ToString(), 250);
            }
            catch
            {
            }
            return 0;
		}
        private bool Save()
        {
            if (isMultiple == true && propertyValueGridControl1.HasRows() == false)
            {
                JMessages.Error("امکان ثبت فرم خالی وجود ندارد.", "فرم");
                return false;
            }
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("FormObjectViewForm");
                if (_ValueObjectCode == 0 && isMultiple == false)
                {
                    ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects();
                    jFormObjects.Date = JDateTime.Now();
                    jFormObjects.FormCode = _FormCode;
                    jFormObjects.ObjectCode = _ObjectCode;
                    jFormObjects.Comment = txtComment.Text;
                    jFormObjects.Description = txtDescription.Text;
                    _ValueObjectCode = jFormObjects.Insert(db);
                    JArchive.ObjectCode = _ValueObjectCode;
                    if (_ValueObjectCode <= 0)
                    {
                        JMessages.Error("ایجاد فرم جدید با خطا مواجه شده است.", "فرم جدید");
                        db.Rollback("FormObjectViewForm");
                        this.Close();
                        return false;
                    }
                    jPropertyValueUserControl1.ValueObjectCode = _ValueObjectCode;
                }

                if ((isMultiple == false && jPropertyValueUserControl1.Save(db)) || (isMultiple == true && propertyValueGridControl1.Save(db)))
                {
                    db.Commit();
                    JFormObjects jFormObjects = new JFormObjects();
                    jFormObjects.Update(_ValueObjectCode, txtComment.Text, txtDescription.Text);
                }
                else
                {
                    db.Rollback("FormObjectViewForm");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                db.Rollback("FormObjectViewForm");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        private void ShowInfo()
        {
            _DataTable = (new JForms(_FormCode)).GetSQL(_ObjectCode);
            if (_DataTable == null) return;
            DataTable dt = new DataTable();
            dt.Columns.Add("نام");
            dt.Columns.Add("مقدار");
            for (int i = 0; i < _DataTable.Columns.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = JLanguages._Text(_DataTable.Columns[i].ToString());
                if (_DataTable.Rows.Count > 0)
                    dr[1] = _DataTable.Rows[0][i];
                dt.Rows.Add(dr);
            }
            dgrInfo.DataSource = dt;
            dgrInfo.Columns[0].Width = (dgrInfo.Width / 100) * 30;
            dgrInfo.Columns[1].Width = (dgrInfo.Width / 100) * 70;
        }

        private void ClearEmptyFormObject()
        {
            if (_ReferCode > 0) return;
            JProperties jProperties = new JProperties(_ConstClassName, _FormCode);
            if (jProperties.GetPropertyTableData(_ValueObjectCode) == null || jProperties.GetPropertyTableData(_ValueObjectCode).Rows.Count == 0)
            {
                JFormObjects jFormObjects = new JFormObjects(_ValueObjectCode);
                jFormObjects.Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (isMultiple) propertyValueGridControl1.SaveFieldsChanges();
                else jPropertyValueUserControl1.SaveFieldsChanges();
                JArchive.ArchiveList();
                if (JMessages.Warning("اطلاعات با موفقیت ذخیره شد. آیا تمایل به بسته شدن فرم دارید؟", "فرم") == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                JMessages.Error("خطا در ذخیره سازی اطلاعات", "خطا");
            }
        }

        private void FormObjectViewForm_Load(object sender, EventArgs e)
        {
            JForms jForms = new JForms(_FormCode);
            this.Text = jForms.FormName;
            isMultiple = jForms.isMultiple;
            if (jForms.Action == null || jForms.Action.Length == 0)
                button1.Visible = false;
            if (jForms.isMultiple)
            {
                tabControl2.SelectTab(1);
                tabControl2.TabPages.RemoveAt(0);
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                tabControl2.SelectTab(0);
                tabControl2.TabPages.RemoveAt(1);
                //jPropertyHistoryView1.Visible = false;
            }

            // Create new FormObject for Multiple Forms
            JDataBase db = new JDataBase();
            db.beginTransaction("FormObjectViewForm");
            try
            {
                if (_ValueObjectCode == 0 && isMultiple == true)
                {
                    ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects();
                    jFormObjects.Date = JDateTime.Now();
                    jFormObjects.FormCode = _FormCode;
                    jFormObjects.ObjectCode = _ObjectCode;
                    jFormObjects.Comment = txtComment.Text;
                    jFormObjects.Description = txtDescription.Text;
                    _ValueObjectCode = jFormObjects.Insert(db);
                    if (_ValueObjectCode <= 0)
                    {
                        JMessages.Error("ایجاد فرم جدید با خطا مواجه شده است.", "فرم جدید");
                        db.Rollback("FormObjectViewForm");
                        this.Close();
                        return;
                    }
                    db.Commit();
                    propertyValueGridControl1.ValueObjectCode = _ValueObjectCode;
                }
            }
            finally { db.Dispose(); }

            if (_ValueObjectCode > 0)
            {
                JFormObjects jFormObjects = new JFormObjects(_ValueObjectCode);
                txtComment.Text = jFormObjects.Comment;
                txtDescription.Text = jFormObjects.Description;
				if (jFormObjects.NoStorage > 0)
				{
					buttonNoStorage.Enabled = false;
					buttonNoStorage.Text = jFormObjects.NoStorage.ToString();
				}


            }

            if (_ReferCode == 0)
            {
                _ReferCode = (new Automation.JARefer()).
                        FindLastRefer(_ConstClassName, _ValueObjectCode, _FormCode, JMainFrame.CurrentPostCode);
                if (_ReferCode <= 0)
                    _ReferCode = (new Automation.JARefer()).
                            FindRefer(_ConstClassName, _ValueObjectCode, _FormCode);
            }
            if (_ReferCode != 0)
            {
                Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                {
                    btnSave.Enabled = false;
                    if (isMultiple) propertyValueGridControl1.SwitchToViewMode();
                    btnRefer.Enabled = false;
                    txtDescription.ChangeToViewMode();
                }
            }
            ShowInfo();
            jPropertyHistoryView1._ClassName = _ConstClassName;
            jPropertyHistoryView1._ObjectCode = _FormCode;
            jPropertyHistoryView1._TableObjectCode = _ValueObjectCode;
            jPropertyHistoryView1.Refresh();
            refersText1.TotalRefers = true;
            refersText1.LoadRefer(_ReferCode);
            JArchive.ClassName = _ConstClassName;
            JArchive.ObjectCode = _ValueObjectCode;
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (Save())
            {
				if (isMultiple) propertyValueGridControl1.SaveFieldsChanges();
				else jPropertyValueUserControl1.SaveFieldsChanges();
				
				JArchive.ArchiveList();

                JForms jForms = new JForms();
                jForms.GetData(_FormCode);

                DataTable _DT = GetData();
                Automation.Refer.frmRecieverSelector frmrs =
                    new Automation.Refer.frmRecieverSelector
                        (_DT, null, _ConstClassName, _FormCode, _ValueObjectCode, jForms.FormName, _ReferCode);
                if (frmrs.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    // Save History
                    if (isMultiple) propertyValueGridControl1.SaveFieldsChanges();
                    else jPropertyValueUserControl1.SaveFieldsChanges();

                    btnSave.Enabled = false;
                    if (isMultiple) propertyValueGridControl1.SwitchToViewMode();
                    btnRefer.Enabled = false;
                    txtDescription.ChangeToViewMode();
                    refersText1.LoadRefer(frmrs.ReferCode);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgrInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private DataTable GetData()
        {
            if (_DataTable == null) return null;

            DataTable dt = (new JProperties(_ConstClassName, _FormCode)).GetPropertyTableDataForPrint(_ValueObjectCode);
            if (dt.Columns.IndexOf("Code") > -1)
            {
                dt.Columns["Code"].ColumnName = "PropPertyKeyCode";
            }
            DataTable NewDataTable = JTable.Join(_DataTable, dt);

            // Add SQL Fileds To DataTable
            JDataBase db = new JDataBase();
            try
            {
                JProperties jProperties = new JProperties(_ConstClassName, _FormCode);
                DataTable Fields = jProperties.GetDataTable();
                foreach (DataRow Field in Fields.Rows)
                {
                    NewDataTable.Columns.Add("Change_" + Field["Name"].ToString().Replace(" ", "__"));
                    foreach (DataRow _NDR in NewDataTable.Rows)
                    {
                        // Add Last Changeset data
                        Globals.Property.JPropertyHistory jPropertyHistory = new JPropertyHistory();
                        DataTable changeset = jPropertyHistory.GetFiledLastChangesetDetails(_ConstClassName, _FormCode, _ValueObjectCode, JMainFrame.CurrentUserCode, Field["Name"].ToString().Replace(" ", "__"));
                        if (changeset.Rows.Count > 0)
                        {
                            Globals.JUser jUser = new Globals.JUser(Convert.ToInt32(changeset.Rows[0]["UserCode"]));
                            _NDR["Change_" + Field["Name"].ToString().Replace(" ", "__")] = jUser.Person.Fam + " " + jUser.Person.Name;
                        }
                        else
                            _NDR["Change_" + Field["Name"].ToString().Replace(" ", "__")] = "";
                    }
                    if (Field["DataType"].ToString() == JSQLDataType.اس_کیو_ال.ToString())
                    {
                        string _SQL = Field["List"].ToString();
                        db.setQuery(_SQL);
                        DataTable PropertyData = db.Query_DataTable();
                        // Add Columns To NewDataTable
                        foreach (DataColumn PropertyDataColumn in PropertyData.Columns)
                        {
                            string columnName = Field["Name"] + "_" + PropertyDataColumn.ColumnName;
                            if (NewDataTable.Columns.IndexOf(columnName) < 0)
                                NewDataTable.Columns.Add(columnName);
                        }
                        // Update new columns with PropertData
                        foreach (DataRow _NDR in NewDataTable.Rows)
                        {
                            DataRow[] _DR = null;
                            try
                            {
                                _DR = PropertyData.Select("Code = '" + _NDR[Field["Name"].ToString().Replace(" ", "__")] + "'");
                            }
                            catch
                            {
                            }
                            foreach (DataColumn PropertyDataColumn in PropertyData.Columns)
                            {

                                string columnName = Field["Name"] + "_" + PropertyDataColumn.ColumnName.Replace(" ", "__");
                                if (NewDataTable.Columns.IndexOf(columnName) < 0)
                                    NewDataTable.Columns.Add(columnName);

                                if (_DR != null && _DR.Length == 1)
                                {
                                    if (PropertyDataColumn.ColumnName.ToLower() == "title" && _DR[0][PropertyDataColumn.ColumnName].ToString().Trim() == "")
                                        _NDR[columnName] = _NDR[Field["Name"].ToString().Replace(" ", "__")];
                                    else
                                        _NDR[columnName] = _DR[0][PropertyDataColumn.ColumnName];

                                }
                                else
                                {
                                    if (PropertyDataColumn.ColumnName.ToLower() == "title")
                                        _NDR[columnName] = _NDR[Field["Name"].ToString().Replace(" ", "__")];
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            // Add FormObject Fileds To DataTable
            JFormObjects jFormObject = new JFormObjects(_ValueObjectCode);
            NewDataTable.Columns.Add("FormObject.Date");
            NewDataTable.Columns.Add("FormObject.Description");
            //NewDataTable.Rows[0]["FormObject.Date"] = JDateTime.FarsiDate(jFormObject.Date);
            //NewDataTable.Rows[0]["FormObject.Description"] = jFormObject.Description;

            for (int i = 0; i < NewDataTable.Rows.Count; i++)
            {
                NewDataTable.Rows[i]["FormObject.Date"] = JDateTime.FarsiDate(jFormObject.Date);
                NewDataTable.Rows[i]["FormObject.Description"] = jFormObject.Description;
            }

            return NewDataTable;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Save();

            JDynamicReportForm jDynamicReportForm = new JDynamicReportForm(JReportDesignCodes.FormManager.GetHashCode(), _FormCode);
            if (isMultiple == false)
                jDynamicReportForm.Add(GetData());
            else
                jDynamicReportForm.Add(GetData());

            jDynamicReportForm.ShowDialog();
        }

        private void FormObjectViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //ClearEmptyFormObject();
        }

		public void NoStorageForms()
		{
		}

        private void button1_Click_1(object sender, EventArgs e)
        {
            JForms jForms = new JForms(_FormCode);
            //int pTypeCode, int pCCode, int pFinanceCode, bool pView, int pSheetCode, int pGroupCode, int pConcernCode
            JAction A = new JAction("", jForms.Action, null, new object[] { _ObjectCode });
            A.run();
        }

        private void button1_Click(object sender, EventArgs e)
		{
			if (JPermission.CheckPermission("ClassLibrary.FormObjectViewForm.NoStorageForms", _FormCode))
			{
				if (Save())
				{
					ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects(_ValueObjectCode);

					//int Year = (new System.Globalization.PersianCalendar()).GetYear(JDateTime.Now());
					//Communication.NoStorage N = new Communication.NoStorage(_ConstClassName, _FormCode , Year);

					Communication.NoStorageForm NSF = new Communication.NoStorageForm(_ConstClassName, _FormCode);
					NSF.ShowDialog();

					if (NSF.NoStorageNumber > 0)
					{
						jFormObjects.NoStorage = NSF.NoStorageNumber;
						jFormObjects.Update();

						buttonNoStorage.Text = jFormObjects.NoStorage.ToString();
						buttonNoStorage.Enabled = false;
					}
				}
			}

		}

		private void panel3_Resize(object sender, EventArgs e)
		{
			SetValueRegister(panel3.Width);
		}

    }
}
