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

namespace AntiClockFitnessCentre
{
    public partial class Register : System.Web.UI.Page
    {
        AntiClockFitnessCentreModal.UserDetails _userdetails = new AntiClockFitnessCentreModal.UserDetails();
        CompanyBL _companyBL = new CompanyBL();
        UserBL _userBL = new UserBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompany();
            }
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
            AntiClockFitnessCenter.BindDropDownList(ref ddlCompany, "--- Select ---", "");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _userdetails.profileimage = null;
                _userdetails.firstName = txtfirstname.Text;
                _userdetails.lastName = txtlastname.Text;
                _userdetails.memberNumber = string.Empty;
                _userdetails.companyid = Convert.ToInt32(ddlCompany.SelectedValue.ToString());

                string _MemberNumber = _userBL.GetMemberName(Convert.ToInt32(ddlCompany.SelectedValue.ToString()),3);

                if (_MemberNumber == "-1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "Error Occured while saving.";
                    IsSuccess(false);
                    return;
                }

                _userdetails.memberNumber = _MemberNumber;

                _userdetails.gender = rblgender.SelectedValue.ToString();
                _userdetails.phonenumber = txtphonenumber.Text;
                _userdetails.emailid = txtemailid.Text;

                _userdetails.username = rblusername.SelectedIndex == 0 ? txtphonenumber.Text : txtemailid.Text;

                _userdetails.password = "password123";
                _userdetails.trainerid = 0;
                _userdetails.roleid = 3;
                _userdetails.emailid = txtemailid.Text;
                _userdetails.height = string.IsNullOrEmpty(txtheight.Text) ? 0 : Convert.ToInt32(txtheight.Text);
                _userdetails.weight = string.IsNullOrEmpty(txtweight.Text) ? 0 : Convert.ToInt32(txtweight.Text);
                _userdetails.dob = string.IsNullOrEmpty(txtdob.Text.Replace(" ", string.Empty)) ? (DateTime?)null : Convert.ToDateTime(txtdob.Text);
                _userdetails.activetill = null;
                _userdetails.addressline1 = txtaddressline1.Text;
                _userdetails.addressline2 = txtaddressline2.Text;
                _userdetails.city = txtcity.Text;
                _userdetails.state = txtstate.Text;
                _userdetails.country = txtcountry.Text;
                _userdetails.goals = txtgoals.Text;
                _userdetails.problem = txtproblems.Text;
                _userdetails.createdby = "0";

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
                            body = string.Format(body, txtfirstname.Text,"password123");
                            AntiClockFitnessCenter.SendEmail(txtemailid.Text, subject, body);
                        }
                    }
                    catch (Exception exp)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                        lblError.Text = exp.Message;
                        IsSuccess(false);
                    }

                   
                    clear();
                    ShowMessage();
                    //Response.Redirect("Login.aspx");
                   
                }
                else if (_Result == 222)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                    lblError.Text = "UserName Already exists";
                    IsSuccess(false);
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

        private void clear()
        {
            txtfirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
           // txtMemberNumber.Text = string.Empty;
            rblgender.SelectedValue = string.Empty;
            txtphonenumber.Text = string.Empty;
            txtemailid.Text = string.Empty;
            rblusername.SelectedIndex = 0;
           // ddlRole.SelectedIndex = 0;
            txtemailid.Text = string.Empty;
            txtheight.Text = string.Empty;
            txtweight.Text = string.Empty;
            txtdob.Text = string.Empty;
            //txtactivetill.Text = string.Empty;
            txtaddressline1.Text = string.Empty;
            txtaddressline2.Text = string.Empty;
            txtcity.Text = string.Empty;
            txtstate.Text = string.Empty;
            txtcountry.Text = string.Empty;
            txtgoals.Text = string.Empty;
            txtproblems.Text = string.Empty;
            //ckbActive.Checked = false;
            //ddlTrainer.SelectedIndex = 0;
            ddlCompany.SelectedIndex = 0;
        }

        private void ShowMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(" Check your mail for password.');window.location.href = 'Login.aspx';");
            sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                            "script", sb.ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}