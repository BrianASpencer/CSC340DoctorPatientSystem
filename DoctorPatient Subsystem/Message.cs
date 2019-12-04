using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace DoctorPatient_Subsystem
{
    class Message
    {
        int noticeID;
        string typeOfNotice;
        string date;
        int doctorID;
        int prescriptionID;
        int refillID;
        string message;
        int appointment;

        Message(int notID, string type, string date, int docID, int preID, int reID, string msg, int app)
        {
            this.noticeID = notID;
            this.typeOfNotice = type;
            this.date = date;
            this.doctorID = docID;
            this.prescriptionID = docID;
            this.refillID = reID;
            this.message = msg;
            this.appointment = app;
        }

        public int getNoticeID()
        {
            return this.noticeID;
        }

        public string getTypeOfNotice()
        {
            return this.typeOfNotice;
        }

        public string getDate()
        {
            return this.date;
        }

        public int getDoctorID()
        {
            return this.doctorID;
        }

        public int getPrescriptionID()
        {
            return this.prescriptionID;
        }

        public int getRefillID()
        {
            return this.refillID;
        }

        public string getMessage()
        {
            return this.message;
        }

        public int getAppointment()
        {
            return this.appointment;
        }

        public void createMessage()
        {
            //SQL INSERT Statement goes here
        }

    }
}
