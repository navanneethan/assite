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

            paySuccess.Visible = false;
            paySuccessMes.Visible = false;
            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
            string status, transactionId, bankTransactionId, responseMessage, bankName, paymentMode, hash;
            string months = "";
            string dateTran = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt"); 
            if (Request.Form["status"] == "success")
            {
                paySuccess.Visible = true;
                paySuccessMes.Visible = true;
                payFailure.Visible = false;
                status = "2";
                months = "1";
                order_id = Request.Form["txnid"];
                 transactionId = Request.Form["payuMoneyId"];
                 bankTransactionId = Request.Form["bank_ref_num"];
                 responseMessage = Request.Form["Error"];
                 bankName = Request.Form["PG_TYPE"];
                 paymentMode = Request.Form["mode"];
                 hash = Request.Form["hash"];
                 string bodyMessageRef = AntiClockFitnessCenter.ReadXML(@"ACHF/Subscription/Body");
                 string headMessageRef = AntiClockFitnessCenter.ReadXML(@"ACHF/Subscription/Subject");

                 bodyMessageRef = string.Format(bodyMessageRef, order_id
                             , Request.Form["amount"], dateTran);
                 lblAmount.Text = Request.Form["amount"];
                 lblID.Text = transactionId;
                 lblTransactionDate.Text = dateTran;
                 lblEmailAddress.Text = Request.Form["email"];

                 try
                 {
                     AntiClockFitnessCenter.SendEmail(Request.Form["email"], headMessageRef, bodyMessageRef);
                 }
                 catch (Exception ex)
                 {
                     
                    
                 }
               
            }
            else
            {
                paySuccess.Visible = false;
                order_id = Request.Form["txnid"];
                transactionId = Request.Form["payuMoneyId"];
                bankTransactionId = Request.Form["bank_ref_num"];
                responseMessage = Request.Form["Error"];
                bankName = Request.Form["PG_TYPE"];
                paymentMode = Request.Form["mode"];
                hash = Request.Form["hash"];
                months = "0";
                status = "3";
                lblResponseMessage.Text = Request.Form["Error"];
                lblAmount.Text = Request.Form["amount"];
                lblID.Text = transactionId;
                lblTransactionDate.Text = dateTran;
                lblEmailAddress.Text = Request.Form["email"];
            }
            int _Result = _PaymentBL.UpdatePaymentDetails(order_id, transactionId, bankTransactionId,
               responseMessage, bankName, paymentMode,hash,months,status);
            //string currencyType = Request.Form["mode"];
        }
    }
}