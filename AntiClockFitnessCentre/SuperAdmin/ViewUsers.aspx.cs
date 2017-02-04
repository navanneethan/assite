using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AntiClockFitnessCentreBAL;
using System.Data.SqlClient;
using System.Data;
using AntiClockFitnessCentreModal;

namespace AntiClockFitnessCentre.SuperAdmin
{
    public partial class ViewUsers : System.Web.UI.Page
    { 
            UserBL _userBL = new UserBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                if (!IsPostBack)
                {
                    LoadUserDetails();
                }
            }
        }

        private void LoadUserDetails()
        {
            DataTable _userdeialsTBL = _userBL.GetUserDetails(0);
            gvUserDetails.DataSource = _userdeialsTBL;
            gvUserDetails.DataBind();
        }

        protected void gvUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvUserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                 string _ID = e.CommandArgument.ToString();
                 if (e.CommandName.Equals("RowDelete"))
                 {
                     int result = _userBL.DeleteUser(Convert.ToInt32(_ID));
                     LoadUserDetails();
                    
                 }
                 else if (e.CommandName.Equals("RowEdit"))
                 {
                     Response.Redirect("AddUsers.aspx?i=" + Server.UrlEncode(_ID));
                 }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = false;
            }
        }

        protected void gvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            gvUserDetails.PageIndex = e.NewPageIndex;
            LoadUserDetails();
        }
    }
}