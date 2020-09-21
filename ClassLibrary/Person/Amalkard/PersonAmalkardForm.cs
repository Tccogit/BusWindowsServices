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
    public partial class PersonAmalkardForm : JBaseForm
    {
        //RealEstate.JSecAmalkard Service { get; set; }

        public PersonAmalkardForm(int PersonCode)
        {
        //    InitializeComponent();
        //    int pCode = PersonCode;
          
        //    JAllPerson allPerson = new JAllPerson(pCode);
        //    Service = new RealEstate.JSecAmalkard(allPerson.Code,true);
             
        }

        private void PersonAmalkardForm_Load(object sender, EventArgs e)
        {
            //grdKhadmat.DataSource =Service.GetAmalkard(true);
            //grdTahod.DataSource = Service.GetSecforms(true, 1);
            //grdWar.DataSource = Service.GetSecforms(true, 2);
        }

        private void grdKhadmat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Int32 Code = Convert.ToInt32(grdKhadmat["Code", grdKhadmat.CurrentRow.Index].Value);
            //JAction act = new JAction("Amalkard", "Security.JSecService.ShowForm", new object[] { Code }, null);
            //act.run();
        }

        private void grdWar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int Code = Convert.ToInt32(grdWar["Code", grdWar.CurrentRow.Index].Value);
            //int Type = 2;
            //JAction act = new JAction("Writer", "Security.JWrittencommitment.ShowFormWritble", new object[] { Code }, null);
            //act.run();
        }

        private void grdTahod_DoubleClick(object sender, EventArgs e)
        {
            //int Code = Convert.ToInt32(grdTahod["Code", grdTahod.CurrentRow.Index].Value);
            //int Type = 2;
            //JAction act = new JAction("Writer", "Security.JWrittencommitment.ShowFormWritble", new object[] { Code }, null);
            //act.run();
        }
    }
}
