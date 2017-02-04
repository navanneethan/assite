using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class FileUploadsBL
    {
        FileUploadsDAL _fileuploadsDAL = new FileUploadsDAL();

        public int InsertTransaction(FileUploadsModel fileuploadsModel)
        {
            return _fileuploadsDAL.InsertTransaction(fileuploadsModel);
        }

        public DataTable GetTransactionType()
        {
            return _fileuploadsDAL.GetTransactionType();
        }

        public DataTable GetTransactions(int transacationId, int userId, int companyId)
        {
            return _fileuploadsDAL.GetTransactions(transacationId, userId, companyId);
        }

        public int DeleteTransactions(int transacationId)
        {
            return _fileuploadsDAL.DeleteTransactions(transacationId);
        }
    }
}
