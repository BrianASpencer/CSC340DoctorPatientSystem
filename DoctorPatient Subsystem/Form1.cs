using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorPatient_Subsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            System.Object[] ItemObject = new System.Object[5];
            for (int i = 0; i <= 4; i++)
            {
                ItemObject[i] = "Patient 0,"+" Record " + i;
            }
            listBox1.Items.AddRange(ItemObject);
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoginLoginBtn_Click(object sender, EventArgs e)
        {

            String id = loginIDtB.Text;
            String password = loginPasswordTB.Text;
            if (radioButtonDoctor.Checked)
            {


                if (id!=sqlId || password != sqlPassword)
                {

                }
                else
                {

                }
            }
            else
            {
                if (id != sqlId || password != sqlPassword)
                {

                }
                else
                {

                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
