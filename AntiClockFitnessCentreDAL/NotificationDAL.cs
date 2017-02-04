using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace AntiClockFitnessCentreDAL
{
    public class NotificationDAL : MainDAL
    {
       
        public DataTable GetNotificationDetails(int UserID)
        {
            _DBManager.CommandText = StoredProcedure.GET_NOTIFICATION_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserID", UserID);
            _DBManager.Parameters = _Paramaters;

           return _DBManager.SelectTable();
        }

        public int InsertNotificationViewed(int eventId,int userId)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_NOTIFICATION_VIEWED;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("EventId", eventId);
            _Paramaters.Add("UserId", userId);
           
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("NotificationDAL", "InsertNotificationViewed-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }

            return _Result;
        }
    }
}
