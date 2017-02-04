using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AntiClockFitnessCentreBAL;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace AntiClockFitnessCentre.Admin
{
    public partial class ViewOpinionPoll : System.Web.UI.Page
    {
        OpinionPollBL _OpinionPollBL = new OpinionPollBL();
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
                    LoadPollDetails();
                   // LoadPollChart();
                }
            }
        }

        //private void LoadPollChart()
        //{
        //    DataTable _OpinionPollChartTBL = _OpinionPollBL.GetPollChart(1);
        //    if(_OpinionPollChartTBL.Rows.Count > 0)
        //    {
        //        string[] x = new string[_OpinionPollChartTBL.Rows.Count];
        //        int[] y = new int[_OpinionPollChartTBL.Rows.Count];

        //        for (int i = 0; i < _OpinionPollChartTBL.Rows.Count; i++)
        //        {
        //            x[i] = _OpinionPollChartTBL.Rows[i][2].ToString();
        //            y[i] = Convert.ToInt32(_OpinionPollChartTBL.Rows[i][0]);
        //        }

        //        chart1.Series[0].Points.DataBindXY(x, y);
        //    }
        //}

        private void LoadPollDetails()
        {
            try
            {
                DataTable _OpinionPollTBL = _OpinionPollBL.GetPollDetails(0, Convert.ToInt32(companyID));
                Session[AntiClockFitnessCenter.POLL_MASTER_DETAILS] = _OpinionPollTBL;
                gvOpinionPoll.DataSource = _OpinionPollTBL;
                gvOpinionPoll.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
        }

        protected void gvOpinionPoll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOpinionPoll.PageIndex = e.NewPageIndex;
                LoadPollDetails();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
        }

        protected void gvOpinionPoll_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _ID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("RowDelete"))
                {
                    int result = _OpinionPollBL.DeletePollDetails(Convert.ToInt32(_ID), userID);
                    LoadPollDetails();

                }
                else if (e.CommandName.Equals("RowEdit"))
                {
                    Response.Redirect("AddOpinionPoll.aspx?i=" + Server.UrlEncode(_ID));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Visible = true;
            }
        }

        protected void gvOpinionPoll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable _OpinionPollMasterTL = Session[AntiClockFitnessCenter.POLL_MASTER_DETAILS] as DataTable;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _linkView = (LinkButton)e.Row.FindControl("lnkPollChart");
                Chart _ChartPollUsers = (Chart)e.Row.FindControl("crtPollUsers");

                DataTable _OpinionPollChartTBL = _OpinionPollBL.GetPollChart(Convert.ToInt32(_OpinionPollMasterTL.Rows[e.Row.RowIndex]["PollId"].ToString()), true);
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
                }
            }
        }
    }
}