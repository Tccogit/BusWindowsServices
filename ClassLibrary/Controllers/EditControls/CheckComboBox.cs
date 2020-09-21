using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Data;

namespace ClassLibrary
{
    public partial class JCheckComboBox : ComboBox
    {
        #region Constructor
        public JCheckComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDown;
            this.DrawItem += new DrawItemEventHandler(JCheckComboBox_DrawItem);
            this.SelectedIndexChanged += new EventHandler(JCheckComboBox_SelectedIndexChanged);
        }

        #endregion

        #region Properties
        private string _CheckStateMember = String.Empty;
        public string CheckStateMember
        {
            get
            {
                return _CheckStateMember;
            }
            set
            {
                _CheckStateMember = value.ToString();
            }
        }

        public object[] SelectedValues
        {
            get
            {
                List<object> sv = new List<object>();
                foreach (var itm in Items)
                {
                    if (((CheckComboBoxItem)itm).CheckState == true)
                        sv.Add(((CheckComboBoxItem)itm).Value);
                }
                return sv.ToArray();
            }
        }

        public int SelectedCount
        {
            get
            {
                int count = 0;
                foreach (var itm in Items)
                {
                    if (((CheckComboBoxItem)itm).CheckState == true) count++;
                }
                return count;
            }
        }

        public DataTable ToDataSource
        {
            set
            {
                List<CheckComboBoxItem> lstCheckComboBoxItem = new List<CheckComboBoxItem>();
                foreach (DataRow dr in ((DataTable)value).Rows)
                {
                    if (String.IsNullOrEmpty(CheckStateMember))
                        lstCheckComboBoxItem.Add(new CheckComboBoxItem(dr[DisplayMember].ToString(), dr[ValueMember], false));
                    else
                        lstCheckComboBoxItem.Add(new CheckComboBoxItem(dr[DisplayMember].ToString(), dr[ValueMember], Convert.ToBoolean(dr[CheckStateMember])));
                }
                DataSource = lstCheckComboBoxItem;
            }
        }
        #endregion

        #region Events
        public event EventHandler CheckStateChanged;

        void JCheckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBoxItem item = (CheckComboBoxItem)SelectedItem;
            item.CheckState = !item.CheckState;
            if (CheckStateChanged != null)
                CheckStateChanged(item, e);
        }

        void JCheckComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            if (!(Items[e.Index] is CheckComboBoxItem))
            {
                e.Graphics.DrawString(
                    Items[e.Index].ToString(),
                    this.Font,
                    Brushes.Black,
                    new Point(e.Bounds.X, e.Bounds.Y));
                return;
            }

            CheckComboBoxItem box = (CheckComboBoxItem)Items[e.Index];
            CheckedListBox clb = new CheckedListBox();
            clb.Location = new Point(0, 0);
            clb.Show();
            CheckBoxRenderer.RenderMatchingApplicationState = true;
            CheckBoxRenderer.DrawCheckBox(
                e.Graphics,
                new Point(e.Bounds.X, e.Bounds.Y),
                e.Bounds,
                box.Text,
                this.Font,
                (e.State & DrawItemState.Focus) == 0,
                box.CheckState ? CheckBoxState.CheckedNormal :
                    CheckBoxState.UncheckedNormal);
        }
        #endregion

        #region Internal Classes
        public class CheckComboBoxItem
        {
            public CheckComboBoxItem(string text, object value, bool initialCheckState)
            {
                _checkState = initialCheckState;
                _text = text;
                _value = value;
            }

            private bool _checkState = false;
            public bool CheckState
            {
                get { return _checkState; }
                set { _checkState = value; }
            }

            private string _text = "";
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            private object _value = null;
            public object Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public override string ToString()
            {
                return "انتخاب ...";
            }
        }
        #endregion

    }

}
