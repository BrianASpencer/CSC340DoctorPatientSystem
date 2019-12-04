using System;
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
        Boolean busyStatus;

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

        public Boolean getBusyStatus()
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
                string sql = "SELECT * FROM ******Doctor Table****** WHERE docID = " + id; //placeholder for the real table name
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
                idNumber = Int32.Parse(row["docID"].ToString());
                name = row["name"].ToString();
                phoneNum = row["phone"].ToString();
                string status = row["busyStatus"].ToString();
                busyStatus = status.Equals("True");
            }
        }

    }
}
