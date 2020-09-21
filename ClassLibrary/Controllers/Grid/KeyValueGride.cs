using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public partial class JKeyValueGride : JJanusGrid
    {

        private DataTable _DataTable;
        public DataTable DataTable
        {
            get
            {
                return _DataTable;
            }
            set
            {
                if (_DataTable != value)
                {
                    bind(value);
                    _DataTable = value;
                }
            }
        }

        public JKeyValueGride()
        {
            InitializeComponent();
        }


        public JKeyValueGride(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
