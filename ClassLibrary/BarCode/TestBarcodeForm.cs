using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.BarCode
{
    public partial class JTestBarcodeForm : Form
    {
        JBarcode B = new JBarcode();
        Graphics g;
        public JTestBarcodeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap Bee = B.Draw(textBox1.Text);
            Bee.Save("D:\\image.bmp");
            Bee.Dispose();
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void JTestBarcodeForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void JTestBarcodeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
