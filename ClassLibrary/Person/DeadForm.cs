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
    public partial class JDead : ClassLibrary.JBaseForm
    {
        public JDead()
        {
            InitializeComponent();
        }

        private void JDead_Load(object sender, EventArgs e)
        {
            label13.ResetText();
            label14.ResetText();
            label15.ResetText();
            label16.ResetText();
            label17.ResetText();
            label18.ResetText();
            label19.ResetText();
            label20.ResetText();
            label12.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JPerson person = new JPerson();
            DateTime date = dateTimePicker1.Value;
            string num =numEdit1.Text;
            int code =Convert.ToInt32(numEdit2.Text);
            person.Code = code;
            if (person.GetDie(code))
            {
                person.UpdateDie(date, num);
            }
            else
            {
                person.DiePerson(date, num);
            }
          
            
              
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void jCodingBox1_Load(object sender, EventArgs e)
        {

        }

        private void numEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '\r')
            {

                int code = Convert.ToInt32(numEdit2.Text);
                JPerson person = new JPerson();

                if (person.getData(code)&&person.GetDie(code))
                {
                    MessageBox.Show("اطلاعات فوت این شخص در سیستم قبلا ثبت شده است و شما می توانید ویرایش کنید.");
                    dateTimePicker1.Value = person.DieDate;
                    numEdit1.Text =Convert.ToString(person.dieNumber);
                    label13.Text = person.Name;
                    label14.Text = person.Fam;
                    label15.Text = person.ShSh;
                    
                }
                else if (person.getData(code))
                {
                    label13.Text = person.Name;
                    label14.Text = person.Fam;
                    label15.Text = person.ShSh;
                }
                else
                {
                    MessageBox.Show("این کد وجود ندارد");
                }
          
                
            
                }
                
              
            }
                 
        
        private void numEdit2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            JPerson person = new JPerson();
            int code =Convert.ToInt32( numEdit2.Text);
            person.getData(code);
            if (person.GetDie(code))
            {
                person.DelDie();
            }
            else
            {
                MessageBox.Show("اطلاعات فوت این شخص در سیستم ثبت نشده است.");
            }
        }
    }
}
