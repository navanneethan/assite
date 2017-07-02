using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre.Admin
{
    public partial class VideoUploads : System.Web.UI.Page
    {
        CommonBL _CommonBL = new CommonBL();
        TrainingVideoBL _TrainingVideoBL = new TrainingVideoBL();
        TrainingVideoModel _TrainingVideoModel = new TrainingVideoModel();
        UserBL _UserBL = new UserBL();
        string userID = "";
        int companyID = 1;
        StringBuilder strbuild = new StringBuilder();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
                _CommonBL.InsertException("FileUploads", "PreInit", ex.StackTrace, userID);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());

                if (!IsPostBack)
                {
                    //LoadTransactionType();
                    btnDelete.Visible = false;
                    if (_UserDetails.Rows[0]["RoleId"].ToString() == "1")
                    {
                        LoadUsers(0);
                    }
                    else if (_UserDetails.Rows[0]["RoleId"].ToString() == "2")
                    {
                        LoadUsers(Convert.ToInt32(_UserDetails.Rows[0]["UserID"].ToString()));
                    }
                }

                if (gvTransaction.Rows.Count > 0)
                {
                    GetData();
                }
            }
            catch (Exception Ex)
            {
                
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                _TrainingVideoModel.userid = Convert.ToInt32(ddlUsers.SelectedValue);
                _TrainingVideoModel.transactionComapnyId = companyID;
                _TrainingVideoModel.createdby = userID;

                if (hdMode.Value == "Save")
                {
                    _TrainingVideoModel.status = true;
                    if (fupTranscationlocation.HasFile)
                    {
                        try
                        {
                            string ext = System.IO.Path.GetExtension(fupTranscationlocation.PostedFile.FileName);
                            string fnn = ddlUsers.SelectedValue + "_" + String.Format("{0:dMyyyyhmmss}", DateTime.Now);
                            fupTranscationlocation.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnn + ext);
                            _TrainingVideoModel.transactionlocation = fnn + ext;
                            //To get thumbsnail image
                            //(new NReco.VideoConverter.FFMpegConverter()).GetVideoThumbnail(Server.MapPath("~/Uploads/") + fnn + ext,
                            //    Server.MapPath("~/Uploads/")+"thumb_"+fnn + ".jpg");
                            int _Result = _TrainingVideoBL.InsertTransaction(_TrainingVideoModel);
                            if (_Result == 1)
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                                lblSucess.Text = "Saved Sucessfully";
                                IsSuccess(true);
                            }
                            LoadTransaction();
                            Clear();
                        }
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                            lblError.Text = ex.Message;
                            IsSuccess(false);
                            _CommonBL.InsertException("FileUploads", "btnsave_if", ex.StackTrace, userID);
                        }

                    }
                }
                else if (hdMode.Value == "Update")
                {
                    // _TrainingVideoModel.status = ckbStatus.Checked ? true : false;
                    _TrainingVideoModel.transactionId = Convert.ToInt32(hdID.Value);
                    if (fupTranscationlocation.HasFile)
                    {
                        try
                        {
                            string fileName = Path.GetFileName(fupTranscationlocation.PostedFile.FileName);// + "_" + ddlUsers.SelectedValue + "_" + ddlTrancationType.SelectedValue;
                            string FilePath = Server.MapPath("~/Uploads/") + fileName;

                            string fnn = ddlUsers.SelectedValue + "_" + String.Format("{0:dMyyyyhmmss}", DateTime.Now);
                            //strbuild = PdfToImageConverter(fupTranscationlocation, fnn);
                            //_TrainingVideoModel.transactionlocation = strbuild.ToString();

                            string extn2 = System.IO.Path.GetExtension(fupTranscationlocation.FileName);
                            fupTranscationlocation.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fnn + extn2);
                            //_TrainingVideoModel.transactionlocation = Server.MapPath("~/Uploads/" + fnn + extn2);
                            _TrainingVideoModel.transactionlocation = fnn + extn2;


                        }
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                            lblError.Text = ex.Message;
                            IsSuccess(false);
                            _CommonBL.InsertException("FileUploads", "btnsave_else", ex.StackTrace, userID);
                        }

                    }
                    else
                    {
                        _TrainingVideoModel.transactionlocation = hdFilePath.Value;
                    }

                    int _Result = _TrainingVideoBL.InsertTransaction(_TrainingVideoModel);
                    if (_Result == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                        lblSucess.Text = "Saved Sucessfully";
                        IsSuccess(true);

                    }
                    LoadTransaction();
                    Clear();
                    fupTranscationlocation.Attributes.Add("class", "btn btn-primary btn-block validate[required]");
                    btnSave.Text = "Save";
                    hdMode.Value = "Save";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                _CommonBL.InsertException("FileUploads", "btnSave", ex.StackTrace, userID);
                IsSuccess(false);

            }
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransaction();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            SelectRecords();
            gvTransaction.AllowPaging = false;
            LoadTransaction();
            ArrayList arr = (ArrayList)ViewState["RecordsTobeDeleted"];
            count = arr.Count;
            for (int i = 0; i < gvTransaction.Rows.Count; i++)
            {
                if (arr.Contains(gvTransaction.DataKeys[i].Value))
                {
                    DeleteRecord(Convert.ToInt32(gvTransaction.DataKeys[i].Value.ToString()));
                    arr.Remove(gvTransaction.DataKeys[i].Value);
                }
            }
            ViewState["RecordsTobeDeleted"] = arr;
            hfCount.Value = "0";
            gvTransaction.AllowPaging = true;
            LoadTransaction();
            ShowMessage(count);
        }

        protected void gvTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DataTable _fileUploadsTL = Session[AntiClockFitnessCenter.TRAINING_DETAILS] as DataTable;
                string _ID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("RowDelete"))
                {
                    foreach (DataRow _Rows in _fileUploadsTL.Rows)
                    {
                        if (_Rows["TransationId"].ToString() == _ID)
                        {
                            DeleteFiles(_Rows["TrasactionLocation"].ToString());
                        }
                    }
                    int result = _TrainingVideoBL.DeleteTransactions(Convert.ToInt32(_ID));
                    LoadTransaction();
                }
                else if (e.CommandName.Equals("RowEdit"))
                {

                    foreach (DataRow _Rows in _fileUploadsTL.Rows)
                    {
                        if (_Rows["TransationId"].ToString() == _ID)
                        {
                            fupTranscationlocation.Attributes.Add("class", "btn btn-primary btn-block");
                            hdID.Value = _ID;
                            hdFilePath.Value = _Rows["TrasactionLocation"].ToString();
                            btnSave.Text = "Update";
                            hdMode.Value = "Update";
                            LoadTransaction();
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Style.Add("display", "block");
                _CommonBL.InsertException("FileUploads", "gvTransaction_RowCommand", ex.StackTrace, userID);
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void gvTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvTransaction.PageIndex = e.NewPageIndex;
            LoadTransaction();
            SelectRecords();
        }

        protected void gvTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable _fileUploadsTL = Session[AntiClockFitnessCenter.TRAINING_DETAILS] as DataTable;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hdID.Value == _fileUploadsTL.Rows[e.Row.RowIndex]["TransationId"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#e7e7e7");
                }

                LinkButton _linkView = (LinkButton)e.Row.FindControl("lnkDownload");
                System.Web.UI.HtmlControls.HtmlGenericControl _divViedo = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Row.FindControl("myVideo");
                System.Web.UI.HtmlControls.HtmlGenericControl _divSlider = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Row.FindControl("divslider");
                //_divSlider.Controls.Add(_newDiv);

                if (_fileUploadsTL.Rows[e.Row.RowIndex]["TrasactionLocation"].ToString().Contains(".mp4"))
                {
                    _linkView.Attributes.Remove("data-local");
                    _divViedo.Style.Add("display", "block");
                    _divSlider.Style.Add("display", "none");
                }
                else
                {
                    _divViedo.Style.Add("display", "none");

                    string[] imglist = _fileUploadsTL.Rows[e.Row.RowIndex]["TrasactionLocation"].ToString().Split(',');

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

                            System.Web.UI.HtmlControls.HtmlImage _newImage = new System.Web.UI.HtmlControls.HtmlImage();
                            _newImage.Src = "~/Uploads/" + imglist[i].ToString();
                            //_newImage.Src = "~/ConvertedImage/" + imglist[i].ToString();

                            _newDiv.Controls.Add(ltEmbed);
                            _divSlider.Controls.Add(_newDiv);

                        }
                        else
                        {
                            System.Web.UI.HtmlControls.HtmlGenericControl _newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            _newDiv.Attributes.Add("class", "item");
                            System.Web.UI.HtmlControls.HtmlImage _newImage = new System.Web.UI.HtmlControls.HtmlImage();
                            _newImage.Src = "~/ConvertedImage/" + imglist[i].ToString();
                            _newDiv.Controls.Add(_newImage);
                            _divSlider.Controls.Add(_newDiv);


                        }
                    }

                }
            }
        }

        private void LoadUsers(int trainerID)
        {

            DataTable _UsersTBL = _UserBL.GetUserDetailsByRole(3, companyID, trainerID);
            if (_UsersTBL != null)
            {
                ddlUsers.DataSource = _UsersTBL;
                ddlUsers.DataTextField = "FullNameMember";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();
            }
            AntiClockFitnessCenter.BindDropDownList(ref ddlUsers, "--- Select ---", " ");

        }

        private void SelectRecords()
        {
            int currentSelectedRec = 0;

            CheckBox chkAll = (CheckBox)gvTransaction.HeaderRow.Cells[4].FindControl("chkAll");
            chkAll.Checked = true;

            ArrayList arr = (ArrayList)ViewState["RecordsTobeDeleted"];

            for (int i = 0; i < gvTransaction.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)gvTransaction.Rows[i].Cells[4].FindControl("chk");

                if (chk != null)
                {
                    chk.Checked = arr.Contains(gvTransaction.DataKeys[i].Value);

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
            GridViewRow header = gvTransaction.HeaderRow;

            chkAll = (CheckBox)header.FindControl("chkAll");
            for (int i = 0; i < gvTransaction.Rows.Count; i++)
            {

                if (chkAll.Checked)
                {

                    if (!arr.Contains(gvTransaction.DataKeys[i].Value))
                    {
                        arr.Add(gvTransaction.DataKeys[i].Value);
                    }
                }
                else
                {
                    CheckBox chk = (CheckBox)gvTransaction.Rows[i]
                                       .Cells[4].FindControl("chk");
                    if (chk.Checked)
                    {
                        if (!arr.Contains(gvTransaction.DataKeys[i].Value))
                        {
                            arr.Add(gvTransaction.DataKeys[i].Value);
                        }
                    }
                    else
                    {
                        if (arr.Contains(gvTransaction.DataKeys[i].Value))
                        {
                            arr.Remove(gvTransaction.DataKeys[i].Value);
                        }
                    }
                }
            }


            ViewState["RecordsTobeDeleted"] = arr;

        }

        private void IsSuccess(bool yes)
        {
            if (yes == false)
                errorMsg.Style.Add("display", "block");
            else
                errorMsg.Style.Add("display", "none");

            //errorMsg.Visible = yes == false ? true : false;
            successMsg.Visible = yes == false ? false : true;
        }

        private void LoadTransaction()
        {
            //if (hdMode.Value == "Save")
            //{
            try
            {
                if (ddlUsers.SelectedIndex > 0)
                {
                    DataTable _FileuploadTBL = _TrainingVideoBL.GetTransactions(0, Convert.ToInt32(ddlUsers.SelectedValue), companyID);
                    if (_FileuploadTBL.Rows.Count > 0 && _FileuploadTBL != null)
                    {
                        Session[AntiClockFitnessCenter.TRAINING_DETAILS] = _FileuploadTBL;
                        gvTransaction.DataSource = _FileuploadTBL;
                        gvTransaction.DataBind();
                        btnDelete.Visible = true;

                    }
                    else
                    {
                        Session[AntiClockFitnessCenter.TRAINING_DETAILS] = null;
                        gvTransaction.DataSource = null; ;
                        gvTransaction.DataBind();
                        btnDelete.Visible = false;
                    }
                }
                else
                {
                    Session[AntiClockFitnessCenter.TRAINING_DETAILS] = null;
                    gvTransaction.DataSource = null; ;
                    gvTransaction.DataBind();
                    btnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
                _CommonBL.InsertException("FileUploads", "LoadTransaction", ex.StackTrace, userID);
            }

            //    fupTranscationlocation.Attributes.Add("class", "btn btn-primary btn-block validate[required]");
            //}
            //else if (hdMode.Value == "Update")
            //{
            //    fupTranscationlocation.Attributes.Add("class", "btn btn-primary btn-block");
            //}
        }

        private void Clear()
        {
            //ddlTrancationType.SelectedIndex = 0;
            //ddlUsers.SelectedIndex = 0;
            //ckbStatus.Checked = false;
            fupTranscationlocation.Attributes.Clear();
            fupTranscationlocation.Attributes.Add("class", "btn btn-primary btn-block validate[required]");
            btnSave.Text = "Save";
            hdMode.Value = "Save";
            hdID.Value = "0";
            Session[AntiClockFitnessCenter.TRAINING_DETAILS] = null;
            gvTransaction.DataSource = null; ;
            gvTransaction.DataBind();
            btnDelete.Visible = false;
        }

        private void DeleteRecord(int CustomerID)
        {
            try
            {
                DataTable _fileUploadsTL = Session[AntiClockFitnessCenter.TRAINING_DETAILS] as DataTable;
                foreach (DataRow _Rows in _fileUploadsTL.Rows)
                {
                    if (_Rows["TransationId"].ToString() == CustomerID.ToString())
                    {
                        DeleteFiles(_Rows["TrasactionLocation"].ToString());
                        int result = _TrainingVideoBL.DeleteTransactions(Convert.ToInt32(CustomerID));

                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Style.Add("display", "block");
                IsSuccess(false);
                _CommonBL.InsertException("FileUploads", "DeleteRecord", ex.StackTrace, userID);
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
            ClientScript.RegisterStartupScript(this.GetType(),
                            "script", sb.ToString());
        }

        private void DeleteFiles(string fileNames)
        {
            try
            {

                if (fileNames.Contains(".mp4"))
                {
                    string hdFilePath = Server.MapPath("~/Uploads/") + fileNames;
                    System.IO.FileInfo input = new FileInfo(hdFilePath);
                    if (input.Exists)
                    {
                        input.Delete();
                    }
                }
                else
                {
                    string[] imglist = fileNames.Split(',');

                    for (int i = 0; i < imglist.Count(); i++)
                    {
                        string hdFilePath = Server.MapPath("~/Uploads/") + imglist[i].ToString();
                        //string hdFilePath = Server.MapPath("~/ConvertedImage/") + imglist[i].ToString();

                        System.IO.FileInfo input = new FileInfo(hdFilePath);
                        if (input.Exists)
                        {
                            input.Delete();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                errorMsg.Style.Add("display", "block");
                IsSuccess(false);
                _CommonBL.InsertException("FileUploads", "DeleteFiles", ex.StackTrace, userID);
            }


        }
    }
}