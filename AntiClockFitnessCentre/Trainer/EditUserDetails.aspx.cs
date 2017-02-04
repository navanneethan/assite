using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre.Trainer
{
    public partial class EditUserDetails : System.Web.UI.Page
    {
        UserBL _userBL = new UserBL();
        string userID = "";
        int companyID = 1;
        int roleID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
                {
                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    userID = _UserDetails.Rows[0]["UserID"].ToString();
                    Session[AntiClockFitnessCenter.LOGIN_USER_ID] = _UserDetails.Rows[0]["UserID"].ToString();
                    companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());
                    roleID = Convert.ToInt32(_UserDetails.Rows[0]["RoleID"].ToString());
                    LoadUserDetails();
                }
            }
        }
        private void LoadUserDetails()
        {
            DataTable _userdeialsTBL = _userBL.GetUserDetailsByRole(3, companyID, 0);
            gvUserDetails.DataSource = _userdeialsTBL;
            gvUserDetails.DataBind();
        }

        //protected void gvUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}

        //protected void gvUserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        string _ID = e.CommandArgument.ToString();
        //        if (e.CommandName.Equals("RowDelete"))
        //        {
        //            //int result = _userBL.DeleteUser(Convert.ToInt32(_ID));
        //            //LoadUserDetails();

        //        }
        //        else if (e.CommandName.Equals("RowEdit"))
        //        {
        //            //Response.Redirect("UserDetails.aspx?i=" + Server.UrlEncode(_ID));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void gvUserDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUserDetails.EditIndex = e.NewEditIndex;
            LoadUserDetails();
        }

        protected void gvUserDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUserDetails.EditIndex = -1;
            LoadUserDetails(); 
            
        }

        protected void gvUserDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtheight = (TextBox)gvUserDetails.Rows[e.RowIndex].FindControl("txtHeight");
            TextBox txtweight = (TextBox)gvUserDetails.Rows[e.RowIndex].FindControl("txtWeight");

            int txth = string.IsNullOrEmpty(txtheight.Text) ? 0 : Convert.ToInt32(txtheight.Text);
            int txtw = string.IsNullOrEmpty(txtweight.Text) ? 0 : Convert.ToInt32(txtweight.Text);

            int userid = Convert.ToInt32(gvUserDetails.DataKeys[e.RowIndex].Value.ToString());

            int _Result = _userBL.UpdateTraineeByTrainer(userid, txth, txtw);
            if (_Result == 1)
            {

            }

            gvUserDetails.EditIndex = -1;
            LoadUserDetails(); 
        }
    }
}