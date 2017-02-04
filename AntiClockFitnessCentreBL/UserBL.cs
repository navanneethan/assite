using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Text;
using AntiClockFitnessCentreDAL;
using AntiClockFitnessCentreModal;

namespace AntiClockFitnessCentreBAL
{
    public class UserBL
    {
        UserDAL _LoginDAL = new UserDAL();

        public DataTable ValidateUser(string username, string password)
        {
            return _LoginDAL.ValidateUser(username, password);
        }

        public int InsertUser(UserDetails userdetails)
        {
            return _LoginDAL.InsertUser(userdetails);
        }

        public string SelectPassword(string userName)
        {
            return _LoginDAL.SelectPassword(userName);
        }


        public int UpdateTraineeDetails(UserDetails userdetails, bool flag)
        {
            return _LoginDAL.UpdateTraineeDetails(userdetails, flag);
        }

        public int UpdateTraineeByTrainer(int Userid, int Height, int Weight)
        {
            return _LoginDAL.UpdateTraineeByTrainer(Userid,Height,Weight);
        }

        public int UpdatePassword(int Userid, string Password)
        {
            return _LoginDAL.UpdatePassword(Userid, Password);
        }

      

        public DataTable GetUserDetails(int userid)
        {
            return _LoginDAL.GetUserDetails(userid);
        }

        public DataTable GetUserDetails(int userid, int roleid, int companyID)
        {
            return _LoginDAL.GetUserDetails(userid,roleid,companyID);
        }

        public DataTable GetUserDetailsByRole(int roleid, int companyID, int trainerID)
        {
            return _LoginDAL.GetUserDetailsByRole(roleid, companyID, trainerID);
        }

        public int DeleteUser(int userid)
        {
            return _LoginDAL.DeleteUser(userid);
        }

        public DataTable GetRole(int roleId)
        {
            return _LoginDAL.GetRole(roleId);
        }

        public string GetMemberName(int CompanyId, int roleId)
        {
            return _LoginDAL.GetMemberName(CompanyId, roleId);
        }
    }
}
