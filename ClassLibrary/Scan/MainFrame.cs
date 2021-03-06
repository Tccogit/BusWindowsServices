using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TwainLib;
using ClassLibrary;

namespace ClassLibrary
{
    //aaaaa
    public class jfrmScanMain : JBaseForm, IMessageFilter
	{
	private System.Windows.Forms.MdiClient mdiClient1;
	private System.Windows.Forms.MenuItem menuMainFile;
	private System.Windows.Forms.MenuItem menuItemScan;
	private System.Windows.Forms.MenuItem menuItemSelSrc;
	private System.Windows.Forms.MenuItem menuMainWindow;
	private System.Windows.Forms.MenuItem menuItemExit;
	private System.Windows.Forms.MenuItem menuItemSepr;
    private System.Windows.Forms.MainMenu mainFrameMenu;
    private IContainer components;
    /// <summary>
    /// لیست آیتم های برگشتی
    /// </summary>    
    public Scan[] ScanFiles;
    public struct Scan
    {
        public byte[] content;
        public string name;
    }
    public jfrmScanMain()
		{
		InitializeComponent();
		tw = new Twain();
		tw.Init( this.Handle );
		}

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            tw.Finish();

            if (components != null)
            {
                components.Dispose();
            }
            for (int i = 0; i < ScanFiles.Length; i++)
            {
                Array.Resize(ref ScanFiles[i].content, 0);
            }
            Array.Resize(ref ScanFiles, 0);
        }
        base.Dispose(disposing);
    }

    public void Free()
    {
        Dispose(true);
    }

        

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jfrmScanMain));
            this.menuMainFile = new System.Windows.Forms.MenuItem();
            this.menuItemSelSrc = new System.Windows.Forms.MenuItem();
            this.menuItemScan = new System.Windows.Forms.MenuItem();
            this.menuItemSepr = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.mainFrameMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuMainWindow = new System.Windows.Forms.MenuItem();
            this.mdiClient1 = new System.Windows.Forms.MdiClient();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // menuMainFile
            // 
            this.menuMainFile.Index = 0;
            this.menuMainFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSelSrc,
            this.menuItemScan,
            this.menuItemSepr,
            this.menuItemExit});
            this.menuMainFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuMainFile.Text = "پرونده";
            // 
            // menuItemSelSrc
            // 
            this.menuItemSelSrc.Index = 0;
            this.menuItemSelSrc.MergeOrder = 11;
            this.menuItemSelSrc.Text = "انتخاب دستگاه";
            this.menuItemSelSrc.Click += new System.EventHandler(this.menuItemSelSrc_Click);
            // 
            // menuItemScan
            // 
            this.menuItemScan.Index = 1;
            this.menuItemScan.MergeOrder = 12;
            this.menuItemScan.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItemScan.Text = "(ESC اسکن (برای خروج از حالت اسکن دکمه ";
            this.menuItemScan.Click += new System.EventHandler(this.menuItemScan_Click);
            // 
            // menuItemSepr
            // 
            this.menuItemSepr.Index = 2;
            this.menuItemSepr.MergeOrder = 19;
            this.menuItemSepr.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.MergeOrder = 21;
            this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.menuItemExit.Text = "ثبت";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // mainFrameMenu
            // 
            this.mainFrameMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuMainFile,
            this.menuMainWindow});
            // 
            // menuMainWindow
            // 
            this.menuMainWindow.Index = 1;
            this.menuMainWindow.MdiList = true;
            this.menuMainWindow.Text = "پنجره";
            // 
            // mdiClient1
            // 
            this.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiClient1.Location = new System.Drawing.Point(0, 0);
            this.mdiClient1.Name = "mdiClient1";
            this.mdiClient1.Size = new System.Drawing.Size(600, 345);
            this.mdiClient1.TabIndex = 0;
            // 
            // jfrmScanMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(600, 345);
            this.Controls.Add(this.mdiClient1);
            this.IsMdiContainer = true;
            this.Menu = this.mainFrameMenu;
            this.Name = "jfrmScanMain";
            this.Text = "اسکن";
            this.ResumeLayout(false);

		}
		#endregion


    
	private void menuItemExit_Click(object sender, System.EventArgs e)
		{
           Array.Resize(ref ScanFiles, this.MdiChildren.Length);
           for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                ScanFiles[i].content = ((PicForm)this.MdiChildren[i]).ScanByte;
                ScanFiles[i].name = ((PicForm)this.MdiChildren[i]).Text;
            }   
        DialogResult = DialogResult.OK;
		Close();
		}

	private void menuItemScan_Click(object sender, System.EventArgs e)
		{
		if( ! msgfilter )
			{
			this.Enabled = false;
			msgfilter = true;
			Application.AddMessageFilter( this );
			}
		tw.Acquire();
		}

	private void menuItemSelSrc_Click(object sender, System.EventArgs e)
		{
		tw.Select();
		}


	bool IMessageFilter.PreFilterMessage( ref Message m )
		{
		TwainCommand cmd = tw.PassMessage( ref m );
		if( cmd == TwainCommand.Not )
			return false;

		switch( cmd )
			{
			case TwainCommand.CloseRequest:
				{
				EndingScan();
				tw.CloseSrc();
				break;
				}
			case TwainCommand.CloseOk:
				{
				EndingScan();
				tw.CloseSrc();
				break;
				}
			case TwainCommand.DeviceEvent:
				{
				break;
				}
            case TwainCommand.TransferReady:
                {
                    ArrayList pics = tw.TransferPictures();
                    EndingScan();
                    tw.CloseSrc();
                    picnumber++;
                    for (int i = 0; i < pics.Count; i++)
                    {
                        IntPtr img = (IntPtr)pics[i];
                        PicForm newpic = new PicForm(img);
                        newpic.MdiParent = this;
                        int picnum = i + 1;
                        newpic.Text = JLanguages._Text("Scan") + picnumber.ToString() + "_" + picnum.ToString();
                        newpic.Show();
                    }
                    break;
                }
			}

		return true;
		}

	private void EndingScan()
		{
		if( msgfilter )
			{
			Application.RemoveMessageFilter( this );
			msgfilter = false;
			this.Enabled = true;
			this.Activate();
			}
		}

	private bool	msgfilter;
	private Twain	tw;
	private int		picnumber = 0;








	[STAThread]
	static void Main() 
		{
		if( Twain.ScreenBitDepth < 15 )
			{
			MessageBox.Show( "Need high/true-color video mode!", "Screen Bit Depth", MessageBoxButtons.OK, MessageBoxIcon.Information );
			return;
			}

		jfrmScanMain mf = new jfrmScanMain();
		Application.Run( mf );
		}

    } // class jfrmScanMain

} // namespace Scan
