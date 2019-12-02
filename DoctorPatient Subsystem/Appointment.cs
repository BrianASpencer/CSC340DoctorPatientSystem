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
    class Appointment
    {
        int appointmentId;
        int doctorId;
        int patientId;
        int noticeId;
        string patientName;
        string doctorName;
        string date;
        string description;

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

        public String getPatientName()
        {
            return patientName;
        }

        public int getDoctortId()
        {
            return doctorId;
        }

        public String getDoctorName()
        {
            return doctorName;
        }

        public String getDate()
        {
            return date;
        }

        public String getDescription()
        {
            return description;
        }


        //retrieve data from database
        public void retreiveAppointmentData(int id)
        {
            //prepare an SQL query to retrieve
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            ArrayList List = new ArrayList();  //a list to save the data
            MySqlConnection conn = new MySqlConnection(connStr);

            //retrieve base info from appointment table

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM ******Table****** WHERE appointmentId = " + id; //placeholder for the real table name
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
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
              
                appointmentId = Int32.Parse(row["appointmentID"].ToString());
                noticeId = Int32.Parse(row["noticeID"].ToString());
                description = row["description"].ToString();
                date= row["date"].ToString();
               
            }

            //use notice id to retrieve patient id and doctor id from notice table

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT doctorId, patientId FROM ******Table****** WHERE noticeId = " + noticeId; //placeholder for the real table name
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
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                patientId = Int32.Parse(row["patientID"].ToString());
                doctorId = Int32.Parse(row["doctorID"].ToString());
                
            }

            //retrieve doctor name from doctor table
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT name FROM ******Table****** WHERE doctorId = " + doctorId; //placeholder for the real table name
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
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                doctorName = row["name"].ToString();

            }


            //retrieve patient name from patient table

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT name FROM ******Table****** WHERE patientId = " + patientId; //placeholder for the real table name
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
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                patientName= row["name"].ToString();
                
            }
            conn.Close();

        }

    }
}
