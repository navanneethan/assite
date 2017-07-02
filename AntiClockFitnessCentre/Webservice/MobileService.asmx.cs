using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace AntiClockFitnessCentre.Webservice
{
    /// <summary>
    /// Summary description for MobileService
    /// </summary>
    [WebService(Namespace = "http://atsaipavi.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MobileService : System.Web.Services.WebService
    {
        public Authentication authentication;


        [SoapHeader("authentication", Required = true)]
        [WebMethod]
        public string HelloWorld()
        {
            if (!CheckAuthention(authentication))
            {
                return null;
            }
            return "Hello World";
        }

        public bool CheckAuthention(Authentication authentication)
        {
            bool _Result = false;
            if (authentication == null)
            {
                return _Result;
            }
            string username = AntiClockFitnessCenter.Decrypt(authentication.Username);
            string password = AntiClockFitnessCenter.Decrypt(authentication.Password);
            string configUser = ConfigurationManager.AppSettings["test_username"].ToString();
            string configPassword = ConfigurationManager.AppSettings["test_password"].ToString();
            if (username == configUser && password == configPassword)
            {
                _Result = true;
            }
            return _Result;
        }
    
    }

    public class Authentication : SoapHeader
    {
        public string Username;
        public string Password;
    }
}
