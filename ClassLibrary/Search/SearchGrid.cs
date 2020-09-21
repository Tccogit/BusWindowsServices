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
    public partial class JSearchGrid : UserControl
    {
        public JAction Action;
        public ListView SearchListView { get; set; }
        public JListViewsNodes Nodes;

        public string[] Properties = new string[0];

        public JSearchGrid()
        {
            InitializeComponent();
        }

        public int AddParams(string pName)
        {
            Array.Resize(ref Properties, Properties.Length+1);
            Properties[Properties.Length-1] = pName;
            return Properties.Length - 1;
        }

        private void Refresh()
        {
        }

        public void Clear()
        {
            Array.Resize(ref Properties, 0);
            Refresh();
        }

        public bool DelParam(string pName)
        {
            return false;
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {

        }

        private void Freebutton_Click(object sender, EventArgs e)
        {
        }
         
    }
}
