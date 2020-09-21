using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace ClassLibrary
{
    //[ToolboxBitmapAttribute(typeof(TextEdit),"Images.TextEdit.ico")]
    /// <summary>
    /// Text Mode
    /// </summary>
    public enum TextModes
    {
        Text, Integer, Real, EMail, Money, Long
    }
    public partial class TextEdit : TextBox
    {
        public TextEdit()
        {
            InitializeComponent();
            mainBackColor = this.BackColor;
        }

        public TextEdit(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #region Changing Colors in Enter & Leave
        private bool thisChangeColorOnEnter = true;
        private bool thisNotEmpty = false;
        private bool thisChangeColorIfNotEmpty = true;
        private bool thisSelectOnEnter = true;
        private bool thisNegative = true;
        private TextModes thisTextMode = TextModes.Text;
        //public string Text
        //{
        //    get
        //    {
        //        return this
        //    }
        //}
        #region Public Properties
        public TextModes TextMode
        {
            get
            {
                return thisTextMode;
            }
            set
            {
                thisTextMode = value;
            }
        }
        public bool Negative
        {
            get
            {
                return thisNegative;
            }
            set
            {
                thisNegative = value;
            }
        }
        public bool NotEmpty
        {
            get
            {
                return thisNotEmpty;
            }
            set
            {
                thisNotEmpty = value;
            }
        }
        public bool ChangeColorOnEnter
        {
            get
            {
                return thisChangeColorIfNotEmpty;
            }
            set
            {
                thisChangeColorIfNotEmpty = value;
            }
        }
        public bool ChangeColorIfNotEmpty
        {
            get;
            //{
            //   // return thisChangeColorOnEnter;
            //}
            set;
            //{
            //    //thisChangeColorOnEnter = value;
            //}
        }

        public bool SelectOnEnter
        {
            get
            {
                return thisSelectOnEnter;
            }
            set
            {
                thisSelectOnEnter = value;
            }
        }

        public decimal DecimalValue
        {
            get
            {
                try
                {
                    if (this.Text == "") return 0;
                    return decimal.Parse(this.Text.Replace(",",""));
                }
                catch
                {
                    //MessageBox.Show("Invalid Decimal value");
                    return 0;
                }
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
                    //MessageBox.Show("Invalid float value");
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
                    return int.Parse(this.Text.Replace(",", "").Split('.')[0]);
                }
                catch
                {
                    //MessageBox.Show("Invalid integer value");
                    return 0;
                }
            }
        }
        public long Int64Value
        {
            get
            {
                try
                {
                    if (this.Text == "") return 0;
                    return Convert.ToInt64(this.Text.Split('.')[0].Replace(",",""));
                }
                catch
                {
                    //MessageBox.Show("Invalid integer value");
                    return 0;
                }
            }
        }
        public Decimal MoneyValue
        {
            get
            {
                if (this.Text == "") return 0;
                return (Convert.ToDecimal(JMoney.RemoveMoney(this.Text)));
            }
        }

        private Color thisNotEmptyColor = Color.Red;
        public Color NotEmptyColor
        {
            get
            {
                return thisNotEmptyColor;
            }
            set
            {
                thisNotEmptyColor = value;
            }
        }

        private Color thisInForeColor = SystemColors.WindowText;
        public Color InForeColor
        {
            get
            {
                return thisInForeColor;
            }
            set
            {
                thisInForeColor = value;
            }
        }

        private Color thisInBackColor = SystemColors.Info;
        public Color InBackColor
        {
            get
            {
                return thisInBackColor;
            }
            set
            {
                thisInBackColor = value;
            }
        }
        #endregion
        Color tmpForeColor, tmpBackColor;
        private Color mainBackColor;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (thisChangeColorOnEnter)
            {
                tmpBackColor = this.BackColor;
                tmpForeColor = this.ForeColor;
                this.ForeColor = thisInForeColor;
                this.BackColor = thisInBackColor;
            }
            if (thisSelectOnEnter)
            {
                this.SelectAll();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            if (thisNotEmpty)
            {
                if (this.Text.Trim() == "")
                {
                    if (this.ChangeColorIfNotEmpty)
                        this.BackColor = thisNotEmptyColor;
                    return;
                }
                else
                {
                    tmpBackColor = mainBackColor;
                }
            }
            if (thisChangeColorOnEnter)
            {
                this.ForeColor = tmpForeColor;
                this.BackColor = tmpBackColor;
            }
            if (TextMode == TextModes.EMail)
            {
                if ((this.Text.Trim() != "") && (!this.Text.Contains('@') || !this.Text.Contains('.')))
                {
                    JMessages.Information("PleaseEnterCorrectEMailFormat", "Error");
                }
            }
            if (TextMode == TextModes.Money)
            {
                this.Text = JMoney.StringToMoney(JMoney.RemoveMoney(this.Text));
            }
            if (TextMode == TextModes.Real)
            {
                //try
                //{
                //    Convert.ToDouble(this.Text);
                //}
                //catch
                //{
                //    JMessages.Error("Real Or Integer Number Only!", "Integer Or Real");
                //    this.BackColor = Color.LightPink;
                //    this.Focus();
                //}
                //finally
                //{
                //}
            }
            if (TextMode == TextModes.Integer)
            {
                try
                {
                    if (this.Text.Trim() != "")
                        Convert.ToInt64(this.Text);
                }
                catch
                {
                    JMessages.Error("Integer Number Only!", "Integer");
                    this.BackColor = Color.LightPink;
                    this.Focus();
                }
                finally
                {
                }
            }
            if (TextMode == TextModes.Long)
            {
                try
                {
                    if (this.Text.Trim() != "")
                        Convert.ToInt64(this.Text);
                }
                catch
                {
                    JMessages.Error("Integer Number Only!", "Integer");
                    this.BackColor = Color.LightPink;
                    this.Focus();
                }
                finally
                {
                }
            }
        }

        #endregion

        bool lastSpace = false;
        private void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Number

            ////////////// Numbers
            if (thisTextMode == TextModes.Integer || thisTextMode == TextModes.Real || thisTextMode == TextModes.Money)
            {
                if (thisNegative) //////////Negative
                {
                    if (thisTextMode == TextModes.Integer || thisTextMode == TextModes.Money || thisTextMode == TextModes.Long)
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
                    else if (thisTextMode == TextModes.Real) //float
                    {
                        if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 ||
                              (e.KeyChar == 46 && !(this.Text.Contains("."))) ||
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
                }
                if (!thisNegative) //////////Positive
                {
                    if (thisTextMode == TextModes.Integer || thisTextMode == TextModes.Money)
                    {
                        if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }

                    }
                    else if (thisTextMode == TextModes.Real) //float
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
            ///////////////
            #endregion
            if (e.KeyChar == ' ')
            {
                if (lastSpace)
                {
                    e.Handled = true;
                }
                else
                    lastSpace = true;
            }
            else
                lastSpace = false;

        }

        private bool ChangingText = false;
        private void TextEdit_TextChanged(object sender, EventArgs e)
        {

            if (!ChangingText && this.TextMode == TextModes.Money)
            {
                ChangingText = true;
                this.Text = JMoney.StringToMoney(JMoney.RemoveMoney(this.Text));
            }
            //if (this.ChangeColorIfNotEmpty && this.Text.Trim() != "")
            //  this.BackColor = tmpBackColor;
        }

    }
}

