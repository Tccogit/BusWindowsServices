using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class JUC_AttachmentManager : UserControl
    {

        // ویژگی ها  و فیلد ها
        #region peroperties,fields
        public JCOfficeWord WordDocument = new JCOfficeWord();
        // بمنظور مدیریت فایل های ورد باز شده جهت ویرایش این آرایه تمام آنها را نگهداری میکند
        public JCOfficeWord[] WordUpdateDocument = new JCOfficeWord[0];
        /// <summary>
        /// مشخصات یه ضمیمه
        /// </summary>
        public struct Attachment
        {
            public int Code;
            public string FileName;
            public string FileTitle;
            public int FileType;
            public byte[] FileContent;
            public string FileText;
            public bool Is_Main_File;
            public int other_file_type;
            public int previous_version_code;
            public bool Is_New;
        }

        class Icons
        {
            public static int Word_Is_Not_Main_File = 0;
            public static int Other_File_Is_Not_Main_File = 1;
            public static int Scan_Is_Not_Main_File = 2;            
            public static int Word_Is_Main_File = 3;
            public static int Other_File_Is_Main_File = 4;
            public static int Scan_Is_Main_File = 5;
        }

        #endregion peroperties,fields
        // سازنده ها
        #region Constructors
        public JUC_AttachmentManager()
        {
            InitializeComponent();
        }
        #endregion Constructors
        // توابع نوشته شده
        #region MyFunction


        /// <summary>
        /// بدست آوردن بالاترین کد در بین فایل های موجود
        /// </summary>
        /// <returns></returns>
        private int GetNextID()
        {
            int max = 0;
            for (int i = 0; i < lstvFiles.Items.Count; i++)
            {                    
                    if (((Attachment)lstvFiles.Items[i].Tag).Code > max)
                    {
                        max = ((Attachment)lstvFiles.Items[i].Tag).Code;
                    }
            }
            return max + 1;
        }

        /// <summary>
        /// خواندن فایل بصورت باینری
        /// </summary>
        /// <param name="fileName">نام فایل</param>
        /// <returns>فایل باینری شده</returns>
        public byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        /// <summary>
        /// انتخاب فایل ورد جدید و خالی
        /// </summary>
        private void SelectNewEmptyFileWord()
        {
            WordDocument = new JCOfficeWord();
            WordDocument.BeforSave += new EventHandler(Word_BeforSave);  
            WordDocument.New();
        }

        /// <summary>
        /// انتخاب فایل ورد آماده
        /// </summary>
        private void SelectExistFileWord()
        {
            JCOfficeWord.DocumentWord _DocumentWord;
            _DocumentWord.FileContent = "";
            _DocumentWord.FileText = "";
            try
            {
                if (odlSelectPatternFile.ShowDialog() == DialogResult.OK)
                {
                    if (odlSelectPatternFile.CheckPathExists)
                    {
                        Word._Document oDoc;
                        Word.Application oWord = new Word.Application();
                        oWord.Visible = false;
                        Object file = odlSelectPatternFile.FileName;
                        Object oMissing = System.Reflection.Missing.Value;
                        oDoc = oWord.Documents.Open(ref file, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing,
                                                ref oMissing);
                        _DocumentWord.FileContent = oDoc.Content.WordOpenXML;
                        _DocumentWord.FileText = oDoc.Content.Text;
                        if (_DocumentWord.FileContent != "")
                        {
                            WordDocument = new JCOfficeWord();
                            WordDocument.BeforSave += new EventHandler(Word_BeforSave);  
                            WordDocument.NewFromExistingFile(_DocumentWord.FileContent, _DocumentWord.FileText);
                        }
                        oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
                    }
                }
            }
            catch (Exception ex)
            {
                JMessages.Message(JLanguages._Text("Invalid File Content"), JLanguages._Text("Error"), ClassLibrary.JMessageType.Error);
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// قبل از ذخیره ورد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Word_BeforSave(object sender, EventArgs e)
        {
            if (WordDocument.File.FileContent != null)
            {
                ListViewItem ltvItem = new ListViewItem();
                Attachment attach;
                
                //attach.Code = GetNextID();
                //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                GetNextID degGetNextID = new GetNextID(GetNextID);
                attach.Code = Convert.ToInt32(this.Invoke(degGetNextID));
                //-------------------------------------------------------
                attach.FileTitle = "فایل ورد";
                attach.FileName = "Word.Docx";
                attach.FileType = ClassLibrary.Domains.JCommunication.JFileType.word;
                attach.FileContent = System.Text.Encoding.ASCII.GetBytes(WordDocument.File.FileContent); 
                attach.FileText = WordDocument.File.FileText;
                attach.Is_Main_File = true;
                attach.other_file_type = 0;
                attach.previous_version_code = 0;
                attach.Is_New = true;

                ltvItem.Text = attach.FileTitle;
                ltvItem.ImageIndex = Icons.Word_Is_Main_File;
                ltvItem.Group = lstvFiles.Groups["lvgWord"];
                ltvItem.Tag = attach;
                if (WordDocument.State == JCOfficeWord.JDocumentState.New)
                {
                    
                    //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                    AddItem degAddToList = new AddItem(AddToList);
                    this.Invoke(degAddToList, ltvItem);
                    //-------------------------------------------------------
                }
                else
                {                   
                    //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                    IS_OldFile degIS_OldFile = new IS_OldFile(IS_OldFile);
                    bool Is_Exist = Convert.ToBoolean(this.Invoke(degIS_OldFile, ((JCOfficeWord)sender).Code));
                    // در صورتی که این فایل قبلا در بانک ذخیره شده باشد فایل جدید ثبت میشود
                    if (Is_Exist)
                    {
                        attach.previous_version_code = ((JCOfficeWord)sender).Code;
                        ltvItem.Tag = attach;
                        //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                        AddItem degAddToList = new AddItem(AddToList);
                        this.Invoke(degAddToList, ltvItem);
                        //-------------------------------------------------------
                    }
                    else
                    {
                        attach.Code = ((JCOfficeWord)sender).Code;
                        ltvItem.Tag = attach;
                        //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                        UpdateItem degUpdateToList = new UpdateItem(UpdateList);
                        this.Invoke(degUpdateToList, ltvItem);
                        //-------------------------------------------------------
                    }
                }
            }

        }

        /// <summary>
        /// قبل از ذخیره ورد که برای ویرایش باز شده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Word_BeforUpdateSave(object sender, EventArgs e)
        {
            bool find = false;
            // جستجو برای آنکه مشخص شود وردی که برای ویرایش باز شده قبل از ویرایش
            for (int i = 0; i < WordUpdateDocument.Length; i++)
            {
                if (WordUpdateDocument[i] != null && WordUpdateDocument[i].Code == ((JCOfficeWord)(sender)).Code)
                {
                    // هر کدام از فایل های وردی که باز می شود رویدادی جهت منتظر ماندن برای ذخیره آن فایل ایجاد می شود
                    //WordDocument = (Communication.JCOfficeWord)(sender);
                    //WordDocument.BeforSave += new EventHandler(Word_BeforSave);
                    WordDocument.State = JCOfficeWord.JDocumentState.Update;
                    find = true;
                    WordDocument = WordUpdateDocument[i];
                    Array.Resize(ref WordUpdateDocument, WordUpdateDocument.Length - 1);
                    break;
                }
            }
           
            if (find)
            {
                Word_BeforSave(sender, e);
            }
            //---------------------------------جهت حذف از آرایه فایل های باز آخری رو روی جاری کپی و سپس آخری را حذف می کنیم----------------------------
            
        }

        /// <summary>
        /// مشخص می کند که آیا این ضمیمه قبلا در جدول بانک ذخیره شده یا خیر
        /// </summary>
        /// <param name="pCode">کد ضمیمه</param>
        /// <returns>bool</returns>
        private bool IS_OldFile(int pCode)
        {
            for (int i = 0; i < lstvFiles.Items.Count; i++)
            {
                Attachment attach = ((Attachment)lstvFiles.Items[i].Tag);
                if (attach.Code == pCode)
                {
                    if (attach.Is_New)
                        return false;
                    else
                    {
                        lstvFiles.Items[i].Remove();
                        return true;
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// افزودن آیتم جدید به لیست
        /// </summary>
        private void AddToList(ListViewItem ltvItem)
        {       
            lstvFiles.Items.Add(ltvItem);
            lstvFiles.Refresh();
            lstvFiles.Items[lstvFiles.Items.Count - 1].BeginEdit();
        }

        /// <summary>
        /// ویرایش آیتم لیست
        /// </summary>
        private void UpdateList(ListViewItem ltvItem)
        {
            for (int i = 0; i < lstvFiles.Items.Count; i++)
            {
                if (((Attachment)lstvFiles.Items[i].Tag).Code == ((Attachment)ltvItem.Tag).Code)
                {
                    lstvFiles.Items[i].Tag = ltvItem.Tag;
                    break;
                }
            }
            lstvFiles.Refresh();
        }

        /// <summary>
        /// تنظیم زیرمنوی ها
        /// </summary>
        private void _setContextMenu()
        {
            //-----------------------تنظیم زیرمنوی الگوها ---------------------
            JCPatternFiles pattern = new JCPatternFiles();
            for (int i = 0; i < pattern.Items.Length; i++)
            {
                tsmPattern.DropDownItems.Add(pattern.Items[i].Name);
                tsmPattern.DropDownItems[tsmPattern.DropDownItems.Count - 1].Click += new EventHandler(Pattern_Click);
                tsmPattern.DropDownItems[tsmPattern.DropDownItems.Count - 1].Tag = pattern.Items[i].Pattern;
                
                tsmTopPattern.DropDownItems.Add(pattern.Items[i].Name);
                tsmTopPattern.DropDownItems[tsmTopPattern.DropDownItems.Count - 1].Click += new EventHandler(Pattern_Click);
                tsmTopPattern.DropDownItems[tsmTopPattern.DropDownItems.Count - 1].Tag = pattern.Items[i].Pattern;
            }
            //-----------------------تنظیم زیرمنوی سایر فایل ها  ---------------------
            DataTable DT = new DataTable();
            DT = (new JAttachmentTypeDefine()).GetList();
            for (int i = 0; i < DT.Rows.Count ; i++)
            {
                tsmOtherFiles.DropDownItems.Add(DT.Rows[i]["Name"].ToString());
                tsmOtherFiles.DropDownItems[tsmOtherFiles.DropDownItems.Count - 1].Click += new EventHandler(OtherFiles_Click);
                tsmOtherFiles.DropDownItems[tsmOtherFiles.DropDownItems.Count - 1].Tag = DT.Rows[i]["code"].ToString();

                tsmTopOtherFiles.DropDownItems.Add(DT.Rows[i]["Name"].ToString());
                tsmTopOtherFiles.DropDownItems[tsmTopOtherFiles.DropDownItems.Count - 1].Click += new EventHandler(OtherFiles_Click);
                tsmTopOtherFiles.DropDownItems[tsmTopOtherFiles.DropDownItems.Count - 1].Tag = DT.Rows[i]["code"].ToString();

            }
        }

        //**********************************************************
        /// <summary>
        /// نمایش فایل باینری در پانل
        /// </summary>
        /// <param name="pic">فایل بصورت باینری</param>
        /// <param name="pX">محا نمایش از سمت بالای صفحه</param>
        /// <param name="pX">محا نمایش از سمت چپ صفحه</param>
        /// <param name="pY"></param>
        private void DisplayFile(byte[] pic,int pX,int pY)
        {
            Byte[] byteRoy = new Byte[0];
            byteRoy = pic;
            MemoryStream stimRoy = new MemoryStream(byteRoy);
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            int originalW = Image.FromStream(stimRoy).Width;
            int orignalH = Image.FromStream(stimRoy).Height;
            int resizedW = (int)(originalW * .370);
            int resizedH = (int)(orignalH * .370);
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(Image.FromStream(stimRoy), 0, 0, resizedW, resizedH);
            graphic.Dispose();
            bmp.Save("RoyNew");
            picBoxThumbNill.Image = ((Image)bmp);

            if (picBoxThumbNill.Image.Width > 200 || picBoxThumbNill.Image.Height > 200)
            {
                // ------------------تنظیم تناسب کوچک کردن تصویر----------------------------
                float percent = 100;
                if (picBoxThumbNill.Image.Width > picBoxThumbNill.Image.Height)
                {
                    percent = 200 / ((float)picBoxThumbNill.Image.Width / 100);
                    pnlDisplayThumbNill.Width = 200;
                    pnlDisplayThumbNill.Height = Convert.ToInt32(Math.Round(((float)picBoxThumbNill.Image.Height / 100) * percent));
                }
                else
                {
                    percent = 200 / ((float)picBoxThumbNill.Image.Height / 100);
                    pnlDisplayThumbNill.Height = 200;
                    pnlDisplayThumbNill.Width = Convert.ToInt32(Math.Round(((float)picBoxThumbNill.Image.Width / 100) * percent));
                }

            }
            else
            {
                pnlDisplayThumbNill.Width = picBoxThumbNill.Image.Width;
                pnlDisplayThumbNill.Height = picBoxThumbNill.Image.Height;
            }

            pnlDisplayThumbNill.Top = lstvFiles.Location.X + pX;
            pnlDisplayThumbNill.Left = lstvFiles.Location.Y + pY;
            picBoxThumbNill.Refresh();
            pnlDisplayThumbNill.Visible = true;

        }
        /// <summary>
        /// فرم اسکن را فراخوانی می کند و بعد از دریافت اسکن آنها را در لیست قرار میدهد
        /// </summary>
        private void scan()
        {
            try
            {               
                ClassLibrary.jfrmScanMain obj = new ClassLibrary.jfrmScanMain();
                if (obj.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < obj.ScanFiles.Length; i++)
                    {
                        DisplayFile(obj.ScanFiles[i].content, 50, 50);
                        byte[] Content = obj.ScanFiles[i].content;
                        if (Content != null)
                        {
                            ListViewItem ltvItem = new ListViewItem();
                            Attachment attach;
                            attach.Code = GetNextID();
                            attach.FileTitle = obj.ScanFiles[i].name;
                            attach.FileName = obj.ScanFiles[i].name + ".jpg";
                            attach.FileType = ClassLibrary.Domains.JCommunication.JFileType.image;
                            attach.FileContent = Content;
                            attach.FileText = "";
                            attach.Is_Main_File = true;
                            attach.other_file_type = 0;
                            attach.previous_version_code = 0;
                            attach.Is_New = true;

                            ltvItem.Text = attach.FileTitle;
                            ltvItem.ImageIndex = Icons.Scan_Is_Main_File; // ClassLibrary.Domains.JCommunication.JFileType.other;                                        
                            ltvItem.Group = lstvFiles.Groups["lvgImage"];
                            ltvItem.Tag = attach;

                            //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                            AddItem degAddToList = new AddItem(AddToList);
                            this.Invoke(degAddToList, ltvItem);
                            //-------------------------------------------------------
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// تنطیم اطلاعات کنترل بر اساس کد نامه وارد شده
        /// </summary>
        /// <param name="pLetterCode"></param>
        public void SetData(int pLetterCode)
        {
           /* Array.Resize(ref WordUpdateDocument, 0);
            try
            {
                DataTable dt = new DataTable();
                dt = (new JCLetterAttachments()).GetAttachments(pLetterCode);
                lstvFiles.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Attachment Attach = new Attachment();
                    Attach.Code = Convert.ToInt32(dt.Rows[i]["code"]);
                    Attach.FileContent = ((byte[])dt.Rows[i]["file_content"]);
                    Attach.FileName = dt.Rows[i]["file_name"].ToString();
                    Attach.FileText = dt.Rows[i]["file_text"].ToString();
                    Attach.FileTitle = dt.Rows[i]["file_title"].ToString();
                    Attach.FileType = Convert.ToInt32(dt.Rows[i]["file_type"]);
                    Attach.Is_Main_File = Convert.ToBoolean(dt.Rows[i]["is_main_file"]);
                    if (dt.Rows[i]["other_file_type"] != null && ClassLibrary.JGeneral.is_Number(dt.Rows[i]["other_file_type"]))
                    {
                        Attach.other_file_type = Convert.ToInt32(dt.Rows[i]["other_file_type"]);
                    }
                    else
                    {
                        Attach.other_file_type = 0;
                    }
                    Attach.Is_New = false;

                    ListViewItem ltvItem = new ListViewItem();
                    ltvItem.Text = Attach.FileTitle;
                    if (Attach.FileType == ClassLibrary.Domains.JCommunication.JFileType.image)
                    {
                        ltvItem.Group = lstvFiles.Groups["lvgImage"];
                        if (Attach.Is_Main_File)
                            ltvItem.ImageIndex = Icons.Scan_Is_Main_File;
                        else
                            ltvItem.ImageIndex = Icons.Scan_Is_Not_Main_File;
                    }
                    else if (Attach.FileType == ClassLibrary.Domains.JCommunication.JFileType.word)
                    {
                        ltvItem.Group = lstvFiles.Groups["lvgWord"];
                        if (Attach.Is_Main_File)
                            ltvItem.ImageIndex = Icons.Word_Is_Main_File;
                        else
                            ltvItem.ImageIndex = Icons.Word_Is_Not_Main_File;
                    }
                    else
                    {
                        ltvItem.Group = lstvFiles.Groups["lvgOtherFiles"];
                        if (Attach.Is_Main_File)
                            ltvItem.ImageIndex = Icons.Other_File_Is_Main_File;
                        else
                            ltvItem.ImageIndex = Icons.Other_File_Is_Not_Main_File;
                    }
                    ltvItem.Tag = Attach;
                    AddToList(ltvItem);

                }
            }
            catch (Exception ex)
            {

            }*/

        }
        #endregion MyFunction

        private void JUC_AttachmentManager_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return; 
            WordDocument.BeforSave += new EventHandler(Word_BeforSave);         
            _setContextMenu();
        }
       
        /// <summary>
        /// انتخاب از انواع فایل تعریف شده توسط کاربران
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOtherFiles(int pCodeType)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] Content =  ReadByteArrayFromFile(openFileDialog1.FileName);
                if (Content != null)
                {
                    ListViewItem ltvItem = new ListViewItem();
                    Attachment attach;
                    attach.Code = GetNextID();
                    attach.FileTitle = openFileDialog1.SafeFileName;
                    attach.FileName = openFileDialog1.SafeFileName;
                    attach.FileType = ClassLibrary.Domains.JCommunication.JFileType.other;
                    attach.FileContent = Content;
                    attach.FileText = "";
                    attach.Is_Main_File = false;
                    attach.other_file_type = pCodeType;
                    attach.previous_version_code = 0;
                    attach.Is_New = true;

                    ltvItem.Text = attach.FileTitle;
                    ltvItem.ImageIndex = Icons.Other_File_Is_Not_Main_File; // ClassLibrary.Domains.JCommunication.JFileType.other;                                        
                    ltvItem.Group = lstvFiles.Groups["lvgOtherFiles"];                    
                    ltvItem.Tag = attach;                    
                    
                    //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
                    AddItem degAddToList = new AddItem(AddToList);
                    this.Invoke(degAddToList, ltvItem);
                    //-------------------------------------------------------
                }
            }
        }

        /// <summary>
        ///فراخوانی تابع انتخاب فایل ورد آماده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            SelectExistFileWord();
        }

        /// <summary>
        ///فراخوانی تابع انتخاب فایل ورد خالی
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SelectNewEmptyFileWord();
        }

        /// <summary>
        ///انتخاب فایل ورد جدید
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pattern_Click(object sender, EventArgs e)
        {
            WordDocument = new JCOfficeWord();
            WordDocument.BeforSave += new EventHandler(Word_BeforSave);  
            WordDocument.New(((ToolStripDropDownItem)(sender)).Tag.ToString());
        }

        private void OtherFiles_Click(object sender, EventArgs e)
        {
            SelectOtherFiles(Convert.ToInt32(((ToolStripDropDownItem)(sender)).Tag.ToString()));
        }

        private void lstvFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstvFiles.SelectedItems == null || lstvFiles.SelectedItems.Count == 0) return;
            try
            {
                string strExtension = JFiles.GetExtension(((Attachment)lstvFiles.SelectedItems[0].Tag).FileName);
                if (((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.word)
                {
                    Array.Resize(ref WordUpdateDocument, WordUpdateDocument.Length + 1);
                    WordUpdateDocument[WordUpdateDocument.Length - 1] = new JCOfficeWord();
                    WordUpdateDocument[WordUpdateDocument.Length - 1].Update( System.Text.Encoding.ASCII.GetString(((Attachment)lstvFiles.SelectedItems[0].Tag).FileContent), ((Attachment)lstvFiles.SelectedItems[0].Tag).Code);
                    WordUpdateDocument[WordUpdateDocument.Length - 1].BeforSave += new EventHandler(Word_BeforUpdateSave);
                }
                else if ((((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.image || strExtension == ".jpg" || strExtension == ".bmp" || strExtension == ".gif" || strExtension == ".png"))
            {
                DisplayFile(((Attachment)lstvFiles.SelectedItems[0].Tag).FileContent, lstvFiles.SelectedItems[0].Position.Y + 60, lstvFiles.SelectedItems[0].Position.X);
            }

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void lstvFiles_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            string strExtension  = JFiles.GetExtension(((Attachment)e.Item.Tag).FileName);
            if (((Attachment)e.Item.Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.image || strExtension == ".jpg" || strExtension == ".bmp" || strExtension == ".gif" || strExtension == ".png")
            {
                DisplayFile(((Attachment)e.Item.Tag).FileContent, e.Item.Position.Y + 60, e.Item.Position.X);
            }
            //else
            //{
            //    pnlDisplayThumbNill.Visible = false;
            //}
        }

        private void lstvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDisplayThumbNill.Visible = false;
            lstvFiles.ContextMenuStrip = cntxMenu;

        }

        private void lstvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            pnlDisplayThumbNill.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            scan();
        }

        private void typedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectNewEmptyFileWord();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            scan();
        }

        private void readyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectExistFileWord();

        }

        private void picBoxThumbNill_VisibleChanged(object sender, EventArgs e)
        {
                 
        }

        private void picBoxThumbNill_MouseClick(object sender, MouseEventArgs e)
        {
            if (pnlDisplayThumbNill.Width == picBoxThumbNill.Image.Width && pnlDisplayThumbNill.Height == picBoxThumbNill.Image.Height)
            {
                pnlDisplayThumbNill.Width = picBoxThumbNill.Image.Width * 3;
                pnlDisplayThumbNill.Height = picBoxThumbNill.Image.Height * 3;
                return;
            }
            pnlDisplayThumbNill.Width = picBoxThumbNill.Image.Width;
            pnlDisplayThumbNill.Height = picBoxThumbNill.Image.Height;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstvFiles.SelectedItems.Count > 0)
                lstvFiles_MouseDoubleClick(sender, null);
        }

        private void lstvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lstvFiles.SelectedItems.Count > 0)
            {               
                string strExtension =JFiles.GetExtension(((Attachment)lstvFiles.SelectedItems[0].Tag).FileName);
                if (
                    ((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.word ||
                    ((((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.image || strExtension == ".jpg" || strExtension == ".bmp" || strExtension == ".gif" || strExtension == ".png"))
                   )
                {
                    cmsNods.Items[0].Enabled = true;
                }
                else
                {
                    cmsNods.Items[0].Enabled = false;
                }

                if (((Attachment)lstvFiles.SelectedItems[0].Tag).Is_Main_File)
                {
                    isMainFileToolStripMenuItem.Text = JLanguages._Text("Is Not Main File");                        
                }
                else
                {
                    isMainFileToolStripMenuItem.Text = JLanguages._Text("Is Main File");                                            
                }

                lstvFiles.ContextMenuStrip = cmsNods;
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstvFiles.SelectedItems.Count > 0)
            {
                lstvFiles.SelectedItems[0].BeginEdit();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstvFiles.SelectedItems.Count > 0 && ((Attachment)lstvFiles.SelectedItems[0].Tag).Is_New)
            {
                lstvFiles.SelectedItems[0].Remove();
            }
        }

        private void isMainFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstvFiles.SelectedItems.Count > 0)
            {
                Attachment Attach;
                Attach = ((Attachment)lstvFiles.SelectedItems[0].Tag);
                //--------------------------- word ------------------------------------------------
                if (((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.word)
                {
                    Attach.Is_Main_File = !(((Attachment)lstvFiles.SelectedItems[0].Tag).Is_Main_File);
                    if (Attach.Is_Main_File)
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Word_Is_Main_File;
                    else
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Word_Is_Not_Main_File;
                }
                    //----------------------- scan ------------------------------------------------
                else if (((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.image)
                {
                    Attach.Is_Main_File = !(((Attachment)lstvFiles.SelectedItems[0].Tag).Is_Main_File);
                    if (Attach.Is_Main_File)
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Scan_Is_Main_File;
                    else
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Scan_Is_Not_Main_File;
                }
                    //----------------------- other file ------------------------------------------
                else if (((Attachment)lstvFiles.SelectedItems[0].Tag).FileType == ClassLibrary.Domains.JCommunication.JFileType.other)
                {
                    Attach.Is_Main_File = !(((Attachment)lstvFiles.SelectedItems[0].Tag).Is_Main_File);
                    if (Attach.Is_Main_File)
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Other_File_Is_Main_File;
                    else
                        lstvFiles.SelectedItems[0].ImageIndex = Icons.Other_File_Is_Not_Main_File;
                }
                lstvFiles.SelectedItems[0].Tag = Attach;
            }
        }

        private void lstvFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            Attachment attach;
            attach = ((Attachment)lstvFiles.Items[e.Item].Tag);
            attach.FileTitle = e.Label;
            lstvFiles.Items[e.Item].Tag = attach;
            
        }

        /// <summary>
        /// فایلهای انتخاب شده
        /// </summary>
        /// <returns>DataTable</returns>
        public List <JFile> SelectedFiles
        {
            get
            {
                List<JFile> files = new List<JFile>();
                for (int i = 0; i < lstvFiles.Items.Count; i++)
                {
                    JFile file = new JFile();
                    Attachment attach = ((Attachment)lstvFiles.Items[i].Tag);
                    file.Content = attach.FileContent;
                    file.FileName = attach.FileName;
                    files.Add(file);
                }
                return files;
            }
        }
    }


    /// <summary>
    /// تعریف دلیگیت جهت اضافه کردن آیتم های جدید به لیست
    /// </summary>
    public delegate void AddItem(ListViewItem ltvItem);
    public delegate void UpdateItem(ListViewItem ltvItem);
    public delegate int GetNextID();
    public delegate bool IS_OldFile(int pCode);
}
