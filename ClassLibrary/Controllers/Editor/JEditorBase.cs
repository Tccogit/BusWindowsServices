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
    public partial class JEditorBase : UserControl
    {

        private JEditor TextEditor;
        private ClassLibrary.Controllers.Editor.JEditorWord WTextEditor;
        private ClassLibrary.Controllers.Editor.JEditorTelerik TTextEditor;

        private int _EditorType;
        public int EditorType
        {
            get
            {
                return _EditorType;
            }
            set
            {
                _EditorType = value;

                rdBaseEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;
                rbTelerik.CheckedChanged -= rdBaseEditor_CheckedChanged;
                rbWordEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;

                switch (value)
                {
                    case 0:
                        rdBaseEditor.Checked = true;
                        break;
                    case 1:
                        rbWordEditor.Checked = true;
                        break;
                    case 2:
                        rbTelerik.Checked = true;
                        break;
                }

                rdBaseEditor.CheckedChanged += rdBaseEditor_CheckedChanged;
                rbTelerik.CheckedChanged += rdBaseEditor_CheckedChanged;
                rbWordEditor.CheckedChanged += rdBaseEditor_CheckedChanged;

            }
        }
        public JEditorBase()
        {
            InitializeComponent();
        }

        public void Load()
        {
            if (EditorType == 0)
            {
                if (WTextEditor != null && WTextEditor.NormalText.Trim() != ""
                    && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                {
                    rbWordEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;
                    rbWordEditor.Checked = true;
                    rbWordEditor.CheckedChanged += rdBaseEditor_CheckedChanged;
                    return;
                }
                if (TTextEditor != null && TTextEditor.NormalText.Trim() != ""
                    && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                {
                    rbTelerik.CheckedChanged -= rdBaseEditor_CheckedChanged;
                    rbTelerik.Checked = true;
                    rbTelerik.CheckedChanged += rdBaseEditor_CheckedChanged;
                    return;
                }

                if (WTextEditor != null)
                {
                    WTextEditor.Destroy();
                    this.panel1.Controls.Remove(WTextEditor);
                    WTextEditor = null;
                }
                if (TTextEditor != null)
                {
                    this.panel1.Controls.Remove(TTextEditor);
                    TTextEditor = null;
                }

                TextEditor = new JEditor();
                this.panel1.Controls.Add(TextEditor);
                TextEditor.Dock = DockStyle.Fill;
                //TextEditor.Width = 800;
                //TextEditor.Height = 600;
                //this.panel1.Resize += panel1_Resize;

            }
            else
                if (EditorType == 1)
                {
                    if (TextEditor != null && TextEditor.GetNormalText().Trim() != ""
                        && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                    {
                        rdBaseEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;
                        rdBaseEditor.Checked = true;
                        rdBaseEditor.CheckedChanged += rdBaseEditor_CheckedChanged;
                        return;
                    }
                    if (TTextEditor != null && TTextEditor.NormalText.Trim() != ""
                        && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                    {
                        rbTelerik.CheckedChanged -= rdBaseEditor_CheckedChanged;
                        rbTelerik.Checked = true;
                        rbTelerik.CheckedChanged += rdBaseEditor_CheckedChanged;
                        return;
                    }

                    if (TextEditor != null)
                    {
                        this.panel1.Controls.Remove(TextEditor);
                        TextEditor = null;
                    }
                    if (TTextEditor != null)
                    {
                        this.panel1.Controls.Remove(TTextEditor);
                        TTextEditor = null;
                    }

                    WTextEditor = new Controllers.Editor.JEditorWord();
                    this.panel1.Controls.Add(WTextEditor);
                    WTextEditor.Dock = DockStyle.Fill;
                    WTextEditor.Load("ClassLibrary.JEditorBase", 0);
                }
                else
                    if (EditorType == 2)
                    {
                        if (TextEditor != null && TextEditor.GetNormalText().Trim() != ""
                            && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                        {
                            rdBaseEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;
                            rdBaseEditor.Checked = true;
                            rdBaseEditor.CheckedChanged += rdBaseEditor_CheckedChanged;
                            return;
                        }
                        if (WTextEditor != null && WTextEditor.NormalText.Trim() != ""
                            && JMessages.Message("در صورت تغییر ویرایشگر اطلاعات تایپ شده حذف خواهد شد . آیا مطما هستید؟", "خطا حذف دیتا", JMessageType.Question) == DialogResult.No)
                        {
                            rbWordEditor.CheckedChanged -= rdBaseEditor_CheckedChanged;
                            rbWordEditor.Checked = true;
                            rbWordEditor.CheckedChanged += rdBaseEditor_CheckedChanged;
                            return;
                        }

                        if (TextEditor != null)
                        {
                            this.panel1.Controls.Remove(TextEditor);
                            TextEditor = null;
                        }
                        if (WTextEditor != null)
                        {
                            WTextEditor.Dispose();
                            this.panel1.Controls.Remove(WTextEditor);
                            WTextEditor = null;
                        }

                        TTextEditor = new Controllers.Editor.JEditorTelerik();
                        this.panel1.Controls.Add(TTextEditor);
                        TTextEditor.Dock = DockStyle.Fill;
                    }
        }

        void panel1_Resize(object sender, EventArgs e)
        {
            TextEditor.Left = panel1.Width / 2 - TextEditor.Width / 2;
            TextEditor.Top = 10;
            TextEditor.Height = panel1.Height - 20;
        }

        public String Text
        {
            get
            {
                if (EditorType == 0)
                    return TextEditor.Text;
                else
                    if (EditorType == 1)
                        return WTextEditor.Text;
                    else
                        return TTextEditor.Text;
            }
            set
            {
                if (EditorType == 0)
                    TextEditor.Text = value;
                else
                    if (EditorType == 1)
                        WTextEditor.Text = value;
                    else
                        TTextEditor.Text = value;
            }
        }

        public string GetNormalText()
        {
            if (EditorType == 0)
                return TextEditor.GetNormalText();
            else
                if (EditorType == 1)
                    return WTextEditor.NormalText;
                else
                    return TTextEditor.NormalText;
        }

        public void ChangeToViewMode()
        {
            panelSelectEditor.Visible = false;
            if (EditorType == 0)
                TextEditor.ChangeToViewMode();
            else
                if (EditorType == 1)
                    WTextEditor.ChangeToViewMode();
                else
                    TTextEditor.ChangeToViewMode();

        }

        public void InsertRTFFooter(string pText)
        {
            if (EditorType == 0)
                TextEditor.InsertRTFFooter(pText);
            else
                if (EditorType == 1)
                    WTextEditor.InsertRTFFooter(pText);
                else
                    TTextEditor.InsertRTFFooter(pText);

        }

        public void InsertHeader(string pText,System.Drawing.Font font,System.Windows.Forms.HorizontalAlignment HorizontalAlignment,Color pColor)
        {
            if (EditorType == 0)
                TextEditor.InsertHeader(pText, font, HorizontalAlignment, pColor);
            else
                if (EditorType == 1)
                    WTextEditor.InsertHeader(pText, font, HorizontalAlignment, pColor);
                else
                    TTextEditor.InsertHeader(pText, font, HorizontalAlignment, pColor);
        }

        public void InsertFooter(string pText, System.Drawing.Font font, System.Windows.Forms.HorizontalAlignment HorizontalAlignment, Color pColor)
        {
            if (EditorType == 0)
                TextEditor.InsertFooter(pText, font, HorizontalAlignment.Right, pColor);
            else
                if (EditorType == 1)
                    WTextEditor.InsertFooter(pText, font, HorizontalAlignment.Right, pColor);
                else
                    TTextEditor.InsertFooter(pText, font, HorizontalAlignment.Right, pColor);
        }

        public void Close()
        {
            if (WTextEditor != null && WTextEditor.isClosed())
                WTextEditor.Close();
        }

        private void rdBaseEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton && (sender as RadioButton).Name == "rdBaseEditor" && (sender as RadioButton).Checked)
            {
                EditorType = 0;
                Load();
            }
            if (sender is RadioButton && (sender as RadioButton).Name == "rbWordEditor" && (sender as RadioButton).Checked)
            {
                EditorType = 1;
                Load();
            }
            if (sender is RadioButton && (sender as RadioButton).Name == "rbTelerik" && (sender as RadioButton).Checked)
            {
                EditorType = 2;
                Load();
            }
           
        }

        private void rbWordEditor_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void JEditorBase_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (WTextEditor != null)
                WTextEditor.Destroy();
        }

        private void rbTelerik_Click(object sender, EventArgs e)
        {

        }

    }
}
