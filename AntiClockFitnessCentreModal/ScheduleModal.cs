using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreModal
{
    public class ScheduleModal
    {
        public int scheduleid;
        public int userid;
        public int trainerID;
        public int exerciseid;
        public string exercisedet;
        public DateTime scheduleStartDate;
        public DateTime scheduleEndDate;
        public bool status;        
        public string createdby = string.Empty;
        public string venu;
        public int ScheduleCompanyId;
    }
}
