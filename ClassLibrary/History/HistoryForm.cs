using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JHistoryForm : JBaseForm
    {

        private DataTable _MainDT;
        private JHistory _History;
        private DataTable _SourceDT;
        public JHistoryForm(JHistory pHistory, int pObjectCode)
        {
            InitializeComponent();

            _SourceDT = pHistory.RetrieveHistory(pObjectCode);
            
            _MainDT = _SourceDT.Copy();
            _History = pHistory;
            uC_GridHistory.Bind(_MainDT, pHistory.ClassName);

            SetFields();
        }

        private void SetFields()
        {
            foreach (DataColumn DC in _MainDT.Columns)
            {
                clBFields.Items.Add(new JmyObject(DC, JLanguages._Text(DC.ColumnName)));
            }
        }

        private void clBFields_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void clBFields_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void clBFields_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _MainDT.Clear();
                _MainDT = _SourceDT.Copy();
                for (int j = 0; j < _MainDT.Rows.Count; j++)
                {
                    bool isChange = true;
                    DataRow DR = _MainDT.Rows[j];
                    if (j < _MainDT.Rows.Count - 1)
                    {
                        foreach (Object Ob in clBFields.CheckedItems)
                        {
                            isChange = false;
                            DataColumn DC = (DataColumn)((JmyObject)Ob).obj;
                            object a1 = DR[DC.ColumnName];
                            object a2 = _MainDT.Rows[j + 1][DC.ColumnName];
                            if (a1.ToString() != a2.ToString())
                            {
                                isChange = true;
                                break;
                            }
                        }
                    }
                    if (!isChange)
                    {
                        DR.Delete();
                        j--;
                    }
                }
                _MainDT.AcceptChanges();
                uC_GridHistory.Bind(_MainDT, _History.ClassName);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }

    public class JmyObject
    {

        public JmyObject(object pObj, string pCaption)
        {
            obj = pObj;
            Caption = pCaption;
        }

        public object obj;
        public string Caption;
        public override string ToString()
        {
            return Caption;
        }
    }

}
