using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class OpinionPollBL
    {
        OpinionPollDAL _opinionPollDAL = new OpinionPollDAL();

        public int InsertPollMaster(OpinionPollModal opinionPollModal)
        {
            return _opinionPollDAL.InsertPollMaster(opinionPollModal);
        }

        public int InsertPollDetails(OpinionPollModal opinionPolModal, List<OpinionPollOptionModal> _LstPollOptionModal)
        {
            return _opinionPollDAL.InsertPollDetails(opinionPolModal, _LstPollOptionModal);
        }

        //public int InsertPollOption(int pollOptionId, int pollId, string pollOptionName, string adminId)
        //{
        //    return _opinionPollDAL.InsertPollOptions(pollOptionId,pollId,pollOptionName,adminId);
        //}

        public int InsertPollOption(List<OpinionPollOptionModal> _LstPollOptionModal, int pollId)
        {
            return _opinionPollDAL.InsertPollOptions(_LstPollOptionModal, pollId);
        }

        public int InsertPollUsers(int pollId, int pollOptionId, int pollUserId)
        {
            return _opinionPollDAL.InsertPollUsers( pollId, pollOptionId,  pollUserId);
        }

        public DataTable GetPollDetails(int pollId, int companyId)
        {
            return _opinionPollDAL.GetPollDetails(pollId,companyId);
        }

        public DataTable GetPollChart(int pollId, bool PollViewFlag)
        {
            return _opinionPollDAL.GetPollChart(pollId, PollViewFlag);
        }

        public DataTable GetTodayPollOptions(int pollId)
        {
            return _opinionPollDAL.GetTodayPollOptions(pollId);
        }

        public int DeletePollDetails(int pollId, string adminId)
        {
            return _opinionPollDAL.DeletePollDetails(pollId, adminId);
        }

        public DataSet GetTodayPollDetails(string userID, int startRecord, int pageSize, string tableName)
        {
            return _opinionPollDAL.GetTodayPollDetails(userID, startRecord, pageSize, tableName);
        }

        public DataTable GetPollHistory(int userID)
        {
            return _opinionPollDAL.GetPollHistory(userID);
        }

    }
}
