using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AntiClockFitnessCentreBAL;
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;

namespace AntiClockFitnessCentre
{
    public partial class Login : System.Web.UI.Page
    {
        UserBL _UserBL = new UserBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
                {
                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    validateUser(_UserDetails);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
                {
                    DataTable _UserDetails = _UserBL.ValidateUser(username, password);
                    validateUser(_UserDetails);
                    
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = "Problem in login. Please try after sometime.";
                failedmsg.Visible = true;
            }
        }

        private void validateUser(DataTable _UserDetails)
        {
            if (_UserDetails != null && _UserDetails.Rows.Count > 0)
            {
                Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] = _UserDetails;
                Session["UsrID"] = _UserDetails.Rows[0]["UserID"].ToString();
                Session["CompanyName"] = _UserDetails.Rows[0]["CompanyName"].ToString();




                if (_UserDetails.Rows[0]["RoleID"].ToString() == "1")
                {
                    Response.Redirect("~/Admin/HomePage.aspx", false);
                }
                else if (_UserDetails.Rows[0]["RoleID"].ToString() == "2")
                {
                    Response.Redirect("~/Trainer/HomePage.aspx", false);
                }
                //else if (_UserDetails.Rows[0]["RoleID"].ToString() == "3")
                //{
                //    Response.Redirect("~/Trainee/HomePage.aspx", false);
                //}
                else if (_UserDetails.Rows[0]["RoleID"].ToString() == "3" && _UserDetails.Rows[0]["PayStatus"].ToString() == "1")
                {
                    Response.Redirect("~/Trainee/HomePage.aspx", false);
                }
                else if (_UserDetails.Rows[0]["RoleID"].ToString() == "3" && (_UserDetails.Rows[0]["PayStatus"].ToString() == "0" || _UserDetails.Rows[0]["PayStatus"].ToString() == "2"))
                {
                    Session["PaymentUserID"] = _UserDetails.Rows[0]["UserID"].ToString();
                    Response.Redirect("~/Payment/PayDetails.aspx", false);
                }
                else if (_UserDetails.Rows[0]["RoleID"].ToString() == "4")
                {
                    Response.Redirect("~/SuperAdmin/Homepage.aspx", false);
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }

              

                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = "Invalid username/password.";
                failedmsg.Visible = true;
            }
        }
      
    }
}