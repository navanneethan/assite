using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using System.Collections;
using System.Data;

namespace AntiClockFitnessCentreDAL
{
    public class FileUploadsDAL :MainDAL
    {
        public int InsertTransaction(FileUploadsModel fileUploadmodel)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_TRANSACTIONS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", fileUploadmodel.transactionId);
            _Paramaters.Add("UserId", fileUploadmodel.userid);
            _Paramaters.Add("TransactionType", fileUploadmodel.transactiontypeid);
            _Paramaters.Add("TrasactionLocation", fileUploadmodel.transactionlocation);
            _Paramaters.Add("Status", fileUploadmodel.status);            
            _Paramaters.Add("CreatedBy", fileUploadmodel.createdby);
            _Paramaters.Add("TransactionCompanyId", fileUploadmodel.transactionComapnyId);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("FileUploadDAL", "InsertFileUpload-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;

        }



        public DataTable GetTransactionType()
        {
            _DBManager.CommandText = StoredProcedure.SELECT_TRANSACTION_TYPE;
            return _DBManager.SelectTable();
        }

        public DataTable GetTransactions(int transacationId, int userId,int companyId)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_TRANSACTIONS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", transacationId);
            _Paramaters.Add("UserId", userId);
            _Paramaters.Add("CompanyId", companyId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int DeleteTransactions(int transacationId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_TRANSACTIONS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("TransationId", transacationId);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("FileUploadDAL", "DeleteFileUpload-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

    }
}
