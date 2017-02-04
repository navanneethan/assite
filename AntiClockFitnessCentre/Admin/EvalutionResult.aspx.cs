using AntiClockFitnessCentreBAL;
//using PdfToImage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre.Admin
{
    public partial class EvalutionResult : System.Web.UI.Page
    {
        EvaluationBL _EvaluationBL = new EvaluationBL();
        UserBL _UserBL = new UserBL();
        string userID = "";
        int companyID = 1;
        StringBuilder strbuild = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());

                if(!IsPostBack)
                {
                    LoadUsers();
                    LoadEvaluation();
                }
                if (gvEvaluation.Rows.Count > 0)
                {
                    GetData();
                }
            }
        }

        private void LoadUsers()
        {
            try
            {
                //Loading roleid 3 for trainees 
                DataTable _UsersTBL = _UserBL.GetUserDetailsByRole(3, companyID, 0);
                if (_UsersTBL != null && _UsersTBL.Rows.Count > 0)
                {
                    ddlUsers.DataSource = _UsersTBL;
                    ddlUsers.DataTextField = "FullNameMember";
                    ddlUsers.DataValueField = "UserID";
                    ddlUsers.DataBind();
                }
                AntiClockFitnessCenter.BindDropDownList(ref ddlUsers, "--- Select ---", "");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }

        }

        private void LoadEvaluation()
        {
            try
            {
                if (ddlUsers.SelectedIndex > 0)
                {
                    DataTable _evalutionTBL = _EvaluationBL.GetEvaluation(0, Convert.ToInt32(ddlUsers.SelectedValue), companyID);
                    Session[AntiClockFitnessCenter.EVALUATION_DETAILS] = _evalutionTBL;
                    if (_evalutionTBL.Rows.Count > 0 && _evalutionTBL != null)
                    {
                        gvEvaluation.DataSource = _evalutionTBL;
                        gvEvaluation.DataBind();
                        btnDelete.Visible = true;                        
                    }
                    else
                    {
                        Session[AntiClockFitnessCenter.EVALUATION_DETAILS] = null;
                        gvEvaluation.DataSource = null; ;
                        gvEvaluation.DataBind();
                        btnDelete.Visible = false;
                    }
                }
                else
                {
                    Session[AntiClockFitnessCenter.EVALUATION_DETAILS] = null;
                    gvEvaluation.DataSource = null; ;
                    gvEvaluation.DataBind();
                    btnDelete.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }

        private StringBuilder PdfToImageConverter(FileUpload fnFile, string fnName)
        {
            try
            {
                string ext = System.IO.Path.GetExtension(fnFile.FileName);
                fnFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnName + ext);
                string Path = Server.MapPath("~/Uploads/" + fnName + ext);

                //path for save converted images
                string SaveImageToFolder = Server.MapPath("~/ConvertedImage/");

                //PDFConvert Pconverter = new PDFConvert();
                bool Converted = false;
                //Pconverter.JPEGQuality = 2000;
                //Pconverter.OutputFormat = "jpeg";
                //Pconverter.OutputToMultipleFile = true;
                ////Pconverter.Height = 2000;
                ////Pconverter.Width = 1526;
                //Pconverter.FitPage = true;
                //Pconverter.TextAlphaBit = 4;

                System.IO.FileInfo input = new FileInfo(Path);

                string output = string.Format("{0}\\{1}{2}", SaveImageToFolder, fnName + "_", ".jpeg");

                //Converted = Pconverter.Convert(input.FullName, output);

                int PDFPageCount = 0;

                string ImageName = string.Empty;
                if (Converted)
                {
                    FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
                    StreamReader r = new StreamReader(fs);
                    string pdfText = r.ReadToEnd();

                    Regex rx1 = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = rx1.Matches(pdfText);
                    PDFPageCount = Convert.ToInt32(matches.Count);

                    for (int i = 1; i <= PDFPageCount; i++)
                    {
                        if (i == PDFPageCount)
                            strbuild.Append(fnName + "_" + i + ".jpeg");
                        else
                            strbuild.Append(fnName + "_" + i + ".jpeg,");

                    }

                    r.Close();

                }

                input.Delete();//delete pdf file after converted!!!

                return strbuild;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }

            return strbuild;
        }


        //private StringBuilder PdfToImageConverter(FileUpload fnFile, string fnName)
        //{
        //    try
        //    {
        //        string ext = System.IO.Path.GetExtension(fnFile.FileName);
        //        fnFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnName + ext);
        //        string Path = Server.MapPath("~/Uploads/" + fnName + ext);

        //        //path for save converted images
        //        string SaveImageToFolder = Server.MapPath("~/ConvertedImage/");

        //        PDFConvert Pconverter = new PDFConvert();
        //        bool Converted = false;
        //        Pconverter.JPEGQuality = 2000;
        //        Pconverter.OutputFormat = "jpeg";
        //        Pconverter.OutputToMultipleFile = true;
        //        //Pconverter.Height = 2000;
        //        //Pconverter.Width = 1526;
        //        Pconverter.FitPage = true;
        //        Pconverter.TextAlphaBit = 4;

        //        System.IO.FileInfo input = new FileInfo(Path);

        //        string output = string.Format("{0}\\{1}{2}", SaveImageToFolder, fnName + "_", ".jpeg");

        //        Converted = Pconverter.Convert(input.FullName, output);

        //        int PDFPageCount = 0;

        //        string ImageName = string.Empty;
        //        if (Converted)
        //        {
        //            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
        //            StreamReader r = new StreamReader(fs);
        //            string pdfText = r.ReadToEnd();

        //            Regex rx1 = new Regex(@"/Type\s*/Page[^s]");
        //            MatchCollection matches = rx1.Matches(pdfText);
        //            PDFPageCount = Convert.ToInt32(matches.Count);

        //            for (int i = 1; i <= PDFPageCount; i++)
        //            {
        //                if (i == PDFPageCount)
        //                    strbuild.Append(fnName + "_" + i + ".jpeg");
        //                else
        //                    strbuild.Append(fnName + "_" + i + ".jpeg,");

        //            }

        //            r.Close();

        //        }

        //        input.Delete();//delete pdf file after converted!!!

        //        return strbuild;
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
        //        lblError.Text = ex.Message;
        //        IsSuccess(false);
        //    }

        //    return strbuild;
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = string.Empty;
                string fnn = string.Empty;

                if (hdMode.Value == "Save")
                {
                    if (fupEvalutionResult.HasFile)
                    {
                        //filename = fupEvalutionResult.PostedFile.FileName;
                        fnn = "ER" + ddlUsers.SelectedValue + String.Format("{0:dMyyyyhmmss}", DateTime.Now);
                        //strbuild = PdfToImageConverter(fupEvalutionResult, fnn);
                        //filename = strbuild.ToString();
                        string ext = System.IO.Path.GetExtension(fupEvalutionResult.FileName);
                        fupEvalutionResult.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnn + ext);
                        filename =  fnn + ext;
                        

                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("alert('");                       
                        sb.Append(" Please select file to upload.');");
                        sb.Append("</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(),
                                        "script", sb.ToString());
                        return;
                    }
                    lblSucess.Text = "Saved Sucessfully";
                }
                else if (hdMode.Value == "Update")
                {
                    if (fupEvalutionResult.HasFile)
                    {
                        //filename = fupEvalutionResult.PostedFile.FileName;
                        fnn = "ER" + ddlUsers.SelectedValue + String.Format("{0:dMyyyyhmmss}", DateTime.Now);
                        //strbuild = PdfToImageConverter(fupEvalutionResult, fnn);
                        //filename = strbuild.ToString();
                        string ext = System.IO.Path.GetExtension(fupEvalutionResult.FileName);
                        fupEvalutionResult.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnn + ext);
                        filename =  fnn + ext;
                    }
                    else
                    {
                        filename = hdFile.Value;
                    }
                    lblSucess.Text = "Updated Sucessfully";
                }

                
                
                int _Result = _EvaluationBL.InsertEvaluation(Convert.ToInt32(hdID.Value), Convert.ToInt32(ddlUsers.SelectedValue), companyID, filename, userID);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    
                    IsSuccess(true);

                }
                LoadEvaluation();
                clear();
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
            if (yes == false)
                errorMsg.Style.Add("display", "block");
            else
                errorMsg.Style.Add("display", "none");
            
           // errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        private void clear()
        {
            //ddlUsers.SelectedIndex = 0;
            hdID.Value = "0";
            fupEvalutionResult.Attributes.Clear();
            fupEvalutionResult.Attributes.Add("class", "validate[required] btn btn-primary btn-block");
            hdMode.Value = "Save";
            btnSubmit.Text = "Save";
            Session[AntiClockFitnessCenter.EVALUATION_DETAILS] = null;
            gvEvaluation.DataSource = null; ;
            gvEvaluation.DataBind();
            btnDelete.Visible = false;

        }
            


        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void gvEvaluation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DataTable _EvaluationTL = Session[AntiClockFitnessCenter.EVALUATION_DETAILS] as DataTable;

                string _ID = e.CommandArgument.ToString();
                //if (e.CommandName.Equals("RowDelete"))
                //{
                //    foreach (DataRow _Rows in _EvaluationTL.Rows)
                //    {
                //        if (_Rows["EvaluationId"].ToString() == _ID)
                //        {
                //            DeleteFiles(_Rows["EvaluationLocation"].ToString());
                //        }
                //    }                   

                //    int result = _EvaluationBL.DeleteEvaluation(Convert.ToInt32(_ID));


                //    LoadEvaluation();
                //}
                //else 
                if (e.CommandName.Equals("RowEdit"))
                {
                    foreach (DataRow _Rows in _EvaluationTL.Rows)
                    {
                        if (_Rows["EvaluationId"].ToString() == _ID)
                        {
                            hdID.Value = _ID;
                            hdFile.Value = _Rows["EvaluationLocation"].ToString();
                            hdMode.Value = "Update";
                            btnSubmit.Text = "Update";
                            LoadEvaluation();
                            break;
                        }
                    }
                   
                   
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Style.Add("display", "block");
            }
        }

        private void DeleteFiles(string fileNames)
        {
            try
            {
                string[] imglist = fileNames.Split(',');

                for (int i = 0; i < imglist.Count(); i++)
                {
                    string hdFilePath = Server.MapPath("~/ConvertedImage/") + imglist[i].ToString();
                    System.IO.FileInfo input = new FileInfo(hdFilePath);
                    if (input.Exists)
                    {
                        input.Delete();
                    }
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Style.Add("display", "block");
                IsSuccess(false);
            }


        }


        protected void gvEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable _EvaluationTL = Session[AntiClockFitnessCenter.EVALUATION_DETAILS] as DataTable;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(hdID.Value == _EvaluationTL.Rows[e.Row.RowIndex]["EvaluationId"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#e7e7e7");
                }

                LinkButton _linkView = (LinkButton)e.Row.FindControl("lnkDownload");
                System.Web.UI.HtmlControls.HtmlGenericControl _divSlider = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Row.FindControl("divslider");

                string[] imglist = _EvaluationTL.Rows[e.Row.RowIndex]["EvaluationLocation"].ToString().Split(',');
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

                        _newDiv.Controls.Add(ltEmbed);
                        _divSlider.Controls.Add(_newDiv);

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
                        _divSlider.Controls.Add(_newDiv);


                    }
                }
            }
        }

        protected void gvEvaluation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvaluation.PageIndex = e.NewPageIndex;
            LoadEvaluation();
           // SelectRecords();
        }

        private void SelectRecords()
        {
            int currentSelectedRec = 0;

            CheckBox chkAll = (CheckBox)gvEvaluation.HeaderRow.Cells[3].FindControl("chkAll");
            chkAll.Checked = true;

            ArrayList arr = (ArrayList)ViewState["RecordsTobeDeleted"];

            for (int i = 0; i < gvEvaluation.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)gvEvaluation.Rows[i].Cells[3].FindControl("chk");

                if (chk != null)
                {
                    chk.Checked = arr.Contains(gvEvaluation.DataKeys[i].Value);

                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }

                    else
                    {
                        currentSelectedRec++;
                    }
                }

            }
            hfCount.Value = (arr.Count - currentSelectedRec).ToString();

        }


        private void GetData()
        {

            ArrayList arr;

            if (ViewState["RecordsTobeDeleted"] != null)
            {
                arr = (ArrayList)ViewState["RecordsTobeDeleted"];

            }
            else
            {

                arr = new ArrayList();
            }

            CheckBox chkAll = new CheckBox();
            GridViewRow header = gvEvaluation.HeaderRow;


            chkAll = (CheckBox)header.FindControl("chkAll");
            for (int i = 0; i < gvEvaluation.Rows.Count; i++)
            {

                if (chkAll.Checked)
                {

                    if (!arr.Contains(gvEvaluation.DataKeys[i].Value))
                    {

                        arr.Add(gvEvaluation.DataKeys[i].Value);

                    }

                }

                else
                {

                    CheckBox chk = (CheckBox)gvEvaluation.Rows[i]

                                       .Cells[3].FindControl("chk");

                    if (chk.Checked)
                    {

                        if (!arr.Contains(gvEvaluation.DataKeys[i].Value))
                        {

                            arr.Add(gvEvaluation.DataKeys[i].Value);

                        }

                    }


                    else
                    {

                        if (arr.Contains(gvEvaluation.DataKeys[i].Value))
                        {

                            arr.Remove(gvEvaluation.DataKeys[i].Value);

                        }

                    }

                }

            }


            ViewState["RecordsTobeDeleted"] = arr;

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            SelectRecords();
            gvEvaluation.AllowPaging = false;
            LoadEvaluation();
            
            ArrayList arr = (ArrayList)ViewState["RecordsTobeDeleted"];
            count = arr.Count;
            for (int i = 0; i < gvEvaluation.Rows.Count; i++)
            {

                if (arr.Contains(gvEvaluation.DataKeys[i].Value))
                {

                    DeleteRecord(Convert.ToInt32(gvEvaluation.DataKeys[i].Value.ToString()));

                    arr.Remove(gvEvaluation.DataKeys[i].Value);

                }

            }

            ViewState["RecordsTobeDeleted"] = arr;
           
            hfCount.Value = "0";
            gvEvaluation.AllowPaging = true;
            LoadEvaluation();
            ShowMessage(count);
            
        }

        private void DeleteRecord(int CustomerID)
        {
            try
            {
                DataTable _EvaluationTL = Session[AntiClockFitnessCenter.EVALUATION_DETAILS] as DataTable;
                foreach (DataRow _Rows in _EvaluationTL.Rows)
                {
                    if (_Rows["EvaluationId"].ToString() == CustomerID.ToString())
                    {
                        DeleteFiles(_Rows["EvaluationLocation"].ToString());
                        int result = _EvaluationBL.DeleteEvaluation(Convert.ToInt32(CustomerID));

                        break;
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

        private void ShowMessage(int count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                            "script", sb.ToString());
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvaluation();
        }
    }
}