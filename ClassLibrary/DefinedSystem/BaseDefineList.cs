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
    public partial class JBaseDefineList : JBaseForm
    {
        public JSubBaseDefine SelectedItem
        {
            get;
            set;
        }
        public JBaseDefineList(JSubBaseDefines items)
        {
            InitializeComponent();
            items.SetListBox(listBox1,0);
            //foreach (JSubBaseDefine item in items)
            //{
            //    listBox1.Items.Add(item);
            //}
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}
