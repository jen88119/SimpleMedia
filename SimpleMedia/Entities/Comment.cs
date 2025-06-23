using System;
using System.Collections.Generic;

namespace SimpleMedia.Entities
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string UserID { get; set; } = null!;
        public int PostID { get; set; }
        public string Content { get; set; } = null!;
        public DateTime LastMaintainDt { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
