using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.Data;

namespace AntiClockFitnessCentre.Admin
{
    public partial class AchievementMaster : System.Web.UI.Page
    {
        AchievementBL _achievementBL = new AchievementBL();
        UserBL _UserBL = new UserBL();
        string userID = "";
        string companyID = "";
        int achieverMasterId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = _UserDetails.Rows[0]["CompanyID"].ToString();
                if (!IsPostBack)
                {
                    HfUpdateID.Value = "0";
                    LoadAchievementMaster();
                }
            }
           
        }

        private void LoadAchievementMaster()
        {
            gvAchevementMaster.DataSource = _achievementBL.GetAchievementMaster(companyID);
            gvAchevementMaster.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //string _achievement = txtAchievement.Text;
                if (HfUpdateID.Value == "0")
                    achieverMasterId = 0;
                else
                    achieverMasterId = Convert.ToInt32(HfUpdateID.Value);

                int _Result = _achievementBL.InsertAchievementMaster(achieverMasterId,txtAchievement.Text, userID, companyID);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    lblSucess.Text = "Saved Sucessfully";
                    IsSuccess(true);
                }
                LoadAchievementMaster();
                txtAchievement.Text = string.Empty;
                HfUpdateID.Value = "0";
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
                HfUpdateID.Value = "0";
            }
        }

        private void IsSuccess(bool yes)
        {
            //if (yes == false)
            //    errorMsg.Style.Add("display", "block");
            //else
            //    errorMsg.Style.Add("display", "none");

            errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        protected void gvAchevementMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
           
            if (e.CommandName.Equals("RowDelete"))
            {
                int _ID = Convert.ToInt32(e.CommandArgument);
                //int _ID = Convert.ToInt32(gvAchevementMaster.DataKeys[index].Value.ToString());
                int result = _achievementBL.DeleteAchievementMaster(_ID, Convert.ToInt32(userID));
                LoadAchievementMaster();
            }
            else if(e.CommandName.Equals("RowEdit"))
            {
                string value = e.CommandArgument.ToString();
                
                int index  = value.IndexOf('-');
                int length = value.Length - 2;
                HfUpdateID.Value = value.Substring(0, index);
                txtAchievement.Text = value.Substring(index + 1, length);
               

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAchievement.Text = string.Empty;
            HfUpdateID.Value = "0";
        }
    }
}