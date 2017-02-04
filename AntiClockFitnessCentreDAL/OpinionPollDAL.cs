using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace AntiClockFitnessCentreDAL
{
    public class OpinionPollDAL :MainDAL
    {
        public int InsertPollMaster(OpinionPollModal opinionPolModal)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_POLL_MASTER;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", opinionPolModal.pollId);
            _Paramaters.Add("PollQuestion", opinionPolModal.pollQuestion);
            _Paramaters.Add("PollImage", opinionPolModal.pollImage);
            _Paramaters.Add("AdminId", opinionPolModal.PollCreatedBy);           
            _Paramaters.Add("PollStartDate", opinionPolModal.pollStartDate);
            _Paramaters.Add("PollEndDate", opinionPolModal.pollEndDate);
            
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.GetResultAsInteger();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("OpinionPollDAL", "InsertPollMaster-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }

            return _Result;
        }

        public int InsertPollDetails(OpinionPollModal opinionPolModal, List<OpinionPollOptionModal> _LstPollOptionModal)
        {
            SqlTransaction objTrans = null;
            int _Result = 0;
            int _Identity;
            bool PollMaster = false;
            bool PollOptionDelete = false;
            bool PollOption = false;
            try
            {
                _DBManager.CommandText = StoredProcedure.INSERT_POLL_MASTER;
                Hashtable _Paramaters = new Hashtable();
                _Paramaters.Add("PollId", opinionPolModal.pollId);
                _Paramaters.Add("PollQuestion", opinionPolModal.pollQuestion);
                _Paramaters.Add("PollImage", opinionPolModal.pollImage);
                _Paramaters.Add("AdminId", opinionPolModal.PollCreatedBy);
                _Paramaters.Add("PollStartDate", opinionPolModal.pollStartDate);
                _Paramaters.Add("PollEndDate", opinionPolModal.pollEndDate);
                _Paramaters.Add("CompanyId", opinionPolModal.pollCompanyId);

                _DBManager.Parameters = _Paramaters;
                objTrans =(SqlTransaction)_DBManager.Transcation();
                _Identity = _DBManager.GetResultAsInteger();

                if (_Identity != -1)
                    PollMaster = true;

                if (_Identity == -1)
                {
                    CommonDAL _CommonDAL = new CommonDAL();
                    _CommonDAL.InsertException("OpinionPollDAL", "InsertPollMaster-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                    objTrans.Rollback();
                    _Result = -1;
                    return _Result;
                }

                if (opinionPolModal.pollId != 0)
                {
                    _DBManager.CommandText = StoredProcedure.DELETE_POLL_OPTIONS;
                    _Paramaters = new Hashtable();
                    _Paramaters.Add("PollId", opinionPolModal.pollId);
                    _DBManager.Parameters = _Paramaters;
                    int _DeleteResult = _DBManager.ExecuteDeleteCommand();

                    if (_DeleteResult != -1)
                        PollOptionDelete = true;

                    if (_DeleteResult == -1)
                    {
                        CommonDAL _CommonDAL = new CommonDAL();
                        _CommonDAL.InsertException("OpinionPollDAL", "DeletePollOptions-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                        objTrans.Rollback();
                        _Result = -1;
                        return _Result;
                    }
                }


                _DBManager.CommandText = StoredProcedure.INSERT_POLL_OPTIONS;

                for (int i = 0; i < _LstPollOptionModal.Count; i++)
                {
                    _Paramaters = new Hashtable();

                    _Paramaters.Add("PollId", _Identity);
                    _Paramaters.Add("PollOptionName", _LstPollOptionModal[i].pollOptionName);
                    _Paramaters.Add("AdminId", opinionPolModal.PollCreatedBy);

                    _DBManager.Parameters = _Paramaters;
                    _Result = _DBManager.ExecuteInsertCommand();
                    if (_Result != -1)
                    {
                        PollOption = true;
                    }
                    if (_Result == -1)
                    {
                        CommonDAL _CommonDAL = new CommonDAL();
                        _CommonDAL.InsertException("OpinionPollDAL", "InsertPollOptions-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                        objTrans.Rollback();
                        _Result = -1;
                        PollOption = false;
                        return _Result;
                    }
                   
                }

                if(PollMaster && PollOption)
                {
                    objTrans.Commit();
                }
                

               
            }
            catch (Exception ex)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("OpinionPollDAL", "InsertPollDetails-exc", ex.Message + "-" + ex.StackTrace, "User");
                objTrans.Rollback();
            }
            
            return _Result;
        }

        public DataTable GetPollChart(int pollId, bool PollViewFlag)
        {
            _DBManager.CommandText = StoredProcedure.GET_POLL_CHART;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", pollId);
            _Paramaters.Add("PollViewFlag", PollViewFlag);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        } 


        //public int InsertPollOptions(OpinionPollOptionModal opinionPollOptionModal)
        //public int InsertPollOptions(int pollOptionId,int pollId,string pollOptionName,string adminId)
        public int InsertPollOptions(List<OpinionPollOptionModal> _LstPollOptionModal,int pollId)
        {

            _DBManager.CommandText = StoredProcedure.DELETE_POLL_OPTIONS;
            Hashtable _Paramaters = new Hashtable();            
            _Paramaters.Add("PollId", pollId);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();

            
            _DBManager.CommandText = StoredProcedure.INSERT_POLL_OPTIONS;

            for (int i = 0; i < _LstPollOptionModal.Count; i++)
            {
                 _Paramaters = new Hashtable();

                 _Paramaters.Add("PollId", _LstPollOptionModal[i].pollMasterId);
                _Paramaters.Add("PollOptionName", _LstPollOptionModal[i].pollOptionName);
                _Paramaters.Add("AdminId", _LstPollOptionModal[i].PollOptionCreatedBy);

                _DBManager.Parameters = _Paramaters;
                _Result = _DBManager.ExecuteInsertCommand();
            }

           

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("OpinionPollDAL", "InsertPollOption-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }

            return _Result;
        }

        public int InsertPollUsers( int pollId,int pollOptionId, int pollUserId)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_POLL_USERS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", pollId);
            _Paramaters.Add("PollOptionId", pollOptionId);
            _Paramaters.Add("PollUserId", pollUserId);
            

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("OpinionPollDAL", "InsertPollUsers-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }

            return _Result;
        }

        public DataTable GetPollDetails(int pollId, int companyId)
        {
            _DBManager.CommandText = StoredProcedure.GET_POLL_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", pollId);
            _Paramaters.Add("CompanyId", companyId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }



        public DataSet GetTodayPollDetails(string userID, int startRecord, int pageSize, string tableName)
        {
            _DBManager.CommandText = StoredProcedure.GET_TODAY_POLL_DETAILS;
           Hashtable _Paramaters = new Hashtable();
           _Paramaters.Add("UserID", userID);
            _DBManager.Parameters = _Paramaters;

            return _DBManager.SelectTables(startRecord, pageSize, tableName);
        }

        public DataTable GetPollHistory(int userID)
        {
            _DBManager.CommandText = StoredProcedure.GET_POLL_HISTORY;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserID", userID);
            _DBManager.Parameters = _Paramaters;

            return _DBManager.SelectTable();
        }

        public DataTable GetTodayPollOptions(int pollId)
        {
            _DBManager.CommandText = StoredProcedure.GET_TODAY_POLL_OPTIONS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", pollId);
            
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

         

        public int DeletePollDetails(int pollId, string adminId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_POLL_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PollId", pollId);
            _Paramaters.Add("AdminId", adminId);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("OpinionPollDAL", "DeletePollDetails-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }
    }
}
