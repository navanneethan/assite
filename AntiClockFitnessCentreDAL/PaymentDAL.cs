using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class PaymentDAL : MainDAL
    {

        public DataTable GetOrderID(int userID,string amount)
        {
            _DBManager.CommandText = StoredProcedure.GET_ORDER_ID;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("UserID", userID);
            _Paramaters.Add("Amount", amount);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public int UpdatePaymentDetails(string orderID,string transID,string bankTransID,
            string resMessage,string bankName,string paymentMode,
            string checkSum,string months,string status)
        {
            _DBManager.CommandText = StoredProcedure.UPDATE_PAYMENT_DETAILS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("ORDERID", orderID);
            _Paramaters.Add("TransID", transID);
            _Paramaters.Add("BankTransID", bankTransID);
            _Paramaters.Add("ResMessage", resMessage);
            _Paramaters.Add("BankName", bankName);
            _Paramaters.Add("PaymentMode", paymentMode);
            _Paramaters.Add("CheckSum", checkSum);
            _Paramaters.Add("Months", months);
            _Paramaters.Add("Status", status);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteUpdateCommand();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("PaymentDAL", "ForgetPassword-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;

        }

        //public DataTable  
    }
}
