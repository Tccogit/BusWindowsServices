using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals.Property;

namespace ClassLibrary
{
    public partial class JFormObjectsForm : JBaseForm
    {
        public int FormStatus = 0;
        public int _FormCode, _ObjectCode, _ValueObjectCode;
        public string _ClassName;
        public const string _ConstClassName = "ClassLibrary.FormManagers";

        public JFormObjectsForm(string className, int objectCode)
        {
            InitializeComponent();
            _ObjectCode = objectCode;
            _ClassName = "Form." + className;

            SetForm();
        }

        private void SetForm()
        {
            lstForms.DataSource = (new ClassLibrary.JForms()).GetDataTable(_ClassName);
            lstForms.DisplayMember = "FormName";
            lstForms.ValueMember = "Code";
        }

        private void GetFormObjects()
        {
            GetFormObjects(_FormCode);
        }
        private void GetFormObjects(int formCode)
        {
            _FormCode = formCode;
            dgrObjects.ActionClassName = "FormManagers_" + formCode.ToString() + "_" + JMainFrame.CurrentUserCode.ToString() + "_" + JMainFrame.CurrentPostCode.ToString();
            dgrObjects.hasRealClassName = false;
            DataTable dt = (new JFormObjects()).GetObjectTable(_FormCode, _ObjectCode);
            dgrObjects.DataSource = null;
            dgrObjects.DataSource = dt;
            //dgrObjects.LoadCustomize();
            //dgrObjects.Refresh();

        }

        private void JDataPropertyForm_Load(object sender, EventArgs e)
        {
            dgrObjects.gridEX1.MouseDoubleClick += new MouseEventHandler(gridEX1_MouseDoubleClick);
        }

        void gridEX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgrObjects.gridEX1.GetRows().Count() == 0) return;
            int currentIndex = dgrObjects.gridEX1.SelectedItems[0].Position;
            (new FormObjectViewForm(_ClassName, _FormCode, _ObjectCode, (int)dgrObjects.SelectedRow["ObjectCode"])).ShowDialog();
            GetFormObjects();
            if (dgrObjects.gridEX1.GetRows().Count() > currentIndex) dgrObjects.gridEX1.MoveTo(currentIndex);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
			try
			{
				if (lstForms.SelectedItem == null)
					return;
				_FormCode = lstForms.SelectedValue == null ? 0 : Convert.ToInt32(lstForms.SelectedValue);
				(new FormObjectViewForm(_ClassName, _FormCode, _ObjectCode)).ShowDialog();
				GetFormObjects();
				if (JMessages.Message("آیا میخواهید " + (lstForms.SelectedItem as DataRowView).Row["FormName"].ToString() + " جدیدی ثبت کنید؟", "", JMessageType.Question) == DialogResult.Yes)
					btnNew_Click(sender, e);
			}
			catch
			{
			}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gridEX1_MouseDoubleClick(null, null);
        }

        private void lstForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstForms.SelectedValue.GetType() != typeof(int)) return;
            GetFormObjects(lstForms.SelectedValue == null ? 0 : Convert.ToInt32(lstForms.SelectedValue));
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgrObjects.gridEX1.GetRows().Count() == 0) return;
            DataTable dt = (new Automation.JARefer()).FindReferByObjectcode(Convert.ToInt32(dgrObjects.SelectedRow["ObjectCode"]), _ConstClassName);
            if (dt != null)
                if (dt.Rows.Count > 0 && CanDeleteFormObjectCompletely())
                {
                    if (JMessages.Question("برای این فرم " + dt.Rows.Count.ToString() + " ارجاع وجود دارد، آیا مطمئن هستید؟", "حذف") == DialogResult.Yes)
                    {
                        (new Automation.JARefer()).DeleteObjectAndRefers(_ConstClassName,_FormCode,(int)dgrObjects.SelectedRow["ObjectCode"]);
                        JFormObjects jFormObjects = new JFormObjects((int)dgrObjects.SelectedRow["ObjectCode"]);
                        jFormObjects.Delete();
                        ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                        jArchDoc.DeleteArchive(_ConstClassName, (int)dgrObjects.SelectedRow["ObjectCode"], true);
                        lstForms_SelectedIndexChanged(null, null);
                    }
                    return;
                }
                else if (dt.Rows.Count > 0)
                {
                    JMessages.Error("فرم ارجاع داده شده قابل حذف نیست.", "حذف");
                    return;
                }

            if (JMessages.Question("آیا از حذف این آیتم مطمئن هستید؟", "حذف") == DialogResult.Yes)
            {
                JFormObjects jFormObjects = new JFormObjects((int)dgrObjects.SelectedRow["ObjectCode"]);
                jFormObjects.Delete();
                ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                jArchDoc.DeleteArchive(_ConstClassName, (int)dgrObjects.SelectedRow["ObjectCode"], true);
                lstForms_SelectedIndexChanged(null, null);
            }
        }

        public bool CanDeleteFormObjectCompletely()
        {
            if (JPermission.CheckPermission("ClassLibrary.JFormObjectsForm.CanDeleteFormObjectCompletely"))
                return true;
            return false;
        }

        private void lstForms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnNew_Click(null, null);
        }
    }
}
