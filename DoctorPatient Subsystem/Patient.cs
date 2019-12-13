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
    class Patient
    {
        int patientId;
        string name;
        string phoneNumber;
        string dateOfBirth;
        string drugAllergies;
        string address;
        string medRecord;

        public Patient(int patId, string patN, string phoneN, string dOB, string drugAl, string add, string medRec)
        {
            patientId = patId;
            name = patN;
            phoneNumber = phoneN;
            dateOfBirth = dOB;
            drugAllergies = drugAl;
            address = add;
            medRecord = medRec;
        }

        //gets
        public int getId()
        {
            return patientId;
        }

        public string getName()
        {
            return name;
        }

        public string getPhoneNum()
        {
            return phoneNumber;
        }

        public string getBirth()
        {
            return dateOfBirth;
        }

        public string getAllergies()
        {
            return drugAllergies;
        }

        public string getAdress()
        {
            return address;
        }

        public string getMedRecord()
        {
            return medRecord;
        }

        public ArrayList retreivePatientList(string key)
        {
            ArrayList patientList = new ArrayList();

            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //prepare an SQL query to retrieve notice i from patient from patients
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_patients WHERE pName LIKE @name ; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", key);
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
                int patId = Int32.Parse(row["patient_id"].ToString());
                string patN = row["pname"].ToString();
                string phoneN = row["phoneNum"].ToString();
                string dOB = row["dateOfBirth"].ToString();
                string drugAl = row["drugAllergies"].ToString();
                string add = row["address"].ToString();
                string medRec = row["medRecord"].ToString();

                patientList.Add(new Patient(patId, patN, phoneN, dOB, drugAl, add, medRec));

            }

            if (patientList.Count == 0)
            {
                return null;
            }
            return patientList;
        }

        //retrieve data from database
        public void retreivePatientData(int id)
        {

            //prepare an SQL query to retrieve the patient 
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kodibrian_patients WHERE patientId = @patId ;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@patId", id);
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
                patientId = Int32.Parse(row["patient_id"].ToString());
                name = row["pname"].ToString();
                address = row["address"].ToString();
                phoneNumber = row["phoneNum"].ToString();
                dateOfBirth = row["dateOfBirth"].ToString();
                drugAllergies = row["drugAllergies"].ToString();
                medRecord = row["medRecord"].ToString();
            }

        }

    }
}
