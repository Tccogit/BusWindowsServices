using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Zone
{
    public partial class JZoneForm : ClassLibrary.JBaseForm
    {   private int Code;
        public JZoneForm()
        {
            
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
        }

        public JZoneForm(int PCode)
        {
            Code = PCode;
            InitializeComponent();
            Load1(PCode);
            State = ClassLibrary.JFormState.Update;

        }

      

        private void Load1(int PCode)
        {
            JZone objZone = new JZone();
            objZone.GetData(PCode);
            txtAdress.Text = objZone.Address;
            txtDisc.Text = objZone.Description;
            txtName.Text = objZone.Name;
            txtTel.Text = objZone.Tel;
           
        }

        private void SetData(JZone Zone)
        {
            Zone.Code = Code;
            Zone.Address = txtAdress.Text.Trim();
            Zone.Description = txtDisc.Text.Trim();
            Zone.Name = txtName.Text.Trim();
            Zone.Tel = txtTel.Text.Trim();
        }
        private int Save()
        {
            JZone objAutoDefine = new JZone();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;
            ClassLibrary.JSystem.Nodes.RefreshDataTable();
            return Code;
        }


        private bool Validation()
        {
            bool result = true;
            string message = "فیلد ({0}) مورد نیاز است";
            if (txtName.Text.Trim() == string.Empty)
            {
                result = false;
                ClassLibrary.JMessages.Error(string.Format(message, ClassLibrary.JLanguages._Text(lblName.Text.Split(':')[0])), "اخطار!");
                txtName.Focus();
            }

            if (result && txtAdress.Text.Trim() == string.Empty)
            {
                result = false;
                ClassLibrary.JMessages.Error(string.Format(message, ClassLibrary.JLanguages._Text(lblAddress.Text.Split(':')[0])), "اخطار!");
                txtAdress.Focus();
            }

            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Save();
                Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validation())
                Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
