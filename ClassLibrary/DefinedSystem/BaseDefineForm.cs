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
    public partial class JBaseDefineForm : JBaseForm
    {
        public  JSubBaseDefine _SubBaseDefine;
        public JBaseDefineForm(JSubBaseDefine pSubBase)
        {
            InitializeComponent();
            _SubBaseDefine = pSubBase;

            JBaseDefine _base = new JBaseDefine();
            _base.GetData(_SubBaseDefine.BCode);

            Text = JLanguages._Text(_base.Name);
            NametextBox.Text = _SubBaseDefine.Name;

            if (_base.ParentCode != null)
            {
                JSubBaseDefines subs = new JSubBaseDefines(_base.ParentCode);
                subs.SetComboBox(ParentcomboBox);
                //ParentcomboBox.Items.AddRange(subs.Items);
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (NametextBox.Text.Trim() == "")
            {
                JMessages.Error("لطفا نام را وارد کنید", "خطا");
                return;
            }
            _SubBaseDefine.Name = NametextBox.Text;

            if (State == JFormState.Insert)
            {
                if (_SubBaseDefine.Insert() > 0)
                    DialogResult = DialogResult.OK;
            }
            else if (_SubBaseDefine.Update())
                    DialogResult = DialogResult.OK;
            Close();
        }

    }
}
