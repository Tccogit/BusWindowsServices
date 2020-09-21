using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using FastReport.Data;
using FastReport.Utils;
using FastReport.TypeConverters;
using FastReport.Design.ToolWindows;
using FastReport.Format;

namespace ClassLibrary
{
    public class JBarcode
    {

        public System.Windows.Forms.PictureBox PBox;

        public JBarcode()
        {
        }

        public Bitmap Draw(string pData)
        {
            try
            {
                //PixelFormat P = PixelFormat.Indexed;
                Bitmap Bee = new Bitmap(pData.Length*170,600);
                Bee.SetResolution(600, 600);
                Graphics g = Graphics.FromImage(Bee);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                
                g.InterpolationMode = InterpolationMode.Bilinear;
                FastReport.GraphicCache cache = new FastReport.GraphicCache();
                cache.GetPen(Color.Black, 1, DashStyle.Solid);
                FRPaintEventArgs PaintEventArgs = new FRPaintEventArgs(g, 6.25F, 6.25F, cache);
                FastReport.Barcode.BarcodeObject BarObj = new FastReport.Barcode.BarcodeObject();

                BarObj.Width = 200F;
                BarObj.Height = 100F;
                BarObj.Text = pData;
                BarObj.Draw(PaintEventArgs);
                
                //Bee.Save("D:\\test.bmp");
                return Bee;
            }
            catch
            {
                return null;
            }
        }
    }

    
}
