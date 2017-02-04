using AntiClockFitnessCentreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreBAL
{
    public class CommonBL
    {
        CommonDAL _CommonDAL = new CommonDAL();

        public int InsertException(string pageName, string methodName, string details, string user)
        {
            return _CommonDAL.InsertException(pageName, methodName, details, user);
        }
    }
}
