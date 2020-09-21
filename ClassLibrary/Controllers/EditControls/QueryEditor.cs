using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers.EditControls
{
    public partial class JQueryEditor : RichTextBox
    {
        public List<String> Words = new List<String>();
        public List<String> Syntaxes = new List<String>();
        public List<String[]> Quotations = new List<String[]>();
        public System.Drawing.Color WordsColor = Color.DarkGreen;
        public System.Drawing.Color SyntaxColor = Color.Blue;
        public System.Drawing.Color QuotationColor = Color.DarkRed;

        private bool _isSQL = true;
        public bool isSQL
        {
            get
            {
                return _isSQL;
            }
            set
            {
                _isSQL = value;
            }
        }

        public JQueryEditor()
        {
            InitializeComponent();
            if (isSQL) CustomizeForSQL();
        }

        private void CustomizeForSQL()
        {
            Quotations.Add(new string[] { "'", "'" });
            //Quotations.Add(new string[] { "[", "]" });

            Syntaxes.Add("SELECT");
            Syntaxes.Add("INSERT");
            Syntaxes.Add("DELETE");
            Syntaxes.Add("UPDATE");
            Syntaxes.Add("INNER");
            Syntaxes.Add("JOIN");
            Syntaxes.Add("LEFT");
            Syntaxes.Add("RIGHT");
            Syntaxes.Add("WHERE");
            Syntaxes.Add("ORDER BY");
            Syntaxes.Add("GROUP BY");
            Syntaxes.Add("FROM");
            Syntaxes.Add("ON");

        }

        void JQueryEditor_TextChanged(object sender, System.EventArgs e)
        {
            int startIndex = this.SelectionStart;
            this.SelectAll();
            this.SelectionColor = Color.Black;
            this.SelectionStart = startIndex;
            this.SelectionLength = 0;
            HighlightText(this, Syntaxes, SyntaxColor);
            HighlightText(this, Words, WordsColor);
            foreach (string[] item in Quotations)
            {
                HighlightQuote(this, QuotationColor, item[0], item[1]);
            }
        }
        private void HighlightText(RichTextBox rtb, List<String> list, Color color)
        {
            int startIndex = rtb.SelectionStart;
            foreach (string word in list)
            {
                int i = 0;
                i = rtb.Find(word, i, rtb.Text.Length, RichTextBoxFinds.WholeWord | RichTextBoxFinds.NoHighlight);

                while (i != -1)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = word.Length;
                    rtb.SelectionColor = color;
                    i = rtb.Find(word, i + 1, rtb.Text.Length, RichTextBoxFinds.WholeWord | RichTextBoxFinds.NoHighlight);
                }
            }
            rtb.SelectionStart = startIndex;
            rtb.SelectionLength = 0;
        }
        private void HighlightQuote(RichTextBox rtb, Color color, string QuoteStringStart, string QuoteStringEnd)
        {
            int startIndex = rtb.SelectionStart;
            int start = -1;
            bool isFind = false;
            while (rtb.Find(QuoteStringStart, start + 1, rtb.Text.Length, RichTextBoxFinds.None | RichTextBoxFinds.NoHighlight) >= 0)
            {
                int i = rtb.Find(QuoteStringEnd, start + 1, rtb.Text.Length, RichTextBoxFinds.None | RichTextBoxFinds.NoHighlight);
                if (i == start || i < start) break;
                if (i >= 0)
                    if (isFind)
                    {
                        rtb.SelectionStart = start;
                        rtb.SelectionLength = i - start + 1;
                        rtb.SelectionColor = color;
                        start = i;
                        isFind = false;
                    }
                    else
                    {
                        start = i;
                        isFind = true;
                    }
            }
            if (isFind)
            {
                rtb.SelectionStart = start;
                rtb.SelectionLength = rtb.Text.Length - start + 1;
                rtb.SelectionColor = color;
                isFind = false;
            }

            rtb.SelectionStart = startIndex;
            rtb.SelectionLength = 0;
        }

    }
}
