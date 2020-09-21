using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinForms.Documents.FormatProviders.Xaml;
using Telerik.WinForms.Documents.Model.Styles;
using Telerik.WinForms.Documents.Model;
using System.Diagnostics;

namespace ClassLibrary.Controllers.Editor
{
    public partial class JEditorTelerik : UserControl
    {
        public JEditorTelerik()
        {
            InitializeComponent();
            StyleDefinition style = this.radRichTextEditor1.Document.Style;
            double? leftIndent = (double?)style.GetPropertyValue(Paragraph.LeftIndentProperty);
            style.SetPropertyValue(Span.FontFamilyProperty, new Telerik.WinControls.RichTextEditor.UI.FontFamily("B Roya"));
        }


        public void ChangeToViewMode()
        {
            radRichTextEditor1.IsReadOnly = true;
            richTextEditorRibbonBar2.Visible = false;
            radPanel1.Visible = true;
        }

        public bool ReadOnly
        {
            get
            {
                return radRichTextEditor1.IsReadOnly;
            }
            set
            {
                radRichTextEditor1.IsReadOnly = true;
            }
        }

        public string Text
        {
            get
            {
                XamlFormatProvider provider = new XamlFormatProvider();
                return provider.Export(radRichTextEditor1.Document);
            }
            set
            {
                XamlFormatProvider provider = new XamlFormatProvider();
                radRichTextEditor1.Document = provider.Import(value);

            }
        }

        public string NormalText
        {
            get
            {
                return radRichTextEditor1.GetPlainText();
            }
        }

        public void InsertRTFFooter(string pText)
        {
            Telerik.WinForms.Documents.DocumentPosition DP = new Telerik.WinForms.Documents.DocumentPosition(radRichTextEditor1.Document);
            DP.MoveToLastPositionInDocument();
            radRichTextEditor1.Insert(pText, DP);
        }

        public void InsertHeader(string pText, System.Drawing.Font font, System.Windows.Forms.HorizontalAlignment HorizontalAlignment, Color pColor)
        {


            radRichTextEditor1.Document.CaretPosition.MoveToFirstPositionInDocument();

            StyleDefinition style = this.radRichTextEditor1.CurrentEditingStyle;
            style.SetPropertyValue(Span.FontFamilyProperty, new Telerik.WinControls.RichTextEditor.UI.FontFamily(font.Name));
            style.SetPropertyValue(Span.FontSizeProperty, font.Size);
            style.SetPropertyValue(Span.ForeColorProperty, Telerik.WinControls.RichTextEditor.UI.Color.FromArgb(pColor.A, pColor.R, pColor.G, pColor.B));
            style.SetPropertyValue(Span.FlowDirectionProperty, Telerik.WinControls.RichTextEditor.UI.FlowDirection.RightToLeft);

            radRichTextEditor1.Insert(pText);
        }

        public void InsertFooter(string pText, System.Drawing.Font font, System.Windows.Forms.HorizontalAlignment HorizontalAlignment, Color pColor)
        {

            radRichTextEditor1.Document.CaretPosition.MoveToLastPositionInDocument();
            StyleDefinition style = this.radRichTextEditor1.CurrentEditingStyle;
            style.SetPropertyValue(Span.FontFamilyProperty, new Telerik.WinControls.RichTextEditor.UI.FontFamily(font.Name));
            style.SetPropertyValue(Span.FontSizeProperty, font.Size);
            style.SetPropertyValue(Span.ForeColorProperty, Telerik.WinControls.RichTextEditor.UI.Color.FromArgb(pColor.A, pColor.R, pColor.G, pColor.B));
            style.SetPropertyValue(Span.FlowDirectionProperty, Telerik.WinControls.RichTextEditor.UI.FlowDirection.RightToLeft);

            radRichTextEditor1.Insert(pText);
        }

        public void Close()
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Print(true);
        }


        public void OfficeWord()
        {
            string filename = ClassLibrary.JFiles.GetExecutingDirectory() + "\\" + "temp.rtf";
            Telerik.WinForms.Documents.FormatProviders.Rtf.RtfFormatProvider provider = new Telerik.WinForms.Documents.FormatProviders.Rtf.RtfFormatProvider();
            string _S = provider.Export(radRichTextEditor1.Document);
            System.IO.File.WriteAllText(filename, _S);
            Process.Start("winword.exe", filename);
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            OfficeWord();
        }


    }
}
