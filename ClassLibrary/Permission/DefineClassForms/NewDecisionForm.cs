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
    public partial class JPermissionDecisionForm : Globals.JBaseForm
    {
        public JPermissionDecision Decision
        {
            get
            {
                return _Decision;
            }
        }
        public  JPermissionDecision _Decision;
        public JPermissionDecisionForm()
        {
            InitializeComponent();
        }

        public JPermissionDecisionForm(JPermissionDecision pDecision)
        {
            InitializeComponent();
            _Decision = pDecision;
            txtDecision.Text = _Decision.Name;
            txtClassName.Text = _Decision.ClassName;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _Decision.Name = txtDecision.Text;
            DialogResult = DialogResult.OK;
        }

        private void JPermissionDecisionForm_Load(object sender, EventArgs e)
        {

        }

    }
}