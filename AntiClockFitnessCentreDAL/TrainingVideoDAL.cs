using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using System.Collections;
using System.Data;

namespace AntiClockFitnessCentreDAL
{
    public class TrainingVideoDAL : MainDAL
    {
        public int InsertTrainingVideo(TrainingVideoModel fileUploadmodel)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_TRAINING_VIDEO;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", fileUploadmodel.transactionId);
            _Paramaters.Add("UserId", fileUploadmodel.userid);
            _Paramaters.Add("TrasactionLocation", fileUploadmodel.transactionlocation);
            _Paramaters.Add("Status", fileUploadmodel.status);            
            _Paramaters.Add("CreatedBy", fileUploadmodel.createdby);
            _Paramaters.Add("TransactionCompanyId", fileUploadmodel.transactionComapnyId);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("TrainingVideoDAL", "InsertFileUpload-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;

        }

        public DataTable GetTrainingVideo(int transacationId, int userId,int companyId)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_TRAINING_VIDEO;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", transacationId);
            _Paramaters.Add("UserId", userId);
            _Paramaters.Add("CompanyId", companyId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int DeleteTrainingVideo(int transacationId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_TRAINING_VIDEO;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", transacationId);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("TrainingVideoDAL", "DeleteFileUpload-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

    }
}
