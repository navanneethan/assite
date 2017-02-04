using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class CompanyDAL : MainDAL
    {
        public int InsertCompany(int CompanyId, string CompanyName,string CompanyCode, string CompanyLogo, string CreatedBy)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_COMPANY;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyId", CompanyId);
            _Paramaters.Add("CompanyName", CompanyName);
            _Paramaters.Add("CompanyCode", CompanyCode);
            _Paramaters.Add("CompanyLogo", CompanyLogo);            
            _Paramaters.Add("CreatedBy", CreatedBy);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.GetResultAsInteger();

            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("CompanyDAL", "InsertCompany-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
                _Result = -1;
            }
            return _Result;
        }

        public int DeleteCompany(int CompanyId)
        {
            _DBManager.CommandText = StoredProcedure.DELETE_COMPANY;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyId", CompanyId);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteDeleteCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("CompanyDAL", "DeleteCompany-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetCompany()
        {
            _DBManager.CommandText = StoredProcedure.GET_COMPANY;
           
            return _DBManager.SelectTable();
        } 
    }
}
