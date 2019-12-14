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
    class Refill
    {
        int refillID;
        string timePeriod;
        int timesFilled;
        string medication;
        int noticeID;
        int doctorID;

        public Refill()
        {

        }

        public Refill(int id)
        {
            noticeID = id;
            getRefillData(id);
        }

        public int getRefillID()
        {
            return this.refillID;
        }

        public string getTimePeriod()
        {
            return this.timePeriod;
        }

        public int getTimesFilled()
        {
            return this.timesFilled;
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
            return doctorID;
        }

        public void createRefill()
        {

        }

        public ArrayList retrieveRefillList(int patientId)
        {
            ArrayList refillList = new ArrayList();

            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //prepare an SQL query to retrieve notice i from patient from patients
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT notice_id FROM kodibrian_message WHERE patient_id = @patId AND typeofNotice Like 'Refill';"; //placeholder for the real table name
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@patId", patientId);
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
                int tempNotId = Int32.Parse(row["notice_id"].ToString());
                refillList.Add(new Refill(tempNotId));
                
            }


            if (refillList.Count == 0)
            {
                return null;
            }
            return refillList;
        }

        public void updateRefill()
        {
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE kodibrian_refill SET notice_id = @noteId , timePeriod = @timeP , timesFilled = @timesF , medication = @med  WHERE appointment_id = @refillId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noteId", noticeID);
                cmd.Parameters.AddWithValue("@timeP", timePeriod);
                cmd.Parameters.AddWithValue("@timesF", timesFilled);
                cmd.Parameters.AddWithValue("@med", medication);
                cmd.Parameters.AddWithValue("@refillId", refillID);

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

        public void getRefillData(int id)
        {
            //prepare an SQL query to retrieve the patient 
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_refill WHERE notice_id = @notId;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notId", noticeID);
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
                timePeriod = row["timePeriod"].ToString();
                timesFilled = Int32.Parse(row["timesFilled"].ToString());
                medication = row["medication"].ToString();
                refillID = Int32.Parse(row["refill_id"].ToString());
                noticeID= Int32.Parse(row["notice_id"].ToString());
            }


            //get doctor id
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                string sql = "SELECT doctor_id FROM kodibrian_message WHERE refill_id =" +refillID+";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
            Console.WriteLine("\n\n\n"+myTable.Columns.Count+"\n"+myTable.Rows.Count+"");
            foreach (DataRow row in myTable.Rows)
            {
                string r = row["doctor_id"].ToString();
                Console.WriteLine("\n\n\n" + r + "\n\n\n");
                doctorID = Int32.Parse(row["doctor_id"].ToString());
                


            }


        }

    }
}
