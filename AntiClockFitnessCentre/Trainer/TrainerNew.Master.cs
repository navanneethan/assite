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
    public partial class TrainerNew : System.Web.UI.MasterPage
    {
        OpinionPollBL _OpinionPollBL = new OpinionPollBL();
        AntiClockFitnessCentreModal.UserDetails _userdetails = new AntiClockFitnessCentreModal.UserDetails();
        AchievementBL _achiverBL = new AchievementBL();
        UserBL _userBL = new UserBL();
        byte[] imgByte = null;
        string userID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DataTable _LoginUserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _LoginUserDetails.Rows[0]["UserID"].ToString();
                hddId.Value = _LoginUserDetails.Rows[0]["UserID"].ToString();
                if (!IsPostBack)
                {
                    LoadTrainerDetails();
                    LoadTopAchiver();
                    LoadPollDetails();
                }

            }
           
        }

        private void LoadTrainerDetails()
        {
            if (!string.IsNullOrEmpty(Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS].ToString()))
            {
                DataTable _LoginUserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _LoginUserDetails.Rows[0]["UserID"].ToString();
                lblAge.Text = _LoginUserDetails.Rows[0]["Age"].ToString();
                lblGender.Text = _LoginUserDetails.Rows[0]["Gender"].ToString();
                lblheight.Text = _LoginUserDetails.Rows[0]["Height"].ToString() + " CM";
                lblUsername.Text = _LoginUserDetails.Rows[0]["FirstName"].ToString() + " " + _LoginUserDetails.Rows[0]["LastName"].ToString();
                lblweight.Text = _LoginUserDetails.Rows[0]["Weight"].ToString() + " KG";

                imgProfileImage.ImageUrl = "/Admin/ProfileImage.ashx?ID=" + _LoginUserDetails.Rows[0]["UserID"].ToString() + "";
                Session[AntiClockFitnessCenter.PROFILE_IMAGE_BYTE] = _LoginUserDetails.Rows[0]["ProfileImage"].ToString();
                //dlUserDetails.DataSource = _LoginUserDetails;
                //dlUserDetails.DataBind();
            }

        }

        private void LoadTopAchiver()
        {
            try
            {
                //Get the start Record Count
                //Remember database count is zero based so first decrease the value of
                //the current page
                int startRecord = (int.Parse(CurrentPage.Value) - 1) * int.Parse(PageSize.Value);

                //Fetch only the necessary records.
                DataSet myTopAchieverds = _achiverBL.GetTopAchievers(startRecord, int.Parse(PageSize.Value), "table1");


                //DataBind the Repeater  
                repTopAchiever.DataSource = myTopAchieverds.Tables[0].DefaultView;
                repTopAchiever.DataBind();

                //Second Part          
                TotalSize.Value = myTopAchieverds.Tables[1].Rows.Count.ToString();
                BuildPagers();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorAchiever.Text = ex.Message;
                //IsSuccess(false);
                errorMsgAchiever.Visible = true;
            }



        }

        public void BuildPagers()
        {
            try
            {
                //Check if its possible to have the previous page
                if ((int.Parse(CurrentPage.Value) - 1) <= 0)
                {
                    Prev.Enabled = false;
                    Prev.CssClass = "btn btn-info btn-xs disabled";
                }
                else
                {
                    Prev.Enabled = true;
                    Prev.CssClass = "btn btn-info btn-xs active";
                }
                //Check if its possible to have the next page  
                if ((int.Parse(CurrentPage.Value) * int.Parse(PageSize.Value))
                      >= int.Parse(TotalSize.Value))
                {
                    Next.Enabled = false;
                    Next.CssClass = "btn btn-info btn-xs disabled";
                }
                else
                {
                    Next.Enabled = true;
                    Next.CssClass = "btn btn-info btn-xs active";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorAchiever.Text = ex.Message;
                //IsSuccess(false);
                errorMsgAchiever.Visible = true;
            }
        }

        public void Page_Repeater(object sender, EventArgs e)
        {
            try
            {
                //Check for Button clicked
                if (((LinkButton)sender).ID == "Prev")
                {
                    //Check if we are on any page greater than 0 
                    if ((int.Parse(CurrentPage.Value) - 1) >= 0)
                    {
                        //Decrease the CurrentPage Value
                        CurrentPage.Value = (int.Parse(CurrentPage.Value) - 1).ToString();
                    }
                }
                else if (((LinkButton)sender).ID == "Next")
                {
                    //Check if we can display the next page.
                    if ((int.Parse(CurrentPage.Value) * int.Parse(PageSize.Value))
                              < int.Parse(TotalSize.Value))
                    {
                        //Increment the CurrentPage value
                        CurrentPage.Value = (int.Parse(CurrentPage.Value) + 1).ToString();
                    }
                }
                //Rebuild the Grid
                LoadTopAchiver();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorAchiever.Text = ex.Message;
                //IsSuccess(false);
                errorMsgAchiever.Visible = true;
            }
        }

        private void LoadPollDetails()
        {
            try
            {
                //Get the start Record Count
                //Remember database count is zero based so first decrease the value of
                //the current page
                int startRecordPoll = (int.Parse(CurrentPagePoll.Value) - 1) * int.Parse(PageSizePoll.Value);

                //Fetch only the necessary records.
                DataSet myPollDetails = _OpinionPollBL.GetTodayPollDetails(userID, startRecordPoll, int.Parse(PageSizePoll.Value), "table1");


                //DataBind the Repeater  
                dlstPoll.DataSource = myPollDetails.Tables[0].DefaultView;
                dlstPoll.DataBind();

                //Second Part          
                TotalSizePoll.Value = myPollDetails.Tables[1].Rows.Count.ToString();
                BuildPagersPoll();


                //DataTable _OpinionPollMater = _OpinionPollBL.GetTodayPollDetails(userID);
                // dlstPoll.DataSource = _OpinionPollMater;
                //dlstPoll.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }

        }


        public void PagePoll_Repeater(object sender, EventArgs e)
        {
            try
            {
                //Check for Button clicked
                if (((LinkButton)sender).ID == "PrevPoll")
                {
                    //Check if we are on any page greater than 0 
                    if ((int.Parse(CurrentPagePoll.Value) - 1) >= 0)
                    {
                        //Decrease the CurrentPage Value
                        CurrentPagePoll.Value = (int.Parse(CurrentPagePoll.Value) - 1).ToString();
                    }
                }
                else if (((LinkButton)sender).ID == "NextPoll")
                {
                    //Check if we can display the next page.
                    if ((int.Parse(CurrentPagePoll.Value) * int.Parse(PageSizePoll.Value))
                              < int.Parse(TotalSizePoll.Value))
                    {
                        //Increment the CurrentPage value
                        CurrentPagePoll.Value = (int.Parse(CurrentPagePoll.Value) + 1).ToString();
                    }
                }
                //Rebuild the Grid
                LoadPollDetails();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }
        }
        
        public void BuildPagersPoll()
        {
            try
            {
                //Check if its possible to have the previous page
                if ((int.Parse(CurrentPagePoll.Value) - 1) <= 0)
                {
                    PrevPoll.Enabled = false;
                    PrevPoll.CssClass = "btn btn-info btn-xs disabled";
                }
                else
                {
                    PrevPoll.Enabled = true;
                    PrevPoll.CssClass = "btn btn-info btn-xs active";
                }
                //Check if its possible to have the next page  
                if ((int.Parse(CurrentPagePoll.Value) * int.Parse(PageSizePoll.Value))
                      >= int.Parse(TotalSizePoll.Value))
                {
                    NextPoll.Enabled = false;
                    NextPoll.CssClass = "btn btn-info btn-xs disabled";
                }
                else
                {
                    NextPoll.Enabled = true;
                    NextPoll.CssClass = "btn btn-info btn-xs active";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }
        }

        protected void dlstPoll_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "SubmitPoll")
                {
                    int pollid = Convert.ToInt32(dlstPoll.DataKeys[e.Item.ItemIndex]);
                    RadioButtonList r = ((RadioButtonList)e.Item.FindControl("rblPollOptions"));

                    string selected = r.SelectedValue;

                    int result = _OpinionPollBL.InsertPollUsers(Convert.ToInt32(pollid), Convert.ToInt32(selected), Convert.ToInt32(hddId.Value));
                    LoadPollDetails();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }
        }

        protected void dlstPoll_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                DataListItem item = e.Item;

                if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
                {
                    Image img = ((Image)e.Item.FindControl("imgPollpic"));
                    string path = img.ImageUrl;
                    if (!string.IsNullOrEmpty(path))
                    {
                        img.Visible = true;
                        img.ImageUrl = "~/Uploads/" + path;
                    }

                    int Polltid = Convert.ToInt32(dlstPoll.DataKeys[e.Item.ItemIndex]);

                    DataTable _PollOptionsTBL = _OpinionPollBL.GetTodayPollOptions(Polltid);

                    RadioButtonList r = ((RadioButtonList)e.Item.FindControl("rblPollOptions"));
                    HiddenField hddIsAttended = ((HiddenField)e.Item.FindControl("hddAttended"));
                    Button btnSubmit = ((Button)e.Item.FindControl("btnSubmit"));

                    r.DataSource = _PollOptionsTBL;
                    r.DataTextField = "PollOptionName";
                    r.DataValueField = "PollOptionId";
                    r.DataBind();

                    if (hddIsAttended.Value == "0")
                        btnSubmit.Visible = true;
                    else
                    {
                        btnSubmit.Visible = false;
                        r.SelectedValue = hddIsAttended.Value;
                        r.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}