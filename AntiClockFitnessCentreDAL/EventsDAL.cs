using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class EventsDAL: MainDAL
    {
        public DataTable GetEventDetails(string userID)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_EVENT_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", userID);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int InsertUser(string userID,string exerciseId,string exercisedetails,string trainerId,string startDate,string endDate,string adminID)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_EVENT_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", userID);
            _Paramaters.Add("ExerciseId", exerciseId);
            _Paramaters.Add("ExeDetails", exercisedetails);
            _Paramaters.Add("TrainerId", trainerId);
            _Paramaters.Add("StartDate", startDate);
            _Paramaters.Add("EndDate", endDate);
            _Paramaters.Add("adminId", adminID);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result != -1)
            {
                // CommonDAL _CommonDAL = new CommonDAL();
                //_CommonDAL.InsertException("UserRegistrationDAL", "UpdateUser-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }
    }
}
