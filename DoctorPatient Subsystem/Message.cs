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
    class Message
    {
        int noticeID;
        string typeOfNotice;
        string date;
        int doctorID;
        int patientID;
        int prescriptionID;
        int refillID;
        string message;
        int appointment;
        bool isGranted;

        public Message()
        {

        }

        public Message(int notID, string type, string date, int docID, int preID, int reID, string msg, int app)
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

        public Message(string type, int docID, int patID, string msg)
        {
            this.typeOfNotice = type;
            this.doctorID = docID;
            this.patientID = patID;
            this.message = msg;

            //insert new message
        }

        public Message(string type, int docID, int patID, int reID)
        {
            this.typeOfNotice = type;
            this.doctorID = docID;
            this.patientID = patID;
            this.refillID = reID;

            //insert new message
        }

        public Message(string type, int docId, int patId,String msg, bool permision)
        {
            //inset new message
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

        public bool getisGranted()
        {
            return isGranted;
        }

        public void setIsGranted(bool logic)
        {
            isGranted = logic;
        }


        public void createMessage()
        {
            //SQL INSERT Statement goes here
        }

        public ArrayList retrieveMessagesList(string whereVar, int key)
        {
            return null;
        }

    }
}
