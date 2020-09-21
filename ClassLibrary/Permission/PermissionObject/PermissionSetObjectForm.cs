using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace ClassLibrary
{
    public partial class JPermissionSetObjectForm : JBaseForm
    {

        private JPermissionObject _PermissionObject;
        public JPermissionSetObjectForm(JPermissionObject pPermission)
        {
            InitializeComponent();
            _PermissionObject = pPermission;
            
            //JPermissionDecision[] TempP = pPermission.GetPermissions();
            //foreach (JPermissionDecision Item in TempP)
            //{
            //    ActioncheckedListBox.Items.Add(Item, false);
            //}
            Employment.JEOrganizationChart[] TempU = pPermission.GetUsersPost();
            foreach (Employment.JEOrganizationChart Item in TempU)
            {
                UserlistBox.Items.Add(Item);
            }
        }

        private void InsertUserbutton_Click(object sender, EventArgs e)
        {
            string[] Temp = _PermissionObject.ClassName.Split('.');
            JUsersListForm userform = new JUsersListForm(Temp[0]);
            userform.ShowDialog();
        }

        private void Applybutton_Click(object sender, EventArgs e)
        {

        }

        private void JPermissionSetObjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
