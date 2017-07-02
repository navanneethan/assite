using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class TrainingVideoBL
    {
        TrainingVideoDAL _fileuploadsDAL = new TrainingVideoDAL();

        public int InsertTransaction(TrainingVideoModel fileuploadsModel)
        {
            return _fileuploadsDAL.InsertTrainingVideo(fileuploadsModel);
        }

        public DataTable GetTransactions(int transacationId, int userId, int companyId)
        {
            return _fileuploadsDAL.GetTrainingVideo(transacationId, userId, companyId);
        }

        public int DeleteTransactions(int transacationId)
        {
            return _fileuploadsDAL.DeleteTrainingVideo(transacationId);
        }
    }
}
