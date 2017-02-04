using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class AchievementDAL : MainDAL
    {

        public int InsertAchievementMaster(int achieverMasterId,string achievement,string userid,string companyID)
        {

            _DBManager.CommandText = StoredProcedure.INSERT_ACHIEVER_MASTER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("AchieverMasterId", achieverMasterId);
            _Paramaters.Add("UserId", userid);
            _Paramaters.Add("CompanyId", companyID);
            _Paramaters.Add("Details", achievement);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("AchievementDAL", "InsertAchievementMaster-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }
            return _Result;

        }

        public int DeleteAchievementMaster(int achieverMasterId,int userid)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_ACHIEVER_MASTER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("AchieverMasterId", achieverMasterId);
            _Paramaters.Add("Userid", userid);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("AchievementDAL", "DeleteAchievementMaster-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }



        public DataTable GetAchievementMaster(string companyID)
        {
            _DBManager.CommandText = StoredProcedure.GET_ACHIEVER_MASTER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyId", companyID);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }


        public int InsertAchieverDetails(int achieverId, int achievementMasterId, int userId, DateTime monthFor, int adminId, string achivedNumber)
        {

            _DBManager.CommandText = StoredProcedure.INSERT_ACHIEVER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("AchieverId", achieverId);
            _Paramaters.Add("UserId", userId);
            _Paramaters.Add("AdminId", adminId);
            _Paramaters.Add("AchievementId", achievementMasterId);
            _Paramaters.Add("MonthFor", monthFor);
            _Paramaters.Add("AchivedNumber", achivedNumber);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("AchievementDAL", "InsertAchieverDetails-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }
            return _Result;

        }

        public DataTable GetAchieverDetails(int achieverId)
        {
            _DBManager.CommandText = StoredProcedure.GET_ACHIEVER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("AchieverId", achieverId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int DeleteAchieverDetails(int achieverId, int adminid)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_ACHIEVER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("AchieverId", achieverId);
            _Paramaters.Add("AdminId", adminid);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("AchievementDAL", "DeleteAchieverDetails-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataSet GetTopAchievers(int startRecord, int pageSize, string tableName)
        {
            _DBManager.CommandText = StoredProcedure.GET_TOP_ACHIEVER_DETAILS;
            Hashtable _Paramaters = new Hashtable();
           
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTables(startRecord, pageSize, tableName);
        }
    }
}
