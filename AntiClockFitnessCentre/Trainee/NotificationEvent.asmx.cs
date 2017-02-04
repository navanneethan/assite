using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AntiClockFitnessCentre.Trainee
{
    /// <summary>
    /// Summary description for NotificationEvent
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NotificationEvent : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession=true)]
    
        public void InsertNotificationView(string userID)
        {
            NotificationBL _NotificationBL = new NotificationBL();
            DataTable _NotificationViewTBL = System.Web.HttpContext.Current.Session[AntiClockFitnessCenter.NOTIFICATION_DETAILS] as DataTable;

            if (_NotificationViewTBL.Rows.Count > 0 && _NotificationViewTBL != null)
            {
                for (int i = 0; i < _NotificationViewTBL.Rows.Count; i++)
                {
                    int _Result = _NotificationBL.InsertNotificationViewed(Convert.ToInt32(_NotificationViewTBL.Rows[i]["ScheduleID"].ToString()), Convert.ToInt32(userID));
                   // int _Result = _NotificationBL.InsertNotificationViewed(2, Convert.ToInt32(userID));
                }
            }

            
        }
    }
}
