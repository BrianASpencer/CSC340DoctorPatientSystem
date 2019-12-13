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
    class Doctor
    {
        int idNumber;
        string name;
        string phoneNum;
        bool busyStatus;

        public Doctor()
        {

        }

        public Doctor(int id, string nam, string phoneN, bool busy)
        {
            idNumber = id;
            name = nam;
            phoneNum = phoneN;
            busyStatus = busy;
        }

        public int getIDNumber()
        {
            return this.idNumber;
        }

        public string getName()
        {
            return this.name;
        }

        public string getPhoneNum()
        {
            return this.phoneNum;
        }

        public bool getBusyStatus()
        {
            return this.busyStatus;
        }

        public void retrieveDoctorData(int id)
        {
            //prepare an SQL query to retrieve the patient 
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_doctor WHERE doctor_id = " + id; 
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
                idNumber = Int32.Parse(row["doctor_id"].ToString());
                name = row["dname"].ToString();
                phoneNum = row["phoneNum"].ToString();
                string status = row["isBusy"].ToString();
                busyStatus = status.Equals("True");
            }
        }

        public ArrayList retrieveDoctorList()
        {
            ArrayList doctorList = new ArrayList();

            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //prepare an SQL query to retrieve notice i from patient from patients
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_doctor ; "; //placeholder for the real table name
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
            foreach (DataRow row in myTable.Rows)
            {
                int docId = Int32.Parse(row["doctor_id"].ToString());
                string docN = row["dname"].ToString();
                string phoneN = row["phoneNum"].ToString();
                string status = row["isBusy"].ToString();
                bool busyStatusT = status.Equals("True");

                doctorList.Add(new Doctor(docId, docN, phoneN, busyStatusT));

            }


            if (doctorList.Count == 0)
            {
                return null;
            }
            return doctorList;
        }

        public ArrayList retrieveNonBusyDoctorList()
        {
            ArrayList doctorList = new ArrayList();

            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //prepare an SQL query to retrieve notice i from patient from patients
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_doctor WHERE isBusy = 0 ; "; //placeholder for the real table name
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
            foreach (DataRow row in myTable.Rows)
            {
                int docId = Int32.Parse(row["doctor_id"].ToString());
                string docN = row["dname"].ToString();
                string phoneN = row["phoneNum"].ToString();
                string status = row["isBusy"].ToString();
                bool busyStatusT = status.Equals("True");

                doctorList.Add(new Doctor(docId, docN, phoneN, busyStatusT));

            }


            if (doctorList.Count == 0)
            {
                return null;
            }
            return doctorList;
        }
    }
}
