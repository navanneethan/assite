using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class PaymentBL
    {
        PaymentDAL _PaymentDAL = new PaymentDAL();

        public DataTable GetOrderID(int userID, string amount)
        {
            return _PaymentDAL.GetOrderID(userID, amount);
        }

        public int UpdatePaymentDetails(string orderID, string transID, string bankTransID,
            string resMessage, string bankName, string paymentMode,
            string checkSum, string months, string status)
        {
            return _PaymentDAL.UpdatePaymentDetails(orderID, transID, bankTransID,
             resMessage, bankName, paymentMode, checkSum, months, status);
        }
    }
}
