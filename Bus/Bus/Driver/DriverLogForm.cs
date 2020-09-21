using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Driver
{
    public partial class DriverLogForm :ClassLibrary.JBaseForm
    {
        private int Code;
        public DriverLogForm()
        {
            InitializeComponent();
            SetDefault();
            State = ClassLibrary.JFormState.Insert;
        }
        public DriverLogForm(int PCode)
        {
            InitializeComponent();
            Code = PCode;
            SetDefault();
            Load1(Code);
            this.State = ClassLibrary.JFormState.Update;
            
        }
        private void Load1(int PCode) {
            JDriverLog objDriveLog = new JDriverLog();
            objDriveLog.GetData(PCode);
            txtEventDate.Text = objDriveLog.EventDate.ToString();
            JcmbLogType.Text = objDriveLog.LogType.ToString();
        }
        private void SetData(JDriverLog Auto)
        {
            Auto.Code = Code;
            Auto.EventDate = DateTime.Parse(txtEventDate.Text);
           Auto.LogType = (int)JcmbLogType.SelectedValue;
           
        }

        private void _setCmbType()
        {
            JcmbLogType.Items.Clear();
            JDriverLogType[] e = (JDriverLogType[])(Enum.GetValues(typeof(JDriverLogType)));
            for (int i = 0; i < e.Length; i++)
            {
                JcmbLogType.Items.Add(e[i].ToString().Replace("_", " "));
            }
        }

        private void SetDefault()
        {
            _setCmbType();
        }


        private int Save()
        {
            JDriverLog objAutoDefine = new JDriverLog();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;
            return Code;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
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
    }
}
