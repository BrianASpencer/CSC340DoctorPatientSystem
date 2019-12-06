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

        public void retrieveRefillData()
        {

        }

        public ArrayList retrieveRefillList(int patientId)
        {
            ArrayList refillList = new ArrayList();

            //prepare an SQL query to retrieve the patient 
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "JOIN statement?? for id of patient's refill -- retrieve refill info?" + patientId; //placeholder for the real table name
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
                int reID = Int32.Parse(row["DoctorID"].ToString());
                string timeP = row["timePeriod"].ToString();
                int timesF = Int32.Parse(row["timesFilled"].ToString());
                string med = row["medication"].ToString();
                int noteID = Int32.Parse(row["noticeID"].ToString());
                int docID = Int32.Parse(row["DoctorID"].ToString());

                Refill loopRefill = new Refill(/*refillID, docID, noticeID, medication, timePeriod, timesFilled */);
                refillList.Add(loopRefill);
            }

            if (refillList.Count == 0)
            {
                return null;
            }
            return refillList;
        }

        public void updateRefill()
        {

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
                string sql = "JOIN statement?? for id of patient's refill -- retrieve refill info?" + id; //placeholder for the real table name
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
                timePeriod = row["timePeriod"].ToString();
                timesFilled = Int32.Parse(row["timesFilled"].ToString());
                medication = row["medication"].ToString();
                noticeID = Int32.Parse(row["noticeID"].ToString());
            }
        }

    }
}
