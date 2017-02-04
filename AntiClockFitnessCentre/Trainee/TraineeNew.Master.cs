using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Web.Services;

using System.Web.Script.Services;

namespace AntiClockFitnessCentre.Trainee
{
    public partial class TraineeNew : System.Web.UI.MasterPage
    {
        OpinionPollBL _OpinionPollBL = new OpinionPollBL();
        AntiClockFitnessCentreModal.UserDetails _userdetails = new AntiClockFitnessCentreModal.UserDetails();
        EvaluationBL _EvaluationBL = new EvaluationBL();
        AchievementBL _achiverBL = new AchievementBL();
        NotificationBL _NotificationBL = new NotificationBL();
        UserBL _userBL = new UserBL();
        byte[] imgByte = null;
        string userID = "";
        StringBuilder _StringSlider = new StringBuilder();
        StringBuilder _StringModel = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                hddId.Value = _UserDetails.Rows[0]["UserID"].ToString();
                if (!IsPostBack)
                {
                    LoadTraineeDetails();
                    LoadTopAchiver();
                    LoadPollDetails();
                    LoadEvaluationResult();
                    LoadPollHistory();                    
                    LoadNotificationDetails();
                }
            }
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

      
        private void LoadNotificationDetails()
        {
            DataTable _NotificationDetailsTBL = _NotificationBL.GetNotificationDetails(Convert.ToInt32(userID));
            int _Count = _NotificationDetailsTBL != null ? _NotificationDetailsTBL.Rows.Count : 0;
            Session[AntiClockFitnessCenter.NOTIFICATION_DETAILS] = _NotificationDetailsTBL;
            if (_Count == 0)
            {
                spnNotificationCount.InnerHtml = "";
                liNotificationCount.Attributes.Remove("class");
                spnNotificationCount.Attributes.Remove("class");
                divModalBody.Style.Clear();
                divModalBody.InnerHtml = hddEmptNotifyMsg.Value;
            }
            else
            {
                spnNotificationCount.InnerHtml = _Count.ToString();
                liNotificationCount.Attributes.Add("class", "active");
                spnNotificationCount.Attributes.Add("class", "badge");
                divModalBody.Style.Add("height", "500px");
                divModalBody.Style.Add("overflow-y", "scroll");
            }
            if(_NotificationDetailsTBL.Rows.Count > 0 && _NotificationDetailsTBL != null)
            { 
                dlistNotification.DataSource = _NotificationDetailsTBL;
                dlistNotification.DataBind();
            }
        }

