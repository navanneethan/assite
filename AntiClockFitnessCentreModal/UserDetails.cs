using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreModal
{
    public enum Roles
    {
        Admin = 1,
        Trainer = 2,
        Client = 3
    }

    public class UserDetails
    {
        public int userid;
        public string firstName = string.Empty;
        public string lastName = string.Empty;
        public string memberNumber = string.Empty;
        public int companyid;
        public string gender = string.Empty;
        public string phonenumber = string.Empty;
        public string username = string.Empty;
        public string password = string.Empty;
        public int roleid;
        public int trainerid;
        public string emailid = string.Empty;
        public int height = 0;
        public int weight = 0;
        public DateTime? dob = null;
        public DateTime? activetill = null;
        public string addressline1 = string.Empty;
        public string addressline2 = string.Empty;
        public string city = string.Empty;
        public string state = string.Empty;
        public string country = string.Empty;
        public bool status;
        public string goals = string.Empty;
        public string problem = string.Empty;
        public byte[] profileimage;

      
        public string createdby = string.Empty;
        
    }
}
