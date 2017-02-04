using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.IO;
using System.Globalization;

namespace AntiClockFitnessCentre.Admin
{
    public partial class Schedule : System.Web.UI.Page
    {
        ScheduleBL _scheduleBL = new ScheduleBL();
        ScheduleModal _schedulemodal = new ScheduleModal();
        UserBL _UserBL = new UserBL();
        string userID = "";
        int companyID = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                Session[AntiClockFitnessCenter.LOGIN_USER_ID] = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());

                if (!IsPostBack)
                {
                    LoadExercise();
                    LoadUsers();
                    LoadTrainee(companyID);
                    LoadSchedule();
                }
            }

        }


        private void LoadUsers()
        {
            try
            {
                DataTable _UsersTBL = _UserBL.GetUserDetailsByRole(3, companyID, 0);
                if (_UsersTBL != null && _UsersTBL.Rows.Count > 0)
                {
                    ddlUser.DataSource = _UsersTBL;
                    ddlUser.DataTextField = "FullNameMember";
                    ddlUser.DataValueField = "UserID";
                    ddlUser.DataBind();
                }
                AntiClockFitnessCenter.BindDropDownList(ref ddlUser, "- Select All -", "0");
                AntiClockFitnessCenter.BindDropDownList(ref ddlUser, "--- Select ---", " ");
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
            
        }

        private void LoadTrainee(int companyID)
        {
            try
            {
                DataTable _UsersTrainersTBL = _UserBL.GetUserDetailsByRole(2, companyID, 0);
                if (_UsersTrainersTBL != null && _UsersTrainersTBL.Rows.Count > 0)
                {
                    ddlTrainer.DataSource = _UsersTrainersTBL;
                    ddlTrainer.DataTextField = "FullName";
                    ddlTrainer.DataValueField = "UserID";
                    ddlTrainer.DataBind();
                }
                AntiClockFitnessCenter.BindDropDownList(ref ddlTrainer, "--- Select ---", " ");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }

        }

        private void LoadExercise()
        {
            try
            {
                DataTable _ScheduleTBL = _scheduleBL.GetScheduleEvent(0, companyID);
                ddlExercise.DataSource = _ScheduleTBL;
                ddlExercise.DataTextField = "ExerciseName";
                ddlExercise.DataValueField = "ExerciseId";
                ddlExercise.DataBind();
                AntiClockFitnessCenter.BindDropDownList(ref ddlExercise, "--- Select ---", " ");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }

        private void LoadSchedule()
        {
            try
            {
                DataTable _ScheduleDet = _scheduleBL.GetSchedule(companyID, "0");
                if (_ScheduleDet.Rows.Count > 0 && _ScheduleDet != null)
                {
                    Session[AntiClockFitnessCenter.SCHEDULE_DETAILS] = _ScheduleDet;
                    gvSchedule.DataSource = _ScheduleDet;
                    gvSchedule.DataBind();
                }
                else
                {
                    Session[AntiClockFitnessCenter.SCHEDULE_DETAILS] = null;
                    gvSchedule.DataSource = null;
                    gvSchedule.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _schedulemodal.exerciseid = Convert.ToInt32(ddlExercise.SelectedValue);
                _schedulemodal.exercisedet = ddlExercise.SelectedItem.Text;
                _schedulemodal.userid = Convert.ToInt32(ddlUser.SelectedValue);
                _schedulemodal.trainerID = Convert.ToInt32(ddlTrainer.SelectedValue);
                _schedulemodal.venu = txtVenu.Text;
                _schedulemodal.ScheduleCompanyId = companyID;
                _schedulemodal.scheduleStartDate = DateTime.ParseExact(txtScheduleDate.Text, "dd MMMM yyyy - h:mm tt", CultureInfo.InvariantCulture);
                _schedulemodal.scheduleEndDate = DateTime.ParseExact(txtEndDate.Text, "dd MMMM yyyy - h:mm tt", CultureInfo.InvariantCulture);

                _schedulemodal.createdby = userID;// "AdminAlexy";
                //_schedulemodal.createdon = DateTime.Now;

                if (hdMode.Value == "Save")
                {
                    //_schedulemodal.status = true;
                    _schedulemodal.scheduleid = 0;

                    int _Result = _scheduleBL.InsertSchedule(_schedulemodal);
                    if (_Result == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                        lblSucess.Text = "Saved Sucessfully";
                        IsSuccess(true);

                        LoadSchedule();
                        Clear();

                        btnSave.Text = "Save";
                        hdMode.Value = "Save";
                    }
                    if(_Result == -1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Error Occured While Saving Data";
                        IsSuccess(false);
                    }
                }
                else if (hdMode.Value == "Update")
                {
                    //_schedulemodal.status = ckbStatus.Checked ? true : false;
                    _schedulemodal.scheduleid = Convert.ToInt32(hdID.Value);

                    int _Result = _scheduleBL.UpdateSchedule(_schedulemodal);
                    if (_Result == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                        lblSucess.Text = "Updated Sucessfully";
                        IsSuccess(true);

                        LoadSchedule();
                        Clear();

                        btnSave.Text = "Save";
                        hdMode.Value = "Save";
                    }
                    if (_Result == -1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Error Occured While Saving Data";
                        IsSuccess(false);
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

        private void IsSuccess(bool yes)
        {
            errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        private void Clear()
        {
            ddlExercise.SelectedIndex = 0;
            ddlUser.SelectedIndex = 0;
            ddlTrainer.SelectedIndex = 0;
            txtEndDate.Text = string.Empty;
           // ckbStatus.Checked = false;
            txtScheduleDate.Text = string.Empty;
            txtVenu.Text = string.Empty;
            //errorMsg.Visible = false;
            //successMsg.Visible = false;
            //lblError.Text = string.Empty;
            //lblSucess.Text = string.Empty;
            btnSave.Text = "Save";
            hdMode.Value = "Save";
        }

        protected void gvSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DataTable _fileUploadsTL = Session[AntiClockFitnessCenter.SCHEDULE_DETAILS] as DataTable;
               
                string _ID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("RowDelete"))
                {
                    int result = _scheduleBL.DeleteSchedule(Convert.ToInt32(_ID), Session[AntiClockFitnessCenter.LOGIN_USER_ID].ToString());
                    LoadSchedule();
                }
                else if (e.CommandName.Equals("RowEdit"))
                {
                   
                    foreach (DataRow _Rows in _fileUploadsTL.Rows)
                    {
                        if (_Rows["ScheduleID"].ToString() == _ID)
                        {
                            hdID.Value = _ID;
                            //hdFilePath.Value = _Rows["TrasactionLocation"].ToString();
                            ddlExercise.SelectedValue = _Rows["ExerciseID"].ToString();
                            ddlUser.SelectedValue = _Rows["TraineeID"].ToString();
                            ddlTrainer.SelectedValue = _Rows["TrainerID"].ToString();
                            txtScheduleDate.Text = string.Format("{0:dd MMMM yyyy - h:mm tt}", Convert.ToDateTime(_Rows["StartDate"].ToString()));
                            txtEndDate.Text = string.Format("{0:dd MMMM yyyy - h:mm tt}", Convert.ToDateTime(_Rows["EndDate"].ToString()));
                            txtVenu.Text = _Rows["Venu"].ToString();

                            //if (_Rows["Status"].ToString() == "True")
                            //    ckbStatus.Checked = true;
                            //else
                            //    ckbStatus.Checked = false;

                            btnSave.Text = "Update";
                            hdMode.Value = "Update";
                            // ddlStatus.SelectedValue = Convert.ToInt32(Convert.ToBoolean(_Rows["ActiveStatus"].ToString())).ToString();

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void gvSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSchedule.PageIndex = e.NewPageIndex;
            LoadSchedule();
        }
    }
}