using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AntiClockFitnessCentreBAL;
using System.Data;
using System.IO;

namespace AntiClockFitnessCentre.SuperAdmin
{
    public partial class Company : System.Web.UI.Page
    {
        CompanyBL _CompanyBL = new CompanyBL();
        
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
                if(!IsPostBack)
                {
                    LoadCompany();
                }
            }
        }

        private void LoadCompany()
        {
            DataTable _CompanyTL = _CompanyBL.GetCompany();
            Session[AntiClockFitnessCenter.COMPANY_DETAILS] = _CompanyTL;
            gvCompany.DataSource = _CompanyTL;
            gvCompany.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = string.Empty;
                if (hddMode.Value == "Save")
                {
                    if (fupCompanyLogo.HasFile)
                    {
                        filename = fupCompanyLogo.PostedFile.FileName;
                        fupCompanyLogo.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    }

                    int _Result = _CompanyBL.InsertCompany(0, txtCompanyName.Text,txtCompanyCode.Text, filename, userID);
                    if (_Result == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                        lblSucess.Text = "Saved Sucessfully";
                        IsSuccess(true);
                        LoadCompany();
                        Clear();
                    }
                    else if (_Result == 222)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Company Name already exists!";
                        IsSuccess(false);
                    }
                    else if (_Result == 333)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Company Code already exists!";
                        IsSuccess(false);
                    }
                }
                else if (hddMode.Value == "Update")
                {
                    if (fupCompanyLogo.HasFile)
                    {
                        filename = fupCompanyLogo.PostedFile.FileName;
                        fupCompanyLogo.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    }
                    else
                    {
                        filename = hddLogo.Value;
                    }

                    int _Result = _CompanyBL.InsertCompany(Convert.ToInt32(hddId.Value), txtCompanyName.Text,txtCompanyCode.Text, filename, userID);
                    if (_Result == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                        lblSucess.Text = "Updated Sucessfully";
                        IsSuccess(true);
                        LoadCompany();
                        Clear();
                    }
                    else if (_Result == 222)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Company Name already exists!";
                        IsSuccess(false);
                    }
                    else if (_Result == 333)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = "Company Code already exists!";
                        IsSuccess(false);
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

        private void IsSuccess(bool yes)
        {
            if (yes == false)
                errorMsg.Style.Add("display", "block");
            else
                errorMsg.Style.Add("display", "none");

            // errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        private void Clear()
        {
            txtCompanyName.Text = string.Empty;
            txtCompanyCode.Text = string.Empty;
            fupCompanyLogo.Attributes.Clear();
            fupCompanyLogo.Attributes.Add("class", "btn btn-primary btn-block");
            hddMode.Value = "Save";
            btnSubmit.Text = "Save";
            imgLogoPreview.Src = string.Empty;
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            lblError.Text = string.Empty;
            successMsg.Visible = false;
        }

        protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DataTable _companyTL = Session[AntiClockFitnessCenter.COMPANY_DETAILS] as DataTable;
                string _ID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("RowDelete"))
                {
                    foreach (DataRow _Rows in _companyTL.Rows)
                    {
                        if (_Rows["CompanyId"].ToString() == _ID)
                        {
                            DeleteFiles(_Rows["CompanyLogo"].ToString());
                            break;
                        }
                    }

                    int result = _CompanyBL.DeleteCompany(Convert.ToInt32(_ID));


                    LoadCompany();
                }
                else if (e.CommandName.Equals("RowEdit"))
                {
                    GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    int rowIndex = gvRow.RowIndex;
                    foreach (DataRow _Rows in _companyTL.Rows)
                    {
                        if (_Rows["CompanyId"].ToString() == _ID)
                        {
                            hddId.Value = _ID;
                            if (string.IsNullOrEmpty(_Rows["CompanyLogo"].ToString()))
                            {
                                hddLogo.Value = "";
                                imgLogoPreview.Src = "";
                            }
                            else
                            {
                                hddLogo.Value = _Rows["CompanyLogo"].ToString();

                                imgLogoPreview.Src = "~/Uploads/" + _Rows["CompanyLogo"].ToString();
                            }

                            hddMode.Value = "Update";
                            btnSubmit.Text = "Update";

                            gvRow.BackColor = System.Drawing.Color.FromName("#e7e7e7");
                            txtCompanyName.Text = _Rows["CompanyName"].ToString();
                            txtCompanyCode.Text = _Rows["CompanyCode"].ToString();
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

        private void DeleteFiles(string fileName)
        {
            try
            {

                string hdFilePath = Server.MapPath("~/Uploads/") + fileName;
                System.IO.FileInfo input = new FileInfo(hdFilePath);
                if (input.Exists)
                {
                    input.Delete();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }


        }

        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DataTable _companyTL = Session[AntiClockFitnessCenter.COMPANY_DETAILS] as DataTable;
                if (_companyTL != null)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton _linkView = (LinkButton)e.Row.FindControl("lnkLogo");
                        Label _lblView = (Label)e.Row.FindControl("lblNoLogo");
                        System.Web.UI.HtmlControls.HtmlImage _imgMlogo = (System.Web.UI.HtmlControls.HtmlImage)e.Row.FindControl("imgmlogo");

                        //DataRowView rowView = (DataRowView)e.Row.DataItem;
                        //int myDataKey = Convert.ToInt32(rowView["CompanyId"]);

                        int rowindex = e.Row.RowIndex;// == 0 ? (gvCompany.PageIndex + 1) : (e.Row.RowIndex * (gvCompany.PageIndex + 1));

                        if (string.IsNullOrEmpty(_companyTL.Rows[rowindex]["CompanyLogo"].ToString()))
                        {
                            _linkView.Visible = false;
                            _lblView.Visible = true;
                            _imgMlogo.Src = "";
                        }
                        else
                        {
                            _linkView.Visible = true;
                            _lblView.Visible = false;
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                
            }
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompany.PageIndex = e.NewPageIndex;
            LoadCompany();
        }

    }
}