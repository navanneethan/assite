using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntiClockFitnessCentreModal;
using AntiClockFitnessCentreDAL;
using System.Data;

namespace AntiClockFitnessCentreBAL
{
    public class MessageBL
    {
        MessageDAL _messageDAL = new MessageDAL();

        public int InsertPost(MessageModal messageModal)
        {
            return _messageDAL.InsertPost(messageModal);
        }

        public int InsertComment(CommentModal commentModal)
        {
            return _messageDAL.InsertComment(commentModal);
        }

        public DataTable GetPost(int CompanyId)
        {
            return _messageDAL.GetPost(CompanyId);
        }

        public DataTable GetComment(int postId)
        {
            return _messageDAL.GetComment(postId);
        }

        public int GetLikeCount(int postId, int userId, bool isView)
        {
            return _messageDAL.GetLikeCount(postId, userId, isView);
        }
    }
}
