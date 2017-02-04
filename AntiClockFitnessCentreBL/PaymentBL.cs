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
            string currency, string resCode, string resMessage, string gateway, string bankName, string paymentMode,
            string checkSum, string months)
        {
            return _PaymentDAL.UpdatePaymentDetails(orderID, transID, bankTransID,
             currency, resCode, resMessage, gateway, bankName, paymentMode, checkSum, months);
        }
    }
}
