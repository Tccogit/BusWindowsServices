using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace ClassLibrary
{
    public partial class JComboBox : System.Windows.Forms.ComboBox
    {
        public JComboBox()
        {
            mainBackColor = this.BackColor;
            InitializeComponent();
        }

        public JComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if ((int)keyData == 87)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        private bool thisChangeColorOnEnter = true;
        private bool thisNotEmpty = false;
        private bool thisChangeColorIfNotEmpty = true;
        private bool thisSelectOnEnter = true;

        private static JSubBaseDefine _LastNewItem = null;
        private JSubBaseDefine _LastItem = null;
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
            get
            {
                return thisChangeColorOnEnter;
            }
            set
            {
                thisChangeColorOnEnter = value;
            }
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
        /// <summary>
        /// کد تعاریف پایه
        /// </summary>
        public int BaseCode
        {
            get;
            set;
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

        Color tmpForeColor, tmpBackColor;
        private void JComboBox_Enter(object sender, EventArgs e)
        {
            CheckField();
            if (thisChangeColorOnEnter)
            {
                tmpBackColor = this.BackColor; ;
                tmpForeColor = this.ForeColor;
                this.ForeColor = thisInForeColor;
                this.BackColor = thisInBackColor;
            }
            if (thisSelectOnEnter)
            {
                this.SelectAll();
            }
        }
        private Color mainBackColor;
        private void JComboBox_Leave(object sender, EventArgs e)
        {
            //if (this.Focused)
                if (this.SelectedIndex == -1)
                    if (NotEmpty)
                    {
                        JMessages.Error("PleaseSelectAnItem", "Error");
                        if (this.Enabled)
                        {
                            this.Focus();
                            //return;
                        }
                    }

            if (thisNotEmpty)
            {                
                if (this.SelectedIndex == -1)
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
        }

        private void JComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // if (this.SelectedItem is JSubBaseDefine)
            try
            {
                //if (Items.Count > 1 && this.BaseCode==0)
                //if (Items.Count > 1 && (Items[1].ToString() == "System.Data.DataRowView") && (String.Compare(((System.Data.DataRowView)(Items[1])).DataView.Table.TableName, "SubDefine") == 0))
                //{
                //    this.BaseCode = Convert.ToInt32(((System.Data.DataRowView)(Items[1])).DataView.Table.Rows[0].ItemArray[2]);
                //    if (this.BaseCode <= 1) 
                //        this.BaseCode = Convert.ToInt32(((System.Data.DataRowView)(Items[1])).DataView.Table.Rows[1].ItemArray[2]);
                //        //((JSubBaseDefine)Items[1]).BCode;
                //}
                //((e.Control && e.KeyValue == (int)Keys.I && this.BaseCode != 0)
                if (e.Control && e.KeyCode == Keys.F)
                    (new ClassLibrary.Controllers.EditControls.JComboboxSearchForm(this)).ShowDialog();
                if ((e.Control && e.KeyValue == (int)Keys.I) && //(this.BaseCode != 0) &&
                    this.DataSource != null && ((DataTable)this.DataSource).TableName == "SubDefine")
                // (String.Compare(((System.Data.DataRowView)(Items[1])).DataView.Table.TableName,"SubDefine") == 0))
                {
                    JSubBaseDefine define = new JSubBaseDefine(this.BaseCode);
                    JBaseDefineForm defineForm = new JBaseDefineForm(define);
                    defineForm.ShowDialog();
                    if (defineForm.DialogResult == DialogResult.OK)
                    {
                        DataTable dt = (DataTable)this.DataSource;
                        DataRow dr = dt.NewRow();
                        dr["Code"] = defineForm._SubBaseDefine.Code;
                        dr["BCode"] = defineForm._SubBaseDefine.BCode;
                        dr["Name"] = defineForm._SubBaseDefine.Name;
                        dt.Rows.Add(dr);
                        this.DataSource = dt;
                        this.SelectedValue = defineForm._SubBaseDefine.Code;
                        //JComboBox_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = false;
                    //        this.SelectNextControl((JComboBox)sender, true, true, false, true);
                }
            }
        }

        private void CheckField()
        {
            try
            {
                if (_LastNewItem is JSubBaseDefine && _LastItem == null &&
                    Items.Count > 1 && Items[1] is JSubBaseDefine)
                {
                    //_LastItem = new JSubBaseDefine(((JSubBaseDefine)Items[1]).BCode);
                    _LastItem = (JSubBaseDefine)Items[1];
                }

                if (_LastNewItem is JSubBaseDefine && _LastItem.Name != _LastNewItem.Name
                    && _LastNewItem.BCode == _LastItem.BCode)
                {
                    _LastItem = _LastNewItem;
                    this.Items.Add(_LastNewItem);
                }
            }
            catch
            {
            }
        }

        private void JComboBox_KeyUp(object sender, KeyEventArgs e)
        {
          
            //
        }

        private void JComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
