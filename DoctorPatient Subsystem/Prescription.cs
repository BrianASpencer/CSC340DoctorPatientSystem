using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DoctorPatient_Subsystem
{
    class Prescription
    {
        int prescriptionID;
        int doctorID;
        int patientID;
        string status;
        string receivedTime;
        string pickUpTime;
        string medication;
        int noticeID;

        public Prescription()
        {

        }

        public Prescription(int docId, int patId, string stat, string rTime, string pTime, string med)
        {
            doctorID=docId;
            patientID=patId;
            status=stat;
            receivedTime=rTime;
            pickUpTime=pTime;
            medication=med;
            createPrescription();
        }

        public int getPrescriptionID()
        {
            return this.prescriptionID;
        }

        public string getStatus()
        {
            return this.status;
        }

        public string getReceivedTime()
        {
            return this.receivedTime;
        }

        public string getPickUpTime()
        {
            return this.pickUpTime;
        }

        public string getMedication()
        {
            return this.medication;
        }

        public int getNoticeID()
        {
            return this.noticeID;
        }

        public int getDoctorID()
        {
            return this.doctorID;
        }

        public int getPatientID()
        {
            return this.patientID;
        }

        public void createPrescription()
        {
            // prepare an SQL query to retrieve
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_prescriptions (pstatus, receivedTime, medication)VALUES (@status , @rTime , @med );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@rTime", receivedTime);
                cmd.Parameters.AddWithValue("@med", medication);               

                //excute and get preID
                prescriptionID = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO kodibrian_message (typeofNotice, mdate, doctor_id, patient_id, prescription_id)VALUES (@type , @date , @docId, @patId, @preId );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Pre");
                cmd.Parameters.AddWithValue("@date", receivedTime);
                cmd.Parameters.AddWithValue("@preId", prescriptionID);
                cmd.Parameters.AddWithValue("@patId", doctorID);
                cmd.Parameters.AddWithValue("@docId", patientID);

                //excute and get NoteID
                noticeID = Convert.ToInt32(cmd.ExecuteScalar());
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
                string sql = "UPDATE kodibrian_prescriptions SET notice_id = @noteId WHERE prescription_id = @preId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noteId", noticeID);
                cmd.Parameters.AddWithValue("@preId", prescriptionID);

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
