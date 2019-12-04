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
        string status;
        string receivedTime;
        string pickUpTime;
        string medication;
        int noticeID;

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

        public void createPrescription()
        {
            //insert statement for DB?
        }

        public void prescriptionData()
        {

        }

        public void updatePrescription()
        {
            //maybe delete table entry in DB and insert new one?
        }

    }
}
