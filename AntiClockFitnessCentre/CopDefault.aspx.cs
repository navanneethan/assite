using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre
{
    public partial class CopDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["LOGIN_USER_DETAILS"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            string subject = AntiClockFitnessCenter.ReadXML(@"ACHF/NewUser/Subject");
            string body = AntiClockFitnessCenter.ReadXML(@"ACHF/NewUser/Body");
            body = string.Format(body, "Test "+DateTime.Now.ToString(), "password123");
            AntiClockFitnessCenter.SendEmail("navanneethan@gmail.com", subject, body);
        }
    }
}