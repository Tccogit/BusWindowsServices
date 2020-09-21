using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using AUTOMOBILE.AutomobileDefine;

namespace BusManagment.Bus
{
    public partial class JBusForm :ClassLibrary.JBaseForm
    {
        private int _Code;
        private int _AutomobileCode;
        private ArchivedDocuments.JArchiveList jArchiveList1;

        public JBusForm()
        {
            InitializeComponent();
            SetDefault();
            State = ClassLibrary.JFormState.Insert;
            LoadProperties();
        }
        public JBusForm(int PCode)
        {
            InitializeComponent();
            _Code = PCode;
            SetDefault();
            LoadData(PCode);
            this.State = ClassLibrary.JFormState.Update;
            LoadProperties();
        }
        private void LoadProperties()
        {
            // Configuring PropertyControl
            jPropertyValue.ClassName = "BusManagment.JBus";
            jPropertyValue.ObjectCode = 1;
            jPropertyValue.ValueObjectCode = _Code;
        }

        private void SetDefault()
        {
            jArchiveList1 = new ArchivedDocuments.JArchiveList();
            tabPage2.Controls.Add(jArchiveList1);
            jArchiveList1.Dock = DockStyle.Fill;
            jArchiveList1.ClassName = "BusManagment.Bus.JBus";

            cmbFleet.DataSource = Fleet.JFleets.GetDataTable(0);
            cmbFleet.DisplayMember = "Name";
            cmbFleet.ValueMember = "Code";

            grdOwners.DataSource = JBusOwners.GetDataTable(_Code);
            grdDevice.DataSource = JBusDevices.GetDataTable(_Code);

        }

        private void LoadData(int PCode) {
            JBus Bus = new JBus();
            Bus.GetData(PCode);
            txtBCode.Text = Bus.BUSNumber.ToString();
            cmbFleet.SelectedValue = Bus.FleetCode;
            checkedActive.Checked = Bus.Active;
            _AutomobileCode = Bus.CarCode;
            
            SetPelaq();
            jArchiveList1.ObjectCode = PCode; 
        }

        private void SetData(JBus Auto)
        {
            Auto.Code = this._Code;
            Auto.Active = checkedActive.Checked;
            Auto.BUSNumber = Convert.ToDouble(txtBCode.Text);
            Auto.CarCode = _AutomobileCode;
            Auto.FleetCode = (int)cmbFleet.SelectedValue;
        }

        bool Validate()
        {
            if (_AutomobileCode == 0)
            {
                JMessages.Error("لطفاً وسیله نقلیه را انتخاب کنید.", "خطا");
                tabControl1.SelectedIndex = 0;
                return false;
            }
            if(txtBCode.Text.Trim() == "")
            {
                JMessages.Error("لطفاً شماره اتوبوس را وارد کنید.", "خطا");
                tabControl1.SelectedIndex = 0;
                return false;
            }
            if (JBuses.CheckExists(_Code, txtBCode.IntValue))
            {
                JMessages.Error("این شماره اتوبوس قبلا وارد شده است.", "خطا");
                tabControl1.SelectedIndex = 0;
                return false; 
            }
            return true;
        }
        private bool Save()
        {
            bool result = false;
            if (!Validate())
                return false;
            JBus objAutoDefine = new JBus();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
            {
                _Code = objAutoDefine.Insert();
                result = _Code > 0;
                if (result)
                {
                    State = ClassLibrary.JFormState.Update;
                }
            }
            else
                if (State == ClassLibrary.JFormState.Update)
                    result = objAutoDefine.Update();

            if (jArchiveList1.ObjectCode == 0)
            {
                jArchiveList1.ObjectCode = _Code;
            }
           
            jArchiveList1.ArchiveList();
            if (result)
            {
                jPropertyValue.ValueObjectCode = _Code;
                jPropertyValue.Save();
            }
            return result ;
        }

