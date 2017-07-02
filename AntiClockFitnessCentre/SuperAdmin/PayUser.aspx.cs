using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntiClockFitnessCentre.SuperAdmin
{
    public partial class PayUser : System.Web.UI.Page
    {
        CompanyBL _CompanyBL = new CompanyBL();
        CommonBL _CommonBL = new CommonBL();
        UserBL _UserBL = new UserBL();
        string userID = "";
        string companyID = "";

        String masterKey = "oaXP0ccHarwp0Kx0"; //"0QmOcbi8ffLq2dlf";
        string orderid;
        string mobilenum;
        string emailid;
        PaymentBL _PaymentBL = new PaymentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
                {
                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    userID = _UserDetails.Rows[0]["UserID"].ToString();
                    companyID = _UserDetails.Rows[0]["CompanyID"].ToString();
                    if (!IsPostBack)
                    {
                        LoadCompany();
                    }
                }
            }
            catch (Exception Ex)
            {
                _CommonBL.InsertException("PayUser", "Page_Load", Ex.StackTrace, userID);
            }
        }

        private void LoadCompany()
        {
            DataTable _CompanyTL = _CompanyBL.GetCompany();
            ddlCompany.DataSource = _CompanyTL;
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataValueField = "CompanyId";
            ddlCompany.DataBind();
            AntiClockFitnessCenter.BindDropDownList(ref ddlCompany, "- Select Company -", "-1");
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedIndex > 0)
            {
                DataTable _Users = _UserBL.GetUserDetailsByRole(3,Convert.ToInt32(ddlCompany.SelectedItem.Value),0);
                ddlUser.DataSource = _Users;
                ddlUser.DataTextField = "FullName";
                ddlUser.DataValueField = "UserID";
                ddlUser.DataBind();
                AntiClockFitnessCenter.BindDropDownList(ref ddlUser, "- Select User -", "-1");

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedIndex == 0)
            {
                errorMsg.Visible = true;
                lblError.Text = "Select atleast one company.";
            }
            else if (ddlUser.SelectedIndex == 0)
            {
                errorMsg.Visible = true;
                lblError.Text = "Select atleast one user.";
            }
            else
            {
                int userID = Convert.ToInt32(ddlUser.SelectedItem.Value.ToString());
                DataTable _Result = _PaymentBL.GetOrderID(userID, "500");
                if (_Result != null && _Result.Rows.Count > 0)
                {
                    orderid = _Result.Rows[0][0].ToString();
                    mobilenum = _Result.Rows[0][1].ToString();
                    emailid = _Result.Rows[0][2].ToString();
                    int _Results = _PaymentBL.UpdatePaymentDetails(orderid, "Cash", "Cash",
                    "INR",  "Cash", "Cash", "Cash",  ddlMonths.SelectedItem.Value,"1");
                    successMsg.Visible = true;
                    lblSucess.Text = "For "+ddlUser.SelectedItem.Text+ " activated for "+ddlMonths.SelectedItem.Value+" month(s)";
                }
            }
        }
    }
}