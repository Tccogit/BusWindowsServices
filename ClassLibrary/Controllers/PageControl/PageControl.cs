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
    public partial class PageControl : UserControl
    {
        private bool ManualComboChange = true;
        private int _PageCount;
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
            set
            {
                if (_PageCount != value)
                {
                    _PageCount = value;
                    ManualComboChange = false;
                    comboBox1.SelectedIndex = _PageCount;
                    ManualComboChange = true;
                }
            }
        }
        public PageControl()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            if (JSystem.Nodes.DataTable == null)
                return;
            ManualComboChange = false;            
            comboBox1.Items.Clear();

            int Len = JSystem.Nodes.DataTable.DefaultView.Count;
            int PageCount = JSystem.Nodes.PageCount;

            for (int i = 0; i < Len; )
            {
                int Temp = PageCount;
                if (i + PageCount > Len)
                {
                    Temp = Len - i;
                }
                comboBox1.Items.Add((i + 1).ToString() + "-->" + (i + Temp).ToString());
                i = i + PageCount;
            }
            comboBox1.Items.Add("Show ALL");
            ManualComboChange = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JSystem.Nodes.LastPage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JSystem.Nodes.NextPage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JSystem.Nodes.BackPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JSystem.Nodes.FirstPage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ManualComboChange) return;
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                JSystem.Nodes.PageShowAll = true;
            }
            else
            {
                JSystem.Nodes.PageShowAll = false;
                JSystem.Nodes.PageNumber = comboBox1.SelectedIndex;
            }
        }
    }
}
