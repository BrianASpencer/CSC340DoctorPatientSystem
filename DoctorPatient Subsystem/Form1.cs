using System;
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
                    loginPanel.Visible=false;
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
                    loginPanel.Visible=false;
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
            patientDisableBtns();

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

            patientEnableBtns();
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
            //patientPhoneDoctorLable.Text += "" + selectedDoc.getName();
        }

        private void patientPhoneBackBtn_Click(object sender, EventArgs e)
        {
            patientPhoneDocLabel.Text = "";
            patientPhoneList.Items.Clear();
            patientPhoneDescrip.Text = "";

            patientPhonePanel.Visible = false;
            patientEnableBtns();
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
            //int docId = selectedDoc.getId(); ;
            //string docName = selectedDoc.getName();
            int patId = userPatient.getId();
            string patName = userPatient.getName();
            string patPhoneNum = userPatient.getPhoneNum();
            string descrip = patientPhoneDescrip.Text;

            //create message/notice

        }

        //patient's request refill interactions

        private void patientRefillBtn_Click(object sender, EventArgs e)
        {
            patientPhonePanel.Visible = true;
            patientDisableBtns();

            List.Clear();
            //make list of refills in data base

            //selectedDoc = (refill)List[0];
        }

        private void patientRefillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Refill selectedRe = (Refill)List[patientRefillList.SelectedIndex];
            //patientRefillID.Text = selectedRe.getRefillId();
            //patientRefillMed.Text = selectedRe.getMed();
            //patientRefillDate.Text = selectedRe.getGoodDate();
            //patientRefillTimes.Text = selectedRe.getTimes();
            //patientRefillMax.Text = selectedRe.getMax();
        }

        private void patientRefillSend_Click(object sender, EventArgs e)
        {
            //Refill selectedRe = (Refill)List[patientRefillList.SelectedIndex];
            //int refillId= selectedRe.getRefillId();
            
            //make message/notice
        }

        private void patientRefillBack_Click(object sender, EventArgs e)
        {
            patientRefillList.Items.Clear();

            patientRefillID.Text = "";
            patientRefillMed.Text = "";
            patientRefillDate.Text = "";
            patientRefillTimes.Text = "";
            patientRefillMax.Text = "";

            patientEnableBtns();

            patientPhonePanel.Visible = false;
        }

        //patient's View Notices interactions

        private void patientNoticeBtn_Click(object sender, EventArgs e)
        {
            patientDisableBtns();
            //make list from notices with patId
            patientNoticePanel.Visible = true;
            //patientNoticeType.Text = (Notice)List[0].getType;
            //patientNoticeDescrip.Text = (Notice)List[0].getDescription();
            patientNoticePanel.Location = new Point(206, 42);
        }

        private void patientNoticeList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Notice selectedNote=(Notice)List[patientNoticeList.SelectedIndex];
            //patientNoticeType.Text = selectedNote.getType;
            //patientNoticeDescrip.Text = selectedNote.getDescription();

            //if type is not acceptable/deniable disable accept and deny btns
        }

        private void patientNoticeAccept_Click(object sender, EventArgs e)
        {

        }

        private void patientNoticeDeny_Click(object sender, EventArgs e)
        {

        }

        private void patientNoticeBack_Click(object sender, EventArgs e)
        {
            patientEnableBtns();

            patientNoticeList.Items.Clear();
            patientNoticeType.Text = "";
            patientNoticeDescrip.Text = "";
            patientNoticePanel.Visible = false;
            patientNoticePanel.Location = new Point(303, 334);
        }

        //patient's view medical record

        private void patientRecordBtn_Click(object sender, EventArgs e)
        {
            patientRecordPanel.Visible = true;
            patientDisableBtns();

            patientRecordTB.Text = userPatient.getMedRecord();
        }

        private void patientRecordBackBtn_Click(object sender, EventArgs e)
        {
            patientRecordTB.Text = "";

            patientEnableBtns();
            patientRecordPanel.Visible = false;

        }

        //patient's back btn

        private void patientBack_Click(object sender, EventArgs e)
        {
            loginIDtB.Text = "";
            loginPasswordTB.Text = "";

            loginPanel.Visible = true;
            loginPanel.Location=new Point(0,0);
            patientPanel.Visible = false;
        }



        public void patientDisableBtns()
        {
            patientRequestAppBnt.Enabled = false;
            patientPhoneBtn.Enabled = false;
            patientRefillBtn.Enabled = false;
            patientNoticeBtn.Enabled = false;
            patientRecordBtn.Enabled = false;
            patientBack.Enabled = false;
        }

        public void patientEnableBtns()
        {
            patientRequestAppBnt.Enabled = true;
            patientPhoneBtn.Enabled = true;
            patientRefillBtn.Enabled = true;
            patientNoticeBtn.Enabled = true;
            patientRecordBtn.Enabled = true;
            patientBack.Enabled = true;
        }
    }
}
