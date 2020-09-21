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
    public partial class JConfigForm : Form
    {
        public JConfigForm()
        {
            InitializeComponent();
            LoadConfig();
        }
        private void LoadConfig()
        {
            if (JGlobal.MainFrame == null)
                return;
            JConfig BConfig = new JConfig();
            txtDbNametextBox.Text = BConfig.Database;
            txtPasswordtextBox.Text = BConfig.Password;
            txtServerNametextBox.Text = BConfig.Server;
            txtWebServerNametextBox.Text = BConfig.WebServer;
            txtUserNametextBox.Text = BConfig.Username;

            txtSmDB.Text = BConfig.DatabaseSaham;
            txtSmPassword.Text = BConfig.PasswordSaham;
            txtSmServer.Text = BConfig.ServerSaham;
            txtSmUserName.Text = BConfig.UsernameSaham;

            txtMaxLengthList.Text = BConfig.MaxLenghList.ToString();
            txtPersonSahamTable.Text = BConfig.PersonSahamTableName;
            txtSheetSaham.Text = BConfig.SheetSahamTableName;
            txtCurrentLang.Text = BConfig.CurrentLang;
            rbWindows.Checked = BConfig.IntegratedSecurity;
            txtSahamWebSite.Text = BConfig.SahamWebConfig;

            ImageAddresstextBox.Text = BConfig.BaseFileAddress;
            txtBascolFileName.Text = BConfig.TimeLogin.ToString();
            jucCompanyDefault.SelectedCode = BConfig.CompanyDefault;

            txtDbNametextBoxArchive.Text = BConfig.DatabaseArchive;
            txtServerNametextBoxArchive.Text = BConfig.ServerArchive;
            txtUserNametextBoxArchive.Text = BConfig.UsernameArchive;
            txtPasswordtextBoxArchive.Text = BConfig.PasswordArchive;
            txtLDAP.Text = BConfig.LDAPServer;
            txtDomainName.Text = BConfig.DomainName;
            txtDayChangePassword.Text = BConfig.MaxDaysPassCheck.ToString();


            RBGSMModem.Checked= (BConfig.SMSSendType == JSMSSendType.GSM);
            RBWebServiceSend.Checked= (BConfig.SMSSendType == JSMSSendType.WebService);
        }

        private void ApplyChanges()
        {
            JConfig BConfig = new JConfig();

            BConfig.Database = txtDbNametextBox.Text;
            BConfig.Server = txtServerNametextBox.Text;
            BConfig.WebServer = txtWebServerNametextBox.Text;
            BConfig.Username = txtUserNametextBox.Text;
            BConfig.Password = txtPasswordtextBox.Text;

            BConfig.DatabaseSaham = txtSmDB.Text;
            BConfig.ServerSaham = txtSmServer.Text;
            BConfig.UsernameSaham = txtSmUserName.Text;
            BConfig.PasswordSaham = txtSmPassword.Text;

            BConfig.MaxLenghList = Convert.ToInt32(txtMaxLengthList.Text);
            BConfig.PersonSahamTableName = txtPersonSahamTable.Text;
            BConfig.SheetSahamTableName = txtSheetSaham.Text;
            BConfig.CurrentLang = txtCurrentLang.Text;
            BConfig.IntegratedSecurity = rbWindows.Checked;
            BConfig.BaseFileAddress = ImageAddresstextBox.Text;
            BConfig.SahamWebConfig = txtSahamWebSite.Text;
            BConfig.TimeLogin = txtBascolFileName.IntValue;
            BConfig.CompanyDefault = Convert.ToInt32(jucCompanyDefault.SelectedCode);

            BConfig.DatabaseArchive = txtDbNametextBoxArchive.Text;
            BConfig.ServerArchive = txtServerNametextBoxArchive.Text;
            BConfig.UsernameArchive = txtUserNametextBoxArchive.Text;
            BConfig.PasswordArchive = txtPasswordtextBoxArchive.Text;
            BConfig.LDAPServer = txtLDAP.Text;
            BConfig.DomainName = txtDomainName.Text;
            try {
                BConfig.MaxDaysPassCheck = int.Parse(txtDayChangePassword.Text);
            }
            catch
            { }

            if (RBGSMModem.Checked)
                BConfig.SMSSendType = JSMSSendType.GSM;
            else
                if (RBWebServiceSend.Checked)
                    BConfig.SMSSendType = JSMSSendType.WebService;


            BConfig.SaveToFile();
        }
        private void OKbutton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            DialogResult = DialogResult.OK;
        }

        private void Applybutton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Applybutton.Enabled = false;
        }

        private void txtServerNametextBox_TextChanged(object sender, EventArgs e)
        {
            Applybutton.Enabled = true;
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            UserNamelabel.Enabled = !rbWindows.Checked;
            Passwordlabel.Enabled = !rbWindows.Checked;
            txtUserNametextBox.Enabled = !rbWindows.Checked;
            txtPasswordtextBox.Enabled = !rbWindows.Checked;
        }

        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            UserNamelabel.Enabled = rbSQL.Checked;
            Passwordlabel.Enabled = rbSQL.Checked;
            txtUserNametextBox.Enabled = rbSQL.Checked;
            txtPasswordtextBox.Enabled = rbSQL.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = ImageAddresstextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                ImageAddresstextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
          if(JConfig.AddDateToStaticDate(txtDateIn.Date,txtDateOut.Date))
            MessageBox.Show("عملیات با موفقیت انجام شد","توجه");
          else
              MessageBox.Show("درج با خطا مواجه شد","هشدار");
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                if (db.Connect())
                {
                    JMessages.Error("OK! connected :)", "Connect to database");
                }
                else
                {
                    JMessages.Error("Can not connected! :(", "Connect to database");
                }
            }
            finally
            {
                db.Dispose();
            }
        }

        private void txtBascolFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            JDataBase db = new JDataBase();
            try
            {
                if (db.Connect())
                {
                    JMessages.Error("OK! connected :)", "Connect to database");
                }
                else
                {
                    JMessages.Error("Can not connected! :(", "Connect to database");
                }
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
