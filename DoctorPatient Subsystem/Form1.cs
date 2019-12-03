using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            loginInvalid.Visible.Equals(false);
            String id = loginIDtB.Text;
            String password = loginPasswordTB.Text;
            String sqlPassword="";
            if (radioButtonDoctor.Checked)
            {

                //prepare an SQL query to retrieve the patient 
                DataTable myTable = new DataTable();
                string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT * FROM ******Doctor Table****** WHERE doctorId = " + id; //placeholder for the real table name
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("@myDate", dateString);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                    myAdapter.Fill(myTable);
                    Console.WriteLine("Table is ready.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();

                //convert the retrieved data to events and save them to the list
                foreach (DataRow row in myTable.Rows)
                {
                    sqlPassword = row["password"].ToString();
                    
                }

                if (myTable==null || password != sqlPassword)
                {
                    loginInvalid.Visible.Equals(true);
                }
                else
                {
                    LoginPanel.Visible.Equals(false);
                }
            }
            else
            {

                //prepare an SQL query to retrieve the patient 
                DataTable myTable = new DataTable();
                string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT * FROM ******Patient Table****** WHERE patientId = " + id; //placeholder for the real table name
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("@myDate", dateString);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                    myAdapter.Fill(myTable);
                    Console.WriteLine("Table is ready.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();

                //convert the retrieved data to events and save them to the list
                foreach (DataRow row in myTable.Rows)
                {
                    sqlPassword = row["password"].ToString();

                }

                if (myTable == null || password != sqlPassword)
                {
                    loginInvalid.Visible.Equals(true);
                }
                else
                {
                    LoginPanel.Visible.Equals(false);
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
