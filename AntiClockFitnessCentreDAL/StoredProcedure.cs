using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreDAL
{
    public static class StoredProcedure
    {
        public const string INSERT_EXCEPTION_DETAILS = "USP_INSERT_EXCEPTION_DETAILS";

        public const string VALIDATE_USER_DETAILS = "USP_VALIDATE_USER_DETAILS";
        public const string SELECT_ROLE_DETAILS = "USP_GET_ROLE_DETAILS";
        public const string INSERT_USER_DETAILS = "USP_INSERT_USER_DETAILS";
        public const string SELECT_USER_DETAILS = "USP_SELECT_USER_DETAILS";
        public const string GET_USER_DETAILS_BY_ROLE = "USP_GET_USER_DETAILS_BY_ROLE";
        public const string UPDATE_TRAINEE_DETAILS = "USP_UPDATE_TRAINEE";
        public const string UPDATE_TRAINEE_BY_TRAINER = "USP_UPDATE_TRAINEE_BY_TRAINER";
        public const string UPDATE_PASSWORD = "USP_UPDATE_PASSWORD";
        public const string SELECT_PASSWORD = "USP_SELECT_PASSWORD";
        public const string DELETE_USER_DETAILS = "USP_DELETE_USER_DETAILS";
        public const string GET_USER_DETAILS_COMPANY_ROLE = "USP_GET_USER_DETAILS_COMPANY_ROLE";
        public const string GET_MEMBER_NUMBER = "USP_GET_MEMBER_NUMBER";
       

        public const string SELECT_TRANSACTION_TYPE = "USP_SELECT_TRANSACTION_TYPE";
        public const string INSERT_TRANSACTIONS = "USP_INSERT_TRANSACTION";
        public const string SELECT_TRANSACTIONS = "USP_SELECT_TRANSACTION";
        public const string DELETE_TRANSACTIONS = "USP_DELETE_TRANSACTION";

        public const string INSERT_TRAINING_VIDEO = "USP_INSERT_TRAINING_VIDEO";
        public const string SELECT_TRAINING_VIDEO = "USP_SELECT_TRAINING_VIDEO";
        public const string DELETE_TRAINING_VIDEO = "USP_DELETE_TRAINING_VIDEO";

        public const string INSERT_SCHEDULE = "USP_INSERT_SCHEDULE";
        public const string SELECT_EXERCISE = "USP_SELECT_EXERCISE";
        public const string SELECT_SCHEDULE = "USP_SELECT_SCHEDULE";
        public const string GET_SCHEDULE = "USP_GET_SCHEDULE";
        public const string DELETE_SCHEDULE = "USP_DELETE_SCHEDULE";
        public const string INSERT_SCHEDULE_EVENT = "USP_INSERT_SCHEDULE_EVENTS";
        public const string GET_SCHEDULE_EVENT = "USP_GET_SCHEDULE_EVENTS";
        public const string DELETE_SCHEDULE_EVENT = "USP_DELETE_SCHEDULE_EVENTS";

        public const string SELECT_EVENT_DETAILS = "USP_GET_EVENT_DETAILS";
        public const string INSERT_EVENT_DETAILS = "USP_INSERT_EVENT_DETAILS";
        public const string UPDATE_EVENT_DETAILS = "USP_UPDATE_EVENT_DETAILS";

        public const string INSERT_POST = "USP_INSERT_POST";
        public const string INSERT_COMMENTS = "USP_INSERT_COMMENTS";
        public const string SELECT_POST = "USP_SELECT_POST";
        public const string SELECT_COMMENTS = "USP_SELECT_COMMENTS";
        public const string SELECT_LIKES_COUNT = "USP_SELECT_LIKES_COUNT";

        public const string GET_ACHIEVER_MASTER = "USP_GET_ACHIEVER_MASTER";
        public const string INSERT_ACHIEVER_MASTER = "USP_INSERT_ACHIEVER_MASTER";
        public const string DELETE_ACHIEVER_MASTER = "USP_DELETE_ACHIEVER_MASTER";


        public const string GET_ACHIEVER_DETAILS = "USP_GET_ACHIEVER_DETAILS";
        public const string INSERT_ACHIEVER_DETAILS = "USP_INSERT_ACHIEVER_DETAILS";
        public const string DELETE_ACHIEVER_DETAILS = "USP_DELETE_ACHIEVER_DETAILS";
        public const string GET_TOP_ACHIEVER_DETAILS = "USP_GET_TOP_ACHIEVER_DETAILS";

        public const string INSERT_POLL_MASTER = "USP_INSERT_POLL_MASTER";
        public const string DELETE_POLL_OPTIONS = "USP_DELETE_POLL_OPTIONS";
        public const string INSERT_POLL_OPTIONS = "USP_INSERT_POLL_OPTIONS";
        public const string GET_POLL_DETAILS = "USP_GET_POLL_DETAILS";
        public const string GET_POLL_CHART = "USP_GET_POLL_CHART";
       
        public const string DELETE_POLL_DETAILS = "USP_DELETE_POLL_DETAILS";
        public const string GET_TODAY_POLL_DETAILS = "USP_GET_POLLFOR_DAY";
        public const string GET_TODAY_POLL_OPTIONS = "USP_POLL_OPTIONS";
        public const string INSERT_POLL_USERS = "USP_INSERT_POLL_USERS";
        public const string GET_POLL_HISTORY = "USP_GET_POLLHISTORY";

        public const string INSERT_EVALUTION = "USP_INSERT_EVALUATION";
        public const string GET_EVALUTION = "USP_GET_EVALUATION";
        public const string DELETE_EVALUTION = "USP_DELETE_EVALUATION";
        public const string GET_USER_EVALUTION = "USP_GET_USER_EVALUATION";

        public const string INSERT_COMPANY = "USP_INSERT_COMPANY";
        public const string GET_COMPANY = "USP_GET_COMPANY";
        public const string DELETE_COMPANY = "USP_DELETE_COMPANY";

        public const string GET_NOTIFICATION_COUNT = "USP_GET_NOTIFICATION_COUNT";
        public const string GET_NOTIFICATION_DETAILS = "USP_GET_NOTIFICATION_DETAILS";
        public const string INSERT_NOTIFICATION_VIEWED = "USP_INSERT_NOTIFICATION_VIEWED";


        public const string GET_ORDER_ID = "USP_GET_ORDER_ID";
        public const string UPDATE_PAYMENT_DETAILS = "USP_UPDATE_PAYMENT_DETAILS";
    }
}
