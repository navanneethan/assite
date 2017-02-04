using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using System.Collections;
using System.Data;

namespace AntiClockFitnessCentreDAL
{
    public class MessageDAL : MainDAL
    {
        public int InsertPost(MessageModal messagemodal)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_POST;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PostId", messagemodal.postId);
            _Paramaters.Add("PostFromId", messagemodal.postFromId);
            _Paramaters.Add("PostContent", messagemodal.postContent);
            _Paramaters.Add("PostContentImage", messagemodal.postContentImage);
            _Paramaters.Add("PostCompanyId", messagemodal.PostcompanyId);
           
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("MessageDAL", "InsertPost-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }
        public int InsertComment(CommentModal commentmodal)
        {
            _DBManager.CommandText = StoredProcedure.INSERT_COMMENTS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CommentId", commentmodal.commentId);
            _Paramaters.Add("CommentFromId", commentmodal.commentFromId);
            _Paramaters.Add("CommentPostId", commentmodal.commentPostId);
            _Paramaters.Add("CommentContent", commentmodal.commentContent);
            //_Paramaters.Add("PostCreatedBy", messagemodal.);

            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.ExecuteInsertCommand();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("MessageDAL", "InsertComment-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }

        public DataTable GetPost(int CompanyId)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_POST;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("CompanyId", CompanyId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }

        public DataTable GetComment(int postId)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_COMMENTS;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PostId", postId);
            _DBManager.Parameters = _Paramaters;
            return _DBManager.SelectTable();
        }
        public int GetLikeCount(int postId, int userId, bool isView)
        {
            _DBManager.CommandText = StoredProcedure.SELECT_LIKES_COUNT;
            Hashtable _Paramaters = new Hashtable();
            _Paramaters.Add("PostId", postId);
            _Paramaters.Add("UserId", userId);
            _Paramaters.Add("IsView", isView);
            _DBManager.Parameters = _Paramaters;
            int _Result = _DBManager.GetResultAsInteger();
            if (_Result == -1)
            {
                CommonDAL _CommonDAL = new CommonDAL();
                _CommonDAL.InsertException("MessageDAL", "GetLikeCount-exc", _DBManager.exceptionMessage.Message + "-" + _DBManager.exceptionMessage.StackTrace, "User");
            }
            return _Result;
        }
    }
}
