using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Touchless.Vision.Camera;

namespace ClassLibrary.WebCam
{
    public partial class GetWebCam : Form
    {

        JWebCam webcam;
        public Bitmap current;
        public GetWebCam()
        {
            InitializeComponent();
        }

        public GetWebCam(int pCaptureWidth, int pCaptureHeight, int pFps)
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            webcam = new JWebCam();
            webcam.InitializeWebCam(ref imgVideo);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcam.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void startCapturing()
        {
        }

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
        }

        private Bitmap ScaleImage(Bitmap pImage, int pnewWidth, int pnewHeight)
        {
            return null;
        }

        public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        {
        }

        private void setFrameSource(CameraFrameSource cameraFrameSource)
        {
        }

        private void thrashOldCamera()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            current = JHelper.SaveImageCapture(imgVideo.Image);
            Close();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntVideoSource_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }
    }
}
