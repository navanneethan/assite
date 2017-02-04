using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using paytm;
using AntiClockFitnessCentreBAL;

namespace AntiClockFitnessCentre.Payment
{
    public partial class PayResponse : System.Web.UI.Page
    {
        PaymentBL _PaymentBL = new PaymentBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Request.Form["MID"];
            Label2.Text = Request.Form["TXNID"];
            Label3.Text = Request.Form["ORDERID"];
            Label4.Text = Request.Form["BANKTXNID"];
            Label5.Text = Request.Form["TXNAMOUNT"];
            Label6.Text = Request.Form["CURRENCY"];
            Label7.Text = Request.Form["STATUS"];
            Label8.Text = Request.Form["RESPCODE"];
            Label9.Text = Request.Form["RESPMSG"];
            Label10.Text = Request.Form["TXNDATE"];
            Label11.Text = Request.Form["GATEWAYNAME"];
            Label12.Text = Request.Form["BANKNAME"];
            Label13.Text = Request.Form["PAYMENTMODE"];
            Label14.Text = Request.Form["CHECKSUMHASH"];
            int _Result = _PaymentBL.UpdatePaymentDetails(Label3.Text, Label2.Text, Label4.Text,
                Label6.Text, Label8.Text, Label9.Text, Label11.Text, Label12.Text, Label13.Text, Label4.Text,"12");
            String masterKey = "0QmOcbi8ffLq2dlf";
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("MID", Request.Form["MID"]);
            parameters.Add("TXNID", Request.Form["TXNID"]);
            parameters.Add("ORDER_ID", Request.Form["ORDERID"]);
            parameters.Add("BANKTXNID", Request.Form["BANKTXNID"]);
            parameters.Add("TXNAMOUNT", Request.Form["TXNAMOUNT"]);
            parameters.Add("CURRENCY", Request.Form["CURRENCY"]);
            parameters.Add("STATUS", Request.Form["STATUS"]);
            parameters.Add("RESPCODE", Request.Form["RESPCODE"]);
            parameters.Add("RESPMSG", Request.Form["RESPMSG"]);
            parameters.Add("TXNDATE", Request.Form["TXNDATE"]);
            parameters.Add("GATEWAYNAME", Request.Form["GATEWAYNAME"]);
            parameters.Add("BANKNAME", Request.Form["BANKNAME"]);
            parameters.Add("PAYMENTMODE", Request.Form["PAYMENTMODE"]);
            string str = Request.Form["CHECKSUMHASH"];

            if (CheckSum.verifyCheckSum(masterKey, parameters, str))
            {
                Response.Write("Success");
                //Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("Failure");
               // Response.Redirect("maintenence.aspx");
            }
        }
    }
}