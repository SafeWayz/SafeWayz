using System;

namespace SafeWayz.Models
{
    public class Comment
    {
        public UserProfile UserWhoCommented { get; set; }
        public string UserComment { get; set; }
        public DateTime CommentDate { get; set; }
        public int CommentUpvotes { get; set; }

    }
}
