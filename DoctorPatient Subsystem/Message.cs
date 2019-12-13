using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace DoctorPatient_Subsystem
{
    class Message
    {
        int noticeID;
        string typeOfNotice;
        string date;
        int doctorID;
        int patientID;
        int prescriptionID;
        int refillID;
        string message;
        int appointment;
        bool isGranted;

        public Message()
        {

        }

        public Message(int notID, string type, string date, int docID, int patID, int preID, int reID, string msg, int app, bool grant)
        {
            this.noticeID = notID;
            this.typeOfNotice = type;
            this.date = date;
            this.doctorID = docID;
            this.patientID = patID;
            this.prescriptionID = preID;
            this.refillID = reID;
            this.message = msg;
            this.appointment = app;
            this.isGranted = grant;
        }

        public Message(string type, int docID, int patID, string msg)
        {
            this.typeOfNotice = type;
            this.doctorID = docID;
            this.patientID = patID;
            this.message = msg;

            //insert new message
            createMessage();
        }

        public Message(string type, int docID, int patID, int reID)
        {
            this.typeOfNotice = type;
            this.doctorID = docID;
            this.patientID = patID;
            this.refillID = reID;

            //insert new message
            createMessage();
        }

        public Message(string type, int docId, int patId,String msg, bool permision)
        {
            //inset new message
            createMessage();
        }

        public int getNoticeID()
        {
            return this.noticeID;
        }

        public string getTypeOfNotice()
        {
            return this.typeOfNotice;
        }

        public string getDate()
        {
            return this.date;
        }

        public int getDoctorID()
        {
            return this.doctorID;
        }

        public int getPrescriptionID()
        {
            return this.prescriptionID;
        }

        public int getRefillID()
        {
            return this.refillID;
        }

        public string getMessage()
        {
            return this.message;
        }

        public int getAppointment()
        {
            return this.appointment;
        }

        public bool getisGranted()
        {
            return isGranted;
        }

        public void setIsGranted(bool logic)
        {
            isGranted = logic;
        }


        public void createMessage()
        {
            //SQL INSERT Statement goes here
        }

        public ArrayList retrieveMessagesList(string whereVar, int key)
        {
            ArrayList messageList = new ArrayList();

            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //prepare an SQL query to retrieve notice i from patient from patients
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_message WHERE @var = @key ;"; 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@var", whereVar);
                cmd.Parameters.AddWithValue("@key", key);
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
                int notId = Int32.Parse(row["notice_id"].ToString());
                string type = row["typeofNotice"].ToString();
                string dateT = row["mdate"].ToString();
                int docId = Int32.Parse(row["doctor_id"].ToString());
                int patId = Int32.Parse(row["patient_id"].ToString());
                int preId = Int32.Parse(row["prescription_id"].ToString());
                int reId = Int32.Parse(row["refill_id"].ToString());
                string mes = row["message"].ToString();
                int appId = Int32.Parse(row["appointment_id"].ToString());
                string status = row["iGranted"].ToString();
                bool grant = status.Equals("True");

                messageList.Add(new Message(notId, type, dateT, docId, patId, preId, reId, mes, appId, grant));

            }


            if (messageList.Count == 0)
            {
                return null;
            }
            return messageList;
        }

    }
}
