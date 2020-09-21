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
    public partial class JPostHistoryForm : JBaseForm
    {
        private int _pUserCode;

        public JPostHistoryForm()
            : this(JMainFrame.CurrentUserCode)
        {
        }

        public JPostHistoryForm(int pUserCode)
        {
            InitializeComponent();
            jGPersonHostory.gridEX1.Click += new EventHandler(gridEX1_Click);
            _pUserCode = pUserCode;
            GetData();
            jGDataTableHistory.gridEX1.SelectionChanged += new EventHandler(jGDataTableHistory_SelectionChanged);
            (jGPersonHostory.DataSource as DataTable).RowChanged += new DataRowChangeEventHandler(JPostHistoryForm_RowChanged);
        }

        void gridEX1_Click(object sender, EventArgs e)
        {
            JHistory His = new JHistory();
            DataTable _DT;
            if (jGPersonHostory.gridEX1.CurrentRow != null)
                //_DT = His.GetXMLHistory(Convert.ToInt32(jGPersonHostory.gridEX1.CurrentRow.Cells["Code"].Value));
                _DT = His.GetDataTableHistory(jGPersonHostory.gridEX1.CurrentRow.Cells["History"].Value.ToString(), _pUserCode, Convert.ToDateTime(jGPersonHostory.gridEX1.CurrentRow.Cells["Date"].Value));
            else _DT = null;
            jGDataTableHistory.DataSource = _DT;
        }


        void jGDataTableHistory_SelectionChanged(object sender, EventArgs e)
        {
            //JHistory His = new JHistory();
            //DataTable _DT;
            //_DT = His.GetDataTableHistory(jGPersonHostory.gridEX1.CurrentRow.Cells["History"].Value.ToString(), _pUserCode, Convert.ToDateTime(jGDataTableHistory.gridEX1.CurrentRow.Cells["Date"].Value));
            //jGDataTableHistory.DataSource = _DT;
        }

        void JPostHistoryForm_RowChanged(object sender, DataRowChangeEventArgs e)
        {

        }

        public void GetData()
        {
            JHistory His = new JHistory();
            DataTable _DT = His.PersonHistory(_pUserCode);
            jGPersonHostory.DataSource = _DT;
            //jGPersonHostory.HidColumns(new string[] { "History" });
            label1.Text = _DT.Rows.Count.ToString();
        }
    }
}
