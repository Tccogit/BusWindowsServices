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
    public partial class JGroupSMSSQLFrom : JBaseForm
    {
        public JGroupSMSSQLFrom()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue == null)
            {
                JMessages.Error("", "");
                return;
            }

            JGroupSMSSQL tmpGroupSMSSQL = new JGroupSMSSQL();
            tmpGroupSMSSQL.GetData((int)cmbGroup.SelectedValue);            
            tmpGroupSMSSQL.GroupCode = (int)cmbGroup.SelectedValue;
            tmpGroupSMSSQL.SQL = txtSQL.Text;
            if (tmpGroupSMSSQL.Code > 0)
            {
                if (tmpGroupSMSSQL.update())
                    JMessages.Message(" با موفقیت انجام شد ", "", JMessageType.Information);
                else

                    JMessages.Message(" خطا ", "", JMessageType.Error);
            }
            else
            {
                if (tmpGroupSMSSQL.Insert() > 0)
                    JMessages.Message(" با موفقیت انجام شد ", "", JMessageType.Information);
                else

                    JMessages.Message(" خطا ", "", JMessageType.Error);
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbGroup.SelectedValue != null)&& (Convert.ToInt32(((System.Data.DataRowView)(cmbGroup.SelectedItem)).Row.ItemArray[0]) != -1))
            {
                JGroupSMSSQL tmpGroupSMSSQL = new JGroupSMSSQL(Convert.ToInt32((cmbGroup.SelectedValue)));
                txtSQL.Text = tmpGroupSMSSQL.SQL;
            }
        }

        private void JGroupSMSSQLFrom_Load(object sender, EventArgs e)
        {
            JGroupSMSs JCCs = new JGroupSMSs();
            JCCs.SetComboBox(cmbGroup, 0);
        }
    }
}
