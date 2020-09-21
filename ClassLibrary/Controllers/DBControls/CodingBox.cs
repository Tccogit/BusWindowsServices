using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    public partial class JCodingBox : UserControl
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr
        lParam);
        public const int CB_SHOWDROPDOWN = 0x14F;

        public string TitleFieldName;
        public string CodeFieldName;
        public string AccessCodeFieldName;
        private DataTable _dataTable;
        public object SelectedValue
        {
            set
            {
                try
                {
                    cmbTitles.SelectedValue = value;
                }
                catch(Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
            get
            {
                return cmbTitles.SelectedValue;
            }
        }
        public int SelectedIndex
        {
            set
            {
                try
                {
                    cmbTitles.SelectedIndex = value;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
            get
            {
                return cmbTitles.SelectedIndex;
            }
        }
        
        public DataTable dataTable
        {
            get
            {
                return _dataTable;
            }
            set
            {
                _dataTable = value;
            }
        }
        public int SelectedCode
        {
            get
            {
                if (txtCode.Text != "" && cmbTitles.SelectedValue != null && int.Parse(cmbTitles.SelectedValue.ToString()) > 0)
                {
                    return Convert.ToInt32(((System.Data.DataRowView)cmbTitles.SelectedItem)["Code"]);
                }
                else
                    return 0;
            }
        }
        public bool ReadOnly
        {
            set
            {
                txtCode.ReadOnly = value;
                cmbTitles.Enabled = !value;
            }
        }

        public string Text
        {
            get
            {
                return cmbTitles.Text;
            }
            set
            {
                cmbTitles.Text = value;
            }
        }
        public DataRowView SelectedItem;
        public JCodingBox()
        {
            InitializeComponent();
        }
        //public event EventHandler ButtonClick;

        //private void btnBrows_Click(object sender, EventArgs e)
        //{
        //    ButtonClick.BeginInvoke(sender, e, null, null);
        //}

        public void SetComboBox()
        {
            try
            {
                if (_dataTable == null)
                    return;
                cmbTitles.DisplayMember = TitleFieldName;
                cmbTitles.ValueMember = AccessCodeFieldName;                           
                DataRow dr = _dataTable.NewRow();
                dr[CodeFieldName] = "-1";
                dr[TitleFieldName] = "-----------";
                dr[AccessCodeFieldName] = "-1";
                _dataTable.Rows.InsertAt(dr, 0);
                cmbTitles.DataSource = _dataTable;
                //if (ParentAccessCode != 0)
                //{
                //    nedtAccessCodeParent.Text = ParentAccessCode.ToString();
                //    cmbOrganizations.SelectedValue = ParentAccessCode;
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void cmbTitles_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbTitles.SelectedIndex != -1 && int.Parse(cmbTitles.SelectedValue.ToString()) != -1)
                {
                }
                else
                {
                    txtCode.Text = "";
                    //txtCode.Focus();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void cmbTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTitles.SelectedValue != null && int.Parse(cmbTitles.SelectedValue.ToString()) != -1)
                {
                    txtCode.Text = cmbTitles.SelectedValue.ToString();
                    SelectedItem = (DataRowView)cmbTitles.SelectedItem;
                }
                else
                {
                    txtCode.Text = "";
                    SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                SelectedItem = null;
            }

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCode.Text != "")
                {
                    cmbTitles.SelectedValue = txtCode.Text;
                }
                else
                {
                    cmbTitles.SelectedIndex = 0;
                }
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (txtCode.Text != "")
                cmbTitles.SelectedValue = int.Parse(txtCode.Text);
        }

        public void SetValue(object pValue)
        {
            cmbTitles.SelectedValue = pValue;
        }

        private void cmbTitles_TextUpdate(object sender, EventArgs e)
        {
            //_dataTable.DefaultView.RowFilter = TitleFieldName+" LIKE '%"+cmbTitles.Text+"%'";

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void cmbTitles_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (((DataTable)cmbTitles.DataSource).DefaultView.RowFilter != "")
            //    {
            //        string temp = cmbTitles.SelectedValue.ToString();
            //        ((DataTable)cmbTitles.DataSource).DefaultView.RowFilter = "";
            //        cmbTitles.SelectedValue = temp;
            //    }
            //}
            //catch { }
        }

        private void cmbTitles_Enter(object sender, EventArgs e)
        {
            //textBox1.SendToBack();
            //cmbTitles.BringToFront();
            //textBox1.Text = cmbTitles.Text; 
        }

        private void cmbTitles_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (cmbTitles.SelectedIndex == -1 || int.Parse(cmbTitles.SelectedValue.ToString()) == -1)
            //        txtCode.Focus();
            //}
            //if (!(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter || e.Alt || e.Shift || e.Control))
            //{
            //    cmbTitles.SendToBack();
            //    textBox1.Focus();
            //}
        }

        private void cmbTitles_KeyUp(object sender, KeyEventArgs e)
        {
            //if ((sender is TextBox) && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter))
            //{
            //    cmbTitles.Focus();
            //}
            //else
            {
               //((DataTable)cmbTitles.DataSource).DefaultView.RowFilter = " full_title like '%" + cmbTitles.Text + "%'";
               //SendMessage(cmbTitles.Handle.ToInt32(), CB_SHOWDROPDOWN, 1, IntPtr.Zero);
            }

        }

        private void cmbTitles_Resize(object sender, EventArgs e)
        {
            setPositionSearchText();
        }

        private void setPositionSearchText()
        {
            //SearchTextBox.Width = cmbTitles.Width - 20;
            //SearchTextBox.Left = cmbTitles.Left + 20;
        }

        private void cmbTitles_ControlAdded(object sender, ControlEventArgs e)
        {
            setPositionSearchText();
        }


    }
}
