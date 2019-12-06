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
        Doctor userDoctor;
        Doctor selectedDoc;
        Patient selectedPat;
        ArrayList List = new ArrayList();

        public Form1()
        {
            InitializeComponent();

            loginPanel.Visible = true;
            loginPanel.Location = new Point(0,0);
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

            //check which is trying to login
            //if the doctor is checked
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
                    
                    loginPasswordTB.Text = "";
                    loginIDtB.Text = "";
                    loginPanel.Location = new Point(773, 455);
                    loginPanel.Visible = false;

                    //make doctor panel visable
                    //move doctor panel
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
                    
                    loginPasswordTB.Text = "";
                    loginIDtB.Text = "";
                    loginPanel.Location = new Point(773, 455);
                    loginPanel.Visible = false;

                    //make Patient panel visable
                    patientPanel.Visible = true;
                    //move Patient panel
                    patientPanel.Location = new Point(0, 0);

                }
            }
        }



////patient's panel////

    //patient's request appointment interactions

        private void patientAppMakeAppBtn_Click(object sender, EventArgs e)
        {
            if (List != null)
            {
                int doctorId = selectedDoc.getIDNumber();
                string doctorName = selectedDoc.getName();
                int patientId = userPatient.getId();
                string patientName = userPatient.getName();
                string description = patientAppDescrip.Text;
                string dateOfApp = patientAppDate.Value.Year + "-" + patientAppDate.Value.Month +
                    "-" + patientAppDate.Value.Day + " " + patientAppTime.Value.Hour + ":" +
                    patientAppTime.Value.Minute + ":00";
                patientAppConfirNum.Text = dateOfApp;

                Random rnd = new Random();
                string confirmationNum = "";
                for (int i = 0; i < 6; i++)
                {
                    confirmationNum += rnd.Next(0, 9);
                }


                //make appointment 
                Appointment newApp = new Appointment(doctorId, patientId, doctorName, patientName,
                    dateOfApp, description, confirmationNum);

                patientAppDoctorLable.Text = "";
                patientAppDescrip.Text = "";

                patientAppConfirNum.Text = dateOfApp;
            }
        }

        private void patientRequestAppBnt_Click(object sender, EventArgs e)
        {
            patientAppPanel.Visible=true;
            patientAppPanel.Location = new Point(203, 37);
            patientDisableBtns();

            List.Clear();

            //make list of doctors in data base
            List = new Doctor().retrieveDoctorList();

            if (List != null)
            {
                selectedDoc = (Doctor)List[0];
            }
            
        }

        private void patientAppBackBtn_Click(object sender, EventArgs e)
        {
            patientAppDoctorLable.Text = "";
            patientAppDocListBox.Items.Clear();
            patientAppDescrip.Text = "";
            patientAppConfirNum.Text = "";

            patientEnableBtns();
            patientAppPanel.Location = new Point(28, 362);
            patientAppPanel.Visible=false;
        }

        private void patientAppDocListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List != null)
            {
                selectedDoc = (Doctor)List[patientAppDocListBox.SelectedIndex];
                patientAppDoctorLable.Text += "" + selectedDoc.getName();
            }

        }

    //patient's request phone call interactions

        private void patientPhoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List != null)
            {
                selectedDoc = (Doctor)List[patientAppDocListBox.SelectedIndex];
                patientPhoneDocLabel.Text += "" + selectedDoc.getName();
            }
        }

        private void patientPhoneBackBtn_Click(object sender, EventArgs e)
        {
            patientPhoneDocLabel.Text = "";
            patientPhoneList.Items.Clear();
            patientPhoneDescrip.Text = "";

            patientPhonePanel.Location = new Point(79, 348);
            patientPhonePanel.Visible = false;

            patientEnableBtns();
        }

        private void patientPhoneBtn_Click(object sender, EventArgs e)
        {
            patientPhonePanel.Visible = true;
            patientPhonePanel.Location = new Point(203, 37);

            List.Clear();
            //make list of doctors in data base
            List = new Doctor().retrieveNonBusyDoctorList();

            if (List != null)
            {
                selectedDoc = (Doctor)List[0];
            }
        }

        private void patientPhoneSendBtn_Click(object sender, EventArgs e)
        {
            if (List != null)
            {
                int docId = selectedDoc.getIDNumber(); ;
                string docName = selectedDoc.getName();
                int patId = userPatient.getId();
                string patName = userPatient.getName();
                string patPhoneNum = userPatient.getPhoneNum();
                string descrip = patientPhoneDescrip.Text;

                string message = docName + ", \n" + patName + ": " + descrip +
                    "\n you can reach them at " + patPhoneNum;

                //create message/notice
                new Message(docId, "Phone Call", patId, message);
            }
        }

    //patient's request refill interactions

        private void patientRefillBtn_Click(object sender, EventArgs e)
        {
            patientPhonePanel.Visible = true;
            patientPhonePanel.Location = new Point(203, 37);

            patientDisableBtns();

            List.Clear();
            //make list of refills in data base
            List = new Refill().retrieveRefillList(userPatient.getId());

        }

        private void patientRefillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List != null)
            {
                Refill selectedRe = (Refill)List[patientRefillList.SelectedIndex];
                patientRefillID.Text = "" + selectedRe.getRefillID();
                patientRefillMed.Text = selectedRe.getMedication();
                patientRefillDate.Text = selectedRe.getTimePeriod();
                patientRefillTimes.Text = "" + selectedRe.getTimesFilled();
            }
        }

        private void patientRefillSend_Click(object sender, EventArgs e)
        {
            if (List != null)
            {
                Refill selectedRe = (Refill)List[patientRefillList.SelectedIndex];
                int refillId = selectedRe.getRefillID();
                int docID = selectedRe.getDoctorID();


                //make message/notice
                new Message(docID, "Refill Request", userPatient.getId(), refillId);
            }
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

            patientPhonePanel.Location = new Point(392, 306);
            patientPhonePanel.Visible = false;
        }

    //patient's View Notices interactions

        private void patientNoticeBtn_Click(object sender, EventArgs e)
        {
            patientDisableBtns();
            
            patientNoticePanel.Visible = true;
            patientNoticePanel.Location = new Point(203, 37);

            //make list from notices with patId
            List = new Message().retrieveMessagesList("PatientID",userPatient.getId());

            if (List != null)
            { 
            patientNoticeType.Text = ((Message)List[0]).getTypeOfNotice();
            patientNoticeDescrip.Text = ((Message)List[0]).getMessage();
            
            }
        }

        private void patientNoticeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            patientNoticeAccept.Enabled = true;
            patientNoticeDeny.Enabled = true;

            if (List != null)
            {
                Message selectedNote = (Message)List[patientNoticeList.SelectedIndex];
                patientNoticeType.Text = selectedNote.getTypeOfNotice();
                patientNoticeDescrip.Text = selectedNote.getMessage();
                //if type is not acceptable/deniable disable/vis accept and deny btns
                if (selectedNote.getTypeOfNotice() != "Record Request")
                {
                    patientNoticeAccept.Enabled = false;
                    patientNoticeDeny.Enabled = false;
                }
            }

        }

        private void patientNoticeAccept_Click(object sender, EventArgs e)
        {
            //checks what type of message it is
            //create message
        }

        private void patientNoticeDeny_Click(object sender, EventArgs e)
        {
            //checks what type of message it is
            //create message
        }

        private void patientNoticeBack_Click(object sender, EventArgs e)
        {
            patientEnableBtns();

            patientNoticeList.Items.Clear();
            patientNoticeType.Text = "";
            patientNoticeDescrip.Text = "";
            
            patientNoticePanel.Location = new Point(303, 334);
            patientNoticePanel.Visible = false;
        }

    //patient's view medical record

        //Record menu clicked
        private void patientRecordBtn_Click(object sender, EventArgs e)
        {
            patientRecordPanel.Visible = true;
            patientRecordPanel.Location = new Point(203, 37);

            patientDisableBtns();

            patientRecordTB.Text = userPatient.getMedRecord();
        }
        //back button was clicked in med record
        private void patientRecordBackBtn_Click(object sender, EventArgs e)
        {
            patientRecordTB.Text = "";

            patientEnableBtns();

            patientRecordPanel.Location = new Point(750, 77);
            patientRecordPanel.Visible = false;

        }

    //patient's back btn

        private void patientBack_Click(object sender, EventArgs e)
        {
            //resets login inputs
            loginIDtB.Text = "";
            loginPasswordTB.Text = "";

            //move and turn visible off for patietn panel
            patientPanel.Location = new Point(547, 578);
            patientPanel.Visible = false;

            //more and make visible for the login panel
            loginPanel.Visible = true;
            loginPanel.Location=new Point(0,0);
            
        }

    //Misc.
        //disables patient menu buttons
        public void patientDisableBtns()
        {
            patientRequestAppBnt.Enabled = false;
            patientPhoneBtn.Enabled = false;
            patientRefillBtn.Enabled = false;
            patientNoticeBtn.Enabled = false;
            patientRecordBtn.Enabled = false;
            patientBack.Enabled = false;
        }

        //enables patient menu buttons
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
