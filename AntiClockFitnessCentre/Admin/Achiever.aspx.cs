  using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AntiClockFitnessCentreBAL;

namespace AntiClockFitnessCentre.Admin
{
    public partial class Achiever : System.Web.UI.Page
    {
        AchievementBL _achievementBL = new AchievementBL();
        UserBL _UserBL = new UserBL();
        string userID = "";
        string companyID = "";
        int achieverId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {

                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = _UserDetails.Rows[0]["CompanyID"].ToString();
                if (!IsPostBack)
                {
                    LoadUsers();
                    LoadAchievementMaster();
                    LoadAchieverDetails(0);
                }
            }

           
        }

        private void LoadUsers()
        {

            DataTable _UsersTBL = _UserBL.GetUserDetailsByRole(3, Convert.ToInt32(companyID), 0);
            if (_UsersTBL != null)
            {
                ddlAchiever.DataSource = _UsersTBL;
                ddlAchiever.DataTextField = "FullName";
                ddlAchiever.DataValueField = "UserID";
                ddlAchiever.DataBind();
            }
            AntiClockFitnessCenter.BindDropDownList(ref ddlAchiever, "--- Select ---", " ");

        }

        private void LoadAchievementMaster()
        {
             DataTable _AchievementsTBL =  _achievementBL.GetAchievementMaster(companyID);
             if (_AchievementsTBL != null)
             {
                 ddlAchievement.DataSource = _AchievementsTBL;
                 ddlAchievement.DataTextField = "AchievementDetails";
                 ddlAchievement.DataValueField = "AchievementID";
                 ddlAchievement.DataBind();
             }
             AntiClockFitnessCenter.BindDropDownList(ref ddlAchievement, "--- Select ---", " ");
           
        }

        private void LoadAchieverDetails(int AchieverId)
        {
            DataTable _AchieverDetailsTBL = _achievementBL.GetAchieverDetails(AchieverId);
            Session[AntiClockFitnessCenter.ACHIEVER_DETAILS] = _AchieverDetailsTBL;
            gvAchiever.DataSource = _AchieverDetailsTBL;
            gvAchiever.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (HfUpdateID.Value == "0")
                {
                    achieverId = 0;
                    lblSucess.Text = "Saved Sucessfully";
                }
                else
                {
                    achieverId = Convert.ToInt32(HfUpdateID.Value);
                    lblSucess.Text = "Updated Sucessfully";
                }

                int _Result = _achievementBL.InsertAchieverDetails(achieverId, Convert.ToInt32(ddlAchievement.SelectedValue), Convert.ToInt32(ddlAchiever.SelectedValue),Convert.ToDateTime(txtMonthFor.Text), Convert.ToInt32(userID),txtNumber.Text);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                   
                    IsSuccess(true);
                }
                clear();
                LoadAchieverDetails(0);

            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }
        private void IsSuccess(bool yes)
        {
           
            errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        private void clear()
        {
            btnSubmit.Text = "Submit";
            ddlAchievement.SelectedIndex = 0;
            ddlAchiever.SelectedIndex = 0;
            txtMonthFor.Text = string.Empty;
            txtNumber.Text = string.Empty;
            HfUpdateID.Value = "0";
        }

        protected void gvAchiever_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DataTable _achiverDetailsTBL = Session[AntiClockFitnessCenter.ACHIEVER_DETAILS] as DataTable;
                int _ID = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("RowDelete"))
                {
                    int result = _achievementBL.DeleteAchieverDetails(_ID, Convert.ToInt32(userID));
                    LoadAchieverDetails(0);
                }
                else if (e.CommandName.Equals("RowEdit"))
                {
                    foreach (DataRow _Rows in _achiverDetailsTBL.Rows)
                    {
                        if (_Rows["AchieverId"].ToString() == _ID.ToString())
                        {
                            HfUpdateID.Value = _ID.ToString();
                            ddlAchievement.SelectedValue = _Rows["AchieverDetailsId"].ToString();
                            ddlAchiever.SelectedValue = _Rows["AchieverUserId"].ToString();
                            txtMonthFor.Text = string.Format("{0:MMMM/yyyy}", Convert.ToDateTime(_Rows["AchievedMonthFor"].ToString()));
                            txtNumber.Text = _Rows["AchievedNumber"].ToString();

                            btnSubmit.Text = "Update";

                            break;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}