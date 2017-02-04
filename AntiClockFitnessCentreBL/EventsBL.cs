using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class EventsBL
    {
        EventsDAL _EventsDAL = new EventsDAL();

        public DataTable GetEventDetails(string userID)
        {
            return _EventsDAL.GetEventDetails(userID);
        }

        public int InsertUser(string userID, string exerciseId, string exercisedetails, string trainerId, string startDate, string endDate, string adminID)
        {
            return _EventsDAL.InsertUser( userID,  exerciseId,  exercisedetails,  trainerId,  startDate,  endDate,  adminID);
        }

    }
}
