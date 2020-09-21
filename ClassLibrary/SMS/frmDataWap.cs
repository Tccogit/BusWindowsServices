//-----------------------------------------------------------------------
// <copyright file="frmDataWap.cs" company="ActiveXperts">
//     Copyright (c) ActiveXperts Software - www.activexperts.com
// </copyright>
// <author>Dennis van de Giessen</author>
//-----------------------------------------------------------------------
namespace ClassLibrary
{
    using System;
    using System.Windows.Forms;
    using AxMmCtlLib;

    public partial class frmDataWap : Form
    {
        SmsDataWapPushClass objWapPush;

        private string strWAPCoding;

        #region Properties
        public string WAPCoding
        {
            get { return strWAPCoding; }
        }
        #endregion

        public frmDataWap()
        {
            InitializeComponent();
            objWapPush = new SmsDataWapPushClass();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            objWapPush.Url = txtURL.Text;
            objWapPush.Description = txtLinkTitle.Text;
            objWapPush.Encode();

            if (objWapPush.LastError != 0)
            {
                MessageBox.Show("Error #" + objWapPush.LastError + " while encoding wap push data: " + objWapPush.GetErrorDescription(objWapPush.LastError));
                return;
            }

            strWAPCoding = objWapPush.Data;
            DialogResult =  DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
