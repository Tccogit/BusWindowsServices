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
    public partial class jChangePersonCodeForm : JBaseForm
    {
        public jChangePersonCodeForm(int pOldCode, int pNewCode)
        {
            if (!JPermission.CheckPermission("ClassLibrary.jChangePersonCodeForm"))
            {
                Close();
                return;
            }
            InitializeComponent();
            if (pOldCode > 0)
                OldjucPerson.SelectedCode = pOldCode;
            if (pNewCode > 0)
                NewjucPerson.SelectedCode = pNewCode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JPersonChange PC = new JPersonChange();
            if (PC.Changes(OldjucPerson.SelectedCode, NewjucPerson.SelectedCode))
            {
                if (checkBoxRev.Checked)
                {
                    JPerson person = new JPerson(Convert.ToInt32(NewjucPerson.SelectedCode));
                    person.Code = Convert.ToInt32(OldjucPerson.SelectedCode);
                    person.insert(true);
                    PC.UpdateTables(NewjucPerson.SelectedCode, OldjucPerson.SelectedCode, null);
                    person.Delete(Convert.ToInt32(NewjucPerson.SelectedCode));
                }
                JMessages.Confirm("با موفقیت انجام شد", "موفق");
            }
            else
            {
                JMessages.Confirm("شکست در انجام انتقال", "شکست");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
