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
    public partial class JLoginForm : JBaseForm
    {
        private JLogin _Login = new JLogin();
        public JLoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (_Login.Login(txtUserName.Text, txtPassword.Text))
            {
//                JMainFrame.CurrentUserCode = _Login.
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            JMainFrame.Terminated = 1;
            Application.Exit();
        }

        private void JLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JMainFrame.CurrentUserCode == 0 && JMainFrame.Terminated == 0)
                e.Cancel = true;
        }

    }
}
