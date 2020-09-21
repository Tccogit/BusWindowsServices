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
    public partial class JTextInputDialogForm : JBaseForm
    {
        public string Text;
        public JTextInputDialogForm(string pLable, string pDefault)
            : this(pLable, pDefault, true)
        {
        }

        public JTextInputDialogForm(string pLable, string pDefault, bool isMultiLine)
        {
            InitializeComponent();
            lbText.Text = pLable;
            txtBox.Text = pDefault;
            Text = pDefault;
            if (isMultiLine == false)
            {
                txtBox.Multiline = false;
                this.Height = 150;
            }
        }

        private void TextInputForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            Text = txtBox.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
