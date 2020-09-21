using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassLibrary
{
    public partial class DateEdit : System.Windows.Forms.MaskedTextBox
    {
        //Propperty
        #region Property
        private bool _InsertInDatesTable = true;
        /// <summary>
        /// در صورتی که صحیح باشد تاریخ وارد شده در جدول تاریخ ها ثبت میشود
        /// </summary>
        public bool InsertInDatesTable
        {
            get
            {
                return _InsertInDatesTable;
            }
            set
            {
                _InsertInDatesTable = value;
            }
        }
        #endregion Property

        #region Year & Month & Day
        /// <summary>
        ///  سال وارد  شده
        /// </summary>
        public int Year
        {
            get
            {
                try
                {
                    return (int.Parse(this.Text.Replace('-','/').Split('/')[0]));
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
        public int Month
        {
            get
            {
                try
                {
					return (int.Parse(this.Text.Split('-', '/')[1]));

                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// روز وارد شده
        /// </summary>
        public int Day
        {
            get
            {
                try
                {
                    return (int.Parse(this.Text.Replace('-', '/').Split('/')[2]));

                }
                catch
                {
                    return 0;
                }
            }
        }
        #endregion

        #region Constructor
        public Color mainBackColor;
        public DateEdit()
        {
            InitializeComponent();
            mainBackColor = this.BackColor;
            this.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //if (!this.DesignMode)
              //  _InitDate();
        }

        public DateEdit(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            //try
            //{
            //    System.Globalization.CultureInfo x = new System.Globalization.CultureInfo("fa-IR");
            //    x.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            //    x.DateTimeFormat.FullDateTimePattern = "MMMM dd, yyyy HH:mm:ss";
            //    this.Culture = x;
            //}
            //catch (Exception ex)
            //{
            //    JMessages.Error(ex.Message, "");
            //}
            this.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //if (!this.DesignMode)
              //  _InitDate();
        }
        /// <summary>
        /// تاریخی وارد نشده است
        /// </summary>
        public bool EmptyDate
        {
            get
            {
                if (this.Text == "    /  /")
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
            if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.English)
                this.Text = DateTime.Now.ToString("yyyy/MM/dd");
            else if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.Farsi)
                this.Text = JDateTime.FarsiDate(DateTime.Now);
        }
        #endregion

        /// <summary>
        /// تاریخ مربوط به متن وارد شده
        /// </summary>
        public DateTime Date
        {
            set
            {
                Text = JDateTime.FarsiDate(value);
            }
            get
            {
                try
                {
                    if (this.EmptyDate)
                        return DateTime.MinValue;
                    if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.English)
                        return Convert.ToDateTime(this.Text);
                    if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.Farsi)
                        return JDateTime.GregorianDate(this.Text);
                    return DateTime.MinValue;
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public string StringDate
        {
            get
            {
                return JDateTime.GregorianDate(this.Text).ToString("yyyy/MM/dd");
            }
        }

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
        /// <summary>
        /// بررسی معتبر بودن تاریخ وارد شده
        /// </summary>
        /// <returns></returns>
        public bool IsValidDate()
        {
            if (Year > 9999 || Month > 12 || Day > 31)
                return false;
            if (Year == 0 || Month == 0 || Day == 0)
                return false;
            if (Date == DateTime.MinValue)
                return false;
            return true;
        }
        
        private void DateEdit_Leave(object sender, EventArgs e)
        {
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
                System.Windows.Forms.MessageBox.Show(JLanguages._Text("Invalid Date Value"));
                this.Focus();
                return;
            }
            #endregion Check Value

            #region Insert in StaticDates Table
            if (InsertInDatesTable)
            {
                JStaticDate stDate = new JStaticDate();
                stDate.En_Date = Date;
                stDate.Insert();
            }
            #endregion Insert in StaticDates Table
        }

        Color tmpForeColor, tmpBackColor;
        private void DateEdit_Enter(object sender, EventArgs e)
        {
            ReadOnly = false;
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Focus();
            this.SelectAll();
            if (thisChangeColorOnEnter)
            {
                tmpBackColor = this.BackColor; ;
                tmpForeColor = this.ForeColor;
                this.ForeColor = thisInForeColor;
                this.BackColor = thisInBackColor;
            }            
        }

		private void DateEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.U)
				this.Date = DateTime.Now;
		}
    }
}
