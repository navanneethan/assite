using AntiClockFitnessCentreBAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace AntiClockFitnessCentre
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EventServices
    {
        EventsBL _EventsBL = new EventsBL(); 
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [WebInvoke(Method = "POST", UriTemplate = "GetCalData/{userID}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        public IList GetCalData(string userID)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            IList _events = new List<Event>();
            //{
            //    new Event(){Id = 1,
            //               Subject = "Test",
            //               StartDate = JSDateTime.ToStr(DateTime.Now.Date),
            //               EndDate =  JSDateTime.ToStr(DateTime.Now.Date.AddHours(11)),
            //               IsAllDayEvent = 1,
            //               IsEditable = 0,
            //               IsMoreThanOneDayEvent =0,
            //               Attendents ="",
            //               Location="Noida",
            //               RecurringEvent = 0,
            //               Color = 2},

            //      new Event(){Id = 2,
            //               Subject = "More Test",
            //               StartDate =  JSDateTime.ToStr( DateTime.Now.Date.AddDays(1)),
            //               EndDate =  JSDateTime.ToStr(DateTime.Now.Date.AddHours(45)),
            //               IsAllDayEvent = 1,
            //               IsEditable = 0,
            //               IsMoreThanOneDayEvent =0,
            //               Attendents ="",
            //               Location="Delhi",
            //               RecurringEvent = 0,
            //               Color = 4}
            
            //};
            //if (HttpContext.Current.Session["LOGIN_USER_DETAILS"] != null)
            {
                //DataTable _UserDetails = HttpContext.Current.Session["LOGIN_USER_DETAILS"] as DataTable;
                DataTable _EventsDet = _EventsBL.GetEventDetails(userID);
                foreach (DataRow _Rows in _EventsDet.Rows)
                {
                    Event _Event = new Event();
                    _Event.Id = Convert.ToInt32(_Rows["ScheduleID"].ToString());
                    _Event.Subject = _Rows["ScheduleDetails"].ToString();
                    _Event.StartDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                    _Event.EndDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                    _Event.Location = _Rows["Venu"].ToString();
                    _Event.Attendents = _Rows["TrainerFullName"].ToString();
                    _Event.StartDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                    _Event.EndDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                    //_Event.Subject = _Rows["ScheduleDetails"].ToString();
                    //_Event.StartDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                    //_Event.EndDate = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                    //_Event.Subject = _Rows["TrainerFullName"].ToString();
                    //_Event.Color = Convert.ToInt32(_Rows["ExerciseID"].ToString());
                    //_Event.StartDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["StartDate"].ToString()));
                    //_Event.EndDateForm = JSDateTime.ToStrFor(Convert.ToDateTime(_Rows["EndDate"].ToString()));
                    //_Event.Location = _Rows["ScheduleDetails"].ToString();
                    //_Event.Attendents = _Rows["Venu"].ToString();
                    _events.Add(_Event);
                }
            }

            //CalendarData objCalData = new CalendarData();
            //objCalData.events = new List<ArrayList>();

            //foreach (var item in _events)
            //{
            //    objCalData.events.Add(ConvertToArrayList<Event>(item));
            //}

            //objCalData.issort = true;
            //objCalData.start = JSDateTime.ToStr(new DateTime(2013, 7, 1));
            //objCalData.end = JSDateTime.ToStr(new DateTime(2013, 7, 31));
            //objCalData.error = null;
            return _events;

        }

        [DataContract]
        public class CalendarData
        {
            [DataMember(Order = 1)]
            public List<ArrayList> events { get; set; }
            [DataMember(Order = 2)]
            public bool issort { get; set; }
            [DataMember(Order = 3)]
            public string start { get; set; }
            [DataMember(Order = 4)]
            public string end { get; set; }
            [DataMember(Order = 5)]
            public string error { get; set; }
        }
        // Use a data contract as illustrated in the sample below to add composite types to service operations.


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
            [DataMember(Name = "id")]
            public int Id { get; set; }
            [DataMember]
            public string Subject { get; set; }
            [DataMember]
            public string StartDate { get; set; }
            [DataMember]
            public string EndDate { get; set; }
            [DataMember]
            public int IsAllDayEvent { get; set; }
            [DataMember]
            public int IsMoreThanOneDayEvent { get; set; }
            [DataMember]
            public int RecurringEvent { get; set; }
            [DataMember]
            public int Color { get; set; }
            [DataMember]
            public int IsEditable { get; set; }
            [DataMember]
            public string Location { get; set; }
            [DataMember]
            public string Attendents { get; set; }
            [DataMember]
            public string StartDateForm { get; set; }
            [DataMember]
            public string EndDateForm { get; set; }
        }

        public ArrayList ConvertToArrayList<T>(T obj)
        {
            ArrayList ls = new ArrayList();
            PropertyInfo[] p = obj.GetType().GetProperties();
            foreach (var item in p)
            {
                ls.Add(item.GetValue(obj, null));
            }
            return ls;
        }


        // Add more operations here and mark them with [OperationContract]
    }
}
