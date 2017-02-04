using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        UserBL _userBL = new UserBL();
        string userName = string.Empty;
        string password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                userName = txtUserName.Text;

                string _Result = _userBL.SelectPassword(userName);
                if (_Result == "-1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error while retriving data.Please try again later";
                    failedmsg.Visible = true;
                    lblpassword.Visible = false;
                    
                   
                }
                if (_Result == "222")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Please, check your Username";
                    failedmsg.Visible = true;
                    lblpassword.Visible = false;

                }
                else
                {
                    lblpassword.Text = "Your password is :" + _Result;
                    txtUserName.Text = string.Empty;
                    lblpassword.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                failedmsg.Visible = true;
                lblpassword.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", false);
        }
    }
}