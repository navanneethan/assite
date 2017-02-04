using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AntiClockFitnessCentreBAL;
using System.Data;

namespace AntiClockFitnessCentre.Admin
{
    /// <summary>
    /// Summary description for ProfileImage
    /// </summary>
    public class ProfileImage : IHttpHandler
    {
        UserBL _userBL = new UserBL();
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["ID"];
            string _Gender = "Male";
            if (!string.IsNullOrEmpty(id))
            {
                DataTable _userdeialsTBL = _userBL.GetUserDetails(Convert.ToInt32(id));
                if (_userdeialsTBL != null)
                {
                    _Gender = _userdeialsTBL.Rows[0]["Gender"].ToString();
                    if (!string.IsNullOrEmpty(_userdeialsTBL.Rows[0]["ProfileImage"].ToString()) && !DBNull.Value.Equals(_userdeialsTBL.Rows[0]["ProfileImage"]))
                    {
                        context.Response.BinaryWrite((byte[])_userdeialsTBL.Rows[0]["ProfileImage"]);
                        return;
                    }

                    if (string.IsNullOrEmpty(_Gender))
                    {
                        context.Response.WriteFile(context.Server.MapPath("~/images/nomale.png"));
                    }
                    else if (_Gender.ToLower() == "male")
                    {
                        context.Response.WriteFile(context.Server.MapPath("~/images/nomale.png"));
                    }
                    else if (_Gender.ToLower() == "female")
                    {
                        context.Response.WriteFile(context.Server.MapPath("~/images/nofemale.png"));
                    }
                }
                else
                {

                    if (_Gender.ToLower() == "male")
                    {
                        context.Response.WriteFile(context.Server.MapPath("images/nomale.png"));
                    }
                    else if (_Gender.ToLower() == "female")
                    {
                        context.Response.WriteFile(context.Server.MapPath("images/nofemale.png"));
                    }
                   
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}