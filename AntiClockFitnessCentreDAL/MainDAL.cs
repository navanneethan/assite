using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public class MainDAL
    {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static string connStringProvider = ConfigurationManager.ConnectionStrings["ConnString"].ProviderName;
        public DBManager _DBManager = new DBManager();

        public MainDAL()
        {
            _DBManager.ConnectionString = connString;
            _DBManager.Provider = connStringProvider;
            _DBManager.CommandType = DBManager.DBCommandType.StoredProcedure;
            
        }
    }
}
