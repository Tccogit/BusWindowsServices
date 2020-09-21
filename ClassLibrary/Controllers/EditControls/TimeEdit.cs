using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassLibrary
{
    public partial class TimeEdit : System.Windows.Forms.MaskedTextBox
    {

        #region EditBox Properties
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
        private bool thisChangeColorIfNotEmpty = true;
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
        private bool thisChangeColorOnEnter = true;
        public bool ChangeColorIfNotEmpty
        {
            get
            {
                return thisChangeColorOnEnter;
            }
            set
            {
                thisChangeColorOnEnter = value;
            }
        }
        private bool thisNotEmpty = false;
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

        #region Constructor
        public Color mainBackColor;
        public TimeEdit()
        {
            InitializeComponent();
            mainBackColor = this.BackColor;
            this.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
        }

        public TimeEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// تاریخی وارد نشده است
        /// </summary>
        public bool EmptyDate
        {
            get
            {
                if (this.Text == "  :")
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// مقدار دهی اولیه
        /// </summary>
        private void _InitDate()
        {
            //if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.English)
                this.Text = DateTime.Now.ToShortTimeString();
            //else if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.Farsi)
            //    this.Text = JDateTime.FarsiDate(DateTime.Now);
        }
        #endregion

        /// <summary>
        ///  سال وارد  شده
        /// </summary>
        public int Hours
        {
            get
            {
                try
                {
                    return (int.Parse(this.Text.Split(':')[0]));
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// ماه وارد شده
        /// </summary>
        public int Minute
        {
            get
            {
                try
                {
                    return (int.Parse(this.Text.Split(':')[1]));

                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// بررسی معتبر بودن تاریخ وارد شده
        /// </summary>
        /// <returns></returns>
        public bool IsValidDate()
        {
            if (Hours > 24 || Minute > 60)
                return false;
            //if (Hours == 0 && Minute == 0)
            //    return false;
            //if (Date == DateTime.MinValue)
            //    return false;
            return true;
        }

        Color tmpForeColor, tmpBackColor;

        private void TimeEdit_Leave(object sender, EventArgs e)
        {
            if ((Hours == 0) && (Minute != 0))
                Text = "00" + Text;
            if ((Hours != 0) &&(Minute == 0))
                Text = Text + ":00";

            #region Check Value
            if (thisNotEmpty)
            {
                if (EmptyDate)
                {
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

            if (EmptyDate)
                return;
            if (!IsValidDate())
            {
                System.Windows.Forms.MessageBox.Show(JLanguages._Text("Invalid Time Value"));
                this.Focus();
                return;
            }
            #endregion Check Value
        }

        private void TimeEdit_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
}
