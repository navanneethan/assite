using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class ScheduleBL
    {
        ScheduleDAL _scheduleDAL = new ScheduleDAL();

        public int InsertSchedule(ScheduleModal schedulemodal)
        {
            return _scheduleDAL.InsertSchedule(schedulemodal);
        }

        public int UpdateSchedule(ScheduleModal schedulemodal)
        {
            return _scheduleDAL.UpdateSchedule(schedulemodal);
        }

        public DataTable GetExercise()
        {
            return _scheduleDAL.GetExercise();
        }

        public DataTable GetSchedule(int scheduleid)
        {
            return _scheduleDAL.GetSchedule(scheduleid);
        }
        public DataTable GetSchedule(int companyid, string user)
        {
            return _scheduleDAL.GetSchedule(companyid, user);
        }

        public int DeleteSchedule(int scheduleid, string user)
        {
            return _scheduleDAL.DeleteSchedule(scheduleid,user);
        }

        public int InsertScheduleEvent(int ScheduleEventId, string ScheduleEventName, int CompanyId, int AdminId)
        {
            return _scheduleDAL.InsertScheduleEvent(ScheduleEventId, ScheduleEventName, CompanyId, AdminId);
        }

        public DataTable GetScheduleEvent(int ScheduleEventId, int CompanyId)
        {
            return _scheduleDAL.GetScheduleEvent(ScheduleEventId, CompanyId);
        }

         public int DeleteScheduleEvent(int ScheduleEventId)
        {
            return _scheduleDAL.DeleteScheduleEvent(ScheduleEventId);
        }

    }
}
