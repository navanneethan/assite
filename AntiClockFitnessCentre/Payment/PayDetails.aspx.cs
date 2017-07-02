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
using System.Security.Cryptography;
using System.Configuration;

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
            string[] hashVarsSeq;
            string hash_string = string.Empty;
            string key = ConfigurationManager.AppSettings["MERCHANT_KEY"];
            int userID = Convert.ToInt32(Session["PaymentUserID"].ToString());
            string amount = "499";
            DataTable _Result = _PaymentBL.GetOrderID(userID, amount);
            if (_Result != null && _Result.Rows.Count > 0)
            {
               // orderid = "D" + DateTime.Now.Ticks.ToString();
                Random rnd = new Random();
                string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                //orderid = strHash.ToString().Substring(0, 20);
                orderid = _Result.Rows[0][0].ToString();
                mobilenum = _Result.Rows[0][1].ToString();
                emailid = _Result.Rows[0][2].ToString();

                hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                hash_string = "";

                foreach (string hash_var in hashVarsSeq)
                {
                    if (hash_var == "key")
                    {
                        hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                        hash_string = hash_string + '|';
                    }
                    else if (hash_var == "txnid")
                    {
                        hash_string = hash_string + orderid;
                        hash_string = hash_string + '|';
                    }
                    else if (hash_var == "amount")
                    {
                        hash_string = hash_string + Convert.ToDecimal(amount).ToString("g29");
                        hash_string = hash_string + '|';
                    }
                    else if (hash_var == "productinfo")
                    {
                        hash_string = hash_string + "Registration";
                        hash_string = hash_string + '|';
                    }
                    else if (hash_var == "firstname")
                    {
                        hash_string = hash_string + "Atsaipavi";
                        hash_string = hash_string + '|';
                    }
                    else if (hash_var == "email")
                    {
                        hash_string = hash_string + emailid;
                        hash_string = hash_string + '|';
                    }
                    else
                    {

                        hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                        hash_string = hash_string + '|';
                    }
                }

                hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT

               string hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                string action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL


                System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                data.Add("hash", hash1);
                data.Add("txnid", orderid);
                data.Add("key", key);
                string AmountForm = Convert.ToDecimal(amount).ToString("g29");
                data.Add("amount", AmountForm);
                data.Add("firstname", "Atsaipavi");
                data.Add("email", emailid);
                data.Add("phone", mobilenum);
                data.Add("productinfo", "Registration");
                //data.Add("surl", "http://localhost:1345/Payment/PayResponse.aspx");
                //data.Add("furl", "http://localhost:1345/Payment/PayResponse.aspx");
                data.Add("surl", "http://www.atsaipavi.com/Payment/PayResponse.aspx");
                data.Add("furl", "http://www.atsaipavi.com/Payment/PayResponse.aspx");
                data.Add("lastname", "");
                data.Add("curl", "");
                data.Add("address1", "");
                data.Add("address2", "");
                data.Add("city", "");
                data.Add("state", "");
                data.Add("country", "");
                data.Add("zipcode", "");
                data.Add("udf1", "");
                data.Add("udf2", "");
                data.Add("udf3", "");
                data.Add("udf4", "");
                data.Add("udf5", "");
                data.Add("pg", "");
                data.Add("service_provider", "payu_paisa");

                string strForm = PreparePOSTForm(action1, data);
                Page.Controls.Add(new LiteralControl(strForm));




                /*
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
                Response.End();*/
            }
        }


        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }


        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }

            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }

    }
}