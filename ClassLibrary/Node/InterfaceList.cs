using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JInterfaceList1
    {
        private UC_Grid _DataGrid;
        private string _SQL;
        public string SQL
        {
            get
            {
                return _SQL;
            }
            set
            {
                _SQL = value;
                Clear();
                Refresh();
            }
        }
        private System.Data.DataTable _DataTable;

        public System.Data.DataTable DataTable
        {
            get
            {
                return _DataTable;
            }
            set
            {
                _DataTable = value;
                _SQL = null;
                Refresh();
            }
        }

        public JInterfaceList1(UC_Grid pDataGrid)
        {
            _DataGrid = pDataGrid;
        }

        public void Refresh()
        {
            if (_DataGrid == null)
                return;
            if (_SQL != null)
            {
                JDataBase DB = new JDataBase();
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                //_DataGrid.DataSource = DB.DataSet.Tables[0];
                _DataGrid.Bind(DB, "");
            }
            else
                if (_DataTable != null)
                    _DataGrid.Bind(_DataTable, "");
        }

        public void Clear()
        {
            if (_DataTable != null)
                _DataTable.Clear();
            if (_DataGrid != null)
                _DataGrid.DataSource = null;
        }

    }
}
