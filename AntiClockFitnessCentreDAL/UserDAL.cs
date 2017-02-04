using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using AntiClockFitnessCentreModal;

namespace AntiClockFitnessCentreDAL
{
    public class UserDAL : MainDAL
    {
        public DataTable ValidateUser(string userName, string password)
        {
            _DBManager.CommandText = StoredProcedure.VALIDATE_USER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserName", userName);
            _Paramaters.Add("Password", password);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public string SelectPassword(string userName)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_PASSWORD;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserName", userName);            

            _DBManager.Parameters = _Paramaters;
            string _Result = _DBManager.GetResultAsString();

            if (string.IsNullOrEmpty(_Result))
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "ForgetPassword-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = "-1";
            }
            return _Result;
           
        }
        

        public int InsertUser(UserDetails userdetails)
        {

            _DBManager.CommandText = StoredProcedure.INSERT_USER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("userid", userdetails.userid);
            _Paramaters.Add("firstname", userdetails.firstName);
            _Paramaters.Add("lastname", userdetails.lastName);
            _Paramaters.Add("gender", userdetails.gender);
            _Paramaters.Add("phonenumber", userdetails.phonenumber);
            _Paramaters.Add("username", userdetails.username);
            _Paramaters.Add("password", userdetails.password);
            _Paramaters.Add("roleid", userdetails.roleid);
            _Paramaters.Add("emailid", userdetails.emailid);
            _Paramaters.Add("height", userdetails.height);
            _Paramaters.Add("weight", userdetails.weight);
            _Paramaters.Add("dob", userdetails.dob);
            _Paramaters.Add("activetill", userdetails.activetill);
            _Paramaters.Add("addressline1", userdetails.addressline1);
            _Paramaters.Add("addressline2", userdetails.addressline2);
            _Paramaters.Add("city", userdetails.city);
            _Paramaters.Add("state", userdetails.state);
            _Paramaters.Add("country", userdetails.country);
            _Paramaters.Add("Goals", userdetails.goals);
            _Paramaters.Add("problems", userdetails.problem);
            _Paramaters.Add("profileimage", userdetails.profileimage);
            _Paramaters.Add("status", userdetails.status);
            _Paramaters.Add("createdby", userdetails.createdby);
            _Paramaters.Add("memberNumber", userdetails.memberNumber);
            _Paramaters.Add("companyId", userdetails.companyid);
            _Paramaters.Add("trainerid", userdetails.trainerid);
            

            _DBManager.Parameters = _Paramaters;
            string _Result = _DBManager.GetResultAsString();

            if (string.IsNullOrEmpty(_Result))
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "InsertUser-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = "-1";
            }
            return Convert.ToInt32(_Result);

        }

        public int UpdateTraineeDetails(UserDetails userdetails, bool flag)
        {
            _DBManager.CommandText = StoredProcedure.UPDATE_TRAINEE_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", userdetails.userid);
            _Paramaters.Add("FirstName", userdetails.firstName);
            _Paramaters.Add("LastName", userdetails.lastName);
            _Paramaters.Add("Dob", userdetails.dob);
            _Paramaters.Add("Gender", userdetails.gender);
            _Paramaters.Add("addressline1", userdetails.addressline1);
            _Paramaters.Add("addressline2", userdetails.addressline2);
            _Paramaters.Add("city", userdetails.city);
            _Paramaters.Add("state", userdetails.country);
            _Paramaters.Add("country", userdetails.state);
            _Paramaters.Add("ProfileImage", userdetails.profileimage);
            _Paramaters.Add("flag", flag);
            _DBManager.Parameters = _Paramaters;

            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "UpdateTraineeDetails-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetUserDetails(int userid)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_USER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("userid", userid);           
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public DataTable GetUserDetails(int userid,int roleid, int companyID)
        {
            _DBManager.CommandText = StoredProcedure.GET_USER_DETAILS_COMPANY_ROLE;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("userid", userid);
            _Paramaters.Add("roleId", roleid);
            _Paramaters.Add("CompanyId", companyID);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public DataTable GetUserDetailsByRole(int roleid, int companyID, int trainerID)
        {
            _DBManager.CommandText = StoredProcedure.GET_USER_DETAILS_BY_ROLE;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("RoleID", roleid);
            _Paramaters.Add("CompanyID", companyID);
            _Paramaters.Add("TrainerID", trainerID);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int DeleteUser(int userid)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_USER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("userid", userid);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "DeleteUserDetails-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetRole(int roleId)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_ROLE_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("RoleId", roleId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int UpdateTraineeByTrainer(int Userid,int Height,int Weight)
        {
            _DBManager.CommandText = StoredProcedure.UPDATE_TRAINEE_BY_TRAINER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", Userid);
            _Paramaters.Add("Height", Height);
            _Paramaters.Add("Weight", Weight);           
            _DBManager.Parameters = _Paramaters;

            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "UpdateTraineeByTrainer-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public int UpdatePassword(int Userid,string Password)
        {
            _DBManager.CommandText = StoredProcedure.UPDATE_PASSWORD;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserId", Userid);
            _Paramaters.Add("Password", Password);
            
            _DBManager.Parameters = _Paramaters;

            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "UpdatePassword-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public string GetMemberName(int companyId,int roleId)
        {
            _DBManager.CommandText = StoredProcedure.GET_MEMBER_NUMBER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyId", companyId);
            _Paramaters.Add("RoleId", roleId);
            _DBManager.Parameters = _Paramaters;

            string _Result = _DBManager.GetResultAsString();

            if (string.IsNullOrEmpty(_Result))
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("UserDAL", "GetMemberName-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = "-1";
            }

            return _Result;
        }

       
    }
}
