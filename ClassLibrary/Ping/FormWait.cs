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
    public partial class JFormWait : JBaseForm
    {
        public static int Status = 0;
        public JFormWait()
        {
            InitializeComponent();
            if (this.DesignMode)
            {
                Status = 2;
            }
            else
                if (Status == 2)
                    Status = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status = 1;
            Application.Exit();
            Application.ExitThread();
        }
    }
}
