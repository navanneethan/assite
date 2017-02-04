using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntiClockFitnessCentreModal
{
    public class MessageModal
    {
        public int postId;
        public int postFromId;
        public string postContent = string.Empty;
        public string postContentImage = string.Empty;
        public bool postLiked;
        public bool postcomment;
        public bool postStatus;
        public int PostcompanyId;

    }
    public class CommentModal
    {
        public int commentId;
        public int commentPostId;
        public int commentFromId;
        public string commentContent = string.Empty;
       
    }
    public class LikeModal
    {
        public int likeId;
        public int likePostId;
        public int likeFromId;
    }
}
