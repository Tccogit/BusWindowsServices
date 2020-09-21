//-----------------------------------------------------------------------
// <copyright file="frmSendOptions.cs" company="ActiveXperts">
//     Copyright (c) ActiveXperts Software - www.activexperts.com
// </copyright>
// <author>Dennis van de Giessen</author>
//-----------------------------------------------------------------------
namespace ClassLibrary
{
    using System;
    using System.Windows.Forms;
    using AxMmCtlLib;

    public partial class frmSendOptions : Form
    {
        private SmsConstants objSmsConstants = new SmsConstants();
        private bool bImmediateDisplay = false, bDeliveryReport = true;
        private int nMultipart;

        #region Properties
        public int MultiPart
        {
            get { return nMultipart; }
        }

 

        public bool ImmediateDisplay
        {
            get { return bImmediateDisplay; }
        }

        public bool DeliveryReport
        {
            get { return bDeliveryReport; }
        }        
        #endregion

        public frmSendOptions()
        {
            InitializeComponent();
            cbxMultipart.SelectedIndex = 0;
            nMultipart = objSmsConstants.MULTIPART_OK;
        }

        private void frmSendOptions_Load(object sender, EventArgs e)
        {
            cbxMultipart.SelectedIndex = nMultipart;
            rbImmediateDisplay.Checked = bImmediateDisplay;
            rbDeliveryReport.Checked = bDeliveryReport;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxMultipart.Text == "OK")
            {
                nMultipart = objSmsConstants.MULTIPART_OK;
            }
            else if (cbxMultipart.Text == "Truncate")
            {
                nMultipart = objSmsConstants.MULTIPART_TRUNCATE;
            }
            else if (cbxMultipart.Text == "Error")
            {
                nMultipart =objSmsConstants.MULTIPART_ERROR;
            }

            bImmediateDisplay = rbImmediateDisplay.Checked;
            bDeliveryReport = rbDeliveryReport.Checked;
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
