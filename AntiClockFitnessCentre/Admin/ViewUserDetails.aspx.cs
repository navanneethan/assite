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

namespace AntiClockFitnessCentre.Admin
{
    public partial class ViewUserDetails : System.Web.UI.Page
    {

        UserBL _userBL = new UserBL();
        string userID = "";
        int companyID = 1;
        int roleId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());
                roleId = Convert.ToInt32(_UserDetails.Rows[0]["RoleID"].ToString());

                if (!IsPostBack)
                {
                    LoadUserDetails();
                }
            }
        }

        private void LoadUserDetails()
        {
            try
            {
                DataTable _userdeialsTBL = _userBL.GetUserDetails(0, roleId, companyID);
                gvUserDetails.DataSource = _userdeialsTBL;
                gvUserDetails.DataBind();
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
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
                     Response.Redirect("UserDetails.aspx?i=" + Server.UrlEncode(_ID));
                 }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
        }

        protected void gvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gvUserDetails.PageIndex = e.NewPageIndex;
                LoadUserDetails();
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
        }
    }
}