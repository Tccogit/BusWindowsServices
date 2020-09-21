using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers
{
    public partial class JAutoTypeLabel : UserControl
    {
        private string[] _text;
        private int pos, itemIndex, count, waittick;
        private bool wait;

        public int WaitTick { get { return waittick; } set { waittick = value; } }
        public string[] TextList
        {
            get
            {
                return _text;
            }
            set
            {
                itemIndex = 0;
                pos = 0;
                wait = false;
                label1.Text = "";
                _text = value;
                timer1.Enabled = true;
            }
        }

        public string SingleText
        {
            set
            {
                string[] str = { value };
                TextList = str;
            }
            get
            {
                if (_text != null && _text.Length > 0)
                    return _text[0];
                else
                    return null;
            }
        }

        public int TimerInterval
        {
            get
            {
                return timer1.Interval;
            }
            set
            {
                try
                {
                    timer1.Interval = (int)value;
                }
                catch { }
                finally { }
            }
        }

        public JAutoTypeLabel()
        {
            InitializeComponent();
        }
        public JAutoTypeLabel(string[] _TextList)
        {
            InitializeComponent();
            TextList = TextList;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_text == null)
                {
                    timer1.Enabled = false;
                    return;
                }
                if (_text.Length == 0)
                {
                    timer1.Enabled = false;
                    return;
                }

                if (wait)
                {
                    count++;
                    if (count > waittick) wait = false;
                    return;
                }

                if (pos > _text[itemIndex].Length)
                {
                    label1.Text = _text[itemIndex];
                    itemIndex++;
                    if (itemIndex >= _text.Length)
                        if (itemIndex == 1)
                        {
                            timer1.Enabled = false;
                            return;
                        }
                        else
                            itemIndex = 0;
                    wait = true;
                    pos = 0;
                    count = 0;
                    return;
                }
                label1.Text = _text[itemIndex].Substring(0, pos) + "_";
                pos++;
            }
            catch { timer1.Enabled = false; }
            finally { }
        }

    }
}
