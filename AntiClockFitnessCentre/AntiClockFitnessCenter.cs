using AntiClockFitnessCentreBAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace AntiClockFitnessCentre
{
    public static class AntiClockFitnessCenter
    {
        public const string TRANSACTION_DETAILS = "TransactionDetailS";
        public const string SCHEDULE_DETAILS = "ScheduleDetailS";
        public const string POLL_MASTER_DETAILS = "PollMasterDetails";
        public const string ACHIEVER_DETAILS = "AchieverDetailS";
        public const string NOTIFICATION_DETAILS = "NotificationDetails";
        public const string EVALUATION_DETAILS = "EvaluationDetails";
        public const string COMPANY_DETAILS = "CompanyDetails";
        public const string PROFILE_IMAGE_BYTE = "ProfileImageByte";        
        public const string LOGIN_USER_DETAILS = "LoginUserDetails";
        public const string LOGIN_USER_ID = "LoginUserID";

        public static void BindDropDownList(ref DropDownList dropDownList, string selectionText, string selectionValue)
        {
            dropDownList.Items.Insert(0, new ListItem(selectionText, selectionValue));
        }

        public static string SuccessMessage()
        {
            StringBuilder strSucess = new StringBuilder();
            strSucess.Append("<script>  $(function () { $('.successMsg').show('slide', callback);");
            strSucess.Append(" function callback() { setTimeout(function () { $('.successMsg').fadeOut();  }, 60000); }; ");
            // strSucess.Append(" $('#successMsg1').hide();");
            strSucess.Append("});  </script>");

            return strSucess.ToString();
        }

        public static string ErrorMessage()
        {
            StringBuilder strSucess = new StringBuilder();
            strSucess.Append("<script>  $(function () { $('.errorMsg').show('slide', callback);");
            strSucess.Append(" function callback() { setTimeout(function () { $('.errorMsg').fadeOut();  }, 60000); }; ");
            // strSucess.Append(" $('#successMsg1').hide();");
            strSucess.Append("});  </script>");

            return strSucess.ToString();
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = ConfigurationManager.AppSettings["valid"].ToString();

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = ConfigurationManager.AppSettings["valid"].ToString();
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string ReadXML(string node)
        {
            string XMLPATH = HttpContext.Current.Server.MapPath("~/ACHF.xml");
            XmlDocument _XmlDocument = new XmlDocument();
            _XmlDocument.Load(XMLPATH);
            XmlNode _XmlNode = _XmlDocument.SelectSingleNode(node);
            return _XmlNode.InnerXml;
        }

        public static bool SendEmail(string strTo, string strSubject, string strMessage)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(strTo))
                {
                    return false;
                }
                string server = ConfigurationManager.AppSettings["SMPTServer"].ToString(),
                   username = ConfigurationManager.AppSettings["SMPTUser"].ToString(),
                   pwd = ConfigurationManager.AppSettings["SMPTPwd"].ToString(),
                port = ConfigurationManager.AppSettings["SMPTPort"].ToString();
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(username);
                msg.To.Add(strTo); //from argument

                msg.Subject = strSubject; //from argument

                msg.IsBodyHtml = true; //from argument

                msg.Body = strMessage; //from argument

                SmtpClient client = new SmtpClient(server);
                client.Port = Convert.ToInt16(port);
                //client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(username, pwd);
                client.Timeout = 20000;
                client.Send(msg);
                result = true;
            }
            catch (System.Exception Ex)
            {
                CommonBL _CommonBL = new CommonBL();
                _CommonBL.InsertException("ASP", "SendMail-ex", "Result- " + Ex.Message + "$$" + Ex.StackTrace, "User");
            }
            return result;
        }

         public static byte[] ImageToBinary(string imagePath)
         {
             FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
             byte[] buffer = new byte[fileStream.Length];
             fileStream.Read(buffer, 0, (int)fileStream.Length);
             fileStream.Close();
             return buffer;
         }

        
    }
}