using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;

namespace AntiClockFitnessCentre
{
    /// <summary>
    /// Summary description for WebSe
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebSe : System.Web.Services.WebService
    {

        [WebMethod]
        public CalendarData GetCalData(string userID)
        {
            return null;
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
                return dateTime.ToString(@"MM\/dd\/yyyy HH:mm");
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
    }
}
