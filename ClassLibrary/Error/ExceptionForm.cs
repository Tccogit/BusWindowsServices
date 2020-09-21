using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JExceptionForm : JBaseForm
    {
        public JExceptionForm()
        {
            InitializeComponent();
            ListExceptions();

            //lbDBOpen.Text = JDataBase.OpenDatabase.ToString();
        }

        private void ListExceptions()
        {
            if (JException.Exceptions == null)
                return;
            listView1.Columns.Add("Message",300);
            listView1.Columns.Add("Source", 100);
            listView1.Columns.Add("Location",400);

            for (int i = 0; i < JException.Exceptions.Count; i++)
            {
                Exception ex = JException.Exceptions[i];
                if (ex == null)
                    continue;
                listView1.Items.Add(ex.Message);
                listView1.Items[i].SubItems.Add(ex.Source);
                listView1.Items[i].SubItems.Add(ex.StackTrace);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClassLibrary.JSystem.Except.EmptyExceptions();
            listView1.Items.Clear();
            ListExceptions();
        }

    }
}
