using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using paytm;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using AntiClockFitnessCentreBAL;

namespace AntiClockFitnessCentre.Payment
{
    public partial class PayDetails : System.Web.UI.Page
    {
        String masterKey = "oaXP0ccHarwp0Kx0"; //"0QmOcbi8ffLq2dlf";
        string orderid;
        string mobilenum;
        string emailid;
        PaymentBL _PaymentBL = new PaymentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            

//            StringBuilder ppForm = new StringBuilder();
//            {
//                //ppForm.AppendFormat(@"<form  name='frmPP' id='frmPP'  action='https://pguat.paytm.com/oltp-web/processTransaction' method='post'>
//           ppForm.AppendFormat(@"<input type='hidden' name='MID' value='Anitcl13804061972193'>
//           <input type='hidden' name='ORDER_ID' value='" + orderid + "'>");
//                ppForm.AppendFormat(@"   <input type='hidden' name='CUST_ID' value='455451'>
//           <input type='hidden' name='TXN_AMOUNT' value='2'>
//           <input type='hidden' name='CHANNEL_ID' value='WEB'>
//           <input type='hidden' name='INDUSTRY_TYPE_ID' value='Retail'>
// <input type='hidden' name='WEBSITE' value='anitweb'>
//           <input type='hidden' name='CHECKSUMHASH' value='" + checkSum + "'>");
//                ppForm.AppendFormat(@"  <input type='submit'>");
//        //</form>");
//            }

//            Response.Redirect("https://pguat.paytm.com/oltp-web/processTransaction");
//            Response.Write(ppForm.ToString());
            //postScript(Page);
        }

        protected void btnPaynow_Click(object sender, EventArgs e)
        {
            if(Session["PaymentUserID"] == null)
            {
                return;
            }
            int userID = Convert.ToInt32(Session["PaymentUserID"].ToString());
            DataTable _Result = _PaymentBL.GetOrderID(userID, "500");
            if (_Result != null && _Result.Rows.Count > 0)
            {
               // orderid = "D" + DateTime.Now.Ticks.ToString();
                orderid = _Result.Rows[0][0].ToString();
                mobilenum = _Result.Rows[0][1].ToString();
                emailid = _Result.Rows[0][2].ToString();
                Dictionary<String, String> parameters = new Dictionary<string, string>();
                parameters.Add("MID", "anticl43431218008938 ");//"Anitcl13804061972193");
                parameters.Add("ORDER_ID", orderid);
                parameters.Add("CUST_ID", "455451");
                parameters.Add("CHANNEL_ID", "WEB");
                parameters.Add("TXN_AMOUNT", "500");
                parameters.Add("INDUSTRY_TYPE_ID", "Retail110");//Retail
                parameters.Add("WEBSITE", "AnitClockweb");//"AnitCweb"
                parameters.Add("MOBILE_NO", mobilenum);
                parameters.Add("EMAIL_ID", emailid);


                String checkSum = CheckSum.generateCheckSum(masterKey, parameters);
                NameValueCollection collections = new NameValueCollection();
                collections.Add("MID", "anticl43431218008938 ");
                collections.Add("ORDER_ID", orderid);
                collections.Add("CUST_ID", "455451");
                collections.Add("CHANNEL_ID", "WEB");
                collections.Add("TXN_AMOUNT", "500");
                collections.Add("INDUSTRY_TYPE_ID", "Retail110");
                collections.Add("WEBSITE", "AnitClockweb");
                collections.Add("CHECKSUMHASH", checkSum);
                collections.Add("MOBILE_NO", mobilenum);
                collections.Add("EMAIL_ID", emailid);
                string remoteUrl = "https://pguat.paytm.com/oltp-web/processTransaction";
                //string remoteUrl = "https://secure.paytm.in/oltp­web/processTransaction";

                string html = "<html><head>";
                html += "</head><body onload='document.forms[0].submit()'>";
                html += string.Format("<form name='PostForm' method='POST' action='{0}'>", remoteUrl);
                foreach (string key in collections.Keys)
                {
                    html += string.Format("<input name='{0}' type='hidden' value='{1}'>", key, collections[key]);
                }
                html += "</form></body></html>";
                Response.Clear();
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
                Response.Charset = "ISO-8859-1";
                Response.Write(html);
                Response.End();
            }
        }
    }
}