using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Report.DynamicFastReport
{
    public partial class jDynamicReprotManagers : JBaseForm
    {
        private DataTable _DataTable;
        private string _Skey;
        private int _iKey;

        public jDynamicReprotManagers(DataTable pDataTable)
        {
            InitializeComponent();
            _DataTable = pDataTable;
            
            _Skey = JDataBase.GetStringFiledsName(_DataTable);
            _iKey = JGeneral.StrintToNumber(_Skey);

            JDynamicReports DRS = new JDynamicReports(0,0);
            DataTable DT = DRS.GetData();
            jJanusGrid1.DataSource = DT;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int _code = (int)jJanusGrid1.SelectedRow.Row["Code"];
                JDynamicReport DR = new JDynamicReport(_code, _code);
                DR.ReportCode = _iKey;
                DR.Update();
            }
        }
    }
}