        private void LoadTraineeDetails()
        {
            if (!string.IsNullOrEmpty(Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS].ToString()))
            {
                DataTable _LoginUserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _LoginUserDetails.Rows[0]["UserID"].ToString();
                hddId.Value = _LoginUserDetails.Rows[0]["UserID"].ToString();
                txtFirstName.Text = _LoginUserDetails.Rows[0]["FirstName"].ToString();
                txtLastName.Text = _LoginUserDetails.Rows[0]["LastName"].ToString();
                txtAge.Text = string.IsNullOrEmpty(_LoginUserDetails.Rows[0]["DOB"].ToString()) ? " " : string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_LoginUserDetails.Rows[0]["DOB"].ToString()));
                imgProfilepic.ImageUrl = "/Admin/ProfileImage.ashx?ID=" + _LoginUserDetails.Rows[0]["UserID"].ToString() + "";

                txtaddressline1.Text = _LoginUserDetails.Rows[0]["ADDRESSLINE1"].ToString();
                txtaddressline2.Text = _LoginUserDetails.Rows[0]["ADDRESSLINE2"].ToString();
                txtcity.Text = _LoginUserDetails.Rows[0]["City"].ToString();
                txtcountry.Text = _LoginUserDetails.Rows[0]["Country"].ToString();
                txtstate.Text = _LoginUserDetails.Rows[0]["State"].ToString();
                rblgender.SelectedValue = _LoginUserDetails.Rows[0]["Gender"].ToString();


                lblAge.Text = _LoginUserDetails.Rows[0]["Age"].ToString();
                lblGender.Text = _LoginUserDetails.Rows[0]["Gender"].ToString();
                lblheight.Text = _LoginUserDetails.Rows[0]["Height"].ToString() + " CM";
                lblUsername.Text = _LoginUserDetails.Rows[0]["FirstName"].ToString() + " " + _LoginUserDetails.Rows[0]["LastName"].ToString();
                lblweight.Text = _LoginUserDetails.Rows[0]["Weight"].ToString() + " KG";
                lblgoals.Text = _LoginUserDetails.Rows[0]["Goals"].ToString();
                lblProblems.Text = _LoginUserDetails.Rows[0]["Problems"].ToString();
                imgProfileImage.ImageUrl = "/Admin/ProfileImage.ashx?ID=" + _LoginUserDetails.Rows[0]["UserID"].ToString() + "";

                lblStatus.Text = _LoginUserDetails.Rows[0]["Status"].ToString();
                lblLastDate.Text = string.IsNullOrEmpty(_LoginUserDetails.Rows[0]["ActiveTill"].ToString()) ? " " : string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_LoginUserDetails.Rows[0]["ActiveTill"].ToString()));
                lbltrainer.Text = _LoginUserDetails.Rows[0]["TrainerId"].ToString();
                Session[AntiClockFitnessCenter.PROFILE_IMAGE_BYTE] = _LoginUserDetails.Rows[0]["ProfileImage"].ToString();

            }

        }

        private void LoadPollHistory()
        {
            try
            {
                DataTable _PollHistoryTBL = _OpinionPollBL.GetPollHistory(Convert.ToInt32(userID));
                if (_PollHistoryTBL.Rows.Count > 0 && _PollHistoryTBL != null)
                {
                    gvPollHistory.DataSource = _PollHistoryTBL;
                    gvPollHistory.DataBind();
                    lblErrorPollHis.Text = "";
                    errorMsgPollHis.Visible = false;
                }
                else
                {
                    
                    lblErrorPollHis.Text = "No History to display.";
                    errorMsgPollHis.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblErrorPollHis.Text = ex.Message;
                errorMsgPollHis.Visible = true;
            }
        }

        private void LoadEvaluationResult()
        {
            try
            {
                DataTable _EvaluationTBL = _EvaluationBL.GetUserEvaluation(Convert.ToInt32(userID));
                if (_EvaluationTBL.Rows.Count > 0 && _EvaluationTBL != null)
                {
                    lblEvaluationResult.Visible = false;
                    string[] imglist = _EvaluationTBL.Rows[0]["EvaluationLocation"].ToString().Split(',');

                    for (int i = 0; i < imglist.Count(); i++)
                    {
                        if (i == 0)
                        {
                            System.Web.UI.HtmlControls.HtmlGenericControl _newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            _newDiv.Attributes.Add("class", "item active");
                            _newDiv.Attributes.Add("style", "height:100%;");

                            LiteralControl ltEmbed = new LiteralControl();
                            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"100%\">";
                            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                            embed += "</object>";
                            ltEmbed.Text = string.Format(embed, ResolveUrl("~/Uploads/" + imglist[i].ToString()));

                            //System.Web.UI.HtmlControls.HtmlImage _newImage = new System.Web.UI.HtmlControls.HtmlImage();
                            //_newImage.Src = "~/ConvertedImage/" + imglist[i].ToString();
                            //imgResult.ImageUrl = "~/ConvertedImage/" + imglist[i].ToString();
                            _newDiv.Controls.Add(ltEmbed);
                            divslider.Controls.Add(_newDiv);
                        }
                        else
                        {
                            System.Web.UI.HtmlControls.HtmlGenericControl _newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            _newDiv.Attributes.Add("class", "item");
                            _newDiv.Attributes.Add("style", "height:100%;");
                            LiteralControl ltEmbed = new LiteralControl();
                            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"100%\">";
                            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                            embed += "</object>";
                            ltEmbed.Text = string.Format(embed, ResolveUrl("~/Uploads/" + imglist[i].ToString()));

                            //System.Web.UI.HtmlControls.HtmlImage _newImage = new System.Web.UI.HtmlControls.HtmlImage();
                            //_newImage.Src = "~/ConvertedImage/" + imglist[i].ToString();
                            _newDiv.Controls.Add(ltEmbed);
                            divslider.Controls.Add(_newDiv);
                        }
                    }
                }
                else
                {
                    lblEvaluationResult.Visible = true;
                }
            }
            catch(Exception ex)
            {

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

                if (TotalSize.Value == "1" || TotalSize.Value == "0" || string.IsNullOrEmpty(TotalSize.Value))
                {
                    Prev.Visible = false;
                    Next.Visible = false;
                }
                else
                {
                    Prev.Visible = true;
                    Next.Visible = true;
                }

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

                if (TotalSizePoll.Value == "1" || TotalSizePoll.Value == "0" || string.IsNullOrEmpty(TotalSizePoll.Value))
                {
                    PrevPoll.Visible = false;
                    NextPoll.Visible = false;
                }
                else
                {
                    PrevPoll.Visible = true;
                    NextPoll.Visible = true;
                }

                BuildPagersPoll();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblerrorPoll.Text = ex.Message;
                //IsSuccess(false);
                errorMsgPoll.Visible = true;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
               // if (!fuldphoto.HasFile)
                if (fuldphoto.HasFile)
                {
                    flag = true;
                    imgByte = new byte[fuldphoto.PostedFile.ContentLength];
                    HttpPostedFile UploadedImage = fuldphoto.PostedFile;
                    UploadedImage.InputStream.Read(imgByte, 0, (int)fuldphoto.PostedFile.ContentLength);

                }
                else
                {
                    flag = false;
                    imgByte = Session[AntiClockFitnessCenter.PROFILE_IMAGE_BYTE] as byte[];
                }

                _userdetails.userid = Convert.ToInt32(hddId.Value);
                _userdetails.firstName = txtFirstName.Text;
                _userdetails.lastName = txtLastName.Text;
                _userdetails.gender = rblgender.SelectedValue.ToString();

                _userdetails.addressline1 = txtaddressline1.Text;
                _userdetails.addressline2 = txtaddressline2.Text;
                _userdetails.city = txtcity.Text;
                _userdetails.state = txtstate.Text;
                _userdetails.country = txtcountry.Text;


                _userdetails.dob = string.IsNullOrEmpty(txtAge.Text.Replace(" ", string.Empty)) ? (DateTime?)null : Convert.ToDateTime(txtAge.Text);
                _userdetails.profileimage = imgByte;

                int _Result = _userBL.UpdateTraineeDetails(_userdetails, flag);
                if (_Result == 1)
                {
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    //sb.Append(@"<script type='text/javascript'>");

                    //sb.Append("$('#editModal').modal('Show');");

                    //sb.Append(@"</script>");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", "openModal();", true);
                   // Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", sb.ToString(), false);
                    lblSucess.Text = "Saved Sucessfully";
                    IsSuccess(true);

                    Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] = _userBL.GetUserDetails(Convert.ToInt32(hddId.Value));
                    LoadTraineeDetails();
                }
                else if (_Result == -1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error While Saving.Please, try again after sometime.";
                    IsSuccess(false);
                }
            }
            catch (Exception ex)
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
                    DataTable _OpinionPollChartTBL = _OpinionPollBL.GetPollChart(Polltid, false);

                    LinkButton _linkView = (LinkButton)e.Item.FindControl("lnkPollChart");
                    Chart _ChartPollUsers = (Chart)e.Item.FindControl("crtPollUsers");

                    if (_OpinionPollChartTBL.Rows.Count > 0)
                    {
                        string[] x = new string[_OpinionPollChartTBL.Rows.Count];
                        int[] y = new int[_OpinionPollChartTBL.Rows.Count];

                        for (int i = 0; i < _OpinionPollChartTBL.Rows.Count; i++)
                        {
                            x[i] = _OpinionPollChartTBL.Rows[i][2].ToString();
                            y[i] = Convert.ToInt32(_OpinionPollChartTBL.Rows[i][0]);
                        }

                        _ChartPollUsers.Series[0].Points.DataBindXY(x, y);
                        
                        _ChartPollUsers.Series[0].BorderWidth = 10;
                        _ChartPollUsers.Series[0].ChartType = SeriesChartType.Pie;
                        _ChartPollUsers.Series[0]["PieLabelStyle"] = "Outside";
                        _ChartPollUsers.Series[0].BorderWidth = 1;
                      
                       // _ChartPollUsers.Series[0].Label = "#PERCENT{P2}";
                        _ChartPollUsers.Series[0].Label = "#PERCENT{P2}";
                        _ChartPollUsers.Series[0].LegendText = "#VALX"; 

                        //_ChartPollUsers.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                        _ChartPollUsers.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);
                       

                        _ChartPollUsers.Legends.Add("Legend1");
                        _ChartPollUsers.Legends[0].Enabled = true;
                        _ChartPollUsers.Legends[0].Docking = Docking.Bottom;
                       // _ChartPollUsers.Legends[0].Title = "Percentage of Users";
                        
                        _ChartPollUsers.Legends[0].Alignment = System.Drawing.StringAlignment.Center;


                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.PointGapDepth = 900;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 25;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 65;
                        _ChartPollUsers.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 35;

                        _linkView.Visible = true;
                    }
                    else
                    {
                        _linkView.Visible = false;
                    }


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
            catch(Exception ex)
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
            catch(Exception ex)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgility_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string trainingprogram = "";
            if (btn.ID == "btnTrucking")
            {
                trainingprogram = "Trekking";
            }
            else if (btn.ID == "btnCycling")
            {
                trainingprogram = "Cycling";
            }
            else if (btn.ID == "btnCircuit")
            {
                trainingprogram = "Circuit training";
            }
            else if (btn.ID == "btnCore")
            {
                trainingprogram = "Cardio & core training";
            }
            else if (btn.ID == "btnAgility")
            {
                trainingprogram = "Cardio & agility training";
            }

            string subject = AntiClockFitnessCenter.ReadXML(@"ACHF/Course/Subject");
            string body = AntiClockFitnessCenter.ReadXML(@"ACHF/Course/Body");
            subject = string.Format(subject, txtFirstName.Text + " " + txtLastName.Text + "(" + hddId.Value + ")");
            body = string.Format(body, txtFirstName.Text + " " + txtLastName.Text + "(" + hddId.Value+")", trainingprogram);
            AntiClockFitnessCenter.SendEmail("achf.ind@gmail.com", subject, body);
        }

        //[WebMethod(EnableSession = true)]
        //[ScriptMethod]
        //public static void InsertNotificationView(string userID)
        //{
        //     NotificationBL _NotificationBL = new NotificationBL();
        //    DataTable _NotificationViewTBL = System.Web.HttpContext.Current.Session[AntiClockFitnessCenter.NOTIFICATION_DETAILS] as DataTable;

        //        if (_NotificationViewTBL.Rows.Count > 0 && _NotificationViewTBL != null)
        //        {
        //            for (int i = 0; i < _NotificationViewTBL.Rows.Count; i++)
        //            {
        //                int _Result = _NotificationBL.InsertNotificationViewed(Convert.ToInt32(_NotificationViewTBL.Rows[i]["ScheduleID"].ToString()), Convert.ToInt32(userID));
        //            }
        //        }

        //        //spnNotificationCount.InnerHtml = "";
        //        //liNotificationCount.Attributes.Remove("class");
        //        //spnNotificationCount.Attributes.Remove("class");

            
        //}

        //protected void lnkbtnNotification_Click(object sender, EventArgs e)
        //{
        //    DataTable _NotificationViewTBL = System.Web.HttpContext.Current.Session[AntiClockFitnessCenter.NOTIFICATION_DETAILS] as DataTable;

        //    if (_NotificationViewTBL.Rows.Count > 0 && _NotificationViewTBL != null)
        //    {
        //        for (int i = 0; i < _NotificationViewTBL.Rows.Count; i++)
        //        {
        //            int _Result = _NotificationBL.InsertNotificationViewed(Convert.ToInt32(_NotificationViewTBL.Rows[i]["ScheduleID"].ToString()), Convert.ToInt32(userID));
        //        }
        //    }

        //    spnNotificationCount.InnerHtml = "";
        //    liNotificationCount.Attributes.Remove("class");
        //    spnNotificationCount.Attributes.Remove("class");
        //}

        
        
    }
}