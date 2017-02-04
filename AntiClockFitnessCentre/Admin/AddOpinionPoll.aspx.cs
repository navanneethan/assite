using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;

using System.Globalization;

namespace AntiClockFitnessCentre.Admin
{
    public partial class AddOpinionPoll : System.Web.UI.Page
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
                    else
                    {
                        SetInitialRow();
                    }
                }
            }
        }

        private void LoadPollDetails(int pId)
        {
            try
            {
                DataTable _OpinionPollTBL = _OpinionPollBL.GetPollDetails(pId,Convert.ToInt32(companyID));
                if (_OpinionPollTBL.Rows.Count > 0)
                {
                    txtQuestion.Text = _OpinionPollTBL.Rows[0]["PollQuestion"].ToString();
                    txtPollStartDate.Value = string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_OpinionPollTBL.Rows[0]["PollStartDate"].ToString()));
                    txtPollEndDate.Value = string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_OpinionPollTBL.Rows[0]["PollEndDate"].ToString()));
                    if (!string.IsNullOrEmpty(_OpinionPollTBL.Rows[0]["PollImage"].ToString()))
                    {
                        imgPollpic.ImageUrl = "~/Uploads/" + _OpinionPollTBL.Rows[0]["PollImage"].ToString();
                    }
                    DataTable _OpinionPollOptionTBL = _OpinionPollBL.GetTodayPollOptions(pId);

                    if (_OpinionPollOptionTBL.Rows.Count > 0)
                    {
                        ViewState["CurrentTable"] = _OpinionPollOptionTBL;

                        // SetPreviousData();
                        //Bind the Repeater with the DataTable
                        repOptions.DataSource = _OpinionPollOptionTBL;
                        repOptions.DataBind();
                        SetPreviousData();


                    }
                    else
                    {
                        SetInitialRow();
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

        private void SetInitialRow()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;

                //Create DataTable columns
                dt.Columns.Add(new DataColumn("RowNumer", typeof(string)));
                dt.Columns.Add(new DataColumn("PollOptionName", typeof(string)));

                //Create Row for each columns
                dr = dt.NewRow();

                dr["RowNumer"] = 1;
                dr["PollOptionName"] = string.Empty;

                dt.Rows.Add(dr);

                //Store the DataTable in ViewState for future reference
                ViewState["CurrentTable"] = dt;


                //Bind the Repeater with the DataTable
                repOptions.DataSource = dt;
                repOptions.DataBind();


                Button btnAdd = (Button)repOptions.Items[0].FindControl("btnAddO");
                Button btnDelete = (Button)repOptions.Items[0].FindControl("btnDeleteO");

                btnAdd.Visible = true;
                btnDelete.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values
                            TextBox tboption = (TextBox)repOptions.Items[rowIndex].FindControl("txtOption");

                            //Create new row in DataTable and set its values
                            drCurrentRow = dtCurrentTable.NewRow();

                            drCurrentRow["RowNumer"] = i + 1;
                            dtCurrentTable.Rows[i - 1]["PollOptionName"] = tboption.Text;
                            rowIndex++;

                        }

                        //add the new row to the current DataTable
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        //store the current DataTable in ViewState
                        ViewState["CurrentTable"] = dtCurrentTable;
                        //rebind the Repeater with the updated DataTable
                        repOptions.DataSource = dtCurrentTable;
                        repOptions.DataBind();
                    }

                }
                else
                {
                    Response.Write("ViewState is null");

                }
                //Set Previous Data on Postbacks
                SetPreviousData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }
        private void SetPreviousData()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            Label lblRow = (Label)repOptions.Items[rowIndex].FindControl("lblRowNumber");
                            TextBox tboption = (TextBox)repOptions.Items[rowIndex].FindControl("txtOption");
                            Button btnAdd = (Button)repOptions.Items[rowIndex].FindControl("btnAddO");
                            Button btnDelete = (Button)repOptions.Items[rowIndex].FindControl("btnDeleteO");
                            lblRow.Text = "Option " + (i + 1);
                            ////Disable previous rows
                            if (i < dt.Rows.Count - 1)
                            {
                                btnAdd.Visible = false;
                                btnDelete.Visible = true;
                            }
                            else
                            {
                                btnAdd.Visible = true;
                                btnDelete.Visible = false;


                            }

                            tboption.Text = dt.Rows[i]["PollOptionName"].ToString();
                            //tbComments.Text = dt.Rows[i]["Comments"].ToString();
                            rowIndex++;
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

        protected void btnDeleteO_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    string OptionId = (sender as Button).CommandArgument;


                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtCurrentTable.Rows.Count; i++)
                        {

                            foreach (DataRow dr in dtCurrentTable.Rows)
                            {
                                if (dr["RowNumer"].ToString() == OptionId)
                                {
                                    dr.Delete();
                                    break;
                                }
                            }
                            dtCurrentTable.AcceptChanges();

                        }


                        //store the current DataTable in ViewState
                        ViewState["CurrentTable"] = dtCurrentTable;
                        //rebind the Repeater with the updated DataTable
                        repOptions.DataSource = dtCurrentTable;
                        repOptions.DataBind();
                    }
                }
                SetPreviousData();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtQuestion.Text = "";
            txtPollEndDate.Value = "";
            txtPollStartDate.Value = "";
            SetInitialRow();
            HfUpdateID.Value = "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (HfUpdateID.Value == "0")
                {
                    _OpnionPollModal.pollId = 0;
                }
                else
                {
                    _OpnionPollModal.pollId = Convert.ToInt32(HfUpdateID.Value);
                    if (!string.IsNullOrEmpty(imgPollpic.ImageUrl))
                    {
                        _OpnionPollModal.pollImage = imgPollpic.ImageUrl.Replace("~/Uploads/", "");
                    }
                    //_OpnionPollModal.pollImage = imgPollpic.ImageUrl.Substring()
                }

                if (fuldphoto.HasFile)
                {
                    string fileName = fuldphoto.FileName;
                    fuldphoto.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    _OpnionPollModal.pollImage = fileName;
                }

                _OpnionPollModal.pollQuestion = txtQuestion.Text;
                _OpnionPollModal.pollStartDate = DateTime.ParseExact(txtPollStartDate.Value, "dd MMMM yyyy", CultureInfo.InvariantCulture);
                _OpnionPollModal.pollEndDate = DateTime.ParseExact(txtPollEndDate.Value, "dd MMMM yyyy", CultureInfo.InvariantCulture);
                _OpnionPollModal.PollCreatedBy = userID;
                _OpnionPollModal.pollCompanyId = Convert.ToInt32(companyID);

               // int Identityresult = _OpinionPollBL.InsertPollMaster(_OpnionPollModal);
                List<OpinionPollOptionModal> _list = new List<OpinionPollOptionModal>();
                foreach (RepeaterItem i in repOptions.Items)
                {
                    TextBox tboption = (TextBox)i.FindControl("txtOption");
                    if (!string.IsNullOrEmpty(tboption.Text))
                    {
                        OpinionPollOptionModal _PollOptionModal = new OpinionPollOptionModal();
                        _PollOptionModal.pollOptionName = tboption.Text;
                        _list.Add(_PollOptionModal);
                    }
                }
                int Result = _OpinionPollBL.InsertPollDetails(_OpnionPollModal, _list);
                if (Result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    lblSucess.Text = "Saved Sucessfully";
                    IsSuccess(true);
                    Clear();
                }
                if(Result == -1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error While Saving Data.";
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
    }
}