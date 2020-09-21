//-----------------------------------------------------------------------
// <copyright file="frmGsmReceiveOptions.cs" company="ActiveXperts">
//     Copyright (c) ActiveXperts Software - www.activexperts.com
// </copyright>
// <author>Dennis van de Giessen</author>
//-----------------------------------------------------------------------
namespace ClassLibrary
{
    using System;
    using System.Windows.Forms;
    using AxMmCtlLib;

    public partial class frmGsmReceiveOptions : Form
    {
        private int nMessageStorage;
        private bool bDeleteAfterReceive;
        private SmsConstants objSmsConstants;

        #region Properties
        public int MessageStorage
        {
            get { return nMessageStorage; }
        }

        public bool DeleteAfterReceive
        {
            get { return bDeleteAfterReceive; }
        }
        #endregion

        public frmGsmReceiveOptions()
        {
            InitializeComponent();
            objSmsConstants = new SmsConstants();
            nMessageStorage = objSmsConstants.GSM_STORAGETYPE_ALL;
            bDeleteAfterReceive = false;

            cbxMessageStorage.Items.Add("ALL - All available");
            cbxMessageStorage.Items.Add("SM - SIM memory only");
            cbxMessageStorage.Items.Add("ME - Device memory only");
            cbxMessageStorage.SelectedIndex = 0;
        }

        private void frmGsmReceiveOptions_Load(object sender, EventArgs e)
        {
            cbDeleteAfterReceive.Checked = bDeleteAfterReceive;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxMessageStorage.SelectedIndex == 0)
            {
                nMessageStorage = objSmsConstants.GSM_STORAGETYPE_ALL;
            }
            else if (cbxMessageStorage.SelectedIndex == 1)
            {
                nMessageStorage = objSmsConstants.GSM_STORAGETYPE_SIM;
                
            }
            else if (cbxMessageStorage.SelectedIndex == 2)
            {
                nMessageStorage = objSmsConstants.GSM_STORAGETYPE_MEMORY;
            }

            bDeleteAfterReceive = cbDeleteAfterReceive.Checked;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
