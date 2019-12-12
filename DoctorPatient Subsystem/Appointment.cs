using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DoctorPatient_Subsystem
{
    class Appointment
    {
        int appointmentId;
        int doctorId;
        int patientId;
        int noticeId;
        string confirmationNum;
        string patientName;
        string doctorName;
        string date;
        string description;

        public Appointment(int docId, int patId, string docName, string patName, string conDate,
            string conDescrip, string confirNum)
        {
            doctorId=docId;
            patientId=patId;
            confirmationNum=confirNum;
            patientName= patName;
            doctorName=docName;
            date=conDate;
            description=conDescrip;

            insertApp();
        }

        //gets
        public int getAppointmentId()
        {
            return appointmentId;
        }

        public int getNoticeId()
        {
            return noticeId;
        }

        public int getpatientId()
        {
            return patientId;
        }

        public string getConfirNum()
        {
            return confirmationNum;
        }

        public string getPatientName()
        {
            return patientName;
        }

        public int getDoctortId()
        {
            return doctorId;
        }

        public string getDoctorName()
        {
            return doctorName;
        }

        public string getDate()
        {
            return date;
        }

        public string getDescription()
        {
            return description;
        }


        //retrieve data from database (Dont Need?)
        public void retreiveAppointmentData(int id)
        {

        }

        private void insertApp()
        {
            //create appointment in table
            // prepare an SQL query to retrieve
             DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //retrieve base info from appointment table

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_appointments (adate, conNum, description)VALUES (@date , @conNum , @des );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@conNum", confirmationNum);
                cmd.Parameters.AddWithValue("@des", description);

                //excute and get appID
                appointmentId = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //create notice
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_message (typeofNotice, mdate, doctor_id, patient_id, appointment_id, message)VALUES (@type , @date , @docId, @patId, @appId, @mes );"; 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Appointment");
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@docId", doctorId);
                cmd.Parameters.AddWithValue("@patId", patientId);
                cmd.Parameters.AddWithValue("@appId", appointmentId);
                cmd.Parameters.AddWithValue("@mes", patientName+" you have an appointment with "+doctorName+". \n Con#: "+confirmationNum+"\n Date: "+date);

                //excute and get NoteID
                noticeId = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            //update appointment in table

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE kodibrian_appointments SET notice_id = @noteId WHERE appointment_id = @appId"; 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noteId", noticeId);
                cmd.Parameters.AddWithValue("@appId", appointmentId);
                
                //excute
                cmd.ExecuteScalar();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

    }
}
