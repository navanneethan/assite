using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class CommonDAL : MainDAL
    {
        public int InsertException(string pageName, string methodName, string details, string user)
        {
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("Page", pageName);
            _Paramaters.Add("Method", methodName);
            _Paramaters.Add("Details", details);
            _Paramaters.Add("User", user);
            _DBManager.Parameters = _Paramaters;
            _DBManager.CommandText = StoredProcedure.INSERT_EXCEPTION_DETAILS;
            return _DBManager.ExecuteInsertCommand();
        }
    }
}
