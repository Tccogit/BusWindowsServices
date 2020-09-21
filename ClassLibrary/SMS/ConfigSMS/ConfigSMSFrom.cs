using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMmCtlLib;

namespace ClassLibrary
{
    public partial class JConfigSMSFrom : JBaseForm
    {

         private Gsm objGsm;
        private SmsConstants objSmsConstants;

        public JConfigSMSFrom()
        {
            InitializeComponent();
            objGsm = new GsmClass();
            objSmsConstants = new SmsConstantsClass();
        }      

        private void JConfigSMS_Load(object sender, EventArgs e)
        {
            string strDevice, strPort;

            //txtLogFile.Text = Path.GetTempPath() + "GsmLog.txt";
            //objGsm.LogFile = txtLogFile.Text;

            // Fill devices Combo
            cbxDevices.Items.Clear();

            // Gets first TAPI device
            strDevice = objGsm.FindFirstDevice();
            while (objGsm.LastError == 0)
            {
                cbxDevices.Items.Add(strDevice);
                // Gets next TAPI device.
                strDevice = objGsm.FindNextDevice();
            }

            // Add COM ports.
            // Gets first COM port            
            strPort = objGsm.FindFirstPort();
            while (objGsm.LastError == 0)
            {
                cbxDevices.Items.Add(strPort);
                // Gets next COM port
                strPort = objGsm.FindNextPort();
            }

            if (cbxDevices.Items.Count > 0)
            {
                cbxDevices.SelectedIndex = 0;
            }
            else
            {
                // Remove previous text from cbx (happens when a user reopens this forms 
                // and removed all devices and COM ports)
                cbxDevices.Text = string.Empty;
            }

            //Fill deviceSpeed combo
            //cbxDeviceSpeed.Items.Clear();
            //cbxDeviceSpeed.Items.Add("Default");
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_110);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_300);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_600);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_1200);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_2400);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_4800);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_9600);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_14400);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_19200);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_38400);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_56000);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_57600);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_64000);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_115200);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_128000);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_230400);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_256000);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_460800);
            //cbxDeviceSpeed.Items.Add(objSmsConstants.GSM_BAUDRATE_921600);
            cbxDeviceSpeed.SelectedIndex = 0;

            //lvSentMessages.Columns.Clear();
            //lvSentMessages.Columns.Add("Time", 60, HorizontalAlignment.Left);
            //lvSentMessages.Columns.Add("Reference", 60, HorizontalAlignment.Left);
            //lvSentMessages.Columns.Add("Recipient", 90, HorizontalAlignment.Left);
            //lvSentMessages.Columns.Add("Status", 100, HorizontalAlignment.Left);
            //lvSentMessages.Columns.Add("Message", 200, HorizontalAlignment.Left);

            //lvReceivedMessages.Items.Clear();
            //lvReceivedMessages.Columns.Clear();
            //lvReceivedMessages.Columns.Add("Time", 60, HorizontalAlignment.Left);
            //lvReceivedMessages.Columns.Add("Sender", 90, HorizontalAlignment.Left);
            //lvReceivedMessages.Columns.Add("Message", 300, HorizontalAlignment.Left);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JConfigSMS tmpConfig = new JConfigSMS();
            tmpConfig.PinCode = txtPincode.Text;
            tmpConfig.ServerName = txtServerName.Text;
            tmpConfig.PortName = cbxDevices.Text;
            tmpConfig.Speed = cbxDeviceSpeed.Text;
            tmpConfig.BodyType = cbxBodyType.Text;
            if (tmpConfig.Insert() > 0)
                JMessages.Information(" Insert Successfully","");
            else
                JMessages.Error(" Insert Not Successfully", "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void btnWapPush_Click(object sender, EventArgs e)
        //{
        //    frmDataWap objFrmDataWap = new frmDataWap();
        //    if (objFrmDataWap.ShowDialog() == DialogResult.OK)
        //    {
        //        //Set bodytype to Data(UDH)
        //        cbxBodyType.SelectedIndex = 3;
        //        txtMessage.Text = objFrmDataWap.WAPCoding;
        //    }
        //}

        //private void btnSendOptions_Click(object sender, EventArgs e)
        //{
        //    frmSendOptions objFrmSendOptions = new frmSendOptions();
        //    objFrmSendOptions.ShowDialog();
        //}

    }
}
