using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JUCPerson : UserControl
    {
        public int PersonCode;
        /// <summary>
        /// برچسب 
        /// </summary>
        private string _LableGroup;
        public string LableGroup
        {
            get
            {
                return _LableGroup;
            }
            set
            {
                _LableGroup = value;
                groupBox3.Text = _LableGroup;
            }
        }

        public JUCPerson()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int Code = 0;
                JFindPersonForm FPF = new JFindPersonForm();
                FPF.ShowDialog();
                if (FPF.SelectedPerson != null)
                    Code = FPF.SelectedPerson.Code;
                if (Code != 0)
                {
                    JAllPerson tmp = new JAllPerson(Code);
                    if (tmp.PersonType == JPersonTypes.RealPerson)
                    {
                        JPerson JDP = new JPerson();
                        if (JDP.getData(Code))
                        {
                            PersonCode = JDP.Code;
                            txtExportCode.Text = JDP.Code.ToString();
                            labDeadName.Text = JDP.Name.ToString() + "  " + JDP.Fam.ToString() + "  " + JDP.FatherName.ToString();
                            labDeadshsh.Text = JDP.ShSh.ToString() + "  " + JDP.ShMeli.ToString() + "  " + JDateTime.FarsiDate(JDP.BthDate);
                        }
                        else
                            JMessages.Error("PersonCodeNotFound", "Error");
                    }
                    else
                    {
                        JOrganization JOrg = new JOrganization();
                        if (JOrg.GetData(Code))
                        {
                            PersonCode = JOrg.Code;
                            txtExportCode.Text = JOrg.Code.ToString();
                            labDeadName.Text = JOrg.Name + "  " + JOrg.RegisterNo + "  " + JOrg.CommercialCode;
                            labDeadshsh.Text =  JOrg.Subject;
                    //JOrg.Managing_Director.ToString() + "  " +
                        }
                        else
                            JMessages.Error("OrganizationCodeNotFound", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }   
        }
  }
}
