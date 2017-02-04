using AntiClockFitnessCentreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreBAL
{
    public class AchievementBL
    {
        AchievementDAL _AchievementDAL = new AchievementDAL();

        public int InsertAchievementMaster(int achieverMasterId,string achievement, string userid, string companyID)
        {
            return _AchievementDAL.InsertAchievementMaster(achieverMasterId, achievement,  userid,  companyID);
        }

        public DataTable GetAchievementMaster(string companyID)
        {
            return _AchievementDAL.GetAchievementMaster(companyID);
        }

        public int DeleteAchievementMaster(int achieverMasterId, int userid)
        {
            return _AchievementDAL.DeleteAchievementMaster(achieverMasterId, userid);
        }

        public int InsertAchieverDetails(int achieverId, int achievementMasterId, int userId, DateTime monthFor, int adminId,string achivedNumber)
        {
            return _AchievementDAL.InsertAchieverDetails(achieverId, achievementMasterId, userId, monthFor, adminId, achivedNumber);
        }

        public DataTable GetAchieverDetails(int achieverId)
        {
            return _AchievementDAL.GetAchieverDetails(achieverId);
        }

        public int DeleteAchieverDetails(int achieverId, int adminid)
        {
            return _AchievementDAL.DeleteAchieverDetails(achieverId, adminid);
        }

        public DataSet GetTopAchievers(int startRecord, int pageSize, string tableName)
        {
            return _AchievementDAL.GetTopAchievers(startRecord, pageSize, tableName);
        }
    }
}
