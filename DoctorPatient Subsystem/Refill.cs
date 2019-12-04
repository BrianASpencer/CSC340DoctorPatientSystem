using System;
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
        string timePeriod;
        int timesFilled;
        string medication;
        int noticeID;

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

        public void createRefill()
        {

        }

        public void retrieveRefillData()
        {

        }

        public void updateRefill()
        {

        }

        public void getRefillData()
        {

        }

    }
}
