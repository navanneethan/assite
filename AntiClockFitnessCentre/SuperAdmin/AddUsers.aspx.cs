using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.Data;
using System.IO;
using System.Text;

namespace AntiClockFitnessCentre.SuperAdmin
{
    public partial class AddUsers : System.Web.UI.Page
    {
        AntiClockFitnessCentreModal.UserDetails _userdetails = new AntiClockFitnessCentreModal.UserDetails();
        CompanyBL _companyBL = new CompanyBL();
        UserBL _userBL = new UserBL();
        byte[] imgByte = null;
        string userID = "";
        int companyID;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                //companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());


                if (!IsPostBack)
                {

                    LoadRole();
                    LoadTrainer(companyID);
                    LoadCompany();
                   // tdSTatus.Visible = false;
                    errorMsg.Visible = false;
                    successMsg.Visible = false;
                    lblPtitle.Text = "Add User Details";
                    btnsave.Text = "Save";
                    if (Request.QueryString.Count > 0)
                    {
                        Int32 s = Convert.ToInt32(Request.QueryString["i"].ToString());
                        hddID.Value = s.ToString();
                        lblPtitle.Text = "Update User Details";
                        btnsave.Text = "Update";
                        LoadUserdetails(s);
                        
                    }
                }
            }

        }

        private void LoadRole()
        {
            DataTable _RoledeialsTBL = _userBL.GetRole(4);       

            ddlRole.DataSource = _RoledeialsTBL;
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "RoleId";
            ddlRole.DataBind();
            AntiClockFitnessCenter.BindDropDownList(ref ddlRole, "--- Select ---", " ");

        }

        private void LoadCompany()
        {
            DataTable _CompanyTL = _companyBL.GetCompany();
            if (_CompanyTL != null)
            {
                ddlCompany.DataSource = _CompanyTL;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
            }
            AntiClockFitnessCenter.BindDropDownList(ref ddlCompany, "--- Select ---", " ");
        }

        private void ShowMemberNumber(int roleid)
        {
            try
            {
                string _MemberNumber = _userBL.GetMemberName(companyID,roleid);

                if (_MemberNumber == "-1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error Occured while loding Member Number.";
                    IsSuccess(false);
                }
                else
                {
                    txtMemberNumber.Text = _MemberNumber;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                lblError.Text = ex.Message;
                IsSuccess(false);
            }
        }

        private void LoadTrainer(int companyID)
        {
            DataTable _UsersTBL = _userBL.GetUserDetailsByRole(2, (companyID), 0);
            if (_UsersTBL != null)
            {
                ddlTrainer.DataSource = _UsersTBL;
                ddlTrainer.DataTextField = "FullName";
                ddlTrainer.DataValueField = "UserID";
                ddlTrainer.DataBind();
            }
            AntiClockFitnessCenter.BindDropDownList(ref ddlTrainer, "--- Select ---", " ");
        }

        private void LoadUserdetails(int i)
        {

            DataTable _userdeialsTBL = _userBL.GetUserDetails(i);

            imgPreview.ImageUrl = "/Admin/ProfileImage.ashx?ID=" + i + "";

            if (_userdeialsTBL.Rows.Count > 0)
            {
                //tdSTatus.Visible = true;
                Session[AntiClockFitnessCenter.PROFILE_IMAGE_BYTE] = _userdeialsTBL.Rows[0]["ProfileImage"].ToString();

                txtfirstname.Text = _userdeialsTBL.Rows[0]["FirstName"].ToString();
                txtlastname.Text = _userdeialsTBL.Rows[0]["LastName"].ToString();
                rblgender.SelectedValue = _userdeialsTBL.Rows[0]["Gender"].ToString();
                txtphonenumber.Text = _userdeialsTBL.Rows[0]["PhoneNumber"].ToString();
               
                txtemailid.Text = _userdeialsTBL.Rows[0]["EmailId"].ToString();

                if (_userdeialsTBL.Rows[0]["UserName"].ToString() == _userdeialsTBL.Rows[0]["PhoneNumber"].ToString())
                    rblusername.SelectedIndex = 0;
                else
                    rblusername.SelectedIndex = 1;

                if (string.IsNullOrEmpty(_userdeialsTBL.Rows[0]["MemberNumber"].ToString()))
                    ShowMemberNumber(Convert.ToInt32(_userdeialsTBL.Rows[0]["RoleID"].ToString()));
                else
                    txtMemberNumber.Text = _userdeialsTBL.Rows[0]["MemberNumber"].ToString();

                txtMemberNumber.Enabled = _userdeialsTBL.Rows[0]["RoleID"].ToString() == "3" ? false : true;

                ddlRole.SelectedValue = _userdeialsTBL.Rows[0]["RoleID"].ToString();
                txtemailid.Text = _userdeialsTBL.Rows[0]["EmailId"].ToString();
                txtheight.Text = _userdeialsTBL.Rows[0]["Height"].ToString();
                txtweight.Text = _userdeialsTBL.Rows[0]["Weight"].ToString();
                txtdob.Text = string.IsNullOrEmpty(_userdeialsTBL.Rows[0]["DOB"].ToString()) ? " " : string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_userdeialsTBL.Rows[0]["DOB"].ToString()));
                txtactivetill.Text = string.IsNullOrEmpty(_userdeialsTBL.Rows[0]["ActiveTill"].ToString()) ? " " : string.Format("{0:dd MMMM yyyy}", Convert.ToDateTime(_userdeialsTBL.Rows[0]["ActiveTill"].ToString()));
                txtaddressline1.Text = _userdeialsTBL.Rows[0]["ADDRESSLINE1"].ToString();
                txtaddressline2.Text = _userdeialsTBL.Rows[0]["ADDRESSLINE2"].ToString();
                txtcity.Text = _userdeialsTBL.Rows[0]["City"].ToString();
                txtstate.Text = _userdeialsTBL.Rows[0]["State"].ToString();
                txtcountry.Text = _userdeialsTBL.Rows[0]["Country"].ToString();
                txtgoals.Text = _userdeialsTBL.Rows[0]["Goals"].ToString();
                txtproblems.Text = _userdeialsTBL.Rows[0]["Problems"].ToString();
                ddlTrainer.SelectedValue = _userdeialsTBL.Rows[0]["TrainerId"].ToString();
                ddlCompany.SelectedValue = _userdeialsTBL.Rows[0]["CompanyID"].ToString();
                //if (_userdeialsTBL.Rows[0]["Status"].ToString() == "True")
                //    ckbActive.Checked = true;
                //else
                //    ckbActive.Checked = false;
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //DataTable _LoginUserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;

            try
            {
                if (Convert.ToInt32(hddID.Value) > 0)
                {
                    _userdetails.userid = Convert.ToInt32(hddID.Value);
                    //_userdetails.status = ckbActive.Checked ? true : false;

                    if (fuldphoto.PostedFile.FileName != "")
                    {

                        imgByte = new byte[fuldphoto.PostedFile.ContentLength];
                        HttpPostedFile UploadedImage = fuldphoto.PostedFile;
                        UploadedImage.InputStream.Read(imgByte, 0, (int)fuldphoto.PostedFile.ContentLength);

                    }
                    else
                    {
                        //byte[] bytes = File.ReadAllBytes("c:\folder\myfile.ext");
                        imgByte = Session[AntiClockFitnessCenter.PROFILE_IMAGE_BYTE] as byte[];
                    }

                   
                }
                else
                {

                    if (fuldphoto.PostedFile.FileName != "")
                    {

                        imgByte = new byte[fuldphoto.PostedFile.ContentLength];
                        HttpPostedFile UploadedImage = fuldphoto.PostedFile;
                        UploadedImage.InputStream.Read(imgByte, 0, (int)fuldphoto.PostedFile.ContentLength);

                    }
                    else
                    {

                        imgByte = rblgender.SelectedIndex == 0 ? AntiClockFitnessCenter.ImageToBinary(Server.MapPath("~/images/nomale.png")) : AntiClockFitnessCenter.ImageToBinary(Server.MapPath("~/images/nofemale.png"));
                    }
                    
                }



                _userdetails.profileimage = imgByte;
                _userdetails.firstName = txtfirstname.Text;
                _userdetails.lastName = txtlastname.Text;
                _userdetails.memberNumber = txtMemberNumber.Text;
                //_userdetails.companyid = 1;
                _userdetails.gender = rblgender.SelectedValue.ToString();
                _userdetails.phonenumber = txtphonenumber.Text;
                _userdetails.emailid = txtemailid.Text;

                _userdetails.username = rblusername.SelectedIndex == 0 ? txtphonenumber.Text : txtemailid.Text;

                _userdetails.password = "password123";
                _userdetails.trainerid = string.IsNullOrEmpty(ddlTrainer.SelectedValue.Replace(" ", string.Empty)) ? 0 : Convert.ToInt32(ddlTrainer.SelectedValue);
                _userdetails.roleid = Convert.ToInt32(ddlRole.SelectedValue);
                _userdetails.emailid = txtemailid.Text;
                _userdetails.height = string.IsNullOrEmpty(txtheight.Text) ? 0 : Convert.ToInt32(txtheight.Text);
                _userdetails.weight = string.IsNullOrEmpty(txtweight.Text) ? 0 : Convert.ToInt32(txtweight.Text);
                _userdetails.dob = string.IsNullOrEmpty(txtdob.Text.Replace(" ", string.Empty)) ? (DateTime?)null : Convert.ToDateTime(txtdob.Text);
                _userdetails.activetill = string.IsNullOrEmpty(txtactivetill.Text.Replace(" ", string.Empty)) ? (DateTime?)null : Convert.ToDateTime(txtactivetill.Text);
                _userdetails.addressline1 = txtaddressline1.Text;
                _userdetails.addressline2 = txtaddressline2.Text;
                _userdetails.city = txtcity.Text;
                _userdetails.state = txtstate.Text;
                _userdetails.country = txtcountry.Text;
                _userdetails.goals = txtgoals.Text;
                _userdetails.problem = txtproblems.Text;
                _userdetails.createdby = userID;
                _userdetails.companyid = Convert.ToInt32(ddlCompany.SelectedValue);

                int _Result = _userBL.InsertUser(_userdetails);

                if (_Result == -1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error Occured while saving.";
                    IsSuccess(false);
                }
                else if (_Result == 1)
                {
                    try
                    {

                        if (!string.IsNullOrEmpty(txtemailid.Text))
                        {
                            string subject = AntiClockFitnessCenter.ReadXML(@"ACHF/NewUser/Subject");
                            string body = AntiClockFitnessCenter.ReadXML(@"ACHF/NewUser/Body");
                            body = string.Format(body,txtfirstname.Text, "password123");
                            AntiClockFitnessCenter.SendEmail(txtemailid.Text, subject, body);
                        }
                    }
                    catch (Exception exp)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = exp.Message;
                        IsSuccess(false);
                    }
                    if (Convert.ToInt32(hddID.Value) > 0)
                    {
                        lblSucess.Text = "Updated Sucessfully.";
                    }
                    else
                    {
                        lblSucess.Text = "Saved Sucessfully.";
                        clear();
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);                    
                    IsSuccess(true);
                    //clear();
                }
                else if (_Result == 222)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "UserName Already exists";
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

        private void clear()
        {
            txtfirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            txtMemberNumber.Text = string.Empty;
            rblgender.SelectedValue = string.Empty;
            txtphonenumber.Text = string.Empty;
            txtemailid.Text = string.Empty;
            rblusername.SelectedIndex = 0;
            ddlRole.SelectedIndex = 0;
            txtemailid.Text = string.Empty;
            txtheight.Text = string.Empty;
            txtweight.Text = string.Empty;
            txtdob.Text = string.Empty;
            txtactivetill.Text = string.Empty;
            txtaddressline1.Text = string.Empty;
            txtaddressline2.Text = string.Empty;
            txtcity.Text = string.Empty;
            txtstate.Text = string.Empty;
            txtcountry.Text = string.Empty;
            txtgoals.Text = string.Empty;
            txtproblems.Text = string.Empty;
            //ckbActive.Checked = false;
            ddlTrainer.SelectedIndex = 0;
            ddlCompany.SelectedIndex = 0;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCompany.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", "<script type = 'text/javascript'>alert('Select a Company.');</script>", false);
                //lblError.Text = "Select Company";
                //IsSuccess(false);
                ddlRole.SelectedIndex = 0;
                return;
            }
            if (ddlRole.SelectedIndex > 0)
            {
                ShowMemberNumber(Convert.ToInt32(ddlRole.SelectedValue.ToString()));

                //txtMemberNumber.Enabled = Convert.ToInt32(ddlRole.SelectedValue.ToString()) == 3 ? false : true;

            }
        }


        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedIndex > 0)
            {
                companyID = Convert.ToInt32(ddlCompany.SelectedValue.ToString());
            }
            if (ddlCompany.SelectedIndex > 0 && ddlRole.SelectedIndex > 0)
            {
                ShowMemberNumber(Convert.ToInt32(ddlRole.SelectedValue.ToString()));
            }
            
            
        }

    }
}