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
    public partial class NumEdit : TextEdit
    {
        public NumEdit()
        {
            InitializeComponent();
        }        

        #region Specify type of TextBox (Negative, Float, Integer)
        
        public enum NumTypes { Integer, Float };
        private NumTypes thisType = NumTypes.Integer;
        private bool thisNegative = true;
        
        public bool Negative
        {
            get
            {
               // if (this.IntValue<0) return true;
                //else
                    return thisNegative;
            }
            set
            {
                thisNegative = value;
            }
        }
        public double FloatValue
        {
            get
            {
                try
                {
                    if (this.Text == "") return 0;
                    return double.Parse(this.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid float value");
                    return 0;
                }
            }
        }
        public int IntValue
        {
            get
            {
                try
                {
                    if (this.Text == "") return 0;
                    return int.Parse(this.Text.Split('.')[0]);
                }
                catch
                {
                    MessageBox.Show("Invalid integer value");
                    return 0;
                }
            }

        }

        public NumTypes NumType
        {
            get
            { 
                return thisType; 
            }
            set
            {
                thisType = value;
            }
        }
        #endregion

        #region Control KeyPressing
        //private bool thisExitOnPressEnter;
        //public bool ExitOnPressEnter
        //{
        //    get
        //    {
        //        return thisExitOnPressEnter;
        //    }
        //    set
        //    {
        //        thisExitOnPressEnter = value;
        //    }
        //}
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    if (thisExitOnPressEnter)
            //    {
            //        MessageBox.Show(this.SelectNextControl(this as Control, true, true, true, true).ToString());
            //        e.Handled = true;
            //    }
            //}
            if (thisNegative) //////////Negative
            {
                if (thisType==NumTypes.Integer)
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 ||
                       (e.KeyChar == 45 && this.SelectionStart == 0 && !(this.Text.Contains('-'))))
                    {
                        if (this.SelectionStart == 0 && (this.Text.Contains('-')))
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else if (thisType==NumTypes.Float) //float
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 ||
                          (e.KeyChar == 46 && !(this.Text.Contains("."))) ||
                        (e.KeyChar == 45 && this.SelectionStart == 0 &&  !(this.Text.Contains('-'))))
                    {
                        if (this.SelectionStart == 0 && (this.Text.Contains('-')))
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            if (!thisNegative) //////////Positive
            {
                if (thisType == NumTypes.Integer)
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 )
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }

                }
                else if (thisType == NumTypes.Float) //float
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 ||
                          (e.KeyChar == 46 && !((sender as TextBox).Text.Contains("."))))
                        
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }

        }

        #endregion
    }
}
