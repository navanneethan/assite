using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreModal
{
    public class OpinionPollModal
    {
        public int pollId;
        public string pollQuestion;
        public string pollImage;
        public DateTime pollStartDate;
        public DateTime pollEndDate;
        public string PollCreatedBy;
        public int pollCompanyId;
    }

    public class OpinionPollOptionModal
    {
        public int pollOptionId;
        public int pollMasterId;
        public string pollOptionName;
        public string PollOptionCreatedBy;
    }
}
