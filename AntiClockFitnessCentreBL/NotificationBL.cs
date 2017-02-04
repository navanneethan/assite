using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class NotificationBL
    {
        NotificationDAL _NotificationDAL = new NotificationDAL();

       
        public DataTable GetNotificationDetails(int UserID)
        {
            return _NotificationDAL.GetNotificationDetails(UserID);
        }

        public int InsertNotificationViewed(int eventId, int userId)
        {
            return _NotificationDAL.InsertNotificationViewed(eventId, userId);
        }
    }
}
