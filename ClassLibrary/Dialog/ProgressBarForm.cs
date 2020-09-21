using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Dialog
{
    public partial class ProgressBarForm : JBaseForm
    {
        private int Max;
        private int Min;
        private string Label;
        private string Massage;
        private int Value;

        public ProgressBarForm(int pMin,int pMax, string pLabel)
        {
            InitializeComponent();
            Min = pMin;
            Max = pMax;
            Label = pLabel;
        }

        public void Start()
        {
            ShowDialog();
        }



    }
}