        int _ownerCode = 0;
        /// <summary>
        /// ذخیره مالک
        /// </summary>
        /// <returns></returns>
        private bool SaveOwner()
        {
            bool result = false;
            if (txtPerson.Tag == null || (int)txtPerson.Tag == 0)
            {
                JMessages.Error("لطفا شخص را انتخاب کنید", "خطا");
                return false;
            }
            if (txtOwStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ شروع را وارد کنید", "خطا");
                return false;
            }
            if (txtOwEndDate.Date != DateTime.MinValue && txtOwStartDate.Date > txtOwEndDate.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            if (chActive.Checked)
            {
                if (!JBusOwners.CheckHasOneActiveOwner(_Code))
                {
                    JMessages.Error("اتوبوس باید فقط دارای یک  مالک فعال باشد.", "خطا");
                    return false;
                }
            }
            JBusOwner owner = new JBusOwner(_ownerCode);
            owner.CodePerson = (int)txtPerson.Tag;
            owner.StartDate = txtOwStartDate.Date;
            owner.EndDate = txtOwEndDate.Date;
            owner.IsActive = chActive.Checked;
            owner.BusCode = _Code;
            if (_ownerCode == 0)
            {
                result = owner.Insert() > 0;
            }
            else
            {
                result = owner.Update();
            }
            if (result) LoadOwners();
            btnAddOwner.Text = ClassLibrary.JLanguages._Text("Add");
            _ownerCode = 0;
            return result;
        }
        private void LoadOwners()
        {
            grdOwners.DataSource = JBusOwners.GetDataTable(_Code);
        }
        private void LoadDevice()
        {
            grdDevice.DataSource = JBusDevices.GetDataTable(_Code);
        }
        //private void SaveDevice()
        //{
        //    DataTable DT = (DataTable)jJanusGridDevice.DataSource;
        //    if (DT != null)
        //    {
        //        for (int i = 0; i < DT.Rows.Count; i++)
        //        {
        //            DataRow DR = DT.Rows[i];
        //            JBusDeviseTable BusDeviseTable = new JBusDeviseTable();
        //            if (DR.RowState == DataRowState.Added)
        //            {
        //                JOwnerTable.SetToClassField(BusDeviseTable, DR);
        //                DR["Code"] = BusDeviseTable.Insert();
        //            }
        //            else
        //                if (DR.RowState == DataRowState.Deleted)
        //                {
        //                    DR.RejectChanges();
        //                    JOwnerTable.SetToClassField(BusDeviseTable, DR);
        //                    BusDeviseTable.Delete();
        //                    DR.Delete();
        //                }
        //                else
        //                    if (DR.RowState == DataRowState.Modified)
        //                    {
        //                        JOwnerTable.SetToClassField(BusDeviseTable, DR);
        //                        BusDeviseTable.Update();
        //                    }

        //            DR.AcceptChanges();
        //        }
        //    }
        //}

        private bool SaveDevice()
        {
            bool result = false;
            if (txtBusDevise.Tag == null || (int)txtBusDevise.Tag == 0)
            {
                JMessages.Error("لطفا دستگاه را انتخاب کنید", "خطا");
                return false;
            }
            if (txtStartDateDevise.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ شروع را وارد کنید", "خطا");
                return false;
            }
            if (txtEndDateDevise.Date != DateTime.MinValue && txtStartDateDevise.Date > txtEndDateDevise.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            JBusDevise device = new JBusDevise(_deviceCode);
            device.DeviceCode = (int)txtBusDevise.Tag;
            device.Installer= (int)txtInstaller.Tag;
            device.StartDate = txtStartDateDevise.Date;
            device.EndDate = txtEndDateDevise.Date;
            device.BusCode = _Code;
            if (_deviceCode == 0)
            {
                result = device.Insert() > 0;
            }
            else
            {
                result = device.Update();
            }
            if (result) 
                LoadDevice();
            btnAddDevice.Text = ClassLibrary.JLanguages._Text("Add");
            _deviceCode = 0;
            return result;
        }

        private void BusForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetPelaq()
        {
            JAutomobileDefine Auto = new JAutomobileDefine();
            Auto.GetData(_AutomobileCode);
            if (Auto.Code > 0)
            {
                txtPlak1.Text = Auto.Plaque.Substring(0, 2);
                cmbPlak.Text = Auto.Plaque.Substring(2, 1);
                txtPlak2.Text = Auto.Plaque.Substring(3, 3);
                txtPlak3.Text = Auto.Plaque.Substring(7, 2);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JAutomobileSearch AS = new  JAutomobileSearch();
            if (AS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _AutomobileCode = AS.SelectedCode;
                SetPelaq();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson != null)
            {

                txtPerson.Text = FindP.SelectedPerson.Name;
                txtPerson.Tag = FindP.SelectedPersonCode;
            }
        } 

        private void btnActiveOw_Click(object sender, EventArgs e)
        {
            if (grdOwners.SelectedRow != null)
            {
                _ownerCode = Convert.ToInt32(grdOwners.SelectedRow["Code"]);
                txtPerson.Text = grdOwners.SelectedRow["Name"].ToString();
                JBusOwner owner = new JBusOwner(_ownerCode);
                txtPerson.Tag = owner.CodePerson;
                txtOwStartDate.Date = owner.StartDate;
                txtOwEndDate.Date = owner.StartDate;
                chActive.Checked = owner.IsActive;
                btnAddOwner.Text = ClassLibrary.JLanguages._Text("Save...");
            }
        }

        private void btnDeActiveOw_Click(object sender, EventArgs e)
        {
            if (grdOwners.SelectedRow != null)
            {
                if (JMessages.Question("آیا می خواهید مالک انتخاب شده حذف شود؟", "حذف؟") == System.Windows.Forms.DialogResult.Yes)
                {
                    _ownerCode = Convert.ToInt32(grdOwners.SelectedRow["Code"]);
                    JBusOwner owner = new JBusOwner(_ownerCode);
                    if (owner.Delete())
                        LoadOwners();
                    _ownerCode = 0;
                }
            }
            //if (grdOwners.SelectedRow!=null)
            //{
            //    grdOwners.SelectedRow.Delete();
            //}
        }

        private void jJanusGridOwner_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AUTOMOBILE.Device.JDeviceSearch DeviceSerach = new AUTOMOBILE.Device.JDeviceSearch();
            if (DeviceSerach.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBusDevise.Text = DeviceSerach.ID.ToString();
                txtBusDevise.Tag = DeviceSerach.SelectedCode;
            }
        }
 
        int _deviceCode = 0;
        private void btnActiveDev_Click(object sender, EventArgs e)
        {
            if (grdDevice.SelectedRow != null)
            {
                _deviceCode = Convert.ToInt32(grdDevice.SelectedRow["Code"]);
                txtBusDevise.Text = grdDevice.SelectedRow["DeviceID"].ToString();
                txtInstaller.Text = grdDevice.SelectedRow["InstallerName"].ToString();
                JBusDevise device = new JBusDevise(_deviceCode);
                txtBusDevise.Tag = device.DeviceCode;
                txtInstaller.Tag = device.Installer;
                txtStartDateDevise.Date = device.StartDate;
                txtEndDateDevise.Date = device.EndDate;
                btnAddDevice.Text = ClassLibrary.JLanguages._Text("Save...");
            }
            
        }

        private void btnDevActiveDev_Click(object sender, EventArgs e)
        {
            if (grdDevice.SelectedRow != null)
            {
                if (JMessages.Question("آیا می خواهید باجه دار انتخاب شده حذف شود؟", "حذف؟") == System.Windows.Forms.DialogResult.Yes)
                {
                    _deviceCode = Convert.ToInt32(grdDevice.SelectedRow["Code"]);
                    JBusDevise device = new JBusDevise(_deviceCode);
                    if (device.Delete())
                        LoadDevice();
                    _deviceCode = 0;
                }
            } 
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (SaveOwner())
                {
                    txtPerson.Tag = 0;
                    txtPerson.Text = "";
                    txtOwStartDate.Text = "";
                    txtOwEndDate.Text = "";
                }
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }

        private void grdOwners_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            btnEditOwner.PerformClick();
        }

        private void grdDevice_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            btnEditDevice.PerformClick();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (SaveDevice())
                {
                    txtBusDevise.Tag = 0;
                    txtBusDevise.Text = "";
                    txtInstaller.Tag = 0;
                    txtInstaller.Text = "";
                    txtStartDateDevise.Text = "";
                    txtEndDateDevise.Text = "";
                }
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }

        private void btnAddInstaller_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson != null)
            {

                txtInstaller.Text = FindP.SelectedPerson.Name;
                txtInstaller.Tag = FindP.SelectedPersonCode;
            }
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            Globals.Property.JDefinePropertyForm DefinePropertyForm = new Globals.Property.JDefinePropertyForm("BusManagment.JBus", 1);
            DefinePropertyForm.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
