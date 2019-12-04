﻿using System;
using System.Collections;
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
        Patient userPatient;
        //Doctor userDoctor;
        //Doctor selectedDoc;
        Patient selectedPat;
        ArrayList List = new ArrayList();

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

        ////Login Panel////

        // Login interactions

        private void LoginLoginBtn_Click(object sender, EventArgs e)
        {
            loginInvalid.Visible=false;
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
                    loginInvalid.Visible=true;
                }
                else
                {
                    LoginPanel.Visible=false;
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
                    loginInvalid.Visible=true;
                }
                else
                {
                    LoginPanel.Visible=false;
                }
            }
        }


        ////patient's panel////

        //patient's request appointment interactions

        private void patientAppMakeAppBtn_Click(object sender, EventArgs e)
        {
            //int doctorId=selectedDoc.getId();
            //string doctorName = selectedDoc.getName();
            int patientId = userPatient.getId();
            string patientName = userPatient.getName();
            string description=patientAppDescrip.Text;
            string dateOfApp = patientAppDate.Value.Year + "-" + patientAppDate.Value.Month +
                "-" + patientAppDate.Value.Day + " " + patientAppTime.Value.Hour + ":" + 
                patientAppTime.Value.Minute + ":00";
            patientAppConfirNum.Text =dateOfApp;

            Random rnd = new Random();
            string confirmationNum ="";
            for(int i = 0; i < 6; i++)
            {
                confirmationNum += rnd.Next(0, 9);
            }
            

            //make appointment 
            //Appointment newApp = new Appointment(doctorId, patientId, doctorName, patientName,
                //dateOfApp, description, confirmationNum);

            patientAppDoctorLable.Text = "";
            patientAppDescrip.Text = "";

            patientAppConfirNum.Text = dateOfApp;
        }

        private void patientRequestAppBnt_Click(object sender, EventArgs e)
        {
            patientAppPanel.Visible=true;

            List.Clear();
            //make list of doctors in data base

            //selectedDoc = (Doctor)List[0];
        }

        private void patientAppBackBtn_Click(object sender, EventArgs e)
        {
            patientAppDoctorLable.Text = "";
            patientAppDocListBox.Items.Clear();
            patientAppDescrip.Text = "";
            patientAppConfirNum.Text = "";

            patientAppPanel.Visible=false;
        }

        private void patientAppDocListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedDoc = (Doctor)List[patientAppDocListBox.SelectedIndex];
            //patientAppDoctorLable.Text += "" + selectedDoc.getName();

        }


        //patient's request phone call interactions

        private void patientPhoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedDoc = (Doctor)List[patientAppDocListBox.SelectedIndex];
            //patientAppDoctorLable.Text += "" + selectedDoc.getName();
        }

        private void patientPhoneBackBtn_Click(object sender, EventArgs e)
        {
            patientPhoneDocLabel.Text = "";
            patientAppDocListBox.Items.Clear();
            patientPhoneDescrip.Text = "";

            patientPhonePanel.Visible = false;
        }

        private void patientPhoneBtn_Click(object sender, EventArgs e)
        {
            patientPhonePanel.Visible = true;

            List.Clear();
            //make list of doctors in data base

            //selectedDoc = (Doctor)List[0];
        }

        private void patientPhoneSendBtn_Click(object sender, EventArgs e)
        {

        }


        //patient's request refill interactions

        private void patientRefillBtn_Click(object sender, EventArgs e)
        {

        }

        private void patientRefillList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void patientRefillSend_Click(object sender, EventArgs e)
        {

        }

        private void patientRefillBack_Click(object sender, EventArgs e)
        {

        }


        //patient's View Notices interactions

        private void patientNoticeBtn_Click(object sender, EventArgs e)
        {

        }

        private void patientNoticeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void patientNoticeAccept_Click(object sender, EventArgs e)
        {

        }

        private void patientNoticeDeny_Click(object sender, EventArgs e)
        {

        }

        private void patientNoticeBack_Click(object sender, EventArgs e)
        {

        }


        //patient's view medical record

        private void patientRecordBtn_Click(object sender, EventArgs e)
        {

        }

        private void patientRecordBackBtn_Click(object sender, EventArgs e)
        {

        }


        //patient's back btn

        private void patientBack_Click(object sender, EventArgs e)
        {

        }



    }
}
