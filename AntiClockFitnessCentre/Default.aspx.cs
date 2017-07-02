using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["LOGIN_USER_DETAILS"] == null)
            //{
            //Response.Redirect("~/Login.aspx");
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                return;
            }
            AntiClockFitnessCenter.SendEmail("atsaipavipvtltd@gmail.com", txtSubject.Text+"-"+txtEmail.Text+"-"+txtName.Text, txtMessage.Text);
        }
    }
}