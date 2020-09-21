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
    public partial class JPersonPropertiesForm : Globals.JBaseForm
    {
        public JPersonPropertiesForm()
        {
            InitializeComponent();
            propertiesRealPerson.ClassName = "ClassLibrary.JRealPerson";
            propertiesRealPerson.ObjectCode = 1;

            propertiesLegalPerson.ClassName = "ClassLibrary.JLegalPerson";
            propertiesLegalPerson.ObjectCode = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            propertiesRealPerson.AcceptChanges();
            propertiesLegalPerson.AcceptChanges();
            btnSave.Enabled = false;
        }

        private void propertiesRealPerson_AfterPropertyAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void propertiesRealPerson_AfterPropertyDeleted(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
