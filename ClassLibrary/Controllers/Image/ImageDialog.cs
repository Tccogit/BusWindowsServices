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
    public partial class JImageDialog : UserControl
    {
        /// <summary>
        /// انواع منبع فایل تصویری
        /// </summary>
        public enum JImageSourceTypes
        {
            FormFile, FromScaner, FromArchive
        }

        #region Properties

        /// <summary>
        /// فایل اسکن شده یا انتخاب شده
        /// </summary>
        private JFile[] _SelectedFile;
        public JFile[] SelectedFile
        {
            get { return _SelectedFile; }
            set { _SelectedFile = value; }
        }
        /// <summary>
        /// نوع فایل - از اسکنر یا از فایل
        /// </summary>
        private JImageSourceTypes _ImageSource;
        private System.IO.MemoryStream _Stream;

        public int CurrentIndex = -1;
        private PictureBox CurrentPictureBox;
        /// <summary>
        /// تصویر برگردانده شده
        /// </summary>
        public Image SelectedImage
        {
            get
            {
                if (CurrentIndex > -1)
                {
                    if (_ImageSource == JImageSourceTypes.FormFile)
                        return (Image.FromFile(SelectedFile[CurrentIndex].FileName));
                    else if (_ImageSource == JImageSourceTypes.FromScaner)
                    {
                        if (_Stream != null)
                            return Image.FromStream(_Stream);
                    }
                }
                return null;
            }
        }
        #endregion Properties

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        public JImageDialog()
        {
            InitializeComponent();

        }

        public void Free()
        {
            //for (int i = 0; i < _SelectedFile.Length; i++)
            //{
            //    _SelectedFile[i].Dispose();
            //}
            //if (_Stream != null)
            //    _Stream.Dispose();
            foreach (TabPage tp in tabControlImages.TabPages)
            {
                try
                {
                    (tp.Tag as PictureBox).Image.Dispose();
                    (tp.Tag as PictureBox).Image = null;
                    (tp.Tag as PictureBox).Dispose();
                }
                catch
                {
                }
            }
        }

        private void CreateTab(string pTabName)
        {
            CreateTab(pTabName, null);
        }

        private void CreateTab(string pTabName, System.IO.MemoryStream pMemoryStream)
        {
            try
            {
                TabPage TP = new TabPage(pTabName);

                PictureBox PB = new PictureBox();
                TP.Controls.Add(PB);
                PB.Dock = DockStyle.Fill;

                tabControlImages.TabPages.Add(TP);
                tabControlImages.SelectedTab = TP;
                TP.Show();
                if (pMemoryStream == null)
                    PB.Load(pTabName);
                else
                    PB.Image = Image.FromStream(pMemoryStream);

                object tObject = PB.Image;
                JSystem.AddObject(ref tObject);
                
                TP.Tag = PB;
                CurrentIndex = tabControlImages.SelectedIndex;
            }
            catch
            {
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string _FileName in openFileDialog1.FileNames)
                    {

                        CreateTab(_FileName);

                        if (this.SelectedFile == null)
                            this.SelectedFile = new JFile[0];
                        Array.Resize(ref _SelectedFile, this.SelectedFile.Length + 1);
                        CurrentIndex = SelectedFile.Length - 1;

                        _ImageSource = JImageSourceTypes.FormFile;

                        this.SelectedFile[CurrentIndex] = new JFile(JFileTypes.Image);
                        this.SelectedFile[CurrentIndex].FileSource = JFile.JFileSource.FromDisk;
                        this.SelectedFile[CurrentIndex].FileName = _FileName;
                    }
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    //ImageBox.Image = null;
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.jfrmScanMain obj = new ClassLibrary.jfrmScanMain();
                if (obj.ShowDialog() == DialogResult.OK)
                {
                    if (this.SelectedFile == null)
                        this.SelectedFile = new JFile[0];

                    int _LastIndexImage = this.SelectedFile.Length - 1;

                    Array.Resize(ref _SelectedFile, this.SelectedFile.Length + obj.ScanFiles.Length);
                    foreach (jfrmScanMain.Scan Scan in obj.ScanFiles)
                    {
                        _LastIndexImage++;
                        this.SelectedFile[_LastIndexImage] = new JFile(JFileTypes.Image);

                        byte[] Content = Scan.content;
                        Byte[] byteRoy = new Byte[0];
                        byteRoy = Content;
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteRoy);

                        object tObject = stream;
                        JSystem.AddObject(ref tObject);

                        if (Content != null)
                        {
                            CreateTab("ImageScan" + _LastIndexImage.ToString(), stream);
                            _ImageSource = JImageSourceTypes.FromScaner;
                            this.SelectedFile[_LastIndexImage].Content = byteRoy;
                            this.SelectedFile[_LastIndexImage].FileSource = JFile.JFileSource.FromMemory;
                            this.SelectedFile[_LastIndexImage].Extension = ".jpg";
                            _Stream = stream;
                        }
                    }
                    obj.Free();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void chStretch_CheckedChanged(object sender, EventArgs e)
        {
            if (chStretch.Checked)
            {
                CurrentPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
                CurrentPictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void btnZomIn_Click(object sender, EventArgs e)
        {
            if (CurrentPictureBox != null)
            {
                if (CurrentPictureBox.SizeMode == PictureBoxSizeMode.Normal)
                    CurrentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                CurrentPictureBox.Height += ((int)CurrentPictureBox.Size.Height * 20 / 100);
                CurrentPictureBox.Width += (int)CurrentPictureBox.Size.Width * 20 / 100;
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (CurrentPictureBox != null)
            {
                if (CurrentPictureBox.SizeMode == PictureBoxSizeMode.Normal)
                    CurrentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                CurrentPictureBox.Height -= (int)CurrentPictureBox.Size.Height * 20 / 100;
                CurrentPictureBox.Width -= (int)CurrentPictureBox.Size.Width * 20 / 100;
            }

        }

        private void tabControlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPictureBox = (tabControlImages.SelectedTab.Tag as PictureBox);
        }

        private void tbnWebCam_Click(object sender, EventArgs e)
        {
            //ClassLibrary.WebCam.GetWebCam FWeb = new ClassLibrary.WebCam.GetWebCam();
            ClassLibrary.WebCam.WebCam FWeb = new ClassLibrary.WebCam.WebCam();
            FWeb.ShowDialog();
            if (FWeb.current != null)
            {
                try
                {
                    Image img = Image.FromHbitmap(FWeb.current.GetHbitmap());
                    string _FileName = System.IO.Path.GetTempPath() + "webcam.jpg";
                    System.IO.File.Delete(_FileName);
                    img.Save(_FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.Dispose();
                    CreateTab(_FileName);
                    
                    if (this.SelectedFile == null)
                        this.SelectedFile = new JFile[0];
                    Array.Resize(ref _SelectedFile, this.SelectedFile.Length + 1);
                    CurrentIndex = SelectedFile.Length - 1;

                    _ImageSource = JImageSourceTypes.FormFile;

                    this.SelectedFile[CurrentIndex] = new JFile(JFileTypes.Image);
                    this.SelectedFile[CurrentIndex].FileSource = JFile.JFileSource.FromDisk;
                    this.SelectedFile[CurrentIndex].FileName = _FileName;
                    
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    //ImageBox.Image = null;
                }
            }

        }



    }
}
