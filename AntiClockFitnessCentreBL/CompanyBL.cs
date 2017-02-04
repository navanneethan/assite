using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
     public class CompanyBL
    {
         CompanyDAL _companyDAL = new CompanyDAL();

         public int InsertCompany(int CompanyId, string CompanyName, string CompanyCode, string CompanyLogo, string CreatedBy)
        {
            return _companyDAL.InsertCompany(CompanyId, CompanyName,CompanyCode, CompanyLogo, CreatedBy);
        }

         public DataTable GetCompany()
        {
            return _companyDAL.GetCompany();
        }

        public int DeleteCompany(int CompanyId)
        {
            return _companyDAL.DeleteCompany(CompanyId);
        }
    }
}
