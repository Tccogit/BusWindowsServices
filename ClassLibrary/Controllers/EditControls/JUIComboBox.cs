using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JUIComboBox : Janus.Windows.EditControls.UIComboBox
    {
        public JUIComboBox()
        {
            InitializeComponent();
        }

        void JUIComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                (new ClassLibrary.Controllers.EditControls.JComboboxSearchForm(this)).ShowDialog();
        }

    }
}
