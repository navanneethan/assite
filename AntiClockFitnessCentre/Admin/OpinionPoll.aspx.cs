using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.Data;
using System.Globalization;

namespace AntiClockFitnessCentre.Admin
{
    public partial class OpinionPoll : System.Web.UI.Page
    {
        OpinionPollBL _OpinionPollBL = new OpinionPollBL();
        OpinionPollModal _OpnionPollModal = new OpinionPollModal();
        OpinionPollOptionModal _OpnionPollOptionModal = new OpinionPollOptionModal();
        UserBL _UserBL = new UserBL();
        string userID = "";
        string companyID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = _UserDetails.Rows[0]["CompanyID"].ToString();
                if (!IsPostBack)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        Int32 s = Convert.ToInt32(Request.QueryString["i"].ToString());
                        HfUpdateID.Value = s.ToString();
                        LoadPollDetails(s);
                    }
                }
            }
        }

        private void LoadPollDetails(int pId)
        {
            DataTable _OpinionPollTBL = _OpinionPollBL.GetPollDetails(pId, Convert.ToInt32(companyID));
            if (_OpinionPollTBL.Rows.Count > 0)
           {
               txtQuestion.Text = _OpinionPollTBL.Rows[0]["PollQuestion"].ToString();
               txtPollStartDate.Text = _OpinionPollTBL.Rows[0]["PollStartDate"].ToString();
               txtPollEndDate.Text = _OpinionPollTBL.Rows[0]["PollEndDate"].ToString();
               if (!string.IsNullOrEmpty(_OpinionPollTBL.Rows[0]["PollImage"].ToString()))
               {
                   imgPollpic.ImageUrl = "~/Uploads/" + _OpinionPollTBL.Rows[0]["PollImage"].ToString();
               }

               DataTable _OpinionPollOptionTBL = _OpinionPollBL.GetTodayPollOptions(pId);

               if (_OpinionPollOptionTBL.Rows.Count > 0)
               {
                   if(_OpinionPollOptionTBL.Rows.Count == 2)
                   {
                       hddOp1.Value = _OpinionPollOptionTBL.Rows[0]["PollOptionId"].ToString();
                       hddOp2.Value = _OpinionPollOptionTBL.Rows[1]["PollOptionId"].ToString();
                       txtOption1.Text = _OpinionPollOptionTBL.Rows[0]["PollOptionName"].ToString();
                       txtOption2.Text = _OpinionPollOptionTBL.Rows[1]["PollOptionName"].ToString();
                   }
                   else if (_OpinionPollOptionTBL.Rows.Count == 3)
                   {
                       hddOp1.Value = _OpinionPollOptionTBL.Rows[0]["PollOptionId"].ToString();
                       hddOp2.Value = _OpinionPollOptionTBL.Rows[1]["PollOptionId"].ToString();
                       hddOp3.Value = _OpinionPollOptionTBL.Rows[2]["PollOptionId"].ToString();
                       txtOption1.Text = _OpinionPollOptionTBL.Rows[0]["PollOptionName"].ToString();
                       txtOption2.Text = _OpinionPollOptionTBL.Rows[1]["PollOptionName"].ToString();
                       txtOption3.Text = _OpinionPollOptionTBL.Rows[2]["PollOptionName"].ToString();
                   }
                   else if (_OpinionPollOptionTBL.Rows.Count == 4)
                   {
                       hddOp1.Value = _OpinionPollOptionTBL.Rows[0]["PollOptionId"].ToString();
                       hddOp2.Value = _OpinionPollOptionTBL.Rows[1]["PollOptionId"].ToString();
                       hddOp3.Value = _OpinionPollOptionTBL.Rows[2]["PollOptionId"].ToString();
                       hddOp4.Value = _OpinionPollOptionTBL.Rows[3]["PollOptionId"].ToString();
                       txtOption1.Text = _OpinionPollOptionTBL.Rows[0]["PollOptionName"].ToString();
                       txtOption2.Text = _OpinionPollOptionTBL.Rows[1]["PollOptionName"].ToString();
                       txtOption3.Text = _OpinionPollOptionTBL.Rows[2]["PollOptionName"].ToString();
                       txtOption4.Text = _OpinionPollOptionTBL.Rows[3]["PollOptionName"].ToString();
                   }
               }

              
           }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (HfUpdateID.Value == "0")
                    _OpnionPollModal.pollId = 0;
                //else
                //    _OpnionPollModal.pollId = Convert.ToInt32(HfUpdateID.Value);

                if (fuldphoto.HasFile)
                {
                    string fileName = fuldphoto.FileName;
                    fuldphoto.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    _OpnionPollModal.pollImage = fileName;
                }

                _OpnionPollModal.pollQuestion = txtQuestion.Text;
                _OpnionPollModal.pollStartDate = DateTime.ParseExact(txtPollStartDate.Text, "dd MMMM yyyy - h:mm tt", CultureInfo.InvariantCulture);
                _OpnionPollModal.pollEndDate = DateTime.ParseExact(txtPollEndDate.Text, "dd MMMM yyyy - h:mm tt", CultureInfo.InvariantCulture);
                _OpnionPollModal.PollCreatedBy = userID;

                int Identityresult  = _OpinionPollBL.InsertPollMaster(_OpnionPollModal);

               


                //if(!string.IsNullOrEmpty(txtOption1.Text))
                //{
                //    int _Result = _OpinionPollBL.InsertPollOption(Convert.ToInt32(hddOp1.Value), Identityresult, txtOption1.Text, userID);
                //    if (_Result == 1)
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                //        lblSucess.Text = "Saved Sucessfully";
                //        IsSuccess(true);
                //    }
                //}
                //if (!string.IsNullOrEmpty(txtOption2.Text))
                //{
                //    int _Result = _OpinionPollBL.InsertPollOption(Convert.ToInt32(hddOp2.Value), Identityresult, txtOption2.Text, userID);
                //    if (_Result == 1)
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                //        lblSucess.Text = "Saved Sucessfully";
                //        IsSuccess(true);
                //    }
                //}
                //if (!string.IsNullOrEmpty(txtOption3.Text))
                //{
                //    int _Result = _OpinionPollBL.InsertPollOption(Convert.ToInt32(hddOp3.Value), Identityresult, txtOption3.Text, userID);
                //    if (_Result == 1)
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                //        lblSucess.Text = "Saved Sucessfully";
                //        IsSuccess(true);
                //    }
                //}
                //if (!string.IsNullOrEmpty(txtOption4.Text))
                //{
                //    int _Result = _OpinionPollBL.InsertPollOption(Convert.ToInt32(hddOp4.Value), Identityresult, txtOption4.Text, userID);
                //    if (_Result == 1)
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                //        lblSucess.Text = "Saved Sucessfully";
                //        IsSuccess(true);
                //    }
                //}

                Clear();

                    
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtQuestion.Text = "";
            txtOption1.Text = "";
            txtOption2.Text = "";
            txtOption3.Text = "";
            txtOption4.Text = "";
            txtPollEndDate.Text = "";
            txtPollStartDate.Text = "";
            hddOp1.Value = "0";
            hddOp2.Value = "0";
            hddOp3.Value = "0";
            hddOp4.Value = "0";
            HfUpdateID.Value = "0";
        }
    }
}