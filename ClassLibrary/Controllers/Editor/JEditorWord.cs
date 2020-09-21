using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers.Editor
{
    public partial class JEditorWord : UserControl
    {
        public JEditorWord()
        {
            InitializeComponent();
        }

        private string _ClassName;
        private int _ObjectCode;

        public void Load(string pClassName, int pObjectCode)
        {
            _ClassName = pClassName;
            _ObjectCode = pObjectCode;
            winWordControl1.ClassName = _ClassName;
            winWordControl1.ObjectCode = _ObjectCode;

            winWordControl1.LoadDocument();
        }

        public void Destroy()
        {
            winWordControl1.CloseWord();
        }

        public void Save()
        {
            ArchivedDocuments.JArchiveDataBase A = new ArchivedDocuments.JArchiveDataBase();
            winWordControl1.SaveInOfficeWord(A,_ClassName,_ObjectCode,true);
            A.Dispose();
        }

        public void ChangeToViewMode()
        {
            //winWordControl1.ChangeToViewMode();
        }

        public bool ReadOnly
        {
            get
            {
                return winWordControl1.ReadOnly;
            }
            set
            {
                winWordControl1.ReadOnly = true;
            }
        }

        public string Text
        {
            get
            {
                return winWordControl1.stringContent;
            }
            set
            {
                try
                {
                    winWordControl1.stringContent = value;
                }
                catch(Exception ex)
                {

                }
            }
        }

        public string NormalText
        {
            get
            {
                return winWordControl1.Text;
            }
        }

        public void InsertRTFFooter(string pText)
        {
            //winWordControl1.InsertFooter(pText);
        }

        public void InsertHeader(string pText, System.Drawing.Font font, System.Windows.Forms.HorizontalAlignment HorizontalAlignment, Color pColor)
        {
            //winWordControl1.InsertHeader(pText);
        }

        public void InsertFooter(string pText, System.Drawing.Font font, System.Windows.Forms.HorizontalAlignment HorizontalAlignment, Color pColor)
        {
            //winWordControl1.InsertFooter(pText);
        }

        public void Close()
        {
            winWordControl1.CloseWord();
        }

        public bool isClosed()
        {
            return true;
            //return winWordControl1.isClosed;
        }

    }
}
