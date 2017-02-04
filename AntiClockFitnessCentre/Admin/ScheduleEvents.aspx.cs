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
    public partial class ScheduleEvents : System.Web.UI.Page
    {
        ScheduleBL _scheduleEventsBL = new ScheduleBL();
        UserBL _UserBL = new UserBL();
        int userID = 1;
        int companyID = 1;
        int scheduleEventId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = Convert.ToInt32(_UserDetails.Rows[0]["UserID"].ToString());
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());
                if (!IsPostBack)
                {
                    HfUpdateID.Value = "0";
                    LoadScheduleEvents();
                }
            }
        }

        public void LoadScheduleEvents()
        {
            try
            {
               // DataTable _ScheduleEventsTBL = _scheduleEventsBL.
                gvEventMaster.DataSource = _scheduleEventsBL.GetScheduleEvent(0, companyID);
                gvEventMaster.DataBind();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //string _achievement = txtAchievement.Text;
                if (HfUpdateID.Value == "0")
                {
                    scheduleEventId = 0;
                    lblSucess.Text = "Saved Sucessfully";
                }
                else
                {
                    scheduleEventId = Convert.ToInt32(HfUpdateID.Value);
                    lblSucess.Text = "Updated Sucessfully";
                }

                int _Result = _scheduleEventsBL.InsertScheduleEvent(scheduleEventId, txtEvent.Text, companyID, userID);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    
                    IsSuccess(true);
                }
                LoadScheduleEvents();
                Clear();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
                HfUpdateID.Value = "0";
            }
        }

        public void Clear()
        {
            txtEvent.Text = string.Empty;
            HfUpdateID.Value = "0";
           
            btnSubmit.Text = "Save";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void gvEventMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("RowDelete"))
                {
                    int _ID = Convert.ToInt32(e.CommandArgument);
                    //int _ID = Convert.ToInt32(gvAchevementMaster.DataKeys[index].Value.ToString());
                    int result = _scheduleEventsBL.DeleteScheduleEvent(_ID);
                    LoadScheduleEvents();
                }
                else if (e.CommandName.Equals("RowEdit"))
                {
                    string value = e.CommandArgument.ToString();

                    int index = value.IndexOf('-');
                    int length = value.Length - 2;
                    HfUpdateID.Value = value.Substring(0, index);
                    txtEvent.Text = value.Substring(index + 1, length);
                   
                    btnSubmit.Text = "Update";

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
                
            }
        }
    }
}