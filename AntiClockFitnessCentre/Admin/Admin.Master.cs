using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AntiClockFitnessCentre.Admin
{
    public partial class Admin1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
            }
            if (!IsPostBack)
            {
                LoadUserdetails();
            }
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Page.Header.DataBind();
        //}

        private void LoadUserdetails()
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _loginUserTBL = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;

                if (_loginUserTBL.Rows.Count > 0)
                {

                    lblUserName.Text = _loginUserTBL.Rows[0]["FirstName"].ToString() + " " + _loginUserTBL.Rows[0]["LastName"].ToString();
                    imgProfileImage.ImageUrl = "ProfileImage.ashx?ID=" + _loginUserTBL.Rows[0]["UserID"].ToString() + "";
                }

            }
        }
    }
}