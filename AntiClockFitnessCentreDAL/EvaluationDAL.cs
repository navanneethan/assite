using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class EvaluationDAL : MainDAL
    {
        public int InsertEvaluation(int EvaluationId, int EvaluationUserId, int companyID, string Evaluationlocation, string CreatedBy)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_EVALUTION;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("EvaluationId", EvaluationId);
            _Paramaters.Add("EvaluationUserId", EvaluationUserId);
            _Paramaters.Add("companyID", companyID);
            _Paramaters.Add("Evaluationlocation", Evaluationlocation);
            _Paramaters.Add("CreatedBy", CreatedBy);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("EvaluationDAL", "InsertEvaluation-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }
            return _Result;
        }

        public int DeleteEvaluation(int EvaluationId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_EVALUTION;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("EvaluationId", EvaluationId);
          
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("EvaluationDAL", "DeleteEvaluation-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetEvaluation(int EvaluationId, int EvaluationUserId, int companyID)
        {
            _DBManager.CommandText = StoredProcedure.GET_EVALUTION;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("EvaluationId", EvaluationId);
            _Paramaters.Add("UserID", EvaluationUserId);
            _Paramaters.Add("CompanyId", companyID);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        } 

        public DataTable GetUserEvaluation(int EvaluationUserId)
        {
            _DBManager.CommandText = StoredProcedure.GET_USER_EVALUTION;
            Hashtable _Paramaters = new Hashtable();           
            _Paramaters.Add("UserID", EvaluationUserId);

            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }
    }
}
