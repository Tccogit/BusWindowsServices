using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace ClassLibrary
{

    public partial class JEditor : UserControl
    {
        public JEditor()
        {
            InitializeComponent();
            SetDefaultFont();
        }

        private void JEditor_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                cmbFont.Items.Add(font.Name);
            }
        }

        private string _Text;
        public string Text
        {
            get
            {
                if (_ViewMode)
                    return _Text;
                else
                    return
                        rtbEditor.Rtf;
            }
            set
            {
                if (_ViewMode)
                {
                    SetAlighn();
                }
                else
                {
                    if (value == null || value == "")
                        SetDefaultFont();
                    _Text = value;
                    rtbEditor.Rtf = _Text;
                    SetAlighn();
                }
            }
        }

        public RichTextBox RichTextBox
        {
            get
            {
                return rtbEditor;
            }
        }

        private bool _ViewMode;
        public bool ViewMode
        {
            get
            {
                return _ViewMode;
            }
            set
            {
                _ViewMode = value;
                if (_ViewMode)
                    ChangeToViewMode();
                else
                    ChangeToEditMode();
            }
        }

        public void ClearText()
        {
            rtbEditor.Text = "";
        }

        public string GetNormalText()
        {
            return rtbEditor.Text;
        }

        public string GetRtf()
        {
            bool readOnly = rtbEditor.ReadOnly;
            rtbEditor.ReadOnly = false;
            string rtf = rtbEditor.Rtf;
            rtbEditor.ReadOnly = readOnly;
            return rtf;
        }

        public int FindText(string text)
        {
            return FindText(text, 0, RichTextBoxFinds.MatchCase);
        }
        public int FindText(string text, int startIndex, RichTextBoxFinds options)
        {
            return rtbEditor.Find(text, startIndex, options);
        }

        public void PasteRTF()
        {
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Rtf);
            rtbEditor.Paste(myFormat);
            SetAlighn();
        }

        public void MoveIndexTo(int index, int length)
        {
            rtbEditor.Select(index, length);
        }


        public void InsertImage(Image pPic)
        {
            try
            {
                System.Drawing.Size size = new Size(pPic.Width, pPic.Height);
                if (pPic.Height > 600)
                {
                    size.Height = 600;
                    size.Width = pPic.Width * 600 / pPic.Height;
                }
                if (pPic.Width > 600)
                {
                    size.Width = 600;
                    size.Height = pPic.Height * 600 / pPic.Width;
                }
                Image pic = resizeImage(pPic, size);
                Clipboard.SetImage(pic);
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                bool ReadOnly = rtbEditor.ReadOnly;
                rtbEditor.ReadOnly = false;
                if (rtbEditor.CanPaste(myFormat))
                {
                    rtbEditor.Paste(myFormat);
                }
                else
                {
                    MessageBox.Show("The data format that you attempted site" +
                    " is not supported by this control.");
                }
                rtbEditor.ReadOnly = ReadOnly;
            }
            catch
            {
            }
        }

        private Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public string GetImage(MemoryStream imageStream, int width, int height)
        {
            MemoryStream stream = new MemoryStream();
            Image img = Image.FromStream(imageStream);
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            byte[] bytes = stream.ToArray();

            string str = BitConverter.ToString(bytes, 0).Replace("-", string.Empty);
            //string str = System.Text.Encoding.UTF8.GetString(bytes);

            string mpic = @"{\pict\jpegblip\picw" +
                img.Width.ToString() + @"\pich" + img.Height.ToString() +
                @"\picwgoal" + width.ToString() + @"\pichgoal" + height.ToString() +
                @"\hex " + str + "}";
            /*string mpic = @"{\rtf1\fbidis\ansi\ansicpg1256\deff0\deflang1065{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\ltrpar\sa200\sl240\slmult1\lang9\f0\fs22{\pict\wmetafile8\picw847\pich847\picwgoal480\pichgoal480 
"
                + str + @"
}\par
\pard\ltrpar\sa200\sl276\slmult1\par
}";*/
            return mpic;
        }

        public void InsertAlign(HorizontalAlignment ha)
        {
            rtbEditor.SelectionAlignment = ha;
        }

        public void InsertRTF(string rtf)
        {
            rtbEditor.SelectedRtf = rtf;
        }

        public void InsertText(string text)
        {
            InsertText(text, 1);
        }
        public void InsertText(string text, int length)
        {
            rtbEditor.SelectionLength = length;
            rtbEditor.SelectedText = text;

            SetAlighn();
        }

        public void InsertHeader(string text, Font font, HorizontalAlignment align, Color color)
        {
            rtbEditor.Select(0, 0);
            rtbEditor.SelectionFont = font;
            rtbEditor.SelectionAlignment = align;
            rtbEditor.SelectionColor = color;
            rtbEditor.SelectedText = text;

            SetAlighn();
        }

        public void InsertFooter(string text, Font font, HorizontalAlignment align, Color color)
        {
            rtbEditor.Select(rtbEditor.Text.Length, 0);
            rtbEditor.SelectionFont = font;
            rtbEditor.SelectionAlignment = align;
            rtbEditor.SelectionColor = color;
            rtbEditor.SelectedText = text;

            SetAlighn();
        }

        public void InsertFooter(string text, Font font)
        {
            rtbEditor.Select(rtbEditor.Text.Length, 0);
            rtbEditor.SelectionFont = font;
            rtbEditor.SelectedText = text;

            SetAlighn();
        }

        public void InsertHeader(string text, Font font)
        {
            rtbEditor.Select(0, 0);
            rtbEditor.SelectionFont = font;
            rtbEditor.SelectedText = text;

            SetAlighn();
        }

        public void InsertRTFFooter(string text)
        {
            rtbEditor.Select(rtbEditor.Text.Length, 0);
            rtbEditor.SelectedRtf = text;

            SetAlighn();
        }


        public void SetDefaultFont()
        {
            try
            {
                FontFamily fontFamily = new FontFamily("B Zar");
                Font font = new Font(fontFamily, Convert.ToSingle(18), rtbEditor.SelectionFont.Style);
                rtbEditor.Font = font;
            }
            catch { }
            finally { }
        }

        public void ChangeToViewMode()
        {
            try
            {
                _ViewMode = true;
                ToolStrip1.Visible = false;
                rtbEditor.ReadOnly = true;
                rtbEditor.BackColor = Color.White;
                rtbEditor.BorderStyle = BorderStyle.None;
            }
            catch
            {
            }
        }

        public void ChangeToEditMode()
        {
            _ViewMode = false;
            ToolStrip1.Visible = true;
            rtbEditor.ReadOnly = false;
            rtbEditor.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBold.CheckState == CheckState.Checked)
                {
                    btnBold.CheckState = CheckState.Unchecked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style ^ FontStyle.Bold;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
                else
                {
                    btnBold.CheckState = CheckState.Checked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style | FontStyle.Bold;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
            }
            catch { }
            finally { }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnItalic.CheckState == CheckState.Checked)
                {
                    btnItalic.CheckState = CheckState.Unchecked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style ^ FontStyle.Italic;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
                else
                {
                    btnItalic.CheckState = CheckState.Checked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style | FontStyle.Italic;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
            }
            catch { }
            finally { }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnUnderline.CheckState == CheckState.Checked)
                {
                    btnUnderline.CheckState = CheckState.Unchecked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style ^ FontStyle.Underline;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
                else
                {
                    btnUnderline.CheckState = CheckState.Checked;
                    FontStyle fontStyle = rtbEditor.SelectionFont.Style | FontStyle.Underline;
                    Font font = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, fontStyle);
                    rtbEditor.SelectionFont = font;
                }
            }
            catch { }
            finally { }
        }

        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            try
            {
                btnLeftAlign.CheckState = CheckState.Checked;
                btnRightAlign.CheckState = CheckState.Unchecked;
                btnCenterAlign.CheckState = CheckState.Unchecked;
                rtbEditor.SelectionAlignment = HorizontalAlignment.Left;
            }
            catch { }
            finally { }
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            try
            {
                btnLeftAlign.CheckState = CheckState.Unchecked;
                btnRightAlign.CheckState = CheckState.Unchecked;
                btnCenterAlign.CheckState = CheckState.Checked;
                rtbEditor.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch { }
            finally { }
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            try
            {
                btnLeftAlign.CheckState = CheckState.Unchecked;
                btnRightAlign.CheckState = CheckState.Checked;
                btnCenterAlign.CheckState = CheckState.Unchecked;
                rtbEditor.SelectionAlignment = HorizontalAlignment.Right;
            }
            catch { }
            finally { }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            uiColorPicker1.Left = 0;
            uiColorPicker1.Top = ToolStrip1.Height;
            uiColorPicker1.Show();
        }

        private void uiColorPicker1_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                uiColorPicker1.Hide();
                rtbEditor.SelectionColor = uiColorPicker1.SelectedColor;
            }
            catch
            {
            }
            finally { }
        }

        private void rtbEditor_Enter(object sender, EventArgs e)
        {
            uiColorPicker1.Hide();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Font font = new Font(rtbEditor.SelectionFont.FontFamily, Convert.ToSingle(cmbSize.Text), rtbEditor.SelectionFont.Style);
                rtbEditor.SelectionFont = font;
            }
            catch
            {
            }
            finally { }
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FontFamily fontFamily = new FontFamily(cmbFont.Text);
                Font font = new Font(fontFamily, rtbEditor.SelectionFont.Size, rtbEditor.SelectionFont.Style);
                rtbEditor.SelectionFont = font;
            }
            catch
            { }
            finally
            {
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();
                    InsertImage(Image.FromFile(dlg.FileName));
                }

                dlg.Dispose();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void Replace(string pOld, string pNew)
        {
            int i = rtbEditor.Find(pOld);
            rtbEditor.Select(i, pOld.Length);
            rtbEditor.SelectedText = pNew;

        }

        private void SetAlighn()
        {
            //rtbEditor.SelectAll();
            //rtbEditor.SelectionIndent = 50;
            //rtbEditor.SelectionRightIndent = 50;
            //rtbEditor.SelectionLength = 0;
            //rtbEditor.SelectionBackColor = rtbEditor.BackColor;
        }
        private void btnWordPad_Click(object sender, EventArgs e)
        {
            OfficeWord();
        }

        public void WordPad()
        {
            string filename = ClassLibrary.JFiles.GetExecutingDirectory() + "\\" + "temp.doc";
            rtbEditor.SaveFile(filename);
            Process.Start("wordpad.exe", filename);
        }
        public void OfficeWord()
        {
            string filename = ClassLibrary.JFiles.GetExecutingDirectory() + "\\" + "temp.doc";
            rtbEditor.SaveFile(filename);
            Process.Start("winword.exe", filename);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا از چاپ این متن مطمئن هستید", "چاپ") == DialogResult.Yes)
                Print();
        }

        public void Print()
        {
            rtbEditor.Print();
        }
    }
}
