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
        string typeOfNotice = null;
        string date = null;
        int doctorID = 0;
        int patientID = 0;
        int prescriptionID = 0;
        int refillID = 0;
        string message = null;
        int appointment = 0;
        bool isGranted = false;

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

            // prepare an SQL query to retrieve
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_message (typeofNotice, mdate, doctor_id, patient_id, message )VALUES (@type , @date , @docId, @patId, @msg );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", typeOfNotice);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.Parameters.AddWithValue("@docId", doctorID);
                cmd.Parameters.AddWithValue("@patId", patientID);

                //excute and get NoteID
                noticeID = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public Message(string type, int docID, int patID, int reID)
        {
            this.typeOfNotice = type;
            this.doctorID = docID;
            this.patientID = patID;
            this.refillID = reID;

            //insert new message

            // prepare an SQL query to retrieve
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_message (typeofNotice, mdate, doctor_id, patient_id, refill_id )VALUES (@type , @date , @docId, @patId, @reId );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", typeOfNotice);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@reId", refillID);
                cmd.Parameters.AddWithValue("@docId", doctorID);
                cmd.Parameters.AddWithValue("@patId", patientID);

                //excute and get NoteID
                noticeID = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public Message(string type, int docId, int patId, string msg, bool permision)
        {
            this.typeOfNotice = type;
            this.doctorID = docId;
            this.patientID = patId;
            this.message = msg;
            this.isGranted = permision;
            //inset new message

            // prepare an SQL query to retrieve
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_message (typeofNotice, mdate, doctor_id, patient_id, message, isGranted )VALUES (@type , @date , @docId, @patId, @msg, @grant );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", typeOfNotice);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.Parameters.AddWithValue("@docId", doctorID);
                cmd.Parameters.AddWithValue("@patId", patientID);
                cmd.Parameters.AddWithValue("@grant", isGranted.ToString());

                //excute and get NoteID
                noticeID = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
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
                string sql = "SELECT * FROM kodibrian_message WHERE " + whereVar + " = " + key + " ;";
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

                int docId;
                if (!row["doctor_id"].ToString().Equals(""))
                    docId = Int32.Parse(row["doctor_id"].ToString());
                else
                    docId = -1;

                int patId;
                if (!row["patient_id"].ToString().Equals(""))
                    patId = Int32.Parse(row["patient_id"].ToString());
                else
                    patId = -1;

                int preId;
                if (!row["prescription_id"].ToString().Equals(""))
                    preId = Int32.Parse(row["prescription_id"].ToString());
                else
                    preId = -1;

                int reId;
                if (!row["refill_id"].ToString().Equals(""))
                    reId = Int32.Parse(row["refill_id"].ToString());
                else
                    reId = -1;

                string mes = row["message"].ToString();

                int appId;
                if (!row["appointment_id"].ToString().Equals(""))
                    appId = Int32.Parse(row["appointment_id"].ToString());
                else
                    appId = -1;

                string status = row["isGranted"].ToString();
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
