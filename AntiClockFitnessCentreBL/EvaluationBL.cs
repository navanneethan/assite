using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class EvaluationBL
    {
        EvaluationDAL _evaluationDAL = new EvaluationDAL();

        public int InsertEvaluation(int EvaluationId, int EvaluationUserId, int companyID, string Evaluationlocation, string CreatedBy)
        {
            return _evaluationDAL.InsertEvaluation( EvaluationId,  EvaluationUserId,  companyID,  Evaluationlocation,  CreatedBy);
        }

        public DataTable GetEvaluation(int EvaluationId, int EvaluationUserId, int companyID)
        {
            return _evaluationDAL.GetEvaluation(EvaluationId, EvaluationUserId, companyID);
        }

        public int DeleteEvaluation(int EvaluationId)
        {
            return _evaluationDAL.DeleteEvaluation(EvaluationId);
        }

        public DataTable GetUserEvaluation(int EvaluationUserId)
        {
            return _evaluationDAL.GetUserEvaluation(EvaluationUserId);
        }
    }
}
