using AntiClockFitnessCentreBAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre
{
    public partial class FullCalendar : System.Web.UI.Page
    {
       
        [WebMethod]
        public static IList GetEvents()
        {
            IList events = new List<Event>();
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                events.Add(new Event
                {
                    EventName = "My Event " + i.ToString(),
                    StartDate = DateTime.Now.AddDays(i).ToString("MM-dd-yyyy"),
                    EndDate = DateTime.Now.AddDays(1).ToString("MM-dd-yyyy"),
                    
                });
            }
            return events;
        }

        [WebMethod]
        public static IList GetEventsDetails(string userID)
        {
            EventsBL _EventsBL = new EventsBL();
            IList events = new List<Event>();
            DataTable _EventsDet = _EventsBL.GetEventDetails(userID);
            foreach (DataRow _Rows in _EventsDet.Rows)
            {
                Event _Event = new Event();
                _Event.EventID = Convert.ToInt32(_Rows["ScheduleID"].ToString());
                _Event.Subject = _Rows["ScheduleDetails"].ToString();
                _Event.StartDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                _Event.EndDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                _Event.Location = _Rows["Venu"].ToString();
                _Event.Attendents = _Rows["TrainerFullName"].ToString();
                _Event.StartDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                _Event.EndDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                events.Add(_Event);
            }

            return events;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public static class JSDateTime
    {
        public static string ToStr(DateTime dateTime)
        {
            return dateTime.ToString(@"MM\/dd\/yyyy");
        }

        public static string ToStrFor(DateTime dateTime)
        {
            return dateTime.ToString(@"dd-MMM-yyyy");
        }
    }


    public class Event
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string EventName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Location { get; set; }
        public string Attendents { get; set; }
        public string StartDateForm { get; set; }
        public string EndDateForm { get; set; }
    }
}