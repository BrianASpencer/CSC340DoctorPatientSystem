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
                patientId = Int32.Parse(row["patientID"].ToString());
                name = row["name"].ToString();
                address = row["address"].ToString();
                phoneNumber = row["phoneNumber"].ToString();
                dateOfBirth = row["birth"].ToString();
                drugAllergies = row["allergies"].ToString();
            }

        }

    }
}
