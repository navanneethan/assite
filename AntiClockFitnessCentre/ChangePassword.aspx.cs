using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        AntiClockFitnessCentreModal.UserDetails _userdetails = new AntiClockFitnessCentreModal.UserDetails();
        UserBL _userBL = new UserBL();
        byte[] imgByte = null;
        int userID;
        string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] == null)
                //{
                //    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                //    userID = Convert.ToInt32(_UserDetails.Rows[0]["UserID"].ToString());

                //}
            }

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                if (_UserDetails.Rows[0]["RoleId"].ToString() == "1")
                {
                    this.Page.MasterPageFile = "~/Admin/Admin.Master";
                }
                else if (_UserDetails.Rows[0]["RoleId"].ToString() == "2")
                {
                    this.Page.MasterPageFile = "~/Trainer/TrainerNew.Master";
                }
                else if (_UserDetails.Rows[0]["RoleId"].ToString() == "3")
                {
                    this.Page.MasterPageFile = "~/Trainee/TraineeNew.Master";
                }
            }

        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
                {
                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    userID = Convert.ToInt32(_UserDetails.Rows[0]["UserID"].ToString());
                    password = _UserDetails.Rows[0]["Password"].ToString();
                }
                if (password != txtOldPassword.Text)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Please Check your Old Password";
                    errorMsg.Visible = true;
                }

                password = txtConfirmPassword.Text;

                int _Result = _userBL.UpdatePassword(userID, password);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    lblSucess.Text = "Saved Sucessfully";
                    successMsg.Visible = true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error while saving";
                    errorMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}