using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AntiClockFitnessCentreModal;
using System.Collections;

namespace AntiClockFitnessCentreDAL
{
    public class ScheduleDAL : MainDAL
    {
        public int InsertSchedule(ScheduleModal schedulemodal)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_EVENT_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", schedulemodal.userid);
            _Paramaters.Add("ExerciseId", schedulemodal.exerciseid);
            _Paramaters.Add("ExeDetails", schedulemodal.exercisedet);
            _Paramaters.Add("TrainerId", schedulemodal.trainerID);
            _Paramaters.Add("StartDate", schedulemodal.scheduleStartDate);
            _Paramaters.Add("EndDate", schedulemodal.scheduleEndDate);
            _Paramaters.Add("adminId", schedulemodal.createdby);
            _Paramaters.Add("venu", schedulemodal.venu);
            _Paramaters.Add("CompanyId", schedulemodal.ScheduleCompanyId);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                 CommonDAL _CommonDAL = new CommonDAL();
                 _CommonDAL.InsertException("ScheduleDAL", "InsertSchedule-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public int UpdateSchedule(ScheduleModal schedulemodal)
        {
            _DBManager.CommandText = StoredProcedure.UPDATE_EVENT_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleId", schedulemodal.scheduleid);
            _Paramaters.Add("UserId", schedulemodal.userid);
            _Paramaters.Add("ExerciseId", schedulemodal.exerciseid);
            _Paramaters.Add("ExeDetails", schedulemodal.exercisedet);
            _Paramaters.Add("TrainerId", schedulemodal.trainerID);
            _Paramaters.Add("StartDate", schedulemodal.scheduleStartDate);
            _Paramaters.Add("EndDate", schedulemodal.scheduleEndDate);
            _Paramaters.Add("adminId", schedulemodal.createdby);
            _Paramaters.Add("venu", schedulemodal.venu);
            _Paramaters.Add("CompanyId", schedulemodal.ScheduleCompanyId);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("ScheduleDAL", "UpdateSchedule-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetExercise()
        {
            _DBManager.CommandText = StoredProcedure.SELECT_EXERCISE;
          
            return _DBManager.SelectTable();
        }

        public DataTable GetSchedule(int scheduleid)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_SCHEDULE;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleId", scheduleid);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public DataTable GetSchedule(int companyid,string user)
        {
            _DBManager.CommandText = StoredProcedure.GET_SCHEDULE;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyID", companyid);
            _Paramaters.Add("UserID", user);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int DeleteSchedule(int scheduleid,string user)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_SCHEDULE;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleId", scheduleid);
            _Paramaters.Add("UserID", scheduleid);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("ScheduleDAL", "DeleteSchedule-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public int InsertScheduleEvent(int ScheduleEventId, string ScheduleEventName,int CompanyId, int AdminId)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_SCHEDULE_EVENT;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleEventId", ScheduleEventId);
            _Paramaters.Add("ScheduleEventName", ScheduleEventName);
            _Paramaters.Add("CompanyId", CompanyId);
            _Paramaters.Add("AdminId", AdminId);  

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("ScheduleDAL", "InsertScheduleEvent-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetScheduleEvent(int ScheduleEventId,int CompanyId)
        {
            _DBManager.CommandText = StoredProcedure.GET_SCHEDULE_EVENT;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleEventId", ScheduleEventId);
            _Paramaters.Add("CompanyId", CompanyId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }
        public int DeleteScheduleEvent(int ScheduleEventId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_SCHEDULE_EVENT;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ScheduleEventId", ScheduleEventId);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("ScheduleDAL", "DeleteScheduleEvent-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }
    }
}
